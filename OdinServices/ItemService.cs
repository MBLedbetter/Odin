using ExcelLibrary;
using Odin.Data;
using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;

namespace OdinServices
{
    public class ItemService
    {

        #region Enumerations

        /// <summary>
        ///     
        /// </summary>
        private static class WorksheetColumnHeaders
        {
            #region Public Properties

            public static string AccountingGroup = "Accounting Group";
            public static string BillOfMaterials = "Bill Of Materials";
            public static string BOM = "BOM";
            public static string AcctgGroup = "Acctg Group (Product)";
            public static string CasepackHeight = "Casepack Height";
            public static string CasepackLength = "Casepack Length";
            public static string CasepackQty = "Casepack Qty";
            public static string CasepackQuantity = "Casepack Quantity";
            public static string CasepackUpc = "Casepack Upc";
            public static string CasepackWeight = "Casepack Weight";
            public static string CasepackWidth = "Casepack Width";
            public static string Category = "Category";
            public static string Category2 = "Category 2";
            public static string Category3 = "Category 3";
            public static string Color = "Color";
            public static string Copyright = "Copyright";
            public static string CountryOfOrigin = "Country of Origin";
            public static string CostProfileGroup = "Cost Profile Group";
            public static string DefaultActualCostCad = "Default Actual Cost CAD";
            public static string DacCad = "Dac Cad";
            public static string DefaultActualCostUsd = "Default Actual Cost USD";
            public static string DacUsd = "DAC USD";
            public static string Description = "Description";
            public static string DirectImport = "Direct Import";
            public static string DtcPrice = "Dtc Price";
            public static string Duty = "Duty";
            public static string Ean = "Ean";
            public static string EcommerceAsin = "Ecommerce Asin";
            public static string EcommerceBullet1 = "Ecommerce Bullet 1";
            public static string EcommerceBullet2 = "Ecommerce Bullet 2";
            public static string EcommerceBullet3 = "Ecommerce Bullet 3";
            public static string EcommerceBullet4 = "Ecommerce Bullet 4";
            public static string EcommerceBullet5 = "Ecommerce Bullet 5";
            public static string EcommerceComponents = "Ecommerce Components";
            public static string EcommerceCost = "Ecommerce Cost";
            public static string EcommerceCountryofOrigin = "Ecommerce Country of Origin";
            public static string EcommerceExternalId = "Ecommerce External ID";
            public static string EcommerceExternalIdType = "Ecommerce External ID Type";
            public static string EcommerceGenericKeywords = "Ecommerce Generic Keywords";
            public static string EcommerceImagePath1 = "Ecommerce Image Path 1";
            public static string EcommerceImagePath2 = "Ecommerce Image Path 2";
            public static string EcommerceImagePath3 = "Ecommerce Image Path 3";
            public static string EcommerceImagePath4 = "Ecommerce Image Path 4";
            public static string EcommerceImagePath5 = "Ecommerce Image Path 5";
            public static string EcommerceItemHeight = "Ecommerce Item Height";
            public static string EcommerceItemLength = "Ecommerce Item Length";
            public static string EcommerceItemName = "Ecommerce Item Name";
            public static string EcommerceItemTypeKeywords = "Ecommerce Item Type Keywords";
            public static string EcommerceItemWeight = "Ecommerce Item Weight";
            public static string EcommerceItemWidth = "Ecommerce Item Width";
            public static string EcommerceModelName = "Ecommerce Model Name";
            public static string EcommercePackageHeight = "Ecommerce Package Height";
            public static string EcommercePackageLength = "Ecommerce Package Length";
            public static string EcommercePackageWeight = "Ecommerce Package Weight";
            public static string EcommercePackageWidth = "Ecommerce Package Width";
            public static string EcommercePageQty = "Ecommerce Page Qty";
            public static string EcommerceParentAsin = "Ecommerce Parent Asin";
            public static string EcommerceProductCategory = "Ecommerce Product Category";
            public static string EcommerceProductDescription = "Ecommerce Product Description";
            public static string EcommerceProductSubcategory = "Ecommerce Product Subcategory";
            public static string EcommerceManufacturerName = "Ecommerce Manufacturer Name";
            public static string EcommerceMsrp = "Ecommerce Msrp";
            public static string EcommerceSearchTerms = "Ecommerce Search Terms";
            public static string EcommerceSubjectKeywords = "Ecommerce Subject Keywords";
            public static string EcommerceSize = "Ecommerce Size";
            public static string EcommerceUpc = "Ecommerce UPC";
            public static string GenericKeywords = "Generic Keywords";
            public static string Genre1 = "Genre 1";
            public static string Genre2 = "Genre 2";
            public static string Genre3 = "Genre 3";
            public static string Gpc = "Gpc";
            public static string Height = "Height";
            public static string ImagePath = "Image Path";
            public static string ImagePath1 = "Image Path 1";
            public static string ImagePath2 = "Image Path 2";
            public static string ImagePath3 = "Image Path 3";
            public static string ImagePath4 = "Image Path 4";
            public static string ImagePath5 = "Image Path 5";
            public static string ItemHeight = "Item Height";
            public static string InnerpackHeight = "Innerpack Height";
            public static string InnerpackLength = "Innerpack Length";
            public static string InnerpackQuantity = "Innerpack Quantity";
            public static string InnerpackQty = "Innerpack Qty";
            public static string InnerpackUpc = "Innerpack Upc";
            public static string InnerpackWidth = "Innerpack Width";
            public static string InnerpackWeight = "Innerpack Weight";
            public static string InStockDate = "In Stock Date";
            public static string In_StockDate = "In-Stock Date";
            public static string Isbn = "Isbn";
            public static string ItemCategory = "Item Category";
            public static string ItemFamily = "Item Family";
            public static string ItemGroup = "Item Group";
            public static string ItemId = "Item Id";
            public static string ItemKeywords = "Item Keywords";
            public static string ItemKeywordsOverride = "Item Keywords Override";
            public static string ItemLength = "Item Length";
            public static string ItemWeight = "Item Weight";
            public static string ItemWidth = "Item Width";
            public static string LabelColor = "Label Color";
            public static string Language = "Language";
            public static string Length = "Length";
            public static string License = "License";
            public static string LicenseBeginDate = "License Begin Date";
            public static string ListPriceCad = "List Price Cad";
            public static string ListPriceCadCAD = "List Price (CAD)";
            public static string ListPriceMxn = "List Price Mxn";
            public static string ListPriceMxnMXN = "List Price (MXN)";
            public static string ListPriceUsd = "List Price Usd";
            public static string ListPriceUsdUSD = "List Price (USD)";
            public static string MetaDescription = "Meta Description";
            public static string MfgSource = "Mfg Source";
            public static string Msrp = "Msrp";
            public static string MsrpCad = "Msrp CAD";
            public static string MsrpMxn = "Msrp MXN";
            public static string ProductFormat = "Product Format";
            public static string ProductGroup = "Product Group";
            public static string ProductIdTranslation = "Product Id Translation";
            public static string ProductLine = "Product Line";
            public static string ProductQty = "Product Qty";
            public static string ProductQuantity = "Product Quantity";
            public static string Property = "Property";
            public static string PricingGroup = "Pricing Group";
            public static string PrintOnDemand = "Print On Demand";
            public static string PricingGroupProduct = "Price Group (Product)";
            public static string PsStatus = "PS Status";
            public static string RelatedProducts = "Related Products";
            public static string SatCode = "SAT Code";
            public static string SellOnAllPosters = "Sell On All Posters";
            public static string SellOnAmazon = "Sell On Amazon";
            public static string SellOnAmazonSellerCentral = "Sell On Amazon Seller Central";
            public static string SellOnEcommerce = "Sell On Ecommerce";
            public static string SellOnFanatics = "Sell On Fanatics";
            public static string SellOnGuitarCenter = "Sell On Guitar Center";
            public static string SellOnHayneedle = "Sell On Hayneedle";
            public static string SellOnHouzz = "Sell On Houzz";
            public static string SellOnTarget = "Sell On Target";
            public static string SellOnTrends = "Sell On Trends";
            public static string SellOnTrs = "Sell On Trs";
            public static string SellOnShopTrends = "Sell On Shop Trends";
            public static string SellOnWalmart = "Sell On Walmart";
            public static string SellOnWayfair = "Sell On Wayfair";
            public static string ShortDescription = "Short Description";
            public static string Size = "Size";
            public static string StatsCode = "Stats Code";
            public static string Status = "Status";
            public static string SubjectKeywords = "Subject Keywords";
            public static string TariffCode = "Tariff Code";
            public static string Territory = "Territory";
            public static string TemplateName = "Template Name";
            public static string TemplateId = "Template ID";
            public static string Title = "Title";
            public static string TitleOverride = "Title Override";
            public static string Udex = "Udex";
            public static string Upc = "Upc";
            public static string Warranty = "Warranty";
            public static string WarrantyCheck = "WarrantyCheck";
            public static string WebsitePrice = "Website Price";
            public static string WebsitePriceOverride = "Website Price Override";
            public static string Weight = "Weight";
            public static string Width = "Width";

            /* Depricated Amazon Fields */
            
            /// <summary>
            ///     A_AmazonActive is the depricated term for "Sell On Amazon" left if in case someone isn't using the new spreadsheet
            /// </summary>
            public static string A_AmazonActive = "Amazon Active";
            public static string A_Asin = "Amazon Asin";
            public static string A_Bullet1 = "Amazon Bullet 1";
            public static string A_Bullet2 = "Amazon Bullet 2";
            public static string A_Bullet3 = "Amazon Bullet 3";
            public static string A_Bullet4 = "Amazon Bullet 4";
            public static string A_Bullet5 = "Amazon Bullet 5";
            public static string A_Components = "Amazon Components";
            public static string A_Cost = "Amazon Cost";
            public static string A_CountryofOrigin = "Amazon Country of Origin";
            public static string A_ExternalID = "Amazon External ID";
            public static string A_ExternalIdType = "Amazon External ID Type";
            public static string A_ImagePath1 = "Amazon Image Path 1";
            public static string A_ImagePath2 = "Amazon Image Path 2";
            public static string A_ImagePath3 = "Amazon Image Path 3";
            public static string A_ImagePath4 = "Amazon Image Path 4";
            public static string A_ImagePath5 = "Amazon Image Path 5";
            public static string A_ItemHeight = "Amazon Item Height";
            public static string A_ItemLength = "Amazon Item Length";
            public static string A_ItemName = "Amazon Item Name";
            public static string A_ItemWeight = "Amazon Item Weight";
            public static string A_ItemWidth = "Amazon Item Width";
            public static string A_ModelName = "Amazon Model Name";
            public static string A_PackageHeight = "Amazon Package Height";
            public static string A_PackageLength = "Amazon Package Length";
            public static string A_PackageWeight = "Amazon Package Weight";
            public static string A_PackageWidth = "Amazon Package Width";
            public static string A_PageQty = "Amazon Page Qty";
            public static string A_ProductCategory = "Amazon Product Category";
            public static string A_ProductDescription = "Amazon Product Description";
            public static string A_ProductSubcategory = "Amazon Product Subcategory";
            public static string A_ManufacturerName = "Amazon Manufacturer Name";
            public static string A_Msrp = "Amazon Msrp";
            public static string A_SearchTerms = "Amazon Search Terms";
            public static string A_Size = "Amazon Size";

            #endregion // public properties            
        }

        #endregion  // Enumerations

        #region Public Properties

        public IItemRepository ItemRepository { get; private set; }
        
        public ITemplateRepository TemplateRepository { get; private set; }

        public IWorkbookReader WorkbookReader { get; private set; }

        #endregion // Public Properties

        #region Public Methods
                
        /// <summary>
        ///     Assigns the value 'N' to items with no direct import value
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        public string AssignDirectImport(string var)
        {
            if (string.IsNullOrEmpty(var.Trim()))
            {
                return "N";
            }
            else return var;
        }
        
