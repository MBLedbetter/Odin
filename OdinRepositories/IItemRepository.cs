using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OdinRepositories
{
    public interface IItemRepository
    {
        List<string> CheckDuplicateEcommerceUPCs(string upc);
        bool CheckOpenOrderLine(string itemId);
        string ReturnSaveProgress();
        bool RepositoryAssigned();
        Boolean IsTest();

        #region Insert Methods

        bool InsertAll(ObservableCollection<ItemObject> items);
        bool InsertCategory(string category);
        bool InsertNewDate(string itemId);
        bool InsertMetaDescription(string value);
        bool InsertLicense(string license, string property = "");
        bool InsertTerritory(string territory);

        #endregion // Insert Methods

        #region Retrieval Methods

        List<string> RetrieveActiveEcommerceItemIds(string startDate, string endDate, string productGroup, string customerName);
        ObservableCollection<ItemObject> RetrieveActiveEcommerceItems(string startDate, string endDate, string productGroup, string customerId);
        ItemObject RetrieveItem(string item, int row);
        List<SearchItem> RetrieveItemSearchResults(string value);
        List<ItemObject> RetrieveItemUpdateRecords(string itemId);
        List<string> RetrieveProductFormats(string var);
        List<string> RetrievePropertyList(string var);
        ItemObject RetrieveWebsiteItem(string idInput);

        #endregion // Retrieval Methods

        #region Removal Methods

        bool RemoveCategory(string value);
        bool RemoveLicense(string value);
        bool RemoveMetaDescription(string value);
        bool RemoveProperty(string value);
        bool RemoveTerritory(string value);

        #endregion // Removal Methods
        
        #region UpdateMethods

        bool UpdateCategory(string category, string oldCategory);
        bool UpdateOnSite(string itemId);

        #endregion // UpdateMethods

    }
}
