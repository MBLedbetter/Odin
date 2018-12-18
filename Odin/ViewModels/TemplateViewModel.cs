using ExcelLibrary;
using Mvvm;
using Odin.Views;
using OdinModels;
using OdinServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;

namespace Odin.ViewModels
{
    public class TemplateViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region Commands
        
        public ICommand SaveCommand
        {
            get
            {
                if (_save == null)
                {
                    _save = new RelayCommand(param => SaveTemplate());
                }
                return _save;
            }
        }
        private RelayCommand _save;

        #endregion // Commands

        #region Properties

        #region Odin Properties

        public int ProdType = 2;
                
        /// <summary>
        ///     Gets or sets the color of the Item Info tab
        /// </summary>
        public string ItemInfoTabColor
        {
            get
            {
                return _itemInfoTabColor;
            }
            set
            {
                _itemInfoTabColor = value;
                OnPropertyChanged("TabColorItemInfo");
            }
        }
        private string _itemInfoTabColor = "White";

        /// <summary>
        ///     Gets or sets the ItemService
        /// </summary>
        public ItemService ItemService { get; set; }
        
        /// <summary>
        ///     Gets or sets the color of the Ecommerce tab
        /// </summary>
        public string EcommerceTabColor
        {
            get
            {
                return _ecommerceTabColor;
            }
            set
            {
                _ecommerceTabColor = value;
                OnPropertyChanged("TabColorEcommerce");
            }
        }
        private string _ecommerceTabColor = "White";

        /// <summary>
        ///     Set the position of the column list dropdown
        /// </summary>
        public string TemplateListColumn
        {
            get
            {
                return _templateListColumn;
            }
            set
            {
                _templateListColumn = value;
                OnPropertyChanged("TemplateListColumn");
            }
        }
        private string _templateListColumn = "5";

        /// <summary>
        ///     Gets or sets the TemplateObject
        /// </summary>
        public ItemObject TemplateObject
        {
            get { return _templateObject; }
            set { _templateObject = value; }
        }
        private ItemObject _templateObject = new ItemObject(2);

        /// <summary>
        ///     Gets or sets the TemplateStatus
        /// </summary>
        public string TemplateStatus
        {
            get
            {
                return this.TemplateObject.Status;
            }
            set
            {
                if (this.TemplateObject.Status != value)
                {
                    this.TemplateObject.Status = value;
                    OnPropertyChanged("TemplateStatus");
                }
            }
        }

    /// <summary>
    ///     Dictionary of tool tips
    /// </summary>
        Dictionary<string, string> ToolTips
        {
            get
            {
                return GlobalData.ToolTips;
            }
        }

        /// <summary>
        ///     Gets or sets the UpdateVisibility
        /// </summary>
        public string UpdateVisibility
        {
            get
            {
                return _updateVisibility;
            }
            set
            {
                _updateVisibility = value;
                OnPropertyChanged("UpdateVisibility");
            }
        }
        private string _updateVisibility = "Hidden";

        /// <summary>
        ///     Gets or sets the color of the Web Info tab
        /// </summary>
        public string WebInfoTabColor
        {
            get
            {
                return _webInfoTabColor;
            }
            set
            {
                _webInfoTabColor = value;
                OnPropertyChanged("WebInfoTabColor");
            }
        }
        private string _webInfoTabColor = "White";

        /// <summary>
        ///     Gets or sets the WindowTitle
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
        private string _windowTitle = "Edit Template";

        #endregion // Odin Properties

        #region Peoplesoft Properties

        public string AccountingGroup
        {
            get
            {
                return this.TemplateObject.AccountingGroup;
            }
            set
            {
                if (this.TemplateObject.AccountingGroup != value)
                {
                    this.TemplateObject.AccountingGroup = value;
                    FlagError("AccountingGroup");
                    OnPropertyChanged("AccountingGroup");
                }
            }
        }
        public string AccountingGroupBoxColor
        {
            get
            {
                return _accountingGroupBoxColor;
            }
            set
            {
                _accountingGroupBoxColor = value;
                OnPropertyChanged("AccountingGroupBoxColor");
            }
        }
        private string _accountingGroupBoxColor = "White";
        public string AccountingGroupError
        {
            get
            {
                return _accountingGroupError;
            }
            set
            {
                _accountingGroupError = value;
                if (value != "")
                {
                    AccountingGroupToolTip = "Error: " + value + "\n\n" + ReturnToolTip("AccountingGroup");
                }
                else
                {
                    AccountingGroupToolTip = ReturnToolTip("AccountingGroup");
                }
                this.AccountingGroupBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("AccountingGroupError");
            }
        }
        private string _accountingGroupError = string.Empty;
        public string AccountingGroupToolTip
        {
            get
            {
                return _accountingGroupToolTip;
            }
            set
            {
                this._accountingGroupToolTip = value;
                OnPropertyChanged("AccountingGroupToolTip");
            }
        }
        private string _accountingGroupToolTip = string.Empty;

        public string CasepackHeight
        {
            get
            {
                return this.TemplateObject.CasepackHeight;
            }
            set
            {
                if (this.TemplateObject.CasepackHeight != value)
                {
                    this.TemplateObject.CasepackHeight = value;
                    FlagError("CasepackHeight");
                    OnPropertyChanged("CasepackHeight");
                }
            }
        }
        public string CasepackHeightBoxColor
        {
            get
            {
                return _casepackHeightBoxColor;
            }
            set
            {
                _casepackHeightBoxColor = value;
                OnPropertyChanged("CasepackHeightBoxColor");
            }
        }
        private string _casepackHeightBoxColor = "White";
        public string CasepackHeightError
        {
            get
            {
                return _casepackHeightError;
            }
            set
            {
                _casepackHeightError = value;
                if (value != "")
                {
                    CasepackHeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("CasepackDimension");
                }
                else
                {
                    CasepackHeightToolTip = ReturnToolTip("CasepackDimension");
                }
                this.CasepackHeightBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("CasepackHeightError");
            }
        }
        private string _casepackHeightError = string.Empty;
        public string CasepackHeightToolTip
        {
            get
            {
                return _casepackHeightToolTip;
            }
            set
            {
                this._casepackHeightToolTip = value;
                OnPropertyChanged("CasepackHeightToolTip");
            }
        }
        private string _casepackHeightToolTip = string.Empty;

        public string CasepackLength
        {
            get
            {
                return this.TemplateObject.CasepackLength.ToString();
            }
            set
            {
                if (this.TemplateObject.CasepackLength != value)
                {
                    this.TemplateObject.CasepackLength = value;
                    FlagError("CasepackLength");
                    OnPropertyChanged("CasepackLength");
                }
            }
        }
        public string CasepackLengthBoxColor
        {
            get
            {
                return _casepackLengthBoxColor;
            }
            set
            {
                _casepackLengthBoxColor = value;
                OnPropertyChanged("CasepackLengthBoxColor");
            }
        }
        private string _casepackLengthBoxColor = "White";
        public string CasepackLengthError
        {
            get
            {
                return _casepackLength;
            }
            set
            {
                _casepackLength = value;
                if (value != "")
                {
                    CasepackLengthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("CasepackDimension");
                }
                else
                {
                    CasepackLengthToolTip = ReturnToolTip("CasepackDimension");
                }
                this.CasepackLengthBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("CasepackLengthError");
            }
        }
        private string _casepackLength = string.Empty;
        public string CasepackLengthToolTip
        {
            get
            {
                return _casepackLengthToolTip;
            }
            set
            {
                this._casepackLengthToolTip = value;
                OnPropertyChanged("CasepackLengthToolTip");
            }
        }
        private string _casepackLengthToolTip = string.Empty;

        public string CasepackQty
        {
            get
            {
                if (this.TemplateObject.CasepackQty != string.Empty)
                {
                    return this.TemplateObject.CasepackQty;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.CasepackQty != value)
                {
                    this.TemplateObject.CasepackQty = value;
                    FlagError("CasepackQty");
                    OnPropertyChanged("CasepackQty");
                }
            }
        }
        public string CasepackQtyBoxColor
        {
            get
            {
                return _casepackQtyBoxColor;
            }
            set
            {
                _casepackQtyBoxColor = value;
                OnPropertyChanged("CasepackQtyBoxColor");
            }
        }
        private string _casepackQtyBoxColor = "White";
        public string CasepackQtyError
        {
            get
            {
                return _casepackQtyError;
            }
            set
            {
                _casepackQtyError = value;
                if (value != "")
                {
                    CasepackQtyToolTip = "Error: " + value + "\n\n" + ReturnToolTip("CasepackQty");
                }
                else
                {
                    CasepackQtyToolTip = ReturnToolTip("CasepackQty");
                }
                this.CasepackQtyBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("CasepackQtyError");
            }
        }
        private string _casepackQtyError = string.Empty;
        public string CasepackQtyToolTip
        {
            get
            {
                return _casepackQtyToolTip;
            }
            set
            {
                this._casepackQtyToolTip = value;
                OnPropertyChanged("CasepackQtyToolTip");
            }
        }
        private string _casepackQtyToolTip = string.Empty;
        
        public string CasepackWidth
        {
            get
            {
                if (this.TemplateObject.CasepackWidth != string.Empty)
                {
                    return this.TemplateObject.CasepackWidth.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.CasepackWidth != value)
                {
                    this.TemplateObject.CasepackWidth = value;
                    FlagError("CasepackWidth");
                    OnPropertyChanged("CasepackWidth");
                }
            }
        }
        public string CasepackWidthBoxColor
        {
            get
            {
                return _casepackWidthBoxColor;
            }
            set
            {
                _casepackWidthBoxColor = value;
                OnPropertyChanged("CasepackWidthBoxColor");
            }
        }
        private string _casepackWidthBoxColor = "White";
        public string CasepackWidthError
        {
            get
            {
                return _casepackWidthError;
            }
            set
            {
                _casepackWidthError = value;
                if (value != "")
                {
                    CasepackWidthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("CasepackDimension");
                }
                else
                {
                    CasepackWidthToolTip = ReturnToolTip("CasepackDimension");
                }
                this.CasepackWidthBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("CasepackWidthErrorMsg");
            }
        }
        private string _casepackWidthError = string.Empty;
        public string CasepackWidthToolTip
        {
            get
            {
                return _casepackWidthToolTip;
            }
            set
            {
                this._casepackWidthToolTip = value;
                OnPropertyChanged("CasepackWidthToolTip");
            }
        }
        private string _casepackWidthToolTip = string.Empty;

        public string CasepackWeight
        {
            get
            {
                if (this.TemplateObject.CasepackWeight != string.Empty)
                {
                    return this.TemplateObject.CasepackWeight.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.CasepackWeight != value)
                {
                    this.TemplateObject.CasepackWeight = value;
                    FlagError("CasepackWeight");
                    OnPropertyChanged("CasepackWeight");
                }
            }
        }
        public string CasepackWeightBoxColor
        {
            get
            {
                return _casepackWeightBoxColor;
            }
            set
            {
                _casepackWeightBoxColor = value;
                OnPropertyChanged("CasepackWeightBoxColor");
            }
        }
        private string _casepackWeightBoxColor = "White";
        public string CasepackWeightError
        {
            get
            {
                return _casepackWeightError;
            }
            set
            {
                _casepackWeightError = value;
                if (value != "")
                {
                    CasepackWeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("CasepackDimension");
                }
                else
                {
                    CasepackWeightToolTip = ReturnToolTip("CasepackDimension");
                }
                this.CasepackWeightBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("CasepackWeightError");
            }
        }
        private string _casepackWeightError = string.Empty;
        public string CasepackWeightToolTip
        {
            get
            {
                return _casepackWeightToolTip;
            }
            set
            {
                this._casepackWeightToolTip = value;
                OnPropertyChanged("CasepackWeightToolTip");
            }
        }
        private string _casepackWeightToolTip = string.Empty;
        
        public string CostProfileGroup
        {
            get
            {
                if (this.TemplateObject.CostProfileGroup != string.Empty)
                {
                    return this.TemplateObject.CostProfileGroup.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.CostProfileGroup != value)
                {
                    this.TemplateObject.CostProfileGroup = value;
                    FlagError("CostProfileGroup");
                    OnPropertyChanged("CostProfileGroup");
                }
            }
        }
        public string CostProfileGroupBoxColor
        {
            get
            {
                return _costProfileGroupBoxColor;
            }
            set
            {
                _costProfileGroupBoxColor = value;
                OnPropertyChanged("CostProfileGroupBoxColor");
            }
        }
        private string _costProfileGroupBoxColor = "White";
        public string CostProfileGroupError
        {
            get
            {
                return _costProfileGroupError;
            }
            set
            {
                _costProfileGroupError = value;
                if (value != "")
                {
                    CostProfileGroupToolTip = "Error: " + value + "\n\n" + ReturnToolTip("CostProfileGroup");
                }
                else
                {
                    CostProfileGroupToolTip = ReturnToolTip("CostProfileGroup");
                }
                this.CostProfileGroupBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("CostProfileGroupError");
            }
        }
        private string _costProfileGroupError = string.Empty;
        public string CostProfileGroupToolTip
        {
            get
            {
                return _costProfileGroupToolTip;
            }
            set
            {
                this._costProfileGroupToolTip = value;
                OnPropertyChanged("CostProfileGroupToolTip");
            }
        }
        private string _costProfileGroupToolTip = string.Empty;

        public string CountryOfOrigin
        {
            get
            {
                if (this.TemplateObject.CountryOfOrigin != string.Empty)
                {
                    return this.TemplateObject.CountryOfOrigin;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.CountryOfOrigin != value)
                {
                    this.TemplateObject.CountryOfOrigin = value;
                    FlagError("CountryOfOrigin");
                    OnPropertyChanged("CountryOfOrigin");
                }
            }
        }
        public string CountryOfOriginBoxColor
        {
            get
            {
                return _countryOfOriginBoxColor;
            }
            set
            {
                _countryOfOriginBoxColor = value;
                OnPropertyChanged("CountryOfOriginBoxColor");
            }
        }
        private string _countryOfOriginBoxColor = "White";
        public string CountryOfOriginError
        {
            get
            {
                return _countryOfOriginError;
            }
            set
            {
                _countryOfOriginError = value;
                if (value != "")
                {
                    CountryOfOriginToolTip = "Error: " + value + "\n\n" + ReturnToolTip("CountryOfOrigin");
                }
                else
                {
                    CountryOfOriginToolTip = ReturnToolTip("CountryOfOrigin");
                }
                this.CountryOfOriginBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("CountryOfOriginError");
            }
        }
        private string _countryOfOriginError = string.Empty;
        public string CountryOfOriginToolTip
        {
            get
            {
                return _countryOfOriginToolTip;
            }
            set
            {
                this._countryOfOriginToolTip = value;
                OnPropertyChanged("CountryOfOriginToolTip");
            }
        }
        private string _countryOfOriginToolTip = string.Empty;

        public string DefaultActualCostUsd
        {
            get
            {
                if (this.TemplateObject.DefaultActualCostUsd != string.Empty)
                {
                    return this.TemplateObject.DefaultActualCostUsd.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.DefaultActualCostUsd != value)
                {
                    this.TemplateObject.DefaultActualCostUsd = value;
                    FlagError("DefaultActualCostUsd");
                    OnPropertyChanged("DefaultActualCostUsd");
                }
            }
        }
        public string DefaultActualCostUsdBoxColor
        {
            get
            {
                return _defaultActualCostUsdBoxColor;
            }
            set
            {
                _defaultActualCostUsdBoxColor = value;
                OnPropertyChanged("DefaultActualCostUsdBoxColor");
            }
        }
        private string _defaultActualCostUsdBoxColor = "White";
        public string DefaultActualCostUsdError
        {
            get
            {
                return _defaultActualCostUsdError;
            }
            set
            {
                _defaultActualCostUsdError = value;
                if (value != "")
                {
                    DefaultActualCostUsdToolTip = "Error: " + value + "\n\n" + ReturnToolTip("DefaultActualCost");
                }
                else
                {
                    DefaultActualCostUsdToolTip = ReturnToolTip("DefaultActualCost");
                }
                this.DefaultActualCostUsdBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("DefaultActualCostUsdError");
            }
        }
        private string _defaultActualCostUsdError = string.Empty;
        public string DefaultActualCostUsdToolTip
        {
            get
            {
                return _defaultActualCostUsdToolTip;
            }
            set
            {
                this._defaultActualCostUsdToolTip = value;
                OnPropertyChanged("DefaultActualCostUsdToolTip");
            }
        }
        private string _defaultActualCostUsdToolTip = string.Empty;

        public string DefaultActualCostCad
        {
            get
            {
                if (this.TemplateObject.DefaultActualCostCad != string.Empty)
                {
                    return this.TemplateObject.DefaultActualCostCad.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.DefaultActualCostCad != value)
                {
                    this.TemplateObject.DefaultActualCostCad = value;
                    FlagError("DefaultActualCostCad");
                    OnPropertyChanged("DefaultActualCostCad");
                }
            }
        }
        public string DefaultActualCostCadBoxColor
        {
            get
            {
                return _defaultActualCostCadBoxColor;
            }
            set
            {
                _defaultActualCostCadBoxColor = value;
                OnPropertyChanged("DefaultActualCostCadBoxColor");
            }
        }
        private string _defaultActualCostCadBoxColor = "White";
        public string DefaultActualCostCadError
        {
            get
            {
                return _defaultActualCostCadError;
            }
            set
            {
                _defaultActualCostCadError = value;
                if (value != "")
                {
                    DefaultActualCostCadToolTip = "Error: " + value + "\n\n" + ReturnToolTip("DefaultActualCost");
                }
                else
                {
                    DefaultActualCostCadToolTip = ReturnToolTip("DefaultActualCost");
                }
                this.DefaultActualCostCadBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("DefaultActualCostCadError");
            }
        }
        private string _defaultActualCostCadError = string.Empty;
        public string DefaultActualCostCadToolTip
        {
            get
            {
                return _defaultActualCostCadToolTip;
            }
            set
            {
                this._defaultActualCostCadToolTip = value;
                OnPropertyChanged("DefaultActualCostCadToolTip");
            }
        }
        private string _defaultActualCostCadToolTip = string.Empty;
        
        public string Duty
        {
            get
            {
                if (this.TemplateObject.Duty != string.Empty)
                {
                    return this.TemplateObject.Duty.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.Duty != value)
                {
                    this.TemplateObject.Duty = value;
                    FlagError("Duty");
                    OnPropertyChanged("Duty");
                }
            }
        }
        public string DutyBoxColor
        {
            get
            {
                return _dutyBoxColor;
            }
            set
            {
                _dutyBoxColor = value;
                OnPropertyChanged("DutyBoxColor");
            }
        }
        private string _dutyBoxColor = "White";
        public string DutyError
        {
            get
            {
                return _dutyError;
            }
            set
            {
                _dutyError = value;
                if (value != "")
                {
                    DutyToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Duty");
                }
                else
                {
                    DutyToolTip = ReturnToolTip("Duty");
                }
                this.DutyBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("DutyError");
            }
        }
        private string _dutyError = string.Empty;
        public string DutyToolTip
        {
            get
            {
                return _dutyToolTip;
            }
            set
            {
                this._dutyToolTip = value;
                OnPropertyChanged("DutyToolTip");
            }
        }
        private string _dutyToolTip = string.Empty;
        
        public string Gpc
        {
            get
            {
                if (this.TemplateObject.Gpc != string.Empty)
                {
                    return this.TemplateObject.Gpc.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.Gpc != value)
                {
                    this.TemplateObject.Gpc = value;
                    FlagError("Gpc");
                    OnPropertyChanged("Gpc");
                }
            }
        }
        public string GpcBoxColor
        {
            get
            {
                return _gpcBoxColor;
            }
            set
            {
                _gpcBoxColor = value;
                OnPropertyChanged("GpcBoxColor");
            }
        }
        private string _gpcBoxColor = "White";
        public string GpcError
        {
            get
            {
                return _gpcError;
            }
            set
            {
                _gpcError = value;
                if (value != "")
                {
                    GpcToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Gpc");
                }
                else
                {
                    GpcToolTip = ReturnToolTip("Gpc");
                }
                this.GpcBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("GpcError");
            }
        }
        private string _gpcError = string.Empty;
        public string GpcToolTip
        {
            get
            {
                return _gpcToolTip;
            }
            set
            {
                this._gpcToolTip = value;
                OnPropertyChanged("GpcToolTip");
            }
        }
        private string _gpcToolTip = string.Empty;
        
