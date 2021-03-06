﻿using ExcelLibrary;
using Microsoft.Win32;
using Mvvm;
using Odin.Views;
using OdinModels;
using OdinServices;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;

namespace Odin.ViewModels
{
    public class FindItemViewModel : ViewModelBase
    {
        #region Commands

        public ICommand AddListCommand
        {
            get
            {
                if (_addList == null)
                {
                    _addList = new RelayCommand(param => AddItemList());
                }
                return _addList;
            }
        }
        private RelayCommand _addList;

        public ICommand EnterKeyCommand
        {
            get
            {
                if (_enterKeyCommand == null)
                {
                    _enterKeyCommand = new RelayCommand(param => EnterKey());
                }
                return _enterKeyCommand;
            }
        }
        private RelayCommand _enterKeyCommand;

        public ICommand FindItemByFieldCommand
        {
            get
            {
                if (_findItemByField == null)
                {
                    _findItemByField = new RelayCommand(param => FindItemByField());
                }
                return _findItemByField;
            }
        }
        private RelayCommand _findItemByField;

        public ICommand FindItemCommand
        {
            get
            {
                if (_findItem == null)
                {
                    _findItem = new RelayCommand(param => FindItemById());
                }
                return _findItem;
            }
        }
        private RelayCommand _findItem;

        public ICommand SortItemIdCommand
        {
            get
            {
                if (_sortItemId == null)
                {
                    _sortItemId = new RelayCommand(param => SortItemIds());
                }
                return _sortItemId;
            }
        }
        private RelayCommand _sortItemId;

        public ICommand SortDescriptionCommand
        {
            get
            {
                if (_sortDescription == null)
                {
                    _sortDescription = new RelayCommand(param => SortDescriptions());
                }
                return _sortDescription;
            }
        }
        private RelayCommand _sortDescription;

        #endregion // Commands

        #region Properties

        private BackgroundWorker BackgroundWorker { get; set; }

        private string BackgroundWorkerState = string.Empty;

        /// <summary>
        ///     Gets or sets the ButtonVisibility
        /// </summary>
        public string ButtonVisibility
        {
            get
            {
                return _buttonVisibility;
            }
            set
            {
                _buttonVisibility = value;
                OnPropertyChanged("ButtonVisibility");
            }

        }
        private string _buttonVisibility = "True";

        /// <summary>
        ///     Flags current Description sort order
        /// </summary>
        private int DescriptionIdSearchOrder { get; set; }

        /// <summary>
        ///     Gets or sets the DisabledCheck
        /// </summary>
        public bool DisabledCheck
        {
            get
            {
                return _disabledCheck;
            }
            set
            {
                _disabledCheck = value;
                OnPropertyChanged("DisabledCheck");                
            }
        }
        private bool _disabledCheck = true;

        /// <summary>
        ///     Gets or sets the ItemErrors
        /// </summary>
        public ObservableCollection<ItemError> ItemErrors
        {
            get
            {
                return _itemErrors;
            }
            private set
            {
                _itemErrors = value;
                OnPropertyChanged("ItemErrors");
            }
        }
        private ObservableCollection<ItemError> _itemErrors = new ObservableCollection<ItemError>();

        /// <summary>
        ///     Gets or sets the ItemIdAbsentList. This keeps track of item ids that were searched for that don't exist in the db or are duplicates on the list.
        /// </summary>
        public List<string> ItemIdAbsentList
        {
            get
            {
                return _itemIdAbsentList;
            }
            set
            {
                _itemIdAbsentList = value;
                OnPropertyChanged("ItemIdAbsentList");
            }
        }
        private List<string> _itemIdAbsentList = new List<string>();

        /// <summary>
        ///     Gets or sets the ItemIdList
        /// </summary>
        public List<string> ItemIdList
        {
            get
            {
                return _itemIdList;
            }
            set
            {
                _itemIdList = value;
                OnPropertyChanged("ItemIdList");
            }
        }
        private List<string> _itemIdList = new List<string>();

        /// <summary>
        ///     Flags current ItemId sort order
        /// </summary>
        private int ItemIdSearchOrder { get; set; }

        /// <summary>
        ///     Gets or sets the ItemService
        /// </summary>
        public ItemService ItemService { get; set; }

        /// <summary>
        ///     Gets or sets the list of completed items
        /// </summary>
        public ObservableCollection<ItemObject> ItemList
        {
            get
            {
                return _itemList;
            }
            private set
            {
                _itemList = value;
                OnPropertyChanged("ItemList");
            }
        }
        private ObservableCollection<ItemObject> _itemList = new ObservableCollection<ItemObject>();

