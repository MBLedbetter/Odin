using Mvvm;
using OdinServices;
using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Odin.Views;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;

namespace Odin.ViewModels
{
    public class ItemViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region Commands

        public ICommand RemoveItemCommand
        {
            get
            {
                if (_RemoveItemCommand == null)
                {
                    _RemoveItemCommand = new RelayCommand(param => RemoveItem());
                }
                return _RemoveItemCommand;
            }
        }
        private RelayCommand _RemoveItemCommand;

        public ICommand SubmitItemCommand
        {
            get
            {
                if (_SubmitItemCommand == null)
                {
                    _SubmitItemCommand = new RelayCommand(param => SubmitItem());
                }
                return _SubmitItemCommand;
            }
        }
        private RelayCommand _SubmitItemCommand;

        #endregion // Commands

        #region Properties

        #region Odin Properties
                              
        public bool BlockInfo { get; set; }
        
        public bool IsNew { get; set; }

        /// <summary>
        ///     List of itemIds in mainwindow
        /// </summary>
        public List<string> ItemIds { get; set; }

        /// <summary>
        ///  Check to distinguish between items and kits 1 == item & 0 == kit
        /// </summary>
        public int ProdType = '1';

        public bool Remove = false;

        public ItemService ItemService { get; set; }

        /// <summary>
        ///     Gets or sets the color of the Ecommerce tab
        /// </summary>
        public string TabColorEcommerce
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
        ///     Gets or sets the color of the Image Path tab
        /// </summary>
        public string TabColorImagePath
        {
            get
            {
                return _tabColorImagePath;
            }
            set
            {
                _tabColorImagePath = value;
                OnPropertyChanged("TabColorImagePath");
            }
        }
        private string _tabColorImagePath = "White";

        /// <summary>
        ///     Gets or sets the color of the Item Info tab
        /// </summary>
        public string TabColorItemInfo
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
        ///     Gets or sets the color of the Web Info tab
        /// </summary>
        public string TabColorWebInfo
        {
            get
            {
                return _tabColorWebInfo;
            }
            set
            {
                _tabColorWebInfo = value;
                OnPropertyChanged("WebInfoTabColorWebInfo");
            }
        }
        private string _tabColorWebInfo = "White";

        /// <summary>
        ///     Gets or sets the color of the Web Flags tab
        /// </summary>
        public string TabColorWebFlag
        {
            get
            {
                return _webFlagTabColor;
            }
            set
            {
                _webFlagTabColor = value;
                OnPropertyChanged("TabColorWebFlag");
            }
        }
        private string _webFlagTabColor = "White";

        /// <summary>
        ///     Dictionary of tool tips
        /// </summary>
        Dictionary<string,string> ToolTips
        {
            get
            {
                return GlobalData.ToolTips;
            }
        }
        
        #endregion // Odin Properties

        #region Peoplesoft Properties