        public string Height
        {
            get
            {
                if (this.TemplateObject.Height != string.Empty)
                {
                    return this.TemplateObject.Height.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.Height != value)
                {
                    this.TemplateObject.Height = value;
                    FlagError("Height");
                    OnPropertyChanged("Height");
                }
            }
        }
        public string HeightBoxColor
        {
            get
            {
                return _heightBoxColor;
            }
            set
            {
                _heightBoxColor = value;
                OnPropertyChanged("HeightBoxColor");
            }
        }
        private string _heightBoxColor = "White";
        public string HeightError
        {
            get
            {
                return _heightError;
            }
            set
            {
                _heightError = value;
                if (value != "")
                {
                    HeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Height");
                }
                else
                {
                    HeightToolTip = ReturnToolTip("Height");
                }
                this.HeightBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("HeightError");
            }
        }
        private string _heightError = string.Empty;
        public string HeightToolTip
        {
            get
            {
                return _heightToolTip;
            }
            set
            {
                this._heightToolTip = value;
                OnPropertyChanged("HeightToolTip");
            }
        }
        private string _heightToolTip = string.Empty;

        public string InnerpackHeight
        {
            get
            {
                if (this.TemplateObject.InnerpackHeight != string.Empty)
                {
                    return this.TemplateObject.InnerpackHeight.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.InnerpackHeight != value)
                {
                    this.TemplateObject.InnerpackHeight = value;
                    FlagError("InnerpackHeight");
                    OnPropertyChanged("InnerpackHeight");
                }
            }
        }
        public string InnerpackHeightBoxColor
        {
            get
            {
                return _innerpackHeightBoxColor;
            }
            set
            {
                _innerpackHeightBoxColor = value;
                OnPropertyChanged("InnerpackHeightBoxColor");
            }
        }
        private string _innerpackHeightBoxColor = "White";
        public string InnerpackHeightError
        {
            get
            {
                return _innerpackHeightError;
            }
            set
            {
                _innerpackHeightError = value;
                if (value != "")
                {
                    InnerpackHeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("InnerpackDimension");
                }
                else
                {
                    InnerpackHeightToolTip = ReturnToolTip("InnerpackDimension");
                }
                this.InnerpackHeightBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("InnerpackHeightError");
            }
        }
        private string _innerpackHeightError = string.Empty;
        public string InnerpackHeightToolTip
        {
            get
            {
                return _innerpackHeightToolTip;
            }
            set
            {
                this._innerpackHeightToolTip = value;
                OnPropertyChanged("InnerpackHeightToolTip");
            }
        }
        private string _innerpackHeightToolTip = string.Empty;

        public string InnerpackLength
        {
            get
            {
                if (this.TemplateObject.InnerpackLength != string.Empty)
                {
                    return this.TemplateObject.InnerpackLength.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.InnerpackLength != value)
                {
                    this.TemplateObject.InnerpackLength = value;
                    FlagError("InnerpackLength");
                    OnPropertyChanged("InnerpackLength");
                }
            }
        }
        public string InnerpackLengthBoxColor
        {
            get
            {
                return _innerpackLengthBoxColor;
            }
            set
            {
                _innerpackLengthBoxColor = value;
                OnPropertyChanged("InnerpackLengthBoxColor");
            }
        }
        private string _innerpackLengthBoxColor = "White";
        public string InnerpackLengthError
        {
            get
            {
                return _innerpackLengthError;
            }
            set
            {
                _innerpackLengthError = value;
                if (value != "")
                {
                    InnerpackLengthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("InnerpackDimension");
                }
                else
                {
                    InnerpackLengthToolTip = ReturnToolTip("InnerpackDimension");
                }
                this.InnerpackLengthBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("InnerpackLengthError");
            }
        }
        private string _innerpackLengthError = string.Empty;
        public string InnerpackLengthToolTip
        {
            get
            {
                return _innerpackLengthToolTip;
            }
            set
            {
                this._innerpackLengthToolTip = value;
                OnPropertyChanged("InnerpackLengthToolTip");
            }
        }
        private string _innerpackLengthToolTip = string.Empty;

        public string InnerpackQuantity
        {
            get
            {
                if (this.TemplateObject.InnerpackQuantity != string.Empty)
                {
                    return this.TemplateObject.InnerpackQuantity.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.InnerpackQuantity != value)
                {
                    this.TemplateObject.InnerpackQuantity = value;
                    FlagError("InnerpackQuantity");
                    OnPropertyChanged("InnerpackQuantity");
                }
            }
        }
        public string InnerpackQuantityBoxColor
        {
            get
            {
                return _innerpackQuantityBoxColor;
            }
            set
            {
                _innerpackQuantityBoxColor = value;
                OnPropertyChanged("InnerpackQuantityBoxColor");
            }
        }
        private string _innerpackQuantityBoxColor = "White";
        public string InnerpackQuantityError
        {
            get
            {
                return _innerpackQuantityError;
            }
            set
            {
                _innerpackQuantityError = value;
                if (value != "")
                {
                    InnerpackQuantityToolTip = "Error: " + value + "\n\n" + ReturnToolTip("InnerpackQuantity");
                }
                else
                {
                    InnerpackQuantityToolTip = ReturnToolTip("InnerpackQuantity");
                }
                this.InnerpackQuantityBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("InnerpackQuantityError");
            }
        }
        private string _innerpackQuantityError = string.Empty;
        public string InnerpackQuantityToolTip
        {
            get
            {
                return _innerpackQuantityToolTip;
            }
            set
            {
                this._innerpackQuantityToolTip = value;
                OnPropertyChanged("InnerpackQuantityToolTip");
            }
        }
        private string _innerpackQuantityToolTip = string.Empty;
        
        public string InnerpackWeight
        {
            get
            {
                if (this.TemplateObject.InnerpackWeight != string.Empty)
                {
                    return this.TemplateObject.InnerpackWeight.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.InnerpackWeight != value)
                {
                    this.TemplateObject.InnerpackWeight = value;
                    FlagError("InnerpackWeight");
                    OnPropertyChanged("InnerpackWeight");
                }
            }
        }
        public string InnerpackWeightBoxColor
        {
            get
            {
                return _innerpackWeightBoxColor;
            }
            set
            {
                _innerpackWeightBoxColor = value;
                OnPropertyChanged("InnerpackWeightBoxColor");
            }
        }
        private string _innerpackWeightBoxColor = "White";
        public string InnerpackWeightError
        {
            get
            {
                return _innerpackWeightError;
            }
            set
            {
                _innerpackWeightError = value;
                if (value != "")
                {
                    InnerpackWeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("InnerpackDimension");
                }
                else
                {
                    InnerpackWeightToolTip = ReturnToolTip("InnerpackDimension");
                }
                this.InnerpackWeightBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("InnerpackWeightError");
            }
        }
        private string _innerpackWeightError = string.Empty;
        public string InnerpackWeightToolTip
        {
            get
            {
                return _innerpackWeightToolTip;
            }
            set
            {
                this._innerpackWeightToolTip = value;
                OnPropertyChanged("InnerpackWeightToolTip");
            }
        }
        private string _innerpackWeightToolTip = string.Empty;

        public string InnerpackWidth
        {
            get
            {
                if (this.TemplateObject.InnerpackWidth != string.Empty)
                {
                    return this.TemplateObject.InnerpackWidth.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.InnerpackWidth != value)
                {
                    this.TemplateObject.InnerpackWidth = value;
                    FlagError("InnerpackWidth");
                    OnPropertyChanged("InnerpackWidth");
                }
            }
        }
        public string InnerpackWidthBoxColor
        {
            get
            {
                return _innerpackWidthBoxColor;
            }
            set
            {
                _innerpackWidthBoxColor = value;
                OnPropertyChanged("InnerpackWidthBoxColor");
            }
        }
        private string _innerpackWidthBoxColor = "White";
        public string InnerpackWidthError
        {
            get
            {
                return _innperpackWidthError;
            }
            set
            {
                _innperpackWidthError = value;
                if (value != "")
                {
                    InnerpackWidthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("InnerpackDimension");
                }
                else
                {
                    InnerpackWidthToolTip = ReturnToolTip("InnerpackDimension");
                }
                this.InnerpackWidthBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("InnerpackWidthError");
            }
        }
        private string _innperpackWidthError = string.Empty;
        public string InnerpackWidthToolTip
        {
            get
            {
                return _innerpackWidthToolTip;
            }
            set
            {
                this._innerpackWidthToolTip = value;
                OnPropertyChanged("InnerpackWidthToolTip");
            }
        }
        private string _innerpackWidthToolTip = string.Empty;
        
        public string ItemCategory
        {
            get
            {
                if (!string.IsNullOrEmpty(this.TemplateObject.ItemCategory))
                {
                    return this.TemplateObject.ItemCategory.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.ItemCategory != value)
                {
                    this.TemplateObject.ItemCategory = value;
                    FlagError("ItemCategory");
                    OnPropertyChanged("ItemCategory");
                }
            }
        }
        public string ItemCategoryBoxColor
        {
            get
            {
                return _itemCategoryBoxColor;
            }
            set
            {
                _itemCategoryBoxColor = value;
                OnPropertyChanged("ItemCategoryBoxColor");
            }
        }
        private string _itemCategoryBoxColor = "White";
        public string ItemCategoryError
        {
            get
            {
                return _itemCategoryError;
            }
            set
            {
                _itemCategoryError = value;
                if (value != "")
                {
                    ItemCategoryToolTip = "Error: " + value + "\n\n" + ReturnToolTip("ItemCategory");
                }
                else
                {
                    ItemCategoryToolTip = ReturnToolTip("ItemCategory");
                }
                this.ItemCategoryBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("ItemCategoryError");
            }
        }
        private string _itemCategoryError = string.Empty;
        public string ItemCategoryToolTip
        {
            get
            {
                return _itemCategoryToolTip;
            }
            set
            {
                this._itemCategoryToolTip = value;
                OnPropertyChanged("ItemCategoryToolTip");
            }
        }
        private string _itemCategoryToolTip = string.Empty;

        public string ItemFamily
        {
            get
            {
                if (this.TemplateObject.ItemFamily != string.Empty)
                {
                    return this.TemplateObject.ItemFamily;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.ItemFamily != value)
                {
                    this.TemplateObject.ItemFamily = value.ToUpper();
                    FlagError("ItemFamily");
                    OnPropertyChanged("ItemFamily");
                }
            }
        }
        public string ItemFamilyBoxColor
        {
            get
            {
                return _itemFamilyBoxColor;
            }
            set
            {
                _itemFamilyBoxColor = value;
                OnPropertyChanged("ItemFamilyBoxColor");
            }
        }
        private string _itemFamilyBoxColor = "White";
        public string ItemFamilyError
        {
            get
            {
                return _itemFamilyError;
            }
            set
            {
                _itemFamilyError = value;
                if (value != "")
                {
                    ItemFamilyToolTip = "Error: " + value + "\n\n" + ReturnToolTip("ItemFamily");
                }
                else
                {
                    ItemFamilyToolTip = ReturnToolTip("ItemFamily");
                }
                this.ItemFamilyBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("ItemFamilyErrorMsg");
            }
        }
        private string _itemFamilyError = string.Empty;
        public string ItemFamilyToolTip
        {
            get
            {
                return _itemFamilyToolTip;
            }
            set
            {
                this._itemFamilyToolTip = value;
                OnPropertyChanged("ItemFamilyToolTip");
            }
        }
        private string _itemFamilyToolTip = string.Empty;

        public string ItemGroup
        {
            get
            {
                if (!string.IsNullOrEmpty(this.TemplateObject.ItemGroup))
                {
                    return this.TemplateObject.ItemGroup.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.ItemGroup != value)
                {
                    this.TemplateObject.ItemGroup = value;
                    FlagError("ItemGroup");
                    OnPropertyChanged("ItemGroup");
                }
            }
        }
        public string ItemGroupBoxColor
        {
            get
            {
                return _itemGroupBoxColor;
            }
            set
            {
                _itemGroupBoxColor = value;
                OnPropertyChanged("ItemGroupBoxColor");
            }
        }
        private string _itemGroupBoxColor = "White";
        public string ItemGroupError
        {
            get
            {
                return _itemGroupError;
            }
            set
            {
                _itemGroupError = value;
                if (value != "")
                {
                    ItemGroupToolTip = "Error: " + value + "\n\n" + ReturnToolTip("ItemGroup");
                }
                else
                {
                    ItemGroupToolTip = ReturnToolTip("ItemGroup");
                }
                this.ItemGroupBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("ItemGroupError");
            }
        }
        private string _itemGroupError = string.Empty;
        public string ItemGroupToolTip
        {
            get
            {
                return _itemGroupToolTip;
            }
            set
            {
                this._itemGroupToolTip = value;
                OnPropertyChanged("ItemGroupToolTip");
            }
        }
        private string _itemGroupToolTip = string.Empty;
        
        public string Length
        {
            get
            {
                if (this.TemplateObject.Length != string.Empty)
                {
                    return this.TemplateObject.Length.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.Length != value)
                {
                    this.TemplateObject.Length = value;
                    FlagError("Length");
                    OnPropertyChanged("Length");
                }
            }
        }
        public string LengthBoxColor
        {
            get
            {
                return _lengthBoxColor;
            }
            set
            {
                _lengthBoxColor = value;
                OnPropertyChanged("LengthBoxColor");
            }
        }
        private string _lengthBoxColor = "White";
        public string LengthError
        {
            get
            {
                return _lengthError;
            }
            set
            {
                _lengthError = value;
                if (value != "")
                {
                    LengthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Length");
                }
                else
                {
                    LengthToolTip = ReturnToolTip("Length");
                }
                this.LengthBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("LengthError");
            }
        }
        private string _lengthError = string.Empty;
        public string LengthToolTip
        {
            get
            {
                return _lengthToolTip;
            }
            set
            {
                this._lengthToolTip = value;
                OnPropertyChanged("LengthToolTip");
            }
        }
        private string _lengthToolTip = string.Empty;
        
