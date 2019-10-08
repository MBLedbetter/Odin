using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.Data
{
    public interface IItemRepository
    {
        #region Public Methods

        /// <summary>
        ///     Retrieves Matching Category Ids for category values and combines for DB field insertion
        /// </summary>
        /// <param name="value1">category</param>
        /// <param name="value2">category 2</param>
        /// <param name="value3">category 3</param>
        string CombineCategories(string category1, string category2, string category3);

        #region Public Insert Methods

        /// <summary>
        ///     Inserts item information into all item tables
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        void InsertAll(ItemObject item, int count);

        /// <summary>
        ///     Inserts item info into PS_ASSET_ITEM_ATTR.
        /// </summary>
        void InsertAssetItemAttr(ItemObject item, OdinContext context);

        /// <summary>
        ///     Runs InsertBuItemsConfig for each business Unit
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        void InsertBuItemsConfigAll(ItemObject item, OdinContext context);

        /// <summary>
        ///     Runs InsertBuItemsInv for each business Unit
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        void InsertBuItemsInvAll(ItemObject item, OdinContext context);

        /// <summary>
        ///     Runs InsertBuItemUtilCd for each business Unit type
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        void InsertBuItemUtilCdAll(ItemObject item, OdinContext context);

        /// <summary>
        ///     Inserts New Category into table
        /// </summary>
        /// <param name="category"></param>
        void InsertCategory(string category);

        /// <summary>
        ///     Runs InsertCmItemMethod for each business Unit
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        void InsertCmItemMethodAll(ItemObject item, OdinContext context);

        /// <summary>
        ///     Runs InsertCustomerProductAttributes for each customer
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        void InsertCustomerProductAttributesAll(ItemObject item, OdinContext context);

        /// <summary>
        /// Runs InsertDefaultLocInvAll for each business Unit
        /// /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        void InsertDefaultLocInvAll(ItemObject item, OdinContext context);

        /// <summary>
        ///     Insert Ecommerce Value into Database
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        void InsertEcommerceValues(ItemObject item, OdinContext context);

        /// <summary>
        ///     Runs InsertEnBomComps for each bill of materials child
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        void InsertEnBomCompsAll(ItemObject item);

        /// <summary>
        ///     Runs InserteEnBomHeader for each item with bill of materials
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        void InsertEnBomHeader(ItemObject item, OdinContext context); 

        /// <summary>
        ///     Runs InsertFxdBinLocInv for each business Unit
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void InsertFxdBinLocInvAll(ItemObject item, OdinContext context);

        /// <summary>
        /// Insert item info(TariffCode, ItemColor, ItemHeight, ItemLength, ItemId, Description, ItemWeight, ItemWidth, Upc) and username to PS_INV_ITEMS
        /// </summary>
        void InsertInvItems(ItemObject item, OdinContext context);

        /// <summary>
        /// Insert item info(item Id) and username to table PS_INV_ITEM_UOM
        /// </summary>
        void InsertInvItemUom(ItemObject item, OdinContext context);

        /// <summary>
        ///     Insert item info into table PS_ITEM_ATTRIB_EX
        /// </summary>
        void InsertItemAttribEx(ItemObject item, OdinContext context);

        /// <summary>
        /// Insert item info into table PS_ITEM_COMPLIANCE
        /// </summary>
        void InsertItemCompliance(ItemObject item, OdinContext context);

        /// <summary>
        ///     Removes existing langage values and runs InsertItemLanguage for each language code in the language field
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void InsertItemLanguageAll(ItemObject item);

        /// <summary>
        ///     Removes existing territory values and runs InsertItemTerritory for each territory code in the territory field
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void InsertItemTerritoryAll(ItemObject item);

        /// <summary>
        ///     Inserts item infor into ODIN_ITEM_UPDATE_RECORDS
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        void InsertItemUpdateRecord(ItemObject item, OdinContext context);

        /// <summary>
        ///     Insert item info  into PS_ITEM_WEB_INFO
        /// </summary>
        void InsertItemWebInfo(ItemObject item, OdinContext context);

        /// <summary>
        /// Insert item info into to PS_MASTER_ITEM_TBL
        /// </summary>
        void InsertMasterItemTbl(ItemObject item, OdinContext context);

        /// <summary>
        ///     Runs InsertPlItemAttrib for each of the business units
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void InsertPlItemAttribAll(ItemObject item, OdinContext context);

        /// <summary>
        /// Insert item info into PS_PROD_ITEM
        /// </summary>
        void InsertProdItem(ItemObject item, OdinContext context);

        /// <summary>
        ///     Inserts License and property into Odin_Web_License
        /// </summary>
        /// <param name="category"></param>
        void InsertLicense(string license, string property);

        /// <summary>
        ///     Insert info into to PS_MARKETPLACE_CUSTOMER_PRODUCTS
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="title"></param>
        void InsertMarketplaceCustomerProducts(string itemId, string title, string customer);

        /// <summary>
        ///     Inserts a Meta Description value into Odin_MetaDescription
        /// </summary>
        /// <param name="metaDescription"></param>
        /// <returns></returns>
        void InsertMetaDescription(string metaDescription);

        /// <summary>
        ///     Runs InsertProdPgrpLnk for each Product Group Type
        /// </summary>
        void InsertProdPgrpLnkAll(ItemObject item, OdinContext context);

        /// <summary>
        ///     Runs InsertProdPrice for each business unit / ccd combination
        /// </summary>
        void InsertProdPriceAll(ItemObject item, OdinContext context);

        /// <summary>
        ///     Runs InsertProdPriceBu for each business unit / currency code combination
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void InsertProdPriceBuAll(ItemObject item, OdinContext context);

        /// <summary>
        ///     Runs InsertProductIdTranslation for each child in the productIdTranslation field
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void InsertProductIdTranslationAll(ItemObject item, OdinContext context);

        /// <summary>
        /// Insert item info into PS_PROD_UOM
        /// </summary>
        void InsertProdUom(ItemObject item, OdinContext context);

        /// <summary>
        ///     Insert item info into PS_PURCH_ITEM_ATTR
        /// </summary>
        void InsertPurchItemAttr(ItemObject item, OdinContext context);

        /// <summary>
        ///     Insert item info into PS_PV_ITM_Category table
        /// </summary>
        void InsertPvItmCategory(ItemObject item, OdinContext context);

        /// <summary>
        ///     Inserts Territory Value into Odin_Web_Territories
        /// </summary>
        /// <param name="category"></param>
        void InsertTerritory(string territory);

        /// <summary>
        ///     Runs InsertUomTypeInv for each Uom type
        /// </summary>
        void InsertUomTypeInvAll(ItemObject item, OdinContext context);

        /// <summary>
        ///     Inserts a value into Odin_NewWebCategories
        /// </summary>
        /// <param name="category"></param>
        void InsertWebCategory(string category);

        #endregion // Public Insert Methods

        #region Public Removal Methods

        /// <summary>
        ///     Removes category from Odin_NewWebCategories
        /// </summary>
        /// <param name="category">Category to be removed</param>
        void RemoveCategory(string categoryName);

        /// <summary>
        ///     Removes all license/property values from ODIN_WEB_LICENSE with the given license
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void RemoveLicense(string licenseName);

        /// <summary>
        ///     Removes a Meta Description from Odin_MetaDescription
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        void RemoveMetaDescription(string metaDescriptionName);

        /// <summary>
        ///     Removes a property from Odin_Web_License
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        void RemoveProperty(string licenseName, string propertyName);

        /// <summary>
        ///     Removes territory value from ODIN_WEB_TERRITORIES with the given territory
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void RemoveTerritory(string territory);

        #endregion // Public Removal Methods

        #region Public Retrieval Methods

        /// <summary>
        ///     Returns all items that fall within the given date range for the given customer
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        List<string> RetrieveActiveEcommerceItemIds(string startDate, string endDate, string productGroup, string customerName);

        /// <summary>
        ///     Retrieves all the Global data values
        /// </summary>
        void RetrieveGlobalData();

        /// <summary>
        ///     Selects all of the info for a given item from the db. If assigned type 2 only retrieves information from db not included in spreadsheet
        /// </summary>
        /// <param name="item"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        ItemObject RetrieveItem(string idInput, int row);

        /// <summary>
        ///     Retrieves the most recent ItemRecord for each item in ODIN_ITEM_UPDATE_RECORDS
        /// </summary>
        /// <returns></returns>
        List<ItemRecord> RetrieveItemRecords();

        /// <summary>
        ///     Retrieves a list of search item values
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        List<SearchItem> RetrieveItemSearchResults(string value, bool includeDisabled);

        /// <summary>
        ///     Retrieve a list of Item Objects relating to update records for the given item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        List<ItemObject> RetrieveItemUpdateRecords(string itemId);

        /// <summary>
        ///     Retrieves a list of all license : Property values
        /// </summary>
        /// <returns></returns>
        List<string> RetrieveLicensePropertyList();

        /// <summary>
        ///     Check if item is listed as being on the shoptrends site. PS_ITEM_WEB_INFO.ON_SHOPTRENDS == "Y"
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        bool RetrieveOnShopTrends(string itemId);

        /// <summary>
        ///     Check if item is listed as being on the trendsinteranational site. PS_ITEM_WEB_INFO.ON_SITE == "Y"
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        bool RetrieveOnSite(string itemId);

        /// <summary>
        ///     Retrives a child / parent match from PS_MARKETPLACE_PRODUCT_TRANSLATIONS
        /// </summary>
        /// <param name="childIt"></param>
        /// <param name="parentId"></param>
        /// <returns>true if match exists</returns>
        bool RetrieveProductIdTranslationMatch(string childId, string parentId);

        /// <summary>
        ///     Retrieves a list of local image paths for the given item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        List<KeyValuePair<string, int>> RetrieveImagePaths(string itemId);

        /// <summary>
        ///     Searches PS_ORD_LINE for any open orders
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>true if any open orders with Item Id exist</returns>
        bool RetrieveOpenOrderLine(string itemId);

        /// <summary>
        ///     Returns the value of the save progress value
        /// </summary>
        /// <returns></returns>
        string RetrieveSaveProgress();

        /// <summary>
        ///     Retrieves a List of SearchItems based on their Item Category
        /// </summary>
        /// <param name="itemCategory">Item Category search parameter</param>
        /// <param name="includeDisabled">if true include items in destroyed status</param>
        /// <returns>List of Search Items</returns>
        List<SearchItem> RetreiveSearchItemByItemCategory(string itemCategory, bool includeDisabled = false);

        /// <summary>
        ///     Retrieves a List of SearchItems based on their Item Group
        /// </summary>
        /// <param name="itemGroup">Item Group search parameter</param>
        /// <param name="includeDisabled">if true include items in destroyed status</param>
        /// <returns>List of Search Items</returns>
        List<SearchItem> RetreiveSearchItemByItemGroup(string itemGroup, bool includeDisabled = false);

        /// <summary>
        ///     Retrieves a List of SearchItems based on their Product Format
        /// </summary>
        /// <param name="productFormat">Product Format search parameter</param>
        /// <param name="includeDisabled">if true include items in destroyed status</param>
        /// <returns>List of Search Items</returns>
        List<SearchItem> RetreiveSearchItemByProductFormat(string productFormat, bool includeDisabled = false);

        /// <summary>
        ///     Retrieves a List of SearchItems based on their Product Group
        /// </summary>
        /// <param name="productGroup">Product Group search parameter</param>
        /// <param name="includeDisabled">if true include items in destroyed status</param>
        /// <returns>List of Search Items</returns>
        List<SearchItem> RetreiveSearchItemByProductGroup(string productGroup, bool includeDisabled = false);

        /// <summary>
        ///     Retrieves a List of SearchItems based on their Product Line
        /// </summary>
        /// <param name="productLine">Product Line search parameter</param>
        /// <param name="includeDisabled">if true include items in destroyed status</param>
        /// <returns>List of Search Items</returns>
        List<SearchItem> RetreiveSearchItemByProductLine(string productLine, bool includeDisabled = false);

        /// <summary>
        ///     Retrieves a List of SearchItems based on their Stats Code
        /// </summary>
        /// <param name="statsCode">Stats Code search parameter</param>
        /// <param name="includeDisabled">if true include items in destroyed status</param>
        /// <returns>List of Search Items</returns>
        List<SearchItem> RetreiveSearchItemByStatsCode(string statsCode, bool includeDisabled = false);

        /// <summary>
        ///     Retrieves a List of SearchItems based on their Tariff Code
        /// </summary>
        /// <param name="tariffCode">Tariff Code search parameter</param>
        /// <param name="includeDisabled">if true include items in destroyed status</param>
        /// <returns>List of Search Items</returns>
        List<SearchItem> RetreiveSearchItemByTariffCode(string tariffCode, bool includeDisabled = false);

        /// <summary>
        ///     Returns the web category code associated with the given name
        /// </summary>
        /// <param name="value"></param>
        string RetrieveWebCategoryCodeByName(string value);

        /// <summary>
        ///     Returns the category name associated with the given code
        /// </summary>
        /// <param name="value"></param>
        string RetrieveCategoryNameByCode(string value);

        /// <summary>
        ///     Retrieve a List of item ids that have been updated withing the given dates
        /// </summary>
        /// <param name="toDate"></param>
        /// <param name="fromDate"></param>
        /// <returns></returns>
        List<string> RetrieveUpdateReportItemIds(DateTime toDate, DateTime fromDate);

        string RetrieveWebsiteUrl(string itemId);

        #endregion // Public Retrieval Methods

        #region Public Update Methods


        /// <summary>
        ///     Runs UpdateBuItemsInv for each business Unit
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>

        void UpdateBuItemsInvAll(ItemObject item, OdinContext context);

        /// <summary>
        ///     Updates the category in Odin_NewWebCategories
        /// </summary>
        /// <param name="category">Category to be removed</param>
        void UpdateCategory(string category, string oldCategory);

        /// <summary>
        ///     Runs UpdateCmItemMethod for each customer
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        void UpdateCmItemMethodAll(ItemObject item, OdinContext context);

        /// <summary>
        ///     Runs UpdateCustomerProductAttributes for each customer
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        void UpdateCustomerProductAttributesAll(ItemObject item, OdinContext context);

        /// <summary>
        ///     Updates PS_AMAZON_ITEM_ATTRIBUTES
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        void UpdateEcommerceValues(ItemObject item, OdinContext context);

        /// <summary>
        ///     Runs UpdateFxdBinLocInv. removes all coresponding rows and adds new
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        void UpdateFxdBinLocInvAll(ItemObject item);

        /// <summary>
        /// Insert item info(TariffCode, ItemColor, ItemHeight, ItemLength, ItemId, Description, ItemWeight, ItemWidth, Upc) and username to PS_INV_ITEMS
        /// </summary>
        void UpdateInvItems(ItemObject item, OdinContext context);

        /// <summary>
        ///     Updates item info in PS_ITEM_ATTRIB_EX
        /// </summary>
        void UpdateItemAttribEx(ItemObject item, OdinContext context);

        /// <summary>
        ///     Updates the values in PS_ITEM_WEB_INFO
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void UpdateItemWebInfo(ItemObject item, OdinContext context);

        /// <summary>
        ///     Updates the values in PS_MASTER_ITEM_TBL
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void UpdateMasterItemTbl(ItemObject item, OdinContext context);

        /// <summary>
        ///     Updates PS_ITEM_WEB_INFO with today's date for the give item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        void UpdateNewDate(string itemId);

        /// <summary>
        ///     Updates the ON_SITE flag in PS_ITEM_WEB_INFO
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        void UpdateOnSite(ItemObject item, string website);

        /// <summary>
        ///     Updates the values in PS_PROD_ITEM
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void UpdateProdItem(ItemObject item, OdinContext context);

        /// <summary>
        ///     Runs UpdateProdPgrpLnk for each Product Group Type
        /// </summary>
        void UpdateProdPgrpLnkAll(ItemObject item);

        /// <summary>
        ///     Runs UpdateProdPrice for each business unit / ccd combination
        /// </summary>
        void UpdateProdPriceAll(ItemObject item, OdinContext context);

        /// <summary>
        ///     Runs InsertProdPriceBu if MXN values had not been previously added
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void UpdateProdPriceBuAll(ItemObject item, OdinContext context);

        /// <summary>
        ///     Updates the values in PS_PURCH_ITEM_ATTR
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void UpdatePurchItemAttr(ItemObject item, OdinContext context);

        /// <summary>
        ///     Updates the values in PS_PV_ITM_CATEGORY
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void UpdatePvItmCategory(ItemObject item);

        #endregion // Public Update Methods

        #endregion // Public Methods
    }
}
