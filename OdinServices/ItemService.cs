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
            public static string Duty = "Duty";
            public static string Ean = "Ean";
            public static string Ecommerce_Asin = "Ecommerce Asin";
            public static string Ecommerce_Bullet1 = "Ecommerce Bullet 1";
            public static string Ecommerce_Bullet2 = "Ecommerce Bullet 2";
            public static string Ecommerce_Bullet3 = "Ecommerce Bullet 3";
            public static string Ecommerce_Bullet4 = "Ecommerce Bullet 4";
            public static string Ecommerce_Bullet5 = "Ecommerce Bullet 5";
            public static string Ecommerce_Components = "Ecommerce Components";
            public static string Ecommerce_Cost = "Ecommerce Cost";
            public static string Ecommerce_CountryofOrigin = "Ecommerce Country of Origin";
            public static string Ecommerce_ExternalId = "Ecommerce External ID";
            public static string Ecommerce_ExternalIdType = "Ecommerce External ID Type";
            public static string Ecommerce_GenericKeywords = "Ecommerce Generic Keywords";
            public static string Ecommerce_ImagePath1 = "Ecommerce Image Path 1";
            public static string Ecommerce_ImagePath2 = "Ecommerce Image Path 2";
            public static string Ecommerce_ImagePath3 = "Ecommerce Image Path 3";
            public static string Ecommerce_ImagePath4 = "Ecommerce Image Path 4";
            public static string Ecommerce_ImagePath5 = "Ecommerce Image Path 5";
            public static string Ecommerce_ItemHeight = "Ecommerce Item Height";
            public static string Ecommerce_ItemLength = "Ecommerce Item Length";
            public static string Ecommerce_ItemName = "Ecommerce Item Name";
            public static string Ecommerce_ItemWeight = "Ecommerce Item Weight";
            public static string Ecommerce_ItemWidth = "Ecommerce Item Width";
            public static string Ecommerce_ModelName = "Ecommerce Model Name";
            public static string Ecommerce_PackageHeight = "Ecommerce Package Height";
            public static string Ecommerce_PackageLength = "Ecommerce Package Length";
            public static string Ecommerce_PackageWeight = "Ecommerce Package Weight";
            public static string Ecommerce_PackageWidth = "Ecommerce Package Width";
            public static string Ecommerce_PageQty = "Ecommerce Page Qty";
            public static string Ecommerce_ProductCategory = "Ecommerce Product Category";
            public static string Ecommerce_ProductDescription = "Ecommerce Product Description";
            public static string Ecommerce_ProductSubcategory = "Ecommerce Product Subcategory";
            public static string Ecommerce_ManufacturerName = "Ecommerce Manufacturer Name";
            public static string Ecommerce_Msrp = "Ecommerce Msrp";
            public static string Ecommerce_SearchTerms = "Ecommerce Search Terms";
            public static string Ecommerce_SubjectKeywords = "Ecommerce Subject Keywords";
            public static string Ecommerce_Size = "Ecommerce Size";
            public static string Ecommerce_Upc = "Ecommerce UPC";
            public static string GenericKeywords = "Generic Keywords";
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
            public static string SellOnTarget = "Sell On Target";
            public static string SellOnTrends = "Sell On Trends";
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
            public static string Udex = "Udex";
            public static string Upc = "Upc";
            public static string WebsitePrice = "Website Price";
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
                return false;
            }
            else
            {
                if (value == "testImagePath")
                {
                    return true;
                }
                else return false;
            }
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
            string[] suffixes = new string[] { "WM", "MI", "TG", "DI" };
            string slimItemId = itemId;
            List<string> existingIds = new List<string>();
            if (itemId.Length>2)
            {
                string idSuffix = itemId.Substring(itemId.Length - 2);
                if (suffixes.Contains(idSuffix))
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
            if (item.Ecommerce_Asin.Trim() == "[CLEAR]") { item.Ecommerce_Asin = ""; }
            if (item.Ecommerce_Bullet1.Trim() == "[CLEAR]") { item.Ecommerce_Bullet1 = ""; }
            if (item.Ecommerce_Bullet2.Trim() == "[CLEAR]") { item.Ecommerce_Bullet2 = ""; }
            if (item.Ecommerce_Bullet3.Trim() == "[CLEAR]") { item.Ecommerce_Bullet3 = ""; }
            if (item.Ecommerce_Bullet4.Trim() == "[CLEAR]") { item.Ecommerce_Bullet4 = ""; }
            if (item.Ecommerce_Bullet5.Trim() == "[CLEAR]") { item.Ecommerce_Bullet5 = ""; }
            if (item.Ecommerce_Components.Trim() == "[CLEAR]") { item.Ecommerce_Components = ""; }
            if (item.Ecommerce_Cost.Trim() == "[CLEAR]") { item.Ecommerce_Cost = ""; }
            if (item.Ecommerce_ExternalId.Trim() == "[CLEAR]") { item.Ecommerce_ExternalId = ""; }
            if (item.Ecommerce_ExternalIdType.Trim() == "[CLEAR]") { item.Ecommerce_ExternalIdType = ""; }
            if (item.Ecommerce_ImagePath1.Trim() == "[CLEAR]") { item.Ecommerce_ImagePath1 = ""; }
            if (item.Ecommerce_ImagePath2.Trim() == "[CLEAR]") { item.Ecommerce_ImagePath2 = ""; }
            if (item.Ecommerce_ImagePath3.Trim() == "[CLEAR]") { item.Ecommerce_ImagePath3 = ""; }
            if (item.Ecommerce_ImagePath4.Trim() == "[CLEAR]") { item.Ecommerce_ImagePath4 = ""; }
            if (item.Ecommerce_ImagePath5.Trim() == "[CLEAR]") { item.Ecommerce_ImagePath5 = ""; }
            if (item.Ecommerce_ItemHeight.Trim() == "[CLEAR]") { item.Ecommerce_ItemHeight = ""; }
            if (item.Ecommerce_ItemLength.Trim() == "[CLEAR]") { item.Ecommerce_ItemLength = ""; }
            if (item.Ecommerce_ItemName.Trim() == "[CLEAR]") { item.Ecommerce_ItemName = ""; }
            if (item.Ecommerce_ItemWeight.Trim() == "[CLEAR]") { item.Ecommerce_ItemWeight = ""; }
            if (item.Ecommerce_ItemWidth.Trim() == "[CLEAR]") { item.Ecommerce_ItemWidth = ""; }
            if (item.Ecommerce_ModelName.Trim() == "[CLEAR]") { item.Ecommerce_ModelName = ""; }
            if (item.Ecommerce_PackageHeight.Trim() == "[CLEAR]") { item.Ecommerce_PackageHeight = ""; }
            if (item.Ecommerce_PackageLength.Trim() == "[CLEAR]") { item.Ecommerce_PackageLength = ""; }
            if (item.Ecommerce_PackageWeight.Trim() == "[CLEAR]") { item.Ecommerce_PackageWeight = ""; }
            if (item.Ecommerce_PackageWidth.Trim() == "[CLEAR]") { item.Ecommerce_PackageWidth = ""; }
            if (item.Ecommerce_PageQty.Trim() == "[CLEAR]") { item.Ecommerce_PageQty = ""; }
            if (item.Ecommerce_ProductCategory.Trim() == "[CLEAR]") { item.Ecommerce_ProductCategory = ""; }
            if (item.Ecommerce_ProductDescription.Trim() == "[CLEAR]") { item.Ecommerce_ProductDescription = ""; }
            if (item.Ecommerce_ProductSubcategory.Trim() == "[CLEAR]") { item.Ecommerce_ProductSubcategory = ""; }
            if (item.Ecommerce_ManufacturerName.Trim() == "[CLEAR]") { item.Ecommerce_ManufacturerName = ""; }
            if (item.Ecommerce_Msrp.Trim() == "[CLEAR]") { item.Ecommerce_Msrp = ""; }
            if (item.Ecommerce_GenericKeywords.Trim() == "[CLEAR]") { item.Ecommerce_GenericKeywords = ""; }
            if (item.Ecommerce_Size.Trim() == "[CLEAR]") { item.Ecommerce_Size = ""; }
            if (item.Ecommerce_SubjectKeywords.Trim() == "[CLEAR]") { item.Ecommerce_SubjectKeywords = ""; }
            if (item.Ecommerce_Upc.Trim() == "[CLEAR]") { item.Ecommerce_Upc = ""; }
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

            if ((!string.IsNullOrEmpty(item.AccountingGroup)) && (item.AccountingGroup.Trim() != returnItem.AccountingGroup.Trim())) { returnItem.AccountingGroup = item.AccountingGroup; }
            if ((!string.IsNullOrEmpty(item.AltImageFile1)) && (item.AltImageFile1.Trim() != returnItem.AltImageFile1.Trim())) { returnItem.AltImageFile1 = item.AltImageFile1; }
            if ((!string.IsNullOrEmpty(item.AltImageFile2)) && (item.AltImageFile2.Trim() != returnItem.AltImageFile2.Trim())) { returnItem.AltImageFile2 = item.AltImageFile2; }
            if ((!string.IsNullOrEmpty(item.AltImageFile3)) && (item.AltImageFile3.Trim() != returnItem.AltImageFile3.Trim())) { returnItem.AltImageFile3 = item.AltImageFile3; }
            if ((!string.IsNullOrEmpty(item.AltImageFile4)) && (item.AltImageFile4.Trim() != returnItem.AltImageFile4.Trim())) { returnItem.AltImageFile4 = item.AltImageFile4; }
            if ((!string.IsNullOrEmpty(item.ReturnBillOfMaterials())) && (item.ReturnBillOfMaterials()).Trim() != returnItem.ReturnBillOfMaterials())
            {
                returnItem.BillOfMaterials = item.BillOfMaterials;
            }
            if ((!string.IsNullOrEmpty(item.Active.ToString())) && (item.Active != returnItem.Active)) { returnItem.Active = item.Active; }
            if ((!string.IsNullOrEmpty(item.CasepackHeight)) && (item.CasepackHeight.Trim() != returnItem.CasepackHeight.Trim())) { returnItem.CasepackHeight = item.CasepackHeight; }
            if ((!string.IsNullOrEmpty(item.CasepackLength)) && (item.CasepackLength.Trim() != returnItem.CasepackLength.Trim())) { returnItem.CasepackLength = item.CasepackLength; }
            if ((!string.IsNullOrEmpty(item.CasepackQty)) && (item.CasepackQty.Trim() != returnItem.CasepackQty.Trim())) { returnItem.CasepackQty = item.CasepackQty; }
            if ((!string.IsNullOrEmpty(item.CasepackUpc)) && (item.CasepackUpc.Trim() != returnItem.CasepackUpc.Trim())) { returnItem.CasepackUpc = item.CasepackUpc; }
            if ((!string.IsNullOrEmpty(item.CasepackWidth)) && (item.CasepackWidth.Trim() != returnItem.CasepackWidth.Trim())) { returnItem.CasepackWidth = item.CasepackWidth; }
            if ((!string.IsNullOrEmpty(item.CasepackWeight)) && (item.CasepackWeight.Trim() != returnItem.CasepackWeight.Trim())) { returnItem.CasepackWeight = item.CasepackWeight; }
            if ((!string.IsNullOrEmpty(item.Category)) && (item.Category.Trim() != returnItem.Category.Trim())) { returnItem.Category = item.Category; }
            if ((!string.IsNullOrEmpty(item.Category2)) && (item.Category2.Trim() != returnItem.Category2.Trim())) { returnItem.Category2 = item.Category2; }
            if ((!string.IsNullOrEmpty(item.Category3)) && (item.Category3.Trim() != returnItem.Category3.Trim())) { returnItem.Category3 = item.Category3; }
            if ((!string.IsNullOrEmpty(item.Color)) && (item.Color.Trim() != returnItem.Color.Trim())) { returnItem.Color = item.Color; }
            if ((!string.IsNullOrEmpty(item.Copyright)) && (item.Copyright.Trim() != returnItem.Copyright.Trim())) { returnItem.Copyright = item.Copyright; }
            if ((!string.IsNullOrEmpty(item.CountryOfOrigin)) && (item.CountryOfOrigin.Trim() != returnItem.CountryOfOrigin.Trim())) { returnItem.CountryOfOrigin = item.CountryOfOrigin; }
            if ((!string.IsNullOrEmpty(item.CostProfileGroup)) && (item.CostProfileGroup.Trim() != returnItem.CostProfileGroup.Trim())) { returnItem.CostProfileGroup = item.CostProfileGroup; }
            if ((!string.IsNullOrEmpty(item.DefaultActualCostCad)) && (item.DefaultActualCostCad.Trim() != returnItem.DefaultActualCostCad.Trim())) { returnItem.DefaultActualCostCad = item.DefaultActualCostCad; }
            if ((!string.IsNullOrEmpty(item.DefaultActualCostUsd)) && (item.DefaultActualCostUsd.Trim() != returnItem.DefaultActualCostUsd.Trim())) { returnItem.DefaultActualCostUsd = item.DefaultActualCostUsd; }
            if ((!string.IsNullOrEmpty(item.Description)) && (item.Description.Trim() != returnItem.Description.Trim())) { returnItem.Description = item.Description; }
            if ((!string.IsNullOrEmpty(item.DirectImport)) && (item.DirectImport.Trim() != returnItem.DirectImport.Trim())) { returnItem.DirectImport = AssignDirectImport(item.DirectImport); }
            if ((!string.IsNullOrEmpty(item.Duty)) && (item.Duty.Trim() != returnItem.Duty.Trim())) { returnItem.Duty = item.Duty; }
            if ((!string.IsNullOrEmpty(item.Ean)) && (item.Ean.Trim() != returnItem.Ean.Trim())) { returnItem.Ean = item.Ean; }
            if ((!string.IsNullOrEmpty(item.Ecommerce_Asin)) && (item.Ecommerce_Asin.Trim() != returnItem.Ecommerce_Asin.Trim())) { returnItem.Ecommerce_Asin = item.Ecommerce_Asin; } // Ecommerce Ecommerce_Asin
            if ((!string.IsNullOrEmpty(item.Ecommerce_Bullet1)) && (item.Ecommerce_Bullet1.Trim() != returnItem.Ecommerce_Bullet1.Trim())) { returnItem.Ecommerce_Bullet1 = item.Ecommerce_Bullet1; } // Ecommerce Bullet 1
            if ((!string.IsNullOrEmpty(item.Ecommerce_Bullet2)) && (item.Ecommerce_Bullet2.Trim() != returnItem.Ecommerce_Bullet2.Trim())) { returnItem.Ecommerce_Bullet2 = item.Ecommerce_Bullet2; } // Ecommerce Bullet 2
            if ((!string.IsNullOrEmpty(item.Ecommerce_Bullet3)) && (item.Ecommerce_Bullet3.Trim() != returnItem.Ecommerce_Bullet3.Trim())) { returnItem.Ecommerce_Bullet3 = item.Ecommerce_Bullet3; } // Ecommerce Bullet 3
            if ((!string.IsNullOrEmpty(item.Ecommerce_Bullet4)) && (item.Ecommerce_Bullet4.Trim() != returnItem.Ecommerce_Bullet4.Trim())) { returnItem.Ecommerce_Bullet4 = item.Ecommerce_Bullet4; } // Ecommerce Bullet 4
            if ((!string.IsNullOrEmpty(item.Ecommerce_Bullet5)) && (item.Ecommerce_Bullet5.Trim() != returnItem.Ecommerce_Bullet5.Trim())) { returnItem.Ecommerce_Bullet5 = item.Ecommerce_Bullet5; } // Ecommerce Bullet 5
            if ((!string.IsNullOrEmpty(item.Ecommerce_Components)) && (item.Ecommerce_Components.Trim() != returnItem.Ecommerce_Components.Trim())) { returnItem.Ecommerce_Components = item.Ecommerce_Components; } // Ecommerce Components
            if ((!string.IsNullOrEmpty(item.Ecommerce_Cost)) && (item.Ecommerce_Cost.Trim() != returnItem.Ecommerce_Cost.Trim())) { returnItem.Ecommerce_Cost = item.Ecommerce_Cost; } // Ecommerce Cost
            if ((!string.IsNullOrEmpty(item.Ecommerce_ExternalId)) && (item.Ecommerce_ExternalId.Trim() != returnItem.Ecommerce_ExternalId.Trim())) { returnItem.Ecommerce_ExternalId = item.Ecommerce_ExternalId; } // Ecommerce External ID
            if ((!string.IsNullOrEmpty(item.Ecommerce_ExternalIdType)) && (item.Ecommerce_ExternalIdType.Trim() != returnItem.Ecommerce_ExternalIdType.Trim())) { returnItem.Ecommerce_ExternalIdType = item.Ecommerce_ExternalIdType; } // Ecommerce External ID Type
            if ((!string.IsNullOrEmpty(item.Ecommerce_ImagePath1)) && (item.Ecommerce_ImagePath1.Trim() != returnItem.Ecommerce_ImagePath1.Trim())) { returnItem.Ecommerce_ImagePath1 = item.Ecommerce_ImagePath1; } // Ecommerce Image Path 1
            if ((!string.IsNullOrEmpty(item.Ecommerce_ImagePath2)) && (item.Ecommerce_ImagePath2.Trim() != returnItem.Ecommerce_ImagePath2.Trim())) { returnItem.Ecommerce_ImagePath2 = item.Ecommerce_ImagePath2; } // Ecommerce Image Path 2
            if ((!string.IsNullOrEmpty(item.Ecommerce_ImagePath3)) && (item.Ecommerce_ImagePath3.Trim() != returnItem.Ecommerce_ImagePath3.Trim())) { returnItem.Ecommerce_ImagePath3 = item.Ecommerce_ImagePath3; } // Ecommerce Image Path 3
            if ((!string.IsNullOrEmpty(item.Ecommerce_ImagePath4)) && (item.Ecommerce_ImagePath4.Trim() != returnItem.Ecommerce_ImagePath4.Trim())) { returnItem.Ecommerce_ImagePath4 = item.Ecommerce_ImagePath4; } // Ecommerce Image Path 4
            if ((!string.IsNullOrEmpty(item.Ecommerce_ImagePath5)) && (item.Ecommerce_ImagePath5.Trim() != returnItem.Ecommerce_ImagePath5.Trim())) { returnItem.Ecommerce_ImagePath5 = item.Ecommerce_ImagePath5; } // Ecommerce Image Path 5
            if ((!string.IsNullOrEmpty(item.Ecommerce_ItemHeight)) && (item.Ecommerce_ItemHeight.Trim() != returnItem.Ecommerce_ItemHeight.Trim())) { returnItem.Ecommerce_ItemHeight = item.Ecommerce_ItemHeight; } // Ecommerce Item Height
            if ((!string.IsNullOrEmpty(item.Ecommerce_ItemLength)) && (item.Ecommerce_ItemLength.Trim() != returnItem.Ecommerce_ItemLength.Trim())) { returnItem.Ecommerce_ItemLength = item.Ecommerce_ItemLength; } // Ecommerce Item Length
            if ((!string.IsNullOrEmpty(item.Ecommerce_ItemName)) && (item.Ecommerce_ItemName.Trim() != returnItem.Ecommerce_ItemName.Trim())) { returnItem.Ecommerce_ItemName = item.Ecommerce_ItemName; } // Ecommerce Item Name
            if ((!string.IsNullOrEmpty(item.Ecommerce_ItemWeight)) && (item.Ecommerce_ItemWeight.Trim() != returnItem.Ecommerce_ItemWeight.Trim())) { returnItem.Ecommerce_ItemWeight = item.Ecommerce_ItemWeight; } // Ecommerce Item Weight
            if ((!string.IsNullOrEmpty(item.Ecommerce_ItemWidth)) && (item.Ecommerce_ItemWidth.Trim() != returnItem.Ecommerce_ItemWidth.Trim())) { returnItem.Ecommerce_ItemWidth = item.Ecommerce_ItemWidth; } // Ecommerce Item Width
            if ((!string.IsNullOrEmpty(item.Ecommerce_ModelName)) && (item.Ecommerce_ModelName.Trim() != returnItem.Ecommerce_ModelName.Trim())) { returnItem.Ecommerce_ModelName = item.Ecommerce_ModelName; } // Ecommerce Model Name
            if ((!string.IsNullOrEmpty(item.Ecommerce_PackageHeight)) && (item.Ecommerce_PackageHeight.Trim() != returnItem.Ecommerce_PackageHeight.Trim())) { returnItem.Ecommerce_PackageHeight = item.Ecommerce_PackageHeight; } // Ecommerce Package Height
            if ((!string.IsNullOrEmpty(item.Ecommerce_PackageLength)) && (item.Ecommerce_PackageLength.Trim() != returnItem.Ecommerce_PackageLength.Trim())) { returnItem.Ecommerce_PackageLength = item.Ecommerce_PackageLength; } // Ecommerce Package Length
            if ((!string.IsNullOrEmpty(item.Ecommerce_PackageWeight)) && (item.Ecommerce_PackageWeight.Trim() != returnItem.Ecommerce_PackageWeight.Trim())) { returnItem.Ecommerce_PackageWeight = item.Ecommerce_PackageWeight; } // Ecommerce Package Weight
            if ((!string.IsNullOrEmpty(item.Ecommerce_PackageWidth)) && (item.Ecommerce_PackageWidth.Trim() != returnItem.Ecommerce_PackageWidth.Trim())) { returnItem.Ecommerce_PackageWidth = item.Ecommerce_PackageWidth; } // Ecommerce Package Width
            if ((!string.IsNullOrEmpty(item.Ecommerce_PageQty)) && (item.Ecommerce_PageQty.Trim() != returnItem.Ecommerce_PageQty.Trim())) { returnItem.Ecommerce_PageQty = item.Ecommerce_PageQty; } // Ecommerce Page Qty
            if ((!string.IsNullOrEmpty(item.Ecommerce_ProductCategory)) && (item.Ecommerce_ProductCategory.Trim() != returnItem.Ecommerce_ProductCategory.Trim())) { returnItem.Ecommerce_ProductCategory = item.Ecommerce_ProductCategory; } // Ecommerce Product Category
            if ((!string.IsNullOrEmpty(item.Ecommerce_ProductDescription)) && (item.Ecommerce_ProductDescription.Trim() != returnItem.Ecommerce_ProductDescription.Trim())) { returnItem.Ecommerce_ProductDescription = item.Ecommerce_ProductDescription; } // Ecommerce Product Description
            if ((!string.IsNullOrEmpty(item.Ecommerce_ProductSubcategory)) && (item.Ecommerce_ProductSubcategory.Trim() != returnItem.Ecommerce_ProductSubcategory.Trim())) { returnItem.Ecommerce_ProductSubcategory = item.Ecommerce_ProductSubcategory; } // Ecommerce Product Subcategory
            if ((!string.IsNullOrEmpty(item.Ecommerce_ManufacturerName)) && (item.Ecommerce_ManufacturerName.Trim() != returnItem.Ecommerce_ManufacturerName.Trim())) { returnItem.Ecommerce_ManufacturerName = item.Ecommerce_ManufacturerName; } 
            if ((!string.IsNullOrEmpty(item.Ecommerce_Msrp)) && (item.Ecommerce_Msrp.Trim() != returnItem.Ecommerce_Msrp.Trim())) { returnItem.Ecommerce_Msrp = item.Ecommerce_Msrp; }
            if ((!string.IsNullOrEmpty(item.Ecommerce_GenericKeywords)) && (item.Ecommerce_GenericKeywords.Trim() != returnItem.Ecommerce_GenericKeywords.Trim())) { returnItem.Ecommerce_GenericKeywords = item.Ecommerce_GenericKeywords; } 
            if ((!string.IsNullOrEmpty(item.Ecommerce_Size)) && (item.Ecommerce_Size.Trim() != returnItem.Ecommerce_Size.Trim())) { returnItem.Ecommerce_Size = item.Ecommerce_Size; } 
            if ((!string.IsNullOrEmpty(item.Ecommerce_SubjectKeywords)) && (item.Ecommerce_SubjectKeywords.Trim() != returnItem.Ecommerce_SubjectKeywords.Trim())) { returnItem.Ecommerce_SubjectKeywords = item.Ecommerce_SubjectKeywords; } 
            if ((!string.IsNullOrEmpty(item.Ecommerce_Upc)) && (item.Ecommerce_Upc.Trim() != returnItem.Ecommerce_Upc.Trim())) { returnItem.Ecommerce_Upc = item.Ecommerce_Upc; } 
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
            if ((!string.IsNullOrEmpty(item.SellOnEcommerce)) && (item.SellOnEcommerce.Trim() != returnItem.SellOnEcommerce.Trim())) { returnItem.SellOnEcommerce = item.SellOnEcommerce.Trim(); }
            if ((!string.IsNullOrEmpty(item.SellOnFanatics)) && (item.SellOnFanatics.Trim() != returnItem.SellOnFanatics.Trim())) { returnItem.SellOnFanatics = item.SellOnFanatics.Trim(); } 
            if ((!string.IsNullOrEmpty(item.SellOnGuitarCenter)) && (item.SellOnGuitarCenter.Trim() != returnItem.SellOnGuitarCenter.Trim())) { returnItem.SellOnGuitarCenter = item.SellOnGuitarCenter.Trim(); } 
            if ((!string.IsNullOrEmpty(item.SellOnHayneedle)) && (item.SellOnHayneedle.Trim() != returnItem.SellOnHayneedle.Trim())) { returnItem.SellOnHayneedle = item.SellOnHayneedle.Trim(); } 
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
            if ((!string.IsNullOrEmpty(item.WebsitePrice)) && (item.WebsitePrice.Trim() != returnItem.WebsitePrice.Trim())) { returnItem.WebsitePrice = item.WebsitePrice; }
            if ((!string.IsNullOrEmpty(item.Weight)) && (item.Weight.Trim() != returnItem.Weight.Trim())) { returnItem.Weight = item.Weight; }
            if ((!string.IsNullOrEmpty(item.Width)) && (item.Width.Trim() != returnItem.Width.Trim())) { returnItem.Width = item.Width; }
            
            returnItem = ClearFields(returnItem);
            returnItem.UpdateSellOnValues();
            return returnItem;
        }
        
        /// <summary>
        ///     pulls down existing template and overrides values with those of the given template. Returns combined template.
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public Template CompleteTemplate(Template template)
        {
                Template oldTemplate = RetrieveTemplate(template.TemplateId);

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
                ItemObject item = new ItemObject()
                {
                    ItemRow = row + 1,
                    ItemId = ItemId,
                    AccountingGroup = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.AccountingGroup, WorksheetColumnHeaders.AcctgGroup),
                    AltImageFile1 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ImagePath2),
                    AltImageFile2 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ImagePath3),
                    AltImageFile3 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ImagePath4),
                    AltImageFile4 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ImagePath5),
                    BillOfMaterials = ParseChildElementIds(ItemId, ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.BillOfMaterials, WorksheetColumnHeaders.BOM)),
                    CasepackHeight = DbUtil.RoundValue4Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.CasepackHeight)),
                    CasepackLength = DbUtil.RoundValue4Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.CasepackLength).Trim()),
                    CasepackQty = DbUtil.RoundValue4Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.CasepackQty, WorksheetColumnHeaders.CasepackQuantity)),
                    CasepackUpc = DbUtil.RoundValue4Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.CasepackUpc).Trim()),
                    CasepackWidth = DbUtil.RoundValue4Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.CasepackWidth).Trim()),
                    CasepackWeight = DbUtil.RoundValue4Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.CasepackWeight).Trim()),
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
                    Duty = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Duty),
                    Ean = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ean),
                    Ecommerce_Asin = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_Asin, WorksheetColumnHeaders.A_Asin),
                    Ecommerce_Bullet1 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_Bullet1, WorksheetColumnHeaders.A_Bullet1),
                    Ecommerce_Bullet2 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_Bullet2, WorksheetColumnHeaders.A_Bullet2),
                    Ecommerce_Bullet3 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_Bullet3, WorksheetColumnHeaders.A_Bullet3),
                    Ecommerce_Bullet4 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_Bullet4, WorksheetColumnHeaders.A_Bullet4),
                    Ecommerce_Bullet5 = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_Bullet5, WorksheetColumnHeaders.A_Bullet5),
                    Ecommerce_Components = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_Components, WorksheetColumnHeaders.A_Components),
                    Ecommerce_Cost = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_Cost, WorksheetColumnHeaders.A_Cost), 2),
                    Ecommerce_ExternalId = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_ExternalId, WorksheetColumnHeaders.A_ExternalID).Trim(),
                    Ecommerce_ExternalIdType = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_ExternalIdType, WorksheetColumnHeaders.A_ExternalIdType).Trim(),
                    Ecommerce_GenericKeywords = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.GenericKeywords, WorksheetColumnHeaders.Ecommerce_GenericKeywords),
                    Ecommerce_ItemHeight = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_ItemHeight, WorksheetColumnHeaders.A_ItemHeight), 1),
                    Ecommerce_ItemLength = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_ItemLength, WorksheetColumnHeaders.A_ItemLength), 1),
                    Ecommerce_ItemName = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_ItemName, WorksheetColumnHeaders.A_ItemName).Trim(),
                    Ecommerce_ItemWeight = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_ItemWeight, WorksheetColumnHeaders.A_ItemWeight), 1),
                    Ecommerce_ItemWidth = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_ItemWidth, WorksheetColumnHeaders.A_ItemWidth), 1),
                    Ecommerce_ModelName = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_ModelName, WorksheetColumnHeaders.A_ModelName).Trim(),
                    Ecommerce_PackageHeight = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_PackageHeight, WorksheetColumnHeaders.A_PackageHeight), 1),
                    Ecommerce_PackageLength = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_PackageLength, WorksheetColumnHeaders.A_PackageLength), 1),
                    Ecommerce_PackageWeight = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_PackageWeight, WorksheetColumnHeaders.A_PackageWeight), 1),
                    Ecommerce_PackageWidth = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_PackageWidth, WorksheetColumnHeaders.A_PackageWidth), 1).Trim(),
                    Ecommerce_PageQty = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_PageQty).Trim(),
                    Ecommerce_ProductCategory = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_ProductCategory, WorksheetColumnHeaders.A_ProductCategory),
                    Ecommerce_ProductDescription = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_ProductDescription, WorksheetColumnHeaders.A_ProductDescription),
                    Ecommerce_ProductSubcategory = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_ProductSubcategory, WorksheetColumnHeaders.A_ProductSubcategory),
                    Ecommerce_ManufacturerName = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_ManufacturerName, WorksheetColumnHeaders.A_ManufacturerName),
                    Ecommerce_Msrp = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_Msrp, WorksheetColumnHeaders.A_Msrp), 2),
                    Ecommerce_SubjectKeywords = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_SearchTerms, WorksheetColumnHeaders.A_SearchTerms),
                    Ecommerce_Size = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_Size, WorksheetColumnHeaders.A_Size),
                    Ecommerce_Upc = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Ecommerce_Upc),
                    Gpc = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Gpc),
                    Height = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Height, WorksheetColumnHeaders.ItemHeight), 1),
                    ImagePath = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ImagePath, WorksheetColumnHeaders.ImagePath1),
                    InnerpackHeight = DbUtil.RoundValue4Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.InnerpackHeight)),
                    InnerpackLength = DbUtil.RoundValue4Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.InnerpackLength)),
                    InnerpackQuantity = DbUtil.RoundValue4Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.InnerpackQuantity, WorksheetColumnHeaders.InnerpackQty)),
                    InnerpackUpc = DbUtil.RoundValue4Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.InnerpackUpc)),
                    InnerpackWidth = DbUtil.RoundValue4Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.InnerpackWidth)),
                    InnerpackWeight = DbUtil.RoundValue4Dec(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.InnerpackWeight)),
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
                    MetaDescription = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.MetaDescription),
                    MfgSource = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.MfgSource).Trim(),
                    Msrp = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Msrp).Trim(),
                    MsrpCad = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.MsrpCad).Trim(),
                    MsrpMxn = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.MsrpMxn).Trim(),
                    PricingGroup = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.PricingGroup, WorksheetColumnHeaders.PricingGroupProduct).Trim(),
                    PrintOnDemand = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.PrintOnDemand).Trim(),
                    ProductFormat = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ProductFormat).Trim(),
                    ProductGroup = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ProductGroup).Trim(),
                    ProductIdTranslation = ParseChildElementIds(ItemId, ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.ProductIdTranslation)),
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
                    SellOnTarget = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.SellOnTarget).Trim(),
                    SellOnTrends = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.SellOnTrends).Trim(),
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
                    WebsitePrice = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.WebsitePrice), 2),
                    Weight = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Weight, WorksheetColumnHeaders.ItemWeight), 1),
                    Width = DbUtil.ZeroTrim(ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.Width, WorksheetColumnHeaders.ItemWidth), 1)
                };

                if (status == "Add")
                {
                    string TemplateName = ReadWorksheetCell(worksheetData, row, WorksheetColumnHeaders.TemplateName, WorksheetColumnHeaders.TemplateId);
                    if (!string.IsNullOrEmpty(TemplateName))
                    {
                        item = SetTemplateValues(TemplateName,item);
                    }
                    item.UpdateSellOnValues();
                }
                item.Ecommerce_CountryofOrigin = RetrieveFullCountryOfOrigin(item.CountryOfOrigin);

                item.ResetUpdate();
                itemList.Add(item);
            }
            return itemList;
        }
        
        /// <summary>
        ///     Calls a window explorer with workbook reader and loads in a list of templates
        /// </summary>
        public List<Template> LoadTemplate(string fileName, string type)
        {
            List<Template> result = new List<Template>();
            WorksheetData worksheetData = this.WorkbookReader.ReadWorksheet(fileName);
            if (worksheetData.CellData.Count == 0)
            {
                MessageBox.Show("Odin could not read any data from provided spread sheet.");
            }
            for (int row = 0; row < worksheetData.CellData.Count; row++)
            {
                if (!string.IsNullOrEmpty(worksheetData.GetValue(row, WorksheetColumnHeaders.TemplateId)) || type == "Add")
                {
                    Template template = new Template()
                    {
                        TemplateId = worksheetData.GetValue(row, WorksheetColumnHeaders.TemplateId, WorksheetColumnHeaders.TemplateName).Trim(),
                        AccountingGroup = worksheetData.GetValue(row, WorksheetColumnHeaders.AccountingGroup, WorksheetColumnHeaders.AcctgGroup).Trim(),
                        CasepackHeight = DbUtil.RoundValue4Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.CasepackHeight).Trim()),
                        CasepackLength = DbUtil.RoundValue4Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.CasepackLength).Trim()),
                        CasepackQty = DbUtil.RoundValue4Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.CasepackQty).Trim()),
                        CasepackWidth = DbUtil.RoundValue4Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.CasepackWidth).Trim()),
                        CasepackWeight = DbUtil.RoundValue4Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.CasepackWeight).Trim()),
                        Category = DbUtil.ReplaceCharacters(worksheetData.GetValue(row, WorksheetColumnHeaders.Category).Trim()),
                        Category2 = DbUtil.ReplaceCharacters(worksheetData.GetValue(row, WorksheetColumnHeaders.Category2).Trim()),
                        Category3 = DbUtil.ReplaceCharacters(worksheetData.GetValue(row, WorksheetColumnHeaders.Category3).Trim()),
                        Copyright = worksheetData.GetValue(row, WorksheetColumnHeaders.Copyright).Trim(),
                        CountryOfOrigin = worksheetData.GetValue(row, WorksheetColumnHeaders.CountryOfOrigin).Trim(),
                        CostProfileGroup = worksheetData.GetValue(row, WorksheetColumnHeaders.CostProfileGroup).Trim(),
                        DefaultActualCostUsd = DbUtil.RoundValue4Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.DacUsd, WorksheetColumnHeaders.DefaultActualCostUsd).Trim()),
                        DefaultActualCostCad = DbUtil.RoundValue4Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.DacCad, WorksheetColumnHeaders.DefaultActualCostCad).Trim()),
                        Gpc = worksheetData.GetValue(row, WorksheetColumnHeaders.Gpc).Trim(),
                        Height = worksheetData.GetValue(row, WorksheetColumnHeaders.Height, WorksheetColumnHeaders.ItemHeight).Trim(),
                        InnerpackHeight = DbUtil.RoundValue4Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.InnerpackHeight).Trim()),
                        InnerpackLength = DbUtil.RoundValue4Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.InnerpackLength).Trim()),
                        InnerpackQuantity = DbUtil.RoundValue4Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.InnerpackQuantity, WorksheetColumnHeaders.InnerpackQty).Trim()),
                        InnerpackWidth = DbUtil.RoundValue4Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.InnerpackWidth).Trim()),
                        InnerpackWeight = DbUtil.RoundValue4Dec(worksheetData.GetValue(row, WorksheetColumnHeaders.InnerpackWeight).Trim()),
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
                        EcommerceBullet1 = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_Bullet1, WorksheetColumnHeaders.A_Bullet1).Trim(),
                        EcommerceBullet2 = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_Bullet2, WorksheetColumnHeaders.A_Bullet2).Trim(),
                        EcommerceBullet3 = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_Bullet3, WorksheetColumnHeaders.A_Bullet3).Trim(),
                        EcommerceBullet4 = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_Bullet4, WorksheetColumnHeaders.A_Bullet4).Trim(),
                        EcommerceBullet5 = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_Bullet5, WorksheetColumnHeaders.A_Bullet5).Trim(),
                        EcommerceComponents = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_Components, WorksheetColumnHeaders.A_Components).Trim(),
                        EcommerceCost = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_Cost, WorksheetColumnHeaders.A_Cost).Trim(),
                        EcommerceExternalIdType = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_ExternalIdType, WorksheetColumnHeaders.A_ExternalIdType).Trim(),
                        EcommerceItemHeight = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_ItemHeight, WorksheetColumnHeaders.A_ItemHeight).Trim(),
                        EcommerceItemLength = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_ItemLength, WorksheetColumnHeaders.A_ItemLength).Trim(),
                        EcommerceItemWeight = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_ItemWeight, WorksheetColumnHeaders.A_ItemWeight).Trim(),
                        EcommerceItemWidth = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_ItemWidth, WorksheetColumnHeaders.A_ItemWidth).Trim(),
                        EcommerceModelName = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_ModelName, WorksheetColumnHeaders.A_ModelName).Trim(),
                        EcommercePackageHeight = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_PackageHeight, WorksheetColumnHeaders.A_PackageHeight).Trim(),
                        EcommercePackageLength = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_PackageLength, WorksheetColumnHeaders.A_PackageLength).Trim(),
                        EcommercePackageWeight = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_PackageWeight, WorksheetColumnHeaders.A_PackageWeight).Trim(),
                        EcommercePackageWidth = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_PackageWidth, WorksheetColumnHeaders.A_PackageWidth).Trim(),
                        EcommercePageQty = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_PageQty, WorksheetColumnHeaders.A_PageQty).Trim(),
                        EcommerceProductCategory = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_ProductCategory, WorksheetColumnHeaders.A_ProductCategory).Trim(),
                        EcommerceProductDescription = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_ProductDescription, WorksheetColumnHeaders.A_ProductDescription).Trim(),
                        EcommerceProductSubcategory = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_ProductSubcategory, WorksheetColumnHeaders.A_ProductSubcategory).Trim(),
                        EcommerceManufacturerName = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_ManufacturerName, WorksheetColumnHeaders.A_ManufacturerName).Trim(),
                        EcommerceMsrp = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_Msrp, WorksheetColumnHeaders.A_Msrp).Trim(),
                        EcommerceSize = worksheetData.GetValue(row, WorksheetColumnHeaders.Ecommerce_Size, WorksheetColumnHeaders.A_Size).Trim(),
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
                result.Add(new Template());
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
                Template template = RetrieveTemplate(TemplateName);
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
                if (string.IsNullOrEmpty(item.Ecommerce_Bullet1)) { item.Ecommerce_Bullet1 = template.EcommerceBullet1; }
                if (string.IsNullOrEmpty(item.Ecommerce_Bullet2)) { item.Ecommerce_Bullet2 = template.EcommerceBullet2; }
                if (string.IsNullOrEmpty(item.Ecommerce_Bullet3)) { item.Ecommerce_Bullet3 = template.EcommerceBullet3; }
                if (string.IsNullOrEmpty(item.Ecommerce_Bullet4)) { item.Ecommerce_Bullet4 = template.EcommerceBullet4; }
                if (string.IsNullOrEmpty(item.Ecommerce_Bullet5)) { item.Ecommerce_Bullet5 = template.EcommerceBullet5; }
                if (string.IsNullOrEmpty(item.Ecommerce_Components)) { item.Ecommerce_Components = template.EcommerceComponents; }
                if (string.IsNullOrEmpty(item.Ecommerce_Cost)) { item.Ecommerce_Cost = template.EcommerceCost; }
                if (string.IsNullOrEmpty(item.Ecommerce_ExternalIdType)) { item.Ecommerce_ExternalIdType = template.EcommerceExternalIdType; }
                if (string.IsNullOrEmpty(item.Ecommerce_ItemHeight)) { item.Ecommerce_ItemHeight = template.EcommerceItemHeight; }
                if (string.IsNullOrEmpty(item.Ecommerce_ItemLength)) { item.Ecommerce_ItemLength = template.EcommerceItemLength; }
                if (string.IsNullOrEmpty(item.Ecommerce_ItemWeight)) { item.Ecommerce_ItemWeight = template.EcommerceItemWeight; }
                if (string.IsNullOrEmpty(item.Ecommerce_ItemWidth)) { item.Ecommerce_ItemWidth = template.EcommerceItemWidth; }
                if (string.IsNullOrEmpty(item.Ecommerce_ModelName)) { item.Ecommerce_ModelName = template.EcommerceModelName; }
                if (string.IsNullOrEmpty(item.Ecommerce_PackageHeight)) { item.Ecommerce_PackageHeight = template.EcommercePackageHeight; }
                if (string.IsNullOrEmpty(item.Ecommerce_PackageLength)) { item.Ecommerce_PackageLength = template.EcommercePackageLength; }
                if (string.IsNullOrEmpty(item.Ecommerce_PackageWeight)) { item.Ecommerce_PackageWeight = template.EcommercePackageWeight; }
                if (string.IsNullOrEmpty(item.Ecommerce_PackageWidth)) { item.Ecommerce_PackageWidth = template.EcommercePackageWidth; }
                if (string.IsNullOrEmpty(item.Ecommerce_PageQty)) { item.Ecommerce_PageQty = template.EcommercePageQty; }
                if (string.IsNullOrEmpty(item.Ecommerce_ProductCategory)) { item.Ecommerce_ProductCategory = template.EcommerceProductCategory; }
                if (string.IsNullOrEmpty(item.Ecommerce_ProductDescription)) { item.Ecommerce_ProductDescription = template.EcommerceProductDescription; }
                if (string.IsNullOrEmpty(item.Ecommerce_ProductSubcategory)) { item.Ecommerce_ProductSubcategory = template.EcommerceProductSubcategory; }
                if (string.IsNullOrEmpty(item.Ecommerce_ManufacturerName)) { item.Ecommerce_ManufacturerName = template.EcommerceManufacturerName; }
                if (string.IsNullOrEmpty(item.Ecommerce_Msrp)) { item.Ecommerce_Msrp = template.EcommerceMsrp; }
                if (string.IsNullOrEmpty(item.Ecommerce_Size)) { item.Ecommerce_Size = template.EcommerceSize; }
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
            List<Template> templates = LoadTemplate(fileName, "Update");
            List<Template> newTemplates = new List<Template>();
            List<string> errors = new List<string>();

            foreach (Template template in templates)
            {
                if (GlobalData.TemplateNames.Contains(template.TemplateId))
                {
                    newTemplates.Add(CompleteTemplate(template));
                    foreach (string error in ValidateAllTemplate(template, "Add"))
                    {
                        errors.Add(error);
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
                        string errorMessage = "The spreadsheet contains a template Id odin does not recognized.";
                        if (!errors.Contains(errorMessage))
                        {
                            errors.Add("The spreadsheet contains a template Id odin does not recognized.");
                        }                        
                    }
                }
            }
            if (errors.Count() == 0)
            {
                foreach (Template template in newTemplates)
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
        public void InsertTemplate(Template template)
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
        ///     Retrieves a list of search items from the database
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public List<SearchItem> RetrieveFindItemSearchResults(string searchValue)
        {
            List<SearchItem> SearchItemResults = ItemRepository.RetrieveItemSearchResults(searchValue);
            foreach(SearchItem item in SearchItemResults)
            {
                if(item.ItemId == searchValue.ToUpper())
                {
                    List<SearchItem> OverrideList = new List<SearchItem>() { item };
                    return OverrideList;
                }
            }

            return SearchItemResults;
        }

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
        public List<string> RetrieveImagePaths(string itemId)
        {
            return ItemRepository.RetrieveImagePaths(itemId);
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
            item.UpdateSellOnValues();
            return item;
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
        ///     Retrieve Property fields from the Global Data. With the key of given license. Empty License returns all properties.
        /// </summary>
        /// <returns>List of properties</returns>
        public List<string> RetrievePropertyList(string license)
        {
            List<string> properties = new List<string>();
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
        ///     Retrieves a template from the db
        /// </summary>
        /// <returns></returns>
        public Template RetrieveTemplate(string name)
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
        public void UpdateOnSite(string itemId)
        {
            ItemRepository.UpdateOnSite(itemId);
        }
        
        /// <summary>
        ///     Updates an existing template
        /// </summary>
        /// <returns></returns>
        public void UpdateTemplate(Template template, string status)
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
        public ObservableCollection<ItemError> ValidateItem(ItemObject var, List<string> itemIds, bool isSubmit)
        {
            ObservableCollection<ItemError> ErrorList = new ObservableCollection<ItemError>();
            if (isSubmit)
            {
                if (var.SellOnTrends != "Y")
                {
                    ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, "Sell On Trends must be set to Y before item can be submitted to the web.", ""));
                    return ErrorList;
                }
            }
            string error = string.Empty;

            // Acounting Group //
            error = ValidateAccountingGroup(var.AccountingGroup, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // AltImage File 1 //
            error = ValidateImagePath(var.AltImageFile1, "Image Path 2", false);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // AltImage File 2 //
            error = ValidateImagePath(var.AltImageFile2, "Image Path 3", false);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // AltImage File 3 //
            error = ValidateImagePath(var.AltImageFile3, "Image Path 4", false);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // AltImage File 4 //
            error = ValidateImagePath(var.AltImageFile4, "Image Path 5", false);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Bill Of Materials //
            error = ValidateBillOfMaterials(var.ItemId, var.BillOfMaterials, itemIds, var.Status, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Casepack Height //
            error = ValidateCasepack(var.CasepackHeight, var.CasepackLength, var.CasepackWeight, var.CasepackWidth, var.ProdType, "Casepack Height ");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Casepack Length //
            error = ValidateCasepack(var.CasepackLength, var.CasepackHeight, var.CasepackWeight, var.CasepackWidth, var.ProdType, "Casepack Length ");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Casepack Weight //
            error = ValidateCasepack(var.CasepackWeight, var.CasepackLength, var.CasepackHeight, var.CasepackWidth, var.ProdType, "Casepack Weight ");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Casepack Width //
            error = ValidateCasepack(var.CasepackWidth, var.CasepackLength, var.CasepackWeight, var.CasepackHeight, var.ProdType, "Casepack Width ");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Casepack Qty //
            error = ValidateCasepackQty(var.CasepackQty, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Category //
            error = ValidateCategory(var.Category, var.HasWeb());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Category 2 //
            error = ValidateCategory2(var.Category2, "2");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Category 3 //
            error = ValidateCategory2(var.Category3, "3");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // CasepackUpc //
            error = ValidatePackUpc(var.CasepackUpc, "Casepack", var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Color //
            error = ValidateColor(var.Color, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Copyright //
            error = ValidateCopyright(var.Copyright);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Country Of Origin //
            error = ValidateCountryOfOrigin(var.CountryOfOrigin, var.ListPriceUsd, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Cost Profile Group //
            error = ValidateCostProfileGroup(var.CostProfileGroup, var.MfgSource, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // DefaultActualCostCad //
            error = ValidateDefaultActualCost(var.DefaultActualCostCad, "CAD", var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Default Actual Cost Usd //
            error = ValidateDefaultActualCost(var.DefaultActualCostUsd, "USD", var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Description //
            error = ValidateDescription(var.Description, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Direct Import //
            error = ValidateDirectImport(var.DirectImport, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Duty //
            error = ValidateDuty(var.Duty, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ean //
            error = ValidateEan(var.Ean, var.Upc, var.ListPriceUsd, var.ProductFormat, var.ProductLine);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Asin //
            error = ValidateEcommerce_Asin(var.Ecommerce_Asin);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Bullet 1 //
            error = ValidateEcommerce_Bullet(var.Ecommerce_Bullet1, "1", var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Bullet 2 //
            error = ValidateEcommerce_Bullet(var.Ecommerce_Bullet2, "2", var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Bullet 3 //
            error = ValidateEcommerce_Bullet(var.Ecommerce_Bullet3, "3", var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Bullet 4 //
            error = ValidateEcommerce_Bullet(var.Ecommerce_Bullet4, "4", false);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Bullet 5 //
            error = ValidateEcommerce_Bullet(var.Ecommerce_Bullet5, "5", false);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Components //
            error = ValidateEcommerce_Components(var.Ecommerce_Components, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Cost //
            error = ValidateEcommerce_Cost(var.Ecommerce_Cost, "", var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce External Id Type //
            error = ValidateEcommerce_ExternalIdType(var.Ecommerce_ExternalIdType, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce External Id //
            error = ValidateEcommerce_ExternalId(var.Ecommerce_ExternalId, var.Ecommerce_ExternalIdType, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Item Height //
            error = ValidateEcommerce_ItemHeight(var.Ecommerce_ItemHeight, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Item Length //
            error = ValidateEcommerce_ItemLength(var.Ecommerce_ItemLength, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Item Name //
            error = ValidateEcommerce_ItemName(var.Ecommerce_ItemName, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Item Weight //
            error = ValidateEcommerce_ItemWeight(var.Ecommerce_ItemWeight, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Item Width //
            error = ValidateEcommerce_ItemWidth(var.Ecommerce_ItemWidth, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Model Name //
            error = ValidateEcommerce_ModelName(var.Ecommerce_ModelName, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Package Height //
            error = ValidateEcommerce_PackageHeight(var.Ecommerce_PackageHeight, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Package Length //
            error = ValidateEcommerce_PackageLength(var.Ecommerce_PackageLength, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Package Weight //
            error = ValidateEcommerce_PackageWeight(var.Ecommerce_PackageWeight, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Package Width //
            error = ValidateEcommerce_PackageWidth(var.Ecommerce_PackageWidth, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Page Qty //
            error = ValidateEcommerce_PageQty(var.Ecommerce_PageQty);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Product Category //
            error = ValidateEcommerce_ProductCategory(var.Ecommerce_ProductCategory, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Product Description //
            error = ValidateEcommerce_ProductDescription(var.Ecommerce_ProductDescription, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Product Subcategory //
            error = ValidateEcommerce_ProductSubcategory(var.Ecommerce_ProductSubcategory, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Manufacturer Name //
            error = ValidateEcommerce_ManufacturerName(var.Ecommerce_ManufacturerName, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Msrp //
            error = ValidateEcommerce_Msrp(var.Ecommerce_Msrp, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Generic Keywords //
            error = ValidateEcommerce_Keywords(var.Ecommerce_GenericKeywords, false, "Ecommerce Generic Keywords", var.Status);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Subject Keywords //
            error = ValidateEcommerce_Keywords(var.Ecommerce_SubjectKeywords, var.HasEcommerce(), "Ecommerce Search Terms", var.Status);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Size //
            error = ValidateEcommerce_Size(var.Ecommerce_Size, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ecommerce Upc //
            error = ValidateEcommerce_Upc(var.Ecommerce_Upc, var.ItemId, var.Upc, var.Status, var.HasEcommerce());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Gpc //
            error = ValidateGpc(var.Gpc, var.ListPriceUsd, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Height //
            error = ValidateHeight(var.Height, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Image Path //
            error = ValidateImagePath(var.ImagePath, "Image Path", var.HasWeb());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Innerpack Height //
            error = ValidateInnerpack(var.InnerpackHeight, var.InnerpackLength, var.InnerpackWeight, var.InnerpackWidth, var.ProdType, "Innerpack Height ");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Innerpack Length //
            error = ValidateInnerpack(var.InnerpackLength, var.InnerpackHeight, var.InnerpackWeight, var.InnerpackWidth, var.ProdType, "Innerpack Length ");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Innerpack Quantity //
            error = ValidateInnerpackQuantity(var.InnerpackQuantity, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Innerpack Upc //
            error = ValidatePackUpc(var.InnerpackUpc, "Innerpack", var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Innerpack Weight //
            error = ValidateInnerpack(var.InnerpackWeight, var.InnerpackLength, var.InnerpackHeight, var.InnerpackWidth, var.ProdType, "Innerpack Weight ");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Innerpack Width //
            error = ValidateInnerpack(var.InnerpackWidth, var.InnerpackLength, var.InnerpackWeight, var.InnerpackHeight, var.ProdType, "Innerpack Width ");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // In Stock Date //
            error = ValidateInStockDate(var.InStockDate);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Isbn //
            error = ValidateIsbn(var.Isbn, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Item Category //
            error = ValidateItemCategory(var.ItemCategory, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Item Family //
            error = ValidateItemFamily(var.ItemFamily, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Item Group //
            error = ValidateItemGroup(var.ItemGroup, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Item Id //
            error = ValidateItemId(var.ItemId, var.Status);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Item Keywords //
            error = ValidateItemKeywords(var.ItemKeywords, var.HasWeb());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Language //
            error = ValidateLanguage(var.Language, var.ListPriceUsd, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Length //
            error = ValidateLength(var.Length, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // License //
            error = ValidateLicense(var.License);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // License Begin Date //
            error = ValidateLicenseBeginDate(var.LicenseBeginDate, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // List Price Cad //
            error = ValidateListPrice(var.ListPriceCad, "CAD", var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // List Price Mxn //
            error = ValidateListPrice(var.ListPriceMxn, "MXN", var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // List Price Usd //
            error = ValidateListPrice(var.ListPriceUsd, "USD", var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Mfg Source //
            error = ValidateMfgSource(var.MfgSource, var.CostProfileGroup, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // List Msrp //
            error = ValidateMsrp(var.Msrp, var.ListPriceUsd, var.ProdType, "USD");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Msrp Cad //
            error = ValidateMsrp(var.MsrpCad, var.ListPriceCad, var.ProdType, "CAD");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Msrp Mxn //
            error = ValidateMsrp(var.MsrpMxn, var.ListPriceMxn, var.ProdType, "MXN");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Product Format //
            error = ValidateProductFormat(var.ProductGroup, var.ProductLine, var.ProductFormat,var.Upc, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Product Group //
            error = ValidateProductGroup(var.ProductGroup, var.Upc, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Product Line //
            error = ValidateProductLine(var.ProductGroup, var.ProductLine,var.Upc, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Pricing Group //
            error = ValidatePricingGroup(var.PricingGroup, var.ListPriceCad, var.ListPriceUsd, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Print On Demand //
            error = ValidatePrintOnDemand(var.PrintOnDemand, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Product Id Translation //
            error = ValidateProductIdTranslation(var.ItemId, var.ProductIdTranslation, itemIds, var.ProductFormat, var.PricingGroup, var.Status, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Property //
            error = ValidateProperty(var.Property, var.License);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Ps Status //
            error = ValidatePsStatus(var.PsStatus, "Item");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, "Error", "PS Status")); }
            // Sat Code //
            error = ValidateSatCode(var.SatCode);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Sell On All Posters //
            error = ValidateSellOnValue(var.SellOnAllPosters, var.SellOnEcommerce, "AllPosters");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Sell On Amazon //
            error = ValidateSellOnValue(var.SellOnAmazon, var.SellOnEcommerce, "Amazon");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Sell On Amazon Seller Central //
            error = ValidateSellOnValue(var.SellOnAmazonSellerCentral, var.SellOnEcommerce, "Amazon Seller Central");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Sell On Ecommerce //
            error = ValidateSellOnValue(var.SellOnEcommerce, null, "Ecommerce");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Sell On Fanatics //
            error = ValidateSellOnValue(var.SellOnFanatics, var.SellOnEcommerce, "Fanatics");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Sell On Guitar Center //
            error = ValidateSellOnValue(var.SellOnGuitarCenter, var.SellOnEcommerce, "Guitar Center");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Sell On Hayneedle //
            error = ValidateSellOnValue(var.SellOnHayneedle, var.SellOnEcommerce, "Hayneedle");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Sell On Target //
            error = ValidateSellOnValue(var.SellOnTarget, var.SellOnEcommerce, "Target");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Sell On Trends //
            error = ValidateSellOnValue(var.SellOnTrends, null, "Trends");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Sell On Walmart //
            error = ValidateSellOnValue(var.SellOnWalmart, var.SellOnEcommerce, "Walmart");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Sell On Wayfair //
            error = ValidateSellOnValue(var.SellOnWayfair, var.SellOnEcommerce, "Wayfair");
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Short Description //
            error = ValidateShortDescription(var.ShortDescription);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Size //
            error = ValidateSize(var.Size);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Standard Cost //
            error = ValidateStandardCost(var.StandardCost, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Stats Code //
            error = ValidateStatsCode(var.StatsCode, var.ListPriceUsd, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Tariff Code //
            error = ValidateTariffCode(var.TariffCode, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Territory //
            error = ValidateTerritory(var.Territory, var.ListPriceUsd, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Title //
            error = ValidateTitle(var.Title, var.HasWeb());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Udex //
            error = ValidateUdex(var.Udex, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Upc //
            error = ValidateUpc(var.Upc,var.ItemId, var.Status, var.ListPriceUsd, var.ProductFormat, var.ProductGroup, var.ProductLine, var.Ean, var.Ecommerce_Upc, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // WebsitePrice //
            error = ValidateWebsitePrice(var.WebsitePrice, var.HasWeb());
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Weight //
            error = ValidateWeight(var.Weight, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }
            // Width //
            error = ValidateWidth(var.Width, var.ProdType);
            if (error != "") { ErrorList.Add(new ItemError(var.ItemId, var.ItemRow, error, "")); }

            return ErrorList;
        }

        /// <summary>
        ///     Validates all fields of current template
        /// </summary>
        /// <param name="var"></param>
        public List<string> ValidateAllTemplate(Template var, string status)
        {
            List<string> ErrorMessages = new List<string>();

            string error = ValidateTemplateId(var.TemplateId, status);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateAccountingGroup(var.AccountingGroup, var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateCasepack(var.CasepackHeight, "", "", "", var.ProdType, "Casepack Height");
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateCasepack(var.CasepackLength, "", "", "", var.ProdType, "Casepack Length");
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateCasepack(var.CasepackWeight, "", "", "", var.ProdType, "Casepack Weight");
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateCasepack(var.CasepackWidth, "", "", "", var.ProdType, "Casepack Width");
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateCasepackQty(var.CasepackQty, var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateCountryOfOrigin(var.CountryOfOrigin, var.ListPriceUsd, var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateCostProfileGroup(var.CostProfileGroup, var.MfgSource, var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateDefaultActualCost(var.DefaultActualCostCad, "CAD", var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateDefaultActualCost(var.DefaultActualCostUsd, "USD", var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateDuty(var.Duty, var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateGpc(var.Gpc, "", var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateHeight(var.Height, var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateInnerpack(var.InnerpackHeight, "", "", "", var.ProdType, "Innerpack Height");
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateInnerpack(var.InnerpackLength, "", "", "", var.ProdType, "Innerpack Length");
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateInnerpack(var.InnerpackWidth, "", "", "", var.ProdType, "Innerpack Width");
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateInnerpack(var.InnerpackWeight, "", "", "", var.ProdType, "Innerpack Weight");
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateInnerpackQuantity(var.InnerpackQuantity, var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateItemCategory(var.ItemCategory, var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateItemFamily(var.ItemFamily, var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateItemGroup(var.ItemGroup, var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateLength(var.Length, var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateListPrice(var.ListPriceCad, "CAD", var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateListPrice(var.ListPriceMxn, "MXN", var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateListPrice(var.ListPriceUsd, "USD", var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateMfgSource(var.MfgSource, var.CostProfileGroup, var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateMsrp(var.Msrp, var.ListPriceUsd, var.ProdType, "USD");
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateMsrp(var.MsrpCad, var.ListPriceCad, var.ProdType, "CAD");
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateMsrp(var.MsrpMxn, var.ListPriceMxn, var.ProdType, "MXN");
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateProductFormat(var.ProductGroup, var.ProductLine, var.ProductFormat, "", var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateProductGroup(var.ProductGroup, "", var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateProductLine(var.ProductGroup, var.ProductLine, "", var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidatePricingGroup(var.PricingGroup, var.ListPriceCad, var.ListPriceUsd, var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateSatCode(var.SatCode);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateTariffCode(var.TariffCode, var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateUdex(var.Udex, var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateWebsitePrice(var.WebsitePrice, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateWeight(var.Weight, var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateWidth(var.Width, var.ProdType);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateCategory(var.Category, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateCategory2(var.Category2, "2");
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateCategory2(var.Category3, "3");
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateCopyright(var.Copyright);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateSize(var.Size);
            if (error != "") { ErrorMessages.Add(error); }

            error = ValidateEcommerce_Bullet(var.EcommerceBullet1, "1", false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_Bullet(var.EcommerceBullet2, "2", false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_Bullet(var.EcommerceBullet3, "3", false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_Bullet(var.EcommerceBullet4, "4", false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_Bullet(var.EcommerceBullet5, "5", false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_Components(var.EcommerceComponents, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_Cost(var.EcommerceCost, "", false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_ExternalIdType(var.EcommerceExternalIdType, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_ItemHeight(var.EcommerceItemHeight, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_ItemLength(var.EcommerceItemLength, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_ItemWeight(var.EcommerceItemWeight, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_ItemWidth(var.EcommerceItemWidth, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_ModelName(var.EcommerceModelName, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_PackageHeight(var.EcommercePackageHeight, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_PackageLength(var.EcommercePackageLength, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_PackageWeight(var.EcommercePackageWeight, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_PackageWidth(var.EcommercePackageWidth, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_PageQty(var.EcommercePageQty);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_ProductCategory(var.EcommerceProductCategory, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_ProductDescription(var.EcommerceProductDescription, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_ProductSubcategory(var.EcommerceProductSubcategory, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_ManufacturerName(var.EcommerceManufacturerName, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_Msrp(var.EcommerceMsrp, false);
            if (error != "") { ErrorMessages.Add(error); }
            error = ValidateEcommerce_Size(var.EcommerceSize, false);
            if (error != "") { ErrorMessages.Add(error); }

            return ErrorMessages;
        }

        /// <summary>
        ///     Validates the Accounting Group field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateAccountingGroup(string value, int prodType)
        {
            bool required = true;
            if(prodType==2)
            {
                required = false;
            }
            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    return "Accounting Group " + OdinServices.Properties.Resources.Error_Required;
                }
                if (value.Length > 10)
                {
                    return "Accounting Group " + OdinServices.Properties.Resources.Error_LengthMax + "10 characters.";
                }
                if (!GlobalData.AccountingGroups.Contains(value))
                {
                    return "Accounting Group " + OdinServices.Properties.Resources.Error_NoMatch;                    
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Bill of Materials Field field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="billOfMaterials"></param>
        /// <param name="currentIds"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateBillOfMaterials(string itemId, List<ChildElement> billOfMaterials, List<string> currentIds, string status, int prodType)
        {
            List<string> BomIdList = new List<string>();
            bool existingValue = false;

            if (billOfMaterials.Count() == 0)
            {
                return "";
            }
            if(GlobalData.BillofMaterials.Where(p => p.ParentId == itemId).Count()>0)
            {
                existingValue = true;
            }
            foreach (ChildElement billOfMaterial in billOfMaterials)
            {
                if (status == "Update" && existingValue)
                {
                    if(!CheckBillofMaterial(billOfMaterial.ParentId.Trim(), billOfMaterial.ItemId.Trim()))
                    {
                        return "Bill of Materials cannot be updated through Odin. The Bill of materials field does not match the values currently saved for this item.";
                    }
                }
                if (!string.IsNullOrEmpty(billOfMaterial.ItemId))
                {
                    if ((!currentIds.Contains(billOfMaterial.ItemId.Trim())) && (!GlobalData.ItemIds.Contains(billOfMaterial.ItemId.Trim())))
                    {
                        return "Bill of Materials field contains an id that does not exist: " + billOfMaterial.ItemId + ".";
                    }
                }
                if (BomIdList.Contains(billOfMaterial.ItemId.Trim()))
                {
                    return "Bill of Material Field can not contain multiple occurances of the same item. ["+ billOfMaterial.ItemId.Trim() + "]";
                }
                else
                {
                    BomIdList.Add(billOfMaterial.ItemId.Trim());
                }
            }
            return "";
        }
        
        /// <summary>
        ///     Validates the Casepack field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value1">Field being validated</param>
        /// <param name="value2">Other Casepack Field</param>
        /// <param name="value3">Other Casepack Field</param>
        /// <param name="value4">Other Casepack Field</param>
        /// <param name="prodType"></param>
        /// <param name="type">Casepack type being validated</param>
        /// <returns></returns>
        public string ValidateCasepack(string value1, string value2, string value3, string value4, int prodType, string type)
        {
            if (string.IsNullOrEmpty(value1))
            {
                if ((string.IsNullOrEmpty(value2)) && (string.IsNullOrEmpty(value3)) && (string.IsNullOrEmpty(value4)))
                {
                    return "";
                }
                else
                {
                    if (prodType != 2)
                    {
                        return type + " cannot be left empty if the other casepack dimensional fields have values(height, weight, width, length).";
                    }
                }
            }
            else
            {
                if (value1.Length > 7)
                {
                    return type + " " + OdinServices.Properties.Resources.Error_LengthMax + "7 characters.";
                }
                if (!DbUtil.IsNumber(value1))
                {
                    return type + " must be a numeric value.";
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates Casepack Qty field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateCasepackQty(string value, int prodType)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            if (value.Contains('.'))
            {
                return "Casepack Qty cannot be a decimal.";
            }
            if (value.Length > 7)
            {
                return "Casepack Qty " + OdinServices.Properties.Resources.Error_LengthMax + "7 characters.";
            }
            if (!DbUtil.IsNumber(value))
            {
                return "Casepack Quantity " + OdinServices.Properties.Resources.Error_NonNumeric;
            }
            return "";
        }

        /// <summary>
        ///     Vaidates Web Cateogry 1 field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="hasWeb"></param>
        /// <returns></returns>
        public string ValidateCategory(string value, bool hasWeb)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (!GlobalData.ReturnWebCategoryListValues().Contains(value))
                {
                    return "Category " + OdinServices.Properties.Resources.Error_NoMatch;
                }
            }

            if (hasWeb)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Category " + OdinServices.Properties.Resources.Error_RequiredWeb;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates additional web category field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cat"></param>
        /// <param name="hasWeb"></param>
        /// <returns></returns>
        public string ValidateCategory2(string value, string cat)
        {
            if (!(string.IsNullOrEmpty(value)))
            {
                if (!GlobalData.ReturnWebCategoryListValues().Contains(value))
                {
                    return "Category " + cat + " " + OdinServices.Properties.Resources.Error_NoMatch;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the color field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateColor(string value, int prodType)
        {
            if (value.Length > 10)
            {
                return "Color field " + OdinServices.Properties.Resources.Error_LengthMax + "10 characters.";
            }
            if (!DbUtil.ContainsOnlyAZ09(value))
            {
                return "Color conatins invalid charachters. (Color can only use charachters A-Z and 0-9)";
            }
            return "";
        }
        
        /// <summary>
        ///     Validate Copyright field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="hasWeb"></param>
        /// <returns></returns>
        public string ValidateCopyright(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 1000)
                {
                    return "Copyright value " + OdinServices.Properties.Resources.Error_LengthMax + "1000 characters.";
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Country of Origin field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="listPriceUS"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateCountryOfOrigin(string value, string listPriceUS, int prodType)
        {
            bool required = true;
            if(prodType == 2){ required = false; }

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    if (listPriceUS == "0" || listPriceUS == "0.00" || listPriceUS == "0.0000")
                    {
                        return "";
                    }
                    else
                    {
                        return "Country of Origin " + OdinServices.Properties.Resources.Error_Required;
                    }
                }
                if (value.Length > 3)
                {
                    return "Country of Origin " + OdinServices.Properties.Resources.Error_LengthMax + "3 characters.";

                }
                if (!DbUtil.ContainsOnlyAZ(value))
                {
                    return "Country of Origin conatins invalid charachters. (Country of Origin can only use charachters A-Z)";
                }
                if (!GlobalData.ReturnCountryofOriginCodes().Contains(value))
                {
                    return "Country of Origin " + OdinServices.Properties.Resources.Error_NoMatch;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Cost Profile Group field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mfgSource">Items MFG Source</param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateCostProfileGroup(string value, string mfgSource, int prodType)
        {
            bool template = false;
            if (prodType == 2) { template = true; }
            if (!string.IsNullOrEmpty(value) || !template)
            {
                if (string.IsNullOrEmpty(value) && !template)
                {
                    return "Cost Profile Group " + OdinServices.Properties.Resources.Error_Required;
                }
                if (!GlobalData.CostProfileGroups.Contains(value))
                {
                    return "Cost Profile Group " + OdinServices.Properties.Resources.Error_NoMatch;
                }
                if (!template)
                {
                    if (((mfgSource == "1") && (value == "MFG_ACTUAL_FIFO")) || ((mfgSource == "2") && (value == "ACTUAL_FIFO")))
                    {
                        return "";
                    }
                    else return "Cost Profile Group does not align with the MFG Sorce value.";
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates Default Actual Cost field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="daccad2"></param>
        /// <param name="standardcost"></param>
        /// <param name="currency"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateDefaultActualCost(string value, string currency, int prodType)
        {
            bool required = true;
            if(prodType == 2) { required = false; }

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    return "Default Actual Cost " + currency + " " + OdinServices.Properties.Resources.Error_Required;
                }
                if (value.Length > 9)
                {
                    return "Default Actual Cost " + currency + " " + OdinServices.Properties.Resources.Error_LengthMax + "9 characters.";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Default Actual Cost " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates Description field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateDescription(string value, int prodType)
        {
            bool required = true;
            if (prodType == 2) { required = false; }

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    return "Description " + OdinServices.Properties.Resources.Error_Required;
                }
                if (value.Length > 60)
                {
                    return "Description field " + OdinServices.Properties.Resources.Error_LengthMax + "60 characters.";
                }
                if (CheckSpecialChar(value))
                {
                    return "Description field " + OdinServices.Properties.Resources.Error_SpecialChars;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Direct Import Field
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateDirectImport(string value, int prodType)
        {
            if (value == "" || value.ToUpper() == "Y" || value.ToUpper() == "N")
            {
                return "";
            }
            else
            {
                return "Direct Import " + OdinServices.Properties.Resources.Error_YorN;
            }
        }

        /// <summary>
        ///     Validates the Duty field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateDuty(string value, int prodType)
        {
            if (value.Count() > 30)
            {
                return "Duty field " + OdinServices.Properties.Resources.Error_LengthMax + "30 characters.";
            }
            return "";
        }

        /// <summary>
        ///     Validates the EAN field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="upc">item's UPC value</param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateEan(string value, string upc, string listpriceUsd, string prodFormat, string prodLine) 
        {            
            if (string.IsNullOrEmpty(value))
            {
                if (listpriceUsd == "" || listpriceUsd == "0" || listpriceUsd == "0.00" || listpriceUsd == "0.0000")
                {
                    return "";
                }
                if (prodLine == "Direct Medical Mail")
                {
                    return "";
                }
                if (string.IsNullOrEmpty(upc))
                {
                    if (GlobalData.UpcProductFormatExceptions.Contains(prodFormat))
                    {
                        return "";
                    }
                    else return "EAN is required when a UPC is not provided.";
                }
            }
            else
            {
                if (CheckSpecialChar(value))
                {
                    return "EAN " + OdinServices.Properties.Resources.Error_SpecialChars;
                }
                if (value.Length > 30)
                {
                    return "EAN field " + OdinServices.Properties.Resources.Error_LengthMax + "30 characters.";
                }
            }
            return "";
        }

        /// <summary>
        ///  Validates the Ecommerce_Asin field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ValidateEcommerce_Asin(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            if (value.Count() > 10)
            {
                return "Amazon Asin " + OdinServices.Properties.Resources.Error_LengthMax + "10 characters.";
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_Bullet Validation field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_Bullet(string value, string bulletNumber, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 254)
                {
                    return "Ecommerce Bullet" + bulletNumber + " " + OdinServices.Properties.Resources.Error_LengthMax + "254 characters.";
                }
                if (!DbUtil.CheckMinimum(value, 10))
                {
                    return "Ecommerce Bullet" + bulletNumber + " " + OdinServices.Properties.Resources.Error_LengthMin + "10 characters.";
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce Bullet" + bulletNumber + " " + OdinServices.Properties.Resources.Error_RequiredAmazon;

                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_Components field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_Components(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 100)
                {
                    return "Ecommerce Components " + OdinServices.Properties.Resources.Error_LengthMax + "100 characters.";
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value) )
                {
                    return "Ecommerce Components " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_Cost field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_Cost(string value, string type, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 9)
                {
                    return "Ecommerce Cost " + type + OdinServices.Properties.Resources.Error_LengthMax + "9 characters.";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Ecommerce Cost " + type + OdinServices.Properties.Resources.Error_NonNumeric;
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce Cost " + type + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_ExternalId field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_ExternalId(string value, string externalIdType, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 20)
                {
                    return "Ecommerce External ID " + OdinServices.Properties.Resources.Error_LengthMax + "20 characters.";
                }
                if (GlobalData.ExternalIdTypes.Contains(externalIdType))
                {
                    switch (externalIdType)
                    {
                        case "UPC":
                            if (CheckSpecialChar(value))
                            {
                                return "Ecommerce External Id " + OdinServices.Properties.Resources.Error_SpecialChars;
                            }
                            if (!DbUtil.IsNumber(value))
                            {
                                return "Ecommerce External Id " + OdinServices.Properties.Resources.Error_NonNumeric;
                            }
                            if ((value.Length != 8) && (value.Length != 12))
                            {
                                return "Ecommerce External Id has invalid length. UPC values can only have a length of 8 or 12 characters.";
                            }
                            return "";
                        case "UPC (12-digits)":
                            if (CheckSpecialChar(value))
                            {
                                return "Ecommerce External Id " + OdinServices.Properties.Resources.Error_SpecialChars;
                            }
                            if (!DbUtil.IsNumber(value))
                            {
                                return "Ecommerce External Id " + OdinServices.Properties.Resources.Error_NonNumeric;
                            }
                            if ((value.Length != 8) && (value.Length != 12))
                            {
                                return "Ecommerce External Id has invalid length. UPC values can only have a length of 8 or 12 characters.";
                            }
                            return "";
                        case "ISBN":
                            return ValidateIsbn(value, 1);
                        case "EAN":
                            return ValidateEan(value, "X", "0", "X", "X");
                    }
                }
                else
                {
                    return "Invalid coresponding ExternalIdType. Odin does not recognize " + externalIdType + " as an valid External Id Type.";
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce External Id " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_ExternalIdType field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_ExternalIdType(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (!GlobalData.ExternalIdTypes.Contains(value))
                {
                    return "Ecommerce External Id Type has an invalid value. (Accepted Values are 'UPC (12-digits)', 'ISBN', 'EAN' or 'GTIN'.";
                }
                return "";
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce External Id Type " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Ecommerce_ItemHeight field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_ItemHeight(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 9)
                {
                    return "Ecommerce Height " + OdinServices.Properties.Resources.Error_LengthMax + "9 characters.";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Ecommerce Height  " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce Height " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Ecommerce_ItemLength field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_ItemLength(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 9)
                {
                    return "Ecommerce Length " + OdinServices.Properties.Resources.Error_LengthMax + "9 characters.";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Ecommerce Length  " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce Item Length " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_ItemName field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_ItemName(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (!DbUtil.CheckMaximum(value, 200))
                {
                    return "Ecommerce Item Name " + OdinServices.Properties.Resources.Error_LengthMax + "200 characters.";
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce Item Name " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_ItemWeight field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_ItemWeight(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 9)
                {
                    return "Ecommerce Weight " + OdinServices.Properties.Resources.Error_LengthMax + "9 characters.";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Ecommerce Weight  " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce Item Weight " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_ItemWidth field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_ItemWidth(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 9)
                {
                    return "Ecommerce Width " + OdinServices.Properties.Resources.Error_LengthMax + "9 characters.";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Ecommerce Width  " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce Item Width " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_ManufacturerName field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_ManufacturerName(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 100)
                {
                    return "Ecommerce Manufacturer Name " + OdinServices.Properties.Resources.Error_LengthMax + "100  characters.";
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce Manufacturer Name " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Ecommerce_ModelName field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_ModelName(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 50)
                {
                    return "Ecommerce Model Name " + OdinServices.Properties.Resources.Error_LengthMax + "50 characters.";
                }
                return "";
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce Model Name " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_Msrp field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_Msrp(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 9)
                {
                    return "Ecommerce MSRP " + OdinServices.Properties.Resources.Error_LengthMax + "9 characters.";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Ecommerce Msrp " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce MSRP " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
                if (value == "0" || value == "0.00" || value == "0.0000")
                {
                    return "Ecommerce Msrp must contain a non-zero value.";
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_PackageHeight field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_PackageHeight(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 9)
                {
                    return "Ecommerce Package Height " + OdinServices.Properties.Resources.Error_LengthMax + "9 characters.";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Ecommerce Package Height " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce Package Height " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_PackageLength field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_PackageLength(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 9)
                {
                    return "Ecommerce Package Length " + OdinServices.Properties.Resources.Error_LengthMax + "9 characters.";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Ecommerce Package Length " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce Package Length " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_PackageWeight field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_PackageWeight(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 9)
                {
                    return "Ecommerce Package Weight " + OdinServices.Properties.Resources.Error_LengthMax + "9 characters.";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Ecommerce Package Weight " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce Package Weight " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///      Validates the Ecommerce_PackageWidth field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_PackageWidth(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 9)
                {
                    return "Ecommerce Package Width " + OdinServices.Properties.Resources.Error_LengthMax + "9 characters.";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Ecommerce Package Width " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce Package Width " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///      Validates the Ecommerce_PageQty field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_PageQty(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 4)
                {
                    return "Ecommerce Page Qty " + OdinServices.Properties.Resources.Error_LengthMax + "4 characters.";
                }
                if (value.Contains("."))
                {
                    return "Ecommerce Page Qty can not be a decimal";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Ecommerce Page Qty " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_ProductCategory field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_ProductCategory(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 50)
                {
                    return "Ecommerce Product Category " + OdinServices.Properties.Resources.Error_LengthMax + "50 characters.";
                }
                return "";
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce Product Category " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_ProductDescription field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_ProductDescription(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (!DbUtil.CheckMinimum(value, 100))
                {
                    return "Ecommerce Product Description " + OdinServices.Properties.Resources.Error_LengthMin + "100 characters.";
                }
                
                if (value.Length > 8000)
                {
                    return "Ecommerce Product Description " + OdinServices.Properties.Resources.Error_LengthMax + "8000 characters.";
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce Product Description " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_ProductSubcategory field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_ProductSubcategory(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 50)
                {
                    return "Ecommerce Product Subcategory " + OdinServices.Properties.Resources.Error_LengthMax + "50 characters.";
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce Product Subcategory " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_GenericKeywords field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_Keywords(string value, bool ecommerceFlag, string type, string status)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 385)
                {
                    return type + " " + OdinServices.Properties.Resources.Error_LengthMax + "385 characters.";
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return type + " " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce_Size field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateEcommerce_Size(string value, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 254)
                {
                    return "Ecommerce Size " + OdinServices.Properties.Resources.Error_LengthMax + "254 characters.";
                }
            }
            if (ecommerceFlag && GlobalData.EcomFlagRequirement)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Ecommerce Size " + OdinServices.Properties.Resources.Error_RequiredAmazon;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Ecommerce Upc field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ValidateEcommerce_Upc(string value, string itemId, string upc, string status, bool ecommerceFlag)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length != 12)
                {
                    return "Ecommerce UPC has an invalid length. Ecommerce UPC can only have a length of 12 characters.";
                }
                if (CheckSpecialChar(value))
                {
                    return "Ecommerce UPC " + OdinServices.Properties.Resources.Error_SpecialChars;
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Ecommerce UPC " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
                if (value == upc)
                {
                    return "Item's Upc and Ecommerce Upc cannot share the same value.";
                }
                List<string> matchId = CheckDuplicateUPCs(itemId, value, status);
                if (matchId.Count > 0)
                {
                    string ids = "";
                    foreach (string id in matchId)
                    {
                        ids += id + ", ";
                    }
                    return "Ecommerce UPC contains a duplicate ID. The following items already contain this upc or ecommerce upc: " + ids;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the GPC field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="listPriceUS">List Price Field</param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateGpc(string value, string listPriceUS, int prodType)
        {
            bool required = true;
            if (prodType == 2) { required = false; }           
            if (!string.IsNullOrEmpty(value) || required)
            {
                if ((string.IsNullOrEmpty(value)) && required)
                {
                    if (listPriceUS == "0" || listPriceUS == "0.00" || listPriceUS == "0.0000")
                    {
                        return "";
                    }
                    else
                    {
                        return "GPC field " + OdinServices.Properties.Resources.Error_Required;
                    }
                }
                if (value.Length > 10)
                {
                    return "GPC field " + OdinServices.Properties.Resources.Error_LengthMax + "10 characters.";
                }
            }
            return "";
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
        ///     Validates the item height field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns>Error message or "" if value is valid</returns>
        public string ValidateHeight(string value, int prodType)
        {
            bool required = true;
            if (prodType == 2) { required = false; }

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    return "Height field " + OdinServices.Properties.Resources.Error_Required;
                }
                if (value.Length > 8)
                {
                    return "Height field " + OdinServices.Properties.Resources.Error_LengthMax + "8 characters.";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Height field " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
                if (Convert.ToDouble(value) < 0.00001)
                {
                    return "Height " + OdinServices.Properties.Resources.Error_0;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Image Path fields. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateImagePath(string value, string field, bool sellOnTrends)
        {
            if (sellOnTrends || !string.IsNullOrEmpty(value))
            {
                if (string.IsNullOrEmpty(value) && sellOnTrends)
                {
                    return field + " " + OdinServices.Properties.Resources.Error_RequiredWeb;
                }
                if (value.Contains("'")||value.Contains("`"))
                {
                    return field + " cannot contain apostrophes.";
                }
                if (CheckSpecialChar(value))
                {
                    return field + " cannot contain special characters.";
                }
                if (value.Length > 254)
                {
                    return field + " " + OdinServices.Properties.Resources.Error_LengthMax + "254 characters.";
                }
                if (!File.Exists(value))
                {
                    return field + @" could not find image with given filepath: "+value;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates Innerpack fields. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value1">Innerpack field being validated</param>
        /// <param name="value2">Other Innerpack value</param>
        /// <param name="value3">Other Innerpack value</param>
        /// <param name="value4">Other Innerpack value</param>
        /// <param name="prodType"></param>
        /// <param name="type">Innerpack Field Type</param>
        /// <returns></returns>
        public string ValidateInnerpack(string value1, string value2, string value3, string value4, int prodType, string type)
        {
            bool template = false;
            if (prodType == 2) { template = true; }
            if (string.IsNullOrEmpty(value1))
            {
                if ((string.IsNullOrEmpty(value2)) && (string.IsNullOrEmpty(value3)) && (string.IsNullOrEmpty(value4)))
                {
                    return "";
                }
                else
                {
                    if (!template)
                    {
                        return type + " field cannot be empty if this item has other innerpack dimension fields filled out (height, weight, width, length).";
                    }
                }
            }
            if (value1.Length > 7)
            {
                return type + " " + OdinServices.Properties.Resources.Error_LengthMax + "7 characters.";
            }
            if (!DbUtil.IsNumber(value1))
            {
                return type + " " + OdinServices.Properties.Resources.Error_NonNumeric;
            }
            return "";
        }

        /// <summary>
        ///     Validates Innerpack Quantity field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateInnerpackQuantity(string value, int prodType)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            if (value.Contains('.'))
            {
                return "Innerpack Quantity cannot be a decimal.";
            }
            if (value.Length > 7)
            {
                return "Innerpack Quantity " + OdinServices.Properties.Resources.Error_LengthMax + "7 characters.";
            }
            if (!DbUtil.IsNumber(value))
            {
                return "Innerpack Quantity " + OdinServices.Properties.Resources.Error_NonNumeric;
            }
            return "";
        }

        /// <summary>
        ///     Validate in stock date field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="hasWeb"></param>
        /// <returns></returns>
        public string ValidateInStockDate(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value == "0000-00-00")
                {
                    return "In Stock Date cannot be set to 0000-00-00.";
                }
                if (!DateTime.TryParse(value, out DateTime temp))
                {
                    return "In Stock Date field must contain a valid date";
                }
                else if (Convert.ToDateTime(value).Date < Convert.ToDateTime("01/01/1753").Date)
                {
                    return "License Begin Date cannot be before 01/01/1753.";
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates ISBN field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateIsbn(string value, int prodType)
        {
            if (!(string.IsNullOrEmpty(value)))
            {
                if (CheckSpecialChar(value))
                {
                    return "ISBN field " + OdinServices.Properties.Resources.Error_SpecialChars;
                }
                if (value.Length > 10)
                {
                    return "ISBN field " + OdinServices.Properties.Resources.Error_LengthMax + "10 characters.";
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates Item Category field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateItemCategory(string value, int prodType)
        {
            bool required = true;
            if (prodType == 2) { required = false; }

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    return "Item Category " + OdinServices.Properties.Resources.Error_Required;
                }
                if (value.Length > 15)
                {
                    return "Item Category " + OdinServices.Properties.Resources.Error_LengthMax + "15 characters.";
                }
                if (!GlobalData.ProductCategories.Contains(value))
                {
                    return "Item Category " + OdinServices.Properties.Resources.Error_NoMatch;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates Item Family field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateItemFamily(string value, int prodType)
        {
            if (!(string.IsNullOrEmpty(value)))
            {
                if (value.Length > 18)
                {
                    return "Item Family " + OdinServices.Properties.Resources.Error_LengthMax + "18 characters.";
                }
                if ((value == "STICKER") || (value == "") || (value == "FLAT"))
                {
                    return "";
                }
                else return "Item Family contains an invalid value. (Item Family must be set to 'STICKER', 'FLAT', or left empty)";
            }
            return "";
        }

        /// <summary>
        ///     Validates Item Group field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateItemGroup(string value, int prodType)
        {
            bool required = true;
            if (prodType == 2) { required = false; }
            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    return "Item Group " + OdinServices.Properties.Resources.Error_Required;
                }
                if (value.Length > 15)
                {
                    return "Item Group field " + OdinServices.Properties.Resources.Error_LengthMax + "15 characters.";
                }
                if (!GlobalData.ItemGroups.Contains(value))
                {
                    return "Item Group " + OdinServices.Properties.Resources.Error_NoMatch;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates Item Id field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public string ValidateItemId(string value, string status)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "Item Id " + OdinServices.Properties.Resources.Error_Required;
            }
            if ((status == "Add") || (status == ""))
            {
                if (value.Length > 18)
                {
                    return "Item Id " + OdinServices.Properties.Resources.Error_LengthMax + "18 characters.";
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!((value[i] >= 'A' && value[i] <= 'Z') || (value[i] >= '0' && value[i] <= '9') || value[i] == '-'))
                    {
                        return "Item Id contains invalid charachters. (Only use A-Z, 0-9 and -)";
                    }
                }
                if (GlobalData.ItemIds.Contains(value))
                {
                    return "Item Id " + OdinServices.Properties.Resources.Error_AlreadyExists;
                }
            }
            else if (status == "Update")
            {
                if(!GlobalData.ItemIds.Contains(value))
                {
                    return "Item ID does not exist in peoplesoft.";
                }
            }
            return "";
        }

        /// <summary>
        ///     Validate item Keywords field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="hasWeb"></param>
        /// <returns></returns>
        public string ValidateItemKeywords(string value, bool hasWeb)
        {
            if(!string.IsNullOrEmpty(value))
            {
                if (value.Length > 1000)
                {
                    return "Item Keywords " + OdinServices.Properties.Resources.Error_LengthMax + "1000 characters.";
                }
            }
            if (hasWeb)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Item Keywords " + OdinServices.Properties.Resources.Error_RequiredWeb;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates Language field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="listPriceUS">Items US list price</param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateLanguage(string value, string listPriceUS, int prodType)
        {
            bool required = (prodType == 2) ? false : true;

            if (!(string.IsNullOrEmpty(value)))
            {
                string[] x = value.Split('/');
                foreach (string y in x)
                {
                    if (!GlobalData.Languages.Contains(y))
                    {
                        return "Language value " + y + OdinServices.Properties.Resources.Error_NoMatch;
                    }
                }
                return "";
            }
            else
            {
                if (listPriceUS == "0" || listPriceUS == "0.00" || listPriceUS == "0.0000")
                {
                    return "";
                }
                if (required)
                {
                    return "Language " + OdinServices.Properties.Resources.Error_Required;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the item length field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns>Error message or "" if value is valid</returns>
        public string ValidateLength(string value, int prodType)
        {
            bool required = (prodType == 2) ? false : true;

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    return "Length field " + OdinServices.Properties.Resources.Error_Required;
                }
                if (value.Length > 8)
                {
                    return "Length field" + OdinServices.Properties.Resources.Error_LengthMax + "8 characters.";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Length field " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
                if (Convert.ToDouble(value) < 0.00001)
                {
                    return "Length field " + OdinServices.Properties.Resources.Error_0;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validate License field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="hasWeb"></param>
        /// <returns></returns>
        public string ValidateLicense(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 255)
                {
                    return "License field " + OdinServices.Properties.Resources.Error_LengthMax + "255 characters.";
                }
                if (!GlobalData.Licenses.Contains(value))
                {
                    return "License field " + OdinServices.Properties.Resources.Error_NoMatch;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates license begin date field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateLicenseBeginDate(string value, int prodType)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value == "0000-00-00")
                {
                    return "License Begin Date cannot be set to 0000-00-00.";
                }
                if (!DateTime.TryParse(value, out DateTime temp))
                {
                    return "License Begin Date field must contain a valid date";
                }
                else if (Convert.ToDateTime(value).Date < Convert.ToDateTime("01/01/1753").Date)
                {
                    return "License Begin Date cannot be before 01/01/1753.";
                }
            }
            return "";
        }
        
        /// <summary>
        ///     Validates MFG Source field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="costProfileGroup">item's cost profile group</param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateMfgSource(string value, string costProfileGroup, int prodType)
        {
            bool required = (prodType == 2) ? false : true;

            if (!(string.IsNullOrEmpty(value)))
            {
                if (value == "1")
                {
                    if (required)
                    {
                        if (costProfileGroup == "MFG_ACTUAL_FIFO")
                        {
                            return "";
                        }
                        else
                        {
                            return "MFG Source value does not properly align with the Cost Profile Group value.";
                        }
                    }
                }                
                else if (value == "2" )
                {
                    if (required)
                    {
                        if (costProfileGroup == "ACTUAL_FIFO")
                        {
                            return "";
                        }
                        else
                        {
                            return "MFG Source value does not properly align with the Cost Profile Group value.";
                        }
                    }
                }
                else return "MFG Source field can only contain a value of '1' or '2'";
            }
            else
            {
                if (required)
                {
                    return "MFG Source " + OdinServices.Properties.Resources.Error_Required;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates MSRP value field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="listPrice">coresponding list price</param>
        /// <param name="prodType"></param>
        /// <param name="type">msrp type (usd, mxn, cad)</param>
        /// <param name="isUS">flag if usd msrp</param>
        /// <returns></returns>
        public string ValidateMsrp(string value, string listPrice, int prodType, string type)
        {
            bool required = (prodType == 2) ? false : true;

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (value.Length > 10)
                {
                    return "MSRP " + type + " " + OdinServices.Properties.Resources.Error_LengthMax + "10 characters.";
                }
                if (string.IsNullOrEmpty(value))
                {
                    if (listPrice == "0")
                    {
                        return "";
                    }
                    if (type == "USD" && required)
                    {
                        return "MSRP " + type + " " + OdinServices.Properties.Resources.Error_Required;
                    }
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "MSRP " + type + " " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validate innerpack or casepack UPC field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="packtype">innerpack or casepack</param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidatePackUpc(string value, string packtype, int prodType)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            if (!DbUtil.IsNumber(value))
            {
                return packtype + "UPC " + OdinServices.Properties.Resources.Error_NonNumeric;
            }
            if ((value.Length != 8) && (value.Length != 12))
            {
                return packtype + "UPC has invalid length. " + packtype + " UPC must have a length of 8 or 12 characters.";
            }
            return "";
        }

        /// <summary>
        ///     Validate item List price field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">(usd, mxn, cad)</param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateListPrice(string value, string type, int prodType)
        {
            bool required = (prodType == 2) ? false : true;

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    return "List Price " + type + " " + OdinServices.Properties.Resources.Error_Required;
                }
                if (value.Length > 9)
                {
                    return "List Price " + type + " " + OdinServices.Properties.Resources.Error_LengthMax + "9 characters.";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "List Price " + type + " " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
            }
            return "";
        }
        
        /// <summary>
        ///     Validates meta description field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="hasWeb"></param>
        /// <returns></returns>
        public string ValidateMetaDescription(string value, bool hasWeb)
        {
            if (!(string.IsNullOrEmpty(value)))
            {
                if (!GlobalData.MetaDescriptions.Contains(value) && !CheckForProductFormat(value))
                {
                    return "Meta Description " + OdinServices.Properties.Resources.Error_NoMatch;
                }
            }
            if (hasWeb && string.IsNullOrEmpty(value))
            {
                return "Meta Description " + OdinServices.Properties.Resources.Error_RequiredWeb;
            }
            return "";
        }

        /// <summary>
        ///     Validate product format field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="productGroup">item's product group</param>
        /// <param name="productLine">item's product line</param>
        /// <param name="productFormat">item's product format</param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateProductFormat(string productGroup, string productLine, string productFormat, string upc, int prodType)
        {
            bool required = (prodType == 2) ? false : true;

            if (!string.IsNullOrEmpty(productFormat) || required)
            {
                if (productFormat.Trim().Length > 60)
                {
                    return "Product Format " + OdinServices.Properties.Resources.Error_LengthMax + "60 characters.";
                }
                if (!string.IsNullOrEmpty(productFormat))
                {
                    if (!CheckProductFormats(productGroup, productLine, productFormat))
                    {
                        return "Product Format does not align with Product Line and Product Group values provided.";
                    }
                }
                else
                {
                    if (!required)
                    {
                        if (!string.IsNullOrEmpty(upc))
                        {
                            return "Product Format is a required value when a UPC value is provided.";
                        }
                    }
                }
            }
            return "";
        }

        /// <summary>
        ///     Validate product group field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateProductGroup(string value, string upc, int prodType)
        {
            bool required = (prodType == 2) ? false : true;

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    return "Product Group " + OdinServices.Properties.Resources.Error_Required;
                }
                if (value.Trim().Length > 30)
                {
                    return "Product Group " + OdinServices.Properties.Resources.Error_LengthMax + "30 characters.";
                }
                if (!GlobalData.ProductGoups.Contains(value))
                {
                    return "Product Group " + OdinServices.Properties.Resources.Error_NoMatch;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the Product Id Translation Field field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="productTranslation"></param>
        /// <param name="currentIds"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateProductIdTranslation(string itemId, List<ChildElement> productTranslations, List<string> currentIds, string productFormat, string pricingGroup, string status, int prodType)
        {
            if (productTranslations.Count() == 0)
            {
                if (productFormat.ToUpper() == "POD POSTER FRAME")
                {
                    return "Product Id Translations are required when the Product Format = 'POD POSTER FRAME'.";
                }
                else if (!string.IsNullOrEmpty(pricingGroup))
                {
                    if (pricingGroup.Substring(0, 3).ToUpper() == "FRP")
                    {
                        return "Product Id Translations are required when the Pricing Group = 'FRP'.";
                    }
                }
                return "";
            }
            else
            {
                foreach (ChildElement productIdTranslation in productTranslations)
                {
                    if (!string.IsNullOrEmpty(productIdTranslation.ItemId))
                    {
                        if ((!currentIds.Contains(productIdTranslation.ItemId.Trim())) && (!GlobalData.ItemIds.Contains(productIdTranslation.ItemId.Trim())))
                        {
                            return "Product Id Translation field contains an id that does not exist: " + productIdTranslation.ItemId + ".";
                        }
                    }
                    int count = 0;
                    string erroredId = string.Empty;
                    foreach (ChildElement productIdTranslation2 in productTranslations)
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
                        return "Product Id Translation can not contain multiple occurances of the same item: "+ erroredId;
                    }
                }
                if (status == "Update")
                {
                    if (!CheckExistingProductIdTranslationsMatch(productTranslations))
                    {
                        foreach (ChildElement productIdTranslation in productTranslations)
                        {
                            if (CheckItemHasOpenOrderLine(productIdTranslation.ItemId))
                            {
                                return "Product Id Translations: Current open orders are preventing this change from taking place.";
                            }
                        }
                    }
                }
            }
            return "";
        }

        /// <summary>
        ///     Validate Product Line field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="productGroup">item's product group</param>
        /// <param name="productLine">item's product line</param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateProductLine(string productGroup, string productLine, string upc, int prodType)
        {
            bool required = (prodType == 2) ? false : true;

            if (!string.IsNullOrEmpty(productLine) || required)
            {
                if (productLine.Trim().Length > 30)
                {
                    return "Product Line " + OdinServices.Properties.Resources.Error_LengthMax + "30 characters.";
                }

                if (!string.IsNullOrEmpty(productGroup))
                {
                    if (!CheckProductLines(productGroup, productLine))
                    {
                        return "Product Line does not align with Product Group provided.";
                    }
                }
                else
                {
                    if (required)
                    {
                        if (!string.IsNullOrEmpty(upc))
                        {
                            return "Product Line is a required value when a UPC is provided";
                        }
                    }
                }
            }
            return "";
        }

        /// <summary>
        ///     Validate Product Quantity field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateProductQty(string value, int prodType)
        {
            if (!(string.IsNullOrEmpty(value)))
            {
                if (!DbUtil.IsNumber(value))
                {
                    return "Product Quantity " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validate Property field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="license">Item's License</param>
        /// <param name="hasWeb"></param>
        /// <returns></returns>
        public string ValidateProperty(string value, string license)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (!RetrievePropertyList(license).Contains(value))
                {
                    return "Property field does not align with the provided item license.";
                }
            }
            return "";
        }

        /// <summary>
        ///     Validate Pricing Group field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="listPriceCad">item's List Price CAD</param>
        /// <param name="listPriceUsd">item's List Price USD</param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidatePricingGroup(string value, string listPriceCad, string listPriceUsd, int prodType)
        {

            bool required = (prodType == 2) ? false : true;

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (value.Length > 30)
                {
                    return "Pricing Group " + OdinServices.Properties.Resources.Error_LengthMax + "30 characters.";
                }
                if (string.IsNullOrEmpty(value))
                {
                    if (((listPriceUsd == "0") || (listPriceUsd == "0.0000") || (listPriceUsd == "") || (listPriceUsd == "0.00")) && ((listPriceCad == "0") || (listPriceCad == "0.0000") || (listPriceCad == "") || (listPriceCad == "0.00")))
                    {
                        return "";
                    }
                    else
                    {
                        return "Pricing Group field cannot be left empty if there is a List Price USD value or a List Price CAD value provided for this item.";
                    }
                }
                if (!GlobalData.PricingGroups.Contains(value) && required)
                {
                    return "Pricing Group " + OdinServices.Properties.Resources.Error_NoMatch;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates Print on Demand field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidatePrintOnDemand(string value, int prodType)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            else
            {
                if (value == "Y" || value == "N")
                {
                    return "";
                }
                else return "Print On Demand " + OdinServices.Properties.Resources.Error_YorN;
            }
        }

        /// <summary>
        ///     Validates Peoplesoft Status field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidatePsStatus(string value, string prodType)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (!GlobalData.PsStatuses.Contains(value))
                {
                    return "PS Status " + OdinServices.Properties.Resources.Error_NoMatch;
                }
            }
            else if (prodType == "Item")
            {
                return "PS Status " + OdinServices.Properties.Resources.Error_Required;
            }
            return "";
        }

        /// <summary>
        ///     Validates the SAT code value. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ValidateSatCode(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 20)
                {
                    return "SAT Code " + OdinServices.Properties.Resources.Error_LengthMax + "20 characters.";
                }
            }
            return "";
        }

        /// <summary>
        ///     Sell On field Validation field. Returns error message string or "" if no error exists.
        /// </summary>
        public string ValidateSellOnValue(string value, string ecomFlag, string type)
        {
            /*
            if (ecomFlag != null)
            {
                if (ecomFlag != "Y" && value == "Y")
                {
                    return "Sell on Ecommerce flag must be set to Y if " + type + " is set to Y.";
                }
            }
            */
            if (string.IsNullOrEmpty(value))
            {
                return "Sell On " + type + " " + OdinServices.Properties.Resources.Error_Required;
            }
            if ((value != "Y") && (value != "N"))
            {
                return "Sell On " + type + " " + OdinServices.Properties.Resources.Error_YorN;
            }
            return "";
        }

        /// <summary>
        ///     Validate Short Description field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="hasWeb"></param>
        /// <returns></returns>
        /// 
        public string ValidateShortDescription(string value)
        {
            return "";
        }

        /// <summary>
        ///     Validate Size field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="hasWeb"></param>
        /// <returns></returns>
        public string ValidateSize(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (CheckSpecialChar(value))
                {
                    return "Size " + OdinServices.Properties.Resources.Error_SpecialChars;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates Standard Cost field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dacusd">Default Actual Cost USD</param>
        /// <param name="daccad">Default Actual Cost CAD</param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateStandardCost(string value, int prodType)
        {

            bool required = (prodType == 2) ? false : true;

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    return "Standard Cost " + OdinServices.Properties.Resources.Error_Required;
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Standard Cost " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates Stats Code field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="listPriceUS">USD List Price</param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateStatsCode(string value, string listPriceUS, int prodType)
        {
            bool required = (prodType == 2) ? false : true;

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    if (listPriceUS == "0" || listPriceUS == "0.00" || listPriceUS == "0.0000")
                    {
                        return "";
                    }
                    else
                    {
                        return "Stats Code " + OdinServices.Properties.Resources.Error_Required;                       
                    }
                }
                if (value.Length > 30)
                {
                    return "Stats Code " + OdinServices.Properties.Resources.Error_LengthMax + "30 characters.";
                }
                
                if(!GlobalData.StatsCodes.ContainsKey(value))
                {
                    return "Stats Code does not match any values set up in the database.";
                }
                
            }
            return "";
        }

        /// <summary>
        ///     Validates Tariff Code field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateTariffCode(string value, int prodType)
        {

            bool required = (prodType == 2) ? false : true;

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    return "Tariff Code " + OdinServices.Properties.Resources.Error_Required;
                }
                if(!GlobalData.TariffCodes.Contains(value))
                {
                    return "Tariff Code " + OdinServices.Properties.Resources.Error_NoMatch;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validate the template Id
        /// </summary>
        /// <param name="value"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public string ValidateTemplateId(string value, string status)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "Template Id is empty. Please select a name before saving.";
            }
            if (value.Length > 255)
            {
                return "TemplateId " + OdinServices.Properties.Resources.Error_LengthMax + "255 characters.";
            }
            if (status != "Update")
            {
                if (GlobalData.TemplateNames.Contains(value))
                {
                    return "Template Id " + value + " already exists. Please select a different name.";
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the item territory field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="listPriceUS"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateTerritory(string value, string listPriceUS, int prodType)
        {

            bool required = (prodType == 2) ? false : true;

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    if (listPriceUS == "0" || listPriceUS == "0.00" || listPriceUS == "0.0000")
                    {
                        return "";
                    }
                    else
                    {
                        return "Territory " + OdinServices.Properties.Resources.Error_Required;
                    }
                }
                string[] x = value.Split('/');
                foreach (string y in x)
                {
                    if (!GlobalData.Territories.Contains(y.Trim()))
                    {
                        return "Territory value " + y + " " + OdinServices.Properties.Resources.Error_NoMatch;
                    }
                }
                return "";
            }
            return "";
        }

        /// <summary>
        ///     Validates the Title field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="hasWeb"></param>
        /// <returns></returns>
        public string ValidateTitle(string value, bool hasWeb)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 266)
                {
                    return "Title " + OdinServices.Properties.Resources.Error_LengthMax + "266 characters.";
                }
            }
            if (hasWeb)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Title " + OdinServices.Properties.Resources.Error_RequiredWeb;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates UDEX field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="group">item's Item Group</param>
        /// <param name="listPriceUS">USD List Price</param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateUdex(string value, int prodType)
        {
            if (prodType == 0)
            {
                return "";
            }
            if(string.IsNullOrEmpty(value))
            {
                return "";
            }
            if (!(string.IsNullOrEmpty(value)))
            {
                if (value.Length > 30)
                {
                    return "Udex " + OdinServices.Properties.Resources.Error_LengthMax + "30 characters.";
                }
                else return "";
            }
            return "";
        }

        /// <summary>
        ///     Validates UPC field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="listpriceUsd">USD List Price</param>
        /// <param name="prodFormat">Product Fromat</param>
        /// <param name="ean">EAN</param>
        /// <param name="productLine">Product Line</param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public string ValidateUpc(string value, string itemId, string status, string listpriceUsd, string prodFormat, string prodGroup, string prodLine, string ean, string ecommerceUpc, int prodType)
        {
            if (string.IsNullOrEmpty(value))
            {
                if (string.IsNullOrEmpty(listpriceUsd) || !string.IsNullOrEmpty(ean))
                {
                    return "";
                }
                else if (prodLine == "Direct Medical Mail")
                {
                    return "";
                }
                else if (listpriceUsd == "0" || listpriceUsd == "0.00" || listpriceUsd == "0.0000")
                {
                    return "";
                }
                else if (GlobalData.UpcProductFormatExceptions.Contains(prodFormat.Trim()))
                {
                    return "";
                }
                else return "UPC " + OdinServices.Properties.Resources.Error_Required + " (Required if the List Price USD is set to something other than 0 or if the Ean field is left blank.)";
            }
            else
            {
                if (!DbUtil.IsNumber(value))
                {
                    return "UPC field " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
                if ((value.Length != 8) && (value.Length != 12))
                {
                    return "UPC has an invalid length. UPC value can only have a length of 8 or 12 characters.";
                }
                if (string.IsNullOrEmpty(prodGroup) || string.IsNullOrEmpty(prodLine) || string.IsNullOrEmpty(prodFormat))
                {
                    return "Product Line, Product Group & Product Format are required values when UPC is provided.";
                }
                if (value == ecommerceUpc)
                {
                    return "Item's Upc and Ecommerce Upc cannot share the same value.";
                }
                List<string> matchId = CheckDuplicateUPCs(itemId, value, status);
                if (matchId.Count > 0)
                {
                    string ids = "";
                    foreach (string id in matchId)
                    {
                        ids += id + ", ";
                    }
                    return "UPC contains a duplicate ID. The following items already contain this upc or ecommerce upc: " + ids;
                }
            }
            return "";
        }
        
        /// <summary>
        ///     Validate item website price field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <returns></returns>
        public string ValidateWebsitePrice(string value, bool hasWeb)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > 9)
                {
                    return "Website Price " + OdinServices.Properties.Resources.Error_LengthMax + "9 characters.";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Website Price " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
            }
            if(hasWeb)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return "Website Price " + OdinServices.Properties.Resources.Error_RequiredWeb;
                }
                if (hasWeb && (value == "0" || value == "0.00" || value == "0.0000"))
                {
                    return "Website Price must contain a value greater than 0.";
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the item weight field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns>Error message or "" if value is valid</returns>
        public string ValidateWeight(string value, int prodType)
        {
            bool required = (prodType == 2) ? false : true;

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    return "Weight field " + OdinServices.Properties.Resources.Error_Required;
                }
                if (value.Length > 8)
                {
                    return "Weight field " + OdinServices.Properties.Resources.Error_LengthMax + "8 characters.";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Weight field " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
                if (Convert.ToDouble(value) < 0.00001)
                {
                    return "Weight field " + OdinServices.Properties.Resources.Error_0;
                }
            }
            return "";
        }

        /// <summary>
        ///     Validates the item width field. Returns error message string or "" if no error exists.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="prodType"></param>
        /// <returns>Error message or "" if value is valid</returns>
        public string ValidateWidth(string value, int prodType)
        {
            bool required = (prodType == 2) ? false : true;

            if (!string.IsNullOrEmpty(value) || required)
            {
                if (string.IsNullOrEmpty(value) && required)
                {
                    return "Width field " + OdinServices.Properties.Resources.Error_Required;
                }
                if (value.Length > 8)
                {
                    return "Width field " + OdinServices.Properties.Resources.Error_LengthMax + "8 characters.";
                }
                if (!DbUtil.IsNumber(value))
                {
                    return "Width field " + OdinServices.Properties.Resources.Error_NonNumeric;
                }
                if (Convert.ToDouble(value) < 0.00001)
                {
                    return "Width field " + OdinServices.Properties.Resources.Error_0;
                }
            }
            return "";
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
