using Mvvm;
using Odin.Views;
using OdinModels;
using OdinServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Odin.ViewModels
{
    public class EcommercePullViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region Commands

        public ICommand PullCommand
        {
            get
            {
                if (_about == null)
                {
                    _about = new RelayCommand(param => PullTemplate());
                }
                return _about;
            }
        }
        private RelayCommand _about;

        #endregion // Commands

        #region Properties

        /// <summary>
        ///     Gets or sets the End Date
        /// </summary>
        public string EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                OnPropertyChanged("EndDate");
            }
        }
        private string _endDate = "";

        /// <summary>
        ///     Gets or sets the view model's excel service
        /// </summary>
        public ExcelService ExcelService { get; set; }

        /// <summary>
        ///     Gets or sets the Item Ids List
        /// </summary>
        public ObservableCollection<ItemObject> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("ItemIds");
            }
        }
        private ObservableCollection<ItemObject> _items = new ObservableCollection<ItemObject>();

        /// <summary>
        ///     Gets or sets the view model's item service
        /// </summary>
        public ItemService ItemService { get; set; }

        /// <summary>
        ///     Gets or sets the Message
        /// </summary>
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }
        private string _message = "";

        /// <summary>
        ///     Gets or sets the Start Date
        /// </summary>
        public string StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }
        private string _startDate = "";

        /// <summary>
        ///     Gets or sets the Search Enabled
        /// </summary>
        public string SearchEnabled
        {
            get
            {
                return _searchEnabled;
            }
            set
            {
                _searchEnabled = value;
                OnPropertyChanged("SearchEnabled");
            }
        }
        private string _searchEnabled = "True";

        /// <summary>
        ///     Gets or sets the Template
        /// </summary>
        public string Template
        {
            get
            {
                return _template;
            }
            set
            {
                _template = value;
                OnPropertyChanged("Template");
            }
        }
        private string _template = "Amazon Posters";

        /// <summary>
        ///     Gets or sets the Template List
        /// </summary>
        public List<string> TemplateList
        {
            get
            {
                return _templateList;
            }
            set
            {
                _templateList = value;
                OnPropertyChanged("TemplateList");
            }
        }

        public string EndDate1 { get => _endDate; set => _endDate = value; }

        private List<string> _templateList = new List<string>();
        
        #endregion // Properties

        #region Methods
         
        /// <summary>
        ///     Calls to the item service to create the appropriate template.
        /// </summary>
        public void PullTemplate()
        {
            string endDate = (string.IsNullOrEmpty(this.EndDate)) ? "1/1/2099" : this.EndDate;
            string startDate = (string.IsNullOrEmpty(this.StartDate)) ? "1/1/1900" : this.StartDate;
            startDate = DbUtil.StripDateTime(startDate);
            endDate = DbUtil.StripDateTime(endDate);

            if (!string.IsNullOrEmpty(this.Template))
            {
                try
                {
                    string customer = ExcelService.RetrieveExcelLayoutCustomer(this.Template);
                    string productType = ExcelService.RetrieveExcelLayoutProductType(this.Template);
                    if (this.Items.Count == 0)
                    {
                        List<string> itemIds = ItemService.RetrieveActiveEcommerceItemIds(startDate, endDate, productType, customer);
                        ObservableCollection<ItemObject> itemList = new ObservableCollection<ItemObject>();
                        int row = 1;
                        foreach (string itemId in itemIds)
                        {
                            itemList.Add(ItemService.RetrieveItem(itemId, row));
                            row++;
                        }
                        this.Items = itemList;
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.LogError("Odin was unable to retrieve active items from the database.", ex.ToString());
                }

                try
                {
                    ExcelService.CreateItemWorkbook(this.Template, this.Items);
                    if (ExcelService.MissingFtpFiles.Count > 0)
                    {
                        AlertView window = new AlertView()
                        {
                            DataContext = new AlertViewModel(ExcelService.MissingFtpFiles, "Alert", "The following images were not found in the external captures folder.")
                        };
                        window.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.LogError("Odin was unable to retrieve the excel layout data.", ex.ToString());
                }
            }
            else
            {
                AlertView window = new AlertView()
                {
                    DataContext = new AlertViewModel("", "Alert", "Please select a template type.")
                };
                window.ShowDialog();
            }
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the EcommercePullViewModel
        /// </summary>
        /// <param name="itemService"></param>
        /// <param name="excelService"></param>
        /// <param name="items"></param>
        public EcommercePullViewModel(ItemService itemService, ExcelService excelService, ObservableCollection<ItemObject> items = null)
        {
            if (itemService == null) { throw new ArgumentNullException("itemService"); }
            if (excelService == null) { throw new ArgumentNullException("excelService"); }
            this.ExcelService = excelService;
            this.ItemService = itemService;
            if (items.Count > 0)
            {
                this.Items = items;
                this.SearchEnabled = "False";
                this.Message = "Clear items from list to pull from date range.";
            }
            else
            {
                this.SearchEnabled = "True";
            }
            try
            {
                foreach (Layout layout in ExcelService.RetrieveExcelLayouts())
                {
                    this.TemplateList.Add(layout.Name);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError("Odin was unable to retrieve the excel layout data.", ex.ToString());
            }
        }

        #endregion // Constructor
    }
}
