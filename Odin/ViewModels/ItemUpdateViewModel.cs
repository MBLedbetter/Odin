using ExcelLibrary;
using Microsoft.Win32;
using Mvvm;
using OdinModels;
using OdinServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using Odin.Views;

namespace Odin.ViewModels
{
    public class ItemUpdateViewModel : ViewModelBase
    {

        #region Commands

        public ICommand AddListCommand
        {
            get
            {
                if (_addList == null)
                {
                    _addList = new RelayCommand(param => LoadExcelInfo());
                }
                return _addList;
            }
        }
        private RelayCommand _addList;

        #endregion // Commands

        #region Properties

        /// <summary>
        ///     Gets or set the AbsentIds list. List of missing ids from uploaded list.
        /// </summary>
        public List<string> AbsentIds
        {
            get
            {
                return _absentIds;
            }
            set
            {
                _absentIds = value;
            }
        }
        private List<string> _absentIds = new List<string>();

        /// <summary>
        ///     Gets or sets the button visibility. hides action buttons while background is running.
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

        public ExcelService ExcelService { get; set; }

        public int IsKit
        {
            get
            {
                return _isKit;
            }
            set
            {
                _isKit = value;
            }
        }
        private int _isKit { get; set; }

        public bool IsKitFlag
        {
            get
            {
                return _isKitFlag;
            }
            set
            {
                if (value == true)
                {
                    this.IsKit = 0;
                }
                else
                {
                    this.IsKit = 1;
                }
                _isKitFlag = value;
                OnPropertyChanged("IsKitFlag");
            }
        }
        private bool _isKitFlag = false;

        /// <summary>
        ///     List of item Ids to be updated
        /// </summary>
        public ObservableCollection<ItemObject> ItemList
        {
            get
            {
                if (_itemList == null)
                {
                    _itemList = new ObservableCollection<ItemObject>();
                }
                return _itemList;
            }
            set
            {
                _itemList = value;
                OnPropertyChanged("ItemList");
            }
        }
        private ObservableCollection<ItemObject> _itemList;

        public int LoadItemCount
        {
            get { return _loadItemCount; }
            set { _loadItemCount = value; }
        }
        private int _loadItemCount = 0;

        public ItemService ItemService { get; set; }

        /// <summary>
        ///     List of loaded excel items
        /// </summary>
        public ObservableCollection<ItemObject> LoadedItems
        {
            get
            {
                return _loadedItems;
            }
            set
            {
                _loadedItems = value;
                OnPropertyChanged("LoadedItems");
            }
        }
        private ObservableCollection<ItemObject> _loadedItems = new ObservableCollection<ItemObject>();

        public string ProgressCheck
        {
            get
            {
                return _progressCheck;
            }
            set
            {
                _progressCheck = value;
                OnPropertyChanged("ProgressCheck");
            }
        }
        private string _progressCheck = string.Empty;

        /// <summary>
        ///     Item id input field
        /// </summary>
        string UpdateType { get; set; }

        private readonly BackgroundWorker LoadItemWorker = new BackgroundWorker();

        #endregion // properties

        #region Methods

        /// <summary>
        ///     Checks that collumn headers are correct and alerts user if any are misspelled
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private void CheckColumnHeaders(string fileName)
        {
            List<string> wrongHeaders = ItemService.ValidateHeaderCollumns(fileName);
            if(wrongHeaders.Count>0)
            {
                AlertView window = new AlertView();
                window.DataContext = new AlertViewModel(wrongHeaders, "Alert", "The following columns did not match any existing values. Please adjust the header or remove this collumn before loading.");
                window.ShowDialog();
            }
        }

        private void LoadItemWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ObservableCollection<ItemObject> collection = GetItems(this.LoadedItems);
            e.Result = collection;
        }

        private void LoadItemWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (ItemObject item in (ObservableCollection<ItemObject>)e.Result)
            {
                this.ItemList.Add(item);
            }
            if (this.AbsentIds.Count > 0)
            {
                AlertView window = new AlertView();
                window.DataContext = new AlertViewModel(this.AbsentIds, "Alert", "The following item ids are either duplicates in the load sheet \r\n or they have not been previously saved to the database.");
                window.ShowDialog();
            }
            this.ProgressCheck = "Item Load Complete";
            this.ButtonVisibility = "True";
        }

        public void LoadItemWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == this.LoadItemCount)
            {
                this.ProgressCheck = "Item Load Complete";
            }
            else
            {
                this.ProgressCheck = "Gathering Existing Data for item # " + e.ProgressPercentage.ToString() + " of " + this.LoadItemCount.ToString();
            }
        }
        
        public ObservableCollection<ItemObject> GetItems(ObservableCollection<ItemObject> loadedValues)
        {
            int count = 1;
            List<string> itemIds = new List<string>();
            ObservableCollection<ItemObject> Returnvalues = new ObservableCollection<ItemObject>();

            foreach (ItemObject item in loadedValues)
            {
                itemIds.Add(item.ItemId);
                if ((ItemService.CheckIdDuplicate(item.ItemId, itemIds))&&GlobalData.ItemIds.Contains(item.ItemId))
                {
                    try
                    {
                        ItemObject newItem = ItemService.CompleteItem(item, count);
                        Returnvalues.Add(newItem);
                        LoadItemWorker.ReportProgress(count);
                        count++;
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.LogError("Odin was unable to complete the given item " + item.ItemId, ex.ToString());
                    }
                }
                else
                {
                    this.AbsentIds.Add(item.ItemId);
                }
            }
            return Returnvalues;
        }

        /// <summary>
        ///     Load info from excell sheet and fill in any missing fields with db data
        /// </summary>
        public void LoadExcelInfo()
        {
            WorkbookReader workbookReader = new WorkbookReader();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel files|*.xls; *.xlsx";
            if (dialog.ShowDialog() != true)
            {
                return;
            }
            CheckColumnHeaders(dialog.FileName);
            try
            {
                this.ProgressCheck = "Loading Data from excel sheet...";
                this.LoadedItems = this.ItemService.LoadExcelItems("Update", dialog.FileName);
                this.LoadItemCount = LoadedItems.Count;
                this.ButtonVisibility = "False";
                LoadItemWorker.DoWork += LoadItemWorker_DoWork;
                LoadItemWorker.ProgressChanged += LoadItemWorker_ProgressChanged;
                LoadItemWorker.RunWorkerCompleted += LoadItemWorker_RunWorkerCompleted;
                LoadItemWorker.WorkerReportsProgress = true;
                LoadItemWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError("Odin was unable to load the additional information for the excel items.", ex.ToString());
            }            
        }

        public ObservableCollection<ItemObject> ReturnList()
        {
            return new ObservableCollection<ItemObject>(ItemList);
        }

        #endregion // Methods

        #region Constructor

        public ItemUpdateViewModel(ItemService itemService, ExcelService excelService)
        {
            if (itemService == null) { throw new ArgumentNullException("itemService"); }
            if (excelService == null) { throw new ArgumentNullException("excelService"); }
            this.ItemService = itemService;
            this.ExcelService = excelService;
        }

        #endregion // Constructor
    }
}
