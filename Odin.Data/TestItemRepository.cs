using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Odin.Data
{
    public class TestItemRepository : IItemRepository
    {
        #region Private Properties


        /// <summary>
        ///     Gets or sets a collection of Product Id Translations
        /// </summary>
        private ObservableCollection<ChildElement> TestProductIdTranslations
        {
            get { return _testProductIdTranslations; }
            set { _testProductIdTranslations = value; }
        }
        private ObservableCollection<ChildElement> _testProductIdTranslations = new ObservableCollection<ChildElement>();

        /// <summary>
        ///     Gets or sets a collection of test items
        /// </summary>
        private ObservableCollection<ItemObject> TestItemCollection
        {
            get { return _testItemCollection; }
            set { _testItemCollection = value; }
        }
        private ObservableCollection<ItemObject> _testItemCollection = new ObservableCollection<ItemObject>();

        #endregion // Private Properties

        #region Private Methods

        #region Private Retrieval Methods

        /// <summary>
        ///     Retrieves Accounting Group values from DB
        /// </summary>
        /// <returns>List of Accounting Group values</returns>
        private List<string> RetrieveAccountingtGroupList()
        {
            return new List<string>(){
                "AccountingGroup1",
                "AccountingGroup2",
                "AccountingGroup3"
            };
        }

        /// <summary>
        ///     Retrieves a list of child elements (BillOfMaterials) from PS_EN_BOM_COMPS for the given ItemId
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        private List<ChildElement> RetrieveBillOfMaterials(string itemId)
        {
            return new List<ChildElement>(new ChildElement[] {
                new ChildElement("ComponentId1", "ItemId1", 0),
                new ChildElement("ComponentId2", "ItemId1", 2),
                new ChildElement("ComponentId1", "ItemId2", 2),
                new ChildElement("ComponentId2", "ItemId2", 0)
                });

        }

        /// <summary>
        ///     Retrieves the category id for the given itemCategory
        /// </summary>
        /// <returns>List of Accounting Group values</returns>
        private string RetriveCategoryId(string itemCategory)
        {
            foreach (KeyValuePair<string, string> x in GlobalData.WebCategoryList)
            {
                if (x.Value == itemCategory)
                {
                    return x.Key;
                }
            }
            return "";
        }

        /// <summary>
        ///     Retrieves list of the Cost Profile Groups from the DB
        /// </summary>
        /// <returns>List of Cost Profile Groups</returns>
        private List<string> RetrieveCostProfileGroups()
        {
            return new List<string>() {
                "CostProfileGroup1",
                "CostProfileGroup2",
                "CostProfileGroup3",
                "CostProfileGroup4",
            };
        }

        /// <summary>
        ///     Retrieves list of countries of origin from db
        /// </summary>
        /// <returns>List of countries of origin</returns>
        private Dictionary<string, string> RetrieveCountriesOfOrigin()
        {
            return new Dictionary<string, string>() {
                { "CO1", "CountryOfOrigin1"},
                { "CO2", "CountryOfOrigin2"},
                { "CO3", "CountryOfOrigin3"},
                { "CO4", "CountryOfOrigin4"},
                { "CO5", "CountryOfOrigin5"},
                { "CO6", "CountryOfOrigin6"}
            };
        }

        /// <summary>
        ///     Returns the coresponding value for the given key from the customerIdConversion list
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string RetrieveCustomerId(string value)
        {
            foreach (KeyValuePair<string, string> x in GlobalData.CustomerIdConversions)
            {
                if (x.Key == value)
                {
                    return x.Value;
                }
            }
            return "";
        }

        /// <summary>
        ///     Retrieves a key value pair list of customer names and their coresponding customer ID from the 
        ///     ODIN_CUSTOMER_CONVERSION table.
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> RetrieveCustomerIdConversionsList()
        {
            return new Dictionary<string, string>() {
                { "1", "Customer1" },
                { "2", "Customer2" },
                { "3", "Customer3" }
            };
        }

        /// <summary>
        ///     Retrieves the Current Cost (Default Actual Cost) from PS_BU_ITEMS_INV table
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="businessUnit"></param>
        /// <returns></returns>
        private string RetrieveDefaultActualCost(string itemId, string businessUnit)
        {
            switch (itemId)
            {
                case "ItemId1":
                    if (businessUnit == "TRUS1")
                    {
                        return "DacUsd1";
                    }
                    else
                        return "DacCan1";
                case "ItemId2":
                    if (businessUnit == "TRUS1")
                    {
                        return "DacUsd2";
                    }
                    else
                        return "DacCan2";
            }
            return "";
        }

        /// <summary>
        ///     Retrieves a dictionary of item category name / ids from PS_ITM_CAT_TBL
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> RetrieveItemCategories()
        {
            return new Dictionary<string, string>() {
                { "1", "ItemCategory1"},
                { "2", "ItemCategory2"},
                { "3", "ItemCategory3"}
            };
        }

        /// <summary>
        ///     Get list of appropriate External Id types for Amazon Products
        /// </summary>
        /// <returns>List of External Id Types</returns>
        private List<string> RetrieveEcommerceExternalIdTypeList()
        {
            return new List<string>() {
                "",
                "ISBN",
                "EAN",
                "UPC",
                "UPC (12-digits)"
            };
        }

        /// <summary>
        ///     Retrieves a list of all ecommerce upc/item id key value pairs
        /// </summary>
        /// <param name="UPC"></param>
        /// <returns>list of existing item Ids with matching UPCs</returns>
        private Dictionary<string, string> RetrieveEcommerceUPCs()
        {
            return new Dictionary<string, string>() {
                { "EcomUpc1", "ItemId1"},
                { "EcomUpc2", "ItemId2"},
                { "EcomUpc3", "ItemId3"}
            };
        }

        /// <summary>
        ///     Retrieves the max effdt from PS_INV_ITEMS for the given item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        private DateTime RetrieveEffdt(string itemId)
        {
            return DateTime.Now;
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
            return new List<string>() {
                "Exception1",
                "Exception2",
                "Exception3"
            };
        }

        /// <summary>
        ///     Retrieves a list of local image paths for the given item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public List<string> RetrieveImagePaths(string itemId)
        {
            return new List<string>();
        }

        /// <summary>
        ///     Retrieve list of InvItemGroups for dropdown and validation form
        /// </summary>
        /// <returns>List of InvItemGroup values</returns>
        private List<string> RetrieveItemGroups()
        {
            return new List<string>() {
                "ItemGroup1",
                "ItemGroup2",
                "ItemGroup3",
                "ItemGroup4"
            };
        }

        /// <summary>
        ///     Retrieves a list of all existing item ids
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private List<string> RetrieveItemIds()
        {
            return new List<string>() {
                "ItemId1",
                "ItemId2",
                "ItemId3",
                "ItemId4",
                "ItemId5"
            };
        }

        /// <summary>
        ///     Retrieves all the language cd values from PS_ITEM_LANGUAGE and returns them as a string
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        private string RetrieveLanguage(string itemId)
        {
            string result = string.Empty;

            List<string> itemLanguages = new List<string>();

            switch (itemId)
            {
                case "ItemId1":
                    itemLanguages.Add("ENG");
                    itemLanguages.Add("SPA");
                    itemLanguages.Add("FRA");
                    break;
                case "ItemId2":
                    itemLanguages.Add("ENG");
                    itemLanguages.Add("FRA");
                    break;
                case "ItemId3":
                    itemLanguages.Add("ENG");
                    break;
            }


            foreach (string itemLanguage in itemLanguages)
            {
                if (result != string.Empty)
                {
                    result += ", ";
                }
                result += itemLanguage;
            }
            return result;
        }

        /// <summary>
        ///     Retrieve list of available languages
        /// </summary>
        /// <returns>List of web languages</returns>
        private List<string> RetrieveLanguages()
        {
            return new List<string>() {
                "ENG",
                "FRA",
                "SPA"
            };
        }

        /// <summary>
        ///     Retrieve list of Licneses from ODIN_WEB_LICENSE
        /// </summary>
        /// <returns>List of InvItemGroup values</returns>
        private List<string> RetrieveLicenseList()
        {
            return new List<string>(){
                "License1",
                "License2",
                "License3"
            };

        }

        /// <summary>
        ///     Retreives the List price from PS_PROD_PRICE for the given itemid/businessUnit/currencycode
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="businessUnit"></param>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
        private string RetrieveListPrice(string itemId, string businessUnit, string currencyCode)
        {
            switch (itemId)
            {
                case "ItemId1":
                    if (businessUnit == "TRUS1")
                    {
                        return "ListPriceUsd1";
                    }
                    else
                        return "ListPriceCad1";
                case "ItemId2":
                    if (businessUnit == "TRUS1")
                    {
                        return "ListPriceUsd2";
                    }
                    else
                        return "ListPriceCad2";
            }
            return "";
        }

        /// <summary>
        ///     Retrieves List of Meta Descriptions
        /// </summary>
        /// <returns></returns>
        private List<string> RetrieveMetaDescriptionList()
        {
            return new List<string>(){
                "MetaDescription1",
                "MetaDescription2",
                "MetaDescription3"
            };
        }

        /// <summary>
        ///     Retrieves the Source Code from PS_BU_ITEMS_INV for the given itemid/businessUnit
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="businessUnit"></param>
        /// <returns></returns>
        private string RetrieveMfgSource(string itemId, string businessUnit)
        {
            switch (itemId)
            {
                case "ItemId1":
                    if (businessUnit == "TRUS1")
                    {
                        return "MfgSource1";
                    }
                    else
                        return "MfgSource1";
                case "ItemId2":
                    if (businessUnit == "TRUS1")
                    {
                        return "MfgSource2";
                    }
                    else
                        return "MfgSource2";
            }
            return "";
        }

        /// <summary>
        ///     Retreives the Msrp from PS_PROD_PRICE for the given itemid/businessUnit/currencycode
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="businessUnit"></param>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
        private string RetrieveMsrp(string itemId, string businessUnit, string currencyCode)
        {
            if (itemId == "ItemId1" && businessUnit == "BusinessUnit1" && currencyCode == "CurrencyCode1")
            {
                return "MSRP1";
            }
            if (itemId == "ItemId2" && businessUnit == "BusinessUnit2" && currencyCode == "CurrencyCode2")
            {
                return "MSRP2";
            }
            return "";
        }

        /// <summary>
        ///     Retrieves Pricing Group values from DB
        /// </summary>
        /// <returns>List of Pricing Group values</returns>
        private List<string> RetrievePriceGroupList()
        {
            return new List<string>() {
                "",
                "PriceGroup1",
                "PriceGroup2",
                "PriceGroup3"
            };
        }

        /// <summary>
        ///     Retrieves item category values form prodcatgrytabl for drop down options
        /// </summary>
        /// <returns>List of item category values</returns>
        private List<string> RetrieveProductCategories()
        {
            return new List<string>() {
                "ProductCategory1",
                "ProductCategory2",
                "ProductCategory3"
            };
        }

        /// <summary>
        ///     Retrieves product format values from PS_PRODUCT_FORMATS
        /// </summary>
        /// <returns>list of product formats</returns>
        private List<ProductFormat> RetrieveProductFormatList()
        {
            return new List<ProductFormat>(){
                new ProductFormat("ProductFormat1", "ProductLine1", "ProductGroup1"),
                new ProductFormat("ProductFormat2", "ProductLine2", "ProductGroup2"),
                new ProductFormat("ProductFormat3", "ProductLine3", "ProductGroup3")
            };
        }

        /// <summary>
        ///     Retrieves the Product Group from PS_PROD_PGRP_LNK
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="prodGrpType"></param>
        /// <returns></returns>
        private string RetrieveProductGroup(string itemId, string prodGrpType)
        {
            if (itemId == "ItemId1") { return "ProductGroup1"; }
            if (itemId == "ItemId2") { return "ProductGroup2"; }
            if (itemId == "ItemId3") { return "ProductGroup3"; }
            return "";
        }

        /// <summary>
        ///     Retrieves list of Product Groups
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private List<string> RetrieveProductGroupList()
        {
            return new List<string>() {
                "ProductGroup1",
                "ProductGroup2",
                "ProductGroup3",
                "ProductGroup4"
            };
        }

        /// <summary>
        ///     Retrieves a list of child elements (ProductIdTranslations) from PS_EN_BOM_COMPS for the given ItemId
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        private List<ChildElement> RetrieveProductIdTranslations(string itemId)
        {
            List<ChildElement> Values = new List<ChildElement>();

            return Values;
        }

        /// <summary>
        ///     Retrieves list of Product Id Translations for a given item
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private List<ChildElement> RetrieveProductIdTranslationList()
        {
            return new List<ChildElement>(){
                new ChildElement("ChildId1", "ItemId1", 3),
                new ChildElement("ChildId2", "ItemId1", 2),
                new ChildElement("ChildId3", "ItemId1", 1),
                new ChildElement("ChildId1", "ItemId2", 3)
            };
        }

        /// <summary>
        ///     Retrieve list of all product lines from PS_PRODUCT_LINES with product group keys
        /// </summary>
        /// <returns>List of all product lines</returns>
        private List<KeyValuePair<string, string>> RetrieveProductLines()
        {
            return new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("ProductGroup1", "ProductLine1"),
                new KeyValuePair<string, string>( "ProductGroup2", "ProductLine2" ),
                new KeyValuePair<string, string>("ProductGroup3", "ProductLine3")
            };
        }

        /// <summary>
        ///     Retrieves all property values from OdinWebLicense with license keys
        /// </summary>
        /// <returns></returns>
        private List<KeyValuePair<string, string>> RetrieveProperties()
        {
            return new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("License1", "Property1"),
                new KeyValuePair<string, string>("License1", "Property2"),
                new KeyValuePair<string, string>("License2", "Property1"),
                new KeyValuePair<string, string>("License2", "Property2"),
                new KeyValuePair<string, string>("License2", "Property3")
            };
        }

        /// <summary>
        ///     Retrieve list of ps Statuses from db.
        /// </summary>
        /// <returns>List of product lines</returns>
        private List<string> RetrievePsStatuses()
        {
            return new List<string>() {
                "PsStatus1",
                "PsStatus2",
                "PsStatus3",
                "PsStatus4"
            };
        }

        /// <summary>
        ///     Retrieves a list of special characters that are not allowed for peoplesoft fields
        /// </summary>
        /// <returns>list of special characters</returns>
        private List<string> RetrieveSpecialCharacters()
        {
            return new List<string>() {
                ""
            };
        }

        /// <summary>
        ///     Retrieves a list of Request statuses
        /// </summary>
        /// <returns></returns>
        private List<string> RetrieveRequestStatuses()
        {
            return new List<string>() {
                "Pending",
                "Completed",
                "Canceled",
                "Incomplete"
            };
        }

        /// <summary>
        ///     Retrieves the Sell on flag for the given customer / item
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        private string RetrieveSendInventoryFlag(string itemId, string company)
        {
            if (itemId == "ItemId1" && company == "Company1") { return "Flag1"; }
            if (itemId == "ItemId2" && company == "Company2") { return "Flag2"; }
            if (itemId == "ItemId3" && company == "Company3") { return "Flag3"; }
            return "";
        }

        /// <summary>
        ///     Retrieves all the Tariff Code values from the DB
        /// </summary>
        /// <returns>List of tarriff codes</returns>
        private List<string> RetrieveTarriffCodeList()
        {
            return new List<string>() {
                "TarriffCode1",
                "TarriffCode2",
                "TarriffCode3",
                "TarriffCode4"
            };
        }

        /// <summary>
        ///     Retrieve list of available territories
        /// </summary>
        /// <returns>List of territories</returns>
        private List<string> RetrieveTerritories()
        {
            return new List<string>() {
                "Territory1",
                "Territory2",
                "Territory3"
            };
        }

        /// <summary>
        ///     Retrieves all the Territory values from PS_ITEM_TERRITORY and returns them as a string
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        private string RetrieveTerritory(string itemId)
        {
            string result = string.Empty;
            switch (itemId)
            {
                case "ItemId1":
                    return "Territory1";
                case "ItemId2":
                    return "Territory2";
                case "ItemId3":
                    return "Territory3";
            }
            return "";
        }

        /// <summary>
        ///     Retrieves a dictionary of all tool tips
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> RetrieveToolTips()
        {
            return new Dictionary<string, string>() {
                {"ToolTipName1", "ToolTipValue1"},
                {"ToolTipName2", "ToolTipValue2"},
                {"ToolTipName3", "ToolTipValue3"},
                {"ToolTipName4", "ToolTipValue4"}
            };
        }

        /// <summary>
        ///     Retrieve a list of user names
        /// </summary>
        /// <returns></returns>
        private List<string> RetrieveUserNames()
        {
            return new List<string>() {
                "User1",
                "User2",
                "User3"
            };            
        }

        /// <summary>
        ///     Retrieve a list of user roles
        /// </summary>
        /// <returns></returns>
        private List<string> RetrieveUserRoles()
        {
            return new List<string>(){
                "",
                "UserRole1",
                "UserRole2",
                "UserRole3"
            };
            
        }

        /// <summary>
        ///     Retrieves a list of all existing upc / item id & ecommerceUpc / item id pairs
        /// </summary>
        /// <returns></returns>
        private List<KeyValuePair<string, string>> RetrieveUpcs()
        {
            return new List<KeyValuePair<string, string>>(){
                new KeyValuePair<string, string>("Upc1", "ItemId1"),
                new KeyValuePair<string, string>("Upc2", "ItemId2"),
                new KeyValuePair<string, string>("Upc3", "ItemId3"),
                new KeyValuePair<string, string>("EcomUpc1", "ItemId1"),
                new KeyValuePair<string, string>("EcomUpc2", "ItemId2"),
                new KeyValuePair<string, string>("EcomUpc3", "ItemId3")
            };
        }

        /// <summary>
        ///     Retrieves a dictionary of categories and their coresponding ids
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> RetrieveWebCategoryList()
        {
            return new Dictionary<string, string>() { 
                { "1", "Category1"},
                { "2", "Category2"},
                { "3", "Category3"},
                { "4", "Category4"},
                { "5", "Category5"}
            };
        }

        #endregion // Private Retrieval Methods

        #region Private Test Methods
        
        /// <summary>
        ///     Adds test items to TestItemCollections
        /// </summary>
        private void PopulateTestItems()
        {
            ItemObject item = new ItemObject()
            {
                Status = "Update",
                AltImageFile1 = "AltImageFile1A",
                AltImageFile2 = "AltImageFile2A",
                AltImageFile3 = "AltImageFile3A",
                AltImageFile4 = "AltImageFile4A",
                AccountingGroup = "AccountingGroupA",
                BillOfMaterials = new List<ChildElement>(),
                CasepackHeight = "CasepackHeightA",
                CasepackLength = "CasepackLengthA",
                CasepackQty = "CasepackQtyA",
                CasepackUpc = "CasepackUpcA",
                CasepackWidth = "CasepackWidthA",
                CasepackWeight = "CasepackWeightA",
                Category = "1,2,3",
                Category2 = "A",
                Category3 = "A",
                Color = "ColorA",
                Copyright = "CopyrightA",
                CountryOfOrigin = "CountryOfOriginA",
                CostProfileGroup = "CostProfileGroupA",
                DefaultActualCostUsd="DefaultActualCostUsdA",
                DefaultActualCostCad="DefaultActualCostCadA",
                Description = "DescriptionA",
                DirectImport = "DirectImportA",
                Duty = "DutyA",
                Ean = "EanA",
                EcommerceAsin = "AAsinA",
                EcommerceBullet1 = "ABullet1A",
                EcommerceBullet2 = "ABullet2A",
                EcommerceBullet3 = "ABullet3A",
                EcommerceBullet4 = "ABullet4A",
                EcommerceBullet5 = "ABullet5A",
                EcommerceComponents = "AComponentsA",
                EcommerceCost = "ACostA",
                EcommerceExternalId = "AExternalIdA",
                EcommerceExternalIdType = "AExternalIdTypeA",
                EcommerceItemHeight = "AItemHeightA",
                EcommerceItemLength = "AItemLengthA",
                EcommerceItemName = "AItemNameA",
                EcommerceItemWeight = "AItemWeightA",
                EcommerceItemWidth = "AItemWidthA",
                EcommerceModelName = "AModelNameA",
                EcommercePackageHeight = "APackageHeightA",
                EcommercePackageLength = "APackageLengthA",
                EcommercePackageWeight = "APackageWeightA",
                EcommercePackageWidth = "APackageWidthA",
                EcommercePageQty = "APageQtyA",
                EcommerceProductCategory = "AProductCategoryA",
                EcommerceProductDescription = "AProductDescriptionA",
                EcommerceProductSubcategory = "AProductSubcategoryA",
                EcommerceManufacturerName = "AManufacturerNameA",
                EcommerceMsrp = "AMsrpA",
                EcommerceGenericKeywords = "ASearchTermsA",
                EcommerceSize = "ASizeA",
                EcommerceUpc = "AUpcA",
                Gpc = "GpcA",
                Height = "HeightA",
                ImagePath = "ImagePathA",
                InnerpackHeight = "InnerpackHeightA",
                InnerpackLength = "InnerpackLengthA",
                InnerpackQuantity = "InnerpackQuantityA",
                InnerpackUpc = "InnerpackUpcA",
                InnerpackWidth = "InnerpackWidthA",
                InnerpackWeight = "InnerpackWeightA",
                InStockDate = "InStockDateA",
                Isbn = "IsbnA",
                ItemCategory = "ItemCategoryA",
                ItemFamily = "ItemFamilyA",
                ItemGroup = "ItemGroupA",
                ItemId = "ItemIdA",
                ItemKeywords = "ItemKeywordsA",
                Language = "LanguageA",
                Length = "LengthA",
                License = "LicenseA",
                LicenseBeginDate = "LicenseBeginDateA",
                ListPriceCad = "ListPriceCadA",
                ListPriceUsd = "ListPriceUsdA",
                ListPriceMxn="ListPriceMxnA",
                MetaDescription = "MetaDescriptionA",
                MfgSource="MfgSourceA",
                Msrp="MsrpUsdA",
                MsrpCad="MsrpCadA",
                MsrpMxn="MsrpMxnA",
                OnSite = "Y",
                ProductFormat ="ProductFormatA",
                ProductGroup="ProductGroupA",
                ProductIdTranslation = new List<ChildElement>(),
                ProductLine="ProductLineA",
                ProductQty="ProductQuantityA",
                Property="PropertyA",
                PricingGroup="PricingGroupA",
                PrintOnDemand="PrintOnDemandA",
                PsStatus="PsStatusA",
                SatCode="SatCodeA",
                SellOnAllPosters="SellOnAllPostersA",
                SellOnAmazon="SellOnAmazonA",
                SellOnFanatics ="SellOnFanaticsA",
                SellOnGuitarCenter="SellOnGuitarCenterA",
                SellOnHayneedle="SellOnHayneedleA",
                SellOnTarget="SellOnTargetA",
                SellOnTrends="SellOnTrendsA",
                SellOnWalmart="SellOnWalmartA",
                SellOnWayfair="SellOnWayfairA",
                ShortDescription="ShortDescriptionA",
                Size="SizeA",
                StandardCost="StandardCostA",
                StatsCode="StatsCodeA",
                TariffCode="TariffCodeA",
                Territory="TerritoryA",
                Title="TitleA",
                Udex="UdexA",
                Upc="UpcA",
                WebsitePrice="WebsitePriceA",
                Weight = "WeightA",
                Width = "WidthA"
            };
            item.EcommerceCountryofOrigin = "CountryOfOriginB";
            item.Status = "Update";
            item.ResetUpdate();
            this.TestItemCollection.Add(item);

            ItemObject item2 = new ItemObject()
            {
                Status = "Update",
                AltImageFile1 = "AltImageFile1B",
                AltImageFile2 = "AltImageFile2B",
                AltImageFile3 = "AltImageFile3B",
                AltImageFile4 = "AltImageFile4B",
                AccountingGroup = "AccountingGroupB",
                BillOfMaterials = new List<ChildElement>(),
                CasepackHeight = "CasepackHeightB",
                CasepackLength = "CasepackLengthB",
                CasepackQty = "CasepackQtyB",
                CasepackUpc = "CasepackUpcB",
                CasepackWidth = "CasepackWidthB",
                CasepackWeight = "CasepackWeightB",
                Category = "4,5,6",
                Category2 = "B",
                Category3 = "B",
                Color = "ColorB",
                Copyright = "CopyrightB",
                CountryOfOrigin = "CountryOfOriginB",
                CostProfileGroup = "CostProfileGroupB",
                DefaultActualCostUsd = "DefaultActualCostUsdB",
                DefaultActualCostCad = "DefaultActualCostCadB",
                Description = "DescriptionB",
                DirectImport = "DirectImportB",
                Duty = "DutyB",
                Ean = "EanB",
                EcommerceAsin = "AAsinB",
                EcommerceBullet1 = "ABullet1B",
                EcommerceBullet2 = "ABullet2B",
                EcommerceBullet3 = "ABullet3B",
                EcommerceBullet4 = "ABullet4B",
                EcommerceBullet5 = "ABullet5B",
                EcommerceComponents = "AComponentsB",
                EcommerceCost = "ACostB",
                EcommerceExternalId = "AExternalIdB",
                EcommerceExternalIdType = "AExternalIdTypeB",
                EcommerceItemHeight = "AItemHeightB",
                EcommerceItemLength = "AItemLengthB",
                EcommerceItemWeight = "AItemWeightB",
                EcommerceItemWidth = "AItemWidthB",
                EcommerceModelName = "AModelNameB",
                EcommercePackageHeight = "APackageHeightB",
                EcommercePackageLength = "APackageLengthB",
                EcommercePackageWeight = "APackageWeightB",
                EcommercePackageWidth = "APackageWidthB",
                EcommercePageQty = "APageQtyB",
                EcommerceProductCategory = "AProductCategoryB",
                EcommerceProductDescription = "AProductDescriptionB",
                EcommerceProductSubcategory = "AProductSubcategoryB",
                EcommerceManufacturerName = "AManufacturerNameB",
                EcommerceMsrp = "AMsrpB",
                EcommerceGenericKeywords = "ASearchTermsB",
                EcommerceSize = "ASizeB",
                EcommerceUpc = "AUpcB",
                Gpc = "GpcB",
                Height = "HeightB",
                ImagePath = "ImagePathB",
                InnerpackHeight = "InnerpackHeightB",
                InnerpackLength = "InnerpackLengthB",
                InnerpackQuantity = "InnerpackQuantityB",
                InnerpackUpc = "InnerpackUpcB",
                InnerpackWidth = "InnerpackWidthB",
                InnerpackWeight = "InnerpackWeightB",
                InStockDate = "InStockDateB",
                Isbn = "IsbnB",
                ItemCategory = "ItemCategoryB",
                ItemFamily = "ItemFamilyB",
                ItemGroup = "ItemGroupB",
                ItemId = "ItemIdB",
                ItemKeywords = "ItemKeywordsB",
                Language = "LanguageB",
                Length = "LengthB",
                License = "LicenseB",
                LicenseBeginDate = "LicenseBeginDateB",
                ListPriceCad = "ListPriceCadB",
                ListPriceUsd = "ListPriceUsdB",
                ListPriceMxn = "ListPriceMxnB",
                MetaDescription = "MetaDescriptionB",
                MfgSource = "MfgSourceB",
                Msrp = "MsrpUsdB",
                MsrpCad = "MsrpCadB",
                MsrpMxn = "MsrpMxnB",
                ProductFormat = "ProductFormatB",
                ProductGroup = "ProductGroupB",
                ProductIdTranslation = new List<ChildElement>(),
                ProductLine = "ProductLineB",
                ProductQty = "ProductQuantityB",
                Property = "PropertyB",
                PricingGroup = "PricingGroupB",
                PrintOnDemand = "PrintOnDemandB",
                PsStatus = "PsStatusB",
                SatCode = "SatCodeB",
                SellOnAllPosters = "SellOnAllPostersB",
                SellOnAmazon = "SellOnAmazonB",
                SellOnAmazonSellerCentral = "SellOnAmazonSellerCentralB",
                SellOnEcommerce = "SellOnEcommerceB",
                SellOnFanatics = "SellOnFanaticsB",
                SellOnGuitarCenter = "SellOnGuitarCenterB",
                SellOnHayneedle = "SellOnHayneedleB",
                SellOnTarget = "SellOnTargetB",
                SellOnTrends = "SellOnTrendsB",
                SellOnWalmart = "SellOnWalmartB",
                SellOnWayfair = "SellOnWayfairB",
                ShortDescription = "ShortDescriptionB",
                Size = "SizeB",
                StandardCost = "StandardCostB",
                StatsCode = "StatsCodeB",
                TariffCode = "TariffCodeB",
                Territory = "TerritoryB",
                Title = "TitleB",
                Udex = "UdexB",
                Upc = "UpcB",
                WebsitePrice = "WebsitePriceB",
                Weight = "WeightB",
                Width = "WidthB"
            };
            item2.OnSite = "Y";
            item2.EcommerceCountryofOrigin = "CountryOfOriginB";
            item2.Status = "Update";
            item2.ResetUpdate();
            this.TestItemCollection.Add(item2);
        
    }
        
        private void PopulateTestProductIdTranslations()
        {
            TestProductIdTranslations.Add(new ChildElement("ST1111", "FROMITEM1", 2));
            TestProductIdTranslations.Add(new ChildElement("ST2222", "FROMITEM1", 2));
            TestProductIdTranslations.Add(new ChildElement("ST3333", "FROMITEM1", 2));
        }
        
        /// <summary>
        ///     Runs all the test population methods
        /// </summary>
        private void SetTestValues()
        {
            GlobalData.ClearValues();
            PopulateTestItems();
            PopulateTestProductIdTranslations();
            SetWebCategoryList();
        }

        /// <summary>
        ///     Sets the GlobalData values for web categories
        /// </summary>
        private void SetWebCategoryList()
        {
            GlobalData.WebCategoryList.Add("1", "Category1");
            GlobalData.WebCategoryList.Add("2", "Category2");
            GlobalData.WebCategoryList.Add("3", "Category3");
            GlobalData.WebCategoryList.Add("4", "Category4");
            GlobalData.WebCategoryList.Add("5", "Category5");
            GlobalData.WebCategoryList.Add("6", "Category6");
        }

        #endregion // Private Test Methods

        #endregion // Private Methods

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
        }

        /// <summary>
        ///     Inserts New Category into table
        /// </summary>
        /// <param name="category"></param>
        public void InsertCategory(string category)
        {
        }

        /// <summary>
        ///     Inserts License and property into Odin_Web_License
        /// </summary>
        /// <param name="category"></param>
        public void InsertLicense(string license, string property)
        {
        }

        /// <summary>
        ///     Inserts a Meta Description value into Odin_MetaDescription
        /// </summary>
        /// <param name="metaDescription"></param>
        /// <returns></returns>
        public void InsertMetaDescription(string metaDescription)
        {
        }

        /// <summary>
        ///     Inserts Territory Value into Odin_Web_Territories
        /// </summary>
        /// <param name="category"></param>
        public void InsertTerritory(string territory)
        {
        }

        /// <summary>
        ///     Inserts a value into Odin_NewWebCategories
        /// </summary>
        /// <param name="category"></param>
        public void InsertWebCategory(string category)
        {
        }

        /// <summary>
        ///     Inserts item info into PS_ASSET_ITEM_ATTR.
        /// </summary>
        public void InsertAssetItemAttr(ItemObject item, OdinContext context)
        {
        }

        /// <summary>
        ///     Runs InsertBuItemsConfig for each business Unit
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        public void InsertBuItemsConfigAll(ItemObject item, OdinContext context)
        {
        }

        /// <summary>
        ///     Runs InsertBuItemsInv for each business Unit
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        public void InsertBuItemsInvAll(ItemObject item, OdinContext context)
        {
        }

        /// <summary>
        ///     Runs InsertBuItemUtilCd for each business Unit type
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void InsertBuItemUtilCdAll(ItemObject item, OdinContext context)
        {
        }
        
        /// <summary>
        ///     Runs InsertCmItemMethod for each business Unit
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void InsertCmItemMethodAll(ItemObject item, OdinContext context)
        {
        }

        /// <summary>
        ///     Runs InsertCustomerProductAttributes for each customer
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public void InsertCustomerProductAttributesAll(ItemObject item, OdinContext context)
        {
        }

        /// <summary>
        /// Runs InsertDefaultLocInvAll for each business Unit
        /// /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        public void InsertDefaultLocInvAll(ItemObject item, OdinContext context)
        {
        }

        /// <summary>
        ///     Insert Ecommerce Value into Database
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        public void InsertEcommerceValues(ItemObject item, OdinContext context)
        {
        }

        /// <summary>
        ///     Runs InsertEnBomComps for each bill of materials child
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        public void InsertEnBomCompsAll(ItemObject item)
        {
        }

        /// <summary>
        ///     Insert bill of materials record into PS_EN_BOM_HEADER
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        public void InsertEnBomHeader(ItemObject item, OdinContext context)
        {

        }

        /// <summary>
        ///     Runs InsertFxdBinLocInv for each business Unit
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void InsertFxdBinLocInvAll(ItemObject item, OdinContext context)
        {
            
        }

        /// <summary>
        /// Insert item info(TariffCode, ItemColor, ItemHeight, ItemLength, ItemId, Description, ItemWeight, ItemWidth, Upc) and username to PS_INV_ITEMS
        /// </summary>
        public void InsertInvItems(ItemObject item, OdinContext context)
        {
            
        }

        /// <summary>
        /// Insert item info(item Id) and username to table PS_INV_ITEM_UOM
        /// </summary>
        public void InsertInvItemUom(ItemObject item, OdinContext context)
        {
            
        }

        /// <summary>
        ///     Insert item info into table PS_ITEM_ATTRIB_EX
        /// </summary>
        public void InsertItemAttribEx(ItemObject item, OdinContext context)
        {
            
        }

        /// <summary>
        /// Insert item info into table PS_ITEM_COMPLIANCE
        /// </summary>
        public void InsertItemCompliance(ItemObject item, OdinContext context)
        {
            
        }

        /// <summary>
        ///     Removes existing langage values and runs InsertItemLanguage for each language code in the language field
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void InsertItemLanguageAll(ItemObject item)
        {
            
        }

        /// <summary>
        ///     Removes existing territory values and runs InsertItemTerritory for each territory code in the territory field
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void InsertItemTerritoryAll(ItemObject item)
        {
            
        }

        /// <summary>
        ///     Inserts item infor into ODIN_ITEM_UPDATE_RECORDS
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public void InsertItemUpdateRecord(ItemObject item, OdinContext context)
        {
            
        }

        /// <summary>
        ///     Insert item info  into PS_ITEM_WEB_INFO
        /// </summary>
        public void InsertItemWebInfo(ItemObject item, OdinContext context)
        {
            
        }

        /// <summary>
        /// Insert item info into to PS_MASTER_ITEM_TBL
        /// </summary>
        public void InsertMasterItemTbl(ItemObject item, OdinContext context)
        {
            
        }

        /// <summary>
        ///     Runs InsertPlItemAttrib for each of the business units
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void InsertPlItemAttribAll(ItemObject item, OdinContext context)
        {
            
        }

        /// <summary>
        /// Insert item info into PS_PROD_ITEM
        /// </summary>
        public void InsertProdItem(ItemObject item, OdinContext context)
        {
            
        }
        
        /// <summary>
        ///     Runs InsertProdPgrpLnk for each Product Group Type
        /// </summary>
        public void InsertProdPgrpLnkAll(ItemObject item, OdinContext context)
        {
            
        }

        /// <summary>
        ///     Runs InsertProdPrice for each business unit / ccd combination
        /// </summary>
        public void InsertProdPriceAll(ItemObject item, OdinContext context)
        {
            
        }

        /// <summary>
        ///     Runs InsertProdPriceBu for each business unit / currency code combination
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void InsertProdPriceBuAll(ItemObject item, OdinContext context)
        {
            
        }

        /// <summary>
        ///     Runs InsertProductIdTranslation for each child in the productIdTranslation field
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void InsertProductIdTranslationAll(ItemObject item, OdinContext context)
        {
            

        }

        /// <summary>
        /// Insert item info into PS_PROD_UOM
        /// </summary>
        public void InsertProdUom(ItemObject item, OdinContext context)
        {
            
        }

        /// <summary>
        ///     Insert item info into PS_PURCH_ITEM_ATTR
        /// </summary>
        public void InsertPurchItemAttr(ItemObject item, OdinContext context)
        {
            
        }

        /// <summary>
        ///     Insert item info into PS_PV_ITM_Category table
        /// </summary>
        public void InsertPvItmCategory(ItemObject item, OdinContext context)
        {
            
        }

        /// <summary>
        ///     Runs InsertUomTypeInv for each Uom type
        /// </summary>
        public void InsertUomTypeInvAll(ItemObject item, OdinContext context)
        {
            
        }

        #endregion // Public Insert Methods

        #region Public Removal Methods

        /// <summary>
        ///     Removes category from Odin_NewWebCategories
        /// </summary>
        /// <param name="category">Category to be removed</param>
        public void RemoveCategory(string categoryName)
        {
        }

        /// <summary>
        ///     Removes all license/property values from ODIN_WEB_LICENSE with the given license
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void RemoveLicense(string licenseName)
        {
        }

        /// <summary>
        ///     Removes a Meta Description from Odin_MetaDescription
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void RemoveMetaDescription(string metaDescriptionName)
        {
        }

        /// <summary>
        ///     Removes a property from Odin_Web_License
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void RemoveProperty(string licenseName, string propertyName)
        {
        }

        /// <summary>
        ///     Removes territory value from ODIN_WEB_TERRITORIES with the given territory
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void RemoveTerritory(string territory)
        {
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
            List<string> returnValues = new List<string>(new string[] {"ItemId1","ItemId2","ItemId3"});
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
            GlobalData.ExternalIdTypes = RetrieveEcommerceExternalIdTypeList();
            GlobalData.ItemCategories = RetrieveItemCategories();
            GlobalData.ItemGroups = RetrieveItemGroups();
            GlobalData.ItemIds = RetrieveItemIds();
            GlobalData.Languages = RetrieveLanguages();
            GlobalData.Licenses = RetrieveLicenseList();
            GlobalData.MetaDescriptions = RetrieveMetaDescriptionList();
            GlobalData.ProductCategories = RetrieveProductCategories();
            GlobalData.ProductFormats = RetrieveProductFormatList();
            GlobalData.ProductGoups = RetrieveProductGroupList();
            GlobalData.ProductLines = RetrieveProductLines();
            GlobalData.Properties = RetrieveProperties();
            GlobalData.PricingGroups = RetrievePriceGroupList();
            GlobalData.PsStatuses = RetrievePsStatuses();
            GlobalData.RequestStatus = RetrieveRequestStatuses();
            GlobalData.SpecialCharacters = RetrieveSpecialCharacters();
            GlobalData.TariffCodes = RetrieveTarriffCodeList();
            GlobalData.Territories = RetrieveTerritories();
            GlobalData.ToolTips = RetrieveToolTips();
            GlobalData.UpcProductFormatExceptions = RetrieveExceptions("UPC", "PRODUCT_FORMAT", "EMPTY UPC");
            GlobalData.Upcs = RetrieveUpcs();
            GlobalData.UserNames = RetrieveUserNames();
            GlobalData.UserRoles = RetrieveUserRoles();
            GlobalData.WebCategoryList = RetrieveWebCategoryList();
        }

        /// <summary>
        ///     Selects all of the info for a given item from the db. If assigned type 2 only retrieves information from db not included in spreadsheet
        /// </summary>
        /// <param name="item"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public ItemObject RetrieveItem(string idInput, int row)
        {
            foreach (ItemObject item in this.TestItemCollection)
            {
                if (item.ItemId == idInput)
                {
                    if (!string.IsNullOrEmpty(item.Category))
                    {
                        List<string> Categories = DbUtil.ParseCategories(item.Category);
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
                    item.ItemRow = row;
                    return item;
                }
            }
            return new ItemObject();
        }

        /// <summary>
        ///     Retrieves a list of search item values
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<SearchItem> RetrieveItemSearchResults(string value)
        {
            return new List<SearchItem>() {
                new SearchItem("ItemId", "Descr254")
            };
        }

        /// <summary>
        ///     Retrieves a list of user records
        /// </summary>
        /// <returns>List of user records</returns>
        public List<ItemRecord> RetrieveItemRecords()
        {
            List<ItemRecord> records = new List<ItemRecord>(new ItemRecord[]{
                new ItemRecord("InputDate1", "ItemId1", "Status1", "UserName1"),
                new ItemRecord("InputDate2", "ItemId2", "Status2", "UserName2"),
                new ItemRecord("InputDate3", "ItemId1", "Status1", "UserName2"),
                new ItemRecord("InputDate4", "ItemId2", "Status2", "UserName3"),
                new ItemRecord("InputDate5", "ItemId1", "Status1", "UserName3")
            });

            return records;
        }

        /// <summary>
        ///     Retrieve a list of Item Objects relating to update records for the given item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public List<ItemObject> RetrieveItemUpdateRecords(string itemId)
        {
            List<ItemObject> items = new List<ItemObject>(new ItemObject[] {
            new ItemObject()
            {
                Status= "Update",
                AltImageFile1 = "AltImageFile1",
                AltImageFile2 = "AltImageFile2",
                AltImageFile3 = "AltImageFile3",
                AltImageFile4 = "AltImageFile4",
                AccountingGroup =  "AccountingGroup",
                BillOfMaterials =  new List<ChildElement>(),
                CasepackHeight = "CasepackHeight",
                CasepackLength = "CasepackLength",
                CasepackQty =  "CasepackQty",
                CasepackUpc =  "CasepackUpc",
                CasepackWidth = "CasepackWidth",
                CasepackWeight = "CasepackWeight",
                Category = "Category",
                Category2 = "",
                Category3 = "",
                Color = "Color",
                Copyright = "Copyright",
                CountryOfOrigin =  "CountryOfOrigin",
                CostProfileGroup = "CostProfileGroup",
                DefaultActualCostUsd = "DefaultActualCostUsd",
                DefaultActualCostCad = "DefaultActualCostCad",
                Description =  "Description",
                DirectImport = "DirectImport",
                Duty = "Duty",
                Ean =  "Ean",
                EcommerceAsin = "AAsin",
                EcommerceBullet1 = "ABullet1",
                EcommerceBullet2 = "ABullet2",
                EcommerceBullet3 = "ABullet3",
                EcommerceBullet4 = "ABullet4",
                EcommerceBullet5 = "ABullet5",
                EcommerceComponents = "AComponents",
                EcommerceCost = "ACost",
                EcommerceExternalId = "AExternalId",
                EcommerceExternalIdType = "AExternalIdType",
                EcommerceGenericKeywords =     "GenericKeywords",
                EcommerceItemHeight = "AHeight",
                EcommerceItemLength = "ALength",
                EcommerceItemName = "AItemName",
                EcommerceItemWeight = "AWeight",
                EcommerceItemWidth =  "AWidth",
                EcommerceModelName =  "AModelName",
                EcommercePackageHeight =  "APackageHeight",
                EcommercePackageLength =  "APackageLength",
                EcommercePackageWeight =  "APackageWeight",
                EcommercePackageWidth = "APackageWidth",
                EcommercePageQty = "APageCount",
                EcommerceProductCategory = "AProductCategory",
                EcommerceProductDescription = "AFullDescription",
                EcommerceProductSubcategory = "AProductSubcategory",
                EcommerceManufacturerName = "AManufacturerName",
                EcommerceMsrp = "AMsrp",
                EcommerceSize = "ASearchTerms",
                EcommerceSubjectKeywords = "ASize",
                EcommerceUpc = "AUpc",
                Gpc =  "Gpc",
                Height = "Height",
                ImagePath = "ImagePath",
                InnerpackHeight =  "InnerpackHeight",
                InnerpackLength =  "InnerpackLength",
                InnerpackQuantity = "InnerpackQty",
                InnerpackUpc = "InnerpackUpc",
                InnerpackWidth = "InnerpackWidth",
                InnerpackWeight =  "InnerpackWeight",
                InStockDate =  "InStockDate",
                Isbn = "Isbn",
                ItemCategory = "ItemCategory",
                ItemFamily = "ItemFamily",
                ItemGroup = "ItemGroup",
                ItemId = "idInput",
                ItemKeywords = "ItemKeywords",
                Language = "Language",
                Length = "Length",
                License =  "License",
                LicenseBeginDate = "LicenseBeginDate",
                ListPriceCad = "ListCan",
                ListPriceUsd = "ListUsd",
                ListPriceMxn = "ListMxn",
                MetaDescription =  "MetaDescription",
                MfgSource = "MfgSource",
                Msrp = "MsrpUsd",
                MsrpCad =  "MsrpCad",
                MsrpMxn =  "MsrpMxn",
                ProductFormat = "ProdFormat",
                ProductGroup = "ProdGroup",
                ProductIdTranslation = new List<ChildElement>(),
                ProductLine =  "ProdLine",
                ProductQty = "ProdQty",
                Property = "Property",
                PricingGroup = "PricingGroup",
                PrintOnDemand = "PrintOnDemand",
                PsStatus = "PsStatus",
                SatCode =  "SatCode",
                SellOnAllPosters = "SellOnAllPosters",
                SellOnAmazon = "SellOnAmazon",
                SellOnFanatics = "SellOnFanatics",
                SellOnGuitarCenter = "SellOnGuitarCenter",
                SellOnHayneedle =  "SellOnHayneedle",
                SellOnTarget = "SellOnTarget",
                SellOnTrends = "SellOnTrends",
                SellOnWalmart = "SellOnWalmart",
                SellOnWayfair = "SellOnWayfair",
                ShortDescription = "ShortDescription",
                Size = "Size",
                StandardCost = "StandardCost",
                StatsCode = "StatsCode",
                TariffCode = "TariffCode",
                Territory = "Territory",
                Title = "Title",
                Udex = "Udex",
                Upc =  "Upc",
                WebsitePrice = "WebsitePrice",
                Weight = "Weight",
                Width = "Width"
            } });

                        
            items[0].OnSite = "Y";
            items[0].EcommerceCountryofOrigin = "CountryOfOrigin";
            items[0].Status = "Update";
            return items;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveLicensePropertyList()
        {
            return new List<string>(new string[] {
                "License1:Property1",
                "License2:Property2",
                "License3:Property3"
            });
        }

        /// <summary>
        ///     Searches PS_ORD_LINE for any open orders
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>true if any open orders with Item Id exist</returns>
        public bool RetrieveOpenOrderLine(string itemId)
        {
            if(itemId=="OpenOrder")
            {
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Retrives a child / parent match from PS_MARKETPLACE_PRODUCT_TRANSLATIONS
        /// </summary>
        /// <param name="childIt"></param>
        /// <param name="parentId"></param>
        /// <returns>true if match exists</returns>
        public bool RetrieveProductIdTranslationMatch(string childId, string parentId)
        {
            foreach(ChildElement child in this.TestProductIdTranslations)
            {
                if (child.ItemId == childId && child.ParentId == parentId)
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
            return "";
        }

        /// <summary>
        ///     Retrieve a List of item ids that have been updated withing the given dates
        /// </summary>
        /// <param name="toDate"></param>
        /// <param name="fromDate"></param>
        /// <returns></returns>
        public List<string> RetrieveUpdateReportItemIds(DateTime toDate, DateTime fromDate)
        {
            List<string> itemIds = new List<string>();
            return itemIds;
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
        }

        /// <summary>
        ///     Updates the category in Odin_NewWebCategories
        /// </summary>
        /// <param name="category">Category to be removed</param>
        public void UpdateCategory(string category, string oldCategory)
        {
        }

        /// <summary>
        ///     Runs UpdateCmItemMethod for each customer
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public void UpdateCmItemMethodAll(ItemObject item, OdinContext context)
        {
        }

        /// <summary>
        ///     Runs UpdateCustomerProductAttributes for each customer
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public void UpdateCustomerProductAttributesAll(ItemObject item, OdinContext context)
        {
        }

        /// <summary>
        ///     Updates PS_AMAZON_ITEM_ATTRIBUTES
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public void UpdateEcommerceValues(ItemObject item, OdinContext context)
        {
            
        }

        /// <summary>
        ///     Runs UpdateFxdBinLocInv for each business Unit
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void UpdateFxdBinLocInvAll(ItemObject item)
        {
        }

        /// <summary>
        /// Insert item info(TariffCode, ItemColor, ItemHeight, ItemLength, ItemId, Description, ItemWeight, ItemWidth, Upc) and username to PS_INV_ITEMS
        /// </summary>
        public void UpdateInvItems(ItemObject item, OdinContext context)
        {
        }

        /// <summary>
        ///     Updates item info in PS_ITEM_ATTRIB_EX
        /// </summary>
        public void UpdateItemAttribEx(ItemObject item, OdinContext context)
        {
        }

        /// <summary>
        ///     Updates the values in PS_ITEM_WEB_INFO
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void UpdateItemWebInfo(ItemObject item, OdinContext context)
        {
        }

        /// <summary>
        ///     Updates the values in PS_MASTER_ITEM_TBL
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void UpdateMasterItemTbl(ItemObject item, OdinContext context)
        {
        }

        /// <summary>
        ///     Updates PS_ITEM_WEB_INFO with today's date for the give item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public void UpdateNewDate(string itemId)
        {
        }

        /// <summary>
        ///     Updates the ON_SITE flag in PS_ITEM_WEB_INFO
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public void UpdateOnSite(string itemId)
        {
        }

        /// <summary>
        ///     Updates the values in PS_PROD_ITEM
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void UpdateProdItem(ItemObject item, OdinContext context)
        {
        }

        /// <summary>
        ///     Runs UpdateProdPgrpLnk for each Product Group Type
        /// </summary>
        public void UpdateProdPgrpLnkAll(ItemObject item)
        {
        }

        /// <summary>
        ///     Runs UpdateProdPrice for each business unit / ccd combination
        /// </summary>
        public void UpdateProdPriceAll(ItemObject item, OdinContext context)
        {
        }

        /// <summary>
        ///     Runs InsertProdPriceBu if MXN values had not been previously added
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void UpdateProdPriceBuAll(ItemObject item, OdinContext context)
        {
        }

        /// <summary>
        ///     Updates the values in PS_PURCH_ITEM_ATTR
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void UpdatePurchItemAttr(ItemObject item, OdinContext context)
        {
        }

        /// <summary>
        ///     Updates the values in PS_PV_ITM_CATEGORY
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void UpdatePvItmCategory(ItemObject item)
        {
        }

        #endregion // Public Update Methods

        #endregion // Public Methods

        #region Constructor

        public TestItemRepository()
        {
            SetTestValues();
        }

        #endregion // Constructor
    }
}
