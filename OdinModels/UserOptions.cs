using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OdinModels
{
    public static class UserOptions
    {
        #region Public Properties

        #region MainWindowHeader Visibility Properties

        #region Ecommerce Visibility Properties

        public static bool EcommerceAsinVisibility
        {
            get
            {
                return _EcommerceasinVisibility;
            }
            set
            {
                _EcommerceasinVisibility = value;
            }
        }
        private static bool _EcommerceasinVisibility = true;

        public static bool EcommerceBullet1Visibility
        {
            get
            {
                return _Ecommercebullet1Visibility;
            }
            set
            {
                _Ecommercebullet1Visibility = value;
            }
        }
        private static bool _Ecommercebullet1Visibility = true;

        public static bool EcommerceBullet2Visibility
        {
            get
            {
                return _Ecommercebullet2Visibility;
            }
            set
            {
                _Ecommercebullet2Visibility = value;
            }
        }
        private static bool _Ecommercebullet2Visibility = true;

        public static bool EcommerceBullet3Visibility
        {
            get
            {
                return _Ecommercebullet3Visibility;
            }
            set
            {
                _Ecommercebullet3Visibility = value;               
            }
        }
        private static bool _Ecommercebullet3Visibility = true;

        public static bool EcommerceBullet4Visibility
        {
            get
            {
                return _Ecommercebullet4Visibility;
            }
            set
            {
                _Ecommercebullet4Visibility = value;
            }
        }
        private static bool _Ecommercebullet4Visibility = true;

        public static bool EcommerceBullet5Visibility
        {
            get
            {
                return _Ecommercebullet5Visibility;
            }
            set
            {
                _Ecommercebullet5Visibility = value;
            }
        }
        private static bool _Ecommercebullet5Visibility = true;

        public static bool EcommerceComponentsVisibility
        {
            get
            {
                return _EcommercecomponentsVisibility;
            }
            set
            {
                _EcommercecomponentsVisibility = value;
            }
        }
        private static bool _EcommercecomponentsVisibility = true;

        public static bool EcommerceCostVisibility
        {
            get
            {
                return _EcommercecostVisibility;
            }
            set
            {
                _EcommercecostVisibility = value;
            }
        }
        private static bool _EcommercecostVisibility = true;

        public static bool EcommerceCountryofOriginVisibility
        {
            get
            {
                return _EcommercecountryofOriginVisibility;
            }
            set
            {
                _EcommercecountryofOriginVisibility = value;
            }
        }
        private static bool _EcommercecountryofOriginVisibility = true;

        public static bool EcommerceExternalIdVisibility
        {
            get
            {
                return _EcommerceexternalIDVisibility;
            }
            set
            {
                _EcommerceexternalIDVisibility = value;
            }
        }
        private static bool _EcommerceexternalIDVisibility = true;

        public static bool EcommerceExternalIdTypeVisibility
        {
            get
            {
                return _EcommerceexternalIdTypeVisibility;
            }
            set
            {
                _EcommerceexternalIdTypeVisibility = value;
            }
        }
        private static bool _EcommerceexternalIdTypeVisibility = true;
        
        public static bool EcommerceItemAliasVisibility
        {
            get
            {
                return _EcommerceitemAliasVisibility;
            }
            set
            {
                _EcommerceitemAliasVisibility = value;
            }
        }
        private static bool _EcommerceitemAliasVisibility = true;

        public static bool EcommerceItemHeightVisibility
        {
            get
            {
                return _EcommerceitemHeightVisibility;
            }
            set
            {
                _EcommerceitemHeightVisibility = value;
            }
        }
        private static bool _EcommerceitemHeightVisibility = true;

        public static bool EcommerceItemLengthVisibility
        {
            get
            {
                return _EcommerceitemLengthVisibility;
            }
            set
            {
                _EcommerceitemLengthVisibility = value;
            }
        }
        private static bool _EcommerceitemLengthVisibility = true;

        public static bool EcommerceItemNameVisibility
        {
            get
            {
                return _EcommerceitemNameVisibility;
            }
            set
            {
                _EcommerceitemNameVisibility = value;
            }
        }
        private static bool _EcommerceitemNameVisibility = true;

        public static bool EcommerceItemTypeKeywordsVisibility
        {
            get
            {
                return _ecommerceItemTypeKeywordsVisibility;
            }
            set
            {
                _ecommerceItemTypeKeywordsVisibility = value;
            }
        }
        private static bool _ecommerceItemTypeKeywordsVisibility = true;

        public static bool EcommerceItemWeightVisibility
        {
            get
            {
                return _EcommerceitemWeightVisibility;
            }
            set
            {
                _EcommerceitemWeightVisibility = value;
            }
        }
        private static bool _EcommerceitemWeightVisibility = true;

        public static bool EcommerceItemWidthVisibility
        {
            get
            {
                return _EcommerceitemWidthVisibility;
            }
            set
            {
                _EcommerceitemWidthVisibility = value;
            }
        }
        private static bool _EcommerceitemWidthVisibility = true;

        public static bool EcommerceModelNameVisibility
        {
            get
            {
                return _EcommercemodelNameVisibility;
            }
            set
            {
                _EcommercemodelNameVisibility = value;
            }
        }
        private static bool _EcommercemodelNameVisibility = true;

        public static bool EcommercePackageHeightVisibility
        {
            get
            {
                return _EcommercepackageHeightVisibility;
            }
            set
            {
                _EcommercepackageHeightVisibility = value;
            }
        }
        private static bool _EcommercepackageHeightVisibility = true;

        public static bool EcommercePackageLengthVisibility
        {
            get
            {
                return _EcommercepackageLengthVisibility;
            }
            set
            {
                _EcommercepackageLengthVisibility = value;
            }
        }
        private static bool _EcommercepackageLengthVisibility = true;

        public static bool EcommercePackageWeightVisibility
        {
            get
            {
                return _EcommercepackageWeightVisibility;
            }
            set
            {
                _EcommercepackageWeightVisibility = value;
            }
        }
        private static bool _EcommercepackageWeightVisibility = true;

        public static bool EcommercePackageWidthVisibility
        {
            get
            {
                return _EcommercepackageWidthVisibility;
            }
            set
            {
                _EcommercepackageWidthVisibility = value;
            }
        }
        private static bool _EcommercepackageWidthVisibility = true;

        public static bool EcommercePageQtyVisibility
        {
            get
            {
                return _EcommercepageQtyVisibility;
            }
            set
            {
                _EcommercepageQtyVisibility = value;
            }
        }
        private static bool _EcommercepageQtyVisibility = true;

        public static bool EcommerceParentAsinVisibility
        {
            get
            {
                return _ecommerceParentAsinVisibility;
            }
            set
            {
                _ecommerceParentAsinVisibility = value;
            }
        }
        private static bool _ecommerceParentAsinVisibility = true;

        public static bool EcommerceProductCategoryVisibility
        {
            get
            {
                return _EcommerceproductCategoryVisibility;
            }
            set
            {
                _EcommerceproductCategoryVisibility = value;
            }
        }
        private static bool _EcommerceproductCategoryVisibility = true;

        public static bool EcommerceProductDescriptionVisibility
        {
            get
            {
                return _EcommerceproductDescriptionVisibility;
            }
            set
            {
                _EcommerceproductDescriptionVisibility = value;
            }
        }
        private static bool _EcommerceproductDescriptionVisibility = true;

        public static bool EcommerceProductSubcategoryVisibility
        {
            get
            {
                return _EcommerceproductSubcategoryVisibility;
            }
            set
            {
                _EcommerceproductSubcategoryVisibility = value;
            }
        }
        private static bool _EcommerceproductSubcategoryVisibility = true;

        public static bool EcommerceManufacturerNameVisibility
        {
            get
            {
                return _EcommercemanufacturerNameVisibility;
            }
            set
            {
                _EcommercemanufacturerNameVisibility = value;
            }
        }
        private static bool _EcommercemanufacturerNameVisibility = true;

        public static bool EcommerceMsrpVisibility
        {
            get
            {
                return _EcommercemsrpVisibility;
            }
            set
            {
                _EcommercemsrpVisibility = value;
            }
        }
        private static bool _EcommercemsrpVisibility = true;

        public static bool EcommerceSearchTermsVisibility
        {
            get
            {
                return _EcommercesearchTermsVisibility;
            }
            set
            {
                _EcommercesearchTermsVisibility = value;
            }
        }
        private static bool _EcommercesearchTermsVisibility = true;

        public static bool EcommerceSizeVisibility
        {
            get
            {
                return _EcommercesizeVisibility;
            }
            set
            {
                _EcommercesizeVisibility = value;
            }
        }
        private static bool _EcommercesizeVisibility = true;

        public static bool EcommerceUpcVisibility
        {
            get
            {
                return _EcommerceupcVisibility;
            }
            set
            {
                _EcommerceupcVisibility = value;
            }
        }
        private static bool _EcommerceupcVisibility = true;

        #endregion // Ecommerce Visibility Properties

        #region B2B Visibility Properties

        /// <summary>
        ///     Gets or sets the Category
        /// </summary>
        public static bool CategoryVisibility
        {
            get
            {
                return _categoryVisibility;
            }
            set
            {
                _categoryVisibility = value;
            }
        }
        private static bool _categoryVisibility = true;

        /// <summary>
        ///     Gets or sets the Category2
        /// </summary>
        public static bool Category2Visibility
        {
            get
            {
                return _category2Visibility;
            }
            set
            {
                _category2Visibility = value;
            }
        }
        private static bool _category2Visibility = true;

        /// <summary>
        ///     Gets or sets the Category3
        /// </summary>
        public static bool Category3Visibility
        {
            get
            {
                return _category3Visibility;
            }
            set
            {
                _category3Visibility = value;
            }
        }
        private static bool _category3Visibility = true;

        /// <summary>
        ///     Gets or sets the Copyright
        /// </summary>
        public static bool CopyrightVisibility
        {
            get
            {
                return _copyrightVisibility;
            }
            set
            {
                _copyrightVisibility = value;
            }
        }
        private static bool _copyrightVisibility = true;

        /// <summary>
        ///     Gets or sets the Genre1
        /// </summary>
        public static bool Genre1Visibility
        {
            get
            {
                return _genre1Visibility;
            }
            set
            {
                _genre1Visibility = value;
            }
        }
        private static bool _genre1Visibility = true;

        /// <summary>
        ///     Gets or sets the Genre2
        /// </summary>
        public static bool Genre2Visibility
        {
            get
            {
                return _genre2Visibility;
            }
            set
            {
                _genre2Visibility = value;
            }
        }
        private static bool _genre2Visibility = true;

        /// <summary>
        ///     Gets or sets the Genre3
        /// </summary>
        public static bool Genre3Visibility
        {
            get
            {
                return _genre3Visibility;
            }
            set
            {
                _genre3Visibility = value;
            }
        }
        private static bool _genre3Visibility = true;

        /// <summary>
        ///     Gets or sets the InStockDate
        /// </summary>
        public static bool InStockDateVisibility
        {
            get
            {
                return _inStockDateVisibility;
            }
            set
            {
                _inStockDateVisibility = value;
            }
        }
        private static bool _inStockDateVisibility = true;

        /// <summary>
        ///     Gets or sets the Item Keywords Override visibility
        /// </summary>
        public static bool ItemKeywordsOverrideVisibility
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets or sets the ItemKeywords
        /// </summary>
        public static bool ItemKeywordsVisibility
        {
            get
            {
                return _itemKeywordsVisibility;
            }
            set
            {
                _itemKeywordsVisibility = value;
            }
        }
        private static bool _itemKeywordsVisibility = true;

        /// <summary>
        ///     Gets or sets the License
        /// </summary>
        public static bool LicenseVisibility
        {
            get
            {
                return _licenseVisibility;
            }
            set
            {
                _licenseVisibility = value;
            }
        }
        private static bool _licenseVisibility = true;

        /// <summary>
        ///     Gets or sets the LicenseBeginDate
        /// </summary>
        public static bool LicenseBeginDateVisibility
        {
            get
            {
                return _licenseBeginDateVisibility;
            }
            set
            {
                _licenseBeginDateVisibility = value;
            }
        }
        private static bool _licenseBeginDateVisibility = true;

        /// <summary>
        ///     Gets or sets the MetaDescription
        /// </summary>
        public static bool MetaDescriptionVisibility
        {
            get
            {
                return _metaDescriptionVisibility;
            }
            set
            {
                _metaDescriptionVisibility = value;
            }
        }
        private static bool _metaDescriptionVisibility = true;
           
        /// <summary>
        ///     Gets or sets the property
        /// </summary>
        public static bool PropertyVisibility
        {
            get
            {
                return _propertyVisibility;
            }
            set
            {
                _propertyVisibility = value;
            }
        }
        private static bool _propertyVisibility = true;

        /// <summary>
        ///     Gets or sets the ShortDescription
        /// </summary>
        public static bool ShortDescriptionVisibility
        {
            get
            {
                return _shortDescriptionVisibility;
            }
            set
            {
                _shortDescriptionVisibility = value;
            }
        }
        private static bool _shortDescriptionVisibility = true;

        /// <summary>
        ///     Gets or sets the Size
        /// </summary>
        public static bool SizeVisibility
        {
            get
            {
                return _sizeVisibility;
            }
            set
            {
                _sizeVisibility = value;
            }
        }
        private static bool _sizeVisibility = true;

        /// <summary>
        ///     Gets or sets the Title
        /// </summary>
        public static bool TitleVisibility
        {
            get
            {
                return _titleVisibility;
            }
            set
            {
                _titleVisibility = value;
            }
        }
        private static bool _titleVisibility = true;
        
        /// <summary>
        ///     Gets or sets the Title Override visibility
        /// </summary>
        public static bool TitleOverrideVisibility
        {
            get;
            set;
        }

        #endregion // B2B Visibility Properties

        #region Peoplesoft Visibility Properties

        public static bool AccountingGroupVisibility
        {
            get
            {
                return _accountingGroupVisibility;
            }
            set
            {
                _accountingGroupVisibility = value;
            }
        }
        private static bool _accountingGroupVisibility = true;

        public static bool BillOfMaterialsVisibility
        {
            get
            {
                return _billOfMaterialsVisibility;
            }
            set
            {
                _billOfMaterialsVisibility = value;
            }
        }
        private static bool _billOfMaterialsVisibility = true;
        
        public static bool CasepackHeightVisibility
        {
            get
            {
                return _casepackHeightVisibility;
            }
            set
            {
                _casepackHeightVisibility = value;
            }
        }
        private static bool _casepackHeightVisibility = true;

        public static bool CasepackLengthVisibility
        {
            get
            {
                return _casepackLengthVisibility;
            }
            set
            {
                _casepackLengthVisibility = value;
            }
        }
        private static bool _casepackLengthVisibility = true;

        public static bool CasepackQtyVisibility
        {
            get
            {
                return _casepackQtyVisibility;
            }
            set
            {
                _casepackQtyVisibility = value;
            }
        }
        private static bool _casepackQtyVisibility = true;

        public static bool CasepackUpcVisibility
        {
            get
            {
                return _casepackUpcVisibility;
            }
            set
            {
                _casepackUpcVisibility = value;
            }
        }
        private static bool _casepackUpcVisibility = true;

        public static bool CasepackWidthVisibility
        {
            get
            {
                return _casepackWidthVisibility;
            }
            set
            {
                _casepackWidthVisibility = value;
            }
        }
        private static bool _casepackWidthVisibility = true;

        public static bool CasepackWeightVisibility
        {
            get
            {
                return _casepackWeightVisibility;
            }
            set
            {
                _casepackWeightVisibility = value;
            }
        }
        private static bool _casepackWeightVisibility = true;

        public static bool ColorVisibility
        {
            get
            {
                return _colorVisibility;
            }
            set
            {
                _colorVisibility = value;
            }
        }
        private static bool _colorVisibility = true;

        public static bool CountryOfOriginVisibility
        {
            get
            {
                return _countryOfOriginVisibility;
            }
            set
            {
                _countryOfOriginVisibility = value;
            }
        }
        private static bool _countryOfOriginVisibility = true;

        public static bool CostProfileGroupVisibility
        {
            get
            {
                return _costProfileGroupVisibility;
            }
            set
            {
                _costProfileGroupVisibility = value;
            }
        }
        private static bool _costProfileGroupVisibility = true;

        public static bool DefaultActualCostCadVisibility
        {
            get
            {
                return _defaultActualCostCadVisibility;
            }
            set
            {
                _defaultActualCostCadVisibility = value;
            }
        }
        private static bool _defaultActualCostCadVisibility = true;

        public static bool DefaultActualCostUsdVisibility
        {
            get
            {
                return _defaultActualCostUsdVisibility;
            }
            set
            {
                _defaultActualCostUsdVisibility = value;
            }
        }
        private static bool _defaultActualCostUsdVisibility = true;

        public static bool DescriptionVisibility
        {
            get
            {
                return _descriptionVisibility;
            }
            set
            {
                _descriptionVisibility = value;
            }
        }
        private static bool _descriptionVisibility = true;

        public static bool DirectImportVisibility
        {
            get
            {
                return _directImportVisibility;
            }
            set
            {
                _directImportVisibility = value;
            }
        }
        private static bool _directImportVisibility = true;

        public static bool DtcPriceVisibility
        {
            get
            {
                return _dtcPriceVisibility;
            }
            set
            {
                _dtcPriceVisibility = value;
            }
        }
        private static bool _dtcPriceVisibility = true;

        public static bool DutyVisibility
        {
            get
            {
                return _dutyVisibility;
            }
            set
            {
                _dutyVisibility = value;
            }
        }
        private static bool _dutyVisibility = true;

        public static bool EanVisibility
        {
            get
            {
                return _eanVisibility;
            }
            set
            {
                _eanVisibility = value;
            }
        }
        private static bool _eanVisibility = true;

        public static bool ExclusiveVisibility
        {
            get
            {
                return _exclusiveVisibility;
            }
            set
            {
                _exclusiveVisibility = value;
            }
        }
        private static bool _exclusiveVisibility = true;

        public static bool GpcVisibility
        {
            get
            {
                return _gpcVisibility;
            }
            set
            {
                _gpcVisibility = value;
            }
        }
        private static bool _gpcVisibility = true;

        public static bool HeightVisibility
        {
            get
            {
                return _heightVisibility;
            }
            set
            {
                _heightVisibility = value;
            }
        }
        private static bool _heightVisibility = true;

        public static bool InnerpackHeightVisibility
        {
            get
            {
                return _innerpackHeightVisibility;
            }
            set
            {
                _innerpackHeightVisibility = value;
            }
        }
        private static bool _innerpackHeightVisibility = true;

        public static bool InnerpackLengthVisibility
        {
            get
            {
                return _innerpackLengthVisibility;
            }
            set
            {
                _innerpackLengthVisibility = value;
            }
        }
        private static bool _innerpackLengthVisibility = true;

        public static bool InnerpackQuantityVisibility
        {
            get
            {
                return _innerpackQuantityVisibility;
            }
            set
            {
                _innerpackQuantityVisibility = value;
            }
        }
        private static bool _innerpackQuantityVisibility = true;
        
        public static bool InnerpackUpcVisibility
        {
            get
            {
                return _innerpackUpcVisibility;
            }
            set
            {
                _innerpackUpcVisibility = value;
            }
        }
        private static bool _innerpackUpcVisibility = true;

        public static bool InnerpackWidthVisibility
        {
            get
            {
                return _innerpackWidthVisibility;
            }
            set
            {
                _innerpackWidthVisibility = value;
            }
        }
        private static bool _innerpackWidthVisibility = true;

        public static bool InnerpackWeightVisibility
        {
            get
            {
                return _innerpackWeightVisibility;
            }
            set
            {
                _innerpackWeightVisibility = value;
            }
        }
        private static bool _innerpackWeightVisibility = true;

        public static bool IsbnVisibility
        {
            get
            {
                return _isbnVisibility;
            }
            set
            {
                _isbnVisibility = value;
            }
        }
        private static bool _isbnVisibility = true;

        public static bool ItemCategoryVisibility
        {
            get
            {
                return _itemCategoryVisibility;
            }
            set
            {
                _itemCategoryVisibility = value;
            }
        }
        private static bool _itemCategoryVisibility = true;

        public static bool ItemFamilyVisibility
        {
            get
            {
                return _itemFamilyVisibility;
            }
            set
            {
                _itemFamilyVisibility = value;
            }
        }
        private static bool _itemFamilyVisibility = true;

        public static bool ItemGroupVisibility
        {
            get
            {
                return _itemGroupVisibility;
            }
            set
            {
                _itemGroupVisibility = value;
            }
        }
        private static bool _itemGroupVisibility = true;        

        public static bool LanguageVisibility
        {
            get
            {
                return _languageVisibility;
            }
            set
            {
                _languageVisibility = value;
            }
        }
        private static bool _languageVisibility = true;

        public static bool LengthVisibility
        {
            get
            {
                return _lengthVisibility;
            }
            set
            {
                _lengthVisibility = value;
            }
        }
        private static bool _lengthVisibility = true;

        public static bool ListPriceCadVisibility
        {
            get
            {
                return _listPriceCadVisibility;
            }
            set
            {
                _listPriceCadVisibility = value;
            }
        }
        private static bool _listPriceCadVisibility = true;

        public static bool ListPriceMxnVisibility
        {
            get
            {
                return _listPriceMxnVisibility;
            }
            set
            {
                _listPriceMxnVisibility = value;
            }
        }
        private static bool _listPriceMxnVisibility = true;

        public static bool ListPriceUsdVisibility
        {
            get
            {
                return _listPriceUsdVisibility;
            }
            set
            {
                _listPriceUsdVisibility = value;
            }
        }
        private static bool _listPriceUsdVisibility = true;

        public static bool MfgSourceVisibility
        {
            get
            {
                return _mfgSourceVisibility;
            }
            set
            {
                _mfgSourceVisibility = value;
            }
        }
        private static bool _mfgSourceVisibility = true;

        public static bool MsrpVisibility
        {
            get
            {
                return _msrpVisibility;
            }
            set
            {
                _msrpVisibility = value;
            }
        }
        private static bool _msrpVisibility = true;

        public static bool MsrpCadVisibility
        {
            get
            {
                return _msrpCadVisibility;
            }
            set
            {
                _msrpCadVisibility = value;
            }
        }
        private static bool _msrpCadVisibility = true;

        public static bool MsrpMxnVisibility
        {
            get
            {
                return _msrpMxnVisibility;
            }
            set
            {
                _msrpMxnVisibility = value;
            }
        }
        private static bool _msrpMxnVisibility = true;

        public static bool OrientationVisibility
        {
            get
            {
                return _orientationVisibility;
            }
            set
            {
                _orientationVisibility = value;
            }
        }
        private static bool _orientationVisibility = true;

        public static bool PricingGroupVisibility
        {
            get
            {
                return _pricingGroupVisibility;
            }
            set
            {
                _pricingGroupVisibility = value;
            }
        }
        private static bool _pricingGroupVisibility = true;

        public static bool PrintOnDemandVisibility
        {
            get
            {
                return _printOnDemandVisibility;
            }
            set
            {
                _printOnDemandVisibility = value;
            }
        }
        private static bool _printOnDemandVisibility = true;

        public static bool ProductFormatVisibility
        {
            get
            {
                return _productFormatVisibility;
            }
            set
            {
                _productFormatVisibility = value;
            }
        }
        private static bool _productFormatVisibility = true;

        public static bool ProductGroupVisibility
        {
            get
            {
                return _productGroupVisibility;
            }
            set
            {
                _productGroupVisibility = value;
            }
        }
        private static bool _productGroupVisibility = true;

        public static bool ProductIdTranslationVisibility
        {
            get
            {
                return _productIdTranslationVisibility;
            }
            set
            {
                _productIdTranslationVisibility = value;
            }
        }
        private static bool _productIdTranslationVisibility = true;

        public static bool ProductLineVisibility
        {
            get
            {
                return _productLineVisibility;
            }
            set
            {
                _productLineVisibility = value;
            }
        }
        private static bool _productLineVisibility = true;

        public static bool ProductQtyVisibility
        {
            get
            {
                return _productQtyVisibility;
            }
            set
            {
                _productQtyVisibility = value;
            }
        }
        private static bool _productQtyVisibility = true;

        public static bool PsStatusVisibility
        {
            get
            {
                return _psStatusVisibility;
            }
            set
            {
                _psStatusVisibility = value;
            }
        }
        private static bool _psStatusVisibility = true;

        public static bool SatCodeVisibility
        {
            get
            {
                return _satCodeVisibility;
            }
            set
            {
                _satCodeVisibility = value;
            }
        }
        private static bool _satCodeVisibility = true;        
        
        public static bool StandardCostVisibility
        {
            get
            {
                return _standardCostVisibility;
            }
            set
            {
                _standardCostVisibility = value;
            }
        }
        private static bool _standardCostVisibility = true;

        public static bool StatsCodeVisibility
        {
            get
            {
                return _statsCodeVisibility;
            }
            set
            {
                _statsCodeVisibility = value;
            }
        }
        private static bool _statsCodeVisibility = true;

        public static bool TariffCodeVisibility
        {
            get
            {
                return _tariffCodeVisibility;
            }
            set
            {
                _tariffCodeVisibility = value;
            }
        }
        private static bool _tariffCodeVisibility = true;

        public static bool TerritoryVisibility
        {
            get
            {
                return _territoryVisibility;
            }
            set
            {
                _territoryVisibility = value;
            }
        }
        private static bool _territoryVisibility = true;

        public static bool UdexVisibility
        {
            get
            {
                return _udexVisibility;
            }
            set
            {
                _udexVisibility = value;
            }
        }
        private static bool _udexVisibility = true;

        public static bool UpcVisibility
        {
            get
            {
                return _upcVisibility;
            }
            set
            {
                _upcVisibility = value;
            }
        }
        private static bool _upcVisibility = true;

        public static bool WarrantyVisibility
        {
            get
            {
                return _warrantyVisibility;
            }
            set
            {
                _warrantyVisibility = value;
            }
        }
        private static bool _warrantyVisibility = true;

        public static bool WarrantyCheckVisibility
        {
            get
            {
                return _warrantyCheckVisibility;
            }
            set
            {
                _warrantyCheckVisibility = value;
            }
        }
        private static bool _warrantyCheckVisibility = true;

        public static bool WebsitePriceOverrideVisibility
        {
            get;
            set;
        }

        public static bool WebsitePriceVisibility
        {
            get
            {
                return _websitePriceVisibility;
            }
            set
            {
                _websitePriceVisibility = value;
            }
        }
        private static bool _websitePriceVisibility = true;

        public static bool WeightVisibility
        {
            get
            {
                return _weightVisibility;
            }
            set
            {
                _weightVisibility = value;
            }
        }
        private static bool _weightVisibility = true;

        public static bool WidthVisibility
        {
            get
            {
                return _widthVisibility;
            }
            set
            {
                _widthVisibility = value;
            }
        }
        private static bool _widthVisibility = true;

        #endregion // Peoplesoft Visibility Properties        

        #region Sell On Visibility Properties

        /// <summary>
        ///     Gets or sets SellOnAllPostersVisibility
        /// </summary>
        public static bool SellOnAllPostersVisibility
        {
            get
            {
                return _sellOnAllPostersVisibility;
            }
            set
            {
                _sellOnAllPostersVisibility = value;
            }
        }
        private static bool _sellOnAllPostersVisibility = true;

        /// <summary>
        ///     Gets or sets SellOnAllPostersVisibility
        /// </summary>
        public static bool SellOnAmazonVisibility
        {
            get
            {
                return _sellOnAmazonVisibility;
            }
            set
            {
                _sellOnAmazonVisibility = value;
            }
        }
        private static bool _sellOnAmazonVisibility = true;

        /// <summary>
        ///     Gets or sets SellOnAmazonSellerCentralVisibility
        /// </summary>
        public static bool SellOnAmazonSellerCentralVisibility
        {
            get
            {
                return _sellOnAmazonSellerCentralVisibility;
            }
            set
            {
                _sellOnAmazonSellerCentralVisibility = value;
            }
        }
        private static bool _sellOnAmazonSellerCentralVisibility = true;

        /// <summary>
        ///     Gets or sets SellOnEcommerceVisibility
        /// </summary>
        public static bool SellOnEcommerceVisibility
        {
            get
            {
                return _sellOnEcommerceVisibility;
            }
            set
            {
                _sellOnEcommerceVisibility = value;
            }
        }
        private static bool _sellOnEcommerceVisibility = true;

        /// <summary>
        ///     Gets or sets SellOnFanaticsVisibility
        /// </summary>
        public static bool SellOnFanaticsVisibility
        {
            get
            {
                return _sellOnFanaticsVisibility;
            }
            set
            {
                _sellOnFanaticsVisibility = value;
            }
        }
        private static bool _sellOnFanaticsVisibility = true;

        /// <summary>
        ///     Gets or sets SellOnGuitarCenterVisibility
        /// </summary>
        public static bool SellOnGuitarCenterVisibility
        {
            get
            {
                return _sellOnGuitarCenterVisibility;
            }
            set
            {
                _sellOnGuitarCenterVisibility = value;
            }
        }
        private static bool _sellOnGuitarCenterVisibility = true;

        /// <summary>
        ///     Gets or sets SellOnHayneedleVisibility
        /// </summary>
        public static bool SellOnHayneedleVisibility
        {
            get
            {
                return _sellOnHayneedleVisibility;
            }
            set
            {
                _sellOnHayneedleVisibility = value;
            }
        }
        private static bool _sellOnHayneedleVisibility = true;

        /// <summary>
        ///     Gets or sets SellOnHouzzVisibility
        /// </summary>
        public static bool SellOnHouzzVisibility
        {
            get
            {
                return _sellOnHouzzVisibility;
            }
            set
            {
                _sellOnHouzzVisibility = value;
            }
        }
        private static bool _sellOnHouzzVisibility = true;

        /// <summary>
        ///     Gets or sets SellOnTargetVisibility
        /// </summary>
        public static bool SellOnTargetVisibility
        {
            get
            {
                return _sellOnTargetVisibility;
            }
            set
            {
                _sellOnTargetVisibility = value;
            }
        }
        private static bool _sellOnTargetVisibility = true;

        /// <summary>
        ///     Gets or sets SellOnTrendsVisibility
        /// </summary>
        public static bool SellOnTrendsVisibility
        {
            get
            {
                return _sellOnTrendsVisibility;
            }
            set
            {
                _sellOnTrendsVisibility = value;
            }
        }
        private static bool _sellOnTrendsVisibility = true;

        /// <summary>
        ///     Gets or sets SellOnTrsVisibility
        /// </summary>
        public static bool SellOnTrsVisibility
        {
            get
            {
                return _sellOnTrsVisibility;
            }
            set
            {
                _sellOnTrsVisibility = value;
            }
        }
        private static bool _sellOnTrsVisibility = true;

        /// <summary>
        ///     Gets or sets SellOnWalmartVisibility
        /// </summary>
        public static bool SellOnWalmartVisibility
        {
            get
            {
                return _sellOnWalmartVisibility;
            }
            set
            {
                _sellOnWalmartVisibility = value;
            }
        }
        private static bool _sellOnWalmartVisibility = true;

        /// <summary>
        ///     Gets or sets SellOnWayfairVisibility
        /// </summary>
        public static bool SellOnWayfairVisibility
        {
            get
            {
                return _sellOnWayfairVisibility;
            }
            set
            {
                _sellOnWayfairVisibility = value;
            }
        }
        private static bool _sellOnWayfairVisibility = true;
        
        #endregion // Sell On Visibility Properties

        #region Image Visibility Properties

        public static bool ImagePath1Visibility
        {
            get
            {
                return _imagePath1Visibility;
            }
            set
            {
                _imagePath1Visibility = value;
            }
        }
        private static bool _imagePath1Visibility = true;

        public static bool ImagePath2Visibility
        {
            get
            {
                return _imagePath2Visibility;
            }
            set
            {
                _imagePath2Visibility = value;
            }
        }
        private static bool _imagePath2Visibility = true;

        public static bool ImagePath3Visibility
        {
            get
            {
                return _imagePath3Visibility;
            }
            set
            {
                _imagePath3Visibility = value;
            }
        }
        private static bool _imagePath3Visibility = true;

        public static bool ImagePath4Visibility
        {
            get
            {
                return _imagePath4Visibility;
            }
            set
            {
                _imagePath4Visibility = value;
            }
        }
        private static bool _imagePath4Visibility = true;

        public static bool ImagePath5Visibility
        {
            get
            {
                return _imagePath5Visibility;
            }
            set
            {
                _imagePath5Visibility = value;
            }
        }
        private static bool _imagePath5Visibility = true;
        #endregion // Image Visibility Properties

        #endregion // MainWindowHeader Visibility Properties

        #endregion // Public Properties

    }
}