        /// <summary>
        ///     Gets or sets the ItemLoadCount
        /// </summary>
        public int ItemLoadCount
        {
            get
            {
                return _itemLoadCount;
            }
            set
            {
                _itemLoadCount = value;
                OnPropertyChanged("ItemLoadCount");
            }
        }
        private int _itemLoadCount = 0;

        /// <summary>
        ///     Gets or sets the progress text of the FindItemView
        /// </summary>
        public string ProgressText
        {
            get
            {
                return _progressText;
            }
            set
            {
                _progressText = value;
                OnPropertyChanged("ProgressText");
            }

        }
        private string _progressText = string.Empty;

        /// <summary>
        ///     Gets or sets the Search By Field Combobox value
        /// </summary>
        public string SearchByField
        {
            get
            {
                return _searchByField;
            }
            set
            {
                _searchByField = value;
                SetSearchByFieldValue(value);
                OnPropertyChanged("SearchByField");
            }
        }
        private string _searchByField = string.Empty;

        /// <summary>
        ///     Gets or sets the Search By Fields Combobox values
        /// </summary>
        public List<string> SearchByFields
        {
            get
            {
                return _searchByFields;
            }
            set
            {
                _searchByFields = value;
                OnPropertyChanged("SearchByFields");
            }
        }
        private List<string> _searchByFields = new List<string>();

        /// <summary>
        ///     Gets or sets the Search By Field Value
        /// </summary>
        public string SearchByFieldValue
        {
            get
            {
                return _searchByFieldValue;
            }
            set
            {
                _searchByFieldValue = value;
                OnPropertyChanged("SearchByFieldValue");
            }
        }
        private string _searchByFieldValue = string.Empty;

        /// <summary>
        ///     Gets or sets the Search By Field value Combobox values
        /// </summary>
        public List<string> SearchByFieldValues
        {
            get
            {
                return _searchByFieldValues;
            }
            set
            {
                _searchByFieldValues = value;
                OnPropertyChanged("SearchByFieldValues");
            }
        }
        private List<string> _searchByFieldValues = new List<string>();

        /// <summary>
        ///     Item id input field
        /// </summary>
        public string ItemIdSearchInput
        {
            get
            {
                return _itemIdSearchInput;
            }
            set
            {
                if (_itemIdSearchInput != value.Trim().ToUpper())
                {
                    _itemIdSearchInput = value.Trim().ToUpper();
                    OnPropertyChanged("ItemIdSearchInput");
                }
            }
        }
        private string _itemIdSearchInput = string.Empty;

        /// <summary>
        ///     Gets or sets the SearchItemIds
        /// </summary>
        public List<string> SearchItemIds
        {
            get
            {
                return _searchItemIds;
            }
            set
            {
                _searchItemIds = value;
                OnPropertyChanged("SearchItemIds");
            }
        }
        private List<string> _searchItemIds = new List<string>();

        /// <summary>
        ///     List of item Ids to be updated
        /// </summary>
        public ObservableCollection<SearchItem> SearchItemList
        {
            get
            {
                if (_searchItemList == null)
                {
                    _searchItemList = new ObservableCollection<SearchItem>();
                }
                return _searchItemList;
            }
            set
            {
                _searchItemList = value;
                OnPropertyChanged("SearchItemList");
            }
        }
        private ObservableCollection<SearchItem> _searchItemList = new ObservableCollection<SearchItem>();

        /// <summary>
        ///     The item that is selected in the view that this view model is bound to.
        /// </summary>
        public ItemObject SelectedItem { get; set; }
        
        /// <summary>
        ///     Gets or sets the SubmitButtonVisibility flag
        /// </summary>
        public bool SubmitButtonVisibility
        {
            get
            {
                return _submitButtonVisibility;
            }
            private set
            {
                _submitButtonVisibility = value;
                OnPropertyChanged("SubmitButtonVisibility");
            }
        }
        private bool _submitButtonVisibility = true;

        /// <summary>
        ///     Gets or sets the Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
            ///     Item id input field
            /// </summary>
        public string UpdateType { get; set; }

        /// <summary>
        ///     Gets or sets the WorkbookReader
        /// </summary>
        private WorkbookReader WorkbookReader { get; set; }

        #endregion // properties

        #region Methods