        /// <summary>
        ///     Gets or sets the ListPriceCad
        /// </summary>
        public string ListPriceCad
        {
            get
            {
                if (this.TemplateObject.ListPriceCad != string.Empty)
                {
                    return this.TemplateObject.ListPriceCad.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.ListPriceCad != value)
                {
                    this.TemplateObject.ListPriceCad = value;
                    FlagError("ListPriceCad");
                    OnPropertyChanged("ListPriceCad");
                }
            }
        }
        public string ListPriceCadBoxColor
        {
            get
            {
                return _listPriceCadBoxColor;
            }
            set
            {
                _listPriceCadBoxColor = value;
                OnPropertyChanged("ListPriceCadBoxColor");
            }
        }
        private string _listPriceCadBoxColor = "White";
        public string ListPriceCadError
        {
            get
            {
                return _listPriceCadError;
            }
            set
            {
                _listPriceCadError = value;
                if (value != "")
                {
                    ListPriceCadToolTip = "Error: " + value + "\n\n" + ReturnToolTip("ListPrice");
                }
                else
                {
                    ListPriceCadToolTip = ReturnToolTip("ListPrice");
                }
                this._listPriceCadBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("ListPriceCadError");
            }
        }
        private string _listPriceCadError = string.Empty;
        public string ListPriceCadToolTip
        {
            get
            {
                return _listPriceCadToolTip;
            }
            set
            {
                this._listPriceCadToolTip = value;
                OnPropertyChanged("ListPriceCadToolTip");
            }
        }
        private string _listPriceCadToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the ListPriceMxn
        /// </summary>
        public string ListPriceMxn
        {
            get
            {
                if (this.TemplateObject.ListPriceMxn != string.Empty)
                {
                    return this.TemplateObject.ListPriceMxn.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.ListPriceMxn != value)
                {
                    this.TemplateObject.ListPriceMxn = value;
                    FlagError("ListPriceMxn");
                    OnPropertyChanged("ListPriceMxn");
                }
            }
        }
        public string ListPriceMxnBoxColor
        {
            get
            {
                return _listPriceMxnBoxColor;
            }
            set
            {
                _listPriceMxnBoxColor = value;
                OnPropertyChanged("ListPriceMxnBoxColor");
            }
        }
        private string _listPriceMxnBoxColor = "White";
        public string ListPriceMxnError
        {
            get
            {
                return _listPriceMxnError;
            }
            set
            {
                _listPriceMxnError = value;
                if (value != "")
                {
                    ListPriceMxnToolTip = "Error: " + value + "\n\n" + ReturnToolTip("ListPrice");
                }
                else
                {
                    ListPriceMxnToolTip = ReturnToolTip("ListPrice");
                }
                this.ListPriceMxnBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("ListPriceMxnError");
            }
        }
        private string _listPriceMxnError = string.Empty;
        public string ListPriceMxnToolTip
        {
            get
            {
                return _listPriceMxnToolTip;
            }
            set
            {
                this._listPriceMxnToolTip = value;
                OnPropertyChanged("ListPriceMxnToolTip");
            }
        }
        private string _listPriceMxnToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the ListPriceUsd
        /// </summary>
        public string ListPriceUsd
        {
            get
            {
                if (this.TemplateObject.ListPriceUsd != string.Empty)
                {
                    return this.TemplateObject.ListPriceUsd.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.ListPriceUsd != value)
                {
                    this.TemplateObject.ListPriceUsd = value;
                    FlagError("ListPriceUsd");
                    OnPropertyChanged("ListPriceUsd");
                }
            }
        }
        public string ListPriceUsdBoxColor
        {
            get
            {
                return _listPriceUsdBoxColor;
            }
            set
            {
                _listPriceUsdBoxColor = value;
                OnPropertyChanged("ListPriceUsdBoxColor");
            }
        }
        private string _listPriceUsdBoxColor = "White";
        public string ListPriceUsdError
        {
            get
            {
                return _listPriceUsdError;
            }
            set
            {
                _listPriceUsdError = value;
                if (value != "")
                {
                    ListPriceUsdToolTip = "Error: " + value + "\n\n" + ReturnToolTip("ListPrice");
                }
                else
                {
                    ListPriceUsdToolTip = ReturnToolTip("ListPrice");
                }
                this.ListPriceUsdBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("ListPriceUsdError");
            }
        }
        private string _listPriceUsdError = string.Empty;
        public string ListPriceUsdToolTip
        {
            get
            {
                return _listPriceUsdToolTip;
            }
            set
            {
                this._listPriceUsdToolTip = value;
                OnPropertyChanged("ListPriceUsdToolTip");
            }
        }
        private string _listPriceUsdToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the MfgSource
        /// </summary>
        public string MfgSource
        {
            get
            {
                if (this.TemplateObject.MfgSource != string.Empty)
                {
                    return this.TemplateObject.MfgSource.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.MfgSource != value)
                {
                    this.TemplateObject.MfgSource = value;
                    FlagError("MfgSource");
                    OnPropertyChanged("MfgSource");
                }
            }
        }
        public string MfgSourceBoxColor
        {
            get
            {
                return _mfgSourceBoxColor;
            }
            set
            {
                _mfgSourceBoxColor = value;
                OnPropertyChanged("MfgSourceBoxColor");
            }
        }
        private string _mfgSourceBoxColor = "White";
        public string MfgSourceError
        {
            get
            {
                return _mfgSourceError;
            }
            set
            {
                _mfgSourceError = value;
                if (value != "")
                {
                    MfgSourceToolTip = "Error: " + value + "\n\n" + ReturnToolTip("MfgSource");
                }
                else
                {
                    MfgSourceToolTip = ReturnToolTip("MfgSource");
                }
                this.MfgSourceBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("MfgSourceError");
            }
        }
        private string _mfgSourceError = string.Empty;
        public string MfgSourceToolTip
        {
            get
            {
                return _mfgSourceToolTip;
            }
            set
            {
                this._mfgSourceToolTip = value;
                OnPropertyChanged("MfgSourceToolTip");
            }
        }
        private string _mfgSourceToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the Msrp
        /// </summary>
        public string Msrp
        {
            get
            {
                if (this.TemplateObject.Msrp != string.Empty)
                {
                    return this.TemplateObject.Msrp.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.Msrp != value)
                {
                    this.TemplateObject.Msrp = value;
                    FlagError("Msrp");
                    OnPropertyChanged("Msrp");
                }
            }
        }
        public string MsrpBoxColor
        {
            get
            {
                return _msrpBoxColor;
            }
            set
            {
                _msrpBoxColor = value;
                OnPropertyChanged("MsrpBoxColor");
            }
        }
        private string _msrpBoxColor = "White";
        public string MsrpError
        {
            get
            {
                return _msrpError;
            }
            set
            {
                _msrpError = value;
                if (value != "")
                {
                    MsrpToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Msrp");
                }
                else
                {
                    MsrpToolTip = ReturnToolTip("Msrp");
                }
                this.MsrpBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("MsrpError");
            }
        }
        private string _msrpError = string.Empty;
        public string MsrpToolTip
        {
            get
            {
                return _msrpToolTip;
            }
            set
            {
                this._msrpToolTip = value;
                OnPropertyChanged("MsrpToolTip");
            }
        }
        private string _msrpToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the MsrpCad
        /// </summary>
        public string MsrpCad
        {
            get
            {
                if (this.TemplateObject.MsrpCad != string.Empty)
                {
                    return this.TemplateObject.MsrpCad.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.MsrpCad != value)
                {
                    this.TemplateObject.MsrpCad = value;
                    FlagError("MsrpCad");
                    OnPropertyChanged("MsrpCad");
                }
            }
        }
        public string MsrpCadBoxColor
        {
            get
            {
                return _msrpCadBoxColor;
            }
            set
            {
                _msrpCadBoxColor = value;
                OnPropertyChanged("MsrpCadBoxColor");
            }
        }
        private string _msrpCadBoxColor = "White";
        public string MsrpCadError
        {
            get
            {
                return _msrpCadError;
            }
            set
            {
                _msrpCadError = value;
                if (value != "")
                {
                    MsrpCadToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Msrp");
                }
                else
                {
                    MsrpCadToolTip = ReturnToolTip("Msrp");
                }
                this.MsrpCadBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("MsrpCadError");
            }
        }
        private string _msrpCadError = string.Empty;
        public string MsrpCadToolTip
        {
            get
            {
                return _msrpCadToolTip;
            }
            set
            {
                this._msrpCadToolTip = value;
                OnPropertyChanged("MsrpCadToolTip");
            }
        }
        private string _msrpCadToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the MsrpMxn
        /// </summary>
        public string MsrpMxn
        {
            get
            {
                if (this.TemplateObject.MsrpMxn != string.Empty)
                {
                    return this.TemplateObject.MsrpMxn.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.MsrpMxn != value)
                {
                    this.TemplateObject.MsrpMxn = value;
                    FlagError("MsrpMxn");
                    OnPropertyChanged("MsrpMxn");
                }
            }
        }
        public string MsrpMxnBoxColor
        {
            get
            {
                return _msrpMxnBoxColor;
            }
            set
            {
                _msrpMxnBoxColor = value;
                OnPropertyChanged("MsrpMxnBoxColor");
            }
        }
        private string _msrpMxnBoxColor = "White";
        public string MsrpMxnError
        {
            get
            {
                return _msrpMxnError;
            }
            set
            {
                _msrpMxnError = value;
                if (value != "")
                {
                    MsrpMxnToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Msrp");
                }
                else
                {
                    MsrpMxnToolTip = ReturnToolTip("Msrp");
                }
                this.MsrpMxnBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("MsrpMxnError");
            }
        }
        private string _msrpMxnError = string.Empty;
        public string MsrpMxnToolTip
        {
            get
            {
                return _msrpMxnToolTip;
            }
            set
            {
                this._msrpMxnToolTip = value;
                OnPropertyChanged("MsrpMxnToolTip");
            }
        }
        private string _msrpMxnToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the PricingGroup
        /// </summary>
        public string PricingGroup
        {
            get
            {
                if (this.TemplateObject.PricingGroup != string.Empty)
                {
                    return this.TemplateObject.PricingGroup.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.PricingGroup != value)
                {
                    this.TemplateObject.PricingGroup = value;
                    FlagError("PricingGroup");
                    OnPropertyChanged("PricingGroup");
                }
            }
        }
        public string PricingGroupBoxColor
        {
            get
            {
                return _pricingGroupBoxColor;
            }
            set
            {
                _pricingGroupBoxColor = value;
                OnPropertyChanged("PricingGroupBoxColor");
            }
        }
        private string _pricingGroupBoxColor = "White";
        public string PricingGroupError
        {
            get
            {
                return _pricingGroupError;
            }
            set
            {
                _pricingGroupError = value;
                if (value != "")
                {
                    PricingGroupToolTip = "Error: " + value + "\n\n" + ReturnToolTip("PricingGroup");
                }
                else
                {
                    PricingGroupToolTip = ReturnToolTip("PricingGroup");
                }
                this.PricingGroupBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("PricingGroupError");
            }
        }
        private string _pricingGroupError = string.Empty;
        public string PricingGroupToolTip
        {
            get
            {
                return _pricingGroupToolTip;
            }
            set
            {
                this._pricingGroupToolTip = value;
                OnPropertyChanged("PricingGroupToolTip");
            }
        }
        private string _pricingGroupToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the PrintOnDemand
        /// </summary>
        public string PrintOnDemand
        {
            get
            {
                if (this.TemplateObject.PrintOnDemand != string.Empty)
                {
                    return this.TemplateObject.PrintOnDemand.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.PrintOnDemand != value)
                {
                    this.TemplateObject.PrintOnDemand = value;
                    FlagError("PrintOnDemand");
                    OnPropertyChanged("PrintOnDemand");
                }
            }
        }
        public string PrintOnDemandBoxColor
        {
            get
            {
                return _printOnDemandBoxColor;
            }
            set
            {
                _printOnDemandBoxColor = value;
                OnPropertyChanged("PrintOnDemandBoxColor");
            }
        }
        private string _printOnDemandBoxColor = "White";
        public string PrintOnDemandError
        {
            get
            {
                return _printOnDemandError;
            }
            set
            {
                _printOnDemandError = value;
                if (value != "")
                {
                    PrintOnDemandToolTip = "Error: " + value + "\n\n" + ReturnToolTip("PrintOnDemand");
                }
                else
                {
                    PrintOnDemandToolTip = ReturnToolTip("PrintOnDemand");
                }
                this.PrintOnDemandBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("PrintOnDemandError");
            }
        }
        private string _printOnDemandError = string.Empty;
        public string PrintOnDemandToolTip
        {
            get
            {
                return _printOnDemandToolTip;
            }
            set
            {
                this._printOnDemandToolTip = value;
                OnPropertyChanged("PrintOnDemandToolTip");
            }
        }
        private string _printOnDemandToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the ProductFormat
        /// </summary>
        public string ProductFormat
        {
            get
            {
                if (this.TemplateObject.ProductFormat != string.Empty)
                {
                    return this.TemplateObject.ProductFormat.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.ProductFormat != value)
                {
                    this.TemplateObject.ProductFormat = value;
                    FlagError("ProductFormat");
                    OnPropertyChanged("ProductFormat");
                }
            }
        }
        public string ProductFormatBoxColor
        {
            get
            {
                return _productFormatBoxColor;
            }
            set
            {
                _productFormatBoxColor = value;
                OnPropertyChanged("ProductFormatBoxColor");
            }
        }
        private string _productFormatBoxColor = "White";
        public string ProductFormatError
        {
            get
            {
                return _productFormatError;
            }
            set
            {
                _productFormatError = value;
                if (value != "")
                {
                    ProductFormatToolTip = "Error: " + value + "\n\n" + ReturnToolTip("ProductFormat");
                }
                else
                {
                    ProductFormatToolTip = ReturnToolTip("ProductFormat");
                }
                this.ProductFormatBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("ProductFormatError");
            }
        }
        private string _productFormatError = string.Empty;
        public string ProductFormatToolTip
        {
            get
            {
                return _productFormatToolTip;
            }
            set
            {
                this._productFormatToolTip = value;
                OnPropertyChanged("ProductFormatToolTip");
            }
        }
        private string _productFormatToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the ProductGroup
        /// </summary>
        public string ProductGroup
        {
            get
            {
                if (this.TemplateObject.ProductGroup != string.Empty)
                {
                    return this.TemplateObject.ProductGroup.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.ProductGroup != value)
                {
                    this.TemplateObject.ProductGroup = value;
                    FlagError("ProductGroup");
                    OnPropertyChanged("ProductGroup");
                }
            }
        }
        public string ProductGroupBoxColor
        {
            get
            {
                return _productGroupBoxColor;
            }
            set
            {
                _productGroupBoxColor = value;
                OnPropertyChanged("ProductGroupBoxColor");
            }
        }
        private string _productGroupBoxColor = "White";
        public string ProductGroupError
        {
            get
            {
                return _productGroupError;
            }
            set
            {
                _productGroupError = value;
                if (value != "")
                {
                    ProductGroupToolTip = "Error: " + value + "\n\n" + ReturnToolTip("ProductGroup");
                }
                else
                {
                    ProductGroupToolTip = ReturnToolTip("ProductGroup");
                }
                this.ProductGroupBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("ProductGroupError");
            }
        }
        private string _productGroupError = string.Empty;
        public string ProductGroupToolTip
        {
            get
            {
                return _productGroupToolTip;
            }
            set
            {
                this._productGroupToolTip = value;
                OnPropertyChanged("    ToolTip");
            }
        }
        private string _productGroupToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the ProductLine
        /// </summary>
        public string ProductLine
        {
            get
            {
                if (this.TemplateObject.ProductLine != string.Empty)
                {
                    return this.TemplateObject.ProductLine.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.ProductLine != value)
                {
                    this.TemplateObject.ProductLine = value;
                    FlagError("ProductLine");
                    OnPropertyChanged("ProductLine");
                }
            }
        }
        public string ProductLineBoxColor
        {
            get
            {
                return _productLineBoxColor;
            }
            set
            {
                _productLineBoxColor = value;
                OnPropertyChanged("ProductLineBoxColor");
            }
        }
        private string _productLineBoxColor = "White";
        public string ProductLineError
        {
            get
            {
                return _productLineError;
            }
            set
            {
                _productLineError = value;
                if (value != "")
                {
                    ProductLineToolTip = "Error: " + value + "\n\n" + ReturnToolTip("ProductLine");
                }
                else
                {
                    ProductLineToolTip = ReturnToolTip("ProductLine");
                }
                this.ProductLineBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("ProductLineError");
            }
        }
        private string _productLineError = string.Empty;
        public string ProductLineToolTip
        {
            get
            {
                return _productLineToolTip;
            }
            set
            {
                this._productLineToolTip = value;
                OnPropertyChanged("ProductLineToolTip");
            }
        }
        private string _productLineToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the ProductQty
        /// </summary>
        public string ProductQty
        {
            get
            {
                if (this.TemplateObject.ProductQty != string.Empty)
                {
                    return this.TemplateObject.ProductQty.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.ProductQty != value)
                {
                    this.TemplateObject.ProductQty = value;
                    FlagError("ProductQty");
                    OnPropertyChanged("ProductQty");
                }
            }
        }
        public string ProductQtyBoxColor
        {
            get
            {
                return _productQtyBoxColor;
            }
            set
            {
                _productQtyBoxColor = value;
                OnPropertyChanged("ProductQtyBoxColor");
            }
        }
        private string _productQtyBoxColor = "White";
        public string ProductQtyError
        {
            get
            {
                return _productQtyError;
            }
            set
            {
                _productQtyError = value;
                if (value != "")
                {
                    ProductQtyToolTip = "Error: " + value + "\n\n" + ReturnToolTip("ProductQty");
                }
                else
                {
                    ProductQtyToolTip = ReturnToolTip("ProductQty");
                }
                this.ProductQtyBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("ProductQtyError");
            }
        }
        private string _productQtyError = string.Empty;
        public string ProductQtyToolTip
        {
            get
            {
                return _productQtyToolTip;
            }
            set
            {
                this._productQtyToolTip = value;
                OnPropertyChanged("ProductQtyToolTip");
            }
        }
        private string _productQtyToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the PsStatus
        /// </summary>
        public string PsStatus
        {
            get
            {
                if (this.TemplateObject.PsStatus != string.Empty)
                {
                    return this.TemplateObject.PsStatus.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.PsStatus != value)
                {
                    this.TemplateObject.PsStatus = value;
                    FlagError("PsStatus");
                    OnPropertyChanged("PsStatus");
                }
            }
        }
        public string PsStatusBoxColor
        {
            get
            {
                return _psStatusBoxColor;
            }
            set
            {
                _psStatusBoxColor = value;
                OnPropertyChanged("PsStatusBoxColor");
            }
        }
        private string _psStatusBoxColor = "White";
        public string PsStatusError
        {
            get
            {
                return _psStatusError;
            }
            set
            {
                _psStatusError = value;
                if (value != "")
                {
                    PsStatusToolTip = "Error: " + value + "\n\n" + ReturnToolTip("PsStatus");
                }
                else
                {
                    PsStatusToolTip = ReturnToolTip("PsStatus");
                }
                this.PsStatusBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("PsStatusError");
            }
        }
        private string _psStatusError = string.Empty;
        public string PsStatusToolTip
        {
            get
            {
                return _psStatusToolTip;
            }
            set
            {
                _psStatusToolTip = value;
                OnPropertyChanged("PsStatusToolTip");
            }
        }
        private string _psStatusToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the SAT Code value
        /// </summary>
        public string SatCode
        {
            get
            {
                if (this.TemplateObject.SatCode != string.Empty)
                {
                    return this.TemplateObject.SatCode.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.SatCode != value)
                {
                    this.TemplateObject.SatCode = value;
                    FlagError("SatCode");
                    OnPropertyChanged("SatCode");
                }
            }
        }
        public string SatCodeBoxColor
        {
            get
            {
                return _satCodeBoxColor;
            }
            set
            {
                _satCodeBoxColor = value;
                OnPropertyChanged("SatCodeBoxColor");
            }
        }
        private string _satCodeBoxColor = "White";
        public string SatCodeError
        {
            get
            {
                return _satCodeError;
            }
            set
            {
                _satCodeError = value;
                if (value != "")
                {
                    SatCodeToolTip = "Error: " + value + "\n\n" + ReturnToolTip("SatCode");
                }
                else
                {
                    SatCodeToolTip = ReturnToolTip("SatCode");
                }
                this.SatCodeBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("SatCodeError");
            }
        }
        private string _satCodeError = string.Empty;
        public string SatCodeToolTip
        {
            get
            {
                return _satCodeToolTip;
            }
            set
            {
                this._satCodeToolTip = value;
                OnPropertyChanged("SatCodeToolTip");
            }
        }
        private string _satCodeToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the TariffCode value
        /// </summary>
        public string TariffCode
        {
            get
            {
                if (this.TemplateObject.TariffCode != string.Empty)
                {
                    return this.TemplateObject.TariffCode.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.TariffCode != value)
                {
                    this.TemplateObject.TariffCode = value;
                    FlagError("TariffCode");
                    OnPropertyChanged("TariffCode");
                }
            }
        }
        public string TariffCodeBoxColor
        {
            get
            {
                return _tariffCodeBoxColor;
            }
            set
            {
                _tariffCodeBoxColor = value;
                OnPropertyChanged("TariffCodeBoxColor");
            }
        }
        private string _tariffCodeBoxColor = "White";
        public string TariffCodeError
        {
            get
            {
                return _tariffCodeError;
            }
            set
            {
                _tariffCodeError = value;
                if (value != "")
                {
                    TariffCodeToolTip = "Error: " + value + "\n\n" + ReturnToolTip("TariffCode");
                }
                else
                {
                    TariffCodeToolTip = ReturnToolTip("TariffCode");
                }
                this.TariffCodeBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("TariffCodeError");
            }
        }
        private string _tariffCodeError = string.Empty;
        public string TariffCodeToolTip
        {
            get
            {
                return _tariffCodeToolTip;
            }
            set
            {
                this._tariffCodeToolTip = value;
                OnPropertyChanged("TariffCodeToolTip");
            }
        }
        private string _tariffCodeToolTip = string.Empty;
                
        /// <summary>
        ///     Gets or sets the Udex value
        /// </summary>
        public string Udex
        {
            get
            {
                if (this.TemplateObject.Udex != string.Empty)
                {
                    return this.TemplateObject.Udex.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.Udex != value)
                {
                    this.TemplateObject.Udex = value;
                    FlagError("Udex");
                    OnPropertyChanged("Udex");
                }
            }
        }
        public string UdexBoxColor
        {
            get
            {
                return _udexBoxColor;
            }
            set
            {
                _udexBoxColor = value;
                OnPropertyChanged("UdexBoxColor");
            }
        }
        private string _udexBoxColor = "White";
        public string UdexError
        {
            get
            {
                return _udexError;
            }
            set
            {
                _udexError = value;
                if (value != "")
                {
                    UdexToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Udex");
                }
                else
                {
                    UdexToolTip = ReturnToolTip("Udex");
                }
                this.UdexBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("UdexError");
            }
        }
        private string _udexError = string.Empty;
        public string UdexToolTip
        {
            get
            {
                return _udexToolTip;
            }
            set
            {
                this._udexToolTip = value;
                OnPropertyChanged("UdexToolTip");
            }
        }
        private string _udexToolTip = string.Empty;
        
        /// <summary>
        ///     Gets or sets the Weight value
        /// </summary>
        public string Weight
        {
            get
            {
                if (this.TemplateObject.Weight != string.Empty)
                {
                    return this.TemplateObject.Weight.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.Weight != value)
                {
                    this.TemplateObject.Weight = value;
                    FlagError("Weight");
                    OnPropertyChanged("Weight");
                }
            }
        }
        public string WeightBoxColor
        {
            get
            {
                return _weightBoxColor;
            }
            set
            {
                _weightBoxColor = value;
                OnPropertyChanged("WeightBoxColor");
            }
        }
        private string _weightBoxColor = "White";
        public string WeightError
        {
            get
            {
                return _weightError;
            }
            set
            {
                _weightError = value;
                if (value != "")
                {
                    WeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Weight");
                }
                else
                {
                    WeightToolTip = ReturnToolTip("Weight");
                }
                this.WeightBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("WeightError");
            }
        }
        private string _weightError = string.Empty;
        public string WeightToolTip
        {
            get
            {
                return _weightToolTip;
            }
            set
            {
                this._weightToolTip = value;
                OnPropertyChanged("WeightToolTip");
            }
        }
        private string _weightToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the Width value
        /// </summary>
        public string Width
        {
            get
            {
                if (this.TemplateObject.Width != string.Empty)
                {
                    return this.TemplateObject.Width.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.Width != value)
                {
                    this.TemplateObject.Width = value;
                    FlagError("Width");
                    OnPropertyChanged("Width");
                }
            }
        }
        public string WidthBoxColor
        {
            get
            {
                return _widthBoxColor;
            }
            set
            {
                _widthBoxColor = value;
                OnPropertyChanged("WidthBoxColor");
            }
        }
        private string _widthBoxColor = "White";
        public string WidthError
        {
            get
            {
                return _widthError;
            }
            set
            {
                _widthError = value;
                if (value != "")
                {
                    WidthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Width");
                }
                else
                {
                    WidthToolTip = ReturnToolTip("Width");
                }
                this.WidthBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("WidthError");
            }
        }
        private string _widthError = string.Empty;
        public string WidthToolTip
        {
            get
            {
                return _widthToolTip;
            }
            set
            {
                this._widthToolTip = value;
                OnPropertyChanged("WidthToolTip");
            }
        }
        private string _widthToolTip = string.Empty;

        #endregion // Peoplesoft Properties

        #region B2B Properties

