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

        public static bool Ecommerce_AsinVisibility
        {
            get
            {
                return _ecommerce_asinVisibility;
            }
            set
            {
                _ecommerce_asinVisibility = value;
            }
        }
        private static bool _ecommerce_asinVisibility = true;

        public static bool Ecommerce_Bullet1Visibility
        {
            get
            {
                return _ecommerce_bullet1Visibility;
            }
            set
            {
                _ecommerce_bullet1Visibility = value;
            }
        }
        private static bool _ecommerce_bullet1Visibility = true;

        public static bool Ecommerce_Bullet2Visibility
        {
            get
            {
                return _ecommerce_bullet2Visibility;
            }
            set
            {
                _ecommerce_bullet2Visibility = value;
            }
        }
        private static bool _ecommerce_bullet2Visibility = true;

        public static bool Ecommerce_Bullet3Visibility
        {
            get
            {
                return _ecommerce_bullet3Visibility;
            }
            set
            {
                _ecommerce_bullet3Visibility = value;               
            }
        }
        private static bool _ecommerce_bullet3Visibility = true;

        public static bool Ecommerce_Bullet4Visibility
        {
            get
            {
                return _ecommerce_bullet4Visibility;
            }
            set
            {
                _ecommerce_bullet4Visibility = value;
            }
        }
        private static bool _ecommerce_bullet4Visibility = true;

        public static bool Ecommerce_Bullet5Visibility
        {
            get
            {
                return _ecommerce_bullet5Visibility;
            }
            set
            {
                _ecommerce_bullet5Visibility = value;
            }
        }
        private static bool _ecommerce_bullet5Visibility = true;

        public static bool Ecommerce_ComponentsVisibility
        {
            get
            {
                return _ecommerce_componentsVisibility;
            }
            set
            {
                _ecommerce_componentsVisibility = value;
            }
        }
        private static bool _ecommerce_componentsVisibility = true;

        public static bool Ecommerce_CostVisibility
        {
            get
            {
                return _ecommerce_costVisibility;
            }
            set
            {
                _ecommerce_costVisibility = value;
            }
        }
        private static bool _ecommerce_costVisibility = true;

        public static bool Ecommerce_CountryofOriginVisibility
        {
            get
            {
                return _ecommerce_countryofOriginVisibility;
            }
            set
            {
                _ecommerce_countryofOriginVisibility = value;
            }
        }
        private static bool _ecommerce_countryofOriginVisibility = true;

        public static bool Ecommerce_ExternalIdVisibility
        {
            get
            {
                return _ecommerce_externalIDVisibility;
            }
            set
            {
                _ecommerce_externalIDVisibility = value;
            }
        }
        private static bool _ecommerce_externalIDVisibility = true;

        public static bool Ecommerce_ExternalIdTypeVisibility
        {
            get
            {
                return _ecommerce_externalIdTypeVisibility;
            }
            set
            {
                _ecommerce_externalIdTypeVisibility = value;
            }
        }
        private static bool _ecommerce_externalIdTypeVisibility = true;
        
        public static bool Ecommerce_ItemAliasVisibility
        {
            get
            {
                return _ecommerce_itemAliasVisibility;
            }
            set
            {
                _ecommerce_itemAliasVisibility = value;
            }
        }
        private static bool _ecommerce_itemAliasVisibility = true;

        public static bool Ecommerce_ItemHeightVisibility
        {
            get
            {
                return _ecommerce_itemHeightVisibility;
            }
            set
            {
                _ecommerce_itemHeightVisibility = value;
            }
        }
        private static bool _ecommerce_itemHeightVisibility = true;

        public static bool Ecommerce_ItemLengthVisibility
        {
            get
            {
                return _ecommerce_itemLengthVisibility;
            }
            set
            {
                _ecommerce_itemLengthVisibility = value;
            }
        }
        private static bool _ecommerce_itemLengthVisibility = true;

        public static bool Ecommerce_ItemNameVisibility
        {
            get
            {
                return _ecommerce_itemNameVisibility;
            }
            set
            {
                _ecommerce_itemNameVisibility = value;
            }
        }
        private static bool _ecommerce_itemNameVisibility = true;

        public static bool Ecommerce_ItemWeightVisibility
        {
            get
            {
                return _ecommerce_itemWeightVisibility;
            }
            set
            {
                _ecommerce_itemWeightVisibility = value;
            }
        }
        private static bool _ecommerce_itemWeightVisibility = true;

        public static bool Ecommerce_ItemWidthVisibility
        {
            get
            {
                return _ecommerce_itemWidthVisibility;
            }
            set
            {
                _ecommerce_itemWidthVisibility = value;
            }
        }
        private static bool _ecommerce_itemWidthVisibility = true;

        public static bool Ecommerce_ModelNameVisibility
        {
            get
            {
                return _ecommerce_modelNameVisibility;
            }
            set
            {
                _ecommerce_modelNameVisibility = value;
            }
        }
        private static bool _ecommerce_modelNameVisibility = true;

        public static bool Ecommerce_PackageHeightVisibility
        {
            get
            {
                return _ecommerce_packageHeightVisibility;
            }
            set
            {
                _ecommerce_packageHeightVisibility = value;
            }
        }
        private static bool _ecommerce_packageHeightVisibility = true;

        public static bool Ecommerce_PackageLengthVisibility
        {
            get
            {
                return _ecommerce_packageLengthVisibility;
            }
            set
            {
                _ecommerce_packageLengthVisibility = value;
            }
        }
        private static bool _ecommerce_packageLengthVisibility = true;

        public static bool Ecommerce_PackageWeightVisibility
        {
            get
            {
                return _ecommerce_packageWeightVisibility;
            }
            set
            {
                _ecommerce_packageWeightVisibility = value;
            }
        }
        private static bool _ecommerce_packageWeightVisibility = true;

        public static bool Ecommerce_PackageWidthVisibility
        {
            get
            {
                return _ecommerce_packageWidthVisibility;
            }
            set
            {
                _ecommerce_packageWidthVisibility = value;
            }
        }
        private static bool _ecommerce_packageWidthVisibility = true;

        public static bool Ecommerce_PageQtyVisibility
        {
            get
            {
                return _ecommerce_pageQtyVisibility;
            }
            set
            {
                _ecommerce_pageQtyVisibility = value;
            }
        }
        private static bool _ecommerce_pageQtyVisibility = true;

        public static bool Ecommerce_ProductCategoryVisibility
        {
            get
            {
                return _ecommerce_productCategoryVisibility;
            }
            set
            {
                _ecommerce_productCategoryVisibility = value;
            }
        }
        private static bool _ecommerce_productCategoryVisibility = true;

        public static bool Ecommerce_ProductDescriptionVisibility
        {
            get
            {
                return _ecommerce_productDescriptionVisibility;
            }
            set
            {
                _ecommerce_productDescriptionVisibility = value;
            }
        }
        private static bool _ecommerce_productDescriptionVisibility = true;

        public static bool Ecommerce_ProductSubcategoryVisibility
        {
            get
            {
                return _ecommerce_productSubcategoryVisibility;
            }
            set
            {
                _ecommerce_productSubcategoryVisibility = value;
            }
        }
        private static bool _ecommerce_productSubcategoryVisibility = true;

        public static bool Ecommerce_ManufacturerNameVisibility
        {
            get
            {
                return _ecommerce_manufacturerNameVisibility;
            }
            set
            {
                _ecommerce_manufacturerNameVisibility = value;
            }
        }
        private static bool _ecommerce_manufacturerNameVisibility = true;

        public static bool Ecommerce_MsrpVisibility
        {
            get
            {
                return _ecommerce_msrpVisibility;
            }
            set
            {
                _ecommerce_msrpVisibility = value;
            }
        }
        private static bool _ecommerce_msrpVisibility = true;

        public static bool Ecommerce_SearchTermsVisibility
        {
            get
            {
                return _ecommerce_searchTermsVisibility;
            }
            set
            {
                _ecommerce_searchTermsVisibility = value;
            }
        }
        private static bool _ecommerce_searchTermsVisibility = true;

        public static bool Ecommerce_SizeVisibility
        {
            get
            {
                return _ecommerce_sizeVisibility;
            }
            set
            {
                _ecommerce_sizeVisibility = value;
            }
        }
        private static bool _ecommerce_sizeVisibility = true;

        public static bool Ecommerce_UpcVisibility
        {
            get
            {
                return _ecommerce_upcVisibility;
            }
            set
            {
                _ecommerce_upcVisibility = value;
            }
        }
        private static bool _ecommerce_upcVisibility = true;

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

        #region Constructor

        #endregion // Constructor
    }
}