        /// <summary>
        ///     Load a list of item ids from an excel spreadsheet and retrieve info from database.
        /// </summary>
        public void AddItemList()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Excel files|*.xls; *.xlsx"
            };
            if (dialog.ShowDialog() != true)
            {
                return;
            }
            try
            {
                this.ItemIdList = ItemService.LoadItemIds(UpdateType, dialog.FileName);
                this.ItemLoadCount = this.ItemIdList.Count;
                this.ButtonVisibility = "False";
                this.BackgroundWorkerState = "ExcelList";
                BackgroundWorker.DoWork += BackgroundWorker_DoWork;
                BackgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
                BackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
                BackgroundWorker.WorkerReportsProgress = true;
                BackgroundWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError("Odin was unable to load the excel spreadsheet.", ex.ToString());
            }

            Mouse.OverrideCursor = null;

        }

        /// <summary>
        ///     Executes FindItem() when enter key is pressed
        /// </summary>
        public void EnterKey()
        {
            FindItemById();
        }
        /// <summary>
        ///     Add item id input to the list of items to update.
        /// </summary>
        public void FindItemByField()
        {
            if (!string.IsNullOrEmpty(this.SearchByField) && !string.IsNullOrEmpty(this.SearchByFieldValue))
            {
                try
                {
                    List<SearchItem> searchItems = RetrieveFindItemByFieldResults(this.SearchByField, this.SearchByFieldValue);
                    if (searchItems.Count() == 0)
                    {
                        AlertView window = new AlertView()
                        {
                            DataContext = new AlertViewModel(new List<string>(), "Alert", "No results were found for the given search criteria.")
                        };
                        window.ShowDialog();
                    }
                    else if (searchItems.Count > 0)
                    {
                        FindItemResultListView window = new FindItemResultListView()
                        {
                            DataContext = new FindItemResultListViewModel(searchItems)
                        };
                        List<string> itemIds = new List<string>();
                        if (window.ShowDialog() == true)
                        {
                            ObservableCollection<SearchItem> ReturnedItems = (window.DataContext as FindItemResultListViewModel).ReturnSelectedItems();

                            // Items already in item list
                            foreach (SearchItem returnedItem in ReturnedItems)
                            {
                                bool exists = false;
                                // Items selected from search

                                foreach (ItemObject CurrentItem in this.ItemList)
                                {
                                    if (returnedItem.ItemId == CurrentItem.ItemId)
                                    {
                                        exists = true;
                                        break;
                                    }
                                }
                                if (!exists)
                                {
                                    itemIds.Add(returnedItem.ItemId);
                                    this.ItemList.Add(ItemService.RetrieveItem(returnedItem.ItemId, this.ItemList.Count + 1));
                                }
                            }
                            this.ItemLoadCount = this.SearchItemIds.Count;
                            this.ButtonVisibility = "False";
                            this.BackgroundWorkerState = "SearchList";
                            BackgroundWorker.DoWork += BackgroundWorker_DoWork;
                            BackgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
                            BackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
                            BackgroundWorker.WorkerReportsProgress = true;
                            BackgroundWorker.RunWorkerAsync();
                            // this.SearchItemList = ReturnedItems;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.LogError("Odin was unable to retireve the items.", ex.ToString());
                }
            }
        }

        /// <summary>
        ///     Add item id input to the list of items to update.
        /// </summary>
        public void FindItemById()
        {
            if (!(string.IsNullOrEmpty(this.ItemIdSearchInput)))
            {
                if (this.ItemIdSearchInput.Length > 1)
                {
                    try
                    {
                        List<SearchItem> searchItems = ItemService.RetrieveFindItemSearchResults(this.ItemIdSearchInput, this.DisabledCheck);
                        if (searchItems.Count() == 0)
                        {
                            List<string> missingItems = new List<string>();
                            foreach (SearchItem searchItem in searchItems)
                            {
                                missingItems.Add(searchItem.ItemId);
                            }
                            AlertView window = new AlertView()
                            {
                                DataContext = new AlertViewModel(missingItems, "Alert", "No results were found for the following items. Or they were duplicates")
                            };
                            window.ShowDialog();
                        }
                        else if (searchItems.Count > 1)
                        {
                            FindItemResultListView window = new FindItemResultListView()
                            {
                                DataContext = new FindItemResultListViewModel(searchItems)
                            };
                            List<string> itemIds = new List<string>();
                            if (window.ShowDialog() == true)
                            {
                                ObservableCollection<SearchItem> ReturnedItems = (window.DataContext as FindItemResultListViewModel).ReturnSelectedItems();
                                // Items already in item list
                                foreach (SearchItem returnedItem in ReturnedItems)
                                {
                                    bool exists = false;
                                    // Items selected from search

                                    foreach (ItemObject CurrentItem in this.ItemList)
                                    {
                                        if (returnedItem.ItemId == CurrentItem.ItemId)
                                        {
                                            exists = true;
                                            break;
                                        }
                                    }
                                    if (!exists)
                                    {
                                        itemIds.Add(returnedItem.ItemId);
                                        this.ItemList.Add(ItemService.RetrieveItem(returnedItem.ItemId, this.ItemList.Count + 1));
                                    }
                                }
                                this.ItemLoadCount = this.SearchItemIds.Count;
                                this.ButtonVisibility = "False";
                                this.BackgroundWorkerState = "SearchList";
                                BackgroundWorker.DoWork += BackgroundWorker_DoWork;
                                BackgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
                                BackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
                                BackgroundWorker.WorkerReportsProgress = true;
                                BackgroundWorker.RunWorkerAsync();
                                // this.SearchItemList = ReturnedItems;
                            }
                        }
                        else if (searchItems.Count == 1)
                        {
                            ObservableCollection<SearchItem> ReturnedItems = new ObservableCollection<SearchItem>()
                            {
                                searchItems[0]
                            };

                            foreach (SearchItem returnedItem in ReturnedItems)
                            {
                                bool exists = false;
                                foreach (ItemObject CurrentItem in this.ItemList)
                                {
                                    if (returnedItem.ItemId == CurrentItem.ItemId)
                                    {
                                        exists = true;
                                        break;
                                    }
                                }
                                if (!exists)
                                {
                                    this.ItemList.Add(ItemService.RetrieveItem(returnedItem.ItemId, this.ItemList.Count + 1));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.LogError("Odin was unable to retireve the items.", ex.ToString());
                    }
                }
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ObservableCollection<ItemObject> returnItems = new ObservableCollection<ItemObject>();
            int count = 1;
            this.ButtonVisibility = "False";
            if (this.BackgroundWorkerState == "ExcelList")
            {
                foreach (string itemId in this.ItemIdList)
                {
                    BackgroundWorker.ReportProgress(count);
                    if (GlobalData.ItemIds.Contains(itemId))
                    {
                        ItemObject item = ItemService.RetrieveItem(itemId, count);
                        item.Status = this.UpdateType;
                        returnItems.Add(item);
                        count++;
                    }
                    else
                    {
                        this.ItemIdAbsentList.Add(itemId);
                    }
                }
            }
            if (this.BackgroundWorkerState == "SearchList")
            {
                foreach (string itemId in this.SearchItemIds)
                {
                    BackgroundWorker.ReportProgress(count);
                    if (GlobalData.ItemIds.Contains(itemId))
                    {
                        ItemObject item = ItemService.RetrieveItem(itemId, count);
                        item.Status = this.UpdateType;
                        returnItems.Add(item);
                        count++;
                    }
                    else
                    {
                        this.ItemIdAbsentList.Add(itemId);
                    }
                }
            }
            e.Result = returnItems;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<string> existingIds = new List<string>();
            foreach (ItemObject existingItem in this.ItemList)
            {
                existingIds.Add(existingItem.ItemId);
            }
            foreach (ItemObject item in (ObservableCollection<ItemObject>)e.Result)
            {
                if (!existingIds.Contains(item.ItemId))
                {
                    this.ItemList.Add(item);
                    existingIds.Add(item.ItemId);
                }
            }
            this.ButtonVisibility = "True";
            this.ProgressText = "Item Load Complete";
            if(this.ItemIdAbsentList.Count>0)
            {
                AlertView window = new AlertView()
                {
                    DataContext = new AlertViewModel(this.ItemIdAbsentList, "Alert", "The following items were not found in the database.")
                };
                window.ShowDialog();
            }
        }

        public void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.ProgressText = "Gathering Data for item " + e.ProgressPercentage.ToString() + " of " + this.ItemLoadCount.ToString();            
        }
        
        /// <summary>
        ///     Returns a list of completed items from the itemviewmodel
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<ItemObject> ReturnList()
        {
            ObservableCollection<ItemObject> ReturnList = new ObservableCollection<ItemObject>();
            int count = 1;
            foreach (SearchItem searchItem in this.SearchItemList)
            {
                ItemObject fullItem = new ItemObject(1);
                if (this.UpdateType == "Remove")
                {
                    fullItem.ItemId = searchItem.ItemId;
                    fullItem.Description = searchItem.Description;
                    fullItem.Status = this.UpdateType;
                    fullItem.ItemRow = count;
                }
                else
                {
                    fullItem = ItemService.RetrieveItem(searchItem.ItemId, count);
                    fullItem.Status = this.UpdateType;
                }
                ReturnList.Add(fullItem);
                count++;
            }
            return ReturnList;
        }

        public List<SearchItem> RetrieveFindItemByFieldResults(string searchByField, string searchByFieldValue)
        {
            switch (searchByField)
            {
                case "Item Category":
                    return ItemService.RetreiveSearchItemByItemCategory(searchByFieldValue, this.DisabledCheck);

                case "Item Group":
                    return ItemService.RetreiveSearchItemByItemGroup(searchByFieldValue, this.DisabledCheck);

                case "Product Format":
                    return ItemService.RetreiveSearchItemByProductFormat(searchByFieldValue, this.DisabledCheck);

                case "Product Group":
                    return ItemService.RetreiveSearchItemByProductGroup(searchByFieldValue, this.DisabledCheck);

                case "Product Line":
                    return ItemService.RetreiveSearchItemByProductLine(searchByFieldValue, this.DisabledCheck);

                case "Stats Code":
                    return ItemService.RetreiveSearchItemByStatsCode(searchByFieldValue, this.DisabledCheck);

                case "Tariff Code":
                    return ItemService.RetreiveSearchItemByTariffCode(searchByFieldValue, this.DisabledCheck);

                default:
                    return new List<SearchItem>();
            }
        }
        public List<string> SetSearchByFields()
        {
            List<string> values = new List<string>()
            {
                "Item Category",
                "Product Format",
                "Product Group",
                "Product Line",
                "Item Group",
                "Stats Code",
                "Tariff Code"
            };

            return values;
        }

        public void SetSearchByFieldValue(string value)
        {
            switch(value)
            {
                case "Item Category":
                    this.SearchByFieldValues = ItemService.RetrieveItemCategoryNames();
                    break;

                case "Item Group":
                    this.SearchByFieldValues = GlobalData.ItemGroups;
                    break;

                case "Product Format":
                    this.SearchByFieldValues = ItemService.RetrieveProductFormatsAll();
                    break;

                case "Product Group":
                    this.SearchByFieldValues = GlobalData.ProductGoups;
                    break;

                case "Product Line":
                    this.SearchByFieldValues = ItemService.RetrieveProductLinesAll();
                    break;

                case "Stats Code":
                    this.SearchByFieldValues = ItemService.RetrieveStatsCodes();
                    break;

                case "Tariff Code":
                    this.SearchByFieldValues = GlobalData.TariffCodes;
                    break;
            }
        }

        /// <summary>
        ///     Sorts List by Item Ids
        /// </summary>
        public void SortItemIds()
        {
            List<SearchItem> SortedList = new List<SearchItem>();
            if (ItemIdSearchOrder == 0)
            {
                SortedList = this.SearchItemList.OrderByDescending(o => o.ItemId).ToList();
                ItemIdSearchOrder = 1;
            }
            else
            {
                SortedList = this.SearchItemList.OrderBy(o => o.ItemId).ToList();
                ItemIdSearchOrder = 0;
            }
            this.SearchItemList = new ObservableCollection<SearchItem>();
            foreach (SearchItem item in SortedList)
            {
                this.SearchItemList.Add(item);
            }
        }

        /// <summary>
        ///     Sorts List by Description
        /// </summary>
        public void SortDescriptions()
        {
            List<SearchItem> SortedList = new List<SearchItem>();
            if (DescriptionIdSearchOrder == 0)
            {
                SortedList = this.SearchItemList.OrderByDescending(o => o.Description).ToList();
                DescriptionIdSearchOrder = 1;
            }
            else
            {
                SortedList = this.SearchItemList.OrderBy(o => o.Description).ToList();
                DescriptionIdSearchOrder = 0;
            }
            this.SearchItemList = new ObservableCollection<SearchItem>();
            foreach(SearchItem item in SortedList)
            {
                this.SearchItemList.Add(item);
            }
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the Find Item View Model
        /// </summary>
        /// <param name="type"></param>
        /// <param name="itemService"></param>
        /// <param name="workbookReader"></param>
        public FindItemViewModel(string type, ItemService itemService, WorkbookReader workbookReader)
        {
            this.BackgroundWorker = new BackgroundWorker();
            this.ItemService = itemService?? throw new ArgumentNullException("itemService");
            this.WorkbookReader = workbookReader?? throw new ArgumentNullException("workbookReader");
            this.UpdateType = type;
            this.SearchByFields = SetSearchByFields();
            this.Title = type + " Items";
            this.ItemIdSearchOrder = 0;
            this.DescriptionIdSearchOrder = 0;
        }

        #endregion //Constructor
    }
}
