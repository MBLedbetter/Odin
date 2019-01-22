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
                    FlagError("BillOfMaterials");
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
                    FlagError("CasepackUpc");
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
                    FlagError("Color");
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
                    FlagError("Description");
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
                    FlagError("DirectImport");
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
                    FlagError("Ean");
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
                    FlagError("InnerpackUpc");
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
                    FlagError("Isbn");
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
                    FlagError("ItemId");
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
                    FlagError("Language");
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
                    FlagError("LicenseBeginDate");
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
                    FlagError("ProductIdTranslation");
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
        ///     Gets or sets the SellOnAllPostersCheck
        /// </summary>
        public bool SellOnAllPostersCheck
        {
            get
            {
                return DbUtil.ConvertToBool(this.ItemViewModelItem.SellOnAllPosters);
            }
            set
            {
                if (this.ItemViewModelItem.SellOnAllPosters != DbUtil.ConvertYN(value))
                {
                    this.ItemViewModelItem.SellOnAllPosters = DbUtil.ConvertYN(value);
                    FlagError("SellOnAllPostersCheck");
                    OnPropertyChanged("SellOnAllPostersCheck");
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
        ///     Gets or sets the SellOnAmazonCheck
        /// </summary>
        public bool SellOnAmazonCheck
        {
            get
            {
                return DbUtil.ConvertToBool(this.ItemViewModelItem.SellOnAmazon);
            }
            set
            {
                if (this.ItemViewModelItem.SellOnAmazon != DbUtil.ConvertYN(value))
                {
                    this.ItemViewModelItem.SellOnAmazon = DbUtil.ConvertYN(value);
                    FlagError("SellOnAmazonCheck");
                    OnPropertyChanged("SellOnAmazonCheck");
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
        ///     Gets or sets the SellOnAmazonSellerCentralCheck
        /// </summary>
        public bool SellOnAmazonSellerCentralCheck
        {
            get
            {
                return DbUtil.ConvertToBool(this.ItemViewModelItem.SellOnAmazonSellerCentral);
            }
            set
            {
                if (this.ItemViewModelItem.SellOnAmazonSellerCentral != DbUtil.ConvertYN(value))
                {
                    this.ItemViewModelItem.SellOnAmazonSellerCentral = DbUtil.ConvertYN(value);
                    FlagError("SellOnAmazonSellerCentralCheck");
                    OnPropertyChanged("SellOnAmazonSellerCentralCheck");
                }
            }
        }
        public string SellOnAmazonSellerCentralBoxColor
        {
            get
            {
                return _sellOnAmazonSellerCentralBoxColor;
            }
            set
            {
                _sellOnAmazonSellerCentralBoxColor = value;
                OnPropertyChanged("SellOnAmazonSellerCentralBoxColor");
            }
        }
        private string _sellOnAmazonSellerCentralBoxColor = "White";
        public string SellOnAmazonSellerCentralError
        {
            get
            {
                return _sellOnAmazonSellerCentralError;
            }
            set
            {
                _sellOnAmazonSellerCentralError = value;
                if (value != "")
                {
                    SellOnAmazonSellerCentralToolTip = "Error: " + value + "\n\n" + ReturnToolTip("SellOnAmazonSellerCentral");
                }
                else
                {
                    SellOnAmazonSellerCentralToolTip = ReturnToolTip("SellOnAmazonSellerCentral");
                }
                this.SellOnAmazonSellerCentralBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorWebFlag = CheckWebFlagsTabColor();
                OnPropertyChanged("SellOnAmazonSellerCentralError");
            }
        }
        private string _sellOnAmazonSellerCentralError = string.Empty;
        public string SellOnAmazonSellerCentralToolTip
        {
            get
            {
                return _sellOnAmazonSellerCentralToolTip;
            }
            set
            {
                this._sellOnAmazonSellerCentralToolTip = value;
                OnPropertyChanged("SellOnAmazonSellerCentralToolTip");
            }
        }
        private string _sellOnAmazonSellerCentralToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the Sell On Ecommerce
        /// </summary>
        public bool SellOnEcommerceCheck
        {
            get
            {
                return DbUtil.ConvertToBool(this.ItemViewModelItem.SellOnEcommerce);
            }
            set
            {
                if (this.ItemViewModelItem.SellOnEcommerce != DbUtil.ConvertYN(value))
                {
                    this.ItemViewModelItem.SellOnEcommerce = DbUtil.ConvertYN(value);
                    FlagError("SellOnEcommerceCheck");
                    OnPropertyChanged("SellOnEcommerceCheck");
                }
            }
        }
        public string SellOnEcommerceBoxColor
        {
            get
            {
                return _sellOnEcommerceBoxColor;
            }
            set
            {
                _sellOnEcommerceBoxColor = value;
                OnPropertyChanged("SellOnEcommerceBoxColor");
            }
        }
        private string _sellOnEcommerceBoxColor = "White";
        public string SellOnEcommerceError
        {
            get
            {
                return _sellOnEcommerceError;
            }
            set
            {
                _sellOnEcommerceError = value;
                if (value != "")
                {
                    SellOnEcommerceToolTip = "Error: " + value + "\n\n" + ReturnToolTip("SellOnEcommerce");
                }
                else
                {
                    SellOnEcommerceToolTip = ReturnToolTip("SellOnEcommerce");
                }
                this.SellOnEcommerceBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorWebFlag = CheckWebFlagsTabColor();
                OnPropertyChanged("SellOnEcommerceError");
            }
        }
        private string _sellOnEcommerceError = string.Empty;
        public string SellOnEcommerceToolTip
        {
            get
            {
                return _sellOnEcommerceToolTip;
            }
            set
            {
                this._sellOnEcommerceToolTip = value;
                OnPropertyChanged("SellOnEcommerceToolTip");
            }
        }
        private string _sellOnEcommerceToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the Sell On Fanatics
        /// </summary>
        public bool SellOnFanaticsCheck
        {
            get
            {
                return DbUtil.ConvertToBool(this.ItemViewModelItem.SellOnFanatics);
            }
            set
            {
                if (this.ItemViewModelItem.SellOnFanatics != DbUtil.ConvertYN(value))
                {
                    this.ItemViewModelItem.SellOnFanatics = DbUtil.ConvertYN(value);
                    FlagError("SellOnFanaticsCheck");
                    OnPropertyChanged("SellOnFanaticsCheck");
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
        public bool SellOnGuitarCenterCheck
        {
            get
            {
                return DbUtil.ConvertToBool(this.ItemViewModelItem.SellOnGuitarCenter);
            }
            set
            {
                if (this.ItemViewModelItem.SellOnGuitarCenter != DbUtil.ConvertYN(value))
                {
                    this.ItemViewModelItem.SellOnGuitarCenter = DbUtil.ConvertYN(value);
                    FlagError("SellOnGuitarCenterCheck");
                    OnPropertyChanged("SellOnGuitarCenterCheck");
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
        public bool SellOnHayneedleCheck
        {
            get
            {
                return DbUtil.ConvertToBool(this.ItemViewModelItem.SellOnHayneedle);
            }
            set
            {
                if (this.ItemViewModelItem.SellOnHayneedle != DbUtil.ConvertYN(value))
                {
                    this.ItemViewModelItem.SellOnHayneedle = DbUtil.ConvertYN(value);
                    FlagError("SellOnHayneedleCheck");
                    OnPropertyChanged("SellOnHayneedleCheck");
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
        public bool SellOnTargetCheck
        {
            get
            {
                return DbUtil.ConvertToBool(this.ItemViewModelItem.SellOnTarget);
            }
            set
            {
                if (this.ItemViewModelItem.SellOnTarget != DbUtil.ConvertYN(value))
                {
                    this.ItemViewModelItem.SellOnTarget = DbUtil.ConvertYN(value);
                    FlagError("SellOnTargetCheck");
                    OnPropertyChanged("SellOnTargetCheck");
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
        public bool SellOnTrendsCheck
        {
            get
            {
                return DbUtil.ConvertToBool(this.ItemViewModelItem.SellOnTrends);
            }
            set
            {
                if (DbUtil.ConvertToBool(this.ItemViewModelItem.SellOnTrends) != value)
                {
                    this.ItemViewModelItem.SellOnTrends = DbUtil.ConvertYN(value);
                    FlagError("SellOnTrendsCheck");
                    OnPropertyChanged("SellOnTrendsCheck");
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
        public bool SellOnWalmartCheck
        {
            get
            {
                return DbUtil.ConvertToBool(this.ItemViewModelItem.SellOnWalmart);
            }
            set
            {
                if (this.ItemViewModelItem.SellOnWalmart != DbUtil.ConvertYN(value))
                {
                    this.ItemViewModelItem.SellOnWalmart = DbUtil.ConvertYN(value);
                    FlagError("SellOnWalmartCheck");
                    OnPropertyChanged("SellOnWalmartCheck");
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
        public bool SellOnWayfairCheck
        {
            get
            {
                return DbUtil.ConvertToBool(this.ItemViewModelItem.SellOnWayfair);
            }
            set
            {
                if (this.ItemViewModelItem.SellOnWayfair != DbUtil.ConvertYN(value))
                {
                    this.ItemViewModelItem.SellOnWayfair = DbUtil.ConvertYN(value);
                    FlagError("SellOnWayfairCheck");
                    OnPropertyChanged("SellOnWayfairCheck");
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
                    FlagError("StandardCost");
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
                    FlagError("StatsCode");
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

                    FlagError("Territory");
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
                    FlagError("Upc");
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
        ///     Gets or sets the Upc value
        /// </summary>
        public string Warranty
        {
            get
            {
                return this.ItemViewModelItem.Warranty;
            }
            set
            {
                if (this.ItemViewModelItem.Warranty != value)
                {
                    this.ItemViewModelItem.Warranty = value;
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
                this.TabColorItemInfo = CheckItemInfoTabColor();
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
                _warrantyToolTip = value;
                OnPropertyChanged("WarrantyToolTip");
            }
        }
        private string _warrantyToolTip = string.Empty;

        /// <summary>
        ///     Gets or sets the WarrantyCheck value
        /// </summary>
        public bool WarrantyCheck
        {
            get
            {
                return DbUtil.ConvertToBool(this.ItemViewModelItem.WarrantyCheck);
            }
            set
            {
                if (this.ItemViewModelItem.WarrantyCheck != DbUtil.ConvertYN(value))
                {
                    this.ItemViewModelItem.WarrantyCheck = DbUtil.ConvertYN(value);
                    FlagError("WarrantyCheck");
                    OnPropertyChanged("WarrantyCheck");
                }
            }
        }
        public string WarrantyCheckBoxColor
        {
            get
            {
                return _warrantyCheckBoxColor;
            }
            set
            {
                _warrantyCheckBoxColor = value;
                OnPropertyChanged("WarrantyCheckBoxColor");
            }
        }
        private string _warrantyCheckBoxColor = "White";
        public string WarrantyCheckError
        {
            get
            {
                return _warrantyCheckError;
            }
            set
            {
                _warrantyCheckError = value;
                if (value != "")
                {
                    WarrantyCheckToolTip = "Error: " + value + "\n\n" + ReturnToolTip("WarrantyCheck");
                }
                else
                {
                    WarrantyCheckToolTip = ReturnToolTip("WarrantyCheck");
                }
                this.WarrantyCheckBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorItemInfo = CheckItemInfoTabColor();
                OnPropertyChanged("WarrantyCheckError");
            }
        }
        private string _warrantyCheckError = string.Empty;
        public string WarrantyCheckToolTip
        {
            get
            {
                return _warrantyCheckToolTip;
            }
            set
            {
                _warrantyCheckToolTip = value;
                OnPropertyChanged("WarrantyCheckToolTip");
            }
        }
        private string _warrantyCheckToolTip = string.Empty;

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
                    FlagError("InStockDate");
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
                    FlagError("ItemKeywords");
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
                    FlagError("Title");
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
                    FlagError("License");
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
                    FlagError("Property");
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
                    FlagError("ShortDescription");
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
                    FlagError("AltImageFile1");
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
                    FlagError("AltImageFile2");
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
                    FlagError("AltImageFile3");
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
                    FlagError("AltImageFile4");
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
                    FlagError("ImagePath");
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
        ///     EcommerceAsin
        /// </summary>
        public string EcommerceAsin
        {
            get
            {
                return this.ItemViewModelItem.EcommerceAsin;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceAsin != value)
                {
                    this.ItemViewModelItem.EcommerceAsin = value;
                    FlagError("EcommerceAsin");
                    OnPropertyChanged("EcommerceAsin");
                }
            }
        }
        public string EcommerceAsinBoxColor
        {
            get
            {
                return _EcommerceasinBoxColor;
            }
            set
            {
                _EcommerceasinBoxColor = value;
                OnPropertyChanged("Ecomemrce_AsinBoxColor");
            }
        }
        private string _EcommerceasinBoxColor = "White";
        public string EcommerceAsinError
        {
            get
            {
                return _EcommerceasinError;
            }
            set
            {
                _EcommerceasinError = value;
                if(value != "")
                {
                    EcommerceAsinToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceAsinToolTip");
                }
                else
                {
                    EcommerceAsinToolTip = ReturnToolTip("EcommerceAsinToolTip");
                }
                this.EcommerceAsinBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceAsinError");
            }
        }
        private string _EcommerceasinError = string.Empty;
        public string EcommerceAsinToolTip
        {
            get
            {
                return _EcommerceAsinToolTip;
            }
            set
            {
                this._EcommerceAsinToolTip = value;
                OnPropertyChanged("EcommerceAsinToolTip");
            }
        }
        private string _EcommerceAsinToolTip = string.Empty;

        /// <summary>
        ///     EcommerceBullet1
        /// </summary>
        public string EcommerceBullet1
        {
            get
            {
                return this.ItemViewModelItem.EcommerceBullet1;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceBullet1 != value)
                {
                    this.ItemViewModelItem.EcommerceBullet1 = value;
                    FlagError("EcommerceBullet1");
                    OnPropertyChanged("EcommerceBullet1");
                }
            }
        }
        public string EcommerceBullet1BoxColor
        {
            get
            {
                return _Ecommercebullet1BoxColor;
            }
            set
            {
                _Ecommercebullet1BoxColor = value;
                OnPropertyChanged("EcommerceBullet1BoxColor");
            }
        }
        private string _Ecommercebullet1BoxColor = "White";
        public string EcommerceBullet1Error
        {
            get
            {
                return _Ecommercebullet1Error;
            }
            set
            {
                _Ecommercebullet1Error = value;
                if (value != "")
                {
                    EcommerceBullet1ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceBulletToolTip");
                }
                else
                {
                    EcommerceBullet1ToolTip = ReturnToolTip("EcommerceBulletToolTip");
                }
                this.EcommerceBullet1BoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceBullet1Error");
            }
        }
        private string _Ecommercebullet1Error = string.Empty;
        public string EcommerceBullet1ToolTip
        {
            get
            {
                return _Ecommercebullet1ToolTip;
            }
            set
            {
                this._Ecommercebullet1ToolTip = value;
                OnPropertyChanged("EcommerceBullet1ToolTip");
            }
        }
        private string _Ecommercebullet1ToolTip = string.Empty;

        /// <summary>
        ///    EcommerceBullet2
        /// </summary>
        public string EcommerceBullet2
        {
            get
            {
                return this.ItemViewModelItem.EcommerceBullet2;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceBullet2 != value)
                {
                    this.ItemViewModelItem.EcommerceBullet2 = value;
                    FlagError("EcommerceBullet2");
                    OnPropertyChanged("EcommerceBullet2");
                }
            }
        }
        public string EcommerceBullet2BoxColor
        {
            get
            {
                return _Ecommercebullet2BoxColor;
            }
            set
            {
                _Ecommercebullet2BoxColor = value;
                OnPropertyChanged("EcommerceBullet2BoxColor");
            }
        }
        private string _Ecommercebullet2BoxColor = "White";
        public string EcommerceBullet2Error
        {
            get
            {
                return _Ecommercebullet2Error;
            }
            set
            {
                _Ecommercebullet2Error = value;
                if (value != "")
                {
                    EcommerceBullet2ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceBulletToolTip");
                }
                else
                {
                    EcommerceBullet2ToolTip = ReturnToolTip("EcommerceBulletToolTip");
                }
                this.EcommerceBullet2BoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceBullet2Error");
            }
        }
        private string _Ecommercebullet2Error = string.Empty;
        public string EcommerceBullet2ToolTip
        {
            get
            {
                return _Ecommercebullet2ToolTip;
            }
            set
            {
                this._Ecommercebullet2ToolTip = value;
                OnPropertyChanged("EcommerceBullet2ToolTip");
            }
        }
        private string _Ecommercebullet2ToolTip = string.Empty;

        /// <summary>
        ///    EcommerceBullet3
        /// </summary>
        public string EcommerceBullet3
        {
            get
            {
                return this.ItemViewModelItem.EcommerceBullet3;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceBullet3 != value)
                {
                    this.ItemViewModelItem.EcommerceBullet3 = value;
                    FlagError("EcommerceBullet2");
                    OnPropertyChanged("EcommerceBullet3");
                }
            }
        }
        public string EcommerceBullet3BoxColor
        {
            get
            {
                return _Ecommercebullet3BoxColor;
            }
            set
            {
                _Ecommercebullet3BoxColor = value;
                OnPropertyChanged("EcommerceBullet3BoxColor");
            }
        }
        private string _Ecommercebullet3BoxColor = "White";
        public string EcommerceBullet3Error
        {
            get
            {
                return _Ecommercebullet3Error;
            }
            set
            {
                _Ecommercebullet3Error = value;
                if (value != "")
                {
                    EcommerceBullet3ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceBulletToolTip");
                }
                else
                {
                    EcommerceBullet3ToolTip = ReturnToolTip("EcommerceBulletToolTip");
                }
                this.EcommerceBullet3BoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceBullet3Error");
            }
        }
        private string _Ecommercebullet3Error = string.Empty;
        public string EcommerceBullet3ToolTip
        {
            get
            {
                return _Ecommercebullet3ToolTip;
            }
            set
            {
                this._Ecommercebullet3ToolTip = value;
                OnPropertyChanged("EcommerceBullet3ToolTip");
            }
        }
        private string _Ecommercebullet3ToolTip = string.Empty;

        /// <summary>
        ///    EcommerceBullet4
        /// </summary>
        public string EcommerceBullet4
        {
            get
            {
                return this.ItemViewModelItem.EcommerceBullet4;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceBullet4 != value)
                {
                    this.ItemViewModelItem.EcommerceBullet4 = value;
                    FlagError("EcommerceBullet4");
                    OnPropertyChanged("EcommerceBullet4");
                }
            }
        }
        public string EcommerceBullet4BoxColor
        {
            get
            {
                return _Ecommercebullet4BoxColor;
            }
            set
            {
                _Ecommercebullet4BoxColor = value;
                OnPropertyChanged("EcommerceBullet4BoxColor");
            }
        }
        private string _Ecommercebullet4BoxColor = "White";
        public string EcommerceBullet4Error
        {
            get
            {
                return _Ecommercebullet4Error;
            }
            set
            {
                _Ecommercebullet4Error = value;
                if (value != "")
                {
                    EcommerceBullet4ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceBulletToolTip");
                }
                else
                {
                    EcommerceBullet4ToolTip = ReturnToolTip("EcommerceBulletToolTip");
                }
                this.EcommerceBullet4BoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceBullet4Error");
            }
        }
        private string _Ecommercebullet4Error = string.Empty;
        public string EcommerceBullet4ToolTip
        {
            get
            {
                return _Ecommercebullet4ToolTip;
            }
            set
            {
                this._Ecommercebullet4ToolTip = value;
                OnPropertyChanged("EcommerceBullet4ToolTip");
            }
        }
        private string _Ecommercebullet4ToolTip = string.Empty;

        /// <summary>
        ///    EcommerceBullet5
        /// </summary>
        public string EcommerceBullet5
        {
            get
            {
                return this.ItemViewModelItem.EcommerceBullet5;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceBullet5 != value)
                {
                    this.ItemViewModelItem.EcommerceBullet5 = value;
                    FlagError("EcommerceBullet5");
                    OnPropertyChanged("EcommerceBullet5");
                }
            }
        }
        public string EcommerceBullet5BoxColor
        {
            get
            {
                return _Ecommercebullet5BoxColor;
            }
            set
            {
                _Ecommercebullet5BoxColor = value;
                OnPropertyChanged("EcommerceBullet5BoxColor");
            }
        }
        private string _Ecommercebullet5BoxColor = "White";
        public string EcommerceBullet5Error
        {
            get
            {
                return _Ecommercebullet5Error;
            }
            set
            {
                _Ecommercebullet5Error = value;
                if (value != "")
                {
                    EcommerceBullet5ToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceBulletToolTip");
                }
                else
                {
                    EcommerceBullet5ToolTip = ReturnToolTip("EcommerceBulletToolTip");
                }
                this.EcommerceBullet5BoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceBullet5Error");
            }
        }
        private string _Ecommercebullet5Error = string.Empty;
        public string EcommerceBullet5ToolTip
        {
            get
            {
                return _Ecommercebullet5ToolTip;
            }
            set
            {
                this._Ecommercebullet5ToolTip = value;
                OnPropertyChanged("EcommerceBullet5ToolTip");
            }
        }
        private string _Ecommercebullet5ToolTip = string.Empty;

        /// <summary>
        ///    EcommerceComponents
        /// </summary>
        public string EcommerceComponents
        {
            get
            {
                return this.ItemViewModelItem.EcommerceComponents;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceComponents != value)
                {
                    this.ItemViewModelItem.EcommerceComponents = value;
                    FlagError("EcommerceComponents");
                    OnPropertyChanged("EcommerceComponents");
                }
            }
        }
        public string EcommerceComponentsBoxColor
        {
            get
            {
                return _EcommercecomponentsBoxColor;
            }
            set
            {
                _EcommercecomponentsBoxColor = value;
                OnPropertyChanged("EcommerceComponentsBoxColor");
            }
        }
        private string _EcommercecomponentsBoxColor = "White";
        public string EcommerceComponentsError
        {
            get
            {
                return _EcommercecomponentsError;
            }
            set
            {
                _EcommercecomponentsError = value;
                if (value != "")
                {
                    EcommerceComponentsToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceComponentsToolTip");
                }
                else
                {
                    EcommerceComponentsToolTip = ReturnToolTip("EcommerceComponentsToolTip");
                }
                this.EcommerceComponentsBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceComponentsError");
            }
        }
        private string _EcommercecomponentsError = string.Empty;
        public string EcommerceComponentsToolTip
        {
            get
            {
                return _EcommercecomponentsToolTip;
            }
            set
            {
                this._EcommercecomponentsToolTip = value;
                OnPropertyChanged("EcommerceComponentsToolTip");
            }
        }
        private string _EcommercecomponentsToolTip = string.Empty;

        /// <summary>
        ///    EcommerceCost
        /// </summary>
        public string EcommerceCost
        {
            get
            {
                return this.ItemViewModelItem.EcommerceCost;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceCost != value)
                {
                    this.ItemViewModelItem.EcommerceCost = value;
                    FlagError("EcommerceCost");
                    OnPropertyChanged("EcommerceCost");
                }
            }
        }
        public string EcommerceCostBoxColor
        {
            get
            {
                return _EcommerceCostBoxColor;
            }
            set
            {
                _EcommerceCostBoxColor = value;
                OnPropertyChanged("EcommerceCostBoxColor");
            }
        }
        private string _EcommerceCostBoxColor = "White";
        public string EcommerceCostError
        {
            get
            {
                return _EcommerceCostError;
            }
            set
            {
                _EcommerceCostError = value;
                if (value != "")
                {
                    EcommerceCostToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceCostToolTip");
                }
                else
                {
                    EcommerceCostToolTip = ReturnToolTip("EcommerceCostToolTip");
                }
                this.EcommerceCostBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceCostError");
            }
        }
        private string _EcommerceCostError = string.Empty;
        public string EcommerceCostToolTip
        {
            get
            {
                return _EcommerceCostToolTip;
            }
            set
            {
                this._EcommerceCostToolTip = value;
                OnPropertyChanged("EcommerceCostToolTip");
            }
        }
        private string _EcommerceCostToolTip = string.Empty;
       
        /// <summary>
        ///    EcommerceExternalId
        /// </summary>
        public string EcommerceExternalId
        {
            get
            {
                return this.ItemViewModelItem.EcommerceExternalId;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceExternalId != value)
                {
                    this.ItemViewModelItem.EcommerceExternalId = value;
                    FlagError("EcommerceExternalId");
                    OnPropertyChanged("EcommerceExternalId");
                }
            }
        }
        public string EcommerceExternalIdBoxColor
        {
            get
            {
                return _EcommerceExternalIDBoxColor;
            }
            set
            {
                _EcommerceExternalIDBoxColor = value;
                OnPropertyChanged("EcommerceExternalIdBoxColor");
            }
        }
        private string _EcommerceExternalIDBoxColor = "White";
        public string EcommerceExternalIdError
        {
            get
            {
                return _EcommerceExternalIDError;
            }
            set
            {
                _EcommerceExternalIDError = value;
                if (value != "")
                {
                    EcommerceExternalIdToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceExternalIdToolTip");
                }
                else
                {
                    EcommerceExternalIdToolTip = ReturnToolTip("EcommerceExternalIdToolTip");
                }
                this.EcommerceExternalIdBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceExternalIdError");
            }
        }
        private string _EcommerceExternalIDError = string.Empty;
        public string EcommerceExternalIdToolTip
        {
            get
            {
                return _EcommerceExternalIDToolTip;
            }
            set
            {
                this._EcommerceExternalIDToolTip = value;
                OnPropertyChanged("EcommerceExternalIdToolTip");
            }
        }
        private string _EcommerceExternalIDToolTip = string.Empty;

        /// <summary>
        ///    EcommerceExternalIdType
        /// </summary>
        public string EcommerceExternalIdType
        {
            get
            {
                return this.ItemViewModelItem.EcommerceExternalIdType;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceExternalIdType != value)
                {
                    this.ItemViewModelItem.EcommerceExternalIdType = value;
                    FlagError("EcommerceExternalIdType");
                    OnPropertyChanged("EcommerceExternalIdType");
                }
            }
        }
        public string EcommerceExternalIdTypeBoxColor
        {
            get
            {
                return _EcommerceExternalIdTypeBoxColor;
            }
            set
            {
                _EcommerceExternalIdTypeBoxColor = value;
                OnPropertyChanged("EcommerceExternalIdTypeBoxColor");
            }
        }
        private string _EcommerceExternalIdTypeBoxColor = "White";
        public string EcommerceExternalIdTypeError
        {
            get
            {
                return _EcommerceExternalIdTypeError;
            }
            set
            {
                _EcommerceExternalIdTypeError = value;
                if (value != "")
                {
                    EcommerceExternalIdTypeToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceExternalIdTypeToolTip");
                }
                else
                {
                    EcommerceExternalIdTypeToolTip = ReturnToolTip("EcommerceExternalIdTypeToolTip");
                }
                this.EcommerceExternalIdTypeBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceExternalIdTypeError");
            }
        }
        private string _EcommerceExternalIdTypeError = string.Empty;
        public string EcommerceExternalIdTypeToolTip
        {
            get
            {
                return _EcommerceExternalIdTypeToolTip;
            }
            set
            {
                this._EcommerceExternalIdTypeToolTip = value;
                OnPropertyChanged("EcommerceExternalIdTypeToolTip");
            }
        }
        private string _EcommerceExternalIdTypeToolTip = string.Empty;

        /// <summary>
        ///    EcommerceImagePath1
        /// </summary>
        public string EcommerceImagePath1
        {
            get
            {
                return this.ItemViewModelItem.EcommerceImagePath1;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceImagePath1 != value)
                {
                    this.ItemViewModelItem.EcommerceImagePath1 = value;
                    OnPropertyChanged("EcommerceImagePath1");
                }
            }
        }

        /// <summary>
        ///    EcommerceImagePath2
        /// </summary>
        public string EcommerceImagePath2
        {
            get
            {
                return this.ItemViewModelItem.EcommerceImagePath2;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceImagePath2 != value)
                {
                    this.ItemViewModelItem.EcommerceImagePath2 = value;
                    OnPropertyChanged("EcommerceImagePath2");
                }
            }
        }

        /// <summary>
        ///    EcommerceImagePath3
        /// </summary>
        public string EcommerceImagePath3
        {
            get
            {
                return this.ItemViewModelItem.EcommerceImagePath3;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceImagePath3 != value)
                {
                    this.ItemViewModelItem.EcommerceImagePath3 = value;
                    OnPropertyChanged("EcommerceImagePath3");
                }
            }
        }

        /// <summary>
        ///    EcommerceImagePath4
        /// </summary>
        public string EcommerceImagePath4
        {
            get
            {
                return this.ItemViewModelItem.EcommerceImagePath4;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceImagePath4 != value)
                {
                    this.ItemViewModelItem.EcommerceImagePath4 = value;
                    OnPropertyChanged("EcommerceImagePath4");
                }
            }
        }

        /// <summary>
        ///    EcommerceImagePath5
        /// </summary>
        public string EcommerceImagePath5
        {
            get
            {
                return this.ItemViewModelItem.EcommerceImagePath5;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceImagePath5 != value)
                {
                    this.ItemViewModelItem.EcommerceImagePath5 = value;
                    OnPropertyChanged("EcommerceImagePath5");
                }
            }
        }

        /// <summary>
        ///    EcommerceItemHeight
        /// </summary>
        public string EcommerceItemHeight
        {
            get
            {
                return this.ItemViewModelItem.EcommerceItemHeight;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceItemHeight != value)
                {
                    this.ItemViewModelItem.EcommerceItemHeight = value;
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
                return _EcommerceItemHeightError;
            }
            set
            {
                _EcommerceItemHeightError = value;
                if (value != "")
                {
                    EcommerceItemHeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceItemHeightToolTip");
                }
                else
                {
                    EcommerceItemHeightToolTip = ReturnToolTip("EcommerceItemHeightToolTip");
                }
                this.EcommerceItemHeightBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceItemHeightError");
            }
        }
        private string _EcommerceItemHeightError = string.Empty;
        public string EcommerceItemHeightToolTip
        {
            get
            {
                return _EcommerceItemHeightToolTip;
            }
            set
            {
                this._EcommerceItemHeightToolTip = value;
                OnPropertyChanged("EcommerceItemHeightToolTip");
            }
        }
        private string _EcommerceItemHeightToolTip = string.Empty;

        /// <summary>
        ///    EcommerceItemLength
        /// </summary>
        public string EcommerceItemLength
        {
            get
            {
                return this.ItemViewModelItem.EcommerceItemLength;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceItemLength != value)
                {
                    this.ItemViewModelItem.EcommerceItemLength = value;
                    FlagError("EcommerceItemLength");
                    OnPropertyChanged("EcommerceItemLength");
                }
            }
        }
        public string EcommerceItemLengthBoxColor
        {
            get
            {
                return _EcommerceItemLengthBoxColor;
            }
            set
            {
                _EcommerceItemLengthBoxColor = value;
                OnPropertyChanged("EcommerceItemLengthBoxColor");
            }
        }
        private string _EcommerceItemLengthBoxColor = "White";
        public string EcommerceItemLengthError
        {
            get
            {
                return _EcommerceItemLengthError;
            }
            set
            {
                _EcommerceItemLengthError = value;
                if (value != "")
                {
                    EcommerceItemLengthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceItemLengthToolTip");
                }
                else
                {
                    EcommerceItemLengthToolTip = ReturnToolTip("EcommerceItemLengthToolTip");
                }
                this.EcommerceItemLengthBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceItemLengthError");
            }
        }
        private string _EcommerceItemLengthError = string.Empty;
        public string EcommerceItemLengthToolTip
        {
            get
            {
                return _EcommerceItemLengthToolTip;
            }
            set
            {
                this._EcommerceItemLengthToolTip = value;
                OnPropertyChanged("EcommerceItemLengthToolTip");
            }
        }
        private string _EcommerceItemLengthToolTip = string.Empty;

        /// <summary>
        ///    EcommerceItemName
        /// </summary>
        public string EcommerceItemName
        {
            get
            {
                return this.ItemViewModelItem.EcommerceItemName;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceItemName != value)
                {
                    this.ItemViewModelItem.EcommerceItemName = value;
                    FlagError("EcommerceItemName");
                    OnPropertyChanged("EcommerceItemName");
                }
            }
        }
        public string EcommerceItemNameBoxColor
        {
            get
            {
                return _EcommerceItemNameBoxColor;
            }
            set
            {
                _EcommerceItemNameBoxColor = value;
                OnPropertyChanged("EcommerceItemNameBoxColor");
            }
        }
        private string _EcommerceItemNameBoxColor = "White";
        public string EcommerceItemNameError
        {
            get
            {
                return _EcommerceItemNameError;
            }
            set
            {
                _EcommerceItemNameError = value;
                if (value != "")
                {
                    EcommerceItemNameToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceItemNameToolTip");
                }
                else
                {
                    EcommerceItemNameToolTip = ReturnToolTip("EcommerceItemNameToolTip");
                }
                this.EcommerceItemNameBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceItemNameError");
            }
        }
        private string _EcommerceItemNameError = string.Empty;
        public string EcommerceItemNameToolTip
        {
            get
            {
                return _EcommerceItemNameToolTip;
            }
            set
            {
                this._EcommerceItemNameToolTip = value;
                OnPropertyChanged("EcommerceItemNameToolTip");
            }
        }
        private string _EcommerceItemNameToolTip = string.Empty;

        /// <summary>
        ///    EcommerceItemWeight
        /// </summary>
        public string EcommerceItemWeight
        {
            get
            {
                return this.ItemViewModelItem.EcommerceItemWeight;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceItemWeight != value)
                {
                    this.ItemViewModelItem.EcommerceItemWeight = value;
                    FlagError("EcommerceItemWeight");
                    OnPropertyChanged("EcommerceItemWeight");
                }
            }
        }
        public string EcommerceItemWeightBoxColor
        {
            get
            {
                return _EcommerceItemWeightBoxColor;
            }
            set
            {
                _EcommerceItemWeightBoxColor = value;
                OnPropertyChanged("EcommerceItemWeightBoxColor");
            }
        }
        private string _EcommerceItemWeightBoxColor = "White";
        public string EcommerceItemWeightError
        {
            get
            {
                return _EcommerceItemWeightError;
            }
            set
            {
                _EcommerceItemWeightError = value;
                if (value != "")
                {
                    EcommerceItemWeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceItemWeightToolTip");
                }
                else
                {
                    EcommerceItemWeightToolTip = ReturnToolTip("EcommerceItemWeightToolTip");
                }
                this.EcommerceItemWeightBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceItemWeightError");
            }
        }
        private string _EcommerceItemWeightError = string.Empty;
        public string EcommerceItemWeightToolTip
        {
            get
            {
                return _EcommerceItemWeightToolTip;
            }
            set
            {
                this._EcommerceItemWeightToolTip = value;
                OnPropertyChanged("EcommerceItemWeightToolTip");
            }
        }
        private string _EcommerceItemWeightToolTip = string.Empty;

        /// <summary>
        ///    EcommerceItemWidth
        /// </summary>
        public string EcommerceItemWidth
        {
            get
            {
                return this.ItemViewModelItem.EcommerceItemWidth;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceItemWidth != value)
                {
                    this.ItemViewModelItem.EcommerceItemWidth = value;
                    FlagError("EcommerceItemWidth");
                    OnPropertyChanged("EcommerceItemWidth");
                }
            }
        }
        public string EcommerceItemWidthBoxColor
        {
            get
            {
                return _EcommerceItemWidthBoxColor;
            }
            set
            {
                _EcommerceItemWidthBoxColor = value;
                OnPropertyChanged("EcommerceItemWidthBoxColor");
            }
        }
        private string _EcommerceItemWidthBoxColor = "White";
        public string EcommerceItemWidthError
        {
            get
            {
                return _EcommerceItemWidthError;
            }
            set
            {
                _EcommerceItemWidthError = value;
                if (value != "")
                {
                    EcommerceItemWidthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceItemWidthToolTip");
                }
                else
                {
                    EcommerceItemWidthToolTip = ReturnToolTip("EcommerceItemWidthToolTip");
                }
                this.EcommerceItemWidthBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceItemWidthError");
            }
        }
        private string _EcommerceItemWidthError = string.Empty;
        public string EcommerceItemWidthToolTip
        {
            get
            {
                return _EcommerceItemWidthToolTip;
            }
            set
            {
                this._EcommerceItemWidthToolTip = value;
                OnPropertyChanged("EcommerceItemWidthToolTip");
            }
        }
        private string _EcommerceItemWidthToolTip = string.Empty;

        /// <summary>
        ///    EcommerceModelName
        /// </summary>
        public string EcommerceModelName
        {
            get
            {
                return this.ItemViewModelItem.EcommerceModelName;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceModelName != value)
                {
                    this.ItemViewModelItem.EcommerceModelName = value;
                    FlagError("EcommerceModelName");
                    OnPropertyChanged("EcommerceModelName");
                }
            }
        }
        public string EcommerceModelNameBoxColor
        {
            get
            {
                return _EcommerceModelNameBoxColor;
            }
            set
            {
                _EcommerceModelNameBoxColor = value;
                OnPropertyChanged("EcommerceModelNameBoxColor");
            }
        }
        private string _EcommerceModelNameBoxColor = "White";
        public string EcommerceModelNameError
        {
            get
            {
                return _EcommerceModelNameError;
            }
            set
            {
                _EcommerceModelNameError = value;
                if (value != "")
                {
                    EcommerceModelNameToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceModelNameToolTip");
                }
                else
                {
                    EcommerceModelNameToolTip = ReturnToolTip("EcommerceModelNameToolTip");
                }
                this.EcommerceModelNameBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceModelNameError");
            }
        }
        private string _EcommerceModelNameError = string.Empty;
        public string EcommerceModelNameToolTip
        {
            get
            {
                return _EcommerceModelNameToolTip;
            }
            set
            {
                this._EcommerceModelNameToolTip = value;
                OnPropertyChanged("EcommerceModelNameToolTip");
            }
        }
        private string _EcommerceModelNameToolTip = string.Empty;

        /// <summary>
        ///    EcommercePackageHeight
        /// </summary>
        public string EcommercePackageHeight
        {
            get
            {
                return this.ItemViewModelItem.EcommercePackageHeight;
            }
            set
            {
                if (this.ItemViewModelItem.EcommercePackageHeight != value)
                {
                    this.ItemViewModelItem.EcommercePackageHeight = value;
                    FlagError("EcommercePackageHeight");
                    OnPropertyChanged("EcommercePackageHeight");
                }
            }
        }
        public string EcommercePackageHeightBoxColor
        {
            get
            {
                return _EcommercePackageHeightBoxColor;
            }
            set
            {
                _EcommercePackageHeightBoxColor = value;
                OnPropertyChanged("EcommercePackageHeightBoxColor");
            }
        }
        private string _EcommercePackageHeightBoxColor = "White";
        public string EcommercePackageHeightError
        {
            get
            {
                return _EcommercePackageHeightError;
            }
            set
            {
                _EcommercePackageHeightError = value;
                if (value != "")
                {
                    EcommercePackageHeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommercePackageHeightToolTip");
                }
                else
                {
                    EcommercePackageHeightToolTip = ReturnToolTip("EcommercePackageHeightToolTip");
                }
                this.EcommercePackageHeightBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommercePackageHeightError");
            }
        }
        private string _EcommercePackageHeightError = string.Empty;
        public string EcommercePackageHeightToolTip
        {
            get
            {
                return _EcommercePackageHeightToolTip;
            }
            set
            {
                this._EcommercePackageHeightToolTip = value;
                OnPropertyChanged("EcommercePackageHeightToolTip");
            }
        }
        private string _EcommercePackageHeightToolTip = string.Empty;

        /// <summary>
        ///    EcommercePackageLength
        /// </summary>
        public string EcommercePackageLength
        {
            get
            {
                return this.ItemViewModelItem.EcommercePackageLength;
            }
            set
            {
                if (this.ItemViewModelItem.EcommercePackageLength != value)
                {
                    this.ItemViewModelItem.EcommercePackageLength = value;
                    FlagError("EcommercePackageLength");
                    OnPropertyChanged("EcommercePackageLength");
                }
            }
        }
        public string EcommercePackageLengthBoxColor
        {
            get
            {
                return _EcommercePackageLengthBoxColor;
            }
            set
            {
                _EcommercePackageLengthBoxColor = value;
                OnPropertyChanged("EcommercePackageLengthBoxColor");
            }
        }
        private string _EcommercePackageLengthBoxColor = "White";
        public string EcommercePackageLengthError
        {
            get
            {
                return _EcommercePackageLengthError;
            }
            set
            {
                _EcommercePackageLengthError = value;
                if (value != "")
                {
                    EcommercePackageLengthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommercePackageLengthToolTip");
                }
                else
                {
                    EcommercePackageLengthToolTip = ReturnToolTip("EcommercePackageLengthToolTip");
                }
                this.EcommercePackageLengthBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommercePackageLengthError");
            }
        }
        private string _EcommercePackageLengthError = string.Empty;
        public string EcommercePackageLengthToolTip
        {
            get
            {
                return _EcommercePackageLengthToolTip;
            }
            set
            {
                this._EcommercePackageLengthToolTip = value;
                OnPropertyChanged("EcommercePackageLengthToolTip");
            }
        }
        private string _EcommercePackageLengthToolTip = string.Empty;

        /// <summary>
        ///    EcommercePackageWeight
        /// </summary>
        public string EcommercePackageWeight
        {
            get
            {
                return this.ItemViewModelItem.EcommercePackageWeight;
            }
            set
            {
                if (this.ItemViewModelItem.EcommercePackageWeight != value)
                {
                    this.ItemViewModelItem.EcommercePackageWeight = value;
                    FlagError("EcommercePackageWeight");
                    OnPropertyChanged("EcommercePackageWeight");
                }
            }
        }
        public string EcommercePackageWeightBoxColor
        {
            get
            {
                return _EcommercePackageWeightBoxColor;
            }
            set
            {
                _EcommercePackageWeightBoxColor = value;
                OnPropertyChanged("EcommercePackageWeightBoxColor");
            }
        }
        private string _EcommercePackageWeightBoxColor = "White";
        public string EcommercePackageWeightError
        {
            get
            {
                return _EcommercePackageWeightError;
            }
            set
            {
                _EcommercePackageWeightError = value;
                if (value != "")
                {
                    EcommercePackageWeightToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommercePackageWeightToolTip");
                }
                else
                {
                    EcommercePackageWeightToolTip = ReturnToolTip("EcommercePackageWeightToolTip");
                }
                this.EcommercePackageWeightBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommercePackageWeightError");
            }
        }
        private string _EcommercePackageWeightError = string.Empty;
        public string EcommercePackageWeightToolTip
        {
            get
            {
                return _EcommercePackageWeightToolTip;
            }
            set
            {
                this._EcommercePackageWeightToolTip = value;
                OnPropertyChanged("EcommercePackageWeightToolTip");
            }
        }
        private string _EcommercePackageWeightToolTip = string.Empty;

        /// <summary>
        ///    EcommercePackageWidth
        /// </summary>
        public string EcommercePackageWidth
        {
            get
            {
                return this.ItemViewModelItem.EcommercePackageWidth;
            }
            set
            {
                if (this.ItemViewModelItem.EcommercePackageWidth != value)
                {
                    this.ItemViewModelItem.EcommercePackageWidth = value;
                    FlagError("EcommercePackageWidth");
                    OnPropertyChanged("EcommercePackageWidth");
                }
            }
        }
        public string EcommercePackageWidthBoxColor
        {
            get
            {
                return _EcommercePackageWidthBoxColor;
            }
            set
            {
                _EcommercePackageWidthBoxColor = value;
                OnPropertyChanged("EcommercePackageWidthBoxColor");
            }
        }
        private string _EcommercePackageWidthBoxColor = "White";
        public string EcommercePackageWidthError
        {
            get
            {
                return _EcommercePackageWidthError;
            }
            set
            {
                _EcommercePackageWidthError = value;
                if (value != "")
                {
                    EcommercePackageWidthToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommercePackageWidthToolTip");
                }
                else
                {
                    EcommercePackageWidthToolTip = ReturnToolTip("EcommercePackageWidthToolTip");
                }
                this.EcommercePackageWidthBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommercePackageWidthError");
            }
        }
        private string _EcommercePackageWidthError = string.Empty;
        public string EcommercePackageWidthToolTip
        {
            get
            {
                return _EcommercePackageWidthToolTip;
            }
            set
            {
                this._EcommercePackageWidthToolTip = value;
                OnPropertyChanged("EcommercePackageWidthToolTip");
            }
        }
        private string _EcommercePackageWidthToolTip = string.Empty;

        /// <summary>
        ///    EcommercePageQty
        /// </summary>
        public string EcommercePageQty
        {
            get
            {
                return this.ItemViewModelItem.EcommercePageQty;
            }
            set
            {
                if (this.ItemViewModelItem.EcommercePageQty != value)
                {
                    this.ItemViewModelItem.EcommercePageQty = value;
                    FlagError("EcommercePageQty");
                    OnPropertyChanged("EcommercePageQty");
                }
            }
        }
        public string EcommercePageQtyBoxColor
        {
            get
            {
                return _EcommercePageQtyBoxColor;
            }
            set
            {
                _EcommercePageQtyBoxColor = value;
                OnPropertyChanged("EcommercePageQtyBoxColor");
            }
        }
        private string _EcommercePageQtyBoxColor = "White";
        public string EcommercePageQtyError
        {
            get
            {
                return _EcommercePageQtyError;
            }
            set
            {
                _EcommercePageQtyError = value;
                if (value != "")
                {
                    EcommercePageQtyToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommercePageQtyToolTip");
                }
                else
                {
                    EcommercePageQtyToolTip = ReturnToolTip("EcommercePageQtyToolTip");
                }
                this.EcommercePageQtyBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommercePageQtyError");
            }
        }
        private string _EcommercePageQtyError = string.Empty;
        public string EcommercePageQtyToolTip
        {
            get
            {
                return _EcommercePageQtyToolTip;
            }
            set
            {
                this._EcommercePageQtyToolTip = value;
                OnPropertyChanged("EcommercePageQtyToolTip");
            }
        }
        private string _EcommercePageQtyToolTip = string.Empty;

        /// <summary>
        ///    EcommerceParentAsin
        /// </summary>
        public string EcommerceParentAsin
        {
            get
            {
                return this.ItemViewModelItem.EcommerceParentAsin;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceParentAsin != value)
                {
                    this.ItemViewModelItem.EcommerceParentAsin = value;
                    FlagError("EcommerceParentAsin");
                    OnPropertyChanged("EcommerceParentAsin");
                }
            }
        }
        public string EcommerceParentAsinBoxColor
        {
            get
            {
                return _ecommerceParentAsinBoxColor;
            }
            set
            {
                _ecommerceParentAsinBoxColor = value;
                OnPropertyChanged("EcommerceParentAsinBoxColor");
            }
        }
        private string _ecommerceParentAsinBoxColor = "White";
        public string EcommerceParentAsinError
        {
            get
            {
                return _ecommerceParentAsinError;
            }
            set
            {
                _ecommerceParentAsinError = value;
                if (value != "")
                {
                    EcommerceParentAsinToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceParentAsinToolTip");
                }
                else
                {
                    EcommerceParentAsinToolTip = ReturnToolTip("EcommerceParentAsinToolTip");
                }
                this.EcommerceParentAsinBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceParentAsinError");
            }
        }
        private string _ecommerceParentAsinError = string.Empty;
        public string EcommerceParentAsinToolTip
        {
            get
            {
                return _ecommerceParentAsinToolTip;
            }
            set
            {
                this._ecommerceParentAsinToolTip = value;
                OnPropertyChanged("EcommerceParentAsinToolTip");
            }
        }
        private string _ecommerceParentAsinToolTip = string.Empty;

        /// <summary>
        ///    EcommerceProductCategory
        /// </summary>
        public string EcommerceProductCategory
        {
            get
            {
                return this.ItemViewModelItem.EcommerceProductCategory;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceProductCategory != value)
                {
                    this.ItemViewModelItem.EcommerceProductCategory = value;
                    FlagError("EcommerceProductCategory");
                    OnPropertyChanged("EcommerceProductCategory");
                }
            }
        }
        public string EcommerceProductCategoryBoxColor
        {
            get
            {
                return _EcommerceProductCategoryBoxColor;
            }
            set
            {
                _EcommerceProductCategoryBoxColor = value;
                OnPropertyChanged("EcommerceProductCategoryBoxColor");
            }
        }
        private string _EcommerceProductCategoryBoxColor = "White";
        public string EcommerceProductCategoryError
        {
            get
            {
                return _EcommerceProductCategoryError;
            }
            set
            {
                _EcommerceProductCategoryError = value;
                if (value != "")
                {
                    EcommerceProductCategoryToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceProductCategoryToolTip");
                }
                else
                {
                    EcommerceProductCategoryToolTip = ReturnToolTip("EcommerceProductCategoryToolTip");
                }
                this.EcommerceProductCategoryBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceProductCategoryError");
            }
        }
        private string _EcommerceProductCategoryError = string.Empty;
        public string EcommerceProductCategoryToolTip
        {
            get
            {
                return _EcommerceProductCategoryToolTip;
            }
            set
            {
                this._EcommerceProductCategoryToolTip = value;
                OnPropertyChanged("EcommerceProductCategoryToolTip");
            }
        }
        private string _EcommerceProductCategoryToolTip = string.Empty;

        /// <summary>
        ///    EcommerceProductDescription
        /// </summary>
        public string EcommerceProductDescription
        {
            get
            {
                return this.ItemViewModelItem.EcommerceProductDescription;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceProductDescription != value)
                {
                    this.ItemViewModelItem.EcommerceProductDescription = value;
                    FlagError("EcommerceProductDescription");
                    OnPropertyChanged("EcommerceProductDescription");
                }
            }
        }
        public string EcommerceProductDescriptionBoxColor
        {
            get
            {
                return _EcommerceProductDescriptionBoxColor;
            }
            set
            {
                _EcommerceProductDescriptionBoxColor = value;
                OnPropertyChanged("EcommerceProductDescriptionBoxColor");
            }
        }
        private string _EcommerceProductDescriptionBoxColor = "White";
        public string EcommerceProductDescriptionError
        {
            get
            {
                return _EcommerceProductDescriptionError;
            }
            set
            {
                _EcommerceProductDescriptionError = value;
                if (value != "")
                {
                    EcommerceProductDescriptionToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceProductDescriptionToolTip");
                }
                else
                {
                    EcommerceProductDescriptionToolTip = ReturnToolTip("EcommerceProductDescriptionToolTip");
                }
                this.EcommerceProductDescriptionBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceProductDescriptionError");
            }
        }
        private string _EcommerceProductDescriptionError = string.Empty;
        public string EcommerceProductDescriptionToolTip
        {
            get
            {
                return _EcommerceProductDescriptionToolTip;
            }
            set
            {
                this._EcommerceProductDescriptionToolTip = value;
                OnPropertyChanged("EcommerceProductDescriptionToolTip");
            }
        }
        private string _EcommerceProductDescriptionToolTip = string.Empty;

        /// <summary>
        ///    EcommerceProductSubcategory
        /// </summary>
        public string EcommerceProductSubcategory
        {
            get
            {
                return this.ItemViewModelItem.EcommerceProductSubcategory;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceProductSubcategory != value)
                {
                    this.ItemViewModelItem.EcommerceProductSubcategory = value;
                    FlagError("EcommerceProductSubcategory");
                    OnPropertyChanged("EcommerceProductSubcategory");
                }
            }
        }
        public string EcommerceProductSubcategoryBoxColor
        {
            get
            {
                return _EcommerceProductSubcategoryBoxColor;
            }
            set
            {
                _EcommerceProductSubcategoryBoxColor = value;
                OnPropertyChanged("EcommerceProductSubcategoryBoxColor");
            }
        }
        private string _EcommerceProductSubcategoryBoxColor = "White";
        public string EcommerceProductSubcategoryError
        {
            get
            {
                return _EcommerceProductSubcategoryError;
            }
            set
            {
                _EcommerceProductSubcategoryError = value;
                if (value != "")
                {
                    EcommerceProductSubcategoryToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceProductSubcategoryToolTip");
                }
                else
                {
                    EcommerceProductSubcategoryToolTip = ReturnToolTip("EcommerceProductSubcategoryToolTip");
                }
                this.EcommerceProductSubcategoryBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceProductSubcategoryError");
            }
        }
        private string _EcommerceProductSubcategoryError = string.Empty;
        public string EcommerceProductSubcategoryToolTip
        {
            get
            {
                return _EcommerceProductSubcategoryToolTip;
            }
            set
            {
                this._EcommerceProductSubcategoryToolTip = value;
                OnPropertyChanged("EcommerceProductSubcategoryToolTip");
            }
        }
        private string _EcommerceProductSubcategoryToolTip = string.Empty;

        /// <summary>
        ///    EcommerceManufacturerName
        /// </summary>
        public string EcommerceManufacturerName
        {
            get
            {
                return this.ItemViewModelItem.EcommerceManufacturerName;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceManufacturerName != value)
                {
                    this.ItemViewModelItem.EcommerceManufacturerName = value;
                    FlagError("EcommerceManufacturerName");
                    OnPropertyChanged("EcommerceManufacturerName");
                }
            }
        }
        public string EcommerceManufacturerNameBoxColor
        {
            get
            {
                return _EcommerceManufacturerNameBoxColor;
            }
            set
            {
                _EcommerceManufacturerNameBoxColor = value;
                OnPropertyChanged("EcommerceManufacturerNameBoxColor");
            }
        }
        private string _EcommerceManufacturerNameBoxColor = "White";
        public string EcommerceManufacturerNameError
        {
            get
            {
                return _EcommerceManufacturerNameError;
            }
            set
            {
                _EcommerceManufacturerNameError = value;
                if (value != "")
                {
                    EcommerceManufacturerNameToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceManufacturerNameToolTip");
                }
                else
                {
                    EcommerceManufacturerNameToolTip = ReturnToolTip("EcommerceManufacturerNameToolTip");
                }
                this.EcommerceManufacturerNameBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceManufacturerNameError");
            }
        }
        private string _EcommerceManufacturerNameError = string.Empty;
        public string EcommerceManufacturerNameToolTip
        {
            get
            {
                return _EcommerceManufacturerNameToolTip;
            }
            set
            {
                this._EcommerceManufacturerNameToolTip = value;
                OnPropertyChanged("EcommerceManufacturerNameToolTip");
            }
        }
        private string _EcommerceManufacturerNameToolTip = string.Empty;

        /// <summary>
        ///    EcommerceMsrp
        /// </summary>
        public string EcommerceMsrp
        {
            get
            {
                return this.ItemViewModelItem.EcommerceMsrp;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceMsrp != value)
                {
                    this.ItemViewModelItem.EcommerceMsrp = value;
                    FlagError("EcommerceMsrp");
                    OnPropertyChanged("EcommerceMsrp");
                }
            }
        }
        public string EcommerceMsrpBoxColor
        {
            get
            {
                return _EcommerceMsrpBoxColor;
            }
            set
            {
                _EcommerceMsrpBoxColor = value;
                OnPropertyChanged("EcommerceMsrpBoxColor");
            }
        }
        private string _EcommerceMsrpBoxColor = "White";
        public string EcommerceMsrpError
        {
            get
            {
                return _EcommerceMsrpError;
            }
            set
            {
                _EcommerceMsrpError = value;
                if (value != "")
                {
                    EcommerceMsrpToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceMsrpToolTip");
                }
                else
                {
                    EcommerceMsrpToolTip = ReturnToolTip("EcommerceMsrpToolTip");
                }
                this.EcommerceMsrpBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceMsrpError");
            }
        }
        private string _EcommerceMsrpError = string.Empty;
        public string EcommerceMsrpToolTip
        {
            get
            {
                return _EcommerceMsrpToolTip;
            }
            set
            {
                this._EcommerceMsrpToolTip = value;
                OnPropertyChanged("EcommerceMsrpToolTip");
            }
        }
        private string _EcommerceMsrpToolTip = string.Empty;

        /// <summary>
        ///    EcommerceGenericKeywords
        /// </summary>
        public string EcommerceGenericKeywords
        {
            get
            {
                return this.ItemViewModelItem.EcommerceGenericKeywords;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceGenericKeywords != value)
                {
                    this.ItemViewModelItem.EcommerceGenericKeywords = value;
                    FlagError("EcommerceGenericKeywords");
                    OnPropertyChanged("EcommerceGenericKeywords");
                }
            }
        }
        public string EcommerceGenericKeywordsBoxColor
        {
            get
            {
                return _EcommerceGenericKeywordsBoxColor;
            }
            set
            {
                _EcommerceGenericKeywordsBoxColor = value;
                OnPropertyChanged("EcommerceGenericKeywordsBoxColor");
            }
        }
        private string _EcommerceGenericKeywordsBoxColor = "White";
        public string EcommerceGenericKeywordsError
        {
            get
            {
                return _EcommerceGenericKeywordsError;
            }
            set
            {
                _EcommerceGenericKeywordsError = value;
                if (value != "")
                {
                    EcommerceGenericKeywordsToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceGenericKeywordsToolTip");
                }
                else
                {
                    EcommerceGenericKeywordsToolTip = ReturnToolTip("EcommerceGenericKeywordsToolTip");
                }
                this.EcommerceGenericKeywordsBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceGenericKeywordsError");
            }
        }
        private string _EcommerceGenericKeywordsError = string.Empty;
        public string EcommerceGenericKeywordsToolTip
        {
            get
            {
                return _EcommerceGenericKeywordsToolTip;
            }
            set
            {
                this._EcommerceGenericKeywordsToolTip = value;
                OnPropertyChanged("EcommerceGenericKeywordsToolTip");
            }
        }
        private string _EcommerceGenericKeywordsToolTip = string.Empty;

        /// <summary>
        ///    EcommerceSize
        /// </summary>
        public string EcommerceSize
        {
            get
            {
                return this.ItemViewModelItem.EcommerceSize;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceSize != value)
                {
                    this.ItemViewModelItem.EcommerceSize = value;
                    FlagError("EcommerceSize");
                    OnPropertyChanged("EcommerceSize");
                }
            }
        }
        public string EcommerceSizeBoxColor
        {
            get
            {
                return _EcommercesizeBoxColor;
            }
            set
            {
                _EcommercesizeBoxColor = value;
                OnPropertyChanged("EcommerceSizeBoxColor");
            }
        }
        private string _EcommercesizeBoxColor = "White";
        public string EcommerceSizeError
        {
            get
            {
                return _EcommercesizeError;
            }
            set
            {
                _EcommercesizeError = value;
                if (value != "")
                {
                    EcommerceSizeToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceSizeToolTip");
                }
                else
                {
                    EcommerceSizeToolTip = ReturnToolTip("EcommerceSizeToolTip");
                }
                this.EcommerceSizeBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceSizeError");
            }
        }
        private string _EcommercesizeError = string.Empty;
        public string EcommerceSizeToolTip
        {
            get
            {
                return _EcommercesizeToolTip;
            }
            set
            {
                this._EcommercesizeToolTip = value;
                OnPropertyChanged("EcommerceSizeToolTip");
            }
        }
        private string _EcommercesizeToolTip = string.Empty;
        
        /// <summary>
        ///    EcommerceSubjectKeywords
        /// </summary>
        public string EcommerceSubjectKeywords
        {
            get
            {
                return this.ItemViewModelItem.EcommerceSubjectKeywords;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceSubjectKeywords != value)
                {
                    this.ItemViewModelItem.EcommerceSubjectKeywords = value;
                    FlagError("EcommerceSubjectKeywords");
                    OnPropertyChanged("EcommerceSubjectKeywords");
                }
            }
        }
        public string EcommerceSubjectKeywordsBoxColor
        {
            get
            {
                return _EcommerceSubjectKeywordsBoxColor;
            }
            set
            {
                _EcommerceSubjectKeywordsBoxColor = value;
                OnPropertyChanged("EcommerceSubjectKeywordsBoxColor");
            }
        }
        private string _EcommerceSubjectKeywordsBoxColor = "White";
        public string EcommerceSubjectKeywordsError
        {
            get
            {
                return _EcommerceSubjectKeywordsError;
            }
            set
            {
                _EcommerceSubjectKeywordsError = value;
                if (value != "")
                {
                    EcommerceSubjectKeywordsToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceSubjectKeywordsToolTip");
                }
                else
                {
                    EcommerceSubjectKeywordsToolTip = ReturnToolTip("EcommerceSubjectKeywordsToolTip");
                }
                this.EcommerceSubjectKeywordsBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceSubjectKeywordsError");
            }
        }
        private string _EcommerceSubjectKeywordsError = string.Empty;
        public string EcommerceSubjectKeywordsToolTip
        {
            get
            {
                return _EcommerceSubjectKeywordsToolTip;
            }
            set
            {
                this._EcommerceSubjectKeywordsToolTip = value;
                OnPropertyChanged("EcommerceSubjectKeywordsToolTip");
            }
        }
        private string _EcommerceSubjectKeywordsToolTip = string.Empty;
        
        /// <summary>
        ///    EcommerceUpc
        /// </summary>
        public string EcommerceUpc
        {
            get
            {
                return this.ItemViewModelItem.EcommerceUpc;
            }
            set
            {
                if (this.ItemViewModelItem.EcommerceUpc != value)
                {
                    this.ItemViewModelItem.EcommerceUpc = value;
                    FlagError("EcommerceUpc");
                    OnPropertyChanged("EcommerceUpc");
                }
            }
        }
        public string EcommerceUpcBoxColor
        {
            get
            {
                return _EcommerceUpcBoxColor;
            }
            set
            {
                _EcommerceUpcBoxColor = value;
                OnPropertyChanged("EcommerceUpcBoxColor");
            }
        }
        private string _EcommerceUpcBoxColor = "White";
        public string EcommerceUpcError
        {
            get
            {
                return _EcommerceUpcError;
            }
            set
            {
                _EcommerceUpcError = value;
                if (value != "")
                {
                    EcommerceUpcToolTip = "Error: " + value + "\n\n" + ReturnToolTip("EcommerceUpcToolTip");
                }
                else
                {
                    EcommerceUpcToolTip = ReturnToolTip("EcommerceUpcToolTip");
                }
                this.EcommerceUpcBoxColor = (value == "") ? "White" : "Tomato";
                this.TabColorEcommerce = CheckEcommerceTabColor();
                OnPropertyChanged("EcommerceUpcError");
            }
        }
        private string _EcommerceUpcError = string.Empty;
        public string EcommerceUpcToolTip
        {
            get
            {
                return _EcommerceUpcToolTip;
            }
            set
            {
                _EcommerceUpcToolTip = value;
                OnPropertyChanged("EcommerceUpcToolTip");
            }
        }
        private string _EcommerceUpcToolTip = string.Empty;

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

        public List<string> EcommerceExternalIdTypeGroups
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

        /// <summary>
        ///     Gets or sets a list of Stats codes for the Stats Code dropdown
        /// </summary>
        public List<string> StatsCodes
        {
            get
            {
                return _statsCodes;
            }
            set
            {
                _statsCodes = value;
                OnPropertyChanged("StatsCodes");
            }
        }
        private List<string> _statsCodes = new List<string>();

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

        private void AssignError(ItemError error)
        {
            switch (error.VarName.Trim())
                {
                    case "Accounting Group":
                        this.AccountingGroupError = error.ReturnErrorMessage();
                        break;

                    case "Image Path 2":
                        this.AltImageFile1Error = error.ReturnErrorMessage();
                        SetImages();
                        break;

                    case "Image Path 3":
                        this.AltImageFile2Error = error.ReturnErrorMessage();
                        SetImages();
                        break;

                    case "Image Path 4":
                        this.AltImageFile3Error = error.ReturnErrorMessage();
                        SetImages();
                        break;

                    case "Image Path 5":
                        this.AltImageFile4Error = error.ReturnErrorMessage();
                        SetImages();
                        break;

                    case "Bill of Materials":
                        this.BillOfMaterialsError = error.ReturnErrorMessage();
                        break;

                    case "Casepack Height":
                        this.CasepackHeightError = error.ReturnErrorMessage();
                        break;

                    case "Casepack Length":
                        this.CasepackHeightError = error.ReturnErrorMessage();
                        break;

                    case "Casepack Weight":
                        this.CasepackHeightError = error.ReturnErrorMessage();
                        break;

                    case "Casepack Width":
                        this.CasepackHeightError = error.ReturnErrorMessage();
                        break;

                    case "Casepack Qty":
                        this.CasepackQtyError = error.ReturnErrorMessage();
                        break;

                    case "Casepack Upc":
                        this.CasepackUpcError = error.ReturnErrorMessage();
                        break;

                    case "Category":
                        this.CategoryError = error.ReturnErrorMessage();
                        break;

                    case "Category 2":
                        this.Category2Error = error.ReturnErrorMessage();
                        break;

                    case "Category 3":
                        this.Category3Error = error.ReturnErrorMessage();
                        break;

                    case "Color":
                        this.ColorError = error.ReturnErrorMessage();
                        break;

                    case "Copyright":
                        this.CopyrightError = error.ReturnErrorMessage();
                        break;

                    case "Country Of Origin":
                        this.CountryOfOriginError = error.ReturnErrorMessage();
                        break;

                    case "Cost Profile Group":
                        this.CostProfileGroupError = error.ReturnErrorMessage();
                        break;

                    case "Default Actual Cost CAD":
                        this.DefaultActualCostCadError = error.ReturnErrorMessage();
                        break;

                    case "Default Actual Cost USD":
                        this.DefaultActualCostUsdError = error.ReturnErrorMessage();
                        break;

                    case "Description":
                        this.DescriptionError = error.ReturnErrorMessage();
                        break;

                    case "Direct Import":
                        this.DirectImportError = error.ReturnErrorMessage();
                        break;

                    case "Duty":
                        this.DutyError = error.ReturnErrorMessage();
                        break;

                    case "Ean":
                        this.EanError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Asin":
                        this.EcommerceAsinError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Bullet 1":
                        this.EcommerceBullet1Error = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Bullet 2":
                        this.EcommerceBullet2Error = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Bullet 3":
                        this.EcommerceBullet3Error = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Bullet 4":
                        this.EcommerceBullet4Error = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Bullet 5":
                        this.EcommerceBullet5Error = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Components":
                        this.EcommerceComponentsError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Cost":
                        this.EcommerceCostError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce External Id":
                        this.EcommerceExternalIdError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce External Id Type":
                        this.EcommerceExternalIdTypeError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Generic Keywords":
                        this.EcommerceGenericKeywordsError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Height":
                        this.EcommerceItemWeightError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Length":
                        this.EcommerceItemWeightError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Item Name":
                        this.EcommerceItemNameError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Weight":
                        this.EcommerceItemWeightError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Width":
                        this.EcommerceItemWeightError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Model Name":
                        this.EcommerceModelNameError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Package Height":
                        this.EcommercePackageHeightError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Package Length":
                        this.EcommercePackageLengthError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Package Weight":
                        this.EcommercePackageWeightError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Package Width":
                        this.EcommercePackageWidthError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Page Qty":
                        this.EcommercePageQtyError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Parent Asin":
                        this.EcommerceParentAsinError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Product Category":
                            this.EcommerceProductCategoryError = error.ReturnErrorMessage();
                            break;

                    case "Ecommerce Product Description":
                        this.EcommerceProductDescriptionError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Product Subcategory":
                        this.EcommerceProductSubcategoryError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Manufacturer Name":
                        this.EcommerceManufacturerNameError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Msrp":
                        this.EcommerceMsrpError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Size":
                        this.EcommerceSizeError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Subject Keywords":
                        this.EcommerceSubjectKeywordsError = error.ReturnErrorMessage();
                        break;

                    case "Ecommerce Upc":
                        this.EcommerceUpcError = error.ReturnErrorMessage();
                        break;

                    case "Gpc":
                        this.GpcError = error.ReturnErrorMessage();
                        break;

                    case "Height":
                        this.HeightError = error.ReturnErrorMessage();
                        break;

                    case "Image Path 1":
                        this.ImagePathError = error.ReturnErrorMessage();
                        SetImages();
                        break;

                    case "Innerpack Height":
                        this.InnerpackWidthError = error.ReturnErrorMessage();
                        break;

                    case "Innerpack Length":
                        this.InnerpackWidthError = error.ReturnErrorMessage();
                        break;

                    case "Innerpack Weight":
                        this.InnerpackWidthError = error.ReturnErrorMessage();
                        break;

                    case "Innerpack Width":
                        this.InnerpackWidthError = error.ReturnErrorMessage();
                        break;

                    case "Innerpack Quantity":
                        this.InnerpackQuantityError = error.ReturnErrorMessage();
                        break;

                    case "Innerpack Upc":
                        this.InnerpackUpcError = error.ReturnErrorMessage();
                        break;

                    case "In Stock Date":
                        this.InStockDateError = error.ReturnErrorMessage();
                        break;

                    case "Isbn":
                        this.IsbnError = error.ReturnErrorMessage();
                        break;

                    case "Item Category":
                        this.ItemCategoryError = error.ReturnErrorMessage();
                        break;

                    case "Item Family":
                        this.ItemFamilyError = error.ReturnErrorMessage();
                        break;

                    case "Item Group":
                        this.ItemGroupError = error.ReturnErrorMessage();
                        break;

                    case "Item Id":
                        this.ItemIdError = error.ReturnErrorMessage();
                        break;

                    case "Item Keywords":
                        this.ItemKeywordsError = error.ReturnErrorMessage();
                        break;

                    case "Language":
                        this.LanguageError = error.ReturnErrorMessage();
                        break;

                    case "Length":
                        this.LengthError = error.ReturnErrorMessage();
                        break;

                    case "License Begin Date":
                        this.LicenseBeginDateError = error.ReturnErrorMessage();
                        break;

                    case "License":
                        this.LicenseError = error.ReturnErrorMessage();
                        break;

                    case "List Price CAD":
                        this.ListPriceCadError = error.ReturnErrorMessage();
                        break;

                    case "List Price MXN":
                        this.MsrpMxnError = error.ReturnErrorMessage();
                        break;

                    case "List Price USD":
                        this.ListPriceUsdError = error.ReturnErrorMessage();
                        break;

                    case "Meta Description":
                        this.MetaDescriptionError = error.ReturnErrorMessage();
                        break;

                    case "MFG Source":
                        this.MfgSourceError = error.ReturnErrorMessage();
                        break;

                    case "MSRP":
                        this.MsrpError = error.ReturnErrorMessage();
                        break;

                    case "MSRP CAD":
                        this.MsrpCadError = error.ReturnErrorMessage();
                        break;

                    case "MSRP MXN":
                        this.MsrpMxnError = error.ReturnErrorMessage();
                        break;

                    case "Pricing Group":
                        this.PricingGroupError = error.ReturnErrorMessage();
                        break;

                    case "Print On Demand":
                        this.PrintOnDemandError = error.ReturnErrorMessage();
                        break;

                    case "Product Format":
                        this.ProductFormatError = error.ReturnErrorMessage();
                        break;

                    case "Product Group":
                        this.ProductGroupError = error.ReturnErrorMessage();
                        break;

                    case "Product Id Translations":
                        this.ProductIdTranslationError = error.ReturnErrorMessage();
                        break;

                    case "Product Line":
                        this.ProductLineError = error.ReturnErrorMessage();
                        break;

                    case "Product Qty":
                        this.ProductQtyError = error.ReturnErrorMessage();
                        break;

                    case "Property":
                        this.PropertyError = error.ReturnErrorMessage();
                        break;

                    case "PS Status":
                        this.PsStatusError = error.ReturnErrorMessage();
                        break;

                    case "SatCode":
                        this.SatCodeError = error.ReturnErrorMessage();
                        break;

                    case "Sell On All Posters":
                        this.SellOnAllPostersError = error.ReturnErrorMessage();
                        break;

                    case "Sell On Amazon":
                        this.SellOnAmazonError = error.ReturnErrorMessage();
                        break;

                    case "Sell On Amazon Seller Central":
                        this.SellOnAmazonSellerCentralError = error.ReturnErrorMessage();
                        break;

                    case "Sell On Ecommerce":
                        this.SellOnEcommerceError = error.ReturnErrorMessage();
                        break;

                    case "Sell On Fanatics":
                        this.SellOnFanaticsError = error.ReturnErrorMessage();
                        break;

                    case "Sell On Guitar Center":
                        this.SellOnGuitarCenterError = error.ReturnErrorMessage();
                        break;

                    case "Sell On Hayneedle":
                        this.SellOnHayneedleError = error.ReturnErrorMessage();
                        break;

                    case "Sell On Target":
                        this.SellOnTargetError = error.ReturnErrorMessage();
                        break;

                    case "Sell On Trends":
                        this.SellOnTrendsError = error.ReturnErrorMessage();
                        break;

                    case "Sell On Walmart":
                        this.SellOnWalmartError = error.ReturnErrorMessage();
                        break;

                    case "Sell On Wayfair":
                        this.SellOnWayfairError = error.ReturnErrorMessage();
                        break;

                    case "Short Description":
                        this.ShortDescriptionError = error.ReturnErrorMessage();
                        break;

                    case "Size":
                        this.SizeError = error.ReturnErrorMessage();
                        break;

                    case "Standard Cost":
                        this.StandardCostError = error.ReturnErrorMessage();
                        break;

                    case "Stats Code":
                        this.StatsCodeError = error.ReturnErrorMessage();
                        break;

                    case "Tariff Code":
                        this.TariffCodeError = error.ReturnErrorMessage();
                        break;

                    case "Territory":
                        this.TerritoryError = error.ReturnErrorMessage();
                        break;

                    case "Title":
                        this.TitleError = error.ReturnErrorMessage();
                        break;

                    case "Udex":
                        this.UdexError = error.ReturnErrorMessage();
                        break;

                    case "UPC":
                        this.UpcError = error.ReturnErrorMessage();
                        break;

                    case "Website Price":
                        this.WebsitePriceError = error.ReturnErrorMessage();
                        break;

                    case "Warranty":
                        this.WarrantyError = error.ReturnErrorMessage();
                        break;

                    case "Warranty Check":
                        this.WarrantyCheckError = error.ReturnErrorMessage();
                        break;

                    case "Weight":
                        this.WeightError = error.ReturnErrorMessage();
                        break;

                    case "Width":
                        this.WidthError = error.ReturnErrorMessage();
                        break;

                    default:
                        throw new ArgumentNullException("ItemViewModel Assign error unknown type " + error.VarName);
                }            
        }

        /// <summary>
        ///     Check ecommerce fields for errored items. 
        /// </summary>
        /// <returns></returns>
        private string CheckEcommerceTabColor()
        {
            if (EcommerceAsinBoxColor != "White") { return "Tomato"; }
            if (EcommerceBullet1BoxColor != "White") { return "Tomato"; }
            if (EcommerceBullet2BoxColor != "White") { return "Tomato"; }
            if (EcommerceBullet3BoxColor != "White") { return "Tomato"; }
            if (EcommerceBullet4BoxColor != "White") { return "Tomato"; }
            if (EcommerceBullet5BoxColor != "White") { return "Tomato"; }
            if (EcommerceComponentsBoxColor != "White") { return "Tomato"; }
            if (EcommerceCostBoxColor != "White") { return "Tomato"; }
            if (EcommerceExternalIdBoxColor != "White") { return "Tomato"; }
            if (EcommerceExternalIdTypeBoxColor != "White") { return "Tomato"; }
            if (EcommerceGenericKeywordsBoxColor != "White") { return "Tomato"; }
            if (EcommerceItemHeightBoxColor != "White") { return "Tomato"; }
            if (EcommerceItemLengthBoxColor != "White") { return "Tomato"; }
            if (EcommerceItemNameBoxColor != "White") { return "Tomato"; }
            if (EcommerceItemWeightBoxColor != "White") { return "Tomato"; }
            if (EcommerceItemWidthBoxColor != "White") { return "Tomato"; }
            if (EcommerceModelNameBoxColor != "White") { return "Tomato"; }
            if (EcommercePackageHeightBoxColor != "White") { return "Tomato"; }
            if (EcommercePackageLengthBoxColor != "White") { return "Tomato"; }
            if (EcommercePackageWeightBoxColor != "White") { return "Tomato"; }
            if (EcommercePackageWidthBoxColor != "White") { return "Tomato"; }
            if (EcommercePageQtyBoxColor != "White") { return "Tomato"; }
            if (EcommerceParentAsinBoxColor != "White") { return "Tomato"; }
            if (EcommerceProductCategoryBoxColor != "White") { return "Tomato"; }
            if (EcommerceProductDescriptionBoxColor != "White") { return "Tomato"; }
            if (EcommerceProductSubcategoryBoxColor != "White") { return "Tomato"; }
            if (EcommerceManufacturerNameBoxColor != "White") { return "Tomato"; }
            if (EcommerceMsrpBoxColor != "White") { return "Tomato"; }
            if (EcommerceSizeBoxColor != "White") { return "Tomato"; }
            if (EcommerceSubjectKeywordsBoxColor != "White") { return "Tomato"; }
            if (EcommerceUpcBoxColor != "White") { return "Tomato"; }
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
            if (WarrantyBoxColor != "White") { return "Tomato"; }
            if (WarrantyCheckBoxColor != "White") { return "Tomato"; }
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
            if (SellOnAmazonBoxColor != "White") { return "Tomato"; }
            if (SellOnAmazonSellerCentralBoxColor != "White") { return "Tomato"; }
            if (SellOnEcommerceBoxColor != "White") { return "Tomato"; }
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
        ///     Runs validation for given field and assigns error message to error fields
        /// </summary>
        /// <param name="field"></param>
        private void FlagError(string field)
        {
            switch(field)
            {
                case "AccountingGroup":
                    this.AccountingGroupError = ItemService.ValidateAccountingGroup(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "AltImageFile1":
                    this.AltImageFile1Error = ItemService.ValidateImagePath(ItemViewModelItem, "2")?.ReturnErrorMessage() ?? "";
                    SetImages();
                    break;

                case "AltImageFile2":
                    this.AltImageFile2Error = ItemService.ValidateImagePath(ItemViewModelItem, "3")?.ReturnErrorMessage() ?? "";
                    SetImages();
                    break;

                case "AltImageFile3":
                    this.AltImageFile3Error = ItemService.ValidateImagePath(ItemViewModelItem, "4")?.ReturnErrorMessage() ?? "";
                    SetImages();
                    break;

                case "AltImageFile4":
                    this.AltImageFile4Error = ItemService.ValidateImagePath(ItemViewModelItem, "5")?.ReturnErrorMessage() ?? "";
                    SetImages();
                    break;

                case "BillOfMaterials":
                    this.BillOfMaterialsError = ItemService.ValidateBillOfMaterials(ItemViewModelItem, this.ItemIds)?.ReturnErrorMessage() ?? "";
                    break;

                case "CasepackHeight":
                    this.CasepackHeightError = ItemService.ValidateCasepack(ItemViewModelItem, "Height")?.ReturnErrorMessage() ?? "";
                    this.CasepackLengthError = ItemService.ValidateCasepack(ItemViewModelItem, "Length")?.ReturnErrorMessage() ?? "";
                    this.CasepackWidthError = ItemService.ValidateCasepack(ItemViewModelItem, "Width")?.ReturnErrorMessage() ?? "";
                    this.CasepackWeightError = ItemService.ValidateCasepack(ItemViewModelItem, "Weight")?.ReturnErrorMessage() ?? "";
                    break;

                case "CasepackLength":
                    this.CasepackHeightError = ItemService.ValidateCasepack(ItemViewModelItem, "Height")?.ReturnErrorMessage() ?? "";
                    this.CasepackLengthError = ItemService.ValidateCasepack(ItemViewModelItem, "Length")?.ReturnErrorMessage() ?? "";
                    this.CasepackWidthError = ItemService.ValidateCasepack(ItemViewModelItem, "Width")?.ReturnErrorMessage() ?? "";
                    this.CasepackWeightError = ItemService.ValidateCasepack(ItemViewModelItem, "Weight")?.ReturnErrorMessage() ?? "";
                    break;

                case "CasepackWeight":
                    this.CasepackHeightError = ItemService.ValidateCasepack(ItemViewModelItem, "Height")?.ReturnErrorMessage() ?? "";
                    this.CasepackLengthError = ItemService.ValidateCasepack(ItemViewModelItem, "Length")?.ReturnErrorMessage() ?? "";
                    this.CasepackWidthError = ItemService.ValidateCasepack(ItemViewModelItem, "Width")?.ReturnErrorMessage() ?? "";
                    this.CasepackWeightError = ItemService.ValidateCasepack(ItemViewModelItem, "Weight")?.ReturnErrorMessage() ?? "";
                    break;

                case "CasepackWidth":
                    this.CasepackHeightError = ItemService.ValidateCasepack(ItemViewModelItem, "Height")?.ReturnErrorMessage()??"";
                    this.CasepackLengthError = ItemService.ValidateCasepack(ItemViewModelItem, "Length")?.ReturnErrorMessage()??"";
                    this.CasepackWidthError = ItemService.ValidateCasepack(ItemViewModelItem, "Width")?.ReturnErrorMessage()??"";
                    this.CasepackWeightError = ItemService.ValidateCasepack(ItemViewModelItem, "Weight")?.ReturnErrorMessage()??"";
                    break;

                case "CasepackQty":
                    this.CasepackQtyError = ItemService.ValidateCasepackQty(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "CasepackUpc":
                    this.CasepackUpcError = ItemService.ValidatePackUpc(ItemViewModelItem, "Casepack")?.ReturnErrorMessage() ?? "";
                    break;

                case "Category":
                    this.CategoryError = ItemService.ValidateCategory(ItemViewModelItem, "1")?.ReturnErrorMessage() ?? "";
                    break;

                case "Category2":
                    this.Category2Error = ItemService.ValidateCategory(ItemViewModelItem, "2")?.ReturnErrorMessage() ?? "";
                    break;

                case "Category3":
                    this.Category3Error = ItemService.ValidateCategory(ItemViewModelItem, "3")?.ReturnErrorMessage() ?? "";
                    break;

                case "Color":
                    this.ColorError = ItemService.ValidateColor(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "Copyright":
                    this.CopyrightError = ItemService.ValidateCopyright(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "CountryOfOrigin":
                    this.ItemViewModelItem.EcommerceCountryofOrigin = ItemService.RetrieveFullCountryOfOrigin(ItemViewModelItem.CountryOfOrigin);
                    this.CountryOfOriginError = ItemService.ValidateCountryOfOrigin(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "CostProfileGroup":
                    this.CostProfileGroupError = ItemService.ValidateCostProfileGroup(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.MfgSourceError = ItemService.ValidateMfgSource(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "DefaultActualCostCad":
                    this.DefaultActualCostCadError = ItemService.ValidateDefaultActualCost(ItemViewModelItem, "CAD")?.ReturnErrorMessage() ?? "";
                    break;

                case "DefaultActualCostUsd":
                    this.DefaultActualCostUsdError = ItemService.ValidateDefaultActualCost(ItemViewModelItem, "USD")?.ReturnErrorMessage() ?? "";
                    break;

                case "Description":
                    this.DescriptionError = ItemService.ValidateDescription(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "DirectImport":
                    this.DirectImportError = ItemService.ValidateDirectImport(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "Duty":
                    this.DutyError = ItemService.ValidateDuty(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "Ean":
                    this.EanError = ItemService.ValidateEan(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceAsin":
                    this.EcommerceAsinError = ItemService.ValidateEcommerceAsin(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceBullet1":
                    this.EcommerceBullet1Error = ItemService.ValidateEcommerceBullet(ItemViewModelItem, "1")?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceBullet2":
                    this.EcommerceBullet2Error = ItemService.ValidateEcommerceBullet(ItemViewModelItem, "2")?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceBullet3":
                    this.EcommerceBullet3Error = ItemService.ValidateEcommerceBullet(ItemViewModelItem, "3")?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceBullet4":
                    this.EcommerceBullet4Error = ItemService.ValidateEcommerceBullet(ItemViewModelItem, "4")?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceBullet5":
                    this.EcommerceBullet5Error = ItemService.ValidateEcommerceBullet(ItemViewModelItem, "5")?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceComponents":
                    this.EcommerceComponentsError = ItemService.ValidateEcommerceComponents(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceCost":
                    this.EcommerceCostError = ItemService.ValidateEcommerceCost(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceExternalId":
                    this.EcommerceExternalIdError = ItemService.ValidateEcommerceExternalId(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceExternalIdType":
                    this.EcommerceExternalIdTypeError = ItemService.ValidateEcommerceExternalIdType(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceGenericKeywords":
                    this.EcommerceGenericKeywordsError = ItemService.ValidateEcommerceKeywords(ItemViewModelItem, "Generic")?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceItemHeight":
                    this.EcommerceItemWeightError = ItemService.ValidateEcommerceItemDimension(ItemViewModelItem, "Height")?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceItemLength":
                    this.EcommerceItemWeightError = ItemService.ValidateEcommerceItemDimension(ItemViewModelItem, "Length")?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceItemName":
                    this.EcommerceItemNameError = ItemService.ValidateEcommerceItemName(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceItemWeight":
                    this.EcommerceItemWeightError = ItemService.ValidateEcommerceItemDimension(ItemViewModelItem, "Weight")?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceItemWidth":
                    this.EcommerceItemWeightError = ItemService.ValidateEcommerceItemDimension(ItemViewModelItem, "Width")?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceModelName":
                    this.EcommerceModelNameError = ItemService.ValidateEcommerceModelName(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommercePackageHeight":
                    this.EcommercePackageHeightError = ItemService.ValidateEcommercePackageDimension(ItemViewModelItem, "Height")?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommercePackageLength":
                    this.EcommercePackageLengthError = ItemService.ValidateEcommercePackageDimension(ItemViewModelItem, "Length")?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommercePackageWeight":
                    this.EcommercePackageWeightError = ItemService.ValidateEcommercePackageDimension(ItemViewModelItem, "Weight")?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommercePackageWidth":
                    this.EcommercePackageWidthError = ItemService.ValidateEcommercePackageDimension(ItemViewModelItem, "Width")?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommercePageQty":
                    this.EcommercePageQtyError = ItemService.ValidateEcommercePageQty(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceParentAsin":
                    this.EcommerceParentAsinError = ItemService.ValidateEcommerceParentAsin(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceProductCategory":
                    this.EcommerceProductCategoryError = ItemService.ValidateEcommerceProductCategory(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceProductDescription":
                    this.EcommerceProductDescriptionError = ItemService.ValidateEcommerceProductDescription(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceProductSubcategory":
                    this.EcommerceProductSubcategoryError = ItemService.ValidateEcommerceProductSubcategory(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceManufacturerName":
                    this.EcommerceManufacturerNameError = ItemService.ValidateEcommerceManufacturerName(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceMsrp":
                    this.EcommerceMsrpError = ItemService.ValidateEcommerceMsrp(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommereSize":
                    this.EcommerceSizeError = ItemService.ValidateEcommerceSize(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommerceSubjectKeywords":
                    this.EcommerceSubjectKeywordsError = ItemService.ValidateEcommerceKeywords(ItemViewModelItem, "Subject")?.ReturnErrorMessage() ?? "";
                    break;

                case "EcommereUpc":
                    this.EcommerceUpcError = ItemService.ValidateEcommerceUpc(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "Gpc":
                    this.GpcError = ItemService.ValidateGpc(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "Height":
                    this.HeightError = ItemService.ValidateEcommerceItemDimension(ItemViewModelItem, "Height")?.ReturnErrorMessage() ?? "";
                    break;

                case "ImagePath":
                    this.ImagePathError = ItemService.ValidateImagePath(ItemViewModelItem, "1")?.ReturnErrorMessage() ?? "";
                    SetImages();
                    break;

                case "InnerpackHeight":
                    this.InnerpackWidthError = ItemService.ValidateInnerpack(ItemViewModelItem, "Width")?.ReturnErrorMessage() ?? "";
                    this.InnerpackHeightError = ItemService.ValidateInnerpack(ItemViewModelItem, "Height")?.ReturnErrorMessage() ?? "";
                    this.InnerpackLengthError = ItemService.ValidateInnerpack(ItemViewModelItem, "Length")?.ReturnErrorMessage() ?? "";
                    this.InnerpackWeightError = ItemService.ValidateInnerpack(ItemViewModelItem, "Weight")?.ReturnErrorMessage() ?? "";
                    break;

                case "InnerpackLength":
                    this.InnerpackWidthError = ItemService.ValidateInnerpack(ItemViewModelItem, "Width")?.ReturnErrorMessage() ?? "";
                    this.InnerpackHeightError = ItemService.ValidateInnerpack(ItemViewModelItem, "Height")?.ReturnErrorMessage() ?? "";
                    this.InnerpackLengthError = ItemService.ValidateInnerpack(ItemViewModelItem, "Length")?.ReturnErrorMessage() ?? "";
                    this.InnerpackWeightError = ItemService.ValidateInnerpack(ItemViewModelItem, "Weight")?.ReturnErrorMessage() ?? "";
                    break;

                case "InnerpackWeight":
                    this.InnerpackWidthError = ItemService.ValidateInnerpack(ItemViewModelItem, "Width")?.ReturnErrorMessage() ?? "";
                    this.InnerpackHeightError = ItemService.ValidateInnerpack(ItemViewModelItem, "Height")?.ReturnErrorMessage() ?? "";
                    this.InnerpackLengthError = ItemService.ValidateInnerpack(ItemViewModelItem, "Length")?.ReturnErrorMessage() ?? "";
                    this.InnerpackWeightError = ItemService.ValidateInnerpack(ItemViewModelItem, "Weight")?.ReturnErrorMessage() ?? "";
                    break;

                case "InnerpackWidth":
                    this.InnerpackWidthError = ItemService.ValidateInnerpack(ItemViewModelItem, "Width")?.ReturnErrorMessage() ?? "";
                    this.InnerpackHeightError = ItemService.ValidateInnerpack(ItemViewModelItem, "Height")?.ReturnErrorMessage() ?? "";
                    this.InnerpackLengthError = ItemService.ValidateInnerpack(ItemViewModelItem, "Length")?.ReturnErrorMessage() ?? "";
                    this.InnerpackWeightError = ItemService.ValidateInnerpack(ItemViewModelItem, "Weight")?.ReturnErrorMessage() ?? "";
                    break;

                case "InnerpackQuantity":
                    this.InnerpackQuantityError = ItemService.ValidateInnerpackQuantity(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "InnerpackUpc":
                    this.InnerpackUpcError = ItemService.ValidatePackUpc(ItemViewModelItem, "Innerpack")?.ReturnErrorMessage() ?? "";
                    break;

                case "InStockDate":
                    this.InStockDateError = ItemService.ValidateInStockDate(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "Isbn":
                    this.IsbnError = ItemService.ValidateIsbn(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "ItemCategory":
                    this.ItemCategoryError = ItemService.ValidateItemCategory(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "ItemFamily":
                    this.ItemFamilyError = ItemService.ValidateItemFamily(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "ItemGroup":
                    this.ItemGroupError = ItemService.ValidateItemGroup(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;
                case "ItemId":
                    this.ItemIdError = ItemService.ValidateItemId(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "ItemKeywords":
                    this.ItemKeywordsError = ItemService.ValidateItemKeywords(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "Language":
                    this.LanguageError = ItemService.ValidateLanguage(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "Length":
                    this.LengthError = ItemService.ValidateEcommerceItemDimension(ItemViewModelItem, "Length")?.ReturnErrorMessage() ?? "";
                    break;

                case "LicenseBeginDate":
                    this.LicenseBeginDateError = ItemService.ValidateLicenseBeginDate(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "License":
                    RefreshPropertyList(ItemViewModelItem.License);
                    this.LicenseError = ItemService.ValidateLicense(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.PropertyError = ItemService.ValidateProperty(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "ListPriceCad":
                    this.ListPriceCadError = ItemService.ValidateListPrice(ItemViewModelItem, "CAD")?.ReturnErrorMessage() ?? "";
                    this.MsrpCadError = ItemService.ValidateMsrp(ItemViewModelItem, "CAD")?.ReturnErrorMessage() ?? "";
                    this.PricingGroupError = ItemService.ValidatePricingGroup(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "ListPriceMxn":
                    this.MsrpMxnError = ItemService.ValidateMsrp(ItemViewModelItem, "MXN")?.ReturnErrorMessage() ?? "";
                    this.ListPriceMxnError = ItemService.ValidateListPrice(ItemViewModelItem, "MXN")?.ReturnErrorMessage() ?? "";
                    break;

                case "ListPriceUsd":
                    this.ListPriceUsdError = ItemService.ValidateListPrice(ItemViewModelItem, "USD")?.ReturnErrorMessage() ?? "";
                    this.ProductQtyTotal = ItemService.RetrieveB2bPrice(ItemViewModelItem.ListPriceUsd, this.ProductQty);
                    this.MsrpError = ItemService.ValidateMsrp(ItemViewModelItem, "USD")?.ReturnErrorMessage() ?? "";
                    this.PricingGroupError = ItemService.ValidatePricingGroup(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.StatsCodeError = ItemService.ValidateStatsCode(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.CountryOfOriginError = ItemService.ValidateCountryOfOrigin(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.LanguageError = ItemService.ValidateLanguage(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.TerritoryError = ItemService.ValidateTerritory(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.GpcError = ItemService.ValidateGpc(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.UpcError = ItemService.ValidateUpc(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "MetaDescription":
                    this.MetaDescriptionError = ItemService.ValidateMetaDescription(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "MfgSource":
                    this.MfgSourceError = ItemService.ValidateMfgSource(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.CostProfileGroupError = ItemService.ValidateCostProfileGroup(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "Msrp":
                    this.MsrpError = ItemService.ValidateMsrp(ItemViewModelItem, "USD")?.ReturnErrorMessage() ?? "";
                    break;

                case "MsrpCad":
                    this.MsrpCadError = ItemService.ValidateMsrp(ItemViewModelItem, "CAD")?.ReturnErrorMessage() ?? "";
                    break;

                case "MsrpMxn":
                    this.MsrpMxnError = ItemService.ValidateMsrp(ItemViewModelItem, "MXN")?.ReturnErrorMessage() ?? "";
                    break;

                case "PricingGroup":
                    this.PricingGroupError = ItemService.ValidatePricingGroup(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "PrintOnDemand":
                    this.PrintOnDemandError = ItemService.ValidatePrintOnDemand(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "ProductFormat":
                    this.ProductFormatError = ItemService.ValidateProductFormat(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.ProductIdTranslationError = ItemService.ValidateProductIdTranslation(ItemViewModelItem, this.ItemIds)?.ReturnErrorMessage() ?? "";
                    this.UpcError = ItemService.ValidateUpc(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.EanError = ItemService.ValidateEan(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "ProductGroup":
                    RefreshProductLines();
                    RefreshProductFormats("");
                    this.ProductFormatError = ItemService.ValidateProductFormat(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.ProductLineError = ItemService.ValidateProductLine(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.ProductGroupError = ItemService.ValidateProductGroup(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.UpcError = ItemService.ValidateUpc(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "ProductIdTranslation":
                    this.ProductIdTranslationError = ItemService.ValidateProductIdTranslation(ItemViewModelItem, this.ItemIds)?.ReturnErrorMessage() ?? "";
                    break;

                case "ProductLine":
                    RefreshProductFormats(this.ProductLine);
                    this.EanError = ItemService.ValidateEan(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.ProductFormatError = ItemService.ValidateProductFormat(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.ProductLineError = ItemService.ValidateProductLine(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.UpcError = ItemService.ValidateUpc(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "ProductQty":
                    this.ProductQtyTotal = ItemService.RetrieveB2bPrice(ItemViewModelItem.ListPriceUsd, ItemViewModelItem.ProductQty);
                    this.ProductQtyError = ItemService.ValidateProductQty(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "Property":
                    this.PropertyError = ItemService.ValidateProperty(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "PsStatus":
                    this.PsStatusError = ItemService.ValidatePsStatus(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "SatCode":
                    this.SatCodeError = ItemService.ValidateSatCode(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    break;

                case "SellOnAllPostersCheck":
                    this.SellOnAllPostersError = ItemService.ValidateSellOnValue(ItemViewModelItem, "All Posters")?.ReturnErrorMessage() ?? "";
                    break;

                case "SellOnAmazonCheck":
                    this.SellOnAmazonError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Amazon")?.ReturnErrorMessage() ?? "";
                    break;

                case "SellOnAmazonSellerCentralCheck":
                    this.SellOnAmazonSellerCentralError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Amazon Seller Central")?.ReturnErrorMessage() ?? "";
                    break;

                case "SellOnEcommerceCheck":
                    this.SellOnEcommerceError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Ecommerce")?.ReturnErrorMessage() ?? "";
                    break;

                case "SellOnFanaticsCheck":
                    this.SellOnFanaticsError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Fanatics")?.ReturnErrorMessage() ?? "";
                    break;

                case "SellOnGuitarCenterCheck":
                    this.SellOnGuitarCenterError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Guitar Center")?.ReturnErrorMessage() ?? "";
                    break;

                case "SellOnHayneedleCheck":
                    this.SellOnHayneedleError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Hayneedle")?.ReturnErrorMessage() ?? "";
                    break;

                case "SellOnTargetCheck":
                    this.SellOnTargetError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Target")?.ReturnErrorMessage() ?? "";
                    break;

                case "SellOnTrendsCheck":
                    this.TitleError = ItemService.ValidateTitle(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.MetaDescriptionError = ItemService.ValidateMetaDescription(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.CategoryError = ItemService.ValidateCategory(ItemViewModelItem, "1")?.ReturnErrorMessage() ?? "";
                    this.ItemKeywordsError = ItemService.ValidateItemKeywords(ItemViewModelItem)?.ReturnErrorMessage() ?? "";
                    this.SellOnTrendsError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Trends")?.ReturnErrorMessage()??"";
                    break;

                case "SellOnWalmartCheck":
                    this.SellOnWalmartError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Walmart")?.ReturnErrorMessage()??"";
                    break;

                case "SellOnWayfairCheck":
                    this.SellOnWayfairError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Wayfair")?.ReturnErrorMessage()??"";
                    break;

                case "ShortDescription":
                    this.ShortDescriptionError = ItemService.ValidateShortDescription(ItemViewModelItem)?.ReturnErrorMessage()??"";
                    break;

                case "Size":
                    this.SizeError = ItemService.ValidateSize(ItemViewModelItem)?.ReturnErrorMessage()??"";
                    break;

                case "StandardCost":
                    this.StandardCostError = ItemService.ValidateStandardCost(ItemViewModelItem)?.ReturnErrorMessage()??"";
                    break;

                case "StatsCode":
                    this.StatsCodeError = ItemService.ValidateStatsCode(ItemViewModelItem)?.ReturnErrorMessage()??"";
                    break;

                case "TariffCode":
                    this.TariffCodeError = ItemService.ValidateTariffCode(ItemViewModelItem)?.ReturnErrorMessage()??"";
                    break;

                case "Territory":
                    this.TerritoryError = ItemService.ValidateTerritory(ItemViewModelItem)?.ReturnErrorMessage()??"";
                    break;

                case "Title":
                    this.TitleError = ItemService.ValidateTitle(ItemViewModelItem)?.ReturnErrorMessage()??"";
                    break;

                case "Udex":
                    this.UdexError = ItemService.ValidateUdex(ItemViewModelItem)?.ReturnErrorMessage()??"";
                    break;

                case "Upc":
                    this.UpcError = ItemService.ValidateUpc(ItemViewModelItem)?.ReturnErrorMessage()??"";
                    this.ProductFormatError = ItemService.ValidateProductFormat(ItemViewModelItem)?.ReturnErrorMessage()??"";
                    this.ProductGroupError = ItemService.ValidateProductGroup(ItemViewModelItem)?.ReturnErrorMessage()??"";
                    this.ProductLineError = ItemService.ValidateProductLine(ItemViewModelItem)?.ReturnErrorMessage()??"";
                    break;

                case "WebsitePrice":
                    this.WebsitePriceError = ItemService.ValidateWebsitePrice(ItemViewModelItem)?.ReturnErrorMessage()??"";
                    break;

                case "Warranty":
                    this.WarrantyError = ItemService.ValidateWarranty(ItemViewModelItem)?.ReturnErrorMessage()??"";
                    break;

                case "WarrantyCheck":
                    this.WarrantyCheckError = ItemService.ValidateWarrantyCheck(ItemViewModelItem)?.ReturnErrorMessage()??"";
                    break;

                case "Weight":
                    this.WeightError = ItemService.ValidateItemDimension(ItemViewModelItem, "Weight")?.ReturnErrorMessage()??"";
                    break;

                case "Width":
                    this.WidthError = ItemService.ValidateItemDimension(ItemViewModelItem, "Width")?.ReturnErrorMessage()??"";
                    break;

                default:
                    throw new ArgumentNullException("ItemViewModel Flag error unknown type " + field);
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
            SetStatsCodes();
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

        public void SetStatsCodes()
        {
            foreach(KeyValuePair<string,string> pair in GlobalData.StatsCodes)
            {
                this.StatsCodes.Add(pair.Key);
            }
            this.StatsCodes.Sort();
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
            this.EcommerceAsinToolTip = ReturnToolTip("EcommerceAsinToolTip");
            this.EcommerceBullet1ToolTip = ReturnToolTip("EcommerceBulletToolTip");
            this.EcommerceBullet2ToolTip = ReturnToolTip("EcommerceBulletToolTip");
            this.EcommerceBullet3ToolTip = ReturnToolTip("EcommerceBulletToolTip");
            this.EcommerceBullet4ToolTip = ReturnToolTip("EcommerceBulletToolTip");
            this.EcommerceBullet5ToolTip = ReturnToolTip("EcommerceBulletToolTip");
            this.EcommerceComponentsToolTip = ReturnToolTip("EcommerceComponentsToolTip");
            this.EcommerceCostToolTip = ReturnToolTip("EcommerceCostToolTip");
            this.EcommerceExternalIdToolTip = ReturnToolTip("EcommerceExternalIdToolTip");
            this.EcommerceExternalIdTypeToolTip = ReturnToolTip("EcommerceExternalIdTypeToolTip");
            this.EcommerceGenericKeywordsToolTip = ReturnToolTip("EcommerceGenericKeywordsToolTip");
            this.EcommerceItemHeightToolTip = ReturnToolTip("EcommerceItemHeightToolTip");
            this.EcommerceItemLengthToolTip = ReturnToolTip("EcommerceItemLengthToolTip");
            this.EcommerceItemNameToolTip = ReturnToolTip("EcommerceItemNameToolTip");
            this.EcommerceItemWeightToolTip = ReturnToolTip("EcommerceItemWeightToolTip");
            this.EcommerceItemWidthToolTip = ReturnToolTip("EcommerceItemWidthToolTip");
            this.EcommerceModelNameToolTip = ReturnToolTip("EcommerceModelNameToolTip");
            this.EcommercePackageHeightToolTip = ReturnToolTip("EcommercePackageHeightToolTip");
            this.EcommercePackageLengthToolTip = ReturnToolTip("EcommercePackageLengthToolTip");
            this.EcommercePackageWeightToolTip = ReturnToolTip("EcommercePackageWeightToolTip");
            this.EcommercePackageWidthToolTip = ReturnToolTip("EcommercePackageWidthToolTip");
            this.EcommercePageQtyToolTip = ReturnToolTip("EcommercePageQtyToolTip");
            this.EcommerceParentAsinToolTip = ReturnToolTip("EcommerceParentAsinToolTip");
            this.EcommerceProductCategoryToolTip = ReturnToolTip("EcommerceProductCategoryToolTip");
            this.EcommerceProductDescriptionToolTip = ReturnToolTip("EcommerceProductDescriptionToolTip");
            this.EcommerceProductSubcategoryToolTip = ReturnToolTip("EcommerceProductSubcategoryToolTip");
            this.EcommerceManufacturerNameToolTip = ReturnToolTip("EcommerceManufacturerNameToolTip");
            this.EcommerceMsrpToolTip = ReturnToolTip("EcommerceMsrpToolTip");
            this.EcommerceSizeToolTip = ReturnToolTip("EcommerceSizeToolTip");
            this.EcommerceSubjectKeywordsToolTip = ReturnToolTip("EcommerceSubjectKeywordsToolTip");
            this.EcommerceUpcToolTip = ReturnToolTip("EcommerceUpcToolTip");
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
            this.SellOnAmazonSellerCentralToolTip = ReturnToolTip("SellOnAmazonSellerCentral");
            this.SellOnEcommerceToolTip = ReturnToolTip("SellOnEcommerce");
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
            this.WarrantyToolTip = ReturnToolTip("Warranty");
            this.WarrantyCheckToolTip = ReturnToolTip("WarrantyCheck");
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
            ObservableCollection<ItemError> errors = ItemService.ValidateItem(ItemViewModelItem, ItemIds, false);
            
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
        
        /*
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
            this.HeightError = ItemService.ValidateItemDimension(var.Height, var.ProdType);
            this.ImagePathError = ItemService.ValidateImagePath(this.ImagePath, "ImagePath", this.ItemViewModelItem.HasWeb());
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
            this.ShortDescriptionError = ItemService.ValidateShortDescription(var.ShortDescription);
            this.SizeError = ItemService.ValidateSize(var.Size);
            this.StandardCostError = ItemService.ValidateStandardCost(var.StandardCost, var.ProdType);
            this.StatsCodeError = ItemService.ValidateStatsCode(var.StatsCode, var.ListPriceUsd, var.ProdType);
            this.TariffCodeError = ItemService.ValidateTariffCode(var.TariffCode, var.ProdType);
            this.TerritoryError = ItemService.ValidateTerritory(var.Territory, var.ListPriceUsd, var.ProdType);
            this.TitleError = ItemService.ValidateTitle(var.Title, var.HasWeb());
            this.UdexError = ItemService.ValidateUdex(var.Udex, var.ProdType);
            this.UpcError = ItemService.ValidateUpc(var.Upc, this.ItemId, this.Status, var.ListPriceUsd, var.ProductFormat, var.ProductGroup, var.ProductLine, var.Ean, var.EcommerceUpc, var.ProdType);
            this.WarrantyError = ItemService.ValidateWarranty(var);
            this.WarrantyCheckError = ItemService.ValidateWarrantyCheck(var);
            this.WebsitePriceError = ItemService.ValidateWebsitePrice(var.WebsitePrice, var.HasWeb());
            this.WeightError = ItemService.ValidateWeight(var.Weight, var.ProdType);
            this.WidthError = ItemService.ValidateWidth(var.Width, var.ProdType);
            ValidateEcommerce();
            ValidateSellOnFields();
        }
        */

        /// <summary>
        ///     Validate all ecommerce fields
        /// </summary>
        public void ValidateEcommerce()
        {
            this.EcommerceAsinError = ItemService.ValidateEcommerceAsin(ItemViewModelItem).ReturnErrorMessage();
            this.EcommerceBullet1Error = ItemService.ValidateEcommerceBullet(ItemViewModelItem, "1").ReturnErrorMessage();
            this.EcommerceBullet2Error = ItemService.ValidateEcommerceBullet(ItemViewModelItem, "2").ReturnErrorMessage();
            this.EcommerceBullet3Error = ItemService.ValidateEcommerceBullet(ItemViewModelItem, "3").ReturnErrorMessage();
            this.EcommerceBullet4Error = ItemService.ValidateEcommerceBullet(ItemViewModelItem, "4").ReturnErrorMessage();
            this.EcommerceBullet5Error = ItemService.ValidateEcommerceBullet(ItemViewModelItem, "5").ReturnErrorMessage();
            this.EcommerceComponentsError = ItemService.ValidateEcommerceComponents(ItemViewModelItem).ReturnErrorMessage();
            this.EcommerceCostError = ItemService.ValidateEcommerceCost(ItemViewModelItem).ReturnErrorMessage();
            this.EcommerceExternalIdTypeError = ItemService.ValidateEcommerceExternalIdType(ItemViewModelItem).ReturnErrorMessage();
            this.EcommerceExternalIdError = ItemService.ValidateEcommerceExternalId(ItemViewModelItem).ReturnErrorMessage();
            this.EcommerceGenericKeywordsError = ItemService.ValidateEcommerceKeywords(ItemViewModelItem, "Generic").ReturnErrorMessage();
            this.EcommerceItemHeightError = ItemService.ValidateEcommerceItemDimension(ItemViewModelItem,"Height").ReturnErrorMessage();
            this.EcommerceItemLengthError = ItemService.ValidateEcommerceItemDimension(ItemViewModelItem, "Length").ReturnErrorMessage();
            this.EcommerceItemNameError = ItemService.ValidateEcommerceItemName(ItemViewModelItem).ReturnErrorMessage();
            this.EcommerceItemWeightError = ItemService.ValidateEcommerceItemDimension(ItemViewModelItem,"Weight").ReturnErrorMessage();
            this.EcommerceItemWidthError = ItemService.ValidateEcommerceItemDimension(ItemViewModelItem, "Width").ReturnErrorMessage();
            this.EcommerceModelNameError = ItemService.ValidateEcommerceModelName(ItemViewModelItem).ReturnErrorMessage();
            this.EcommercePackageHeightError = ItemService.ValidateEcommercePackageDimension(ItemViewModelItem, "Height").ReturnErrorMessage();
            this.EcommercePackageLengthError = ItemService.ValidateEcommercePackageDimension(ItemViewModelItem, "Length").ReturnErrorMessage();
            this.EcommercePackageWeightError = ItemService.ValidateEcommercePackageDimension(ItemViewModelItem, "Weight").ReturnErrorMessage();
            this.EcommercePackageWidthError = ItemService.ValidateEcommercePackageDimension(ItemViewModelItem, "Width").ReturnErrorMessage();
            this.EcommercePageQtyError = ItemService.ValidateEcommercePageQty(ItemViewModelItem).ReturnErrorMessage();
            this.EcommerceParentAsinError = ItemService.ValidateEcommerceParentAsin(ItemViewModelItem).ReturnErrorMessage();
            this.EcommerceProductCategoryError = ItemService.ValidateEcommerceProductCategory(ItemViewModelItem).ReturnErrorMessage();
            this.EcommerceProductDescriptionError = ItemService.ValidateEcommerceProductDescription(ItemViewModelItem).ReturnErrorMessage();
            this.EcommerceProductSubcategoryError = ItemService.ValidateEcommerceProductSubcategory(ItemViewModelItem).ReturnErrorMessage();
            this.EcommerceManufacturerNameError = ItemService.ValidateEcommerceManufacturerName(ItemViewModelItem).ReturnErrorMessage();
            this.EcommerceMsrpError = ItemService.ValidateEcommerceMsrp(ItemViewModelItem).ReturnErrorMessage();
            this.EcommerceSizeError = ItemService.ValidateEcommerceSize(ItemViewModelItem).ReturnErrorMessage();
            this.EcommerceSubjectKeywordsError = ItemService.ValidateEcommerceKeywords(ItemViewModelItem, "Subject").ReturnErrorMessage();
            this.EcommerceUpcError = ItemService.ValidateEcommerceUpc(ItemViewModelItem).ReturnErrorMessage();
        }

        /// <summary>
        ///     Validate the sell on fields for external ecommerce sites
        /// </summary>
        public void ValidateSellOnFields()
        {
            this.SellOnAllPostersError = ItemService.ValidateSellOnValue(ItemViewModelItem, "All Posters").ReturnErrorMessage();
            this.SellOnAmazonError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Amazon").ReturnErrorMessage();
            this.SellOnAmazonSellerCentralError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Amazon Seller Central").ReturnErrorMessage();
            this.SellOnFanaticsError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Fanatics").ReturnErrorMessage();
            this.SellOnGuitarCenterError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Guitar Center").ReturnErrorMessage();
            this.SellOnHayneedleError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Hayneedle").ReturnErrorMessage();
            this.SellOnTargetError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Target").ReturnErrorMessage();
            this.SellOnWalmartError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Walmart").ReturnErrorMessage();
            this.SellOnWayfairError = ItemService.ValidateSellOnValue(ItemViewModelItem, "Wayfair").ReturnErrorMessage();
        }

        #endregion //Methods

        #region Constructor

        /// <summary>
        ///     Constructs Item View Model Object
        /// </summary>
        /// <param name="itemObj"></param>
        /// <param name="itemService"></param>
        public ItemViewModel(ItemObject itemObj, ItemService itemService, List<string> itemIds, ObservableCollection<ItemError> errors = null)
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
            if (errors != null)
            {
                foreach (ItemError error in errors)
                {
                    if (error.ItemIdNumber == this.ItemViewModelItem.ItemId)
                    {
                        AssignError(error);
                    }
                }
            }
            // ValidateAll(this.ItemViewModelItem);
        }

        #endregion // Constructor
    }
}