        public string Copyright
        {
            get
            {
                if (this.TemplateObject.Copyright != string.Empty)
                {
                    return this.TemplateObject.Copyright.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.Copyright != value)
                {
                    this.TemplateObject.Copyright = value;
                    FlagError("Copyright");
                    OnPropertyChanged("Copyright");
                }
            }
        }
        public string CopyrightBoxColor
        {
            get
            {
                return _copyrightBoxColor;
            }
            set
            {
                _copyrightBoxColor = value;
                OnPropertyChanged("CopyrightBoxColor");
            }
        }
        private string _copyrightBoxColor = "White";
        public string CopyrightError
        {
            get
            {
                return _copyrightError;
            }
            set
            {
                _copyrightError = value;
                if (value != "")
                {
                    CopyrightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Copyright");
                }
                else
                {
                    CopyrightToolTip = ReturnToolTip("Copyright");
                }
                this.CopyrightBoxColor = (value == "") ? "White" : "Tomato";
                this.WebInfoTabColor = CheckWebInfoTabColor();
                OnPropertyChanged("CopyrightError");
            }
        }
        private string _copyrightError = string.Empty;
        public string CopyrightToolTip
        {
            get
            {
                return _copyrightToolTip;
            }
            set
            {
                this._copyrightToolTip = value;
                OnPropertyChanged("CopyrightToolTip");
            }
        }
        private string _copyrightToolTip = string.Empty;
        
        public string Category
        {
            get
            {
                if (this.TemplateObject.Category != string.Empty)
                {
                    return this.TemplateObject.Category.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.Category != value)
                {
                    this.TemplateObject.Category = value;
                    FlagError("Category");
                    OnPropertyChanged("Category");
                }
            }
        }
        public string CategoryBoxColor
        {
            get
            {
                return _categoryBoxColor;
            }
            set
            {
                _categoryBoxColor = value;
                OnPropertyChanged("CategoryBoxColor");
            }
        }
        private string _categoryBoxColor = "White";
        public string CategoryError
        {
            get
            {
                return _categoryError;
            }
            set
            {
                _categoryError = value;
                if (value != "")
                {
                    CategoryToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Category");
                }
                else
                {
                    CategoryToolTip = ReturnToolTip("Category");
                }
                this.CategoryBoxColor = (value == "") ? "White" : "Tomato";
                this.WebInfoTabColor = CheckWebInfoTabColor();
                OnPropertyChanged("CategoryError");
            }
        }
        private string _categoryError = string.Empty;
        public string CategoryToolTip
        {
            get
            {
                return _categoryToolTip;
            }
            set
            {
                this._categoryToolTip = value;
                OnPropertyChanged("CategoryToolTip");
            }
        }
        private string _categoryToolTip = string.Empty;

        public string Category2
        {
            get
            {
                if (this.TemplateObject.Category2 != string.Empty)
                {
                    return this.TemplateObject.Category2.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.Category2 != value)
                {
                    this.TemplateObject.Category2 = value;
                    FlagError("Category2");
                    OnPropertyChanged("Category2");
                }
            }
        }
        public string Category2BoxColor
        {
            get
            {
                return _category2BoxColor;
            }
            set
            {
                _category2BoxColor = value;
                OnPropertyChanged("Category2BoxColor");
            }
        }
        private string _category2BoxColor = "White";
        public string Category2Error
        {
            get
            {
                return _category2Error;
            }
            set
            {
                _category2Error = value;
                if (value != "")
                {
                    Category2ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Category");
                }
                else
                {
                    Category2ToolTip = ReturnToolTip("Category");
                }
                this.Category2BoxColor = (value == "") ? "White" : "Tomato";
                this.WebInfoTabColor = CheckWebInfoTabColor();
                OnPropertyChanged("Category2Error");
            }
        }
        private string _category2Error = string.Empty;
        public string Category2ToolTip
        {
            get
            {
                return _category2ToolTip;
            }
            set
            {
                this._category2ToolTip = value;
                OnPropertyChanged("Category2ToolTip");
            }
        }
        private string _category2ToolTip = string.Empty;

        public string Category3
        {
            get
            {
                if (this.TemplateObject.Category3 != string.Empty)
                {
                    return this.TemplateObject.Category3.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.Category3 != value)
                {
                    this.TemplateObject.Category3 = value;
                    FlagError("Category3");
                    OnPropertyChanged("Category3");
                }
            }
        }
        public string Category3BoxColor
        {
            get
            {
                return _category3BoxColor;
            }
            set
            {
                _category3BoxColor = value;
                OnPropertyChanged("Category3BoxColor");
            }
        }
        private string _category3BoxColor = "White";
        public string Category3Error
        {
            get
            {
                return _category3Error;
            }
            set
            {
                _category3Error = value;
                if (value != "")
                {
                    Category3ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Category");
                }
                else
                {
                    Category3ToolTip = ReturnToolTip("Category");
                }
                this.Category3BoxColor = (value == "") ? "White" : "Tomato";
                this.WebInfoTabColor = CheckWebInfoTabColor();
                OnPropertyChanged("Category3Error");
            }
        }
        private string _category3Error = string.Empty;
        public string Category3ToolTip
        {
            get
            {
                return _category3ToolTip;
            }
            set
            {
                this._category3ToolTip = value;
                OnPropertyChanged("Category3ToolTip");
            }
        }
        private string _category3ToolTip = string.Empty;
                
        public string MetaDescription
        {
            get
            {
                if (this.TemplateObject.MetaDescription != string.Empty)
                {
                    return this.TemplateObject.MetaDescription.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.MetaDescription != value)
                {
                    this.TemplateObject.MetaDescription = value;
                    FlagError("MetaDescription");
                    OnPropertyChanged("MetaDescription");
                }
            }
        }
        public string MetaDescriptionBoxColor
        {
            get
            {
                return _metaDescriptionBoxColor;
            }
            set
            {
                _metaDescriptionBoxColor = value;
                OnPropertyChanged("MetaDescriptionBoxColor");
            }
        }
        private string _metaDescriptionBoxColor = "White";
        public string MetaDescriptionError
        {
            get
            {
                return _metaDescriptionError;
            }
            set
            {
                _metaDescriptionError = value;
                if (value != "")
                {
                    MetaDescriptionToolTip = "Error: " + value + "\n\n" + ReturnToolTip("MetaDescription");
                }
                else
                {
                    MetaDescriptionToolTip = ReturnToolTip("MetaDescription");
                }
                this.MetaDescriptionBoxColor = (value == "") ? "White" : "Tomato";
                this.WebInfoTabColor = CheckWebInfoTabColor();
                OnPropertyChanged("MetaDescriptionError");
            }
        }
        private string _metaDescriptionError = string.Empty;
        public string MetaDescriptionToolTip
        {
            get
            {
                return _metaDescriptionToolTip;
            }
            set
            {
                this._metaDescriptionToolTip = value;
                OnPropertyChanged("MetaDescriptionToolTip");
            }
        }
        private string _metaDescriptionToolTip = string.Empty;
        
        public string Size
        {
            get
            {
                if (this.TemplateObject.Size != string.Empty)
                {
                    return this.TemplateObject.Size;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.Size != value)
                {
                    this.TemplateObject.Size = value;
                    FlagError("Size");
                    OnPropertyChanged("Size");
                }
            }
        }
        public string SizeBoxColor
        {
            get
            {
                return _sizeBoxColor;
            }
            set
            {
                _sizeBoxColor = value;
                OnPropertyChanged("SizeBoxColor");
            }
        }
        private string _sizeBoxColor = "White";
        public string SizeError
        {
            get
            {
                return _sizeError;
            }
            set
            {
                _sizeError = value;
                if (value != "")
                {
                    SizeToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Size");
                }
                else
                {
                    SizeToolTip = ReturnToolTip("Size");
                }
                this.SizeBoxColor = (value == "") ? "White" : "Tomato";
                this.WebInfoTabColor = CheckWebInfoTabColor();
                OnPropertyChanged("SizeError");
            }
        }
        private string _sizeError = string.Empty;
        public string SizeToolTip
        {
            get
            {
                return _sizeToolTip;
            }
            set
            {
                this._sizeToolTip = value;
                OnPropertyChanged("SizeToolTip");
            }
        }
        private string _sizeToolTip = string.Empty;

        public string WebsitePrice
        {
            get
            {
                if (this.TemplateObject.WebsitePrice != string.Empty)
                {
                    return this.TemplateObject.WebsitePrice;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.WebsitePrice != value)
                {
                    this.TemplateObject.WebsitePrice = value;
                    FlagError("WebsitePrice");
                    OnPropertyChanged("WebsitePrice");
                }
            }
        }
        public string WebsitePriceBoxColor
        {
            get
            {
                return _websitePriceBoxColor;
            }
            set
            {
                _websitePriceBoxColor = value;
                OnPropertyChanged("WebsitePriceBoxColor");
            }
        }
        private string _websitePriceBoxColor = "White";
        public string WebsitePriceError
        {
            get
            {
                return _websitePriceError;
            }
            set
            {
                _websitePriceError = value;
                if (value != "")
                {
                    WebsitePriceToolTip = "Error: " + value + "\n\n" + ReturnToolTip("WebsitePrice");
                }
                else
                {
                    WebsitePriceToolTip = ReturnToolTip("WebsitePrice");
                }
                this.WebsitePriceBoxColor = (value == "") ? "White" : "Tomato";
                this.WebInfoTabColor = CheckWebInfoTabColor();
                OnPropertyChanged("WebsitePriceError");
            }
        }
        private string _websitePriceError = string.Empty;
        public string WebsitePriceToolTip
        {
            get
            {
                return _websitePriceToolTip;
            }
            set
            {
                this._websitePriceToolTip = value;
                OnPropertyChanged("WebsitePriceToolTip");
            }
        }
        private string _websitePriceToolTip = string.Empty;

        #endregion // B2B Properties

        #region Ecommerce Properties

        /// <summary>
        ///     EcommerceBullet1
        /// </summary>
        public string EcommerceBullet1
        {
            get
            {
                if (this.TemplateObject.EcommerceBullet1 != string.Empty)
                {
                    return this.TemplateObject.EcommerceBullet1;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceBullet1 != value)
                {
                    this.TemplateObject.EcommerceBullet1 = value;
                    FlagError("EcommerceBullet1");
                    OnPropertyChanged("EcommerceBullet1");
                }
            }
        }
        public string EcommerceBullet1BoxColor
        {
            get
            {
                return _ecommercebullet1BoxColor;
            }
            set
            {
                _ecommercebullet1BoxColor = value;
                OnPropertyChanged("EcommerceBullet1BoxColor");
            }
        }
        private string _ecommercebullet1BoxColor = "White";
        public string EcommerceBullet1Error
        {
            get
            {
                return _ecommercebullet1Error;
            }
            set
            {
                _ecommercebullet1Error = value;
                if (value != "")
                {
                    EcommerceBullet1ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceBulletToolTip");
                }
                else
                {
                    EcommerceBullet1ToolTip = ReturnToolTip("EcommerceBulletToolTip");
                }
                this.EcommerceBullet1BoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceBullet1Error");
            }
        }
        private string _ecommercebullet1Error = string.Empty;
        public string EcommerceBullet1ToolTip
        {
            get
            {
                return _ecommercebullet1ToolTip;
            }
            set
            {
                this._ecommercebullet1ToolTip = value;
                OnPropertyChanged("EcommerceBullet1ToolTip");
            }
        }
        private string _ecommercebullet1ToolTip = string.Empty;

        /// <summary>
        ///    EcommerceBullet2
        /// </summary>
        public string EcommerceBullet2
        {
            get
            {
                if (this.TemplateObject.EcommerceBullet2 != string.Empty)
                {
                    return this.TemplateObject.EcommerceBullet2;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceBullet2 != value)
                {
                    this.TemplateObject.EcommerceBullet2 = value;
                    FlagError("EcommerceBullet2");
                    OnPropertyChanged("EcommerceBullet2");
                }
            }
        }
        public string EcommerceBullet2BoxColor
        {
            get
            {
                return _ecommercebullet2BoxColor;
            }
            set
            {
                _ecommercebullet2BoxColor = value;
                OnPropertyChanged("EcommerceBullet2BoxColor");
            }
        }
        private string _ecommercebullet2BoxColor = "White";
        public string EcommerceBullet2Error
        {
            get
            {
                return _ecommercebullet2Error;
            }
            set
            {
                _ecommercebullet2Error = value;
                if (value != "")
                {
                    EcommerceBullet2ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceBulletToolTip"); ;
                }
                else
                {
                    EcommerceBullet2ToolTip = ReturnToolTip("EcommerceBulletToolTip"); ;
                }
                this.EcommerceBullet2BoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceBullet2Error");
            }
        }
        private string _ecommercebullet2Error = string.Empty;
        public string EcommerceBullet2ToolTip
        {
            get
            {
                return _ecommercebullet2ToolTip;
            }
            set
            {
                this._ecommercebullet2ToolTip = value;
                OnPropertyChanged("EcommerceBullet2ToolTip");
            }
        }
        private string _ecommercebullet2ToolTip = string.Empty;

        /// <summary>
        ///    EcommerceBullet3
        /// </summary>
        public string EcommerceBullet3
        {
            get
            {
                if (this.TemplateObject.EcommerceBullet3 != string.Empty)
                {
                    return this.TemplateObject.EcommerceBullet3;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceBullet3 != value)
                {
                    this.TemplateObject.EcommerceBullet3 = value;
                    FlagError("EcommerceBullet3");
                    OnPropertyChanged("EcommerceBullet3");
                }
            }
        }
        public string EcommerceBullet3BoxColor
        {
            get
            {
                return _ecommercebullet3BoxColor;
            }
            set
            {
                _ecommercebullet3BoxColor = value;
                OnPropertyChanged("EcommerceBullet3BoxColor");
            }
        }
        private string _ecommercebullet3BoxColor = "White";
        public string EcommerceBullet3Error
        {
            get
            {
                return _ecommercebullet3Error;
            }
            set
            {
                _ecommercebullet3Error = value;
                if (value != "")
                {
                    EcommerceBullet3ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceBulletToolTip");
                }
                else
                {
                    EcommerceBullet3ToolTip = ReturnToolTip("EcommerceBulletToolTip");
                }
                this.EcommerceBullet3BoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceBullet3Error");
            }
        }
        private string _ecommercebullet3Error = string.Empty;
        public string EcommerceBullet3ToolTip
        {
            get
            {
                return _ecommercebullet3ToolTip;
            }
            set
            {
                this._ecommercebullet3ToolTip = value;
                OnPropertyChanged("EcommerceBullet3ToolTip");
            }
        }
        private string _ecommercebullet3ToolTip = string.Empty;

        /// <summary>
        ///    EcommerceBullet4
        /// </summary>
        public string EcommerceBullet4
        {
            get
            {
                if (this.TemplateObject.EcommerceBullet4 != string.Empty)
                {
                    return this.TemplateObject.EcommerceBullet4;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceBullet4 != value)
                {
                    this.TemplateObject.EcommerceBullet4 = value;
                    FlagError("EcommerceBullet4");
                    OnPropertyChanged("EcommerceBullet4");
                }
            }
        }
        public string EcommerceBullet4BoxColor
        {
            get
            {
                return _ecommercebullet4BoxColor;
            }
            set
            {
                _ecommercebullet4BoxColor = value;
                OnPropertyChanged("EcommerceBullet4BoxColor");
            }
        }
        private string _ecommercebullet4BoxColor = "White";
        public string EcommerceBullet4Error
        {
            get
            {
                return _ecommercebullet4Error;
            }
            set
            {
                _ecommercebullet4Error = value;
                if (value != "")
                {
                    EcommerceBullet4ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceBulletToolTip");
                }
                else
                {
                    EcommerceBullet4ToolTip = ReturnToolTip("EcommerceBulletToolTip");
                }
                this.EcommerceBullet4BoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceBullet4Error");
            }
        }
        private string _ecommercebullet4Error = string.Empty;
        public string EcommerceBullet4ToolTip
        {
            get
            {
                return _ecommercebullet4ToolTip;
            }
            set
            {
                this._ecommercebullet4ToolTip = value;
                OnPropertyChanged("EcommerceBullet4ToolTip");
            }
        }
        private string _ecommercebullet4ToolTip = string.Empty;

        /// <summary>
        ///    EcommerceBullet5
        /// </summary>
        public string EcommerceBullet5
        {
            get
            {
                if (this.TemplateObject.EcommerceBullet5 != string.Empty)
                {
                    return this.TemplateObject.EcommerceBullet5;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceBullet5 != value)
                {
                    this.TemplateObject.EcommerceBullet5 = value;
                    FlagError("EcommerceBullet5");
                    OnPropertyChanged("EcommerceBullet5");
                }
            }
        }
        public string EcommerceBullet5BoxColor
        {
            get
            {
                return _ecommercebullet5BoxColor;
            }
            set
            {
                _ecommercebullet5BoxColor = value;
                OnPropertyChanged("EcommerceBullet5BoxColor");
            }
        }
        private string _ecommercebullet5BoxColor = "White";
        public string EcommerceBullet5Error
        {
            get
            {
                return _ecommercebullet5Error;
            }
            set
            {
                _ecommercebullet5Error = value;
                if (value != "")
                {
                    EcommerceBullet5ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceBulletToolTip");
                }
                else
                {
                    EcommerceBullet5ToolTip = ReturnToolTip("EcommerceBulletToolTip");
                }
                this.EcommerceBullet5BoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceBullet5Error");
            }
        }
        private string _ecommercebullet5Error = string.Empty;
        public string EcommerceBullet5ToolTip
        {
            get
            {
                return _ecommercebullet5ToolTip;
            }
            set
            {
                this._ecommercebullet5ToolTip = value;
                OnPropertyChanged("EcommerceBullet5ToolTip");
            }
        }
        private string _ecommercebullet5ToolTip = string.Empty;

        /// <summary>
        ///    EcommerceComponents
        /// </summary>
        public string EcommerceComponents
        {
            get
            {
                if (this.TemplateObject.EcommerceComponents != string.Empty)
                {
                    return this.TemplateObject.EcommerceComponents;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceComponents != value)
                {
                    this.TemplateObject.EcommerceComponents = value;
                    FlagError("EcommerceComponents");
                    OnPropertyChanged("EcommerceComponents");
                }
            }
        }
        public string EcommerceComponentsBoxColor
        {
            get
            {
                return _ecommercecomponentsBoxColor;
            }
            set
            {
                _ecommercecomponentsBoxColor = value;
                OnPropertyChanged("EcommerceComponentsBoxColor");
            }
        }
        private string _ecommercecomponentsBoxColor = "White";
        public string EcommerceComponentsError
        {
            get
            {
                return _ecommercecomponentsError;
            }
            set
            {
                _ecommercecomponentsError = value;
                if (value != "")
                {
                    EcommerceComponentsToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceComponentsToolTip");
                }
                else
                {
                    EcommerceComponentsToolTip = ReturnToolTip("EcommerceComponentsToolTip");
                }
                this.EcommerceComponentsBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceComponentsError");
            }
        }
        private string _ecommercecomponentsError = string.Empty;
        public string EcommerceComponentsToolTip
        {
            get
            {
                return _ecommercecomponentsToolTip;
            }
            set
            {
                this._ecommercecomponentsToolTip = value;
                OnPropertyChanged("EcommerceComponentsToolTip");
            }
        }
        private string _ecommercecomponentsToolTip = string.Empty;

        /// <summary>
        ///    EcommerceCost
        /// </summary>
        public string EcommerceCost
        {
            get
            {
                if (this.TemplateObject.EcommerceCost != string.Empty)
                {
                    return this.TemplateObject.EcommerceCost;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceCost != value)
                {
                    this.TemplateObject.EcommerceCost = value;
                    FlagError("EcommerceCost");
                    OnPropertyChanged("EcommerceCost");
                }
            }
        }
        public string EcommerceCostBoxColor
        {
            get
            {
                return _ecommerceCostBoxColor;
            }
            set
            {
                _ecommerceCostBoxColor = value;
                OnPropertyChanged("EcommerceCostBoxColor");
            }
        }
        private string _ecommerceCostBoxColor = "White";
        public string EcommerceCostError
        {
            get
            {
                return _ecommerceCostError;
            }
            set
            {
                _ecommerceCostError = value;
                if (value != "")
                {
                    EcommerceCostToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceCostToolTip");
                }
                else
                {
                    EcommerceCostToolTip = ReturnToolTip("EcommerceCostToolTip");
                }
                this.EcommerceCostBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceCostError");
            }
        }
        private string _ecommerceCostError = string.Empty;
        public string EcommerceCostToolTip
        {
            get
            {
                return _ecommerceCostToolTip;
            }
            set
            {
                this._ecommerceCostToolTip = value;
                OnPropertyChanged("EcommerceCostToolTip");
            }
        }
        private string _ecommerceCostToolTip = string.Empty;

