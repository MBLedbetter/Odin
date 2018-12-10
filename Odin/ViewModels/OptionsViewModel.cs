using Mvvm;
using Odin.Views;
using OdinModels;
using OdinServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Odin.ViewModels
{
    public class OptionsViewModel : ViewModelBase
    {
        #region Commands

        public ICommand AddProductFormatExclusionCommand
        {
            get
            {
                if (_addProductFormatExclusion == null)
                {
                    _addProductFormatExclusion = new RelayCommand(param => AddOption("ProductFormatExclusion"));
                }
                return _addProductFormatExclusion;
            }
        }
        private RelayCommand _addProductFormatExclusion;

        public ICommand RemoveProductFormatExclusionCommand
        {
            get
            {
                if (_removeProductFormatExclusion == null)
                {
                    _removeProductFormatExclusion = new RelayCommand(param => RemoveProductFormatExclusion());
                }
                return _removeProductFormatExclusion;
            }
        }
        private RelayCommand _removeProductFormatExclusion;

        public ICommand AddVariantGroupIdExclusionCommand
        {
            get
            {
                if (_addVariantGroupIdExclusion == null)
                {
                    _addVariantGroupIdExclusion = new RelayCommand(param => AddOption("VariantGroupExclusion"));
                }
                return _addVariantGroupIdExclusion;
            }
        }
        private RelayCommand _addVariantGroupIdExclusion;

        public ICommand RemoveVariantGroupIdExclusionCommand
        {
            get
            {
                if (_removeVariantGroupIdExclusion == null)
                {
                    _removeVariantGroupIdExclusion = new RelayCommand(param => RemoveVariantGroupIdExclusion());
                }
                return _removeVariantGroupIdExclusion;
            }
        }
        private RelayCommand _removeVariantGroupIdExclusion;

        #endregion // Commands

        #region Properties

        private bool InitiateFlag { get; set; }

        #region MainWindowHeader Properties

        #region Ecommerce VisibilityProperties

        public bool EcommerceFieldVisibility
        {
            get
            {
                return _ecommerceFieldVisibility;
            }
            set
            {
                _ecommerceFieldVisibility = value;
                if (!InitiateFlag)
                {
                    OnPropertyChanged("EcommerceFieldVisibility");
                }
                SetEcommerceFieldVisibility(value);
            }
        }
        private bool _ecommerceFieldVisibility = true;

        public bool EcommerceAsinVisibility
        {
            get
            {
                return UserOptions.EcommerceAsinVisibility;
            }
            set
            {
                UserOptions.EcommerceAsinVisibility = value;
                OnPropertyChanged("EcommerceAsinVisibility");
            }
        }

        public bool EcommerceBullet1Visibility
        {
            get
            {
                return UserOptions.EcommerceBullet1Visibility;
            }
            set
            {
                UserOptions.EcommerceBullet1Visibility = value;
                OnPropertyChanged("EcommerceBullet1Visibility");
            }
        }

        public bool EcommerceBullet2Visibility
        {
            get
            {
                return UserOptions.EcommerceBullet2Visibility;
            }
            set
            {
                UserOptions.EcommerceBullet2Visibility = value;
                OnPropertyChanged("EcommerceBullet2Visibility");
            }
        }

        public bool EcommerceBullet3Visibility
        {
            get
            {
                return UserOptions.EcommerceBullet3Visibility;
            }
            set
            {
                UserOptions.EcommerceBullet3Visibility = value;
                OnPropertyChanged("EcommerceBullet3Visibility");
            }
        }

        public bool EcommerceBullet4Visibility
        {
            get
            {
                return UserOptions.EcommerceBullet4Visibility;
            }
            set
            {
                UserOptions.EcommerceBullet4Visibility = value;
                OnPropertyChanged("EcommerceBullet4Visibility");
            }
        }

        public bool EcommerceBullet5Visibility
        {
            get
            {
                return UserOptions.EcommerceBullet5Visibility;
            }
            set
            {
                UserOptions.EcommerceBullet5Visibility = value;
                OnPropertyChanged("EcommerceBullet5Visibility");
            }
        }

        public bool EcommerceComponentsVisibility
        {
            get
            {
                return UserOptions.EcommerceComponentsVisibility;
            }
            set
            {
                UserOptions.EcommerceComponentsVisibility = value;
                OnPropertyChanged("EcommerceComponentsVisibility");
            }
        }

        public bool EcommerceCostVisibility
        {
            get
            {
                return UserOptions.EcommerceCostVisibility;
            }
            set
            {
                UserOptions.EcommerceCostVisibility = value;
                OnPropertyChanged("EcommerceCostVisibility");
            }
        }

        public bool EcommerceCountryofOriginVisibility
        {
            get
            {
                return UserOptions.EcommerceCountryofOriginVisibility;
            }
            set
            {
                UserOptions.EcommerceCountryofOriginVisibility = value;
                OnPropertyChanged("EcommerceCountryofOriginVisibility");
            }
        }

        public bool EcommerceExternalIdVisibility
        {
            get
            {
                return UserOptions.EcommerceExternalIdVisibility;
            }
            set
            {
                UserOptions.EcommerceExternalIdVisibility = value;
                OnPropertyChanged("EcommerceExternalIdVisibility");
            }
        }

        public bool EcommerceExternalIdTypeVisibility
        {
            get
            {
                return UserOptions.EcommerceExternalIdTypeVisibility;
            }
            set
            {
                UserOptions.EcommerceExternalIdTypeVisibility = value;
                OnPropertyChanged("EcommerceExternalIdTypeVisibility");
            }
        }

        public bool EcommerceItemAliasVisibility
        {
            get
            {
                return UserOptions.EcommerceItemAliasVisibility;
            }
            set
            {
                UserOptions.EcommerceItemAliasVisibility = value;
                OnPropertyChanged("EcommerceItemAliasVisibility");
            }
        }

        public bool EcommerceItemHeightVisibility
        {
            get
            {
                return UserOptions.EcommerceItemHeightVisibility;
            }
            set
            {
                UserOptions.EcommerceItemHeightVisibility = value;
                OnPropertyChanged("EcommerceItemHeightVisibility");
            }
        }

        public bool EcommerceItemLengthVisibility
        {
            get
            {
                return UserOptions.EcommerceItemLengthVisibility;
            }
            set
            {
                UserOptions.EcommerceItemLengthVisibility = value;
                OnPropertyChanged("EcommerceItemLengthVisibility");
            }
        }

        public bool EcommerceItemNameVisibility
        {
            get
            {
                return UserOptions.EcommerceItemNameVisibility;
            }
            set
            {
                UserOptions.EcommerceItemNameVisibility = value;
                OnPropertyChanged("EcommerceItemNameVisibility");
            }
        }

        public bool EcommerceItemWeightVisibility
        {
            get
            {
                return UserOptions.EcommerceItemWeightVisibility;
            }
            set
            {
                UserOptions.EcommerceItemWeightVisibility = value;
                OnPropertyChanged("EcommerceItemWeightVisibility");
            }
        }

        public bool EcommerceItemWidthVisibility
        {
            get
            {
                return UserOptions.EcommerceItemWidthVisibility;
            }
            set
            {
                UserOptions.EcommerceItemWidthVisibility = value;
                OnPropertyChanged("EcommerceItemWidthVisibility");
            }
        }

        public bool EcommerceModelNameVisibility
        {
            get
            {
                return UserOptions.EcommerceModelNameVisibility;
            }
            set
            {
                UserOptions.EcommerceModelNameVisibility = value;
                OnPropertyChanged("EcommerceModelNameVisibility");
            }
        }

        public bool EcommercePackageHeightVisibility
        {
            get
            {
                return UserOptions.EcommercePackageHeightVisibility;
            }
            set
            {
                UserOptions.EcommercePackageHeightVisibility = value;
                OnPropertyChanged("EcommercePackageHeightVisibility");
            }
        }

        public bool EcommercePackageLengthVisibility
        {
            get
            {
                return UserOptions.EcommercePackageLengthVisibility;
            }
            set
            {
                UserOptions.EcommercePackageLengthVisibility = value;
                OnPropertyChanged("EcommercePackageLengthVisibility");
            }
        }

        public bool EcommercePackageWeightVisibility
        {
            get
            {
                return UserOptions.EcommercePackageWeightVisibility;
            }
            set
            {
                UserOptions.EcommercePackageWeightVisibility = value;
                OnPropertyChanged("EcommercePackageWeightVisibility");
            }
        }

        public bool EcommercePackageWidthVisibility
        {
            get
            {
                return UserOptions.EcommercePackageWidthVisibility;
            }
            set
            {
                UserOptions.EcommercePackageWidthVisibility = value;
                OnPropertyChanged("EcommercePackageWidthVisibility");
            }
        }

        public bool EcommercePageQtyVisibility
        {
            get
            {
                return UserOptions.EcommercePageQtyVisibility;
            }
            set
            {
                UserOptions.EcommercePageQtyVisibility = value;
                OnPropertyChanged("EcommercePageQtyVisibility");
            }
        }

        public bool EcommerceProductCategoryVisibility
        {
            get
            {
                return UserOptions.EcommerceProductCategoryVisibility;
            }
            set
            {
                UserOptions.EcommerceProductCategoryVisibility = value;
                OnPropertyChanged("EcommerceProductCategoryVisibility");
            }
        }

        public bool EcommerceProductDescriptionVisibility
        {
            get
            {
                return UserOptions.EcommerceProductDescriptionVisibility;
            }
            set
            {
                UserOptions.EcommerceProductDescriptionVisibility = value;
                OnPropertyChanged("EcommerceProductDescriptionVisibility");
            }
        }

        public bool EcommerceProductSubcategoryVisibility
        {
            get
            {
                return UserOptions.EcommerceProductSubcategoryVisibility;
            }
            set
            {
                UserOptions.EcommerceProductSubcategoryVisibility = value;
                OnPropertyChanged("EcommerceProductSubcategoryVisibility");
            }
        }

        public bool EcommerceManufacturerNameVisibility
        {
            get
            {
                return UserOptions.EcommerceManufacturerNameVisibility;
            }
            set
            {
                UserOptions.EcommerceManufacturerNameVisibility = value;
                OnPropertyChanged("EcommerceManufacturerNameVisibility");
            }
        }

        public bool EcommerceMsrpVisibility
        {
            get
            {
                return UserOptions.EcommerceMsrpVisibility;
            }
            set
            {
                UserOptions.EcommerceMsrpVisibility = value;
                OnPropertyChanged("EcommerceMsrpVisibility");
            }
        }

        public bool EcommerceSearchTermsVisibility
        {
            get
            {
                return UserOptions.EcommerceSearchTermsVisibility;
            }
            set
            {
                UserOptions.EcommerceSearchTermsVisibility = value;
                OnPropertyChanged("EcommerceSearchTermsVisibility");
            }
        }

        public bool EcommerceSizeVisibility
        {
            get
            {
                return UserOptions.EcommerceSizeVisibility;
            }
            set
            {
                UserOptions.EcommerceSizeVisibility = value;
                OnPropertyChanged("EcommerceSizeVisibility");
            }
        }

        public bool EcommerceUpcVisibility
        {
            get
            {
                return UserOptions.EcommerceUpcVisibility;
            }
            set
            {
                UserOptions.EcommerceUpcVisibility = value;
                OnPropertyChanged("EcommerceUpcVisibility");
            }
        }

        #endregion // Visibility Ecommerce Properties

        #region B2B Visibility Properties

        /// <summary>
        ///     Gets or sets the Category
        /// </summary>
        public bool B2BFieldVisibility
        {
            get
            {
                return _b2BFieldVisibility;
            }
            set
            {
                _b2BFieldVisibility = value;
                if (!InitiateFlag)
                {
                    SetB2BFieldVisibility(value);
                }
                OnPropertyChanged("B2BFieldVisibility");
            }
        }
        private bool _b2BFieldVisibility = true;

        /// <summary>
        ///     Gets or sets the Category
        /// </summary>
        public bool CategoryVisibility
        {
            get
            {
                return UserOptions.CategoryVisibility;
            }
            set
            {
                UserOptions.CategoryVisibility = value;
                OnPropertyChanged("CategoryVisibility");
            }
        }

        /// <summary>
        ///     Gets or sets the Category2
        /// </summary>
        public bool Category2Visibility
        {
            get
            {
                return UserOptions.Category2Visibility;
            }
            set
            {
                UserOptions.Category2Visibility = value;
                OnPropertyChanged("Category2Visibility");
            }
        }

        /// <summary>
        ///     Gets or sets the Category3
        /// </summary>
        public bool Category3Visibility
        {
            get
            {
                return UserOptions.Category3Visibility;
            }
            set
            {
                UserOptions.Category3Visibility = value;
                OnPropertyChanged("Category3Visibility");
            }
        }

        /// <summary>
        ///     Gets or sets the Copyright
        /// </summary>
        public bool CopyrightVisibility
        {
            get
            {
                return UserOptions.CopyrightVisibility;
            }
            set
            {
                UserOptions.CopyrightVisibility = value;
                OnPropertyChanged("CopyrightVisibility");
            }
        }

        /// <summary>
        ///     Gets or sets the InStockDate
        /// </summary>
        public bool InStockDateVisibility
        {
            get
            {
                return UserOptions.InStockDateVisibility;
            }
            set
            {
                UserOptions.InStockDateVisibility = value;
                OnPropertyChanged("InStockDateVisibility");
            }
        }

        /// <summary>
        ///     Gets or sets the ItemKeywords
        /// </summary>
        public bool ItemKeywordsVisibility
        {
            get
            {
                return UserOptions.ItemKeywordsVisibility;
            }
            set
            {
                UserOptions.ItemKeywordsVisibility = value;
                OnPropertyChanged("ItemKeywordsVisibility");
            }
        }
        
        /// <summary>
        ///     Gets or sets the License
        /// </summary>
        public bool LicenseVisibility
        {
            get
            {
                return UserOptions.LicenseVisibility;
            }
            set
            {
                UserOptions.LicenseVisibility = value;
                OnPropertyChanged("LicenseVisibility");
            }
        }

        /// <summary>
        ///     Gets or sets the LicenseBeginDate
        /// </summary>
        public bool LicenseBeginDateVisibility
        {
            get
            {
                return UserOptions.LicenseBeginDateVisibility;
            }
            set
            {
                UserOptions.LicenseBeginDateVisibility = value;
                OnPropertyChanged("LicenseBeginDateVisibility");
            }
        }

        /// <summary>
        ///     Gets or sets the MetaDescription
        /// </summary>
        public bool MetaDescriptionVisibility
        {
            get
            {
                return UserOptions.MetaDescriptionVisibility;
            }
            set
            {
                UserOptions.MetaDescriptionVisibility = value;
                OnPropertyChanged("MetaDescriptionVisibility");
            }
        }

        /// <summary>
        ///     Gets or sets the property
        /// </summary>
        public bool PropertyVisibility
        {
            get
            {
                return UserOptions.PropertyVisibility;
            }
            set
            {
                UserOptions.PropertyVisibility = value;
                OnPropertyChanged("PropertyVisibility");
            }
        }

        /// <summary>
        ///     Gets or sets the ShortDescription
        /// </summary>
        public bool ShortDescriptionVisibility
        {
            get
            {
                return UserOptions.ShortDescriptionVisibility;
            }
            set
            {
                UserOptions.ShortDescriptionVisibility = value;
                OnPropertyChanged("ShortDescriptionVisibility");
            }
        }

        /// <summary>
        ///     Gets or sets the Size
        /// </summary>
        public bool SizeVisibility
        {
            get
            {
                return UserOptions.SizeVisibility;
            }
            set
            {
                UserOptions.SizeVisibility = value;
                OnPropertyChanged("SizeVisibility");
            }
        }

        /// <summary>
        ///     Gets or sets the Title
        /// </summary>
        public bool TitleVisibility
        {
            get
            {
                return UserOptions.TitleVisibility;
            }
            set
            {
                UserOptions.TitleVisibility = value;
                OnPropertyChanged("TitleVisibility");
            }
        }

        /// <summary>
        ///     Gets or sets the Website Price Visibility
        /// </summary>
        public bool WebsitePriceVisibility
        {
            get
            {
                return UserOptions.WebsitePriceVisibility;
            }
            set
            {
                UserOptions.WebsitePriceVisibility = value;
                OnPropertyChanged("WebsitePriceVisibility");
            }
        }

        #endregion // B2B Visibility Properties

        #region Peoplesoft Visibility Properties

        public bool PeoplesoftFieldVisibility
        {
            get
            {
                return _peoplesoftFieldVisibility;
            }
            set
            {

                _peoplesoftFieldVisibility = value;

                if (!InitiateFlag)
                {
                    SetPeoplesoftFieldVisibility(value);
                }
                OnPropertyChanged("PeoplesoftFieldVisibility");
            }
        }
        private bool _peoplesoftFieldVisibility = true;

        public bool AccountingGroupVisibility
        {
            get
            {
                return UserOptions.AccountingGroupVisibility;
            }
            set
            {
                UserOptions.AccountingGroupVisibility = value;
                OnPropertyChanged("AccountingGroupVisibility");
            }
        }

        public bool BillOfMaterialsVisibility
        {
            get
            {
                return UserOptions.BillOfMaterialsVisibility;
            }
            set
            {
                UserOptions.BillOfMaterialsVisibility = value;
                OnPropertyChanged("BillOfMaterialsVisibility");
            }
        }

        public bool CasepackHeightVisibility
        {
            get
            {
                return UserOptions.CasepackHeightVisibility;
            }
            set
            {
                UserOptions.CasepackHeightVisibility = value;
                OnPropertyChanged("CasepackHeightVisibility");
            }
        }

        public bool CasepackLengthVisibility
        {
            get
            {
                return UserOptions.CasepackLengthVisibility;
            }
            set
            {
                UserOptions.CasepackLengthVisibility = value;
                OnPropertyChanged("CasepackLengthVisibility");
            }
        }

        public bool CasepackQtyVisibility
        {
            get
            {
                return UserOptions.CasepackQtyVisibility;
            }
            set
            {
                UserOptions.CasepackQtyVisibility = value;
                OnPropertyChanged("CasepackQtyVisibility");
            }
        }

        public bool CasepackUpcVisibility
        {
            get
            {
                return UserOptions.CasepackUpcVisibility;
            }
            set
            {
                UserOptions.CasepackUpcVisibility = value;
                OnPropertyChanged("CasepackUpcVisibility");
            }
        }

        public bool CasepackWidthVisibility
        {
            get
            {
                return UserOptions.CasepackWidthVisibility;
            }
            set
            {
                UserOptions.CasepackWidthVisibility = value;
                OnPropertyChanged("CasepackWidthVisibility");
            }
        }

        public bool CasepackWeightVisibility
        {
            get
            {
                return UserOptions.CasepackWeightVisibility;
            }
            set
            {
                UserOptions.CasepackWeightVisibility = value;
                OnPropertyChanged("CasepackWeightVisibility");
            }
        }

        public bool ColorVisibility
        {
            get
            {
                return UserOptions.ColorVisibility;
            }
            set
            {
                UserOptions.ColorVisibility = value;
                OnPropertyChanged("ColorVisibility");
            }
        }

        public bool CountryOfOriginVisibility
        {
            get
            {
                return UserOptions.CountryOfOriginVisibility;
            }
            set
            {
                UserOptions.CountryOfOriginVisibility = value;
                OnPropertyChanged("CountryOfOriginVisibility");
            }
        }

        public bool CostProfileGroupVisibility
        {
            get
            {
                return UserOptions.CostProfileGroupVisibility;
            }
            set
            {
                UserOptions.CostProfileGroupVisibility = value;
                OnPropertyChanged("CostProfileGroupVisibility");
            }
        }

        public bool DefaultActualCostCadVisibility
        {
            get
            {
                return UserOptions.DefaultActualCostCadVisibility;
            }
            set
            {
                UserOptions.DefaultActualCostCadVisibility = value;
                OnPropertyChanged("DefaultActualCostCadVisibility");
            }
        }

        public bool DefaultActualCostUsdVisibility
        {
            get
            {
                return UserOptions.DefaultActualCostUsdVisibility;
            }
            set
            {
                UserOptions.DefaultActualCostUsdVisibility = value;
                OnPropertyChanged("DefaultActualCostUsdVisibility");
            }
        }

        public bool DescriptionVisibility
        {
            get
            {
                return UserOptions.DescriptionVisibility;
            }
            set
            {
                UserOptions.DescriptionVisibility = value;
                OnPropertyChanged("DescriptionVisibility");
            }
        }

        public bool DirectImportVisibility
        {
            get
            {
                return UserOptions.DirectImportVisibility;
            }
            set
            {
                UserOptions.DirectImportVisibility = value;
                OnPropertyChanged("DirectImportVisibility");
            }
        }

        public bool DutyVisibility
        {
            get
            {
                return UserOptions.DutyVisibility;
            }
            set
            {
                UserOptions.DutyVisibility = value;
                OnPropertyChanged("DutyVisibility");
            }
        }

        public bool EanVisibility
        {
            get
            {
                return UserOptions.EanVisibility;
            }
            set
            {
                UserOptions.EanVisibility = value;
                OnPropertyChanged("EanVisibility");
            }
        }

        public bool GpcVisibility
        {
            get
            {
                return UserOptions.GpcVisibility;
            }
            set
            {
                UserOptions.GpcVisibility = value;
                OnPropertyChanged("GpcVisibility");
            }
        }

        public bool HeightVisibility
        {
            get
            {
                return UserOptions.HeightVisibility;
            }
            set
            {
                UserOptions.HeightVisibility = value;
                OnPropertyChanged("HeightVisibility");
            }
        }

        public bool InnerpackHeightVisibility
        {
            get
            {
                return UserOptions.InnerpackHeightVisibility;
            }
            set
            {
                UserOptions.InnerpackHeightVisibility = value;
                OnPropertyChanged("InnerpackHeightVisibility");
            }
        }

        public bool InnerpackLengthVisibility
        {
            get
            {
                return UserOptions.InnerpackLengthVisibility;
            }
            set
            {
                UserOptions.InnerpackLengthVisibility = value;
                OnPropertyChanged("InnerpackLengthVisibility");
            }
        }

        public bool InnerpackQuantityVisibility
        {
            get
            {
                return UserOptions.InnerpackQuantityVisibility;
            }
            set
            {
                UserOptions.InnerpackQuantityVisibility = value;
                OnPropertyChanged("InnerpackQuantityVisibility");
            }
        }

        public bool InnerpackUpcVisibility
        {
            get
            {
                return UserOptions.InnerpackUpcVisibility;
            }
            set
            {
                UserOptions.InnerpackUpcVisibility = value;
                OnPropertyChanged("InnerpackUpcVisibility");
            }
        }

        public bool InnerpackWidthVisibility
        {
            get
            {
                return UserOptions.InnerpackWidthVisibility;
            }
            set
            {
                UserOptions.InnerpackWidthVisibility = value;
                OnPropertyChanged("InnerpackWidthVisibility");
            }
        }

        public bool InnerpackWeightVisibility
        {
            get
            {
                return UserOptions.InnerpackWeightVisibility;
            }
            set
            {
                UserOptions.InnerpackWeightVisibility = value;
                OnPropertyChanged("InnerpackWeightVisibility");
            }
        }

        public bool IsbnVisibility
        {
            get
            {
                return UserOptions.IsbnVisibility;
            }
            set
            {
                UserOptions.IsbnVisibility = value;
                OnPropertyChanged("IsbnVisibility");
            }
        }

        public bool ItemCategoryVisibility
        {
            get
            {
                return UserOptions.ItemCategoryVisibility;
            }
            set
            {
                UserOptions.ItemCategoryVisibility = value;
                OnPropertyChanged("ItemCategoryVisibility");
            }
        }

        public bool ItemFamilyVisibility
        {
            get
            {
                return UserOptions.ItemFamilyVisibility;
            }
            set
            {
                UserOptions.ItemFamilyVisibility = value;
                OnPropertyChanged("ItemFamilyVisibility");
            }
        }

        public bool ItemGroupVisibility
        {
            get
            {
                return UserOptions.ItemGroupVisibility;
            }
            set
            {
                UserOptions.ItemGroupVisibility = value;
                OnPropertyChanged("ItemGroupVisibility");
            }
        }

        public bool LanguageVisibility
        {
            get
            {
                return UserOptions.LanguageVisibility;
            }
            set
            {
                UserOptions.LanguageVisibility = value;
                OnPropertyChanged("LanguageVisibility");
            }
        }

        public bool LengthVisibility
        {
            get
            {
                return UserOptions.LengthVisibility;
            }
            set
            {
                UserOptions.LengthVisibility = value;
                OnPropertyChanged("LengthVisibility");
            }
        }

        public bool ListPriceCadVisibility
        {
            get
            {
                return UserOptions.ListPriceCadVisibility;
            }
            set
            {
                UserOptions.ListPriceCadVisibility = value;
                OnPropertyChanged("ListPriceCadVisibility");
            }
        }

        public bool ListPriceMxnVisibility
        {
            get
            {
                return UserOptions.ListPriceMxnVisibility;
            }
            set
            {
                UserOptions.ListPriceMxnVisibility = value;
                OnPropertyChanged("ListPriceMxnVisibility");
            }
        }

        public bool ListPriceUsdVisibility
        {
            get
            {
                return UserOptions.ListPriceUsdVisibility;
            }
            set
            {
                UserOptions.ListPriceUsdVisibility = value;
                OnPropertyChanged("ListPriceUsdVisibility");
            }
        }

        public bool MfgSourceVisibility
        {
            get
            {
                return UserOptions.MfgSourceVisibility;
            }
            set
            {
                UserOptions.MfgSourceVisibility = value;
                OnPropertyChanged("MfgSourceVisibility");
            }
        }

        public bool MsrpVisibility
        {
            get
            {
                return UserOptions.MsrpVisibility;
            }
            set
            {
                UserOptions.MsrpVisibility = value;
                OnPropertyChanged("MsrpVisibility");
            }
        }

        public bool MsrpCadVisibility
        {
            get
            {
                return UserOptions.MsrpCadVisibility;
            }
            set
            {
                UserOptions.MsrpCadVisibility = value;
                OnPropertyChanged("MsrpCadVisibility");
            }
        }

        public bool MsrpMxnVisibility
        {
            get
            {
                return UserOptions.MsrpMxnVisibility;
            }
            set
            {
                UserOptions.MsrpMxnVisibility = value;
                OnPropertyChanged("MsrpMxnVisibility");
            }
        }

        public bool PricingGroupVisibility
        {
            get
            {
                return UserOptions.PricingGroupVisibility;
            }
            set
            {
                UserOptions.PricingGroupVisibility = value;
                OnPropertyChanged("PricingGroupVisibility");
            }
        }

        public bool PrintOnDemandVisibility
        {
            get
            {
                return UserOptions.PrintOnDemandVisibility;
            }
            set
            {
                UserOptions.PrintOnDemandVisibility = value;
                OnPropertyChanged("PrintOnDemandVisibility");
            }
        }

        public bool ProductFormatVisibility
        {
            get
            {
                return UserOptions.ProductFormatVisibility;
            }
            set
            {
                UserOptions.ProductFormatVisibility = value;
                OnPropertyChanged("ProductFormatVisibility");
            }
        }

        public bool ProductGroupVisibility
        {
            get
            {
                return UserOptions.ProductGroupVisibility;
            }
            set
            {
                UserOptions.ProductGroupVisibility = value;
                OnPropertyChanged("ProductGroupVisibility");
            }
        }

        public bool ProductIdTranslationVisibility
        {
            get
            {
                return UserOptions.ProductIdTranslationVisibility;
            }
            set
            {
                UserOptions.ProductIdTranslationVisibility = value;
                OnPropertyChanged("ProductIdTranslationVisibility");
            }
        }

        public bool ProductLineVisibility
        {
            get
            {
                return UserOptions.ProductLineVisibility;
            }
            set
            {
                UserOptions.ProductLineVisibility = value;
                OnPropertyChanged("ProductLineVisibility");
            }
        }

        public bool ProductQtyVisibility
        {
            get
            {
                return UserOptions.ProductQtyVisibility;
            }
            set
            {
                UserOptions.ProductQtyVisibility = value;
                OnPropertyChanged("ProductQtyVisibility");
            }
        }

        public bool PsStatusVisibility
        {
            get
            {
                return UserOptions.PsStatusVisibility;
            }
            set
            {
                UserOptions.PsStatusVisibility = value;
                OnPropertyChanged("PsStatusVisibility");
            }
        }
        
        public bool SatCodeVisibility
        {
            get
            {
                return UserOptions.SatCodeVisibility;
            }
            set
            {
                UserOptions.SatCodeVisibility = value;
                OnPropertyChanged("SatCodeVisibility");
            }
        }
        
        public bool StandardCostVisibility
        {
            get
            {
                return UserOptions.StandardCostVisibility;
            }
            set
            {
                UserOptions.StandardCostVisibility = value;
                OnPropertyChanged("StandardCostVisibility");
            }
        }

        public bool StatsCodeVisibility
        {
            get
            {
                return UserOptions.StatsCodeVisibility;
            }
            set
            {
                UserOptions.StatsCodeVisibility = value;
                OnPropertyChanged("StatsCodeVisibility");
            }
        }

        public bool TariffCodeVisibility
        {
            get
            {
                return UserOptions.TariffCodeVisibility;
            }
            set
            {
                UserOptions.TariffCodeVisibility = value;
                OnPropertyChanged("TariffCodeVisibility");
            }
        }

        public bool TerritoryVisibility
        {
            get
            {
                return UserOptions.TerritoryVisibility;
            }
            set
            {
                UserOptions.TerritoryVisibility = value;
                OnPropertyChanged("TerritoryVisibility");
            }
        }

        public bool UdexVisibility
        {
            get
            {
                return UserOptions.UdexVisibility;
            }
            set
            {
                UserOptions.UdexVisibility = value;
                OnPropertyChanged("UdexVisibility");
            }
        }

        public bool UpcVisibility
        {
            get
            {
                return UserOptions.UpcVisibility;
            }
            set
            {
                UserOptions.UpcVisibility = value;
                OnPropertyChanged("UpcVisibility");
            }
        }

        public bool WarrantyVisibility
        {
            get
            {
                return UserOptions.WarrantyVisibility;
            }
            set
            {
                UserOptions.WarrantyVisibility = value;
                OnPropertyChanged("WarrantyVisibility");
            }
        }

        public bool WarrantyCheckVisibility
        {
            get
            {
                return UserOptions.WarrantyCheckVisibility;
            }
            set
            {
                UserOptions.WarrantyCheckVisibility = value;
                OnPropertyChanged("WarrantyCheckVisibility");
            }
        }

        public bool WeightVisibility
        {
            get
            {
                return UserOptions.WeightVisibility;
            }
            set
            {
                UserOptions.WeightVisibility = value;
                OnPropertyChanged("WeightVisibility");
            }
        }

        public bool WidthVisibility
        {
            get
            {
                return UserOptions.WidthVisibility;
            }
            set
            {
                UserOptions.WidthVisibility = value;
                OnPropertyChanged("WidthVisibility");
            }
        }

        #endregion // Peoplesoft Visibility Properties        

        #region Sell On Visibility Properties

        public bool SellOnVisibility
        {
            get
            {
                return _sellOnVisibility;
            }
            set
            {
                _sellOnVisibility = value;
                if (!InitiateFlag)
                {
                    SetSellOnFieldVisibility(value);
                }
                OnPropertyChanged("SellOnVisibility");
            }
        }
        private bool _sellOnVisibility = true;

        public bool SellOnAllPostersVisibility
        {
            get
            {
                return UserOptions.SellOnAllPostersVisibility;
            }
            set
            {
                UserOptions.SellOnAllPostersVisibility = value;
                OnPropertyChanged("SellOnAllPostersVisibility");
            }
        }

        public bool SellOnAmazonVisibility
        {
            get
            {
                return UserOptions.SellOnAmazonVisibility;
            }
            set
            {
                UserOptions.SellOnAmazonVisibility = value;
                OnPropertyChanged("SellOnAmazonVisibility");
            }
        }

        public bool SellOnAmazonSellerCentralVisibility
        {
            get
            {
                return UserOptions.SellOnAmazonSellerCentralVisibility;
            }
            set
            {
                UserOptions.SellOnAmazonSellerCentralVisibility = value;
                OnPropertyChanged("SellOnAmazonSellerCentralVisibility");
            }
        }

        public bool SellOnEcommerceVisibility
        {
            get
            {
                return UserOptions.SellOnEcommerceVisibility;
            }
            set
            {
                UserOptions.SellOnEcommerceVisibility = value;
                OnPropertyChanged("SellOnEcommerceVisibility");
            }
        }

        public bool SellOnFanaticsVisibility
        {
            get
            {
                return UserOptions.SellOnFanaticsVisibility;
            }
            set
            {
                UserOptions.SellOnFanaticsVisibility = value;
                OnPropertyChanged("SellOnFanaticsVisibility");
            }
        }

        public bool SellOnGuitarCenterVisibility
        {
            get
            {
                return UserOptions.SellOnGuitarCenterVisibility;
            }
            set
            {
                UserOptions.SellOnGuitarCenterVisibility = value;
                OnPropertyChanged("SellOnGuitarCenterVisibility");
            }
        }

        public bool SellOnHayneedleVisibility
        {
            get
            {
                return UserOptions.SellOnHayneedleVisibility;
            }
            set
            {
                UserOptions.SellOnHayneedleVisibility = value;
                OnPropertyChanged("SellOnHayneedleVisibility");
            }
        }

        public bool SellOnTargetVisibility
        {
            get
            {
                return UserOptions.SellOnTargetVisibility;
            }
            set
            {
                UserOptions.SellOnTargetVisibility = value;
                OnPropertyChanged("SellOnTargetVisibility");
            }
        }

        public bool SellOnTrendsVisibility
        {
            get
            {
                return UserOptions.SellOnTrendsVisibility;
            }
            set
            {
                UserOptions.SellOnTrendsVisibility = value;
                OnPropertyChanged("SellOnTrendsVisibility");
            }
        }

        public bool SellOnWalmartVisibility
        {
            get
            {
                return UserOptions.SellOnWalmartVisibility;
            }
            set
            {
                UserOptions.SellOnWalmartVisibility = value;
                OnPropertyChanged("SellOnWalmartVisibility");
            }
        }

        public bool SellOnWayfairVisibility
        {
            get
            {
                return UserOptions.SellOnWayfairVisibility;
            }
            set
            {
                UserOptions.SellOnWayfairVisibility = value;
                OnPropertyChanged("SellOnWayfairVisibility");
            }
        }

        #endregion // Sell On Visibility Properties

        #region Image Visibility Properties

        /// <summary>
        ///     Gets or sets the Image Path Visibility
        /// </summary>
        public bool ImagePathVisibility
        {
            get
            {
                return _imagePathVisibility;
            }
            set
            {
                _imagePathVisibility = value;
                if (!InitiateFlag)
                {
                    SetImagePathVisibility(value);
                }
                OnPropertyChanged("ImagePathVisibility");
            }
        }
        private bool _imagePathVisibility = true;

        public bool ImagePath1Visibility
        {
            get
            {
                return UserOptions.ImagePath1Visibility;
            }
            set
            {
                UserOptions.ImagePath1Visibility = value;
                OnPropertyChanged("ImagePath1Visibility");
            }
        }

        public bool ImagePath2Visibility
        {
            get
            {
                return UserOptions.ImagePath2Visibility;
            }
            set
            {
                UserOptions.ImagePath2Visibility = value;
                OnPropertyChanged("ImagePath2Visibility");
            }
        }

        public bool ImagePath3Visibility
        {
            get
            {
                return UserOptions.ImagePath3Visibility;
            }
            set
            {
                UserOptions.ImagePath3Visibility = value;
                OnPropertyChanged("ImagePath3Visibility");
            }
        }

        public bool ImagePath4Visibility
        {
            get
            {
                return UserOptions.ImagePath4Visibility;
            }
            set
            {
                UserOptions.ImagePath4Visibility = value;
                OnPropertyChanged("ImagePath4Visibility");
            }
        }

        public bool ImagePath5Visibility
        {
            get
            {
                return UserOptions.ImagePath5Visibility;
            }
            set
            {
                UserOptions.ImagePath5Visibility = value;
                OnPropertyChanged("ImagePath5Visibility");
            }
        }

        #endregion // Image Visibility Properties

        #endregion // MainWindowHeader Visibility Properties

        /// <summary>
        ///     Gets or sets the EcommerceVisibility
        /// </summary>
        public string EcommerceVisibility
        {
            get
            {
                return _ecommerceVisibility;
            }
            set
            {
                _ecommerceVisibility = value;
                OnPropertyChanged("EcommerceVisibility");
            }
        }
        private string _ecommerceVisibility = "Hidden";

        /// <summary>
        ///     Gets or sets the update flag
        /// </summary>
        public bool HasUpdate { get; set; }

        /// <summary>
        ///     Gets or sets the OptionService
        /// </summary>
        private OptionService OptionService { get; set; }

        /// <summary>
        ///     Gets or sets the SelectedProductFormatExclusionOption
        /// </summary>
        public string SelectedProductFormatExclusionOption
        {
            get
            {
                return _selectedProductFormatExclusionOption;
            }
            set
            {
                _selectedProductFormatExclusionOption = value;
                OnPropertyChanged("SelectedProductFormatExclusionOption");
            }
        }
        private string _selectedProductFormatExclusionOption = string.Empty;

        /// <summary>
        ///     Gets or Sets the ProductFormatExclusionOptions list
        /// </summary>
        public List<string> ProductFormatExclusionOptions
        {
            get
            {
                return _productFormatExclusionOptions;
            }
            set
            {
                _productFormatExclusionOptions = value;
                OnPropertyChanged("ProductFormatExclusionOptions");
            }

        }
        private List<string> _productFormatExclusionOptions = new List<string>();

        /// <summary>
        ///     Gets or sets the SelectedVariantGroupExclusionOption
        /// </summary>
        public string SelectedVariantGroupExclusionOption
        {
            get
            {
                return _selectedVariantGroupExclusionOption;
            }
            set
            {
                _selectedVariantGroupExclusionOption = value;
                OnPropertyChanged("SelectedVariantGroupExclusionOption");
            }
        }
        private string _selectedVariantGroupExclusionOption = string.Empty;

        /// <summary>
        ///     Gets or Sets the VariantGroupExclusionOptions list
        /// </summary>
        public List<string> VariantGroupExclusionOptions
        {
            get
            {
                return _variantGroupExclusionOptions;
            }
            set
            {
                _variantGroupExclusionOptions = value;
                OnPropertyChanged("VariantGroupExclusionOptions");
            }

        }
        private List<string> _variantGroupExclusionOptions = new List<string>();

        #endregion // Properties

        #region Methods

        /// <summary>
        ///     Adds a value to the VariantGroupIdExclusion list
        /// </summary>
        public void AddOption(string optionType)
        {
            TextPromptView textWindow = new TextPromptView()
            {
                DataContext = new TextPromptViewModel()
            };
            textWindow.ShowDialog();

            if (textWindow.DialogResult==true)
            {
                string result = (textWindow.DataContext as TextPromptViewModel).TextValue;
                if (optionType == "VariantGroupExclusion")
                {
                    OptionService.InsertOption(optionType, result, "");
                    GlobalData.VariantGroupExclusionOptions = OptionService.RetrieveOptions("VariantGroupExclusion", "");
                    this.VariantGroupExclusionOptions = GlobalData.VariantGroupExclusionOptions;
                }
                else if (optionType == "ProductFormatExclusion")
                {
                    OptionService.InsertOption(optionType, result, GlobalData.UserName);
                    GlobalData.ProductFormatExclusionOptions = OptionService.RetrieveOptions("ProductFormatExclusion", GlobalData.UserName);
                    this.ProductFormatExclusionOptions = GlobalData.ProductFormatExclusionOptions;
                }

                HasUpdate = true;

            }
        }

        public bool CheckB2BFieldVisibility()
        {
            if (UserOptions.CategoryVisibility == false) { return false; }
            if (UserOptions.Category2Visibility  == false) { return false; }
            if (UserOptions.Category3Visibility  == false) { return false; }
            if (UserOptions.CopyrightVisibility  == false) { return false; }
            if (UserOptions.InStockDateVisibility  == false) { return false; }
            if (UserOptions.ItemKeywordsVisibility  == false) { return false; }
            if (UserOptions.LicenseVisibility  == false) { return false; }
            if (UserOptions.MetaDescriptionVisibility  == false) { return false; }
            if (UserOptions.PropertyVisibility  == false) { return false; }
            if (UserOptions.ShortDescriptionVisibility  == false) { return false; }
            if (UserOptions.SizeVisibility  == false) { return false; }
            if (UserOptions.TitleVisibility  == false) { return false; }
            if (UserOptions.WebsitePriceVisibility == false) { return false; }
            return true;
        }

        public bool CheckEcommerceFieldVisibility()
        {
            if (UserOptions.EcommerceAsinVisibility == false) { return false; }
            if (UserOptions.EcommerceBullet1Visibility == false) { return false; }
            if (UserOptions.EcommerceBullet2Visibility == false) { return false; }
            if (UserOptions.EcommerceBullet3Visibility == false) { return false; }
            if (UserOptions.EcommerceBullet4Visibility == false) { return false; }
            if (UserOptions.EcommerceBullet5Visibility == false) { return false; }
            if (UserOptions.EcommerceComponentsVisibility == false) { return false; }
            if (UserOptions.EcommerceCostVisibility == false) { return false; }
            if (UserOptions.EcommerceCountryofOriginVisibility == false) { return false; }
            if (UserOptions.EcommerceExternalIdVisibility == false) { return false; }
            if (UserOptions.EcommerceExternalIdTypeVisibility == false) { return false; }
            if (UserOptions.EcommerceItemAliasVisibility == false) { return false; }
            if (UserOptions.EcommerceItemHeightVisibility == false) { return false; }
            if (UserOptions.EcommerceItemLengthVisibility == false) { return false; }
            if (UserOptions.EcommerceItemNameVisibility == false) { return false; }
            if (UserOptions.EcommerceItemWeightVisibility == false) { return false; }
            if (UserOptions.EcommerceItemWidthVisibility == false) { return false; }
            if (UserOptions.EcommerceModelNameVisibility == false) { return false; }
            if (UserOptions.EcommercePackageHeightVisibility == false) { return false; }
            if (UserOptions.EcommercePackageLengthVisibility == false) { return false; }
            if (UserOptions.EcommercePackageWeightVisibility == false) { return false; }
            if (UserOptions.EcommercePackageWidthVisibility == false) { return false; }
            if (UserOptions.EcommercePageQtyVisibility == false) { return false; }
            if (UserOptions.EcommerceProductCategoryVisibility == false) { return false; }
            if (UserOptions.EcommerceProductDescriptionVisibility == false) { return false; }
            if (UserOptions.EcommerceProductSubcategoryVisibility == false) { return false; }
            if (UserOptions.EcommerceManufacturerNameVisibility == false) { return false; }
            if (UserOptions.EcommerceMsrpVisibility == false) { return false; }
            if (UserOptions.EcommerceSearchTermsVisibility == false) { return false; }
            if (UserOptions.EcommerceSizeVisibility == false) { return false; }
            if (UserOptions.EcommerceUpcVisibility == false) { return false; }
            if (UserOptions.WarrantyVisibility == false) { return false; }
            if (UserOptions.WarrantyCheckVisibility == false) { return false; }
            return true;
        }

        public bool CheckImagePathVisibility()
        {
            if (UserOptions.ImagePath1Visibility  == false) { return false; }
            if (UserOptions.ImagePath2Visibility  == false) { return false; }
            if (UserOptions.ImagePath3Visibility  == false) { return false; }
            if (UserOptions.ImagePath4Visibility  == false) { return false; }
            if (UserOptions.ImagePath5Visibility  == false) { return false; }
            return true;
        }

        public bool CheckPeoplesoftFieldVisibility()
        {
            if (UserOptions.AccountingGroupVisibility  == false) { return false; }
            if (UserOptions.BillOfMaterialsVisibility  == false) { return false; }
            if (UserOptions.CasepackHeightVisibility  == false) { return false; }
            if (UserOptions.CasepackLengthVisibility  == false) { return false; }
            if (UserOptions.CasepackQtyVisibility  == false) { return false; }
            if (UserOptions.CasepackUpcVisibility  == false) { return false; }
            if (UserOptions.CasepackWidthVisibility  == false) { return false; }
            if (UserOptions.CasepackWeightVisibility  == false) { return false; }
            if (UserOptions.ColorVisibility  == false) { return false; }
            if (UserOptions.CountryOfOriginVisibility  == false) { return false; }
            if (UserOptions.CostProfileGroupVisibility  == false) { return false; }
            if (UserOptions.DefaultActualCostCadVisibility  == false) { return false; }
            if (UserOptions.DefaultActualCostUsdVisibility  == false) { return false; }
            if (UserOptions.DescriptionVisibility  == false) { return false; }
            if (UserOptions.DirectImportVisibility  == false) { return false; }
            if (UserOptions.DutyVisibility  == false) { return false; }
            if (UserOptions.EanVisibility  == false) { return false; }
            if (UserOptions.GpcVisibility  == false) { return false; }
            if (UserOptions.HeightVisibility  == false) { return false; }
            if (UserOptions.InnerpackHeightVisibility  == false) { return false; }
            if (UserOptions.InnerpackLengthVisibility  == false) { return false; }
            if (UserOptions.InnerpackQuantityVisibility  == false) { return false; }
            if (UserOptions.InnerpackUpcVisibility  == false) { return false; }
            if (UserOptions.InnerpackWidthVisibility  == false) { return false; }
            if (UserOptions.InnerpackWeightVisibility  == false) { return false; }
            if (UserOptions.IsbnVisibility  == false) { return false; }
            if (UserOptions.ItemCategoryVisibility  == false) { return false; }
            if (UserOptions.ItemFamilyVisibility  == false) { return false; }
            if (UserOptions.ItemGroupVisibility  == false) { return false; }
            if (UserOptions.LanguageVisibility  == false) { return false; }
            if (UserOptions.LengthVisibility  == false) { return false; }
            if (UserOptions.LicenseBeginDateVisibility  == false) { return false; }
            if (UserOptions.ListPriceCadVisibility  == false) { return false; }
            if (UserOptions.ListPriceMxnVisibility  == false) { return false; }
            if (UserOptions.ListPriceUsdVisibility  == false) { return false; }
            if (UserOptions.MfgSourceVisibility  == false) { return false; }
            if (UserOptions.MsrpVisibility  == false) { return false; }
            if (UserOptions.MsrpCadVisibility  == false) { return false; }
            if (UserOptions.MsrpMxnVisibility  == false) { return false; }
            if (UserOptions.PricingGroupVisibility  == false) { return false; }
            if (UserOptions.PrintOnDemandVisibility  == false) { return false; }
            if (UserOptions.ProductFormatVisibility  == false) { return false; }
            if (UserOptions.ProductGroupVisibility  == false) { return false; }
            if (UserOptions.ProductIdTranslationVisibility  == false) { return false; }
            if (UserOptions.ProductLineVisibility  == false) { return false; }
            if (UserOptions.ProductQtyVisibility  == false) { return false; }
            if (UserOptions.PsStatusVisibility  == false) { return false; }
            if (UserOptions.SatCodeVisibility  == false) { return false; }
            if (UserOptions.StandardCostVisibility  == false) { return false; }
            if (UserOptions.StatsCodeVisibility  == false) { return false; }
            if (UserOptions.TariffCodeVisibility  == false) { return false; }
            if (UserOptions.TerritoryVisibility  == false) { return false; }
            if (UserOptions.UdexVisibility  == false) { return false; }
            if (UserOptions.UpcVisibility  == false) { return false; }
            if (UserOptions.WeightVisibility  == false) { return false; }
            if (UserOptions.WidthVisibility  == false) { return false; }
                return true;
        }

        public bool CheckSellOnFieldVisibility()
        {
            if (UserOptions.SellOnAllPostersVisibility  == false) { return false; }
            if (UserOptions.SellOnAmazonVisibility  == false) { return false; }
            if (UserOptions.SellOnAmazonSellerCentralVisibility == false) { return false; }
            if (UserOptions.SellOnEcommerceVisibility == false) { return false; }
            if (UserOptions.SellOnFanaticsVisibility  == false) { return false; }
            if (UserOptions.SellOnGuitarCenterVisibility == false) { return false; }
            if (UserOptions.SellOnHayneedleVisibility  == false) { return false; }
            if (UserOptions.SellOnTargetVisibility  == false) { return false; }
            if (UserOptions.SellOnTrendsVisibility  == false) { return false; }
            if (UserOptions.SellOnWalmartVisibility  == false) { return false; }
            if (UserOptions.SellOnWayfairVisibility  == false) { return false; }
            return true;
        }

        /// <summary>
        ///     Removes a value from the ProductFormatExclusion list
        /// </summary>
        public void RemoveProductFormatExclusion()
        {
            OptionService.RemoveOption("ProductFormatExclusion", this.SelectedProductFormatExclusionOption, GlobalData.UserName);
            GlobalData.ProductFormatExclusionOptions = OptionService.RetrieveOptions("ProductFormatExclusion", GlobalData.UserName);
            this.ProductFormatExclusionOptions = GlobalData.ProductFormatExclusionOptions;
            HasUpdate = true;
        }

        /// <summary>
        ///     Removes a value from the VariantGroupIdExclusion list
        /// </summary>
        public void RemoveVariantGroupIdExclusion()
        {
            OptionService.RemoveOption("VariantGroupExclusion", this.SelectedVariantGroupExclusionOption, "");
            GlobalData.VariantGroupExclusionOptions = OptionService.RetrieveOptions("VariantGroupExclusion","");
            this.VariantGroupExclusionOptions = GlobalData.VariantGroupExclusionOptions;
            HasUpdate = true;
        }

        /// <summary>
        ///     Runs all retrieval methods and populates properties
        /// </summary>
        public void RetrieveAllOptions()
        {
            this.VariantGroupExclusionOptions = GlobalData.VariantGroupExclusionOptions;
            this.ProductFormatExclusionOptions = GlobalData.ProductFormatExclusionOptions;
            InitiateFlag = true;
            this.B2BFieldVisibility = CheckB2BFieldVisibility();
            this.EcommerceFieldVisibility = CheckEcommerceFieldVisibility();
            this.ImagePathVisibility = CheckImagePathVisibility();
            this.PeoplesoftFieldVisibility = CheckPeoplesoftFieldVisibility();
            this.SellOnVisibility = CheckSellOnFieldVisibility();
            InitiateFlag = false;
        }

        /// <summary>
        ///     Flags all the b2b values to true or false
        /// </summary>
        /// <param name="value"></param>
        public void SetB2BFieldVisibility(bool value)
        {
            if (value)
            {
                CategoryVisibility = true;
                Category2Visibility = true;
                Category3Visibility = true;
                CopyrightVisibility = true;
                InStockDateVisibility = true;
                ItemKeywordsVisibility = true;
                LicenseVisibility = true;
                MetaDescriptionVisibility = true;
                PropertyVisibility = true;
                ShortDescriptionVisibility = true;
                SizeVisibility = true;
                TitleVisibility = true;
                WebsitePriceVisibility = true;
            }
            else
            {
                CategoryVisibility = false;
                Category2Visibility = false;
                Category3Visibility = false;
                CopyrightVisibility = false;
                InStockDateVisibility = false;
                ItemKeywordsVisibility = false;
                LicenseVisibility = false;
                MetaDescriptionVisibility = false;
                PropertyVisibility = false;
                ShortDescriptionVisibility = false;
                SizeVisibility = false;
                WebsitePriceVisibility = false;
            }
        }

        /// <summary>
        ///     Flags all the ecommerce values to true or false
        /// </summary>
        /// <param name="value"></param>
        public void SetEcommerceFieldVisibility(bool value)
        {
            if (value)
            {
                EcommerceAsinVisibility = true;
                EcommerceBullet1Visibility = true;
                EcommerceBullet2Visibility = true;
                EcommerceBullet3Visibility = true;
                EcommerceBullet4Visibility = true;
                EcommerceBullet5Visibility = true;
                EcommerceComponentsVisibility = true;
                EcommerceCostVisibility = true;
                EcommerceCountryofOriginVisibility = true;
                EcommerceExternalIdVisibility = true;
                EcommerceExternalIdTypeVisibility = true;
                EcommerceItemAliasVisibility = true;
                EcommerceItemHeightVisibility = true;
                EcommerceItemLengthVisibility = true;
                EcommerceItemNameVisibility = true;
                EcommerceItemWeightVisibility = true;
                EcommerceItemWidthVisibility = true;
                EcommerceModelNameVisibility = true;
                EcommercePackageHeightVisibility = true;
                EcommercePackageLengthVisibility = true;
                EcommercePackageWeightVisibility = true;
                EcommercePackageWidthVisibility = true;
                EcommercePageQtyVisibility = true;
                EcommerceProductCategoryVisibility = true;
                EcommerceProductDescriptionVisibility = true;
                EcommerceProductSubcategoryVisibility = true;
                EcommerceManufacturerNameVisibility = true;
                EcommerceMsrpVisibility = true;
                EcommerceSearchTermsVisibility = true;
                EcommerceSizeVisibility = true;
                EcommerceUpcVisibility = true;
                WarrantyVisibility = true;
                WarrantyCheckVisibility = true;
            }
            else
            {
                EcommerceAsinVisibility = false;
                EcommerceBullet1Visibility = false;
                EcommerceBullet2Visibility = false;
                EcommerceBullet3Visibility = false;
                EcommerceBullet4Visibility = false;
                EcommerceBullet5Visibility = false;
                EcommerceComponentsVisibility = false;
                EcommerceCostVisibility = false;
                EcommerceCountryofOriginVisibility = false;
                EcommerceExternalIdVisibility = false;
                EcommerceExternalIdTypeVisibility = false;
                EcommerceItemAliasVisibility = false;
                EcommerceItemHeightVisibility = false;
                EcommerceItemLengthVisibility = false;
                EcommerceItemNameVisibility = false;
                EcommerceItemWeightVisibility = false;
                EcommerceItemWidthVisibility = false;
                EcommerceModelNameVisibility = false;
                EcommercePackageHeightVisibility = false;
                EcommercePackageLengthVisibility = false;
                EcommercePackageWeightVisibility = false;
                EcommercePackageWidthVisibility = false;
                EcommercePageQtyVisibility = false;
                EcommerceProductCategoryVisibility = false;
                EcommerceProductDescriptionVisibility = false;
                EcommerceProductSubcategoryVisibility = false;
                EcommerceManufacturerNameVisibility = false;
                EcommerceMsrpVisibility = false;
                EcommerceSearchTermsVisibility = false;
                EcommerceSizeVisibility = false;
                EcommerceUpcVisibility = false;
                WarrantyVisibility = false;
                WarrantyCheckVisibility = false;
            }
        }

        /// <summary>
        ///     Flags all the image path values to true or false
        /// </summary>
        /// <param name="value"></param>
        public void SetImagePathVisibility(bool value)
        {
            if(value)
            {
                ImagePath1Visibility = true;
                ImagePath2Visibility = true;
                ImagePath3Visibility = true;
                ImagePath4Visibility = true;
                ImagePath5Visibility = true;
            }
            else
            {
                ImagePath1Visibility = false;
                ImagePath2Visibility = false;
                ImagePath3Visibility = false;
                ImagePath4Visibility = false;
                ImagePath5Visibility = false;
            }
        }

        /// <summary>
        ///     Flags all the peoplesoft values to true or false
        /// </summary>
        /// <param name="value"></param>
        public void SetPeoplesoftFieldVisibility(bool value)
        {
            if (value)
            {
                AccountingGroupVisibility = true;
                BillOfMaterialsVisibility = true;
                CasepackHeightVisibility = true;
                CasepackLengthVisibility = true;
                CasepackQtyVisibility = true;
                CasepackUpcVisibility = true;
                CasepackWidthVisibility = true;
                CasepackWeightVisibility = true;
                ColorVisibility = true;
                CountryOfOriginVisibility = true;
                CostProfileGroupVisibility = true;
                DefaultActualCostCadVisibility = true;
                DefaultActualCostUsdVisibility = true;
                DescriptionVisibility = true;
                DirectImportVisibility = true;
                DutyVisibility = true;
                EanVisibility = true;
                GpcVisibility = true;
                HeightVisibility = true;
                InnerpackHeightVisibility = true;
                InnerpackLengthVisibility = true;
                InnerpackQuantityVisibility = true;
                InnerpackUpcVisibility = true;
                InnerpackWidthVisibility = true;
                InnerpackWeightVisibility = true;
                IsbnVisibility = true;
                ItemCategoryVisibility = true;
                ItemFamilyVisibility = true;
                ItemGroupVisibility = true;
                LanguageVisibility = true;
                LengthVisibility = true;
                LicenseBeginDateVisibility = true;
                ListPriceCadVisibility = true;
                ListPriceMxnVisibility = true;
                ListPriceUsdVisibility = true;
                MfgSourceVisibility = true;
                MsrpVisibility = true;
                MsrpCadVisibility = true;
                MsrpMxnVisibility = true;
                PricingGroupVisibility = true;
                PrintOnDemandVisibility = true;
                ProductFormatVisibility = true;
                ProductGroupVisibility = true;
                ProductIdTranslationVisibility = true;
                ProductLineVisibility = true;
                ProductQtyVisibility = true;
                PsStatusVisibility = true;
                SatCodeVisibility = true;
                StandardCostVisibility = true;
                StatsCodeVisibility = true;
                TariffCodeVisibility = true;
                TerritoryVisibility = true;
                UdexVisibility = true;
                UpcVisibility = true;
                WeightVisibility = true;
                WidthVisibility = true;
            }
            else
            {
                AccountingGroupVisibility = false;
                BillOfMaterialsVisibility = false;
                CasepackHeightVisibility = false;
                CasepackLengthVisibility = false;
                CasepackQtyVisibility = false;
                CasepackUpcVisibility = false;
                CasepackWidthVisibility = false;
                CasepackWeightVisibility = false;
                ColorVisibility = false;
                CountryOfOriginVisibility = false;
                CostProfileGroupVisibility = false;
                DefaultActualCostCadVisibility = false;
                DefaultActualCostUsdVisibility = false;
                DescriptionVisibility = false;
                DirectImportVisibility = false;
                DutyVisibility = false;
                EanVisibility = false;
                GpcVisibility = false;
                HeightVisibility = false;
                InnerpackHeightVisibility = false;
                InnerpackLengthVisibility = false;
                InnerpackQuantityVisibility = false;
                InnerpackUpcVisibility = false;
                InnerpackWidthVisibility = false;
                InnerpackWeightVisibility = false;
                IsbnVisibility = false;
                ItemCategoryVisibility = false;
                ItemFamilyVisibility = false;
                ItemGroupVisibility = false;
                LanguageVisibility = false;
                LengthVisibility = false;
                LicenseBeginDateVisibility = false;
                ListPriceCadVisibility = false;
                ListPriceMxnVisibility = false;
                ListPriceUsdVisibility = false;
                MfgSourceVisibility = false;
                MsrpVisibility = false;
                MsrpCadVisibility = false;
                MsrpMxnVisibility = false;
                PricingGroupVisibility = false;
                PrintOnDemandVisibility = false;
                ProductFormatVisibility = false;
                ProductGroupVisibility = false;
                ProductIdTranslationVisibility = false;
                ProductLineVisibility = false;
                ProductQtyVisibility = false;
                PsStatusVisibility = false;
                SatCodeVisibility = false;
                StandardCostVisibility = false;
                StatsCodeVisibility = false;
                TariffCodeVisibility = false;
                TerritoryVisibility = false;
                UdexVisibility = false;
                UpcVisibility = false;
                WeightVisibility = false;
                WidthVisibility = false;
            }
        }

        /// <summary>
        ///     Flags all the sell on values to true or false
        /// </summary>
        /// <param name="value"></param>
        public void SetSellOnFieldVisibility(bool value)
        {
            if (value)
            {
                SellOnAllPostersVisibility = true;
                SellOnAmazonVisibility = true;
                SellOnAmazonSellerCentralVisibility = true;
                SellOnEcommerceVisibility = true;
                SellOnFanaticsVisibility = true;
                SellOnGuitarCenterVisibility = true;
                SellOnHayneedleVisibility = true;
                SellOnTargetVisibility = true;
                SellOnTrendsVisibility = true;
                SellOnWalmartVisibility = true;
                SellOnWayfairVisibility = true;
            }
            else
            {
                SellOnAllPostersVisibility = false;
                SellOnAmazonVisibility = false;
                SellOnAmazonSellerCentralVisibility = false;
                SellOnGuitarCenterVisibility = false;
                SellOnHayneedleVisibility = false;
                SellOnTargetVisibility = false;
                SellOnTrendsVisibility = false;
                SellOnWalmartVisibility = false;
                SellOnWayfairVisibility = false;
            }
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the OptionsViewModel
        /// </summary>
        /// <param name="optionService"></param>
        public OptionsViewModel(OptionService optionService)
        {
            this.OptionService = optionService ?? throw new ArgumentNullException("optionService");
            List<string> Permissions = this.OptionService.RetrievePermissions(GlobalData.UserName);
            if (Permissions.Count != 0)
            {
                this.EcommerceVisibility = Permissions.Contains("EcommerceCONTROL") ? "Visible" : "Hidden";
            }
            RetrieveAllOptions();
            this.HasUpdate = false;
        }

        #endregion // Constructor
    }
}