        public string AccountingGroup
        {
            get
            {
                return this.ItemViewModelItem.AccountingGroup;
            }
            set
            {
                if (this.ItemViewModelItem.AccountingGroup != value)
                {
                    this.ItemViewModelItem.AccountingGroup = value;
                    AccountingGroupError = ItemService.ValidateAccountingGroup(value, this.ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
        
        public string BillOfMaterials
        {
            get
            {
                return this.ItemViewModelItem.ReturnBillOfMaterials();
            }
            set
            {
                if (this.ItemViewModelItem.ReturnBillOfMaterials() != value)
                {
                    this.ItemViewModelItem.BillOfMaterials = ItemService.ParseChildElementIds(this.ItemId, value);
                    this.BillOfMaterialsError = ItemService.ValidateBillOfMaterials(this.ItemId, this.ItemViewModelItem.BillOfMaterials, this.ItemIds, this.Status, this.ProdType);
                    OnPropertyChanged("BillOfMaterials");
                }
            }
        }
        public string BillOfMaterialsBoxColor
        {
            get
            {
                return _billOfMaterialsBoxColor;
            }
            set
            {
                _billOfMaterialsBoxColor = value;
                OnPropertyChanged("BillOfMaterialsBoxColor");
            }
        }
        private string _billOfMaterialsBoxColor = "White";
        public string BillOfMaterialsError
        {
            get
            {
                return _billOfMaterialsError;
            }
            set
            {
                _billOfMaterialsError = value;
                if (value != "")
                {
                    BillOfMaterialsToolTip = "Error: " + value + "\n\n" + ReturnToolTip("BillOfMaterials");
                }
                else
                {
                    BillOfMaterialsToolTip = ReturnToolTip("BillOfMaterials");
                }
                this.BillOfMaterialsBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("BillOfMaterialsError");
            }
        }
        private string _billOfMaterialsError = string.Empty;
        public string BillOfMaterialsToolTip
        {
            get
            {
                return _billOfMaterialsToolTip;
            }
            set
            {
                this._billOfMaterialsToolTip = value;
                OnPropertyChanged("BillOfMaterialsToolTip");
            }
        }
        private string _billOfMaterialsToolTip = string.Empty;
        
        public string CasepackHeight
        {
            get
            {
                return this.ItemViewModelItem.CasepackHeight;
            }
            set
            {
                if (this.ItemViewModelItem.CasepackHeight != value)
                {
                    this.ItemViewModelItem.CasepackHeight = value;

                    this.CasepackHeightError = ItemService.ValidateCasepack(value, this.CasepackLength, this.CasepackWidth, this.CasepackWeight, this.ProdType, "Casepack Height");
                    this.CasepackLengthError = ItemService.ValidateCasepack(this.CasepackLength, value, this.CasepackWidth, this.CasepackWeight, this.ProdType, "Casepack Length");
                    this.CasepackWidthError = ItemService.ValidateCasepack(this.CasepackWidth, value, this.CasepackLength, this.CasepackWeight, this.ProdType, "Casepack Width");
                    this.CasepackWeightError = ItemService.ValidateCasepack(this.CasepackWeight, this.CasepackWidth, value, this.CasepackLength, this.ProdType, "Casepack Weight");
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.CasepackLength.ToString();
            }
            set
            {
                if (this.ItemViewModelItem.CasepackLength != value)
                {
                    this.ItemViewModelItem.CasepackLength = value;
                    this.CasepackHeightError = ItemService.ValidateCasepack(this.CasepackHeight, value, this.CasepackWidth, this.CasepackWeight, this.ProdType, "Casepack Height");
                    this.CasepackLengthError = ItemService.ValidateCasepack(value, this.CasepackHeight, this.CasepackWidth, this.CasepackWeight, this.ProdType, "Casepack Length");
                    this.CasepackWidthError = ItemService.ValidateCasepack(this.CasepackWidth, value, this.CasepackHeight, this.CasepackWeight, this.ProdType, "Casepack Width");
                    this.CasepackWeightError = ItemService.ValidateCasepack(this.CasepackWeight, this.CasepackWidth, value, this.CasepackHeight, this.ProdType, "Casepack Weight");
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.CasepackQty;
            }
            set
            {
                if (this.ItemViewModelItem.CasepackQty != value)
                {
                    this.ItemViewModelItem.CasepackQty = value;
                    this.CasepackQtyError = ItemService.ValidateCasepackQty(value, this.ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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

        public string CasepackUpc
        {
            get
            {
                return this.ItemViewModelItem.CasepackUpc;
            }
            set
            {
                if (this.ItemViewModelItem.CasepackUpc != value)
                {
                    this.ItemViewModelItem.CasepackUpc = value;
                    this.CasepackUpcError = ItemService.ValidatePackUpc(value, "Casepack", this.ProdType);
                    OnPropertyChanged("CasepackUpc");
                }
            }
        }
        public string CasepackUpcBoxColor
        {
            get
            {
                return _casepackUpcBoxColor;
            }
            set
            {
                _casepackUpcBoxColor = value;
                OnPropertyChanged("CasepackUpcBoxColor");
            }
        }
        private string _casepackUpcBoxColor = "White";
        public string CasepackUpcError
        {
            get
            {
                return _casepackUpcError;
            }
            set
            {
                _casepackUpcError = value;
                if (value != "")
                {
                    CasepackUpcToolTip = "Error: " + value + "\n\n" + ReturnToolTip("CasepackUpc");
                }
                else
                {
                    CasepackUpcToolTip = ReturnToolTip("CasepackUpc");
                }
                this.CasepackUpcBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("CasepackUpcError");
            }
        }
        private string _casepackUpcError = string.Empty;
        public string CasepackUpcToolTip
        {
            get
            {
                return __casepackUpcToolTip;
            }
            set
            {
                this.__casepackUpcToolTip = value;
                OnPropertyChanged("CasepackUpcToolTip");
            }
        }
        private string __casepackUpcToolTip = string.Empty;

        public string CasepackWidth
        {
            get
            {
                return this.ItemViewModelItem.CasepackWidth.ToString();
            }
            set
            {
                if (this.ItemViewModelItem.CasepackWidth != value)
                {
                    this.ItemViewModelItem.CasepackWidth = value;

                    this.CasepackHeightError = ItemService.ValidateCasepack(this.CasepackHeight, this.CasepackLength, this.CasepackWidth, this.CasepackWeight, this.ProdType, "Casepack Height");
                    this.CasepackLengthError = ItemService.ValidateCasepack(this.CasepackLength, this.CasepackHeight, value, this.CasepackWeight, this.ProdType, "Casepack Length");
                    this.CasepackWidthError = ItemService.ValidateCasepack(value, this.CasepackHeight, this.CasepackLength, this.CasepackWeight, this.ProdType, "Casepack Width");
                    this.CasepackWeightError = ItemService.ValidateCasepack(this.CasepackWeight, this.CasepackWidth, value, this.CasepackLength, this.ProdType, "Casepack Weight");
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.CasepackWeight.ToString();
            }
            set
            {
                if (this.ItemViewModelItem.CasepackWeight != value)
                {
                    this.ItemViewModelItem.CasepackWeight = value;
                    this.CasepackHeightError = ItemService.ValidateCasepack(this.CasepackHeight, this.CasepackLength, this.CasepackWidth, value, this.ProdType, "Casepack Height");
                    this.CasepackLengthError = ItemService.ValidateCasepack(this.CasepackLength, this.CasepackHeight, this.CasepackWidth, value, this.ProdType, "Casepack Length");
                    this.CasepackWidthError = ItemService.ValidateCasepack(this.CasepackWidth, this.CasepackHeight, this.CasepackLength,  value, this.ProdType, "Casepack Width");
                    this.CasepackWeightError = ItemService.ValidateCasepack(value, this.CasepackWidth, this.CasepackHeight, this.CasepackLength, this.ProdType, "Casepack Weight");
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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

        public string Color
        {
            get
            {
                return this.ItemViewModelItem.Color.ToString();
            }
            set
            {
                if (this.ItemViewModelItem.Color != value)
                {
                    this.ItemViewModelItem.Color = value;
                    this.ColorError = ItemService.ValidateColor(value, ProdType);
                    OnPropertyChanged("Color");
                }
            }
        }
        public string ColorBoxColor
        {
            get
            {
                return _colorBoxColor;
            }
            set
            {
                _colorBoxColor = value;
                OnPropertyChanged("ColorBoxColor");
            }
        }
        private string _colorBoxColor = "White";
        public string ColorError
        {
            get
            {
                return _colorError;
            }
            set
            {
                _colorError = value;
                if (value != "")
                {
                    ColorToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Color");
                }
                else
                {
                    ColorToolTip = ReturnToolTip("Color");
                }
                this.ColorBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("ColorError");
            }
        }
        private string _colorError = string.Empty;
        public string ColorToolTip
        {
            get
            {
                return _colorToolTip;
            }
            set
            {
                this._colorToolTip = value;
                OnPropertyChanged("ColorToolTip");
            }
        }
        private string _colorToolTip = string.Empty;

        public string CostProfileGroup
        {
            get
            {
                return this.ItemViewModelItem.CostProfileGroup.ToString();
            }
            set
            {
                if (this.ItemViewModelItem.CostProfileGroup != value)
                {
                    this.ItemViewModelItem.CostProfileGroup = value;
                    this.CostProfileGroupError = ItemService.ValidateCostProfileGroup(value, this.MfgSource, ProdType);
                    this.MfgSourceError = ItemService.ValidateMfgSource(this.MfgSource, value, ProdType);

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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.CountryOfOrigin;
            }
            set
            {
                if (this.ItemViewModelItem.CountryOfOrigin != value)
                {
                    this.ItemViewModelItem.CountryOfOrigin = value;
                    this.ItemViewModelItem.Ecommerce_CountryofOrigin = ItemService.RetrieveFullCountryOfOrigin(value);
                    this.CountryOfOriginError = ItemService.ValidateCountryOfOrigin(value, ListPriceUsd, ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.DefaultActualCostUsd.ToString();
            }
            set
            {
                if (this.ItemViewModelItem.DefaultActualCostUsd != value)
                {
                    this.ItemViewModelItem.DefaultActualCostUsd = value;
                    DefaultActualCostUsdError = ItemService.ValidateDefaultActualCost(value, "USD", ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.DefaultActualCostCad.ToString();
            }
            set
            {
                if (this.ItemViewModelItem.DefaultActualCostCad != value)
                {
                    this.ItemViewModelItem.DefaultActualCostCad = value;
                    DefaultActualCostCadError = ItemService.ValidateDefaultActualCost(value, "CAD", ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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

        public string Description
        {
            get
            {
                return this.ItemViewModelItem.Description.ToString();
            }
            set
            {
                if (this.ItemViewModelItem.Description != value)
                {
                    this.ItemViewModelItem.Description = DbUtil.ReplaceCharacters(value);
                    DescriptionError = this.ItemService.ValidateDescription(DbUtil.ReplaceCharacters(value), this.ProdType);
                    OnPropertyChanged("Description");
                }
            }
        }
        public string DescriptionBoxColor
        {
            get
            {
                return _descriptionBoxColor;
            }
            set
            {
                _descriptionBoxColor = value;
                OnPropertyChanged("DescriptionBoxColor");
            }
        }
        private string _descriptionBoxColor = "White";
        public string DescriptionError
        {
            get
            {
                return _descriptionError;
            }
            set
            {
                _descriptionError = value;
                if (value != "")
                {
                    DescriptionToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Description");
                }
                else
                {
                    DescriptionToolTip = ReturnToolTip("Description");
                }
                this.DescriptionBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("DescriptionError");
            }
        }
        private string _descriptionError = string.Empty;
        public string DescriptionToolTip
        {
            get
            {
                return _descriptionToolTip;
            }
            set
            {
                this._descriptionToolTip = value;
                OnPropertyChanged("DescriptionToolTip");
            }
        }
        private string _descriptionToolTip = string.Empty;

        public string DirectImport
        {
            get
            {
                return this.ItemViewModelItem.DirectImport.ToString();
            }
            set
            {
                if (this.ItemViewModelItem.DirectImport != value)
                {
                    this.ItemViewModelItem.DirectImport = value;
                    DirectImportError = this.ItemService.ValidateDirectImport(value, this.ProdType);
                    OnPropertyChanged("DirectImport");
                }
            }
        }
        public string DirectImportBoxColor
        {
            get
            {
                return _directImportBoxColor;
            }
            set
            {
                _directImportBoxColor = value;
                OnPropertyChanged("DirectImportBoxColor");
            }
        }
        private string _directImportBoxColor = "White";
        public string DirectImportError
        {
            get
            {
                return _directImportError;
            }
            set
            {
                _directImportError = value;
                if (value != "")
                {
                    DirectImportToolTip = "Error: " + value + "\n\n" + ReturnToolTip("DirectImport");
                }
                else
                {
                    DirectImportToolTip = ReturnToolTip("Description");
                }
                this.DirectImportBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("DirectImportError");
            }
        }
        private string _directImportError = string.Empty;
        public string DirectImportToolTip
        {
            get
            {
                return _directImportToolTip;
            }
            set
            {
                this._directImportToolTip = value;
                OnPropertyChanged("DirectImportToolTip");
            }
        }
        private string _directImportToolTip = string.Empty;

        public string Ean
        {
            get
            {
                return this.ItemViewModelItem.Ean.ToString();
            }
            set
            {
                if (this.ItemViewModelItem.Ean != value)
                {
                    this.ItemViewModelItem.Ean = value;
                    EanError = ItemService.ValidateEan(value, this.Upc, this.ListPriceUsd, this.ProductFormat, this.ProductLine);
                    OnPropertyChanged("Ean");
                }
            }
        }
        public string EanBoxColor
        {
            get
            {
                return _eanBoxColor;
            }
            set
            {
                _eanBoxColor = value;
                OnPropertyChanged("EanBoxColor");
            }
        }
        private string _eanBoxColor = "White";
        public string EanError
        {
            get
            {
                return _eanError;
            }
            set
            {
                _eanError = value;
                if (value != "")
                {
                    EanToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ean");
                }
                else
                {
                    EanToolTip = ReturnToolTip("Ean");
                }
                this.EanBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("EanError");
            }
        }
        private string _eanError = string.Empty;
        public string EanToolTip
        {
            get
            {
                return _eanToolTip;
            }
            set
            {
                this._eanToolTip = value;
                OnPropertyChanged("EanToolTip");
            }
        }
        private string _eanToolTip = string.Empty;

        public string Duty
        {
            get
            {
                return this.ItemViewModelItem.Duty.ToString();
            }
            set
            {
                if (this.ItemViewModelItem.Duty != value)
                {
                    this.ItemViewModelItem.Duty = value;
                    DutyError = ItemService.ValidateDuty(value, ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.Gpc;
            }
            set
            {
                if (this.ItemViewModelItem.Gpc != value)
                {
                    this.ItemViewModelItem.Gpc = value;
                    GpcError = ItemService.ValidateGpc(value, ListPriceUsd, ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.Height;
            }
            set
            {
                if (this.ItemViewModelItem.Height != value)
                {
                    this.ItemViewModelItem.Height = value;
                    HeightError = ItemService.ValidateHeight(value, ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.InnerpackHeight;
            }
            set
            {
                if (this.ItemViewModelItem.InnerpackHeight != value)
                {
                    this.ItemViewModelItem.InnerpackHeight = value;
                    InnerpackHeightError = ItemService.ValidateInnerpack(value, InnerpackLength, InnerpackWidth, InnerpackWeight, ProdType, "Innerpack Height");
                    InnerpackLengthError = ItemService.ValidateInnerpack(InnerpackLength, value, InnerpackWidth, InnerpackWeight, ProdType, "Innerpack Length");
                    InnerpackWeightError = ItemService.ValidateInnerpack(InnerpackWeight, value, InnerpackLength, InnerpackWidth, ProdType, "Innerpack Weight");
                    InnerpackWidthError = ItemService.ValidateInnerpack(InnerpackWidth, value, InnerpackLength, InnerpackWeight, ProdType, "Innerpack Width");
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.InnerpackLength;
            }
            set
            {
                if (this.ItemViewModelItem.InnerpackLength != value)
                {
                    this.ItemViewModelItem.InnerpackLength = value;
                    InnerpackHeightError = ItemService.ValidateInnerpack(InnerpackHeight, value, InnerpackWidth, InnerpackWeight, ProdType, "Innerpack Height");
                    InnerpackLengthError = ItemService.ValidateInnerpack(value, InnerpackHeight, InnerpackWidth, InnerpackWeight, ProdType, "Innerpack Length");
                    InnerpackWeightError = ItemService.ValidateInnerpack(InnerpackWeight, value, InnerpackWidth, InnerpackHeight, ProdType, "Innerpack Weight");
                    InnerpackWidthError = ItemService.ValidateInnerpack(InnerpackWidth, value, InnerpackHeight, InnerpackWeight, ProdType, "Innerpack Width");
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.InnerpackQuantity;
            }
            set
            {
                if (this.ItemViewModelItem.InnerpackQuantity != value)
                {
                    this.ItemViewModelItem.InnerpackQuantity = value;
                    InnerpackQuantityError = ItemService.ValidateInnerpackQuantity(value, ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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

        public string InnerpackUpc
        {
            get
            {
                return this.ItemViewModelItem.InnerpackUpc;
            }
            set
            {
                if (this.ItemViewModelItem.InnerpackUpc != value)
                {
                    this.ItemViewModelItem.InnerpackUpc = value;
                    InnerpackUpcError = ItemService.ValidatePackUpc(value, "Innerpack", ProdType);
                    OnPropertyChanged("InnerpackUpc");
                }
            }
        }
        public string InnerpackUpcBoxColor
        {
            get
            {
                return _innerpackUpcBoxColor;
            }
            set
            {
                _innerpackUpcBoxColor = value;
                OnPropertyChanged("InnerpackUpcBoxColor");
            }
        }
        private string _innerpackUpcBoxColor = "White";
        public string InnerpackUpcError
        {
            get
            {
                return _innerpackUpcError;
            }
            set
            {
                _innerpackUpcError = value;
                if (value != "")
                {
                    InnerpackUpcToolTip = "Error: " + value + "\n\n" + ReturnToolTip("InnerpackUpc");
                }
                else
                {
                    InnerpackUpcToolTip = ReturnToolTip("InnerpackUpc");
                }
                this.InnerpackUpcBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("InnerpackUpcError");
            }
        }
        private string _innerpackUpcError = string.Empty;
        public string InnerpackUpcToolTip
        {
            get
            {
                return _innerpackUpcToolTip;
            }
            set
            {
                this._innerpackUpcToolTip = value;
                OnPropertyChanged("InnerpackUpcToolTip");
            }
        }
        private string _innerpackUpcToolTip = string.Empty;

        public string InnerpackWeight
        {
            get
            {
                return this.ItemViewModelItem.InnerpackWeight;
            }
            set
            {
                if (this.ItemViewModelItem.InnerpackWeight != value)
                {
                    this.ItemViewModelItem.InnerpackWeight = value;
                    InnerpackLengthError = ItemService.ValidateInnerpack(InnerpackLength, value, InnerpackWidth, InnerpackHeight, ProdType, "Innerpack Length");
                    InnerpackWidthError = ItemService.ValidateInnerpack(InnerpackWidth, value, InnerpackLength, InnerpackHeight, ProdType, "Innerpack Width");
                    InnerpackHeightError = ItemService.ValidateInnerpack(InnerpackHeight, value, InnerpackLength, InnerpackWidth, ProdType, "Innerpack Height");
                    InnerpackWeightError = ItemService.ValidateInnerpack(value, InnerpackWidth, InnerpackLength, InnerpackHeight, ProdType, "Innerpack Weight");

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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.InnerpackWidth;
            }
            set
            {
                if (this.ItemViewModelItem.InnerpackWidth != value)
                {
                    this.ItemViewModelItem.InnerpackWidth = value;
                    InnerpackLengthError = ItemService.ValidateInnerpack(InnerpackLength, value, InnerpackHeight, InnerpackWeight, ProdType, "Innerpack Length");
                    InnerpackWidthError = ItemService.ValidateInnerpack(value, InnerpackHeight, InnerpackLength, InnerpackWeight, ProdType, "Innerpack Width");
                    InnerpackHeightError = ItemService.ValidateInnerpack(InnerpackHeight, InnerpackLength, InnerpackWeight, value, ProdType, "Innerpack Height");
                    InnerpackWeightError = ItemService.ValidateInnerpack(InnerpackWeight, value, InnerpackLength, InnerpackHeight, ProdType, "Innerpack Weight");
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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

        public string Isbn
        {
            get
            {
                return this.ItemViewModelItem.Isbn;
            }
            set
            {
                if (this.ItemViewModelItem.Isbn != value)
                {
                    this.ItemViewModelItem.Isbn = value;
                    IsbnError = ItemService.ValidateIsbn(value, ProdType);
                    OnPropertyChanged("Isbn");
                }
            }
        }
        public string IsbnBoxColor
        {
            get
            {
                return _isbnBoxColor;
            }
            set
            {
                _isbnBoxColor = value;
                OnPropertyChanged("IsbnBoxColor");
            }
        }
        private string _isbnBoxColor = "White";
        public string IsbnError
        {
            get
            {
                return _isbnError;
            }
            set
            {
                _isbnError = value;
                if (value != "")
                {
                    IsbnToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Isbn");
                }
                else
                {
                    IsbnToolTip = ReturnToolTip("Isbn");
                }
                this.IsbnBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("IsbnErrorMsg");
            }
        }
        private string _isbnError = string.Empty;
        public string IsbnToolTip
        {
            get
            {
                return _isbnToolTip;
            }
            set
            {
                this._isbnToolTip = value;
                OnPropertyChanged("IsbnToolTip");
            }
        }
        private string _isbnToolTip = string.Empty;

        public string ItemCategory
        {
            get
            {
                return this.ItemViewModelItem.ItemCategory;
            }
            set
            {
                if (this.ItemViewModelItem.ItemCategory != value)
                {
                    this.ItemViewModelItem.ItemCategory = value;
                    ItemCategoryError = ItemService.ValidateItemCategory(value, ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.ItemFamily;
            }
            set
            {
                if (this.ItemViewModelItem.ItemFamily != value)
                {
                    this.ItemViewModelItem.ItemFamily = value.ToUpper();
                    ItemFamilyError = ItemService.ValidateItemFamily(value, ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                    return this.ItemViewModelItem.ItemGroup;
            }
            set
            {
                if (this.ItemViewModelItem.ItemGroup != value)
                {
                    this.ItemViewModelItem.ItemGroup = value;
                    this.ItemGroupError = ItemService.ValidateItemGroup(value, ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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

        public string ItemId
        {
            get
            {
                return this.ItemViewModelItem.ItemId;
            }
            set
            {
                if (this.ItemViewModelItem.ItemId != value)
                {
                    this.ItemViewModelItem.ItemId = value;
                    this.ItemIdError = ItemService.ValidateItemId(value, this.ItemViewModelItem.Status);
                    OnPropertyChanged("ItemId");
                }
            }
        }
        public string ItemIdBoxColor
        {
            get
            {
                return _itemIdBoxColor;
            }
            set
            {
                _itemIdBoxColor = value;
                OnPropertyChanged("ItemIdBoxColor");
            }
        }
        private string _itemIdBoxColor = "White";
        public string ItemIdError
        {
            get
            {
                return _itemIdError;
            }
            set
            {
                _itemIdError = value;
                if (value != "")
                {
                    ItemIdToolTip = "Error: " + value + "\n\n" + ReturnToolTip("ItemId");
                }
                else
                {
                    ItemIdToolTip = ReturnToolTip("ItemId");
                }
                this.ItemIdBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("ItemIdError");
            }
        }
        private string _itemIdError = string.Empty;
        public string ItemIdToolTip
        {
            get
            {
                return _itemIdToolTip;
            }
            set
            {
                this._itemIdToolTip = value;
                OnPropertyChanged("ItemIdToolTip");
            }
        }
        private string _itemIdToolTip = string.Empty;

        public int ItemRow
        {
            get
            {
                return this.ItemViewModelItem.ItemRow;
            }
            set
            {
                this.ItemViewModelItem.ItemRow = value;
            }
        }

        public string Language
        {
            get
            {
                    return this.ItemViewModelItem.Language;
            }
            set
            {
                if (this.ItemViewModelItem.Language != value)
                {
                    this.ItemViewModelItem.Language = (DbUtil.OrderLanguage(value) == "") ? value : DbUtil.OrderLanguage(value);
                    this.LanguageError = ItemService.ValidateLanguage(DbUtil.OrderLanguage(value), this.ListPriceUsd, ProdType);
                    OnPropertyChanged("Language");
                }
            }
        }
        public string LanguageBoxColor
        {
            get
            {
                return _languageBoxColor;
            }
            set
            {
                _languageBoxColor = value;
                OnPropertyChanged("LanguageBoxColor");
            }
        }
        private string _languageBoxColor = "White";
        public string LanguageError
        {
            get
            {
                return _languageError;
            }
            set
            {
                _languageError = value;
                if (value != "")
                {
                    LanguageToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Language");
                }
                else
                {
                    LanguageToolTip = ReturnToolTip("Language");
                }
                this.LanguageBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("LanguageError");
            }
        }
        private string _languageError = string.Empty;
        public string LanguageToolTip
        {
            get
            {
                return _languageToolTip;
            }
            set
            {
                this._languageToolTip = value;
                OnPropertyChanged("LanguageToolTip");
            }
        }
        private string _languageToolTip = string.Empty;

        public string Length
        {
            get
            {
                return this.ItemViewModelItem.Length;
            }
            set
            {
                if (this.ItemViewModelItem.Length != value)
                {
                    this.ItemViewModelItem.Length = value;
                    this.LengthError = ItemService.ValidateLength(value, ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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

        public string LicenseBeginDate
        {
            get
            {
                return this.ItemViewModelItem.LicenseBeginDate;
            }
            set
            {
                if (this.ItemViewModelItem.LicenseBeginDate != value)
                {
                    this.ItemViewModelItem.LicenseBeginDate = value;
                    this.LicenseBeginDateError = ItemService.ValidateLicenseBeginDate(value, this.ProdType);
                    OnPropertyChanged("LicenseBeginDate");
                }
            }
        }
        public string LicenseBeginDateBoxColor
        {
            get
            {
                return _licenseBeginDateBoxColor;
            }
            set
            {
                _licenseBeginDateBoxColor = value;
                OnPropertyChanged("LicenseBeginDateBoxColor");
            }
        }
        private string _licenseBeginDateBoxColor = "White";
        public string LicenseBeginDateError
        {
            get
            {
                return _licenseBeginDateError;
            }
            set
            {
                _licenseBeginDateError = value;
                if (value != "")
                {
                    LicenseBeginDateToolTip = "Error: " + value + "\n\n" + ReturnToolTip("LicenseBeginDate");
                }
                else
                {
                    LicenseBeginDateToolTip = ReturnToolTip("LicenseBeginDate");
                }
                this.LicenseBeginDateBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("LicenseBeginDateError");
            }
        }
        private string _licenseBeginDateError = string.Empty;
        public string LicenseBeginDateToolTip
        {
            get
            {
                return _licenseBeginDateToolTip;
            }
            set
            {
                this._licenseBeginDateToolTip = value;
                OnPropertyChanged("LicenseBeginDateToolTip");
            }
        }
        private string _licenseBeginDateToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the ListPriceCad
        /// </summary>
        public string ListPriceCad
        {
            get
            {
                    return this.ItemViewModelItem.ListPriceCad;
            }
            set
            {
                if (this.ItemViewModelItem.ListPriceCad != value)
                {
                    this.ItemViewModelItem.ListPriceCad = value;
                    this.ListPriceCadError = ItemService.ValidateListPrice(value, "CAD", this.ProdType);
                    this.MsrpCadError = ItemService.ValidateMsrp(this.MsrpCad, value, this.ProdType, "CAD");
                    this.PricingGroupError = ItemService.ValidatePricingGroup(this.PricingGroup, value, this.ListPriceUsd, this.ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.ListPriceMxn;
            }
            set
            {
                if (this.ItemViewModelItem.ListPriceMxn != value)
                {
                    this.ItemViewModelItem.ListPriceMxn = value;
                    this.MsrpMxnError = ItemService.ValidateMsrp(MsrpMxn, value, this.ProdType, "MXN");
                    this.ListPriceMxnError = ItemService.ValidateListPrice(value, "MXN", this.ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.ListPriceUsd;
            }
            set
            {
                if (this.ItemViewModelItem.ListPriceUsd != value)
                {
                    this.ItemViewModelItem.ListPriceUsd = value;
                    this.ListPriceUsdError = ItemService.ValidateListPrice(value, "USD", this.ProdType);
                    this.ProductQtyTotal = ItemService.RetrieveB2bPrice(value, this.ProductQty);
                    this.MsrpError = ItemService.ValidateMsrp(this.Msrp, value, this.ProdType, "USD");
                    this.PricingGroupError = ItemService.ValidatePricingGroup(this.PricingGroup, this.ListPriceCad, value, this.ProdType);
                    this.StatsCodeError = ItemService.ValidateStatsCode(value, this.ListPriceUsd, this.ProdType);
                    this.CountryOfOriginError = ItemService.ValidateCountryOfOrigin(this.CountryOfOrigin, value, this.ProdType);
                    this.LanguageError = ItemService.ValidateLanguage(DbUtil.OrderLanguage(this.Language), value, this.ProdType);
                    this.TerritoryError = ItemService.ValidateTerritory(DbUtil.OrderTerritory(this.Territory), value, this.ProdType);
                    this.GpcError = ItemService.ValidateGpc(value, this.ListPriceUsd, this.ProdType);
                    this.UpcError = ItemService.ValidateUpc(this.Upc, this.ItemId, this.Status, value, this.ProductFormat, this.ProductGroup, this.ProductLine, this.Ean,this.Ecommerce_Upc, this.ProdType);
                    ValidateEcommerce();
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.MfgSource;
            }
            set
            {
                if (this.ItemViewModelItem.MfgSource != value)
                {
                    this.ItemViewModelItem.MfgSource = value;
                    this.MfgSourceError = ItemService.ValidateMfgSource(value, this.CostProfileGroup, this.ProdType);
                    this.CostProfileGroupError = ItemService.ValidateCostProfileGroup(this.CostProfileGroup, value, this.ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.Msrp;
            }
            set
            {
                if (this.ItemViewModelItem.Msrp != value)
                {
                    this.ItemViewModelItem.Msrp = value;
                    this.MsrpError = ItemService.ValidateMsrp(value, this.ListPriceUsd, this.ProdType, "USD");
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.MsrpCad;
            }
            set
            {
                if (this.ItemViewModelItem.MsrpCad != value)
                {
                    this.ItemViewModelItem.MsrpCad = value;
                    this.MsrpCadError = ItemService.ValidateMsrp(value, this.ListPriceCad, this.ProdType, "CAD");
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.MsrpMxn;
            }
            set
            {
                if (this.ItemViewModelItem.MsrpMxn != value)
                {
                    this.ItemViewModelItem.MsrpMxn = value;
                    this.MsrpMxnError = ItemService.ValidateMsrp(value, this.ListPriceMxn, this.ProdType, "MXN");
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.PricingGroup;
            }
            set
            {
                if (this.ItemViewModelItem.PricingGroup != value)
                {
                    this.ItemViewModelItem.PricingGroup = value;
                    this.PricingGroupError = ItemService.ValidatePricingGroup(value, this.ListPriceCad, this.ListPriceCad, this.ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                    return this.ItemViewModelItem.PrintOnDemand;
            }
            set
            {
                if (this.ItemViewModelItem.PrintOnDemand != value)
                {
                    this.ItemViewModelItem.PrintOnDemand = value;
                    this.PrintOnDemandError = ItemService.ValidatePrintOnDemand(value, this.ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.ProductFormat;
            }
            set
            {
                if (this.ItemViewModelItem.ProductFormat != value)
                {
                    this.ItemViewModelItem.ProductFormat = value;
                    this.ProductFormatError = ItemService.ValidateProductFormat(this.ProductGroup, this.ProductLine, value, this.Upc, this.ProdType);
                    this.ProductIdTranslationError = ItemService.ValidateProductIdTranslation(this.ItemId, this.ItemViewModelItem.ProductIdTranslation, this.ItemIds, this.ProductFormat, this.PricingGroup, this.Status, this.ProdType);
                    this.UpcError = ItemService.ValidateUpc(this.Upc, this.ItemId, this.Status, this.ListPriceUsd, this.ProductFormat, this.ProductGroup, this.ProductLine, this.Ean,this.Ecommerce_Upc, this.ProdType);
                    this.EanError = ItemService.ValidateEan(value, this.Upc, this.ListPriceUsd, this.ProductFormat, this.ProductLine);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.ProductGroup;
            }
            set
            {
                if (this.ItemViewModelItem.ProductGroup != value)
                {
                    this.ItemViewModelItem.ProductGroup = value;
                    RefreshProductLines();
                    RefreshProductFormats("");
                    this.ProductFormatError = ItemService.ValidateProductFormat(value, this.ProductLine, this.ProductFormat, this.Upc, this.ProdType);
                    this.ProductLineError = ItemService.ValidateProductLine(value, this.ProductLine, this.Upc, this.ProdType);
                    this.ProductGroupError = ItemService.ValidateProductGroup(value, this.Upc, this.ProdType);
                    this.UpcError = ItemService.ValidateUpc(this.Upc, this.ItemId, this.Status, this.ListPriceUsd, this.ProductFormat, value, this.ProductLine, this.Ean, this.Ecommerce_Upc, this.ProdType);
                    ValidateEcommerce();
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
        ///     Gets or sets the ProductIdTranslation
        /// </summary>
        public string ProductIdTranslation
        {
            get
            {
                return this.ItemViewModelItem.ReturnProductIdTranslations();
            }
            set
            {
                if (this.ItemViewModelItem.ReturnProductIdTranslations() != value)
                {
                    this.ItemViewModelItem.ProductIdTranslation = ItemService.ParseChildElementIds(this.ItemId, value);
                    this.ProductIdTranslationError = ItemService.ValidateProductIdTranslation(this.ItemId, this.ItemViewModelItem.ProductIdTranslation, this.ItemIds, this.ProductFormat, this.PricingGroup, this.Status, this.ProdType);
                    OnPropertyChanged("ProductIdTranslation");
                }
            }
        }
        public string ProductIdTranslationBoxColor
        {
            get
            {
                return _productIdTranslationBoxColor;
            }
            set
            {
                _productIdTranslationBoxColor = value;
                OnPropertyChanged("ProductIdTranslationBoxColor");
            }
        }
        private string _productIdTranslationBoxColor = "White";
        public string ProductIdTranslationError
        {
            get
            {
                return _productIdTranslationError;
            }
            set
            {
                _productIdTranslationError = value;
                if (value != "")
                {
                    ProductIdTranslationToolTip = "Error: " + value + "\n\n" + ReturnToolTip("ProductIdTranslation");
                }
                else
                {
                    ProductIdTranslationToolTip = ReturnToolTip("ProductIdTranslation");
                }
                this.ProductIdTranslationBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("ProductIdTranslationError");
            }
        }
        private string _productIdTranslationError = string.Empty;
        public string ProductIdTranslationToolTip
        {
            get
            {
                return _productIdTranslationToolTip;
            }
            set
            {
                this._productIdTranslationToolTip = value;
                OnPropertyChanged("ProductIdTranslationToolTip");
            }
        }
        private string _productIdTranslationToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the ProductLine
        /// </summary>
        public string ProductLine
        {
            get
            {
                return this.ItemViewModelItem.ProductLine;
            }
            set
            {
                if (this.ItemViewModelItem.ProductLine != value)
                {
                    this.ItemViewModelItem.ProductLine = value;
                    RefreshProductFormats(this.ProductLine);
                    this.EanError = ItemService.ValidateEan(this.Ean, this.Upc, this.ListPriceUsd, this.ProductFormat, this.ProductLine);
                    this.ProductFormatError = ItemService.ValidateProductFormat(this.ProductGroup, value, this.ProductFormat, this.Upc, this.ProdType);
                    this.ProductLineError = ItemService.ValidateProductLine(this.ProductGroup, value, this.Upc, this.ProdType);
                    this.UpcError = ItemService.ValidateUpc(this.Upc, this.ItemId, this.Status, this.ListPriceUsd, this.ProductFormat, this.ProductGroup, value, this.Ean, this.Ecommerce_Upc, this.ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.ProductQty;
            }
            set
            {
                if (this.ItemViewModelItem.ProductQty != value)
                {
                    this.ItemViewModelItem.ProductQty = value;
                    this.ProductQtyTotal = ItemService.RetrieveB2bPrice(this.ListPriceUsd, value);
                    this.ProductQtyError = ItemService.ValidateProductQty(value, this.ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("ProductQtyError");
            }
        }
        private string _productQtyError = string.Empty;
        public string ProductQtyTotal
        {
            get
            {
                return _productQtyTotal;
            }
            set
            {
                _productQtyTotal = value;
                OnPropertyChanged("ProductQtyTotal");
            }
        }
        private string _productQtyTotal = string.Empty;
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
                return this.ItemViewModelItem.PsStatus;
            }
            set
            {
                if (this.ItemViewModelItem.PsStatus != value)
                {
                    this.ItemViewModelItem.PsStatus = value;
                    this.PsStatusError = ItemService.ValidatePsStatus(value, "Item");
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                this._psStatusToolTip = value;
                OnPropertyChanged("PsStatusToolTip");
            }
        }
        private string _psStatusToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the SAT Code
        /// </summary>
        public string SatCode
        {
            get
            {
                return this.ItemViewModelItem.SatCode;
            }
            set
            {
                if (this.ItemViewModelItem.SatCode != value)
                {
                    this.ItemViewModelItem.SatCode = value;
                    this.SatCodeError = ItemService.ValidateSatCode(value);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
        ///     Gets or sets the SellOnAllPosters
        /// </summary>
        public string SellOnAllPosters
        {
            get
            {
                return this.ItemViewModelItem.SellOnAllPosters;
            }
            set
            {
                if (this.ItemViewModelItem.SellOnAllPosters != value)
                {
                    this.ItemViewModelItem.SellOnAllPosters = value;
                    this.SellOnAllPostersError = ItemService.ValidateSellOnValue(value, "AllPosters");
                    ValidateEcommerce();
                    OnPropertyChanged("SellOnAllPosters");
                }
            }
        }
        public string SellOnAllPostersBoxColor
        {
            get
            {
                return _sellOnAllPostersBoxColor;
            }
            set
            {
                _sellOnAllPostersBoxColor = value;
                OnPropertyChanged("SellOnAllPostersBoxColor");
            }
        }
        private string _sellOnAllPostersBoxColor = "White";
        public string SellOnAllPostersError
        {
            get
            {
                return _sellOnAllPostersError;
            }
            set
            {
                _sellOnAllPostersError = value;
                if (value != "")
                {
                    SellOnAllPostersToolTip = "Error: " + value + "\n\n" + ReturnToolTip("SellOnAllPosters");
                }
                else
                {
                    SellOnAllPostersToolTip = ReturnToolTip("SellOnAllPosters");
                }
                this.SellOnAllPostersBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorWebFlag = CheckWebFlagsTabColor();
                OnPropertyChanged("SellOnAllPostersError");
            }
        }
        private string _sellOnAllPostersError = string.Empty;
        public string SellOnAllPostersToolTip
        {
            get
            {
                return _sellOnAllPostersToolTip;
            }
            set
            {
                this._sellOnAllPostersToolTip = value;
                OnPropertyChanged("SellOnAllPostersToolTip");
            }
        }
        private string _sellOnAllPostersToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the SellOnAmazon
        /// </summary>
        public string SellOnAmazon
        {
            get
            {
                return this.ItemViewModelItem.SellOnAmazon;
            }
            set
            {
                if (this.ItemViewModelItem.SellOnAmazon != value)
                {
                    this.ItemViewModelItem.SellOnAmazon = value;
                    this.SellOnAmazonError = ItemService.ValidateSellOnValue(value, "Amazon");
                    ValidateEcommerce();
                    OnPropertyChanged("SellOnAmazon");
                }
            }
        }
        public string SellOnAmazonBoxColor
        {
            get
            {
                return _sellOnAmazonBoxColor;
            }
            set
            {
                _sellOnAmazonBoxColor = value;
                OnPropertyChanged("SellOnAmazonBoxColor");
            }
        }
        private string _sellOnAmazonBoxColor = "White";
        public string SellOnAmazonError
        {
            get
            {
                return _sellOnAmazonError;
            }
            set
            {
                _sellOnAmazonError = value;
                if (value != "")
                {
                    SellOnAmazonToolTip = "Error: " + value + "\n\n" + ReturnToolTip("SellOnAmazon");
                }
                else
                {
                    SellOnAmazonToolTip = ReturnToolTip("SellOnAmazon");
                }
                this.SellOnAmazonBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorWebFlag = CheckWebFlagsTabColor();
                OnPropertyChanged("SellOnAmazonError");
            }
        }
        private string _sellOnAmazonError = string.Empty;
        public string SellOnAmazonToolTip
        {
            get
            {
                return _sellOnAmazonToolTip;
            }
            set
            {
                this._sellOnAmazonToolTip = value;
                OnPropertyChanged("SellOnAmazonToolTip");
            }
        }
        private string _sellOnAmazonToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the Sell On Fanatics
        /// </summary>
        public string SellOnFanatics
        {
            get
            {
                return this.ItemViewModelItem.SellOnFanatics;
            }
            set
            {
                if (this.ItemViewModelItem.SellOnFanatics != value)
                {
                    this.ItemViewModelItem.SellOnFanatics = value;
                    this.SellOnFanaticsError = ItemService.ValidateSellOnValue(value, "Fanatics");
                    ValidateEcommerce();
                    OnPropertyChanged("SellOnFanatics");
                }
            }
        }
        public string SellOnFanaticsBoxColor
        {
            get
            {
                return _sellOnFanaticsBoxColor;
            }
            set
            {
                _sellOnFanaticsBoxColor = value;
                OnPropertyChanged("SellOnFanaticsBoxColor");
            }
        }
        private string _sellOnFanaticsBoxColor = "White";
        public string SellOnFanaticsError
        {
            get
            {
                return _sellOnFanaticsError;
            }
            set
            {
                _sellOnFanaticsError = value;
                if (value != "")
                {
                    SellOnFanaticsToolTip = "Error: " + value + "\n\n" + ReturnToolTip("SellOnFanatics");
                }
                else
                {
                    SellOnFanaticsToolTip = ReturnToolTip("SellOnFanatics");
                }
                this.SellOnFanaticsBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorWebFlag = CheckWebFlagsTabColor();
                OnPropertyChanged("SellOnFanaticsError");
            }
        }
        private string _sellOnFanaticsError = string.Empty;
        public string SellOnFanaticsToolTip
        {
            get
            {
                return _sellOnFanaticsToolTip;
            }
            set
            {
                this._sellOnFanaticsToolTip = value;
                OnPropertyChanged("SellOnFanaticsToolTip");
            }
        }
        private string _sellOnFanaticsToolTip = string.Empty;


        /// <summary>
        ///     Gets or sets the Sell On GuitarCenter
        /// </summary>
        public string SellOnGuitarCenter
        {
            get
            {
                return this.ItemViewModelItem.SellOnGuitarCenter;
            }
            set
            {
                if (this.ItemViewModelItem.SellOnGuitarCenter != value)
                {
                    this.ItemViewModelItem.SellOnGuitarCenter = value;
                    this.SellOnGuitarCenterError = ItemService.ValidateSellOnValue(value, "Guitar Center");
                    ValidateEcommerce();
                    OnPropertyChanged("SellOnGuitarCenter");
                }
            }
        }
        public string SellOnGuitarCenterBoxColor
        {
            get
            {
                return _sellOnGuitarCenterBoxColor;
            }
            set
            {
                _sellOnGuitarCenterBoxColor = value;
                OnPropertyChanged("SellOnGuitarCenterBoxColor");
            }
        }
        private string _sellOnGuitarCenterBoxColor = "White";
        public string SellOnGuitarCenterError
        {
            get
            {
                return _sellOnGuitarCenterError;
            }
            set
            {
                _sellOnGuitarCenterError = value;
                if (value != "")
                {
                    SellOnGuitarCenterToolTip = "Error: " + value + "\n\n" + ReturnToolTip("SellOnGuitarCenter");
                }
                else
                {
                    SellOnGuitarCenterToolTip = ReturnToolTip("SellOnGuitarCenter");
                }
                this.SellOnGuitarCenterBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorWebFlag = CheckWebFlagsTabColor();
                OnPropertyChanged("SellOnGuitarCenterError");
            }
        }
        private string _sellOnGuitarCenterError = string.Empty;
        public string SellOnGuitarCenterToolTip
        {
            get
            {
                return _sellOnGuitarCenterToolTip;
            }
            set
            {
                this._sellOnGuitarCenterToolTip = value;
                OnPropertyChanged("SellOnGuitarCenterToolTip");
            }
        }
        private string _sellOnGuitarCenterToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the Sell On Hayneedle
        /// </summary>
        public string SellOnHayneedle
        {
            get
            {
                return this.ItemViewModelItem.SellOnHayneedle;
            }
            set
            {
                if (this.ItemViewModelItem.SellOnHayneedle != value)
                {
                    this.ItemViewModelItem.SellOnHayneedle = value;
                    this.SellOnHayneedleError = ItemService.ValidateSellOnValue(value, "Hayneedle");
                    ValidateEcommerce();
                    OnPropertyChanged("SellOnHayneedle");
                }
            }
        }
        public string SellOnHayneedleBoxColor
        {
            get
            {
                return _sellOnHayneedleBoxColor;
            }
            set
            {
                _sellOnHayneedleBoxColor = value;
                OnPropertyChanged("SellOnHayneedleBoxColor");
            }
        }
        private string _sellOnHayneedleBoxColor = "White";
        public string SellOnHayneedleError
        {
            get
            {
                return _sellOnHayneedleError;
            }
            set
            {
                _sellOnHayneedleError = value;
                if (value != "")
                {
                    SellOnHayneedleToolTip = "Error: " + value + "\n\n" + ReturnToolTip("SellOnHayneedle");
                }
                else
                {
                    SellOnHayneedleToolTip = ReturnToolTip("SellOnHayneedle");
                }
                this.SellOnHayneedleBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorWebFlag = CheckWebFlagsTabColor();
                OnPropertyChanged("SellOnHayneedleError");
            }
        }
        private string _sellOnHayneedleError = string.Empty;
        public string SellOnHayneedleToolTip
        {
            get
            {
                return _sellOnHayneedleToolTip;
            }
            set
            {
                this._sellOnHayneedleToolTip = value;
                OnPropertyChanged("SellOnHayneedleToolTip");
            }
        }
        private string _sellOnHayneedleToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the Sell On Target
        /// </summary>
        public string SellOnTarget
        {
            get
            {
                return this.ItemViewModelItem.SellOnTarget;
            }
            set
            {
                if (this.ItemViewModelItem.SellOnTarget != value)
                {
                    this.ItemViewModelItem.SellOnTarget = value;
                    this.SellOnTargetError = ItemService.ValidateSellOnValue(value, "Target");
                    ValidateEcommerce();
                    OnPropertyChanged("SellOnTarget");
                }
            }
        }
        public string SellOnTargetBoxColor
        {
            get
            {
                return _sellOnTargetBoxColor;
            }
            set
            {
                _sellOnTargetBoxColor = value;
                OnPropertyChanged("SellOnTargetBoxColor");
            }
        }
        private string _sellOnTargetBoxColor = "White";
        public string SellOnTargetError
        {
            get
            {
                return _sellOnTargetError;
            }
            set
            {
                _sellOnTargetError = value;
                if (value != "")
                {
                    SellOnTargetErrorToolTip = "Error: " + value + "\n\n" + ReturnToolTip("SellOnTarget");
                }
                else
                {
                    SellOnTargetErrorToolTip = ReturnToolTip("SellOnTarget");
                }
                this.SellOnTargetBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorWebFlag = CheckWebFlagsTabColor();
                OnPropertyChanged("SellOnTargetsErrorError");
            }
        }
        private string _sellOnTargetError = string.Empty;
        public string SellOnTargetErrorToolTip
        {
            get
            {
                return _sellOnTargetToolTip;
            }
            set
            {
                this._sellOnTargetToolTip = value;
                OnPropertyChanged("SellOnTargetToolTip");
            }
        }
        private string _sellOnTargetToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the Sell On Trends
        /// </summary>
        public string SellOnTrends
        {
            get
            {
                return this.ItemViewModelItem.SellOnTrends;
            }
            set
            {
                if (this.ItemViewModelItem.SellOnTrends != value)
                {
                    this.ItemViewModelItem.SellOnTrends = value;
                    this.SellOnTrendsError = ItemService.ValidateSellOnValue(value, "Trends");
                    this.TitleError = ItemService.ValidateTitle(this.Title, ItemViewModelItem.HasWeb());
                    this.MetaDescriptionError = ItemService.ValidateMetaDescription(this.MetaDescription, ItemViewModelItem.HasWeb());
                    this.CategoryError = ItemService.ValidateCategory(this.Category, ItemViewModelItem.HasWeb());
                    this.ItemKeywordsError = ItemService.ValidateItemKeywords(this.ItemKeywords, ItemViewModelItem.HasWeb());
                    OnPropertyChanged("SellOnTrends");
                }
            }
        }
        public string SellOnTrendsBoxColor
        {
            get
            {
                return _sellOnTrendsBoxColor;
            }
            set
            {
                _sellOnTrendsBoxColor = value;
                OnPropertyChanged("SellOnTrendsBoxColor");
            }
        }
        private string _sellOnTrendsBoxColor = "White";
        public string SellOnTrendsError
        {
            get
            {
                return _sellOnTrendsError;
            }
            set
            {
                _sellOnTrendsError = value;
                if (value != "")
                {
                    SellOnTrendsToolTip = "Error: " + value + "\n\n" + ReturnToolTip("SellOnTrends");
                }
                else
                {
                    SellOnTrendsToolTip = ReturnToolTip("SellOnTrends");
                }
                this.SellOnTrendsBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorWebFlag = CheckWebFlagsTabColor();
                OnPropertyChanged("SellOnTrendsError");
            }
        }
        private string _sellOnTrendsError = string.Empty;
        public string SellOnTrendsToolTip
        {
            get
            {
                return __sellOnTrendsToolTip;
            }
            set
            {
                this.__sellOnTrendsToolTip = value;
                OnPropertyChanged("SellOnTrendsToolTip");
            }
        }
        private string __sellOnTrendsToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the Sell On Walmart
        /// </summary>
        public string SellOnWalmart
        {
            get
            {
                return this.ItemViewModelItem.SellOnWalmart;
            }
            set
            {
                if (this.ItemViewModelItem.SellOnWalmart != value)
                {
                    this.ItemViewModelItem.SellOnWalmart = value;
                    this.SellOnWalmartError = ItemService.ValidateSellOnValue(value, "Walmart");
                    ValidateEcommerce();
                    OnPropertyChanged("SellOnWalmart");
                }
            }
        }
        public string SellOnWalmartBoxColor
        {
            get
            {
                return _sellOnWalmartBoxColor;
            }
            set
            {
                _sellOnWalmartBoxColor = value;
                OnPropertyChanged("SellOnWalmartBoxColor");
            }
        }
        private string _sellOnWalmartBoxColor = "White";
        public string SellOnWalmartError
        {
            get
            {
                return _sellOnWalmartError;
            }
            set
            {
                _sellOnWalmartError = value;
                if (value != "")
                {
                    SellOnWalmartToolTip = "Error: " + value + "\n\n" + ReturnToolTip("SellOnWalmart");
                }
                else
                {
                    SellOnWalmartToolTip = ReturnToolTip("SellOnWalmart");
                }
                this.SellOnWalmartBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorWebFlag = CheckWebFlagsTabColor();
                OnPropertyChanged("SellOnWalmartError");
            }
        }
        private string _sellOnWalmartError = string.Empty;
        public string SellOnWalmartToolTip
        {
            get
            {
                return __sellOnWalmartToolTip;
            }
            set
            {
                this.__sellOnWalmartToolTip = value;
                OnPropertyChanged("SellOnWalmartToolTip");
            }
        }
        private string __sellOnWalmartToolTip = string.Empty;


        /// <summary>
        ///     Gets or sets the Sell On Wayfair
        /// </summary>
        public string SellOnWayfair
        {
            get
            {
                return this.ItemViewModelItem.SellOnWayfair;
            }
            set
            {
                if (this.ItemViewModelItem.SellOnWayfair != value)
                {
                    this.ItemViewModelItem.SellOnWayfair = value;
                    this.SellOnWayfairError = ItemService.ValidateSellOnValue(value, "Wayfair");
                    ValidateEcommerce();
                    OnPropertyChanged("SellOnWayfair");
                }
            }
        }
        public string SellOnWayfairBoxColor
        {
            get
            {
                return _sellOnWayfairBoxColor;
            }
            set
            {
                _sellOnWayfairBoxColor = value;
                OnPropertyChanged("SellOnWayfairBoxColor");
            }
        }
        private string _sellOnWayfairBoxColor = "White";
        public string SellOnWayfairError
        {
            get
            {
                return _sellOnWayfairError;
            }
            set
            {
                _sellOnWayfairError = value;
                if (value != "")
                {
                    SellOnWayfairToolTip = "Error: " + value + "\n\n" + ReturnToolTip("SellOnWayfair");
                }
                else
                {
                    SellOnWayfairToolTip = ReturnToolTip("SellOnWayfair");
                }
                this.SellOnWayfairBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorWebFlag = CheckWebFlagsTabColor();
                OnPropertyChanged("SellOnWayfairError");
            }
        }
        private string _sellOnWayfairError = string.Empty;
        public string SellOnWayfairToolTip
        {
            get
            {
                return __sellOnWayfairToolTip;
            }
            set
            {
                this.__sellOnWayfairToolTip = value;
                OnPropertyChanged("SellOnWayfairToolTip");
            }
        }
        private string __sellOnWayfairToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the StandardCost value
        /// </summary>
        public string StandardCost
        {
            get
            {
                return this.ItemViewModelItem.StandardCost.ToString();
            }
            set
            {
                if (this.ItemViewModelItem.StandardCost != value)
                {
                    this.ItemViewModelItem.StandardCost = value;
                    this.StandardCostError = ItemService.ValidateStandardCost(value, this.ProdType);
                    OnPropertyChanged("StandardCost");
                }
            }
        }
        public string StandardCostBoxColor
        {
            get
            {
                return _standardCostBoxColor;
            }
            set
            {
                _standardCostBoxColor = value;
                OnPropertyChanged("StandardCostBoxColor");
            }
        }
        private string _standardCostBoxColor = "White";
        public string StandardCostError
        {
            get
            {
                return _standardCostError;
            }
            set
            {
                _standardCostError = value;
                if (value != "")
                {
                    StandardCostToolTip = "Error: " + value + "\n\n" + ReturnToolTip("StandardCost");
                }
                else
                {
                    StandardCostToolTip = ReturnToolTip("StandardCost");
                }
                this.StandardCostBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("StandardCostError");
            }
        }
        private string _standardCostError = string.Empty;
        public string StandardCostToolTip
        {
            get
            {
                return _standardCostToolTip;
            }
            set
            {
                this._standardCostToolTip = value;
                OnPropertyChanged("StandardCostToolTip");
            }
        }
        private string _standardCostToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the StatsCode value
        /// </summary>
        public string StatsCode
        {
            get
            {
                return this.ItemViewModelItem.StatsCode;
            }
            set
            {
                if (this.ItemViewModelItem.StatsCode != value)
                {
                    this.ItemViewModelItem.StatsCode = value;
                    this.StatsCodeError = ItemService.ValidateStatsCode(value, this.ListPriceUsd, this.ProdType);
                    OnPropertyChanged("StatsCode");
                }
            }
        }
        public string StatsCodeBoxColor
        {
            get
            {
                return _statsCodeBoxColor;
            }
            set
            {
                _statsCodeBoxColor = value;
                OnPropertyChanged("StatsCodeBoxColor");
            }
        }
        private string _statsCodeBoxColor = "White";
        public string StatsCodeError
        {
            get
            {
                return _statsCodeError;
            }
            set
            {
                _statsCodeError = value;
                if (value != "")
                {
                    StatsCodeToolTip = "Error: " + value + "\n\n" + ReturnToolTip("StatsCode");
                }
                else
                {
                    StatsCodeToolTip = ReturnToolTip("StatsCode");
                }
                this.StatsCodeBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("StatsCodeError");
            }
        }
        private string _statsCodeError = string.Empty;
        public string StatsCodeToolTip
        {
            get
            {
                return _statsCodeToolTip;
            }
            set
            {
                this._statsCodeToolTip = value;
                OnPropertyChanged("StatsCodeToolTip");
            }
        }
        private string _statsCodeToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the Status value
        /// </summary>
        public string Status
        {
            get
            {
                return this.ItemViewModelItem.Status;
            }
            set
            {
                this.ItemViewModelItem.Status = value;
            }
        }

        /// <summary>
        ///     Gets or sets the TariffCode value
        /// </summary>
        public string TariffCode
        {
            get
            {
                return this.ItemViewModelItem.TariffCode;
            }
            set
            {
                if (this.ItemViewModelItem.TariffCode != value)
                {
                    this.ItemViewModelItem.TariffCode = value;
                    this.TariffCodeError = ItemService.ValidateTariffCode(value, this.ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
        ///     Gets or sets the Territory value
        /// </summary>
        public string Territory
        {
            get
            {
                return this.ItemViewModelItem.Territory;
            }
            set
            {
                if (this.ItemViewModelItem.Territory != value)
                {
                    this.ItemViewModelItem.Territory = DbUtil.OrderTerritory(value);
                    this.TerritoryError = ItemService.ValidateTerritory(DbUtil.OrderTerritory(value), this.ListPriceUsd, this.ProdType);
                    OnPropertyChanged("Territory");
                }
            }
        }
        public string TerritoryBoxColor
        {
            get
            {
                return _territoryBoxColor;
            }
            set
            {
                _territoryBoxColor = value;
                OnPropertyChanged("TerritoryBoxColor");
            }
        }
        private string _territoryBoxColor = "White";
        public string TerritoryError
        {
            get
            {
                return _territoryError;
            }
            set
            {
                _territoryError = value;
                if (value != "")
                {
                    TerritoryToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Territory");
                }
                else
                {
                    TerritoryToolTip = ReturnToolTip("Territory");
                }
                this.TerritoryBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("TerritoryError");
            }
        }
        private string _territoryError = string.Empty;
        public string TerritoryToolTip
        {
            get
            {
                return _territoryToolTip;
            }
            set
            {
                this._territoryToolTip = value;
                OnPropertyChanged("TerritoryToolTip");
            }
        }
        private string _territoryToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the Udex value
        /// </summary>
        public string Udex
        {
            get
            {
                return this.ItemViewModelItem.Udex;
            }
            set
            {
                if (this.ItemViewModelItem.Udex != value)
                {
                    this.ItemViewModelItem.Udex = value;
                    this.UdexError = ItemService.ValidateUdex(value, this.ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
        ///     Gets or sets the Upc value
        /// </summary>
        public string Upc
        {
            get
            {
                return this.ItemViewModelItem.Upc;
            }
            set
            {
                if (this.ItemViewModelItem.Upc != value)
                {
                    this.ItemViewModelItem.Upc = value;
                    this.UpcError = ItemService.ValidateUpc(value, this.ItemId, this.Status, this.ListPriceUsd, this.ProductFormat, this.ProductGroup, this.ProductLine, this.Ean, this.Ecommerce_Upc, this.ProdType);
                    this.ProductFormatError = ItemService.ValidateProductFormat(this.ProductGroup, this.ProductLine, this.ProductFormat, value, this.ProdType);
                    this.ProductGroupError = ItemService.ValidateProductGroup(this.ProductGroup, value, this.ProdType);
                    this.ProductLineError = ItemService.ValidateProductLine(this.ProductGroup, this.ProductLine, value, this.ProdType);
                    OnPropertyChanged("Upc");
                }
            }
        }
        public string UpcBoxColor
        {
            get
            {
                return _upcBoxColor;
            }
            set
            {
                _upcBoxColor = value;
                OnPropertyChanged("UpcBoxColor");
            }
        }
        private string _upcBoxColor = "White";
        public string UpcError
        {
            get
            {
                return _upcError;
            }
            set
            {
                _upcError = value;
                if (value != "")
                {
                    UpcToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Upc");
                }
                else
                {
                    UpcToolTip = ReturnToolTip("Upc");
                }
                this.UpcBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("UpcError");
            }
        }
        private string _upcError = string.Empty;
        public string UpcToolTip
        {
            get
            {
                return _upcToolTip;
            }
            set
            {
                _upcToolTip = value;
                OnPropertyChanged("UpcToolTip");
            }
        }
        private string _upcToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the Weight value
        /// </summary>
        public string Weight
        {
            get
            {
                return this.ItemViewModelItem.Weight;
            }
            set
            {
                if (this.ItemViewModelItem.Weight != value)
                {
                    this.ItemViewModelItem.Weight = value;
                    this.WeightError = ItemService.ValidateWeight(value, this.ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                return this.ItemViewModelItem.Width;
            }
            set
            {
                if (this.ItemViewModelItem.Width != value)
                {
                    this.ItemViewModelItem.Width = value;
                    this.WidthError = ItemService.ValidateWidth(value, this.ProdType);
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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

        /// <summary>
        ///     Gets or sets the copyright
        /// </summary>
        public string Copyright
        {
            get
            {
                return this.ItemViewModelItem.Copyright;
            }
            set
            {
                if (this.ItemViewModelItem.Copyright != value)
                {
                    this.ItemViewModelItem.Copyright = value;
                    this.CopyrightError = ItemService.ValidateCopyright(value);
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
                this.TabColorWebInfo = CheckWebInfoTabColor();
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

        /// <summary>
        ///     Gets or sets the in stock date
        /// </summary>
        public string InStockDate
        {
            get
            {
                return this.ItemViewModelItem.InStockDate;
            }
            set
            {
                if (this.ItemViewModelItem.InStockDate != value)
                {
                    this.ItemViewModelItem.InStockDate = value;
                    this.InStockDateError = ItemService.ValidateInStockDate(value);
                    OnPropertyChanged("InStockDate");
                }
            }
        }
        public string InStockDateBoxColor
        {
            get
            {
                return _inStockDateBoxColor;
            }
            set
            {
                _inStockDateBoxColor = value;
                OnPropertyChanged("InStockDateBoxColor");
            }
        }
        private string _inStockDateBoxColor = "White";
        public string InStockDateError
        {
            get
            {
                return _inStockDateError;
            }
            set
            {
                _inStockDateError = value;
                if (value != "")
                {
                    InStockDateToolTip = "Error: " + value + "\n\n" + ReturnToolTip("InStockDate");
                }
                else
                {
                    InStockDateToolTip = ReturnToolTip("InStockDate");
                }
                this.InStockDateBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorWebInfo = CheckWebInfoTabColor();
                OnPropertyChanged("InStockDateError");
            }
        }
        private string _inStockDateError = string.Empty;
        public string InStockDateToolTip
        {
            get
            {
                return _inStockDateToolTip;
            }
            set
            {
                this._inStockDateToolTip = value;
                OnPropertyChanged("InStockDateToolTip");
            }
        }
        private string _inStockDateToolTip = string.Empty;

        /// <summary>
        ///     Gets or set the category
        /// </summary>
        public string Category
        {
            get
            {
                return this.ItemViewModelItem.Category;
            }
            set
            {
                if (this.ItemViewModelItem.Category != value)
                {
                    this.ItemViewModelItem.Category = value;
                    this.CategoryError = ItemService.ValidateCategory(value, this.ItemViewModelItem.HasWeb());
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
                this.TabColorWebInfo = CheckWebInfoTabColor();
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

        /// <summary>
        ///     Gets or sets the category 2
        /// </summary>
        public string Category2
        {
            get
            {
                return this.ItemViewModelItem.Category2;
            }
            set
            {
                if (this.ItemViewModelItem.Category2 != value)
                {
                    this.ItemViewModelItem.Category2 = value;
                    this.Category2Error = ItemService.ValidateCategory2(value, "2");
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
                this.TabColorWebInfo = CheckWebInfoTabColor();
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

        /// <summary>
        ///     Gets or sets the category 3
        /// </summary>
        public string Category3
        {
            get
            {
                return this.ItemViewModelItem.Category3;
            }
            set
            {
                if (this.ItemViewModelItem.Category3 != value)
                {
                    this.ItemViewModelItem.Category3 = value;
                    this.Category3Error = ItemService.ValidateCategory2(value, "3");
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
                this.TabColorWebInfo = CheckWebInfoTabColor();
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

        /// <summary>
        ///     Gets or sets the item keywords
        /// </summary>
        public string ItemKeywords
        {
            get
            {
                return this.ItemViewModelItem.ItemKeywords;
            }
            set
            {
                if (this.ItemViewModelItem.ItemKeywords != value)
                {
                    this.ItemViewModelItem.ItemKeywords = value;
                    this.ItemKeywordsError = ItemService.ValidateItemKeywords(value, this.ItemViewModelItem.HasWeb());
                    OnPropertyChanged("ItemKeywords");
                }
            }
        }
        public string ItemKeywordsBoxColor
        {
            get
            {
                return _itemKeywordsBoxColor;
            }
            set
            {
                _itemKeywordsBoxColor = value;
                OnPropertyChanged("ItemKeywordsBoxColor");
            }
        }
        private string _itemKeywordsBoxColor = "White";
        public string ItemKeywordsError
        {
            get
            {
                return _itemKeywordsError;
            }
            set
            {
                _itemKeywordsError = value;
                if (value != "")
                {
                    ItemKeywordsToolTip = "Error: " + value + "\n\n" + ReturnToolTip("ItemKeywords");
                }
                else
                {
                    ItemKeywordsToolTip = ReturnToolTip("ItemKeywords");
                }
                this.ItemKeywordsBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorWebInfo = CheckWebInfoTabColor();
                OnPropertyChanged("ItemKeywordsError");
            }
        }
        private string _itemKeywordsError = string.Empty;
        public string ItemKeywordsToolTip
        {
            get
            {
                return _itemKeywordsErrorToolTip;
            }
            set
            {
                this._itemKeywordsErrorToolTip = value;
                OnPropertyChanged("ItemKeywordsToolTip");
            }
        }
        private string _itemKeywordsErrorToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the title
        /// </summary>
        public string Title
        {
            get
            {
                return this.ItemViewModelItem.Title;
            }
            set
            {
                if (this.ItemViewModelItem.Title != value)
                {
                    this.ItemViewModelItem.Title = value;
                    this.TitleError = ItemService.ValidateTitle(value, this.ItemViewModelItem.HasWeb());
                    OnPropertyChanged("Title");
                }
            }
        }
        public string TitleBoxColor
        {
            get
            {
                return _titleBoxColor;
            }
            set
            {
                _titleBoxColor = value;
                OnPropertyChanged("TitleBoxColor");
            }
        }
        private string _titleBoxColor = "White";
        public string TitleError
        {
            get
            {
                return _titleError;
            }
            set
            {
                _titleError = value;
                if (value != "")
                {
                    TitleToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Title");
                }
                else
                {
                    TitleToolTip = ReturnToolTip("Title");
                }
                this.TitleBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorWebInfo = CheckWebInfoTabColor();
                OnPropertyChanged("TitleError");
            }
        }
        private string _titleError = string.Empty;
        public string TitleToolTip
        {
            get
            {
                return _titleToolTip;
            }
            set
            {
                this._titleToolTip = value;
                OnPropertyChanged("TitleToolTip");
            }
        }
        private string _titleToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the license
        /// </summary>
        public string License
        {
            get
            {
                return this.ItemViewModelItem.License;
            }
            set
            {
                if (this.ItemViewModelItem.License != value)
                {
                    this.ItemViewModelItem.License = value;
                    RefreshPropertyList(value);
                    this.LicenseError = ItemService.ValidateLicense(value);
                    this.PropertyError = ItemService.ValidateProperty(this.Property, value);
                    OnPropertyChanged("License");
                }
            }
        }
        public string LicenseBoxColor
        {
            get
            {
                return _licenseBoxColor;
            }
            set
            {
                _licenseBoxColor = value;
                OnPropertyChanged("LicenseBoxColor");
            }
        }
        private string _licenseBoxColor = "White";
        public string LicenseError
        {
            get
            {
                return _licenseError;
            }
            set
            {
                _licenseError = value;
                if (value != "")
                {
                    LicenseToolTip = "Error: " + value + "\n\n" + ReturnToolTip("License");
                }
                else
                {
                    LicenseToolTip = ReturnToolTip("License");
                }
                this.LicenseBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorWebInfo = CheckWebInfoTabColor();
                OnPropertyChanged("LicenseError");
            }
        }
        private string _licenseError = string.Empty;
        public string LicenseToolTip
        {
            get
            {
                return _licenseToolTip;
            }
            set
            {
                this._licenseToolTip = value;
                OnPropertyChanged("LicenseToolTip");
            }
        }
        private string _licenseToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the meta description
        /// </summary>
        public string MetaDescription
        {
            get
            {
                return this.ItemViewModelItem.MetaDescription;
            }
            set
            {
                if (this.ItemViewModelItem.MetaDescription != value)
                {
                    this.ItemViewModelItem.MetaDescription = value;
                    this.MetaDescriptionError = ItemService.ValidateMetaDescription(value, this.ItemViewModelItem.HasWeb());
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
                this.TabColorWebInfo = CheckWebInfoTabColor();
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

        /// <summary>
        ///     Gets or sets the property
        /// </summary>
        public string Property
        {
            get
            {
                return this.ItemViewModelItem.Property;
            }
            set
            {
                if (this.ItemViewModelItem.Property != value)
                {
                    this.ItemViewModelItem.Property = value;
                    this.PropertyError = ItemService.ValidateProperty(value, this.License);
                    OnPropertyChanged("Property");
                }
            }
        }
        public string PropertyBoxColor
        {
            get
            {
                return _propertyBoxColor;
            }
            set
            {
                _propertyBoxColor = value;
                OnPropertyChanged("PropertyBoxColor");
            }
        }
        private string _propertyBoxColor = "White";
        public string PropertyError
        {
            get
            {
                return _propertyError;
            }
            set
            {
                _propertyError = value;
                if (value != "")
                {
                    PropertyToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Property");
                }
                else
                {
                    PropertyToolTip = ReturnToolTip("Property");
                }
                this.PropertyBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorWebInfo = CheckWebInfoTabColor();
                OnPropertyChanged("PropertyError");
            }
        }
        private string _propertyError = string.Empty;
        public string PropertyToolTip
        {
            get
            {
                return _propertyToolTip;
            }
            set
            {
                this._propertyToolTip = value;
                OnPropertyChanged("PropertyToolTip");
            }
        }
        private string _propertyToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the short description
        /// </summary>
        public string ShortDescription
        {
            get
            {
                return this.ItemViewModelItem.ShortDescription;
            }
            set
            {
                if (this.ItemViewModelItem.ShortDescription != value)
                {
                    this.ItemViewModelItem.ShortDescription = value;
                    this.ShortDescriptionError = ItemService.ValidateShortDescription(value);
                    OnPropertyChanged("ShortDescription");
                }
            }
        }
        public string ShortDescriptionBoxColor
        {
            get
            {
                return _shortDescriptionBoxColor;
            }
            set
            {
                _shortDescriptionBoxColor = value;
                OnPropertyChanged("ShortDescriptionBoxColor");
            }
        }
        private string _shortDescriptionBoxColor = "White";
        public string ShortDescriptionError
        {
            get
            {
                return _shortDescriptionError;
            }
            set
            {
                _shortDescriptionError = value;
                if (value != "")
                {
                    ShortDescriptionToolTip = "Error: " + value + "\n\n" + ReturnToolTip("ShortDescription");
                }
                else
                {
                    ShortDescriptionToolTip = ReturnToolTip("ShortDescription");
                }
                this.ShortDescriptionBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorWebInfo = CheckWebInfoTabColor();
                OnPropertyChanged("ShortDescriptionError");
            }
        }
        private string _shortDescriptionError = string.Empty;
        public string ShortDescriptionToolTip
        {
            get
            {
                return _shortDescriptionToolTip;
            }
            set
            {
                this._shortDescriptionToolTip = value;
                OnPropertyChanged("ShortDescriptionToolTip");
            }
        }
        private string _shortDescriptionToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the size
        /// </summary>
        public string Size
        {
            get
            {
                return this.ItemViewModelItem.Size;
            }
            set
            {
                if (this.ItemViewModelItem.Size != value)
                {
                    this.ItemViewModelItem.Size = value;
                    this.SizeError = ItemService.ValidateSize(value);
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
                this.TabColorWebInfo = CheckWebInfoTabColor();
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

        /// <summary>
        ///     Gets or sets the websitePrice
        /// </summary>
        public string WebsitePrice
        {
            get
            {
                return this.ItemViewModelItem.WebsitePrice;
            }
            set
            {
                if (this.ItemViewModelItem.WebsitePrice != value)
                {
                    this.ItemViewModelItem.WebsitePrice = value;
                    this.WebsitePriceError = ItemService.ValidateWebsitePrice(value, this.ItemViewModelItem.HasWeb());
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
                this.TabColorWebInfo = CheckWebInfoTabColor();
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

        #region Image Properties

        /// <summary>
        ///     Gets or sets the Alt Image File 1
        /// </summary>
        public string AltImageFile1
        {
            get
            {
                return this.ItemViewModelItem.AltImageFile1;
            }
            set
            {
                if (this.ItemViewModelItem.AltImageFile1 != value)
                {
                    this.ItemViewModelItem.AltImageFile1 = value;
                    this.Ecommerce_ImagePath2 = ItemViewModelItem.Ecommerce_ImagePath2;
                    this.AltImageFile1Error = ItemService.ValidateImagePath(value, "Image Path 2", false);
                    SetImages();
                    OnPropertyChanged("AltImageFile1");
                }
            }
        }
        public string AltImageFile1BoxColor
        {
            get
            {
                return _AltImageFile1BoxColor;
            }
            set
            {
                _AltImageFile1BoxColor = value;
                OnPropertyChanged("AltImageFile1BoxColor");
            }
        }
        private string _AltImageFile1BoxColor = "White";
        public string AltImageFile1Error
        {
            get
            {
                return _AltImageFile1Error;
            }
            set
            {
                _AltImageFile1Error = value;
                if (value != "")
                {
                    AltImageFile1ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("AltImageFile1ToolTip");
                }
                else
                {
                    AltImageFile1ToolTip = ReturnToolTip("AltImageFile1ToolTip");
                }
                this.AltImageFile1BoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorImagePath = CheckImagePathTabColor();
                OnPropertyChanged("AltImageFile1Error");
            }
        }
        private string _AltImageFile1Error = string.Empty;
        public string AltImageFile1ToolTip
        {
            get
            {
                return _AltImageFile1ToolTip;
            }
            set
            {
                this._AltImageFile1ToolTip = value;
                OnPropertyChanged("AltImageFile1ToolTip");
            }
        }
        private string _AltImageFile1ToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the Alt Image File 2
        /// </summary>
        public string AltImageFile2
        {
            get
            {
                return this.ItemViewModelItem.AltImageFile2;
            }
            set
            {
                if (this.ItemViewModelItem.AltImageFile2 != value)
                {
                    this.ItemViewModelItem.AltImageFile2 = value;
                    this.Ecommerce_ImagePath3 = ItemViewModelItem.Ecommerce_ImagePath3;
                    this.AltImageFile2Error = ItemService.ValidateImagePath(value, "Image Path 3", false);
                    SetImages();
                    OnPropertyChanged("AltImageFile2");
                }
            }
        }
        public string AltImageFile2BoxColor
        {
            get
            {
                return _AltImageFile2BoxColor;
            }
            set
            {
                _AltImageFile2BoxColor = value;
                OnPropertyChanged("AltImageFile2BoxColor");
            }
        }
        private string _AltImageFile2BoxColor = "White";
        public string AltImageFile2Error
        {
            get
            {
                return _AltImageFile2Error;
            }
            set
            {
                _AltImageFile2Error = value;
                if (value != "")
                {
                    AltImageFile2ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("AltImageFile2ToolTip");
                }
                else
                {
                    AltImageFile2ToolTip = ReturnToolTip("AltImageFile2ToolTip");
                }
                this.AltImageFile2BoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorImagePath = CheckImagePathTabColor();
                OnPropertyChanged("AltImageFile2Error");
            }
        }
        private string _AltImageFile2Error = string.Empty;
        public string AltImageFile2ToolTip
        {
            get
            {
                return _AltImageFile2ToolTip;
            }
            set
            {
                this._AltImageFile2ToolTip = value;
                OnPropertyChanged("AltImageFile2ToolTip");
            }
        }
        private string _AltImageFile2ToolTip = string.Empty;
        
        /// <summary>
        ///     Gets or sets the Alt Image File 3
        /// </summary>
        public string AltImageFile3
        {
            get
            {
                return this.ItemViewModelItem.AltImageFile3;
            }
            set
            {
                if (this.ItemViewModelItem.AltImageFile3 != value)
                {
                    this.ItemViewModelItem.AltImageFile3 = value;
                    this.Ecommerce_ImagePath4 = ItemViewModelItem.Ecommerce_ImagePath4;
                    this.AltImageFile3Error = ItemService.ValidateImagePath(value, "Image Path 4", false);
                    SetImages();
                    OnPropertyChanged("AltImageFile3");
                }
            }
        }
        public string AltImageFile3BoxColor
        {
            get
            {
                return _AltImageFile3BoxColor;
            }
            set
            {
                _AltImageFile3BoxColor = value;
                OnPropertyChanged("AltImageFile3BoxColor");
            }
        }
        private string _AltImageFile3BoxColor = "White";
        public string AltImageFile3Error
        {
            get
            {
                return _AltImageFile3Error;
            }
            set
            {
                _AltImageFile3Error = value;
                if (value != "")
                {
                    AltImageFile3ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("AltImageFile3ToolTip");
                }
                else
                {
                    AltImageFile3ToolTip = ReturnToolTip("AltImageFile3ToolTip");
                }
                this.AltImageFile3BoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorImagePath = CheckImagePathTabColor();
                OnPropertyChanged("AltImageFile3Error");
            }
        }
        private string _AltImageFile3Error = string.Empty;
        public string AltImageFile3ToolTip
        {
            get
            {
                return _AltImageFile3ToolTip;
            }
            set
            {
                this._AltImageFile3ToolTip = value;
                OnPropertyChanged("AltImageFile3ToolTip");
            }
        }
        private string _AltImageFile3ToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the Alt Image File 4
        /// </summary>
        public string AltImageFile4
        {
            get
            {
                return this.ItemViewModelItem.AltImageFile4;
            }
            set
            {
                if (this.ItemViewModelItem.AltImageFile4 != value)
                {
                    this.ItemViewModelItem.AltImageFile4 = value;
                    this.Ecommerce_ImagePath5 = ItemViewModelItem.Ecommerce_ImagePath5;
                    this.AltImageFile4Error = ItemService.ValidateImagePath(value, "Image Path 5", false);
                    SetImages();
                    OnPropertyChanged("AltImageFile4");
                }
            }
        }
        public string AltImageFile4BoxColor
        {
            get
            {
                return _AltImageFile4BoxColor;
            }
            set
            {
                _AltImageFile4BoxColor = value;
                OnPropertyChanged("AltImageFile4BoxColor");
            }
        }
        private string _AltImageFile4BoxColor = "White";
        public string AltImageFile4Error
        {
            get
            {
                return _AltImageFile4Error;
            }
            set
            {
                _AltImageFile4Error = value;
                if (value != "")
                {
                    AltImageFile4ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("AltImageFile4ToolTip");
                }
                else
                {
                    AltImageFile4ToolTip = ReturnToolTip("AltImageFile4ToolTip");
                }
                this.AltImageFile4BoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorImagePath = CheckImagePathTabColor();
                OnPropertyChanged("AltImageFile4Error");
            }
        }
        private string _AltImageFile4Error = string.Empty;
        public string AltImageFile4ToolTip
        {
            get
            {
                return _AltImageFile4ToolTip;
            }
            set
            {
                this._AltImageFile4ToolTip = value;
                OnPropertyChanged("AltImageFile4ToolTip");
            }
        }
        private string _AltImageFile4ToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the image path
        /// </summary>
        public string ImagePath
        {
            get
            {
                return this.ItemViewModelItem.ImagePath;
            }
            set
            {
                if (this.ItemViewModelItem.ImagePath != value)
                {
                    this.ItemViewModelItem.ImagePath = value;
                    this.Ecommerce_ImagePath1 = ItemViewModelItem.Ecommerce_ImagePath1;
                    this.ImagePathError = ItemService.ValidateImagePath(value, "Image Path", true);
                    SetImages();
                    OnPropertyChanged("ImagePath");
                }
            }
        }
        public string ImagePathBoxColor
        {
            get
            {
                return _ImagePathBoxColor;
            }
            set
            {
                _ImagePathBoxColor = value;
                OnPropertyChanged("ImagePathBoxColor");
            }
        }
        private string _ImagePathBoxColor = "White";
        public string ImagePathError
        {
            get
            {
                return _ImagePathError;
            }
            set
            {
                _ImagePathError = value;
                if (value != "")
                {
                    ImagePathToolTip = "Error: " + value + "\n\n" + ReturnToolTip("ImagePathToolTip");
                }
                else
                {
                    ImagePathToolTip = ReturnToolTip("ImagePathToolTip");
                }
                this.ImagePathBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorImagePath = CheckImagePathTabColor();
                OnPropertyChanged("ImagePathError");
            }
        }
        private string _ImagePathError = string.Empty;
        public string ImagePathToolTip
        {
            get
            {
                return _ImagePathToolTip;
            }
            set
            {
                this._ImagePathToolTip = value;
                OnPropertyChanged("ImagePathToolTip");
            }
        }
        private string _ImagePathToolTip = string.Empty;

        #endregion // Image Properties

        #region Ecommerce Properties

        /// <summary>
        ///     Ecommerce_Asin
        /// </summary>
        public string Ecommerce_Asin
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_Asin;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_Asin != value)
                {
                    this.ItemViewModelItem.Ecommerce_Asin = value;
                    this.Ecommerce_AsinError = ItemService.ValidateEcommerce_Asin(value);
                    OnPropertyChanged("Ecommerce_Asin");
                }
            }
        }
        public string Ecommerce_AsinBoxColor
        {
            get
            {
                return _ecommerce_asinBoxColor;
            }
            set
            {
                _ecommerce_asinBoxColor = value;
                OnPropertyChanged("Ecomemrce_AsinBoxColor");
            }
        }
        private string _ecommerce_asinBoxColor = "White";
        public string Ecommerce_AsinError
        {
            get
            {
                return _ecommerce_asinError;
            }
            set
            {
                _ecommerce_asinError = value;
                if(value != "")
                {
                    Ecommerce_AsinToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_AsinToolTip");
                }
                else
                {
                    Ecommerce_AsinToolTip = ReturnToolTip("Ecommerce_AsinToolTip");
                }
                this.Ecommerce_AsinBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_AsinError");
            }
        }
        private string _ecommerce_asinError = string.Empty;
        public string Ecommerce_AsinToolTip
        {
            get
            {
                return _ecommerce_AsinToolTip;
            }
            set
            {
                this._ecommerce_AsinToolTip = value;
                OnPropertyChanged("Ecommerce_AsinToolTip");
            }
        }
        private string _ecommerce_AsinToolTip = string.Empty;

        /// <summary>
        ///     Ecommerce_Bullet1
        /// </summary>
        public string Ecommerce_Bullet1
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_Bullet1;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_Bullet1 != value)
                {
                    this.ItemViewModelItem.Ecommerce_Bullet1 = value;
                    this.Ecommerce_Bullet1Error = ItemService.ValidateEcommerce_Bullet(value, "1", ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_Bullet1");
                }
            }
        }
        public string Ecommerce_Bullet1BoxColor
        {
            get
            {
                return _ecommerce_bullet1BoxColor;
            }
            set
            {
                _ecommerce_bullet1BoxColor = value;
                OnPropertyChanged("Ecommerce_Bullet1BoxColor");
            }
        }
        private string _ecommerce_bullet1BoxColor = "White";
        public string Ecommerce_Bullet1Error
        {
            get
            {
                return _ecommerce_bullet1Error;
            }
            set
            {
                _ecommerce_bullet1Error = value;
                if (value != "")
                {
                    Ecommerce_Bullet1ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_BulletToolTip");
                }
                else
                {
                    Ecommerce_Bullet1ToolTip = ReturnToolTip("Ecommerce_BulletToolTip");
                }
                this.Ecommerce_Bullet1BoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_Bullet1Error");
            }
        }
        private string _ecommerce_bullet1Error = string.Empty;
        public string Ecommerce_Bullet1ToolTip
        {
            get
            {
                return _ecommerce_bullet1ToolTip;
            }
            set
            {
                this._ecommerce_bullet1ToolTip = value;
                OnPropertyChanged("Ecommerce_Bullet1ToolTip");
            }
        }
        private string _ecommerce_bullet1ToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_Bullet2
        /// </summary>
        public string Ecommerce_Bullet2
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_Bullet2;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_Bullet2 != value)
                {
                    this.ItemViewModelItem.Ecommerce_Bullet2 = value;
                    this.Ecommerce_Bullet2Error = ItemService.ValidateEcommerce_Bullet(value, "2", ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_Bullet2");
                }
            }
        }
        public string Ecommerce_Bullet2BoxColor
        {
            get
            {
                return _ecommerce_bullet2BoxColor;
            }
            set
            {
                _ecommerce_bullet2BoxColor = value;
                OnPropertyChanged("Ecommerce_Bullet2BoxColor");
            }
        }
        private string _ecommerce_bullet2BoxColor = "White";
        public string Ecommerce_Bullet2Error
        {
            get
            {
                return _ecommerce_bullet2Error;
            }
            set
            {
                _ecommerce_bullet2Error = value;
                if (value != "")
                {
                    Ecommerce_Bullet2ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_BulletToolTip");
                }
                else
                {
                    Ecommerce_Bullet2ToolTip = ReturnToolTip("Ecommerce_BulletToolTip");
                }
                this.Ecommerce_Bullet2BoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_Bullet2Error");
            }
        }
        private string _ecommerce_bullet2Error = string.Empty;
        public string Ecommerce_Bullet2ToolTip
        {
            get
            {
                return _ecommerce_bullet2ToolTip;
            }
            set
            {
                this._ecommerce_bullet2ToolTip = value;
                OnPropertyChanged("Ecommerce_Bullet2ToolTip");
            }
        }
        private string _ecommerce_bullet2ToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_Bullet3
        /// </summary>
        public string Ecommerce_Bullet3
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_Bullet3;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_Bullet3 != value)
                {
                    this.ItemViewModelItem.Ecommerce_Bullet3 = value;
                    this.Ecommerce_Bullet3Error = ItemService.ValidateEcommerce_Bullet(value, "3", ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_Bullet3");
                }
            }
        }
        public string Ecommerce_Bullet3BoxColor
        {
            get
            {
                return _ecommerce_bullet3BoxColor;
            }
            set
            {
                _ecommerce_bullet3BoxColor = value;
                OnPropertyChanged("Ecommerce_Bullet3BoxColor");
            }
        }
        private string _ecommerce_bullet3BoxColor = "White";
        public string Ecommerce_Bullet3Error
        {
            get
            {
                return _ecommerce_bullet3Error;
            }
            set
            {
                _ecommerce_bullet3Error = value;
                if (value != "")
                {
                    Ecommerce_Bullet3ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_BulletToolTip");
                }
                else
                {
                    Ecommerce_Bullet3ToolTip = ReturnToolTip("Ecommerce_BulletToolTip");
                }
                this.Ecommerce_Bullet3BoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_Bullet3Error");
            }
        }
        private string _ecommerce_bullet3Error = string.Empty;
        public string Ecommerce_Bullet3ToolTip
        {
            get
            {
                return _ecommerce_bullet3ToolTip;
            }
            set
            {
                this._ecommerce_bullet3ToolTip = value;
                OnPropertyChanged("Ecommerce_Bullet3ToolTip");
            }
        }
        private string _ecommerce_bullet3ToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_Bullet4
        /// </summary>
        public string Ecommerce_Bullet4
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_Bullet4;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_Bullet4 != value)
                {
                    this.ItemViewModelItem.Ecommerce_Bullet4 = value;
                    this.Ecommerce_Bullet4Error = ItemService.ValidateEcommerce_Bullet(value, "4", false);
                    OnPropertyChanged("Ecommerce_Bullet4");
                }
            }
        }
        public string Ecommerce_Bullet4BoxColor
        {
            get
            {
                return _ecommerce_bullet4BoxColor;
            }
            set
            {
                _ecommerce_bullet4BoxColor = value;
                OnPropertyChanged("Ecommerce_Bullet4BoxColor");
            }
        }
        private string _ecommerce_bullet4BoxColor = "White";
        public string Ecommerce_Bullet4Error
        {
            get
            {
                return _ecommerce_bullet4Error;
            }
            set
            {
                _ecommerce_bullet4Error = value;
                if (value != "")
                {
                    Ecommerce_Bullet4ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_BulletToolTip");
                }
                else
                {
                    Ecommerce_Bullet4ToolTip = ReturnToolTip("Ecommerce_BulletToolTip");
                }
                this.Ecommerce_Bullet4BoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_Bullet4Error");
            }
        }
        private string _ecommerce_bullet4Error = string.Empty;
        public string Ecommerce_Bullet4ToolTip
        {
            get
            {
                return _ecommerce_bullet4ToolTip;
            }
            set
            {
                this._ecommerce_bullet4ToolTip = value;
                OnPropertyChanged("Ecommerce_Bullet4ToolTip");
            }
        }
        private string _ecommerce_bullet4ToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_Bullet5
        /// </summary>
        public string Ecommerce_Bullet5
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_Bullet5;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_Bullet5 != value)
                {
                    this.ItemViewModelItem.Ecommerce_Bullet5 = value;
                    this.Ecommerce_Bullet5Error = ItemService.ValidateEcommerce_Bullet(value, "5", false);
                    OnPropertyChanged("Ecommerce_Bullet5");
                }
            }
        }
        public string Ecommerce_Bullet5BoxColor
        {
            get
            {
                return _ecommerce_bullet5BoxColor;
            }
            set
            {
                _ecommerce_bullet5BoxColor = value;
                OnPropertyChanged("Ecommerce_Bullet5BoxColor");
            }
        }
        private string _ecommerce_bullet5BoxColor = "White";
        public string Ecommerce_Bullet5Error
        {
            get
            {
                return _ecommerce_bullet5Error;
            }
            set
            {
                _ecommerce_bullet5Error = value;
                if (value != "")
                {
                    Ecommerce_Bullet5ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_BulletToolTip");
                }
                else
                {
                    Ecommerce_Bullet5ToolTip = ReturnToolTip("Ecommerce_BulletToolTip");
                }
                this.Ecommerce_Bullet5BoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_Bullet5Error");
            }
        }
        private string _ecommerce_bullet5Error = string.Empty;
        public string Ecommerce_Bullet5ToolTip
        {
            get
            {
                return _ecommerce_bullet5ToolTip;
            }
            set
            {
                this._ecommerce_bullet5ToolTip = value;
                OnPropertyChanged("Ecommerce_Bullet5ToolTip");
            }
        }
        private string _ecommerce_bullet5ToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_Components
        /// </summary>
        public string Ecommerce_Components
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_Components;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_Components != value)
                {
                    this.ItemViewModelItem.Ecommerce_Components = value;
                    this.Ecommerce_ComponentsError = ItemService.ValidateEcommerce_Components(value, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_Components");
                }
            }
        }
        public string Ecommerce_ComponentsBoxColor
        {
            get
            {
                return _ecommerce_componentsBoxColor;
            }
            set
            {
                _ecommerce_componentsBoxColor = value;
                OnPropertyChanged("Ecommerce_ComponentsBoxColor");
            }
        }
        private string _ecommerce_componentsBoxColor = "White";
        public string Ecommerce_ComponentsError
        {
            get
            {
                return _ecommerce_componentsError;
            }
            set
            {
                _ecommerce_componentsError = value;
                if (value != "")
                {
                    Ecommerce_ComponentsToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_ComponentsToolTip");
                }
                else
                {
                    Ecommerce_ComponentsToolTip = ReturnToolTip("Ecommerce_ComponentsToolTip");
                }
                this.Ecommerce_ComponentsBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_ComponentsError");
            }
        }
        private string _ecommerce_componentsError = string.Empty;
        public string Ecommerce_ComponentsToolTip
        {
            get
            {
                return _ecommerce_componentsToolTip;
            }
            set
            {
                this._ecommerce_componentsToolTip = value;
                OnPropertyChanged("Ecommerce_ComponentsToolTip");
            }
        }
        private string _ecommerce_componentsToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_Cost
        /// </summary>
        public string Ecommerce_Cost
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_Cost;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_Cost != value)
                {
                    this.ItemViewModelItem.Ecommerce_Cost = value;
                    this.Ecommerce_CostError = ItemService.ValidateEcommerce_Cost(value, "",this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_Cost");
                }
            }
        }
        public string Ecommerce_CostBoxColor
        {
            get
            {
                return _ecommerce_CostBoxColor;
            }
            set
            {
                _ecommerce_CostBoxColor = value;
                OnPropertyChanged("Ecommerce_CostBoxColor");
            }
        }
        private string _ecommerce_CostBoxColor = "White";
        public string Ecommerce_CostError
        {
            get
            {
                return _ecommerce_CostError;
            }
            set
            {
                _ecommerce_CostError = value;
                if (value != "")
                {
                    Ecommerce_CostToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_CostToolTip");
                }
                else
                {
                    Ecommerce_CostToolTip = ReturnToolTip("Ecommerce_CostToolTip");
                }
                this.Ecommerce_CostBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_CostError");
            }
        }
        private string _ecommerce_CostError = string.Empty;
        public string Ecommerce_CostToolTip
        {
            get
            {
                return _ecommerce_CostToolTip;
            }
            set
            {
                this._ecommerce_CostToolTip = value;
                OnPropertyChanged("Ecommerce_CostToolTip");
            }
        }
        private string _ecommerce_CostToolTip = string.Empty;
       
        /// <summary>
        ///    Ecommerce_ExternalId
        /// </summary>
        public string Ecommerce_ExternalId
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_ExternalId;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_ExternalId != value)
                {
                    this.ItemViewModelItem.Ecommerce_ExternalId = value;
                    this.Ecommerce_ExternalIdError = ItemService.ValidateEcommerce_ExternalId(value, this.Ecommerce_ExternalIdType, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_ExternalId");
                }
            }
        }
        public string Ecommerce_ExternalIdBoxColor
        {
            get
            {
                return _ecommerce_ExternalIDBoxColor;
            }
            set
            {
                _ecommerce_ExternalIDBoxColor = value;
                OnPropertyChanged("Ecommerce_ExternalIdBoxColor");
            }
        }
        private string _ecommerce_ExternalIDBoxColor = "White";
        public string Ecommerce_ExternalIdError
        {
            get
            {
                return _ecommerce_ExternalIDError;
            }
            set
            {
                _ecommerce_ExternalIDError = value;
                if (value != "")
                {
                    Ecommerce_ExternalIdToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_ExternalIdToolTip");
                }
                else
                {
                    Ecommerce_ExternalIdToolTip = ReturnToolTip("Ecommerce_ExternalIdToolTip");
                }
                this.Ecommerce_ExternalIdBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_ExternalIdError");
            }
        }
        private string _ecommerce_ExternalIDError = string.Empty;
        public string Ecommerce_ExternalIdToolTip
        {
            get
            {
                return _ecommerce_ExternalIDToolTip;
            }
            set
            {
                this._ecommerce_ExternalIDToolTip = value;
                OnPropertyChanged("Ecommerce_ExternalIdToolTip");
            }
        }
        private string _ecommerce_ExternalIDToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_ExternalIdType
        /// </summary>
        public string Ecommerce_ExternalIdType
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_ExternalIdType;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_ExternalIdType != value)
                {
                    this.ItemViewModelItem.Ecommerce_ExternalIdType = value;
                    this.Ecommerce_ExternalIdTypeError = ItemService.ValidateEcommerce_ExternalIdType(value, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_ExternalIdType");
                }
            }
        }
        public string Ecommerce_ExternalIdTypeBoxColor
        {
            get
            {
                return _ecommerce_ExternalIdTypeBoxColor;
            }
            set
            {
                _ecommerce_ExternalIdTypeBoxColor = value;
                OnPropertyChanged("Ecommerce_ExternalIdTypeBoxColor");
            }
        }
        private string _ecommerce_ExternalIdTypeBoxColor = "White";
        public string Ecommerce_ExternalIdTypeError
        {
            get
            {
                return _ecommerce_ExternalIdTypeError;
            }
            set
            {
                _ecommerce_ExternalIdTypeError = value;
                if (value != "")
                {
                    Ecommerce_ExternalIdTypeToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_ExternalIdTypeToolTip");
                }
                else
                {
                    Ecommerce_ExternalIdTypeToolTip = ReturnToolTip("Ecommerce_ExternalIdTypeToolTip");
                }
                this.Ecommerce_ExternalIdTypeBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_ExternalIdTypeError");
            }
        }
        private string _ecommerce_ExternalIdTypeError = string.Empty;
        public string Ecommerce_ExternalIdTypeToolTip
        {
            get
            {
                return _ecommerce_ExternalIdTypeToolTip;
            }
            set
            {
                this._ecommerce_ExternalIdTypeToolTip = value;
                OnPropertyChanged("Ecommerce_ExternalIdTypeToolTip");
            }
        }
        private string _ecommerce_ExternalIdTypeToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_ImagePath1
        /// </summary>
        public string Ecommerce_ImagePath1
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_ImagePath1;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_ImagePath1 != value)
                {
                    this.ItemViewModelItem.Ecommerce_ImagePath1 = value;
                    OnPropertyChanged("Ecommerce_ImagePath1");
                }
            }
        }

        /// <summary>
        ///    Ecommerce_ImagePath2
        /// </summary>
        public string Ecommerce_ImagePath2
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_ImagePath2;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_ImagePath2 != value)
                {
                    this.ItemViewModelItem.Ecommerce_ImagePath2 = value;
                    OnPropertyChanged("Ecommerce_ImagePath2");
                }
            }
        }

        /// <summary>
        ///    Ecommerce_ImagePath3
        /// </summary>
        public string Ecommerce_ImagePath3
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_ImagePath3;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_ImagePath3 != value)
                {
                    this.ItemViewModelItem.Ecommerce_ImagePath3 = value;
                    OnPropertyChanged("Ecommerce_ImagePath3");
                }
            }
        }

        /// <summary>
        ///    Ecommerce_ImagePath4
        /// </summary>
        public string Ecommerce_ImagePath4
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_ImagePath4;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_ImagePath4 != value)
                {
                    this.ItemViewModelItem.Ecommerce_ImagePath4 = value;
                    OnPropertyChanged("Ecommerce_ImagePath4");
                }
            }
        }

        /// <summary>
        ///    Ecommerce_ImagePath5
        /// </summary>
        public string Ecommerce_ImagePath5
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_ImagePath5;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_ImagePath5 != value)
                {
                    this.ItemViewModelItem.Ecommerce_ImagePath5 = value;
                    OnPropertyChanged("Ecommerce_ImagePath5");
                }
            }
        }

        /// <summary>
        ///    Ecommerce_ItemHeight
        /// </summary>
        public string Ecommerce_ItemHeight
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_ItemHeight;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_ItemHeight != value)
                {
                    this.ItemViewModelItem.Ecommerce_ItemHeight = value;
                    this.Ecommerce_ItemHeightError = ItemService.ValidateEcommerce_ItemHeight(value, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_ItemHeight");
                }
            }
        }
        public string Ecommerce_ItemHeightBoxColor
        {
            get
            {
                return _Ecommerce_ItemHeightBoxColor;
            }
            set
            {
                _Ecommerce_ItemHeightBoxColor = value;
                OnPropertyChanged("Ecommerce_ItemHeightBoxColor");
            }
        }
        private string _Ecommerce_ItemHeightBoxColor = "White";
        public string Ecommerce_ItemHeightError
        {
            get
            {
                return _ecommerce_ItemHeightError;
            }
            set
            {
                _ecommerce_ItemHeightError = value;
                if (value != "")
                {
                    Ecommerce_ItemHeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_ItemHeightToolTip");
                }
                else
                {
                    Ecommerce_ItemHeightToolTip = ReturnToolTip("Ecommerce_ItemHeightToolTip");
                }
                this.Ecommerce_ItemHeightBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_ItemHeightError");
            }
        }
        private string _ecommerce_ItemHeightError = string.Empty;
        public string Ecommerce_ItemHeightToolTip
        {
            get
            {
                return _ecommerce_ItemHeightToolTip;
            }
            set
            {
                this._ecommerce_ItemHeightToolTip = value;
                OnPropertyChanged("Ecommerce_ItemHeightToolTip");
            }
        }
        private string _ecommerce_ItemHeightToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_ItemLength
        /// </summary>
        public string Ecommerce_ItemLength
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_ItemLength;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_ItemLength != value)
                {
                    this.ItemViewModelItem.Ecommerce_ItemLength = value;
                    this.Ecommerce_ItemLengthError = ItemService.ValidateEcommerce_ItemLength(value, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_ItemLength");
                }
            }
        }
        public string Ecommerce_ItemLengthBoxColor
        {
            get
            {
                return _ecommerce_ItemLengthBoxColor;
            }
            set
            {
                _ecommerce_ItemLengthBoxColor = value;
                OnPropertyChanged("Ecommerce_ItemLengthBoxColor");
            }
        }
        private string _ecommerce_ItemLengthBoxColor = "White";
        public string Ecommerce_ItemLengthError
        {
            get
            {
                return _ecommerce_ItemLengthError;
            }
            set
            {
                _ecommerce_ItemLengthError = value;
                if (value != "")
                {
                    Ecommerce_ItemLengthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_ItemLengthToolTip");
                }
                else
                {
                    Ecommerce_ItemLengthToolTip = ReturnToolTip("Ecommerce_ItemLengthToolTip");
                }
                this.Ecommerce_ItemLengthBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_ItemLengthError");
            }
        }
        private string _ecommerce_ItemLengthError = string.Empty;
        public string Ecommerce_ItemLengthToolTip
        {
            get
            {
                return _ecommerce_ItemLengthToolTip;
            }
            set
            {
                this._ecommerce_ItemLengthToolTip = value;
                OnPropertyChanged("Ecommerce_ItemLengthToolTip");
            }
        }
        private string _ecommerce_ItemLengthToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_ItemName
        /// </summary>
        public string Ecommerce_ItemName
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_ItemName;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_ItemName != value)
                {
                    this.ItemViewModelItem.Ecommerce_ItemName = value;
                    this.Ecommerce_ItemNameError = ItemService.ValidateEcommerce_ItemName(value, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_ItemName");
                }
            }
        }
        public string Ecommerce_ItemNameBoxColor
        {
            get
            {
                return _ecommerce_ItemNameBoxColor;
            }
            set
            {
                _ecommerce_ItemNameBoxColor = value;
                OnPropertyChanged("Ecommerce_ItemNameBoxColor");
            }
        }
        private string _ecommerce_ItemNameBoxColor = "White";
        public string Ecommerce_ItemNameError
        {
            get
            {
                return _ecommerce_ItemNameError;
            }
            set
            {
                _ecommerce_ItemNameError = value;
                if (value != "")
                {
                    Ecommerce_ItemNameToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_ItemNameToolTip");
                }
                else
                {
                    Ecommerce_ItemNameToolTip = ReturnToolTip("Ecommerce_ItemNameToolTip");
                }
                this.Ecommerce_ItemNameBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_ItemNameError");
            }
        }
        private string _ecommerce_ItemNameError = string.Empty;
        public string Ecommerce_ItemNameToolTip
        {
            get
            {
                return _ecommerce_ItemNameToolTip;
            }
            set
            {
                this._ecommerce_ItemNameToolTip = value;
                OnPropertyChanged("Ecommerce_ItemNameToolTip");
            }
        }
        private string _ecommerce_ItemNameToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_ItemWeight
        /// </summary>
        public string Ecommerce_ItemWeight
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_ItemWeight;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_ItemWeight != value)
                {
                    this.ItemViewModelItem.Ecommerce_ItemWeight = value;
                    this.Ecommerce_ItemWeightError = ItemService.ValidateEcommerce_ItemWeight(value, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_ItemWeight");
                }
            }
        }
        public string Ecommerce_ItemWeightBoxColor
        {
            get
            {
                return _ecommerce_ItemWeightBoxColor;
            }
            set
            {
                _ecommerce_ItemWeightBoxColor = value;
                OnPropertyChanged("Ecommerce_ItemWeightBoxColor");
            }
        }
        private string _ecommerce_ItemWeightBoxColor = "White";
        public string Ecommerce_ItemWeightError
        {
            get
            {
                return _ecommerce_ItemWeightError;
            }
            set
            {
                _ecommerce_ItemWeightError = value;
                if (value != "")
                {
                    Ecommerce_ItemWeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_ItemWeightToolTip");
                }
                else
                {
                    Ecommerce_ItemWeightToolTip = ReturnToolTip("Ecommerce_ItemWeightToolTip");
                }
                this.Ecommerce_ItemWeightBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_ItemWeightError");
            }
        }
        private string _ecommerce_ItemWeightError = string.Empty;
        public string Ecommerce_ItemWeightToolTip
        {
            get
            {
                return _ecommerce_ItemWeightToolTip;
            }
            set
            {
                this._ecommerce_ItemWeightToolTip = value;
                OnPropertyChanged("Ecommerce_ItemWeightToolTip");
            }
        }
        private string _ecommerce_ItemWeightToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_ItemWidth
        /// </summary>
        public string Ecommerce_ItemWidth
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_ItemWidth;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_ItemWidth != value)
                {
                    this.ItemViewModelItem.Ecommerce_ItemWidth = value;
                    this.Ecommerce_ItemWeightError = ItemService.ValidateEcommerce_ItemWeight(value, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_ItemWidth");
                }
            }
        }
        public string Ecommerce_ItemWidthBoxColor
        {
            get
            {
                return _ecommerce_ItemWidthBoxColor;
            }
            set
            {
                _ecommerce_ItemWidthBoxColor = value;
                OnPropertyChanged("Ecommerce_ItemWidthBoxColor");
            }
        }
        private string _ecommerce_ItemWidthBoxColor = "White";
        public string Ecommerce_ItemWidthError
        {
            get
            {
                return _ecommerce_ItemWidthError;
            }
            set
            {
                _ecommerce_ItemWidthError = value;
                if (value != "")
                {
                    Ecommerce_ItemWidthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_ItemWidthToolTip");
                }
                else
                {
                    Ecommerce_ItemWidthToolTip = ReturnToolTip("Ecommerce_ItemWidthToolTip");
                }
                this.Ecommerce_ItemWidthBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_ItemWidthError");
            }
        }
        private string _ecommerce_ItemWidthError = string.Empty;
        public string Ecommerce_ItemWidthToolTip
        {
            get
            {
                return _ecommerce_ItemWidthToolTip;
            }
            set
            {
                this._ecommerce_ItemWidthToolTip = value;
                OnPropertyChanged("Ecommerce_ItemWidthToolTip");
            }
        }
        private string _ecommerce_ItemWidthToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_ModelName
        /// </summary>
        public string Ecommerce_ModelName
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_ModelName;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_ModelName != value)
                {
                    this.ItemViewModelItem.Ecommerce_ModelName = value;
                    this.Ecommerce_ModelNameError = ItemService.ValidateEcommerce_ModelName(value, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_ModelName");
                }
            }
        }
        public string Ecommerce_ModelNameBoxColor
        {
            get
            {
                return _ecommerce_ModelNameBoxColor;
            }
            set
            {
                _ecommerce_ModelNameBoxColor = value;
                OnPropertyChanged("Ecommerce_ModelNameBoxColor");
            }
        }
        private string _ecommerce_ModelNameBoxColor = "White";
        public string Ecommerce_ModelNameError
        {
            get
            {
                return _ecommerce_ModelNameError;
            }
            set
            {
                _ecommerce_ModelNameError = value;
                if (value != "")
                {
                    Ecommerce_ModelNameToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_ModelNameToolTip");
                }
                else
                {
                    Ecommerce_ModelNameToolTip = ReturnToolTip("Ecommerce_ModelNameToolTip");
                }
                this.Ecommerce_ModelNameBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_ModelNameError");
            }
        }
        private string _ecommerce_ModelNameError = string.Empty;
        public string Ecommerce_ModelNameToolTip
        {
            get
            {
                return _ecommerce_ModelNameToolTip;
            }
            set
            {
                this._ecommerce_ModelNameToolTip = value;
                OnPropertyChanged("Ecommerce_ModelNameToolTip");
            }
        }
        private string _ecommerce_ModelNameToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_PackageHeight
        /// </summary>
        public string Ecommerce_PackageHeight
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_PackageHeight;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_PackageHeight != value)
                {
                    this.ItemViewModelItem.Ecommerce_PackageHeight = value;
                    this.Ecommerce_PackageHeightError = ItemService.ValidateEcommerce_PackageHeight(value, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_PackageHeight");
                }
            }
        }
        public string Ecommerce_PackageHeightBoxColor
        {
            get
            {
                return _ecommerce_PackageHeightBoxColor;
            }
            set
            {
                _ecommerce_PackageHeightBoxColor = value;
                OnPropertyChanged("Ecommerce_PackageHeightBoxColor");
            }
        }
        private string _ecommerce_PackageHeightBoxColor = "White";
        public string Ecommerce_PackageHeightError
        {
            get
            {
                return _ecommerce_PackageHeightError;
            }
            set
            {
                _ecommerce_PackageHeightError = value;
                if (value != "")
                {
                    Ecommerce_PackageHeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_PackageHeightToolTip");
                }
                else
                {
                    Ecommerce_PackageHeightToolTip = ReturnToolTip("Ecommerce_PackageHeightToolTip");
                }
                this.Ecommerce_PackageHeightBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_PackageHeightError");
            }
        }
        private string _ecommerce_PackageHeightError = string.Empty;
        public string Ecommerce_PackageHeightToolTip
        {
            get
            {
                return _ecommerce_PackageHeightToolTip;
            }
            set
            {
                this._ecommerce_PackageHeightToolTip = value;
                OnPropertyChanged("Ecommerce_PackageHeightToolTip");
            }
        }
        private string _ecommerce_PackageHeightToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_PackageLength
        /// </summary>
        public string Ecommerce_PackageLength
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_PackageLength;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_PackageLength != value)
                {
                    this.ItemViewModelItem.Ecommerce_PackageLength = value;
                    this.Ecommerce_PackageLengthError = ItemService.ValidateEcommerce_PackageLength(value, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_PackageLength");
                }
            }
        }
        public string Ecommerce_PackageLengthBoxColor
        {
            get
            {
                return _ecommerce_PackageLengthBoxColor;
            }
            set
            {
                _ecommerce_PackageLengthBoxColor = value;
                OnPropertyChanged("Ecommerce_PackageLengthBoxColor");
            }
        }
        private string _ecommerce_PackageLengthBoxColor = "White";
        public string Ecommerce_PackageLengthError
        {
            get
            {
                return _ecommerce_PackageLengthError;
            }
            set
            {
                _ecommerce_PackageLengthError = value;
                if (value != "")
                {
                    Ecommerce_PackageLengthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_PackageLengthToolTip");
                }
                else
                {
                    Ecommerce_PackageLengthToolTip = ReturnToolTip("Ecommerce_PackageLengthToolTip");
                }
                this.Ecommerce_PackageLengthBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_PackageLengthError");
            }
        }
        private string _ecommerce_PackageLengthError = string.Empty;
        public string Ecommerce_PackageLengthToolTip
        {
            get
            {
                return _ecommerce_PackageLengthToolTip;
            }
            set
            {
                this._ecommerce_PackageLengthToolTip = value;
                OnPropertyChanged("Ecommerce_PackageLengthToolTip");
            }
        }
        private string _ecommerce_PackageLengthToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_PackageWeight
        /// </summary>
        public string Ecommerce_PackageWeight
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_PackageWeight;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_PackageWeight != value)
                {
                    this.ItemViewModelItem.Ecommerce_PackageWeight = value;
                    this.Ecommerce_PackageWeightError = ItemService.ValidateEcommerce_PackageWeight(value, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_PackageWeight");
                }
            }
        }
        public string Ecommerce_PackageWeightBoxColor
        {
            get
            {
                return _ecommerce_PackageWeightBoxColor;
            }
            set
            {
                _ecommerce_PackageWeightBoxColor = value;
                OnPropertyChanged("Ecommerce_PackageWeightBoxColor");
            }
        }
        private string _ecommerce_PackageWeightBoxColor = "White";
        public string Ecommerce_PackageWeightError
        {
            get
            {
                return _ecommerce_PackageWeightError;
            }
            set
            {
                _ecommerce_PackageWeightError = value;
                if (value != "")
                {
                    Ecommerce_PackageWeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_PackageWeightToolTip");
                }
                else
                {
                    Ecommerce_PackageWeightToolTip = ReturnToolTip("Ecommerce_PackageWeightToolTip");
                }
                this.Ecommerce_PackageWeightBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_PackageWeightError");
            }
        }
        private string _ecommerce_PackageWeightError = string.Empty;
        public string Ecommerce_PackageWeightToolTip
        {
            get
            {
                return _ecommerce_PackageWeightToolTip;
            }
            set
            {
                this._ecommerce_PackageWeightToolTip = value;
                OnPropertyChanged("Ecommerce_PackageWeightToolTip");
            }
        }
        private string _ecommerce_PackageWeightToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_PackageWidth
        /// </summary>
        public string Ecommerce_PackageWidth
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_PackageWidth;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_PackageWidth != value)
                {
                    this.ItemViewModelItem.Ecommerce_PackageWidth = value;
                    this.Ecommerce_PackageWidthError = ItemService.ValidateEcommerce_PackageWidth(value, ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_PackageWidth");
                }
            }
        }
        public string Ecommerce_PackageWidthBoxColor
        {
            get
            {
                return _ecommerce_PackageWidthBoxColor;
            }
            set
            {
                _ecommerce_PackageWidthBoxColor = value;
                OnPropertyChanged("Ecommerce_PackageWidthBoxColor");
            }
        }
        private string _ecommerce_PackageWidthBoxColor = "White";
        public string Ecommerce_PackageWidthError
        {
            get
            {
                return _ecommerce_PackageWidthError;
            }
            set
            {
                _ecommerce_PackageWidthError = value;
                if (value != "")
                {
                    Ecommerce_PackageWidthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_PackageWidthToolTip");
                }
                else
                {
                    Ecommerce_PackageWidthToolTip = ReturnToolTip("Ecommerce_PackageWidthToolTip");
                }
                this.Ecommerce_PackageWidthBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_PackageWidthError");
            }
        }
        private string _ecommerce_PackageWidthError = string.Empty;
        public string Ecommerce_PackageWidthToolTip
        {
            get
            {
                return _ecommerce_PackageWidthToolTip;
            }
            set
            {
                this._ecommerce_PackageWidthToolTip = value;
                OnPropertyChanged("Ecommerce_PackageWidthToolTip");
            }
        }
        private string _ecommerce_PackageWidthToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_PageQty
        /// </summary>
        public string Ecommerce_PageQty
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_PageQty;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_PageQty != value)
                {
                    this.ItemViewModelItem.Ecommerce_PageQty = value;
                    this.Ecommerce_PageQtyError = ItemService.ValidateEcommerce_PageQty(value);
                    OnPropertyChanged("Ecommerce_PageQty");
                }
            }
        }
        public string Ecommerce_PageQtyBoxColor
        {
            get
            {
                return _Ecommerce_PageQtyBoxColor;
            }
            set
            {
                _Ecommerce_PageQtyBoxColor = value;
                OnPropertyChanged("Ecommerce_PageQtyBoxColor");
            }
        }
        private string _Ecommerce_PageQtyBoxColor = "White";
        public string Ecommerce_PageQtyError
        {
            get
            {
                return _Ecommerce_PageQtyError;
            }
            set
            {
                _Ecommerce_PageQtyError = value;
                if (value != "")
                {
                    Ecommerce_PageQtyToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_PageQtyToolTip");
                }
                else
                {
                    Ecommerce_PageQtyToolTip = ReturnToolTip("Ecommerce_PageQtyToolTip");
                }
                this.Ecommerce_PageQtyBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_PageQtyError");
            }
        }
        private string _Ecommerce_PageQtyError = string.Empty;
        public string Ecommerce_PageQtyToolTip
        {
            get
            {
                return _Ecommerce_PageQtyToolTip;
            }
            set
            {
                this._Ecommerce_PageQtyToolTip = value;
                OnPropertyChanged("Ecommerce_PageQtyToolTip");
            }
        }
        private string _Ecommerce_PageQtyToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_ProductCategory
        /// </summary>
        public string Ecommerce_ProductCategory
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_ProductCategory;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_ProductCategory != value)
                {
                    this.ItemViewModelItem.Ecommerce_ProductCategory = value;
                    this.Ecommerce_ProductCategoryError = ItemService.ValidateEcommerce_ProductCategory(value, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_ProductCategory");
                }
            }
        }
        public string Ecommerce_ProductCategoryBoxColor
        {
            get
            {
                return _ecommerce_ProductCategoryBoxColor;
            }
            set
            {
                _ecommerce_ProductCategoryBoxColor = value;
                OnPropertyChanged("Ecommerce_ProductCategoryBoxColor");
            }
        }
        private string _ecommerce_ProductCategoryBoxColor = "White";
        public string Ecommerce_ProductCategoryError
        {
            get
            {
                return _ecommerce_ProductCategoryError;
            }
            set
            {
                _ecommerce_ProductCategoryError = value;
                if (value != "")
                {
                    Ecommerce_ProductCategoryToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_ProductCategoryToolTip");
                }
                else
                {
                    Ecommerce_ProductCategoryToolTip = ReturnToolTip("Ecommerce_ProductCategoryToolTip");
                }
                this.Ecommerce_ProductCategoryBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_ProductCategoryError");
            }
        }
        private string _ecommerce_ProductCategoryError = string.Empty;
        public string Ecommerce_ProductCategoryToolTip
        {
            get
            {
                return _ecommerce_ProductCategoryToolTip;
            }
            set
            {
                this._ecommerce_ProductCategoryToolTip = value;
                OnPropertyChanged("Ecommerce_ProductCategoryToolTip");
            }
        }
        private string _ecommerce_ProductCategoryToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_ProductDescription
        /// </summary>
        public string Ecommerce_ProductDescription
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_ProductDescription;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_ProductDescription != value)
                {
                    this.ItemViewModelItem.Ecommerce_ProductDescription = value;
                    this.Ecommerce_ProductDescriptionError = ItemService.ValidateEcommerce_ProductDescription(value, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_ProductDescription");
                }
            }
        }
        public string Ecommerce_ProductDescriptionBoxColor
        {
            get
            {
                return _ecommerce_ProductDescriptionBoxColor;
            }
            set
            {
                _ecommerce_ProductDescriptionBoxColor = value;
                OnPropertyChanged("Ecommerce_ProductDescriptionBoxColor");
            }
        }
        private string _ecommerce_ProductDescriptionBoxColor = "White";
        public string Ecommerce_ProductDescriptionError
        {
            get
            {
                return _ecommerce_ProductDescriptionError;
            }
            set
            {
                _ecommerce_ProductDescriptionError = value;
                if (value != "")
                {
                    Ecommerce_ProductDescriptionToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_ProductDescriptionToolTip");
                }
                else
                {
                    Ecommerce_ProductDescriptionToolTip = ReturnToolTip("Ecommerce_ProductDescriptionToolTip");
                }
                this.Ecommerce_ProductDescriptionBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_ProductDescriptionError");
            }
        }
        private string _ecommerce_ProductDescriptionError = string.Empty;
        public string Ecommerce_ProductDescriptionToolTip
        {
            get
            {
                return _ecommerce_ProductDescriptionToolTip;
            }
            set
            {
                this._ecommerce_ProductDescriptionToolTip = value;
                OnPropertyChanged("Ecommerce_ProductDescriptionToolTip");
            }
        }
        private string _ecommerce_ProductDescriptionToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_ProductSubcategory
        /// </summary>
        public string Ecommerce_ProductSubcategory
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_ProductSubcategory;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_ProductSubcategory != value)
                {
                    this.ItemViewModelItem.Ecommerce_ProductSubcategory = value;
                    this.Ecommerce_ProductSubcategoryError = ItemService.ValidateEcommerce_ProductSubcategory(value, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_ProductSubcategory");
                }
            }
        }
        public string Ecommerce_ProductSubcategoryBoxColor
        {
            get
            {
                return _ecommerce_ProductSubcategoryBoxColor;
            }
            set
            {
                _ecommerce_ProductSubcategoryBoxColor = value;
                OnPropertyChanged("Ecommerce_ProductSubcategoryBoxColor");
            }
        }
        private string _ecommerce_ProductSubcategoryBoxColor = "White";
        public string Ecommerce_ProductSubcategoryError
        {
            get
            {
                return _ecommerce_ProductSubcategoryError;
            }
            set
            {
                _ecommerce_ProductSubcategoryError = value;
                if (value != "")
                {
                    Ecommerce_ProductSubcategoryToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_ProductSubcategoryToolTip");
                }
                else
                {
                    Ecommerce_ProductSubcategoryToolTip = ReturnToolTip("Ecommerce_ProductSubcategoryToolTip");
                }
                this.Ecommerce_ProductSubcategoryBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_ProductSubcategoryError");
            }
        }
        private string _ecommerce_ProductSubcategoryError = string.Empty;
        public string Ecommerce_ProductSubcategoryToolTip
        {
            get
            {
                return _ecommerce_ProductSubcategoryToolTip;
            }
            set
            {
                this._ecommerce_ProductSubcategoryToolTip = value;
                OnPropertyChanged("Ecommerce_ProductSubcategoryToolTip");
            }
        }
        private string _ecommerce_ProductSubcategoryToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_ManufacturerName
        /// </summary>
        public string Ecommerce_ManufacturerName
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_ManufacturerName;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_ManufacturerName != value)
                {
                    this.ItemViewModelItem.Ecommerce_ManufacturerName = value;
                    this.Ecommerce_ManufacturerNameError = ItemService.ValidateEcommerce_ManufacturerName(value, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_ManufacturerName");
                }
            }
        }
        public string Ecommerce_ManufacturerNameBoxColor
        {
            get
            {
                return _ecommerce_ManufacturerNameBoxColor;
            }
            set
            {
                _ecommerce_ManufacturerNameBoxColor = value;
                OnPropertyChanged("Ecommerce_ManufacturerNameBoxColor");
            }
        }
        private string _ecommerce_ManufacturerNameBoxColor = "White";
        public string Ecommerce_ManufacturerNameError
        {
            get
            {
                return _ecommerce_ManufacturerNameError;
            }
            set
            {
                _ecommerce_ManufacturerNameError = value;
                if (value != "")
                {
                    Ecommerce_ManufacturerNameToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_ManufacturerNameToolTip");
                }
                else
                {
                    Ecommerce_ManufacturerNameToolTip = ReturnToolTip("Ecommerce_ManufacturerNameToolTip");
                }
                this.Ecommerce_ManufacturerNameBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_ManufacturerNameError");
            }
        }
        private string _ecommerce_ManufacturerNameError = string.Empty;
        public string Ecommerce_ManufacturerNameToolTip
        {
            get
            {
                return _ecommerce_ManufacturerNameToolTip;
            }
            set
            {
                this._ecommerce_ManufacturerNameToolTip = value;
                OnPropertyChanged("Ecommerce_ManufacturerNameToolTip");
            }
        }
        private string _ecommerce_ManufacturerNameToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_Msrp
        /// </summary>
        public string Ecommerce_Msrp
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_Msrp;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_Msrp != value)
                {
                    this.ItemViewModelItem.Ecommerce_Msrp = value;
                    this.Ecommerce_MsrpError = ItemService.ValidateEcommerce_Msrp(value, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_Msrp");
                }
            }
        }
        public string Ecommerce_MsrpBoxColor
        {
            get
            {
                return _ecommerce_MsrpBoxColor;
            }
            set
            {
                _ecommerce_MsrpBoxColor = value;
                OnPropertyChanged("Ecommerce_MsrpBoxColor");
            }
        }
        private string _ecommerce_MsrpBoxColor = "White";
        public string Ecommerce_MsrpError
        {
            get
            {
                return _ecommerce_MsrpError;
            }
            set
            {
                _ecommerce_MsrpError = value;
                if (value != "")
                {
                    Ecommerce_MsrpToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_MsrpToolTip");
                }
                else
                {
                    Ecommerce_MsrpToolTip = ReturnToolTip("Ecommerce_MsrpToolTip");
                }
                this.Ecommerce_MsrpBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_MsrpError");
            }
        }
        private string _ecommerce_MsrpError = string.Empty;
        public string Ecommerce_MsrpToolTip
        {
            get
            {
                return _ecommerce_MsrpToolTip;
            }
            set
            {
                this._ecommerce_MsrpToolTip = value;
                OnPropertyChanged("Ecommerce_MsrpToolTip");
            }
        }
        private string _ecommerce_MsrpToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_SearchTerms
        /// </summary>
        public string Ecommerce_SearchTerms
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_SearchTerms;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_SearchTerms != value)
                {
                    this.ItemViewModelItem.Ecommerce_SearchTerms = value;
                    this.Ecommerce_SearchTermsError = ItemService.ValidateEcommerce_SearchTerms(value, this.ItemViewModelItem.HasEcommerce(), this.Status);
                    OnPropertyChanged("Ecommerce_SearchTerms");
                }
            }
        }
        public string Ecommerce_SearchTermsBoxColor
        {
            get
            {
                return _ecommerce_SearchTermsBoxColor;
            }
            set
            {
                _ecommerce_SearchTermsBoxColor = value;
                OnPropertyChanged("Ecommerce_SearchTermsBoxColor");
            }
        }
        private string _ecommerce_SearchTermsBoxColor = "White";
        public string Ecommerce_SearchTermsError
        {
            get
            {
                return _ecommerce_SearchTermsError;
            }
            set
            {
                _ecommerce_SearchTermsError = value;
                if (value != "")
                {
                    Ecommerce_SearchTermsToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_SearchTermsToolTip");
                }
                else
                {
                    Ecommerce_SearchTermsToolTip = ReturnToolTip("Ecommerce_SearchTermsToolTip");
                }
                this.Ecommerce_SearchTermsBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_SearchTermsError");
            }
        }
        private string _ecommerce_SearchTermsError = string.Empty;
        public string Ecommerce_SearchTermsToolTip
        {
            get
            {
                return _ecommerce_SearchTermsToolTip;
            }
            set
            {
                this._ecommerce_SearchTermsToolTip = value;
                OnPropertyChanged("Ecommerce_SearchTermsToolTip");
            }
        }
        private string _ecommerce_SearchTermsToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_Size
        /// </summary>
        public string Ecommerce_Size
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_Size;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_Size != value)
                {
                    this.ItemViewModelItem.Ecommerce_Size = value;
                    this.Ecommerce_SizeError = ItemService.ValidateEcommerce_Size(value, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_Size");
                }
            }
        }
        public string Ecommerce_SizeBoxColor
        {
            get
            {
                return _ecommerce_sizeBoxColor;
            }
            set
            {
                _ecommerce_sizeBoxColor = value;
                OnPropertyChanged("Ecommerce_SizeBoxColor");
            }
        }
        private string _ecommerce_sizeBoxColor = "White";
        public string Ecommerce_SizeError
        {
            get
            {
                return _ecommerce_sizeError;
            }
            set
            {
                _ecommerce_sizeError = value;
                if (value != "")
                {
                    Ecommerce_SizeToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_SizeToolTip");
                }
                else
                {
                    Ecommerce_SizeToolTip = ReturnToolTip("Ecommerce_SizeToolTip");
                }
                this.Ecommerce_SizeBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_SizeError");
            }
        }
        private string _ecommerce_sizeError = string.Empty;
        public string Ecommerce_SizeToolTip
        {
            get
            {
                return _ecommerce_sizeToolTip;
            }
            set
            {
                this._ecommerce_sizeToolTip = value;
                OnPropertyChanged("Ecommerce_SizeToolTip");
            }
        }
        private string _ecommerce_sizeToolTip = string.Empty;

        /// <summary>
        ///    Ecommerce_Upc
        /// </summary>
        public string Ecommerce_Upc
        {
            get
            {
                return this.ItemViewModelItem.Ecommerce_Upc;
            }
            set
            {
                if (this.ItemViewModelItem.Ecommerce_Upc != value)
                {
                    this.ItemViewModelItem.Ecommerce_Upc = value;
                    this.Ecommerce_UpcError = ItemService.ValidateEcommerce_Upc(value, this.ItemId, this.Upc, this.Status, this.ItemViewModelItem.HasEcommerce());
                    OnPropertyChanged("Ecommerce_Upc");
                }
            }
        }
        public string Ecommerce_UpcBoxColor
        {
            get
            {
                return _ecommerce_UpcBoxColor;
            }
            set
            {
                _ecommerce_UpcBoxColor = value;
                OnPropertyChanged("Ecommerce_UpcBoxColor");
            }
        }
        private string _ecommerce_UpcBoxColor = "White";
        public string Ecommerce_UpcError
        {
            get
            {
                return _ecommerce_UpcError;
            }
            set
            {
                _ecommerce_UpcError = value;
                if (value != "")
                {
                    Ecommerce_UpcToolTip = "Error: " + value + "\n\n" + ReturnToolTip("Ecommerce_UpcToolTip");
                }
                else
                {
                    Ecommerce_UpcToolTip = ReturnToolTip("Ecommerce_UpcToolTip");
                }
                this.Ecommerce_UpcBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("Ecommerce_UpcError");
            }
        }
        private string _ecommerce_UpcError = string.Empty;
        public string Ecommerce_UpcToolTip
        {
            get
            {
                return _ecommerce_UpcToolTip;
            }
            set
            {
                _ecommerce_UpcToolTip = value;
                OnPropertyChanged("Ecommerce_UpcToolTip");
            }
        }
        private string _ecommerce_UpcToolTip = string.Empty;

        #endregion // Ecommerce Properties
        
        #region ComboBox Properties

        public List<string> AccountingGroupsList
        {
            get
            {
                return GlobalData.AccountingGroups;
            }
        }

        public List<string> CountriesOfOrigin
        {
            get
            {
                return _countriesOfOrigin;
            }
            set
            {
                _countriesOfOrigin = value;
            }
        }
        private List<string> _countriesOfOrigin = new List<string>();

        public List<string> CostProfileGroups
        {
            get
            {
                return GlobalData.CostProfileGroups;
            }
        }

        public List<string> Ecommerce_ExternalIdTypeGroups
        {
            get
            {
                return GlobalData.ExternalIdTypes;
            }
        }

        public List<string> ItemGroups
        {
            get
            {
                return GlobalData.ItemGroups;
            }
        }

        public List<string> Languages
        {
            get
            {
                return GlobalData.Languages;
            }
        }
        
        public List<string> Licenses
        {
            get
            {
                return GlobalData.Licenses;
            }
        }

        public List<string> MetaDescriptions
        {
            get
            {
                return GlobalData.MetaDescriptions;
            }
        }

        public List<string> PricingGroups
        {
            get
            {
                return GlobalData.PricingGroups;
            }
        }

        public List<string> ProductCategories
        {
            get
            {
                return GlobalData.ProductCategories;
            }
        }

        public List<string> ProductGroups
        {
            get
            {
                return GlobalData.ProductGoups;
            }
        }

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

        public List<string> PsStatuses
        {
            get
            {
                return GlobalData.PsStatuses;
            }
        }

        public List<string> TariffCodes
        {
            get
            {
                return GlobalData.TariffCodes;
            }
        }

        public List<string> Territories
        {
            get
            {
                return GlobalData.Territories;
            }
        }

        public List<string> WebCategoryList
        {
            get
            {
                return GlobalData.ReturnWebCategoryListValues();
            }
        }

        #endregion // ComboBox Properties

        #region Images

        /// <summary>
        ///     Gets or sets the Image1
        /// </summary>
        public BitmapImage Image1
        {
            get { return _image1; }
            set
            {
                _image1 = value;
                OnPropertyChanged("Image1");
            }
        }
        private BitmapImage _image1 = new BitmapImage();

        /// <summary>
        ///     Gets or sets the Image1
        /// </summary>
        public BitmapImage Image2
        {
            get { return _image2; }
            set
            {
                _image2 = value;
                OnPropertyChanged("Image2");
            }
        }
        private BitmapImage _image2 = new BitmapImage();

        /// <summary>
        ///     Gets or sets the Image3
        /// </summary>
        public BitmapImage Image3
        {
            get { return _image3; }
            set
            {
                _image3 = value;
                OnPropertyChanged("Image3");
            }
        }
        private BitmapImage _image3 = new BitmapImage();

        /// <summary>
        ///     Gets or sets the Image4
        /// </summary>
        public BitmapImage Image4
        {
            get { return _image4; }
            set
            {
                _image4 = value;
                OnPropertyChanged("Image1");
            }
        }
        private BitmapImage _image4 = new BitmapImage();

        /// <summary>
        ///     Gets or sets the Image5
        /// </summary>
        public BitmapImage Image5
        {
            get { return _image5; }
            set
            {
                _image5 = value;
                OnPropertyChanged("Image5");
            }
        }
        private BitmapImage _image5 = new BitmapImage();

        #endregion // Images

        public ItemObject ItemViewModelItem 
            { 
                get; 
                set; 
            }

        public ObservableCollection<ItemError> ItemErrors
        {
            get
            {
                return _itemErrors;
            }
            set
            {
                _itemErrors = value;
            }
        }
        private ObservableCollection<ItemError> _itemErrors = new ObservableCollection<ItemError>();

        #endregion // Properties
        
        #region Methods

        /// <summary>
        ///     Check ecommerce fields for errored items. 
        /// </summary>
        /// <returns></returns>
        private string CheckEcommerceTabColor()
        {
            if (Ecommerce_AsinBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_Bullet1BoxColor != "White") { return "Tomato"; }
            if (Ecommerce_Bullet2BoxColor != "White") { return "Tomato"; }
            if (Ecommerce_Bullet3BoxColor != "White") { return "Tomato"; }
            if (Ecommerce_Bullet4BoxColor != "White") { return "Tomato"; }
            if (Ecommerce_Bullet5BoxColor != "White") { return "Tomato"; }
            if (Ecommerce_ComponentsBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_CostBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_ExternalIdBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_ExternalIdTypeBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_ItemHeightBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_ItemLengthBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_ItemNameBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_ItemWeightBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_ItemWidthBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_ModelNameBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_PackageHeightBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_PackageLengthBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_PackageWeightBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_PackageWidthBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_PageQtyBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_ProductCategoryBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_ProductDescriptionBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_ProductSubcategoryBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_ManufacturerNameBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_MsrpBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_SearchTermsBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_SizeBoxColor != "White") { return "Tomato"; }
            if (Ecommerce_UpcBoxColor != "White") { return "Tomato"; }
            return "White";
        }

        /// <summary>
        ///     Check image fields for errored items. 
        /// </summary>
        /// <returns></returns>
        private string CheckImagePathTabColor()
        {
            if (ImagePathBoxColor != "White") { return "Tomato"; }
            if (AltImageFile1BoxColor != "White") { return "Tomato"; }
            if (AltImageFile2BoxColor != "White") { return "Tomato"; }
            if (AltImageFile3BoxColor != "White") { return "Tomato"; }
            if (AltImageFile4BoxColor != "White") { return "Tomato"; }
            return "White";
        }

        /// <summary>
        ///     Check item info fields for errored items
        /// </summary>
        /// <returns>'Tomato' if errors exist, 'White' if no errors exist</returns>
        private string CheckItemInfoTabColor()
        {
            if (AccountingGroupBoxColor != "White") { return "Tomato"; }
            if (BillOfMaterialsBoxColor != "White") { return "Tomato"; }
            if (CasepackHeightBoxColor != "White") { return "Tomato"; }
            if (CasepackLengthBoxColor != "White") { return "Tomato"; }
            if (CasepackQtyBoxColor != "White") { return "Tomato"; }
            if (CasepackUpcBoxColor != "White") { return "Tomato"; }
            if (CasepackWidthBoxColor != "White") { return "Tomato"; }
            if (CasepackWeightBoxColor != "White") { return "Tomato"; }
            if (ColorBoxColor != "White") { return "Tomato"; }
            if (CostProfileGroupBoxColor != "White") { return "Tomato"; }
            if (CountryOfOriginBoxColor != "White") { return "Tomato"; }
            if (DefaultActualCostUsdBoxColor != "White") { return "Tomato"; }
            if (DefaultActualCostCadBoxColor != "White") { return "Tomato"; }
            if (DescriptionBoxColor != "White") { return "Tomato"; }
            if (EanBoxColor != "White") { return "Tomato"; }
            if (DutyBoxColor != "White") { return "Tomato"; }
            if (GpcBoxColor != "White") { return "Tomato"; }
            if (HeightBoxColor != "White") { return "Tomato"; }
            if (InnerpackHeightBoxColor != "White") { return "Tomato"; }
            if (InnerpackLengthBoxColor != "White") { return "Tomato"; }
            if (InnerpackQuantityBoxColor != "White") { return "Tomato"; }
            if (InnerpackUpcBoxColor != "White") { return "Tomato"; }
            if (InnerpackWeightBoxColor != "White") { return "Tomato"; }
            if (InnerpackWidthBoxColor != "White") { return "Tomato"; }
            if (IsbnBoxColor != "White") { return "Tomato"; }
            if (ItemCategoryBoxColor != "White") { return "Tomato"; }
            if (ItemFamilyBoxColor != "White") { return "Tomato"; }
            if (ItemGroupBoxColor != "White") { return "Tomato"; }
            if (ItemIdBoxColor != "White") { return "Tomato"; }
            if (LanguageBoxColor != "White") { return "Tomato"; }
            if (LengthBoxColor != "White") { return "Tomato"; }
            if (LicenseBeginDateBoxColor != "White") { return "Tomato"; }
            if (ListPriceCadBoxColor != "White") { return "Tomato"; }
            if (ListPriceMxnBoxColor != "White") { return "Tomato"; }
            if (ListPriceUsdBoxColor != "White") { return "Tomato"; }
            if (MfgSourceBoxColor != "White") { return "Tomato"; }
            if (MsrpBoxColor != "White") { return "Tomato"; }
            if (MsrpCadBoxColor != "White") { return "Tomato"; }
            if (MsrpMxnBoxColor != "White") { return "Tomato"; }
            if (PricingGroupBoxColor != "White") { return "Tomato"; }
            if (PrintOnDemandBoxColor != "White") { return "Tomato"; }
            if (ProductFormatBoxColor != "White") { return "Tomato"; }
            if (ProductGroupBoxColor != "White") { return "Tomato"; }
            if (ProductIdTranslationBoxColor != "White") { return "Tomato"; }
            if (ProductLineBoxColor != "White") { return "Tomato"; }
            if (ProductQtyBoxColor != "White") { return "Tomato"; }
            if (PsStatusBoxColor != "White") { return "Tomato"; }
            if (SatCodeBoxColor != "White") { return "Tomato"; }
            if (StandardCostBoxColor != "White") { return "Tomato"; }
            if (StatsCodeBoxColor != "White") { return "Tomato"; }
            if (TariffCodeBoxColor != "White") { return "Tomato"; }
            if (TerritoryBoxColor != "White") { return "Tomato"; }
            if (UdexBoxColor != "White") { return "Tomato"; }
            if (UpcBoxColor != "White") { return "Tomato"; }
            if (WeightBoxColor != "White") { return "Tomato"; }
            if (WidthBoxColor != "White") { return "Tomato"; }
            return "White";
        }

        /// <summary>
        ///     Checks the Web Flags box colors and assigns the appropirate color to the web flag tab
        /// </summary>
        /// <returns></returns>
        private string CheckWebFlagsTabColor()
        {
            if (SellOnAllPostersBoxColor != "White") { return "Tomato"; }
            if (SellOnAmazonBoxColor != "White") { return "Tomato";  }
            if (SellOnFanaticsBoxColor != "White") { return "Tomato"; }
            if (SellOnGuitarCenterBoxColor != "White") { return "Tomato"; }
            if (SellOnHayneedleBoxColor != "White") { return "Tomato"; }
            if (SellOnTargetBoxColor != "White") { return "Tomato"; }
            if (SellOnTrendsBoxColor != "White") { return "Tomato"; }
            if (SellOnWalmartBoxColor != "White") { return "Tomato"; }
            if (SellOnWayfairBoxColor != "White") { return "Tomato"; }
            return "White";
        }

        /// <summary>
        ///     Checks the Web Field box colors and assigns the appropirate color to the web tab
        /// </summary>
        /// <returns></returns>
        private string CheckWebInfoTabColor()
        {
            if (CopyrightBoxColor != "White") { return "Tomato"; }
            if (InStockDateBoxColor != "White") { return "Tomato"; }
            if (CategoryBoxColor != "White") { return "Tomato"; }
            if (Category2BoxColor != "White") { return "Tomato"; }
            if (Category3BoxColor != "White") { return "Tomato"; }
            if (ItemKeywordsBoxColor != "White") { return "Tomato"; }
            if (TitleBoxColor != "White") { return "Tomato"; }
            if (LicenseBoxColor != "White") { return "Tomato"; }
            if (MetaDescriptionBoxColor != "White") { return "Tomato"; }
            if (PropertyBoxColor != "White") { return "Tomato"; }
            if (ShortDescriptionBoxColor != "White") { return "Tomato"; }
            if (SizeBoxColor != "White") { return "Tomato"; }
            if (WebsitePriceBoxColor != "White") { return "Tomato"; }
            return "White";
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
        ///     Retrieves and refreshes the properties that align with the given license.
        /// </summary>
        /// <param name="license"></param>
        private void RefreshPropertyList(string license)
        {
            this.PropertyList = ItemService.RetrievePropertyList(license);
        }

        /// <summary>
        ///     Removes current item from main window item list
        /// </summary>
        public void RemoveItem()
        {
            this.Remove = true;
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
        ///     Sets the combo box values and refreshes the values assigned to them
        /// </summary>
        /// <param name="item"></param>
        private void SetOptions(ItemObject item)
        {
            foreach(KeyValuePair<string,string> x in GlobalData.CountriesOfOrigin)
            {
                this.CountriesOfOrigin.Add(x.Key);
            }
            RefreshProductLines();
            this.ProductLine = "";
            this.ProductLine = item.ProductLine;
            RefreshProductFormats(ProductLine);
            this.ProductFormat = "";
            this.ProductFormat = item.ProductFormat;
            RefreshPropertyList(item.License);
            this.Property = "";
            this.Property = item.Property;
        }

        /// <summary>
        ///     Sets the item viewmodel images
        /// </summary>
        private void SetImages()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.ItemViewModelItem.ImagePath))
                {
                    if (File.Exists(this.ItemViewModelItem.ImagePath))
                    {
                        Image1 = new BitmapImage(new Uri(this.ItemViewModelItem.ImagePath));
                    }
                    else
                    {
                        Image1 = new BitmapImage();
                    }
                }
                else
                {
                    Image1 = new BitmapImage();
                }
                if (!string.IsNullOrEmpty(this.ItemViewModelItem.AltImageFile1))
                {
                    if (File.Exists(this.ItemViewModelItem.AltImageFile1))
                    {
                        Image2 = new BitmapImage(new Uri(this.ItemViewModelItem.AltImageFile1));
                    }
                    else
                    {
                        Image2 = new BitmapImage();
                    }
                }
                else
                {
                    Image2 = new BitmapImage();
                }
                if (!string.IsNullOrEmpty(this.ItemViewModelItem.AltImageFile2))
                {
                    if (File.Exists(this.ItemViewModelItem.AltImageFile2))
                    {
                        Image3 = new BitmapImage(new Uri(this.ItemViewModelItem.AltImageFile2));
                    }
                    else
                    {
                        Image3 = new BitmapImage();
                    }
                }
                else
                {
                    Image3 = new BitmapImage();
                }
                if (!string.IsNullOrEmpty(this.ItemViewModelItem.AltImageFile3))
                {
                    if (File.Exists(this.ItemViewModelItem.AltImageFile3))
                    {
                        Image4 = new BitmapImage(new Uri(this.ItemViewModelItem.AltImageFile3));
                    }
                    else
                    {
                        Image4 = new BitmapImage();
                    }
                }
                else
                {
                    Image4 = new BitmapImage();
                }
                if (!string.IsNullOrEmpty(this.ItemViewModelItem.AltImageFile4))
                {
                    if (File.Exists(this.ItemViewModelItem.AltImageFile4))
                    {
                        Image5 = new BitmapImage(new Uri(this.ItemViewModelItem.AltImageFile4));
                    }
                    else
                    {
                        Image5 = new BitmapImage();
                    }
                }
                else
                {
                    Image5 = new BitmapImage();
                }
            }
            catch(Exception ex)
            {
                ErrorLog.LogError("Odin could not load 1 or more image files.", ex.ToString());
            }
        }

        /// <summary>
        ///     Sets 'IsNew' field
        /// </summary>
        /// <param name="value"></param>
        private void SetIsUpdate(string value)
        {
            if (value == "Add")
            {
                this.IsNew = true;
            }
            else
                this.IsNew = false;
        }

        /// <summary>
        ///     Sets the default tool tip values for the template viewmodel fields
        /// </summary>
        public void SetToolTips()
        {
            this.AccountingGroupToolTip = ReturnToolTip("AccountingGroup");
            this.AltImageFile1ToolTip = ReturnToolTip("AltImageFileToolTip");
            this.AltImageFile2ToolTip = ReturnToolTip("AltImageFileToolTip");
            this.AltImageFile3ToolTip = ReturnToolTip("AltImageFileToolTip");
            this.AltImageFile4ToolTip = ReturnToolTip("AltImageFileToolTip");
            this.BillOfMaterialsToolTip = ReturnToolTip("BillOfMaterials");
            this.CasepackHeightToolTip = ReturnToolTip("CasepackDimension");
            this.CasepackLengthToolTip = ReturnToolTip("CasepackDimension");
            this.CasepackQtyToolTip = ReturnToolTip("CasepackQty");
            this.CasepackUpcToolTip = ReturnToolTip("CasepackUpc");
            this.CasepackWidthToolTip = ReturnToolTip("CasepackDimension");
            this.CasepackWeightToolTip = ReturnToolTip("CasepackDimension");
            this.CategoryToolTip = ReturnToolTip("Category");
            this.Category2ToolTip = ReturnToolTip("Category");
            this.Category3ToolTip = ReturnToolTip("Category");
            this.ColorToolTip = ReturnToolTip("Color");
            this.CopyrightToolTip = ReturnToolTip("Copyright");
            this.CostProfileGroupToolTip = ReturnToolTip("CostProfileGroup");
            this.CountryOfOriginToolTip = ReturnToolTip("CountryOfOrigin");
            this.DefaultActualCostUsdToolTip = ReturnToolTip("DefaultActualCost");
            this.DefaultActualCostCadToolTip = ReturnToolTip("DefaultActualCost");
            this.DescriptionToolTip = ReturnToolTip("Description");
            this.DirectImportToolTip = ReturnToolTip("DirectImport");
            this.DutyToolTip = ReturnToolTip("Duty");
            this.EanToolTip = ReturnToolTip("Ean");
            this.Ecommerce_AsinToolTip = ReturnToolTip("Ecommerce_AsinToolTip");
            this.Ecommerce_Bullet1ToolTip = ReturnToolTip("Ecommerce_BulletToolTip");
            this.Ecommerce_Bullet2ToolTip = ReturnToolTip("Ecommerce_BulletToolTip");
            this.Ecommerce_Bullet3ToolTip = ReturnToolTip("Ecommerce_BulletToolTip");
            this.Ecommerce_Bullet4ToolTip = ReturnToolTip("Ecommerce_BulletToolTip");
            this.Ecommerce_Bullet5ToolTip = ReturnToolTip("Ecommerce_BulletToolTip");
            this.Ecommerce_ComponentsToolTip = ReturnToolTip("Ecommerce_ComponentsToolTip");
            this.Ecommerce_CostToolTip = ReturnToolTip("Ecommerce_CostToolTip");
            this.Ecommerce_ExternalIdToolTip = ReturnToolTip("Ecommerce_ExternalIdToolTip");
            this.Ecommerce_ExternalIdTypeToolTip = ReturnToolTip("Ecommerce_ExternalIdTypeToolTip");
            this.Ecommerce_ItemHeightToolTip = ReturnToolTip("Ecommerce_ItemHeightToolTip");
            this.Ecommerce_ItemLengthToolTip = ReturnToolTip("Ecommerce_ItemLengthToolTip");
            this.Ecommerce_ItemNameToolTip = ReturnToolTip("Ecommerce_ItemNameToolTip");
            this.Ecommerce_ItemWeightToolTip = ReturnToolTip("Ecommerce_ItemWeightToolTip");
            this.Ecommerce_ItemWidthToolTip = ReturnToolTip("Ecommerce_ItemWidthToolTip");
            this.Ecommerce_ModelNameToolTip = ReturnToolTip("Ecommerce_ModelNameToolTip");
            this.Ecommerce_PackageHeightToolTip = ReturnToolTip("Ecommerce_PackageHeightToolTip");
            this.Ecommerce_PackageLengthToolTip = ReturnToolTip("Ecommerce_PackageLengthToolTip");
            this.Ecommerce_PackageWeightToolTip = ReturnToolTip("Ecommerce_PackageWeightToolTip");
            this.Ecommerce_PackageWidthToolTip = ReturnToolTip("Ecommerce_PackageWidthToolTip");
            this.Ecommerce_PageQtyToolTip = ReturnToolTip("Ecommerce_PageQtyToolTip");
            this.Ecommerce_ProductCategoryToolTip = ReturnToolTip("Ecommerce_ProductCategoryToolTip");
            this.Ecommerce_ProductDescriptionToolTip = ReturnToolTip("Ecommerce_ProductDescriptionToolTip");
            this.Ecommerce_ProductSubcategoryToolTip = ReturnToolTip("Ecommerce_ProductSubcategoryToolTip");
            this.Ecommerce_ManufacturerNameToolTip = ReturnToolTip("Ecommerce_ManufacturerNameToolTip");
            this.Ecommerce_MsrpToolTip = ReturnToolTip("Ecommerce_MsrpToolTip");
            this.Ecommerce_SearchTermsToolTip = ReturnToolTip("Ecommerce_SearchTermsToolTip");
            this.Ecommerce_SizeToolTip = ReturnToolTip("Ecommerce_SizeToolTip");
            this.Ecommerce_UpcToolTip = ReturnToolTip("Ecommerce_UpcToolTip");
            this.GpcToolTip = ReturnToolTip("Gpc");
            this.HeightToolTip = ReturnToolTip("Height");
            this.ImagePathToolTip = ReturnToolTip("ImagePath");
            this.InnerpackHeightToolTip = ReturnToolTip("InnerpackDimension");
            this.InnerpackLengthToolTip = ReturnToolTip("InnerpackDimension");
            this.InnerpackQuantityToolTip = ReturnToolTip("InnerpackQuantity");
            this.InnerpackUpcToolTip = ReturnToolTip("InnerpackUpc");
            this.InnerpackWeightToolTip = ReturnToolTip("InnerpackDimension");
            this.InnerpackWidthToolTip = ReturnToolTip("InnerpackDimension");
            this.InStockDateToolTip = ReturnToolTip("InStockDate");
            this.IsbnToolTip = ReturnToolTip("Isbn");
            this.ItemCategoryToolTip = ReturnToolTip("ItemCategory");
            this.ItemFamilyToolTip = ReturnToolTip("ItemFamily");
            this.ItemGroupToolTip = ReturnToolTip("ItemGroup");
            this.ItemIdToolTip = ReturnToolTip("ItemId");
            this.ItemKeywordsToolTip = ReturnToolTip("ItemKeywords");
            this.LanguageToolTip = ReturnToolTip("Language");
            this.LengthToolTip = ReturnToolTip("Length");
            this.LicenseToolTip = ReturnToolTip("License");
            this.LicenseBeginDateToolTip = ReturnToolTip("LicenseBeginDate");
            this.ListPriceCadToolTip = ReturnToolTip("ListPrice");
            this.ListPriceMxnToolTip = ReturnToolTip("ListPrice");
            this.ListPriceUsdToolTip = ReturnToolTip("ListPrice");
            this.MetaDescriptionToolTip = ReturnToolTip("MetaDescription");
            this.MfgSourceToolTip = ReturnToolTip("MfgSource");
            this.MsrpToolTip = ReturnToolTip("Msrp");
            this.MsrpCadToolTip = ReturnToolTip("Msrp");
            this.MsrpMxnToolTip = ReturnToolTip("Msrp");
            this.PricingGroupToolTip = ReturnToolTip("PricingGroup");
            this.PrintOnDemandToolTip = ReturnToolTip("PrintOnDemand");
            this.ProductFormatToolTip = ReturnToolTip("ProductFormat");
            this.ProductGroupToolTip = ReturnToolTip("ProductGroup");
            this.ProductIdTranslationToolTip = ReturnToolTip("ProductIdTranslation");
            this.ProductLineToolTip = ReturnToolTip("ProductLine");
            this.ProductQtyToolTip = ReturnToolTip("ProductQty");
            this.PropertyToolTip = ReturnToolTip("Property");
            this.PsStatusToolTip = ReturnToolTip("PsStatus");
            this.SatCodeToolTip = ReturnToolTip("SatCode");
            this.SellOnAllPostersToolTip = ReturnToolTip("SellOnAllPosters");
            this.SellOnAmazonToolTip = ReturnToolTip("SellOnAmazon");
            this.SellOnFanaticsToolTip = ReturnToolTip("SellOnFanatics");
            this.SellOnGuitarCenterToolTip = ReturnToolTip("SellOnGuitarCenter");
            this.SellOnHayneedleToolTip = ReturnToolTip("SellOnHayneedle");
            this.SellOnTargetErrorToolTip = ReturnToolTip("SellOnTarget");
            this.SellOnTrendsToolTip = ReturnToolTip("SellOnTrends");
            this.SellOnWalmartToolTip = ReturnToolTip("SellOnWalmart");
            this.SellOnWayfairToolTip = ReturnToolTip("SellOnWayfair");
            this.ShortDescriptionToolTip = ReturnToolTip("ShortDescription");
            this.SizeToolTip = ReturnToolTip("Size");
            this.StandardCostToolTip = ReturnToolTip("StandardCost");
            this.StatsCodeToolTip = ReturnToolTip("StatsCode");
            this.TariffCodeToolTip = ReturnToolTip("TariffCode");
            this.TerritoryToolTip = ReturnToolTip("Territory");
            this.TitleToolTip = ReturnToolTip("Title");
            this.UdexToolTip = ReturnToolTip("Udex");
            this.UpcToolTip = ReturnToolTip("Upc");
            this.WebsitePriceToolTip = ReturnToolTip("WebsitePrice");
            this.WeightToolTip = ReturnToolTip("Weight");
            this.WidthToolTip = ReturnToolTip("Width");
        }

        /// <summary>
        ///     Submits current item and any changes made back to the main window view model.
        /// </summary>
        /// <returns></returns>
        public bool SubmitItem()
        {
            ObservableCollection<ItemError> errors = ItemService.ValidateAllItem(ItemViewModelItem, ItemIds, false);
            
            List<string> errorMessages = new List<string>();
            if (errors.Count != 0)
            {
                for (int i = (errors.Count - 1); i >= 0; i--)
                {
                    errorMessages.Add(errors[i].ErrorMessage);
                    errors.Remove(errors[i]);
                }
                AlertView window = new AlertView()
                {
                    DataContext = new AlertViewModel(errorMessages, "Alert", "Please resolve the following errors before submitting.")
                };
                window.ShowDialog();
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        ///     Validates all fields of current item
        /// </summary>
        /// <param name="var"></param>
        public void ValidateAll(ItemObject var)
        {
            this.AccountingGroupError = ItemService.ValidateAccountingGroup(AccountingGroup, var.ProdType);
            this.AltImageFile1Error = ItemService.ValidateImagePath(this.AltImageFile1, "Image Path 2", false);
            this.AltImageFile2Error = ItemService.ValidateImagePath(this.AltImageFile2, "Image Path 3", false);
            this.AltImageFile3Error = ItemService.ValidateImagePath(this.AltImageFile3, "Image Path 4", false);
            this.AltImageFile4Error = ItemService.ValidateImagePath(this.AltImageFile4, "Image Path 5", false);
            this.BillOfMaterialsError = ItemService.ValidateBillOfMaterials(var.ItemId, var.BillOfMaterials, this.ItemIds, var.Status, var.ProdType);
            this.CasepackHeightError = ItemService.ValidateCasepack(var.CasepackHeight, var.CasepackLength, var.CasepackWeight, var.CasepackWidth, var.ProdType, "Casepack Height");
            this.CasepackLengthError = ItemService.ValidateCasepack(var.CasepackHeight, var.CasepackLength, var.CasepackWeight, var.CasepackWidth, var.ProdType, "Casepack Length");
            this.CasepackWeightError = ItemService.ValidateCasepack(var.CasepackHeight, var.CasepackLength, var.CasepackWeight, var.CasepackWidth, var.ProdType, "Casepack Weight");
            this.CasepackWidthError = ItemService.ValidateCasepack(var.CasepackHeight, var.CasepackLength, var.CasepackWeight, var.CasepackWidth, var.ProdType, "Casepack Width");
            this.CasepackQtyError = ItemService.ValidateCasepackQty(var.CasepackQty, var.ProdType);
            this.CasepackUpcError = ItemService.ValidatePackUpc(var.CasepackUpc, "Casepack", var.ProdType);
            this.CategoryError = ItemService.ValidateCategory(var.Category, var.HasWeb());
            this.Category2Error = ItemService.ValidateCategory2(var.Category2, "2");
            this.Category3Error = ItemService.ValidateCategory2(var.Category3, "3");
            this.ColorError = ItemService.ValidateColor(var.Color, var.ProdType);
            this.CopyrightError = ItemService.ValidateCopyright(var.Copyright);
            this.CountryOfOriginError = ItemService.ValidateCountryOfOrigin(var.CountryOfOrigin, var.ListPriceUsd, var.ProdType);
            this.CostProfileGroupError = ItemService.ValidateCostProfileGroup(var.CostProfileGroup, var.MfgSource, var.ProdType);
            this.DefaultActualCostCadError = ItemService.ValidateDefaultActualCost(var.DefaultActualCostCad, "CAD", var.ProdType);
            this.DefaultActualCostUsdError = ItemService.ValidateDefaultActualCost(var.DefaultActualCostUsd, "USD", var.ProdType);
            this.DescriptionError = ItemService.ValidateDescription(var.Description, var.ProdType);
            this.DutyError = ItemService.ValidateDuty(var.Duty, var.ProdType);
            this.EanError = ItemService.ValidateEan(var.Ean, var.Upc, var.ListPriceUsd, var.ProductFormat, var.ProductLine);
            this.GpcError = ItemService.ValidateGpc(var.Gpc, var.ListPriceUsd, var.ProdType);
            this.HeightError = ItemService.ValidateHeight(var.Height, var.ProdType);
            this.ImagePathError = ItemService.ValidateImagePath(this.ImagePath, "ImagePath", this.ItemViewModelItem.HasEcommerce());
            this.InnerpackHeightError = ItemService.ValidateInnerpack(var.InnerpackHeight, var.InnerpackLength, var.InnerpackWeight, var.InnerpackWidth, var.ProdType, "Innerpack Height");
            this.InnerpackLengthError = ItemService.ValidateInnerpack(var.InnerpackHeight, var.InnerpackLength, var.InnerpackWeight, var.InnerpackWidth, var.ProdType, "Innerpack Length");
            this.InnerpackWidthError = ItemService.ValidateInnerpack(var.InnerpackHeight, var.InnerpackLength, var.InnerpackWeight, var.InnerpackWidth, var.ProdType, "Innerpack Width");
            this.InnerpackWeightError = ItemService.ValidateInnerpack(var.InnerpackHeight, var.InnerpackLength, var.InnerpackWeight, var.InnerpackWidth, var.ProdType, "Innerpack Weight");
            this.InnerpackUpcError = ItemService.ValidatePackUpc(var.InnerpackUpc, "Innerpack", var.ProdType);
            this.InnerpackQuantityError = ItemService.ValidateInnerpackQuantity(var.InnerpackQuantity, var.ProdType);
            this.InStockDateError = ItemService.ValidateInStockDate(var.InStockDate);
            this.IsbnError = ItemService.ValidateIsbn(var.Isbn, var.ProdType);
            this.ItemCategoryError = ItemService.ValidateItemCategory(var.ItemCategory, var.ProdType);
            this.ItemFamilyError = ItemService.ValidateItemFamily(var.ItemFamily, var.ProdType);
            this.ItemGroupError = ItemService.ValidateItemGroup(var.ItemGroup, var.ProdType);
            this.ItemIdError = ItemService.ValidateItemId(var.ItemId, var.Status);
            this.ItemKeywordsError = ItemService.ValidateItemKeywords(var.ItemKeywords, var.HasWeb());
            this.LanguageError = ItemService.ValidateLanguage(var.Language, var.ListPriceUsd, var.ProdType);
            this.LengthError = ItemService.ValidateLength(var.Length, var.ProdType);
            this.LicenseBeginDateError = ItemService.ValidateLicenseBeginDate(var.LicenseBeginDate, var.ProdType);
            this.LicenseError = ItemService.ValidateLicense(var.License);
            this.ListPriceCadError = ItemService.ValidateListPrice(var.ListPriceCad, "CAD", var.ProdType);
            this.ListPriceMxnError = ItemService.ValidateListPrice(var.ListPriceMxn, "MXN", var.ProdType);
            this.ListPriceUsdError = ItemService.ValidateListPrice(var.ListPriceUsd, "USD", var.ProdType);
            this.MfgSourceError = ItemService.ValidateMfgSource(var.MfgSource, var.CostProfileGroup, var.ProdType);
            this.MsrpError = ItemService.ValidateMsrp(var.Msrp, var.ListPriceUsd, var.ProdType, "USD");
            this.MsrpCadError = ItemService.ValidateMsrp(var.MsrpCad, var.ListPriceCad, var.ProdType, "CAD");
            this.MsrpMxnError = ItemService.ValidateMsrp(var.MsrpMxn, var.ListPriceMxn, var.ProdType, "MXN");
            this.ProductFormatError = ItemService.ValidateProductFormat(var.ProductGroup, var.ProductLine, var.ProductFormat, var.Upc, var.ProdType);
            this.ProductGroupError = ItemService.ValidateProductGroup(var.ProductGroup,var.Upc, var.ProdType);
            this.ProductLineError = ItemService.ValidateProductLine(var.ProductGroup, var.ProductLine, var.Upc, var.ProdType);
            this.PricingGroupError = ItemService.ValidatePricingGroup(var.PricingGroup, var.ListPriceCad, var.ListPriceUsd, var.ProdType);
            this.PrintOnDemandError = ItemService.ValidatePrintOnDemand(var.PrintOnDemand, var.ProdType);
            this.PropertyError = ItemService.ValidateProperty(var.Property, var.License);
            this.PsStatusError = ItemService.ValidatePsStatus(var.PsStatus, "Item");
            this.SatCodeError = ItemService.ValidateSatCode(var.SatCode);
            this.SellOnAllPostersError = ItemService.ValidateSellOnValue(this.SellOnAllPosters, "All Posters");
            this.SellOnAmazonError = ItemService.ValidateSellOnValue(this.SellOnAmazon, "Amazon");
            this.SellOnFanaticsError = ItemService.ValidateSellOnValue(this.SellOnFanatics, "Fanatics");
            this.SellOnGuitarCenterError = ItemService.ValidateSellOnValue(this.SellOnGuitarCenter, "Guitar Center");
            this.SellOnHayneedleError = ItemService.ValidateSellOnValue(this.SellOnHayneedle, "Hayneedle");
            this.SellOnTargetError = ItemService.ValidateSellOnValue(this.SellOnTarget, "Target");
            this.SellOnTrendsError = ItemService.ValidateSellOnValue(this.SellOnTrends, "Trends");
            this.SellOnWalmartError = ItemService.ValidateSellOnValue(this.SellOnWalmart, "Walmart");
            this.SellOnWayfairError = ItemService.ValidateSellOnValue(this.SellOnWayfair, "Wayfair");
            this.ShortDescriptionError = ItemService.ValidateShortDescription(var.ShortDescription);
            this.SizeError = ItemService.ValidateSize(var.Size);
            this.StandardCostError = ItemService.ValidateStandardCost(var.StandardCost, var.ProdType);
            this.StatsCodeError = ItemService.ValidateStatsCode(var.StatsCode, var.ListPriceUsd, var.ProdType);
            this.TariffCodeError = ItemService.ValidateTariffCode(var.TariffCode, var.ProdType);
            this.TerritoryError = ItemService.ValidateTerritory(var.Territory, var.ListPriceUsd, var.ProdType);
            this.TitleError = ItemService.ValidateTitle(var.Title, var.HasWeb());
            this.UdexError = ItemService.ValidateUdex(var.Udex, var.ProdType);
            this.UpcError = ItemService.ValidateUpc(var.Upc, this.ItemId, this.Status, var.ListPriceUsd, var.ProductFormat, var.ProductGroup, var.ProductLine, var.Ean, var.Ecommerce_Upc, var.ProdType);
            this.WebsitePriceError = ItemService.ValidateWebsitePrice(var.WebsitePrice, var.HasWeb());
            this.WeightError = ItemService.ValidateWeight(var.Weight, var.ProdType);
            this.WidthError = ItemService.ValidateWidth(var.Width, var.ProdType);
            ValidateEcommerce();
        }

        /// <summary>
        ///     Validate all ecommerce fields
        /// </summary>
        public void ValidateEcommerce()
        {
            this.Ecommerce_AsinError = ItemService.ValidateEcommerce_Asin(this.Ecommerce_Asin);
            this.Ecommerce_Bullet1Error = ItemService.ValidateEcommerce_Bullet(this.Ecommerce_Bullet1, "1", this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_Bullet2Error = ItemService.ValidateEcommerce_Bullet(this.Ecommerce_Bullet2, "2", this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_Bullet3Error = ItemService.ValidateEcommerce_Bullet(this.Ecommerce_Bullet3, "3", this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_Bullet4Error = ItemService.ValidateEcommerce_Bullet(this.Ecommerce_Bullet4, "4", false);
            this.Ecommerce_Bullet5Error = ItemService.ValidateEcommerce_Bullet(this.Ecommerce_Bullet5, "5", false);
            this.Ecommerce_ComponentsError = ItemService.ValidateEcommerce_Components(this.Ecommerce_Components, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_CostError = ItemService.ValidateEcommerce_Cost(this.Ecommerce_Cost, "", this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_ExternalIdTypeError = ItemService.ValidateEcommerce_ExternalIdType(this.Ecommerce_ExternalIdType, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_ExternalIdError = ItemService.ValidateEcommerce_ExternalId(this.Ecommerce_ExternalId, this.Ecommerce_ExternalIdType, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_ItemHeightError = ItemService.ValidateEcommerce_ItemHeight(this.Ecommerce_ItemHeight, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_ItemLengthError = ItemService.ValidateEcommerce_ItemLength(this.Ecommerce_ItemLength, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_ItemNameError = ItemService.ValidateEcommerce_ItemName(this.Ecommerce_ItemName, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_ItemWeightError = ItemService.ValidateEcommerce_ItemWeight(this.Ecommerce_ItemWeight, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_ItemWidthError = ItemService.ValidateEcommerce_ItemWidth(this.Ecommerce_ItemWidth, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_ModelNameError = ItemService.ValidateEcommerce_ModelName(this.Ecommerce_ModelName, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_PackageHeightError = ItemService.ValidateEcommerce_PackageHeight(this.Ecommerce_PackageHeight, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_PackageLengthError = ItemService.ValidateEcommerce_PackageLength(this.Ecommerce_PackageLength, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_PackageWeightError = ItemService.ValidateEcommerce_PackageWeight(this.Ecommerce_PackageWeight, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_PackageWidthError = ItemService.ValidateEcommerce_PackageWidth(this.Ecommerce_PackageWidth, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_PageQtyError = ItemService.ValidateEcommerce_PageQty(this.Ecommerce_PageQty);
            this.Ecommerce_ProductCategoryError = ItemService.ValidateEcommerce_ProductCategory(this.Ecommerce_ProductCategory, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_ProductDescriptionError = ItemService.ValidateEcommerce_ProductDescription(this.Ecommerce_ProductDescription, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_ProductSubcategoryError = ItemService.ValidateEcommerce_ProductSubcategory(this.Ecommerce_ProductSubcategory, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_ManufacturerNameError = ItemService.ValidateEcommerce_ManufacturerName(this.Ecommerce_ManufacturerName, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_MsrpError = ItemService.ValidateEcommerce_Msrp(this.Ecommerce_Msrp, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_SearchTermsError = ItemService.ValidateEcommerce_SearchTerms(this.Ecommerce_SearchTerms, this.ItemViewModelItem.HasEcommerce(), this.Status);
            this.Ecommerce_SizeError = ItemService.ValidateEcommerce_Size(this.Ecommerce_Size, this.ItemViewModelItem.HasEcommerce());
            this.Ecommerce_UpcError = ItemService.ValidateEcommerce_Upc(this.Ecommerce_Upc, this.ItemId, this.Upc, this.Status, this.ItemViewModelItem.HasEcommerce());
        }

        #endregion //Methods

        #region Constructor

        /// <summary>
        ///     Constructs Item View Model Object
        /// </summary>
        /// <param name="itemObj"></param>
        /// <param name="itemService"></param>
        public ItemViewModel(ItemObject itemObj, ItemService itemService, List<string> itemIds)
        {
            if (itemService == null) { throw new ArgumentNullException("itemService"); }    
            this.ItemService = itemService ?? throw new ArgumentNullException("itemService");
            this.ItemIds = itemIds;
            this.ItemViewModelItem = (itemObj.Clone() as ItemObject);
            SetOptions(itemObj);
            SetToolTips();
            SetImages();
            SetIsUpdate(itemObj.Status);            
            this.BlockInfo = true;
            ValidateAll(this.ItemViewModelItem);
        }

        #endregion // Constructor
    }
}