        /// <summary>
        ///    EcommerceExternalIdType
        /// </summary>
        public string EcommerceExternalIdType
        {
            get
            {
                if (this.TemplateObject.EcommerceExternalIdType != string.Empty)
                {
                    return this.TemplateObject.EcommerceExternalIdType;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceExternalIdType != value)
                {
                    this.TemplateObject.EcommerceExternalIdType = value;
                    FlagError("EcommerceExternalIdType");
                    OnPropertyChanged("EcommerceExternalIdType");
                }
            }
        }
        public string EcommerceExternalIdTypeBoxColor
        {
            get
            {
                return _ecommerceExternalIdTypeBoxColor;
            }
            set
            {
                _ecommerceExternalIdTypeBoxColor = value;
                OnPropertyChanged("EcommerceExternalIdTypeBoxColor");
            }
        }
        private string _ecommerceExternalIdTypeBoxColor = "White";
        public string EcommerceExternalIdTypeError
        {
            get
            {
                return _ecommerceExternalIdTypeError;
            }
            set
            {
                _ecommerceExternalIdTypeError = value;
                if (value != "")
                {
                    EcommerceExternalIdTypeToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceExternalIdTypeToolTip");
                }
                else
                {
                    EcommerceExternalIdTypeToolTip = ReturnToolTip("EcommerceExternalIdTypeToolTip");
                }
                this.EcommerceExternalIdTypeBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceExternalIdTypeError");
            }
        }
        private string _ecommerceExternalIdTypeError = string.Empty;
        public string EcommerceExternalIdTypeToolTip
        {
            get
            {
                return _ecommerceExternalIdTypeToolTip;
            }
            set
            {
                this._ecommerceExternalIdTypeToolTip = value;
                OnPropertyChanged("EcommerceExternalIdTypeToolTip");
            }
        }
        private string _ecommerceExternalIdTypeToolTip = string.Empty;
        
        /// <summary>
        ///    EcommerceItemHeight
        /// </summary>
        public string EcommerceItemHeight
        {
            get
            {
                if (this.TemplateObject.EcommerceItemHeight != string.Empty)
                {
                    return this.TemplateObject.EcommerceItemHeight;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceItemHeight != value)
                {
                    this.TemplateObject.EcommerceItemHeight = value;
                    FlagError("EcommerceItemHeight");
                    OnPropertyChanged("EcommerceItemHeight");
                }
            }
        }
        public string EcommerceItemHeightBoxColor
        {
            get
            {
                return _EcommerceItemHeightBoxColor;
            }
            set
            {
                _EcommerceItemHeightBoxColor = value;
                OnPropertyChanged("EcommerceItemHeightBoxColor");
            }
        }
        private string _EcommerceItemHeightBoxColor = "White";
        public string EcommerceItemHeightError
        {
            get
            {
                return _ecommerceItemHeightError;
            }
            set
            {
                _ecommerceItemHeightError = value;
                if (value != "")
                {
                    EcommerceItemHeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceItemHeightToolTip");
                }
                else
                {
                    EcommerceItemHeightToolTip = ReturnToolTip("EcommerceItemHeightToolTip");
                }
                this.EcommerceItemHeightBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceItemHeightError");
            }
        }
        private string _ecommerceItemHeightError = string.Empty;
        public string EcommerceItemHeightToolTip
        {
            get
            {
                return _ecommerceItemHeightToolTip;
            }
            set
            {
                this._ecommerceItemHeightToolTip = value;
                OnPropertyChanged("EcommerceItemHeightToolTip");
            }
        }
        private string _ecommerceItemHeightToolTip = string.Empty;

        /// <summary>
        ///    EcommerceItemLength
        /// </summary>
        public string EcommerceItemLength
        {
            get
            {
                if (this.TemplateObject.EcommerceItemLength != string.Empty)
                {
                    return this.TemplateObject.EcommerceItemLength;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceItemLength != value)
                {
                    this.TemplateObject.EcommerceItemLength = value;
                    FlagError("EcommerceItemLength");
                    OnPropertyChanged("EcommerceItemLength");
                }
            }
        }
        public string EcommerceItemLengthBoxColor
        {
            get
            {
                return _ecommerceItemLengthBoxColor;
            }
            set
            {
                _ecommerceItemLengthBoxColor = value;
                OnPropertyChanged("EcommerceItemLengthBoxColor");
            }
        }
        private string _ecommerceItemLengthBoxColor = "White";
        public string EcommerceItemLengthError
        {
            get
            {
                return _ecommerceItemLengthError;
            }
            set
            {
                _ecommerceItemLengthError = value;
                if (value != "")
                {
                    EcommerceItemLengthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceItemLengthToolTip");
                }
                else
                {
                    EcommerceItemLengthToolTip = ReturnToolTip("EcommerceItemLengthToolTip");
                }
                this.EcommerceItemLengthBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceItemLengthError");
            }
        }
        private string _ecommerceItemLengthError = string.Empty;
        public string EcommerceItemLengthToolTip
        {
            get
            {
                return _ecommerceItemLengthToolTip;
            }
            set
            {
                this._ecommerceItemLengthToolTip = value;
                OnPropertyChanged("EcommerceItemLengthToolTip");
            }
        }
        private string _ecommerceItemLengthToolTip = string.Empty;
        
        /// <summary>
        ///    EcommerceItemWeight
        /// </summary>
        public string EcommerceItemWeight
        {
            get
            {
                if (this.TemplateObject.EcommerceItemWeight != string.Empty)
                {
                    return this.TemplateObject.EcommerceItemWeight;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceItemWeight != value)
                {
                    this.TemplateObject.EcommerceItemWeight = value;
                    FlagError("EcommerceItemWeight");
                    OnPropertyChanged("EcommerceItemWeight");
                }
            }
        }
        public string EcommerceItemWeightBoxColor
        {
            get
            {
                return _ecommerceItemWeightBoxColor;
            }
            set
            {
                _ecommerceItemWeightBoxColor = value;
                OnPropertyChanged("EcommerceItemWeightBoxColor");
            }
        }
        private string _ecommerceItemWeightBoxColor = "White";
        public string EcommerceItemWeightError
        {
            get
            {
                return _ecommerceItemWeightError;
            }
            set
            {
                _ecommerceItemWeightError = value;
                if (value != "")
                {
                    EcommerceItemWeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceItemWeightToolTip");
                }
                else
                {
                    EcommerceItemWeightToolTip = ReturnToolTip("EcommerceItemWeightToolTip");
                }
                this.EcommerceItemWeightBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceItemWeightError");
            }
        }
        private string _ecommerceItemWeightError = string.Empty;
        public string EcommerceItemWeightToolTip
        {
            get
            {
                return _ecommerceItemWeightToolTip;
            }
            set
            {
                this._ecommerceItemWeightToolTip = value;
                OnPropertyChanged("EcommerceItemWeightToolTip");
            }
        }
        private string _ecommerceItemWeightToolTip = string.Empty;

        /// <summary>
        ///    EcommerceItemWidth
        /// </summary>
        public string EcommerceItemWidth
        {
            get
            {
                if (this.TemplateObject.EcommerceItemWidth != string.Empty)
                {
                    return this.TemplateObject.EcommerceItemWidth;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceItemWidth != value)
                {
                    this.TemplateObject.EcommerceItemWidth = value;
                    FlagError("EcommerceItemWidth");
                    OnPropertyChanged("EcommerceItemWidth");
                }
            }
        }
        public string EcommerceItemWidthBoxColor
        {
            get
            {
                return _ecommerceItemWidthBoxColor;
            }
            set
            {
                _ecommerceItemWidthBoxColor = value;
                OnPropertyChanged("EcommerceItemWidthBoxColor");
            }
        }
        private string _ecommerceItemWidthBoxColor = "White";
        public string EcommerceItemWidthError
        {
            get
            {
                return _ecommerceItemWidthError;
            }
            set
            {
                _ecommerceItemWidthError = value;
                if (value != "")
                {
                    EcommerceItemWidthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceItemWidthToolTip");
                }
                else
                {
                    EcommerceItemWidthToolTip = ReturnToolTip("EcommerceItemWidthToolTip");
                }
                this.EcommerceItemWidthBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceItemWidthError");
            }
        }
        private string _ecommerceItemWidthError = string.Empty;
        public string EcommerceItemWidthToolTip
        {
            get
            {
                return _ecommerceItemWidthToolTip;
            }
            set
            {
                this._ecommerceItemWidthToolTip = value;
                OnPropertyChanged("EcommerceItemWidthToolTip");
            }
        }
        private string _ecommerceItemWidthToolTip = string.Empty;

        /// <summary>
        ///    EcommerceModelName
        /// </summary>
        public string EcommerceModelName
        {
            get
            {
                if (this.TemplateObject.EcommerceModelName != string.Empty)
                {
                    return this.TemplateObject.EcommerceModelName;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceModelName != value)
                {
                    this.TemplateObject.EcommerceModelName = value;
                    FlagError("EcommerceModelName");
                    OnPropertyChanged("EcommerceModelName");
                }
            }
        }
        public string EcommerceModelNameBoxColor
        {
            get
            {
                return _ecommerceModelNameBoxColor;
            }
            set
            {
                _ecommerceModelNameBoxColor = value;
                OnPropertyChanged("EcommerceModelNameBoxColor");
            }
        }
        private string _ecommerceModelNameBoxColor = "White";
        public string EcommerceModelNameError
        {
            get
            {
                return _ecommerceModelNameError;
            }
            set
            {
                _ecommerceModelNameError = value;
                if (value != "")
                {
                    EcommerceModelNameToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceModelNameToolTip");
                }
                else
                {
                    EcommerceModelNameToolTip = ReturnToolTip("EcommerceModelNameToolTip");
                }
                this.EcommerceModelNameBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceModelNameError");
            }
        }
        private string _ecommerceModelNameError = string.Empty;
        public string EcommerceModelNameToolTip
        {
            get
            {
                return _ecommerceModelNameToolTip;
            }
            set
            {
                this._ecommerceModelNameToolTip = value;
                OnPropertyChanged("EcommerceModelNameToolTip");
            }
        }
        private string _ecommerceModelNameToolTip = string.Empty;

        /// <summary>
        ///    EcommercePackageHeight
        /// </summary>
        public string EcommercePackageHeight
        {
            get
            {
                if (this.TemplateObject.EcommercePackageHeight != string.Empty)
                {
                    return this.TemplateObject.EcommercePackageHeight;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommercePackageHeight != value)
                {
                    this.TemplateObject.EcommercePackageHeight = value;
                    FlagError("EcommercePackageHeight");
                    OnPropertyChanged("EcommercePackageHeight");
                }
            }
        }
        public string EcommercePackageHeightBoxColor
        {
            get
            {
                return _ecommercePackageHeightBoxColor;
            }
            set
            {
                _ecommercePackageHeightBoxColor = value;
                OnPropertyChanged("EcommercePackageHeightBoxColor");
            }
        }
        private string _ecommercePackageHeightBoxColor = "White";
        public string EcommercePackageHeightError
        {
            get
            {
                return _ecommercePackageHeightError;
            }
            set
            {
                _ecommercePackageHeightError = value;
                if (value != "")
                {
                    EcommercePackageHeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommercePackageHeightToolTip");
                }
                else
                {
                    EcommercePackageHeightToolTip = ReturnToolTip("EcommercePackageHeightToolTip");
                }
                this.EcommercePackageHeightBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommercePackageHeightError");
            }
        }
        private string _ecommercePackageHeightError = string.Empty;
        public string EcommercePackageHeightToolTip
        {
            get
            {
                return _ecommercePackageHeightToolTip;
            }
            set
            {
                this._ecommercePackageHeightToolTip = value;
                OnPropertyChanged("EcommercePackageHeightToolTip");
            }
        }
        private string _ecommercePackageHeightToolTip = string.Empty;

        /// <summary>
        ///    EcommercePackageLength
        /// </summary>
        public string EcommercePackageLength
        {
            get
            {
                if (this.TemplateObject.EcommercePackageLength != string.Empty)
                {
                    return this.TemplateObject.EcommercePackageLength;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommercePackageLength != value)
                {
                    this.TemplateObject.EcommercePackageLength = value;
                    FlagError("EcommercePackageLength");
                    OnPropertyChanged("EcommercePackageLength");
                }
            }
        }
        public string EcommercePackageLengthBoxColor
        {
            get
            {
                return _ecommercePackageLengthBoxColor;
            }
            set
            {
                _ecommercePackageLengthBoxColor = value;
                OnPropertyChanged("EcommercePackageLengthBoxColor");
            }
        }
        private string _ecommercePackageLengthBoxColor = "White";
        public string EcommercePackageLengthError
        {
            get
            {
                return _ecommercePackageLengthError;
            }
            set
            {
                _ecommercePackageLengthError = value;
                if (value != "")
                {
                    EcommercePackageLengthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommercePackageLengthToolTip");
                }
                else
                {
                    EcommercePackageLengthToolTip = ReturnToolTip("EcommercePackageLengthToolTip");
                }
                this.EcommercePackageLengthBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommercePackageLengthError");
            }
        }
        private string _ecommercePackageLengthError = string.Empty;
        public string EcommercePackageLengthToolTip
        {
            get
            {
                return _ecommercePackageLengthToolTip;
            }
            set
            {
                this._ecommercePackageLengthToolTip = value;
                OnPropertyChanged("EcommercePackageLengthToolTip");
            }
        }
        private string _ecommercePackageLengthToolTip = string.Empty;

        /// <summary>
        ///    EcommercePackageWeight
        /// </summary>
        public string EcommercePackageWeight
        {
            get
            {
                if (this.TemplateObject.EcommercePackageWeight != string.Empty)
                {
                    return this.TemplateObject.EcommercePackageWeight;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommercePackageWeight != value)
                {
                    this.TemplateObject.EcommercePackageWeight = value;
                    FlagError("EcommercePackageWeight");
                    OnPropertyChanged("EcommercePackageWeight");
                }
            }
        }
        public string EcommercePackageWeightBoxColor
        {
            get
            {
                return _ecommercePackageWeightBoxColor;
            }
            set
            {
                _ecommercePackageWeightBoxColor = value;
                OnPropertyChanged("EcommercePackageWeightBoxColor");
            }
        }
        private string _ecommercePackageWeightBoxColor = "White";
        public string EcommercePackageWeightError
        {
            get
            {
                return _ecommercePackageWeightError;
            }
            set
            {
                _ecommercePackageWeightError = value;
                if (value != "")
                {
                    EcommercePackageWeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommercePackageWeightToolTip");
                }
                else
                {
                    EcommercePackageWeightToolTip = ReturnToolTip("EcommercePackageWeightToolTip");
                }
                this.EcommercePackageWeightBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommercePackageWeightError");
            }
        }
        private string _ecommercePackageWeightError = string.Empty;
        public string EcommercePackageWeightToolTip
        {
            get
            {
                return _ecommercePackageWeightToolTip;
            }
            set
            {
                this._ecommercePackageWeightToolTip = value;
                OnPropertyChanged("EcommercePackageWeightToolTip");
            }
        }
        private string _ecommercePackageWeightToolTip = string.Empty;

        /// <summary>
        ///    EcommercePackageWidth
        /// </summary>
        public string EcommercePackageWidth
        {
            get
            {
                if (this.TemplateObject.EcommercePackageWidth != string.Empty)
                {
                    return this.TemplateObject.EcommercePackageWidth;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommercePackageWidth != value)
                {
                    this.TemplateObject.EcommercePackageWidth = value;
                    FlagError("EcommercePackageWidth");
                    OnPropertyChanged("EcommercePackageWidth");
                }
            }
        }
        public string EcommercePackageWidthBoxColor
        {
            get
            {
                return _ecommercePackageWidthBoxColor;
            }
            set
            {
                _ecommercePackageWidthBoxColor = value;
                OnPropertyChanged("EcommercePackageWidthBoxColor");
            }
        }
        private string _ecommercePackageWidthBoxColor = "White";
        public string EcommercePackageWidthError
        {
            get
            {
                return _ecommercePackageWidthError;
            }
            set
            {
                _ecommercePackageWidthError = value;
                if (value != "")
                {
                    EcommercePackageWidthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommercePackageWidthToolTip");
                }
                else
                {
                    EcommercePackageWidthToolTip = ReturnToolTip("EcommercePackageWidthToolTip");
                }
                this.EcommercePackageWidthBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommercePackageWidthError");
            }
        }
        private string _ecommercePackageWidthError = string.Empty;
        public string EcommercePackageWidthToolTip
        {
            get
            {
                return _ecommercePackageWidthToolTip;
            }
            set
            {
                this._ecommercePackageWidthToolTip = value;
                OnPropertyChanged("EcommercePackageWidthToolTip");
            }
        }
        private string _ecommercePackageWidthToolTip = string.Empty;

        /// <summary>
        ///    EcommercePageQty
        /// </summary>
        public string EcommercePageQty
        {
            get
            {
                if (this.TemplateObject.EcommercePageQty != string.Empty)
                {
                    return this.TemplateObject.EcommercePageQty;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommercePageQty != value)
                {
                    this.TemplateObject.EcommercePageQty = value;
                    FlagError("EcommercePageQty");
                    OnPropertyChanged("EcommercePageQty");
                }
            }
        }
        public string EcommercePageQtyBoxColor
        {
            get
            {
                return _ecommercePageQtyBoxColor;
            }
            set
            {
                _ecommercePageQtyBoxColor = value;
                OnPropertyChanged("EcommercePageQtyBoxColor");
            }
        }
        private string _ecommercePageQtyBoxColor = "White";
        public string EcommercePageQtyError
        {
            get
            {
                return _ecommercePageQtyError;
            }
            set
            {
                _ecommercePageQtyError = value;
                if (value != "")
                {
                    EcommercePageQtyToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommercePageQtyToolTip");
                }
                else
                {
                    EcommercePageQtyToolTip = ReturnToolTip("EcommercePageQtyToolTip");
                }
                this.EcommercePageQtyBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommercePageQtyError");
            }
        }
        private string _ecommercePageQtyError = string.Empty;
        public string EcommercePageQtyToolTip
        {
            get
            {
                return _ecommercePageQtyToolTip;
            }
            set
            {
                this._ecommercePageQtyToolTip = value;
                OnPropertyChanged("EcommercePageQtyToolTip");
            }
        }
        private string _ecommercePageQtyToolTip = string.Empty;

        /// <summary>
        ///    EcommerceProductCategory
        /// </summary>
        public string EcommerceProductCategory
        {
            get
            {
                if (this.TemplateObject.EcommerceProductCategory != string.Empty)
                {
                    return this.TemplateObject.EcommerceProductCategory;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceProductCategory != value)
                {
                    this.TemplateObject.EcommerceProductCategory = value;
                    FlagError("EcommerceProductCategory");
                    OnPropertyChanged("EcommerceProductCategory");
                }
            }
        }
        public string EcommerceProductCategoryBoxColor
        {
            get
            {
                return _ecommerceProductCategoryBoxColor;
            }
            set
            {
                _ecommerceProductCategoryBoxColor = value;
                OnPropertyChanged("EcommerceProductCategoryBoxColor");
            }
        }
        private string _ecommerceProductCategoryBoxColor = "White";
        public string EcommerceProductCategoryError
        {
            get
            {
                return _ecommerceProductCategoryError;
            }
            set
            {
                _ecommerceProductCategoryError = value;
                if (value != "")
                {
                    EcommerceProductCategoryToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceProductCategoryToolTip");
                }
                else
                {
                    EcommerceProductCategoryToolTip = ReturnToolTip("EcommerceProductCategoryToolTip");
                }
                this.EcommerceProductCategoryBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceProductCategoryError");
            }
        }
        private string _ecommerceProductCategoryError = string.Empty;
        public string EcommerceProductCategoryToolTip
        {
            get
            {
                return _ecommerceProductCategoryToolTip;
            }
            set
            {
                this._ecommerceProductCategoryToolTip = value;
                OnPropertyChanged("EcommerceProductCategoryToolTip");
            }
        }
        private string _ecommerceProductCategoryToolTip = string.Empty;

