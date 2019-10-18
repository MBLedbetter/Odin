using Microsoft.Win32;
using Mvvm;
using OdinServices;
using Odin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using ExcelLibrary;
using OdinModels;
using System.ComponentModel;
using System.Linq;

namespace Odin.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        #region Command Properties
        
        public ICommand AboutCommand
        {
            get
            {
                if (_about == null)
                {
                    _about = new RelayCommand(param => About());
                }
                return _about;
            }
        }
        private RelayCommand _about;
        public ICommand CreateEcommerceExcelCommand
        {
            get
            {
                if (_createEcommerceExcel == null)
                {
                    _createEcommerceExcel = new RelayCommand(param => CreateAmazonExcelFromList(Items));
                }
                return _createEcommerceExcel;
            }
        }
        private RelayCommand _createEcommerceExcel;
        public ICommand CreateFullExcelCommand
        {
            get
            {
                if (_createFullExcel == null)
                {
                    _createFullExcel = new RelayCommand(param => ExcelService.CreateItemWorkbook("**Item", this.Items));
                }
                return _createFullExcel;
            }
        }
        private RelayCommand _createFullExcel;
        public ICommand CreateFullTemplateCommand
        {
            get
            {
                if (_createFullTemplate == null)
                {
                    _createFullTemplate = new RelayCommand(param => ExcelService.CreateItemWorkbook("**Template", this.Items));
                }
                return _createFullTemplate;
            }
        }
        private RelayCommand _createFullTemplate;
        public ICommand DBSettingsCommand
        {
            get
            {
                if (_dBSettings == null)
                {
                    _dBSettings = new RelayCommand(param => EditDbSettings());
                }
                return _dBSettings;
            }
        }
        private RelayCommand _dBSettings;
        public ICommand DeleteItemCommand
        {
            get
            {
                if (_deleteItemCommand == null)
                {
                    _deleteItemCommand = new RelayCommand(param => FindItem("Remove"));
                }
                return _deleteItemCommand;
            }
        }
        private RelayCommand _deleteItemCommand;
        public ICommand EditSelectedErrorCommand
        {
            get
            {
                if (_editSelectedErrorCommand == null)
                {
                    _editSelectedErrorCommand = new RelayCommand(param => EditSelectedError());
                }
                return _editSelectedErrorCommand;
            }
        }
        private RelayCommand _editSelectedErrorCommand;
        public ICommand EditSelectedItemCommand
        {
            get
            {
                if (_editSelectedItemCommand == null)
                {
                    _editSelectedItemCommand = new RelayCommand(param => EditSelectedItem(null));
                }
                return _editSelectedItemCommand;
            }
        }
        private RelayCommand _editSelectedItemCommand;
        public ICommand FindItemCommand
        {
            get
            {
                if (_findItemCommand == null)
                {
                    _findItemCommand = new RelayCommand(param => FindItem("Update"));
                }
                return _findItemCommand;
            }
        }
        private RelayCommand _findItemCommand;
        public ICommand FindItemUpdateRecordCommand
        {
            get
            {
                if (_findItemUpdateRecordCommand == null)
                {
                    _findItemUpdateRecordCommand = new RelayCommand(param => FindItemUpdateRecord());
                }
                return _findItemUpdateRecordCommand;
            }
        }
        private RelayCommand _findItemUpdateRecordCommand;
        public ICommand FormRefreshCommand
        {
            get
            {
                if (_formRefreshCommand == null)
                {
                    _formRefreshCommand = new RelayCommand(param => FormRefresh());
                }
                return _formRefreshCommand;
            }
        }
        private RelayCommand _formRefreshCommand;
        public ICommand HelpCommand
        {
            get
            {
                if (_helpCommand == null)
                {
                    _helpCommand = new RelayCommand(param => OpenHelpWindow());
                }
                return _helpCommand;
            }
        }
        private RelayCommand _helpCommand;
        public ICommand ItemRecordsCommand
        {
            get
            {
                if (_itemRecordsCommand == null)
                {
                    _itemRecordsCommand = new RelayCommand(param => OpenItemRecordsWindow());
                }
                return _itemRecordsCommand;
            }
        }
        private RelayCommand _itemRecordsCommand;
        public ICommand ItemUpdateReportCommand
        {
            get
            {
                if (_itemUpdateRecordCommand == null)
                {
                    _itemUpdateRecordCommand = new RelayCommand(param => OpenItemUpdateReportWindow());
                }
                return _itemUpdateRecordCommand;
            }
        }
        private RelayCommand _itemUpdateRecordCommand;
        public ICommand LoadItemsCommand
        {
            get
            {
                if (_loadItemsCommand == null)
                {
                    _loadItemsCommand = new RelayCommand(param => LoadItems());
                }
                return _loadItemsCommand;
            }
        }
        private RelayCommand _loadItemsCommand;
        public ICommand LoadTemplateCommand
        {
            get
            {
                if (_loadTemplatesCommand == null)
                {
                    _loadTemplatesCommand = new RelayCommand(param => LoadTemplates());
                }
                return _loadTemplatesCommand;
            }
        }
        private RelayCommand _loadTemplatesCommand;
        public ICommand ManageFieldCommand
        {
            get
            {
                if (_editCategoryCommand == null)
                {
                    _editCategoryCommand = new RelayCommand(param => OpenManageFieldsWindow());
                }
                return _editCategoryCommand;
            }
        }
        private RelayCommand _editCategoryCommand;
        public ICommand ManagePermisionCommand
        {
            get
            {
                if (_managePermision == null)
                {
                    _managePermision = new RelayCommand(param => ManagePermision());
                }
                return _managePermision;
            }
        }
        private RelayCommand _managePermision;
        public ICommand Magento1CustomExcelCommand
        {
            get
            {
                if (_magento1CustomExcel == null)
                {
                    _magento1CustomExcel = new RelayCommand(param => CreateMagento1CustomExcel());
                }
                return _magento1CustomExcel;
            }
        }
        private RelayCommand _magento1CustomExcel;
        public ICommand Magento2CustomExcelCommand
        {
            get
            {
                if (_magento2CustomExcel == null)
                {
                    _magento2CustomExcel = new RelayCommand(param => CreateMagento2CustomExcel());
                }
                return _magento2CustomExcel;
            }
        }
        private RelayCommand _magento2CustomExcel;
        public ICommand NewTemplateCommand
        {
            get
            {
                if (_newTemplate == null)
                {
                    _newTemplate = new RelayCommand(param => NewTemplate());
                }
                return _newTemplate;
            }
        }
        private RelayCommand _newTemplate;
        public ICommand OpenExcelGeneratorCommand
        {
            get
            {
                if (_openExcelGenerator == null)
                {
                    _openExcelGenerator = new RelayCommand(param => OpenExcelGenerator());
                }
                return _openExcelGenerator;
            }
        }
        private RelayCommand _openExcelGenerator;
        public ICommand OptionsCommand
        {
            get
            {
                if (_options == null)
                {
                    _options = new RelayCommand(param => OpenOptionsWindow());
                }
                return _options;
            }
        }
        private RelayCommand _options;
        public ICommand PullEcommerceCommand
        {
            get
            {
                if (_createAllAmazonItems == null)
                {
                    _createAllAmazonItems = new RelayCommand(param => CreateAmazonExcelFromList());
                }
                return _createAllAmazonItems;
            }
        }
        private RelayCommand _createAllAmazonItems;
        public ICommand PullImagesCommand
        {
            get
            {
                if (_pullImages == null)
                {
                    _pullImages = new RelayCommand(param => PullImages());
                }
                return _pullImages;
            }
        }
        private RelayCommand _pullImages;
        public ICommand RemoveSelectedItemCommand
        {
            get
            {
                if (_removeSelectedItem == null)
                {
                    _removeSelectedItem = new RelayCommand(param => RemoveItem());
                }
                return _removeSelectedItem;
            }
        }
        private RelayCommand _removeSelectedItem;
        public ICommand RequestEcommerceImageListCommand
        {
            get
            {
                if (_requestEcommerceImageList == null)
                {
                    _requestEcommerceImageList = new RelayCommand(param => ViewEcommerceImageList());
                }
                return _requestEcommerceImageList;
            }
        }
        private RelayCommand _requestEcommerceImageList;
        public ICommand RequestEcommerceImagesCommand
        {
            get
            {
                if (_requestEcommerceImages == null)
                {
                    _requestEcommerceImages = new RelayCommand(param => SubmitEcommerceImages());
                }
                return _requestEcommerceImages;
            }
        }
        private RelayCommand _requestEcommerceImages;
        public ICommand SaveItemsCommand
        {
            get
            {
                if (_saveItemsCommand == null)
                {
                    _saveItemsCommand = new RelayCommand(param => SaveItems());
                }
                return _saveItemsCommand;
            }
        }
        private RelayCommand _saveItemsCommand;
        public ICommand SubmitItemsCommand
        {
            get
            {
                if (_submitItemsCommand == null)
                {
                    _submitItemsCommand = new RelayCommand(param => SubmitItems());
                }
                return _submitItemsCommand;
            }
        }
        private RelayCommand _submitItemsCommand;
        public ICommand TemplateAllCommand
        {
            get
            {
                if (_templateAllCommand == null)
                {
                    _templateAllCommand = new RelayCommand(param => OpenTemplateAll());
                }
                return _templateAllCommand;
            }
        }
        private RelayCommand _templateAllCommand;
        public ICommand UpdateHistoryCommand
        {
            get
            {
                if (_updateHistoryCommand == null)
                {
                    _updateHistoryCommand = new RelayCommand(param => OpenNotificationHistory());
                }
                return _updateHistoryCommand;
            }
        }
        private RelayCommand _updateHistoryCommand;
        public ICommand UpdateNewCategoryCommand
        {
            get
            {
                if (_updateNewCategory == null)
                {
                    _updateNewCategory = new RelayCommand(param => UpdateNewCategory());
                }
                return _updateNewCategory;
            }
        }
        private RelayCommand _updateNewCategory;
        public ICommand UpdateTemplateCommand
        {
            get
            {
                if (_updateTemplate == null)
                {
                    _updateTemplate = new RelayCommand(param => UpdateTemplate());
                }
                return _updateTemplate;
            }
        }
        private RelayCommand _updateTemplate;
        public ICommand UpdateProductsCommand
        {
            get
            {
                if (_updateProductsCommand == null)
                {
                    _updateProductsCommand = new RelayCommand(param => UpdateProducts());
                }
                return _updateProductsCommand;
            }
        }
        private RelayCommand _updateProductsCommand;
        public ICommand UploadTemplateCommand
        {
            get
            {
                if (_uploadTemplateCommand == null)
                {
                    _uploadTemplateCommand = new RelayCommand(param => UploadTemplates());
                }
                return _uploadTemplateCommand;
            }
        }
        private RelayCommand _uploadTemplateCommand;
        public ICommand ViewDataCommand
        {
            get
            {
                if (_viewData == null)
                {
                    _viewData = new RelayCommand(param => ViewDataWindow());
                }
                return _viewData;
            }
        }
        private RelayCommand _viewData;
        
        public ICommand ValidateSpreadsheetCommand
        {
            get
            {
                if (_validateSpreadsheetCommand == null)
                {
                    _validateSpreadsheetCommand = new RelayCommand(param => ValidateSpreadSheet());
                }
                return _validateSpreadsheetCommand;
            }
        }
        private RelayCommand _validateSpreadsheetCommand;
        public ICommand ViewSubmissionsAdminCommand
        {
            get
            {
                if (_viewSubmissionsAdmin == null)
                {
                    _viewSubmissionsAdmin = new RelayCommand(param => ViewSubmissionsAdmin());
                }
                return _viewSubmissionsAdmin;
            }
        }
        private RelayCommand _viewSubmissionsAdmin;
        public ICommand ViewSubmissionsCommand
        {
            get
            {
                if (_viewSubmissions == null)
                {
                    _viewSubmissions = new RelayCommand(param => ViewSubmissions());
                }
                return _viewSubmissions;
            }
        }
        private RelayCommand _viewSubmissions;

        #endregion // Command Properties

        #region Properties     

        // private BackgroundWorker BackgroundWorker { get; set; }

        // private string BackgroundWorkerState = string.Empty;

        /// <summary>
        ///     Gets or sets the EmailService
        /// </summary>
        public EmailService EmailService { get; set; }

        /// <summary>
        ///     Gets or sets the ExcelService
        /// </summary>
        public ExcelService ExcelService { get; set; }

        /// <summary>
        ///     Gets or sets the FtpService
        /// </summary>
        public FtpService FtpService { get; set; }

        /// <summary>
        ///     List of validation errors coresponding to the Items list
        /// </summary>
        public ObservableCollection<ItemError> ItemErrors
        {
            get
            {
                if (_itemErrors == null)
                {
                    _itemErrors = new ObservableCollection<ItemError>();
                }
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
        ///		List of items loaded into MainWindowViewModel
        /// </summary>
        public ObservableCollection<ItemObject> Items
        {
            get
            {
                return _items;
            }
            private set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }
        private ObservableCollection<ItemObject> _items = new ObservableCollection<ItemObject>();

        /// <summary>
        ///     Gets or sets the ItemService
        /// </summary>
        public ItemService ItemService { get; set; }

        /// <summary>
        ///     Gets or sets the Option Service
        /// </summary>
        public OptionService OptionService { get; set; }

        /// <summary>
        ///     Gets the permissionAdminVisibility. Shows or hides admin controls.
        /// </summary>
        public string PermissionAdminVisibility
        {
            get
            {
                if (GlobalData.UserPermissions.Contains("ADMIN_CONTROLS"))
                {
                    return "Visible";
                }
                else return "Hidden";
            }
        }

        /// <summary>
        ///     Gets the PermissionEcommerceControlVisibility. Shows or hides ecommerce controls.
        /// </summary>
        public string PermissionEcommerceControlVisibility
        {
            get
            {
                if (GlobalData.UserPermissions.Contains("ECOMMERCE_CONTROL"))
                {
                    return "Visible";
                }
                else return "Hidden";
            }
        }

        /// <summary>
        ///     Gets or sets the PermissionRequestNewCategoryVisibility. Shows or hides the request new category button.
        /// </summary>
        public string PermissionRequestNewCategoryVisibility
        {
            get
            {
                if (GlobalData.UserPermissions.Contains("ADMIN_CONTROLS"))
                {
                    return "Visible";
                }
                else return "Hidden";
            }
        }

        /// <summary>
        ///     Gets the PermissionSaveItemVisibility. Shows or hides save button.
        /// </summary>
        public string PermissionSaveItemVisibility
        {
            get
            {
                if (GlobalData.UserPermissions.Contains("SAVE_ITEMS"))
                {
                    return "Visible";
                }
                else return "Hidden";
            }
        }

        /// <summary>
        ///     Gets the PermissionSubmitItemVisibility. Shows or hides the submit button.
        /// </summary>
        public string PermissionSubmitItemVisibility
        {
            get
            {
                if (GlobalData.UserPermissions.Contains("WEB_SUBMIT"))
                {
                    return "Visible";
                }
                else return "Hidden";
            }
        }

        /// <summary>
        ///     Gets or sets the PermissionTest. Shows or hides whatever is currently being tested. 
        ///     Current Test: Templates
        /// </summary>
        public string PermissionTest
        {
            get
            {
                return _permissionTest;
            }
            set
            {
                _permissionTest = value;
                OnPropertyChanged("PermissionTest");
            }
        }
        private string _permissionTest = "Hidden";

        /// <summary>
        ///     Gets or sets the footer message
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
        private string _progressText;

        /// <summary>
        ///     Bool keeps track of if items have been saved
        /// </summary>
        public bool SaveStatus
        {
            get
            {
                return _saveStatus;
            }
            set
            {
                _saveStatus = value;
                OnPropertyChanged("SaveStatus");
            }
        }
        private bool _saveStatus;

        /// <summary>
        ///     The error that is selected in the view that this view model is bound to.
        /// </summary>
        public ItemError SelectedError { get; set; }

        /// <summary>
        ///     The item that is selected in the view that this view model is bound to.
        /// </summary>
        public ItemObject SelectedItem { get; set; }

        /// <summary>
        ///     Bool keeps track of if items have been saved
        /// </summary>
        public bool SubmitStatus
        {
            get
            {
                return _submitStatus;
            }
            set
            {
                _submitStatus = value;
                OnPropertyChanged("SubmitStatus");
            }
        }
        private bool _submitStatus;
         
        /// <summary>
        ///     Display Title for top bar of main window view
        /// </summary>
        public string WindowTitle
        {
            get
            {
                return _windowTitle;
            }
            set
            {
                _windowTitle = value;
                OnPropertyChanged("WindowTitle");
            }
        }
        private string _windowTitle;

        public WorkbookReader WorkbookReader { get; set; }

        #region Visibility Properties

        /// <summary>
        ///     Gets or sets the AccountingGroupVisibility field
        /// </summary>
        public string AccountingGroupVisibility
        {
            get
            {
                return _accountingGroupVisibility;
            }
            set
            {
                _accountingGroupVisibility = value;
                OnPropertyChanged("AccountingGroupVisibility");
            }
        }
        private string _accountingGroupVisibility = "auto";

        /// <summary>
        ///     Gets or sets the BillOfMaterialsVisibility field
        /// </summary>
        public string BillOfMaterialsVisibility
        {
            get
            {
                return _billOfMaterialsVisibility;
            }
            set
            {
                _billOfMaterialsVisibility = value;
                OnPropertyChanged("BillOfMaterialsVisibility");
            }
        }
        private string _billOfMaterialsVisibility = "auto";

        /// <summary>
        ///     Gets or sets the CasepackHeightVisibility field
        /// </summary>
        public string CasepackHeightVisibility
        {
            get
            {
                return _casepackHeightVisibility;
            }
            set
            {
                _casepackHeightVisibility = value;
                OnPropertyChanged("CasepackHeightVisibility");
            }
        }
        private string _casepackHeightVisibility = "auto";

        /// <summary>
        ///     Gets or sets the CasepackLengthVisibility field
        /// </summary>
        public string CasepackLengthVisibility
        {
            get
            {
                return _casepackLengthVisibility;
            }
            set
            {
                _casepackLengthVisibility = value;
                OnPropertyChanged("CasepackLengthVisibility");
            }
        }
        private string _casepackLengthVisibility = "auto";

        /// <summary>
        ///     Gets or sets the CasepackQtyVisibility field
        /// </summary>
        public string CasepackQtyVisibility
        {
            get
            {
                return _casepackQtyVisibility;
            }
            set
            {
                _casepackQtyVisibility = value;
                OnPropertyChanged("CasepackQtyVisibility");
            }
        }
        private string _casepackQtyVisibility = "auto";

        /// <summary>
        ///     Gets or sets the CasepackUpcVisibility field
        /// </summary>
        public string CasepackUpcVisibility
        {
            get
            {
                return _casepackUpcVisibility;
            }
            set
            {
                _casepackUpcVisibility = value;
                OnPropertyChanged("CasepackUpcVisibility");
            }
        }
        private string _casepackUpcVisibility = "auto";

        /// <summary>
        ///     Gets or sets the CasepackWidthVisibility field
        /// </summary>
        public string CasepackWidthVisibility
        {
            get
            {
                return _casepackWidthVisibility;
            }
            set
            {
                _casepackWidthVisibility = value;
                OnPropertyChanged("CasepackWidthVisibility");
            }
        }
        private string _casepackWidthVisibility = "auto";

        /// <summary>
        ///     Gets or sets the CasepackWeightVisibility field
        /// </summary>
        public string CasepackWeightVisibility
        {
            get
            {
                return _casepackWeightVisibility;
            }
            set
            {
                _casepackWeightVisibility = value;
                OnPropertyChanged("CasepackWeightVisibility");
            }
        }
        private string _casepackWeightVisibility = "auto";

        /// <summary>
        ///     Gets or sets the ColorVisibility field
        /// </summary>
        public string ColorVisibility
        {
            get
            {
                return _colorVisibility;
            }
            set
            {
                _colorVisibility = value;
                OnPropertyChanged("ColorVisibility");
            }
        }
        private string _colorVisibility = "auto";

        /// <summary>
        ///     Gets or sets the CountryOfOriginVisibility field
        /// </summary>
        public string CountryOfOriginVisibility
        {
            get
            {
                return _countryOfOriginVisibility;
            }
            set
            {
                _countryOfOriginVisibility = value;
                OnPropertyChanged("CountryOfOriginVisibility");
            }
        }
        private string _countryOfOriginVisibility = "auto";

        /// <summary>
        ///     Gets or sets the CostProfileGroupVisibility field
        /// </summary>
        public string CostProfileGroupVisibility
        {
            get
            {
                return _costProfileGroupVisibility;
            }
            set
            {
                _costProfileGroupVisibility = value;
                OnPropertyChanged("CostProfileGroupVisibility");
            }
        }
        private string _costProfileGroupVisibility = "auto";

        /// <summary>
        ///     Gets or sets the DefaultActualCostCadVisibility field
        /// </summary>
        public string DefaultActualCostCadVisibility
        {
            get
            {
                return _defaultActualCostCadVisibility;
            }
            set
            {
                _defaultActualCostCadVisibility = value;
                OnPropertyChanged("DefaultActualCostCadVisibility");
            }
        }
        private string _defaultActualCostCadVisibility = "auto";

        /// <summary>
        ///     Gets or sets the DefaultActualCostUsdVisibility field
        /// </summary>
        public string DefaultActualCostUsdVisibility
        {
            get
            {
                return _defaultActualCostUsdVisibility;
            }
            set
            {
                _defaultActualCostUsdVisibility = value;
                OnPropertyChanged("DefaultActualCostUsdVisibility");
            }
        }
        private string _defaultActualCostUsdVisibility = "auto";

        /// <summary>
        ///     Gets or sets the DescriptionVisibility field
        /// </summary>
        public string DescriptionVisibility
        {
            get
            {
                return _descriptionVisibility;
            }
            set
            {
                _descriptionVisibility = value;
                OnPropertyChanged("DescriptionVisibility");
            }
        }
        private string _descriptionVisibility = "auto";

        /// <summary>
        ///     Gets or sets the DirectImportVisibility field
        /// </summary>
        public string DirectImportVisibility
        {
            get
            {
                return _directImportVisibility;
            }
            set
            {
                _directImportVisibility = value;
                OnPropertyChanged("DirectImportVisibility");
            }
        }
        private string _directImportVisibility = "auto";

        /// <summary>
        ///     Gets or sets the DutyVisibility field
        /// </summary>
        public string DutyVisibility
        {
            get
            {
                return _dutyVisibility;
            }
            set
            {
                _dutyVisibility = value;
                OnPropertyChanged("DutyVisibility");
            }
        }
        private string _dutyVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EanVisibility field
        /// </summary>
        public string EanVisibility
        {
            get
            {
                return _eanVisibility;
            }
            set
            {
                _eanVisibility = value;
                OnPropertyChanged("EanVisibility");
            }
        }
        private string _eanVisibility = "auto";

        /// <summary>
        ///     Gets or sets the Genre1Visibility field
        /// </summary>
        public string Genre1Visibility
        {
            get
            {
                return _genre1Visibility;
            }
            set
            {
                _genre1Visibility = value;
                OnPropertyChanged("Genre1Visibility");
            }
        }
        private string _genre1Visibility = "auto";

        /// <summary>
        ///     Gets or sets the Genre2Visibility field
        /// </summary>
        public string Genre2Visibility
        {
            get
            {
                return _genre2Visibility;
            }
            set
            {
                _genre2Visibility = value;
                OnPropertyChanged("Genre2Visibility");
            }
        }
        private string _genre2Visibility = "auto";

        /// <summary>
        ///     Gets or sets the Genre3Visibility field
        /// </summary>
        public string Genre3Visibility
        {
            get
            {
                return _genre3Visibility;
            }
            set
            {
                _genre3Visibility = value;
                OnPropertyChanged("Genre3Visibility");
            }
        }
        private string _genre3Visibility = "auto";

        /// <summary>
        ///     Gets or sets the GpcVisibility field
        /// </summary>
        public string GpcVisibility
        {
            get
            {
                return _gpcVisibility;
            }
            set
            {
                _gpcVisibility = value;
                OnPropertyChanged("GpcVisibility");
            }
        }
        private string _gpcVisibility = "auto";

        /// <summary>
        ///     Gets or sets the HeightVisibility field
        /// </summary>
        public string HeightVisibility
        {
            get
            {
                return _heightVisibility;
            }
            set
            {
                _heightVisibility = value;
                OnPropertyChanged("HeightVisibility");
            }
        }
        private string _heightVisibility = "auto";

        /// <summary>
        ///     Gets or sets the InnerpackHeightVisibility field
        /// </summary>
        public string InnerpackHeightVisibility
        {
            get
            {
                return _innerpackHeightVisibility;
            }
            set
            {
                _innerpackHeightVisibility = value;
                OnPropertyChanged("InnerpackHeightVisibility");
            }
        }
        private string _innerpackHeightVisibility = "auto";

        /// <summary>
        ///     Gets or sets the InnerpackLengthVisibility field
        /// </summary>
        public string InnerpackLengthVisibility
        {
            get
            {
                return _innerpackLengthVisibility;
            }
            set
            {
                _innerpackLengthVisibility = value;
                OnPropertyChanged("InnerpackLengthVisibility");
            }
        }
        private string _innerpackLengthVisibility = "auto";

        /// <summary>
        ///     Gets or sets the InnerpackQuantityVisibility field
        /// </summary>
        public string InnerpackQuantityVisibility
        {
            get
            {
                return _innerpackQuantityVisibility;
            }
            set
            {
                _innerpackQuantityVisibility = value;
                OnPropertyChanged("InnerpackQuantityVisibility");
            }
        }
        private string _innerpackQuantityVisibility = "auto";

        /// <summary>
        ///     Gets or sets the InnerpackUpcVisibility field
        /// </summary>
        public string InnerpackUpcVisibility
        {
            get
            {
                return _innerpackUpcVisibility;
            }
            set
            {
                _innerpackUpcVisibility = value;
                OnPropertyChanged("InnerpackUpcVisibility");
            }
        }
        private string _innerpackUpcVisibility = "auto";

        /// <summary>
        ///     Gets or sets the InnerpackWidthVisibility field
        /// </summary>
        public string InnerpackWidthVisibility
        {
            get
            {
                return _innerpackWidthVisibility;
            }
            set
            {
                _innerpackWidthVisibility = value;
                OnPropertyChanged("InnerpackWidthVisibility");
            }
        }
        private string _innerpackWidthVisibility = "auto";

        /// <summary>
        ///     Gets or sets the InnerpackWeightVisibility field
        /// </summary>
        public string InnerpackWeightVisibility
        {
            get
            {
                return _innerpackWeightVisibility;
            }
            set
            {
                _innerpackWeightVisibility = value;
                OnPropertyChanged("InnerpackWeightVisibility");
            }
        }
        private string _innerpackWeightVisibility = "auto";

        /// <summary>
        ///     Gets or sets the IsbnVisibility field
        /// </summary>
        public string IsbnVisibility
        {
            get
            {
                return _isbnVisibility;
            }
            set
            {
                _isbnVisibility = value;
                OnPropertyChanged("IsbnVisibility");
            }
        }
        private string _isbnVisibility = "auto";

        /// <summary>
        ///     Gets or sets the ItemCategoryVisibility field
        /// </summary>
        public string ItemCategoryVisibility
        {
            get
            {
                return _itemCategoryVisibility;
            }
            set
            {
                _itemCategoryVisibility = value;
                OnPropertyChanged("ItemCategoryVisibility");
            }
        }
        private string _itemCategoryVisibility = "auto";

        /// <summary>
        ///     Gets or sets the ItemFamilyVisibility field
        /// </summary>
        public string ItemFamilyVisibility
        {
            get
            {
                return _itemFamilyVisibility;
            }
            set
            {
                _itemFamilyVisibility = value;
                OnPropertyChanged("ItemFamilyVisibility");
            }
        }
        private string _itemFamilyVisibility = "auto";

        /// <summary>
        ///     Gets or sets the ItemGroupVisibility field
        /// </summary>
        public string ItemGroupVisibility
        {
            get
            {
                return _itemGroupVisibility;
            }
            set
            {
                _itemGroupVisibility = value;
                OnPropertyChanged("ItemGroupVisibility");
            }
        }
        private string _itemGroupVisibility = "auto";

        /// <summary>
        ///     Gets or sets the LanguageVisibility field
        /// </summary>
        public string LanguageVisibility
        {
            get
            {
                return _languageVisibility;
            }
            set
            {
                _languageVisibility = value;
                OnPropertyChanged("LanguageVisibility");
            }
        }
        private string _languageVisibility = "auto";

        /// <summary>
        ///     Gets or sets the LengthVisibility field
        /// </summary>
        public string LengthVisibility
        {
            get
            {
                return _lengthVisibility;
            }
            set
            {
                _lengthVisibility = value;
                OnPropertyChanged("LengthVisibility");
            }
        }
        private string _lengthVisibility = "auto";

        /// <summary>
        ///     Gets or sets the ListPriceCadVisibility field
        /// </summary>
        public string ListPriceCadVisibility
        {
            get
            {
                return _listPriceCadVisibility;
            }
            set
            {
                _listPriceCadVisibility = value;
                OnPropertyChanged("ListPriceCadVisibility");
            }
        }
        private string _listPriceCadVisibility = "auto";

        /// <summary>
        ///     Gets or sets the ListPriceMxnVisibility field
        /// </summary>
        public string ListPriceMxnVisibility
        {
            get
            {
                return _listPriceMxnVisibility;
            }
            set
            {
                _listPriceMxnVisibility = value;
                OnPropertyChanged("ListPriceMxnVisibility");
            }
        }
        private string _listPriceMxnVisibility = "auto";

        /// <summary>
        ///     Gets or sets the ListPriceUsdVisibility field
        /// </summary>
        public string ListPriceUsdVisibility
        {
            get
            {
                return _listPriceUsdVisibility;
            }
            set
            {
                _listPriceUsdVisibility = value;
                OnPropertyChanged("ListPriceUsdVisibility");
            }
        }
        private string _listPriceUsdVisibility = "auto";

        /// <summary>
        ///     Gets or sets the MfgSourceVisibility field
        /// </summary>
        public string MfgSourceVisibility
        {
            get
            {
                return _mfgSourceVisibility;
            }
            set
            {
                _mfgSourceVisibility = value;
                OnPropertyChanged("MfgSourceVisibility");
            }
        }
        private string _mfgSourceVisibility = "auto";

        /// <summary>
        ///     Gets or sets the MsrpVisibility field
        /// </summary>
        public string MsrpVisibility
        {
            get
            {
                return _msrpVisibility;
            }
            set
            {
                _msrpVisibility = value;
                OnPropertyChanged("MsrpVisibility");
            }
        }
        private string _msrpVisibility = "auto";

        /// <summary>
        ///     Gets or sets the MsrpCadVisibility field
        /// </summary>
        public string MsrpCadVisibility
        {
            get
            {
                return _msrpCadVisibility;
            }
            set
            {
                _msrpCadVisibility = value;
                OnPropertyChanged("MsrpCadVisibility");
            }
        }
        private string _msrpCadVisibility = "auto";

        /// <summary>
        ///     Gets or sets the MsrpMxnVisibility field
        /// </summary>
        public string MsrpMxnVisibility
        {
            get
            {
                return _msrpMxnVisibility;
            }
            set
            {
                _msrpMxnVisibility = value;
                OnPropertyChanged("MsrpMxnVisibility");
            }
        }
        private string _msrpMxnVisibility = "auto";

        /// <summary>
        ///     Gets or sets the PricingGroupVisibility field
        /// </summary>
        public string PricingGroupVisibility
        {
            get
            {
                return _pricingGroupVisibility;
            }
            set
            {
                _pricingGroupVisibility = value;
                OnPropertyChanged("PricingGroupVisibility");
            }
        }
        private string _pricingGroupVisibility = "auto";

        /// <summary>
        ///     Gets or sets the PrintOnDemandVisibility field
        /// </summary>
        public string PrintOnDemandVisibility
        {
            get
            {
                return _printOnDemandVisibility;
            }
            set
            {
                _printOnDemandVisibility = value;
                OnPropertyChanged("PrintOnDemandVisibility");
            }
        }
        private string _printOnDemandVisibility = "auto";

        /// <summary>
        ///     Gets or sets the ProductFormatVisibility field
        /// </summary>
        public string ProductFormatVisibility
        {
            get
            {
                return _productFormatVisibility;
            }
            set
            {
                _productFormatVisibility = value;
                OnPropertyChanged("ProductFormatVisibility");
            }
        }
        private string _productFormatVisibility = "auto";

        /// <summary>
        ///     Gets or sets the ProductGroupVisibility field
        /// </summary>
        public string ProductGroupVisibility
        {
            get
            {
                return _productGroupVisibility;
            }
            set
            {
                _productGroupVisibility = value;
                OnPropertyChanged("ProductGroupVisibility");
            }
        }
        private string _productGroupVisibility = "auto";

        /// <summary>
        ///     Gets or sets the ProductIdTranslationVisibility field
        /// </summary>
        public string ProductIdTranslationVisibility
        {
            get
            {
                return _productIdTranslationVisibility;
            }
            set
            {
                _productIdTranslationVisibility = value;
                OnPropertyChanged("ProductIdTranslationVisibility");
            }
        }
        private string _productIdTranslationVisibility = "auto";

        /// <summary>
        ///     Gets or sets the ProductLineVisibility field
        /// </summary>
        public string ProductLineVisibility
        {
            get
            {
                return _productLineVisibility;
            }
            set
            {
                _productLineVisibility = value;
                OnPropertyChanged("ProductLineVisibility");
            }
        }
        private string _productLineVisibility = "auto";

        /// <summary>
        ///     Gets or sets the ProductQtyVisibility field
        /// </summary>
        public string ProductQtyVisibility
        {
            get
            {
                return _productQtyVisibility;
            }
            set
            {
                _productQtyVisibility = value;
                OnPropertyChanged("ProductQtyVisibility");
            }
        }
        private string _productQtyVisibility = "auto";

        /// <summary>
        ///     Gets or sets the PsStatusVisibility field
        /// </summary>
        public string PsStatusVisibility
        {
            get
            {
                return _psStatusVisibility;
            }
            set
            {
                _psStatusVisibility = value;
                OnPropertyChanged("PsStatusVisibility");
            }
        }
        private string _psStatusVisibility = "auto";

        /// <summary>
        ///     Gets or sets the SatCodeVisibility field
        /// </summary>
        public string SatCodeVisibility
        {
            get
            {
                return _satCodeVisibility;
            }
            set
            {
                _satCodeVisibility = value;
                OnPropertyChanged("SatCodeVisibility");
            }
        }
        private string _satCodeVisibility = "auto";

        /// <summary>
        ///     Gets or sets the StandardCostVisibility field
        /// </summary>
        public string StandardCostVisibility
        {
            get
            {
                return _standardCostVisibility;
            }
            set
            {
                _standardCostVisibility = value;
                OnPropertyChanged("StandardCostVisibility");
            }
        }
        private string _standardCostVisibility = "auto";

        /// <summary>
        ///     Gets or sets the StatsCodeVisibility field
        /// </summary>
        public string StatsCodeVisibility
        {
            get
            {
                return _statsCodeVisibility;
            }
            set
            {
                _statsCodeVisibility = value;
                OnPropertyChanged("StatsCodeVisibility");
            }
        }
        private string _statsCodeVisibility = "auto";

        /// <summary>
        ///     Gets or sets the TariffCodeVisibility field
        /// </summary>
        public string TariffCodeVisibility
        {
            get
            {
                return _tariffCodeVisibility;
            }
            set
            {
                _tariffCodeVisibility = value;
                OnPropertyChanged("TariffCodeVisibility");
            }
        }
        private string _tariffCodeVisibility = "auto";

        /// <summary>
        ///     Gets or sets the TerritoryVisibility field
        /// </summary>
        public string TerritoryVisibility
        {
            get
            {
                return _territoryVisibility;
            }
            set
            {
                _territoryVisibility = value;
                OnPropertyChanged("TerritoryVisibility");
            }
        }
        private string _territoryVisibility = "auto";

        /// <summary>
        ///     Gets or sets the UdexVisibility field
        /// </summary>
        public string UdexVisibility
        {
            get
            {
                return _udexVisibility;
            }
            set
            {
                _udexVisibility = value;
                OnPropertyChanged("UdexVisibility");
            }
        }
        private string _udexVisibility = "auto";

        /// <summary>
        ///     Gets or sets the UpcVisibility field
        /// </summary>
        public string UpcVisibility
        {
            get
            {
                return _upcVisibility;
            }
            set
            {
                _upcVisibility = value;
                OnPropertyChanged("UpcVisibility");
            }
        }
        private string _upcVisibility = "auto";

        /// <summary>
        ///     Gets or sets the WarrantyVisibility field
        /// </summary>
        public string WarrantyVisibility
        {
            get
            {
                return _warrantyVisibility;
            }
            set
            {
                _warrantyVisibility = value;
                OnPropertyChanged("WarrantyVisibility");
            }
        }
        private string _warrantyVisibility = "auto";

        /// <summary>
        ///     Gets or sets the WarrantyCheckVisibility field
        /// </summary>
        public string WarrantyCheckVisibility
        {
            get
            {
                return _warrantyCheckVisibility;
            }
            set
            {
                _warrantyCheckVisibility = value;
                OnPropertyChanged("WarrantyCheckVisibility");
            }
        }
        private string _warrantyCheckVisibility = "auto";

        /// <summary>
        ///     Gets or sets the WebsitePriceVisibility field
        /// </summary>
        public string WebsitePriceOverrideVisibility
        {
            get
            {
                if (UserOptions.WebsitePriceOverrideVisibility)
                {
                    return "100";
                }
                else return "0";
            }
        }

        /// <summary>
        ///     Gets or sets the WebsitePriceVisibility field
        /// </summary>
        public string WebsitePriceVisibility
        {
            get
            {
                return _websitePriceVisibility;
            }
            set
            {
                _websitePriceVisibility = value;
                OnPropertyChanged("WebsitePriceVisibility");
            }
        }
        private string _websitePriceVisibility = "auto";

        /// <summary>
        ///     Gets or sets the WeightVisibility field
        /// </summary>
        public string WeightVisibility
        {
            get
            {
                return _weightVisibility;
            }
            set
            {
                _weightVisibility = value;
                OnPropertyChanged("WeightVisibility");
            }
        }
        private string _weightVisibility = "auto";

        /// <summary>
        ///     Gets or sets the WidthVisibility field
        /// </summary>
        public string WidthVisibility
        {
            get
            {
                return _widthVisibility;
            }
            set
            {
                _widthVisibility = value;
                OnPropertyChanged("WidthVisibility");
            }
        }
        private string _widthVisibility = "auto";

        /* B2B Visibility */

        /// <summary>
        ///     Gets or sets the CategoryVisibility field
        /// </summary>
        public string CategoryVisibility
        {
            get
            {
                return _categoryVisibility;
            }
            set
            {
                _categoryVisibility = value;
                OnPropertyChanged("CategoryVisibility");
            }
        }
        private string _categoryVisibility = "auto";

        /// <summary>
        ///     Gets or sets the Category2Visibility field
        /// </summary>
        public string Category2Visibility
        {
            get
            {
                return _category2Visibility;
            }
            set
            {
                _category2Visibility = value;
                OnPropertyChanged("Category2Visibility");
            }
        }
        private string _category2Visibility = "auto";

        /// <summary>
        ///     Gets or sets the Category3Visibility field
        /// </summary>
        public string Category3Visibility
        {
            get
            {
                return _category3Visibility;
            }
            set
            {
                _category3Visibility = value;
                OnPropertyChanged("Category3Visibility");
            }
        }
        private string _category3Visibility = "auto";

        /// <summary>
        ///     Gets or sets the CopyrightVisibility field
        /// </summary>
        public string CopyrightVisibility
        {
            get
            {
                return _copyrightVisibility;
            }
            set
            {
                _copyrightVisibility = value;
                OnPropertyChanged("CopyrightVisibility");
            }
        }
        private string _copyrightVisibility = "auto";

        /// <summary>
        ///     Gets or sets the InStockDateVisibility field
        /// </summary>
        public string InStockDateVisibility
        {
            get
            {
                return _inStockDateVisibility;
            }
            set
            {
                _inStockDateVisibility = value;
                OnPropertyChanged("InStockDateVisibility");
            }
        }
        private string _inStockDateVisibility = "auto";

        /// <summary>
        ///     Gets or sets the ItemKeywordsVisibility field
        /// </summary>
        public string ItemKeywordsVisibility
        {
            get
            {
                return _itemKeywordsVisibility;
            }
            set
            {
                _itemKeywordsVisibility = value;
                OnPropertyChanged("ItemKeywordsVisibility");
            }
        }
        private string _itemKeywordsVisibility = "auto";

        /// <summary>
        ///     Gets the ItemKeywordsVisibility field
        /// </summary>
        public string ItemKeywordsOverrideVisibility
        {
            get
            {
                if (UserOptions.ItemKeywordsOverrideVisibility)
                {
                    return "100";
                }
                else return "0";
            }
        }

        /// <summary>
        ///     Gets or sets the LicenseVisibility field
        /// </summary>
        public string LicenseVisibility
        {
            get
            {
                return _licenseVisibility;
            }
            set
            {
                _licenseVisibility = value;
                OnPropertyChanged("LicenseVisibility");
            }
        }
        private string _licenseVisibility = "auto";

        /// <summary>
        ///     Gets or sets the LicenseBeginDateVisibility field
        /// </summary>
        public string LicenseBeginDateVisibility
        {
            get
            {
                return _licenseBeginDateVisibility;
            }
            set
            {
                _licenseBeginDateVisibility = value;
                OnPropertyChanged("LicenseBeginDateVisibility");
            }
        }
        private string _licenseBeginDateVisibility = "auto";

        /// <summary>
        ///     Gets or sets the MetaDescriptionVisibility field
        /// </summary>
        public string MetaDescriptionVisibility
        {
            get
            {
                return _metaDescriptionVisibility;
            }
            set
            {
                _metaDescriptionVisibility = value;
                OnPropertyChanged("MetaDescriptionVisibility");
            }
        }
        private string _metaDescriptionVisibility = "auto";

        /// <summary>
        ///     Gets or sets the PropertyVisibility field
        /// </summary>
        public string PropertyVisibility
        {
            get
            {
                return _propertyVisibility;
            }
            set
            {
                _propertyVisibility = value;
                OnPropertyChanged("PropertyVisibility");
            }
        }
        private string _propertyVisibility = "auto";

        /// <summary>
        ///     Gets or sets the ShortDescriptionVisibility field
        /// </summary>
        public string ShortDescriptionVisibility
        {
            get
            {
                return _shortDescriptionVisibility;
            }
            set
            {
                _shortDescriptionVisibility = value;
                OnPropertyChanged("ShortDescriptionVisibility");
            }
        }
        private string _shortDescriptionVisibility = "auto";

        /// <summary>
        ///     Gets or sets the SizeVisibility field
        /// </summary>
        public string SizeVisibility
        {
            get
            {
                return _sizeVisibility;
            }
            set
            {
                _sizeVisibility = value;
                OnPropertyChanged("SizeVisibility");
            }
        }
        private string _sizeVisibility = "auto";

        /// <summary>
        ///     Gets or sets the TitleVisibility field
        /// </summary>
        public string TitleVisibility
        {
            get
            {
                return _titleVisibility;
            }
            set
            {
                _titleVisibility = value;
                OnPropertyChanged("TitleVisibility");
            }
        }
        private string _titleVisibility = "auto";

        /// <summary>
        ///     Gets the TitleVisibility field
        /// </summary>
        public string TitleOverrideVisibility
        {
            get
            {
                if (UserOptions.TitleOverrideVisibility)
                {
                    return "100";
                }
                else return "0";
            }
        }
        
        /* Sell On Visibility */

        /// <summary>
        ///     Gets or sets the SellOnAllPostersVisibility field
        /// </summary>
        public string SellOnAllPostersVisibility
        {
            get
            {
                return _sellOnAllPostersVisibility;
            }
            set
            {
                _sellOnAllPostersVisibility = value;
                OnPropertyChanged("SellOnAllPostersVisibility");
            }
        }
        private string _sellOnAllPostersVisibility = "auto";

        /// <summary>
        ///     Gets or sets the SellOnAmazonVisibility field
        /// </summary>
        public string SellOnAmazonVisibility
        {
            get
            {
                return _sellOnAmazonVisibility;
            }
            set
            {
                _sellOnAmazonVisibility = value;
                OnPropertyChanged("SellOnAmazonVisibility");
            }
        }
        private string _sellOnAmazonVisibility = "auto";

        /// <summary>
        ///     Gets or sets the SellOnAmazonSellerCentralVisibility field
        /// </summary>
        public string SellOnAmazonSellerCentralVisibility
        {
            get
            {
                return _sellOnAmazonSellerCentralVisibility;
            }
            set
            {
                _sellOnAmazonSellerCentralVisibility = value;
                OnPropertyChanged("SellOnAmazonSellerCentralVisibility");
            }
        }
        private string _sellOnAmazonSellerCentralVisibility = "auto";

        /// <summary>
        ///     Gets or sets the SellOnEcommerceVisibility field
        /// </summary>
        public string SellOnEcommerceVisibility
        {
            get
            {
                return _sellOnEcommerceVisibility;
            }
            set
            {
                _sellOnEcommerceVisibility = value;
                OnPropertyChanged("SellOnEcommerceVisibility");
            }
        }
        private string _sellOnEcommerceVisibility = "auto";

        /// <summary>
        ///     Gets or sets the SellOnFanaticsVisibility field
        /// </summary>
        public string SellOnFanaticsVisibility
        {
            get
            {
                return _sellOnFanaticsVisibility;
            }
            set
            {
                _sellOnFanaticsVisibility = value;
                OnPropertyChanged("SellOnFanaticsVisibility");
            }
        }
        private string _sellOnFanaticsVisibility = "auto";


        /// <summary>
        ///     Gets or sets the SellOnGuitarCenterVisibility field
        /// </summary>
        public string SellOnGuitarCenterVisibility
        {
            get
            {
                return _sellOnGuitarCenterVisibility;
            }
            set
            {
                _sellOnGuitarCenterVisibility = value;
                OnPropertyChanged("SellOnGuitarCenterVisibility");
            }
        }
        private string _sellOnGuitarCenterVisibility = "auto";

        /// <summary>
        ///     Gets or sets the SellOnHayneedleVisibility field
        /// </summary>
        public string SellOnHayneedleVisibility
        {
            get
            {
                return _sellOnHayneedleVisibility;
            }
            set
            {
                _sellOnHayneedleVisibility = value;
                OnPropertyChanged("SellOnHayneedleVisibility");
            }
        }
        private string _sellOnHayneedleVisibility = "auto";

        /// <summary>
        ///     Gets or sets the SellOnHouzzVisibility field
        /// </summary>
        public string SellOnHouzzVisibility
        {
            get
            {
                return _sellOnHouzzVisibility;
            }
            set
            {
                _sellOnHouzzVisibility = value;
                OnPropertyChanged("SellOnHouzzVisibility");
            }
        }
        private string _sellOnHouzzVisibility = "auto";

        /// <summary>
        ///     Gets or sets the SellOnTargetVisibility field
        /// </summary>
        public string SellOnTargetVisibility
        {
            get
            {
                return _sellOnTargetVisibility;
            }
            set
            {
                _sellOnTargetVisibility = value;
                OnPropertyChanged("SellOnTargetVisibility");
            }
        }
        private string _sellOnTargetVisibility = "auto";

        /// <summary>
        ///     Gets or sets the SellOnTrendsVisibility field
        /// </summary>
        public string SellOnTrendsVisibility
        {
            get
            {
                return _sellOnTrendsVisibility;
            }
            set
            {
                _sellOnTrendsVisibility = value;
                OnPropertyChanged("SellOnTrendsVisibility");
            }
        }
        private string _sellOnTrendsVisibility = "auto";

        /// <summary>
        ///     Gets or sets the SellOnTrsVisibility field
        /// </summary>
        public string SellOnTrsVisibility
        {
            get
            {
                return _sellOnTrsVisibility;
            }
            set
            {
                _sellOnTrsVisibility = value;
                OnPropertyChanged("SellOnTrsVisibility");
            }
        }
        private string _sellOnTrsVisibility = "auto";

        /// <summary>
        ///     Gets or sets the SellOnWalmartVisibility field
        /// </summary>
        public string SellOnWalmartVisibility
        {
            get
            {
                return _sellOnWalmartVisibility;
            }
            set
            {
                _sellOnWalmartVisibility = value;
                OnPropertyChanged("SellOnWalmartVisibility");
            }
        }
        private string _sellOnWalmartVisibility = "auto";

        /// <summary>
        ///     Gets or sets the SellOnWayfairVisibility field
        /// </summary>
        public string SellOnWayfairVisibility
        {
            get
            {
                return _sellOnWayfairVisibility;
            }
            set
            {
                _sellOnWayfairVisibility = value;
                OnPropertyChanged("SellOnWayfairVisibility");
            }
        }
        private string _sellOnWayfairVisibility = "auto";

        /* Image Path Visibility */

        /// <summary>
        ///     Gets or sets the ImagePath1Visibility field
        /// </summary>
        public string ImagePath1Visibility
        {
            get
            {
                return _imagePath1Visibility;
            }
            set
            {
                _imagePath1Visibility = value;
                OnPropertyChanged("ImagePath1Visibility");
            }
        }
        private string _imagePath1Visibility = "auto";

        /// <summary>
        ///     Gets or sets the ImagePath2Visibility field
        /// </summary>
        public string ImagePath2Visibility
        {
            get
            {
                return _imagePath2Visibility;
            }
            set
            {
                _imagePath2Visibility = value;
                OnPropertyChanged("ImagePath2Visibility");
            }
        }
        private string _imagePath2Visibility = "auto";

        /// <summary>
        ///     Gets or sets the ImagePath3Visibility field
        /// </summary>
        public string ImagePath3Visibility
        {
            get
            {
                return _imagePath3Visibility;
            }
            set
            {
                _imagePath3Visibility = value;
                OnPropertyChanged("ImagePath3Visibility");
            }
        }
        private string _imagePath3Visibility = "auto";

        /// <summary>
        ///     Gets or sets the ImagePath4Visibility field
        /// </summary>
        public string ImagePath4Visibility
        {
            get
            {
                return _imagePath4Visibility;
            }
            set
            {
                _imagePath4Visibility = value;
                OnPropertyChanged("ImagePath4Visibility");
            }
        }
        private string _imagePath4Visibility = "auto";

        /// <summary>
        ///     Gets or sets the ImagePath5Visibility field
        /// </summary>
        public string ImagePath5Visibility
        {
            get
            {
                return _imagePath5Visibility;
            }
            set
            {
                _imagePath5Visibility = value;
                OnPropertyChanged("ImagePath5Visibility");
            }
        }
        private string _imagePath5Visibility = "auto";

        /* Ecommerce Visibility */

        /// <summary>
        ///     Gets or sets the EcommerceAsinVisibility field
        /// </summary>
        public string EcommerceAsinVisibility
        {
            get
            {
                return _EcommerceAsinVisibility;
            }
            set
            {
                _EcommerceAsinVisibility = value;
                OnPropertyChanged("EcommerceAsinVisibility");
            }
        }
        private string _EcommerceAsinVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceBullet1Visibility field
        /// </summary>
        public string EcommerceBullet1Visibility
        {
            get
            {
                return _EcommerceBullet1Visibility;
            }
            set
            {
                _EcommerceBullet1Visibility = value;
                OnPropertyChanged("EcommerceBullet1Visibility");
            }
        }
        private string _EcommerceBullet1Visibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceBullet2Visibility field
        /// </summary>
        public string EcommerceBullet2Visibility
        {
            get
            {
                return _EcommerceBullet2Visibility;
            }
            set
            {
                _EcommerceBullet2Visibility = value;
                OnPropertyChanged("EcommerceBullet2Visibility");
            }
        }
        private string _EcommerceBullet2Visibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceBullet3Visibility field
        /// </summary>
        public string EcommerceBullet3Visibility
        {
            get
            {
                return _EcommerceBullet3Visibility;
            }
            set
            {
                _EcommerceBullet3Visibility = value;
                OnPropertyChanged("EcommerceBullet3Visibility");
            }
        }
        private string _EcommerceBullet3Visibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceBullet4Visibility field
        /// </summary>
        public string EcommerceBullet4Visibility
        {
            get
            {
                return _EcommerceBullet4Visibility;
            }
            set
            {
                _EcommerceBullet4Visibility = value;
                OnPropertyChanged("EcommerceBullet4Visibility");
            }
        }
        private string _EcommerceBullet4Visibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceBullet5Visibility field
        /// </summary>
        public string EcommerceBullet5Visibility
        {
            get
            {
                return _EcommerceBullet5Visibility;
            }
            set
            {
                _EcommerceBullet5Visibility = value;
                OnPropertyChanged("EcommerceBullet5Visibility");
            }
        }
        private string _EcommerceBullet5Visibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceComponentsVisibility field
        /// </summary>
        public string EcommerceComponentsVisibility
        {
            get
            {
                return _EcommerceComponentsVisibility;
            }
            set
            {
                _EcommerceComponentsVisibility = value;
                OnPropertyChanged("EcommerceComponentsVisibility");
            }
        }
        private string _EcommerceComponentsVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceCostVisibility field
        /// </summary>
        public string EcommerceCostVisibility
        {
            get
            {
                return _EcommerceCostVisibility;
            }
            set
            {
                _EcommerceCostVisibility = value;
                OnPropertyChanged("EcommerceCostVisibility");
            }
        }
        private string _EcommerceCostVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceCountryofOriginVisibility field
        /// </summary>
        public string EcommerceCountryofOriginVisibility
        {
            get
            {
                return _EcommerceCountryofOriginVisibility;
            }
            set
            {
                _EcommerceCountryofOriginVisibility = value;
                OnPropertyChanged("EcommerceCountryofOriginVisibility");
            }
        }
        private string _EcommerceCountryofOriginVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceExternalIdVisibility field
        /// </summary>
        public string EcommerceExternalIdVisibility
        {
            get
            {
                return _EcommerceExternalIdVisibility;
            }
            set
            {
                _EcommerceExternalIdVisibility = value;
                OnPropertyChanged("EcommerceExternalIdVisibility");
            }
        }
        private string _EcommerceExternalIdVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceExternalIdTypeVisibility field
        /// </summary>
        public string EcommerceExternalIdTypeVisibility
        {
            get
            {
                return _EcommerceExternalIdTypeVisibility;
            }
            set
            {
                _EcommerceExternalIdTypeVisibility = value;
                OnPropertyChanged("EcommerceExternalIdTypeVisibility");
            }
        }
        private string _EcommerceExternalIdTypeVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceItemAliasVisibility field
        /// </summary>
        public string EcommerceItemAliasVisibility
        {
            get
            {
                return _EcommerceItemAliasVisibility;
            }
            set
            {
                _EcommerceItemAliasVisibility = value;
                OnPropertyChanged("EcommerceItemAliasVisibility");
            }
        }
        private string _EcommerceItemAliasVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceItemHeightVisibility field
        /// </summary>
        public string EcommerceItemHeightVisibility
        {
            get
            {
                return _EcommerceItemHeightVisibility;
            }
            set
            {
                _EcommerceItemHeightVisibility = value;
                OnPropertyChanged("EcommerceItemHeightVisibility");
            }
        }
        private string _EcommerceItemHeightVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceItemLengthVisibility field
        /// </summary>
        public string EcommerceItemLengthVisibility
        {
            get
            {
                return _EcommerceItemLengthVisibility;
            }
            set
            {
                _EcommerceItemLengthVisibility = value;
                OnPropertyChanged("EcommerceItemLengthVisibility");
            }
        }
        private string _EcommerceItemLengthVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceItemNameVisibility field
        /// </summary>
        public string EcommerceItemNameVisibility
        {
            get
            {
                return _EcommerceItemNameVisibility;
            }
            set
            {
                _EcommerceItemNameVisibility = value;
                OnPropertyChanged("EcommerceItemNameVisibility");
            }
        }
        private string _EcommerceItemNameVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceItemTypeKeywordsVisibility field
        /// </summary>
        public string EcommerceItemTypeKeywordsVisibility
        {
            get
            {
                return _EcommerceItemTypeKeywordsVisibility;
            }
            set
            {
                _EcommerceItemTypeKeywordsVisibility = value;
                OnPropertyChanged("EcommerceItemTypeKeywordsVisibility");
            }
        }
        private string _EcommerceItemTypeKeywordsVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceItemWeightVisibility field
        /// </summary>
        public string EcommerceItemWeightVisibility
        {
            get
            {
                return _EcommerceItemWeightVisibility;
            }
            set
            {
                _EcommerceItemWeightVisibility = value;
                OnPropertyChanged("EcommerceItemWeightVisibility");
            }
        }
        private string _EcommerceItemWeightVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceItemWidthVisibility field
        /// </summary>
        public string EcommerceItemWidthVisibility
        {
            get
            {
                return _EcommerceItemWidthVisibility;
            }
            set
            {
                _EcommerceItemWidthVisibility = value;
                OnPropertyChanged("EcommerceItemWidthVisibility");
            }
        }
        private string _EcommerceItemWidthVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceModelNameVisibility field
        /// </summary>
        public string EcommerceModelNameVisibility
        {
            get
            {
                return _EcommerceModelNameVisibility;
            }
            set
            {
                _EcommerceModelNameVisibility = value;
                OnPropertyChanged("EcommerceModelNameVisibility");
            }
        }
        private string _EcommerceModelNameVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommercePackageHeightVisibility field
        /// </summary>
        public string EcommercePackageHeightVisibility
        {
            get
            {
                return _EcommercePackageHeightVisibility;
            }
            set
            {
                _EcommercePackageHeightVisibility = value;
                OnPropertyChanged("EcommercePackageHeightVisibility");
            }
        }
        private string _EcommercePackageHeightVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommercePackageLengthVisibility field
        /// </summary>
        public string EcommercePackageLengthVisibility
        {
            get
            {
                return _EcommercePackageLengthVisibility;
            }
            set
            {
                _EcommercePackageLengthVisibility = value;
                OnPropertyChanged("EcommercePackageLengthVisibility");
            }
        }
        private string _EcommercePackageLengthVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommercePackageWeightVisibility field
        /// </summary>
        public string EcommercePackageWeightVisibility
        {
            get
            {
                return _EcommercePackageWeightVisibility;
            }
            set
            {
                _EcommercePackageWeightVisibility = value;
                OnPropertyChanged("EcommercePackageWeightVisibility");
            }
        }
        private string _EcommercePackageWeightVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommercePackageWidthVisibility field
        /// </summary>
        public string EcommercePackageWidthVisibility
        {
            get
            {
                return _EcommercePackageWidthVisibility;
            }
            set
            {
                _EcommercePackageWidthVisibility = value;
                OnPropertyChanged("EcommercePackageWidthVisibility");
            }
        }
        private string _EcommercePackageWidthVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommercePageQtyVisibility field
        /// </summary>
        public string EcommercePageQtyVisibility
        {
            get
            {
                return _EcommercePageQtyVisibility;
            }
            set
            {
                _EcommercePageQtyVisibility = value;
                OnPropertyChanged("EcommercePageQtyVisibility");
            }
        }
        private string _EcommercePageQtyVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceParentAsinVisibility field
        /// </summary>
        public string EcommerceParentAsinVisibility
        {
            get
            {
                return _ecommerceParentAsinVisibility;
            }
            set
            {
                _ecommerceParentAsinVisibility = value;
                OnPropertyChanged("EcommerceParentAsinVisibility");
            }
        }
        private string _ecommerceParentAsinVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceProductCategoryVisibility field
        /// </summary>
        public string EcommerceProductCategoryVisibility
        {
            get
            {
                return _EcommerceProductCategoryVisibility;
            }
            set
            {
                _EcommerceProductCategoryVisibility = value;
                OnPropertyChanged("EcommerceProductCategoryVisibility");
            }
        }
        private string _EcommerceProductCategoryVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceProductDescriptionVisibility field
        /// </summary>
        public string EcommerceProductDescriptionVisibility
        {
            get
            {
                return _EcommerceProductDescriptionVisibility;
            }
            set
            {
                _EcommerceProductDescriptionVisibility = value;
                OnPropertyChanged("EcommerceProductDescriptionVisibility");
            }
        }
        private string _EcommerceProductDescriptionVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceProductSubcategoryVisibility field
        /// </summary>
        public string EcommerceProductSubcategoryVisibility
        {
            get
            {
                return _EcommerceProductSubcategoryVisibility;
            }
            set
            {
                _EcommerceProductSubcategoryVisibility = value;
                OnPropertyChanged("EcommerceProductSubcategoryVisibility");
            }
        }
        private string _EcommerceProductSubcategoryVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceManufacturerNameVisibility field
        /// </summary>
        public string EcommerceManufacturerNameVisibility
        {
            get
            {
                return _EcommerceManufacturerNameVisibility;
            }
            set
            {
                _EcommerceManufacturerNameVisibility = value;
                OnPropertyChanged("EcommerceManufacturerNameVisibility");
            }
        }
        private string _EcommerceManufacturerNameVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceMsrpVisibility field
        /// </summary>
        public string EcommerceMsrpVisibility
        {
            get
            {
                return _EcommerceMsrpVisibility;
            }
            set
            {
                _EcommerceMsrpVisibility = value;
                OnPropertyChanged("EcommerceMsrpVisibility");
            }
        }
        private string _EcommerceMsrpVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceSearchTermsVisibility field
        /// </summary>
        public string EcommerceSearchTermsVisibility
        {
            get
            {
                return _EcommerceSearchTermsVisibility;
            }
            set
            {
                _EcommerceSearchTermsVisibility = value;
                OnPropertyChanged("EcommerceSearchTermsVisibility");
            }
        }
        private string _EcommerceSearchTermsVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceSizeVisibility field
        /// </summary>
        public string EcommerceSizeVisibility
        {
            get
            {
                return _EcommerceSizeVisibility;
            }
            set
            {
                _EcommerceSizeVisibility = value;
                OnPropertyChanged("EcommerceSizeVisibility");
            }
        }
        private string _EcommerceSizeVisibility = "auto";

        /// <summary>
        ///     Gets or sets the EcommerceUpcVisibility field
        /// </summary>
        public string EcommerceUpcVisibility
        {
            get
            {
                return _EcommerceUpcVisibility;
            }
            set
            {
                _EcommerceUpcVisibility = value;
                OnPropertyChanged("EcommerceUpcVisibility");
            }
        }
        private string _EcommerceUpcVisibility = "auto";

        #endregion // Visibility Properties

        #endregion // Properties

        #region Methods
        
        /// <summary>
        ///     Creates and displays the About window
        /// </summary>
        public void About()
        {
            AboutView window = new AboutView()
            {
                DataContext = new AboutViewModel()
            };
            window.ShowDialog();
        }
        
        private void BackgroundWorkerSave_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i = 0; i<this.Items.Count;i++)
            {
                try
                {
                    if (this.Items[i].Status != "Saved")
                    {
                        ItemService.InsertItem(this.Items[i], i + 1);
                        if (!GlobalData.ItemIds.Contains(this.Items[i].ItemId))
                        {
                            GlobalData.ItemIds.Add(this.Items[i].ItemId);
                        }
                    }
                    this.Items[i].Status = "Saved";
                    this.Items[i].RowColor = "LightGreen";
                    this.ProgressText = "Saving item " + i + 1 + " of " + this.Items.Count.ToString();
                }
                catch (Exception ex)
                {
                    this.Items[i].Status = "Error";
                    this.Items[i].RowColor = "Salmon";
                    ErrorLog.LogError("Item " + this.Items[i].ItemId + " Failed to Save.", ex.ToString());
                    break;
                }
                ((BackgroundWorker)sender).ReportProgress(i + 1);
            }
            this.SaveStatus = true;         
        }

        private void BackgroundWorkerValidate_DoWork(object sender, DoWorkEventArgs e)
        {
            ObservableCollection<ItemError> errors = new ObservableCollection<ItemError>();
            for (int i = 0; i < this.Items.Count ;i++)
            {
                if (this.Items[i].HasUpdate)
                {
                    foreach (ItemError error in this.ItemService.ValidateItem(this.Items[i], false))
                    {
                        errors.Add(error);
                    }
                }
                ((BackgroundWorker)sender).ReportProgress(i + 1);
            }
            this.ItemErrors = errors;
        }

        private void BackgroundWorkerSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.ItemErrors.Where(o => o.ErrorType == "Error").Count() == 0)
            {
                this.ProgressText = "Items Saved";
                this.SubmitStatus = true;
            }
            else
            {
                this.ProgressText = "Item Error Halted Save Process";
                this.SubmitStatus = false;
            }
            this.SubmitStatus = true;            
            this.SaveStatus = true;
        }

        private void BackgroundWorkerValidate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
                this.ProgressText = "Item Validation Complete";
                this.SubmitStatus = true;

            this.SaveStatus = true;
        }

        public void BackgroundWorkerSave_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == this.Items.Count)
            {
                this.ProgressText = "Items Saved";
            }
            else
            {
                this.ProgressText = "Saving Data for item # " + e.ProgressPercentage.ToString() + " of " + this.Items.Count.ToString();
            }

        }

        public void BackgroundWorkerValidate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == this.Items.Count)
            {
                this.ProgressText = "Item Load Complete";
            }
            else
            {
                this.ProgressText = "Validating Data for item # " + e.ProgressPercentage.ToString() + " of " + this.Items.Count.ToString();
            }
            
        }

        /// <summary>
        ///     Checks that collumn headers are correct and alerts user if any are misspelled
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool CheckCollumnHeaders(string fileName)
        {
            List<string> wrongHeaders = ItemService.ValidateHeaderCollumns(fileName);
            if (wrongHeaders.Count > 0)
            {
                AlertView window = new AlertView()
                {
                    DataContext = new AlertViewModel(wrongHeaders, "Alert", "Odin did not recognize the following collumn headers.")
                };
                window.ShowDialog();
            }
            return true;
        }

        /// <summary>
        ///     Clears existing items and item errors from Odin
        /// </summary>
        public void ClearLists()
        {
            this.Items = new ObservableCollection<ItemObject>();
            this.ItemErrors = new ObservableCollection<ItemError>();
            GlobalData.LocalItemIds = new List<string>();
        }

        /// <summary>
        ///     Creates an excel file from Item List containing all amazon information
        /// </summary>
        public void CreateAmazonExcelFromList(ObservableCollection<ItemObject> itemsList = null)
        {
            EcommercePullView window = new EcommercePullView()
            {
                DataContext = new EcommercePullViewModel(this.ItemService, this.ExcelService, this.Items)
            };
            window.ShowDialog();
        }

        /// <summary>
        ///     Creates a Magento 1 excel sheet from the curretnly loaded items
        /// </summary>
        public void CreateMagento1CustomExcel()
        {
            if(this.Items.Count>0)
            {
                Random rnd = new Random();
                int rndId = rnd.Next(1000);
                string custId = "CUST-" + rndId.ToString();
                ExcelService.WriteMagentoCsv(this.Items, custId, "Add");
            }
            else
            {
                MessageBox.Show("There are no items!");
            }
        }

        /// <summary>
        ///     Creates a Magento 2 excel sheet from the curretnly loaded items
        /// </summary>
        public void CreateMagento2CustomExcel()
        {
            if (this.Items.Count > 0)
            {
                Random rnd = new Random();
                int rndId = rnd.Next(1000);
                string custId = "CUST-" + rndId.ToString();
                ExcelService.WriteMagento2Csv(this.Items, custId, "Add");
            }
            else
            {
                MessageBox.Show("There are no items!");
            }
        }

        /// <summary>
        ///     Opens DbSetting View / View Model
        /// </summary>
        public void EditDbSettings()
        {
            DbSettingsView window = new DbSettingsView()
            {
                DataContext = new DbSettingsViewModel()
            };
            window.ShowDialog();
            if ((window.DataContext as DbSettingsViewModel).Status == true)
            {
                App.WireUp();
                this.ItemService = App.ItemService;
                this.OptionService = App.OptionService;
                this.EmailService = App.EmailService;
                this.ExcelService = App.ExcelService;
                this.WorkbookReader = App.WorkbookReader;
                this.WindowTitle = SetWindowTitle();
                ClearLists();
            }
        }

        /// <summary>
        ///     Assigns the item via errors item row to be edited
        /// </summary>
        public void EditSelectedError()
        {
            ItemObject item = Items.Where(x => x.ItemId == this.SelectedError.ItemIdNumber && 
                                            x.ItemRow == this.SelectedError.LineNumber).FirstOrDefault();
            this.SelectedItem = item;
            EditSelectedItem(item);

            /*
            foreach (ItemObject item in Items)
            {
                if (item.ItemId == this.SelectedError.ItemIdNumber)
                {
                    this.SelectedItem = item;
                    EditSelectedItem(item);
                    break;
                }
            }
            */
        }

        /// <summary>
        ///     Opens the ItemView window for the selected item.
        /// </summary>
        /// <param name="item"></param>
        public void EditSelectedItem(ItemObject item)
        {
            List<ItemError> selectedItemErrors = ItemErrors.Where(x => x.ItemIdNumber == this.SelectedItem.ItemId).ToList();
            ItemView window = new ItemView
            {
                DataContext = new ItemViewModel(this.SelectedItem, this.ItemService, selectedItemErrors)
            };

            window.ShowDialog();

            if (window.DialogResult == true)
            {
                if ((window.DataContext as ItemViewModel).Remove)
                {
                    RemoveItem((window.DataContext as ItemViewModel).ItemId);
                }
                else
                {
                    this.SelectedItem.UpdateItem((window.DataContext as ItemViewModel).ItemViewModelItem);

                    foreach(ItemError error in selectedItemErrors)
                    {
                        if(!(window.DataContext as ItemViewModel).ItemErrors.Where(x=> x.ErrorField == error.ErrorField).Any())
                        {
                            this.ItemErrors.Remove(error);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Function that retrieves item information from the Peoplesoft Database
        /// </summary>
        /// <param name="type">variable that distiguishes whether user is searching by id or uploading web info</param>
        public void FindItem(string type)
        {
            FindItemView window = new FindItemView()
            {
                DataContext = new FindItemViewModel(type, ItemService, WorkbookReader)
            };
            if (window.ShowDialog() == true)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                ClearLists();
                if (type == "Update")
                {
                    this.Items = (window.DataContext as FindItemViewModel).ItemList;
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.DoWork += BackgroundWorkerValidate_DoWork;
                    worker.ProgressChanged += BackgroundWorkerValidate_ProgressChanged;
                    worker.WorkerReportsProgress = true;
                    worker.RunWorkerCompleted += BackgroundWorkerValidate_RunWorkerCompleted;
                    worker.RunWorkerAsync();

                    SaveStatus = true;
                    SubmitStatus = false;
                }
                else if (type == "Remove")
                {
                    this.Items = (window.DataContext as FindItemViewModel).ItemList;
                    foreach (ItemObject item in this.Items)
                    {
                        item.Status = "Remove";
                    }
                    this.ItemErrors.Clear();
                    SaveStatus = false;
                    SubmitStatus = true;
                }
                Mouse.OverrideCursor = null;
            }
        }

        public void FindItemUpdateRecord()
        {
            AdminRecordView window = new AdminRecordView()
            {
                DataContext = new AdminRecordViewModel(ItemService)
            };
            window.ShowDialog();
        }

        /// <summary>
        ///     Clears all items and item errors from the form.
        /// </summary>
        public void FormRefresh()
        {
            if (MessageBox.Show("Are you sure you want to clear the table? All unsaved data will be lost.", "Odin", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Items = new ObservableCollection<ItemObject>();
                ItemErrors = new ObservableCollection<ItemError>();
            }
        }

        /// <summary>
        ///     Loads a selected excel file using the workbook reader
        /// </summary>
        public void LoadItems()
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Excel files|*.xls; *.xlsx"
            };
            if (dialog.ShowDialog() != true)
            {
                return;
            }
            else
            {
                ClearLists();
            }
            if (CheckCollumnHeaders(dialog.FileName))
            {
                Mouse.OverrideCursor = Cursors.Wait;
                try
                {
                    this.Items = this.ItemService.LoadExcelItems("Add", dialog.FileName);
                }
                catch (Exception ex)
                {
                    ErrorLog.LogError("Odin was unable to load the excel items.", ex.ToString());
                }
                this.ItemErrors = new ObservableCollection<ItemError>();
                try
                {
                    foreach (ItemObject item in this.Items)
                    {
                        foreach (ItemError error in this.ItemService.ValidateItem(item, false))
                        {
                            this.ItemErrors.Add(error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.LogError("Odin was unable to validate all the items.", ex.ToString());
                }

                SaveStatus = true;
                SubmitStatus = false;

                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        ///     Open TemplateViewModel and load in given template data
        /// </summary>
        public void LoadTemplates()
        {
            TemplateView window = new TemplateView()
            {
                DataContext = new TemplateViewModel(this.ItemService, "Add")
            };
            (window.DataContext as TemplateViewModel).LoadTemplateExcelInfo();
            window.ShowDialog();
        }

        /// <summary>
        /// Manage permissions / roles / users
        /// </summary>
        public void ManagePermision()
        {
            PermissionsView window = new PermissionsView()
            {
                DataContext = new PermissionsViewModel(OptionService)
            };
            window.ShowDialog();
        }

        /// <summary>
        ///     Opens TemplateViewModel
        /// </summary>
        public void NewTemplate()
        {
            TemplateView window = new TemplateView()
            {
                DataContext = new TemplateViewModel(this.ItemService, "Add")
            };
            window.ShowDialog();
        }

        /// <summary>
        ///     Opens the help window
        /// </summary>
        public void OpenHelpWindow()
        {
            HelpView window = new HelpView()
            {
                DataContext = new HelpViewModel()
            };
            window.ShowDialog();
        }

        /// <summary>
        ///     Opens the Excel Generator view / viewmodel
        /// </summary>
        public void OpenExcelGenerator()
        {
            ExcelGeneratorView window = new ExcelGeneratorView()
            {
                DataContext = new ExcelGeneratorViewModel(this.ExcelService, this.ItemService)
            };
            window.ShowDialog();
        }

        public void OpenItemRecordsWindow()
        {
            ItemRecordListView window = new ItemRecordListView()
            {
                DataContext = new ItemRecordListViewModel(this.ItemService)
            };
            window.ShowDialog();
        }

        public void OpenItemUpdateReportWindow()
        {
            ItemUpdateReportView window = new ItemUpdateReportView()
            {
                DataContext = new ItemUpdateReportViewModel(this.ItemService, this.ExcelService)
            };
            window.ShowDialog();
        }

        /// <summary>
        ///     Opens the OpenManageFieldsWindow window.
        /// </summary>
        /// <param name="item"></param>
        public void OpenManageFieldsWindow()
        {
            FieldEditView window = new FieldEditView()
            {
                DataContext = new FieldEditViewModel(ItemService, EmailService)
            };
            window.ShowDialog();
        }

        /// <summary>
        ///     Opens the options window and refreshes the option caches
        /// </summary>
        public void OpenOptionsWindow()
        {
            OptionsView window = new OptionsView()
            {
                DataContext = new OptionsViewModel(this.OptionService)
            };
            window.ShowDialog();
            if ((window.DataContext as OptionsViewModel).HasUpdate)
            {
                this.OptionService.SetCaches();
            }
            SetListVisibilty();
        }

        /// <summary>
        ///     Opens the TemplateAll view / viewmodel
        /// </summary>
        public void OpenTemplateAll()
        {
            TemplateAllView window = new TemplateAllView()
            {
                DataContext = new TemplateAllViewModel(this.ItemService, this.ExcelService)
            };
            window.ShowDialog();
        }

        /// <summary>
        ///     Opens a window that lists all to posted notifications
        /// </summary>
        public void OpenNotificationHistory()
        {
            List<string> notificationList = OptionService.RetrieveNotifications("All");
            AlertView window = new AlertView()
            {
                DataContext = new AlertViewModel(notificationList, "", "")
            };
            window.ShowDialog();
        }

        /// <summary>
        ///     Copies the images for the given request into a folder on the users desktop
        /// </summary>
        public void PullImages()
        {
            List<string> missingImages = ItemService.PullImages(this.Items);
            if (missingImages.Count > 0)
            {
                AlertView window = new AlertView
                {
                    DataContext = new AlertViewModel(missingImages, "Alert", "The following images were not found in the captures folder or were too large.")
                };
                window.ShowDialog();
            }
        }

        /// <summary>
        ///     Remove the given item from the list, error list and local itemid list
        /// </summary>
        /// <param name="itemId"></param>
        public void RemoveItem(string itemId = null)
        {
            if (itemId == null)
            {
                itemId = this.SelectedItem.ItemId;
            }

            for (int x = this.ItemErrors.Count - 1; x >= 0; x--)
            {
                if (this.ItemErrors[x].ItemIdNumber == (itemId))
                {
                    this.ItemErrors.Remove(this.ItemErrors[x]);
                }
            }
            foreach (ItemObject collectionItem in Items)
            {
                if (collectionItem.ItemId == (itemId))
                {
                    this.Items.Remove(collectionItem);
                    break;
                }
            }
            if (GlobalData.LocalItemIds.Contains(itemId))
            {
                GlobalData.LocalItemIds.Remove(itemId);
            }
            ReorderRows();
        }

        /// <summary>
        ///     Reorders the row numbers of all items and errors. Used when an item is removed from item list
        /// </summary>
        public void ReorderRows()
        {
            for (int x = 0; x < this.Items.Count; x++)
            {
                if(this.Items[x].ItemRow!= x+1)
                {
                    this.Items[x].ItemRow = x + 1;

                    foreach (ItemError itemError in this.ItemErrors)
                    {
                        if(itemError.ItemIdNumber == this.Items[x].ItemId)
                        {
                            itemError.LineNumber = x + 1;
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Submits a request for additional file images to be uploaded to the b2b server
        /// </summary>
        public void SubmitEcommerceImages()
        {
            if (this.FtpService == null && !GlobalData.FtpUserexceptions.Contains(GlobalData.UserName))
            {
                this.FtpService = new FtpService();
            }

            if (this.FtpService != null)
            {
                if (!GlobalData.ExistingFiles.Any())
                {
                    GlobalData.ExistingFiles = this.FtpService.ReturnExistingImageFiles();
                }
                List<string> skippedFiles = new List<string>();
                OpenFileDialog dialog = new OpenFileDialog() {
                    Multiselect = true,
                    Filter = "Excel files|*.jpg; *.jpeg; *.png"
                };
                if (dialog.ShowDialog() != true)
                {
                    return;
                }
                else
                {
                    string fileCount = dialog.FileNames.Length.ToString();
                    int count = 0;
                    foreach (string name in dialog.FileNames)
                    {
                        string[] parts = name.Split('\\');
                        if (!GlobalData.ExistingFiles.Contains(parts[parts.Length - 1]) && !parts[parts.Length - 1].Contains("'"))
                        {
                            this.FtpService.SubmitImage(name);
                        }
                        else
                        {
                            skippedFiles.Add(parts[parts.Length - 1]);
                        }
                        count++;
                        this.ProgressText = "Uploading image file " + count.ToString() + " of " + fileCount;
                    }
                }
                if (skippedFiles.Count > 0)
                {
                    AlertView window = new AlertView()
                    {
                        DataContext = new AlertViewModel(skippedFiles, "Alert", "The following images already exist on the server or the names contain special characters.")
                    };
                    window.ShowDialog();
                }
                this.ProgressText = "Image file upload complete.";
            }
            else
            {
                AlertView window = new AlertView()
                {
                    DataContext = new AlertViewModel(new List<string>(), "Alert", "The Image files could not be uploaded.")
                };
                window.ShowDialog();
                this.ProgressText = "Image files could not be uploaded.";
            }
        }
        
        /// <summary>
        ///     This function saves items to the database
        /// </summary>
        public void SaveItems()
        {
            BackgroundWorker worker = new BackgroundWorker();
            Mouse.OverrideCursor = Cursors.Wait;
            
            bool savedRun = false;
            
            if ((this.ItemErrors.Where(o=>o.ErrorType=="Error").Count() == 0) && (this.Items.Count > 0))
            {
                if (!savedRun)
                {
                    worker.DoWork += BackgroundWorkerSave_DoWork;
                    worker.ProgressChanged += BackgroundWorkerSave_ProgressChanged;
                    worker.WorkerReportsProgress = true;
                    worker.RunWorkerCompleted += BackgroundWorkerSave_RunWorkerCompleted;
                    worker.RunWorkerAsync();
                }  
            }
            else
            {
                MessageBox.Show("Please remove all errors before saving");
            }
            this.SaveStatus = false;
            this.SubmitStatus = false;
            Mouse.OverrideCursor = null;
        }

        public void SetListVisibilty()
        {
            /* Peoplesoft Visibility */
            this.AccountingGroupVisibility = (UserOptions.AccountingGroupVisibility) ? "100" : "0";
            this.BillOfMaterialsVisibility = (UserOptions.BillOfMaterialsVisibility) ? "100" : "0";
            this.CasepackHeightVisibility = (UserOptions.CasepackHeightVisibility) ? "100" : "0";
            this.CasepackLengthVisibility = (UserOptions.CasepackLengthVisibility) ? "100" : "0";
            this.CasepackQtyVisibility = (UserOptions.CasepackQtyVisibility) ? "100" : "0";
            this.CasepackUpcVisibility = (UserOptions.CasepackUpcVisibility) ? "100" : "0";
            this.CasepackWidthVisibility = (UserOptions.CasepackWidthVisibility) ? "100" : "0";
            this.CasepackWeightVisibility = (UserOptions.CasepackWeightVisibility) ? "100" : "0";
            this.ColorVisibility = (UserOptions.ColorVisibility) ? "100" : "0";
            this.CountryOfOriginVisibility = (UserOptions.CountryOfOriginVisibility) ? "100" : "0";
            this.CostProfileGroupVisibility = (UserOptions.CostProfileGroupVisibility) ? "100" : "0";
            this.DefaultActualCostCadVisibility = (UserOptions.DefaultActualCostCadVisibility) ? "100" : "0";
            this.DefaultActualCostUsdVisibility = (UserOptions.DefaultActualCostUsdVisibility) ? "100" : "0";
            this.DescriptionVisibility = (UserOptions.DescriptionVisibility) ? "100" : "0";
            this.DirectImportVisibility = (UserOptions.DirectImportVisibility) ? "100" : "0";
            this.DutyVisibility = (UserOptions.DutyVisibility) ? "100" : "0";
            this.EanVisibility = (UserOptions.EanVisibility) ? "100" : "0";
            this.Genre1Visibility = (UserOptions.Genre1Visibility) ? "100" : "0";
            this.Genre2Visibility = (UserOptions.Genre2Visibility) ? "100" : "0";
            this.Genre3Visibility = (UserOptions.Genre3Visibility) ? "100" : "0";
            this.GpcVisibility = (UserOptions.GpcVisibility) ? "100" : "0";
            this.HeightVisibility = (UserOptions.HeightVisibility) ? "100" : "0";
            this.InnerpackHeightVisibility = (UserOptions.InnerpackHeightVisibility) ? "100" : "0";
            this.InnerpackLengthVisibility = (UserOptions.InnerpackLengthVisibility) ? "100" : "0";
            this.InnerpackQuantityVisibility = (UserOptions.InnerpackQuantityVisibility) ? "100" : "0";
            this.InnerpackUpcVisibility = (UserOptions.InnerpackUpcVisibility) ? "100" : "0";
            this.InnerpackWidthVisibility = (UserOptions.InnerpackWidthVisibility) ? "100" : "0";
            this.InnerpackWeightVisibility = (UserOptions.InnerpackWeightVisibility) ? "100" : "0";
            this.IsbnVisibility = (UserOptions.IsbnVisibility) ? "100" : "0";
            this.ItemCategoryVisibility = (UserOptions.ItemCategoryVisibility) ? "100" : "0";
            this.ItemFamilyVisibility = (UserOptions.ItemFamilyVisibility) ? "100" : "0";
            this.ItemGroupVisibility = (UserOptions.ItemGroupVisibility) ? "100" : "0";
            this.LanguageVisibility = (UserOptions.LanguageVisibility) ? "100" : "0";
            this.LengthVisibility = (UserOptions.LengthVisibility) ? "100" : "0";
            this.ListPriceCadVisibility = (UserOptions.ListPriceCadVisibility) ? "100" : "0";
            this.ListPriceMxnVisibility = (UserOptions.ListPriceMxnVisibility) ? "100" : "0";
            this.ListPriceUsdVisibility = (UserOptions.ListPriceUsdVisibility) ? "100" : "0";
            this.MfgSourceVisibility = (UserOptions.MfgSourceVisibility) ? "100" : "0";
            this.MsrpVisibility = (UserOptions.MsrpVisibility) ? "100" : "0";
            this.MsrpCadVisibility = (UserOptions.MsrpCadVisibility) ? "100" : "0";
            this.MsrpMxnVisibility = (UserOptions.MsrpMxnVisibility) ? "100" : "0";
            this.PricingGroupVisibility = (UserOptions.PricingGroupVisibility) ? "100" : "0";
            this.PrintOnDemandVisibility = (UserOptions.PrintOnDemandVisibility) ? "100" : "0";
            this.ProductFormatVisibility = (UserOptions.ProductFormatVisibility) ? "100" : "0";
            this.ProductGroupVisibility = (UserOptions.ProductGroupVisibility) ? "100" : "0";
            this.ProductIdTranslationVisibility = (UserOptions.ProductIdTranslationVisibility) ? "100" : "0";
            this.ProductLineVisibility = (UserOptions.ProductLineVisibility) ? "100" : "0";
            this.ProductQtyVisibility = (UserOptions.ProductQtyVisibility) ? "100" : "0";
            this.PsStatusVisibility = (UserOptions.PsStatusVisibility) ? "100" : "0";
            this.SatCodeVisibility = (UserOptions.SatCodeVisibility) ? "100" : "0";
            this.StandardCostVisibility = (UserOptions.StandardCostVisibility) ? "100" : "0";
            this.StatsCodeVisibility = (UserOptions.StatsCodeVisibility) ? "100" : "0";
            this.TariffCodeVisibility = (UserOptions.TariffCodeVisibility) ? "100" : "0";
            this.TerritoryVisibility = (UserOptions.TerritoryVisibility) ? "100" : "0";
            this.UdexVisibility = (UserOptions.UdexVisibility) ? "100" : "0";
            this.UpcVisibility = (UserOptions.UpcVisibility) ? "100" : "0";
            this.WebsitePriceVisibility = (UserOptions.WebsitePriceVisibility) ? "100" : "0";
            this.WeightVisibility = (UserOptions.WeightVisibility) ? "100" : "0";
            this.WidthVisibility = (UserOptions.WidthVisibility) ? "100" : "0";
            /* B2B Visibility */
            this.CategoryVisibility = (UserOptions.CategoryVisibility) ? "100" : "0";
            this.Category2Visibility = (UserOptions.Category2Visibility) ? "100" : "0";
            this.Category3Visibility = (UserOptions.Category3Visibility) ? "100" : "0";
            this.CopyrightVisibility = (UserOptions.CopyrightVisibility) ? "100" : "0";
            this.InStockDateVisibility = (UserOptions.InStockDateVisibility) ? "100" : "0";
            this.ItemKeywordsVisibility = (UserOptions.ItemKeywordsVisibility) ? "100" : "0";
            this.LicenseVisibility = (UserOptions.LicenseVisibility) ? "100" : "0";
            this.LicenseBeginDateVisibility = (UserOptions.LicenseBeginDateVisibility) ? "100" : "0";
            this.MetaDescriptionVisibility = (UserOptions.MetaDescriptionVisibility) ? "100" : "0";
            this.PropertyVisibility = (UserOptions.PropertyVisibility) ? "100" : "0";
            this.ShortDescriptionVisibility = (UserOptions.ShortDescriptionVisibility) ? "100" : "0";
            this.SizeVisibility = (UserOptions.SizeVisibility) ? "100" : "0";
            this.TitleVisibility = (UserOptions.TitleVisibility) ? "100" : "0";
            /* Sell On Visibility */
            this.SellOnAllPostersVisibility = (UserOptions.SellOnAllPostersVisibility) ? "100" : "0";
            this.SellOnAmazonVisibility = (UserOptions.SellOnAmazonVisibility) ? "100" : "0";
            this.SellOnAmazonSellerCentralVisibility = (UserOptions.SellOnAmazonSellerCentralVisibility) ? "100" : "0";
            this.SellOnEcommerceVisibility = (UserOptions.SellOnEcommerceVisibility) ? "100" : "0";
            this.SellOnFanaticsVisibility = (UserOptions.SellOnFanaticsVisibility) ? "100" : "0";
            this.SellOnGuitarCenterVisibility = (UserOptions.SellOnGuitarCenterVisibility) ? "100" : "0";
            this.SellOnHayneedleVisibility = (UserOptions.SellOnHayneedleVisibility) ? "100" : "0";
            this.SellOnHouzzVisibility = (UserOptions.SellOnHouzzVisibility) ? "100" : "0";
            this.SellOnTargetVisibility = (UserOptions.SellOnTargetVisibility) ? "100" : "0";
            this.SellOnTrendsVisibility = (UserOptions.SellOnTrendsVisibility) ? "100" : "0";
            this.SellOnTrsVisibility = (UserOptions.SellOnTrsVisibility) ? "100" : "0";
            this.SellOnWalmartVisibility = (UserOptions.SellOnWalmartVisibility) ? "100" : "0";
            this.SellOnWayfairVisibility = (UserOptions.SellOnWayfairVisibility) ? "100" : "0";
            /* Image Path Visibility */
            this.ImagePath1Visibility = (UserOptions.ImagePath1Visibility) ? "100" : "0";
            this.ImagePath2Visibility = (UserOptions.ImagePath2Visibility) ? "100" : "0";
            this.ImagePath3Visibility = (UserOptions.ImagePath3Visibility) ? "100" : "0";
            this.ImagePath4Visibility = (UserOptions.ImagePath4Visibility) ? "100" : "0";
            this.ImagePath5Visibility = (UserOptions.ImagePath5Visibility) ? "100" : "0";
            /* Ecommerce Visibility */
            this.EcommerceAsinVisibility = (UserOptions.EcommerceAsinVisibility) ? "100" : "0";
            this.EcommerceBullet1Visibility = (UserOptions.EcommerceBullet1Visibility) ? "100" : "0";
            this.EcommerceBullet2Visibility = (UserOptions.EcommerceBullet2Visibility) ? "100" : "0";
            this.EcommerceBullet3Visibility = (UserOptions.EcommerceBullet3Visibility) ? "100" : "0";
            this.EcommerceBullet4Visibility = (UserOptions.EcommerceBullet4Visibility) ? "100" : "0";
            this.EcommerceBullet5Visibility = (UserOptions.EcommerceBullet5Visibility) ? "100" : "0";
            this.EcommerceComponentsVisibility = (UserOptions.EcommerceComponentsVisibility) ? "100" : "0";
            this.EcommerceCostVisibility = (UserOptions.EcommerceCostVisibility) ? "100" : "0";
            this.EcommerceCountryofOriginVisibility = (UserOptions.EcommerceCountryofOriginVisibility) ? "100" : "0";
            this.EcommerceExternalIdVisibility = (UserOptions.EcommerceExternalIdVisibility) ? "100" : "0";
            this.EcommerceExternalIdTypeVisibility = (UserOptions.EcommerceExternalIdTypeVisibility) ? "100" : "0";
            this.EcommerceItemAliasVisibility = (UserOptions.EcommerceItemAliasVisibility) ? "100" : "0";
            this.EcommerceItemHeightVisibility = (UserOptions.EcommerceItemHeightVisibility) ? "100" : "0";
            this.EcommerceItemLengthVisibility = (UserOptions.EcommerceItemLengthVisibility) ? "100" : "0";
            this.EcommerceItemNameVisibility = (UserOptions.EcommerceItemNameVisibility) ? "100" : "0";
            this.EcommerceItemTypeKeywordsVisibility = (UserOptions.EcommerceItemTypeKeywordsVisibility) ? "100" : "0";
            this.EcommerceItemWeightVisibility = (UserOptions.EcommerceItemWeightVisibility) ? "100" : "0";
            this.EcommerceItemWidthVisibility = (UserOptions.EcommerceItemWidthVisibility) ? "100" : "0";
            this.EcommerceModelNameVisibility = (UserOptions.EcommerceModelNameVisibility) ? "100" : "0";
            this.EcommercePackageHeightVisibility = (UserOptions.EcommercePackageHeightVisibility) ? "100" : "0";
            this.EcommercePackageLengthVisibility = (UserOptions.EcommercePackageLengthVisibility) ? "100" : "0";
            this.EcommercePackageWeightVisibility = (UserOptions.EcommercePackageWeightVisibility) ? "100" : "0";
            this.EcommercePackageWidthVisibility = (UserOptions.EcommercePackageWidthVisibility) ? "100" : "0";
            this.EcommercePageQtyVisibility = (UserOptions.EcommercePageQtyVisibility) ? "100" : "0";
            this.EcommerceParentAsinVisibility = (UserOptions.EcommerceParentAsinVisibility) ? "100" : "0";
            this.EcommerceProductCategoryVisibility = (UserOptions.EcommerceProductCategoryVisibility) ? "100" : "0";
            this.EcommerceProductDescriptionVisibility = (UserOptions.EcommerceProductDescriptionVisibility) ? "100" : "0";
            this.EcommerceProductSubcategoryVisibility = (UserOptions.EcommerceProductSubcategoryVisibility) ? "100" : "0";
            this.EcommerceManufacturerNameVisibility = (UserOptions.EcommerceManufacturerNameVisibility) ? "100" : "0";
            this.EcommerceMsrpVisibility = (UserOptions.EcommerceMsrpVisibility) ? "100" : "0";
            this.EcommerceSearchTermsVisibility = (UserOptions.EcommerceSearchTermsVisibility) ? "100" : "0";
            this.EcommerceSizeVisibility = (UserOptions.EcommerceSizeVisibility) ? "100" : "0";
            this.EcommerceUpcVisibility = (UserOptions.EcommerceUpcVisibility) ? "100" : "0";

        }

        private void SetUserOptionsDefaults()
        {
            UserOptions.AccountingGroupVisibility = true;
            UserOptions.BillOfMaterialsVisibility = true;
            UserOptions.CasepackHeightVisibility = true;
            UserOptions.CasepackLengthVisibility = true;
            UserOptions.CasepackQtyVisibility = true;
            UserOptions.CasepackUpcVisibility = true;
            UserOptions.CasepackWidthVisibility = true;
            UserOptions.CasepackWeightVisibility = true;
            UserOptions.ColorVisibility = true;
            UserOptions.CountryOfOriginVisibility = true;
            UserOptions.CostProfileGroupVisibility = true;
            UserOptions.DefaultActualCostCadVisibility = true;
            UserOptions.DefaultActualCostUsdVisibility = true;
            UserOptions.DescriptionVisibility = true;
            UserOptions.DirectImportVisibility = true;
            UserOptions.DutyVisibility = true;
            UserOptions.EanVisibility = true;
            UserOptions.Genre1Visibility = true;
            UserOptions.Genre2Visibility = true;
            UserOptions.Genre3Visibility = true;
            UserOptions.GpcVisibility = true;
            UserOptions.HeightVisibility = true;
            UserOptions.InnerpackHeightVisibility = true;
            UserOptions.InnerpackLengthVisibility = true;
            UserOptions.InnerpackQuantityVisibility = true;
            UserOptions.InnerpackUpcVisibility = true;
            UserOptions.InnerpackWidthVisibility = true;
            UserOptions.InnerpackWeightVisibility = true;
            UserOptions.IsbnVisibility = true;
            UserOptions.ItemCategoryVisibility = true;
            UserOptions.ItemFamilyVisibility = true;
            UserOptions.ItemGroupVisibility = true;
            UserOptions.LanguageVisibility = true;
            UserOptions.LengthVisibility = true;
            UserOptions.ListPriceCadVisibility = true;
            UserOptions.ListPriceMxnVisibility = true;

            UserOptions.ListPriceUsdVisibility = true;
            UserOptions.MfgSourceVisibility = true;
            UserOptions.MsrpVisibility = true;
            UserOptions.MsrpCadVisibility = true;
            UserOptions.MsrpMxnVisibility = true;
            UserOptions.PricingGroupVisibility = true;
            UserOptions.PrintOnDemandVisibility = true;
            UserOptions.ProductFormatVisibility = true;
            UserOptions.ProductGroupVisibility = true;
            UserOptions.ProductIdTranslationVisibility = true;
            UserOptions.ProductLineVisibility = true;
            UserOptions.ProductQtyVisibility = true;
            UserOptions.PsStatusVisibility = true;
            UserOptions.SatCodeVisibility = true;
            UserOptions.StandardCostVisibility = true;
            UserOptions.StatsCodeVisibility = true;
            UserOptions.TariffCodeVisibility = true;
            UserOptions.TerritoryVisibility = true;
            UserOptions.UdexVisibility = true;
            UserOptions.UpcVisibility = true;
            UserOptions.WebsitePriceVisibility = true;
            UserOptions.WeightVisibility = true;
            UserOptions.WidthVisibility = true;
            UserOptions.CategoryVisibility = true;
            UserOptions.Category2Visibility = true;
            UserOptions.Category3Visibility = true;
            UserOptions.CopyrightVisibility = true;
            UserOptions.InStockDateVisibility = true;
            UserOptions.ItemKeywordsVisibility = true;
            UserOptions.LicenseVisibility = true;
            UserOptions.LicenseBeginDateVisibility = true;
            UserOptions.MetaDescriptionVisibility = true;
            UserOptions.PropertyVisibility = true;
            UserOptions.ShortDescriptionVisibility = true;
            UserOptions.SizeVisibility = true;
            UserOptions.TitleVisibility = true;
            UserOptions.SellOnAllPostersVisibility = true;
            UserOptions.SellOnAmazonVisibility = true;
            UserOptions.SellOnAmazonSellerCentralVisibility = true;
            UserOptions.SellOnEcommerceVisibility = true;
            UserOptions.SellOnFanaticsVisibility = true;
            UserOptions.SellOnGuitarCenterVisibility = true;
            UserOptions.SellOnHayneedleVisibility = true;
            UserOptions.SellOnHouzzVisibility = true;
            UserOptions.SellOnTargetVisibility = true;
            UserOptions.SellOnTrendsVisibility = true;
            UserOptions.SellOnTrsVisibility = true;
            UserOptions.SellOnWalmartVisibility = true;
            UserOptions.SellOnWayfairVisibility = true;
            UserOptions.ImagePath1Visibility = true;
            UserOptions.ImagePath2Visibility = true;
            UserOptions.ImagePath3Visibility = true;
            UserOptions.ImagePath4Visibility = true;
            UserOptions.ImagePath5Visibility = true;
            UserOptions.EcommerceAsinVisibility = true;
            UserOptions.EcommerceBullet1Visibility = true;
            UserOptions.EcommerceBullet2Visibility = true;
            UserOptions.EcommerceBullet3Visibility = true;
            UserOptions.EcommerceBullet4Visibility = true;
            UserOptions.EcommerceBullet5Visibility = true;
            UserOptions.EcommerceComponentsVisibility = true;
            UserOptions.EcommerceCostVisibility = true;
            UserOptions.EcommerceCountryofOriginVisibility = true;
            UserOptions.EcommerceExternalIdVisibility = true;
            UserOptions.EcommerceExternalIdTypeVisibility = true;
            UserOptions.EcommerceItemAliasVisibility = true;
            UserOptions.EcommerceItemHeightVisibility = true;
            UserOptions.EcommerceItemLengthVisibility = true;
            UserOptions.EcommerceItemNameVisibility = true;
            UserOptions.EcommerceItemTypeKeywordsVisibility = true;
            UserOptions.EcommerceItemWeightVisibility = true;
            UserOptions.EcommerceItemWidthVisibility = true;
            UserOptions.EcommerceModelNameVisibility = true;
            UserOptions.EcommercePackageHeightVisibility = true;
            UserOptions.EcommercePackageLengthVisibility = true;
            UserOptions.EcommercePackageWeightVisibility = true;
            UserOptions.EcommercePackageWidthVisibility = true;
            UserOptions.EcommercePageQtyVisibility = true;
            UserOptions.EcommerceParentAsinVisibility = true;
            UserOptions.EcommerceProductCategoryVisibility = true;
            UserOptions.EcommerceProductDescriptionVisibility = true;
            UserOptions.EcommerceProductSubcategoryVisibility = true;
            UserOptions.EcommerceManufacturerNameVisibility = true;
            UserOptions.EcommerceMsrpVisibility = true;
            UserOptions.EcommerceSearchTermsVisibility = true;
            UserOptions.EcommerceSizeVisibility = true;
            UserOptions.EcommerceUpcVisibility = true;
        }

        /// <summary>
        ///     Sets the window title for mainwindowview. Makes distinction between production and development
        /// </summary>
        /// <returns></returns>
        public string SetWindowTitle()
        {
            string result = "Odin";
            if(Odin.Properties.Settings.Default.DbName=="FS88PRD")
            {
                result += " - " + GlobalData.UserName;
            }
            else if (Odin.Properties.Settings.Default.DbName == "FS88DEV")
            {
                result += " : Development - " + GlobalData.UserName;
            }
            return result;
        }

        /// <summary>
        ///     This function submits a request for items to be added to the website.
        /// </summary>
        public void SubmitItems()
        {
            List<ItemError> errors = new List<ItemError>();
            try
            {
                if (Items[0].Status != "Remove")
                {
                    foreach (ItemObject item in Items)
                    {
                        foreach (ItemError er in ItemService.ValidateItem(item, true))
                        {
                            if (er.ErrorType == "Error")
                            {
                                errors.Add(er);
                            }
                        }                    
                    }
                }
                if ((errors.Count == 0) || (Items[0].Status == "Remove"))
                {
                    string comment = string.Empty;
                    string site = string.Empty;
                    if (Items[0].Status == "Remove")
                    {
                        CommentBoxView window = new CommentBoxView()
                        {
                            DataContext = new CommentBoxViewModel()
                        };
                        window.ShowDialog();
                        if (window.DialogResult == true)
                        {
                            comment = (window.DataContext as CommentBoxViewModel).Comment;
                            site = (window.DataContext as CommentBoxViewModel).Website;
                        }
                        ExcelService.SubmitRequest(Items, "Remove", site, comment);
                        EmailService.SendPendingRequestEmail(GlobalData.UserName, comment, site, ExcelService.ReturnRequestNum());
                        MessageBox.Show("Items Removal Submitted Successfully");
                        Items = new ObservableCollection<ItemObject>(); ;
                        SubmitStatus = false;
                    }
                    else
                    {
                        string itemWebChecklist = string.Empty;
                        foreach (ItemObject item in this.Items)
                        {
                            if ((item.SellOnTrends != "Y") && (item.SellOnTrs != "Y"))
                            {
                                itemWebChecklist = (itemWebChecklist != string.Empty) ? itemWebChecklist += ", ": itemWebChecklist += item.ItemId + ", ";
                            }
                        }
                        if (itemWebChecklist == string.Empty)
                        {                            
                            bool isNew = string.IsNullOrEmpty(Items[0].NewDate) ? true : false;
                            if (isNew)
                            {
                                CommentBoxView window = new CommentBoxView()
                                {
                                    DataContext = new CommentBoxViewModel()
                                };
                                window.ShowDialog();
                                if (window.DialogResult == true)
                                {
                                    comment = (window.DataContext as CommentBoxViewModel).Comment;
                                    site = (window.DataContext as CommentBoxViewModel).Website;
                                }
                                Mouse.OverrideCursor = Cursors.Wait;
                                ExcelService.SubmitRequest(Items, "Add", site, comment);
                                EmailService.SendPendingRequestEmail(GlobalData.UserName, comment, site ,ExcelService.ReturnRequestNum());
                                Mouse.OverrideCursor = null;
                                MessageBox.Show("Items Submitted Successfully");
                                Items = new ObservableCollection<ItemObject>();
                                this.SubmitStatus = false;
                                Mouse.OverrideCursor = null;
                            }
                            else
                            {
                                CommentBoxView window = new CommentBoxView()
                                {
                                    DataContext = new CommentBoxViewModel()
                                };
                                window.ShowDialog();
                                if (window.DialogResult == true)
                                {
                                    comment = (window.DataContext as CommentBoxViewModel).Comment;
                                    site = (window.DataContext as CommentBoxViewModel).Website;
                                }
                                Mouse.OverrideCursor = Cursors.Wait;
                                ExcelService.SubmitRequest(Items, "Update", site, comment);
                                EmailService.SendPendingRequestEmail(GlobalData.UserName, comment, site, ExcelService.ReturnRequestNum());
                                MessageBox.Show("Items Submitted Successfully");
                                Items = new ObservableCollection<ItemObject>();
                                this.SubmitStatus = false;
                                Mouse.OverrideCursor = null;
                            }                            
                        }
                        else
                        {
                            MessageBox.Show("Please mark the following items to Sell on Trends before submitting " + itemWebChecklist);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please resolve all errors before submitting.");
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError("Odin was unable to submit the item request.", ex.ToString());
            }
        }
        
        /// <summary>
        ///     Scan Active items for 
        /// </summary>
        public void UpdateNewCategory()
        {
            MessageBox.Show("Functionality Coming Soon");
        }

        /// <summary>
        ///     opens the update template view / viewmodel
        /// </summary>
        public void UpdateTemplate()
        {
            TemplateView window = new TemplateView()
            {
                DataContext = new TemplateViewModel(this.ItemService, "Update")
            };
            window.ShowDialog();
        }

        /// <summary>
        ///     Function that opens the UploadWebViewModel. Alows users to upload a list of web information
        /// </summary>
        public void UpdateProducts()
        {
            UploadWebView window = new UploadWebView()
            {
                DataContext = new ItemUpdateViewModel(ItemService, ExcelService)
            };
            if (window.ShowDialog() == true)
            {
                this.ProgressText = "Validating Item Info";
                ClearLists();
                this.Items = (window.DataContext as ItemUpdateViewModel).ReturnList();
                if ((window.DataContext as ItemUpdateViewModel).IsKitFlag)
                {
                    foreach (ItemObject item in this.Items)
                    {
                        item.ProdType = 0;
                    }
                }
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += BackgroundWorkerValidate_DoWork;
                worker.ProgressChanged += BackgroundWorkerValidate_ProgressChanged;
                worker.WorkerReportsProgress = true;
                worker.RunWorkerCompleted += BackgroundWorkerValidate_RunWorkerCompleted;
                worker.RunWorkerAsync();
            }
        }

        /// <summary>
        ///     Loads in an excel sheet and updates all the templates in it.
        /// </summary>
        public void UploadTemplates()
        {
            WorkbookReader workbookReader = new WorkbookReader();
            string idAbsentees = String.Empty;
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "Excel files|*.xls; *.xlsx"
            };
            if (dialog.ShowDialog() != true)
            {
                return;
            }
            else
            {
                try
                {
                    List<string> results = ItemService.UploadTemplates(dialog.FileName);
                    if (results.Count != 0)
                    {
                        AlertView window = new AlertView()
                        {
                            DataContext = new AlertViewModel(results, "Alert", "Please resolve the following errors before uploading the templates.")
                        };
                        window.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Templates successfully updated.");
                        OpenTemplateAll();

                    }
                }
                catch(Exception ex)
                {
                    ErrorLog.LogError("Unable to retrieve existing template data.", ex.ToString());
                }
            }
        }
        
        /// <summary>
        ///     Checks a selected spreadsheet for errors
        /// </summary>
        public void ValidateSpreadSheet()
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Excel files|*.xls; *.xlsx"
            };
            if (dialog.ShowDialog() != true)
            {
                return ;
            }
            try
            {
                if (CheckCollumnHeaders(dialog.FileName))
                {
                    ObservableCollection<ItemObject> checkItems = ItemService.LoadExcelItems("Add", dialog.FileName);
                    ObservableCollection<ItemError> checkErrors = new ObservableCollection<ItemError>();
                    foreach (ItemObject item in checkItems)
                    {
                        foreach (ItemError error in this.ItemService.ValidateItem(item, false))
                        {
                            if (!checkErrors.Contains(error))
                            {
                                checkErrors.Add(error);
                            }
                        }
                    }
                    if (checkErrors.Count == 0)
                    {
                        MessageBox.Show("Everything is A-OK!");
                    }
                    else
                    {
                        List<string> errorMessages = new List<string>();
                        foreach (ItemError error in checkErrors)
                        {
                            error.LineNumber = error.LineNumber++;
                            errorMessages.Add("Row: " + error.LineNumber + " Error: " + error.ErrorMessage + "\r\n");
                        }

                        AlertView window = new AlertView()
                        {
                            DataContext = new AlertViewModel(errorMessages, "Alert", "The following errors were found in the given spreadsheet.")
                        };
                        window.ShowDialog();
                    }
                    foreach(ItemObject item in checkItems)
                    {
                        GlobalData.LocalItemIds.Remove(item.ItemId);
                    }
                }
            }
            catch(Exception ex)
            {
                ErrorLog.LogError("Odin was unable to validate the given spreadsheet.", ex.ToString());
            }
        
        }

        public void ViewDataWindow()
        {
            DataView window = new DataView()
            {
                DataContext = new DataViewModel()
            };
            window.ShowDialog();

        }

        /// <summary>
        ///     Populates and displays an alert window with all existing image files on the server.
        /// </summary>
        public void ViewEcommerceImageList()
        {
            if (!GlobalData.FtpUserexceptions.Contains(GlobalData.UserName))
            {
                this.FtpService = new FtpService();
                if(!GlobalData.ExistingFiles.Any())
                {
                    GlobalData.ExistingFiles = this.FtpService.ReturnExistingImageFiles();
                    GlobalData.ExistingFiles.Sort();
                }
                AlertView window = new AlertView()
                {
                    DataContext = new AlertViewModel(GlobalData.ExistingFiles, "Info", "The following images exist on the server.")
                };
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show("Odin could not access the image files.");
            }
        }

        /// <summary>
        ///     Bring up the View Submission Window
        /// </summary>
        public void ViewSubmissionsAdmin()
        {
            Items.Clear();
            ProductRequestView window1 = new ProductRequestView()
            {
                DataContext = new ProductRequestViewModel(true, true, this.EmailService, this.ExcelService, this.OptionService, this.ItemService)
            };
     
            window1.ShowDialog();
        }

        /// <summary>
        /// View personal submissions
        /// </summary>
        public void ViewSubmissions()
        {
            Items.Clear();
            ProductRequestView window = new ProductRequestView()
            {
                DataContext = new ProductRequestViewModel(false, false, this.EmailService, this.ExcelService, this.OptionService, this.ItemService)
            };
            window.ShowDialog();
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the MainWindowViewModel
        /// </summary>
        /// <param name="itemService"></param>
        /// <param name="optionService"></param>
        /// <param name="excelService"></param>
        /// <param name="workbookReader"></param>
        /// <param name="emailService"></param>
        public MainWindowViewModel(ItemService itemService,
            OptionService optionService,
            ExcelService excelService,
            WorkbookReader workbookReader,
            EmailService emailService)
        {
            try
            {
                this.EmailService = emailService ?? throw new ArgumentNullException("emailService");
                this.ExcelService = excelService ?? throw new ArgumentNullException("excelService");
                this.ItemService = itemService ?? throw new ArgumentNullException("itemService");
                this.OptionService = optionService ?? throw new ArgumentNullException("optionService");
                this.WorkbookReader = workbookReader ?? throw new ArgumentNullException("workbookReader");
                SetUserOptionsDefaults();
                this.SubmitStatus = false;
                this.SaveStatus = false;
                this.WindowTitle = SetWindowTitle();
            }
            catch
            {
                EditDbSettings();
            }
        }

        #endregion //Constructor
    }

}
