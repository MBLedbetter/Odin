using Odin.DbTableModels;
using OdinModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows;

namespace Odin.Data
{
    public class ItemRepository : IItemRepository
    {
        #region Fields
        
        private readonly IOdinContextFactory contextFactory;

        #endregion // Fields

        #region Properties

        /// <summary>
        ///     Gets or sets the save progress value. Used to display progress of item saves.
        /// </summary>
        public string SaveProgress
        {
            get
            {
                return _saveProgress;
            }
            set
            {
                _saveProgress = value;
            }
        }
        private string _saveProgress = string.Empty;

        #endregion // Properties

        #region Public Methods
        
        /// <summary>
        ///     Retrieves Matching Category Ids for category values and combines for DB field insertion
        /// </summary>
        /// <param name="value1">category</param>
        /// <param name="value2">category 2</param>
        /// <param name="value3">category 3</param>
        /// <returns></returns>
        public string CombineCategories(string value1, string value2, string value3)
        {
            string returnValue = "";
            if (!string.IsNullOrEmpty(value1)) { returnValue += RetrieveWebCategoryCodeByName(value1) + ","; }
            if (!string.IsNullOrEmpty(value2)) { returnValue += RetrieveWebCategoryCodeByName(value2) + ","; }
            if (!string.IsNullOrEmpty(value3)) { returnValue += RetrieveWebCategoryCodeByName(value3) + ","; }

            if (returnValue != "")
            {
                returnValue = returnValue.Remove(returnValue.Length - 1);
            }

            return returnValue;
        }

        #region Public Insert Methods

        /// <summary>
        ///     Inserts item information into all item tables
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public void InsertAll(ItemObject item, int count)
        {
            if (item.Status == "Add" || item.CheckUpdates())
            {
                using (OdinContext context = this.contextFactory.CreateContext())
                {
                    if (item.Status == "Add")
                    {
                        InsertAssetItemAttr(item, context);
                        InsertBuItemsConfigAll(item, context);
                        InsertBuItemsInvAll(item, context);
                        InsertBuItemUtilCdAll(item, context);
                        InsertCmItemMethodAll(item, context);
                        InsertCustomerProductAttributesAll(item, context);
                        InsertDefaultLocInvAll(item, context);
                        InsertEcommerceValues(item, context);
                        InsertFxdBinLocInvAll(item, context);
                        InsertInvItems(item, context);
                        InsertInvItemUom(item, context);
                        InsertItemAttribEx(item, context);
                        InsertItemCompliance(item, context);
                        InsertItemLanguageAll(item);
                        InsertItemTerritoryAll(item);
                        InsertItemWebInfo(item, context);
                        InsertMasterItemTbl(item, context);
                        InsertPlItemAttribAll(item, context);
                        InsertProdItem(item, context);
                        InsertProdPgrpLnkAll(item, context);
                        InsertProdPriceAll(item, context);
                        InsertProdPriceBuAll(item, context);
                        InsertProdUom(item, context);
                        InsertPurchItemAttr(item, context);
                        InsertPvItmCategory(item, context);
                        InsertUomTypeInvAll(item, context);

                        if (item.ProductIdTranslation.Count > 0)
                        {
                            InsertProductIdTranslationAll(item, context);
                        }
                        if (item.BillOfMaterials.Count > 0)
                        {
                            InsertEnBomCompsAll(item);
                            InsertEnBomHeader(item, context);
                            InsertEnBomOutputs(item, context);
                            InsertSfPrdnAreaIt(item, context);
                        }
                        InsertItemUpdateRecord(item, context);
                    }
                    else if (item.CheckUpdates())
                    {
                        if (item.BuItemsInvUpdate()) { UpdateBuItemsInvAll(item, context); }
                        if (item.CmItemMethodUpdate()) { UpdateCmItemMethodAll(item, context); }
                        if (item.SellOnFlagUpdate()) { UpdateCustomerProductAttributesAll(item, context); }
                        if (item.EcommerceValuesUpdate()) { UpdateEcommerceValues(item, context); }
                        if (item.FxdBinLocInvUpdate()) { UpdateFxdBinLocInvAll(item); }
                        if (item.InvItemsUpdate()) { UpdateInvItems(item, context); }
                        if (item.ItemAttribExUpdate()) { UpdateItemAttribEx(item, context); }
                        if (item.ItemLanguageUpdate()) { InsertItemLanguageAll(item); }
                        if (item.ItemTerritoryUpdate()) { InsertItemTerritoryAll(item); }
                        if (item.ItemWebInfoUpdate()) { UpdateItemWebInfo(item, context); }
                        if (item.MasterItemUpdate()) { UpdateMasterItemTbl(item, context); }
                        if (item.ProdItemUpdate()) { UpdateProdItem(item, context); }
                        if (item.ProdPgrpLnkUpdate()) { UpdateProdPgrpLnkAll(item); }
                        if (item.ProdPriceUpdate()) { UpdateProdPriceAll(item, context); }
                        if (item.ProdPriceBuUpdate()) { UpdateProdPriceBuAll(item, context); }
                        if (item.PurchItemAttrUpdate()) { UpdatePurchItemAttr(item, context); }
                        if (item.PvItmCategoryUpdate()) { UpdatePvItmCategory(item); }

                        if (item.ProductIdTranslationUpdate)
                        {
                            // === Removed Circa 8/15/2018 ===
                            // RemoveMarketplaceProductTranslationsAll(item, context);
                            // InsertProductIdTranslationAll(item, context);
                        }
                        if (item.BillOfMaterialsUpdate)
                        {
                            RemoveEnBomCompsAll(item.ItemId);
                            InsertEnBomCompsAll(item);
                            InsertEnBomHeader(item, context);
                            InsertEnBomOutputs(item, context);
                            InsertSfPrdnAreaIt(item, context);
                        }
                        InsertItemUpdateRecord(item, context);
                    }
                    context.SaveChanges();
                    this.SaveProgress = count.ToString();
                }
            }
        }

        /// <summary>
        ///     Inserts item info into PS_ASSET_ITEM_ATTR.
        /// </summary>
        public void InsertAssetItemAttr(ItemObject item, OdinContext context)
        {
            if (!context.AssetItemAttr.Any(o => o.InvItemId == item.ItemId))
            {
                context.AssetItemAttr.Add(new AssetItemAttr
                {
                    Setid = "SHARE",
                    InvItemId = item.ItemId,
                    ProfileId = ""
                });
            }
        }

        /// <summary>
        ///     Runs InsertBuItemsConfig for each business Unit
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        public void InsertBuItemsConfigAll(ItemObject item, OdinContext context)
        {
            InsertBuItemsConfig(item, "TRUS1", context);
            InsertBuItemsConfig(item, "TRCN1", context);
        }
        
        /// <summary>
        ///     Runs InsertBuItemsInv for each business Unit
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        public void InsertBuItemsInvAll(ItemObject item, OdinContext context)
        {
            InsertBuItemsInv(item, "TRMX1", item.DefaultActualCostUsd, context);
            InsertBuItemsInv(item, "TRUS1", item.DefaultActualCostUsd, context);
            InsertBuItemsInv(item, "TRCN1", item.DefaultActualCostCad, context);
        }

        /// <summary>
        ///     Runs InsertBuItemUtilCd for each business Unit type
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void InsertBuItemUtilCdAll(ItemObject item, OdinContext context)
        {
            InsertBuItemUtilCd(item, "TRUS1", context);
            InsertBuItemUtilCd(item, "TRCN1", context);
        }