        /// <summary>
        ///    EcommerceProductDescription
        /// </summary>
        public string EcommerceProductDescription
        {
            get
            {
                if (this.TemplateObject.EcommerceProductDescription != string.Empty)
                {
                    return this.TemplateObject.EcommerceProductDescription;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceProductDescription != value)
                {
                    this.TemplateObject.EcommerceProductDescription = value;
                    FlagError("EcommerceProductDescription");
                    OnPropertyChanged("EcommerceProductDescription");
                }
            }
        }
        public string EcommerceProductDescriptionBoxColor
        {
            get
            {
                return _ecommerceProductDescriptionBoxColor;
            }
            set
            {
                _ecommerceProductDescriptionBoxColor = value;
                OnPropertyChanged("EcommerceProductDescriptionBoxColor");
            }
        }
        private string _ecommerceProductDescriptionBoxColor = "White";
        public string EcommerceProductDescriptionError
        {
            get
            {
                return _ecommerceProductDescriptionError;
            }
            set
            {
                _ecommerceProductDescriptionError = value;
                if (value != "")
                {
                    EcommerceProductDescriptionToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceProductDescriptionToolTip");
                }
                else
                {
                    EcommerceProductDescriptionToolTip = ReturnToolTip("EcommerceProductDescriptionToolTip");
                }
                this.EcommerceProductDescriptionBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceProductDescriptionError");
            }
        }
        private string _ecommerceProductDescriptionError = string.Empty;
        public string EcommerceProductDescriptionToolTip
        {
            get
            {
                return _ecommerceProductDescriptionToolTip;
            }
            set
            {
                this._ecommerceProductDescriptionToolTip = value;
                OnPropertyChanged("EcommerceProductDescriptionToolTip");
            }
        }
        private string _ecommerceProductDescriptionToolTip = string.Empty;

        /// <summary>
        ///    EcommerceProductSubcategory
        /// </summary>
        public string EcommerceProductSubcategory
        {
            get
            {
                if (this.TemplateObject.EcommerceProductSubcategory != string.Empty)
                {
                    return this.TemplateObject.EcommerceProductSubcategory;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceProductSubcategory != value)
                {
                    this.TemplateObject.EcommerceProductSubcategory = value;
                    FlagError("EcommerceProductSubcategory");
                    OnPropertyChanged("EcommerceProductSubcategory");
                }
            }
        }
        public string EcommerceProductSubcategoryBoxColor
        {
            get
            {
                return _ecommerceProductSubcategoryBoxColor;
            }
            set
            {
                _ecommerceProductSubcategoryBoxColor = value;
                OnPropertyChanged("EcommerceProductSubcategoryBoxColor");
            }
        }
        private string _ecommerceProductSubcategoryBoxColor = "White";
        public string EcommerceProductSubcategoryError
        {
            get
            {
                return _ecommerceProductSubcategoryError;
            }
            set
            {
                _ecommerceProductSubcategoryError = value;
                if (value != "")
                {
                    EcommerceProductSubcategoryToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceProductSubcategoryToolTip");
                }
                else
                {
                    EcommerceProductSubcategoryToolTip = ReturnToolTip("EcommerceProductSubcategoryToolTip");
                }
                this.EcommerceProductSubcategoryBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceProductSubcategoryError");
            }
        }
        private string _ecommerceProductSubcategoryError = string.Empty;
        public string EcommerceProductSubcategoryToolTip
        {
            get
            {
                return _ecommerceProductSubcategoryToolTip;
            }
            set
            {
                this._ecommerceProductSubcategoryToolTip = value;
                OnPropertyChanged("EcommerceProductSubcategoryToolTip");
            }
        }
        private string _ecommerceProductSubcategoryToolTip = string.Empty;

        /// <summary>
        ///    EcommerceManufacturerName
        /// </summary>
        public string EcommerceManufacturerName
        {
            get
            {
                if (this.TemplateObject.EcommerceManufacturerName != string.Empty)
                {
                    return this.TemplateObject.EcommerceManufacturerName;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceManufacturerName != value)
                {
                    this.TemplateObject.EcommerceManufacturerName = value;
                    FlagError("EcommerceManufacturerName");
                    OnPropertyChanged("EcommerceManufacturerName");
                }
            }
        }
        public string EcommerceManufacturerNameBoxColor
        {
            get
            {
                return _ecommerceManufacturerNameBoxColor;
            }
            set
            {
                _ecommerceManufacturerNameBoxColor = value;
                OnPropertyChanged("EcommerceManufacturerNameBoxColor");
            }
        }
        private string _ecommerceManufacturerNameBoxColor = "White";
        public string EcommerceManufacturerNameError
        {
            get
            {
                return _ecommerceManufacturerNameError;
            }
            set
            {
                _ecommerceManufacturerNameError = value;
                if (value != "")
                {
                    EcommerceManufacturerNameToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceManufacturerNameToolTip");
                }
                else
                {
                    EcommerceManufacturerNameToolTip = ReturnToolTip("EcommerceManufacturerNameToolTip");
                }
                this.EcommerceManufacturerNameBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceManufacturerNameError");
            }
        }
        private string _ecommerceManufacturerNameError = string.Empty;
        public string EcommerceManufacturerNameToolTip
        {
            get
            {
                return _ecommerceManufacturerNameToolTip;
            }
            set
            {
                this._ecommerceManufacturerNameToolTip = value;
                OnPropertyChanged("EcommerceManufacturerNameToolTip");
            }
        }
        private string _ecommerceManufacturerNameToolTip = string.Empty;

        /// <summary>
        ///    EcommerceMsrp
        /// </summary>
        public string EcommerceMsrp
        {
            get
            {
                if (this.TemplateObject.EcommerceMsrp != string.Empty)
                {
                    return this.TemplateObject.EcommerceMsrp;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceMsrp != value)
                {
                    this.TemplateObject.EcommerceMsrp = value;
                    FlagError("EcommerceMsrp");
                    OnPropertyChanged("EcommerceMsrp");
                }
            }
        }
        public string EcommerceMsrpBoxColor
        {
            get
            {
                return _ecommerceMsrpBoxColor;
            }
            set
            {
                _ecommerceMsrpBoxColor = value;
                OnPropertyChanged("EcommerceMsrpBoxColor");
            }
        }
        private string _ecommerceMsrpBoxColor = "White";
        public string EcommerceMsrpError
        {
            get
            {
                return _ecommerceMsrpError;
            }
            set
            {
                _ecommerceMsrpError = value;
                if (value != "")
                {
                    EcommerceMsrpToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceMsrpToolTip");
                }
                else
                {
                    EcommerceMsrpToolTip = ReturnToolTip("EcommerceMsrpToolTip");
                }
                this.EcommerceMsrpBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceMsrpError");
            }
        }
        private string _ecommerceMsrpError = string.Empty;
        public string EcommerceMsrpToolTip
        {
            get
            {
                return _ecommerceMsrpToolTip;
            }
            set
            {
                this._ecommerceMsrpToolTip = value;
                OnPropertyChanged("EcommerceMsrpToolTip");
            }
        }
        private string _ecommerceMsrpToolTip = string.Empty;

        /// <summary>
        ///    EcommerceSize
        /// </summary>
        public string EcommerceSize
        {
            get
            {
                if (this.TemplateObject.EcommerceSize != string.Empty)
                {
                    return this.TemplateObject.EcommerceSize;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.EcommerceSize != value)
                {
                    this.TemplateObject.EcommerceSize = value;
                    FlagError("EcommerceSize");
                    OnPropertyChanged("EcommerceSize");
                }
            }
        }
        public string EcommerceSizeBoxColor
        {
            get
            {
                return _ecommercesizeBoxColor;
            }
            set
            {
                _ecommercesizeBoxColor = value;
                OnPropertyChanged("EcommerceSizeBoxColor");
            }
        }
        private string _ecommercesizeBoxColor = "White";
        public string EcommerceSizeError
        {
            get
            {
                return _ecommercesizeError;
            }
            set
            {
                _ecommercesizeError = value;
                if (value != "")
                {
                    EcommerceSizeToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceSizeToolTip");
                }
                else
                {
                    EcommerceSizeToolTip = ReturnToolTip("EcommerceSizeToolTip");
                }
                this.EcommerceSizeBoxColor = (value == "") ? "White" : "Tomato";
                this.EcommerceTabColor = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceSizeError");
            }
        }
        private string _ecommercesizeError = string.Empty;
        public string EcommerceSizeToolTip
        {
            get
            {
                return _ecommercesizeToolTip;
            }
            set
            {
                this._ecommercesizeToolTip = value;
                OnPropertyChanged("EcommerceSizeToolTip");
            }
        }
        private string _ecommercesizeToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the Warranty value
        /// </summary>
        public string Warranty
        {
            get
            {
                if (this.TemplateObject.Warranty != string.Empty)
                {
                    return this.TemplateObject.Warranty.ToString();
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.Warranty != value)
                {
                    this.TemplateObject.Warranty = value;
                    FlagError("Warranty");
                    OnPropertyChanged("Warranty");
                }
            }
        }
        public string WarrantyBoxColor
        {
            get
            {
                return _warrantyBoxColor;
            }
            set
            {
                _warrantyBoxColor = value;
                OnPropertyChanged("WarrantyBoxColor");
            }
        }
        private string _warrantyBoxColor = "White";
        public string WarrantyError
        {
            get
            {
                return _warrantyError;
            }
            set
            {
                _warrantyError = value;
                if (value != "")
                {
                    WarrantyToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Warranty");
                }
                else
                {
                    WarrantyToolTip = ReturnToolTip("Warranty");
                }
                this.WarrantyBoxColor = (value == "") ? "White" : "Tomato";
                this.ItemInfoTabColor = CheckItemInfoTabColor();
                OnPropertyChanged("WarrantyError");
            }
        }
        private string _warrantyError = string.Empty;
        public string WarrantyToolTip
        {
            get
            {
                return _warrantyToolTip;
            }
            set
            {
                this._warrantyToolTip = value;
                OnPropertyChanged("WarrantyToolTip");
            }
        }
        private string _warrantyToolTip = string.Empty;

        #endregion // Ecommerce Properties

        #region ComboBox Properties

        /// <summary>
        ///     Gets the AccountingGroupList combo box values
        /// </summary>
        public List<string> AccountingGroupList
        {
            get
            {
                return GlobalData.AccountingGroups;
            }
        }

        /// <summary>
        ///     Gets the costProfileGroupList
        /// </summary>
        public List<string> CostProfileGroupList
        {
            get
            {
                return GlobalData.CostProfileGroups;
            }
        }

        /// <summary>
        ///     Gets the ecommerce external id type combo box values
        /// </summary>
        public List<string> EcommerceExternalIdTypeGroups
        {
            get
            {
                return GlobalData.ExternalIdTypes;
            }
        }

        /// <summary>
        ///     Gets the ItemCategories combobox list
        /// </summary>
        public List<string> ItemCategories
        {
            get
            {
                return GlobalData.ProductCategories;
            }
        }

        /// <summary>
        ///     Gets the ItemGroups combobox list
        /// </summary>
        public List<string> ItemGroups
        {
            get
            {
                return GlobalData.ItemGroups;
            }
        }

        /// <summary>
        ///     Gets the MetaDescriptions
        /// </summary>
        public List<string> MetaDescriptions
        {
            get
            {
                return GlobalData.MetaDescriptions;
            }
        }

        /// <summary>
        ///     Gets the PricingGroups combobox list
        /// </summary>
        public List<string> PricingGroups
        {
            get
            {
                return GlobalData.PricingGroups;
            }
        }

        /// <summary>
        ///     Gets or sets the product formats combo box values
        /// </summary>
        public List<string> ProductFormats
        {
            get
            {
                return _productFormats;
            }
            set
            {
                _productFormats = value;
                OnPropertyChanged("ProductFormats");
            }
        }
        private List<string> _productFormats = new List<string>();

        /// <summary>
        ///     Gets the product groups combo box values
        /// </summary>
        public List<string> ProductGroups
        {
            get
            {
                return GlobalData.ProductGoups;
            }
        }

        /// <summary>
        ///     Gets or sets the product lines combo box values
        /// </summary>
        public List<string> ProductLines
        {
            get
            {
                return _productLines;
            }
            set
            {
                _productLines = value;
                OnPropertyChanged("ProductLines");
            }
        }
        private List<string> _productLines = new List<string>();
        
        /// <summary>
        ///     Gets or sets the property combo box values
        /// </summary>
        public List<string> PropertyList
        {
            get
            {
                return _propertyList;
            }
            set
            {
                _propertyList = value;
                OnPropertyChanged("PropertyList");
            }
        }
        private List<string> _propertyList = new List<string>();

        /// <summary>
        ///     Gets the PsStatuses
        /// </summary>
        public List<string> PsStatuses
        {
            get
            {
                return GlobalData.PsStatuses;
            }
        }

        /// <summary>
        ///     Gets the TariffCodes
        /// </summary>
        public List<string> TariffCodes
        {
            get
            {
                return GlobalData.TariffCodes;
            }
        }
        
        /// <summary>
        ///     Gets or sets the template combo box values
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
        private List<string> _templateList = new List<string>();

        /// <summary>
        ///     Gets the WebCategoryList
        /// </summary>
        public List<string> WebCategoryList
        {
            get
            {
                return GlobalData.ReturnWebCategoryListValues();
            }
        }

        #endregion // ComboBox Properties

        #region Template Properties

