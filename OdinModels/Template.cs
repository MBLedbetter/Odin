using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OdinModels
{
    public class Template
    {
        #region Events

        /// <summary>
        ///     This event is raised when a property of this object is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion // Events

        #region Properties

        /// <summary>
        ///     Gets / Sets TemplateId field
        /// </summary>
        public string TemplateId
        {
            get
            {
                return _templateId;
            }
            set
            {
                if (_templateId != value)
                {
                    _templateId = value;
                    OnPropertyChanged("TemplateId");
                }
            }
        }
        private string _templateId = string.Empty;

        /// <summary>
        ///     Gets / Sets AccountingGroup field
        /// </summary>
        public string AccountingGroup
        {
            get
            {
                return _accountingGroup;
            }
            set
            {
                if (_accountingGroup != value)
                {
                    _accountingGroup = value;
                    OnPropertyChanged("AccountingGroup");
                }
            }
        }
        private string _accountingGroup = string.Empty;

        /// <summary>
        ///     Gets / Sets CasepackHeight field
        /// </summary>
        public string CasepackHeight
        {
            get
            {
                return _casepackHeight;
            }
            set
            {
                if (_casepackHeight != value)
                {
                    _casepackHeight = value;
                    OnPropertyChanged("CasepackHeight");
                }
            }
        }
        private string _casepackHeight = string.Empty;

        /// <summary>
        ///     Gets / Sets CasepackLenght field
        /// </summary>
        public string CasepackLength
        {
            get
            {
                return _casepackLength;
            }
            set
            {
                if (_casepackLength != value)
                {
                    _casepackLength = value;
                    OnPropertyChanged("CasepackLength");
                }
            }
        }
        private string _casepackLength = string.Empty;

        /// <summary>
        ///     Gets / Sets CasepackQty field
        /// </summary>
        public string CasepackQty
        {
            get
            {
                return _casepackQty;
            }
            set
            {
                if (_casepackQty != value)
                {
                    _casepackQty = value;
                    OnPropertyChanged("CasepackQty");
                }
            }
        }
        private string _casepackQty = string.Empty;
        
        /// <summary>
        ///     Gets / Sets CasepackWidth field
        /// </summary>
        public string CasepackWidth
        {
            get
            {
                return _casepackWidth;
            }
            set
            {
                if (_casepackWidth != value)
                {
                    _casepackWidth = value;
                    OnPropertyChanged("CasepackWidth");
                }
            }
        }
        private string _casepackWidth = string.Empty;

        /// <summary>
        ///     Gets / Sets CasepackWeight field
        /// </summary>
        public string CasepackWeight
        {
            get
            {
                return _casepackWeight;
            }
            set
            {
                if (_casepackWeight != value)
                {
                    _casepackWeight = value;
                    OnPropertyChanged("CasepackWeight");
                }
            }
        }
        private string _casepackWeight = string.Empty;

        /// <summary>
        ///     Gets / Sets Category field
        /// </summary>
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged("Category");
                }
            }
        }
        private string _category = string.Empty;

        /// <summary>
        ///     Gets / Sets Category2 field
        /// </summary>
        public string Category2
        {
            get
            {
                return _category2;
            }
            set
            {
                if (_category2 != value)
                {
                    _category2 = value;
                    OnPropertyChanged("Category2");
                }
            }
        }
        private string _category2 = string.Empty;

        /// <summary>
        ///     Gets / Sets Category3 field
        /// </summary>
        public string Category3
        {
            get
            {
                return _category3;
            }
            set
            {
                if (_category3 != value)
                {
                    _category3 = value;
                    OnPropertyChanged("Category3");
                }
            }
        }
        private string _category3 = string.Empty;

        /// <summary>
        ///     Gets / Sets Copyright field
        /// </summary>
        public string Copyright
        {
            get
            {
                return _copyright;
            }
            set
            {
                if (_copyright != value)
                {
                    _copyright = value;
                    OnPropertyChanged("Copyright");
                }
            }
        }
        private string _copyright = string.Empty;

        /// <summary>
        ///     Gets / Sets CountryOfOrigin field
        /// </summary>
        public string CountryOfOrigin
        {
            get
            {
                return _countryOfOrigin;
            }
            set
            {
                if (_countryOfOrigin != value)
                {
                    _countryOfOrigin = value;
                    OnPropertyChanged("CountryOfOrigin");
                }
            }
        }
        private string _countryOfOrigin = string.Empty;

        /// <summary>
        ///     Gets / Sets CostProfileGroup field
        /// </summary>
        public string CostProfileGroup
        {
            get
            {
                return _costProfileGroup;
            }
            set
            {
                if (_costProfileGroup != value)
                {
                    _costProfileGroup = value;
                    OnPropertyChanged("CostProfileGroup");
                }
            }
        }
        private string _costProfileGroup = string.Empty;

        /// <summary>
        ///     Gets / Sets DefaultActualCostCad field
        /// </summary>
        public string DefaultActualCostCad
        {
            get
            {
                return _defaultActualCostCad;
            }
            set
            {
                if (_defaultActualCostCad != value)
                {
                    _defaultActualCostCad = value;
                    OnPropertyChanged("DefaultActualCostCad");
                }
            }
        }
        private string _defaultActualCostCad = string.Empty;

        /// <summary>
        ///     Gets / Sets DefaultActualCostUsd field
        /// </summary>
        public string DefaultActualCostUsd
        {
            get
            {
                return _defaultActualCostUsd;
            }
            set
            {
                if (_defaultActualCostUsd != value)
                {
                    _defaultActualCostUsd = value;
                    OnPropertyChanged("DefaultActualCostUsd");
                }
            }
        }
        private string _defaultActualCostUsd = string.Empty;

        /// <summary>
        ///     Gets / Sets Duty field
        /// </summary>
        public string Duty
        {
            get
            {
                return _duty;
            }
            set
            {
                if (_duty != value)
                {
                    _duty = value;
                    OnPropertyChanged("Duty");
                }
            }
        }
        private string _duty = string.Empty;
        
        /// <summary>
        ///     Gets / Sets Gpc field
        /// </summary>
        public string Gpc
        {
            get
            {
                return _gpc;
            }
            set
            {
                if (_gpc != value)
                {
                    _gpc = value;
                    OnPropertyChanged("Gpc");
                }
            }
        }
        private string _gpc = string.Empty;

        /// <summary>
        ///     Gets / Sets Height field
        /// </summary>
        public string Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (_height != value)
                {
                    _height = value;
                    OnPropertyChanged("Height");
                }
            }
        }
        private string _height = string.Empty;

        /// <summary>
        ///     Gets / Sets InnerpackHeight field
        /// </summary>
        public string InnerpackHeight
        {
            get
            {
                return _innerpackHeight;
            }
            set
            {
                if (_innerpackHeight != value)
                {
                    _innerpackHeight = value;
                    OnPropertyChanged("InnerpackHeight");
                }
            }
        }
        private string _innerpackHeight = string.Empty;

        /// <summary>
        ///     Gets / Sets InnerpackLength field
        /// </summary>
        public string InnerpackLength
        {
            get
            {
                return _innerpackLength;
            }
            set
            {
                if (_innerpackLength != value)
                {
                    _innerpackLength = value;
                    OnPropertyChanged("InnerpackLength");
                }
            }
        }
        private string _innerpackLength = string.Empty;

        /// <summary>
        ///     Gets / Sets InnerpackQty field
        /// </summary>
        public string InnerpackQuantity
        {
            get
            {
                return _innerpackQuantity;
            }
            set
            {
                if (_innerpackQuantity != value)
                {
                    _innerpackQuantity = value;
                    OnPropertyChanged("InnerpackQty");
                }
            }
        }
        private string _innerpackQuantity = string.Empty;
        
        /// <summary>
        ///     Gets / Sets InnerpackWeight field
        /// </summary>
        public string InnerpackWeight
        {
            get
            {
                return _innerpackWeight;
            }
            set
            {
                if (_innerpackWeight != value)
                {
                    _innerpackWeight = value;
                    OnPropertyChanged("InnerpackWeight");
                }
            }
        }
        private string _innerpackWeight = string.Empty;

        /// <summary>
        ///     Gets / Sets InnerpackWidth field
        /// </summary>
        public string InnerpackWidth
        {
            get
            {
                return _innerpackWidth;
            }
            set
            {
                if (_innerpackWidth != value)
                {
                    _innerpackWidth = value;
                    OnPropertyChanged("InnerpackWidth");
                }
            }
        }
        private string _innerpackWidth = string.Empty;
        
        /// <summary>
        ///     Gets / Sets ItemCategory field
        /// </summary>
        public string ItemCategory
        {
            get
            {
                return _itemCategory;
            }
            set
            {
                if (_itemCategory != value)
                {
                    _itemCategory = value;
                    OnPropertyChanged("ItemCategory");
                }
            }
        }
        private string _itemCategory = string.Empty;

        /// <summary>
        ///     Gets / Sets ItemFamily field
        /// </summary>
        public string ItemFamily
        {
            get
            {
                return _itemFamily;
            }
            set
            {
                if (_itemFamily != value)
                {
                    _itemFamily = value;
                    OnPropertyChanged("ItemFamily");
                }
            }
        }
        private string _itemFamily = string.Empty;

        /// <summary>
        ///     Gets / Sets ItemGroup field
        /// </summary>
        public string ItemGroup
        {
            get
            {
                return _itemGroup;
            }
            set
            {
                if (_itemGroup != value)
                {
                    _itemGroup = value;
                    OnPropertyChanged("ItemGroup");
                }
            }
        }
        private string _itemGroup = string.Empty;
        
        /// <summary>
        ///     Gets / Sets Length field
        /// </summary>
        public string Length
        {
            get
            {
                return _length;
            }
            set
            {
                if (_length != value)
                {
                    _length = value;
                    OnPropertyChanged("Length");
                }
            }
        }
        private string _length = string.Empty;
        
        /// <summary>
        ///     Gets / Sets ListPriceCad field
        /// </summary>
        public string ListPriceCad
        {
            get
            {
                return _listPriceCad;
            }
            set
            {
                if (_listPriceCad != value)
                {
                    _listPriceCad = value;
                    OnPropertyChanged("ListPriceCad");
                }
            }
        }
        private string _listPriceCad = string.Empty;

        /// <summary>
        ///     Gets / Sets ListPriceMxn field
        /// </summary>
        public string ListPriceMxn
        {
            get
            {
                return _listPriceMxn;
            }
            set
            {
                if (_listPriceMxn != value)
                {
                    _listPriceMxn = value;
                    OnPropertyChanged("ListPriceMxn");
                }
            }
        }
        private string _listPriceMxn = string.Empty;

        /// <summary>
        ///     Gets / Sets ListPriceUsd field
        /// </summary>
        public string ListPriceUsd
        {
            get
            {
                return _listPriceUsd;
            }
            set
            {
                if (_listPriceUsd != value)
                {
                    _listPriceUsd = value;
                    OnPropertyChanged("ListPriceUsd");
                }
            }
        }
        private string _listPriceUsd = string.Empty;

        /// <summary>
        ///     Gets / Sets MetaDescription field
        /// </summary>
        public string MetaDescription
        {
            get
            {
                return _metaDescription;
            }
            set
            {
                if (_metaDescription != value)
                {
                    _metaDescription = value;
                    OnPropertyChanged("MetaDescription");
                }
            }
        }
        private string _metaDescription = string.Empty;

        /// <summary>
        ///     Gets / Sets MfgSource field
        /// </summary>
        public string MfgSource
        {
            get
            {
                return _mfgSource;
            }
            set
            {
                if (_mfgSource != value)
                {
                    _mfgSource = value;
                    OnPropertyChanged("MfgSource");
                }
            }
        }
        private string _mfgSource = string.Empty;

        /// <summary>
        ///     Gets / Sets Msrp field
        /// </summary>
        public string Msrp
        {
            get
            {
                return _msrp;
            }
            set
            {
                if (_msrp != value)
                {
                    _msrp = value;
                    OnPropertyChanged("Msrp");
                }
            }
        }
        private string _msrp = string.Empty;

        /// <summary>
        ///     Gets / Sets MsrpCad field
        /// </summary>
        public string MsrpCad
        {
            get
            {
                return _msrpCad;
            }
            set
            {
                if (_msrpCad != value)
                {
                    _msrpCad = value;
                    OnPropertyChanged("MsrpCad");
                }
            }
        }
        private string _msrpCad = string.Empty;

        /// <summary>
        ///     Gets / Sets MsrpMxn field
        /// </summary>
        public string MsrpMxn
        {
            get
            {
                return _msrpMxn;
            }
            set
            {
                if (_msrpMxn != value)
                {
                    _msrpMxn = value;
                    OnPropertyChanged("MsrpMxn");
                }
            }
        }
        private string _msrpMxn = string.Empty;

        public int ProdType = 2;

        /// <summary>
        ///     Gets / Sets PrintOnDemand field
        /// </summary>
        public string PrintOnDemand
        {
            get
            {
                return _printOnDemand;
            }
            set
            {
                if (_printOnDemand != value)
                {
                    _printOnDemand = value;
                    OnPropertyChanged("PrintOnDemand");
                }
            }
        }
        private string _printOnDemand = string.Empty;

        /// <summary>
        ///     Gets / Sets ProductFormat field
        /// </summary>
        public string ProductFormat
        {
            get
            {
                return _productFormat;
            }
            set
            {
                if (_productFormat != value)
                {
                    _productFormat = value;
                    OnPropertyChanged("ProductFormat");
                }
            }
        }
        private string _productFormat = string.Empty;

        /// <summary>
        ///     Gets / Sets ProductGroup field
        /// </summary>
        public string ProductGroup
        {
            get
            {
                return _productGroup;
            }
            set
            {
                if (_productGroup != value)
                {
                    _productGroup = value;
                    OnPropertyChanged("ProductGroup");
                }
            }
        }
        private string _productGroup = string.Empty;

        /// <summary>
        ///     Gets / Sets ProductLine field
        /// </summary>
        public string ProductLine
        {
            get
            {
                return _productLine;
            }
            set
            {
                if (_productLine != value)
                {
                    _productLine = value;
                    OnPropertyChanged("ProductLine");
                }
            }
        }
        private string _productLine = string.Empty;

        /// <summary>
        ///     Gets / Sets ProductQty field
        /// </summary>
        public string ProductQty
        {
            get
            {
                return _productQty;
            }
            set
            {
                if (_productQty != value)
                {
                    _productQty = value;
                    OnPropertyChanged("ProductQty");
                }
            }
        }
        private string _productQty = string.Empty;

        /// <summary>
        ///     Gets / Sets PricingGroup field
        /// </summary>
        public string PricingGroup
        {
            get
            {
                return _pricingGroup;
            }
            set
            {
                if (_pricingGroup != value)
                {
                    _pricingGroup = value;
                    OnPropertyChanged("PricingGroup");
                }
            }
        }
        private string _pricingGroup = string.Empty;

        /// <summary>
        ///     Gets / Sets Ps Status field
        /// </summary>
        public string PsStatus
        {
            get
            {
                return _psStatus;
            }
            set
            {
                if (_psStatus != value)
                {
                    _psStatus = value;
                    OnPropertyChanged("PsStatus");
                }
            }
        }
        private string _psStatus = string.Empty;

        /// <summary>
        ///     Gets / Sets SAT Code
        /// </summary>
        public string SatCode
        {
            get
            {
                return _satCode;
            }
            set
            {
                if (_satCode != value)
                {
                    _satCode = value;
                    OnPropertyChanged("SatCode");
                }
            }
        }
        private string _satCode = string.Empty;

        /// <summary>
        ///     Gets / Sets Size field
        /// </summary>
        public string Size
        {
            get
            {
                return _size;
            }
            set
            {
                if (_size != value)
                {
                    _size = value;
                    OnPropertyChanged("Size");
                }
            }
        }
        private string _size = string.Empty;
        
        /// <summary>
        ///     Gets / Sets TariffCode field
        /// </summary>
        public string TariffCode
        {
            get
            {
                return _tariffCode;
            }
            set
            {
                if (_tariffCode != value)
                {
                    _tariffCode = value;
                    OnPropertyChanged("TariffCode");
                }
            }
        }
        private string _tariffCode = string.Empty;
        
        /// <summary>
        ///     Gets / Sets Udex field
        /// </summary>
        public string Udex
        {
            get
            {
                return _udex;
            }
            set
            {
                if (_udex != value)
                {
                    _udex = value;
                    OnPropertyChanged("Udex");
                }
            }
        }
        private string _udex = string.Empty;

        /// <summary>
        ///     Gets / Sets Website Price field
        /// </summary>
        public string WebsitePrice
        {
            get
            {
                return _websitePrice;
            }
            set
            {
                if (_websitePrice != value)
                {
                    _websitePrice = value;
                    OnPropertyChanged("WebsitePrice");
                }
            }
        }
        private string _websitePrice = string.Empty;

        /// <summary>
        ///     Gets / Sets Weight field
        /// </summary>
        public string Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    OnPropertyChanged("Weight");
                }
            }
        }
        private string _weight = string.Empty;

        /// <summary>
        ///     Gets / Sets Width field
        /// </summary>
        public string Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (_width != value)
                {
                    _width = value;
                    OnPropertyChanged("Width");
                }
            }
        }
        private string _width = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceBullet1 field
        /// </summary>
        public string EcommerceBullet1
        {
            get
            {
                return _ecommerceBullet1;
            }
            set
            {
                if (_ecommerceBullet1 != value)
                {
                    _ecommerceBullet1 = value;
                    OnPropertyChanged("EcommerceBullet1");
                }
            }
        }
        private string _ecommerceBullet1 = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceBullet2 field
        /// </summary>
        public string EcommerceBullet2
        {
            get
            {
                return _ecommerceBullet2;
            }
            set
            {
                if (_ecommerceBullet2 != value)
                {
                    _ecommerceBullet2 = value;
                    OnPropertyChanged("EcommerceBullet2");
                }
            }
        }
        private string _ecommerceBullet2 = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceBullet3 field
        /// </summary>
        public string EcommerceBullet3
        {
            get
            {
                return _ecommerceBullet3;
            }
            set
            {
                if (_ecommerceBullet3 != value)
                {
                    _ecommerceBullet3 = value;
                    OnPropertyChanged("EcommerceBullet3");
                }
            }
        }
        private string _ecommerceBullet3 = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceBullet4 field
        /// </summary>
        public string EcommerceBullet4
        {
            get
            {
                return _ecommerceBullet4;
            }
            set
            {
                if (_ecommerceBullet4 != value)
                {
                    _ecommerceBullet4 = value;
                    OnPropertyChanged("EcommerceBullet4");
                }
            }
        }
        private string _ecommerceBullet4 = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceBullet5 field
        /// </summary>
        public string EcommerceBullet5
        {
            get
            {
                return _ecommerceBullet5;
            }
            set
            {
                if (_ecommerceBullet5 != value)
                {
                    _ecommerceBullet5 = value;
                    OnPropertyChanged("EcommerceBullet5");
                }
            }
        }
        private string _ecommerceBullet5 = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceComponents field
        /// </summary>
        public string EcommerceComponents
        {
            get
            {
                return _ecommerceComponents;
            }
            set
            {
                if (_ecommerceComponents != value)
                {
                    _ecommerceComponents = value;
                    OnPropertyChanged("EcommerceComponents");
                }
            }
        }
        private string _ecommerceComponents = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceCost field
        /// </summary>
        public string EcommerceCost
        {
            get
            {
                return _ecommerceCost;
            }
            set
            {
                if (_ecommerceCost != value)
                {
                    _ecommerceCost = value;
                    OnPropertyChanged("EcommerceCost");
                }
            }
        }
        private string _ecommerceCost = string.Empty;
        
        /// <summary>
        ///     Gets / Sets EcommerceExternalIdType field
        /// </summary>
        public string EcommerceExternalIdType
        {
            get
            {
                return _ecommerceExternalIdType;
            }
            set
            {
                if (_ecommerceExternalIdType != value)
                {
                    _ecommerceExternalIdType = value;
                    OnPropertyChanged("EcommerceExternalIdType");
                }
            }
        }
        private string _ecommerceExternalIdType = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceItemHeight field
        /// </summary>
        public string EcommerceItemHeight
        {
            get
            {
                return _ecommerceItemHeight;
            }
            set
            {
                if (_ecommerceItemHeight != value)
                {
                    _ecommerceItemHeight = value;
                    OnPropertyChanged("EcommerceItemHeight");
                }
            }
        }
        private string _ecommerceItemHeight = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceItemLength field
        /// </summary>
        public string EcommerceItemLength
        {
            get
            {
                return _ecommerceItemLength;
            }
            set
            {
                if (_ecommerceItemLength != value)
                {
                    _ecommerceItemLength = value;
                    OnPropertyChanged("EcommerceItemLength");
                }
            }
        }
        private string _ecommerceItemLength = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceItemWeight field
        /// </summary>
        public string EcommerceItemWeight
        {
            get
            {
                return _ecommerceItemWeight;
            }
            set
            {
                if (_ecommerceItemWeight != value)
                {
                    _ecommerceItemWeight = value;
                    OnPropertyChanged("EcommerceItemWeight");
                }
            }
        }
        private string _ecommerceItemWeight = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceItemWidth field
        /// </summary>
        public string EcommerceItemWidth
        {
            get
            {
                return _ecommerceItemWidth;
            }
            set
            {
                if (_ecommerceItemWidth != value)
                {
                    _ecommerceItemWidth = value;
                    OnPropertyChanged("EcommerceItemWidth");
                }
            }
        }
        private string _ecommerceItemWidth = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceModelName field
        /// </summary>
        public string EcommerceModelName
        {
            get
            {
                return _ecommerceModelName;
            }
            set
            {
                if (_ecommerceModelName != value)
                {
                    _ecommerceModelName = value;
                    OnPropertyChanged("EcommerceModelName");
                }
            }
        }
        private string _ecommerceModelName = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommercePackageLength field
        /// </summary>
        public string EcommercePackageLength
        {
            get
            {
                return _ecommercePackageLength;
            }
            set
            {
                if (_ecommercePackageLength != value)
                {
                    _ecommercePackageLength = value;
                    OnPropertyChanged("EcommercePackageLength");
                }
            }
        }
        private string _ecommercePackageLength = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommercePackageHeight field
        /// </summary>
        public string EcommercePackageHeight
        {
            get
            {
                return _ecommercePackageHeight;
            }
            set
            {
                if (_ecommercePackageHeight != value)
                {
                    _ecommercePackageHeight = value;
                    OnPropertyChanged("EcommercePackageHeight");
                }
            }
        }
        private string _ecommercePackageHeight = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommercePackageWeight field
        /// </summary>
        public string EcommercePackageWeight
        {
            get
            {
                return _ecommercePackageWeight;
            }
            set
            {
                if (_ecommercePackageWeight != value)
                {
                    _ecommercePackageWeight = value;
                    OnPropertyChanged("EcommercePackageWeight");
                }
            }
        }
        private string _ecommercePackageWeight = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommercePackageWidth field
        /// </summary>
        public string EcommercePackageWidth
        {
            get
            {
                return _ecommercePackageWidth;
            }
            set
            {
                if (_ecommercePackageWidth != value)
                {
                    _ecommercePackageWidth = value;
                    OnPropertyChanged("EcommercePackageWidth");
                }
            }
        }
        private string _ecommercePackageWidth = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommercePageQty field
        /// </summary>
        public string EcommercePageQty
        {
            get
            {
                return _ecommercePageQty;
            }
            set
            {
                if (_ecommercePageQty != value)
                {
                    _ecommercePageQty = value;
                    OnPropertyChanged("EcommercePageQty");
                }
            }
        }
        private string _ecommercePageQty = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceProductCategory field
        /// </summary>
        public string EcommerceProductCategory
        {
            get
            {
                return _ecommerceProductCategory;
            }
            set
            {
                if (_ecommerceProductCategory != value)
                {
                    _ecommerceProductCategory = value;
                    OnPropertyChanged("EcommerceProductCategory");
                }
            }
        }
        private string _ecommerceProductCategory = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceProductDescription field
        /// </summary>
        public string EcommerceProductDescription
        {
            get
            {
                return _ecommerceProductDescription;
            }
            set
            {
                if (_ecommerceProductDescription != value)
                {
                    _ecommerceProductDescription = value;
                    OnPropertyChanged("EcommerceProductDescription");
                }
            }
        }
        private string _ecommerceProductDescription = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceProductSubcategory field
        /// </summary>
        public string EcommerceProductSubcategory
        {
            get
            {
                return _ecommerceProductSubcategory;
            }
            set
            {
                if (_ecommerceProductSubcategory != value)
                {
                    _ecommerceProductSubcategory = value;
                    OnPropertyChanged("EcommerceProductSubcategory");
                }
            }
        }
        private string _ecommerceProductSubcategory = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceManufacturerName field
        /// </summary>
        public string EcommerceManufacturerName
        {
            get
            {
                return _ecommerceManufacturerName;
            }
            set
            {
                if (_ecommerceManufacturerName != value)
                {
                    _ecommerceManufacturerName = value;
                    OnPropertyChanged("EcommerceManufacturerName");
                }
            }
        }
        private string _ecommerceManufacturerName = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceMsrp field
        /// </summary>
        public string EcommerceMsrp
        {
            get
            {
                return _ecommerceMsrp;
            }
            set
            {
                if (_ecommerceMsrp != value)
                {
                    _ecommerceMsrp = value;
                    OnPropertyChanged("EcommerceMsrp");
                }
            }
        }
        private string _ecommerceMsrp = string.Empty;

        /// <summary>
        ///     Gets / Sets EcommerceSize field
        /// </summary>
        public string EcommerceSize
        {
            get
            {
                return _ecommerceSize;
            }
            set
            {
                if (_ecommerceSize != value)
                {
                    _ecommerceSize = value;
                    OnPropertyChanged("EcommerceSize");
                }
            }
        }
        private string _ecommerceSize = string.Empty;

        #endregion // Properites

        #region Methods

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
        #endregion // Methods

        #region Constructor

        public Template()
        {

        }

        /// <summary>
        ///     Constructs the Template Object
        /// </summary>
        public Template(
            string templateId,
            string accountingGroup,
            string casepackHeight,
            string casepackLength,
            string casepackQty,
            string casepackWidth,
            string casepackWeight,
            string category,
            string category2,
            string category3,
            string copyright,
            string costProfileGroup,
            string defaultActualCostCad,
            string defaultActualCostUsd,
            string duty,
            string gpc,
            string height,
            string innerpackHeight,
            string innerpackLength,
            string innerpackQuantity,
            string innerpackWeight,
            string innerpackWidth,
            string itemCategory,
            string itemFamily,
            string itemGroup,
            string length,
            string listPriceCad,
            string listPriceMxn,
            string listPriceUsd,
            string metaDescription,
            string mfgSource,
            string msrp,
            string msrpCad,
            string msrpMxn,
            string productFormat,
            string productGroup,
            string productLine,
            string productQty,
            string pricingGroup,
            string psStatus,
            string size,
            string tariffCode,
            string udex,
            string weight,
            string width,
            string ecommerceBullet1,
            string ecommerceBullet2,
            string ecommerceBullet3,
            string ecommerceBullet4,
            string ecommerceBullet5,
            string ecommerceComponents,
            string ecommerceCost,
            string ecommerceExternalIdType,
            string ecommerceItemHeight,
            string ecommerceItemLength,
            string ecommerceItemWeight,
            string ecommerceItemWidth,
            string ecommerceModelName,
            string ecommercePackageLength,
            string ecommercePackageHeight,
            string ecommercePackageWeight,
            string ecommercePackageWidth,
            string ecommercePageQty,
            string ecommerceProductCategory,
            string ecommerceProductDescription,
            string ecommerceProductSubcategory,
            string ecommerceManufacturerName,
            string ecommerceMsrp,
            string ecommerceSize)
        {
            this.TemplateId = templateId;
            this.AccountingGroup = accountingGroup;
            this.CasepackHeight = casepackHeight;
            this.CasepackLength = casepackLength;
            this.CasepackQty = casepackQty;
            this.CasepackWidth = casepackWidth;
            this.CasepackWeight = casepackWeight;
            this.Category = category;
            this.Category2 = category2;
            this.Category3 = category3;
            this.Copyright = copyright;
            this.CostProfileGroup = costProfileGroup;
            this.DefaultActualCostCad = defaultActualCostCad;
            this.DefaultActualCostUsd = defaultActualCostUsd;
            this.Duty = duty;
            this.Gpc = gpc;
            this.Height = height;
            this.InnerpackHeight = innerpackHeight;
            this.InnerpackLength = innerpackLength;
            this.InnerpackQuantity = innerpackQuantity;
            this.InnerpackWeight = innerpackWeight;
            this.InnerpackWidth = innerpackWidth;
            this.ItemCategory = itemCategory;
            this.ItemFamily = itemFamily;
            this.ItemGroup = itemGroup;
            this.Length = length;
            this.ListPriceCad = listPriceCad;
            this.ListPriceMxn = listPriceMxn;
            this.ListPriceUsd = listPriceUsd;
            this.MetaDescription = metaDescription;
            this.MfgSource = mfgSource;
            this.Msrp = msrp;
            this.MsrpCad = msrpCad;
            this.MsrpMxn = msrpMxn;
            this.ProductGroup = productGroup;
            this.ProductLine = productLine;
            this.ProductFormat = productFormat;
            this.ProductQty = productQty;
            this.PricingGroup = pricingGroup;
            this.PsStatus = psStatus;
            this.Size = size;
            this.TariffCode = tariffCode;
            this.Udex = udex;
            this.Weight = weight;
            this.Width = width;
            this.EcommerceBullet1 = ecommerceBullet1;
            this.EcommerceBullet2 = ecommerceBullet2;
            this.EcommerceBullet3 = ecommerceBullet3;
            this.EcommerceBullet4 = ecommerceBullet4;
            this.EcommerceBullet5 = ecommerceBullet5;
            this.EcommerceComponents = ecommerceComponents;
            this.EcommerceCost = ecommerceCost;
            this.EcommerceExternalIdType = ecommerceExternalIdType;
            this.EcommerceItemHeight = ecommerceItemHeight;
            this.EcommerceItemLength = ecommerceItemLength;
            this.EcommerceItemWeight = ecommerceItemWeight;
            this.EcommerceItemWidth = ecommerceItemWidth;
            this.EcommerceModelName = ecommerceModelName;
            this.EcommercePackageLength = ecommercePackageLength;
            this.EcommercePackageHeight = ecommercePackageHeight;
            this.EcommercePackageWeight = ecommercePackageWeight;
            this.EcommercePackageWidth = ecommercePackageWidth;
            this.EcommercePageQty = ecommercePageQty;
            this.EcommerceProductCategory = ecommerceProductCategory;
            this.EcommerceProductDescription = ecommerceProductDescription;
            this.EcommerceProductSubcategory = ecommerceProductSubcategory;
            this.EcommerceManufacturerName = ecommerceManufacturerName;
            this.EcommerceMsrp = ecommerceMsrp;
            this.EcommerceSize = ecommerceSize;
        }

        #endregion // Constructor
    
    }
}