        /// <summary>
        ///     Inserts New Category into table
        /// </summary>
        /// <param name="category"></param>
        public void InsertCategory(string category)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if (!context.OdinNewWebCategories.Any(o => o.Category == category))
                {
                    context.OdinNewWebCategories.Add(new OdinNewWebCategories
                    {
                        Category = category,
                        OldId = 0
                    });
                    context.SaveChanges();
                }

            }
        }

        /// <summary>
        ///     Runs InsertCmItemMethod for each business Unit
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void InsertCmItemMethodAll(ItemObject item, OdinContext context)
        {
            InsertCmItemMethod(item, "TRUS1", context);
            InsertCmItemMethod(item, "TRCN1", context);
        }

        /// <summary>
        ///     Runs InsertCustomerProductAttributes for each customer
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public void InsertCustomerProductAttributesAll(ItemObject item, OdinContext context)
        {
            InsertCustomerProductAttributes(item.ItemId, RetrieveCustomerId("ALL POSTERS"), item.SellOnAllPosters, context) ;
            InsertCustomerProductAttributes(item.ItemId, RetrieveCustomerId("AMAZON"), item.SellOnAmazon, context) ;
            InsertCustomerProductAttributes(item.ItemId, RetrieveCustomerId("FANATICS"), item.SellOnFanatics, context);
            InsertCustomerProductAttributes(item.ItemId, RetrieveCustomerId("GUITAR CENTER"), item.SellOnGuitarCenter, context);
            InsertCustomerProductAttributes(item.ItemId, RetrieveCustomerId("HAYNEEDLE"), item.SellOnHayneedle, context) ;
            InsertCustomerProductAttributes(item.ItemId, RetrieveCustomerId("TARGET"), item.SellOnTarget, context);
            InsertCustomerProductAttributes(item.ItemId, RetrieveCustomerId("WALMART"), item.SellOnWalmart, context) ;
            InsertCustomerProductAttributes(item.ItemId, RetrieveCustomerId("WAYFAIR"), item.SellOnWayfair, context);            
        }
        
        /// <summary>
        /// Runs InsertDefaultLocInvAll for each business Unit
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        public void InsertDefaultLocInvAll(ItemObject item, OdinContext context)
        {
            InsertDefaultLocInv(item, "TRUS1", context);
            InsertDefaultLocInv(item, "TRCN1", context);
        }

        /// <summary>
        ///     Insert Ecommerce Value into Database
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        public void InsertEcommerceValues(ItemObject item, OdinContext context)
        {
            if (!context.AmazonItemAttributes.Any(o => o.InvItemId == item.ItemId))
            {
                string cost = (!string.IsNullOrEmpty(item.Ecommerce_Cost)) ? item.Ecommerce_Cost : "0";
                string height = (!string.IsNullOrEmpty(item.Ecommerce_ItemHeight)) ? item.Ecommerce_ItemHeight : "0";
                string length = (!string.IsNullOrEmpty(item.Ecommerce_ItemLength)) ? item.Ecommerce_ItemLength : "0";
                string weight = (!string.IsNullOrEmpty(item.Ecommerce_ItemWeight)) ? item.Ecommerce_ItemWeight : "0";
                string width = (!string.IsNullOrEmpty(item.Ecommerce_ItemWidth)) ? item.Ecommerce_ItemWidth : "0";
                string packageHeight = (!string.IsNullOrEmpty(item.Ecommerce_PackageHeight)) ? item.Ecommerce_PackageHeight : "0";
                string packageLength = (!string.IsNullOrEmpty(item.Ecommerce_PackageLength)) ? item.Ecommerce_PackageLength : "0";
                string packageWeight = (!string.IsNullOrEmpty(item.Ecommerce_PackageWeight)) ? item.Ecommerce_PackageWeight : "0";
                string packageWidth = (!string.IsNullOrEmpty(item.Ecommerce_PackageWidth)) ? item.Ecommerce_PackageWidth : "0";
                string pageQty = (!string.IsNullOrEmpty(item.Ecommerce_PageQty)) ? item.Ecommerce_PageQty : "0";
                string msrp = (!string.IsNullOrEmpty(item.Ecommerce_Msrp)) ? item.Ecommerce_Msrp : "0";

                context.AmazonItemAttributes.Add(new AmazonItemAttributes
                {
                    Asin = item.Ecommerce_Asin,
                    Bullet1 = item.Ecommerce_Bullet1,
                    Bullet2 = item.Ecommerce_Bullet2,
                    Bullet3 = item.Ecommerce_Bullet3,
                    Bullet4 = item.Ecommerce_Bullet4,
                    Bullet5 = item.Ecommerce_Bullet5,
                    Components = item.Ecommerce_Components,
                    Cost = Convert.ToDecimal(cost),
                    CountryOfOrigin = item.Ecommerce_CountryofOrigin,
                    ExternalId = item.Ecommerce_ExternalId,
                    ExternalIdType = item.Ecommerce_ExternalIdType,
                    ImageUrl1 = item.Ecommerce_ImagePath1,
                    ImageUrl2 = item.Ecommerce_ImagePath2,
                    ImageUrl3 = item.Ecommerce_ImagePath3,
                    ImageUrl4 = item.Ecommerce_ImagePath4,
                    ImageUrl5 = item.Ecommerce_ImagePath5,
                    Height = Convert.ToDecimal(height),
                    InvItemId = item.ItemId,
                    ItemName = item.Ecommerce_ItemName,
                    Length = Convert.ToDecimal(length),
                    Weight = Convert.ToDecimal(weight),
                    Width = Convert.ToDecimal(width),
                    ModelName = item.Ecommerce_ModelName,
                    PackageHeight = Convert.ToDecimal(packageHeight),
                    PackageLength = Convert.ToDecimal(packageLength),
                    PackageWeight = Convert.ToDecimal(packageWeight),
                    PackageWidth = Convert.ToDecimal(packageWidth),
                    PageCount = Convert.ToInt16(pageQty),
                    ProductCategory = item.Ecommerce_ProductCategory,
                    FullDescription = item.Ecommerce_ProductDescription,
                    ProductSubcategory = item.Ecommerce_ProductSubcategory,
                    ManufacturerName = item.Ecommerce_ManufacturerName,
                    Msrp = Convert.ToDecimal(msrp),
                    SearchTerms = item.Ecommerce_SearchTerms.ToLower(),
                    Size = item.Ecommerce_Size,
                    UpcOverride = item.Ecommerce_Upc
                });
            }
        }

        /// <summary>
        ///     Insert Bill of material record into PS_EN_BOM_HEADER
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        public void InsertEnBomHeader(ItemObject item, OdinContext context)
        {
            if (!context.EnBomHeader.Any(o => o.InvItemId == item.ItemId))
            {
                context.EnBomHeader.Add(new EnBomHeader
                {
                    BomCode = 1,
                    BomState = "PR",
                    BomType = "PR",
                    BomQty = 1,
                    BusinessUnit = "TRUS1",
                    Descr = DbUtil.Char30(item.Description).ToUpper(),
                    Descrshort = DbUtil.Char10(item.Description).ToUpper(),
                    InvItemId = item.ItemId,
                    Text254 = ""
                });
            }
        }

        /// <summary>
        ///     Insert Bill of material record into PS_EN_BOM_OUTPUTS
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        public void InsertEnBomOutputs(ItemObject item, OdinContext context)
        {
            if (!context.EnBomOutputs.Any(o => o.InvItemId == item.ItemId && o.BusinessUnit == "TRUS1"))
            {
                context.EnBomOutputs.Add(new EnBomOutputs
                {
                    BomCode = 1,
                    BomState = "PR",
                    BomType = "PR",
                    BusinessUnit = "TRUS1",
                    DateInEffect = new DateTime(1901, 01, 01, 0, 0, 0),
                    DateObsolete = new DateTime(2099, 12, 31, 0, 0, 0),
                    IncrRelOffset = 0.0000M,
                    IncrRelType = "1",
                    InvItemId = item.ItemId,
                    MgOutputCostPct = 100,
                    MgOutputItem = item.ItemId,
                    MgOutputQty = 1.0000M,
                    MgOutputQtyCode = "ASY",
                    MgOutputResPct = 100,
                    MgOutputType = "CP",
                    OpSequence = 0
                });
            }
        }

        /// <summary>
        ///     Runs InsertEnBomComps for each bill of materials child
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        public void InsertEnBomCompsAll(ItemObject item)
        {
            using (OdinContext context1 = this.contextFactory.CreateContext())
            {
                foreach (ChildElement child in item.BillOfMaterials)
                {
                    InsertEnBomComps(item, child.ItemId, child.Qty, context1);
                }
                context1.SaveChanges();
            }
        }

        /// <summary>
        ///     Runs InsertFxdBinLocInv for each business Unit
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void InsertFxdBinLocInvAll(ItemObject item, OdinContext context)
        {
            InsertFxdBinLocInv(item, "TRUS1", context);
            InsertFxdBinLocInv(item, "TRCN1", context);
        }

        /// <summary>
        /// Insert item info(TariffCode, ItemColor, ItemHeight, ItemLength, ItemId, Description, ItemWeight, ItemWidth, Upc) and username to PS_INV_ITEMS
        /// </summary>
        public void InsertInvItems(ItemObject item, OdinContext context)
        {
            if (!context.InvItems.Any(o => o.InvItemId == item.ItemId && o.Setid == "SHARE"))
            {
                context.InvItems.Add(new InvItems
                {
                    AvailLeadTime = 0,
                    AvailStatus = "",
                    ChargeCode = "",
                    ChargeMarkupAmt = 0,
                    ChargeMarkupPcnt = 0,
                    CommodityCd = "",
                    CommodityCdEu = "",
                    ConsumableFlg = "N",
                    CurrencyCd = "",
                    Descr254 = item.Description.ToUpper(),
                    DisposableFlag = "N",
                    Effdt = Convert.ToDateTime("1901-01-01"),
                    HarmonizedCd = item.TariffCode,
                    HazClassCd = "",
                    IntlHazardId = "",
                    InvItemColor = item.Color,
                    InvItemHeight = Convert.ToDecimal(item.Height),
                    InvItemId = item.ItemId,
                    InvItemLength = Convert.ToDecimal(item.Length),
                    InvItemSize = "",
                    InvItemTemplate = "",
                    InvItemType = "",
                    InvItemVolume = 0,
                    InvItemWeight = Convert.ToDecimal(item.Weight),
                    InvItemWidth = Convert.ToDecimal(item.Width),
                    InvProdGrade = "",
                    InvStockType = "",
                    LastDttmUpdate = DateTime.Now,
                    LastMaintOprid = GlobalData.UserName,
                    MaxCapacity = 0,
                    MsdsId = "",
                    PackingCd = "",
                    PotencyRating = "",
                    RecomHumidityPct = 0,
                    RecomStorTemp = 0,
                    RecycleFlag = "N",
                    RetestLeadTime = 0,
                    ReturnableFlg = "N",
                    ReusableFlag = "N",
                    ServiceExchAmt = 0,
                    ServicePrice = 0,
                    ServiceableFlg = "N",
                    Setid = "SHARE",
                    ShelfLife = 0,
                    ShipTypeId = "",
                    StorRulesId = "",
                    UnitMeasureDim = "IN",
                    UnitMeasureTemp = "",
                    UnitMeasureVol = "",
                    UnitMeasureWt = "LB",
                    UpcId = item.Upc
                });
            }
        }

        /// <summary>
        /// Insert item info(item Id) and username to table PS_INV_ITEM_UOM
        /// </summary>
        public void InsertInvItemUom(ItemObject item, OdinContext context)
        {
            if (!context.InvItemUom.Any(o => o.InvItemId == item.ItemId && o.UnitOfMeasure == "EA" && o.Setid == "SHARE"))
            {
                context.InvItemUom.Add(new InvItemUom
                {
                    Setid = "SHARE",
                    InvItemId = item.ItemId,
                    UnitOfMeasure = "EA",
                    ConversionRate = 1,
                    QtyPrecision = "W",
                    RoundRule = "N",
                    DfltUomStock = "Y",
                    LastDttmUpdate = DateTime.Now,
                    LastMaintOprid = GlobalData.UserName,
                    PackingWeight = 0,
                    PackingVolume = 0,
                    ShippingWeight = 0,
                    ShippingVolume = 0,
                    UnitMeasureWt = "",
                    UnitMeasureVol = "",
                    PackingCd = "",
                    PackagingCd = "",
                    ContainerType = ""
                });

            }
        }

        /// <summary>
        ///     Insert item info into table PS_ITEM_ATTRIB_EX
        /// </summary>
        public void InsertItemAttribEx(ItemObject item, OdinContext context)
        {
            if (!context.ItemAttribEx.Any(o => o.InvItemId == item.ItemId && o.Setid == "SHARE"))
            {
                DateTime licenseBeginDate = !(string.IsNullOrEmpty(item.LicenseBeginDate)) ? Convert.ToDateTime(item.LicenseBeginDate) : new DateTime(1900, 01, 01);
                context.ItemAttribEx.Add(new ItemAttribEx
                {
                    AltImageFile1 = item.AltImageFile1,
                    AltImageFile2 = item.AltImageFile2,
                    AltImageFile3 = item.AltImageFile3,
                    AltImageFile4 = item.AltImageFile4,
                    BoxItemGroup = "",
                    CasepackHeight = DbUtil.ToDecimal(item.CasepackHeight),
                    CasepackLength = DbUtil.ToDecimal(item.CasepackLength),
                    CasepackQty = Convert.ToInt16(item.CasepackQty),
                    CasepackUpc = item.CasepackUpc,
                    CasepackWidth = DbUtil.ToDecimal(item.CasepackWidth),
                    CasepackWeight = DbUtil.ToDecimal(item.CasepackWeight),
                    DirectImport = item.DirectImport,
                    Duty = item.Duty,
                    Gtin = "",
                    ImageFileName = item.ImagePath,
                    InnerpackHeight = DbUtil.ToDecimal(item.InnerpackHeight),
                    InnerpackLength = DbUtil.ToDecimal(item.InnerpackLength),
                    InnerpackQty = DbUtil.ToShort(item.InnerpackQuantity),
                    InnerpackUpc = item.InnerpackUpc,
                    InnerpackWeight = DbUtil.ToDecimal(item.InnerpackWeight),
                    InnerpackWidth = DbUtil.ToDecimal(item.InnerpackWidth),
                    InvItemId = item.ItemId,
                    LicenseBeginDate = Convert.ToDateTime(licenseBeginDate),
                    PrintOnDemand = item.PrintOnDemand,
                    ProdFormat = item.ProductFormat,
                    ProdGroup = item.ProductGroup,
                    ProdLine = item.ProductLine,
                    SatCode = item.SatCode,
                    SellOnWeb = item.SellOnTrends,
                    Setid = "SHARE",
                    TranslateEdiProd = item.ReturnTranslateEdiProd(),
                    WebsitePrice = DbUtil.ToDecimal(item.WebsitePrice)
                });
            }
        }

        /// <summary>
        /// Insert item info into table PS_ITEM_COMPLIANCE
        /// </summary>
        public void InsertItemCompliance(ItemObject item, OdinContext context)
        {
            if (!context.ItemCompliance.Any(o => o.InvItemId == item.ItemId && o.Setid == "SHARE"))
            {
                context.ItemCompliance.Add(new ItemCompliance
                {
                    InvItemId = item.ItemId,
                    Prop65Compliant = "N",
                    Setid = "SHARE"
                });
            }
        }

        /// <summary>
        ///     Removes existing langage values and runs InsertItemLanguage for each language code in the language field
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void InsertItemLanguageAll(ItemObject item)
        {
            using (OdinContext context1 = this.contextFactory.CreateContext())
            {
                RemoveItemLanguageAll(item, context1);
                context1.SaveChanges();
            }

            using (OdinContext context2 = this.contextFactory.CreateContext())
            {
                if (!string.IsNullOrEmpty(item.Language))
                {
                    string[] languageCodes = item.Language.Split('/');
                    foreach (string code in languageCodes)
                    {
                        InsertItemLanguage(item, code, context2);
                    }
                }
                context2.SaveChanges();
            }
        }

        /// <summary>
        ///     Removes existing territory values and runs InsertItemTerritory for each territory code in the territory field
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void InsertItemTerritoryAll(ItemObject item)
        {
            using (OdinContext context1 = this.contextFactory.CreateContext())
            {
                RemoveItemTerritoryAll(item, context1);
                context1.SaveChanges();
            }

            using (OdinContext context2 = this.contextFactory.CreateContext())
            {
                if (!string.IsNullOrEmpty(item.Territory))
                {
                    string[] territories = item.Territory.Split('/');
                    foreach (string code in territories)
                    {
                        InsertItemTerritory(item, code, context2);
                    }
                }
                context2.SaveChanges();
            }            
        }

        /// <summary>
        ///     Inserts item infor into ODIN_ITEM_UPDATE_RECORDS
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public void InsertItemUpdateRecord(ItemObject item, OdinContext context)
        {
            context.OdinItemUpdateRecords.Add(new OdinItemUpdateRecords
            {
                InvItemId = item.ItemId,
                ItemInputStatus = item.Status,
                InputDate = DateTime.Now,
                Username = GlobalData.UserName,
                AccountingGroup = item.AccountingGroup,
                AltImageFile1 = item.AltImageFile1,
                AltImageFile2 = item.AltImageFile2,
                AltImageFile3 = item.AltImageFile3,
                AltImageFile4 = item.AltImageFile4,
                BillOfMaterials = item.ReturnBillOfMaterials(),
                CasepackHeight = item.CasepackHeight,
                CasepackLength = item.CasepackLength,
                CasepackQty = item.CasepackQty,
                CasepackUpc = item.CasepackUpc,
                CasepackWidth = item.CasepackWidth,
                CasepackWeight = item.CasepackWeight,
                Category = item.Category,
                Category2 = item.Category2,
                Category3 = item.Category3,
                Color = item.Color,
                Copyright = item.Copyright,
                CountryOfOrigin = item.CountryOfOrigin,
                CostProfileGroup = item.CostProfileGroup,
                DefaultActualCostUsd = item.DefaultActualCostUsd,
                DefaultActualCostCad = item.DefaultActualCostCad,
                Description = item.Description,
                DirectImport = item.DirectImport,
                Duty = item.Duty,
                Ean = item.Ean,
                Fplcanl1 = "",
                Fplusl1 = "",
                Gpc = item.Gpc,
                Height = item.Height,
                ImageFileName = item.ImagePath,
                ImagePath = item.ImagePath,
                InnerpackHeight = item.InnerpackHeight,
                InnerpackLength = item.InnerpackLength,
                InnerpackQty = item.InnerpackQuantity,
                InnerpackUpc = item.InnerpackUpc,
                InnerpackWidth = item.InnerpackWidth,
                InnerpackWeight = item.InnerpackWeight,
                InStockDate = item.InStockDate,
                Isbn = item.Isbn,
                ItemCategory = item.ItemCategory,
                ItemFamily = item.ItemFamily,
                ItemGroup = item.ItemGroup,
                ItemKeywords = item.ItemKeywords,
                Language = item.Language,
                Length = item.Length,
                License = item.License,
                LicenseBeginDate = item.LicenseBeginDate,
                ListPriceCad = item.ListPriceCad,
                ListPriceUsd = item.ListPriceUsd,
                ListPriceMxn = item.ListPriceMxn,
                MetaDescription = item.MetaDescription,
                MfgSource = item.MfgSource,
                Msrp = item.Msrp,
                MsrpCad = item.MsrpCad,
                MsrpMxn = item.MsrpMxn,
                ProductFormat = item.ProductFormat,
                ProductGroup = item.ProductGroup,
                ProductIdTranslation = item.ReturnProductIdTranslations(),
                ProductLine = item.ProductLine,
                ProdQty = item.ProductQty,
                PricingGroup = item.PricingGroup,
                PrintOnDemand = item.PrintOnDemand,
                PsStatus = item.PsStatus,
                Property = item.Property,
                SatCode = item.SatCode,
                ShortDesc = item.ShortDescription,
                SellOnAllposters = item.SellOnAllPosters,
                SellOnFanatics = item.SellOnFanatics,
                SellOnGuitarCenter = item.SellOnGuitarCenter,
                SellOnHayneedle = item.SellOnHayneedle,
                SellOnTarget = item.SellOnTarget,
                SellOnWeb = item.SellOnTrends,
                SellOnWalmart = item.SellOnWalmart,
                SellOnWayfair = item.SellOnWayfair,
                SellOnJet = "",
                Size = item.Size,
                StandardCost = item.StandardCost,
                StatsCode = item.StatsCode,
                TariffCode = item.TariffCode,
                Territory = item.Territory,
                Title = item.Title,
                Udex = item.Udex,
                Upc = item.Upc,
                WebsitePrice = item.WebsitePrice,
                Weight = item.Weight,
                Width = item.Width,
                AAmazonActive = item.SellOnAmazon,
                AAsin = item.Ecommerce_Asin,
                ABullet1 = item.Ecommerce_Bullet1,
                ABullet2 = item.Ecommerce_Bullet2,
                ABullet3 = item.Ecommerce_Bullet3,
                ABullet4 = item.Ecommerce_Bullet4,
                ABullet5 = item.Ecommerce_Bullet5,
                AComponents = item.Ecommerce_Components,
                ACost = item.Ecommerce_Cost,
                AExternalIdType = item.Ecommerce_ExternalIdType,
                AExternalId = item.Ecommerce_ExternalId,
                AImageUrl1 = item.Ecommerce_ImagePath1,
                AImageUrl2 = item.Ecommerce_ImagePath2,
                AImageUrl3 = item.Ecommerce_ImagePath3,
                AImageUrl4 = item.Ecommerce_ImagePath4,
                AImageUrl5 = item.Ecommerce_ImagePath5,
                AItemHeight = item.Ecommerce_ItemHeight,
                AItemLength = item.Ecommerce_ItemLength,
                AItemName = item.Ecommerce_ItemName,
                AItemWeight = item.Ecommerce_ItemWeight,
                AItemWidth = item.Ecommerce_ItemWidth,
                AModelName = item.Ecommerce_ModelName,
                APackageLength = item.Ecommerce_PackageLength,
                APackageHeight = item.Ecommerce_PackageHeight,
                APackageWidth = item.Ecommerce_PackageWidth,
                APageQty = item.Ecommerce_PageQty,
                APackageWeight = item.Ecommerce_PackageWeight,
                AProductCategory = item.Ecommerce_ProductCategory,
                AProductDescription = item.Ecommerce_ProductDescription,
                AProductSubcategory = item.Ecommerce_ProductSubcategory,
                AManufacturerName = item.Ecommerce_ManufacturerName,
                AMsrp = item.Ecommerce_Msrp,
                ASearchTerms = item.Ecommerce_SearchTerms,
                ASize = item.Ecommerce_Size,
                AUpc = item.Ecommerce_Upc
            });
        }

        /// <summary>
        ///     Insert item info  into PS_ITEM_WEB_INFO
        /// </summary>
        public void InsertItemWebInfo(ItemObject item, OdinContext context)
        {
            if (!context.ItemWebInfo.Any(o => o.InvItemId == item.ItemId))
            {
                item.CombinedCategories = CombineCategories(item.Category, item.Category2, item.Category3);                
                
                DateTime inStockDate = (!(string.IsNullOrEmpty(item.InStockDate))) ? Convert.ToDateTime(item.InStockDate) : new DateTime(1900, 01, 01);
                context.ItemWebInfo.Add(new ItemWebInfo
                {
                    Active = item.Active,
                    AttributeSet = "",
                    Category = item.CombinedCategories,
                    Copyright = item.Copyright,
                    ImagePath = item.ImagePath,
                    InStockDate = inStockDate.Date,
                    InvItemId = item.ItemId,
                    ItemKeywords = item.ItemKeywords,
                    Language = "",
                    License = item.License,
                    MetaDescription = item.MetaDescription,
                    Msrp = "0",
                    Newcategory = "",
                    NewDate = "",
                    OnSite = "N",
                    ProdQty = item.ProductQty,
                    Property = item.Property,
                    ShortDesc = item.ShortDescription,
                    Size = item.Size,
                    Title = item.Title,
                    Territory = ""
                });
            }
        }

        /// <summary>
        ///     Inserts License and property into Odin_Web_License
        /// </summary>
        /// <param name="category"></param>
        public void InsertLicense(string license, string property)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if (!context.OdinWebLicense.Any(o => o.License == license && o.Property == property))
                {
                    context.OdinWebLicense.Add(new OdinWebLicense
                    {
                        License = license,
                        Property = property
                    });
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Insert item info into to PS_MASTER_ITEM_TBL
        /// </summary>
        public void InsertMasterItemTbl(ItemObject item, OdinContext context)
        {
            if (!context.MasterItemTbl.Any(o => o.InvItemId == item.ItemId && o.Setid == "SHARE"))
            {
                string categoryId = RetriveCategoryId(item.ItemCategory);
                context.MasterItemTbl.Add(new MasterItemTbl
                {
                    ApprovRequired = "N",
                    ApprovSubmitted = "N",
                    ApprovalDate = Convert.ToDateTime(DbUtil.StripTime(DateTime.Now)),
                    ApprovalOprid = GlobalData.UserName,
                    CategoryId = categoryId,
                    CfgCodeOpt = "N",
                    CfgCostOpt = "N",
                    CfgLotOpt = "N",
                    ChangeField = "",
                    CmGroup = item.CostProfileGroup,
                    ConsignedFlag = "N",
                    CpTemplateId = "",
                    CpTreeDist = "",
                    CpTreePrdn = "",
                    DateAdded = Convert.ToDateTime(DbUtil.StripTime(DateTime.Now)),
                    DenialReason = "",
                    Descr = DbUtil.Char30(item.Description).ToUpper(),
                    Descr60 = DbUtil.Char60(item.Description.ToUpper()),
                    Descrshort = DbUtil.Char10(item.Description).ToUpper(),
                    DeviceTracking = "N",
                    DistCfgFlag = "N",
                    InvItemGroup = item.ItemGroup,
                    InvItemId = item.ItemId,
                    InvProdFamCd = item.ItemFamily,
                    InventoryItem = "Y",
                    ItemFieldC1A = "",
                    ItemFieldC1B = "",
                    ItemFieldC1C = "",
                    ItemFieldC1D = "",
                    ItemFieldC10A = "",
                    ItemFieldC10B = "",
                    ItemFieldC10C = "",
                    ItemFieldC10D = "",
                    ItemFieldC2 = item.PsStatus,
                    ItemFieldC30A = "",
                    ItemFieldC30B = "",
                    ItemFieldC30C = "",
                    ItemFieldC30D = "",
                    ItemFieldC4 = "",
                    ItemFieldC6 = "",
                    ItemFieldC8 = "",
                    ItemFieldN12A = 0,
                    ItemFieldN12B = 0,
                    ItemFieldN12C = 0,
                    ItemFieldN12D = 0,
                    ItemFieldN15A = 0,
                    ItemFieldN15B = 0,
                    ItemFieldN15C = 0,
                    ItemFieldN15D = 0,
                    ItmStatDtFuture = null,
                    ItmStatusCurrent = "1",
                    ItmStatusEffdt = Convert.ToDateTime(DbUtil.StripTime(DateTime.Now)),
                    ItmStatusFuture = "",
                    LastDttmUpdate = DateTime.Now,
                    LastMaintOprid = GlobalData.UserName,
                    LotControl = "N",
                    MaterialReconFlg = "N",
                    NonOwnFlag = "N",
                    OrigOprid = GlobalData.UserName,
                    PhysicalNature = "G",
                    PlPrioFamily = "",
                    PrdnCfgFlag = "N",
                    PromiseOption = "",
                    SerialControl = "N",
                    SerialInPrdn = "N",
                    Setid = "SHARE",
                    ShipSerialCntrl = "N",
                    StagedDateFlag = "N",
                    TraceChange = "0",
                    TraceUsage = "0",
                    UnitMeasureStd = "EA",
                    UsgTrckngMethod = "01"
                });
            }
        }
        
        /// <summary>
        ///     Inserts a Meta Description value into Odin_MetaDescription
        /// </summary>
        /// <param name="metaDescription"></param>
        /// <returns></returns>
        public void InsertMetaDescription(string metaDescription)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if (!context.OdinMetaDescription.Any(o => o.MetaDescription == metaDescription))
                {
                    context.OdinMetaDescription.Add(new OdinMetaDescription
                    {
                        MetaDescription = metaDescription
                    });
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        ///     Runs InsertPlItemAttrib for each of the business units
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void InsertPlItemAttribAll(ItemObject item, OdinContext context)
        {
            InsertPlItemAttrib(item, "TRUS1", context);
            InsertPlItemAttrib(item, "TRCN1", context);
        }

        /// <summary>
        /// Insert item info into PS_PROD_ITEM
        /// </summary>
        public void InsertProdItem(ItemObject item, OdinContext context)
        {
            if (!context.ProdItem.Any(o => o.ProductId == item.ItemId && o.Setid == "SHARE"))
            {
                context.ProdItem.Add(new ProdItem
                {
                    ActivityId = "",
                    AppliesTo = "",
                    BpDtlTmplId = "",
                    BusinessUnitPc = "",
                    CaApTmplId = "",
                    CaBpTmplId = "",
                    CatalogNbr = "",
                    CfgCodeOpt = "N",
                    CfgKitFlag = "N",
                    CommFlag = "N",
                    CommPct = 0,
                    CostElement = "",
                    CpTemplateId = "",
                    CpTreeDist = "",
                    DatetimeAdded = DateTime.Now,
                    Descr = DbUtil.Char30(item.Description).ToUpper(),
                    Descr254 = item.Description.ToUpper(),
                    DropShipFlag = "N",
                    EffStatus = "A",
                    ExportLicReq = "N",
                    ForecastItemFlag = "N",
                    HoldUpdateSw = "N",
                    InvItemId = item.ItemId,
                    LastMaintOprid = GlobalData.UserName,
                    Lastupddttm = DateTime.Now,
                    LowerMarginPct = 0,
                    ModelNbr = "",
                    Percentage = 0,
                    PhysicalNature = "G",
                    PriceKitFlag = "",
                    PricingStructure = "AMT",
                    ProdBrand = "",
                    ProdCategory = item.ItemCategory,
                    ProdFieldC10A = item.Isbn,
                    ProdFieldC10B = "",
                    ProdFieldC10C = item.Gpc,
                    ProdFieldC10D = "",
                    ProdFieldC1A = "",
                    ProdFieldC1B = "",
                    ProdFieldC1C = "",
                    ProdFieldC1D = "",
                    ProdFieldC2 = "",
                    ProdFieldC30A = item.Ean,
                    ProdFieldC30B = item.StatsCode,
                    ProdFieldC30C = item.Udex,
                    ProdFieldC30D = "",
                    ProdFieldC4 = "",
                    ProdFieldC6 = "",
                    ProdFieldC8 = "",
                    ProdFieldN12A = 0,
                    ProdFieldN12B = 0,
                    ProdFieldN12C = 0,
                    ProdFieldN12D = 0,
                    ProdFieldN15A = 0,
                    ProdFieldN15B = 0,
                    ProdFieldN15C = 0,
                    ProdFieldN15D = 0,
                    ProductId = item.ItemId,
                    ProductKitFlag = "N",
                    ProductUse = "1",
                    ProjectId = "",
                    Renewable = "N",
                    ReturnFlag = "Y",
                    RevRecogMethod = "4",
                    RnwTemplateId = "",
                    Setid = "SHARE",
                    TaxProductNbr = item.ItemId,
                    TaxTransSubType = "",
                    TaxTransType = "",
                    ThirdPartyFlg = "N",
                    UpperMarginPct = 0,
                    VatSvcPerfrmFlg = ""
                });
            }
        }

        /// <summary>
        ///     Runs InsertProdPgrpLnk for each Product Group Type
        /// </summary>
        public void InsertProdPgrpLnkAll(ItemObject item, OdinContext context)
        {
            InsertProdPgrpLnk(item, "ACCT", item.AccountingGroup.ToUpper(), "N", context);
            if (!(string.IsNullOrEmpty(item.PricingGroup)))
            {
                InsertProdPgrpLnk(item, "PRC",item.PricingGroup.ToUpper(), "Y", context);
            }
        }

        /// <summary>
        ///     Runs InsertProdPrice for each business unit / ccd combination
        /// </summary>
        public void InsertProdPriceAll(ItemObject item, OdinContext context)
        {
            InsertProdPrice(item, "TRCN1", "CAD", item.ListPriceCad, DbUtil.AssignMsrp(item.MsrpCad, item.Msrp), context);
            InsertProdPrice(item, "TRUS1", "CAD", item.ListPriceCad, DbUtil.AssignMsrp(item.MsrpCad, item.Msrp), context);
            InsertProdPrice(item, "TRUS1", "USD", item.ListPriceUsd, Convert.ToDecimal(item.Msrp), context);
            if (!(string.IsNullOrEmpty(item.ListPriceMxn)))
            {
                InsertProdPrice(item, "TRUS1", "MXN", item.ListPriceMxn, DbUtil.AssignMsrp(item.MsrpMxn, item.Msrp), context);
                InsertProdPrice(item, "TRMX1", "MXN", item.ListPriceMxn, DbUtil.AssignMsrp(item.MsrpMxn, item.Msrp), context);
            }
        }

        /// <summary>
        ///     Runs InsertProdPriceBu for each business unit / currency code combination
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void InsertProdPriceBuAll(ItemObject item, OdinContext context)
        {
            InsertProdPriceBu(item, "CAD", "TRCN1", context);
            InsertProdPriceBu(item, "CAD", "TRUS1", context);
            InsertProdPriceBu(item, "USD", "TRUS1", context);
            if (!(string.IsNullOrEmpty(item.ListPriceMxn)))
            {
                InsertProdPriceBu(item, "MXN", "TRUS1", context);
                InsertProdPriceBu(item, "MXN", "TRMX1", context);
            }
        }

        /// <summary>
        ///     Runs InsertProductIdTranslation for each child in the productIdTranslation field
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void InsertProductIdTranslationAll(ItemObject item, OdinContext context)
        {
            foreach (ChildElement productIdTranslation in item.ProductIdTranslation)
            {
                if (!string.IsNullOrEmpty(productIdTranslation.ItemId) && !string.IsNullOrEmpty(item.ItemId))
                {
                    InsertProductIdTranslation(item.ItemId, productIdTranslation.ItemId.Trim(), productIdTranslation.Qty, context);
                }
            }
        }

        /// <summary>
        /// Insert item info into PS_PROD_UOM
        /// </summary>
        public void InsertProdUom(ItemObject item, OdinContext context)
        {
            if (!context.ProdUom.Any(o => o.ProductId == item.ItemId))
            {
                context.ProdUom.Add(new ProdUom
                {
                    DatetimeAdded = DateTime.Now,
                    DfltUom = "Y",
                    LastMaintOprid = GlobalData.UserName,
                    Lastupddttm = DateTime.Now,
                    MaxOrderQty = 0,
                    MinOrderQty = 0,
                    OrderIncrement = 0,
                    ProductId = item.ItemId,
                    Setid = "SHARE",
                    UnitOfMeasure = "EA"
                });
            }
        }

        /// <summary>
        ///     Insert item info into PS_PURCH_ITEM_ATTR
        /// </summary>
        public void InsertPurchItemAttr(ItemObject item, OdinContext context)
        {
            if (!context.PurchItemAttr.Any(o => o.InvItemId == item.ItemId))
            {
                context.PurchItemAttr.Add(new PurchItemAttr
                {
                    AcceptAllShipto = "Y",
                    AcceptAllVendor = "Y",
                    Account = "23000",
                    Affiliate = "",
                    AffiliateIntra1 = "",
                    AffiliateIntra2 = "",
                    Altacct = "",
                    AutoSource = "Y",
                    AvailAllRgns = "Y",
                    BudgetRef = "",
                    Chartfield1 = "",
                    Chartfield2 = "",
                    Chartfield3 = "",
                    ClassFld = "",
                    ContractReq = "N",
                    CurrencyCd = "USD",
                    Deptid = "",
                    Descr = DbUtil.Char30(item.Description).ToUpper(),
                    Descr254Mixed = item.Description.ToUpper(),
                    Descrshort = DbUtil.Char10(item.Description).ToUpper(),
                    ExtPrcTol = 50,
                    ExtPrcTolL = 999999,
                    FileExtension = "",
                    Filename = "",
                    FundCode = "",
                    InspectCd = "N",
                    InspectSamplePer = 0,
                    InspectUomType = "S",
                    InvItemId = item.ItemId,
                    KbOvrRecvTol = 0,
                    KbPastDuePo = "N",
                    LastDttmUpdate = null,
                    LastPoPricePaid = 0,
                    LeadTimeImp = 0,
                    Model = "",
                    OperatingUnit = "",
                    OpridModifiedBy = "",
                    PackingVolume = 0,
                    PackingWeight = 0,
                    PctExtPrcTol = 100,
                    PctExtPrcTolL = 100,
                    PctUnderQty = 0,
                    PctUnitPrcTol = 5,
                    PctUnitPrcTolL = 100,
                    PoAvailDt = Convert.ToDateTime(DbUtil.StripTime(DateTime.Now)),
                    PoUnavailDt = Convert.ToDateTime("2999-12-31"),
                    PriceImp = 0,
                    PriceList = Convert.ToDecimal(item.StandardCost),
                    PrimaryBuyer = "",
                    Product = "",
                    ProgramCode = "",
                    ProjectId = "",
                    QtyRecvTolPct = 0,
                    RecvPartialFlg = "1",
                    RecvReq = "Y",
                    RejectDays = 0,
                    RfqReqFlag = "N",
                    RjctOverTolFlag = "N",
                    RoutingId = "",
                    Setid = "SHARE",
                    ShipLateDays = 0,
                    ShiptoPrImp = 0,
                    ShipTypeId = "",
                    SrcMethod = "B",
                    StdLead = 0,
                    StocklessFlg = "N",
                    TaxableCd = "Y",
                    UltimateUseCd = "",
                    UnitMeasureVol = "",
                    UnitMeasureWt = "",
                    UnitPrcTol = 999999,
                    UnitPrcTolL = 999999,
                    UseCatSrcCntl = "N",
                    VatSvcPerfrmFlg = "",
                    VndrPrImp = 0,
                    WfPctPrcTolOvr = 999,
                    WfPctPrcTolUnd = 999,
                    WfPrcTolOvr = 99999999,
                    WfPrcTolUnd = 99999999
                });
            }
        }

        /// <summary>
        ///     Insert item info into PS_PV_ITM_Category table
        /// </summary>
        public void InsertPvItmCategory(ItemObject item, OdinContext context)
        {
            string categoryId = RetriveCategoryId(item.ItemCategory);
            if (!context.PvItmCategory.Any(o => o.InvItemId == item.ItemId))
            {
                context.PvItmCategory.Add(new PvItmCategory
                {
                    Setid = "SHARE",
                    InvItemId = item.ItemId,
                    CategoryId = categoryId,
                    PvPreferredCat = "Y"
                });
            }
        }

        /// <summary>
        ///     Inserts Territory Value into Odin_Web_Territories
        /// </summary>
        /// <param name="category"></param>
        public void InsertTerritory(string territory)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if (!context.OdinWebTerritories.Any(o => o.Territory == territory))
                {
                    context.OdinWebTerritories.Add(new OdinWebTerritories
                    {
                        Territory = territory
                    });
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        ///     Runs InsertUomTypeInv for each Uom type
        /// </summary>
        public void InsertUomTypeInvAll(ItemObject item, OdinContext context)
        {
            InsertUomTypeInv(item, "ORDR", context);
            InsertUomTypeInv(item, "SHIP", context);
            InsertUomTypeInv(item, "STCK", context);
        }

        /// <summary>
        ///     Inserts a value into Odin_NewWebCategories
        /// </summary>
        /// <param name="category"></param>
        public void InsertWebCategory(string category)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                int x = (from o in context.OdinNewWebCategories select o.Id).DefaultIfEmpty(0).Max() + 1;
                context.OdinNewWebCategories.Add(new OdinNewWebCategories { Category = category, OldId = 0, Id = x });
                context.SaveChanges();
            }
        }

        #endregion // Public Insert Methods

        #region Public Removal Methods

        /// <summary>
        ///     Removes category from Odin_NewWebCategories
        /// </summary>
        /// <param name="category">Category to be removed</param>
        public void RemoveCategory(string categoryName)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                foreach (OdinNewWebCategories odinNewWebCategories in (from o in context.OdinNewWebCategories where o.Category == categoryName select o))
                {
                    context.OdinNewWebCategories.Remove(odinNewWebCategories);
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        ///     Removes all license/property values from ODIN_WEB_LICENSE with the given license
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void RemoveLicense(string licenseName)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                foreach (OdinWebLicense odinWebLicense in (from o in context.OdinWebLicense where o.License == licenseName select o))
                {
                    context.OdinWebLicense.Remove(odinWebLicense);
                }
                context.SaveChanges();
            }
            
        }

        /// <summary>
        ///     Removes a Meta Description from Odin_MetaDescription
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void RemoveMetaDescription(string metaDescriptionName)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                foreach (OdinMetaDescription odinMetaDescription in (from o in context.OdinMetaDescription where o.MetaDescription == metaDescriptionName select o))
                {
                    context.OdinMetaDescription.Remove(odinMetaDescription);
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        ///     Removes a property from Odin_Web_License
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void RemoveProperty(string licenseName, string propertyName)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                foreach (OdinWebLicense odinWebLicense in (from o in context.OdinWebLicense where o.Property == propertyName && o.License == licenseName select o))
                {
                    context.OdinWebLicense.Remove(odinWebLicense);
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        ///     Removes territory value from ODIN_WEB_TERRITORIES with the given territory
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void RemoveTerritory(string territory)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                foreach (OdinWebTerritories odinWebTerritories in (from o in context.OdinWebTerritories where o.Territory == territory select o))
                {
                    context.OdinWebTerritories.Remove(odinWebTerritories);
                }
                context.SaveChanges();
            }
        }

        #endregion // Public Removal Methods

        #region Public Retrieval Methods

        /// <summary>
        ///     Returns all items that fall within the given date range for the given customer
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<string> RetrieveActiveEcommerceItemIds(string startDate, string endDate, string productGroup, string customerName)
        {
            List<string> returnValues = new List<string>();
            DateTime start = Convert.ToDateTime(startDate);
            DateTime end = Convert.ToDateTime(endDate);
            string customerId = RetrieveCustomerId(customerName);
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                var x = (from customerProductAttribute in context.CustomerProductAttributes
                         join itemAttribEx in context.ItemAttribEx
                            on
                            new
                            {
                                Key1 = customerProductAttribute.ProductId,
                                Key2 = "SHARE"
                            }
                            equals
                            new
                            {
                                Key1 = itemAttribEx.InvItemId,
                                Key2 = itemAttribEx.Setid
                            }
                         join masterItemTbl in context.MasterItemTbl
                            on
                            new
                            {
                                Key1 = customerProductAttribute.ProductId,
                                Key2 = "SHARE",
                            }
                            equals
                            new
                            {
                                Key1 = masterItemTbl.InvItemId,
                                Key2 = masterItemTbl.Setid
                            }
                         where customerProductAttribute.SendInventory == "Y"
                             && masterItemTbl.DateAdded > start
                             && masterItemTbl.DateAdded < end
                             && customerProductAttribute.CustId == customerId
                             && customerProductAttribute.Setid == "SHARE"
                         select new
                         {
                             ItemId = customerProductAttribute.ProductId,
                             PsStatus = masterItemTbl.ItemFieldC2

                         }).ToList();

                foreach (var y in x)
                {
                    if (y.PsStatus != "I" & y.PsStatus != "D")
                    {
                        returnValues.Add(y.ItemId);
                    }
                }
            }
            return returnValues;
        }
        
        /// <summary>
        ///     Returns the category name associated with the given code
        /// </summary>
        /// <param name="value"></param>
        public string RetrieveCategoryNameByCode(string value)
        {
            if (GlobalData.WebCategoryList.ContainsKey(value))
            {
                return GlobalData.WebCategoryList[value];
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        ///     Retrieves all the Global data values
        /// </summary>
        public void RetrieveGlobalData()
        {
            GlobalData.AccountingGroups = RetrieveAccountingtGroupList();
            GlobalData.CostProfileGroups = RetrieveCostProfileGroups();
            GlobalData.CountriesOfOrigin = RetrieveCountriesOfOrigin();
            GlobalData.Customers = RetrieveCustomerIdConversionsList();
            GlobalData.CustomerIdConversions = RetrieveCustomerIdConversionsList();
            GlobalData.ExternalIdTypes = RetrieveEcommerce_ExternalIdTypeList();
            GlobalData.ItemCategories = RetrieveItemCategories();
            GlobalData.ItemGroups = RetrieveItemGroups();
            GlobalData.ItemIds = RetrieveItemIds();
            // GlobalData.ItemRecords = RetrieveItemRecords();
            GlobalData.Languages = RetrieveLanguages();
            GlobalData.Licenses = RetrieveLicenseList();
            GlobalData.MetaDescriptions = RetrieveMetaDescriptionList();
            GlobalData.ProductCategories = RetrieveProductCategories();
            GlobalData.ProductFormats = RetrieveProductFormatList();
            // GlobalData.ProductFormatsFiltered = RetrieveProductFormatList();
            GlobalData.ProductGoups = RetrieveProductGroupList();
            GlobalData.ProductLines = RetrieveProductLines();
            GlobalData.Properties = RetrieveProperties();
            GlobalData.PricingGroups = RetrievePriceGroupList();
            GlobalData.PsStatuses = RetrievePsStatuses();
            GlobalData.RequestStatus = RetrieveRequestStatuses();
            GlobalData.SpecialCharacters = RetrieveSpecialCharacters();
            GlobalData.TariffCodes = RetrieveTariffCodeList();
            GlobalData.Territories = RetrieveTerritories();
            GlobalData.ToolTips = RetrieveToolTips();
            GlobalData.UpcProductFormatExceptions = RetrieveExceptions("UPC", "PRODUCT_FORMAT", "EMPTY UPC");
            GlobalData.Upcs = RetrieveUpcs();
            GlobalData.UserNames = RetrieveUserNames();
            GlobalData.UserRoles = RetrieveUserRoles();
            GlobalData.WebCategoryList = RetrieveWebCategoryList();
        }

        /// <summary>
        ///     Retrieves the local file paths for all the given images
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public List<string> RetrieveImagePaths(string itemId)
        {
            List<string> imagePaths = new List<string>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                var dataset = context.ItemAttribEx
                .Where(x => x.InvItemId == itemId)
                .Select(x => new { x.ImageFileName, x.AltImageFile1, x.AltImageFile2, x.AltImageFile3, x.AltImageFile4 }).FirstOrDefault();
                if (!string.IsNullOrEmpty(dataset.ImageFileName)) { imagePaths.Add(dataset.ImageFileName); }
                if (!string.IsNullOrEmpty(dataset.AltImageFile1)) { imagePaths.Add(dataset.AltImageFile1); }
                if (!string.IsNullOrEmpty(dataset.AltImageFile2)) { imagePaths.Add(dataset.AltImageFile2); }
                if (!string.IsNullOrEmpty(dataset.AltImageFile3)) { imagePaths.Add(dataset.AltImageFile3); }
                if (!string.IsNullOrEmpty(dataset.AltImageFile4)) { imagePaths.Add(dataset.AltImageFile4); }
            }
            return imagePaths;
        }

        /// <summary>
        ///     Selects all of the info for a given item from the db. If assigned type 2 only retrieves information from db not included in spreadsheet
        /// </summary>
        /// <param name="item"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public ItemObject RetrieveItem(string idInput, int row)
        {
            ItemObject item = new ItemObject
            {
                ItemId = idInput
            };
            // DateTime effdt = RetrieveEffdt(idInput);

            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if (context.OdinItem.Any(o => o.InvItemId == idInput.Trim()))
                {
                    OdinItem odinItem = (from o in context.OdinItem
                                         where o.InvItemId == idInput.Trim()
                                         select o).FirstOrDefault();

                    item.AccountingGroup = (!string.IsNullOrEmpty(odinItem.AccountingGroup)) ? odinItem.AccountingGroup : "";
                    item.AltImageFile1 = (!string.IsNullOrEmpty(odinItem.AltImageFile1)) ? odinItem.AltImageFile1 : "";
                    item.AltImageFile2 = (!string.IsNullOrEmpty(odinItem.AltImageFile2)) ? odinItem.AltImageFile2 : "";
                    item.AltImageFile3 = (!string.IsNullOrEmpty(odinItem.AltImageFile3)) ? odinItem.AltImageFile3 : "";
                    item.AltImageFile4 = (!string.IsNullOrEmpty(odinItem.AltImageFile4)) ? odinItem.AltImageFile4 : "";
                    item.BillOfMaterials = (!string.IsNullOrEmpty(odinItem.BillOfMaterials)) ? DbUtil.ParseChildElements(odinItem.InvItemId, odinItem.BillOfMaterials) : new List<ChildElement>();
                    item.CasepackHeight = (odinItem.CasepackHeight != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.CasepackHeight), 1) : "";
                    item.CasepackLength = (odinItem.CasepackLength != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.CasepackLength), 1) : "";
                    item.CasepackQty = (!string.IsNullOrEmpty(Convert.ToString(odinItem.CasepackQty))) ? Convert.ToString(odinItem.CasepackQty).Trim() : "";
                    item.CasepackUpc = (!string.IsNullOrEmpty(odinItem.CasepackUpc)) ? odinItem.CasepackUpc.Trim() : "";
                    item.CasepackWeight = (odinItem.CasepackWeight != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.CasepackWeight), 1) : "";
                    item.CasepackWidth = (odinItem.CasepackWidth != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.CasepackWidth), 1) : "";
                    item.Color = (!string.IsNullOrEmpty(odinItem.InvItemColor)) ? odinItem.InvItemColor.Trim() : "";
                    item.Copyright = (!string.IsNullOrEmpty(odinItem.Copyright)) ? odinItem.Copyright.Trim() : "";
                    item.CountryOfOrigin = (!string.IsNullOrEmpty(odinItem.CountryIstOrigin)) ? odinItem.CountryIstOrigin.Trim() : "";
                    item.CostProfileGroup = (!string.IsNullOrEmpty(odinItem.CmGroup)) ? odinItem.CmGroup.Trim() : "";
                    item.DefaultActualCostCad = (odinItem.DefaultActualCostCad != null) ? DbUtil.ZeroTrim(odinItem.DefaultActualCostCad.ToString(), 2):"";
                    item.DefaultActualCostUsd = (odinItem.DefaultActualCostUsd != null) ? DbUtil.ZeroTrim(odinItem.DefaultActualCostUsd.ToString(), 2):"";
                    item.Description = (!string.IsNullOrEmpty(odinItem.Descr60)) ? odinItem.Descr60.Trim() : "";
                    item.DirectImport = (!string.IsNullOrEmpty(odinItem.DirectImport)) ? odinItem.DirectImport.Trim() : "";
                    item.Duty = (!string.IsNullOrEmpty(odinItem.Duty)) ? odinItem.Duty.Trim() : "";
                    item.Ean = (!string.IsNullOrEmpty(odinItem.Ean)) ? odinItem.Ean.Trim() : "";
                    item.Ecommerce_Asin = (!string.IsNullOrEmpty(odinItem.EcommerceAsin)) ? odinItem.EcommerceAsin.Trim() : "";
                    item.Ecommerce_Bullet1 = (!string.IsNullOrEmpty(odinItem.EcommerceBullet1)) ? odinItem.EcommerceBullet1.Trim() : "";
                    item.Ecommerce_Bullet2 = (!string.IsNullOrEmpty(odinItem.EcommerceBullet2)) ? odinItem.EcommerceBullet2.Trim() : "";
                    item.Ecommerce_Bullet3 = (!string.IsNullOrEmpty(odinItem.EcommerceBullet3)) ? odinItem.EcommerceBullet3.Trim() : "";
                    item.Ecommerce_Bullet4 = (!string.IsNullOrEmpty(odinItem.EcommerceBullet4)) ? odinItem.EcommerceBullet4.Trim() : "";
                    item.Ecommerce_Bullet5 = (!string.IsNullOrEmpty(odinItem.EcommerceBullet5)) ? odinItem.EcommerceBullet5.Trim() : "";
                    item.Ecommerce_Components = (!string.IsNullOrEmpty(odinItem.EcommerceComponents)) ? odinItem.EcommerceComponents.Trim() : "";
                    item.Ecommerce_Cost = (odinItem.EcommerceCost != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.EcommerceCost).Trim(), 2) : "";
                    item.Ecommerce_ExternalId = (!string.IsNullOrEmpty(odinItem.EcommerceExternalId)) ? odinItem.EcommerceExternalId.Trim() : "";
                    item.Ecommerce_ExternalIdType = (!string.IsNullOrEmpty(odinItem.EcommerceExternalIdType)) ? odinItem.EcommerceExternalIdType.Trim() : "";
                    item.Ecommerce_ImagePath1 = (!string.IsNullOrEmpty(odinItem.EcommerceImageUrl1)) ? odinItem.EcommerceImageUrl1.Trim() : "";
                    item.Ecommerce_ImagePath2 = (!string.IsNullOrEmpty(odinItem.EcommerceImageUrl2)) ? odinItem.EcommerceImageUrl2.Trim() : "";
                    item.Ecommerce_ImagePath3 = (!string.IsNullOrEmpty(odinItem.EcommerceImageUrl3)) ? odinItem.EcommerceImageUrl3.Trim() : "";
                    item.Ecommerce_ImagePath4 = (!string.IsNullOrEmpty(odinItem.EcommerceImageUrl4)) ? odinItem.EcommerceImageUrl4.Trim() : "";
                    item.Ecommerce_ImagePath5 = (!string.IsNullOrEmpty(odinItem.EcommerceImageUrl5)) ? odinItem.EcommerceImageUrl5.Trim() : "";
                    item.Ecommerce_ItemHeight = (odinItem.EcommerceHeight != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.EcommerceHeight).Trim(), 1) : "";
                    item.Ecommerce_ItemLength = (odinItem.EcommerceLength != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.EcommerceLength).Trim(), 1) : "";
                    item.Ecommerce_ItemName = (!string.IsNullOrEmpty(odinItem.EcommerceItemName)) ? odinItem.EcommerceItemName.Trim() : "";
                    item.Ecommerce_ItemWeight = (odinItem.EcommerceWeight != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.EcommerceWeight).Trim(), 1) : "";
                    item.Ecommerce_ItemWidth = (odinItem.EcommerceWidth != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.EcommerceWidth).Trim(), 1) : "";
                    item.Ecommerce_ModelName = (!string.IsNullOrEmpty(odinItem.EcommerceModelName)) ? odinItem.EcommerceModelName.Trim() : "";
                    item.Ecommerce_PackageHeight = (odinItem.EcommercePackageHeight != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.EcommercePackageHeight).Trim(), 1) : "";
                    item.Ecommerce_PackageLength = (odinItem.EcommercePackageLength != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.EcommercePackageLength).Trim(), 1) : "";
                    item.Ecommerce_PackageWeight = (odinItem.EcommercePackageWeight != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.EcommercePackageWeight).Trim(), 1) : "";
                    item.Ecommerce_PackageWidth = (odinItem.EcommercePackageWidth != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.EcommercePackageWidth).Trim(), 1) : "";
                    item.Ecommerce_PageQty = (!string.IsNullOrEmpty(Convert.ToString(odinItem.EcommercePageCount))) ? Convert.ToString(odinItem.EcommercePageCount).Trim() : "";
                    item.Ecommerce_ProductCategory = (!string.IsNullOrEmpty(odinItem.EcommerceProductCategory)) ? odinItem.EcommerceProductCategory.Trim() : "";
                    item.Ecommerce_ProductDescription = (!string.IsNullOrEmpty(odinItem.EcommerceFullDescription)) ? odinItem.EcommerceFullDescription.Trim() : "";
                    item.Ecommerce_ProductSubcategory = (!string.IsNullOrEmpty(odinItem.EcommerceProductSubcategory)) ? odinItem.EcommerceProductSubcategory.Trim() : "";
                    item.Language = (!string.IsNullOrEmpty(odinItem.Language)) ? DbUtil.OrderLanguage(odinItem.Language):"";
                    item.Ecommerce_ManufacturerName = (!string.IsNullOrEmpty(odinItem.EcommerceManufacturerName)) ? odinItem.EcommerceManufacturerName.Trim() : "";
                    item.Ecommerce_Msrp = (odinItem.EcommerceMsrp != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.EcommerceMsrp).Trim(), 2) : "";
                    item.Ecommerce_SearchTerms = (!string.IsNullOrEmpty(odinItem.EcommerceSearchTerms)) ? odinItem.EcommerceSearchTerms.Trim() : "";
                    item.Ecommerce_Size = (!string.IsNullOrEmpty(odinItem.EcommerceSize)) ? odinItem.EcommerceSize.Trim() : "";
                    item.Ecommerce_Upc = (!string.IsNullOrEmpty(odinItem.EcommerceUpc)) ? odinItem.EcommerceUpc.Trim() : "";
                    item.Gpc = (!string.IsNullOrEmpty(odinItem.Gpc)) ? odinItem.Gpc.Trim() : "";
                    item.Height = (odinItem.InvItemHeight != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.InvItemHeight), 1) : "";
                    item.ImagePath = (!string.IsNullOrEmpty(odinItem.ImageFileName)) ? odinItem.ImageFileName.Trim() : "";
                    item.InnerpackHeight = (odinItem.InnerpackHeight != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.InnerpackHeight), 1) : "";
                    item.InnerpackLength = (odinItem.InnerpackLength != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.InnerpackLength), 1) : "";
                    item.InnerpackQuantity = (odinItem.InnerpackQty != null) ? Convert.ToString(odinItem.InnerpackQty).Trim() : "";
                    item.InnerpackUpc = (!string.IsNullOrEmpty(odinItem.InnerpackUpc)) ? odinItem.InnerpackUpc.Trim() : "";
                    item.InnerpackWidth = (odinItem.InnerpackWidth != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.InnerpackWidth), 1) : "";
                    item.InnerpackWeight = (odinItem.InnerpackWeight != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.InnerpackWeight), 1) : "";
                    item.InStockDate = (odinItem.InStockDate != null) ? Convert.ToString(DbUtil.StripTime(odinItem.InStockDate)) : "";
                    item.Isbn = (!string.IsNullOrEmpty(odinItem.Isbn)) ? odinItem.Isbn.Trim() : "";
                    item.ItemCategory = (!string.IsNullOrEmpty(odinItem.ProdCategory)) ? odinItem.ProdCategory.Trim() : "";
                    item.ItemFamily = (!string.IsNullOrEmpty(odinItem.InvProdFamCd)) ? odinItem.InvProdFamCd.Trim() : "";
                    item.ItemGroup = (!string.IsNullOrEmpty(odinItem.InvItemGroup)) ? odinItem.InvItemGroup.Trim() : "";
                    item.ItemId = (!string.IsNullOrEmpty(idInput)) ? idInput : "";
                    item.ItemKeywords = (!string.IsNullOrEmpty(odinItem.ItemKeywords)) ? odinItem.ItemKeywords.Trim() : "";
                    item.Language = (!string.IsNullOrEmpty(odinItem.Language)) ? DbUtil.OrderLanguage(odinItem.Language) : "";
                    item.Length = (odinItem.InvItemLength != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.InvItemLength), 1) : "";
                    item.License = (!string.IsNullOrEmpty(odinItem.License)) ? odinItem.License.Trim() : "";
                    item.LicenseBeginDate = (odinItem.LicenseBeginDate != null) ? Convert.ToString(DbUtil.StripTime(odinItem.LicenseBeginDate)) : "";
                    item.ListPriceCad = (odinItem.ListPriceCad != null) ? DbUtil.ZeroTrim(odinItem.ListPriceCad.ToString(), 2) : "";
                    item.ListPriceMxn = (odinItem.ListPriceMxn !=null ) ? DbUtil.ZeroTrim(odinItem.ListPriceMxn.ToString(), 2): "";
                    item.ListPriceUsd = (odinItem.ListPriceUsd != null) ? DbUtil.ZeroTrim(odinItem.ListPriceUsd.ToString(), 2): "";
                    item.MetaDescription = (!string.IsNullOrEmpty(odinItem.MetaDescription)) ? odinItem.MetaDescription.Trim() : "";
                    item.MfgSource = (!string.IsNullOrEmpty(odinItem.MfgSource)) ? odinItem.MfgSource.Trim() : "";
                    item.MsrpCad = (!string.IsNullOrEmpty(odinItem.MsrpCad)) ? DbUtil.ZeroTrim(odinItem.MsrpCad, 2) : "";
                    item.MsrpMxn = (!string.IsNullOrEmpty(odinItem.MsrpMxn)) ? DbUtil.ZeroTrim(odinItem.MsrpMxn, 2) : "";
                    item.Msrp = (!string.IsNullOrEmpty(odinItem.MsrpUsd)) ? DbUtil.ZeroTrim(odinItem.MsrpUsd, 2) : "";
                    item.PricingGroup = (!string.IsNullOrEmpty(odinItem.PricingGroup)) ? odinItem.PricingGroup.Trim() : "";
                    item.ProductFormat = (!string.IsNullOrEmpty(odinItem.ProdFormat)) ? odinItem.ProdFormat.Trim() : "";
                    item.ProductGroup = (!string.IsNullOrEmpty(odinItem.ProdGroup)) ? odinItem.ProdGroup.Trim() : "";
                    item.ProductIdTranslation = (!string.IsNullOrEmpty(odinItem.ProductIdTranslation)) ? DbUtil.ParseChildElements(odinItem.InvItemId, odinItem.ProductIdTranslation) : new List<ChildElement>();
                    item.ProductLine = (!string.IsNullOrEmpty(odinItem.ProdLine)) ? odinItem.ProdLine.Trim() : "";
                    item.ProductQty = (!string.IsNullOrEmpty(odinItem.ProdQty)) ? odinItem.ProdQty.Trim() : "";
                    item.Property = (!string.IsNullOrEmpty(odinItem.Property)) ? odinItem.Property.Trim() : "";
                    item.PrintOnDemand = (!string.IsNullOrEmpty(odinItem.PrintOnDemand)) ? odinItem.PrintOnDemand.Trim() : "";
                    item.PsStatus = (!string.IsNullOrEmpty(odinItem.Psstatus)) ? odinItem.Psstatus.Trim() : "";
                    item.SatCode = (!string.IsNullOrEmpty(odinItem.SatCode)) ? odinItem.SatCode.Trim() : "";
                    item.SellOnTrends = (!string.IsNullOrEmpty(odinItem.SellOnWeb)) ? odinItem.SellOnWeb.Trim() : "";
                    item.SellOnAllPosters = (!string.IsNullOrEmpty(odinItem.SellOnAllPosters)) ? odinItem.SellOnAllPosters.Trim() : "";
                    item.SellOnAmazon = (!string.IsNullOrEmpty(odinItem.SellOnAmazon)) ? odinItem.SellOnAmazon.Trim() : "";
                    item.SellOnFanatics = (!string.IsNullOrEmpty(odinItem.SellOnFanatics)) ? odinItem.SellOnFanatics.Trim() : "";
                    item.SellOnGuitarCenter = (!string.IsNullOrEmpty(odinItem.SellOnGuitarCenter)) ? odinItem.SellOnGuitarCenter.Trim() : "";
                    item.SellOnHayneedle = (!string.IsNullOrEmpty(odinItem.SellOnHayneedle)) ? odinItem.SellOnHayneedle.Trim() : "";
                    item.SellOnTarget = (!string.IsNullOrEmpty(odinItem.SellOnTarget)) ? odinItem.SellOnTarget.Trim() : "";
                    item.SellOnWalmart = (!string.IsNullOrEmpty(odinItem.SellOnWalmart)) ? odinItem.SellOnWalmart.Trim() : "";
                    item.SellOnWayfair = (!string.IsNullOrEmpty(odinItem.SellOnWayfair)) ? odinItem.SellOnWayfair.Trim() : "";
                    item.ShortDescription = (!string.IsNullOrEmpty(odinItem.ShortDesc)) ? odinItem.ShortDesc.Trim() : "";
                    item.Size = (!string.IsNullOrEmpty(odinItem.Size)) ? odinItem.Size.Trim() : "";
                    item.StandardCost = (odinItem.StandardCost != null) ? Convert.ToString(odinItem.StandardCost).Trim() : "";
                    item.StatsCode = (!string.IsNullOrEmpty(odinItem.StatsCode)) ? odinItem.StatsCode.Trim() : "";
                    item.TariffCode = (!string.IsNullOrEmpty(odinItem.HarmonizedCd)) ? odinItem.HarmonizedCd.Trim() : "";
                    item.Territory = (!string.IsNullOrEmpty(odinItem.Territory)) ? DbUtil.OrderTerritory(odinItem.Territory) : "";
                    item.Title = (!string.IsNullOrEmpty(odinItem.Title)) ? odinItem.Title.Trim() : "";
                    item.Udex = (!string.IsNullOrEmpty(odinItem.Udex)) ? odinItem.Udex.Trim() : "";
                    item.Upc = (!string.IsNullOrEmpty(odinItem.UpcId)) ? odinItem.UpcId.Trim() : "";
                    item.WebsitePrice = (odinItem.WebsitePrice != null) ? DbUtil.ZeroTrim(odinItem.WebsitePrice.ToString(), 2) : "";
                    item.Weight = (odinItem.InvItemWeight != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.InvItemWeight), 1) : "";
                    item.Width = (odinItem.InvItemWidth != null) ? DbUtil.ZeroTrim(Convert.ToString(odinItem.InvItemWidth), 1) : "";
                    item.OnSite = (!string.IsNullOrEmpty(odinItem.OnSite)) ? odinItem.OnSite : "";
                    item.Ecommerce_CountryofOrigin = (!string.IsNullOrEmpty(odinItem.CountryIstOrigin)) ? odinItem.CountryIstOrigin : "";
                    item.Status = "Update";
                    item.ItemRow = row;
                    if (!string.IsNullOrEmpty(odinItem.Category))
                    {
                        List<string> Categories = DbUtil.ParseCategories(odinItem.Category);
                        int catCount = 0;
                        foreach (string cat in Categories)
                        {
                            switch (catCount)
                            {
                                case 0:
                                    item.Category = Categories[catCount];
                                    break;
                                case 1:
                                    item.Category2 = Categories[catCount];
                                    break;
                                case 2:
                                    item.Category3 = Categories[catCount];
                                    break;
                            }
                            catCount++;
                        }
                    }
                    item.ResetUpdate();
                }
            }
            return item;
        }

        /// <summary>
        ///     Retrieves a list of search item values
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<SearchItem> RetrieveItemSearchResults(string value)
        {
            List<SearchItem> returnSearchItemList = new List<SearchItem>();

            using (OdinContext context = this.contextFactory.CreateContext())
            {
                List<InvItems> invItems = (from o in context.InvItems
                                           where o.InvItemId.Contains(value) || o.Descr254.Contains(value)
                                           select o).ToList();

                foreach (InvItems invItem in invItems)
                {
                    returnSearchItemList.Add(new SearchItem(invItem.InvItemId, invItem.Descr254));
                }
            }
            return returnSearchItemList;
        }

        /// <summary>
        ///     Retrieves a list of user records
        /// </summary>
        /// <returns>List of user records</returns>
        public List<ItemRecord> RetrieveItemRecords()
        {
            List<ItemRecord> records = new List<ItemRecord>();
            List<string> itemIds = new List<string>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if ((context.OdinItemUpdateRecords.Any()))
                {
                    var odinItemUpdateRecords = (from o in context.OdinItemUpdateRecords
                                                 orderby o.InputDate descending
                                                 group o by new { o.InvItemId, o.ItemInputStatus, o.Username, o.InputDate } into g
                                                 select new
                                                 {
                                                     ItemId = g.Key.InvItemId,
                                                     Status = g.Key.ItemInputStatus,
                                                     UserName = g.Key.Username,
                                                     InputDate = g.Max(x => x.InputDate)
                                                 }).ToList();
                    foreach (var x in odinItemUpdateRecords)
                    {
                        if (!itemIds.Contains(x.ItemId))
                        {
                            itemIds.Add(x.ItemId);
                            records.Add(new ItemRecord(x.InputDate.ToString(), x.ItemId, x.Status, x.UserName));
                        }
                    }
                }
            }
            return records;
        }

        /// <summary>
        ///     Retrieve a list of Item Objects relating to update records for the given item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public List<ItemObject> RetrieveItemUpdateRecords(string itemId)
        {
            List<ItemObject> items = new List<ItemObject>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                List<OdinItemUpdateRecords> odinItemUpdateRecords = (from o in context.OdinItemUpdateRecords
                                                                     where o.InvItemId == itemId
                                                                     select o).ToList();

                foreach (OdinItemUpdateRecords odinItemUpdateRecord in odinItemUpdateRecords)
                {
                    ItemObject item = new ItemObject();

                    List<ChildElement> idTranslations = new List<ChildElement>();
                    if (!string.IsNullOrEmpty(odinItemUpdateRecord.ProductIdTranslation))
                    {
                        foreach (string x in odinItemUpdateRecord.ProductIdTranslation.Split(','))
                        {
                            ChildElement idTranslation = new ChildElement(x, itemId);
                            item.ProductIdTranslation.Add(idTranslation);
                        }
                    }

                    List<ChildElement> billOfMaterialsList = new List<ChildElement>();
                    if (!string.IsNullOrEmpty(odinItemUpdateRecord.BillOfMaterials))
                    {
                        foreach (string x in odinItemUpdateRecord.BillOfMaterials.Split(','))
                        {
                            ChildElement billOfMaterial = new ChildElement(x, itemId);
                            item.BillOfMaterials.Add(billOfMaterial);
                        }
                    }
                    item.AccountingGroup = odinItemUpdateRecord.AccountingGroup;
                    item.AltImageFile1 = odinItemUpdateRecord.AltImageFile1;
                    item.AltImageFile2 = odinItemUpdateRecord.AltImageFile2;
                    item.AltImageFile3 = odinItemUpdateRecord.AltImageFile3;
                    item.AltImageFile4 = odinItemUpdateRecord.AltImageFile4;
                    item.CasepackHeight = odinItemUpdateRecord.CasepackHeight;
                    item.CasepackLength = odinItemUpdateRecord.CasepackLength;
                    item.CasepackQty = odinItemUpdateRecord.CasepackQty;
                    item.CasepackUpc = odinItemUpdateRecord.CasepackUpc;
                    item.CasepackWidth = odinItemUpdateRecord.CasepackWidth;
                    item.CasepackWeight = odinItemUpdateRecord.CasepackWeight;
                    item.Category = odinItemUpdateRecord.Category;
                    item.Category2 = odinItemUpdateRecord.Category2;
                    item.Category3 = odinItemUpdateRecord.Category3;
                    item.Color = odinItemUpdateRecord.Color;
                    item.Copyright = odinItemUpdateRecord.Copyright;
                    item.CountryOfOrigin = odinItemUpdateRecord.CountryOfOrigin;
                    item.CostProfileGroup = odinItemUpdateRecord.CostProfileGroup;
                    item.Description = odinItemUpdateRecord.Description;
                    item.DirectImport = odinItemUpdateRecord.DirectImport;
                    item.DefaultActualCostCad = odinItemUpdateRecord.DefaultActualCostCad;
                    item.DefaultActualCostUsd = odinItemUpdateRecord.DefaultActualCostUsd;
                    item.Duty = odinItemUpdateRecord.Duty;
                    item.Ean = odinItemUpdateRecord.Ean;
                    item.Gpc = odinItemUpdateRecord.Gpc;
                    item.Height = odinItemUpdateRecord.Height;
                    item.ImagePath = odinItemUpdateRecord.ImagePath;
                    item.InnerpackHeight = odinItemUpdateRecord.InnerpackHeight;
                    item.InnerpackLength = odinItemUpdateRecord.InnerpackLength;
                    item.InnerpackQuantity = odinItemUpdateRecord.InnerpackQty;
                    item.InnerpackUpc = odinItemUpdateRecord.InnerpackUpc;
                    item.InnerpackWidth = odinItemUpdateRecord.InnerpackWidth;
                    item.InnerpackWeight = odinItemUpdateRecord.InnerpackWeight;
                    item.Isbn = odinItemUpdateRecord.Isbn;
                    item.ItemFamily = odinItemUpdateRecord.ItemFamily;
                    item.ItemGroup = odinItemUpdateRecord.ItemGroup;
                    item.ItemId = odinItemUpdateRecord.InvItemId;
                    item.ItemKeywords = odinItemUpdateRecord.ItemKeywords;
                    item.Language = odinItemUpdateRecord.Language;
                    item.License = odinItemUpdateRecord.License;
                    item.LicenseBeginDate = odinItemUpdateRecord.LicenseBeginDate;
                    item.ListPriceUsd = odinItemUpdateRecord.ListPriceUsd;
                    item.ListPriceCad = odinItemUpdateRecord.ListPriceCad;
                    item.ListPriceMxn = odinItemUpdateRecord.ListPriceMxn;
                    item.Length = odinItemUpdateRecord.Length;
                    item.MetaDescription = odinItemUpdateRecord.MetaDescription;
                    item.MfgSource = odinItemUpdateRecord.MfgSource;
                    item.Msrp = odinItemUpdateRecord.Msrp;
                    item.MsrpCad = odinItemUpdateRecord.MsrpCad;
                    item.MsrpMxn = odinItemUpdateRecord.MsrpMxn;
                    item.ItemCategory = odinItemUpdateRecord.ItemCategory;
                    item.PrintOnDemand = odinItemUpdateRecord.PrintOnDemand;
                    item.ProductFormat = odinItemUpdateRecord.ProductFormat;
                    item.ProductGroup = odinItemUpdateRecord.ProductGroup;
                    item.ProductLine = odinItemUpdateRecord.ProductLine;
                    item.ProductQty = odinItemUpdateRecord.ProdQty;
                    item.Property = odinItemUpdateRecord.Property;
                    item.PricingGroup = odinItemUpdateRecord.PricingGroup;
                    item.PsStatus = odinItemUpdateRecord.PsStatus;
                    item.SatCode = odinItemUpdateRecord.SatCode;
                    item.SellOnAllPosters = odinItemUpdateRecord.SellOnAllposters;
                    item.SellOnAmazon = odinItemUpdateRecord.SellOnAmazon;
                    item.SellOnFanatics = odinItemUpdateRecord.SellOnFanatics;
                    item.SellOnGuitarCenter = odinItemUpdateRecord.SellOnGuitarCenter;
                    item.SellOnHayneedle = odinItemUpdateRecord.SellOnHayneedle;
                    item.SellOnTarget = odinItemUpdateRecord.SellOnTarget;
                    item.SellOnWalmart = odinItemUpdateRecord.SellOnWalmart;
                    item.SellOnWayfair = odinItemUpdateRecord.SellOnWayfair;
                    item.SellOnTrends = odinItemUpdateRecord.SellOnWeb;
                    item.ShortDescription = odinItemUpdateRecord.ShortDesc;
                    item.Size = odinItemUpdateRecord.Size;
                    item.StandardCost = odinItemUpdateRecord.StandardCost;
                    item.StatsCode = odinItemUpdateRecord.StatsCode;
                    item.Status = odinItemUpdateRecord.ItemInputStatus;
                    item.TariffCode = odinItemUpdateRecord.TariffCode;
                    item.Territory = odinItemUpdateRecord.Territory;
                    item.Title = odinItemUpdateRecord.Title;
                    item.Udex = odinItemUpdateRecord.Udex;
                    item.Upc = odinItemUpdateRecord.Upc;
                    item.WebsitePrice = odinItemUpdateRecord.WebsitePrice;
                    item.Weight = odinItemUpdateRecord.Weight;
                    item.Width = odinItemUpdateRecord.Width;
                    item.InStockDate = (!string.IsNullOrEmpty(odinItemUpdateRecord.InStockDate)) ? Convert.ToString(DbUtil.StripTime(odinItemUpdateRecord.InStockDate)) : "";
                    item.Ecommerce_ItemName = odinItemUpdateRecord.AItemName;
                    item.Ecommerce_ModelName = odinItemUpdateRecord.AModelName;
                    item.Ecommerce_ProductCategory = odinItemUpdateRecord.AProductCategory;
                    item.Ecommerce_ProductSubcategory = odinItemUpdateRecord.AProductSubcategory;
                    item.Ecommerce_Asin = odinItemUpdateRecord.AAsin;
                    item.Ecommerce_Bullet1 = odinItemUpdateRecord.ABullet1;
                    item.Ecommerce_Bullet2 = odinItemUpdateRecord.ABullet2;
                    item.Ecommerce_Bullet3 = odinItemUpdateRecord.ABullet3;
                    item.Ecommerce_Bullet4 = odinItemUpdateRecord.ABullet4;
                    item.Ecommerce_Bullet5 = odinItemUpdateRecord.ABullet5;
                    item.Ecommerce_ProductDescription = odinItemUpdateRecord.AProductDescription;
                    item.Ecommerce_ExternalIdType = odinItemUpdateRecord.AExternalIdType;
                    item.Ecommerce_ExternalId = odinItemUpdateRecord.AExternalId;
                    item.Ecommerce_SearchTerms = odinItemUpdateRecord.ASearchTerms;
                    item.Ecommerce_ImagePath1 = odinItemUpdateRecord.AImageUrl1;
                    item.Ecommerce_ImagePath2 = odinItemUpdateRecord.AImageUrl2;
                    item.Ecommerce_ImagePath3 = odinItemUpdateRecord.AImageUrl3;
                    item.Ecommerce_ImagePath4 = odinItemUpdateRecord.AImageUrl4;
                    item.Ecommerce_ImagePath5 = odinItemUpdateRecord.AImageUrl5;
                    item.Ecommerce_Size = odinItemUpdateRecord.ASize;
                    item.Ecommerce_Upc = odinItemUpdateRecord.AUpc;
                    item.Ecommerce_Cost = odinItemUpdateRecord.ACost;
                    item.Ecommerce_Msrp = odinItemUpdateRecord.AMsrp;
                    item.Ecommerce_ManufacturerName = odinItemUpdateRecord.AManufacturerName;
                    item.Ecommerce_ItemLength = odinItemUpdateRecord.AItemLength;
                    item.Ecommerce_ItemHeight = odinItemUpdateRecord.AItemHeight;
                    item.Ecommerce_ItemWeight = odinItemUpdateRecord.AItemWeight;
                    item.Ecommerce_ItemWidth = odinItemUpdateRecord.AItemWidth;
                    item.Ecommerce_PackageHeight = odinItemUpdateRecord.APackageHeight;
                    item.Ecommerce_PackageLength = odinItemUpdateRecord.APackageLength;
                    item.Ecommerce_PackageWeight = odinItemUpdateRecord.APackageWeight;
                    item.Ecommerce_PackageWidth = odinItemUpdateRecord.APackageWidth;
                    item.Ecommerce_PageQty = odinItemUpdateRecord.APageQty;
                    item.Ecommerce_Components = odinItemUpdateRecord.AComponents;

                    item.UserName = odinItemUpdateRecord.Username;
                    item.RecordDate = Convert.ToString(odinItemUpdateRecord.InputDate);
                    item.Status = odinItemUpdateRecord.ItemInputStatus;
                    items.Add(item);
                }
            }
            return items;
        }
        
        /// <summary>
        ///     Retrieves a list of all license : Property values
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveLicensePropertyList()
        {
            List<string> results = new List<string>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if (context.OdinWebLicense.Any())
                {
                    var query = (from o in context.OdinWebLicense select o).ToList();
                    foreach (var x in query)
                    {
                        results.Add(x.License + " : " + x.Property);
                    }
                }
            }
            results.Sort();
            return results;
        }

        /// <summary>
        ///     Searches PS_ORD_LINE for any open orders
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>true if any open orders with Item Id exist</returns>
        public bool RetrieveOpenOrderLine(string itemId)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                List<string> results = (from o in context.OrdLine where o.CustomerItemNbr == itemId select o.OrdLineStatus).ToList();
                foreach(string x in results)
                {
                    if(x == "P" || x == "O")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        ///     Retrives a child / parent match from PS_MARKETPLACE_PRODUCT_TRANSLATIONS
        /// </summary>
        /// <param name="childIt"></param>
        /// <param name="parentId"></param>
        /// <returns>true if match exists</returns>
        public bool RetrieveProductIdTranslationMatch(string childId, string parentId)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                MarketplaceProductTranslations match = (from o in context.MarketplaceProductTranslations
                                                        where o.FromProductId == parentId
                                                        && o.ToProductId == childId
                                                        select o).FirstOrDefault();

                if (match != null)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///     Returns the value of the save progress value
        /// </summary>
        /// <returns></returns>
        public string RetrieveSaveProgress()
        {
            return this.SaveProgress;
        }

        /// <summary>
        ///     Returns the web category code associated with the given name
        /// </summary>
        /// <param name="value"></param>
        public string RetrieveWebCategoryCodeByName(string value)
        {
            if (GlobalData.WebCategoryList.Values.Contains(value))
            {
                return GlobalData.WebCategoryList.FirstOrDefault(x => x.Value == value).Key;
            }
            else
            {
                return "";
            }
        }

        #endregion // Public Retrieval Methods

        #region Public Update Methods

        /// <summary>
        ///     Runs UpdateBuItemsInv for each business Unit
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>

        public void UpdateBuItemsInvAll(ItemObject item, OdinContext context)
        {
            UpdateBuItemsInv(item, "TRMX1", item.DefaultActualCostUsd, context);
            UpdateBuItemsInv(item, "TRUS1", item.DefaultActualCostUsd, context);
            UpdateBuItemsInv(item, "TRCN1", item.DefaultActualCostCad, context);

        }

        /// <summary>
        ///     Updates the category in Odin_NewWebCategories
        /// </summary>
        /// <param name="category">Category to be removed</param>
        public void UpdateCategory(string category, string oldCategory)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                OdinNewWebCategories odinNewWebCategories = (from o in context.OdinNewWebCategories where o.Category == oldCategory select o).FirstOrDefault();
                if (odinNewWebCategories != null)
                {
                    odinNewWebCategories.Category = category;
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        ///     Runs UpdateCmItemMethod for each customer
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public void UpdateCmItemMethodAll(ItemObject item, OdinContext context)
        {
            UpdateCmItemMethod(item, "TRUS1", context);
            UpdateCmItemMethod(item, "TRCN1", context);

        }

        /// <summary>
        ///     Runs UpdateCustomerProductAttributes for each customer
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public void UpdateCustomerProductAttributesAll(ItemObject item, OdinContext context)
        {
            UpdateCustomerProductAttributes(item.ItemId, RetrieveCustomerId("ALL POSTERS"), item.SellOnAllPosters, context);
            UpdateCustomerProductAttributes(item.ItemId, RetrieveCustomerId("AMAZON"), item.SellOnAmazon, context);
            UpdateCustomerProductAttributes(item.ItemId, RetrieveCustomerId("FANATICS"), item.SellOnFanatics, context);
            UpdateCustomerProductAttributes(item.ItemId, RetrieveCustomerId("GUITAR CENTER"), item.SellOnGuitarCenter, context);
            UpdateCustomerProductAttributes(item.ItemId, RetrieveCustomerId("HAYNEEDLE"), item.SellOnHayneedle, context);
            UpdateCustomerProductAttributes(item.ItemId, RetrieveCustomerId("TARGET"), item.SellOnTarget, context);
            UpdateCustomerProductAttributes(item.ItemId, RetrieveCustomerId("WALMART"), item.SellOnWalmart, context);
            UpdateCustomerProductAttributes(item.ItemId, RetrieveCustomerId("WAYFAIR"), item.SellOnWayfair, context);
        }

        /// <summary>
        ///     Updates PS_AMAZON_ITEM_ATTRIBUTES
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public void UpdateEcommerceValues(ItemObject item, OdinContext context)
        {
            AmazonItemAttributes amazonItemAttributes = context.AmazonItemAttributes.SingleOrDefault(o => o.InvItemId == item.ItemId);
            if (amazonItemAttributes != null)
            {
                string cost = (!string.IsNullOrEmpty(item.Ecommerce_Cost)) ? item.Ecommerce_Cost : "0";
                string height = (!string.IsNullOrEmpty(item.Ecommerce_ItemHeight)) ? item.Ecommerce_ItemHeight : "0";
                string length = (!string.IsNullOrEmpty(item.Ecommerce_ItemLength)) ? item.Ecommerce_ItemLength : "0";
                string weight = (!string.IsNullOrEmpty(item.Ecommerce_ItemWeight)) ? item.Ecommerce_ItemWeight : "0";
                string width = (!string.IsNullOrEmpty(item.Ecommerce_ItemWidth)) ? item.Ecommerce_ItemWidth : "0";
                string packageHeight = (!string.IsNullOrEmpty(item.Ecommerce_PackageHeight)) ? item.Ecommerce_PackageHeight : "0";
                string packageLength = (!string.IsNullOrEmpty(item.Ecommerce_PackageLength)) ? item.Ecommerce_PackageLength : "0";
                string packageWeight = (!string.IsNullOrEmpty(item.Ecommerce_PackageWeight)) ? item.Ecommerce_PackageWeight : "0";
                string packageWidth = (!string.IsNullOrEmpty(item.Ecommerce_PackageWidth)) ? item.Ecommerce_PackageWidth : "0";
                string pageQty = (!string.IsNullOrEmpty(item.Ecommerce_PageQty)) ? item.Ecommerce_PageQty : "0";
                string msrp = (!string.IsNullOrEmpty(item.Ecommerce_Msrp)) ? item.Ecommerce_Msrp : "0";

                amazonItemAttributes.Asin = item.Ecommerce_Asin;
                amazonItemAttributes.Bullet1 = item.Ecommerce_Bullet1;
                amazonItemAttributes.Bullet2 = item.Ecommerce_Bullet2;
                amazonItemAttributes.Bullet3 = item.Ecommerce_Bullet3;
                amazonItemAttributes.Bullet4 = item.Ecommerce_Bullet4;
                amazonItemAttributes.Bullet5 = item.Ecommerce_Bullet5;
                amazonItemAttributes.Components = item.Ecommerce_Components;
                amazonItemAttributes.Cost = Convert.ToDecimal(cost);
                amazonItemAttributes.CountryOfOrigin = item.Ecommerce_CountryofOrigin;
                amazonItemAttributes.ExternalId = item.Ecommerce_ExternalId;
                amazonItemAttributes.ExternalIdType = item.Ecommerce_ExternalIdType;
                amazonItemAttributes.ImageUrl1 = item.Ecommerce_ImagePath1;
                amazonItemAttributes.ImageUrl2 = item.Ecommerce_ImagePath2;
                amazonItemAttributes.ImageUrl3 = item.Ecommerce_ImagePath3;
                amazonItemAttributes.ImageUrl4 = item.Ecommerce_ImagePath4;
                amazonItemAttributes.ImageUrl5 = item.Ecommerce_ImagePath5;
                amazonItemAttributes.Height = Convert.ToDecimal(height);
                amazonItemAttributes.ItemName = item.Ecommerce_ItemName;
                amazonItemAttributes.Length = Convert.ToDecimal(length);
                amazonItemAttributes.Weight = Convert.ToDecimal(weight);
                amazonItemAttributes.Width = Convert.ToDecimal(width);
                amazonItemAttributes.ModelName = item.Ecommerce_ModelName;
                amazonItemAttributes.PackageHeight = Convert.ToDecimal(packageHeight);
                amazonItemAttributes.PackageLength = Convert.ToDecimal(packageLength);
                amazonItemAttributes.PackageWeight = Convert.ToDecimal(packageWeight);
                amazonItemAttributes.PackageWidth = Convert.ToDecimal(packageWidth);
                amazonItemAttributes.PageCount = Convert.ToInt16(pageQty);
                amazonItemAttributes.ProductCategory = item.Ecommerce_ProductCategory;
                amazonItemAttributes.FullDescription = item.Ecommerce_ProductDescription;
                amazonItemAttributes.ProductSubcategory = item.Ecommerce_ProductSubcategory;
                amazonItemAttributes.ManufacturerName = item.Ecommerce_ManufacturerName;
                amazonItemAttributes.Msrp = Convert.ToDecimal(msrp);
                amazonItemAttributes.SearchTerms = item.Ecommerce_SearchTerms.ToLower();
                amazonItemAttributes.Size = item.Ecommerce_Size;
                amazonItemAttributes.UpcOverride = item.Ecommerce_Upc.Trim();
            }
            else
            {
                // if item ecommerce doesn't already exist insert new line
                InsertEcommerceValues(item, context);
            }
        }

        /// <summary>
        ///     Runs UpdateFxdBinLocInv for each business Unit
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void UpdateFxdBinLocInvAll(ItemObject item)
        {
            using (OdinContext removeContext = this.contextFactory.CreateContext())
            {
                RemoveFxdBinLocInv(item.ItemId, removeContext);
                removeContext.SaveChanges();
            }
            using (OdinContext insertContext = this.contextFactory.CreateContext())
            {
                InsertFxdBinLocInvAll(item, insertContext);
                insertContext.SaveChanges();
            }
        }

        /// <summary>
        /// Insert item info(TariffCode, ItemColor, ItemHeight, ItemLength, ItemId, Description, ItemWeight, ItemWidth, Upc) and username to PS_INV_ITEMS
        /// </summary>
        public void UpdateInvItems(ItemObject item, OdinContext context)
        {
            InvItems invItems = context.InvItems.SingleOrDefault(o => o.InvItemId == item.ItemId && o.Setid == "SHARE");
            if (invItems != null)
            {
                invItems.HarmonizedCd = item.TariffCode;
                invItems.InvItemColor = item.Color;
                invItems.InvItemHeight = DbUtil.ToDecimal(item.Height);
                invItems.InvItemLength = DbUtil.ToDecimal(item.Length);
                invItems.InvItemWeight = DbUtil.ToDecimal(item.Weight);
                invItems.Descr254 = item.Description.ToUpper();
                invItems.InvItemWidth = DbUtil.ToDecimal(item.Width);
                invItems.LastMaintOprid = GlobalData.UserName;
                invItems.LastDttmUpdate = DateTime.Now;
                invItems.UpcId = item.Upc;

            }
        }

        /// <summary>
        ///     Updates item info in PS_ITEM_ATTRIB_EX
        /// </summary>
        public void UpdateItemAttribEx(ItemObject item, OdinContext context)
        {
            ItemAttribEx itemAttribEx = context.ItemAttribEx.SingleOrDefault(o => o.InvItemId == item.ItemId && o.Setid == "SHARE");
            if (itemAttribEx != null)
            {
                string licenseBeginDate = !(string.IsNullOrEmpty(item.LicenseBeginDate)) ? item.LicenseBeginDate : "1900-01-01";
                itemAttribEx.AltImageFile1 = item.AltImageFile1;
                itemAttribEx.AltImageFile2 = item.AltImageFile2;
                itemAttribEx.AltImageFile3 = item.AltImageFile3;
                itemAttribEx.AltImageFile4 = item.AltImageFile4;
                itemAttribEx.CasepackHeight = DbUtil.ToDecimal(item.CasepackHeight);
                itemAttribEx.CasepackLength = DbUtil.ToDecimal(item.CasepackLength);
                itemAttribEx.CasepackQty = Convert.ToInt16(item.CasepackQty);
                itemAttribEx.CasepackUpc = item.CasepackUpc;
                itemAttribEx.CasepackWidth = DbUtil.ToDecimal(item.CasepackWidth);
                itemAttribEx.CasepackWeight = DbUtil.ToDecimal(item.CasepackWeight);
                itemAttribEx.DirectImport = item.DirectImport;
                itemAttribEx.Duty = item.Duty;
                itemAttribEx.ImageFileName = item.ImagePath;
                itemAttribEx.InnerpackHeight = DbUtil.ToDecimal(item.InnerpackHeight);
                itemAttribEx.InnerpackLength = DbUtil.ToDecimal(item.InnerpackLength);
                itemAttribEx.InnerpackQty = Convert.ToInt16(item.InnerpackQuantity);
                itemAttribEx.InnerpackUpc = item.InnerpackUpc;
                itemAttribEx.InnerpackWeight = DbUtil.ToDecimal(item.InnerpackWeight);
                itemAttribEx.InnerpackWidth = DbUtil.ToDecimal(item.InnerpackWidth);
                itemAttribEx.LicenseBeginDate = Convert.ToDateTime(licenseBeginDate);
                itemAttribEx.PrintOnDemand = item.PrintOnDemand;
                itemAttribEx.ProdFormat = item.ProductFormat;
                itemAttribEx.ProdGroup = item.ProductGroup;
                itemAttribEx.ProdLine = item.ProductLine;
                itemAttribEx.SatCode = item.SatCode;
                itemAttribEx.SellOnWeb = item.SellOnTrends;
                itemAttribEx.TranslateEdiProd = item.ReturnTranslateEdiProd();
                itemAttribEx.WebsitePrice = DbUtil.ToDecimal(item.WebsitePrice);

            }
        }

        /// <summary>
        ///     Updates the values in PS_ITEM_WEB_INFO
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void UpdateItemWebInfo(ItemObject item, OdinContext context)
        {
            ItemWebInfo itemWebInfo = context.ItemWebInfo.SingleOrDefault(o => o.InvItemId == item.ItemId);

            if (itemWebInfo != null)
            {
                item.CombinedCategories = CombineCategories(item.Category, item.Category2, item.Category3);

                DateTime inStockDate = (!(string.IsNullOrEmpty(item.InStockDate))) ? Convert.ToDateTime(item.InStockDate) : new DateTime(1900, 01, 01);

                itemWebInfo.Active = item.Active;
                itemWebInfo.Category = item.CombinedCategories;
                itemWebInfo.Copyright = item.Copyright;
                itemWebInfo.ImagePath = item.ImagePath;
                itemWebInfo.InStockDate = inStockDate.Date;
                itemWebInfo.InvItemId = item.ItemId;
                itemWebInfo.ItemKeywords = item.ItemKeywords;
                itemWebInfo.License = item.License;
                itemWebInfo.MetaDescription = item.MetaDescription;
                itemWebInfo.ProdQty = item.ProductQty;
                itemWebInfo.Property = item.Property;
                itemWebInfo.ShortDesc = item.ShortDescription;
                itemWebInfo.Size = item.Size;
                itemWebInfo.Title = item.Title;
            }
            else
            {
                InsertItemWebInfo(item, context);
            }
        }

        /// <summary>
        ///     Updates the values in PS_MASTER_ITEM_TBL
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void UpdateMasterItemTbl(ItemObject item, OdinContext context)
        {
            MasterItemTbl masterItemTbl = context.MasterItemTbl.SingleOrDefault(o => o.InvItemId == item.ItemId && o.Setid == "SHARE");
            if (masterItemTbl != null)
            {
                string categoryId = RetriveCategoryId(item.ItemCategory);
                
                masterItemTbl.CategoryId = categoryId;
                masterItemTbl.CmGroup = item.CostProfileGroup;
                masterItemTbl.Descr = DbUtil.Char30(item.Description).ToUpper();
                masterItemTbl.Descr60 = DbUtil.Char60(item.Description.ToUpper());
                masterItemTbl.Descrshort = DbUtil.Char10(item.Description).ToUpper();
                masterItemTbl.InvItemGroup = item.ItemGroup;
                masterItemTbl.InvItemId = item.ItemId;
                masterItemTbl.InvProdFamCd = item.ItemFamily;
                masterItemTbl.ItemFieldC2 = item.PsStatus;
                masterItemTbl.ItmStatusEffdt = Convert.ToDateTime(DbUtil.StripTime(DateTime.Now));
                masterItemTbl.LastDttmUpdate = DateTime.Now;
                masterItemTbl.LastMaintOprid = GlobalData.UserName;
                masterItemTbl.OrigOprid = GlobalData.UserName;

            }
        }

        /// <summary>
        ///     Updates PS_ITEM_WEB_INFO with today's date for the give item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public void UpdateNewDate(string itemId)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                ItemWebInfo itemWebInfo = (from o in context.ItemWebInfo where o.InvItemId == itemId select o).FirstOrDefault();
                if (itemWebInfo != null)
                {
                    itemWebInfo.NewDate = Convert.ToString(DateTime.Now.Date);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        ///     Updates the ON_SITE flag in PS_ITEM_WEB_INFO
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public void UpdateOnSite(string itemId)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                ItemWebInfo itemWebInfo = (from o in context.ItemWebInfo where o.InvItemId == itemId select o).FirstOrDefault();
                if (itemWebInfo != null)
                {
                    itemWebInfo.OnSite = "Y";
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        ///     Updates the values in PS_PROD_ITEM
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void UpdateProdItem(ItemObject item, OdinContext context)
        {
            ProdItem prodItem = context.ProdItem.SingleOrDefault(o => o.InvItemId == item.ItemId && o.Setid == "SHARE");
            if (prodItem != null)
            {
                prodItem.Descr = DbUtil.Char30(item.Description).ToUpper();
                prodItem.Descr254 = item.Description.ToUpper();
                prodItem.ProdCategory = item.ItemCategory;
                prodItem.ProdFieldC10A = item.Isbn;
                prodItem.ProdFieldC10C = item.Gpc;
                prodItem.ProdFieldC30A = item.Ean;
                prodItem.ProdFieldC30B = item.StatsCode;
                prodItem.ProdFieldC30C = item.Udex;
                prodItem.Lastupddttm = DateTime.Now;
                prodItem.LastMaintOprid = GlobalData.UserName;

            }
        }

        /// <summary>
        ///     Updates values in PS_PROD_PGRP_LNK by removing all rows and replacing the data
        /// </summary>
        public void UpdateProdPgrpLnkAll(ItemObject item)
        {
            using (OdinContext context1 = this.contextFactory.CreateContext())
            {
                RemoveProdPgrpLnkAll(item.ItemId, context1);
                context1.SaveChanges();
            }

            using (OdinContext context2 = this.contextFactory.CreateContext())
            {
                InsertProdPgrpLnkAll(item, context2);
                context2.SaveChanges();
            }
        }

        /// <summary>
        ///     Runs UpdateProdPrice for each business unit / ccd combination
        /// </summary>
        public void UpdateProdPriceAll(ItemObject item, OdinContext context)
        {
            UpdateProdPrice(item, "TRCN1", "CAD", item.ListPriceCad, DbUtil.AssignMsrp(item.MsrpCad, item.Msrp), context);
            UpdateProdPrice(item, "TRUS1", "CAD", item.ListPriceCad, DbUtil.AssignMsrp(item.MsrpCad, item.Msrp), context);
            UpdateProdPrice(item, "TRUS1", "USD", item.ListPriceUsd, Convert.ToDecimal(item.Msrp), context);
            UpdateProdPrice(item, "TRUS1", "MXN", item.ListPriceMxn, DbUtil.AssignMsrp(item.MsrpMxn, item.Msrp), context);
            UpdateProdPrice(item, "TRMX1", "MXN", item.ListPriceMxn, DbUtil.AssignMsrp(item.MsrpMxn, item.Msrp), context);

        }

        /// <summary>
        ///     Runs InsertProdPriceBu if MXN values had not been previously added
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void UpdateProdPriceBuAll(ItemObject item, OdinContext context)
        {
            if (!(string.IsNullOrEmpty(item.ListPriceMxn)))
            {
                if (!context.ProdPriceBu.Any(o => o.ProductId == item.ItemId && o.CurrencyCd == "MXN"))
                {
                    InsertProdPriceBu(item, "MXN", "TRUS1", context);
                    InsertProdPriceBu(item, "MXN", "TRMX1", context);
                }
            }
        }

        /// <summary>
        ///     Updates the values in PS_PURCH_ITEM_ATTR
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void UpdatePurchItemAttr(ItemObject item, OdinContext context)
        {
            PurchItemAttr purchItemAttr = context.PurchItemAttr.SingleOrDefault(o => o.InvItemId == item.ItemId && o.Setid == "SHARE");
            if (purchItemAttr != null)
            {
                purchItemAttr.Descr = DbUtil.Char30(item.Description).ToUpper();
                purchItemAttr.Descrshort = DbUtil.Char10(item.Description).ToUpper();
                purchItemAttr.PriceList = Convert.ToDecimal(item.StandardCost);
                purchItemAttr.Descr254Mixed = item.Description.ToUpper();
                purchItemAttr.LastDttmUpdate = DateTime.Now;
            }
        }

        /// <summary>
        ///     Updates the values in PS_PV_ITM_CATEGORY by removing the existing line and replacing it
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void UpdatePvItmCategory(ItemObject item)
        {
            using (OdinContext context1 = this.contextFactory.CreateContext())
            {
                RemovePvItmCategory(item, context1);
                context1.SaveChanges();
            }

            using (OdinContext context2 = this.contextFactory.CreateContext())
            {
                InsertPvItmCategory(item, context2);
                context2.SaveChanges();
            }
        }

        #endregion // Public Update Methods

        #endregion // Public Methods

        #region Private Methods

        #region Private Insert Methods

        /// <summary>
        ///     Insert Item info into PS_BU_ITEMS_CONFIG
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        private void InsertBuItemsConfig(ItemObject item, string businessUnit, OdinContext context)
        {
            if (!context.BuItemsConfig.Any(o => o.InvItemId == item.ItemId && o.BusinessUnit == businessUnit))
            {
                context.BuItemsConfig.Add(new BuItemsConfig
                {
                    BusinessUnit = businessUnit,
                    InvItemId = item.ItemId,
                    RuleBasedComp = "Y",
                    RuleBasedOper = "Y",
                    RefBomItem = "",
                    CfgLeadTime = 0,
                    ShipTypeId = "",
                    BusinessUnitCp = "",
                    Lastupddttm = DateTime.Now
                });
            }
        }
        
        /// <summary>
        ///     Insert Item info into PS_BU_ITEMS_INV table
        /// </summary>
        private void InsertBuItemsInv(ItemObject item, string businessUnit, string defaultActualCost, OdinContext context)
        {
            if (!context.BuItemsInv.Any(o => o.InvItemId == item.ItemId && o.BusinessUnit == businessUnit))
            {
                context.BuItemsInv.Add(new BuItemsInv
                {
                    AddHandling = "N",
                    AnndmInstance = 0,
                    AnndmStatus = "1",
                    Aoq = 1,
                    AvailLeadTime = 0,
                    AverageCost = 0,
                    AverageCostMat = 0,
                    BomCode = 1,
                    BomUsage = "1",
                    BusinessUnit = businessUnit,
                    ChargeCode = "",
                    ChargeMarkupAmt = 0,
                    ChargeMarkupPcnt = 0,
                    ConsignedFlag = "N",
                    CostElement = "100",
                    CostGroupCd = "",
                    CountryIstOrigin = item.CountryOfOrigin,
                    CurrentCost = Convert.ToDecimal(defaultActualCost),
                    CycleInstance = 0,
                    DaysSupply = 0,
                    DeclaredValue = 0,
                    DfltActualCost = Convert.ToDecimal(defaultActualCost),
                    DockToStock = 0,
                    DpPolicycontrol = "",
                    DpPolicyset = "",
                    DpPublishDate = null,
                    DpPublishname = "",
                    DtTimestamp = DateTime.Now, // ?
                    EnAutoRev = "N",
                    Eoq = 0,
                    EoqcInstance = 0,
                    EoqcStatus = "1",
                    ExcessBu = "",
                    ExcessInventory = "N",
                    ExportLicNbr = "",
                    ExporterEccn = "",
                    Foq = 0,
                    ForecastItemFlag = "N",
                    Forecaster = "",
                    HistoricalLead = 0,
                    HldcInstance = 0,
                    HldcStatus = "1",
                    InclWipQtyFlg = "N",
                    InspectTime = 0,
                    InvItemId = item.ItemId,
                    InvStockType = "",
                    InventoryItem = "Y",
                    IpPlanningFlg = "N",
                    IsolateItemFlg = "N",
                    IssueMethod = "ISS",
                    IssueMultiple = 1,
                    IstRegionOrigin = "",
                    ItemFieldC1A = "",
                    ItemFieldC1B = "",
                    ItemFieldC1C = "",
                    ItemFieldC1D = "",
                    ItemFieldC10A = "",
                    ItemFieldC10B = "",
                    ItemFieldC10C = "",
                    ItemFieldC10D = "",
                    ItemFieldC2 = "A",
                    ItemFieldC30A = "",
                    ItemFieldC30B = "",
                    ItemFieldC30C = "",
                    ItemFieldC30D = "",
                    ItemFieldC4 = "",
                    ItemFieldC6 = "",
                    ItemFieldC8 = "",
                    ItemFieldN12A = 0,
                    ItemFieldN12B = 0,
                    ItemFieldN12C = 0,
                    ItemFieldN12D = 0,
                    ItemFieldN15A = 0,
                    ItemFieldN15B = 0,
                    ItemFieldN15C = 0,
                    ItemFieldN15D = 0,
                    ItmStatDtFuture = null,
                    ItmStatusCurrent = "1",
                    ItmStatusEffdt = DbUtil.StripTime(DateTime.Now),
                    ItmStatusFuture = "",
                    Last2QtrDemand = 0,
                    LastAdjustment = null,
                    LastAnnualDemand = 0,
                    LastCycleCount = DbUtil.StripTime(DateTime.Now),
                    LastDemandCalc = "",
                    LastDemandDate = null,
                    LastIssExcess = 0,
                    LastMoDemand = 0,
                    LastOrder = "",
                    LastOrderDate = null,
                    LastPitCount = null,
                    LastPricePaid = 0,
                    LastPutawayDate = null,
                    LastQtrDemand = 0,
                    LastUdDemand = 0,
                    LastUtilReview = null,
                    MasterRtgOpt = "ITM",
                    MaterialReconFlg = "N",
                    MfgCostedFlag = "Y",
                    MfgLeadtimeF = 0,
                    MfgLeadtimeV = 0,
                    MfgLtratef = "HR",
                    MfgLtratev = "HR",
                    MgAssociatedBom = item.ItemId,
                    MgPrdnOption = "01",
                    MgValidPrdnOpt = "N",
                    NextUtilReview = null,
                    NoReplenishFlg = "Y",
                    NonOwnFlag = "N",
                    OrderMultiple = 0,
                    Oversized = "N",
                    PhantomItemFlag = "N",
                    PlannerCd = "",
                    PrdnAreaCode = "",
                    ProjectedLead = 0,
                    QtyAvailable = 0,
                    QtyIutPar = 0,
                    QtyMaximum = 0,
                    QtyOnhand = 0,
                    QtyOwned = 0,
                    QtyReserved = 0,
                    RefRoutingItem = item.ItemId,
                    RelatedItemId = "",
                    ReorderPoint = 0,
                    ReorderQty = 0,
                    ReplCalcPeriod = 365,
                    ReplenishClass = "",
                    ReplenishLead = 0,
                    ReplenishPoint = 0,
                    RetestLeadTime = 0,
                    RevisionControl = "N",
                    RopcInstance = 0,
                    RopcStatus = "1",
                    RtgCode = 0,
                    SafetyLeadTime = 0,
                    SafetyStock = 0,
                    SfDispatchMode = "",
                    SfRplMethod = "3",
                    SfRplMode = "1",
                    SfRplPrdnArea = "",
                    SfRplSource = "1",
                    SfRplStorArea = "",
                    SfRplStorLev1 = "",
                    SfRplStorLev2 = "",
                    SfRplStorLev3 = "",
                    SfRplStorLev4 = "",
                    SfRplType = "1",
                    SfRplVendorId = "",
                    SfRplVndrLoc = "",
                    SfWipMaxQty = 0,
                    ShelfLife = 0,
                    ShipTypeId = "",
                    SourceCode = item.MfgSource,
                    SstcInstance = 0,
                    SstcStatus = "1",
                    StagedDateFlag = "N",
                    StdPackUom = "EA",
                    StockoutRate = 95,
                    TargetLevel = 0,
                    TransferMinOrder = 0,
                    TransferYield = 0,
                    TransitCostTyp = "F",
                    UomConvFlag = "0",
                    UseUpQoh = "N",
                    UsgTrckngMethod = "01",
                    VendorId = "",
                    VndrLoc = "",
                    WipMinQty = 0,
                    YieldCalcFlg = "N"
                });
            }
        }

        /// <summary>
        /// Insert item info(itemId) into table PS_BU_ITEM_UTIL_CD x 2
        /// </summary>
        private void InsertBuItemUtilCd(ItemObject item, string businessUnit, OdinContext context)
        {
            if (!context.BuItemUtilCd.Any(o => o.InvItemId == item.ItemId && o.BusinessUnit == businessUnit))
            {
                context.BuItemUtilCd.Add(new BuItemUtilCd
                {
                    BusinessUnit = businessUnit,
                    InvItemId = item.ItemId,
                    PlanningFlg = "N",
                    UtilizCd = "",
                    UtilizGroup = "MC"
                });
            }
        }

        /// <summary>
        /// Insert item info into table PS_CM_ITEM_METHOD
        /// </summary>
        private void InsertCmItemMethod(ItemObject item, string businessUnit, OdinContext context)
        {
            if (!context.CmItemMethod.Any(o => o.InvItemId == item.ItemId && o.BusinessUnit == businessUnit))
            {
                string cmProfileId = (item.CostProfileGroup == "ACTUAL_FIFO") ? cmProfileId = "ACTFIFO" : "MFGACTFIFO";

                context.CmItemMethod.Add(new CmItemMethod
                {
                    BusinessUnit = businessUnit,
                    CmBook = "FIN",
                    CmProfileId = cmProfileId,
                    InvItemId = item.ItemId
                });
            }
        }
        
        /// <summary>
        ///     Insert rows into the PS_CUSTOMER_PRODUCT_ATTRIBUTES table. Set the flag for the given customer
        ///     to allow sales of the given item.
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="customerId"></param>
        /// <param name="flag"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private void InsertCustomerProductAttributes(string itemId, string customerId, string sendInventoryFlag, OdinContext context)
        {
            if (!context.CustomerProductAttributes.Any(o => o.ProductId == itemId && o.CustId == customerId && o.Setid == "SHARE"))
            {
                context.CustomerProductAttributes.Add(new CustomerProductAttributes
                {
                    Setid = "SHARE",
                    ProductId = itemId,
                    CustId = customerId,
                    InnerpackQty = 0,
                    CasepackQty = 0,
                    SendInventory = sendInventoryFlag
                });
            }
        }

        /// <summary>
        /// Insert item info(itemId) into table PS_DEFAULT_LOC_INV x2
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        private void InsertDefaultLocInv(ItemObject item, string businessUnit, OdinContext context)
        {
            if (!context.DefaultLocInv.Any(o => o.InvItemId == item.ItemId && o.BusinessUnit == businessUnit && o.DefLocType == "O"))
            {
                context.DefaultLocInv.Add(new DefaultLocInv
                {
                    BusinessUnit = businessUnit,
                    DefLocType = "O",
                    InvItemId = item.ItemId,
                    StorageArea = "RECV",
                    StorLevel1 = "0",
                    StorLevel2 = "0",
                    StorLevel3 = "",
                    StorLevel4 = ""
                });
            }
        }
 
        /// <summary>
        ///     Inserts rows into PS_EN_BOM_COMPS for each bill of materials in item.BillOfMaterials
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        private void InsertEnBomComps(ItemObject item, string childId, int childQty, OdinContext context)
        {
            if (!context.EnBomComps.Any(o => o.InvItemId.Trim() == item.ItemId.Trim() && o.BusinessUnit == "TRUS1" && o.ComponentId.Trim() == childId.Trim() && o.BomState == "PR" && o.BomType == "PR" && o.BomCode == 1 && o.OpSequence == 0))
            {
                context.EnBomComps.Add(new EnBomComps
                {
                    BusinessUnit = "TRUS1",
                    InvItemId = item.ItemId,
                    BomState = "PR",
                    BomType = "PR",
                    BomCode = 1,
                    ComponentId = childId.Trim(),
                    OpSequence = 0,
                    DateInEffect = Convert.ToDateTime("1900-01-01 00:00:00.000"),
                    DateObsolete = Convert.ToDateTime("2099-12-31 00:00:00.000"),
                    PosNbr = 0,
                    QtyPer = childQty,
                    QtyCode = "ASY",
                    Yield = 100,
                    EcoId = "",
                    PendingStatus = "ACT",
                    SubSupplyFlg = "N",
                    NonOwnFlag = "N",
                    TeardownFlag = "N",
                    RollupFlg = "N",
                    EnSubsExist = "N",
                    InvItemSize = "",
                    InvItemHeight = Convert.ToDecimal(0.0300),
                    InvItemLength = Convert.ToDecimal(37.0000),
                    InvItemWidth = Convert.ToDecimal(25.0000),
                    InvItemWeight = Convert.ToDecimal(0.1250),
                    InvItemVolume = 0,
                    UnitMeasureDim = "IN",
                    UnitMeasureWt = "LB",
                    UnitMeasureVol = "",
                    Text254 = "",
                    IncrConsType = "1",
                    IncrConsOffset = 0,
                    CompRev = ""
                });
            }
        }
                
        /// <summary>
        /// Insert info(itemId) to table PS_FXD_BIN_LOC_INV
        /// </summary>
        private void InsertFxdBinLocInv(ItemObject item, string businessUnit, OdinContext context)
        {
            if (!context.FxdBinLocInv.Any(o => o.InvItemId == item.ItemId && o.BusinessUnit == businessUnit && o.StorageArea == "PICK"))
            {
                string fpll1 = "0";
                if ((!string.IsNullOrEmpty(item.ItemGroup)) && (!string.IsNullOrEmpty(item.ItemFamily)))
                {
                    if ((item.ItemGroup.ToUpper() == "POSTER") && (item.ItemFamily.ToUpper() == "FLAT"))
                    {
                        fpll1 = "10";
                    }
                }
                context.FxdBinLocInv.Add(new FxdBinLocInv
                {
                    BusinessUnit = businessUnit,
                    InvItemId = item.ItemId,
                    PickingOrder = 1,
                    QtyOptimal = 0,
                    StorageArea = "PICK",
                    StorLevel1 = fpll1,
                    StorLevel2 = "0",
                    StorLevel3 = "",
                    StorLevel4 = "",
                    UnitOfMeasure = "EA"
                });
            }
        }

        /// <summary>
        ///     Inserts new language values into PS_ITEM_LANGUAGE
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        private void InsertItemLanguage(ItemObject item, string languageCd, OdinContext context)
        {
            if (!context.ItemLanguage.Any(o => o.InvItemId == item.ItemId && o.LanguageCd == languageCd && o.Setid == "SHARE"))
            {
                context.ItemLanguage.Add(new ItemLanguage
                {
                    InvItemId = item.ItemId,
                    LanguageCd = languageCd,
                    Setid = "SHARE"
                });
            }
        }

        /// <summary>
        ///     Inserts new language values into PS_ITEM_TERRITORY
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        public void InsertItemTerritory(ItemObject item, string territory, OdinContext context)
        {
            if (!context.ItemTerritory.Any(o => o.InvItemId == item.ItemId && o.Territory == territory && o.Setid == "SHARE"))
            {
                context.ItemTerritory.Add(new ItemTerritory
                {
                    InvItemId = item.ItemId,
                    Setid = "SHARE",
                    Territory = territory
                });
            }
        }

        /// <summary>
        /// Insert item info(itemId) into table PS_PL_ITEM_ATTRIB
        /// </summary>
        private void InsertPlItemAttrib(ItemObject item, string businessUnit, OdinContext context)
        {
            if (!context.PlItemAttrib.Any(o => o.InvItemId == item.ItemId && o.BusinessUnit == businessUnit))
            {
                context.PlItemAttrib.Add(new PlItemAttrib
                {
                    BusinessUnit = businessUnit,
                    InvItemId = item.ItemId,
                    ReschOutFactor = 0,
                    ReschInFactor = 0,
                    DemandFenceOf = 0,
                    PlanFenceOff = 0,
                    PlanHorizon = 999,
                    TransferMinOrder = 0,
                    TransferMaxOrder = 0,
                    TransOrdMultiple = 1,
                    TransferOrdMod = "N",
                    PurMinOrder = 0,
                    PurMaxOrder = 0,
                    PurOrderMultiple = 1,
                    PurOrderMod = "N",
                    MfgModUnit = "",
                    MfgMinOrder = 0,
                    MfgMaxOrder = 0,
                    MfgOrderMultiple = 1,
                    MfgOrderMod = "N",
                    MfgLeadTimeFlag = "N",
                    SafetyLevel = 0,
                    ExcessLevel = 0,
                    AutoApproveMsg = "",
                    PlannerCd = "",
                    PurchaseYield = 100,
                    TransferYield = 100,
                    SalesConsump = "N",
                    ProdConsump = "N",
                    TransConsump = "N",
                    MsrConsump = "N",
                    ExtraConsump = "N",
                    PlAggDmdFlag = "N",
                    ReleasedOrder = 999,
                    FirmedOrder = 0,
                    PlPrioFamily = "",
                    UseShiptoLoc = "N",
                    PlFixedPeriod = 0,
                    PlItemExpl = "N",
                    PlProjUseDt = null,
                    PlannedBy = "4",
                    CapFenceOff = 0,
                    FcstFulfillSize = 0,
                    FcstAdjAction = "1",
                    EarlyFence = 0,
                    GblEarlyFence = "Y",
                    PlSearchDepth = 1,
                    SpotBuyFlg = "N"
                });
            }
        }

        /// <summary>
        /// Insert item info into PS_PROD_PGRP_LNK
        /// </summary>
        private void InsertProdPgrpLnk(ItemObject item, string prodGroupType, string prodGroup, string primPrcFlag, OdinContext context)
        {
            if (!context.ProdPgrpLnk.Any(o => o.ProductId == item.ItemId && o.ProdGrpType == prodGroupType && o.Setid == "SHARE"))
            {
                context.ProdPgrpLnk.Add(new ProdPgrpLnk
                {
                    DatetimeAdded = DateTime.Now,
                    LastMaintOprid = GlobalData.UserName,
                    Lastupddttm = DateTime.Now,
                    PrimaryFlag = "N",
                    PrimPrcFlag = primPrcFlag,
                    ProdGrpType = prodGroupType,
                    ProductGroup = prodGroup,
                    ProductId = item.ItemId,
                    Setid = "SHARE"
                });
            }
        }

        /// <summary>
        ///     Insert item info into PS_PROD_PRICE
        /// </summary>
        private void InsertProdPrice(ItemObject item, string businessUnit, string currencyCode, string listPrice, Decimal msrp, OdinContext context)
        {
            context.ProdPrice.Add(new ProdPrice
            {
                BusinessUnitIn = businessUnit,
                CurrencyCd = currencyCode,
                DatetimeAdded = DateTime.Now,
                Effdt = Convert.ToDateTime("1901-01-01"),
                EffStatus = "A",
                LastMaintOprid = GlobalData.UserName,
                Lastupddttm = DateTime.Now,
                ListPrice = Convert.ToDecimal(listPrice),
                MfgSugRtlPrc = msrp,
                PricingFlag = "",
                ProductId = item.ItemId,
                RepairCost = 0,
                ServiceCost = 0,
                Setid = "SHARE",
                UnitCost = 0,
                UnitOfMeasure = "EA"
            });
        }

        /// <summary>
        /// Insert item info into PS_PROD_PRICE_BU
        /// </summary>
        private void InsertProdPriceBu(ItemObject item, string currencyCode, string businessUnit, OdinContext context)
        {
            if (!context.ProdPriceBu.Any(o => o.ProductId == item.ItemId && o.BusinessUnitIn == businessUnit && o.CurrencyCd == currencyCode))
            {
                context.ProdPriceBu.Add(new ProdPriceBu
                {
                    BusinessUnitIn = businessUnit,
                    CurrencyCd = currencyCode,
                    DatetimeAdded = DateTime.Now,
                    LastMaintOprid = GlobalData.UserName,
                    Lastupddttm = DateTime.Now,
                    ProductId = item.ItemId,
                    Setid = "SHARE",
                    UnitOfMeasure = "EA"
                });
            }
        }
        
        /// <summary>
        ///     Insert a product id translation line into PS_MARKETPLACE_PRODUCT_TRANSLATIONS
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private void InsertProductIdTranslation(string itemId, string childId, int qty, OdinContext context)
        {
            if (!context.MarketplaceProductTranslations.Any(o => o.FromProductId == itemId && o.ToProductId == childId))
            {
                context.MarketplaceProductTranslations.Add(new MarketplaceProductTranslations
                {
                    FromProductId = itemId,
                    ToProductId = childId,
                    ToQty = qty,
                    DttmAdded = DateTime.Now,
                    Oprid = GlobalData.UserName
                });
            }
        }
                
        /// <summary>
        ///     Inserts BOM header Value into PS_SF_PRDN_AREA_IT
        /// </summary>
        /// <param name="category"></param>
        private void InsertSfPrdnAreaIt(ItemObject item, OdinContext context)
        {
            if (!context.SfPrdnAreaIt.Any(o => o.InvItemId == item.ItemId))
            {
                context.SfPrdnAreaIt.Add(new SfPrdnAreaIt
                {
                    BusinessUnit = "TRUS1",
                    PrdnAreaCode = "USA",
                    InvItemId = item.ItemId,
                    BomCode = 1,
                    RtgCode = 0,
                    DateInEffect = DateTime.Now,
                    Revision = "",
                    PrimaryFlg = "Y",
                    MaPrdnIdFlg = "Y",
                    IssueMethod = "ISS",
                    PaItStatus = "ACT",
                    PrdnRateQty = 0,
                    NetChangeFlg = "N",
                    NetChangeEp = "N",
                    PaItPriority = 0,
                    Percentage = 0,
                    LockBomRtgFlg = "N",
                    PrdnSchDefnFlg = "CMP",
                    BegSeq = "",
                    PrdnAreaItemTxt = null
                });
            }
        }

        /// <summary>
        ///     Insert Item info into PS_UOM_TYPE_INV
        /// </summary>
        private void InsertUomTypeInv(ItemObject item, string invUomType, OdinContext context)
        {
            if (!context.UomTypeInv.Any(o => o.InvItemId == item.ItemId && o.InvUomType == invUomType))
            {
                context.UomTypeInv.Add(new UomTypeInv
                {
                    Setid = "SHARE",
                    InvItemId = item.ItemId,
                    UnitOfMeasure = "EA",
                    InvUomType = invUomType
                });
            }
        }

        #endregion // Private Insert Methods

        #region Private Removal Methods

        /// <summary>
        ///     Removes all values from PS_EN_BOM_COMPS where COMPONENT_ID = the given itemid
        /// </summary>
        /// <param name="category">item id of bom components to remove</param>
        private void RemoveEnBomCompsAll(string itemId)
        {
            using (OdinContext context1 = this.contextFactory.CreateContext())
            {
                foreach (EnBomComps enBomComps in (from o in context1.EnBomComps where o.ComponentId == itemId select o))
                {
                    context1.EnBomComps.Remove(enBomComps);
                }
                context1.SaveChanges();
            }
        }

        /// <summary>
        ///     Removes all values from PS_FXD_BIN_LOC_INV where InvItemId = the given itemid
        /// </summary>
        /// <param name="category">item id of bom components to remove</param>
        private void RemoveFxdBinLocInv(string itemId, OdinContext context)
        {
            foreach (FxdBinLocInv fxdBinLocInv in (from o in context.FxdBinLocInv where o.InvItemId == itemId select o))
            {
                context.FxdBinLocInv.Remove(fxdBinLocInv);
            }
        }

        /// <summary>
        ///     Removes all values from PS_ITEM_LANGUAGE that corespond with the given item id
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private void RemoveItemLanguageAll(ItemObject item, OdinContext context)
        {
            foreach (ItemLanguage itemLanguage in (from o in context.ItemLanguage where o.InvItemId == item.ItemId select o))
            {
                context.ItemLanguage.Remove(itemLanguage);
            }
        }
        
        /// <summary>
        ///     Removes all values from PS_ITEM_TERRITORY that corespond with the given item id
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private void RemoveItemTerritoryAll(ItemObject item, OdinContext context)
        {
            foreach (ItemTerritory itemTerritory in (from o in context.ItemTerritory where o.InvItemId == item.ItemId select o))
            {
                context.ItemTerritory.Remove(itemTerritory);
            }
        }

        /// <summary>
        ///     Removes all values from PS_PROD_PGRP_LNK where ProductId = the given itemid
        /// </summary>
        private void RemoveProdPgrpLnkAll(string itemId, OdinContext context)
        {
            foreach (ProdPgrpLnk prodPgrpLnk in (from o in context.ProdPgrpLnk where o.ProductId == itemId select o))
            {
                context.ProdPgrpLnk.Remove(prodPgrpLnk);
            }
        }

        /// <summary>
        ///     Removes value from PS_PV_ITEM_CATEGORY that coresponds with the given item id
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private void RemovePvItmCategory(ItemObject item, OdinContext context)
        {
            PvItmCategory pvItmCategory = (from o in context.PvItmCategory where o.InvItemId == item.ItemId select o).FirstOrDefault();
            if (pvItmCategory != null)
            {
                context.PvItmCategory.Remove(pvItmCategory);
            }
        }

        #endregion // Private Removal Methods

        #region Private Retrieval Methods

        /// <summary>
        ///     Retrieves Accounting Group values from DB
        /// </summary>
        /// <returns>List of Accounting Group values</returns>
        private List<string> RetrieveAccountingtGroupList()
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                return (from o in context.ProdGroupTbl select o.ProductGroup).ToList();
            }
        }

        /// <summary>
        ///     Retrieves the category id for the given itemCategory
        /// </summary>
        /// <returns>List of Accounting Group values</returns>
        private string RetriveCategoryId(string itemCategory)
        {
            KeyValuePair<string, string> result = GlobalData.ItemCategories.FirstOrDefault(x => x.Value == itemCategory);
            return result.Key;
        }

        /// <summary>
        ///     Retrieves list of the Cost Profile Groups from the DB
        /// </summary>
        /// <returns>List of Cost Profile Groups</returns>
        private List<string> RetrieveCostProfileGroups()
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                return (from o in context.CmGroupDefn select o.CmGroup).ToList();
            }
        }

        /// <summary>
        ///     Retrieves list of countries of origin from db
        /// </summary>
        /// <returns>List of countries of origin</returns>
        private Dictionary<string, string> RetrieveCountriesOfOrigin()
        {
            Dictionary<string, string> returnValues = new Dictionary<string, string>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                List<CountryTbl> countryTbls = (from o in context.CountryTbl select o).ToList();
                foreach (CountryTbl x in countryTbls)
                {
                    returnValues.Add(x.Country, x.Descr);
                }
            }
            return returnValues;
        }
        
        /// <summary>
        ///     Returns the coresponding value for the given key from the customerIdConversion list
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string RetrieveCustomerId(string value)
        {
            return GlobalData.CustomerIdConversions[value];
            
            /*
            foreach (KeyValuePair<string, string> x in GlobalData.CustomerIdConversions)
            {
                if (x.Key == value)
                {
                    return x.Value;
                }
            }
            */
        }

        /// <summary>
        ///     Retrieves a key value pair list of customer names and their coresponding customer ID from the 
        ///     ODIN_CUSTOMER_CONVERSION table.
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> RetrieveCustomerIdConversionsList()
        {
            Dictionary<string, string> returnValues = new Dictionary<string, string>();
            List<string> custNameList = new List<string>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                List<OdinCustomerConversion> odinCustomerConversions = (from o in context.OdinCustomerConversion select o).ToList();
                foreach (OdinCustomerConversion x in odinCustomerConversions)
                {
                    if (!custNameList.Contains(x.CustName))
                    {
                        custNameList.Add(x.CustName);
                        returnValues.Add(x.CustName, x.CorporateCustId);
                    }
                }
            }
            return returnValues;
        }
                
        /// <summary>
        ///     Get list of appropriate External Id types for Amazon Products
        /// </summary>
        /// <returns>List of External Id Types</returns>
        private List<string> RetrieveEcommerce_ExternalIdTypeList()
        {
            List<string> Types = new List<string>( new string[] { "", "ISBN", "EAN", "UPC", "UPC (12-digits)"});
            return Types;
        }
        
        /// <summary>
        ///     Retrieves a List of exception values for a given field
        /// </summary>
        /// <param name="field">Field being granted the exception</param>
        /// <param name="exceptionTrigger">Field that exception looks to</param>
        /// <param name="exceptionResult">What the exception allows.</param>
        /// <returns></returns>
        private List<string> RetrieveExceptions(string field, string exceptionTrigger, string exceptionResult)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                List<OdinItemExceptions> odinItemExceptions = (from o in context.OdinItemExceptions select o).ToList();
                odinItemExceptions = odinItemExceptions.Where(o => o.ExceptionTrigger == exceptionTrigger && o.ExceptionResult == exceptionResult).ToList();
                return odinItemExceptions.Select(o => o.ExceptionValue).ToList();
            }
        }

        /// <summary>
        ///     Retrieves a dictionary of item category name / ids from PS_ITM_CAT_TBL
        /// </summary>
        /// <returns></returns>
        private Dictionary<string,string> RetrieveItemCategories()
        {
            Dictionary<string, string> returnValues = new Dictionary<string, string>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if ((context.ItmCatTbl.Any()))
                {
                    var dataset = context.ItmCatTbl.Select(x => new { x.CategoryId, x.CategoryCd }).ToList();
                    foreach (var x in dataset)
                    {
                        returnValues.Add(x.CategoryId, x.CategoryCd);
                    }
                }
            }
            return returnValues;
        }

        /// <summary>
        ///     Retrieve list of InvItemGroups for dropdown and validation form
        /// </summary>
        /// <returns>List of InvItemGroup values</returns>
        private List<string> RetrieveItemGroups()
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                return (from o in context.InvItemGroup select o.InvItemGroup).ToList();
            }
        }

        /// <summary>
        ///     Retrieves a list of all existing item ids
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private List<string> RetrieveItemIds()
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                return (from o in context.ItemAttribEx select o.InvItemId).ToList();
            }
        }
                
        /// <summary>
        ///     Retrieve list of available languages
        /// </summary>
        /// <returns>List of web languages</returns>
        private List<string> RetrieveLanguages()
        {
            List<string> results = new List<string>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if ((context.LanguageTbl.Any()))
                {
                    results = (from o in context.OdinWebLanguages select o.Language).ToList();
                }
            }
            results.Sort();
            return results;
        }

        /// <summary>
        ///     Retrieve list of Licneses from ODIN_WEB_LICENSE
        /// </summary>
        /// <returns>List of InvItemGroup values</returns>
        private List<string> RetrieveLicenseList()
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                return (from o in context.OdinWebLicense select o.License).Distinct().ToList();
            }
        }
        
        /// <summary>
        ///     Retrieves List of Meta Descriptions
        /// </summary>
        /// <returns></returns>
        private List<string> RetrieveMetaDescriptionList()
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                return (from o in context.OdinMetaDescription orderby o.MetaDescription select o.MetaDescription).ToList();
            }
        }
        
        /// <summary>
        ///     Retrieves Pricing Group values from DB
        /// </summary>
        /// <returns>List of Pricing Group values</returns>
        private List<string> RetrievePriceGroupList()
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                List<string> values = (from o in context.ProdGroupTbl where o.ProdGrpType == "PRC" select o.ProductGroup).ToList();
                values.Add("");
                return values;
            }
        }

        /// <summary>
        ///     Retrieves item category values form prodcatgrytabl for drop down options
        /// </summary>
        /// <returns>List of item category values</returns>
        private List<string> RetrieveProductCategories()
        {
            List<string> values = new List<string>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if ((context.ProdCatgryTbl.Any()))
                {
                    values = (from o in context.ProdCatgryTbl select o.ProdCategory).ToList();
                }
            }
            return values;
        }

        /// <summary>
        ///     Retrieves product format values from db
        /// </summary>
        /// <returns>list of product formats</returns>
        private List<ProductFormat> RetrieveProductFormatList()
        {
            List<ProductFormat> Values = new List<ProductFormat>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if ((context.ProductFormats.Any()))
                {
                    var query = (from o in context.ProductFormats select o).ToList();
                    foreach (var x in query)
                    {
                        Values.Add(new ProductFormat(x.ProdFormat, x.ProdLine, x.ProdGroup));
                    }
                }
            }
            return Values;
        }

        /// <summary>
        ///     Retrieves list of Product Groups
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private List<string> RetrieveProductGroupList()
        {
            List<string> values = new List<string>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if ((context.ProductGroups.Any()))
                {
                    values = (from o in context.ProductGroups select o.ProdGroup).ToList();
                }
            }
            return values;
        }

        /// <summary>
        ///     Retrieve list of all product lines from PS_PRODUCT_LINES with product group values
        /// </summary>
        /// <returns>List of all product lines</returns>
        private List<KeyValuePair<string, string>> RetrieveProductLines()
        {
            List<KeyValuePair<string, string>> results = new List<KeyValuePair<string, string>>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if ((context.ProductLines.Any()))
                {
                    var query = (from o in context.ProductLines select o).ToList();
                    foreach (var x in query)
                    {
                        results.Add(new KeyValuePair<string, string>(x.ProdLine, x.ProdGroup));
                    }
                }
            }
            return results;
        }

        /// <summary>
        ///     Retrieves all property values from OdinWebLicense with license keys
        /// </summary>
        /// <returns></returns>
        private List<KeyValuePair<string, string>> RetrieveProperties()
        {
            List<KeyValuePair<string, string>> results = new List<KeyValuePair<string, string>>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if (context.OdinWebLicense.Any())
                {
                    var query = (from o in context.OdinWebLicense select o).ToList();
                    foreach (var x in query)
                    {
                        results.Add(new KeyValuePair<string, string>(x.License, x.Property));
                    }
                }
            }
            return results;
        }

        /// <summary>
        ///     Retrieve list of ps Statuses from db.
        /// </summary>
        /// <returns>List of product lines</returns>
        private List<string> RetrievePsStatuses()
        {
            List<string> values = new List<string>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if (context.ItemStatusTbl.Any())
                {
                    values = (from o in context.ItemStatusTbl select o.StatusCd).ToList();
                }
            }
            values.Sort();
            return values;
        }

        /// <summary>
        ///     Retrieves a list of special characters that are not allowed for peoplesoft fields
        /// </summary>
        /// <returns>list of special characters</returns>
        private List<string> RetrieveSpecialCharacters()
        {
            List<string> values = new List<string>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if (context.OdinSpecialChars.Any())
                {
                    values = (from o in context.OdinSpecialChars select o.Character).ToList();
                }
            }
            return values;
        }

        /// <summary>
        ///     Retrieves a list of Request statuses
        /// </summary>
        /// <returns></returns>
        private List<string> RetrieveRequestStatuses()
        {
            List<string> results = new List<string>(new string[] {"Pending","Completed","Canceled","Incomplete"});
            return results;
        }

        /// <summary>
        ///     Retrieves all the Tariff Code values from the DB
        /// </summary>
        /// <returns>List of tarriff codes</returns>
        private List<string> RetrieveTariffCodeList()
        {
            List<string> results = new List<string>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if (context.HrmnTariffCd.Any())
                {
                    results = (from o in context.HrmnTariffCd select o.HarmonizedCd).ToList();
                }
                results.Sort();
            }
            return results;
        }

        /// <summary>
        ///     Retrieve list of available territories
        /// </summary>
        /// <returns>List of territories</returns>
        private List<string> RetrieveTerritories()
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                List<string> values = (from o in context.OdinWebTerritories select o.Territory).ToList();
                values.Sort();
                return values;
            }
        }

        /// <summary>
        ///     Retrieves a dictionary of all tool tips
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> RetrieveToolTips()
        {
            Dictionary<string, string> results = new Dictionary<string, string>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                var query = (from o in context.OdinToolTips select o).ToList();
                foreach (var x in query)
                {
                    results.Add(x.Name, x.Value);
                }
            }
            return results;
        }

        /// <summary>
        ///     Retrieve a list of user names
        /// </summary>
        /// <returns></returns>
        private List<string> RetrieveUserNames()
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                List<string> values = (from o in context.OdinUserRoles select o.Username).Distinct().ToList();
                values.Sort();
                return values;
            }
        }

        /// <summary>
        ///     Retrieve a list of user roles
        /// </summary>
        /// <returns></returns>
        private List<string> RetrieveUserRoles()
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                List<string> values = (from o in context.OdinRolePermissions select o.Role).Distinct().ToList();
                values.Add("");
                values.Sort();
                return values;
            }
        }

        /// <summary>
        ///     Retrieves a list of all existing upc / item id & ecommerceUpc / item id pairs
        /// </summary>
        /// <returns></returns>
        private List<KeyValuePair<string, string>> RetrieveUpcs()
        {
            List<KeyValuePair<string, string>> upcs = new List<KeyValuePair<string, string>>();

            using (OdinContext context = this.contextFactory.CreateContext())
            {
                var vanillaUpcs = context.InvItems.Where(x=>x.Setid=="SHARE").Select(x => new { x.UpcId, x.InvItemId }).ToList();
                foreach (var x in vanillaUpcs)
                {
                    upcs.Add(new KeyValuePair<string, string>(x.UpcId, x.InvItemId));
                }
                var ecomUpcs = context.AmazonItemAttributes.Select(x => new { x.UpcOverride, x.InvItemId }).ToList();
                foreach (var x in ecomUpcs)
                {
                    upcs.Add(new KeyValuePair<string, string>(x.UpcOverride, x.InvItemId));
                }
            }
            return upcs;
        }

        /// <summary>
        ///     Retrieves a dictionary of Category name /  id from ODIN_NEW_WEB_CATEGORIES
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> RetrieveWebCategoryList()
        {
            Dictionary<string, string> returnValues = new Dictionary<string, string>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                List<OdinNewWebCategories> odinNewWebCategories = (from o in context.OdinNewWebCategories select o).ToList();
                foreach (OdinNewWebCategories x in odinNewWebCategories)
                {
                    returnValues.Add(x.Id.ToString(), x.Category);
                }
            }
            return returnValues;
        }

        #endregion // Private Retrieval Methods

        #region Private Update Methods

        /// <summary>
        ///     Updates Item info into PS_BU_ITEMS_INV table
        /// </summary>
        private void UpdateBuItemsInv(ItemObject item, string businessUnit, string defaultActualCost, OdinContext context)
        {
            BuItemsInv buItemsInv = context.BuItemsInv.SingleOrDefault(o => o.InvItemId == item.ItemId && o.BusinessUnit == businessUnit);
            if (buItemsInv != null)
            {
                if (buItemsInv.CountryIstOrigin != item.CountryOfOrigin || buItemsInv.CurrentCost != Convert.ToDecimal(defaultActualCost) || buItemsInv.SourceCode != item.MfgSource)
                {
                    buItemsInv.CountryIstOrigin = item.CountryOfOrigin;
                    buItemsInv.CurrentCost = Convert.ToDecimal(defaultActualCost);
                    buItemsInv.DfltActualCost = Convert.ToDecimal(defaultActualCost);
                    buItemsInv.SourceCode = item.MfgSource;
                }
            }
        }
        
        /// <summary>
        ///     Updates the CM_PROFILE_ID field in PS_CM_ITEM_METHOD 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private void UpdateCmItemMethod(ItemObject item, string businessUnit, OdinContext context)
        {
            string cmProfileId = (item.CostProfileGroup == "ACTUAL_FIFO") ? "ACTFIFO" : "MFGACTFIFO";

            CmItemMethod cmItemMethod = context.CmItemMethod.SingleOrDefault(o => o.InvItemId == item.ItemId && o.CmBook == "FIN" && o.BusinessUnit == businessUnit);
            if (cmItemMethod != null)
            {
                cmItemMethod.CmProfileId = cmProfileId;

            }
        }

        /// <summary>
        ///     Updates the SEND_INVENTORY flage in PS_CUSTOMER_PRODUCT_ATTRIBUTES
        /// </summary>
        private void UpdateCustomerProductAttributes(string itemId, string customer, string sellOnFlag, OdinContext context)
        {
            CustomerProductAttributes customerProductAttributes = context.CustomerProductAttributes.SingleOrDefault(o => o.ProductId == itemId && o.CustId == customer && o.Setid == "SHARE");
            if (customerProductAttributes != null)
            {
                if (customerProductAttributes.SendInventory != sellOnFlag)
                {
                    customerProductAttributes.SendInventory = sellOnFlag;
                }
            }
        }
                
        /// <summary>
        ///     Updates item info in PS_PROD_PRICE
        /// </summary>
        private void UpdateProdPrice(ItemObject item, string businessUnit, string currencyCode, string listPrice, Decimal msrp, OdinContext context)
        {
            ProdPrice prodPrice = context.ProdPrice.SingleOrDefault(o => o.ProductId == item.ItemId && o.BusinessUnitIn == businessUnit && o.CurrencyCd == currencyCode);
            if (prodPrice != null)
            {
                if (prodPrice.ListPrice != Convert.ToDecimal(listPrice) || prodPrice.MfgSugRtlPrc != msrp)
                {
                    prodPrice.ListPrice = Convert.ToDecimal(listPrice);
                    prodPrice.Lastupddttm = DateTime.Now;
                    prodPrice.MfgSugRtlPrc = msrp;
                    prodPrice.LastMaintOprid = GlobalData.UserName;
                }
            }
        }
        
        #endregion // Private Update Methods

        #endregion // Private Methods

        #region Constructors

        /// <summary>
        ///     Constructs the ItemRepository class
        /// </summary>
        /// <param name="contextFactory"></param>
        public ItemRepository(IOdinContextFactory contextFactory)
        {
            this.contextFactory = contextFactory ?? throw new ArgumentNullException("contextFactory");
        }

        #endregion // Constructors
    }
}