        /// <summary>
        ///     Checks existing bill of materials. If a match exists return true. Else return false.
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="childId"></param>
        /// <returns></returns>
        public bool CheckBillofMaterial(string itemId, string childId)
        {
            foreach(ChildElement x in GlobalData.BillofMaterials)
            {
                if(x.ItemId == childId && x.ParentId == itemId)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///     Checks that provided image path returns a file
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isTest"></param>
        /// <returns></returns>
        public bool CheckFileExists(string value, bool isTest)
        {
            if (!isTest)
            {
                // value = "@" + value;
                if (File.Exists(value))
                {
                    return true;  
                }
            }
            else
            {
                if (value == "testImagePath")
                {
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        ///     Check that the provided image is not too large
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isTest"></param>
        /// <returns>false if file is too large</returns>
        public bool CheckFileSize(string value, bool isTest)
        {
            if (!isTest)
            {
                // value = "@" + value;
                if (File.Exists(value))
                {
                    // Check that file isn't too big, to prevent memory exception
                    if ((new System.IO.FileInfo(value).Length < 20000000))
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (value == "testImagePath")
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///     Checks for existing items with matching UPC, checks to make sure found itemIds do not contain given itemId (ex. RP1234 * RP1234WP)
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="upc"></param>
        /// <param name="itemStatus"></param>
        /// <returns>itemId if a duplicate UPC is found</returns>
        public List<string> CheckDuplicateUPCs(string itemId, string upc, string itemStatus)
        {
            List<string> result = new List<string>();
            string slimItemId = itemId;
            List<string> existingIds = new List<string>();
            if (itemId.Length>2)
            {
                string idSuffix = itemId.Substring(itemId.Length - 2);
                if (GlobalData.ItemIdSuffixes.Contains(idSuffix))
                {
                    slimItemId = itemId.Substring(0, itemId.Length - 2);
                }
            }

            List<KeyValuePair<string, string>> matches = GlobalData.Upcs.Where(v => v.Key == upc).ToList();

            foreach (KeyValuePair<string, string> obj in matches)
            {
                existingIds.Add(obj.Value);
            }
            if (existingIds.Count() == 0)
            {
                return result;
            }
            if(itemStatus == "Add")
            {
                foreach(string id in existingIds)
                {
                    if(!id.Contains(slimItemId) && !itemId.Contains(id))
                    {
                        result.Add(id);                        
                    }
                }
            }
            else if (itemStatus == "Update")
            {
                if (existingIds.Count() == 1)
                {
                    bool existingValue = true;
                    foreach (string id in existingIds)
                    {
                        if (!id.Contains(slimItemId) && !itemId.Contains(id))
                        {
                            existingValue = false;
                            result.Add(id);
                        }
                    }
                    if (existingValue)
                    {
                        return result;
                    }
                }
                else
                {
                    foreach (string id in existingIds)
                    {
                        if (!id.Contains(slimItemId) && !itemId.Contains(id))
                        {
                            result.Add(id);
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        ///     Checks if price field is blank, if it is insert 0.00.
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        public string CheckEmptyPrice(string var)
        {
            if (string.IsNullOrEmpty(var))
            {
                return "0.00";
            }
            else return var;
        }

        /// <summary>
        ///     Check to see if Id already exists in database
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public bool CheckForExistsingItemId(string itemId)
        {
            if (GlobalData.ItemIds.Contains(itemId))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Checks product formats for an object with a matching value. Returns true if match found
        /// </summary>
        /// <param name="prodFormat"></param>
        /// <returns></returns>
        public bool CheckForProductFormat(string prodFormat)
        {
            foreach(ProductFormat x in GlobalData.ProductFormats)
            {
                if(x.Format == prodFormat)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///     Checks if a given value is greater than 0.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if greater than 0</returns>
        public bool CheckGreaterThanZero(string value)
        {
            if (decimal.TryParse(value, out decimal valueDec))
            {
                if (valueDec > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///     Check for duplicate id's in list and check that id exists in database
        /// </summary>
        /// <param name="itemId">item Id being compared</param>
        /// <param name="items">list of items being checked against</param>
        /// <returns></returns>
        public bool CheckIdDuplicate(string itemId, List<string> itemids)
        {
            // if item does not exist in db it can't be updated
            if (!GlobalData.ItemIds.Contains(itemId))
            {
                return false;
            }

            // if the item occurs more than once in the loaded item list it's a duplicate            
            if (itemids.Count(x => x == itemId) == 1)
            {
                return true;
            }
            return false;
        }
        
        /// <summary>
        ///     Searches PS_ORD_LINE for any open orders (ORD_LINE_STATUS = P or O) with the given ItemId = CUSTOMER_ITEM_NBR
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>true if any open orders with Item Id exist</returns>
        public bool CheckItemHasOpenOrderLine(string itemId)
        {
            return ItemRepository.RetrieveOpenOrderLine(itemId);
        }

        /// <summary>
        ///     Checks if product is currently marked as being on site
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        public bool CheckOnSite(string itemId, string site)
        {
            if(site.ToUpper() == "TRENDSINTERNATIONAL.COM")
            {
                return ItemRepository.RetrieveOnSite(itemId);
            }
            else if (site.ToUpper() == "SHOPTRENDS.COM")
            {
                return ItemRepository.RetrieveOnShopTrends(itemId);
            }
            return false;
        }

        /// <summary>
        ///     Checks if the combination of product group, product line and product format is valid. Returns true if all match
        /// </summary>
        /// <param name="productGroup"></param>
        /// <param name="productLine"></param>
        /// <param name="productFormat"></param>
        /// <returns></returns>
        public bool CheckProductFormats(string productGroup, string productLine, string productFormat)
        {
            foreach(ProductFormat x in GlobalData.ProductFormats)
            {
                if (x.Group == productGroup.Trim())
                {
                    if (x.Line == productLine.Trim())
                    {
                        if (x.Format == productFormat.Trim())
                        {
                            return true;                            
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        ///     Checks valid product group / line pairs and returns true if values match valid pair
        /// </summary>
        /// <param name="productGroup"></param>
        /// <param name="productLine"></param>
        /// <returns></returns>
        public bool CheckProductLines(string productGroup, string productLine)
        {
            foreach(KeyValuePair<string,string> x in GlobalData.ProductLines)
            {
                if(x.Key == productLine && x.Value == productGroup)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///     Check string for special characters. Special chars have no place in the peoplesoft database.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool CheckSpecialChar(string value)
        {
            foreach (string specialChar in GlobalData.SpecialCharacters)
            {
                if (value.Contains(specialChar))
                {
                    return true;
                }
            }
            return false;
        }        
        
        /// <summary>
        ///     Compares current list of product id translations with those currently in the database returns false if the two lists don't match
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="productIdTranslationList"></param>
        /// <returns>false if a conflict emerges</returns>
        public bool CheckExistingProductIdTranslationsMatch(List<ChildElement> productIdTranslationList)
        {
            foreach (ChildElement x in productIdTranslationList)
            {
                ItemRepository.RetrieveProductIdTranslationMatch(x.ItemId, x.ParentId);
            }
            return true;
        }

        /// <summary>
        ///     Replace "[CLEAR]" with empty value for all fields
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public ItemObject ClearFields(ItemObject item)
        {
            if (item.AccountingGroup.Trim() == "[CLEAR]") { item.AccountingGroup = ""; }
            if (item.AltImageFile1.Trim() == "[CLEAR]") { item.AltImageFile1 = ""; }
            if (item.AltImageFile2.Trim() == "[CLEAR]") { item.AltImageFile2 = ""; }
            if (item.AltImageFile3.Trim() == "[CLEAR]") { item.AltImageFile3 = ""; }
            if (item.AltImageFile4.Trim() == "[CLEAR]") { item.AltImageFile4 = ""; }
            if (item.CasepackHeight.Trim() == "[CLEAR]") { item.CasepackHeight = ""; }
            if (item.CasepackLength.Trim() == "[CLEAR]") { item.CasepackLength = ""; }
            if (item.CasepackQty.Trim() == "[CLEAR]") { item.CasepackQty = ""; }
            if (item.CasepackUpc.Trim() == "[CLEAR]") { item.CasepackUpc = ""; }
            if (item.CasepackWidth.Trim() == "[CLEAR]") { item.CasepackWidth = ""; }
            if (item.CasepackWeight.Trim() == "[CLEAR]") { item.CasepackWeight = ""; }
            if (item.Category.Trim() == "[CLEAR]") { item.Category = ""; }
            if (item.Category2.Trim() == "[CLEAR]") { item.Category2 = ""; }
            if (item.Category3.Trim() == "[CLEAR]") { item.Category3 = ""; }
            if (item.Color.Trim() == "[CLEAR]") { item.Color = ""; }
            if (item.Copyright.Trim() == "[CLEAR]") { item.Copyright = ""; }
            if (item.CountryOfOrigin.Trim() == "[CLEAR]") { item.CountryOfOrigin = ""; }
            if (item.CostProfileGroup.Trim() == "[CLEAR]") { item.CostProfileGroup = ""; }
            if (item.DefaultActualCostUsd.Trim() == "[CLEAR]") { item.DefaultActualCostUsd = ""; }
            if (item.DefaultActualCostCad.Trim() == "[CLEAR]") { item.DefaultActualCostCad = ""; }
            if (item.Description.Trim() == "[CLEAR]") { item.Description = ""; }
            if (item.DirectImport.Trim() == "[CLEAR]") { item.DirectImport = ""; }
            if (item.Duty.Trim() == "[CLEAR]") { item.Duty = ""; }
            if (item.Ean.Trim() == "[CLEAR]") { item.Ean = ""; }
            if (item.EcommerceAsin.Trim() == "[CLEAR]") { item.EcommerceAsin = ""; }
            if (item.EcommerceBullet1.Trim() == "[CLEAR]") { item.EcommerceBullet1 = ""; }
            if (item.EcommerceBullet2.Trim() == "[CLEAR]") { item.EcommerceBullet2 = ""; }
            if (item.EcommerceBullet3.Trim() == "[CLEAR]") { item.EcommerceBullet3 = ""; }
            if (item.EcommerceBullet4.Trim() == "[CLEAR]") { item.EcommerceBullet4 = ""; }
            if (item.EcommerceBullet5.Trim() == "[CLEAR]") { item.EcommerceBullet5 = ""; }
            if (item.EcommerceComponents.Trim() == "[CLEAR]") { item.EcommerceComponents = ""; }
            if (item.EcommerceCost.Trim() == "[CLEAR]") { item.EcommerceCost = ""; }
            if (item.EcommerceExternalId.Trim() == "[CLEAR]") { item.EcommerceExternalId = ""; }
            if (item.EcommerceExternalIdType.Trim() == "[CLEAR]") { item.EcommerceExternalIdType = ""; }
            if (item.EcommerceImagePath1.Trim() == "[CLEAR]") { item.EcommerceImagePath1 = ""; }
            if (item.EcommerceImagePath2.Trim() == "[CLEAR]") { item.EcommerceImagePath2 = ""; }
            if (item.EcommerceImagePath3.Trim() == "[CLEAR]") { item.EcommerceImagePath3 = ""; }
            if (item.EcommerceImagePath4.Trim() == "[CLEAR]") { item.EcommerceImagePath4 = ""; }
            if (item.EcommerceImagePath5.Trim() == "[CLEAR]") { item.EcommerceImagePath5 = ""; }
            if (item.EcommerceItemHeight.Trim() == "[CLEAR]") { item.EcommerceItemHeight = ""; }
            if (item.EcommerceItemLength.Trim() == "[CLEAR]") { item.EcommerceItemLength = ""; }
            if (item.EcommerceItemName.Trim() == "[CLEAR]") { item.EcommerceItemName = ""; }
            if (item.EcommerceItemTypeKeywords.Trim() == "[CLEAR]") { item.EcommerceItemTypeKeywords = ""; }
            if (item.EcommerceItemWeight.Trim() == "[CLEAR]") { item.EcommerceItemWeight = ""; }
            if (item.EcommerceItemWidth.Trim() == "[CLEAR]") { item.EcommerceItemWidth = ""; }
            if (item.EcommerceModelName.Trim() == "[CLEAR]") { item.EcommerceModelName = ""; }
            if (item.EcommercePackageHeight.Trim() == "[CLEAR]") { item.EcommercePackageHeight = ""; }
            if (item.EcommercePackageLength.Trim() == "[CLEAR]") { item.EcommercePackageLength = ""; }
            if (item.EcommercePackageWeight.Trim() == "[CLEAR]") { item.EcommercePackageWeight = ""; }
            if (item.EcommercePackageWidth.Trim() == "[CLEAR]") { item.EcommercePackageWidth = ""; }
            if (item.EcommercePageQty.Trim() == "[CLEAR]") { item.EcommercePageQty = ""; }
            if (item.EcommerceParentAsin.Trim() == "[CLEAR]") { item.EcommerceParentAsin = ""; }
            if (item.EcommerceProductCategory.Trim() == "[CLEAR]") { item.EcommerceProductCategory = ""; }
            if (item.EcommerceProductDescription.Trim() == "[CLEAR]") { item.EcommerceProductDescription = ""; }
            if (item.EcommerceProductSubcategory.Trim() == "[CLEAR]") { item.EcommerceProductSubcategory = ""; }
            if (item.EcommerceManufacturerName.Trim() == "[CLEAR]") { item.EcommerceManufacturerName = ""; }
            if (item.EcommerceMsrp.Trim() == "[CLEAR]") { item.EcommerceMsrp = ""; }
            if (item.EcommerceGenericKeywords.Trim() == "[CLEAR]") { item.EcommerceGenericKeywords = ""; }
            if (item.EcommerceSize.Trim() == "[CLEAR]") { item.EcommerceSize = ""; }
            if (item.EcommerceSubjectKeywords.Trim() == "[CLEAR]") { item.EcommerceSubjectKeywords = ""; }
            if (item.EcommerceUpc.Trim() == "[CLEAR]") { item.EcommerceUpc = ""; }
            if (item.Genre1.Trim() == "[CLEAR]") { item.Genre1 = ""; }
            if (item.Genre2.Trim() == "[CLEAR]") { item.Genre2 = ""; }
            if (item.Genre3.Trim() == "[CLEAR]") { item.Genre3 = ""; }
            if (item.Gpc.Trim() == "[CLEAR]") { item.Gpc = ""; }
            if (item.Height.Trim() == "[CLEAR]") { item.Height = ""; }
            if (item.ImagePath.Trim() == "[CLEAR]") { item.ImagePath = ""; }
            if (item.InnerpackHeight.Trim() == "[CLEAR]") { item.InnerpackHeight = ""; }
            if (item.InnerpackLength.Trim() == "[CLEAR]") { item.InnerpackLength = ""; }
            if (item.InnerpackQuantity.Trim() == "[CLEAR]") { item.InnerpackQuantity = ""; }
            if (item.InnerpackUpc.Trim() == "[CLEAR]") { item.InnerpackUpc = ""; }
            if (item.InnerpackWidth.Trim() == "[CLEAR]") { item.InnerpackWidth = ""; }
            if (item.InnerpackWeight.Trim() == "[CLEAR]") { item.InnerpackWeight = ""; }
            if (item.InStockDate.Trim() == "[CLEAR]") { item.InStockDate = ""; }
            if (item.Isbn.Trim() == "[CLEAR]") { item.Isbn = ""; }
            if (item.ItemCategory.Trim() == "[CLEAR]") { item.ItemCategory = ""; }
            if (item.ItemFamily.Trim() == "[CLEAR]") { item.ItemFamily = ""; }
            if (item.ItemGroup.Trim() == "[CLEAR]") { item.ItemGroup = ""; }
            if (item.ItemKeywords.Trim() == "[CLEAR]") { item.ItemKeywords = ""; }
            if (item.Language.Trim() == "[CLEAR]") { item.Language = ""; }
            if (item.Length.Trim() == "[CLEAR]") { item.Length = ""; }
            if (item.License.Trim() == "[CLEAR]") { item.License = ""; }
            if (item.LicenseBeginDate.Trim() == "[CLEAR]") { item.LicenseBeginDate = ""; }
            if (item.ListPriceCad.Trim() == "[CLEAR]") { item.ListPriceCad = ""; }
            if (item.ListPriceUsd.Trim() == "[CLEAR]") { item.ListPriceUsd = ""; }
            if (item.ListPriceMxn.Trim() == "[CLEAR]") { item.ListPriceMxn = ""; }
            if (item.MetaDescription.Trim() == "[CLEAR]") { item.MetaDescription = ""; }
            if (item.MfgSource.Trim() == "[CLEAR]") { item.MfgSource = ""; }
            if (item.Msrp.Trim() == "[CLEAR]") { item.Msrp = ""; }
            if (item.MsrpCad.Trim() == "[CLEAR]") { item.MsrpCad = ""; }
            if (item.MsrpMxn.Trim() == "[CLEAR]") { item.MsrpMxn = ""; }
            if (item.PricingGroup.Trim() == "[CLEAR]") { item.PricingGroup = ""; }
            if (item.ProductFormat.Trim() == "[CLEAR]") { item.ProductFormat = ""; }
            if (item.ProductGroup.Trim() == "[CLEAR]") { item.ProductGroup = ""; }
            if (item.ProductLine.Trim() == "[CLEAR]") { item.ProductLine = ""; }
            if (item.ProductQty.Trim() == "[CLEAR]") { item.ProductQty = ""; }
            if (item.Property.Trim() == "[CLEAR]") { item.Property = ""; }
            if (item.SatCode.Trim() == "[CLEAR]") { item.SatCode = ""; }
            if (item.ShortDescription.Trim() == "[CLEAR]") { item.ShortDescription = ""; }
            if (item.Size.Trim() == "[CLEAR]") { item.Size = ""; }
            if (item.StandardCost.Trim() == "[CLEAR]") { item.StandardCost = ""; }
            if (item.StatsCode.Trim() == "[CLEAR]") { item.StatsCode = ""; }
            if (item.TariffCode.Trim() == "[CLEAR]") { item.TariffCode = ""; }
            if (item.Territory.Trim() == "[CLEAR]") { item.Territory = ""; }
            if (item.Title.Trim() == "[CLEAR]"){ item.Title = ""; }
            if (item.Udex.Trim() == "[CLEAR]") { item.Udex = ""; }
            if (item.Upc.Trim() == "[CLEAR]") { item.Upc = ""; }
            if (item.Warranty.Trim() == "[CLEAR]") { item.Warranty = ""; }
            if (item.WarrantyCheck.Trim() == "[CLEAR]") { item.WarrantyCheck = ""; }
            if (item.WebsitePrice.Trim() == "[CLEAR]") { item.WebsitePrice = ""; }
            if (item.Weight.Trim() == "[CLEAR]") { item.Weight = ""; }
            if (item.Width.Trim() == "[CLEAR]") { item.Width = ""; }
            return item;
        }

        /// <summary>
        ///     Fills missing fields with previously saved info from database
        /// </summary>
        /// <param name="item"></param>
        /// <param name="ItemList"></param>
        /// <returns>Completed Item</returns>
        public ItemObject CompleteItem(ItemObject item, int itemRow)
        {
            // Retrieve existing values from database
            ItemObject returnItem = RetrieveItem(item.ItemId, itemRow);

            if ((!string.IsNullOrEmpty(item.AccountingGroup)) && (item.AccountingGroup.Trim() != returnItem.AccountingGroup.Trim())) { returnItem.AccountingGroup = item.AccountingGroup; } // Accounting Group
            if ((!string.IsNullOrEmpty(item.AltImageFile1)) && (item.AltImageFile1.Trim() != returnItem.AltImageFile1.Trim())) { returnItem.AltImageFile1 = item.AltImageFile1; }  // Alt Image Field 1
            if ((!string.IsNullOrEmpty(item.AltImageFile2)) && (item.AltImageFile2.Trim() != returnItem.AltImageFile2.Trim())) { returnItem.AltImageFile2 = item.AltImageFile2; }  // Alt Image Field 2
            if ((!string.IsNullOrEmpty(item.AltImageFile3)) && (item.AltImageFile3.Trim() != returnItem.AltImageFile3.Trim())) { returnItem.AltImageFile3 = item.AltImageFile3; }  // Alt Image Field 3
            if ((!string.IsNullOrEmpty(item.AltImageFile4)) && (item.AltImageFile4.Trim() != returnItem.AltImageFile4.Trim())) { returnItem.AltImageFile4 = item.AltImageFile4; }  // Alt Image Field 4
            if ((!string.IsNullOrEmpty(item.ReturnBillOfMaterials())) && (item.ReturnBillOfMaterials()).Trim() != returnItem.ReturnBillOfMaterials())
            {
                returnItem.BillOfMaterials = item.BillOfMaterials;
            } // Bill of Materials
            if ((!string.IsNullOrEmpty(item.Active.ToString())) && (item.Active != returnItem.Active)) { returnItem.Active = item.Active; } // Active
            if ((!string.IsNullOrEmpty(item.CasepackHeight)) && (item.CasepackHeight.Trim() != returnItem.CasepackHeight.Trim())) { returnItem.CasepackHeight = item.CasepackHeight; } // Casepack Height
            if ((!string.IsNullOrEmpty(item.CasepackLength)) && (item.CasepackLength.Trim() != returnItem.CasepackLength.Trim())) { returnItem.CasepackLength = item.CasepackLength; } // Casepack Length
            if ((!string.IsNullOrEmpty(item.CasepackQty)) && (item.CasepackQty.Trim() != returnItem.CasepackQty.Trim())) { returnItem.CasepackQty = item.CasepackQty; } // Casepack Qty
            if ((!string.IsNullOrEmpty(item.CasepackUpc)) && (item.CasepackUpc.Trim() != returnItem.CasepackUpc.Trim())) { returnItem.CasepackUpc = item.CasepackUpc; } // Casepack UPC
            if ((!string.IsNullOrEmpty(item.CasepackWidth)) && (item.CasepackWidth.Trim() != returnItem.CasepackWidth.Trim())) { returnItem.CasepackWidth = item.CasepackWidth; } // Casepack Width
            if ((!string.IsNullOrEmpty(item.CasepackWeight)) && (item.CasepackWeight.Trim() != returnItem.CasepackWeight.Trim())) { returnItem.CasepackWeight = item.CasepackWeight; } // Casepack Weight
            if ((!string.IsNullOrEmpty(item.Category)) && (item.Category.Trim() != returnItem.Category.Trim())) { returnItem.Category = item.Category; } // Category
            if ((!string.IsNullOrEmpty(item.Category2)) && (item.Category2.Trim() != returnItem.Category2.Trim())) { returnItem.Category2 = item.Category2; } // Category 2
            if ((!string.IsNullOrEmpty(item.Category3)) && (item.Category3.Trim() != returnItem.Category3.Trim())) { returnItem.Category3 = item.Category3; } // Category 3
            if ((!string.IsNullOrEmpty(item.Color)) && (item.Color.Trim() != returnItem.Color.Trim())) { returnItem.Color = item.Color; } // Color
            if ((!string.IsNullOrEmpty(item.Copyright)) && (item.Copyright.Trim() != returnItem.Copyright.Trim())) { returnItem.Copyright = item.Copyright; } // Copyright
            if ((!string.IsNullOrEmpty(item.CountryOfOrigin)) && (item.CountryOfOrigin.Trim() != returnItem.CountryOfOrigin.Trim())) { returnItem.CountryOfOrigin = item.CountryOfOrigin; } // Country of Origin
            if ((!string.IsNullOrEmpty(item.CostProfileGroup)) && (item.CostProfileGroup.Trim() != returnItem.CostProfileGroup.Trim())) { returnItem.CostProfileGroup = item.CostProfileGroup; } // Cost Profile Group
            if ((!string.IsNullOrEmpty(item.DefaultActualCostCad)) && (item.DefaultActualCostCad.Trim() != returnItem.DefaultActualCostCad.Trim())) { returnItem.DefaultActualCostCad = item.DefaultActualCostCad; } // Default Actual Cost CAD
            if ((!string.IsNullOrEmpty(item.DefaultActualCostUsd)) && (item.DefaultActualCostUsd.Trim() != returnItem.DefaultActualCostUsd.Trim())) { returnItem.DefaultActualCostUsd = item.DefaultActualCostUsd; } // Default Actual Cost USD
            if ((!string.IsNullOrEmpty(item.Description)) && (item.Description.Trim() != returnItem.Description.Trim())) { returnItem.Description = item.Description; } // Description
            if ((!string.IsNullOrEmpty(item.DirectImport)) && (item.DirectImport.Trim() != returnItem.DirectImport.Trim())) { returnItem.DirectImport = AssignDirectImport(item.DirectImport); } // Direct Import
            if ((!string.IsNullOrEmpty(item.DtcPrice)) && (item.DtcPrice.Trim() != returnItem.DtcPrice.Trim())) { returnItem.DtcPrice = item.DtcPrice; } // DTC Price
            if ((!string.IsNullOrEmpty(item.Duty)) && (item.Duty.Trim() != returnItem.Duty.Trim())) { returnItem.Duty = item.Duty; } // Duty
            if ((!string.IsNullOrEmpty(item.Ean)) && (item.Ean.Trim() != returnItem.Ean.Trim())) { returnItem.Ean = item.Ean; } // EAN
            if ((!string.IsNullOrEmpty(item.EcommerceAsin)) && (item.EcommerceAsin.Trim() != returnItem.EcommerceAsin.Trim())) { returnItem.EcommerceAsin = item.EcommerceAsin; } // Ecommerce EcommerceAsin
            if ((!string.IsNullOrEmpty(item.EcommerceBullet1)) && (item.EcommerceBullet1.Trim() != returnItem.EcommerceBullet1.Trim())) { returnItem.EcommerceBullet1 = item.EcommerceBullet1; } // Ecommerce Bullet 1
            if ((!string.IsNullOrEmpty(item.EcommerceBullet2)) && (item.EcommerceBullet2.Trim() != returnItem.EcommerceBullet2.Trim())) { returnItem.EcommerceBullet2 = item.EcommerceBullet2; } // Ecommerce Bullet 2
            if ((!string.IsNullOrEmpty(item.EcommerceBullet3)) && (item.EcommerceBullet3.Trim() != returnItem.EcommerceBullet3.Trim())) { returnItem.EcommerceBullet3 = item.EcommerceBullet3; } // Ecommerce Bullet 3
            if ((!string.IsNullOrEmpty(item.EcommerceBullet4)) && (item.EcommerceBullet4.Trim() != returnItem.EcommerceBullet4.Trim())) { returnItem.EcommerceBullet4 = item.EcommerceBullet4; } // Ecommerce Bullet 4
            if ((!string.IsNullOrEmpty(item.EcommerceBullet5)) && (item.EcommerceBullet5.Trim() != returnItem.EcommerceBullet5.Trim())) { returnItem.EcommerceBullet5 = item.EcommerceBullet5; } // Ecommerce Bullet 5
            if ((!string.IsNullOrEmpty(item.EcommerceComponents)) && (item.EcommerceComponents.Trim() != returnItem.EcommerceComponents.Trim())) { returnItem.EcommerceComponents = item.EcommerceComponents; } // Ecommerce Components
            if ((!string.IsNullOrEmpty(item.EcommerceCost)) && (item.EcommerceCost.Trim() != returnItem.EcommerceCost.Trim())) { returnItem.EcommerceCost = item.EcommerceCost; } // Ecommerce Cost
            if ((!string.IsNullOrEmpty(item.EcommerceExternalId)) && (item.EcommerceExternalId.Trim() != returnItem.EcommerceExternalId.Trim())) { returnItem.EcommerceExternalId = item.EcommerceExternalId; } // Ecommerce External ID
            if ((!string.IsNullOrEmpty(item.EcommerceExternalIdType)) && (item.EcommerceExternalIdType.Trim() != returnItem.EcommerceExternalIdType.Trim())) { returnItem.EcommerceExternalIdType = item.EcommerceExternalIdType; } // Ecommerce External ID Type
            if ((!string.IsNullOrEmpty(item.EcommerceImagePath1)) && (item.EcommerceImagePath1.Trim() != returnItem.EcommerceImagePath1.Trim())) { returnItem.EcommerceImagePath1 = item.EcommerceImagePath1; } // Ecommerce Image Path 1
            if ((!string.IsNullOrEmpty(item.EcommerceImagePath2)) && (item.EcommerceImagePath2.Trim() != returnItem.EcommerceImagePath2.Trim())) { returnItem.EcommerceImagePath2 = item.EcommerceImagePath2; } // Ecommerce Image Path 2
            if ((!string.IsNullOrEmpty(item.EcommerceImagePath3)) && (item.EcommerceImagePath3.Trim() != returnItem.EcommerceImagePath3.Trim())) { returnItem.EcommerceImagePath3 = item.EcommerceImagePath3; } // Ecommerce Image Path 3
            if ((!string.IsNullOrEmpty(item.EcommerceImagePath4)) && (item.EcommerceImagePath4.Trim() != returnItem.EcommerceImagePath4.Trim())) { returnItem.EcommerceImagePath4 = item.EcommerceImagePath4; } // Ecommerce Image Path 4
            if ((!string.IsNullOrEmpty(item.EcommerceImagePath5)) && (item.EcommerceImagePath5.Trim() != returnItem.EcommerceImagePath5.Trim())) { returnItem.EcommerceImagePath5 = item.EcommerceImagePath5; } // Ecommerce Image Path 5
            if ((!string.IsNullOrEmpty(item.EcommerceItemHeight)) && (item.EcommerceItemHeight.Trim() != returnItem.EcommerceItemHeight.Trim())) { returnItem.EcommerceItemHeight = item.EcommerceItemHeight; } // Ecommerce Item Height
            if ((!string.IsNullOrEmpty(item.EcommerceItemLength)) && (item.EcommerceItemLength.Trim() != returnItem.EcommerceItemLength.Trim())) { returnItem.EcommerceItemLength = item.EcommerceItemLength; } // Ecommerce Item Length
            if ((!string.IsNullOrEmpty(item.EcommerceItemName)) && (item.EcommerceItemName.Trim() != returnItem.EcommerceItemName.Trim())) { returnItem.EcommerceItemName = item.EcommerceItemName; } // Ecommerce Item Name
            if ((!string.IsNullOrEmpty(item.EcommerceItemTypeKeywords)) && (item.EcommerceItemTypeKeywords.Trim() != returnItem.EcommerceItemTypeKeywords.Trim())) { returnItem.EcommerceItemTypeKeywords = item.EcommerceItemTypeKeywords; } // Ecommerce Item Type Keywords
            if ((!string.IsNullOrEmpty(item.EcommerceItemWeight)) && (item.EcommerceItemWeight.Trim() != returnItem.EcommerceItemWeight.Trim())) { returnItem.EcommerceItemWeight = item.EcommerceItemWeight; } // Ecommerce Item Weight
            if ((!string.IsNullOrEmpty(item.EcommerceItemWidth)) && (item.EcommerceItemWidth.Trim() != returnItem.EcommerceItemWidth.Trim())) { returnItem.EcommerceItemWidth = item.EcommerceItemWidth; } // Ecommerce Item Width
            if ((!string.IsNullOrEmpty(item.EcommerceModelName)) && (item.EcommerceModelName.Trim() != returnItem.EcommerceModelName.Trim())) { returnItem.EcommerceModelName = item.EcommerceModelName; } // Ecommerce Model Name
            if ((!string.IsNullOrEmpty(item.EcommercePackageHeight)) && (item.EcommercePackageHeight.Trim() != returnItem.EcommercePackageHeight.Trim())) { returnItem.EcommercePackageHeight = item.EcommercePackageHeight; } // Ecommerce Package Height
            if ((!string.IsNullOrEmpty(item.EcommercePackageLength)) && (item.EcommercePackageLength.Trim() != returnItem.EcommercePackageLength.Trim())) { returnItem.EcommercePackageLength = item.EcommercePackageLength; } // Ecommerce Package Length
            if ((!string.IsNullOrEmpty(item.EcommercePackageWeight)) && (item.EcommercePackageWeight.Trim() != returnItem.EcommercePackageWeight.Trim())) { returnItem.EcommercePackageWeight = item.EcommercePackageWeight; } // Ecommerce Package Weight
            if ((!string.IsNullOrEmpty(item.EcommercePackageWidth)) && (item.EcommercePackageWidth.Trim() != returnItem.EcommercePackageWidth.Trim())) { returnItem.EcommercePackageWidth = item.EcommercePackageWidth; } // Ecommerce Package Width
            if ((!string.IsNullOrEmpty(item.EcommercePageQty)) && (item.EcommercePageQty.Trim() != returnItem.EcommercePageQty.Trim())) { returnItem.EcommercePageQty = item.EcommercePageQty; } // Ecommerce Page Qty
            if ((!string.IsNullOrEmpty(item.EcommerceParentAsin)) && (item.EcommerceParentAsin.Trim() != returnItem.EcommerceParentAsin.Trim())) { returnItem.EcommerceParentAsin = item.EcommerceParentAsin; } // Ecommerce Parent Asin
            if ((!string.IsNullOrEmpty(item.EcommerceProductCategory)) && (item.EcommerceProductCategory.Trim() != returnItem.EcommerceProductCategory.Trim())) { returnItem.EcommerceProductCategory = item.EcommerceProductCategory; } // Ecommerce Product Category
            if ((!string.IsNullOrEmpty(item.EcommerceProductDescription)) && (item.EcommerceProductDescription.Trim() != returnItem.EcommerceProductDescription.Trim())) { returnItem.EcommerceProductDescription = item.EcommerceProductDescription; } // Ecommerce Product Description
            if ((!string.IsNullOrEmpty(item.EcommerceProductSubcategory)) && (item.EcommerceProductSubcategory.Trim() != returnItem.EcommerceProductSubcategory.Trim())) { returnItem.EcommerceProductSubcategory = item.EcommerceProductSubcategory; } // Ecommerce Product Subcategory
            if ((!string.IsNullOrEmpty(item.EcommerceManufacturerName)) && (item.EcommerceManufacturerName.Trim() != returnItem.EcommerceManufacturerName.Trim())) { returnItem.EcommerceManufacturerName = item.EcommerceManufacturerName; } 
            if ((!string.IsNullOrEmpty(item.EcommerceMsrp)) && (item.EcommerceMsrp.Trim() != returnItem.EcommerceMsrp.Trim())) { returnItem.EcommerceMsrp = item.EcommerceMsrp; }
            if ((!string.IsNullOrEmpty(item.EcommerceGenericKeywords)) && (item.EcommerceGenericKeywords.Trim() != returnItem.EcommerceGenericKeywords.Trim())) { returnItem.EcommerceGenericKeywords = item.EcommerceGenericKeywords; } 
            if ((!string.IsNullOrEmpty(item.EcommerceSize)) && (item.EcommerceSize.Trim() != returnItem.EcommerceSize.Trim())) { returnItem.EcommerceSize = item.EcommerceSize; } 
            if ((!string.IsNullOrEmpty(item.EcommerceSubjectKeywords)) && (item.EcommerceSubjectKeywords.Trim() != returnItem.EcommerceSubjectKeywords.Trim())) { returnItem.EcommerceSubjectKeywords = item.EcommerceSubjectKeywords; } 
            if ((!string.IsNullOrEmpty(item.EcommerceUpc)) && (item.EcommerceUpc.Trim() != returnItem.EcommerceUpc.Trim())) { returnItem.EcommerceUpc = item.EcommerceUpc; }
            if ((!string.IsNullOrEmpty(item.Genre1)) && (item.Genre1.Trim() != returnItem.Genre1.Trim())) { returnItem.Genre1 = item.Genre1; }
            if ((!string.IsNullOrEmpty(item.Genre2)) && (item.Genre2.Trim() != returnItem.Genre2.Trim())) { returnItem.Genre2 = item.Genre2; }
            if ((!string.IsNullOrEmpty(item.Genre3)) && (item.Genre3.Trim() != returnItem.Genre3.Trim())) { returnItem.Genre3 = item.Genre3; }
            if ((!string.IsNullOrEmpty(item.Gpc)) && (item.Gpc.Trim() != returnItem.Gpc.Trim())) { returnItem.Gpc = item.Gpc; }
            if ((!string.IsNullOrEmpty(item.Height)) && (item.Height.Trim() != returnItem.Height.Trim())) { returnItem.Height = item.Height; }
            if ((!string.IsNullOrEmpty(item.ImagePath)) && (item.ImagePath.Trim() != returnItem.ImagePath.Trim())) { returnItem.ImagePath = item.ImagePath; }
            if ((!string.IsNullOrEmpty(item.InnerpackHeight)) && (item.InnerpackHeight.Trim() != returnItem.InnerpackHeight.Trim())) { returnItem.InnerpackHeight = item.InnerpackHeight; }
            if ((!string.IsNullOrEmpty(item.InnerpackLength)) && (item.InnerpackLength.Trim() != returnItem.InnerpackLength.Trim())) { returnItem.InnerpackLength = item.InnerpackLength; }
            if ((!string.IsNullOrEmpty(item.InnerpackQuantity)) && (item.InnerpackQuantity.Trim() != returnItem.InnerpackQuantity.Trim())) { returnItem.InnerpackQuantity = item.InnerpackQuantity; }
            if ((!string.IsNullOrEmpty(item.InnerpackUpc)) && (item.InnerpackUpc.Trim() != returnItem.InnerpackUpc.Trim())) { returnItem.InnerpackUpc = item.InnerpackUpc; }
            if ((!string.IsNullOrEmpty(item.InnerpackWeight)) && (item.InnerpackWeight.Trim() != returnItem.InnerpackWeight.Trim())) { returnItem.InnerpackWeight = item.InnerpackWeight; }
            if ((!string.IsNullOrEmpty(item.InnerpackWidth)) && (item.InnerpackWidth.Trim() != returnItem.InnerpackWidth.Trim())) { returnItem.InnerpackWidth = item.InnerpackWidth; }
            if ((!string.IsNullOrEmpty(item.InStockDate)) && (item.InStockDate.Trim() != returnItem.InStockDate.Trim())) { returnItem.InStockDate = item.InStockDate; }
            if ((!string.IsNullOrEmpty(item.Isbn)) && (item.Isbn.Trim() != returnItem.Isbn.Trim())) { returnItem.Isbn = item.Isbn; }
            if ((!string.IsNullOrEmpty(item.ItemCategory)) && (item.ItemCategory.Trim() != returnItem.ItemCategory.Trim())) { returnItem.ItemCategory = item.ItemCategory; }
            if ((!string.IsNullOrEmpty(item.ItemFamily)) && (item.ItemFamily.Trim() != returnItem.ItemFamily.Trim())) { returnItem.ItemFamily = item.ItemFamily; }
            if ((!string.IsNullOrEmpty(item.ItemGroup)) && (item.ItemGroup.Trim() != returnItem.ItemGroup.Trim())) { returnItem.ItemGroup = item.ItemGroup; }
            if ((!string.IsNullOrEmpty(item.ItemKeywords)) && (item.ItemKeywords.Trim() != returnItem.ItemKeywords.Trim())) { returnItem.ItemKeywords = item.ItemKeywords; }
            if ((!string.IsNullOrEmpty(item.Language)) && (item.Language.Trim() != returnItem.Language.Trim())) { returnItem.Language = DbUtil.OrderLanguage(item.Language); }
            if ((!string.IsNullOrEmpty(item.Length)) && (item.Length.Trim() != returnItem.Length.Trim())) { returnItem.Length = item.Length; }
            if ((!string.IsNullOrEmpty(item.License)) && (item.License.Trim() != returnItem.License.Trim())) { returnItem.License = item.License; }
            if ((!string.IsNullOrEmpty(item.LicenseBeginDate)) && (item.LicenseBeginDate.Trim() != returnItem.LicenseBeginDate.Trim())) { returnItem.LicenseBeginDate = item.LicenseBeginDate; }
            if ((!string.IsNullOrEmpty(item.ListPriceCad)) && (item.ListPriceCad.Trim() != returnItem.ListPriceCad.Trim())) { returnItem.ListPriceCad = CheckEmptyPrice(item.ListPriceCad); }
            if ((!string.IsNullOrEmpty(item.ListPriceMxn)) && (item.ListPriceMxn.Trim() != returnItem.ListPriceMxn.Trim())) { returnItem.ListPriceMxn = CheckEmptyPrice(item.ListPriceMxn); }
            if ((!string.IsNullOrEmpty(item.ListPriceUsd)) && (item.ListPriceUsd.Trim() != returnItem.ListPriceUsd.Trim())) { returnItem.ListPriceUsd = CheckEmptyPrice(item.ListPriceUsd); }
            if ((!string.IsNullOrEmpty(item.MetaDescription)) && (item.MetaDescription.Trim() != returnItem.MetaDescription.Trim())) { returnItem.MetaDescription = item.MetaDescription; }
            if ((!string.IsNullOrEmpty(item.MfgSource)) && (item.MfgSource.Trim() != returnItem.MfgSource.Trim())) { returnItem.MfgSource = item.MfgSource; }
            if ((!string.IsNullOrEmpty(item.Msrp)) && (item.Msrp.Trim() != returnItem.Msrp.Trim())) { returnItem.Msrp = CheckEmptyPrice(item.Msrp); }
            if ((!string.IsNullOrEmpty(item.MsrpCad)) && (item.MsrpCad.Trim() != returnItem.MsrpCad.Trim())) { returnItem.MsrpCad = CheckEmptyPrice(item.MsrpCad); }
            if ((!string.IsNullOrEmpty(item.MsrpMxn)) && (item.MsrpMxn.Trim() != returnItem.MsrpMxn.Trim())) { returnItem.MsrpMxn = CheckEmptyPrice(item.MsrpMxn); }
            if ((!string.IsNullOrEmpty(item.PricingGroup)) && (item.PricingGroup.Trim() != returnItem.PricingGroup.Trim())) { returnItem.PricingGroup = item.PricingGroup; }
            if ((!string.IsNullOrEmpty(item.PrintOnDemand)) && (item.PrintOnDemand.Trim() != returnItem.PrintOnDemand.Trim())) { returnItem.PrintOnDemand = item.PrintOnDemand; }
            if ((!string.IsNullOrEmpty(item.ProductGroup)) && (item.ProductGroup.Trim() != returnItem.ProductGroup.Trim())) { returnItem.ProductGroup = item.ProductGroup; }
            if ((!string.IsNullOrEmpty(item.ReturnProductIdTranslations())) && (item.ReturnProductIdTranslations()).Trim() != returnItem.ReturnProductIdTranslations())
            {
                returnItem.ProductIdTranslation = item.ProductIdTranslation;
            }
            if ((!string.IsNullOrEmpty(item.ProductLine)) && (item.ProductLine.Trim() != returnItem.ProductLine.Trim())) { returnItem.ProductLine = item.ProductLine; }
            if ((!string.IsNullOrEmpty(item.ProductQty)) && (item.ProductQty.Trim() != returnItem.ProductQty.Trim())) { returnItem.ProductQty = item.ProductQty; }
            if ((!string.IsNullOrEmpty(item.ProductFormat)) && (item.ProductFormat.Trim() != returnItem.ProductFormat.Trim())) { returnItem.ProductFormat = item.ProductFormat; }
            if ((!string.IsNullOrEmpty(item.Property)) && (item.Property.Trim() != returnItem.Property.Trim())) { returnItem.Property = item.Property; }
            if ((!string.IsNullOrEmpty(item.PsStatus)) && (item.PsStatus.Trim() != returnItem.PsStatus.Trim())) { returnItem.PsStatus = item.PsStatus; }
            if ((!string.IsNullOrEmpty(item.SatCode)) && (item.SatCode.Trim() != returnItem.SatCode.Trim())) { returnItem.SatCode = item.SatCode; }
            if ((!string.IsNullOrEmpty(item.SellOnAllPosters)) && (item.SellOnAllPosters.Trim() != returnItem.SellOnAllPosters.Trim())) { returnItem.SellOnAllPosters = item.SellOnAllPosters.Trim(); } 
            if ((!string.IsNullOrEmpty(item.SellOnAmazon)) && (item.SellOnAmazon.Trim() != returnItem.SellOnAmazon.Trim())) { returnItem.SellOnAmazon = item.SellOnAmazon.Trim(); } 
            if ((!string.IsNullOrEmpty(item.SellOnAmazonSellerCentral)) && (item.SellOnAmazonSellerCentral.Trim() != returnItem.SellOnAmazonSellerCentral.Trim())) { returnItem.SellOnAmazonSellerCentral = item.SellOnAmazonSellerCentral.Trim(); }
            if ((!string.IsNullOrEmpty(item.SellOnTarget)) && (item.SellOnTarget.Trim() != returnItem.SellOnTarget.Trim())) { returnItem.SellOnTarget = item.SellOnTarget.Trim(); }
            if ((!string.IsNullOrEmpty(item.SellOnTrends)) && (item.SellOnTrends.Trim() != returnItem.SellOnTrends.Trim())) { returnItem.SellOnTrends = item.SellOnTrends.Trim(); }
            if ((!string.IsNullOrEmpty(item.SellOnTrs)) && (item.SellOnTrs.Trim() != returnItem.SellOnTrs.Trim())) { returnItem.SellOnTrs = item.SellOnTrs.Trim(); }
            if ((!string.IsNullOrEmpty(item.SellOnEcommerce)) && (item.SellOnEcommerce.Trim() != returnItem.SellOnEcommerce.Trim())) { returnItem.SellOnEcommerce = item.SellOnEcommerce.Trim(); }
            if ((!string.IsNullOrEmpty(item.SellOnFanatics)) && (item.SellOnFanatics.Trim() != returnItem.SellOnFanatics.Trim())) { returnItem.SellOnFanatics = item.SellOnFanatics.Trim(); } 
            if ((!string.IsNullOrEmpty(item.SellOnGuitarCenter)) && (item.SellOnGuitarCenter.Trim() != returnItem.SellOnGuitarCenter.Trim())) { returnItem.SellOnGuitarCenter = item.SellOnGuitarCenter.Trim(); } 
            if ((!string.IsNullOrEmpty(item.SellOnHayneedle)) && (item.SellOnHayneedle.Trim() != returnItem.SellOnHayneedle.Trim())) { returnItem.SellOnHayneedle = item.SellOnHayneedle.Trim(); }
            if ((!string.IsNullOrEmpty(item.SellOnHouzz)) && (item.SellOnHouzz.Trim() != returnItem.SellOnHouzz.Trim())) { returnItem.SellOnHouzz = item.SellOnHouzz.Trim(); }
            if ((!string.IsNullOrEmpty(item.SellOnWalmart)) && (item.SellOnWalmart.Trim() != returnItem.SellOnWalmart.Trim())) { returnItem.SellOnWalmart = item.SellOnWalmart.Trim(); } 
            if ((!string.IsNullOrEmpty(item.SellOnWayfair)) && (item.SellOnWayfair.Trim() != returnItem.SellOnWayfair.Trim())) { returnItem.SellOnWayfair = item.SellOnWayfair.Trim(); } 
            if ((!string.IsNullOrEmpty(item.ShortDescription)) && (item.ShortDescription.Trim() != returnItem.ShortDescription.Trim())) { returnItem.ShortDescription = item.ShortDescription.Trim(); }
            if ((!string.IsNullOrEmpty(item.Size)) && (item.Size.Trim() != returnItem.Size.Trim())) { returnItem.Size = item.Size.Trim(); }
            if ((!string.IsNullOrEmpty(item.StandardCost)) && (item.StandardCost.Trim() != returnItem.StandardCost.Trim())) { returnItem.StandardCost = item.StandardCost.Trim(); }
            if ((!string.IsNullOrEmpty(item.StatsCode)) && (item.StatsCode.Trim() != returnItem.StatsCode.Trim())) { returnItem.StatsCode = item.StatsCode.Trim(); }
            returnItem.Status = "Update";
            if ((!string.IsNullOrEmpty(item.TariffCode)) && (item.TariffCode.Trim() != returnItem.TariffCode.Trim())) { returnItem.TariffCode = item.TariffCode; }
            if ((!string.IsNullOrEmpty(item.Territory)) && (item.Territory.Trim() != returnItem.Territory.Trim())) { returnItem.Territory = DbUtil.OrderTerritory(item.Territory); }
            if ((!string.IsNullOrEmpty(item.Title)) && (item.Title.Trim() != returnItem.Title.Trim())) { returnItem.Title = item.Title; }
            if ((!string.IsNullOrEmpty(item.Udex)) && (item.Udex.Trim() != returnItem.Udex.Trim())) { returnItem.Udex = item.Udex; }
            if ((!string.IsNullOrEmpty(item.Upc)) && (item.Upc.Trim() != returnItem.Upc.Trim())) { returnItem.Upc = item.Upc; }
            if ((!string.IsNullOrEmpty(item.Warranty)) && (item.Warranty.Trim() != returnItem.Warranty.Trim())) { returnItem.Warranty = item.Upc; }
            if ((!string.IsNullOrEmpty(item.WarrantyCheck)) && (item.WarrantyCheck.Trim() != returnItem.WarrantyCheck.Trim())) { returnItem.WarrantyCheck = item.WarrantyCheck; }
            if ((!string.IsNullOrEmpty(item.WebsitePrice)) && (item.WebsitePrice.Trim() != returnItem.WebsitePrice.Trim())) { returnItem.WebsitePrice = item.WebsitePrice; }
            if ((!string.IsNullOrEmpty(item.Weight)) && (item.Weight.Trim() != returnItem.Weight.Trim())) { returnItem.Weight = item.Weight; }
            if ((!string.IsNullOrEmpty(item.Width)) && (item.Width.Trim() != returnItem.Width.Trim())) { returnItem.Width = item.Width; }
            
            returnItem = ClearFields(returnItem);
            returnItem.SetFlagDefaults();
            return returnItem;
        }
        
        /// <summary>
        ///     pulls down existing template and overrides values with those of the given template. Returns combined template.
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public ItemObject CompleteTemplate(ItemObject template)
        {
                ItemObject oldTemplate = RetrieveTemplate(template.TemplateId);

                if (string.IsNullOrEmpty(template.AccountingGroup)) { template.AccountingGroup = oldTemplate.AccountingGroup; }
                if (string.IsNullOrEmpty(template.CasepackHeight)) { template.CasepackHeight = oldTemplate.CasepackHeight; }
                if (string.IsNullOrEmpty(template.CasepackLength)) { template.CasepackLength = oldTemplate.CasepackLength; }
                if (string.IsNullOrEmpty(template.CasepackQty)) { template.CasepackQty = oldTemplate.CasepackQty; }
                if (string.IsNullOrEmpty(template.CasepackWidth)) { template.CasepackWidth = oldTemplate.CasepackWidth; }
                if (string.IsNullOrEmpty(template.CasepackWeight)) { template.CasepackWeight = oldTemplate.CasepackWeight; }
                if (string.IsNullOrEmpty(template.Category)) { template.Category = oldTemplate.Category; }
                if (string.IsNullOrEmpty(template.Category2)) { template.Category2 = oldTemplate.Category2; }
                if (string.IsNullOrEmpty(template.Category3)) { template.Category3 = oldTemplate.Category3; }
                if (string.IsNullOrEmpty(template.Copyright)) { template.Copyright = oldTemplate.Copyright; }
                if (string.IsNullOrEmpty(template.CostProfileGroup)) { template.CostProfileGroup = oldTemplate.CostProfileGroup; }
                if (string.IsNullOrEmpty(template.DefaultActualCostUsd)) { template.DefaultActualCostUsd = oldTemplate.DefaultActualCostUsd; }
                if (string.IsNullOrEmpty(template.DefaultActualCostCad)) { template.DefaultActualCostCad = oldTemplate.DefaultActualCostCad; }
                if (string.IsNullOrEmpty(template.DtcPrice)) { template.DtcPrice = oldTemplate.DtcPrice; }
                if (string.IsNullOrEmpty(template.Duty)) { template.Duty = oldTemplate.Duty; }
                if (string.IsNullOrEmpty(template.EcommerceBullet1)) { template.EcommerceBullet1 = oldTemplate.EcommerceBullet1; }
                if (string.IsNullOrEmpty(template.EcommerceBullet2)) { template.EcommerceBullet2 = oldTemplate.EcommerceBullet2; }
                if (string.IsNullOrEmpty(template.EcommerceBullet3)) { template.EcommerceBullet3 = oldTemplate.EcommerceBullet3; }
                if (string.IsNullOrEmpty(template.EcommerceBullet4)) { template.EcommerceBullet4 = oldTemplate.EcommerceBullet4; }
                if (string.IsNullOrEmpty(template.EcommerceBullet5)) { template.EcommerceBullet5 = oldTemplate.EcommerceBullet5; }
                if (string.IsNullOrEmpty(template.EcommerceComponents)) { template.EcommerceComponents = oldTemplate.EcommerceComponents; }
                if (string.IsNullOrEmpty(template.EcommerceCost)) { template.EcommerceCost = oldTemplate.EcommerceCost; }
                if (string.IsNullOrEmpty(template.EcommerceExternalIdType)) { template.EcommerceExternalIdType = oldTemplate.EcommerceExternalIdType; }
                if (string.IsNullOrEmpty(template.EcommerceItemHeight)) { template.EcommerceItemHeight = oldTemplate.EcommerceItemHeight; }
                if (string.IsNullOrEmpty(template.EcommerceItemLength)) { template.EcommerceItemLength = oldTemplate.EcommerceItemLength; }
                if (string.IsNullOrEmpty(template.EcommerceItemTypeKeywords)) { template.EcommerceItemTypeKeywords = oldTemplate.EcommerceItemTypeKeywords; }
                if (string.IsNullOrEmpty(template.EcommerceItemWeight)) { template.EcommerceItemWeight = oldTemplate.EcommerceItemWeight; }
                if (string.IsNullOrEmpty(template.EcommerceItemWidth)) { template.EcommerceItemWidth = oldTemplate.EcommerceItemWidth; }
                if (string.IsNullOrEmpty(template.EcommerceModelName)) { template.EcommerceModelName = oldTemplate.EcommerceModelName; }
                if (string.IsNullOrEmpty(template.EcommercePackageLength)) { template.EcommercePackageLength = oldTemplate.EcommercePackageLength; }
                if (string.IsNullOrEmpty(template.EcommercePackageHeight)) { template.EcommercePackageHeight = oldTemplate.EcommercePackageHeight; }
                if (string.IsNullOrEmpty(template.EcommercePackageWeight)) { template.EcommercePackageWeight = oldTemplate.EcommercePackageWeight; }
                if (string.IsNullOrEmpty(template.EcommercePackageWidth)) { template.EcommercePackageWidth = oldTemplate.EcommercePackageWidth; }
                if (string.IsNullOrEmpty(template.EcommercePageQty)) { template.EcommercePageQty = oldTemplate.EcommercePageQty; }
                if (string.IsNullOrEmpty(template.EcommerceProductCategory)) { template.EcommerceProductCategory = oldTemplate.EcommerceProductCategory; }
                if (string.IsNullOrEmpty(template.EcommerceProductDescription)) { template.EcommerceProductDescription = oldTemplate.EcommerceProductDescription; }
                if (string.IsNullOrEmpty(template.EcommerceProductSubcategory)) { template.EcommerceProductSubcategory = oldTemplate.EcommerceProductSubcategory; }
                if (string.IsNullOrEmpty(template.EcommerceManufacturerName)) { template.EcommerceManufacturerName = oldTemplate.EcommerceManufacturerName; }
                if (string.IsNullOrEmpty(template.EcommerceMsrp)) { template.EcommerceMsrp = oldTemplate.EcommerceMsrp; }
                if (string.IsNullOrEmpty(template.EcommerceSize)) { template.EcommerceSize = oldTemplate.EcommerceSize; }
                if (string.IsNullOrEmpty(template.Gpc)) { template.Gpc = oldTemplate.Gpc; }
                if (string.IsNullOrEmpty(template.Height)) { template.Height = oldTemplate.Height; }
                if (string.IsNullOrEmpty(template.InnerpackHeight)) { template.InnerpackHeight = oldTemplate.InnerpackHeight; }
                if (string.IsNullOrEmpty(template.InnerpackLength)) { template.InnerpackLength = oldTemplate.InnerpackLength; }
                if (string.IsNullOrEmpty(template.InnerpackQuantity)) { template.InnerpackQuantity = oldTemplate.InnerpackQuantity; }
                if (string.IsNullOrEmpty(template.InnerpackWidth)) { template.InnerpackWidth = oldTemplate.InnerpackWidth; }
                if (string.IsNullOrEmpty(template.InnerpackWeight)) { template.InnerpackWeight = oldTemplate.InnerpackWeight; }
                if (string.IsNullOrEmpty(template.ItemCategory)) { template.ItemCategory = oldTemplate.ItemCategory; }
                if (string.IsNullOrEmpty(template.ItemFamily)) { template.ItemFamily = oldTemplate.ItemFamily; }
                if (string.IsNullOrEmpty(template.ItemGroup)) { template.ItemGroup = oldTemplate.ItemGroup; }
                if (string.IsNullOrEmpty(template.Length)) { template.Length = oldTemplate.Length; }
                if (string.IsNullOrEmpty(template.ListPriceCad)) { template.ListPriceCad = oldTemplate.ListPriceCad; }
                if (string.IsNullOrEmpty(template.ListPriceUsd)) { template.ListPriceUsd = oldTemplate.ListPriceUsd; }
                if (string.IsNullOrEmpty(template.ListPriceMxn)) { template.ListPriceMxn = oldTemplate.ListPriceMxn; }
                if (string.IsNullOrEmpty(template.MetaDescription)) { template.MetaDescription = oldTemplate.MetaDescription; }
                if (string.IsNullOrEmpty(template.MfgSource)) { template.MfgSource = oldTemplate.MfgSource; }
                if (string.IsNullOrEmpty(template.Msrp)) { template.Msrp = oldTemplate.Msrp; }
                if (string.IsNullOrEmpty(template.MsrpCad)) { template.MsrpCad = oldTemplate.MsrpCad; }
                if (string.IsNullOrEmpty(template.MsrpMxn)) { template.MsrpMxn = oldTemplate.MsrpMxn; }
                if (string.IsNullOrEmpty(template.PrintOnDemand)) { template.PrintOnDemand = oldTemplate.PrintOnDemand; }
                if (string.IsNullOrEmpty(template.ProductFormat)) { template.ProductFormat = oldTemplate.ProductFormat; }
                if (string.IsNullOrEmpty(template.ProductGroup)) { template.ProductGroup = oldTemplate.ProductGroup; }
                if (string.IsNullOrEmpty(template.ProductLine)) { template.ProductLine = oldTemplate.ProductLine; }
                if (string.IsNullOrEmpty(template.ProductQty)) { template.ProductQty = oldTemplate.ProductQty; }
                if (string.IsNullOrEmpty(template.PricingGroup)) { template.PricingGroup = oldTemplate.PricingGroup; }
                if (string.IsNullOrEmpty(template.PsStatus)) { template.PsStatus = oldTemplate.PsStatus; }
                if (string.IsNullOrEmpty(template.SatCode)) { template.SatCode = oldTemplate.SatCode; }
                if (string.IsNullOrEmpty(template.Size)) { template.Size = oldTemplate.Size; }
                if (string.IsNullOrEmpty(template.TariffCode)) { template.TariffCode = oldTemplate.TariffCode; }
                if (string.IsNullOrEmpty(template.Udex)) { template.Udex = oldTemplate.Udex; }
                if (string.IsNullOrEmpty(template.WebsitePrice)) { template.WebsitePrice = oldTemplate.WebsitePrice; }
                if (string.IsNullOrEmpty(template.Warranty)) { template.Warranty = oldTemplate.Warranty; }
                if (string.IsNullOrEmpty(template.Weight)) { template.Weight = oldTemplate.Weight; }
                if (string.IsNullOrEmpty(template.Width)) { template.Width = oldTemplate.Width; }
            
            return template;
        }

        /// <summary>
        ///     Excel bug causes 'Poster Captures' folder directory to be duplicated when copied and pasted. This removes the error when loaded into odin.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string FixImgUrl(string value)
        {
            string returnValue = value;
            if (value.Contains("Poster Captures\\Poster Captures\\"))
            {
                returnValue = value.Replace("Poster Captures\\Poster Captures", "Poster Captures");
            }
            return returnValue;
        }

        /// <summary>
        ///   Formats the Category for Lemonstand
        /// </summary>
        /// <param name="value">: split category</param>
        /// <returns>website formated category with | and => splits</returns>
        public string FormatCategory(string value)
        {
            string returnValue = "";

            if (!string.IsNullOrEmpty(value))
            {
                string comboValue = string.Empty;
                string[] s = value.Split(':');

                foreach (string category in s)
                {
                    if (comboValue != string.Empty)
                    {
                        comboValue += "=>";
                    }
                    comboValue += category.Trim();
                    if (returnValue != string.Empty)
                    {
                        returnValue += '|';
                    }
                    returnValue += comboValue;

                }
            }
            return returnValue;
        }        
        
        /// <summary>
        ///     Calls a window explorer with workbook reader and loads in list of spreadsheet items
        /// </summary>
        /// <param name="status">Item Status (update / add / remove)</param>
        /// <returns>List of spreadsheet items</returns>
        public List<string> LoadItemIds(string status, string fileName)
        {
            List<string> itemIdList = new List<string>();
            WorksheetData worksheetData = this.WorkbookReader.ReadWorksheet(fileName);
            if (worksheetData.CellData.Count == 0)
            {
                MessageBox.Show("Odin could not read any data from provided spread sheet.");
            }
            for (int row = 0; row < worksheetData.CellData.Count; row++)
            {
                if (!string.IsNullOrEmpty(worksheetData.GetValue(row, WorksheetColumnHeaders.ItemId)))
                {
                    if (GlobalData.ItemIds.Contains(worksheetData.GetValue(row, WorksheetColumnHeaders.ItemId).Trim()))
                    {
                        itemIdList.Add(worksheetData.GetValue(row, WorksheetColumnHeaders.ItemId).Trim());
                    }
                }

                else
                {
                    continue;
                }
            }
            return itemIdList;
        }

        /// <summary>
        ///     Reads a cell from the given worksheet and returns the value
        /// </summary>
        /// <param name="worksheetData">worksheet being read</param>
        /// <param name="row">data row</param>
        /// <param name="value">header value</param>
        /// <param name="value2">alternate header value</param>
        /// <returns></returns>
        public string ReadWorksheetCell(WorksheetData worksheetData, int row, string value, string value2 = null)
        {
            if (value2 != null)
            {
                if (!string.IsNullOrEmpty(worksheetData.GetValue(row, value, value2)))
                {
                    return worksheetData.GetValue(row, value, value2).Trim();
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(worksheetData.GetValue(row, value)))
                {
                    return worksheetData.GetValue(row, value).Trim();
                }
            }
            return "";
        }

        /// <summary>
        ///     Returns image name as a [itemid]-[itemnumber].jpg 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="imgNum"></param>
        /// <returns></returns>
        public string ReturnImageName(string itemId, int imgNum, bool forMagento2Images = true)
        {
            // for framed posters in Magento 2, points to location of shared images on server
            if (forMagento2Images)
            {
                if (itemId.Substring(0, 2) == "FR")
                {
                    if (imgNum == 5 || imgNum == 4)
                    {
                        if (itemId.Contains("BLK22X34"))
                        {
                            if (imgNum == 4)
                            {
                                return "../catalog/product/frames/cust_frame_back_blk.png";
                            }
                            else
                            {
                                return "../catalog/product/frames/cust_frame_blk_side.jpg";
                            }
                        }
                        if (itemId.Contains("SIL22X34"))
                        {
                            if (imgNum == 4)
                            {
                                return "../catalog/product/frames/cust_frame_back_sil.png";
                            }
                            else
                            {
                                return "../catalog/product/frames/cust_frame_sil_side.jpg";
                            }
                        }
                    }
                }
            }

            return itemId + "-" + imgNum.ToString() + ".jpg";
        }

        /// <summary>
        ///     Calls a window explorer with workbook reader and loads in list of spreadsheet items
        /// </summary>
        /// <param name="status">Item Status (update / add / remove)</param>
        /// <returns>List of spreadsheet items</returns>
        public ObservableCollection<ItemObject> LoadExcelItems(string status, string fileName)
        {
            ObservableCollection<ItemObject> itemList = new ObservableCollection<ItemObject>();
            WorksheetData worksheetData = this.WorkbookReader.ReadWorksheet(fileName);
            if (worksheetData.CellData.Count == 0)
            {
                MessageBox.Show("Odin could not read any data from provided spread sheet.");
            }
            for (int row = 0; row < worksheetData.CellData.Count; row++)
            {
                string ItemId = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ItemId);

                if (ItemId == "")
                {
                    continue;
                }
                GlobalData.LocalItemIds.Add(ItemId);
                ItemObject item = new ItemObject(1)
                {
                    ItemRow = row + 1,
                    ItemId = ItemId,
                    AccountingGroup = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.AccountingGroup, WorksheetColumnHeaders.AcctgGroup),
                    AltImageFile1 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ImagePath2),
                    AltImageFile2 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ImagePath3),
                    AltImageFile3 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ImagePath4),
                    AltImageFile4 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ImagePath5),
                    BillOfMaterials = ParseChildElementIds(ItemId, ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.BillOfMaterials, WorksheetColumnHeaders.BOM)),
                    CasepackHeight = DbUtil.RoundValue2Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.CasepackHeight)),
                    CasepackLength = DbUtil.RoundValue2Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.CasepackLength).Trim()),
                    CasepackQty = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.CasepackQty, WorksheetColumnHeaders.CasepackQuantity),
                    CasepackUpc = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.CasepackUpc).Trim(),
                    CasepackWidth = DbUtil.RoundValue2Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.CasepackWidth).Trim()),
                    CasepackWeight = DbUtil.RoundValue2Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.CasepackWeight).Trim()),
                    Category = DbUtil.ReplaceCharacters(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Category)),
                    Category2 = DbUtil.ReplaceCharacters(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Category2)),
                    Category3 = DbUtil.ReplaceCharacters(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Category3)),
                    Color = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Color, WorksheetColumnHeaders.LabelColor),
                    Copyright = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Copyright),
                    CountryOfOrigin = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.CountryOfOrigin),
                    CostProfileGroup = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.CostProfileGroup),
                    DefaultActualCostUsd = DbUtil.RoundValue4Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.DacUsd, WorksheetColumnHeaders.DefaultActualCostUsd)),
                    DefaultActualCostCad = DbUtil.RoundValue4Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.DacCad, WorksheetColumnHeaders.DefaultActualCostCad)),
                    Description = DbUtil.ReplaceCharacters(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Description)).Trim(),
                    DirectImport = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.DirectImport),
                    DtcPrice = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.DtcPrice), 2),
                    Duty = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Duty),
                    Ean = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ean),
                    EcommerceAsin = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceAsin, WorksheetColumnHeaders.A_Asin),
                    EcommerceBullet1 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceBullet1, WorksheetColumnHeaders.A_Bullet1),
                    EcommerceBullet2 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceBullet2, WorksheetColumnHeaders.A_Bullet2),
                    EcommerceBullet3 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceBullet3, WorksheetColumnHeaders.A_Bullet3),
                    EcommerceBullet4 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceBullet4, WorksheetColumnHeaders.A_Bullet4),
                    EcommerceBullet5 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceBullet5, WorksheetColumnHeaders.A_Bullet5),
                    EcommerceComponents = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceComponents, WorksheetColumnHeaders.A_Components),
                    EcommerceCost = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceCost, WorksheetColumnHeaders.A_Cost), 2),
                    EcommerceExternalId = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceExternalId, WorksheetColumnHeaders.A_ExternalID).Trim(),
                    EcommerceExternalIdType = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceExternalIdType, WorksheetColumnHeaders.A_ExternalIdType).Trim(),
                    EcommerceGenericKeywords = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.GenericKeywords, WorksheetColumnHeaders.EcommerceGenericKeywords),
                    EcommerceItemHeight = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceItemHeight, WorksheetColumnHeaders.A_ItemHeight), 1),
                    EcommerceItemLength = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceItemLength, WorksheetColumnHeaders.A_ItemLength), 1),
                    EcommerceItemName = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceItemName, WorksheetColumnHeaders.A_ItemName).Trim(),
                    EcommerceItemTypeKeywords = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceItemTypeKeywords).Trim(),
                    EcommerceItemWeight = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceItemWeight, WorksheetColumnHeaders.A_ItemWeight), 1),
                    EcommerceItemWidth = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceItemWidth, WorksheetColumnHeaders.A_ItemWidth), 1),
                    EcommerceModelName = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceModelName, WorksheetColumnHeaders.A_ModelName).Trim(),
                    EcommercePackageHeight = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommercePackageHeight, WorksheetColumnHeaders.A_PackageHeight), 1),
                    EcommercePackageLength = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommercePackageLength, WorksheetColumnHeaders.A_PackageLength), 1),
                    EcommercePackageWeight = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommercePackageWeight, WorksheetColumnHeaders.A_PackageWeight), 1),
                    EcommercePackageWidth = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommercePackageWidth, WorksheetColumnHeaders.A_PackageWidth), 1).Trim(),
                    EcommercePageQty = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommercePageQty).Trim(),
                    EcommerceParentAsin = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceParentAsin).Trim(),
                    EcommerceProductCategory = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceProductCategory, WorksheetColumnHeaders.A_ProductCategory),
                    EcommerceProductDescription = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceProductDescription, WorksheetColumnHeaders.A_ProductDescription),
                    EcommerceProductSubcategory = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceProductSubcategory, WorksheetColumnHeaders.A_ProductSubcategory),
                    EcommerceManufacturerName = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceManufacturerName, WorksheetColumnHeaders.A_ManufacturerName),
                    EcommerceMsrp = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceMsrp, WorksheetColumnHeaders.A_Msrp), 2),
                    EcommerceSubjectKeywords = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceSearchTerms, WorksheetColumnHeaders.A_SearchTerms),
                    EcommerceSize = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceSize, WorksheetColumnHeaders.A_Size),
                    EcommerceUpc = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.EcommerceUpc),
                    Genre1 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Genre1),
                    Genre2 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Genre2),
                    Genre3 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Genre3),
                    Gpc = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Gpc),
                    Height = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Height, WorksheetColumnHeaders.ItemHeight), 1),
                    ImagePath = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ImagePath, WorksheetColumnHeaders.ImagePath1),
                    InnerpackHeight = DbUtil.RoundValue2Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.InnerpackHeight)),
                    InnerpackLength = DbUtil.RoundValue2Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.InnerpackLength)),
                    InnerpackQuantity = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.InnerpackQuantity, WorksheetColumnHeaders.InnerpackQty),
                    InnerpackUpc = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.InnerpackUpc),
                    InnerpackWidth = DbUtil.RoundValue2Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.InnerpackWidth)),
                    InnerpackWeight = DbUtil.RoundValue2Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.InnerpackWeight)),
                    InStockDate = DbUtil.DateTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.InStockDate, WorksheetColumnHeaders.In_StockDate)),
                    Isbn = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Isbn).Trim(),
                    ItemCategory = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ItemCategory).Trim(),
                    ItemFamily = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ItemFamily).Trim(),
                    ItemGroup = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ItemGroup),
                    ItemKeywords = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ItemKeywords),
                    Language = DbUtil.OrderLanguage(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Language)),
                    Length = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Length, WorksheetColumnHeaders.ItemLength), 1),
                    License = RemoveSpecialChar(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.License)),
                    LicenseBeginDate = DbUtil.DateTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.LicenseBeginDate)),
                    ListPriceCad = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ListPriceCad, WorksheetColumnHeaders.ListPriceCadCAD), 2),
                    ListPriceUsd = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ListPriceUsd, WorksheetColumnHeaders.ListPriceUsdUSD), 2),
                    ListPriceMxn = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ListPriceMxn, WorksheetColumnHeaders.ListPriceMxnMXN), 2),
                    MetaDescription = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.MetaDescription).Trim(),
                    MfgSource = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.MfgSource).Trim(),
                    Msrp = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Msrp).Trim(),
                    MsrpCad = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.MsrpCad).Trim(),
                    MsrpMxn = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.MsrpMxn).Trim(),
                    PricingGroup = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.PricingGroup, WorksheetColumnHeaders.PricingGroupProduct).Trim(),
                    PrintOnDemand = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.PrintOnDemand).Trim(),
                    ProductFormat = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ProductFormat).Trim(),
                    ProductGroup = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ProductGroup).Trim(),
                    ProductLine = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ProductLine).Trim(),
                    ProductQty = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ProductQty, WorksheetColumnHeaders.ProductQuantity),
                    Property = RemoveSpecialChar(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Property)),
                    PsStatus = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.PsStatus).Trim(),
                    SatCode = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.SatCode).Trim(),
                    SellOnAllPosters = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.SellOnAllPosters).Trim(),
                    SellOnAmazon = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.A_AmazonActive, WorksheetColumnHeaders.SellOnAmazon).Trim(),
                    SellOnAmazonSellerCentral = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.SellOnAmazonSellerCentral).Trim(),
                    SellOnEcommerce = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.SellOnEcommerce).Trim(),
                    SellOnFanatics = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.SellOnFanatics).Trim(),
                    SellOnGuitarCenter = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.SellOnGuitarCenter).Trim(),
                    SellOnHayneedle = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.SellOnHayneedle).Trim(),
                    SellOnHouzz = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.SellOnHouzz).Trim(),
                    SellOnTarget = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.SellOnTarget).Trim(),
                    SellOnTrends = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.SellOnTrends).Trim(),
                    SellOnTrs = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.SellOnTrs, WorksheetColumnHeaders.SellOnShopTrends).Trim(),
                    SellOnWalmart = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.SellOnWalmart).Trim(),
                    SellOnWayfair = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.SellOnWayfair).Trim(),
                    ShortDescription = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ShortDescription).Trim(),
                    Size = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Size).Trim(),
                    StandardCost = DbUtil.RoundValue4Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.DacUsd, WorksheetColumnHeaders.DefaultActualCostUsd)),
                    StatsCode = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.StatsCode).Trim(),
                    Status = status,
                    TariffCode = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.TariffCode).Trim(),
                    Territory = DbUtil.OrderTerritory(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Territory)),
                    Title = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Title).Trim(),
                    Udex = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Udex).Trim(),
                    Upc = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Upc).Trim(),
                    Warranty = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Warranty).Trim(),
                    WarrantyCheck = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.WarrantyCheck).Trim(),
                    WebsitePrice = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.WebsitePrice), 2),
                    Weight = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Weight, WorksheetColumnHeaders.ItemWeight), 1),
                    Width = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Width, WorksheetColumnHeaders.ItemWidth), 1)
                };
                // Load override attributes if admin
                if (GlobalData.UserPermissions.Contains("ADMIN_CONTROLS"))
                {
                    item.ItemKeywordsOverride = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ItemKeywordsOverride).Trim();
                    item.TitleOverride = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.TitleOverride).Trim();
                    item.WebsitePriceOverride = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.WebsitePriceOverride).Trim();
                }
                if (status == "Add")
                {
                    item.ProductIdTranslation = ParseChildElementIds(ItemId, ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ProductIdTranslation));
                    string TemplateName = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.TemplateName, WorksheetColumnHeaders.TemplateId);
                    if (!string.IsNullOrEmpty(TemplateName))
                    {
                        item = SetTemplateValues(TemplateName,item);
                    }
                    item.SetFlagDefaults();
                }
                item.EcommerceCountryofOrigin = RetrieveFullCountryOfOrigin(item.CountryOfOrigin);

                item.ResetUpdate();
                itemList.Add(item);
            }
            return itemList;
        }
        
        /// <summary>
        ///     Calls a window explorer with workbook reader and loads in a list of templates
        /// </summary>
        public List<ItemObject> LoadTemplate(string fileName, string type)
        {
            List<ItemObject> result = new List<ItemObject>();
            WorksheetData worksheetData = this.WorkbookReader.ReadWorksheet(fileName);
            if (worksheetData.CellData.Count == 0)
            {
                MessageBox.Show("Odin could not read any data from provided spread sheet.");
            }
            for (int row = 0; row < worksheetData.CellData.Count; row++)
            {
                if (!string.IsNullOrEmpty(worksheetData.GetValue(row, WorksheetColumnHeaders.TemplateId)) || type == "Add")
                {
                    ItemObject template = new ItemObject(2)
                    {
                        TemplateId = worksheetData.GetValue(row, WorksheetColumnHeaders.TemplateId, WorksheetColumnHeaders.TemplateName).Trim(),
                        AccountingGroup = worksheetData.GetValue(row, WorksheetColumnHeaders.AccountingGroup, WorksheetColumnHeaders.AcctgGroup).Trim(),
                        CasepackHeight = DbUtil.RoundValue2Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.CasepackHeight).Trim()),
                        CasepackLength = DbUtil.RoundValue2Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.CasepackLength).Trim()),
                        CasepackQty = worksheetData.GetValue(row, WorksheetColumnHeaders.CasepackQty).Trim(),
                        CasepackWidth = DbUtil.RoundValue2Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.CasepackWidth).Trim()),
                        CasepackWeight = DbUtil.RoundValue2Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.CasepackWeight).Trim()),
                        Category = DbUtil.ReplaceCharacters(worksheetData.GetValue(row, WorksheetColumnHeaders.Category).Trim()),
                        Category2 = DbUtil.ReplaceCharacters(worksheetData.GetValue(row, WorksheetColumnHeaders.Category2).Trim()),
                        Category3 = DbUtil.ReplaceCharacters(worksheetData.GetValue(row, WorksheetColumnHeaders.Category3).Trim()),
                        Copyright = worksheetData.GetValue(row, WorksheetColumnHeaders.Copyright).Trim(),
                        CountryOfOrigin = worksheetData.GetValue(row, WorksheetColumnHeaders.CountryOfOrigin).Trim(),
                        CostProfileGroup = worksheetData.GetValue(row, WorksheetColumnHeaders.CostProfileGroup).Trim(),
                        DefaultActualCostUsd = DbUtil.RoundValue4Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.DacUsd, WorksheetColumnHeaders.DefaultActualCostUsd).Trim()),
                        DefaultActualCostCad = DbUtil.RoundValue4Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.DacCad, WorksheetColumnHeaders.DefaultActualCostCad).Trim()),
                        DtcPrice = DbUtil.RoundValue2Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.DtcPrice).Trim()),
                        Gpc = worksheetData.GetValue(row, WorksheetColumnHeaders.Gpc).Trim(),
                        Height = worksheetData.GetValue(row, WorksheetColumnHeaders.Height, WorksheetColumnHeaders.ItemHeight).Trim(),
                        InnerpackHeight = DbUtil.RoundValue2Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.InnerpackHeight).Trim()),
                        InnerpackLength = DbUtil.RoundValue2Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.InnerpackLength).Trim()),
                        InnerpackQuantity = worksheetData.GetValue(row, WorksheetColumnHeaders.InnerpackQuantity, WorksheetColumnHeaders.InnerpackQty).Trim(),
                        InnerpackWidth = DbUtil.RoundValue2Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.InnerpackWidth).Trim()),
                        InnerpackWeight = DbUtil.RoundValue2Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.InnerpackWeight).Trim()),
                        ItemCategory = worksheetData.GetValue(row, WorksheetColumnHeaders.ItemCategory).Trim(),
                        ItemFamily = worksheetData.GetValue(row, WorksheetColumnHeaders.ItemFamily).Trim(),
                        ItemGroup = worksheetData.GetValue(row, WorksheetColumnHeaders.ItemGroup).Trim(),
                        Length = worksheetData.GetValue(row, WorksheetColumnHeaders.Length, WorksheetColumnHeaders.ItemLength).Trim(),
                        ListPriceCad = worksheetData.GetValue(row, WorksheetColumnHeaders.ListPriceCad, WorksheetColumnHeaders.ListPriceCadCAD).Trim(),
                        ListPriceUsd = worksheetData.GetValue(row, WorksheetColumnHeaders.ListPriceUsd, WorksheetColumnHeaders.ListPriceUsdUSD).Trim(),
                        ListPriceMxn = worksheetData.GetValue(row, WorksheetColumnHeaders.ListPriceMxn, WorksheetColumnHeaders.ListPriceMxnMXN).Trim(),
                        MetaDescription = worksheetData.GetValue(row, WorksheetColumnHeaders.MetaDescription).Trim(),
                        MfgSource = worksheetData.GetValue(row, WorksheetColumnHeaders.MfgSource).Trim(),
                        Msrp = worksheetData.GetValue(row, WorksheetColumnHeaders.Msrp).Trim(),
                        MsrpCad = worksheetData.GetValue(row, WorksheetColumnHeaders.MsrpCad).Trim(),
                        MsrpMxn = worksheetData.GetValue(row, WorksheetColumnHeaders.MsrpMxn).Trim(),
                        PricingGroup = worksheetData.GetValue(row, WorksheetColumnHeaders.PricingGroup, WorksheetColumnHeaders.PricingGroupProduct).Trim(),
                        PrintOnDemand = worksheetData.GetValue(row, WorksheetColumnHeaders.PrintOnDemand).Trim(),
                        ProductFormat = worksheetData.GetValue(row, WorksheetColumnHeaders.ProductFormat).Trim(),
                        ProductGroup = worksheetData.GetValue(row, WorksheetColumnHeaders.ProductGroup).Trim(),
                        ProductLine = worksheetData.GetValue(row, WorksheetColumnHeaders.ProductLine).Trim(),
                        ProductQty = worksheetData.GetValue(row, WorksheetColumnHeaders.ProductQty, WorksheetColumnHeaders.ProductQuantity).Trim(),
                        PsStatus = worksheetData.GetValue(row, WorksheetColumnHeaders.PsStatus).Trim(),
                        Size = worksheetData.GetValue(row, WorksheetColumnHeaders.Size).Trim(),
                        TariffCode = worksheetData.GetValue(row, WorksheetColumnHeaders.TariffCode).Trim(),
                        Udex = worksheetData.GetValue(row, WorksheetColumnHeaders.Udex).Trim(),
                        WebsitePrice = worksheetData.GetValue(row, WorksheetColumnHeaders.WebsitePrice).Trim(),
                        Weight = worksheetData.GetValue(row, WorksheetColumnHeaders.Weight, WorksheetColumnHeaders.ItemWeight).Trim(),
                        Width = worksheetData.GetValue(row, WorksheetColumnHeaders.Width, WorksheetColumnHeaders.ItemWidth).Trim(),
                        EcommerceBullet1 = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceBullet1, WorksheetColumnHeaders.A_Bullet1).Trim(),
                        EcommerceBullet2 = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceBullet2, WorksheetColumnHeaders.A_Bullet2).Trim(),
                        EcommerceBullet3 = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceBullet3, WorksheetColumnHeaders.A_Bullet3).Trim(),
                        EcommerceBullet4 = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceBullet4, WorksheetColumnHeaders.A_Bullet4).Trim(),
                        EcommerceBullet5 = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceBullet5, WorksheetColumnHeaders.A_Bullet5).Trim(),
                        EcommerceComponents = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceComponents, WorksheetColumnHeaders.A_Components).Trim(),
                        EcommerceCost = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceCost, WorksheetColumnHeaders.A_Cost).Trim(),
                        EcommerceExternalIdType = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceExternalIdType, WorksheetColumnHeaders.A_ExternalIdType).Trim(),
                        EcommerceItemHeight = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceItemHeight, WorksheetColumnHeaders.A_ItemHeight).Trim(),
                        EcommerceItemLength = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceItemLength, WorksheetColumnHeaders.A_ItemLength).Trim(),
                        EcommerceItemTypeKeywords = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceItemTypeKeywords).Trim(),
                        EcommerceItemWeight = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceItemWeight, WorksheetColumnHeaders.A_ItemWeight).Trim(),
                        EcommerceItemWidth = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceItemWidth, WorksheetColumnHeaders.A_ItemWidth).Trim(),
                        EcommerceModelName = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceModelName, WorksheetColumnHeaders.A_ModelName).Trim(),
                        EcommercePackageHeight = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommercePackageHeight, WorksheetColumnHeaders.A_PackageHeight).Trim(),
                        EcommercePackageLength = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommercePackageLength, WorksheetColumnHeaders.A_PackageLength).Trim(),
                        EcommercePackageWeight = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommercePackageWeight, WorksheetColumnHeaders.A_PackageWeight).Trim(),
                        EcommercePackageWidth = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommercePackageWidth, WorksheetColumnHeaders.A_PackageWidth).Trim(),
                        EcommercePageQty = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommercePageQty, WorksheetColumnHeaders.A_PageQty).Trim(),
                        EcommerceProductCategory = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceProductCategory, WorksheetColumnHeaders.A_ProductCategory).Trim(),
                        EcommerceProductDescription = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceProductDescription, WorksheetColumnHeaders.A_ProductDescription).Trim(),
                        EcommerceProductSubcategory = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceProductSubcategory, WorksheetColumnHeaders.A_ProductSubcategory).Trim(),
                        EcommerceManufacturerName = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceManufacturerName, WorksheetColumnHeaders.A_ManufacturerName).Trim(),
                        EcommerceMsrp = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceMsrp, WorksheetColumnHeaders.A_Msrp).Trim(),
                        EcommerceSize = worksheetData.GetValue(row, WorksheetColumnHeaders.EcommerceSize, WorksheetColumnHeaders.A_Size).Trim(),
                    };
                    result.Add(template);
                    if (type == "Add") { return result; }
                }
                else
                {
                    continue;
                }
            }
            if (result.Count == 0)
            {
                result.Add(new ItemObject(2));
            }
            return result;
        }
        
        /// <summary>
        ///     Parse the productId translation IDs and check for an ammount value be checking for whitespace or parenthesis
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ChildElement ParseChildElementId(string parentId, string productId)
        {
            ChildElement productIdTranslation = new ChildElement(productId, parentId);
            productId = productId.Trim();
            if (productId.Contains("("))
            {
                string[] parts = productId.Split('(');
                if (parts[1].Contains(")")) { parts[1] = parts[1].Replace(")", ""); }

                if (DbUtil.IsNumber(parts[1]))
                {
                    productIdTranslation.ItemId = parts[0].Trim();
                    productIdTranslation.Qty = Convert.ToInt32(parts[1]);
                }
            }
            else if (productId.Contains(" "))
            {
                string[] parts = productId.Split(' ');
                if(DbUtil.IsNumber(parts[1]))
                {
                    productIdTranslation.ItemId = parts[0].Trim();
                    productIdTranslation.Qty = Convert.ToInt32(parts[1]);
                }
            }
            return productIdTranslation;
        }

        /// <summary>
        ///     Parses through a string of comma seperated product id translations and returns a list
        /// </summary>
        /// <param name="productIds"></param>
        /// <returns></returns>
        public List<ChildElement> ParseChildElementIds(string parentId, string productIds)
        {
            List<ChildElement> result = new List<ChildElement>();
            if (!string.IsNullOrEmpty(productIds))
            {
                if (productIds != "[CLEAR]")
                {
                    string[] stringList = productIds.Split(',');
                    foreach (string i in stringList)
                    {
                        if (!string.IsNullOrEmpty(i))
                        {
                            result.Add(ParseChildElementId(parentId, i));
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        ///     Copies the images for the given request into a folder on the users desktop
        /// </summary>
        /// <param name="itemIds"></param>
        /// <returns>Any image paths that were incorrect</returns>
        public List<string> PullImages(List<string> itemIds, bool clearSpaces = false)
        {
            string location = @"C:\Users\" + Environment.UserName.ToLower() + @"\Desktop\EcomerceImages";
            List<string> missingImages = new List<string>();
            List<string> usedIdCores = new List<string>();
            Directory.CreateDirectory(location);
            foreach (string itemId in itemIds)
            {
                foreach (KeyValuePair<string,int> img in RetrieveImagePaths(itemId))
                {
                    if (CheckFileExists(img.Key, false))
                    {
                        if (CheckFileSize(img.Key, false))
                        {
                            string filename = location + @"\" + ReturnImageName(itemId, img.Value);
                            //  make sure the same image file has not been created in the ecommerceImage directory already
                            if (!CheckFileExists(filename, false))
                            {
                                Image myImage = Image.FromFile(img.Key, true);
                                SaveJpeg(filename, myImage, 60);
                                myImage.Dispose();
                                if (!usedIdCores.Contains(RetrieveItemIdCore(itemId)) && img.Value == 1)
                                {
                                    if (itemId.Substring(0, 2) == "RP" || itemId.Substring(0, 3) == "POD")
                                    {
                                        filename = location + @"\" + ReturnImageName("POSTER" + RetrieveItemIdCore(itemId), img.Value);
                                        Image posterImage = Image.FromFile(img.Key, true);
                                        SaveJpeg(filename, posterImage, 60);
                                        posterImage.Dispose();
                                        usedIdCores.Add(RetrieveItemIdCore(itemId));
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        missingImages.Add(img.Key);
                    }
                }
            }
            return missingImages;
        }

        /// <summary>
        ///     Combines the three category fields into a single string to be uploaded to the website.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <returns></returns>
        public string RemoveDuplicateCategories(string value1, string value2, string value3)
        {
            string value = "";
            List<string> values = new List<string>();
            List<string> sort = new List<string>();
            if (!string.IsNullOrEmpty(value1)) { values.Add(FormatCategory(value1)); }
            if (!string.IsNullOrEmpty(value2)) { values.Add(FormatCategory(value2)); }
            if (!string.IsNullOrEmpty(value3)) { values.Add(FormatCategory(value3)); }
            if (values.Count > 0)
            {
                foreach (string i in values)
                {
                    string[] x = i.Split('|');
                    foreach (string a in x)
                    {
                        if (!sort.Contains(a))
                        {
                            sort.Add(a);
                        }
                    }
                }
                foreach (string x in sort)
                {
                    value += x + "|";
                }
            }
            if (value != "")
            {
                value = value.Remove(value.Length - 1);
            }

            return value;
        }
                
        /// <summary>
        ///     Returns a list of all header values (IN CAPS and with no spaces)
        /// </summary>
        /// <returns></returns>
        public List<string> ReturnHeaderValues()
        {
            List<string> headers = new List<string>();

            Type t = typeof(WorksheetColumnHeaders);
            FieldInfo[] fields = t.GetFields(BindingFlags.Static | BindingFlags.Public);

            foreach (FieldInfo fi in fields)
            {
                string header = fi.GetValue(null).ToString().ToUpper();
                header = header.Replace(" ", "");
                headers.Add(header);
            }
            headers.Add("IMAGEPATH");
            return headers;
        }

        /// <summary>
        ///     Multiplies the item price by the prodQty value and returns the new price for packs.
        /// </summary>
        /// <param name="price"></param>
        /// <param name="prodQty"></param>
        /// <returns></returns>
        public string ReturnItemPrice(string price, string prodQty)
        {
            string value = price;
            if ((!string.IsNullOrEmpty(prodQty)) || (prodQty != "1"))
            {
                if (decimal.TryParse(price, out decimal decValue))
                {
                    if (decimal.TryParse(prodQty, out decValue))
                    {
                        decimal prodQtyInt = Convert.ToDecimal(prodQty);
                        if (prodQtyInt >= 1)
                        {
                            decimal priceInt = Convert.ToDecimal(price);
                            decimal newValue = priceInt * prodQtyInt;
                            value = Convert.ToString(newValue);
                        }
                    }
                }
            }
            return value;
        }

        /// <summary> 
        /// Returns the image codec with the given mime type 
        /// </summary> 
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats 
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec 
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];

            return null;
        }

        /// <summary> 
        /// Saves an image as a jpeg image, with the given quality 
        /// </summary> 
        /// <param name="path"> Path to which the image would be saved. </param> 
        /// <param name="quality"> An integer from 0 to 100, with 100 being the highest quality. </param> 
        public static void SaveJpeg(string path, Image img, int quality)
        {
            if(path.Contains('.'))
            {
               string[] segments = path.Split('.');
                path = segments[0] + ".jpg";
            }
            if (quality < 0 || quality > 100)
                throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");
            Bitmap img2 = new Bitmap(img);
            // Encoder parameter for image quality 
            EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, quality);
            // JPEG image codec 
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img2.Save(path, jpegCodec, encoderParams);

            img2.Dispose();
            encoderParams.Dispose();
            qualityParam.Dispose();
        }

        /// <summary>
        ///     Reads the categories for the product to determine what product group to assign, default to "Product"
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        public string SetProductType(List<string> var)
        {
            foreach (string i in var)
            {
                if (i.Contains("Paper Craft"))
                {
                    return "Papercraft Product";
                }
                else if (i.Contains("Posters"))
                {
                    return "Poster Product";
                }
                else if (i.Contains("Stickers & Tattoos"))
                {
                    return "Sticker Product";
                }
                else if (i.Contains("Writing"))
                {
                    return "Writing Product";
                }
                else if (i.Contains("Gift Wrap"))
                {
                    return "Gift Wrap Product";
                }
                else if (i.Contains("Art Zone"))
                {
                    return "Art Zone Product";
                }
                else if (i.Contains("Bookmarks"))
                {
                    return "Bookmark Product";
                }
                else if (i.Contains("Calendars"))
                {
                    return "Calendar Product";
                }
                else if (i.Contains("Tape"))
                {
                    return "Tape Product";
                }
                else if (i.Contains("Tape Works"))
                {
                    return "Tape Product";
                }
            }

            return "Product";
        }

        /// <summary>
        ///     Returns items with pre-loaded template data
        /// </summary>
        /// <param name="TemplateName"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public ItemObject SetTemplateValues(string TemplateName, ItemObject item)
        {
            if (GlobalData.TemplateNames.Contains(TemplateName))
            {
                ItemObject template = RetrieveTemplate(TemplateName);
                if (string.IsNullOrEmpty(item.AccountingGroup)) { item.AccountingGroup = template.AccountingGroup; }
                if (string.IsNullOrEmpty(item.CasepackHeight)) { item.CasepackHeight = template.CasepackHeight; }
                if (string.IsNullOrEmpty(item.CasepackLength)) { item.CasepackLength = template.CasepackLength; }
                if (string.IsNullOrEmpty(item.CasepackQty)) { item.CasepackQty = template.CasepackQty; }
                if (string.IsNullOrEmpty(item.CasepackWidth)) { item.CasepackWidth = template.CasepackWidth; }
                if (string.IsNullOrEmpty(item.CasepackWeight)) { item.CasepackWeight = template.CasepackWeight; }
                if (string.IsNullOrEmpty(item.Category)) { item.Category = template.Category; }
                if (string.IsNullOrEmpty(item.Category2)) { item.Category2 = template.Category2; }
                if (string.IsNullOrEmpty(item.Category3)) { item.Category3 = template.Category3; }
                if (string.IsNullOrEmpty(item.Copyright)) { item.Copyright = template.Copyright; }
                if (string.IsNullOrEmpty(item.CountryOfOrigin)) { item.CountryOfOrigin = template.CountryOfOrigin; }
                if (string.IsNullOrEmpty(item.CostProfileGroup)) { item.CostProfileGroup = template.CostProfileGroup; }
                if (string.IsNullOrEmpty(item.DefaultActualCostUsd)) { item.DefaultActualCostUsd = template.DefaultActualCostUsd; }
                if (string.IsNullOrEmpty(item.DefaultActualCostCad)) { item.DefaultActualCostCad = template.DefaultActualCostCad; }
                if (string.IsNullOrEmpty(item.Duty)) { item.Duty = template.Duty; }
                if (string.IsNullOrEmpty(item.EcommerceBullet1)) { item.EcommerceBullet1 = template.EcommerceBullet1; }
                if (string.IsNullOrEmpty(item.EcommerceBullet2)) { item.EcommerceBullet2 = template.EcommerceBullet2; }
                if (string.IsNullOrEmpty(item.EcommerceBullet3)) { item.EcommerceBullet3 = template.EcommerceBullet3; }
                if (string.IsNullOrEmpty(item.EcommerceBullet4)) { item.EcommerceBullet4 = template.EcommerceBullet4; }
                if (string.IsNullOrEmpty(item.EcommerceBullet5)) { item.EcommerceBullet5 = template.EcommerceBullet5; }
                if (string.IsNullOrEmpty(item.EcommerceComponents)) { item.EcommerceComponents = template.EcommerceComponents; }
                if (string.IsNullOrEmpty(item.EcommerceCost)) { item.EcommerceCost = template.EcommerceCost; }
                if (string.IsNullOrEmpty(item.EcommerceExternalIdType)) { item.EcommerceExternalIdType = template.EcommerceExternalIdType; }
                if (string.IsNullOrEmpty(item.EcommerceItemHeight)) { item.EcommerceItemHeight = template.EcommerceItemHeight; }
                if (string.IsNullOrEmpty(item.EcommerceItemLength)) { item.EcommerceItemLength = template.EcommerceItemLength; }
                if (string.IsNullOrEmpty(item.EcommerceItemTypeKeywords)) { item.EcommerceItemTypeKeywords = template.EcommerceItemTypeKeywords; }
                if (string.IsNullOrEmpty(item.EcommerceItemWeight)) { item.EcommerceItemWeight = template.EcommerceItemWeight; }
                if (string.IsNullOrEmpty(item.EcommerceItemWidth)) { item.EcommerceItemWidth = template.EcommerceItemWidth; }
                if (string.IsNullOrEmpty(item.EcommerceModelName)) { item.EcommerceModelName = template.EcommerceModelName; }
                if (string.IsNullOrEmpty(item.EcommercePackageHeight)) { item.EcommercePackageHeight = template.EcommercePackageHeight; }
                if (string.IsNullOrEmpty(item.EcommercePackageLength)) { item.EcommercePackageLength = template.EcommercePackageLength; }
                if (string.IsNullOrEmpty(item.EcommercePackageWeight)) { item.EcommercePackageWeight = template.EcommercePackageWeight; }
                if (string.IsNullOrEmpty(item.EcommercePackageWidth)) { item.EcommercePackageWidth = template.EcommercePackageWidth; }
                if (string.IsNullOrEmpty(item.EcommercePageQty)) { item.EcommercePageQty = template.EcommercePageQty; }
                if (string.IsNullOrEmpty(item.EcommerceProductCategory)) { item.EcommerceProductCategory = template.EcommerceProductCategory; }
                if (string.IsNullOrEmpty(item.EcommerceProductDescription)) { item.EcommerceProductDescription = template.EcommerceProductDescription; }
                if (string.IsNullOrEmpty(item.EcommerceProductSubcategory)) { item.EcommerceProductSubcategory = template.EcommerceProductSubcategory; }
                if (string.IsNullOrEmpty(item.EcommerceManufacturerName)) { item.EcommerceManufacturerName = template.EcommerceManufacturerName; }
                if (string.IsNullOrEmpty(item.EcommerceMsrp)) { item.EcommerceMsrp = template.EcommerceMsrp; }
                if (string.IsNullOrEmpty(item.EcommerceSize)) { item.EcommerceSize = template.EcommerceSize; }
                if (string.IsNullOrEmpty(item.Gpc)) { item.Gpc = template.Gpc; }
                if (string.IsNullOrEmpty(item.Height)) { item.Height = template.Height; }
                if (string.IsNullOrEmpty(item.InnerpackHeight)) { item.InnerpackHeight = template.InnerpackHeight; }
                if (string.IsNullOrEmpty(item.InnerpackLength)) { item.InnerpackLength = template.InnerpackLength; }
                if (string.IsNullOrEmpty(item.InnerpackQuantity)) { item.InnerpackQuantity = template.InnerpackQuantity; }
                if (string.IsNullOrEmpty(item.InnerpackWidth)) { item.InnerpackWidth = template.InnerpackWidth; }
                if (string.IsNullOrEmpty(item.InnerpackWeight)) { item.InnerpackWeight = template.InnerpackWeight; }
                if (string.IsNullOrEmpty(item.ItemCategory)) { item.ItemCategory = template.ItemCategory; }
                if (string.IsNullOrEmpty(item.ItemFamily)) { item.ItemFamily = template.ItemFamily; }
                if (string.IsNullOrEmpty(item.ItemGroup)) { item.ItemGroup = template.ItemGroup; }
                if (string.IsNullOrEmpty(item.Length)) { item.Length = template.Length; }
                if (string.IsNullOrEmpty(item.ListPriceCad)) { item.ListPriceCad = template.ListPriceCad; }
                if (string.IsNullOrEmpty(item.ListPriceUsd)) { item.ListPriceUsd = template.ListPriceUsd; }
                if (string.IsNullOrEmpty(item.ListPriceMxn)) { item.ListPriceMxn = template.ListPriceMxn; }
                if (string.IsNullOrEmpty(item.MetaDescription)) { item.MetaDescription = template.MetaDescription; }
                if (string.IsNullOrEmpty(item.MfgSource)) { item.MfgSource = template.MfgSource; }
                if (string.IsNullOrEmpty(item.Msrp)) { item.Msrp = template.Msrp; }
                if (string.IsNullOrEmpty(item.MsrpCad)) { item.MsrpCad = template.MsrpCad; }
                if (string.IsNullOrEmpty(item.MsrpMxn)) { item.MsrpMxn = template.MsrpMxn; }
                if (string.IsNullOrEmpty(item.PrintOnDemand)) { item.PrintOnDemand = template.PrintOnDemand; }
                if (string.IsNullOrEmpty(item.ProductFormat)) { item.ProductFormat = template.ProductFormat; }
                if (string.IsNullOrEmpty(item.ProductGroup)) { item.ProductGroup = template.ProductGroup; }
                if (string.IsNullOrEmpty(item.ProductLine)) { item.ProductLine = template.ProductLine; }
                if (string.IsNullOrEmpty(item.ProductQty)) { item.ProductQty = template.ProductQty; }
                if (string.IsNullOrEmpty(item.PricingGroup)) { item.PricingGroup = template.PricingGroup; }
                if (string.IsNullOrEmpty(item.PsStatus)) { item.PsStatus = template.PsStatus; }
                if (string.IsNullOrEmpty(item.SatCode)) { item.SatCode = template.SatCode; }
                if (string.IsNullOrEmpty(item.Size)) { item.Size = template.Size; }
                if (string.IsNullOrEmpty(item.StandardCost)) { item.StandardCost = template.DefaultActualCostUsd; }
                if (string.IsNullOrEmpty(item.TariffCode)) { item.TariffCode = template.TariffCode; }
                if (string.IsNullOrEmpty(item.Udex)) { item.Udex = template.Udex; }
                if (string.IsNullOrEmpty(item.Warranty)) { item.Warranty = template.Warranty; }
                if (string.IsNullOrEmpty(item.WebsitePrice)) { item.WebsitePrice = template.WebsitePrice; }
                if (string.IsNullOrEmpty(item.Weight)) { item.Weight = template.Weight; }
                if (string.IsNullOrEmpty(item.Width)) { item.Width = template.Width; }
            }
            return item;
        }

        /// <summary>
        ///     Loads in a list of templates, completes them with existing data and saves the result
        /// </summary>
        /// <param name="fileName"></param>
        public List<string> UploadTemplates(string fileName)
        {
            List<ItemObject> templates = LoadTemplate(fileName, "Update");
            List<ItemObject> newTemplates = new List<ItemObject>();
            List<string> errors = new List<string>();

            foreach (ItemObject template in templates)
            {
                if (GlobalData.TemplateNames.Contains(template.TemplateId))
                {
                    newTemplates.Add(CompleteTemplate(template));
                    foreach (ItemError error in ValidateAllTemplate(template, "Update"))
                    {
                        errors.Add(error.ReturnErrorMessage());
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(template.TemplateId))
                    {
                        string errorMessage = "The spreadsheet has a missing Template Id.";
                        if (!errors.Contains(errorMessage))
                        {
                            errors.Add("The spreadsheet has a missing Template Id.");
                        }
                    }
                    else
                    {
                        string errorMessage = "The spreadsheet contains a template Id that Odin does not recognize : " + template.TemplateId;
                        if (!errors.Contains(errorMessage))
                        {
                            errors.Add(errorMessage);
                        }                        
                    }
                }
            }
            if (errors.Count() == 0)
            {
                foreach (ItemObject template in newTemplates)
                {
                    UpdateTemplate(template, "Add");
                }
            }
            return errors;
        }

        #region Insert Methods

        /// <summary>
        ///     Adds a new web category
        /// </summary>
        /// <param name="category"></param>
        public void InsertCategory(string category)
        {
            ItemRepository.InsertCategory(category);
        }
        
        /// <summary>
        ///     Save items to web & combine categories
        /// </summary>
        /// <param name="items"></param>
        public void InsertItem(ItemObject item, int count)
        {
            if (item.PrintOnDemand == "")
            {
                item.PrintOnDemand = "N";
            }
            
            ItemRepository.InsertAll(item, count);
        }

        /// <summary>
        ///     Inserts a value into Odin_Web_License
        /// </summary>
        /// <param name="license"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public void InsertLicense(string license, string property = "")
        {
            ItemRepository.InsertLicense(license, property);
        }

        /// <summary>
        ///     Insert info into to PS_MARKETPLACE_CUSTOMER_PRODUCTS
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="title"></param>
        public void InsertMarketplaceCustomerProducts(string itemId, string title, string customer)
        {
            ItemRepository.InsertMarketplaceCustomerProducts(itemId, title, customer);
        }

        /// <summary>
        ///     Inserts a meta description value into Odin_MetaDescription
        /// </summary>
        /// <param name="value"></param>
        public void InsertMetaDescription(string value)
        {
            ItemRepository.InsertMetaDescription(value);
        }

        /// <summary>
        ///     Insert a template into the db
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public void InsertTemplate(ItemObject template)
        {
            TemplateRepository.InsertTemplate(template);
            GlobalData.TemplateNames = TemplateRepository.RetrieveTemplateNameList();
        }

        /// <summary>
        ///     Inserts a new territory value into Odin_Web_Territories
        /// </summary>
        /// <param name="territory"></param>
        /// <returns></returns>
        public void InsertTerritory(string territory)
        {
            ItemRepository.InsertTerritory(territory);
        }

        /// <summary>
        ///     Updates a web category field
        /// </summary>
        /// <param name="category"></param>
        /// <param name="oldCategory"></param>
        public void UpdateCategory(string category, string oldCategory)
        {
            ItemRepository.UpdateCategory(category, oldCategory);
        }

        /// <summary>
        ///     Updates the newdate field with today's date
        /// </summary>
        /// <param name="value"></param>
        public void UpdateNewDate(string value)
        {
            ItemRepository.UpdateNewDate(value);
        }

        #endregion // Insert Methods

        #region Removal Methods

        /// <summary>
        ///     Removes category from Odin_NewWebCategories
        /// </summary>
        /// <param name="category"></param>
        public void RemoveCategory(string category)
        {
            ItemRepository.RemoveCategory(category);
        }

        /// <summary>
        ///     Removes a License and all associted propertiesfrom Odin_Web_License
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void RemoveLicense(string value)
        {
            ItemRepository.RemoveLicense(value);
        }

        /// <summary>
        ///     Removes a Meta Description from Odin_MetaDescription
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void RemoveMetaDescription(string value)
        {
            ItemRepository.RemoveMetaDescription(value);
        }

        /// <summary>
        ///     Removes a property from Odin_Web_License
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void RemoveProperty(string property)
        {
            string[] x = property.Split(':');
            ItemRepository.RemoveProperty(x[1].Trim(), x[0].Trim());
        }

        /// <summary>
        ///     Check string for special characters. Special chars have no place in the peoplesoft database.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string RemoveSpecialChar(string value)
        {
            value.Replace("™", "");
            value.Replace("®", "");
            value.Replace(",", "");
            value.Replace("©", "");
            return value;
        }

        /// <summary>
        ///     Remove a selected template from the db
        /// </summary>
        /// <param name="templateName"></param>
        /// <returns></returns>
        public void RemoveTemplate(string templateName)
        {
            TemplateRepository.RemoveTemplate(templateName);
        }

        /// <summary>
        ///     Removes a territory from Odin_Web_Territories
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void RemoveTerritory(string value)
        {
            ItemRepository.RemoveTerritory(value);
        }

        #endregion // Removal Methods

        #region Retrieval Methods
        
        /// <summary>
        ///     Returns a list of all item ids with an active status of 'A' for the given customer
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveActiveEcommerceItemIds(string startDate, string endDate, string productGroup, string customerName)
        {
            return ItemRepository.RetrieveActiveEcommerceItemIds(startDate, endDate, productGroup, customerName);
        }
                 
        /// <summary>
        ///     Return the list price of item. If item has product qty multiply list price
        /// </summary>
        /// <param name="item"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public string RetrieveB2bPrice(string listPrice, string prodQty)
        {
            string value = listPrice;

            if ((!string.IsNullOrEmpty(prodQty)) && (!string.IsNullOrEmpty(listPrice)))
            {
                if (DbUtil.IsNumber(prodQty))
                {
                    decimal qty = Convert.ToDecimal(prodQty);
                    if (qty > 1)
                    {
                        decimal i = Convert.ToDecimal(listPrice);
                        decimal newValue = qty * i;
                        value = Convert.ToString(newValue);
                    }
                }
            }
            return value;
        }

        /// <summary>
        ///     Retrieves a list of search items from the database
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public List<SearchItem> RetrieveFindItemSearchResults(string searchValue, bool includeDisabled)
        {
            List<SearchItem> SearchItemResults = ItemRepository.RetrieveItemSearchResults(searchValue, includeDisabled);
            foreach (SearchItem item in SearchItemResults)
            {
                if (item.ItemId == searchValue.ToUpper())
                {
                    List<SearchItem> OverrideList = new List<SearchItem>() { item };
                    return OverrideList;
                }
            }

            return SearchItemResults;
        }

        /// <summary>
        ///     Returns the full country name of the given country code
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string RetrieveFullCountryOfOrigin(string value)
        {
            if(GlobalData.CountriesOfOrigin.ContainsKey(value))
            {
                return GlobalData.CountriesOfOrigin[value].Trim();
            }
            else
            {
                return "";
            }
        }
        
        /// <summary>
        ///     Retrieves a list of local image paths for the given item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public List<KeyValuePair<string, int>> RetrieveImagePaths(string itemId)
        {
            List<KeyValuePair<string, int>> results = ItemRepository.RetrieveImagePaths(itemId);
            
            return results;
        }

        /// <summary>
        ///     Select an item and all it's fields from the database
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public ItemObject RetrieveItem(string itemId, int count)
        {
            ItemObject item = ItemRepository.RetrieveItem(itemId, count);
            // item.RelatedProducts = RetrieveRelatedProducts(item.ItemId);
            item.SetFlagDefaults();
            return item;
        }

        /// <summary>
        ///     Retrieves a List of all Item Category Names from global data
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveItemCategoryNames()
        {
            List<string> result = GlobalData.ItemCategories.Keys.ToList();
            result.Sort();
            return result;
        }

        /// <summary>
        ///     Removes prefixes and suffixes from itemId.
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>ItemId core</returns>
        public string RetrieveItemIdCore(string itemId)
        {
            
            string idCore = itemId;
            foreach (string x in GlobalData.ItemTypeExtensionsList.OrderBy(x => x.Length))
            {
                if(itemId.Contains(x))
                {
                    idCore = idCore.Replace(x,"");
                }
            }
            return idCore;
        }

        /// <summary>
        ///     Retrieves a list of most recent ItemRecords from ODIN_ITEM_UPDATE_RECORDS
        /// </summary>
        /// <returns></returns>
        public List<ItemRecord> RetrieveItemRecords()
        {
            return ItemRepository.RetrieveItemRecords();
        }

        /// <summary>
        ///     Return all update records for the given itemId
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public List<ItemObject> RetrieveItemUpdateRecords(string itemId)
        {
            return ItemRepository.RetrieveItemUpdateRecords(itemId);
        }

        /// <summary>
        ///     Retrieves a list of all license : Property values
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public List<string> RetrieveLicensePropertyList()
        {
            return ItemRepository.RetrieveLicensePropertyList();
        }

        /// <summary>
        ///     Increments the given date by 4 months (if no date provided incremented from current date)
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string RetrieveNewToDate(string i)
        {
            string input = i;
            if (string.IsNullOrEmpty(input))
            {
                DateTime thisDay = DateTime.Now;
                input = thisDay.ToString("d");
            }
            string result = string.Empty;
            string[] num = input.Split('/');
            int month = Int32.Parse(num[0]) + 4;
            int year = Int32.Parse(num[2]);
            if (month > 12)
            {
                month = month - 12;
                year = year + 1;
            }
            result = Convert.ToString(month) + "/1/" + Convert.ToString(year);
            // result += " 0:00";

            return result;
        }

        /// <summary>
        ///     Retrieve Product Format fields from Global Data 
        ///     that corespond with the product line. 
        /// </summary>
        /// <returns>List of product formats</returns>
        public List<string> RetrieveProductFormats(string productLine)
        {
            List<string> productFormats = new List<string>();
            foreach(ProductFormat x in GlobalData.ProductFormats)
            {
                if (!GlobalData.ProductFormatExclusionOptions.Contains(x.Format))
                {
                    if (productLine == x.Line)
                    {
                        if (!productFormats.Contains(x.Format))
                        {
                            productFormats.Add(x.Format);
                        }
                    }
                }
            }
            productFormats.Sort();
            return productFormats;
        }

        /// <summary>
        ///     Retrive all distinct product format values
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveProductFormatsAll()
        {
            List<string> result = GlobalData.ProductFormats.Select(c => c.Format).Distinct().ToList();
            result.Sort();
            return result;
        }

        /// <summary>
        ///     Retrieve Product Line fields from the Global Data 
        ///     that corespond to the give product group
        /// </summary>
        /// <returns>List of product lines</returns>
        public List<string> RetrieveProductLines(string productGroup)
        {
            List<string> productLines = new List<string>();
            foreach(KeyValuePair<string,string> x in GlobalData.ProductLines)
            {
                if(x.Value == productGroup)
                {
                    productLines.Add(x.Key);
                }
            }
            productLines.Sort();
            return productLines;
        }

        /// <summary>
        ///     Retrive all distinct product line values
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveProductLinesAll()
        {
            List<string> result = new List<string>();
            foreach (KeyValuePair<string, string> x in GlobalData.ProductLines)
            {
                if (!result.Contains(x.Key))
                {
                    result.Add(x.Key);
                }
            }
            result.Sort();
            return result;
        }        

        /// <summary>
        ///     Retrieve Property fields from the Global Data. With the key of given license. Empty License returns all properties.
        /// </summary>
        /// <returns>List of properties</returns>
        public List<string> RetrievePropertyList(string license)
        {
            List<string> properties = new List<string>
            {
                ""
            };
            if (!string.IsNullOrEmpty(license))
            {
                foreach (KeyValuePair<string, string> x in GlobalData.Properties)
                {
                    if (x.Key == license)
                    {
                        properties.Add(x.Value);
                    }
                }
            }            
            else
            {                
                foreach (KeyValuePair<string, string> x in GlobalData.Properties)
                {
                    properties.Add(x.Key+":"+x.Value);
                }                
            }
            
            properties.Sort();
            return properties;
        }

        /// <summary>
        ///     Retrieves existing related item ids for the given itemId. ItemIds with 
        ///     the same numerical value, but with different prefixes / suffixes are 
        ///     considered 'related'. 
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns> List of itemIds </returns>
        public List<string> RetrieveRelatedProductIds(string itemId)
        {
            string idCore = RetrieveItemIdCore(itemId);
            List<string> relatedProducts = new List<string>();

            foreach(KeyValuePair<string,string> x in GlobalData.ItemTypeExtensions)
            {
                string y = (x.Key+idCore+x.Value).Trim();
                if(GlobalData.ItemIds.Contains(y)||GlobalData.LocalItemIds.Contains(y))
                {
                    relatedProducts.Add(y);
                }
            }

            return relatedProducts;
        }

        /// <summary>
        ///     Retrieves a List of SearchItems based on their Item Category
        /// </summary>
        /// <param name="itemCategory">Item Category search parameter</param>
        /// <param name="includeDisabled">if true include items in destroyed status</param>
        /// <returns>List of Search Items</returns>
        public List<SearchItem> RetreiveSearchItemByItemCategory(string itemCategory, bool includeDisabled = false)
        {
            return ItemRepository.RetreiveSearchItemByItemCategory(itemCategory, includeDisabled);
        }

        /// <summary>
        ///     Retrieves a List of SearchItems based on their Item Group
        /// </summary>
        /// <param name="itemGroup">Item Group search parameter</param>
        /// <param name="includeDisabled">if true include items in destroyed status</param>
        /// <returns>List of Search Items</returns>
        public List<SearchItem> RetreiveSearchItemByItemGroup(string itemGroup, bool includeDisabled = false)
        {
            return ItemRepository.RetreiveSearchItemByItemGroup(itemGroup, includeDisabled);
        }

        /// <summary>
        ///     Retrieves a List of SearchItems based on their Product Format
        /// </summary>
        /// <param name="productFormat">Product Format search parameter</param>
        /// <param name="includeDisabled">if true include items in destroyed status</param>
        /// <returns>List of Search Items</returns>
        public List<SearchItem> RetreiveSearchItemByProductFormat(string productFormat, bool includeDisabled = false)
        {
            return ItemRepository.RetreiveSearchItemByProductFormat(productFormat, includeDisabled);
        }

        /// <summary>
        ///     Retrieves a List of SearchItems based on their Product Group
        /// </summary>
        /// <param name="productGroup">Product Group search parameter</param>
        /// <param name="includeDisabled">if true include items in destroyed status</param>
        /// <returns>List of Search Items</returns>
        public List<SearchItem> RetreiveSearchItemByProductGroup(string productGroup, bool includeDisabled = false)
        {
            return ItemRepository.RetreiveSearchItemByProductGroup(productGroup, includeDisabled);
        }

        /// <summary>
        ///     Retrieves a List of SearchItems based on their Product Line
        /// </summary>
        /// <param name="productLine">Product Line search parameter</param>
        /// <param name="includeDisabled">if true include items in destroyed status</param>
        /// <returns>List of Search Items</returns>
        public List<SearchItem> RetreiveSearchItemByProductLine(string productLine, bool includeDisabled = false)
        {
            return ItemRepository.RetreiveSearchItemByProductLine(productLine, includeDisabled);
        }

        /// <summary>
        ///     Retrieves a List of SearchItems based on their Stats Code
        /// </summary>
        /// <param name="statsCode">Stats Code search parameter</param>
        /// <param name="includeDisabled">if true include items in destroyed status</param>
        /// <returns>List of Search Items</returns>
        public List<SearchItem> RetreiveSearchItemByStatsCode(string statsCode, bool includeDisabled = false)
        {
            return ItemRepository.RetreiveSearchItemByStatsCode(statsCode, includeDisabled);
        }

        /// <summary>
        ///     Retrieves a List of SearchItems based on their Tariff Code
        /// </summary>
        /// <param name="tariffCode">Tariff Code search parameter</param>
        /// <param name="includeDisabled">if true include items in destroyed status</param>
        /// <returns>List of Search Items</returns>
        public List<SearchItem> RetreiveSearchItemByTariffCode(string tariffCode, bool includeDisabled = false)
        {
            return ItemRepository.RetreiveSearchItemByTariffCode(tariffCode, includeDisabled);
        }

        /// <summary>
        ///     Retrieves a List of all stats codes values in global data
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveStatsCodes()
        {
            List<string> result = GlobalData.StatsCodes.Keys.ToList();
            result.Sort();
            return result;
        }

        /// <summary>
        ///     Retrieves a template from the db
        /// </summary>
        /// <returns></returns>
        public ItemObject RetrieveTemplate(string name)
        {            
            return TemplateRepository.RetrieveTemplate(name);
        }

        public List<string> RetrieveUpdateItemReportItemIds(DateTime toDate, DateTime fromDate)
        {
            return ItemRepository.RetrieveUpdateReportItemIds(toDate, fromDate);
        }

        #endregion // Retrieval Methods

        #region Update Methods

        /// <summary>
        ///     Updates the ON_SITE flag 
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public void UpdateOnSite(ItemObject item, string website)
        {
            // If update is for multiple sites
            if(website.Contains(","))
            {
                string[] x = website.Split(',');
                foreach (string y in x)
                {
                    ItemRepository.UpdateOnSite(item, y.Trim());
                }
            }
            else
            {
                ItemRepository.UpdateOnSite(item, website);
            }
        }
        
        /// <summary>
        ///     Updates an existing template
        /// </summary>
        /// <returns></returns>
        public void UpdateTemplate(ItemObject template, string status)
        {
            TemplateRepository.UpdateTemplate(template, status);
            GlobalData.TemplateNames = TemplateRepository.RetrieveTemplateNameList();
        }

        #endregion // Update Methods

        #region Validation Methods

        /// <summary>
        ///     Validates all fields for the given item
        /// </summary>
        /// <param name="var">ItemObj being validated</param>
        /// <returns></returns>
        public ObservableCollection<ItemError> ValidateItem(ItemObject var, bool isSubmit)
        {
            ObservableCollection<ItemError> ErrorList = new ObservableCollection<ItemError>();
            if (isSubmit)
            {
                if (var.SellOnTrends != "Y" && var.SellOnTrs != "Y")
                {
                    ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, " or Sell on Shop Trends must be set to Y before item can be submitted to the web.", "Sell On Trends"));
                    return ErrorList;
                }
            }
            string error = string.Empty;
            ItemError validationError = null;
            // Accounting Group //
            validationError = ValidateAccountingGroup(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // AltImage File 1 //
            validationError = ValidateImagePath(var, "2");
            if (validationError != null) { ErrorList.Add(validationError); }
            // AltImage File 2 //
            validationError = ValidateImagePath(var, "3");
            if (validationError != null) { ErrorList.Add(validationError); }
            // AltImage File 3 //
            validationError =ValidateImagePath(var, "4");
            if (validationError != null) { ErrorList.Add(validationError); }
            // AltImage File 4 //
            validationError =ValidateImagePath(var, "5");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Bill Of Materials //
            validationError =ValidateBillOfMaterials(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Casepack Height //
            validationError =ValidateCasepack(var, "Height");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Casepack Length //
            validationError =ValidateCasepack(var, "Length");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Casepack Weight //
            validationError =ValidateCasepack(var, "Weight");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Casepack Width //
            validationError =ValidateCasepack(var, "Width");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Casepack Qty //
            validationError =ValidateCasepackQty(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Category //
            validationError =ValidateCategory(var, "1");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Category 2 //
            validationError =ValidateCategory(var, "2");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Category 3 //
            validationError =ValidateCategory(var, "3");
            if (validationError != null) { ErrorList.Add(validationError); }
            // CasepackUpc //
            validationError =ValidatePackUpc(var, "Casepack");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Color //
            validationError =ValidateColor(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Copyright //
            validationError =ValidateCopyright(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Country Of Origin //
            validationError =ValidateCountryOfOrigin(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Cost Profile Group //
            validationError =ValidateCostProfileGroup(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // DefaultActualCostCad //
            validationError =ValidateDefaultActualCost(var, "CAD");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Default Actual Cost Usd //
            validationError =ValidateDefaultActualCost(var, "USD");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Description //
            validationError =ValidateDescription(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Direct Import //
            validationError =ValidateDirectImport(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // DTC Price //
            validationError = ValidateDtcPrice(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Duty //
            validationError =ValidateDuty(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ean //
            validationError =ValidateEan(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Asin //
            validationError =ValidateEcommerceAsin(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Bullet 1 //
            validationError =ValidateEcommerceBullet(var, "1");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Bullet 2 //
            validationError =ValidateEcommerceBullet(var, "2");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Bullet 3 //
            validationError =ValidateEcommerceBullet(var, "3");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Bullet 4 //
            validationError =ValidateEcommerceBullet(var, "4");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Bullet 5 //
            validationError =ValidateEcommerceBullet(var, "5");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Components //
            validationError =ValidateEcommerceComponents(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Cost //
            validationError =ValidateEcommerceCost(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce External Id Type //
            validationError =ValidateEcommerceExternalIdType(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce External Id //
            validationError =ValidateEcommerceExternalId(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Item Height //
            validationError =ValidateEcommerceItemDimension(var, "Height");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Item Length //
            validationError = ValidateEcommerceItemDimension(var, "Length");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Item Name //
            validationError =ValidateEcommerceItemName(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Item Type Keywords //
            validationError = ValidateEcommerceItemTypeKeywords(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Item Weight //
            validationError = ValidateEcommerceItemDimension(var, "Weight");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Item Width //
            validationError = ValidateEcommerceItemDimension(var, "Width");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Model Name //
            validationError =ValidateEcommerceModelName(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Package Height //
            validationError =ValidateEcommercePackageDimension(var, "Height");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Package Length //
            validationError = ValidateEcommercePackageDimension(var, "Length");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Package Weight //
            validationError = ValidateEcommercePackageDimension(var, "Weight");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Package Width //
            validationError =ValidateEcommercePackageDimension(var, "Width");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Page Qty //
            validationError =ValidateEcommercePageQty(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Parent Asin //
            validationError = ValidateEcommerceParentAsin(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Product Category //
            validationError =ValidateEcommerceProductCategory(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Product Description //
            validationError =ValidateEcommerceProductDescription(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Product Subcategory //
            validationError =ValidateEcommerceProductSubcategory(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Manufacturer Name //
            validationError =ValidateEcommerceManufacturerName(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Msrp //
            validationError =ValidateEcommerceMsrp(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Generic Keywords //
            validationError =ValidateEcommerceKeywords(var, "Generic");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Subject Keywords //
            validationError =ValidateEcommerceKeywords(var, "Subject");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Size //
            validationError =ValidateEcommerceSize(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ecommerce Upc //
            validationError =ValidateEcommerceUpc(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Genre1 //
            validationError = ValidateGenre(var,1);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Genre2 //
            validationError = ValidateGenre(var, 2);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Genre3 //
            validationError = ValidateGenre(var, 3);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Gpc //
            validationError =ValidateGpc(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Height //
            validationError =ValidateItemDimension(var, "Height");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Image Path //
            validationError =ValidateImagePath(var, "1");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Innerpack Height //
            validationError =ValidateInnerpack(var, "Height");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Innerpack Length //
            validationError =ValidateInnerpack(var, "Length");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Innerpack Quantity //
            validationError =ValidateInnerpackQuantity(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Innerpack Upc //
            validationError =ValidatePackUpc(var, "Innerpack");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Innerpack Weight //
            validationError =ValidateInnerpack(var,"Weight");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Innerpack Width //
            validationError =ValidateInnerpack(var, "Width");
            if (validationError != null) { ErrorList.Add(validationError); }
            // In Stock Date //
            validationError =ValidateInStockDate(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Isbn //
            validationError =ValidateIsbn(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Item Category //
            validationError =ValidateItemCategory(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Item Family //
            validationError =ValidateItemFamily(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Item Group //
            validationError =ValidateItemGroup(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Item Id //
            validationError =ValidateItemId(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Item Keywords //
            validationError =ValidateItemKeywords(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Language //
            validationError =ValidateLanguage(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Length //
            validationError =ValidateItemDimension(var, "Length");
            if (validationError != null) { ErrorList.Add(validationError); }
            // License //
            validationError =ValidateLicense(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // License Begin Date //
            validationError =ValidateLicenseBeginDate(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // List Price Cad //
            validationError =ValidateListPrice(var, "CAD");
            if (validationError != null) { ErrorList.Add(validationError); }
            // List Price Mxn //
            validationError =ValidateListPrice(var, "MXN");
            if (validationError != null) { ErrorList.Add(validationError); }
            // List Price Usd //
            validationError =ValidateListPrice(var, "USD");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Meta Description //
            validationError = ValidateMetaDescription(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Mfg Source //
            validationError =ValidateMfgSource(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // List Msrp //
            validationError =ValidateMsrp(var, "USD");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Msrp Cad //
            validationError =ValidateMsrp(var, "CAD");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Msrp Mxn //
            validationError =ValidateMsrp(var, "MXN");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Product Format //
            validationError =ValidateProductFormat(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Product Group //
            validationError =ValidateProductGroup(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Product Line //
            validationError =ValidateProductLine(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Pricing Group //
            validationError =ValidatePricingGroup(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Print On Demand //
            validationError =ValidatePrintOnDemand(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Product Id Translation //
            validationError =ValidateProductIdTranslation(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Property //
            validationError =ValidateProperty(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Ps Status //
            validationError =ValidatePsStatus(var);
            if (validationError != null) { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, "Error", "PS Status")); }
            // Sat Code //
            validationError =ValidateSatCode(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Sell On All Posters //
            validationError =ValidateSellOnValue(var, "All Posters");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Sell On Amazon //
            validationError =ValidateSellOnValue(var,"Amazon");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Sell On Amazon Seller Central //
            validationError =ValidateSellOnValue(var, "Amazon Seller Central");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Sell On Ecommerce //
            validationError =ValidateSellOnValue(var, "Ecommerce");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Sell On Fanatics //
            validationError =ValidateSellOnValue(var, "Fanatics");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Sell On Guitar Center //
            validationError =ValidateSellOnValue(var, "Guitar Center");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Sell On Hayneedle //
            validationError =ValidateSellOnValue(var, "Hayneedle");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Sell On Houzz //
            validationError = ValidateSellOnValue(var, "Houzz");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Sell On Target //
            validationError =ValidateSellOnValue(var, "Target");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Sell On Trends //
            validationError =ValidateSellOnValue(var, "Trends");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Sell On Shop Trends //
            validationError = ValidateSellOnValue(var, "Shop Trends");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Sell On Walmart //
            validationError =ValidateSellOnValue(var, "Walmart");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Sell On Wayfair //
            validationError =ValidateSellOnValue(var, "Wayfair");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Short Description //
            validationError =ValidateShortDescription(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Size //
            validationError =ValidateSize(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Standard Cost //
            validationError =ValidateStandardCost(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Stats Code //
            validationError =ValidateStatsCode(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Tariff Code //
            validationError =ValidateTariffCode(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Territory //
            validationError =ValidateTerritory(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Title //
            validationError =ValidateTitle(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Udex //
            validationError =ValidateUdex(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Upc //
            validationError =ValidateUpc(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Warranty //
            validationError =ValidateWarranty(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // WarrantyCheck //
            validationError =ValidateWarrantyCheck(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // WebsitePrice //
            validationError =ValidateWebsitePrice(var);
            if (validationError != null) { ErrorList.Add(validationError); }
            // Weight //
            validationError =ValidateItemDimension(var, "Weight");
            if (validationError != null) { ErrorList.Add(validationError); }
            // Width //
            validationError = ValidateItemDimension(var, "Width");
            if (validationError != null) { ErrorList.Add(validationError); }

            return ErrorList;
        }

        /// <summary>
        ///     Validates all fields of current template
        /// </summary>
        /// <param name="var"></param>
        public List<ItemError> ValidateAllTemplate(ItemObject var, string status)
        {
            var.Status = status;
            List<ItemError> ErrorMessages = new List<ItemError>();
            ItemError validationError = null;

            validationError = ValidateTemplateId(var,true);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateAccountingGroup(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateCasepack(var, "Height");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateCasepack(var, "Length");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateCasepack(var, "Weight");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateCasepack(var, "Width");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateCasepackQty(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateCountryOfOrigin(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateCostProfileGroup(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateDefaultActualCost(var, "CAD");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateDefaultActualCost(var, "USD");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateDuty(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateGpc(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateItemDimension(var,"Height");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateInnerpack(var, "Height");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateInnerpack(var, "Length");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateInnerpack(var, "Width");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateInnerpack(var, "Weight");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateInnerpackQuantity(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateItemCategory(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateItemFamily(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateItemGroup(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateItemDimension(var,"Length");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateListPrice(var, "CAD");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateListPrice(var, "MXN");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateListPrice(var, "USD");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateMfgSource(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateMsrp(var, "USD");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateMsrp(var, "CAD");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateMsrp(var, "MXN");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateProductFormat(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateProductGroup(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateProductLine(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidatePricingGroup(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateSatCode(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateTariffCode(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateUdex(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateWebsitePrice(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateItemDimension(var, "Weight");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateItemDimension(var, "Width");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateCategory(var, "1");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateCategory(var, "2");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateCategory(var, "3");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateCopyright(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateSize(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceBullet(var, "1");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceBullet(var, "2");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceBullet(var, "3");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceBullet(var, "4");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceBullet(var, "5");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceComponents(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceCost(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceExternalIdType(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceItemDimension(var, "Height");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceItemDimension(var, "Length");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceItemDimension(var, "Weight");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceItemDimension(var, "Height");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceItemTypeKeywords(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceModelName(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommercePackageDimension(var, "Height");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommercePackageDimension(var, "Length");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommercePackageDimension(var, "Weight");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommercePackageDimension(var, "Width");
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommercePageQty(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceParentAsin(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceProductCategory(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceProductDescription(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceProductSubcategory(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceManufacturerName(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceMsrp(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }
            validationError = ValidateEcommerceSize(var);
            if (validationError != null) { ErrorMessages.Add(validationError); }

            return ErrorMessages;
        }

        /// <summary>
        ///     Validates the Accounting Group field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public ItemError ValidateAccountingGroup(ItemObject var)
        {
            bool required = true;
            if(var.ProdType==2)
            {
                required = false;
            }
            if (!string.IsNullOrEmpty(var.AccountingGroup) || required)
            {
                if (string.IsNullOrEmpty(var.AccountingGroup) && required)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_Required,
                        "Accounting Group");
                }
                if (var.AccountingGroup.Length > 10)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "10 characters.",
                        "Accounting Group");
                }
                if (!GlobalData.AccountingGroups.Contains(var.AccountingGroup))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NoMatch,
                        "Accounting Group");                 
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the Bill of Materials Field field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="billOfMaterials"></param>
        /// <param name="currentIds"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public ItemError ValidateBillOfMaterials(ItemObject var)
        {
            List<string> BomIdList = new List<string>();
            bool existingValue = false;
            
            if (var.BillOfMaterials.Count() == 0)
            {
                return null;
            }
            else
            {
                if (var.ProductIdTranslation.Count()>0)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Field must be left empty if Product Id Translation has a value.",
                        "Bill of Materials");
                }
            }
            if(GlobalData.BillofMaterials.Where(p => p.ParentId == var.ItemId).Count()>0)
            {
                existingValue = true;
            }
            foreach (ChildElement billOfMaterial in var.BillOfMaterials)
            {
                if (var.Status == "Update" && existingValue)
                {
                    if(!CheckBillofMaterial(billOfMaterial.ParentId.Trim(), billOfMaterial.ItemId.Trim()))
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Field cannot be updated through Odin. The Bill of materials field does not match the values currently saved for this item. Once established Bill of Materials can only be updated through peoplesoft.",
                            "Bill of Materials");
                    }
                }
                if (!string.IsNullOrEmpty(billOfMaterial.ItemId))
                {
                    if ((!GlobalData.LocalItemIds.Contains(billOfMaterial.ItemId.Trim())) && (!GlobalData.ItemIds.Contains(billOfMaterial.ItemId.Trim())))
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Field contains an id that does not exist: " + billOfMaterial.ItemId + ". These items must exist in the database before they can be used as a bill of material.",
                            "Bill of Materials");
                    }
                }
                if (BomIdList.Contains(billOfMaterial.ItemId.Trim()))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Field can not contain multiple occurances of the same item. ["+ billOfMaterial.ItemId.Trim() + "]. Please remove duplicates.",
                        "Bill of Materials");
                }
                else
                {
                    BomIdList.Add(billOfMaterial.ItemId.Trim());
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the Casepack field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <param name="type">Casepack type: Height, Length, Weight, Width</param>
        /// <returns></returns>
        public ItemError ValidateCasepack(ItemObject var, string type)
        {
            string value1 = string.Empty;
            string value2 = string.Empty;
            string value3 = string.Empty;
            string value4 = string.Empty;
            switch (type)
            {
                case "Height":
                    value1 = var.CasepackHeight;
                    value2 = var.CasepackLength;
                    value3 = var.CasepackWeight;
                    value4 = var.CasepackWidth;
                    break;
                case "Length":
                    value1 = var.CasepackLength;
                    value2 = var.CasepackHeight;
                    value3 = var.CasepackWeight;
                    value4 = var.CasepackWidth;
                    break;
                case "Weight":
                    value1 = var.CasepackWeight;
                    value2 = var.CasepackLength;
                    value3 = var.CasepackHeight;
                    value4 = var.CasepackWidth;
                    break;
                case "Width":
                    value1 = var.CasepackWidth;
                    value2 = var.CasepackLength;
                    value3 = var.CasepackWeight;
                    value4 = var.CasepackHeight;
                    break;
                default:
                    throw new ArgumentNullException("Validate Casepack unknown type " + type);
            }

            if (string.IsNullOrEmpty(value1))
            {
                if ((string.IsNullOrEmpty(value2)) && (string.IsNullOrEmpty(value3)) && (string.IsNullOrEmpty(value4)))
                {
                    return null;
                }
                else
                {
                    if (var.ProdType != 2)
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Value cannot be left empty if the other casepack dimensional fields have values(height, weight, width, length).",
                            "Casepack " + type);
                    }
                }
            }
            else
            {
                if (value1.Length > 7)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "7 characters.",
                        "Casepack " + type);
                }
                if (!DbUtil.IsNumber(value1))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "must be a numeric value.",
                        "Casepack " + type);
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates Casepack Qty field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateCasepackQty(ItemObject var)
        {
            if (string.IsNullOrEmpty(var.CasepackQty))
            {
                return null;
            }
            if (var.CasepackQty.Contains('.'))
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    "Value cannot be a decimal.",
                    "Casepack Quantity");
            }
            if (var.CasepackQty.Length > 7)
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_LengthMax + "7 characters.",
                    "Casepack Quantity");
            }
            if (!DbUtil.IsNumber(var.CasepackQty))
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_NonNumeric,
                    "Casepack Quantity");
            }
            return null;
        }

        /// <summary>
        ///     Vaidates Web Cateogry field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="value">Item Obejct</param>
        /// <param name="categoryNumber">Category Number as string</param>
        /// <returns></returns>
        public ItemError ValidateCategory(ItemObject var, string categoryNumber)
        {
            string value = string.Empty;
            bool webRequired = false;
            string fieldName = string.Empty;
            switch (categoryNumber)
            {
                case "1":
                    value = var.Category;
                    webRequired = true;
                    fieldName = "Category";
                    break;
                case "2":
                    value = var.Category2;
                    fieldName = "Category 2";
                    break;
                case "3":
                    value = var.Category3;
                    fieldName = "Category 3";
                    break;
                default:
                    throw new ArgumentNullException("ValidateCategory unknown categoryNumber: " + categoryNumber);
            }
            if (!string.IsNullOrEmpty(value))
            {
                if (!GlobalData.ReturnWebCategoryListValues().Contains(value))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NoMatch,
                        fieldName);
                }
            }

            if (var.HasWeb && webRequired)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredWeb,
                        fieldName);
                }
            }
            return null;
        }
        
        /// <summary>
        ///     Validates the color field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Obejct</param>
        /// <returns></returns>
        public ItemError ValidateColor(ItemObject var)
        {
            if (var.Color.Length > 10)
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_LengthMax + "10 characters.",
                    "Color");
            }
            if (!DbUtil.ContainsOnlyAZ09(var.Color))
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    "Value conatins invalid charachters. (Color can only use charachters A-Z and 0-9)",
                    "Color");
            }
            return null;
        }
        
        /// <summary>
        ///     Validate Copyright field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="hasWeb"></param>
        /// <returns></returns>
        public ItemError ValidateCopyright(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.Copyright))
            {
                if (var.Copyright.Length > 1000)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "1000 characters.",
                        "Copyright");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the Country of Origin field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateCountryOfOrigin(ItemObject var)
        {
            bool required = true;
            if(var.ProdType == 2){ required = false; }

            if (!string.IsNullOrEmpty(var.CountryOfOrigin) || required)
            {
                if (string.IsNullOrEmpty(var.CountryOfOrigin) && required)
                {
                    if (!CheckGreaterThanZero(var.ListPriceUsd))
                    {
                        return null;
                    }
                    else
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            OdinServices.Properties.Resources.Error_Required,
                            "Country Of Origin");
                    }
                }
                if (var.CountryOfOrigin.Length > 3)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "3 characters.",
                        "Country Of Origin");

                }
                if (!DbUtil.ContainsOnlyAZ(var.CountryOfOrigin))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value conatins invalid charachters. (Country of Origin can only use charachters A-Z)",
                        "Country Of Origin");
                }
                if (!GlobalData.ReturnCountryofOriginCodes().Contains(var.CountryOfOrigin))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NoMatch,
                        "Country Of Origin");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the Cost Profile Group field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateCostProfileGroup(ItemObject var)
        {
            bool template = false;
            if (var.ProdType == 2) { template = true; }
            if (!string.IsNullOrEmpty(var.CostProfileGroup) || !template)
            {
                if (string.IsNullOrEmpty(var.CostProfileGroup) && !template)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_Required,
                        "Cost Profile Group");
                }
                if (!GlobalData.CostProfileGroups.Contains(var.CostProfileGroup))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NoMatch,
                        "Cost Profile Group");
                }
                if (!template)
                {
                    if (((var.MfgSource == "1") && (var.CostProfileGroup == "MFG_ACTUAL_FIFO")) || ((var.MfgSource == "2") && (var.CostProfileGroup == "ACTUAL_FIFO")))
                    {
                        return null;
                    }
                    else
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Value does not align with the MFG Sorce value.",
                            "Cost Profile Group");
                    }
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates Default Actual Cost field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <param name="currency">Default Actual Cost Type: USD, CAD, MXN</param>
        /// <returns></returns>
        public ItemError ValidateDefaultActualCost(ItemObject var, string currency)
        {
            string value = string.Empty;
            switch (currency)
            {
                case "USD":
                    value = var.ListPriceUsd;
                    break;
                case "CAD":
                    value = var.ListPriceCad;
                    break;
                case "MXN":
                    value = var.ListPriceMxn;
                    break;
                default:
                    throw new ArgumentNullException("ValidateDefaultActualCost unknown currency " + currency);
            }
            bool required = true;
            if(var.ProdType == 2) { required = false; }

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_Required,
                        "Default Actual Cost " + currency);
                }
                if (value.Length > 9)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "9 characters.",
                        "Default Actual Cost " + currency);
                }
                if (!DbUtil.IsNumber(value))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NonNumeric,
                        "Default Actual Cost " + currency);
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates Description field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateDescription(ItemObject var)
        {
            bool required = true;
            string value = DbUtil.ReplaceCharacters(var.Description);
            if (var.ProdType == 2) { required = false; }

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_Required,
                        "Description");
                }
                if (value.Contains((char)13))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value cannot contain carriage returns.",
                        "Description");
                }
                if (value.Length > 60)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "60 characters.",
                        "Description");
                }
                if (CheckSpecialChar(value))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_SpecialChars,
                        "Description");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the Direct Import Field
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateDirectImport(ItemObject var)
        {
            if (var.DirectImport == "" || var.DirectImport.ToUpper() == "Y" || var.DirectImport.ToUpper() == "N")
            {
                return null;
            }
            else
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_YorN,
                    "Direct Import");
            }
        }

        /// <summary>
        ///     Validates the Dtc Price field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateDtcPrice(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.DtcPrice))
            {
                if (var.DtcPrice.Length > 9)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "9 characters.",
                        "Dtc Price");
                }
                if (!DbUtil.IsNumber(var.DtcPrice))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NonNumeric,
                        "Dtc Price");
                }
                else
                {
                    if (var.SellOnTrs == "Y")
                    {
                        if (Convert.ToDouble(var.DtcPrice) < 0.01)
                        {
                            return new ItemError(
                                var.ItemId,
                                var.ItemRow,
                                "Value must be more that 0.00",
                                "Dtc Price");
                        }
                    }
                }
            }
            else
            {
                if (var.SellOnTrs == "Y")
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Required if Sell on Shop Trends is set to 'Y'.",
                        "Dtc Price");                    
                }
                if (var.ProductLine == "Poster Frame" && var.ItemId.Substring(0, 3) == "POD")
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Required if product line = Poster Frame and item Id starts with 'POD'.",
                        "Dtc Price");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the Duty field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public ItemError ValidateDuty(ItemObject var)
        {
            if (var.Duty.Count() > 30)
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_LengthMax + "30 characters.",
                    "Duty");
            }
            return null;
        }

        /// <summary>
        ///     Validates the EAN field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEan(ItemObject var) 
        {            
            if (string.IsNullOrEmpty(var.Ean))
            {
                if (var.ListPriceUsd == "" || !CheckGreaterThanZero(var.ListPriceUsd))
                {
                    return null;
                }
                if (var.ProductLine == "Direct Medical Mail")
                {
                    return null;
                }
                if (string.IsNullOrEmpty(var.Upc))
                {
                    if (GlobalData.UpcProductFormatExceptions.Contains(var.ProductFormat))
                    {
                        return null;
                    }
                    else {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Value is required when a UPC is not provided.",
                            "EAN");
                    }
                }
            }
            else
            {
                if (CheckSpecialChar(var.Ean))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_SpecialChars,
                        "EAN");
                }
                if (var.Ean.Length > 30)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "30 characters.",
                        "EAN");
                }
                if (var.Ean.Contains("-"))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value cannot contain dashes (-).",
                        "EAN");
                }
            }
            return null;
        }

        /// <summary>
        ///  Validates the EcommerceAsin field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommerceAsin(ItemObject var)
        {
            if (string.IsNullOrEmpty(var.EcommerceAsin))
            {
                return null;
            }
            if (var.EcommerceAsin.Count() > 10)
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_LengthMax + "10 characters.",
                    "Ecommerce Asin");
            }
            if(GlobalData.Asins.ContainsKey(var.EcommerceAsin))
            {
                if(GlobalData.Asins[var.EcommerceAsin] != var.ItemId)
                {
                    if(GlobalData.Asins[var.EcommerceAsin].Contains(','))
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Multiple items contain this ASIN: " + GlobalData.Asins[var.EcommerceAsin] + ". Please fix duplicates before saving.",
                            "Ecommerce Asin");
                    }
                    else
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Another item already contains this ASIN: "+ GlobalData.Asins[var.EcommerceAsin],
                            "Ecommerce Asin");
                    }
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the EcommerceBullet Validation field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommerceBullet(ItemObject var, string bulletNumber)
        {
            string value = string.Empty;
            bool ecomRequired = false;
            switch (bulletNumber)
            {
                case "1":
                    value = var.EcommerceBullet1;
                    ecomRequired = true;
                    break;
                case "2":
                    value = var.EcommerceBullet2;
                    ecomRequired = true;
                    break;
                case "3":
                    value = var.EcommerceBullet3;
                    ecomRequired = true;
                    break;
                case "4":
                    value = var.EcommerceBullet4;
                    break;
                case "5":
                    value = var.EcommerceBullet5;
                    break;
                default:
                    throw new ArgumentNullException("ValidateEcommerceBullet unknown bulletNumber: " + bulletNumber);
            }
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 254)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "254 characters.",
                        "Ecommerce Bullet " + bulletNumber);
                }
                if (!DbUtil.CheckMinimum(value, 10))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMin + "10 characters.",
                        "Ecommerce Bullet " + bulletNumber);
                }
            }
            if (var.HasEcommerce && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value) && ecomRequired && var.ProdType != 2)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredAmazon,
                        "Ecommerce Bullet " + bulletNumber);
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the EcommerceComponents field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommerceComponents(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.EcommerceComponents))
            {
                if (var.EcommerceComponents.Length > 100)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "100 characters.",
                        "Ecommerce Components");
                }
            }
            if (var.HasEcommerce && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(var.EcommerceComponents) )
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredAmazon,
                        "Ecommerce Components");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the EcommerceCost field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommerceCost(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.EcommerceCost))
            {
                if (var.EcommerceCost.Length > 9)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "9 characters.",
                        "Ecommerce Cost");
                }
                if (!DbUtil.IsNumber(var.EcommerceCost))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NonNumeric,
                        "Ecommerce Cost");
                }
            }
            if (var.HasEcommerce && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(var.EcommerceCost))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredAmazon,
                        "Ecommerce Cost");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the EcommerceExternalId field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommerceExternalId(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.EcommerceExternalId))
            {
                if (var.EcommerceExternalId.Length > 20)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "20 characters.",
                        "Ecommerce External Id");
                }
                if (GlobalData.ExternalIdTypes.Contains(var.EcommerceExternalIdType))
                {
                    switch (var.EcommerceExternalIdType)
                    {
                        case "UPC":
                            if (CheckSpecialChar(var.EcommerceExternalId))
                            {
                                return new ItemError(
                                    var.ItemId,
                                    var.ItemRow,
                                    OdinServices.Properties.Resources.Error_SpecialChars,
                                    "Ecommerce External Id");
                            }
                            if (!DbUtil.IsNumber(var.EcommerceExternalId))
                            {
                                return new ItemError(
                                    var.ItemId,
                                    var.ItemRow,
                                    OdinServices.Properties.Resources.Error_NonNumeric,
                                    "Ecommerce External Id");
                            }
                            if ((var.EcommerceExternalId.Length != 8) && (var.EcommerceExternalId.Length != 12))
                            {
                                return new ItemError(
                                    var.ItemId,
                                    var.ItemRow,
                                    "Value has invalid length. UPC values can only have a length of 8 or 12 characters.",
                                    "Ecommerce External Id");
                            }
                            return null;
                        case "UPC (12-digits)":
                            if (CheckSpecialChar(var.EcommerceExternalId))
                            {
                                return new ItemError(
                                    var.ItemId,
                                    var.ItemRow,
                                    OdinServices.Properties.Resources.Error_SpecialChars,
                                    "Ecommerce External Id");
                            }
                            if (!DbUtil.IsNumber(var.EcommerceExternalId))
                            {
                                return new ItemError(
                                    var.ItemId,
                                    var.ItemRow,
                                    OdinServices.Properties.Resources.Error_NonNumeric,
                                    "Ecommerce External Id");
                            }
                            if ((var.EcommerceExternalId.Length != 8) && (var.EcommerceExternalId.Length != 12))
                            {
                                return new ItemError(
                                    var.ItemId,
                                    var.ItemRow,
                                    "Value has invalid length. UPC values can only have a length of 8 or 12 characters.",
                                    "Ecommerce External Id");
                            }
                            return null;
                        case "ISBN":
                            return ValidateIsbn(var);
                        case "EAN":
                            return ValidateEan(var);
                    }
                }
                else
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Invalid coresponding ExternalIdType. Odin does not recognize " + var.EcommerceExternalIdType + " as an valid External Id Type.",
                        "Ecommerce External Id");
                }
            }
            if (var.HasEcommerce && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(var.EcommerceExternalId))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredAmazon,
                        "Ecommerce External Id");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the EcommerceExternalIdType field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommerceExternalIdType(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.EcommerceExternalIdType))
            {
                if (!GlobalData.ExternalIdTypes.Contains(var.EcommerceExternalIdType))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value has an invalid value. (Accepted Values are 'UPC (12-digits)', 'ISBN', 'EAN' or 'GTIN'.",
                        "Ecommerce External Id Type");
                }
                return null;
            }
            if (var.HasEcommerce && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(var.EcommerceExternalIdType))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredAmazon,
                        "Ecommerce External Id Type");
                }
            }
            return null;
        }

        /// <summary>
        ///     EcommerceItemHeight field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommerceItemDimension(ItemObject var, string type)
        {
            string value = string.Empty;
            switch(type)
            {
                case "Height":
                    value = var.EcommerceItemHeight;
                    break;
                case "Length":
                    value = var.EcommerceItemLength;
                    break;
                case "Weight":
                    value = var.EcommerceItemWeight;
                    break;
                case "Width":
                    value = var.EcommerceItemWidth;
                    break;
                default:
                    throw new ArgumentNullException("ValidateEcommerceItemDimension unknown type " + type);
            }
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 9)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "9 characters.",
                        "Ecommerce " + type);
                }
                if (!DbUtil.IsNumber(value))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NonNumeric,
                        "Ecommerce " + type);
                }
            }
            if (var.HasEcommerce && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredAmazon,
                        "Ecommerce " + type);
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates Item Type Keywords field. Returns an ItemError or null if no error exists.
        /// </summary>
        public ItemError ValidateEcommerceItemTypeKeywords(ItemObject var)
        {
            string value = string.Empty;
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 500)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "500 characters.",
                        "Ecommerce Item Type Keywords");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the EcommerceItemName field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommerceItemName(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.EcommerceItemName))
            {
                if (!DbUtil.CheckMaximum(var.EcommerceItemName, 200))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "200 characters.",
                        "Ecommerce Item Name");
                }
            }
            if (var.HasEcommerce && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(var.EcommerceItemName))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredAmazon,
                        "Ecommerce Item Name");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the EcommerceManufacturerName field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommerceManufacturerName(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.EcommerceManufacturerName))
            {
                if (var.EcommerceManufacturerName.Length > 100)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "100  characters.",
                        "Ecommerce Manufacturer Name");
                }
            }
            if (var.HasEcommerce && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(var.EcommerceManufacturerName))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredAmazon,
                        "Ecommerce Manufacturer Name");
                }
            }
            return null;
        }

        /// <summary>
        ///     EcommerceModelName field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommerceModelName(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.EcommerceModelName))
            {
                if (var.EcommerceModelName.Length > 50)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "50 characters.",
                        "Ecommerce Model Name");
                }
                return null;
            }
            if (var.HasEcommerce && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(var.EcommerceModelName))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredAmazon,
                        "Ecommerce Model Name");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the EcommerceMsrp field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommerceMsrp(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.EcommerceMsrp))
            {
                if (var.EcommerceMsrp.Length > 9)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "9 characters.",
                        "Ecommerce Msrp");
                }
                if (!DbUtil.IsNumber(var.EcommerceMsrp))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NonNumeric,
                        "Ecommerce Msrp");
                }
            }
            if (var.HasEcommerce && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(var.EcommerceMsrp))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredAmazon,
                        "Ecommerce Msrp");
                }
                if (!CheckGreaterThanZero(var.EcommerceMsrp))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value must contain a non-zero value.",
                        "Ecommerce Msrp");
                }
            }
            return null;
        }

        /// <summary>
        ///      Validates the EcommercePackageWidth field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommercePackageDimension(ItemObject var, string type)
        {
            string value = string.Empty;
            switch (type)
            {
                case "Height":
                    value = var.EcommercePackageHeight;
                    break;
                case "Length":
                    value = var.EcommercePackageLength;
                    break;
                case "Weight":
                    value = var.EcommercePackageWeight;
                    break;
                case "Width":
                    value = var.EcommercePackageWidth;
                    break;
                default:
                    throw new ArgumentNullException("ValidateEcommercePackageDimension unknown type " + type);
            }
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 9)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "9 characters.",
                        "Ecommerce Package " + type);
                }
                if (!DbUtil.IsNumber(value))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NonNumeric,
                        "Ecommerce Package " + type);
                }
            }
            if (var.HasEcommerce && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredAmazon,
                        "Ecommerce Package " + type);
                }
            }
            return null;
        }

        /// <summary>
        ///      Validates the EcommercePageQty field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommercePageQty(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.EcommercePageQty))
            {
                if (var.EcommercePageQty.Length > 4)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                         OdinServices.Properties.Resources.Error_LengthMax + "4 characters.",
                        "Ecommerce Page Qty");
                }
                if (var.EcommercePageQty.Contains("."))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value can not be a decimal",
                        "Ecommerce Page Qty");
                }
                if (!DbUtil.IsNumber(var.EcommercePageQty))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NonNumeric,
                        "Ecommerce Page Qty");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the EcommerceParentAsin field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ItemError ValidateEcommerceParentAsin(ItemObject var)
        {
            if (string.IsNullOrEmpty(var.EcommerceParentAsin))
            {
                return null;
            }
            if (var.EcommerceParentAsin.Count() > 10)
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_LengthMax + "10 characters.",
                    "Ecommerce Parent Asin");
            }
            return null;
        }

        /// <summary>
        ///     Validates the EcommerceProductCategory field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommerceProductCategory(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.EcommerceProductCategory))
            {
                if (var.EcommerceProductCategory.Length > 50)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "50 characters.",
                        "Ecommerce Product Category");
                }
                return null;
            }
            if (var.HasEcommerce && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(var.EcommerceProductCategory))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredAmazon,
                        "Ecommerce Product Category");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the EcommerceProductDescription field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommerceProductDescription(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.EcommerceProductDescription))
            {
                if (!DbUtil.CheckMinimum(var.EcommerceProductDescription, 100))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                         OdinServices.Properties.Resources.Error_LengthMin + "100 characters.",
                        "Ecommerce Product Description");
                }
                
                if (var.EcommerceProductDescription.Length > 8000)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "8000 characters.",
                        "Ecommerce Product Description");
                }
            }
            if (var.HasEcommerce && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(var.EcommerceProductDescription))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredAmazon,
                        "Ecommerce Product Description");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the EcommerceProductSubcategory field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommerceProductSubcategory(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.EcommerceProductSubcategory))
            {
                if (var.EcommerceProductSubcategory.Length > 50)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "50 characters.",
                        "Ecommerce Product Subcategory");
                }
            }
            if (var.HasEcommerce && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(var.EcommerceProductSubcategory))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredAmazon,
                        "Ecommerce Product Subcategory");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the EcommerceGenericKeywords field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommerceKeywords(ItemObject var, string type)
        {
            string value = string.Empty;
            bool ecommerceRequired = false;
            switch (type)
            {
                case "Generic":
                    value = var.EcommerceGenericKeywords;
                    break;
                case "Subject":
                    value = var.EcommerceSubjectKeywords;
                    ecommerceRequired = true;
                    break;
                default:
                    throw new ArgumentNullException("ValidateEcommerceKeywords unknown type " + type);
            }
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 385)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "385 characters.",
                        "Ecommerce " + type + " Keywords");
                }
            }
            if (var.HasEcommerce && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value) && ecommerceRequired)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredAmazon,
                        "Ecommerce " + type + " Keywords");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the EcommerceSize field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommerceSize(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.EcommerceSize))
            {
                if (var.EcommerceSize.Length > 254)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "254 characters.",
                        "Ecommerce Size");
                }
            }
            if (var.HasEcommerce && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(var.EcommerceSize))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredAmazon,
                        "Ecommerce Size");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the Ecommerce Upc field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateEcommerceUpc(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.EcommerceUpc))
            {
                if (var.EcommerceUpc.Length != 12)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value has an invalid length. Ecommerce UPC can only have a length of 12 characters.",
                        "Ecommerce UPC");
                }
                if (CheckSpecialChar(var.EcommerceUpc))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_SpecialChars,
                        "Ecommerce UPC");
                }
                if (!DbUtil.IsNumber(var.EcommerceUpc))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NonNumeric,
                        "Ecommerce UPC");
                }
                if (var.EcommerceUpc == var.Upc)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Item's Upc and Ecommerce Upc cannot share the same value.",
                        "Ecommerce UPC");
                }
                List<string> matchId = CheckDuplicateUPCs(var.ItemId, var.EcommerceUpc, var.Status);
                if (matchId.Count > 0)
                {
                    string ids = "";
                    foreach (string id in matchId)
                    {
                        ids += id + ", ";
                    }
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value contains a duplicate ID. The following items already contain this upc or ecommerce upc: " + ids,
                        "Ecommerce UPC");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the genre field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <param name="type"></param>
        /// <returns>Error message or "" if value is valid</returns>
        public ItemError ValidateGenre(ItemObject var, int type)
        {
            
            string value = string.Empty;
            switch (type)
            {
                case 1:
                    value = var.Genre1;
                    break;
                case 2:
                    value = var.Genre2;
                    break;
                case 3:
                    value = var.Genre3;
                    break;
                default:
                    throw new ArgumentNullException("ValidateGenre unknown type " + type.ToString());
            }

            if (!string.IsNullOrEmpty(value))
            {
                if (!GlobalData.Genres.Contains(value))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NoMatch,
                        "Genre "+type.ToString());
                }
            }
            else
            {
                if(var.SellOnTrs == "Y" && type == 1)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value is required for products being sold on ShopTrends.",
                        "Genre " + type.ToString());
                }
            }            
            return null;            
        }

        /// <summary>
        ///     Validates the GPC field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateGpc(ItemObject var)
        {
            bool required = true;
            if (var.ProdType == 2) { required = false; }           
            if (!string.IsNullOrEmpty(var.Gpc) || required)
            {
                if ((string.IsNullOrEmpty(var.Gpc)) && required)
                {
                    if (!CheckGreaterThanZero(var.ListPriceUsd))
                    {
                        return null;
                    }
                    else
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            OdinServices.Properties.Resources.Error_Required,
                            "GPC");
                    }
                }
                if (var.Gpc.Length > 10)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "10 characters.",
                        "GPC");
                }
            }
            return null;
        }
        
        /// <summary>
        ///     Checks that all collumn headers are valid
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of incorrect collumn headers</returns>
        public List<string> ValidateHeaderCollumns(string fileName)
        {
            List<string> missingHeaders = new List<string>();
            WorksheetData worksheetData = this.WorkbookReader.ReadWorksheet(fileName);
            if (worksheetData.CellData.Count == 0)
            {
                MessageBox.Show("Odin could not read any data from provided spread sheet.");
            }
            foreach (string column in worksheetData.ColumnHeaders)
            {
                if (!string.IsNullOrEmpty(column))
                {
                    if (!ReturnHeaderValues().Contains(column.ToUpper().Replace(" ", "")))
                    {
                        missingHeaders.Add(column);
                    }
                }
            }
            return missingHeaders;
        }

        /// <summary>
        ///     Validates the item height field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <param name="type">Item Dimension type: Height, Length, Weight, Width</param>
        /// <returns>Error message or "" if value is valid</returns>
        public ItemError ValidateItemDimension(ItemObject var, string type)
        {
            string value = string.Empty;
            switch (type)
            {
                case "Height":
                    value = var.Height;
                    break;
                case "Length":
                    value = var.Length;
                    break;
                case "Weight":
                    value = var.Weight;
                    break;
                case "Width":
                    value = var.Width;
                    break;
                default:
                    throw new ArgumentNullException("ValidateItemDimension unknown type " + type);
            }
            bool required = true;
            if (var.ProdType == 2) { required = false; }

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_Required,
                        type);
                }
                if (value.Length > 8)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "8 characters.",
                        type);
                }
                if (!DbUtil.IsNumber(value))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NonNumeric,
                        type);
                }
                if (Convert.ToDouble(value) < 0.00001)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_0,
                        type);
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the Image Path fields. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <param name="imageNumber">Image number as string</param>
        public ItemError ValidateImagePath(ItemObject var, string imageNumber)
        {
            string value = string.Empty;
            bool required = false;
            switch (imageNumber)
            {
                case "1":
                    value = var.ImagePath.Trim();
                    required = true;
                    break;
                case "2":
                    value = var.AltImageFile1.Trim();
                    break;
                case "3":
                    value = var.AltImageFile2.Trim();
                    break;
                case "4":
                    value = var.AltImageFile3.Trim();
                    break;
                case "5":
                    value = var.AltImageFile4.Trim();
                    break;
                default:
                    throw new ArgumentNullException("ValidateImagePath unknown imageNumber " + imageNumber);
            }
            if (!string.IsNullOrEmpty(value))
            {
                string fileType = "";
                if (value.Length > 4)
                {
                    fileType = value.Substring(value.Length - 4).ToUpper();
                }
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Contains("'") || value.Contains("`"))
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Value cannot contain apostrophes.",
                            "Image Path " + imageNumber);
                    }
                    if (CheckSpecialChar(value))
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Value cannot contain special characters.",
                            "Image Path " + imageNumber);
                    }
                    if (fileType != ".JPG"
                            && fileType != ".PNG"
                            && fileType != ".TIF")
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Invalid file type. (Must be .jpg, .png, or .tif).",
                            "Image Path " + imageNumber);
                    }
                    if (!CheckFileExists(value, false))
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            @" could not find image with given filepath : " + value,
                            "Image Path " + imageNumber);
                    }
                    if (!CheckFileSize(value, false) && fileType != ".TIF")
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            @" Image file is too large (Max 20,000KB for .jpg & .png files)",
                            "Image Path " + imageNumber);
                    }
                    if (value.Length > 254)
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            OdinServices.Properties.Resources.Error_LengthMax + "254 characters.",
                            "Image Path " + imageNumber);
                    }
                }
                else
                {
                    if((var.SellOnTrends == "Y" || var.SellOnTrs == "Y") && required)
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            OdinServices.Properties.Resources.Error_RequiredWeb,
                            "Image Path " + imageNumber);
                    }
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates Innerpack fields. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <param name="var"> Innerpack type: Height, Length, Weight, Width</param>
        /// <returns></returns>
        public ItemError ValidateInnerpack(ItemObject var, string type)
        {
            string value1 = string.Empty;
            string value2 = string.Empty;
            string value3 = string.Empty;
            string value4 = string.Empty;
            switch (type)
            {
                case "Height":
                    value1 = var.InnerpackHeight;
                    value2 = var.InnerpackLength;
                    value3 = var.InnerpackWeight;
                    value4 = var.InnerpackWidth;
                    break;
                case "Length":
                    value1 = var.InnerpackLength;
                    value2 = var.InnerpackHeight;
                    value3 = var.InnerpackWeight;
                    value4 = var.InnerpackWidth;
                    break;
                case "Weight":
                    value1 = var.InnerpackWeight;
                    value2 = var.InnerpackLength;
                    value3 = var.InnerpackHeight;
                    value4 = var.InnerpackWidth;
                    break;
                case "Width":
                    value1 = var.InnerpackWidth;
                    value2 = var.InnerpackLength;
                    value3 = var.InnerpackWeight;
                    value4 = var.InnerpackHeight;
                    break;
                default:
                    throw new ArgumentNullException("ValidateInnerpack unknown type " + type);
            }
            bool template = false;
            if (var.ProdType == 2) { template = true; }
            if (string.IsNullOrEmpty(value1))
            {
                if ((string.IsNullOrEmpty(value2)) && (string.IsNullOrEmpty(value3)) && (string.IsNullOrEmpty(value4)))
                {
                    return null;
                }
                else
                {
                    if (!template)
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Field cannot be empty if this item has other innerpack dimension fields filled out (height, weight, width, length).",
                            "Innerpack " + type);                        
                    }
                }
            }
            if (value1.Length > 7)
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_LengthMax + "7 characters.",
                    "Innerpack " + type);
            }
            if (!DbUtil.IsNumber(value1))
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_NonNumeric,
                    "Innerpack " + type);
            }
            return null;
        }

        /// <summary>
        ///     Validates Innerpack Quantity field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateInnerpackQuantity(ItemObject var)
        {
            if (string.IsNullOrEmpty(var.InnerpackQuantity))
            {
                return null;
            }
            if (var.InnerpackQuantity.Contains('.'))
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    "Value cannot be a decimal.",
                    "Innerpack Quantity");
            }
            if (var.InnerpackQuantity.Length > 7)
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_LengthMax + "7 characters.",
                    "Innerpack Quantity");
            }
            if (!DbUtil.IsNumber(var.InnerpackQuantity))
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_NonNumeric,
                    "Innerpack Quantity");
            }
            return null;
        }

        /// <summary>
        ///     Validate in stock date field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateInStockDate(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.InStockDate))
            {
                if (var.InStockDate == "0000-00-00")
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value cannot be set to 0000-00-00.",
                        "License Begin Date");
                }
                if (!DateTime.TryParse(var.InStockDate, out DateTime temp))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value must contain a valid date",
                        "License Begin Date");
                }
                else if (Convert.ToDateTime(var.InStockDate).Date < Convert.ToDateTime("01/01/1753").Date)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value cannot be before 01/01/1753.",
                        "License Begin Date");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates ISBN field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateIsbn(ItemObject var)
        {
            if (!(string.IsNullOrEmpty(var.Isbn)))
            {
                if (CheckSpecialChar(var.Isbn))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_SpecialChars,
                        "ISBN");
                }
                if (var.Isbn.Length > 10)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "10 characters.",
                        "ISBN");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates Item Category field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateItemCategory(ItemObject var)
        {
            bool required = true;
            if (var.ProdType == 2) { required = false; }

            if (!string.IsNullOrEmpty(var.ItemCategory) || required)
            {
                if (string.IsNullOrEmpty(var.ItemCategory) && required)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_Required,
                        "Item Category");
                }
                if (var.ItemCategory.Length > 15)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "15 characters.",
                        "Item Category");
                }
                if (!GlobalData.ProductCategories.Contains(var.ItemCategory))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NoMatch,
                        "Item Category");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates Item Family field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateItemFamily(ItemObject var)
        {
            if (!(string.IsNullOrEmpty(var.ItemFamily)))
            {
                if (var.ItemFamily.Length > 18)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "18 characters.",
                        "Item Family");
                }
                if ((var.ItemFamily == "STICKER") || (var.ItemFamily == "") || (var.ItemFamily == "FLAT"))
                {
                    return null;
                }
                else
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value contains an invalid value. (Item Family must be set to 'STICKER', 'FLAT', or left empty)",
                        "Item Family"); 
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates Item Group field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateItemGroup(ItemObject var)
        {
            bool required = true;
            if (var.ProdType == 2) { required = false; }
            if (!string.IsNullOrEmpty(var.ItemGroup) || required)
            {
                if (string.IsNullOrEmpty(var.ItemGroup) && required)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_Required,
                        "Item Group");
                }
                if (var.ItemGroup.Length > 15)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "15 characters.",
                        "Item Group");
                }
                if (!GlobalData.ItemGroups.Contains(var.ItemGroup))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NoMatch,
                        "Item Group");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates Item Id field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateItemId(ItemObject var)
        {
            if (string.IsNullOrEmpty(var.ItemId))
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_Required,
                    "Item Id");
            }
            if ((var.Status == "Add") || (var.Status == ""))
            {
                if (var.ItemId.Length > 18)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "18 characters.",
                        "Item Id");
                }
                for (int i = 0; i < var.ItemId.Length; i++)
                {
                    if (!((var.ItemId[i] >= 'A' && var.ItemId[i] <= 'Z') || (var.ItemId[i] >= '0' && var.ItemId[i] <= '9') || var.ItemId[i] == '-'))
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Value contains invalid charachters. (Only use A-Z, 0-9 and -)",
                            "Item Id");
                    }
                }
                if (GlobalData.ItemIds.Contains(var.ItemId))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_AlreadyExists,
                        "Item Id");
                }
            }
            else if (var.Status == "Update")
            {
                if(!GlobalData.ItemIds.Contains(var.ItemId))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value does not exist in peoplesoft.",
                        "Item Id");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validate item Keywords field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateItemKeywords(ItemObject var)
        {
            if(!string.IsNullOrEmpty(var.ItemKeywords))
            {
                if (var.ItemKeywords.Length > 1000)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "1000 characters.",
                        "Item Keywords");
                }
            }
            if (var.HasWeb)
            {
                if (string.IsNullOrEmpty(var.ItemKeywords))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredWeb,
                        "Item Keywords");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates Language field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateLanguage(ItemObject var)
        {
            bool required = (var.ProdType == 2) ? false : true;
            string value = DbUtil.OrderLanguage(var.Language);
            if (!(string.IsNullOrEmpty(value)))
            {
                string[] x = value.Split('/');
                foreach (string y in x)
                {
                    if (!GlobalData.Languages.Contains(y))
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                             y + OdinServices.Properties.Resources.Error_NoMatch,
                            "Language");
                    }
                }
                return null;
            }
            else
            {
                if (!CheckGreaterThanZero(var.ListPriceUsd))
                {
                    return null;
                }
                if (required)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_Required,
                        "Language");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validate License field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateLicense(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.License))
            {
                if (var.License.Length > 255)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "255 characters.",
                        "License");
                }
                if (!GlobalData.Licenses.Contains(var.License))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NoMatch,
                        "License");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates license begin date field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateLicenseBeginDate(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.LicenseBeginDate))
            {
                if (var.LicenseBeginDate == "0000-00-00")
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value cannot be set to 0000-00-00.",
                        "License Begin Date");
                }
                if (!DateTime.TryParse(var.LicenseBeginDate, out DateTime temp))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value must contain a valid date",
                        "License Begin Date");
                }
                else if (Convert.ToDateTime(var.LicenseBeginDate).Date < Convert.ToDateTime("01/01/1753").Date)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value cannot be before 01/01/1753.",
                        "License Begin Date");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates MFG Source field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateMfgSource(ItemObject var)
        {
            bool required = (var.ProdType == 2) ? false : true;

            if (!(string.IsNullOrEmpty(var.MfgSource)))
            {
                if (var.MfgSource == "1")
                {
                    if (required)
                    {
                        if (var.CostProfileGroup == "MFG_ACTUAL_FIFO")
                        {
                            return null;
                        }
                        else
                        {
                            return new ItemError(
                                var.ItemId,
                                var.ItemRow,
                                "Value does not properly align with the Cost Profile Group value.",
                                "MFG Source");
                        }
                    }
                }
                else if (var.MfgSource == "2")
                {
                    if (required)
                    {
                        if (var.CostProfileGroup == "ACTUAL_FIFO")
                        {
                            return null;
                        }
                        else
                        {
                            return new ItemError(
                                var.ItemId,
                                var.ItemRow,
                                "Value does not properly align with the Cost Profile Group value.",
                                "MFG Source");
                        }
                    }
                }
                else
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value can only be either '1' or '2'",
                        "MFG Source");
                }
            }
            else
            {
                if (required)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_Required,
                        "MFG Source");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates MSRP value field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <param name="type">CAD, USD OR MXN</param>
        /// <returns></returns>
        public ItemError ValidateMsrp(ItemObject var, string type)
        {
            bool required = (var.ProdType == 2) ? false : true;
            string value = string.Empty;
            string name = string.Empty;
            switch (type)
            {
                case "CAD":
                    value = var.MsrpCad;
                    name = "MSRP CAD";
                    break;
                case "MXN":
                    value = var.MsrpMxn;
                    name = "MSRP MXN";
                    break;
                case "USD":
                    value = var.Msrp;
                    name = "MSRP";
                    break;
                default:
                    throw new ArgumentNullException("ValidateMsrp unknown type " + type);
            }

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (value.Length > 10)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "10 characters.",
                        name);
                }
                if (!DbUtil.IsNumber(value))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NonNumeric,
                        name);
                }
                if (string.IsNullOrEmpty(value))
                {
                    if (!CheckGreaterThanZero(var.ListPriceUsd))
                    {
                        return null;
                    }
                    if (type == "USD" && required)
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            OdinServices.Properties.Resources.Error_Required,
                            name);
                    }
                }
            }
            return null;
        }

        /// <summary>
        ///     Validate innerpack or casepack UPC field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="value">Item Object</param>
        /// <param name="packtype">Innerpack or Casepack</param>
        /// <returns></returns>
        public ItemError ValidatePackUpc(ItemObject var, string type)
        {
            string value = string.Empty;
            switch (type)
            {
                case "Casepack":
                    value = var.CasepackUpc;
                    break;
                case "Innerpack":
                    value = var.InnerpackUpc;
                    break;
                default:
                    throw new ArgumentNullException("ValidatePackUpc unknown type " + type);
            }
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            if (!DbUtil.IsNumber(value))
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_NonNumeric,
                    type + " UPC");
            }
            if ((value.Length != 8) && (value.Length != 12))
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    "Value has invalid length. " + type + " UPC must have a length of 8 or 12 characters.",
                    type + " UPC");
            }
            return null;
        }

        /// <summary>
        ///     Validate item List price field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <param name="type">USD, MXN OR CAD</param>
        /// <returns></returns>
        public ItemError ValidateListPrice(ItemObject var, string currency)
        {
            bool required = (var.ProdType == 2) ? false : true;
            string value = string.Empty;
            switch (currency)
            {
                case "USD":
                    value = var.ListPriceUsd;
                    break;
                case "CAD":
                    value = var.ListPriceCad;
                    break;
                case "MXN":
                    value = var.ListPriceMxn;
                    break;
                default:
                    throw new ArgumentNullException("ValidateListPrice unknown currency " + currency);
            }

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_Required,
                        "List Price " + currency);
                }
                if (value.Length > 9)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "9 characters.",
                        "List Price " + currency);
                }
                if (!DbUtil.IsNumber(value))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NonNumeric,
                        "List Price " + currency);
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates meta description field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateMetaDescription(ItemObject var)
        {
            if (!(string.IsNullOrEmpty(var.MetaDescription)))
            {
                if (!GlobalData.MetaDescriptions.Contains(var.MetaDescription) && !CheckForProductFormat(var.MetaDescription))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NoMatch,
                        "Meta Description");
                }
            }
            if (var.SellOnTrends=="Y" && string.IsNullOrEmpty(var.MetaDescription))
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_RequiredWeb,
                    "Meta Description");
            }
            return null;
        }

        /// <summary>
        ///     Validate product format field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateProductFormat(ItemObject var)
        {
            bool required = (var.ProdType == 2) ? false : true;

            if (!string.IsNullOrEmpty(var.ProductFormat))
            {
                if (var.ProductFormat.Trim().Length > 60)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "60 characters.",
                        "Product Format");
                }
                if (!CheckProductFormats(var.ProductGroup, var.ProductLine, var.ProductFormat))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value does not align with Product Line and Product Group values provided.",
                        "Product Format");
                }                
            }
            else
            {
                if (required)
                {
                    if (!string.IsNullOrEmpty(var.Upc))
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Value is a required value when a UPC value is provided.",
                            "Product Format");
                    }
                }            
            }
            return null;
        }

        /// <summary>
        ///     Validate product group field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateProductGroup(ItemObject var)
        {
            bool required = (var.ProdType == 2) ? false : true;

            if (!string.IsNullOrEmpty(var.ProductGroup) || required)
            {
                if (string.IsNullOrEmpty(var.ProductGroup) && required)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_Required,
                        "Product Group");
                }
                if (var.ProductGroup.Trim().Length > 30)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "30 characters.",
                        "Product Group");
                }
                if (!GlobalData.ProductGoups.Contains(var.ProductGroup))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NoMatch,
                        "Product Group");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the Product Id Translation Field field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <param name="currentIds">List of Ids currently in Odin</param>
        /// <returns></returns>
        public ItemError ValidateProductIdTranslation(ItemObject var)
        {
            if (var.ProductIdTranslation.Count() == 0)
            {
                if (var.ProductFormat.ToUpper() == "POD POSTER FRAME")
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value is required when the Product Format = 'POD POSTER FRAME'.",
                        "Product Id Translations");
                }
                else if (!string.IsNullOrEmpty(var.PricingGroup))
                {
                    if (var.PricingGroup.Substring(0, 3).ToUpper() == "FRP")
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Value is required when the Pricing Group = 'FRP'.",
                            "Product Id Translations");
                    }
                }
                return null;
            }
            else
            {
                if(var.BillOfMaterials.Count>0)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Field must be empty if Bill of Materials has a value.",
                        "Product Id Translations");
                }
                foreach (ChildElement productIdTranslation in var.ProductIdTranslation)
                {
                    if (!string.IsNullOrEmpty(productIdTranslation.ItemId))
                    {
                        if ((!GlobalData.LocalItemIds.Contains(productIdTranslation.ItemId.Trim())) && (!GlobalData.ItemIds.Contains(productIdTranslation.ItemId.Trim())))
                        {
                            return new ItemError(
                                var.ItemId,
                                var.ItemRow,
                                "Value contains an id that does not exist: " + productIdTranslation.ItemId + ".",
                                "Product Id Translations");
                        }
                    }
                    int count = 0;
                    string erroredId = string.Empty;
                    foreach (ChildElement productIdTranslation2 in var.ProductIdTranslation)
                    {
                        if ((productIdTranslation2.ItemId.Trim() == productIdTranslation.ItemId.Trim()))
                        {
                            count++;
                            if(count>1)
                            {
                                erroredId = productIdTranslation.ItemId;
                            }
                        }
                    }
                    if(count >1)
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Value can not contain multiple occurances of the same item: " + erroredId,
                            "Product Id Translations");
                    }
                }
                if (var.Status == "Update")
                {
                    if (!CheckExistingProductIdTranslationsMatch(var.ProductIdTranslation))
                    {
                        foreach (ChildElement productIdTranslation in var.ProductIdTranslation)
                        {
                            if (CheckItemHasOpenOrderLine(productIdTranslation.ItemId))
                            {
                                return new ItemError(
                                    var.ItemId,
                                    var.ItemRow,
                                    "Current open orders are preventing this change from taking place.",
                                    "Product Id Translations");
                            }
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        ///     Validate Product Line field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateProductLine(ItemObject var)
        {
            bool required = (var.ProdType == 2) ? false : true;

            if (!string.IsNullOrEmpty(var.ProductLine) || required)
            {
                if (var.ProductLine.Trim().Length > 30)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "30 characters.",
                        "Product Line");
                }

                if (!string.IsNullOrEmpty(var.ProductGroup))
                {
                    if (!CheckProductLines(var.ProductGroup, var.ProductLine))
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Value does not align with Product Group provided.",
                            "Product Line");
                    }
                }
                else
                {
                    if (required)
                    {
                        if (!string.IsNullOrEmpty(var.Upc))
                        {
                            return new ItemError(
                                var.ItemId,
                                var.ItemRow,
                                "Value is a required value when a UPC is provided",
                                "Product Line");
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        ///     Validate Product Quantity field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateProductQty(ItemObject var)
        {
            if (!(string.IsNullOrEmpty(var.ProductQty)))
            {
                if (!DbUtil.IsNumber(var.ProductQty))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NonNumeric,
                        "Product Quantity");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validate Property field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="value">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateProperty(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.Property))
            {
                if (!RetrievePropertyList(var.License).Contains(var.Property))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value does not align with the provided item license.",
                        "Property");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validate Pricing Group field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidatePricingGroup(ItemObject var)
        { 
            bool required = (var.ProdType == 2) ? false : true;

            if (!string.IsNullOrEmpty(var.PricingGroup) || required)
            {
                if (var.PricingGroup.Length > 30)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "30 characters.",
                        "Pricing Group");
                }
                if (string.IsNullOrEmpty(var.PricingGroup))
                {
                    if (!CheckGreaterThanZero(var.ListPriceUsd) && !CheckGreaterThanZero(var.ListPriceCad))
                    {
                        return null;
                    }
                    else
                    {
                        return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value cannot be left empty if there is a List Price USD value or a List Price CAD value provided for this item.",
                        "Pricing Group");
                    }
                }
                if (!GlobalData.PricingGroups.Contains(var.PricingGroup) && required)
                {
                    return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            OdinServices.Properties.Resources.Error_NoMatch,
                            "Pricing Group");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates Print on Demand field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="value">Item Object</param>
        /// <returns></returns>
        public ItemError ValidatePrintOnDemand(ItemObject var)
        {
            if (string.IsNullOrEmpty(var.PrintOnDemand))
            {
                return null;
            }
            else
            {
                if (var.PrintOnDemand != "Y" && var.PrintOnDemand != "N")
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_YorN,
                        "Print On Demand");
                }

            }
            return null;
        }

        /// <summary>
        ///     Validates Peoplesoft Status field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidatePsStatus(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.PsStatus))
            {
                if (!GlobalData.PsStatuses.Contains(var.PsStatus))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NoMatch,
                        "PS Status");
                }
            }
            else if (var.ProdType == 1)
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_Required,
                    "PS Status");
            }
            return null;
        }

        /// <summary>
        ///     Validates the SAT code value. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <returns></returns>
        public ItemError ValidateSatCode(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.SatCode))
            {
                if (var.SatCode.Length > 20)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "20 characters.",
                        "SAT Code");
                }
            }
            return null;
        }

        /// <summary>
        ///     Sell On field Validation field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="var">Item Object</param>
        /// <param name="type"> sell on type</param>
        public ItemError ValidateSellOnValue(ItemObject var, string type)
        {
            string value = string.Empty;
            bool checkItemId = false;
            switch (type)
            {
                case "All Posters":
                    value = var.SellOnAllPosters;
                    break;
                case "Amazon":
                    value = var.SellOnAmazon;
                    break;
                case "Amazon Seller Central":
                    value = var.SellOnAmazonSellerCentral;
                    break;
                case "Ecommerce":
                    value = var.SellOnEcommerce;
                    break;
                case "Fanatics":
                    value = var.SellOnFanatics;
                    break;
                case "Guitar Center":
                    value = var.SellOnGuitarCenter;
                    break;
                case "Hayneedle":
                    value = var.SellOnHayneedle;
                    break;
                case "Houzz":
                    value = var.SellOnHouzz;
                    break;
                case "Target":
                    value = var.SellOnTarget;
                    break;
                case "Trends":
                    value = var.SellOnTrends;
                    break;
                case "Shop Trends":
                    value = var.SellOnTrs;
                    checkItemId = true;
                    break;
                case "Walmart":
                    value = var.SellOnWalmart;
                    break;
                case "Wayfair":
                    value = var.SellOnWayfair;
                    break;
                default:
                    throw new ArgumentNullException("ValidateSellOnValue unknown type " + type);
            }

            if (string.IsNullOrEmpty(value))
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_Required,
                    "Sell On " + type);
            }
            if ((value != "Y") && (value != "N"))
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_YorN,
                    "Sell On " + type);
            }
            if(checkItemId)
            {
                if(var.ItemId.Contains("-"))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Item's being sold on Shop Trends cannot contain a '-' in the itemId.",
                        "Sell On " + type);
                }
            }
            return null;
        }

        /// <summary>
        ///     Validate Short Description field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// 
        public ItemError ValidateShortDescription(ItemObject var)
        {
            return null;
        }

        /// <summary>
        ///     Validate Size field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ItemError ValidateSize(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.Size))
            {
                if (CheckSpecialChar(var.Size))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_SpecialChars,
                        "Size");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates Standard Cost field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ItemError ValidateStandardCost(ItemObject var)
        {
            bool required = (var.ProdType == 2) ? false : true;

            if (!string.IsNullOrEmpty(var.StandardCost) || required)
            {
                if (string.IsNullOrEmpty(var.StandardCost) && required)
                {
                    return new ItemError(
                       var.ItemId,
                       var.ItemRow,
                       OdinServices.Properties.Resources.Error_Required,
                       "Standard Cost");
                }
                if (!DbUtil.IsNumber(var.StandardCost))
                {
                    return new ItemError(
                       var.ItemId,
                       var.ItemRow,
                       OdinServices.Properties.Resources.Error_NonNumeric,
                       "Standard Cost");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates Stats Code field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ItemError ValidateStatsCode(ItemObject var)
        {
            bool required = (var.ProdType == 2) ? false : true;

            if (!string.IsNullOrEmpty(var.StatsCode) || required)
            {
                if (string.IsNullOrEmpty(var.StatsCode) && required)
                {
                    if (!CheckGreaterThanZero(var.ListPriceUsd))
                    {
                        return null;
                    }
                    else
                    {
                        return new ItemError(
                           var.ItemId,
                           var.ItemRow,
                           OdinServices.Properties.Resources.Error_Required,
                           "Stats Code");
                    }
                }
                if (var.StatsCode.Length > 30)
                {
                    return new ItemError(
                       var.ItemId,
                       var.ItemRow,
                       OdinServices.Properties.Resources.Error_LengthMax + "30 characters.",
                       "Stats Code");
                }                
                if(!GlobalData.StatsCodes.ContainsKey(var.StatsCode))
                {
                    return new ItemError(
                       var.ItemId,
                       var.ItemRow,
                       "Value does not match any values set up in the database.",
                       "Stats Code");
                }                
            }
            return null;
        }

        /// <summary>
        ///     Validates Tariff Code field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ItemError ValidateTariffCode(ItemObject var)
        {
            bool required = (var.ProdType == 2) ? false : true;

            if (!string.IsNullOrEmpty(var.TariffCode) || required)
            {
                if (string.IsNullOrEmpty(var.TariffCode) && required)
                {
                    return new ItemError(
                       var.ItemId,
                       var.ItemRow,
                       OdinServices.Properties.Resources.Error_Required,
                       "Tariff Code");
                }
                if(!GlobalData.TariffCodes.Contains(var.TariffCode))
                {
                    return new ItemError(
                       var.ItemId,
                       var.ItemRow,
                       OdinServices.Properties.Resources.Error_NoMatch,
                       "Tariff Code");
                }
            }
            return null;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="var">item object</param>
        /// <param name="isTemplate">Is this an item field</param>
        /// <returns></returns>
        public ItemError ValidateTemplateId(ItemObject var, bool isTemplate)
        {
            if (string.IsNullOrEmpty(var.TemplateId))
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    "Value is empty. Please select a name before saving.",
                    "Template Id");
            }
            else
            {
                if (var.TemplateId.Length > 255)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "255 characters.",
                        "Template Id");
                }
                if (var.Status != "Update")
                {
                    if (GlobalData.TemplateNames.Contains(var.TemplateId))
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            var.TemplateId + " already exists. Please select a different name.",
                            "Template Id");
                    }
                }
                if (!isTemplate)
                {
                    if (!GlobalData.TemplateNames.Contains(var.TemplateId))
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Value does not match any existing Template Ids.",
                            "Template Id");
                    }
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the item territory field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ItemError ValidateTerritory(ItemObject var)
        {
            string value = DbUtil.OrderTerritory(var.Territory);
            bool required = (var.ProdType == 2) ? false : true;

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    if (!CheckGreaterThanZero(var.ListPriceUsd))
                    {
                        return null;
                    }
                    else
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            OdinServices.Properties.Resources.Error_Required,
                            "Territory");
                    }
                }
                string[] x = value.Split('/');
                foreach (string y in x)
                {
                    if (!GlobalData.Territories.Contains(y.Trim()))
                    {
                        return new ItemError(
                            var.ItemId,
                            var.ItemRow,
                            "Value " + y + " " + OdinServices.Properties.Resources.Error_NoMatch,
                            "Territory");
                    }
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates the Title field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ItemError ValidateTitle(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.Title))
            {
                if (var.Title.Length > 266)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "266 characters.",
                        "Title");
                }
            }
            if (var.HasWeb)
            {
                if (string.IsNullOrEmpty(var.Title))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredWeb,
                        "Title");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validates UDEX field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="group">item's Item Group</param>
        /// <param name="listPriceUS">USD List Price</param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public ItemError ValidateUdex(ItemObject var)
        {
            if (var.ProdType == 2)
            {
                return null;
            }
            if(string.IsNullOrEmpty(var.Udex))
            {
                return null;
            }
            if (!(string.IsNullOrEmpty(var.Udex)))
            {
                if (var.Udex.Length > 30)
                {
                    return new ItemError(
                       var.ItemId,
                       var.ItemRow,
                       OdinServices.Properties.Resources.Error_LengthMax + "30 characters.",
                       "Udex");
                }
                else return null;
            }
            return null;
        }

        /// <summary>
        ///     Validates UPC field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="listpriceUsd">USD List Price</param>
        /// <param name="prodFormat">Product Fromat</param>
        /// <param name="ean">EAN</param>
        /// <param name="productLine">Product Line</param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public ItemError ValidateUpc(ItemObject var)
        {
            if (string.IsNullOrEmpty(var.Upc))
            {
                if (string.IsNullOrEmpty(var.ListPriceUsd) || !string.IsNullOrEmpty(var.Ean))
                {
                    return null;
                }
                else if (var.ProductLine == "Direct Medical Mail")
                {
                    return null;
                }
                else if (!CheckGreaterThanZero(var.ListPriceUsd))
                {
                    return null;
                }
                else if (GlobalData.UpcProductFormatExceptions.Contains(var.ProductFormat.Trim()))
                {
                    return null;
                }
                else
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_Required + " (Required if the List Price USD is set to something other than 0 or if the Ean field is left blank.)",
                        "UPC");
                }
            }
            else
            {
                
                if(var.Upc == "000000000000")
                {
                    // Exception for items that do not get scanned (for comic-con / other events)
                    return null;
                }
                
                if (!DbUtil.IsNumber(var.Upc))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NonNumeric,
                        "UPC");
                }
                if ((var.Upc.Length != 8) && (var.Upc.Length != 12))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value has an invalid length. UPC value can only have a length of 8 or 12 characters.",
                        "UPC");
                }
                if (string.IsNullOrEmpty(var.ProductGroup) || string.IsNullOrEmpty(var.ProductLine) || string.IsNullOrEmpty(var.ProductFormat))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Product Line, Product Group & Product Format are required values when UPC is provided.",
                        "UPC");
                }
                if (var.Upc == var.EcommerceUpc)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Item's Upc and Ecommerce Upc cannot share the same value.",
                        "UPC");
                }
                List<string> matchId = CheckDuplicateUPCs(var.ItemId, var.Upc, var.Status);
                if (matchId.Count > 0)
                {
                    string ids = "";
                    foreach (string id in matchId)
                    {
                        ids += id + ", ";
                    }
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value contains a duplicate ID. The following items already contain this upc or ecommerce upc: " + ids,
                        "UPC");
                }
            }
            return null;
        }

        /// <summary>
        ///     Validate item warranty field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <returns></returns>
        public ItemError ValidateWarranty(ItemObject var)
        {
            if (var.Warranty.Length > 1000)
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_LengthMax + "1000 characters.",
                    "Warranty");
            }
            return null;
        }

        /// <summary>
        ///     Validate item warranty field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <returns></returns>
        public ItemError ValidateWarrantyCheck(ItemObject var)
        {
            if ((var.WarrantyCheck != "Y") && (var.WarrantyCheck != "N"))
            {
                return new ItemError(
                    var.ItemId,
                    var.ItemRow,
                    OdinServices.Properties.Resources.Error_YorN,
                    "Warranty Check");
            }
            return null;
        }

        /// <summary>
        ///     Validate item website price field. Returns ItemError or null if no error exists.
        /// </summary>
        /// <returns></returns>
        public ItemError ValidateWebsitePrice(ItemObject var)
        {
            if (!string.IsNullOrEmpty(var.WebsitePrice))
            {
                if (var.WebsitePrice.Length > 9)
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_LengthMax + "9 characters.",
                        "Website Price");
                }
                if (!DbUtil.IsNumber(var.WebsitePrice))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_NonNumeric,
                        "Website Price");
                }
            }
            if(var.HasWeb)
            {
                if (string.IsNullOrEmpty(var.WebsitePrice))
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        OdinServices.Properties.Resources.Error_RequiredWeb,
                        "Website Price");
                }
                if (!CheckGreaterThanZero(var.WebsitePrice) && var.ProductGroup != "Display")
                {
                    return new ItemError(
                        var.ItemId,
                        var.ItemRow,
                        "Value must contain a value greater than 0.",
                        "Website Price");
                }
            }
            return null;
        }
                
        #endregion // Validation Methods
        
        #endregion // Public Methods

        #region Constructor

        /// <summary>
        ///     Constructs the ItemService
        /// </summary>
        /// <param name="workbookReader"></param>
        /// <param name="itemRepository"></param>
        /// <param name="templateRepository"></param>
        public ItemService(IWorkbookReader workbookReader, IItemRepository itemRepository, ITemplateRepository templateRepository)
        {
            this.ItemRepository = itemRepository ?? throw new ArgumentNullException("itemRepository");
            this.TemplateRepository = templateRepository ?? throw new ArgumentNullException("templateRepository");
            this.WorkbookReader = workbookReader ?? throw new ArgumentNullException("workbookReader");
        }

        #endregion // Constructor

    }
}
