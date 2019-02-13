using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OdinModels
{
    public class ItemObject : ICloneable, INotifyPropertyChanged
    {

        #region Events

        /// <summary>
        ///     This event is raised when a property of this object is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion // Events

        #region Properties

        #region Field Properties

        /// <summary>
        ///     Gets or sets the AccountingGroup
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
                    AccountingGroupUpdate = true;
                }
                _accountingGroup = value;
                OnPropertyChanged("AccountingGroup");


            }
        }
        private string _accountingGroup = string.Empty;

        /// <summary>
        ///     Track if item is active on the website
        /// </summary>
        public int Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }
        private int _active = 0;

        /// <summary>
        ///     Gets or sets the AltImageFile5
        /// </summary>
        public string AltImageFile1
        {
            get
            {
                return _altImageFile1;
            }
            set
            {
                if (_altImageFile1 != value) { AltImageFile1Update = true; }
                this.EcommerceImagePath2 = CreateEcommerceImageUrl(value);
                _altImageFile1 = value;
                OnPropertyChanged("AltImageFile1");
            }
        }
        private string _altImageFile1 = string.Empty;

        /// <summary>
        ///     Gets or sets the AltImageFile2
        /// </summary>
        public string AltImageFile2
        {
            get
            {
                return _altImageFile2;
            }
            set
            {
                if (_altImageFile2 != value) { AltImageFile2Update = true; }
                this.EcommerceImagePath3 = CreateEcommerceImageUrl(value);
                _altImageFile2 = value;
                OnPropertyChanged("AltImageFile2");
            }

        }
        private string _altImageFile2 = string.Empty;

        /// <summary>
        ///     Gets or sets the AltImageFile3
        /// </summary>
        public string AltImageFile3
        {
            get
            {
                return _altImageFile3;
            }
            set
            {
                if (_altImageFile3 != value) { AltImageFile3Update = true; }
                this.EcommerceImagePath4 = CreateEcommerceImageUrl(value);
                _altImageFile3 = value;
                OnPropertyChanged

                    ("AltImageFile3");

            }
        }
        private string _altImageFile3 = string.Empty;

        /// <summary>
        ///     Gets or sets the AltImageFile4
        /// </summary>
        public string AltImageFile4
        {
            get
            {
                return _altImageFile4;
            }
            set
            {
                if (_altImageFile4 != value) { AltImageFile4Update = true; }
                this.EcommerceImagePath5 = CreateEcommerceImageUrl(value);
                _altImageFile4 = value;
                OnPropertyChanged

                    ("AltImageFile4");

            }
        }
        private string _altImageFile4 = string.Empty;

        /// <summary>
        ///     Gets or sets the BillOfMaterials
        /// </summary>
        public List<ChildElement> BillOfMaterials
        {
            get
            {
                return _billOfMaterials;
            }
            set
            {
                if (_billOfMaterials != value) { BillOfMaterialsUpdate = true; }
                _billOfMaterials = value;
                BillOfMaterialsString = ReturnBillOfMaterials();
                OnPropertyChanged

                    ("BillOfMaterials");

            }
        }
        private List<ChildElement> _billOfMaterials = new List<ChildElement>();

        /// <summary>
        ///     Gets or sets the BillOfMaterialsString
        /// </summary>
        public string BillOfMaterialsString
        {
            get
            {
                return _billOfMaterialsString;
            }
            set
            {
                _billOfMaterialsString = value;
                OnPropertyChanged

                    ("BillOfMaterialsString");

            }
        }
        private string _billOfMaterialsString = string.Empty;

        /// <summary>
        ///     Gets or sets the CasepackHeight
        /// </summary>
        public string CasepackHeight
        {
            get
            {
                return _casepackHeight;
            }
            set
            {
                if (_casepackHeight != value) { CasepackHeightUpdate = true; }
                _casepackHeight = value;
                OnPropertyChanged

                    ("CasepackHeight");

            }
        }
        private string _casepackHeight = string.Empty;

        /// <summary>
        ///     Gets or sets the CasepackLength
        /// </summary>
        public string CasepackLength
        {
            get
            {
                return _casepackLength;
            }
            set
            {
                if (_casepackLength != value) { CasepackLengthUpdate = true; }
                _casepackLength = value;
                OnPropertyChanged

                    ("CasepackLength")
                    ;

            }
        }
        private string _casepackLength = string.Empty;

        /// <summary>
        ///     Gets or sets the CasepackQty
        /// </summary>
        public string CasepackQty
        {
            get
            {
                return _casepackQty;
            }
            set
            {
                if (_casepackQty != value) { CasepackQtyUpdate = true; }
                _casepackQty = value;
                OnPropertyChanged("CasepackQty");
            }
        }
        private string _casepackQty = string.Empty;

        /// <summary>
        ///     Gets or sets the CasepackUpc
        /// </summary>
        public string CasepackUpc
        {
            get
            {
                return _casepackUpc;
            }
            set
            {
                if (_casepackUpc != value) { CasepackUpcUpdate = true; }
                _casepackUpc = value;
                OnPropertyChanged("CasepackUpc");
            }
        }
        private string _casepackUpc = string.Empty;

        /// <summary>
        ///     Gets or sets the CasepackWidth
        /// </summary>
        public string CasepackWidth
        {
            get
            {
                return _casepackWidth;
            }
            set
            {
                if (_casepackWidth != value) { CasepackWidthUpdate = true; }
                _casepackWidth = value;
                OnPropertyChanged

                    ("CasepackWidth");

            }
        }
        private string _casepackWidth = string.Empty;

        /// <summary>
        ///     Gets or sets the CasepackWeight
        /// </summary>
        public string CasepackWeight
        {
            get
            {
                return _casepackWeight;
            }
            set
            {
                if (_casepackWeight != value) { CasepackWeightUpdate = true; }
                _casepackWeight = value;
                OnPropertyChanged("CasepackWeight");

            }
        }
        private string _casepackWeight = string.Empty;

        /// <summary>
        ///     Gets or sets the Category
        /// </summary>
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                if (_category != value) { CategoryUpdate = true; }
                _category = value;
                OnPropertyChanged

                    ("Category");

            }
        }
        private string _category = string.Empty;

        /// <summary>
        ///     Gets or sets the Category2
        /// </summary>
        public string Category2
        {
            get
            {
                return _category2;
            }
            set
            {
                if (_category2 != value) { Category2Update = true; }
                _category2 = value;
                OnPropertyChanged

                    ("Category2");

            }
        }
        private string _category2 = string.Empty;

        /// <summary>
        ///     Gets or sets the Category3
        /// </summary>
        public string Category3
        {
            get
            {
                return _category3;
            }
            set
            {
                if (_category3 != value) { Category3Update = true; }
                _category3 = value;
                OnPropertyChanged

                    ("Category3");

            }
        }
        private string _category3 = string.Empty;

        /// <summary>
        ///     Gets or sets the Color
        /// </summary>
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (_color != value) { ColorUpdate = true; }
                _color = value;
                OnPropertyChanged

                    ("Color");

            }
        }
        private string _color = string.Empty;

        /// <summary>
        ///     Gets or sets the CombinedCategories
        /// </summary>
        public string CombinedCategories
        {
            get
            {
                return _combinedCategories;
            }
            set
            {
                _combinedCategories = value;
                OnPropertyChanged

                    ("CombinedCategories");

            }
        }
        private string _combinedCategories = string.Empty;

        /// <summary>
        ///     Gets or sets the Copyright
        /// </summary>
        public string Copyright
        {
            get
            {
                return _copyright;
            }
            set
            {
                if (_copyright != value) { CopyrightUpdate = true; }
                _copyright = value;
                OnPropertyChanged

                    ("Copyright");

            }
        }
        private string _copyright = string.Empty;

        /// <summary>
        ///     Gets or sets the CostProfileGroup
        /// </summary>
        public string CostProfileGroup
        {
            get
            {
                return _costProfileGroup;
            }
            set
            {
                if (_costProfileGroup != value) { CostProfileGroupUpdate = true; }
                _costProfileGroup = value;
                OnPropertyChanged("CostProfileGroup");
            }
        }
        private string _costProfileGroup = string.Empty;

        /// <summary>
        ///     Gets or sets the CountryOfOrigin
        /// </summary>
        public string CountryOfOrigin
        {
            get
            {
                return _countryOfOrigin;
            }
            set
            {
                if (_countryOfOrigin != value) { CountryOfOriginUpdate = true; }
                _countryOfOrigin = value;
                OnPropertyChanged("CountryOfOrigin");
            }
        }
        private string _countryOfOrigin = string.Empty;

        /// <summary>
        ///     Gets or sets the DefaultActualCostCad
        /// </summary>
        public string DefaultActualCostCad
        {
            get
            {
                return _defaultActualCostCad;
            }
            set
            {
                if (_defaultActualCostCad != value) { DefaultActualCostCadUpdate = true; }
                _defaultActualCostCad = value;
                OnPropertyChanged("DefaultActualCostCad");

            }
        }
        private string _defaultActualCostCad = string.Empty;

        /// <summary>
        ///     Gets or sets the DefaultActualCostUsd
        /// </summary>
        public string DefaultActualCostUsd
        {
            get
            {
                return _defaultActualCostUsd;
            }
            set
            {
                if (_defaultActualCostUsd != value) { DefaultActualCostUsdUpdate = true; }
                _defaultActualCostUsd = value;
                OnPropertyChanged

                    ("DefaultActualCostUsd");

            }
        }
        private string _defaultActualCostUsd = string.Empty;

        /// <summary>
        ///     Gets or sets the Description
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description != value) { DescriptionUpdate = true; }
                _description = value;
                OnPropertyChanged

                    ("Description");

            }
        }
        private string _description = string.Empty;

        /// <summary>
        ///     Gets or sets the DirectImport
        /// </summary>
        public string DirectImport
        {
            get
            {
                return _directImport;
            }
            set
            {
                if (_directImport != value) { DirectImportUpdate = true; }
                _directImport = value;
                OnPropertyChanged

                    ("DirectImport");

            }
        }
        private string _directImport = string.Empty;

        /// <summary>
        ///     Gets or sets the Duty
        /// </summary>
        public string Duty
        {
            get
            {
                return _duty;
            }
            set
            {
                if (_duty != value) { DutyUpdate = true; }
                _duty = value;
                OnPropertyChanged

                    ("Duty");

            }
        }
        private string _duty = string.Empty;

        /// <summary>
        ///     Gets or sets the Ean
        /// </summary>
        public string Ean
        {
            get
            {
                return _ean;
            }
            set
            {
                if (_ean != value) { EanUpdate = true; }
                _ean = value;
                OnPropertyChanged

                    ("Ean");

            }
        }
        private string _ean = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceAsin
        /// </summary>
        public string EcommerceAsin
        {
            get
            {
                return _ecommerceasin;
            }
            set
            {
                if (_ecommerceasin != value) { EcommerceAsinUpdate = true; }
                _ecommerceasin = value;
                OnPropertyChanged

                    ("EcommerceAsin");

            }
        }
        private string _ecommerceasin = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceBullet1
        /// </summary>
        public string EcommerceBullet1
        {
            get
            {
                return _ecommercebullet1;
            }
            set
            {
                if (_ecommercebullet1 != value) { EcommerceBullet1Update = true; }
                _ecommercebullet1 = value;
                OnPropertyChanged

                    ("EcommerceBullet1");

            }
        }
        private string _ecommercebullet1 = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceBullet2
        /// </summary>
        public string EcommerceBullet2
        {
            get
            {
                return _ecommercebullet2;
            }
            set
            {
                if (_ecommercebullet2 != value) { EcommerceBullet2Update = true; }
                _ecommercebullet2 = value;
                OnPropertyChanged

                    ("EcommerceBullet2");

            }
        }
        private string _ecommercebullet2 = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceBullet3
        /// </summary>
        public string EcommerceBullet3
        {
            get
            {
                return _ecommercebullet3;
            }
            set
            {
                if (_ecommercebullet3 != value) { EcommerceBullet3Update = true; }
                _ecommercebullet3 = value;
                OnPropertyChanged

                    ("EcommerceBullet3");
            }

        }
        private string _ecommercebullet3 = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceBullet4
        /// </summary>
        public string EcommerceBullet4
        {
            get
            {
                return _ecommercebullet4;
            }
            set
            {
                if (_ecommercebullet4 != value) { EcommerceBullet4Update = true; }
                _ecommercebullet4 = value;
                OnPropertyChanged("EcommerceBullet4");

            }
        }
        private string _ecommercebullet4 = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceBullet5
        /// </summary>
        public string EcommerceBullet5
        {
            get
            {
                return _ecommercebullet5;
            }
            set
            {
                if (_ecommercebullet5 != value) { EcommerceBullet5Update = true; }
                _ecommercebullet5 = value;
                OnPropertyChanged("EcommerceBullet5");

            }
        }
        private string _ecommercebullet5 = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceComponents
        /// </summary>
        public string EcommerceComponents
        {
            get
            {
                return _ecommercecomponents;
            }
            set
            {
                if (_ecommercecomponents != value) { EcommerceComponentsUpdate = true; }
                _ecommercecomponents = value;
                OnPropertyChanged

                    ("EcommerceComponents");

            }
        }
        private string _ecommercecomponents = string.Empty;

        /// <summary>
        ///     Gets or sets the amazon cost
        /// </summary>
        public string EcommerceCost
        {
            get
            {
                return _ecommercecost;
            }
            set
            {
                if (_ecommercecost != value) { EcommerceCostUpdate = true; }
                _ecommercecost = value;
                OnPropertyChanged

                    ("EcommerceCost");

            }
        }
        private string _ecommercecost = string.Empty;

        /// <summary>
        ///     Gets or sets the country of origin ecommerce value
        /// </summary>
        public string EcommerceCountryofOrigin
        {
            get
            {
                return _ecommercecountryofOrigin;
            }
            set
            {
                if (_ecommercecountryofOrigin != value) { EcommerceCountryofOriginUpdate = true; }
                _ecommercecountryofOrigin = value;
                OnPropertyChanged

                    ("EcommerceCountryofOrigin");

            }
        }
        private string _ecommercecountryofOrigin = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceExternalId
        /// </summary>
        public string EcommerceExternalId
        {
            get
            {
                return _ecommerceexternalID;
            }
            set
            {
                if (_ecommerceexternalID != value) { EcommerceExternalIdUpdate = true; }
                _ecommerceexternalID = value;
                OnPropertyChanged

                    ("EcommerceExternalId");

            }
        }
        private string _ecommerceexternalID = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceExternalIdType
        /// </summary>
        public string EcommerceExternalIdType
        {
            get
            {
                return _ecommerceexternalIdType;
            }
            set
            {
                if (_ecommerceexternalIdType != value) { EcommerceExternalIdTypeUpdate = true; }
                _ecommerceexternalIdType = value;
                OnPropertyChanged

                    ("EcommerceExternalIdType");

            }
        }
        private string _ecommerceexternalIdType = string.Empty;

        /// <summary>
        ///     Generic Keywords (formery ecommerce search terms) for external ecommerce sites
        /// </summary>
        public string EcommerceGenericKeywords
        {
            get
            {
                return _genericKeywords;
            }
            set
            {
                if (_genericKeywords != value) { EcommerceGenericKeywordsUpdate = true; }
                _genericKeywords = value;
                OnPropertyChanged

                    ("EcommerceGenericKeywords");

            }
        }
        private string _genericKeywords = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceImagePath1
        /// </summary>
        public string EcommerceImagePath1
        {
            get
            {
                return _ecommerceimagePath1;
            }
            set
            {
                if (_ecommerceimagePath1 != value) { EcommerceImagePath1Update = true; }
                _ecommerceimagePath1 = value;
                OnPropertyChanged
                    ("EcommerceImagePath1");

            }
        }
        private string _ecommerceimagePath1 = string.Empty;

        /// <summary>
        ///     Gets or sets the AltImageFile4
        /// </summary>
        public string EcommerceImagePath2
        {
            get
            {
                return _ecommerceimagePath2;
            }
            set
            {
                if (_ecommerceimagePath2 != value) { EcommerceImagePath2Update = true; }
                _ecommerceimagePath2 = value;
                OnPropertyChanged

                    ("EcommerceImagePath2");

            }
        }
        private string _ecommerceimagePath2 = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceImagePath3
        /// </summary>
        public string EcommerceImagePath3
        {
            get
            {
                return _ecommerceimagePath3;
            }
            set
            {
                if (_ecommerceimagePath3 != value) { EcommerceImagePath3Update = true; }
                _ecommerceimagePath3 = value;
                OnPropertyChanged
                    ("EcommerceImagePath3");

            }
        }
        private string _ecommerceimagePath3 = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceImagePath4
        /// </summary>
        public string EcommerceImagePath4
        {
            get
            {
                return _ecommerceimagePath4;
            }
            set
            {
                if (_ecommerceimagePath4 != value) { EcommerceImagePath4Update = true; }
                _ecommerceimagePath4 = value;
                OnPropertyChanged

                    ("EcommerceImagePath4");

            }
        }
        private string _ecommerceimagePath4 = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceImagePath5
        /// </summary>
        public string EcommerceImagePath5
        {
            get
            {
                return _ecommerceimagePath5;
            }
            set
            {
                if (_ecommerceimagePath5 != value) { EcommerceImagePath5Update = true; }
                _ecommerceimagePath5 = value;
                OnPropertyChanged
                    ("EcommerceImagePath5");

            }
        }
        private string _ecommerceimagePath5 = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceItemHeight
        /// </summary>
        public string EcommerceItemHeight
        {
            get
            {
                return _ecommerceitemHeight;
            }
            set
            {
                if (_ecommerceitemHeight != value) { EcommerceItemHeightUpdate = true; }
                _ecommerceitemHeight = value;
                OnPropertyChanged
                    ("EcommerceItemHeight");

            }
        }
        private string _ecommerceitemHeight = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceItemLength
        /// </summary>
        public string EcommerceItemLength
        {
            get
            {
                return _ecommerceitemLength;
            }
            set
            {
                if (_ecommerceitemLength != value) { EcommerceItemLengthUpdate = true; }
                _ecommerceitemLength = value;
                OnPropertyChanged

                    ("EcommerceItemLength");

            }
        }
        private string _ecommerceitemLength = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceItemName
        /// </summary>
        public string EcommerceItemName
        {
            get
            {
                return _ecommerceitemName;
            }
            set
            {
                if (_ecommerceitemName != value) { EcommerceItemNameUpdate = true; }
                _ecommerceitemName = value;
                OnPropertyChanged
                    ("EcommerceItemName");

            }
        }
        private string _ecommerceitemName = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceItemTypeKeywords
        /// </summary>
        public string EcommerceItemTypeKeywords
        {
            get
            {
                return _ecommerceItemTypeKeywords;
            }
            set
            {
                if (_ecommerceItemTypeKeywords != value) { EcommerceItemTypeKeywordsUpdate = true; }
                _ecommerceItemTypeKeywords = value;
                OnPropertyChanged("EcommerceItemTypeKeywords");

            }
        }
        private string _ecommerceItemTypeKeywords = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceItemWeight
        /// </summary>
        public string EcommerceItemWeight
        {
            get
            {
                return _ecommerceitemWeight;
            }
            set
            {
                if (_ecommerceitemWeight != value) { EcommerceItemWeightUpdate = true; }
                _ecommerceitemWeight = value;
                OnPropertyChanged("EcommerceItemWeight");
            }
        }
        private string _ecommerceitemWeight = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceItemWidth
        /// </summary>
        public string EcommerceItemWidth
        {
            get
            {
                return _ecommerceitemWidth;
            }
            set
            {
                if (_ecommerceitemWidth != value) { EcommerceItemWidthUpdate = true; }
                _ecommerceitemWidth = value;
                OnPropertyChanged

                    ("EcommerceItemWidth");

            }
        }
        private string _ecommerceitemWidth = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceModelName
        /// </summary>
        public string EcommerceModelName
        {
            get
            {
                return _ecommercemodelName;
            }
            set
            {
                if (_ecommercemodelName != value) { EcommerceModelNameUpdate = true; }
                _ecommercemodelName = value;
                OnPropertyChanged

                    ("EcommerceModelName");

            }
        }
        private string _ecommercemodelName = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommercePackageHeight
        /// </summary>
        public string EcommercePackageHeight
        {
            get
            {
                return _ecommercepackageHeight;
            }
            set
            {
                if (_ecommercepackageHeight != value) { EcommercePackageHeightUpdate = true; }
                _ecommercepackageHeight = value;
                OnPropertyChanged

                    ("EcommercePackageHeight");

            }
        }
        private string _ecommercepackageHeight = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommercePackageLength
        /// </summary>
        public string EcommercePackageLength
        {
            get
            {
                return _ecommercepackageLength;
            }
            set
            {
                if (_ecommercepackageLength != value) { EcommercePackageLengthUpdate = true; }
                _ecommercepackageLength = value;
                OnPropertyChanged

                    ("EcommercePackageLength");

            }
        }
        private string _ecommercepackageLength = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommercePackageWeight
        /// </summary>
        public string EcommercePackageWeight
        {
            get
            {
                return _ecommercepackageWeight;
            }
            set
            {
                if (_ecommercepackageWeight != value) { EcommercePackageWeightUpdate = true; }
                _ecommercepackageWeight = value;
                OnPropertyChanged

                    ("EcommercePackageWeight");

            }
        }
        private string _ecommercepackageWeight = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommercePackageWidth
        /// </summary>
        public string EcommercePackageWidth
        {
            get
            {
                return _ecommercepackageWidth;
            }
            set
            {
                if (_ecommercepackageWidth != value) { EcommercePackageWidthUpdate = true; }
                _ecommercepackageWidth = value;
                OnPropertyChanged

                    ("EcommercePackageWidth");

            }
        }
        private string _ecommercepackageWidth = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommercePageQty
        /// </summary>
        public string EcommercePageQty
        {
            get
            {
                return _ecommercepageQty;
            }
            set
            {
                if (_ecommercepageQty != value) { EcommercePageQtyUpdate = true; }
                _ecommercepageQty = value;
                OnPropertyChanged("EcommercePageQty");                

            }
        }
        private string _ecommercepageQty = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceParentAsin
        /// </summary>
        public string EcommerceParentAsin
        {
            get
            {
                return _ecommerceParentAsin;
            }
            set
            {
                if (_ecommerceParentAsin != value) { EcommerceParentAsinUpdate = true; }
                _ecommerceParentAsin = value;
                OnPropertyChanged("EcommerceParentAsin");
            }
        }
        private string _ecommerceParentAsin = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceProductCategory
        /// </summary>
        public string EcommerceProductCategory
        {
            get
            {
                return _ecommerceproductCategory;
            }
            set
            {
                if (_ecommerceproductCategory != value) { EcommerceProductCategoryUpdate = true; }
                _ecommerceproductCategory = value;
                OnPropertyChanged

                    ("EcommerceProductCategory");

            }
        }
        private string _ecommerceproductCategory = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceProductDescription
        /// </summary>
        public string EcommerceProductDescription
        {
            get
            {
                return _ecommerceproductDescription;
            }
            set
            {
                if (_ecommerceproductDescription != value) { EcommerceProductDescriptionUpdate = true; }
                _ecommerceproductDescription = value;
                OnPropertyChanged

                    ("EcommerceProductDescription");

            }
        }
        private string _ecommerceproductDescription = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceProductSubcategory
        /// </summary>
        public string EcommerceProductSubcategory
        {
            get
            {
                return _ecommerceproductSubcategory;
            }
            set
            {
                if (_ecommerceproductSubcategory != value) { EcommerceProductSubcategoryUpdate = true; }
                _ecommerceproductSubcategory = value;
                OnPropertyChanged

                    ("EcommerceProductSubcategory");

            }
        }
        private string _ecommerceproductSubcategory = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceManufacturerName
        /// </summary>
        public string EcommerceManufacturerName
        {
            get
            {
                return _ecommercemanufacturerName;
            }
            set
            {
                if (_ecommercemanufacturerName != value) { EcommerceManufacturerNameUpdate = true; }
                _ecommercemanufacturerName = value;
                OnPropertyChanged

                    ("EcommerceManufacturerName");

            }
        }
        private string _ecommercemanufacturerName = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceMsrp
        /// </summary>
        public string EcommerceMsrp
        {
            get
            {
                return _ecommercemsrp;
            }
            set
            {
                if (_ecommercemsrp != value) { EcommerceMsrpUpdate = true; }
                _ecommercemsrp = value;
                OnPropertyChanged

                    ("EcommerceMsrp");

            }
        }
        private string _ecommercemsrp = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceSize
        /// </summary>
        public string EcommerceSize
        {
            get
            {
                return _ecommercesize;
            }
            set
            {
                if (_ecommercesize != value) { EcommerceSizeUpdate = true; }
                _ecommercesize = value;
                OnPropertyChanged("EcommerceSize");
            }
        }
        private string _ecommercesize = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceSubjectKeywords
        /// </summary>
        public string EcommerceSubjectKeywords
        {
            get
            {
                return _subjectKeywords;
            }
            set
            {
                if (_subjectKeywords != value) { EcommerceSubjectKeywordsUpdate = true; }
                _subjectKeywords = value;
                OnPropertyChanged

                    ("EcommerceSubjectKeywords");

            }
        }
        private string _subjectKeywords = string.Empty;

        /// <summary>
        ///     Gets or sets the EcommerceUpc
        /// </summary>
        public string EcommerceUpc
        {
            get
            {
                return _ecommerceupc;
            }
            set
            {
                if (_ecommerceupc != value) { EcommerceUpcUpdate = true; }
                _ecommerceupc = value;
                OnPropertyChanged("EcommerceUpc");
            }
        }
        private string _ecommerceupc = string.Empty;

        /// <summary>
        ///     Gets or sets the Gpc
        /// </summary>
        public string Gpc
        {
            get
            {
                return _gpc;
            }
            set
            {
                if (_gpc != value) { GpcUpdate = true; }
                _gpc = value;
                OnPropertyChanged("Gpc");

            }
        }
        private string _gpc = string.Empty;

        /// <summary>
        ///     Gets or sets the Height
        /// </summary>
        public string Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (_height != value) { HeightUpdate = true; }
                _height = value;
                OnPropertyChanged
                    ("Height");

            }
        }
        private string _height = string.Empty;

        /// <summary>
        ///     Gets or sets the ImagePath
        /// </summary>
        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                if (_imagePath != value) { ImagePathUpdate = true; }
                this.EcommerceImagePath1 = CreateEcommerceImageUrl(value);
                _imagePath = value;
                OnPropertyChanged("ImagePath");

            }
        }
        private string _imagePath = string.Empty;

        /// <summary>
        ///     Gets or sets the InnerpackHeight
        /// </summary>
        public string InnerpackHeight
        {
            get
            {
                return _innerpackHeight;
            }
            set
            {
                if (_innerpackHeight != value) { InnerpackHeightUpdate = true; }
                _innerpackHeight = value;
                OnPropertyChanged
                    ("InnerpackHeight");

            }
        }
        private string _innerpackHeight = string.Empty;

        /// <summary>
        ///     Gets or sets the InnerpackLength
        /// </summary>
        public string InnerpackLength
        {
            get
            {
                return _innerpackLength;
            }
            set
            {
                if (_innerpackLength != value) { InnerpackLengthUpdate = true; }
                _innerpackLength = value;
                OnPropertyChanged

                    ("InnerpackLength");

            }
        }
        private string _innerpackLength = string.Empty;

        /// <summary>
        ///     Gets or sets the InnerpackQuantity
        /// </summary>
        public string InnerpackQuantity
        {
            get
            {
                return _innerpackQuantity;
            }
            set
            {
                if (_innerpackQuantity != value) { InnerpackQuantityUpdate = true; }
                _innerpackQuantity = value;
                OnPropertyChanged
                    ("InnerpackQuantity");

            }
        }
        private string _innerpackQuantity = string.Empty;

        /// <summary>
        ///     Gets or set the item objects innerpack UPC
        /// </summary>
        public string InnerpackUpc
        {
            get
            {
                return _innerpackUpc;
            }
            set
            {
                if (_innerpackUpc != value) { InnerpackUpcUpdate = true; }
                _innerpackUpc = value;
                OnPropertyChanged

                    ("InnerpackUpc");

            }
        }
        private string _innerpackUpc = string.Empty;

        /// <summary>
        ///     Gets or sets the InnerpackWidth
        /// </summary>
        public string InnerpackWidth
        {
            get
            {
                return _innerpackWidth;
            }
            set
            {
                if (_innerpackWidth != value) { InnerpackWidthUpdate = true; }
                _innerpackWidth = value;
                OnPropertyChanged

                    ("InnerpackWidth");

            }
        }
        private string _innerpackWidth = string.Empty;

        /// <summary>
        ///     Gets or sets the InnerpackWeight
        /// </summary>
        public string InnerpackWeight
        {
            get
            {
                return _innerpackWeight;
            }
            set
            {
                if (_innerpackWeight != value) { InnerpackWeightUpdate = true; }
                _innerpackWeight = value;
                OnPropertyChanged

                    ("InnerpackWeight");

            }
        }
        private string _innerpackWeight = string.Empty;

        /// <summary>
        ///     Gets or sets the InStockDate
        /// </summary>
        public string InStockDate
        {
            get
            {
                return _inStockDate;
            }
            set
            {
                if (_inStockDate != value) { InStockDateUpdate = true; }
                _inStockDate = value;
                OnPropertyChanged
                    ("InStockDate");

            }
        }
        private string _inStockDate = string.Empty;

        /// <summary>
        ///     Gets or sets the Isbn
        /// </summary>
        public string Isbn
        {
            get
            {
                return _isbn;
            }
            set
            {
                if (_isbn != value) { IsbnUpdate = true; }
                _isbn = value;
                OnPropertyChanged

                    ("Isbn");

            }
        }
        private string _isbn = string.Empty;

        /// <summary>
        ///     Gets or sets the ItemCategory
        /// </summary>
        public string ItemCategory
        {
            get
            {
                return _itemCategory;
            }
            set
            {
                if (_itemCategory != value) { ItemCategoryUpdate = true; }
                _itemCategory = value;
                OnPropertyChanged
                    ("ItemCategory");

            }
        }
        private string _itemCategory = string.Empty;

        /// <summary>
        ///     Gets or sets the ItemFamily
        /// </summary>
        public string ItemFamily
        {
            get
            {
                return _itemFamily;
            }
            set
            {
                if (_itemFamily != value) { ItemFamilyUpdate = true; }
                _itemFamily = value;
                OnPropertyChanged

                    ("ItemFamily");

            }
        }
        private string _itemFamily = string.Empty;

        /// <summary>
        ///     Gets or sets the ItemGroup
        /// </summary>
        public string ItemGroup
        {
            get
            {
                return _itemGroup;
            }
            set
            {
                if (_itemGroup != value) { ItemGroupUpdate = true; }
                _itemGroup = value;
                OnPropertyChanged
                    ("ItemGroup");

            }
        }
        private string _itemGroup = string.Empty;

        /// <summary>
        ///     Gets or sets the ItemId
        /// </summary>
        public string ItemId
        {
            get
            {
                return _itemId;
            }
            set
            {
                _itemId = value;
                OnPropertyChanged

                    ("ItemId");

            }
        }
        private string _itemId = string.Empty;

        /// <summary>
        ///     Gets or sets the ItemKeywords
        /// </summary>
        public string ItemKeywords
        {
            get
            {
                return _itemKeywords;
            }
            set
            {
                if (_itemKeywords != value) { ItemKeywordsUpdate = true; }
                _itemKeywords = value;
                OnPropertyChanged

                    ("ItemKeywords");

            }
        }
        private string _itemKeywords = string.Empty;

        /// <summary>
        ///     Gets or sets the Language
        /// </summary>
        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                if (_language != value) { LanguageUpdate = true; }
                _language = value;
                OnPropertyChanged

                    ("Language");

            }
        }
        private string _language = string.Empty;

        /// <summary>
        ///     Gets or sets the Length
        /// </summary>
        public string Length
        {
            get
            {
                return _length;
            }
            set
            {
                if (_length != value) { LengthUpdate = true; }
                _length = value;
                OnPropertyChanged

                    ("Length");

            }
        }
        private string _length = string.Empty;

        /// <summary>
        ///     Gets or sets the License
        /// </summary>
        public string License
        {
            get
            {
                return _license;
            }
            set
            {
                if (_license != value) { LicenseUpdate = true; }
                _license = value;
                OnPropertyChanged

                    ("License");

            }
        }
        private string _license = string.Empty;

        /// <summary>
        ///     Gets or sets the LicenseBeginDate
        /// </summary>
        public string LicenseBeginDate
        {
            get
            {
                return _licenseBeginDate;
            }
            set
            {
                if (_licenseBeginDate != value) { LicenseBeginDateUpdate = true; }
                _licenseBeginDate = value;
                OnPropertyChanged

                    ("LicenseBeginDate");

            }
        }
        private string _licenseBeginDate = string.Empty;

        /// <summary>
        ///     Gets or sets the ListPriceCad
        /// </summary>
        public string ListPriceCad
        {
            get
            {
                return _listPriceCad;
            }
            set
            {
                if (_listPriceCad != value) { ListPriceCadUpdate = true; }
                _listPriceCad = value;
                OnPropertyChanged

                    ("ListPriceCad");

            }
        }
        private string _listPriceCad = string.Empty;

        /// <summary>
        ///     Gets or sets the ListPriceMxn
        /// </summary>
        public string ListPriceMxn
        {
            get
            {
                return _listPriceMxn;
            }
            set
            {
                if (_listPriceMxn != value) { ListPriceMxnUpdate = true; }
                _listPriceMxn = value;
                OnPropertyChanged
                    ("ListPriceMxn");

            }
        }
        private string _listPriceMxn = string.Empty;

        /// <summary>
        ///     Gets or sets the ListPriceUsd
        /// </summary>
        public string ListPriceUsd
        {
            get
            {
                return _listPriceUsd;
            }
            set
            {
                if (_listPriceUsd != value) { ListPriceUsdUpdate = true; }
                _listPriceUsd = value;
                OnPropertyChanged("ListPriceUsd");
            }
        }
        private string _listPriceUsd = string.Empty;

        /// <summary>
        ///     Gets or sets the MetaDescription
        /// </summary>
        public string MetaDescription
        {
            get
            {
                return _metaDescription;
            }
            set
            {
                if (_metaDescription != value) { MetaDescriptionUpdate = true; }
                _metaDescription = value;
                OnPropertyChanged("MetaDescription");
            }
        }
        private string _metaDescription = string.Empty;

        /// <summary>
        ///     Gets or sets the MfgSource
        /// </summary>
        public string MfgSource
        {
            get
            {
                return _mfgSource;
            }
            set
            {
                if (_mfgSource != value) { MfgSourceUpdate = true; }
                _mfgSource = value;
                OnPropertyChanged("MfgSource");
            }
        }
        private string _mfgSource = string.Empty;

        /// <summary>
        ///     Gets or sets the Msrp
        /// </summary>
        public string Msrp
        {
            get
            {
                return _msrp;
            }
            set
            {
                if (_msrp != value) { MsrpUpdate = true; }
                _msrp = value;
                OnPropertyChanged("Msrp");
            }
        }
        private string _msrp = string.Empty;

        /// <summary>
        ///     Gets or sets the MsrpCad
        /// </summary>
        public string MsrpCad
        {
            get
            {
                return _msrpCad;
            }
            set
            {
                if (_msrpCad != value) { MsrpCadUpdate = true; }
                _msrpCad = value;
                OnPropertyChanged("MsrpCad");
            }
        }
        private string _msrpCad = string.Empty;

        /// <summary>
        ///     Gets or sets the MsrpMxn
        /// </summary>
        public string MsrpMxn
        {
            get
            {
                return _msrpMxn;
            }
            set
            {
                if (_msrpMxn != value) { MsrpMxnUpdate = true; }
                _msrpMxn = value;
                OnPropertyChanged("MsrpMxn");
            }
        }
        private string _msrpMxn = string.Empty;

        /// <summary>
        ///     Gets or set the OnSite value. Flag for determining if the item has already been uploaded to trendsinternational.com.
        ///     User cannot edit this field. Switched upon admin exporting web excel.
        /// </summary>
        public string OnSite
        {
            get
            {
                return _onSite;
            }
            set
            {
                _onSite = value;
                OnPropertyChanged("OnSite");
            }
        }
        private string _onSite = string.Empty;

        /// <summary>
        ///     Gets or sets the PricingGroup
        /// </summary>
        public string PricingGroup
        {
            get
            {
                return _pricingGroup;
            }
            set
            {
                if (_pricingGroup != value) { PricingGroupUpdate = true; }
                _pricingGroup = value;
                OnPropertyChanged("PricingGroup");
            }
        }
        private string _pricingGroup = string.Empty;

        /// <summary>
        ///     Gets or sets the PrintOnDemand
        /// </summary>
        public string PrintOnDemand
        {
            get
            {
                return _printOnDemand;
            }
            set
            {
                if (_printOnDemand != value) { PrintOnDemandUpdate = true; }
                _printOnDemand = value;
                OnPropertyChanged("PrintOnDemand");
            }
        }
        private string _printOnDemand = "";

        /// <summary>
        ///     Gets or sets the ProductFormat
        /// </summary>
        public string ProductFormat
        {
            get
            {
                return _productFormat;
            }
            set
            {
                if (_productFormat != value) { ProductFormatUpdate = true; }
                _productFormat = value;
                OnPropertyChanged("ProductFormat");
            }
        }
        private string _productFormat = string.Empty;

        /// <summary>
        ///     Gets or sets the ProductGroup
        /// </summary>
        public string ProductGroup
        {
            get
            {
                return _productGroup;
            }
            set
            {
                if (_productGroup != value) { ProductGroupUpdate = true; }
                _productGroup = value;
                OnPropertyChanged("ProductGroup");
            }
        }
        private string _productGroup = string.Empty;

        /// <summary>
        ///     List of Product Id Translations associated with this item object
        /// </summary>
        public List<ChildElement> ProductIdTranslation
        {
            get
            {
                return _productIdTranslation;
            }
            set
            {
                if (_productIdTranslation != value) { ProductIdTranslationUpdate = true; }
                _productIdTranslation = value;
                ProductIdTranslationString = ReturnProductIdTranslations();
                OnPropertyChanged("ProductIdTranslation");
            }
        }
        private List<ChildElement> _productIdTranslation = new List<ChildElement>();

        /// <summary>
        ///     Gets or sets the ProductIdTranslationString
        /// </summary>
        public string ProductIdTranslationString
        {
            get
            {
                return _productIdTranslationString;
            }
            set
            {
                _productIdTranslationString = value;
                OnPropertyChanged("ProductIdTranslationString");
            }
        }
        private string _productIdTranslationString = string.Empty;

        /// <summary>
        ///     Gets or sets the ProductLine
        /// </summary>
        public string ProductLine
        {
            get
            {
                return _productLine;
            }
            set
            {
                if (_productLine != value) { ProductLineUpdate = true; }
                _productLine = value;
                OnPropertyChanged("ProductLine");
            }
        }
        private string _productLine = string.Empty;

        /// <summary>
        ///     Gets or sets the ProductQty
        /// </summary>
        public string ProductQty
        {
            get
            {
                return _productQty;
            }
            set
            {
                if (_productQty != value) { ProductQtyUpdate = true; }
                _productQty = value;

                OnPropertyChanged("ProductQty");

            }
        }
        private string _productQty = string.Empty;

        /// <summary>
        ///     Gets or sets the property
        /// </summary>
        public string Property
        {
            get
            {
                return _property;
            }
            set
            {
                if (_property != value) { PropertyUpdate = true; }
                _property = value;
                OnPropertyChanged("Property");

            }
        }
        private string _property = string.Empty;

        /// <summary>
        ///     Gets or sets the PsStatus
        /// </summary>
        public string PsStatus
        {
            get
            {
                return _psStatus;
            }
            set
            {
                if (_psStatus != value) { PsStatusUpdate = true; }
                _psStatus = value;
                OnPropertyChanged("PsStatus");

            }
        }
        private string _psStatus = string.Empty;

        /// <summary>
        ///     Gets or sets the satcode
        /// </summary>
        public string SatCode
        {
            get
            {
                return _satCode;
            }
            set
            {
                if (_satCode != value) { SatCodeUpdate = true; }
                _satCode = value;
                OnPropertyChanged("SatCode");

            }
        }
        private string _satCode = string.Empty;

        /// <summary>
        ///     Gets or sets the SellOnAttributes field
        /// </summary>
        public List<string> SellOnAttributes
        {
            get
            {
                return _sellOnAttributes;
            }
            set
            {
                if (_sellOnAttributes != value) { SellOnAttributesUpdate = true; }
                _sellOnAttributes = value;
                OnPropertyChanged("SellOnAttributes");

            }
        }
        private List<string> _sellOnAttributes = new List<string>();

        /// <summary>
        ///     Gets or sets the SellOnAllPosters field
        /// </summary>
        public string SellOnAllPosters
        {
            get
            {
                return _sellOnAllPosters;
            }
            set
            {
                if (_sellOnAllPosters != value) { SellOnAllPostersUpdate = true; }
                _sellOnAllPosters = value;
                OnPropertyChanged("SellOnAllPosters");
            }
        }
        private string _sellOnAllPosters = "";

        /// <summary>
        ///     Gets or sets the SellOnAmazon field
        /// </summary>
        public string SellOnAmazon
        {
            get
            {
                return _sellOnAmazon;
            }
            set
            {
                if (_sellOnAmazon != value) { SellOnAmazonUpdate = true; }
                _sellOnAmazon = value;
                OnPropertyChanged("SellOnAmazon");
            }
        }
        private string _sellOnAmazon = "";

        /// <summary>
        ///     Gets or sets the SellOnAmazonSellerCentral field
        /// </summary>
        public string SellOnAmazonSellerCentral
        {
            get
            {
                return _sellOnAmazonSellerCentral;
            }
            set
            {
                if (_sellOnAmazonSellerCentral != value) { SellOnAmazonSellerCentralUpdate = true; }
                _sellOnAmazonSellerCentral = value;
                OnPropertyChanged("SellOnAmazonSellerCentral");
            }
        }
        private string _sellOnAmazonSellerCentral = "";

        /// <summary>
        ///     Gets or sets the SellOnEcommerce field
        /// </summary>
        public string SellOnEcommerce
        {
            get
            {
                return _sellOnEcommerce;
            }
            set
            {
                if (_sellOnEcommerce != value) { SellOnEcommerceUpdate = true; }
                _sellOnEcommerce = value;
                OnPropertyChanged("SellOnEcommerce");
            }
        }
        private string _sellOnEcommerce = "";

        /// <summary>
        ///     Gets or sets the SellOnFanatics field
        /// </summary>
        public string SellOnFanatics
        {
            get
            {
                return _sellOnFanatics;
            }
            set
            {
                if (_sellOnFanatics != value) { SellOnFanaticsUpdate = true; }
                _sellOnFanatics = value;
                OnPropertyChanged("SellOnFanatics");
            }
        }
        private string _sellOnFanatics = "";

        /// <summary>
        ///     Gets or sets the SellOnGuitarCenter field
        /// </summary>
        public string SellOnGuitarCenter
        {
            get
            {
                return _sellOnGuitarCenter;
            }
            set
            {
                if (_sellOnGuitarCenter != value) { SellOnGuitarCenterUpdate = true; }
                _sellOnGuitarCenter = value;
                OnPropertyChanged("SellOnGuitarCenter");
            }
        }
        private string _sellOnGuitarCenter = "";

        /// <summary>
        ///     Gets or sets the SellOnHayneedle field
        /// </summary>
        public string SellOnHayneedle
        {
            get
            {
                return _sellOnHayneedle;
            }
            set
            {
                if (_sellOnHayneedle != value) { SellOnHayneedleUpdate = true; }
                _sellOnHayneedle = value;
                OnPropertyChanged("SellOnHayneedle");
            }
        }
        private string _sellOnHayneedle = "";

        /// <summary>
        ///     Gets or sets the SellOnTarget
        /// </summary>
        public string SellOnTarget
        {
            get
            {
                return _sellOnTarget;
            }
            set
            {
                if (_sellOnTarget != value) { SellOnTargetUpdate = true; }
                _sellOnTarget = value;
                OnPropertyChanged("SellOnTarget");

            }
        }
        private string _sellOnTarget = "";

        /// <summary>
        ///     Gets or sets the SellOnTrends
        /// </summary>
        public string SellOnTrends
        {
            get
            {
                return _sellOnTrends;
            }
            set
            {
                if (_sellOnTrends != value) { SellOnTrendsUpdate = true; }
                _sellOnTrends = value;
                OnPropertyChanged("SellOnTrends");
            }
        }
        private string _sellOnTrends = "";

        /// <summary>
        ///     Gets or sets the SellOnWalmart
        /// </summary>
        public string SellOnWalmart
        {
            get
            {
                return _sellOnWalmart;
            }
            set
            {
                if (_sellOnWalmart != value) { SellOnWalmartUpdate = true; }
                _sellOnWalmart = value;
                OnPropertyChanged("SellOnWalmart");

            }
        }
        private string _sellOnWalmart = "";

        /// <summary>
        ///     Gets or sets the SellOnWayfair
        /// </summary>
        public string SellOnWayfair
        {
            get
            {
                return _sellOnWayfair;
            }
            set
            {
                if (_sellOnWayfair != value) { SellOnWayfairUpdate = true; }
                _sellOnWayfair = value;
                OnPropertyChanged("SellOnWayfair");

            }
        }
        private string _sellOnWayfair = "";

        /// <summary>
        ///     Gets or sets the ShortDescription
        /// </summary>
        public string ShortDescription
        {
            get
            {
                return _shortDescription;
            }
            set
            {
                if (_shortDescription != value) { ShortDescriptionUpdate = true; }
                _shortDescription = value;
                OnPropertyChanged("ShortDescription");

            }
        }
        private string _shortDescription = string.Empty;

        /// <summary>
        ///     Gets or sets the Size
        /// </summary>
        public string Size
        {
            get
            {
                return _size;
            }
            set
            {
                if (_size != value) { SizeUpdate = true; }
                _size = value;
                OnPropertyChanged("Size");

            }
        }
        private string _size = string.Empty;

        /// <summary>
        ///     Gets or sets the StandardCost
        /// </summary>
        public string StandardCost
        {
            get
            {
                return _standardCost;
            }
            set
            {
                if (_standardCost != value) { StandardCostUpdate = true; }
                _standardCost = value;
                OnPropertyChanged("StandardCost");
            }
        }
        private string _standardCost = string.Empty;

        /// <summary>
        ///     Gets or sets the StatsCode
        /// </summary>
        public string StatsCode
        {
            get
            {
                return _statsCode;
            }
            set
            {
                if (_statsCode != value) { StatsCodeUpdate = true; }
                _statsCode = value;
                OnPropertyChanged("StatsCode");

            }
        }
        private string _statsCode = string.Empty;

        /// <summary>
        ///     Gets or sets the TariffCode
        /// </summary>
        public string TariffCode
        {
            get
            {
                return _tariffCode;
            }
            set
            {
                if (_tariffCode != value) { TariffCodeUpdate = true; }
                _tariffCode = value;
                OnPropertyChanged("TariffCode");

            }
        }
        private string _tariffCode = string.Empty;

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
        ///     Gets or sets the Territory
        /// </summary>
        public string Territory
        {
            get
            {
                return _territory;
            }
            set
            {
                if (_territory != value) { TerritoryUpdate = true; }
                _territory = value;
                OnPropertyChanged("Territory");
            }

        }
        private string _territory = string.Empty;

        /// <summary>
        ///     Gets or sets the Title
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title != value) { TitleUpdate = true; }
                _title = value;
                OnPropertyChanged("Title");

            }
        }
        private string _title = string.Empty;

        /// <summary>
        ///     Gets or sets the Udex
        /// </summary>
        public string Udex
        {
            get
            {
                return _udex;
            }
            set
            {
                if (_udex != value) { UdexUpdate = true; }
                _udex = value;
                OnPropertyChanged("Udex");
            }

        }
        private string _udex = string.Empty;

        /// <summary>
        ///     Gets or sets the Upc
        /// </summary>
        public string Upc
        {
            get
            {
                return _upc;
            }
            set
            {
                if (_upc != value) { UpcUpdate = true; }
                _upc = value;
                OnPropertyChanged("Upc");

            }
        }
        private string _upc = string.Empty;

        /// <summary>
        ///     Gets or sets the Warranty
        /// </summary>
        public string Warranty
        {
            get
            {
                return _warranty;
            }
            set
            {
                if (_warranty != value) { WarrantyUpdate = true; }
                _warranty = value;
                OnPropertyChanged("Warranty");

            }
        }
        private string _warranty = string.Empty;

        /// <summary>
        ///     Gets or sets the WarrantyCheck
        /// </summary>
        public string WarrantyCheck
        {
            get
            {
                return _warrantyCheck;
            }
            set
            {
                if (_warrantyCheck != value) { WarrantyCheckUpdate = true; }
                _warrantyCheck = value;
                OnPropertyChanged("WarrantyCheck");

            }
        }
        private string _warrantyCheck = string.Empty;

        /// <summary>
        ///     Gets or sets the WebsitePrice
        /// </summary>
        public string WebsitePrice
        {
            get
            {
                return _websitePrice;
            }
            set
            {
                if (_websitePrice != value) { WebsitePriceUpdate = true; }
                _websitePrice = value;
                OnPropertyChanged("WebsitePrice");
            }
        }
        private string _websitePrice = string.Empty;

        /// <summary>
        ///     Gets or sets the Weight
        /// </summary>
        public string Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (_weight != value) { WeightUpdate = true; }
                _weight = value;
                OnPropertyChanged("Weight");
            }
        }
        private string _weight = string.Empty;

        /// <summary>
        ///     Gets or sets the Width
        /// </summary>
        public string Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (_width != value) { WidthUpdate = true; }
                _width = value;
                OnPropertyChanged("Width");

            }
        }
        private string _width = string.Empty;

        #endregion // Field Properties        

        #region Odin Properties

        /// <summary>
        ///     Gets or sets the ItemRow
        /// </summary>
        public int ItemRow
        {
            get
            {
                return _itemRow;
            }
            set
            {
                _itemRow = value;
                OnPropertyChanged("ItemRow");

            }
        }
        private int _itemRow;

        public string NewDate { get; set; }

        /// <summary>
        ///     Product Type: distinguishes between items(1) and kits(0)
        /// </summary>
        public int ProdType
        {
            get
            {
                return _prodType;
            }
            set
            {
                _prodType = value;
                OnPropertyChanged("ProdType");
            }
        }
        private int _prodType = 0;

        /// <summary>
        ///     Gets or sets the RecordDate. Used for update records view.
        /// </summary>
        public string RecordDate
        {
            get
            {
                return _recordDate;
            }
            set
            {
                _recordDate = value;
                OnPropertyChanged("RecordDate");

            }
        }
        private string _recordDate = string.Empty;

        /// <summary>
        ///     Gets or sets the RowColor. Used for listview display.
        /// </summary>
        public string RowColor
        {
            get
            {
                return _rowColor;
            }
            set
            {
                _rowColor = value;
                OnPropertyChanged("RowColor");

            }
        }
        private string _rowColor = "White";

        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                if ((value == "Add") || (value == "Update")) { this.Active = 1; }
                else { this.Active = 0; }
                OnPropertyChanged("Status");
            }
        }
        private string _status = string.Empty;

        /// <summary>
        ///     Gets or sets the UserName. Used for update records view.
        /// </summary>
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");

            }
        }
        private string _userName = string.Empty;

        #endregion // Odin Properties

        #region Update Flags

        /// <summary>
        ///     Check field updates. If item has updated field return true.
        /// </summary>
        /// <returns>True if any fields have been updated</returns>
        public bool HasUpdate
        {
            get
            {
                if (this.BuItemsInvUpdate ||
                    this.EcommerceValuesUpdate ||
                    this.CmItemMethodUpdate ||
                    this.EnBomCompsUpdate ||
                    this.FxdBinLocInvUpdate ||
                    this.InvItemsUpdate ||
                    this.ItemAttribExUpdate ||
                    this.ItemLanguageUpdate ||
                    this.ItemWebInfoUpdate ||
                    this.MasterItemUpdate ||
                    this.ProdItemUpdate ||
                    this.ProdPgrpLnkUpdate ||
                    this.ProdPriceBuUpdate ||
                    this.ProdPriceUpdate ||
                    this.PurchItemAttrUpdate ||
                    this.PvItmCategoryUpdate ||
                    this.SellOnFlagUpdate)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///    Update flag for fields stored in AmazonItemAttributes
        /// </summary>
        public bool EcommerceValuesUpdate
        {
            get
            {
                if (this.EcommerceAsinUpdate ||
                    this.EcommerceBullet1Update ||
                    this.EcommerceBullet2Update ||
                    this.EcommerceBullet3Update ||
                    this.EcommerceBullet4Update ||
                    this.EcommerceBullet5Update ||
                    this.EcommerceComponentsUpdate ||
                    this.EcommerceCostUpdate ||
                    this.EcommerceExternalIdUpdate ||
                    this.EcommerceExternalIdTypeUpdate ||
                    this.EcommerceGenericKeywordsUpdate ||
                    this.EcommerceImagePath1Update ||
                    this.EcommerceImagePath2Update ||
                    this.EcommerceImagePath3Update ||
                    this.EcommerceImagePath4Update ||
                    this.EcommerceImagePath5Update ||
                    this.EcommerceItemHeightUpdate ||
                    this.EcommerceItemLengthUpdate ||
                    this.EcommerceItemNameUpdate ||
                    this.EcommerceItemTypeKeywordsUpdate ||
                    this.EcommerceItemWeightUpdate ||
                    this.EcommerceItemWidthUpdate ||
                    this.EcommerceModelNameUpdate ||
                    this.EcommercePackageHeightUpdate ||
                    this.EcommercePackageLengthUpdate ||
                    this.EcommercePackageWeightUpdate ||
                    this.EcommercePackageWidthUpdate ||
                    this.EcommercePageQtyUpdate ||
                    this.EcommerceParentAsinUpdate ||
                    this.EcommerceProductCategoryUpdate ||
                    this.EcommerceProductDescriptionUpdate ||
                    this.EcommerceProductSubcategoryUpdate ||
                    this.EcommerceManufacturerNameUpdate ||
                    this.EcommerceMsrpUpdate ||
                    this.EcommerceSizeUpdate ||
                    this.EcommerceSubjectKeywordsUpdate ||
                    this.EcommerceUpcUpdate)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        ///     Update flag for fields stored in BuItemsInv
        /// </summary>
        public bool BuItemsInvUpdate
        {
            get
            {
                if (this.CountryOfOriginUpdate ||
                    this.MfgSourceUpdate ||
                    this.DefaultActualCostCadUpdate ||
                    this.DefaultActualCostUsdUpdate)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///    Update flag for fields stored in CmItemMethod
        /// </summary>
        public bool CmItemMethodUpdate
        {
            get
            {
                if (this.CostProfileGroupUpdate)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///    Update flag for fields stored in EnBomCompsUpdate
        /// </summary>
        /// <returns></returns>
        public bool EnBomCompsUpdate
        {
            get
            {
                if (this.BillOfMaterialsUpdate)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///    Update flag for fields stored in FxdbinlocInv
        /// </summary>
        public bool FxdBinLocInvUpdate
        {
            get
            {
                if (this.ItemFamilyUpdate ||
                    this.ItemGroupUpdate)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        ///     Flag for if item is marked to be sold on web (SellOnTrends == 'Y')
        /// </summary>
        /// <returns></returns>
        public bool HasWeb
        {
            get
            {
                if (this.SellOnTrends == "Y")
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///     Flag for if item is marked to be sold on any ecommerce site
        /// </summary>
        /// <returns></returns>
        public bool HasEcommerce
        {
            get
            {
                if (this.SellOnAllPosters == "Y" ||
                    this.SellOnAmazon == "Y" ||
                    this.SellOnAmazonSellerCentral == "Y" ||
                    this.SellOnEcommerce == "Y" ||
                    this.SellOnFanatics == "Y" ||
                    this.SellOnGuitarCenter == "Y" ||
                    this.SellOnHayneedle == "Y" ||
                    this.SellOnTarget == "Y" ||
                    this.SellOnWalmart == "Y" ||
                    this.SellOnWayfair == "Y")
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///     Update flag for fields stored in InvItems
        /// </summary>
        /// <returns></returns>
        public bool InvItemsUpdate
        {
            get
            {
                if (this.TariffCodeUpdate ||
                this.ColorUpdate ||
                this.HeightUpdate ||
                this.LengthUpdate ||
                this.DescriptionUpdate ||
                this.WeightUpdate ||
                this.WidthUpdate ||
                this.UpcUpdate)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        ///     Update flag for fields stored in ItemAttribEx
        /// </summary>
        /// <returns></returns>
        public bool ItemAttribExUpdate
        {
            get
            {
                if (this.AltImageFile1Update ||
                    this.AltImageFile2Update ||
                    this.AltImageFile3Update ||
                    this.AltImageFile4Update ||
                    this.CasepackHeightUpdate ||
                    this.CasepackLengthUpdate ||
                    this.CasepackQtyUpdate ||
                    this.CasepackUpcUpdate ||
                    this.CasepackWeightUpdate ||
                    this.CasepackWidthUpdate ||
                    this.DirectImportUpdate ||
                    this.ImagePathUpdate ||
                    this.InnerpackHeightUpdate ||
                    this.InnerpackLengthUpdate ||
                    this.InnerpackQuantityUpdate ||
                    this.InnerpackUpcUpdate ||
                    this.InnerpackWeightUpdate ||
                    this.InnerpackWidthUpdate ||
                    this.LicenseBeginDateUpdate ||
                    this.PrintOnDemandUpdate ||
                    this.ProductFormatUpdate ||
                    this.ProductLineUpdate ||
                    this.ProductGroupUpdate ||
                    this.InnerpackWidthUpdate ||
                    this.SatCodeUpdate ||
                    this.SellOnEcommerceUpdate ||
                    this.SellOnTrendsUpdate ||
                    this.WebsitePriceUpdate)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///    Update flag for fields stored in ItemLanguage
        /// </summary>
        public bool ItemLanguageUpdate
        {
            get
            {
                if (this.LanguageUpdate)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///    Update flag for fields stored in ItemTerritory
        /// </summary>
        public bool ItemTerritoryUpdate
        {
            get
            {
                if (this.TerritoryUpdate)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///    Update flag for fields stored in ItemWebInfo
        /// </summary>
        /// <returns></returns>
        public bool ItemWebInfoUpdate
        {
            get
            {
                if (this.ItemKeywordsUpdate ||
                    this.CategoryUpdate ||
                    this.Category2Update ||
                    this.Category3Update ||
                    this.PropertyUpdate ||
                    this.CopyrightUpdate ||
                    this.TitleUpdate ||
                    this.LicenseUpdate ||
                    this.ShortDescriptionUpdate ||
                    this.MetaDescriptionUpdate ||
                    this.ProductQtyUpdate ||
                    this.SizeUpdate ||
                    this.InStockDateUpdate ||
                    this.WarrantyUpdate ||
                    this.WarrantyCheckUpdate)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///    Update flag for fields stored in ItemWebInfo
        /// </summary>
        public bool MasterItemUpdate
        {
            get
            {
                if (this.ItemCategoryUpdate ||
                    this.CostProfileGroupUpdate ||
                    this.DescriptionUpdate ||
                    this.ItemGroupUpdate ||
                    this.PsStatusUpdate ||
                    this.ItemFamilyUpdate)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        ///    Update flag for fields stored in ProdItem
        /// </summary>
        public bool ProdItemUpdate
        {
            get
            {
                if (this.ItemCategoryUpdate ||
                    this.StatsCodeUpdate ||
                    this.DescriptionUpdate ||
                    this.IsbnUpdate ||
                    this.EanUpdate ||
                    this.UdexUpdate ||
                    this.GpcUpdate)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        ///    Update flag for fields stored in ProdPgrpLnk
        /// </summary>
        public bool ProdPgrpLnkUpdate
        {
            get
            {
                if (this.AccountingGroupUpdate ||
                    this.PricingGroupUpdate)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        ///    Update flag for fields stored in ProdPriceBu
        /// </summary>
        /// <returns></returns>
        public bool ProdPriceBuUpdate
        {
            get
            {
                if (this.ProductGroupUpdate ||
                    this.ListPriceCadUpdate ||
                    this.ListPriceUsdUpdate ||
                    this.ListPriceMxnUpdate ||
                    this.MsrpUpdate ||
                    this.MsrpCadUpdate ||
                    this.MsrpMxnUpdate)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///    Check fields for Prod Price table to see if any have been updated.
        /// </summary>
        public bool ProdPriceUpdate
        {
            get
            {
                if (this.ProductGroupUpdate ||
                        this.ListPriceCadUpdate ||
                        this.ListPriceUsdUpdate ||
                        this.ListPriceMxnUpdate ||
                        this.MsrpUpdate ||
                        this.MsrpCadUpdate ||
                        this.MsrpMxnUpdate)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///    Update flag for fields stored in PurchItemAttr
        /// </summary>
        public bool PurchItemAttrUpdate
        {
            get
            {
                if (this.DescriptionUpdate ||
                    this.StandardCostUpdate)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///    Update flag for fields stored in PvItmCategory
        /// </summary>
        public bool PvItmCategoryUpdate
        {
            get
            {
                if (this.ItemCategoryUpdate)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///    Update flag for fields stored in CustomerProductAttributes
        /// </summary>
        public bool SellOnFlagUpdate
        {
            get
            {
                if (this.SellOnAllPostersUpdate ||
                    this.SellOnAmazonUpdate ||
                    this.SellOnAmazonSellerCentralUpdate ||
                    this.SellOnFanaticsUpdate ||
                    this.SellOnGuitarCenterUpdate ||
                    this.SellOnHayneedleUpdate ||
                    this.SellOnTargetUpdate ||
                    this.SellOnWalmartUpdate ||
                    this.SellOnWayfairUpdate)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///     AccountingGroupUpdate update flag
        /// </summary>
        public bool AccountingGroupUpdate = false;

        /// <summary>
        ///     AltImageFile1Update update flag
        /// </summary>
        public bool AltImageFile1Update = false;

        /// <summary>
        ///     AltImageFile2Update update flag
        /// </summary>
        public bool AltImageFile2Update = false;

        /// <summary>
        ///     AltImageFile3Update update flag
        /// </summary>
        public bool AltImageFile3Update = false;

        /// <summary>
        ///     AltImageFile4Update update flag
        /// </summary>
        public bool AltImageFile4Update = false;

        /// <summary>
        ///     BillOfMaterialsUpdate update flag
        /// </summary>
        public bool BillOfMaterialsUpdate = false;

        /// <summary>
        ///     CasepackHeightUpdate update flag
        /// </summary>
        public bool CasepackHeightUpdate = false;

        /// <summary>
        ///     CasepackLengthUpdate update flag
        /// </summary>
        public bool CasepackLengthUpdate = false;

        /// <summary>
        ///     CasepackQtyUpdate update flag
        /// </summary>
        public bool CasepackQtyUpdate = false;

        /// <summary>
        ///     CasepackUpcUpdate update flag
        /// </summary>
        public bool CasepackUpcUpdate = false;

        /// <summary>
        ///     CasepackWidthUpdate update flag
        /// </summary>
        public bool CasepackWidthUpdate = false;

        /// <summary>
        ///     CasepackWeightUpdate update flag
        /// </summary>
        public bool CasepackWeightUpdate = false;

        /// <summary>
        ///     CategoryUpdate update flag
        /// </summary>
        public bool CategoryUpdate = false;

        /// <summary>
        ///     Category2Update update flag
        /// </summary>
        public bool Category2Update = false;

        /// <summary>
        ///     Category3Update update flag
        /// </summary>
        public bool Category3Update = false;

        /// <summary>
        ///     ColorUpdate update flag
        /// </summary>
        public bool ColorUpdate = false;

        /// <summary>
        ///     CopyrightUpdate update flag
        /// </summary>
        public bool CopyrightUpdate = false;

        /// <summary>
        ///     CountryOfOriginUpdate update flag
        /// </summary>
        public bool CountryOfOriginUpdate = false;

        /// <summary>
        ///     CostProfileGroupUpdate update flag
        /// </summary>
        public bool CostProfileGroupUpdate = false;

        /// <summary>
        ///     DefaultActualCostCadUpdate update flag
        /// </summary>
        public bool DefaultActualCostCadUpdate = false;

        /// <summary>
        ///     DefaultActualCostUsdUpdate update flag
        /// </summary>
        public bool DefaultActualCostUsdUpdate = false;

        /// <summary>
        ///     DescriptionUpdate update flag
        /// </summary>
        public bool DescriptionUpdate = false;

        /// <summary>
        ///     DirectImportUpdate update flag
        /// </summary>
        public bool DirectImportUpdate = false;

        /// <summary>
        ///     DutyUpdate update flag
        /// </summary>
        public bool DutyUpdate = false;

        /// <summary>
        ///     EanUpdate update flag
        /// </summary>
        public bool EanUpdate = false;

        /// <summary>
        ///     EcommerceAsinUpdate update flag
        /// </summary>
        public bool EcommerceAsinUpdate = false;

        /// <summary>
        ///     EcommerceBullet1Update update flag
        /// </summary>
        public bool EcommerceBullet1Update = false;

        /// <summary>
        ///     EcommerceBullet2Update update flag
        /// </summary>
        public bool EcommerceBullet2Update = false;

        /// <summary>
        ///     EcommerceBullet3Update update flag
        /// </summary>
        public bool EcommerceBullet3Update = false;

        /// <summary>
        ///     EcommerceBullet4Update update flag
        /// </summary>
        public bool EcommerceBullet4Update = false;

        /// <summary>
        ///     EcommerceBullet5Update update flag
        /// </summary>
        public bool EcommerceBullet5Update = false;

        /// <summary>
        ///     EcommerceComponentsUpdate update flag
        /// </summary>
        public bool EcommerceComponentsUpdate = false;

        /// <summary>
        ///     EcommerceCostUpdate update flag
        /// </summary>
        public bool EcommerceCostUpdate = false;

        /// <summary>
        ///     EcommerceCountryofOriginUpdate update flag
        /// </summary>
        public bool EcommerceCountryofOriginUpdate = false;

        /// <summary>
        ///     EcommerceExternalIdUpdate update flag
        /// </summary>
        public bool EcommerceExternalIdUpdate = false;

        /// <summary>
        ///     EcommerceExternalIdTypeUpdate update flag
        /// </summary>
        public bool EcommerceExternalIdTypeUpdate = false;

        /// <summary>
        ///     EcommerceGenericKeywordsUpdate update flag
        /// </summary>
        public bool EcommerceGenericKeywordsUpdate = false;

        /// <summary>
        ///     EcommerceImagePath1Update update flag
        /// </summary>
        public bool EcommerceImagePath1Update = false;

        /// <summary>
        ///     EcommerceImagePath2Update update flag
        /// </summary>
        public bool EcommerceImagePath2Update = false;

        /// <summary>
        ///     EcommerceImagePath3Update update flag
        /// </summary>
        public bool EcommerceImagePath3Update = false;

        /// <summary>
        ///     EcommerceImagePath4Update update flag
        /// </summary>
        public bool EcommerceImagePath4Update = false;

        /// <summary>
        ///     EcommerceImagePath5Update update flag
        /// </summary>
        public bool EcommerceImagePath5Update = false;

        /// <summary>
        ///     EcommerceItemHeightUpdate update flag
        /// </summary>
        public bool EcommerceItemHeightUpdate = false;

        /// <summary>
        ///     EcommerceItemLengthUpdate update flag
        /// </summary>
        public bool EcommerceItemLengthUpdate = false;

        /// <summary>
        ///     EcommerceItemNameUpdate update flag
        /// </summary>
        public bool EcommerceItemNameUpdate = false;

        /// <summary>
        ///     EcommerceItemTypeKeywordsUpdate update flag
        /// </summary>
        public bool EcommerceItemTypeKeywordsUpdate = false;

        /// <summary>
        ///     EcommerceItemWeightUpdate update flag
        /// </summary>
        public bool EcommerceItemWeightUpdate = false;

        /// <summary>
        ///     EcommerceItemWidthUpdate update flag
        /// </summary>
        public bool EcommerceItemWidthUpdate = false;

        /// <summary>
        ///     EcommerceManufacturerNameUpdate update flag
        /// </summary>
        public bool EcommerceManufacturerNameUpdate = false;

        /// <summary>
        ///     EcommerceModelNameUpdate update flag
        /// </summary>
        public bool EcommerceModelNameUpdate = false;

        /// <summary>
        ///     EcommerceMsrpUpdate update flag
        /// </summary>
        public bool EcommerceMsrpUpdate = false;

        /// <summary>
        ///     EcommercePackageHeightUpdate update flag
        /// </summary>
        public bool EcommercePackageHeightUpdate = false;

        /// <summary>
        ///     EcommercePackageLengthUpdate update flag
        /// </summary>
        public bool EcommercePackageLengthUpdate = false;

        /// <summary>
        ///     EcommercePackageWeightUpdate update flag
        /// </summary>
        public bool EcommercePackageWeightUpdate = false;

        /// <summary>
        ///     EcommercePackageWidthUpdate update flag
        /// </summary>
        public bool EcommercePackageWidthUpdate = false;

        /// <summary>
        ///     EcommercePageQtyUpdate update flag
        /// </summary>
        public bool EcommercePageQtyUpdate = false;

        /// <summary>
        ///     EcommerceParentAsin update flag
        /// </summary>
        public bool EcommerceParentAsinUpdate = false;

        /// <summary>
        ///     EcommerceProductCategoryUpdate update flag
        /// </summary>
        public bool EcommerceProductCategoryUpdate = false;

        /// <summary>
        ///     EcommerceProductDescriptionUpdate update flag
        /// </summary>
        public bool EcommerceProductDescriptionUpdate = false;

        /// <summary>
        ///     EcommerceProductSubcategoryUpdate update flag
        /// </summary>
        public bool EcommerceProductSubcategoryUpdate = false;

        /// <summary>
        ///     Ecommere_SizeUpdate update flag
        /// </summary>
        public bool EcommerceSizeUpdate = false;

        /// <summary>
        ///     EcommerceSubjectKeywordsUpdate update flag
        /// </summary>
        public bool EcommerceSubjectKeywordsUpdate = false;

        /// <summary>
        ///     Ecommere_UpcUpdate update flag
        /// </summary>
        public bool EcommerceUpcUpdate = false;

        /// <summary>
        ///     GpcUpdate update flag
        /// </summary>
        public bool GpcUpdate = false;

        /// <summary>
        ///     HeightUpdate update flag
        /// </summary>
        public bool HeightUpdate = false;

        /// <summary>
        ///     ImagePathUpdate update flag
        /// </summary>
        public bool ImagePathUpdate = false;

        /// <summary>
        ///     InnerpackHeightUpdate update flag
        /// </summary>
        public bool InnerpackHeightUpdate = false;

        /// <summary>
        ///     InnerpackLengthUpdate update flag
        /// </summary>
        public bool InnerpackLengthUpdate = false;

        /// <summary>
        ///     InnerpackQuantityUpdate update flag
        /// </summary>
        public bool InnerpackQuantityUpdate = false;

        /// <summary>
        ///     InnerpackUpcUpdate update flag
        /// </summary>
        public bool InnerpackUpcUpdate = false;

        /// <summary>
        ///     InnerpackWidthUpdate update flag
        /// </summary>
        public bool InnerpackWidthUpdate = false;

        /// <summary>
        ///     InnerpackWeightUpdate update flag
        /// </summary>
        public bool InnerpackWeightUpdate = false;

        /// <summary>
        ///     InStockDateUpdate update flag
        /// </summary>
        public bool InStockDateUpdate = false;

        /// <summary>
        ///     IsbnUpdate update flag
        /// </summary>
        public bool IsbnUpdate = false;

        /// <summary>
        ///     ItemCategoryUpdate update flag
        /// </summary>
        public bool ItemCategoryUpdate = false;

        /// <summary>
        ///     ItemFamilyUpdate update flag
        /// </summary>
        public bool ItemFamilyUpdate = false;

        /// <summary>
        ///     ItemGroupUpdate update flag
        /// </summary>
        public bool ItemGroupUpdate = false;

        /// <summary>
        ///     ItemKeywordsUpdate update flag
        /// </summary>
        public bool ItemKeywordsUpdate = false;

        /// <summary>
        ///     LanguageUpdate update flag
        /// </summary>
        public bool LanguageUpdate = false;

        /// <summary>
        ///     LengthUpdate update flag
        /// </summary>
        public bool LengthUpdate = false;

        /// <summary>
        ///     LicenseBeginDateUpdate update flag
        /// </summary>
        public bool LicenseBeginDateUpdate = false;

        /// <summary>
        ///     LicenseUpdate update flag
        /// </summary>
        public bool LicenseUpdate = false;

        /// <summary>
        ///     ListPriceCadUpdate update flag
        /// </summary>
        public bool ListPriceCadUpdate = false;

        /// <summary>
        ///     ListPriceMxnUpdate update flag
        /// </summary>
        public bool ListPriceMxnUpdate = false;

        /// <summary>
        ///     ListPriceUsdUpdate update flag
        /// </summary>
        public bool ListPriceUsdUpdate = false;

        /// <summary>
        ///     MetaDescriptionUpdate update flag
        /// </summary>
        public bool MetaDescriptionUpdate = false;

        /// <summary>
        ///     MfgSourceUpdate update flag
        /// </summary>
        public bool MfgSourceUpdate = false;

        /// <summary>
        ///     MsrpUpdate update flag
        /// </summary>
        public bool MsrpUpdate = false;

        /// <summary>
        ///     MsrpCadUpdate update flag
        /// </summary>
        public bool MsrpCadUpdate = false;

        /// <summary>
        ///     MsrpMxnUpdate update flag
        /// </summary>
        public bool MsrpMxnUpdate = false;

        /// <summary>
        ///     PricingGroupUpdate update flag
        /// </summary>
        public bool PricingGroupUpdate = false;

        /// <summary>
        ///     PrintOnDemandUpdate update flag
        /// </summary>
        public bool PrintOnDemandUpdate = false;

        /// <summary>
        ///     ProductFormatUpdate update flag
        /// </summary>
        public bool ProductFormatUpdate = false;

        /// <summary>
        ///     ProductGroupUpdate update flag
        /// </summary>
        public bool ProductGroupUpdate = false;

        /// <summary>
        ///     ProductIdTranslationUpdate update flag
        /// </summary>
        public bool ProductIdTranslationUpdate = false;

        /// <summary>
        ///     ProductLineUpdate update flag
        /// </summary>
        public bool ProductLineUpdate = false;

        /// <summary>
        ///     ProductQtyUpdate update flag
        /// </summary>
        public bool ProductQtyUpdate = false;

        /// <summary>
        ///     PropertyUpdate update flag
        /// </summary>
        public bool PropertyUpdate = false;

        /// <summary>
        ///     PsStatusUpdate update flag
        /// </summary>
        public bool PsStatusUpdate = false;

        /// <summary>
        ///     SatCodeUpdate update flag
        /// </summary>
        public bool SatCodeUpdate = false;

        /// <summary>
        ///     SellOnAttributesUpdate update flag
        /// </summary>
        public bool SellOnAttributesUpdate = false;

        /// <summary>
        ///     SellOnAllPostersUpdate update flag
        /// </summary>
        public bool SellOnAllPostersUpdate = false;

        /// <summary>
        ///     SellOnAmazonUpdate update flag
        /// </summary>
        public bool SellOnAmazonUpdate = false;

        /// <summary>
        ///     SellOnAmazonSellerCentralUpdate update flag
        /// </summary>
        public bool SellOnAmazonSellerCentralUpdate = false;

        /// <summary>
        ///     SellOnEcommerceUpdate update flag
        /// </summary>
        public bool SellOnEcommerceUpdate = false;

        /// <summary>
        ///     SellOnFanaticsUpdate update flag
        /// </summary>
        public bool SellOnFanaticsUpdate = false;

        /// <summary>
        ///     SellOnGuitarCenterUpdate update flag
        /// </summary>
        public bool SellOnGuitarCenterUpdate = false;

        /// <summary>
        ///     SellOnHayneedleUpdate update flag
        /// </summary>
        public bool SellOnHayneedleUpdate = false;

        /// <summary>
        ///     SellOnTargetUpdate update flag
        /// </summary>
        public bool SellOnTargetUpdate = false;

        /// <summary>
        ///     SellOnTrendsUpdate update flag
        /// </summary>
        public bool SellOnTrendsUpdate = false;

        /// <summary>
        ///     SellOnWalmartUpdate update flag
        /// </summary>
        public bool SellOnWalmartUpdate = false;

        /// <summary>
        ///     SellOnWayfairUpdate update flag
        /// </summary>
        public bool SellOnWayfairUpdate = false;

        /// <summary>
        ///     ShortDescriptionUpdate update flag
        /// </summary>
        public bool ShortDescriptionUpdate = false;

        /// <summary>
        ///     SizeUpdate update flag
        /// </summary>
        public bool SizeUpdate = false;

        /// <summary>
        ///     StandardCostUpdate update flag
        /// </summary>
        public bool StandardCostUpdate = false;

        /// <summary>
        ///     StatsCodeUpdate update flag
        /// </summary>
        public bool StatsCodeUpdate = false;

        /// <summary>
        ///     TariffCodeUpdate update flag
        /// </summary>
        public bool TariffCodeUpdate = false;

        /// <summary>
        ///     TerritoryUpdate update flag
        /// </summary>
        public bool TerritoryUpdate = false;

        /// <summary>
        ///     TitleUpdate update flag
        /// </summary>
        public bool TitleUpdate = false;

        /// <summary>
        ///     UdexUpdate update flag
        /// </summary>
        public bool UdexUpdate = false;

        /// <summary>
        ///     UpcUpdate update flag
        /// </summary>
        public bool UpcUpdate = false;

        /// <summary>
        ///     WebsitePriceUpdate update flag
        /// </summary>
        public bool WebsitePriceUpdate = false;

        /// <summary>
        ///     WarrantyUpdate update flag
        /// </summary>
        public bool WarrantyUpdate = false;

        /// <summary>
        ///     WarrantyCheckUpdate update flag
        /// </summary>
        public bool WarrantyCheckUpdate = false;

        /// <summary>
        ///     WeightUpdate update flag
        /// </summary>
        public bool WeightUpdate = false;

        /// <summary>
        ///     WidthUpdate update flag
        /// </summary>
        public bool WidthUpdate = false;

        #endregion // Update Flags

        #endregion // Properties

        #region Methods

        /// <summary>
        ///     Creates a clone of this object
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        ///     Combines the product Id and qty from a product Id Translation object into a single string
        /// </summary>
        /// <param name="productIdTranslastion"></param>
        /// <returns></returns>
        public string CombineChildElement(ChildElement childElement)
        {
            string result = childElement.ItemId;
            if (childElement.Qty != 1)
            {
                string qty = Convert.ToString(childElement.Qty);
                result += " (" + qty + ")";
            }
            return result;
        }

        /// <summary>
        ///     returns image url path on trends b2b site
        /// </summary>
        /// <param name="value">image name</param>
        /// <returns></returns>
        public string CreateEcommerceImageUrl(string value)
        {
            string returnValue = "";
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Contains("http://trendsinternational.com/media/catalog/product/"))
                {
                    return value;
                }
                else
                {
                    string[] values = value.Split('\\');
                    if (values.Length > 1)
                    {
                        returnValue = "http://trendsinternational.com/media/catalog/product/";
                        int last = values.Length;
                        value = values[last - 1];
                        string a = (!string.IsNullOrEmpty(value.Substring(0, 1))) ? value.Substring(0, 1) + "/" : "";
                        string b = (!string.IsNullOrEmpty(value.Substring(1, 1))) ? value.Substring(1, 1) + "/" : "";
                        values = value.Split('.');
                        value = value.Replace("." + values[values.Length - 1], "");
                        returnValue += a + b + value.TrimEnd('.') + ".jpg";
                    }
                    else
                    {
                        return value;
                    }
                }
            }
            return returnValue;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        ///     Set all field update values to false.
        /// </summary>
        public void ResetUpdate()
        {
            this.AccountingGroupUpdate = false;
            this.BillOfMaterialsUpdate = false;
            this.AltImageFile1Update = false;
            this.AltImageFile2Update = false;
            this.AltImageFile3Update = false;
            this.AltImageFile4Update = false;
            this.CasepackHeightUpdate = false;
            this.CasepackLengthUpdate = false;
            this.CasepackQtyUpdate = false;
            this.CasepackUpcUpdate = false;
            this.CasepackWidthUpdate = false;
            this.CasepackWeightUpdate = false;
            this.CategoryUpdate = false;
            this.Category2Update = false;
            this.Category3Update = false;
            this.ColorUpdate = false;
            this.CopyrightUpdate = false;
            this.CountryOfOriginUpdate = false;
            this.CostProfileGroupUpdate = false;
            this.DefaultActualCostUsdUpdate = false;
            this.DefaultActualCostCadUpdate = false;
            this.DescriptionUpdate = false;
            this.DirectImportUpdate = false;
            this.DutyUpdate = false;
            this.EanUpdate = false;
            this.EcommerceAsinUpdate = false;
            this.EcommerceBullet1Update = false;
            this.EcommerceBullet2Update = false;
            this.EcommerceBullet3Update = false;
            this.EcommerceBullet4Update = false;
            this.EcommerceBullet5Update = false;
            this.EcommerceComponentsUpdate = false;
            this.EcommerceCostUpdate = false;
            this.EcommerceExternalIdUpdate = false;
            this.EcommerceExternalIdTypeUpdate = false;
            this.EcommerceImagePath1Update = false;
            this.EcommerceImagePath2Update = false;
            this.EcommerceImagePath3Update = false;
            this.EcommerceImagePath4Update = false;
            this.EcommerceImagePath5Update = false;
            this.EcommerceItemHeightUpdate = false;
            this.EcommerceItemLengthUpdate = false;
            this.EcommerceItemNameUpdate = false;
            this.EcommerceItemTypeKeywordsUpdate = false;
            this.EcommerceItemWeightUpdate = false;
            this.EcommerceItemWidthUpdate = false;
            this.EcommerceModelNameUpdate = false;
            this.EcommercePackageHeightUpdate = false;
            this.EcommercePackageLengthUpdate = false;
            this.EcommercePackageWeightUpdate = false;
            this.EcommercePackageWidthUpdate = false;
            this.EcommercePageQtyUpdate = false;
            this.EcommerceParentAsinUpdate = false;
            this.EcommerceProductCategoryUpdate = false;
            this.EcommerceProductDescriptionUpdate = false;
            this.EcommerceProductSubcategoryUpdate = false;
            this.EcommerceManufacturerNameUpdate = false;
            this.EcommerceMsrpUpdate = false;
            this.EcommerceGenericKeywordsUpdate = false;
            this.EcommerceSizeUpdate = false;
            this.EcommerceSubjectKeywordsUpdate = false;
            this.EcommerceUpcUpdate = false;
            this.GpcUpdate = false;
            this.HeightUpdate = false;
            this.ImagePathUpdate = false;
            this.InStockDateUpdate = false;
            this.InnerpackHeightUpdate = false;
            this.InnerpackLengthUpdate = false;
            this.InnerpackQuantityUpdate = false;
            this.InnerpackUpcUpdate = false;
            this.InnerpackWidthUpdate = false;
            this.InnerpackWeightUpdate = false;
            this.IsbnUpdate = false;
            this.ItemCategoryUpdate = false;
            this.ItemFamilyUpdate = false;
            this.ItemGroupUpdate = false;
            this.ItemKeywordsUpdate = false;
            this.LanguageUpdate = false;
            this.LengthUpdate = false;
            this.LicenseUpdate = false;
            this.LicenseBeginDateUpdate = false;
            this.ListPriceCadUpdate = false;
            this.ListPriceUsdUpdate = false;
            this.ListPriceMxnUpdate = false;
            this.MetaDescriptionUpdate = false;
            this.MfgSourceUpdate = false;
            this.MsrpUpdate = false;
            this.MsrpCadUpdate = false;
            this.MsrpMxnUpdate = false;
            this.ProductFormatUpdate = false;
            this.ProductGroupUpdate = false;
            this.ProductIdTranslationUpdate = false;
            this.ProductLineUpdate = false;
            this.ProductQtyUpdate = false;
            this.PricingGroupUpdate = false;
            this.PrintOnDemandUpdate = false;
            this.PsStatusUpdate = false;
            this.SatCodeUpdate = false;
            this.SellOnAllPostersUpdate = false;
            this.SellOnAmazonUpdate = false;
            this.SellOnAmazonSellerCentralUpdate = false;
            this.SellOnEcommerceUpdate = false;
            this.SellOnFanaticsUpdate = false;
            this.SellOnGuitarCenterUpdate = false;
            this.SellOnHayneedleUpdate = false;
            this.SellOnWalmartUpdate = false;
            this.SellOnWayfairUpdate = false;
            this.SellOnTrendsUpdate = false;
            this.SellOnTargetUpdate = false;
            this.ShortDescriptionUpdate = false;
            this.SizeUpdate = false;
            this.StandardCostUpdate = false;
            this.StatsCodeUpdate = false;
            this.TariffCodeUpdate = false;
            this.TerritoryUpdate = false;
            this.TitleUpdate = false;
            this.UdexUpdate = false;
            this.UpcUpdate = false;
            this.WarrantyUpdate = false;
            this.WarrantyCheckUpdate = false;
            this.WebsitePriceUpdate = false;
            this.WeightUpdate = false;
            this.WidthUpdate = false;
        }

        /// <summary>
        ///     Returns Bill of Materials list as a string
        /// </summary>
        /// <returns></returns>
        public string ReturnBillOfMaterials()
        {
            string result = string.Empty;
            int listLength = this.BillOfMaterials.Count;
            int count = 0;
            while (count < listLength)
            {
                result += CombineChildElement(this.BillOfMaterials[count]);
                if (listLength - count > 1)
                {
                    result += ", ";
                }
                count++;
            }
            return result;
        }

        /// <summary>
        ///     Returns Product Id Translations as a string
        /// </summary>
        /// <returns></returns>
        public string ReturnProductIdTranslations()
        {
            string result = string.Empty;
            if (this.ProductIdTranslation.Count > 0)
            {
                int listLength = this.ProductIdTranslation.Count;
                int count = 0;
                while (count < listLength)
                {
                    result += CombineChildElement(this.ProductIdTranslation[count]);
                    if (listLength - count > 1)
                    {
                        result += ", ";
                    }
                    count++;
                }
            }
            return result;
        }

        /// <summary>
        ///     Returns a "Y" if ProductIdTransalations Exist, "N" if the field is empty
        /// </summary>
        /// <returns></returns>
        public string ReturnTranslateEdiProd()
        {
            if (ProductIdTranslation.Count > 0)
            {
                return "Y";
            }
            return "N";
        }

        /// <summary>
        ///     Sets this items update values to that of the given item
        /// </summary>
        /// <param name="item"></param>
        public void UpdateItem(ItemObject item)
        {
            if (item.HasUpdate)
            {
                this.AltImageFile1 = item.AltImageFile1;
                this.AltImageFile2 = item.AltImageFile2;
                this.AltImageFile3 = item.AltImageFile3;
                this.AltImageFile4 = item.AltImageFile4;
                this.AccountingGroup = item.AccountingGroup;
                this.BillOfMaterials = item.BillOfMaterials;
                this.CasepackHeight = item.CasepackHeight;
                this.CasepackLength = item.CasepackLength;
                this.CasepackQty = item.CasepackQty;
                this.CasepackUpc = item.CasepackUpc;
                this.CasepackWidth = item.CasepackWidth;
                this.CasepackWeight = item.CasepackWeight;
                this.Category = item.Category;
                this.Category2 = item.Category2;
                this.Category3 = item.Category3;
                this.Color = item.Color;
                this.Copyright = item.Copyright;
                this.CountryOfOrigin = item.CountryOfOrigin;
                this.CostProfileGroup = item.CostProfileGroup;
                this.DefaultActualCostUsd = item.DefaultActualCostUsd;
                this.DefaultActualCostCad = item.DefaultActualCostCad;
                this.Description = item.Description;
                this.DirectImport = item.DirectImport;
                this.Duty = item.Duty;
                this.Ean = item.Ean;
                this.EcommerceAsin = item.EcommerceAsin;
                this.EcommerceBullet1 = item.EcommerceBullet1;
                this.EcommerceBullet2 = item.EcommerceBullet2;
                this.EcommerceBullet3 = item.EcommerceBullet3;
                this.EcommerceBullet4 = item.EcommerceBullet4;
                this.EcommerceBullet5 = item.EcommerceBullet5;
                this.EcommerceComponents = item.EcommerceComponents;
                this.EcommerceCost = item.EcommerceCost;
                this.EcommerceExternalId = item.EcommerceExternalId;
                this.EcommerceExternalIdType = item.EcommerceExternalIdType;
                this.EcommerceImagePath1 = item.EcommerceImagePath1;
                this.EcommerceImagePath2 = item.EcommerceImagePath2;
                this.EcommerceImagePath3 = item.EcommerceImagePath3;
                this.EcommerceImagePath4 = item.EcommerceImagePath4;
                this.EcommerceImagePath5 = item.EcommerceImagePath5;
                this.EcommerceItemHeight = item.EcommerceItemHeight;
                this.EcommerceItemLength = item.EcommerceItemLength;
                this.EcommerceItemName = item.EcommerceItemName;
                this.EcommerceItemTypeKeywords = item.EcommerceItemTypeKeywords;
                this.EcommerceItemWeight = item.EcommerceItemWeight;
                this.EcommerceItemWidth = item.EcommerceItemWidth;
                this.EcommerceModelName = item.EcommerceModelName;
                this.EcommercePackageHeight = item.EcommercePackageHeight;
                this.EcommercePackageLength = item.EcommercePackageLength;
                this.EcommercePackageWeight = item.EcommercePackageWeight;
                this.EcommercePackageWidth = item.EcommercePackageWidth;
                this.EcommercePageQty = item.EcommercePageQty;
                this.EcommerceParentAsin = item.EcommerceParentAsin;
                this.EcommerceProductCategory = item.EcommerceProductCategory;
                this.EcommerceProductDescription = item.EcommerceProductDescription;
                this.EcommerceProductSubcategory = item.EcommerceProductSubcategory;
                this.EcommerceManufacturerName = item.EcommerceManufacturerName;
                this.EcommerceMsrp = item.EcommerceMsrp;
                this.EcommerceGenericKeywords = item.EcommerceGenericKeywords;
                this.EcommerceSize = item.EcommerceSize;
                this.EcommerceSubjectKeywords = item.EcommerceSubjectKeywords;
                this.EcommerceUpc = item.EcommerceUpc;
                this.Gpc = item.Gpc;
                this.Height = item.Height;
                this.ImagePath = item.ImagePath;
                this.InnerpackHeight = item.InnerpackHeight;
                this.InnerpackLength = item.InnerpackLength;
                this.InnerpackQuantity = item.InnerpackQuantity;
                this.InnerpackUpc = item.InnerpackUpc;
                this.InnerpackWidth = item.InnerpackWidth;
                this.InnerpackWeight = item.InnerpackWeight;
                this.InStockDate = item.InStockDate;
                this.Isbn = item.Isbn;
                this.ItemCategory = item.ItemCategory;
                this.ItemFamily = item.ItemFamily;
                this.ItemGroup = item.ItemGroup;
                this.ItemId = item.ItemId;
                this.ItemKeywords = item.ItemKeywords;
                this.Language = item.Language;
                this.Length = item.Length;
                this.License = item.License;
                this.LicenseBeginDate = item.LicenseBeginDate;
                this.ListPriceCad = item.ListPriceCad;
                this.ListPriceUsd = item.ListPriceUsd;
                this.ListPriceMxn = item.ListPriceMxn;
                this.MetaDescription = item.MetaDescription;
                this.MfgSource = item.MfgSource;
                this.Msrp = item.Msrp;
                this.MsrpCad = item.MsrpCad;
                this.MsrpMxn = item.MsrpMxn;
                this.ProductFormat = item.ProductFormat;
                this.ProductGroup = item.ProductGroup;
                this.ProductIdTranslation = item.ProductIdTranslation;
                this.ProductLine = item.ProductLine;
                this.ProductQty = item.ProductQty;
                this.Property = item.Property;
                this.PricingGroup = item.PricingGroup;
                this.PrintOnDemand = item.PrintOnDemand;
                this.PsStatus = item.PsStatus;
                this.RowColor = "White";
                this.SatCode = item.SatCode;
                this.SellOnAllPosters = item.SellOnAllPosters;
                this.SellOnAmazon = item.SellOnAmazon;
                this.SellOnAmazonSellerCentral = item.SellOnAmazonSellerCentral;
                this.SellOnEcommerce = item.SellOnEcommerce;
                this.SellOnFanatics = item.SellOnFanatics;
                this.SellOnGuitarCenter = item.SellOnGuitarCenter;
                this.SellOnHayneedle = item.SellOnHayneedle;
                this.SellOnTarget = item.SellOnTarget;
                this.SellOnTrends = item.SellOnTrends;
                this.SellOnWalmart = item.SellOnWalmart;
                this.SellOnWayfair = item.SellOnWayfair;
                this.ShortDescription = item.ShortDescription;
                this.Size = item.Size;
                this.StandardCost = item.StandardCost;
                this.StatsCode = item.StatsCode;
                this.Status = item.Status;
                this.EcommerceSubjectKeywords = item.EcommerceSubjectKeywords;
                this.TariffCode = item.TariffCode;
                this.Territory = item.Territory;
                this.Title = item.Title;
                this.Udex = item.Udex;
                this.Upc = item.Upc;
                this.Warranty = item.Warranty;
                this.WarrantyCheck = item.WarrantyCheck;
                this.WebsitePrice = item.WebsitePrice;
                this.Weight = item.Weight;
                this.Width = item.Width;
                if (item.Status != "Add")
                {
                    this.Status = "Update";
                }
            }
        }
        
        /// <summary>
        ///     Set SellOn values to N for any empty fields and sets PsStatus to I if empty
        /// </summary>
        public void SetFlagDefaults()
        {
            if (string.IsNullOrEmpty(this.PsStatus)) { this.PsStatus = "I"; }
            if (string.IsNullOrEmpty(this.SellOnAllPosters)) { this.SellOnAllPosters = "N"; }
            if (string.IsNullOrEmpty(this.SellOnAmazon)) { this.SellOnAmazon = "N"; }
            if (string.IsNullOrEmpty(this.SellOnAmazonSellerCentral)) { this.SellOnAmazonSellerCentral = "N"; }
            if (string.IsNullOrEmpty(this.SellOnEcommerce)) { this.SellOnEcommerce = "N"; }
            if (string.IsNullOrEmpty(this.SellOnFanatics)) { this.SellOnFanatics = "N"; }
            if (string.IsNullOrEmpty(this.SellOnGuitarCenter)) { this.SellOnGuitarCenter = "N"; }
            if (string.IsNullOrEmpty(this.SellOnHayneedle)) { this.SellOnHayneedle = "N"; }
            if (string.IsNullOrEmpty(this.SellOnTarget)) { this.SellOnTarget = "N"; }
            if (string.IsNullOrEmpty(this.SellOnTrends)) { this.SellOnTrends = "N"; }
            if (string.IsNullOrEmpty(this.SellOnWalmart)) { this.SellOnWalmart = "N"; }
            if (string.IsNullOrEmpty(this.SellOnWayfair)) { this.SellOnWayfair = "N"; }
            if (string.IsNullOrEmpty(this.PrintOnDemand)) { this.PrintOnDemand = "N"; }
            if (string.IsNullOrEmpty(this.WarrantyCheck)) { this.WarrantyCheck = "N"; }
        }
        

        #endregion //Methods

        #region Constructor

        public ItemObject(int prodType)
        {
            this.ProdType = prodType;
        }

        #endregion
    }
}