        /// <summary>
        ///     Set the position of the column list dropdown
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
                if (this.Template != "")
                {
                    PopulateFields(this.Template);
                }
                if(this.TemplateStatus == "Update")
                {
                    this.TemplateId = value;
                }
                OnPropertyChanged("Template");
            }
        }
        private string _template = string.Empty;

        /// <summary>
        ///     Gets or sets the Template Id
        /// </summary>
        public string TemplateId
        {
            get
            {
                if (this.TemplateObject.TemplateId != string.Empty)
                {
                    return this.TemplateObject.TemplateId;
                }
                else return "";
            }
            set
            {
                if (this.TemplateObject.TemplateId != value)
                {
                    this.TemplateObject.TemplateId = value;
                    FlagError("TemplateId");
                    OnPropertyChanged("TemplateId");
                }
            }
        }

        public string TemplateIdBoxColor
        {
            get
            {
                return _templateIdBoxColor;
            }
            set
            {
                _templateIdBoxColor = value;
                OnPropertyChanged("TemplateIdBoxColor");
            }
        }
        private string _templateIdBoxColor = "White";

        public string TemplateIdError
        {
            get
            {
                return _templateIdError;
            }
            set
            {
                _templateIdError = value;
                if (value != "")
                {
                    TemplateIdToolTip = "Error: " + value + "\n\n" + ReturnToolTip("TemplateId");
                }
                else
                {
                    TemplateIdToolTip = ReturnToolTip("TemplateId");
                }
                this.TemplateIdBoxColor = (value == "") ? "White" : "Tomato";
                OnPropertyChanged("TemplateIdError");
            }
        }
        private string _templateIdError = string.Empty;

        public string TemplateIdToolTip
        {
            get
            {
                return _templateIdToolTip;
            }
            set
            {
                this._templateIdToolTip = value;
                OnPropertyChanged("TemplateIdToolTip");
            }
        }
        private string _templateIdToolTip = string.Empty;

        #endregion // Template Properties

        #endregion // Properties

        #region Methods

        /// <summary>
        ///     Checks the ecommerce fields for error color. If error exists for one of the fields
        ///     returns "Tomato" (error color). Otherwise returns "White"
        /// </summary>
        /// <returns>White or Tomato</returns>
        private string CheckEcommerceTabColor()
        {
            if (EcommerceBullet1BoxColor != "White") { return "Tomato"; }
            if (EcommerceBullet2BoxColor != "White") { return "Tomato"; }
            if (EcommerceBullet3BoxColor != "White") { return "Tomato"; }
            if (EcommerceBullet4BoxColor != "White") { return "Tomato"; }
            if (EcommerceBullet5BoxColor != "White") { return "Tomato"; }
            if (EcommerceComponentsBoxColor != "White") { return "Tomato"; }
            if (EcommerceCostBoxColor != "White") { return "Tomato"; }
            if (EcommerceExternalIdTypeBoxColor != "White") { return "Tomato"; }
            if (EcommerceItemHeightBoxColor != "White") { return "Tomato"; }
            if (EcommerceItemLengthBoxColor != "White") { return "Tomato"; }
            if (EcommerceItemWeightBoxColor != "White") { return "Tomato"; }
            if (EcommerceItemWidthBoxColor != "White") { return "Tomato"; }
            if (EcommerceModelNameBoxColor != "White") { return "Tomato"; }
            if (EcommercePackageHeightBoxColor != "White") { return "Tomato"; }
            if (EcommercePackageLengthBoxColor != "White") { return "Tomato"; }
            if (EcommercePackageWeightBoxColor != "White") { return "Tomato"; }
            if (EcommercePackageWidthBoxColor != "White") { return "Tomato"; }
            if (EcommercePageQtyBoxColor != "White") { return "Tomato"; }
            if (EcommerceProductCategoryBoxColor != "White") { return "Tomato"; }
            if (EcommerceProductDescriptionBoxColor != "White") { return "Tomato"; }
            if (EcommerceProductSubcategoryBoxColor != "White") { return "Tomato"; }
            if (EcommerceManufacturerNameBoxColor != "White") { return "Tomato"; }
            if (EcommerceMsrpBoxColor != "White") { return "Tomato"; }
            if (EcommerceSizeBoxColor != "White") { return "Tomato"; }
            if (WarrantyBoxColor != "White") { return "Tomato"; }
            return "White";
        }

        /// <summary>
        ///     Checks if all fields are empty. Returns true if all fields are empty.
        /// </summary>
        /// <returns></returns>
        private bool CheckEmptyFields()
        {
            if (!string.IsNullOrEmpty(this.AccountingGroup)) { return false; }
            if (!string.IsNullOrEmpty(this.CasepackHeight)) { return false; }
            if (!string.IsNullOrEmpty(this.CasepackLength)) { return false; }
            if (!string.IsNullOrEmpty(this.CasepackQty)) { return false; }
            if (!string.IsNullOrEmpty(this.CasepackWidth)) { return false; }
            if (!string.IsNullOrEmpty(this.CasepackWeight)) { return false; }
            if (!string.IsNullOrEmpty(this.CostProfileGroup)) { return false; }
            if (!string.IsNullOrEmpty(this.CountryOfOrigin)) { return false; }
            if (!string.IsNullOrEmpty(this.DefaultActualCostUsd)) { return false; }
            if (!string.IsNullOrEmpty(this.DefaultActualCostCad)) { return false; }
            if (!string.IsNullOrEmpty(this.Duty)) { return false; }
            if (!string.IsNullOrEmpty(this.Gpc)) { return false; }
            if (!string.IsNullOrEmpty(this.Height)) { return false; }
            if (!string.IsNullOrEmpty(this.InnerpackHeight)) { return false; }
            if (!string.IsNullOrEmpty(this.InnerpackLength)) { return false; }
            if (!string.IsNullOrEmpty(this.InnerpackQuantity)) { return false; }
            if (!string.IsNullOrEmpty(this.InnerpackWeight)) { return false; }
            if (!string.IsNullOrEmpty(this.InnerpackWidth)) { return false; }
            if (!string.IsNullOrEmpty(this.ItemCategory)) { return false; }
            if (!string.IsNullOrEmpty(this.ItemFamily)) { return false; }
            if (!string.IsNullOrEmpty(this.ItemGroup)) { return false; }
            if (!string.IsNullOrEmpty(this.Length)) { return false; }
            if (!string.IsNullOrEmpty(this.ListPriceCad)) { return false; }
            if (!string.IsNullOrEmpty(this.ListPriceMxn)) { return false; }
            if (!string.IsNullOrEmpty(this.ListPriceUsd)) { return false; }
            if (!string.IsNullOrEmpty(this.MfgSource)) { return false; }
            if (!string.IsNullOrEmpty(this.Msrp)) { return false; }
            if (!string.IsNullOrEmpty(this.MsrpCad)) { return false; }
            if (!string.IsNullOrEmpty(this.MsrpMxn)) { return false; }
            if (!string.IsNullOrEmpty(this.PricingGroup)) { return false; }
            if (!string.IsNullOrEmpty(this.ProductFormat)) { return false; }
            if (!string.IsNullOrEmpty(this.ProductGroup)) { return false; }
            if (!string.IsNullOrEmpty(this.ProductLine)) { return false; }
            if (!string.IsNullOrEmpty(this.ProductQty)) { return false; }
            if (!string.IsNullOrEmpty(this.SatCode)) { return false; }
            if (!string.IsNullOrEmpty(this.TariffCode)) { return false; }
            if (!string.IsNullOrEmpty(this.Udex)) { return false; }
            if (!string.IsNullOrEmpty(this.WebsitePrice)) { return false; }
            if (!string.IsNullOrEmpty(this.Weight)) { return false; }
            if (!string.IsNullOrEmpty(this.Width)) { return false; }
            if (!string.IsNullOrEmpty(this.Copyright)) { return false; }
            if (!string.IsNullOrEmpty(this.Category)) { return false; }
            if (!string.IsNullOrEmpty(this.Category2)) { return false; }
            if (!string.IsNullOrEmpty(this.Category3)) { return false; }
            if (!string.IsNullOrEmpty(this.MetaDescription)) { return false; }
            if (!string.IsNullOrEmpty(this.Size)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceBullet1)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceBullet2)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceBullet3)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceBullet4)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceBullet5)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceComponents)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceCost)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceExternalIdType)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceItemHeight)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceItemLength)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceItemWeight)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceItemWidth)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceModelName)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommercePackageHeight)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommercePackageLength)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommercePackageWeight)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommercePackageWidth)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommercePageQty)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceProductCategory)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceProductDescription)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceProductSubcategory)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceManufacturerName)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceMsrp)) { return false; }
            if (!string.IsNullOrEmpty(this.EcommerceSize)) { return false; }
            if (!string.IsNullOrEmpty(this.Warranty)) { return false; }
            return true;
        }

        /// <summary>
        ///     Checks the item info fields for error color. If error exists for one of the fields
        ///     returns "Tomato" (error color). Otherwise returns "White"
        /// </summary>
        /// <returns>White or Tomato</returns>
        private string CheckItemInfoTabColor()
        {
            if (AccountingGroupBoxColor != "White") { return "Tomato"; }
            if (CasepackHeightBoxColor != "White") { return "Tomato"; }
            if (CasepackLengthBoxColor != "White") { return "Tomato"; }
            if (CasepackQtyBoxColor != "White") { return "Tomato"; }
            if (CasepackWidthBoxColor != "White") { return "Tomato"; }
            if (CasepackWeightBoxColor != "White") { return "Tomato"; }
            if (CostProfileGroupBoxColor != "White") { return "Tomato"; }
            if (CountryOfOriginBoxColor != "White") { return "Tomato"; }
            if (DefaultActualCostUsdBoxColor != "White") { return "Tomato"; }
            if (DefaultActualCostCadBoxColor != "White") { return "Tomato"; }
            if (DutyBoxColor != "White") { return "Tomato"; }
            if (GpcBoxColor != "White") { return "Tomato"; }
            if (HeightBoxColor != "White") { return "Tomato"; }
            if (InnerpackHeightBoxColor != "White") { return "Tomato"; }
            if (InnerpackLengthBoxColor != "White") { return "Tomato"; }
            if (InnerpackQuantityBoxColor != "White") { return "Tomato"; }
            if (InnerpackWeightBoxColor != "White") { return "Tomato"; }
            if (InnerpackWidthBoxColor != "White") { return "Tomato"; }
            if (ItemCategoryBoxColor != "White") { return "Tomato"; }
            if (ItemFamilyBoxColor != "White") { return "Tomato"; }
            if (ItemGroupBoxColor != "White") { return "Tomato"; }
            if (LengthBoxColor != "White") { return "Tomato"; }
            if (ListPriceCadBoxColor != "White") { return "Tomato"; }
            if (ListPriceMxnBoxColor != "White") { return "Tomato"; }
            if (ListPriceUsdBoxColor != "White") { return "Tomato"; }
            if (MfgSourceBoxColor != "White") { return "Tomato"; }
            if (MsrpBoxColor != "White") { return "Tomato"; }
            if (MsrpCadBoxColor != "White") { return "Tomato"; }
            if (MsrpMxnBoxColor != "White") { return "Tomato"; }
            if (PricingGroupBoxColor != "White") { return "Tomato"; }
            if (ProductFormatBoxColor != "White") { return "Tomato"; }
            if (ProductGroupBoxColor != "White") { return "Tomato"; }
            if (ProductLineBoxColor != "White") { return "Tomato"; }
            if (ProductQtyBoxColor != "White") { return "Tomato"; }
            if (PsStatusBoxColor != "White") { return "Tomato"; }
            if (SatCodeBoxColor != "White") { return "Tomato"; }
            if (TariffCodeBoxColor != "White") { return "Tomato"; }
            if (UdexBoxColor != "White") { return "Tomato"; }
            if (WeightBoxColor != "White") { return "Tomato"; }
            if (WidthBoxColor != "White") { return "Tomato"; }
            return "White";
        }

        /// <summary>
        ///     Checks the Web Field box colors and assigns the appropirate color to the web tab
        /// </summary>
        /// <returns></returns>
        private string CheckWebInfoTabColor()
        {
            if (CopyrightBoxColor != "White") { return "Tomato"; }
            if (CategoryBoxColor != "White") { return "Tomato"; }
            if (Category2BoxColor != "White") { return "Tomato"; }
            if (Category3BoxColor != "White") { return "Tomato"; }
            if (MetaDescriptionBoxColor != "White") { return "Tomato"; }
            if (SizeBoxColor != "White") { return "Tomato"; }
            if (WebsitePriceBoxColor != "White") { return "Tomato"; }
            return "White";
        }

        /// <summary>
        ///     Runs validation for given field and assigns error message to error fields
        /// </summary>
        /// <param name="field"></param>
        private void FlagError(string field)
        {
            switch (field)
            {
                case "AccountingGroup":
                    this.AccountingGroupError = ItemService.ValidateAccountingGroup(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "CasepackHeight":
                    this.CasepackHeightError = ItemService.ValidateCasepack(TemplateObject, "Height")?.ReturnErrorMessage() ?? "";
                    break;

                case "CasepackLength":
                    this.CasepackLengthError = ItemService.ValidateCasepack(TemplateObject, "Length")?.ReturnErrorMessage() ?? "";
                    break;

                case "CasepackWeight":
                    this.CasepackWeightError = ItemService.ValidateCasepack(TemplateObject, "Weight")?.ReturnErrorMessage() ?? "";
                    break;

                case "CasepackWidth":
                    this.CasepackWidthError = ItemService.ValidateCasepack(TemplateObject, "Width")?.ReturnErrorMessage() ?? "";
                    break;

                case "CasepackQty":
                    this.CasepackQtyError = ItemService.ValidateCasepackQty(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "Category":
                    this.CategoryError = ItemService.ValidateCategory(TemplateObject, "1")?.ReturnErrorMessage()??"";
                    break;

                case "Category2":
                    this.Category2Error = ItemService.ValidateCategory(TemplateObject, "2")?.ReturnErrorMessage()??"";
                    break;

                case "Category3":
                    this.Category3Error = ItemService.ValidateCategory(TemplateObject, "3")?.ReturnErrorMessage()??"";
                    break;

                case "Copyright":
                    this.CopyrightError = ItemService.ValidateCopyright(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "CountryOfOrigin":
                    this.CountryOfOriginError = ItemService.ValidateCountryOfOrigin(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "CostProfileGroup":
                    this.CostProfileGroupError = ItemService.ValidateCostProfileGroup(TemplateObject)?.ReturnErrorMessage()??"";
                    this.MfgSourceError = ItemService.ValidateMfgSource(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "DefaultActualCostCad":
                    this.DefaultActualCostCadError = ItemService.ValidateDefaultActualCost(TemplateObject, "CAD")?.ReturnErrorMessage()??"";
                    break;

                case "DefaultActualCostUsd":
                    this.DefaultActualCostUsdError = ItemService.ValidateDefaultActualCost(TemplateObject, "USD")?.ReturnErrorMessage()??"";
                    break;

                case "Duty":
                    this.DutyError = ItemService.ValidateDuty(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceBullet1":
                    this.EcommerceBullet1Error = ItemService.ValidateEcommerceBullet(TemplateObject, "1")?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceBullet2":
                    this.EcommerceBullet2Error = ItemService.ValidateEcommerceBullet(TemplateObject, "2")?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceBullet3":
                    this.EcommerceBullet3Error = ItemService.ValidateEcommerceBullet(TemplateObject, "3")?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceBullet4":
                    this.EcommerceBullet4Error = ItemService.ValidateEcommerceBullet(TemplateObject, "4")?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceBullet5":
                    this.EcommerceBullet5Error = ItemService.ValidateEcommerceBullet(TemplateObject, "5")?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceComponents":
                    this.EcommerceComponentsError = ItemService.ValidateEcommerceComponents(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceCost":
                    this.EcommerceCostError = ItemService.ValidateEcommerceCost(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceExternalIdType":
                    this.EcommerceExternalIdTypeError = ItemService.ValidateEcommerceExternalIdType(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceItemHeight":
                    this.EcommerceItemWeightError = ItemService.ValidateEcommerceItemDimension(TemplateObject, "Height")?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceItemLength":
                    this.EcommerceItemWeightError = ItemService.ValidateEcommerceItemDimension(TemplateObject, "Length")?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceItemWeight":
                    this.EcommerceItemWeightError = ItemService.ValidateEcommerceItemDimension(TemplateObject, "Weight")?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceItemWidth":
                    this.EcommerceItemWeightError = ItemService.ValidateEcommerceItemDimension(TemplateObject, "Width")?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceModelName":
                    this.EcommerceModelNameError = ItemService.ValidateEcommerceModelName(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "EcommercePackageHeight":
                    this.EcommercePackageHeightError = ItemService.ValidateEcommercePackageDimension(TemplateObject, "Height")?.ReturnErrorMessage()??"";
                    break;

                case "EcommercePackageLength":
                    this.EcommercePackageLengthError = ItemService.ValidateEcommercePackageDimension(TemplateObject, "Length")?.ReturnErrorMessage()??"";
                    break;

                case "EcommercePackageWeight":
                    this.EcommercePackageWeightError = ItemService.ValidateEcommercePackageDimension(TemplateObject, "Weight")?.ReturnErrorMessage()??"";
                    break;

                case "EcommercePackageWidth":
                    this.EcommercePackageWidthError = ItemService.ValidateEcommercePackageDimension(TemplateObject, "Width")?.ReturnErrorMessage()??"";
                    break;

                case "EcommercePageQty":
                    this.EcommercePageQtyError = ItemService.ValidateEcommercePageQty(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceProductCategory":
                    this.EcommerceProductCategoryError = ItemService.ValidateEcommerceProductCategory(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceProductDescription":
                    this.EcommerceProductDescriptionError = ItemService.ValidateEcommerceProductDescription(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceProductSubcategory":
                    this.EcommerceProductSubcategoryError = ItemService.ValidateEcommerceProductSubcategory(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceManufacturerName":
                    this.EcommerceManufacturerNameError = ItemService.ValidateEcommerceManufacturerName(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "EcommerceMsrp":
                    this.EcommerceMsrpError = ItemService.ValidateEcommerceMsrp(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "Ecommere_Size":
                    this.EcommerceSizeError = ItemService.ValidateEcommerceSize(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "Gpc":
                    this.GpcError = ItemService.ValidateGpc(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "Height":
                    this.EcommerceItemHeightError = ItemService.ValidateEcommerceItemDimension(TemplateObject, "Height")?.ReturnErrorMessage()??"";
                    break;

                case "InnerpackHeight":
                    this.InnerpackHeightError = ItemService.ValidateInnerpack(TemplateObject, "Height")?.ReturnErrorMessage()??"";
                    break;

                case "InnerpackLength":
                    this.InnerpackLengthError = ItemService.ValidateInnerpack(TemplateObject, "Length")?.ReturnErrorMessage() ?? "";
                    break;

                case "InnerpackWeight":
                    this.InnerpackWeightError = ItemService.ValidateInnerpack(TemplateObject, "Weight")?.ReturnErrorMessage() ?? "";
                    break;

                case "InnerpackWidth":
                    this.InnerpackWidthError = ItemService.ValidateInnerpack(TemplateObject, "Width")?.ReturnErrorMessage() ?? "";
                    break;

                case "InnerpackQuantity":
                    this.InnerpackQuantityError = ItemService.ValidateInnerpackQuantity(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "ItemCategory":
                    this.ItemCategoryError = ItemService.ValidateItemCategory(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "ItemFamily":
                    this.ItemFamilyError = ItemService.ValidateItemFamily(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "ItemGroup":
                    this.ItemGroupError = ItemService.ValidateItemGroup(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "Length":
                    this.EcommerceItemLengthError = ItemService.ValidateEcommerceItemDimension(TemplateObject, "Length")?.ReturnErrorMessage()??"";
                    break;

                case "ListPriceCad":
                    this.ListPriceCadError = ItemService.ValidateListPrice(TemplateObject, "CAD")?.ReturnErrorMessage()??"";
                    this.MsrpCadError = ItemService.ValidateMsrp(TemplateObject, "CAD")?.ReturnErrorMessage()??"";
                    this.PricingGroupError = ItemService.ValidatePricingGroup(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "ListPriceMxn":
                    this.MsrpMxnError = ItemService.ValidateMsrp(TemplateObject, "MXN")?.ReturnErrorMessage()??"";
                    this.ListPriceMxnError = ItemService.ValidateListPrice(TemplateObject, "MXN")?.ReturnErrorMessage()??"";
                    break;

                case "ListPriceUsd":
                    this.ListPriceUsdError = ItemService.ValidateListPrice(TemplateObject, "USD")?.ReturnErrorMessage()??"";
                    break;

                case "MetaDescription":
                    this.MetaDescriptionError = ItemService.ValidateMetaDescription(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "MfgSource":
                    this.MfgSourceError = ItemService.ValidateMfgSource(TemplateObject)?.ReturnErrorMessage()??"";
                    this.CostProfileGroupError = ItemService.ValidateCostProfileGroup(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "Msrp":
                    this.MsrpError = ItemService.ValidateMsrp(TemplateObject, "USD")?.ReturnErrorMessage()??"";
                    break;

                case "MsrpCad":
                    this.MsrpCadError = ItemService.ValidateMsrp(TemplateObject, "CAD")?.ReturnErrorMessage()??"";
                    break;

                case "MsrpMxn":
                    this.MsrpMxnError = ItemService.ValidateMsrp(TemplateObject, "MXN")?.ReturnErrorMessage()??"";
                    break;

                case "PricingGroup":
                    this.PricingGroupError = ItemService.ValidatePricingGroup(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "PrintOnDemand":
                    this.PrintOnDemandError = ItemService.ValidatePrintOnDemand(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "ProductFormat":
                    this.ProductFormatError = ItemService.ValidateProductFormat(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "ProductGroup":
                    RefreshProductLines();
                    RefreshProductFormats("");
                    this.ProductGroupError = ItemService.ValidateProductGroup(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "ProductLine":
                    RefreshProductFormats(this.ProductLine);
                    this.ProductLineError = ItemService.ValidateProductLine(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "ProductQty":
                    this.ProductQtyError = ItemService.ValidateProductQty(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "PsStatus":
                    this.PsStatusError = ItemService.ValidatePsStatus(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "SatCode":
                    this.SatCodeError = ItemService.ValidateSatCode(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "Size":
                    this.SizeError = ItemService.ValidateSize(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "TariffCode":
                    this.TariffCodeError = ItemService.ValidateTariffCode(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "TemplateId":
                    this.TemplateIdError = ItemService.ValidateTemplateId(TemplateObject)?.ReturnErrorMessage() ?? "";
                    break;

                case "Udex":
                    this.UdexError = ItemService.ValidateUdex(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "Warranty":
                    this.WarrantyError = ItemService.ValidateWarranty(TemplateObject)?.ReturnErrorMessage() ?? "";
                    break;

                case "WebsitePrice":
                    this.WebsitePriceError = ItemService.ValidateWebsitePrice(TemplateObject)?.ReturnErrorMessage()??"";
                    break;

                case "Weight":
                    this.WeightError = ItemService.ValidateItemDimension(TemplateObject, "Weight")?.ReturnErrorMessage()??"";
                    break;

                case "Width":
                    this.WidthError = ItemService.ValidateItemDimension(TemplateObject, "Width")?.ReturnErrorMessage()??"";
                    break;

                default:
                    throw new ArgumentNullException("TemplateViewModel Flag error unknown type " + field);
            }
        }

        /// <summary>
        ///     Populates the viewmodel fields with an existing item
        /// </summary>
        /// <param name="template"></param>
        public void ImportTemplate(ItemObject template)
        {
            this.Template = template.TemplateId;
            this.AccountingGroup = template.AccountingGroup;
            this.CasepackHeight = template.CasepackHeight;
            this.CasepackLength = template.CasepackLength;
            this.CasepackQty = template.CasepackQty;
            this.CasepackWidth = template.CasepackWidth;
            this.CasepackWeight = template.CasepackWeight;
            this.Category = template.Category;
            this.Category2 = template.Category2;
            this.Category3 = template.Category3;
            this.Copyright = template.Copyright;
            this.CostProfileGroup = template.CostProfileGroup;
            this.CountryOfOrigin = template.CountryOfOrigin;
            this.DefaultActualCostUsd = template.DefaultActualCostUsd;
            this.DefaultActualCostCad = template.DefaultActualCostCad;
            this.Duty = template.Duty;
            this.EcommerceBullet1 = template.EcommerceBullet1;
            this.EcommerceBullet2 = template.EcommerceBullet2;
            this.EcommerceBullet3 = template.EcommerceBullet3;
            this.EcommerceBullet4 = template.EcommerceBullet4;
            this.EcommerceBullet5 = template.EcommerceBullet5;
            this.EcommerceComponents = template.EcommerceComponents;
            this.EcommerceCost = template.EcommerceCost;
            this.EcommerceExternalIdType = template.EcommerceExternalIdType;
            this.EcommerceItemHeight = template.EcommerceItemHeight;
            this.EcommerceItemLength = template.EcommerceItemLength;
            this.EcommerceItemWeight = template.EcommerceItemWeight;
            this.EcommerceItemWidth = template.EcommerceItemWidth;
            this.EcommerceModelName = template.EcommerceModelName;
            this.EcommercePackageHeight = template.EcommercePackageHeight;
            this.EcommercePackageLength = template.EcommercePackageLength;
            this.EcommercePackageWeight = template.EcommercePackageWeight;
            this.EcommercePackageWidth = template.EcommercePackageWidth;
            this.EcommercePageQty = template.EcommercePageQty;
            this.EcommerceProductCategory = template.EcommerceProductCategory;
            this.EcommerceProductDescription = template.EcommerceProductDescription;
            this.EcommerceProductSubcategory = template.EcommerceProductSubcategory;
            this.EcommerceManufacturerName = template.EcommerceManufacturerName;
            this.EcommerceMsrp = template.EcommerceMsrp;
            this.EcommerceSize = template.EcommerceSize;
            this.Gpc = template.Gpc;
            this.Height = template.Height;
            this.InnerpackHeight = template.InnerpackHeight;
            this.InnerpackLength = template.InnerpackLength;
            this.InnerpackQuantity = template.InnerpackQuantity;
            this.InnerpackWeight = template.InnerpackWeight;
            this.InnerpackWidth = template.InnerpackWidth;
            this.ItemCategory = template.ItemCategory;
            this.ItemFamily = template.ItemFamily;
            this.ItemGroup = template.ItemGroup;
            this.Length = template.Length;
            this.ListPriceCad = template.ListPriceCad;
            this.ListPriceMxn = template.ListPriceMxn;
            this.ListPriceUsd = template.ListPriceUsd;
            this.MetaDescription = template.MetaDescription;
            this.MfgSource = template.MfgSource;
            this.Msrp = template.Msrp;
            this.MsrpCad = template.MsrpCad;
            this.MsrpMxn = template.MsrpMxn;
            this.PrintOnDemand = template.PrintOnDemand;
            this.PricingGroup = template.PricingGroup;
            this.ProdType = template.ProdType;
            this.ProductGroup = template.ProductGroup;
            this.ProductLine = template.ProductLine;
            this.ProductFormat = template.ProductFormat;
            this.ProductQty = template.ProductQty;
            this.PsStatus = template.PsStatus;
            this.SatCode = template.SatCode;
            this.Size = template.Size;
            this.TariffCode = template.TariffCode;
            this.Udex = template.Udex;
            this.Warranty = template.Warranty;
            this.WebsitePrice = template.WebsitePrice;
            this.Weight = template.Weight;
            this.Width = template.Width;
        }

        /// <summary>
        ///     Load info from excell sheet and fill in any missing fields with db data
        /// </summary>
        public void LoadTemplateExcelInfo()
        {
            WorkbookReader workbookReader = new WorkbookReader();
            string idAbsentees = String.Empty;
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Excel files|*.xls; *.xlsx"
            };
            if (dialog.ShowDialog() != true)
            {
                return;
            }
            try
            {
                ItemObject template = this.ItemService.LoadTemplate(dialog.FileName,"Add")[0];

                this.TemplateId = template.TemplateId;
                this.AccountingGroup = template.AccountingGroup;
                this.CasepackHeight = template.CasepackHeight;
                this.CasepackLength = template.CasepackLength;
                this.CasepackQty = template.CasepackQty;
                this.CasepackWidth = template.CasepackWidth;
                this.CasepackWeight = template.CasepackWeight;
                this.Category = template.Category;
                this.Category2 = template.Category2;
                this.Category3 = template.Category3;
                this.Copyright = template.Copyright;
                this.CountryOfOrigin = template.CountryOfOrigin;
                this.CostProfileGroup = template.CostProfileGroup;
                this.DefaultActualCostUsd = template.DefaultActualCostUsd;
                this.DefaultActualCostCad = template.DefaultActualCostCad;
                this.EcommerceBullet1 = template.EcommerceBullet1;
                this.EcommerceBullet2 = template.EcommerceBullet2;
                this.EcommerceBullet3 = template.EcommerceBullet3;
                this.EcommerceBullet4 = template.EcommerceBullet4;
                this.EcommerceBullet5 = template.EcommerceBullet5;
                this.EcommerceComponents = template.EcommerceComponents;
                this.EcommerceCost = template.EcommerceCost;
                this.EcommerceExternalIdType = template.EcommerceExternalIdType;
                this.EcommerceItemHeight = template.EcommerceItemHeight;
                this.EcommerceItemLength = template.EcommerceItemLength;
                this.EcommerceItemWeight = template.EcommerceItemWeight;
                this.EcommerceItemWidth = template.EcommerceItemWidth;
                this.EcommerceModelName = template.EcommerceModelName;
                this.EcommercePackageHeight = template.EcommercePackageHeight;
                this.EcommercePackageLength = template.EcommercePackageLength;
                this.EcommercePackageWeight = template.EcommercePackageWeight;
                this.EcommercePackageWidth = template.EcommercePackageWidth;
                this.EcommercePageQty = template.EcommercePageQty;
                this.EcommerceProductCategory = template.EcommerceProductCategory;
                this.EcommerceProductDescription = template.EcommerceProductDescription;
                this.EcommerceProductSubcategory = template.EcommerceProductSubcategory;
                this.EcommerceManufacturerName = template.EcommerceManufacturerName;
                this.EcommerceMsrp = template.EcommerceMsrp;
                this.EcommerceSize = template.EcommerceSize;
                this.Gpc = template.Gpc;
                this.Height = template.Height;
                this.InnerpackHeight = template.InnerpackHeight;
                this.InnerpackLength = template.InnerpackLength;
                this.InnerpackQuantity = template.InnerpackQuantity;
                this.InnerpackWidth = template.InnerpackWidth;
                this.InnerpackWeight = template.InnerpackWeight;
                this.ItemCategory = template.ItemCategory;
                this.ItemFamily = template.ItemFamily;
                this.ItemGroup = template.ItemGroup;
                this.Length = template.Length;
                this.ListPriceCad = template.ListPriceCad;
                this.ListPriceUsd = template.ListPriceUsd;
                this.ListPriceMxn = template.ListPriceMxn;
                this.MetaDescription = template.MetaDescription;
                this.MfgSource = template.MfgSource;
                this.Msrp = template.Msrp;
                this.MsrpCad = template.MsrpCad;
                this.MsrpMxn = template.MsrpMxn;
                this.PrintOnDemand = template.PrintOnDemand;
                this.PricingGroup = template.PricingGroup;
                this.ProdType = template.ProdType;
                this.ProductGroup = template.ProductGroup;
                this.ProductLine = template.ProductLine;
                this.ProductFormat = template.ProductFormat;
                this.ProductQty = template.ProductQty;
                this.PsStatus = template.PsStatus;
                this.SatCode = template.SatCode;
                this.Size = template.Size;
                this.TariffCode = template.TariffCode;
                this.Udex = template.Udex;
                this.WebsitePrice = template.WebsitePrice;
                this.Warranty = template.Warranty;
                this.Weight = template.Weight;
                this.Width = template.Width;
            }
            catch(Exception ex)
            {
                ErrorLog.LogError("Odin was unable to load the templates from the database.", ex.ToString());
            }
        }

        /// <summary>
        ///     Populates the template view model fields with the given template name
        /// </summary>
        /// <param name="templateName"></param>
        private void PopulateFields(string templateName)
        {
            bool loadTemplate = true;
            if (!CheckEmptyFields())
            {
                string dialogMessage = "Changing template will clear any unsaved template fields. Do you wish to continue?";
                DialogResult dialogResult = MessageBox.Show(dialogMessage, "Warning", System.Windows.Forms.MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    loadTemplate = false;
                    this.Template = "";
                }
            }
            if (loadTemplate)
            {
                ItemObject template = ItemService.RetrieveTemplate(templateName);
                this.AccountingGroup = template.AccountingGroup;
                this.CasepackHeight = template.CasepackHeight;
                this.CasepackLength = template.CasepackLength;
                this.CasepackQty = template.CasepackQty;
                this.CasepackWidth = template.CasepackWidth;
                this.CasepackWeight = template.CasepackWeight;
                this.Category = template.Category;
                this.Category2 = template.Category2;
                this.Category3 = template.Category3;
                this.Copyright = template.Copyright;
                this.CostProfileGroup = template.CostProfileGroup;
                this.CountryOfOrigin = template.CountryOfOrigin;
                this.DefaultActualCostUsd = template.DefaultActualCostUsd;
                this.DefaultActualCostCad = template.DefaultActualCostCad;
                this.Duty = template.Duty;
                this.EcommerceBullet1 = template.EcommerceBullet1;
                this.EcommerceBullet2 = template.EcommerceBullet2;
                this.EcommerceBullet3 = template.EcommerceBullet3;
                this.EcommerceBullet4 = template.EcommerceBullet4;
                this.EcommerceBullet5 = template.EcommerceBullet5;
                this.EcommerceComponents = template.EcommerceComponents;
                this.EcommerceCost = template.EcommerceCost;
                this.EcommerceExternalIdType = template.EcommerceExternalIdType;
                this.EcommerceItemHeight = template.EcommerceItemHeight;
                this.EcommerceItemLength = template.EcommerceItemLength;
                this.EcommerceItemWeight = template.EcommerceItemWeight;
                this.EcommerceItemWidth = template.EcommerceItemWidth;
                this.EcommerceModelName = template.EcommerceModelName;
                this.EcommercePackageHeight = template.EcommercePackageHeight;
                this.EcommercePackageLength = template.EcommercePackageLength;
                this.EcommercePackageWeight = template.EcommercePackageWeight;
                this.EcommercePackageWidth = template.EcommercePackageWidth;
                this.EcommercePageQty = template.EcommercePageQty;
                this.EcommerceProductCategory = template.EcommerceProductCategory;
                this.EcommerceProductDescription = template.EcommerceProductDescription;
                this.EcommerceProductSubcategory = template.EcommerceProductSubcategory;
                this.EcommerceManufacturerName = template.EcommerceManufacturerName;
                this.EcommerceMsrp = template.EcommerceMsrp;
                this.EcommerceSize = template.EcommerceSize;
                this.Gpc = template.Gpc;
                this.Height = template.Height;
                this.InnerpackHeight = template.InnerpackHeight;
                this.InnerpackLength = template.InnerpackLength;
                this.InnerpackQuantity = template.InnerpackQuantity;
                this.InnerpackWeight = template.InnerpackWeight;
                this.InnerpackWidth = template.InnerpackWidth;
                this.ItemCategory = template.ItemCategory;
                this.ItemFamily = template.ItemFamily;
                this.ItemGroup = template.ItemGroup;
                this.Length = template.Length;
                this.ListPriceCad = template.ListPriceCad;
                this.ListPriceMxn = template.ListPriceMxn;
                this.ListPriceUsd = template.ListPriceUsd;
                this.MetaDescription = template.MetaDescription;
                this.MfgSource = template.MfgSource;
                this.Msrp = template.Msrp;
                this.MsrpCad = template.MsrpCad;
                this.MsrpMxn = template.MsrpMxn;
                this.PrintOnDemand = template.PrintOnDemand;
                this.PricingGroup = template.PricingGroup;
                this.ProductGroup = template.ProductGroup;
                this.ProductLine = template.ProductLine;
                this.ProductFormat = template.ProductFormat;
                this.ProductQty = template.ProductQty;
                this.PsStatus = template.PsStatus;
                this.SatCode = template.SatCode;
                this.Size = template.Size;
                this.TariffCode = template.TariffCode;
                this.Udex = template.Udex;
                this.WebsitePrice = template.WebsitePrice;
                this.Warranty = template.Warranty;
                this.Weight = template.Weight;
                this.Width = template.Width;
            }
        }

        /// <summary>
        ///     Retrieves and refreshes the Product Lines that align with the current Product Group.
        /// </summary>
        private void RefreshProductLines()
        {
            this.ProductLines = ItemService.RetrieveProductLines(this.ProductGroup);
        }

        /// <summary>
        ///     Retrieves and refreshes the Product Formats that align with the given Product Line.
        /// </summary>
        private void RefreshProductFormats(string productLine)
        {
            this.ProductFormats = ItemService.RetrieveProductFormats(productLine);
        }

        /// <summary>
        ///     Removes the given template from the database
        /// </summary>
        /// <returns></returns>
        public bool RemoveTemplate()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this template.", "Remove Template", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    ItemService.UpdateTemplate(this.TemplateObject, "Remove");
                    MessageBox.Show("Template Removed.");
                    return true;
                }
                catch (Exception ex)
                {
                    ErrorLog.LogError("Odin was unable to remove the give template from the database.", ex.ToString());
                }
            }
            return false;
        }

        /// <summary>
        ///     Return tool tip value for the given field
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ReturnToolTip(string value)
        {
            if (this.ToolTips.ContainsKey(value))
            {
                return this.ToolTips[value];
            }
            return "";
        }

        /// <summary>
        ///     Submits current item and any changes made back to the main window view model.
        /// </summary>
        /// <returns></returns>
        public bool SaveTemplate()
        {
            List<string> Errors = new List<string>();
            try
            {
                foreach(ItemError error in ItemService.ValidateAllTemplate(this.TemplateObject, this.TemplateStatus))
                {
                    Errors.Add(error.ReturnErrorMessage());
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError("Odin was unable to validate the template fields.", ex.ToString());
            }
            if (Errors.Count != 0)
            {
                AlertView window = new AlertView()
                {
                    DataContext = new AlertViewModel(Errors, "Alert", "")
                };
                window.ShowDialog();
                return false;
            }
            try
            {
                if (this.TemplateStatus == "Add")
                {
                    ItemService.InsertTemplate(this.TemplateObject);
                }
                else if (this.TemplateStatus == "Update")
                {
                    ItemService.UpdateTemplate(this.TemplateObject, this.TemplateStatus);
                }
                MessageBox.Show("Template " + this.TemplateStatus + " success.");
            }
            catch (Exception ex)
            {
                ErrorLog.LogError("Odin was unable to save the template.", ex.ToString());
            }
            this.TemplateList = GlobalData.TemplateNames;
            this.TemplateStatus = "Update";
            return true;
        }

        /// <summary>
        ///     Sets the default tool tip values for the template viewmodel fields
        /// </summary>
        public void SetToolTips()
        {
            this.AccountingGroupToolTip = ReturnToolTip("AccountingGroup");
            this.CasepackHeightToolTip = ReturnToolTip("CasepackDimension");
            this.CasepackLengthToolTip = ReturnToolTip("CasepackDimension");
            this.CasepackQtyToolTip = ReturnToolTip("CasepackQty");
            this.CasepackWidthToolTip = ReturnToolTip("CasepackDimension");
            this.CasepackWeightToolTip = ReturnToolTip("CasepackDimension");
            this.CostProfileGroupToolTip = ReturnToolTip("CostProfileGroup");
            this.CountryOfOriginToolTip = ReturnToolTip("CountryOfOrigin");
            this.DefaultActualCostUsdToolTip = ReturnToolTip("DefaultActualCost");
            this.DefaultActualCostCadToolTip = ReturnToolTip("DefaultActualCost");
            this.DutyToolTip = ReturnToolTip("Duty");
            this.GpcToolTip = ReturnToolTip("Gpc");
            this.HeightToolTip = ReturnToolTip("Height");
            this.InnerpackHeightToolTip = ReturnToolTip("InnerpackDimension");
            this.InnerpackLengthToolTip = ReturnToolTip("InnerpackDimension");
            this.InnerpackQuantityToolTip = ReturnToolTip("InnerpackQuantity");
            this.InnerpackWeightToolTip = ReturnToolTip("InnerpackDimension");
            this.InnerpackWidthToolTip = ReturnToolTip("InnerpackDimension");
            this.ItemCategoryToolTip = ReturnToolTip("ItemCategory");
            this.ItemFamilyToolTip = ReturnToolTip("ItemFamily");
            this.ItemGroupToolTip = ReturnToolTip("ItemGroup");
            this.LengthToolTip = ReturnToolTip("Length");
            this.ListPriceCadToolTip = ReturnToolTip("ListPrice");
            this.ListPriceMxnToolTip = ReturnToolTip("ListPrice");
            this.ListPriceUsdToolTip = ReturnToolTip("ListPrice");
            this.MfgSourceToolTip = ReturnToolTip("MfgSource");
            this.MsrpToolTip = ReturnToolTip("Msrp");
            this.MsrpCadToolTip = ReturnToolTip("Msrp");
            this.MsrpMxnToolTip = ReturnToolTip("Msrp");
            this.PricingGroupToolTip = ReturnToolTip("PricingGroup");
            this.PrintOnDemandToolTip = ReturnToolTip("PrintOnDemand");
            this.ProductFormatToolTip = ReturnToolTip("ProductFormat");
            this.ProductGroupToolTip = ReturnToolTip("ProductGroup");
            this.ProductLineToolTip = ReturnToolTip("ProductLine");
            this.ProductQtyToolTip = ReturnToolTip("ProductQty");
            this.PsStatusToolTip = ReturnToolTip("PsStatus");
            this.SatCodeToolTip = ReturnToolTip("SatCode");
            this.TariffCodeToolTip = ReturnToolTip("TariffCode");
            this.UdexToolTip = ReturnToolTip("Udex");
            this.WebsitePriceToolTip = ReturnToolTip("WebsitePrice");
            this.WeightToolTip = ReturnToolTip("Weight");
            this.WidthToolTip = ReturnToolTip("Width");
            this.CopyrightToolTip = ReturnToolTip("Copyright");
            this.CategoryToolTip = ReturnToolTip("Category");
            this.Category2ToolTip = ReturnToolTip("Category");
            this.Category3ToolTip = ReturnToolTip("Category");
            this.MetaDescriptionToolTip = ReturnToolTip("MetaDescription");
            this.SizeToolTip = ReturnToolTip("Size");
            this.EcommerceBullet1ToolTip = ReturnToolTip("EcommerceBulletToolTip");
            this.EcommerceBullet2ToolTip = ReturnToolTip("EcommerceBulletToolTip");
            this.EcommerceBullet3ToolTip = ReturnToolTip("EcommerceBulletToolTip");
            this.EcommerceBullet4ToolTip = ReturnToolTip("EcommerceBulletToolTip");
            this.EcommerceBullet5ToolTip = ReturnToolTip("EcommerceBulletToolTip");
            this.EcommerceComponentsToolTip = ReturnToolTip("EcommerceComponentsToolTip");
            this.EcommerceCostToolTip = ReturnToolTip("EcommerceCostToolTip");
            this.EcommerceExternalIdTypeToolTip = ReturnToolTip("EcommerceExternalIdTypeToolTip");
            this.EcommerceItemHeightToolTip = ReturnToolTip("EcommerceItemHeightToolTip");
            this.EcommerceItemLengthToolTip = ReturnToolTip("EcommerceItemLengthToolTip");
            this.EcommerceItemWeightToolTip = ReturnToolTip("EcommerceItemWeightToolTip");
            this.EcommerceItemWidthToolTip = ReturnToolTip("EcommerceItemWidthToolTip");
            this.EcommerceModelNameToolTip = ReturnToolTip("EcommerceModelNameToolTip");
            this.EcommercePackageHeightToolTip = ReturnToolTip("EcommercePackageHeightToolTip");
            this.EcommercePackageLengthToolTip = ReturnToolTip("EcommercePackageLengthToolTip");
            this.EcommercePackageWeightToolTip = ReturnToolTip("EcommercePackageWeightToolTip");
            this.EcommercePackageWidthToolTip = ReturnToolTip("EcommercePackageWidthToolTip");
            this.EcommercePageQtyToolTip = ReturnToolTip("EcommercePageQtyToolTip");
            this.EcommerceProductCategoryToolTip = ReturnToolTip("EcommerceProductCategoryToolTip");
            this.EcommerceProductDescriptionToolTip = ReturnToolTip("EcommerceProductDescriptionToolTip");
            this.EcommerceProductSubcategoryToolTip = ReturnToolTip("EcommerceProductSubcategoryToolTip");
            this.EcommerceManufacturerNameToolTip = ReturnToolTip("EcommerceManufacturerNameToolTip");
            this.EcommerceMsrpToolTip = ReturnToolTip("EcommerceMsrpToolTip");
            this.EcommerceSizeToolTip = ReturnToolTip("EcommerceSizeToolTip");
            this.TemplateIdToolTip = ReturnToolTip("TemplateId");
        }

        /// <summary>
        ///     Sets the visibility for the update functionality. Also sets the title and template list column
        /// </summary>
        /// <param name="status"></param>
        public void SetVisibility(string status)
        {
            if(status == "Add")
            {
                this.UpdateVisibility = "Visible";
                this.WindowTitle = "Add New Template";
                this.TemplateListColumn = "5";
            }
            else
            {
                this.UpdateVisibility = "Hidden";
                this.WindowTitle = "Update Template";
                this.TemplateListColumn = "2";
            }
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Creates the Template View Model
        /// </summary>
        /// <param name="itemService"></param>
        /// <param name="templateStatus"></param>
        public TemplateViewModel(ItemService itemService, string templateStatus, ItemObject template = null)
        {
            this.ItemService = itemService ?? throw new ArgumentNullException("itemService");
            this.TemplateList = GlobalData.TemplateNames;
            this.TemplateObject.Status = templateStatus;
            SetVisibility(templateStatus);
            SetToolTips();
            if (template != null)
            {
                ImportTemplate(template);
            }
        }

        #endregion // Constructor
    }
}
