using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;

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

        /// <summary>
        ///     Unique identifier for product
        /// </summary>
        public string OdinIdentifier
        {
            get
            {
                return _odinIdentifier;
            }
            set
            {
                _odinIdentifier = value;
            }
        }
        private string _odinIdentifier = string.Empty;

        #region Ecommerce Properties
        
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
                this.Ecommerce_ImagePath2 = CreateEcommerce_ImageUrl(value);
                _altImageFile1 = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AltImageFile1"));
                }
            }
        }
        private string _altImageFile1 = string.Empty;
        public bool AltImageFile1Update = false;

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
                this.Ecommerce_ImagePath3 = CreateEcommerce_ImageUrl(value);
                _altImageFile2 = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AltImageFile2"));
                }
            }
        }
        private string _altImageFile2 = string.Empty;
        public bool AltImageFile2Update = false;

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
                this.Ecommerce_ImagePath4 = CreateEcommerce_ImageUrl(value);
                _altImageFile3 = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AltImageFile3"));
                }
            }
        }
        private string _altImageFile3 = string.Empty;
        public bool AltImageFile3Update = false;

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
                this.Ecommerce_ImagePath5 = CreateEcommerce_ImageUrl(value);
                _altImageFile4 = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AltImageFile4"));
                }
            }
        }
        private string _altImageFile4 = string.Empty;
        public bool AltImageFile4Update = false;
        
        public string Ecommerce_Asin
        {
            get
            {
                return _ecommerce_asin;
            }
            set
            {
                if (_ecommerce_asin != value) { Ecommerce_AsinUpdate = true; }
                _ecommerce_asin = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_Asin"));
                }
            }
        }
        private string _ecommerce_asin = string.Empty;
        public bool Ecommerce_AsinUpdate = false;

        public string Ecommerce_Bullet1
        {
            get
            {
                return _ecommerce_bullet1;
            }
            set
            {
                if (_ecommerce_bullet1 != value) { Ecommerce_Bullet1Update = true; }
                _ecommerce_bullet1 = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_Bullet1"));
                }
            }
        }
        private string _ecommerce_bullet1 = string.Empty;
        public bool Ecommerce_Bullet1Update = false;

        public string Ecommerce_Bullet2
        {
            get
            {
                return _ecommerce_bullet2;
            }
            set
            {
                if (_ecommerce_bullet2 != value) { Ecommerce_Bullet2Update = true; }
                _ecommerce_bullet2 = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_Bullet2"));
                }
            }
        }
        private string _ecommerce_bullet2 = string.Empty;
        public bool Ecommerce_Bullet2Update = false;

        public string Ecommerce_Bullet3
        {
            get
            {
                return _ecommerce_bullet3;
            }
            set
            {
                if (_ecommerce_bullet3 != value) { Ecommerce_Bullet3Update = true; }
                _ecommerce_bullet3 = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_Bullet3"));
                }
            }
        }
        private string _ecommerce_bullet3 = string.Empty;
        public bool Ecommerce_Bullet3Update = false;

        public string Ecommerce_Bullet4
        {
            get
            {
                return _ecommerce_bullet4;
            }
            set
            {
                if (_ecommerce_bullet4 != value) { Ecommerce_Bullet4Update = true; }
                _ecommerce_bullet4 = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_Bullet4"));
                }
            }
        }
        private string _ecommerce_bullet4 = string.Empty;
        public bool Ecommerce_Bullet4Update = false;

        public string Ecommerce_Bullet5
        {
            get
            {
                return _ecommerce_bullet5;
            }
            set
            {
                if (_ecommerce_bullet5 != value) { Ecommerce_Bullet5Update = true; }
                _ecommerce_bullet5 = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_Bullet5"));
                }
            }
        }
        private string _ecommerce_bullet5 = string.Empty;
        public bool Ecommerce_Bullet5Update = false;

        public string Ecommerce_Components
        {
            get
            {
                return _ecommerce_components;
            }
            set
            {
                if (_ecommerce_components != value) { Ecommerce_ComponentsUpdate = true; }
                _ecommerce_components = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_Components"));
                }
            }
        }
        private string _ecommerce_components = string.Empty;
        public bool Ecommerce_ComponentsUpdate = false;

        /// <summary>
        ///     Gets or sets the amazon cost
        /// </summary>
        public string Ecommerce_Cost
        {
            get
            {
                return _ecommerce_cost;
            }
            set
            {
                if (_ecommerce_cost != value) { Ecommerce_CostUpdate = true; }
                _ecommerce_cost = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_Cost"));
                }
            }
        }
        private string _ecommerce_cost = string.Empty;
        public bool Ecommerce_CostUpdate = false;

        /// <summary>
        ///     Gets or sets the country of origin ecommerce value
        /// </summary>
        public string Ecommerce_CountryofOrigin
        {
            get
            {
                return _ecommerce_countryofOrigin;
            }
            set
            {
                if (_ecommerce_countryofOrigin != value) { Ecommerce_CountryofOriginUpdate = true; }
                _ecommerce_countryofOrigin = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_CountryofOrigin"));
                }
            }
        }
        private string _ecommerce_countryofOrigin = string.Empty;
        public bool Ecommerce_CountryofOriginUpdate = false;

        public string Ecommerce_ExternalId
        {
            get
            {
                return _ecommerce_externalID;
            }
            set
            {
                if (_ecommerce_externalID != value) { Ecommerce_ExternalIdUpdate = true; }
                _ecommerce_externalID = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ExternalId"));
                }
            }
        }
        private string _ecommerce_externalID = string.Empty;
        public bool Ecommerce_ExternalIdUpdate = false;

        public string Ecommerce_ExternalIdType
        {
            get
            {
                return _ecommerce_externalIdType;
            }
            set
            {
                if (_ecommerce_externalIdType != value) { Ecommerce_ExternalIdTypeUpdate = true; }
                _ecommerce_externalIdType = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ExternalIdType"));
                }
            }
        }
        private string _ecommerce_externalIdType = string.Empty;
        public bool Ecommerce_ExternalIdTypeUpdate = false;

        public string Ecommerce_ImagePath1
        {
            get
            {
                return _ecommerce_imagePath1;
            }
            set
            {
                if (_ecommerce_imagePath1 != value) { Ecommerce_ImagePath1Update = true; }
                _ecommerce_imagePath1 = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ImagePath1"));
                }
            }
        }
        private string _ecommerce_imagePath1 = string.Empty;
        public bool Ecommerce_ImagePath1Update = false;

        public string Ecommerce_ImagePath2
        {
            get
            {
                return _ecommerce_imagePath2;
            }
            set
            {
                if (_ecommerce_imagePath2 != value) { Ecommerce_ImagePath2Update = true; }
                _ecommerce_imagePath2 = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ImagePath2"));
                }
            }
        }
        private string _ecommerce_imagePath2 = string.Empty;
        public bool Ecommerce_ImagePath2Update = false;

        public string Ecommerce_ImagePath3
        {
            get
            {
                return _ecommerce_imagePath3;
            }
            set
            {
                if (_ecommerce_imagePath3 != value) { Ecommerce_ImagePath3Update = true; }
                _ecommerce_imagePath3 = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ImagePath3"));
                }
            }
        }
        private string _ecommerce_imagePath3 = string.Empty;
        public bool Ecommerce_ImagePath3Update = false;

        public string Ecommerce_ImagePath4
        {
            get
            {
                return _ecommerce_imagePath4;
            }
            set
            {
                if (_ecommerce_imagePath4 != value) { Ecommerce_ImagePath4Update = true; }
                _ecommerce_imagePath4 = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ImagePath4"));
                }
            }
        }
        private string _ecommerce_imagePath4 = string.Empty;
        public bool Ecommerce_ImagePath4Update = false;

        public string Ecommerce_ImagePath5
        {
            get
            {
                return _ecommerce_imagePath5;
            }
            set
            {
                if (_ecommerce_imagePath5 != value) { Ecommerce_ImagePath5Update = true; }
                _ecommerce_imagePath5 = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ImagePath5"));
                }
            }
        }
        private string _ecommerce_imagePath5 = string.Empty;
        public bool Ecommerce_ImagePath5Update = false;

        public string Ecommerce_ItemAlias
        {
            get
            {
                return _ecommerce_itemAlias;
            }
            set
            {
                _ecommerce_itemAlias = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ItemAlias"));
                }
            }
        }
        private string _ecommerce_itemAlias = string.Empty;

        public string Ecommerce_ItemHeight
        {
            get
            {
                return _ecommerce_itemHeight;
            }
            set
            {
                if (_ecommerce_itemHeight != value) { Ecommerce_ItemHeightUpdate = true; }
                _ecommerce_itemHeight = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ItemHeight"));
                }
            }
        }
        private string _ecommerce_itemHeight = string.Empty;
        public bool Ecommerce_ItemHeightUpdate = false;

        public string Ecommerce_ItemLength
        {
            get
            {
                return _ecommerce_itemLength;
            }
            set
            {
                if (_ecommerce_itemLength != value) { Ecommerce_ItemLengthUpdate = true; }
                _ecommerce_itemLength = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ItemLength"));
                }
            }
        }
        private string _ecommerce_itemLength = string.Empty;
        public bool Ecommerce_ItemLengthUpdate = false;

        public string Ecommerce_ItemName
        {
            get
            {
                return _ecommerce_itemName;
            }
            set
            {
                if (_ecommerce_itemName != value) { Ecommerce_ItemNameUpdate = true; }
                _ecommerce_itemName = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ItemName"));
                }
            }
        }
        private string _ecommerce_itemName = string.Empty;
        public bool Ecommerce_ItemNameUpdate = false;

        public string Ecommerce_ItemWeight
        {
            get
            {
                return _ecommerce_itemWeight;
            }
            set
            {
                if (_ecommerce_itemWeight != value) { Ecommerce_ItemWeightUpdate = true; }
                _ecommerce_itemWeight = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ItemWeight"));
                }
            }
        }
        private string _ecommerce_itemWeight = string.Empty;
        public bool Ecommerce_ItemWeightUpdate = false;

        public string Ecommerce_ItemWidth
        {
            get
            {
                return _ecommerce_itemWidth;
            }
            set
            {
                if (_ecommerce_itemWidth != value) { Ecommerce_ItemWidthUpdate = true; }
                _ecommerce_itemWidth = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ItemWidth"));
                }
            }
        }
        private string _ecommerce_itemWidth = string.Empty;
        public bool Ecommerce_ItemWidthUpdate = false;

        public string Ecommerce_ModelName
        {
            get
            {
                return _ecommerce_modelName;
            }
            set
            {
                if (_ecommerce_modelName != value) { Ecommerce_ModelNameUpdate = true; }
                _ecommerce_modelName = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ModelName"));
                }
            }
        }
        private string _ecommerce_modelName = string.Empty;
        public bool Ecommerce_ModelNameUpdate = false;

        public string Ecommerce_PackageHeight
        {
            get
            {
                return _ecommerce_packageHeight;
            }
            set
            {
                if (_ecommerce_packageHeight != value) { Ecommerce_PackageHeightUpdate = true; }
                _ecommerce_packageHeight = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_PackageHeight"));
                }
            }
        }
        private string _ecommerce_packageHeight = string.Empty;
        public bool Ecommerce_PackageHeightUpdate = false;

        public string Ecommerce_PackageLength
        {
            get
            {
                return _ecommerce_packageLength;
            }
            set
            {
                if (_ecommerce_packageLength != value) { Ecommerce_PackageLengthUpdate = true; }
                _ecommerce_packageLength = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_PackageLength"));
                }
            }
        }
        private string _ecommerce_packageLength = string.Empty;
        public bool Ecommerce_PackageLengthUpdate = false;

        public string Ecommerce_PackageWeight
        {
            get
            {
                return _ecommerce_packageWeight;
            }
            set
            {
                if (_ecommerce_packageWeight != value) { Ecommerce_PackageWeightUpdate = true; }
                _ecommerce_packageWeight = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_PackageWeight"));
                }
            }
        }
        private string _ecommerce_packageWeight = string.Empty;
        public bool Ecommerce_PackageWeightUpdate = false;

        public string Ecommerce_PackageWidth
        {
            get
            {
                return _ecommerce_packageWidth;
            }
            set
            {
                if (_ecommerce_packageWidth != value) { Ecommerce_PackageWidthUpdate = true; }
                _ecommerce_packageWidth = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_PackageWidth"));
                }
            }
        }
        private string _ecommerce_packageWidth = string.Empty;
        public bool Ecommerce_PackageWidthUpdate = false;

        public string Ecommerce_PageQty
        {
            get
            {
                return _ecommerce_pageQty;
            }
            set
            {
                if (_ecommerce_pageQty != value) { Ecommerce_PageQtyUpdate = true; }
                _ecommerce_pageQty = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_PageQty"));
                }
            }
        }
        private string _ecommerce_pageQty = string.Empty;
        public bool Ecommerce_PageQtyUpdate = false;

        public string Ecommerce_ProductCategory
        {
            get
            {
                return _ecommerce_productCategory;
            }
            set
            {
                if (_ecommerce_productCategory != value) { Ecommerce_ProductCategoryUpdate = true; }
                _ecommerce_productCategory = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ProductCategory"));
                }
            }
        }
        private string _ecommerce_productCategory = string.Empty;
        public bool Ecommerce_ProductCategoryUpdate = false;

        public string Ecommerce_ProductDescription
        {
            get
            {
                return _ecommerce_productDescription;
            }
            set
            {
                if (_ecommerce_productDescription != value) { Ecommerce_ProductDescriptionUpdate = true; }
                _ecommerce_productDescription = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ProductDescription"));
                }
            }
        }
        private string _ecommerce_productDescription = string.Empty;
        public bool Ecommerce_ProductDescriptionUpdate = false;

        public string Ecommerce_ProductSubcategory
        {
            get
            {
                return _ecommerce_productSubcategory;
            }
            set
            {
                if (_ecommerce_productSubcategory != value) { Ecommerce_ProductSubcategoryUpdate = true; }
                _ecommerce_productSubcategory = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ProductSubcategory"));
                }
            }
        }
        private string _ecommerce_productSubcategory = string.Empty;
        public bool Ecommerce_ProductSubcategoryUpdate = false;

        public string Ecommerce_ManufacturerName
        {
            get
            {
                return _ecommerce_manufacturerName;
            }
            set
            {
                if (_ecommerce_manufacturerName != value) { Ecommerce_ManufacturerNameUpdate = true; }
                _ecommerce_manufacturerName = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_ManufacturerName"));
                }
            }
        }
        private string _ecommerce_manufacturerName = string.Empty;
        public bool Ecommerce_ManufacturerNameUpdate = false;

        public string Ecommerce_Msrp
        {
            get
            {
                return _ecommerce_msrp;
            }
            set
            {
                if (_ecommerce_msrp != value) { Ecommerce_MsrpUpdate = true; }
                _ecommerce_msrp = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_Msrp"));
                }
            }
        }
        private string _ecommerce_msrp = string.Empty;
        public bool Ecommerce_MsrpUpdate = false;

        public string Ecommerce_SearchTerms
        {
            get
            {
                return _ecommerce_searchTerms;
            }
            set
            {
                if (_ecommerce_searchTerms != value) { Ecommerce_SearchTermsUpdate = true; }
                _ecommerce_searchTerms = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_SearchTerms"));
                }
            }
        }
        private string _ecommerce_searchTerms = string.Empty;
        public bool Ecommerce_SearchTermsUpdate = false;

        public string Ecommerce_Size
        {
            get
            {
                return _ecommerce_size;
            }
            set
            {
                if (_ecommerce_size != value) { Ecommere_SizeUpdate = true; }
                _ecommerce_size = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_Size"));
                }
            }
        }
        private string _ecommerce_size = string.Empty;
        public bool Ecommere_SizeUpdate = false;

        public string Ecommerce_Upc
        {
            get
            {
                return _ecommerce_upc;
            }
            set
            {
                if (_ecommerce_upc != value) { Ecommere_UpcUpdate = true; }
                _ecommerce_upc = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ecommerce_Upc"));
                }
            }
        }
        private string _ecommerce_upc = string.Empty;
        public bool Ecommere_UpcUpdate = false;

        #endregion // Ecommerce Properties

        #region B2B Properties

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Category"));
                }
            }
        }
        private string _category = string.Empty;
        public bool CategoryUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Category2"));
                }
            }
        }
        private string _category2 = string.Empty;
        public bool Category2Update = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Category3"));
                }
            }
        }
        private string _category3 = string.Empty;
        public bool Category3Update = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Copyright"));
                }
            }
        }
        private string _copyright = string.Empty;
        public bool CopyrightUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CombinedCategories"));
                }
            }
        }
        private string _combinedCategories = string.Empty;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("InStockDate"));
                }
            }
        }
        private string _inStockDate = string.Empty;
        public bool InStockDateUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ItemKeywords"));
                }
            }
        }
        private string _itemKeywords = string.Empty;
        public bool ItemKeywordsUpdate = false;

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
                this.Ecommerce_ImagePath1 = CreateEcommerce_ImageUrl(value);
                _imagePath = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ImagePath"));
                }
            }
        }
        private string _imagePath = string.Empty;
        public bool ImagePathUpdate = false;
        
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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("License"));
                }
            }
        }
        private string _license = string.Empty;
        public bool LicenseUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("LicenseBeginDate"));
                }
            }
        }
        private string _licenseBeginDate = string.Empty;
        public bool LicenseBeginDateUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MetaDescription"));
                }
            }
        }
        private string _metaDescription = string.Empty;
        public bool MetaDescriptionUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("OnSite"));
                }
            }
        }
        private string _onSite = string.Empty;
        
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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Property"));
                }
            }
        }
        private string _property = string.Empty;
        public bool PropertyUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ShortDescription"));
                }
            }
        }
        private string _shortDescription = string.Empty;
        public bool ShortDescriptionUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Size"));
                }
            }
        }
        private string _size = string.Empty;
        public bool SizeUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Title"));
                }
            }
        }
        private string _title = string.Empty;
        public bool TitleUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("WebsitePrice"));
                }
            }
        }
        private string _websitePrice = string.Empty;
        public bool WebsitePriceUpdate = false;

        #endregion // B2B Properties

        #region Peoplesoft Properties

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AccountingGroup"));
                }

            }
        }
        private string _accountingGroup = string.Empty;
        public bool AccountingGroupUpdate = false;
        private int _active = 0;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BillOfMaterials"));
                }
            }
        }
        private List<ChildElement> _billOfMaterials = new List<ChildElement>();
        public string BillOfMaterialsString
        {
            get
            {
                return _billOfMaterialsString;
            }
            set
            {
                _billOfMaterialsString = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BillOfMaterialsString"));
                }
            }
        }
        private string _billOfMaterialsString = string.Empty;

        public bool BillOfMaterialsUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CasepackHeight"));
                }
            }
        }
        private string _casepackHeight = string.Empty;
        public bool CasepackHeightUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CasepackLength"));
                }
            }
        }
        private string _casepackLength = string.Empty;
        public bool CasepackLengthUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CasepackQty"));
                }
            }
        }
        private string _casepackQty = string.Empty;
        public bool CasepackQtyUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CasepackUpc"));
                }
            }
        }
        private string _casepackUpc = string.Empty;
        public bool CasepackUpcUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CasepackWidth"));
                }
            }
        }
        private string _casepackWidth = string.Empty;
        public bool CasepackWidthUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CasepackWeight"));
                }
            }
        }
        private string _casepackWeight = string.Empty;
        public bool CasepackWeightUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Color"));
                }
            }
        }
        private string _color = string.Empty;
        public bool ColorUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CountryOfOrigin"));
                }
            }
        }
        private string _countryOfOrigin = string.Empty;
        public bool CountryOfOriginUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CostProfileGroup"));
                }
            }
        }
        private string _costProfileGroup = string.Empty;
        public bool CostProfileGroupUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DefaultActualCostCad"));
                }
            }
        }
        private string _defaultActualCostCad = string.Empty;
        public bool DefaultActualCostCadUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DefaultActualCostUsd"));
                }
            }
        }
        private string _defaultActualCostUsd = string.Empty;
        public bool DefaultActualCostUsdUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Description"));
                }
            }
        }
        private string _description = string.Empty;
        public bool DescriptionUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DirectImport"));
                }
            }
        }
        private string _directImport = string.Empty;
        public bool DirectImportUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Duty"));
                }
            }
        }
        private string _duty = string.Empty;
        public bool DutyUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ean"));
                }
            }
        }
        private string _ean = string.Empty;
        public bool EanUpdate = false;
        
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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Gpc"));
                }
            }
        }
        private string _gpc = string.Empty;
        public bool GpcUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Height"));
                }
            }
        }
        private string _height = string.Empty;
        public bool HeightUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("InnerpackHeight"));
                }
            }
        }
        private string _innerpackHeight = string.Empty;
        public bool InnerpackHeightUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("InnerpackLength"));
                }
            }
        }
        private string _innerpackLength = string.Empty;
        public bool InnerpackLengthUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("InnerpackQuantity"));
                }
            }
        }
        private string _innerpackQuantity = string.Empty;
        public bool InnerpackQuantityUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("InnerpackUpc"));
                }
            }
        }
        private string _innerpackUpc = string.Empty;
        public bool InnerpackUpcUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("InnerpackWidth"));
                }
            }
        }
        private string _innerpackWidth = string.Empty;
        public bool InnerpackWidthUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("InnerpackWeight"));
                }
            }
        }
        private string _innerpackWeight = string.Empty;
        public bool InnerpackWeightUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Isbn"));
                }
            }
        }
        private string _isbn = string.Empty;
        public bool IsbnUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ItemCategory"));
                }
            }
        }
        private string _itemCategory = string.Empty;
        public bool ItemCategoryUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ItemFamily"));
                }
            }
        }
        private string _itemFamily = string.Empty;
        public bool ItemFamilyUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ItemGroup"));
                }
            }
        }
        private string _itemGroup = string.Empty;
        public bool ItemGroupUpdate = false;

        public string ItemId
        {
            get
            {
                return _itemId;
            }
            set
            {
                _itemId = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ItemId"));
                }
            }
        }
        private string _itemId = string.Empty;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Language"));
                }
            }
        }
        private string _language = string.Empty;
        public bool LanguageUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Length"));
                }
            }
        }
        private string _length = string.Empty;
        public bool LengthUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ListPriceCad"));
                }
            }
        }
        private string _listPriceCad = string.Empty;
        public bool ListPriceCadUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ListPriceMxn"));
                }
            }
        }
        private string _listPriceMxn = string.Empty;
        public bool ListPriceMxnUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ListPriceUsd"));
                }
            }
        }
        private string _listPriceUsd = string.Empty;
        public bool ListPriceUsdUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MfgSource"));
                }
            }
        }
        private string _mfgSource = string.Empty;
        public bool MfgSourceUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Msrp"));
                }
            }
        }
        private string _msrp = string.Empty;
        public bool MsrpUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MsrpCad"));
                }
            }
        }
        private string _msrpCad = string.Empty;
        public bool MsrpCadUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MsrpMxn"));
                }
            }
        }
        private string _msrpMxn = string.Empty;
        public bool MsrpMxnUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("PricingGroup"));
                }
            }
        }
        private string _pricingGroup = string.Empty;
        public bool PricingGroupUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("PrintOnDemand"));
                }
            }
        }
        private string _printOnDemand = "";
        public bool PrintOnDemandUpdate = false;

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

                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductFormat"));
                }
            }
        }
        private string _productFormat = string.Empty;
        public bool ProductFormatUpdate = false;

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

                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductGroup"));
                }
            }
        }
        private string _productGroup = string.Empty;
        public bool ProductGroupUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductIdTranslation"));
                }
            }
        }
        private List<ChildElement> _productIdTranslation = new List<ChildElement>();
        public string ProductIdTranslationString
        {
            get
            {
                return _productIdTranslationString;
            }
            set
            {
                _productIdTranslationString = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductIdTranslationString"));
                }
            }
        }
        private string _productIdTranslationString = string.Empty;
        /// <summary>
        ///     Flag to track if product id translation has been updated
        /// </summary>
        public bool ProductIdTranslationUpdate = false;

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

                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductLine"));
                }
            }
        }
        private string _productLine = string.Empty;
        public bool ProductLineUpdate = false;

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

                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductQty"));
                }
            }
        }
        private string _productQty = string.Empty;
        public bool ProductQtyUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("PsStatus"));
                }
            }
        }
        private string _psStatus = string.Empty;
        public bool PsStatusUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SatCode"));
                }
            }
        }
        private string _satCode = string.Empty;
        public bool SatCodeUpdate = false;
        
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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SellOnAttributes"));
                }
            }
        }
        private List<string> _sellOnAttributes = new List<string>();
        public bool SellOnAttributesUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SellOnAllPosters"));
                }
            }
        }
        private string _sellOnAllPosters = "";
        public bool SellOnAllPostersUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SellOnAmazon"));
                }
            }
        }
        private string _sellOnAmazon = "";
        public bool SellOnAmazonUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SellOnAmazonSellerCentral"));
                }
            }
        }
        private string _sellOnAmazonSellerCentral = "";
        public bool SellOnAmazonSellerCentralUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SellOnFanatics"));
                }
            }
        }
        private string _sellOnFanatics = "";
        public bool SellOnFanaticsUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SellOnGuitarCenter"));
                }
            }
        }
        private string _sellOnGuitarCenter = "";
        public bool SellOnGuitarCenterUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SellOnHayneedle"));
                }
            }
        }
        private string _sellOnHayneedle = "";
        public bool SellOnHayneedleUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SellOnTarget"));
                }
            }
        }
        private string _sellOnTarget = "";
        public bool SellOnTargetUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SellOnTrends"));
                }
            }
        }
        private string _sellOnTrends = "";
        public bool SellOnTrendsUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SellOnWalmart"));
                }
            }
        }
        private string _sellOnWalmart = "";
        public bool SellOnWalmartUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SellOnWayfair"));
                }
            }
        }
        private string _sellOnWayfair = "";
        public bool SellOnWayfairUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("StandardCost"));
                }
            }
        }
        private string _standardCost = string.Empty;
        public bool StandardCostUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("StatsCode"));
                }
            }
        }
        private string _statsCode = string.Empty;
        public bool StatsCodeUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("TariffCode"));
                }
            }
        }
        private string _tariffCode = string.Empty;
        public bool TariffCodeUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Territory"));
                }
            }
        }
        private string _territory = string.Empty;
        public bool TerritoryUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Udex"));
                }
            }
        }
        private string _udex = string.Empty;
        public bool UdexUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Upc"));
                }
            }
        }
        private string _upc = string.Empty;
        public bool UpcUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Weight"));
                }
            }
        }
        private string _weight = string.Empty;
        public bool WeightUpdate = false;

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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Width"));
                }
            }
        }
        private string _width = string.Empty;
        public bool WidthUpdate = false;

        #endregion // Peoplesoft Properties        

        #region Odin Properties

        public int ItemRow
        {
            get
            {
                return _itemRow;
            }
            set
            {
                _itemRow = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ItemRow"));
                }
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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProdType"));
                }
            }
        }
        private int _prodType = 1;
        
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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("RecordDate"));
                }
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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("RowColor"));
                }
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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Status"));
                }
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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("UserName"));
                }
            }
        }
        private string _userName = string.Empty;

        #endregion // Odin Properties

        #endregion // Properties

        #region Methods

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
        public string CreateEcommerce_ImageUrl(string value)
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
                    returnValue = "http://trendsinternational.com/media/catalog/product/";
                    string[] values = value.Split('\\');
                    int last = values.Length;
                    value = values[last - 1];
                    string a = (!string.IsNullOrEmpty(value.Substring(0, 1))) ? value.Substring(0, 1) + "/" : "";
                    string b = (!string.IsNullOrEmpty(value.Substring(1, 1))) ? value.Substring(1, 1) + "/" : "";
                    values = value.Split('.');
                    value = value.Replace("." + values[values.Length - 1], "");
                    returnValue += a + b + value.TrimEnd('.') + ".jpg";
                }
            }
            return returnValue;
        }

        /// <summary>
        ///     Combine List of Bill of Materials into one string
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
        ///     Combine List of productIdTranslations into one string
        /// </summary>
        /// <param name="productIdTranslationList"></param>
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
        ///     Set all fieldupdate values to false.
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
            this.Ecommerce_AsinUpdate = false;
            this.Ecommerce_Bullet1Update = false;
            this.Ecommerce_Bullet2Update = false;
            this.Ecommerce_Bullet3Update = false;
            this.Ecommerce_Bullet4Update = false;
            this.Ecommerce_Bullet5Update = false;
            this.Ecommerce_ComponentsUpdate = false;
            this.Ecommerce_CostUpdate = false;
            this.Ecommerce_ExternalIdUpdate = false;
            this.Ecommerce_ExternalIdTypeUpdate = false;
            this.Ecommerce_ImagePath1Update = false;
            this.Ecommerce_ImagePath2Update = false;
            this.Ecommerce_ImagePath3Update = false;
            this.Ecommerce_ImagePath4Update = false;
            this.Ecommerce_ImagePath5Update = false;
            this.Ecommerce_ItemHeightUpdate = false;
            this.Ecommerce_ItemLengthUpdate = false;
            this.Ecommerce_ItemNameUpdate = false;
            this.Ecommerce_ItemWeightUpdate = false;
            this.Ecommerce_ItemWidthUpdate = false;
            this.Ecommerce_ModelNameUpdate = false;
            this.Ecommerce_PackageHeightUpdate = false;
            this.Ecommerce_PackageLengthUpdate = false;
            this.Ecommerce_PackageWeightUpdate = false;
            this.Ecommerce_PackageWidthUpdate = false;
            this.Ecommerce_PageQtyUpdate = false;
            this.Ecommerce_ProductCategoryUpdate = false;
            this.Ecommerce_ProductDescriptionUpdate = false;
            this.Ecommerce_ProductSubcategoryUpdate = false;
            this.Ecommerce_ManufacturerNameUpdate = false;
            this.Ecommerce_MsrpUpdate = false;
            this.Ecommerce_SearchTermsUpdate = false;
            this.Ecommere_SizeUpdate = false;
            this.Ecommere_UpcUpdate = false;
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
            this.WebsitePriceUpdate = false;
            this.WeightUpdate = false;
            this.WidthUpdate = false;
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
            if (item.CheckUpdates())
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
                this.Ecommerce_Asin = item.Ecommerce_Asin;
                this.Ecommerce_Bullet1 = item.Ecommerce_Bullet1;
                this.Ecommerce_Bullet2 = item.Ecommerce_Bullet2;
                this.Ecommerce_Bullet3 = item.Ecommerce_Bullet3;
                this.Ecommerce_Bullet4 = item.Ecommerce_Bullet4;
                this.Ecommerce_Bullet5 = item.Ecommerce_Bullet5;
                this.Ecommerce_Components = item.Ecommerce_Components;
                this.Ecommerce_Cost = item.Ecommerce_Cost;
                this.Ecommerce_ExternalId = item.Ecommerce_ExternalId;
                this.Ecommerce_ExternalIdType = item.Ecommerce_ExternalIdType;
                this.Ecommerce_ImagePath1 = item.Ecommerce_ImagePath1;
                this.Ecommerce_ImagePath2 = item.Ecommerce_ImagePath2;
                this.Ecommerce_ImagePath3 = item.Ecommerce_ImagePath3;
                this.Ecommerce_ImagePath4 = item.Ecommerce_ImagePath4;
                this.Ecommerce_ImagePath5 = item.Ecommerce_ImagePath5;
                this.Ecommerce_ItemHeight = item.Ecommerce_ItemHeight;
                this.Ecommerce_ItemLength = item.Ecommerce_ItemLength;
                this.Ecommerce_ItemName = item.Ecommerce_ItemName;
                this.Ecommerce_ItemWeight = item.Ecommerce_ItemWeight;
                this.Ecommerce_ItemWidth = item.Ecommerce_ItemWidth;
                this.Ecommerce_ModelName = item.Ecommerce_ModelName;
                this.Ecommerce_PackageHeight = item.Ecommerce_PackageHeight;
                this.Ecommerce_PackageLength = item.Ecommerce_PackageLength;
                this.Ecommerce_PackageWeight = item.Ecommerce_PackageWeight;
                this.Ecommerce_PackageWidth = item.Ecommerce_PackageWidth;
                this.Ecommerce_PageQty = item.Ecommerce_PageQty;
                this.Ecommerce_ProductCategory = item.Ecommerce_ProductCategory;
                this.Ecommerce_ProductDescription = item.Ecommerce_ProductDescription;
                this.Ecommerce_ProductSubcategory = item.Ecommerce_ProductSubcategory;
                this.Ecommerce_ManufacturerName = item.Ecommerce_ManufacturerName;
                this.Ecommerce_Msrp = item.Ecommerce_Msrp;
                this.Ecommerce_SearchTerms = item.Ecommerce_SearchTerms;
                this.Ecommerce_Size = item.Ecommerce_Size;
                this.Ecommerce_Upc = item.Ecommerce_Upc;
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
                this.TariffCode = item.TariffCode;
                this.Territory = item.Territory;
                this.Title = item.Title;
                this.Udex = item.Udex;
                this.Upc = item.Upc;
                this.WebsitePrice = item.WebsitePrice;
                this.Weight = item.Weight;
                this.Width = item.Width;
                if(item.Status!="Add")
                {
                    this.Status = "Update";
                }
            }
        }

        #region Update Check Methods
        
        /// <summary>
        ///     Check field updates. If item has updated field return true.
        /// </summary>
        /// <returns>True if any fields have been updated</returns>
        public bool CheckUpdates()
        {
            if (AccountingGroupUpdate == true) { return true; }
            if (AltImageFile1Update == true) { return true; }
            if (AltImageFile2Update == true) { return true; }
            if (AltImageFile3Update == true) { return true; }
            if (AltImageFile4Update == true) { return true; }
            if (BillOfMaterialsUpdate == true) { return true; }
            if (CasepackHeightUpdate == true) { return true; }
            if (CasepackLengthUpdate == true) { return true; }
            if (CasepackQtyUpdate == true) { return true; }
            if (CasepackUpcUpdate == true) { return true; }
            if (CasepackWidthUpdate == true) { return true; }
            if (CasepackWeightUpdate == true) { return true; }
            if (CategoryUpdate == true) { return true; }
            if (Category2Update == true) { return true; }
            if (Category3Update == true) { return true; }
            if (ColorUpdate == true) { return true; }
            if (CopyrightUpdate == true) { return true; }
            if (CountryOfOriginUpdate == true) { return true; }
            if (CostProfileGroupUpdate == true) { return true; }
            if (DefaultActualCostUsdUpdate == true) { return true; }
            if (DefaultActualCostCadUpdate == true) { return true; }
            if (DescriptionUpdate == true) { return true; }
            if (DirectImportUpdate == true) { return true; }
            if (DutyUpdate == true) { return true; }
            if (EanUpdate == true) { return true; }
            if (Ecommerce_AsinUpdate == true) { return true; }
            if (Ecommerce_Bullet1Update == true) { return true; }
            if (Ecommerce_Bullet2Update == true) { return true; }
            if (Ecommerce_Bullet3Update == true) { return true; }
            if (Ecommerce_Bullet4Update == true) { return true; }
            if (Ecommerce_Bullet5Update == true) { return true; }
            if (Ecommerce_ComponentsUpdate == true) { return true; }
            if (Ecommerce_CostUpdate == true) { return true; }
            if (Ecommerce_ExternalIdUpdate == true) { return true; }
            if (Ecommerce_ExternalIdTypeUpdate == true) { return true; }
            if (Ecommerce_ImagePath1Update == true) { return true; }
            if (Ecommerce_ImagePath2Update == true) { return true; }
            if (Ecommerce_ImagePath3Update == true) { return true; }
            if (Ecommerce_ImagePath4Update == true) { return true; }
            if (Ecommerce_ImagePath5Update == true) { return true; }
            if (Ecommerce_ItemHeightUpdate == true) { return true; }
            if (Ecommerce_ItemLengthUpdate == true) { return true; }
            if (Ecommerce_ItemNameUpdate == true) { return true; }
            if (Ecommerce_ItemWeightUpdate == true) { return true; }
            if (Ecommerce_ItemWidthUpdate == true) { return true; }
            if (Ecommerce_ModelNameUpdate == true) { return true; }
            if (Ecommerce_PackageHeightUpdate == true) { return true; }
            if (Ecommerce_PackageLengthUpdate == true) { return true; }
            if (Ecommerce_PackageWeightUpdate == true) { return true; }
            if (Ecommerce_PackageWidthUpdate == true) { return true; }
            if (Ecommerce_PageQtyUpdate == true) { return true; }
            if (Ecommerce_ProductCategoryUpdate == true) { return true; }
            if (Ecommerce_ProductDescriptionUpdate == true) { return true; }
            if (Ecommerce_ProductSubcategoryUpdate == true) { return true; }
            if (Ecommerce_ManufacturerNameUpdate == true) { return true; }
            if (Ecommerce_MsrpUpdate == true) { return true; }
            if (Ecommerce_SearchTermsUpdate == true) { return true; }
            if (Ecommere_SizeUpdate == true) { return true; }
            if (Ecommere_UpcUpdate == true) { return true; }
            if (GpcUpdate == true) { return true; }
            if (HeightUpdate == true) { return true; }
            if (ImagePathUpdate == true) { return true; }
            if (InStockDateUpdate == true) { return true; }
            if (InnerpackHeightUpdate == true) { return true; }
            if (InnerpackLengthUpdate == true) { return true; }
            if (InnerpackQuantityUpdate == true) { return true; }
            if (InnerpackUpcUpdate == true) { return true; }
            if (InnerpackWidthUpdate == true) { return true; }
            if (InnerpackWeightUpdate == true) { return true; }
            if (IsbnUpdate == true) { return true; }
            if (ItemCategoryUpdate == true) { return true; }
            if (ItemFamilyUpdate == true) { return true; }
            if (ItemGroupUpdate == true) { return true; }
            if (ItemKeywordsUpdate == true) { return true; }
            if (LanguageUpdate == true) { return true; }
            if (LengthUpdate == true) { return true; }
            if (LicenseUpdate == true) { return true; }
            if (LicenseBeginDateUpdate == true) { return true; }
            if (ListPriceCadUpdate == true) { return true; }
            if (ListPriceUsdUpdate == true) { return true; }
            if (ListPriceMxnUpdate == true) { return true; }
            if (MetaDescriptionUpdate == true) { return true; }
            if (MfgSourceUpdate == true) { return true; }
            if (MsrpUpdate == true) { return true; }
            if (MsrpCadUpdate == true) { return true; }
            if (MsrpMxnUpdate == true) { return true; }
            if (ProductFormatUpdate == true) { return true; }
            if (ProductGroupUpdate == true) { return true; }
            if (ProductIdTranslationUpdate == true) { return true; }
            if (ProductLineUpdate == true) { return true; }
            if (ProductQtyUpdate == true) { return true; }
            if (PricingGroupUpdate == true) { return true; }
            if (PrintOnDemandUpdate == true) { return true; }
            if (PsStatusUpdate == true) { return true; }
            if (SatCodeUpdate == true) { return true; }
            if (SellOnAllPostersUpdate == true) { return true; }
            if (SellOnAmazonUpdate == true) { return true; }
            if (SellOnAmazonSellerCentralUpdate == true) { return true; }
            if (SellOnFanaticsUpdate == true) { return true; }
            if (SellOnGuitarCenterUpdate == true) { return true; }
            if (SellOnHayneedleUpdate == true) { return true; }
            if (SellOnTargetUpdate == true) { return true; }
            if (SellOnTrendsUpdate == true) { return true; }
            if (SellOnWalmartUpdate == true) { return true; }
            if (SellOnWayfairUpdate == true) { return true; }
            if (ShortDescriptionUpdate == true) { return true; }
            if (SizeUpdate == true) { return true; }
            if (StandardCostUpdate == true) { return true; }
            if (StatsCodeUpdate == true) { return true; }
            if (TariffCodeUpdate == true) { return true; }
            if (TerritoryUpdate == true) { return true; }
            if (TitleUpdate == true) { return true; }
            if (UdexUpdate == true) { return true; }
            if (UpcUpdate == true) { return true; }
            if (WebsitePriceUpdate == true) { return true; }
            if (WeightUpdate == true) { return true; }
            if (WidthUpdate == true) { return true; }
            return false;
        }
        
        /// <summary>
         ///    Check fields for amazon table to see if any have been updated.
         /// </summary>
         /// <returns> true if any fields have been updated </returns>
        public bool EcommerceValuesUpdate()
        {
            if (Ecommerce_AsinUpdate == true) { return true; }
            if (Ecommerce_Bullet1Update == true) { return true; }
            if (Ecommerce_Bullet2Update == true) { return true; }
            if (Ecommerce_Bullet3Update == true) { return true; }
            if (Ecommerce_Bullet4Update == true) { return true; }
            if (Ecommerce_Bullet5Update == true) { return true; }
            if (Ecommerce_ComponentsUpdate == true) { return true; }
            if (Ecommerce_CostUpdate == true) { return true; }
            if (Ecommerce_ExternalIdUpdate == true) { return true; }
            if (Ecommerce_ExternalIdTypeUpdate == true) { return true; }
            if (Ecommerce_ImagePath1Update == true) { return true; }
            if (Ecommerce_ImagePath2Update == true) { return true; }
            if (Ecommerce_ImagePath3Update == true) { return true; }
            if (Ecommerce_ImagePath4Update == true) { return true; }
            if (Ecommerce_ImagePath5Update == true) { return true; }
            if (Ecommerce_ItemHeightUpdate == true) { return true; }
            if (Ecommerce_ItemLengthUpdate == true) { return true; }
            if (Ecommerce_ItemNameUpdate == true) { return true; }
            if (Ecommerce_ItemWeightUpdate == true) { return true; }
            if (Ecommerce_ItemWidthUpdate == true) { return true; }
            if (Ecommerce_ModelNameUpdate == true) { return true; }
            if (Ecommerce_PackageHeightUpdate == true) { return true; }
            if (Ecommerce_PackageLengthUpdate == true) { return true; }
            if (Ecommerce_PackageWeightUpdate == true) { return true; }
            if (Ecommerce_PackageWidthUpdate == true) { return true; }
            if (Ecommerce_PageQtyUpdate == true) { return true; }
            if (Ecommerce_ProductCategoryUpdate == true) { return true; }
            if (Ecommerce_ProductDescriptionUpdate == true) { return true; }
            if (Ecommerce_ProductSubcategoryUpdate == true) { return true; }
            if (Ecommerce_ManufacturerNameUpdate == true) { return true; }
            if (Ecommerce_MsrpUpdate == true) { return true; }
            if (Ecommerce_SearchTermsUpdate == true) { return true; }
            if (Ecommere_SizeUpdate == true) { return true; }
            if (Ecommere_UpcUpdate == true) { return true; }
            if (CountryOfOriginUpdate == true) { return true; }

            return false;
        }

        /// <summary>
        ///    Check fields for BuItemsInv table to see if any have been updated.
        /// </summary>
        /// <returns></returns>
        public bool BuItemsInvUpdate()
        {
            if (CountryOfOriginUpdate == true) { return true; }
            if (MfgSourceUpdate == true) { return true; }
            if (DefaultActualCostCadUpdate == true) { return true; }
            if (DefaultActualCostUsdUpdate == true) { return true; }
            return false;
        }

        /// <summary>
        ///    Check fields for CmItemMethod table to see if any have been updated.
        /// </summary>
        /// <returns></returns>
        public bool CmItemMethodUpdate()
        {
            if (CostProfileGroupUpdate == true) { return true; }
            return false;
        }

        /// <summary>
        ///    Check fields for PS_EN_BOM_COMPS table to see if any have been updated.
        /// </summary>
        /// <returns></returns>
        public bool EnBomCompsUpdate()
        {
            if (BillOfMaterialsUpdate == true) { return true; }
            return false;
        }

        /// <summary>
        ///    Check fields for fxdbinlocInv table to see if any have been updated.
        /// </summary>
        /// <returns></returns>
        public bool FxdBinLocInvUpdate()
        {
            if (this.ItemFamilyUpdate == true) { return true; }
            if (this.ItemGroupUpdate == true) { return true; }
            return false;
        }

        /// <summary>
        ///     Checks web flags. Returns true if set to 'Y'
        /// </summary>
        /// <returns></returns>
        public bool HasWeb()
        {
            if(this.SellOnTrends == "Y") { return true; }
            return false;
        }

        public bool HasEcommerce()
        {
            if (this.SellOnAllPosters == "Y") { return true; }
            if (this.SellOnAmazon == "Y") { return true; }
            if (this.SellOnAmazonSellerCentral == "Y") { return true; }
            if (this.SellOnFanatics == "Y") { return true; }
            if (this.SellOnGuitarCenter == "Y") { return true; }
            if (this.SellOnHayneedle == "Y") { return true; }
            if (this.SellOnTarget == "Y") { return true; }
            if (this.SellOnWalmart == "Y") { return true; }
            if (this.SellOnWayfair == "Y") { return true; }
            return false;
        }

        /// <summary>
        ///     Checks to see if item is cleared to be sold on any web platform
        /// </summary>
        /// <returns>true if flags are set</returns>
        public bool ImageRequired()
        {
            if (this.SellOnAllPosters == "Y") { return true; }
            if (this.SellOnAmazon == "Y") { return true; }
            if (this.SellOnAmazonSellerCentral == "Y") { return true; }
            if (this.SellOnFanatics == "Y") { return true; }
            if (this.SellOnGuitarCenter == "Y") { return true; }
            if (this.SellOnHayneedle == "Y") { return true; }
            if (this.SellOnTarget == "Y") { return true; }
            if (this.SellOnTrends == "Y") { return true; }
            if (this.SellOnWalmart == "Y") { return true; }
            if (this.SellOnWayfair == "Y") { return true; }
            return false;
        }

        /// <summary>
        ///    Check fields for inv items table to see if any have been updated.
        /// </summary>
        /// <returns></returns>
        public bool InvItemsUpdate()
        {
            if (TariffCodeUpdate == true) { return true; }
            if (ColorUpdate == true) { return true; }
            if (HeightUpdate == true) { return true; }
            if (LengthUpdate == true) { return true; }
            if (DescriptionUpdate == true) { return true; }
            if (WeightUpdate == true) { return true; }
            if (WidthUpdate == true) { return true; }
            if (UpcUpdate == true) { return true; }

            return false;
        }

        /// <summary>
        ///     Check field for ItemAttribEx table to see if any have been updated
        /// </summary>
        /// <returns></returns>
        public bool ItemAttribExUpdate()
        {
            if (ImagePathUpdate == true) { return true; }
            if (AltImageFile1Update == true) { return true; }
            if (AltImageFile2Update == true) { return true; }
            if (AltImageFile3Update == true) { return true; }
            if (AltImageFile4Update == true) { return true; }
            if (CasepackHeightUpdate == true) { return true; }
            if (CasepackLengthUpdate == true) { return true; }
            if (CasepackQtyUpdate == true) { return true; }
            if (CasepackUpcUpdate == true) { return true; }
            if (CasepackWeightUpdate == true) { return true; }
            if (CasepackWidthUpdate == true) { return true; }
            if (DirectImportUpdate == true) { return true; }
            if (InnerpackHeightUpdate == true) { return true; }
            if (InnerpackLengthUpdate == true) { return true; }
            if (InnerpackQuantityUpdate == true) { return true; }
            if (InnerpackUpcUpdate == true) { return true; }
            if (InnerpackWeightUpdate == true) { return true; }
            if (InnerpackWidthUpdate == true) { return true; }
            if (LicenseBeginDateUpdate == true) { return true; }
            if (PrintOnDemandUpdate == true) { return true; }
            if (ProductFormatUpdate == true) { return true; }
            if (ProductLineUpdate == true) { return true; }
            if (ProductGroupUpdate == true) { return true; }
            if (InnerpackWidthUpdate == true) { return true; }
            if (SatCodeUpdate == true) { return true; }
            if (SellOnTrendsUpdate == true) { return true; }
            if (WebsitePriceUpdate == true) { return true; }
            return false;
        }

        /// <summary>
        ///    Check fields for language table to see if any have been updated.
        /// </summary>
        /// <returns></returns>
        public bool ItemLanguageUpdate()
        {
            if (LanguageUpdate == true) { return true; }
            return false;
        }

        /// <summary>
        ///    Check fields for territory table to see if any have been updated.
        /// </summary>
        /// <returns></returns>
        public bool ItemTerritoryUpdate()
        {
            if (TerritoryUpdate == true) { return true; }
            return false;
        }

        /// <summary>
        ///    Check fields for web info table to see if any have been updated.
        /// </summary>
        /// <returns></returns>
        public bool ItemWebInfoUpdate()
        {
            if (ItemKeywordsUpdate == true) { return true; }
            if (CategoryUpdate == true) { return true; }
            if (Category2Update == true) { return true; }
            if (Category3Update == true) { return true; }
            if (PropertyUpdate == true) { return true; }
            if (CopyrightUpdate == true) { return true; }
            if (TitleUpdate == true) { return true; }
            if (LicenseUpdate == true) { return true; }
            if (ShortDescriptionUpdate == true) { return true; }
            if (MetaDescriptionUpdate == true) { return true; }
            if (ProductQtyUpdate == true) { return true; }
            if (SizeUpdate == true) { return true; }
            if (InStockDateUpdate == true) { return true; }
            return false;
        }

        /// <summary>
        ///    Check fields for master item table to see if any have been updated.
        /// </summary>
        /// <returns></returns>
        public bool MasterItemUpdate()
        {
            if (ItemCategoryUpdate == true) { return true; }
            if (CostProfileGroupUpdate == true) { return true; }
            if (DescriptionUpdate == true) { return true; }
            if (ItemGroupUpdate == true) { return true; }
            if (PsStatusUpdate == true) { return true; }
            if (ItemFamilyUpdate == true) { return true; }

            return false;
        }

        /// <summary>
        ///    Check fields for prod Item table to see if any have been updated.
        /// </summary>
        /// <returns></returns>
        public bool ProdItemUpdate()
        {
            if (ItemCategoryUpdate == true) { return true; }
            if (StatsCodeUpdate == true) { return true; }
            if (DescriptionUpdate == true) { return true; }
            if (IsbnUpdate == true) { return true; }
            if (EanUpdate == true) { return true; }
            if (UdexUpdate == true) { return true; }
            if (GpcUpdate == true) { return true; }
            return false;
        }

        /// <summary>
        ///    Check fields for ProdPgrpLnk table to see if any have been updated.
        /// </summary>
        /// <returns></returns>
        public bool ProdPgrpLnkUpdate()
        {
            if (AccountingGroupUpdate == true) { return true; }
            if (PricingGroupUpdate == true) { return true; }
            return false;
        }

        /// <summary>
        ///    Check fields for Prod Price table to see if any have been updated.
        /// </summary>
        /// <returns></returns>
        public bool ProdPriceBuUpdate()
        {
            if (ProductGroupUpdate == true) { return true; }
            if (ListPriceCadUpdate == true) { return true; }
            if (ListPriceUsdUpdate == true) { return true; }
            if (ListPriceMxnUpdate == true) { return true; }
            if (MsrpUpdate == true) { return true; }
            if (MsrpCadUpdate == true) { return true; }
            if (MsrpMxnUpdate == true) { return true; }
            return false;
        }

        /// <summary>
        ///    Check fields for Prod Price table to see if any have been updated.
        /// </summary>
        /// <returns></returns>
        public bool ProdPriceUpdate()
        {
            if (ProductGroupUpdate == true) { return true; }
            if (ListPriceCadUpdate == true) { return true; }
            if (ListPriceUsdUpdate == true) { return true; }
            if (ListPriceMxnUpdate == true) { return true; }
            if (MsrpUpdate == true) { return true; }
            if (MsrpCadUpdate == true) { return true; }
            if (MsrpMxnUpdate == true) { return true; }
            return false;
        }

        /// <summary>
        ///    Check fields for PurchItemAttr table to see if any have been updated.
        /// </summary>
        /// <returns></returns>
        public bool PurchItemAttrUpdate()
        {
            if (DescriptionUpdate == true) { return true; }
            if (StandardCostUpdate == true) { return true; }
            return false;
        }

        /// <summary>
        ///    Check fields for PvItmCategory table to see if any have been updated.
        /// </summary>
        /// <returns></returns>
        public bool PvItmCategoryUpdate()
        {
            if (ItemCategoryUpdate == true) { return true; }
            return false;
        }

        /// <summary>
        ///    Check sell on flags to see if any have been updated.
        /// </summary>
        /// <returns></returns>
        public bool SellOnFlagUpdate()
        {
            if (SellOnAllPostersUpdate == true) { return true; }
            if (SellOnAmazonUpdate == true) { return true; }
            if (SellOnAmazonSellerCentralUpdate == true) { return true; }
            if (SellOnFanaticsUpdate == true) { return true; }
            if (SellOnGuitarCenterUpdate == true) { return true; }
            if (SellOnHayneedleUpdate == true) { return true; }
            if (SellOnTargetUpdate == true) { return true; }
            if (SellOnWalmartUpdate == true) { return true; }
            if (SellOnWayfairUpdate == true) { return true; }
            if (PrintOnDemandUpdate == true) { return true; }
            return false;
        }

        /// <summary>
        ///     Set SellOn values to N for any empty fields and sets PsStatus to I if empty
        /// </summary>
        public void UpdateSellOnValues()
        {
            if (string.IsNullOrEmpty(this.PsStatus)) { this.PsStatus = "I"; }
            if (string.IsNullOrEmpty(this.SellOnAllPosters)) { this.SellOnAllPosters="N"; }
            if (string.IsNullOrEmpty(this.SellOnAmazon)) { this.SellOnAmazon = "N"; }
            if (string.IsNullOrEmpty(this.SellOnAmazonSellerCentral)) { this.SellOnAmazonSellerCentral = "N"; }
            if (string.IsNullOrEmpty(this.SellOnFanatics)) { this.SellOnFanatics = "N"; }
            if (string.IsNullOrEmpty(this.SellOnGuitarCenter)) { this.SellOnGuitarCenter = "N"; }
            if (string.IsNullOrEmpty(this.SellOnHayneedle)) { this.SellOnHayneedle = "N"; }
            if (string.IsNullOrEmpty(this.SellOnTarget)) { this.SellOnTarget = "N"; }
            if (string.IsNullOrEmpty(this.SellOnWalmart)) { this.SellOnWalmart = "N"; }
            if (string.IsNullOrEmpty(this.SellOnWayfair)) { this.SellOnWayfair = "N"; }
            if (string.IsNullOrEmpty(this.PrintOnDemand)) { this.PrintOnDemand = "N"; }
        }

        #endregion // Update Check Methods

        #endregion //Methods

        #region Constructor

        public ItemObject()
        {
        }

        /// <summary>
        ///		The constructor for this item.
        /// </summary>
        /// 
        /// <param name="itemId">
        ///		This item's unique item Id.
        /// </param>
        /// 
        /// <param name="description">
        ///		This item's description.
        /// </param>
        /// 
        /// <param name="accountingGroup">
        ///     This item's accounting group.
        /// </param>
        /// 
        /// <param name="casepackHeight">
        ///     This item's casepack height.
        /// </param>
        /// 
        /// <param name="casepackLength">
        ///     This item's casepack length
        /// </param>
        /// 
        /// <param name="casepackWidth">
        ///     This item's casepack width
        /// </param>
        /// 
        /// <param name="color">
        ///     This item's color.
        /// </param>
        /// 
        /// <param name="countryOfOrigin">
        ///     This item's country of origin.
        /// </param>
        /// 
        /// <param name="costProfileGroup">
        ///     This item's cost profile group.
        /// </param>
        /// 
        /// <param name="directImport">
        ///     This item's direct import status.
        /// </param>
        /// 
        /// <param name="height">
        ///     This item's height.
        /// </param>
        /// 
        /// <param name="innerpackHeight">
        ///     This item's innerpack height.
        /// </param>
        /// 
        /// <param name="innerpackLength">
        ///     This item's innerpack length.
        /// </param>
        /// 
        /// <param name="innerpackQuantity">
        ///     This item's innerpack quantity.
        /// </param>
        /// 
        /// <param name="innerpackWidth">
        ///     This item's innerpack width.
        /// </param>
        /// 
        /// <param name="itemGroup">
        ///     This item's item group.
        /// </param>
        /// 
        /// <param name="length">
        ///     This item's length.
        /// </param>
        /// 
        /// <param name="listPrice">
        ///     This item's list price.
        /// </param>
        /// 
        /// <param name="productFormat">
        ///     This item's product format.
        /// </param>
        /// 
        /// <param name="productGroup">
        ///     This item's product group.
        /// </param>
        /// 
        /// <param name="productLine">
        ///     This item's product line.
        /// </param>
        /// 
        /// <param name="pricingGroup">
        ///     This item's pricing group.
        /// </param>
        /// 
        /// <param name="printOnDemand">
        ///     This item's print on demand field.
        /// </param>
        /// 
        /// <param name="statsCode">
        ///     This item's stats code.
        /// </param>
        /// 
        /// <param name="standardCost">
        ///     This item's stamdard cost.
        /// </param>
        /// 
        /// <param name="tariffCode">
        ///     This item's tariff code.
        /// </param>
        /// 
        /// <param name="upc">
        ///     This item's upc.
        /// </param>
        /// <param name="width">
        ///     This item's width.
        /// </param>
        public ItemObject(
            string status,
            string altImageFile1,
            string altImageFile2,
            string altImageFile3,
            string altImageFile4,
            string accountingGroup,
            List<ChildElement> billOfMaterials,
            string casepackHeight,
            string casepackLength,
            string casepackQty,
            string casepackUpc,
            string casepackWidth,
            string casepackWeight,
            string category,
            string category2,
            string category3,
            string color,
            string copyright,
            string countryOfOrigin,
            string costProfileGroup,
            string defaultActualCostUsd,
            string defaultActualCostCad,
            string description,
            string directImport,
            string duty,
            string ean,
            string ecommerce_Asin,
            string ecommerce_Bullet1,
            string ecommerce_Bullet2,
            string ecommerce_Bullet3,
            string ecommerce_Bullet4,
            string ecommerce_Bullet5,
            string ecommerce_Components,
            string ecommerce_CostAmazon,
            string ecommerce_ExternalID,
            string ecommerce_ExternalIdType,
            string ecommerce_ItemHeight,
            string ecommerce_ItemLength,
            string ecommerce_ItemName,
            string ecommerce_ItemWeight,
            string ecommerce_ItemWidth,
            string ecommerce_ModelName,
            string ecommerce_PackageHeight,
            string ecommerce_PackageLength,
            string ecommerce_PackageWeight,
            string ecommerce_PackageWidth,
            string ecommerce_PageQty,
            string ecommerce_ProductCategory,
            string ecommerce_ProductDescription,
            string ecommerce_ProductSubcategory,
            string ecommerce_ManufacturerName,
            string ecommerce_Msrp,
            string ecommerce_SearchTerms,
            string ecommerce_Size,
            string ecommerce_Upc,
            string gpc,
            string height,
            string imagePath,
            string innerpackHeight,
            string innerpackLength,
            string innerpackQuantity,
            string innerpackUpc,
            string innerpackWidth,
            string innerpackWeight,
            string inStockDate,
            string isbn,
            string itemCategory,
            string itemFamily,
            string itemGroup,
            string itemId,
            string itemKeywords,
            string language,
            string length,
            string license,
            string licenseBeginDate,
            string listPriceCad,
            string listPriceUsd,
            string listPriceMxn,
            string metaDescription,
            string mfgSource,
            string msrp,
            string msrpCad,
            string msrpMxn,
            string productFormat,
            string productGroup,
            List<ChildElement> productIdTranslation,
            string productLine,
            string productQty,
            string property,
            string pricingGroup,
            string printOnDemand,
            string psStatus,
            string satCode,
            string sellOnAllPosters,
            string sellOnAmazon,
            string sellOnFanatics,
            string sellOnGuitarCenter,
            string sellOnHayneedle,
            string sellOnTarget,
            string sellOnTrends,
            string sellOnWalmart,
            string sellOnWayfair,
            string shortDescription,
            string size,
            string standardCost,
            string statsCode,
            string tariffCode,
            string territory,
            string title,
            string udex,
            string upc,
            string websitePrice,
            string weight,
            string width
            )
        {
            this.AltImageFile1 = altImageFile1;
            this.AltImageFile2 = altImageFile2;
            this.AltImageFile3 = altImageFile3;
            this.AltImageFile4 = altImageFile4;
            this.AccountingGroup = accountingGroup;
            this.BillOfMaterials = billOfMaterials;
            this.CasepackHeight = casepackHeight;
            this.CasepackLength = casepackLength;
            this.CasepackQty = casepackQty;
            this.CasepackUpc = casepackUpc;
            this.CasepackWidth = casepackWidth;
            this.CasepackWeight = casepackWeight;
            this.Category = category;
            this.Category2 = category2;
            this.Category3 = category3;
            this.Color = color;
            this.Copyright = copyright;
            this.CountryOfOrigin = countryOfOrigin;
            this.CostProfileGroup = costProfileGroup;
            this.DefaultActualCostUsd = defaultActualCostUsd;
            this.DefaultActualCostCad = defaultActualCostCad;
            this.Description = description;
            this.DirectImport = directImport;
            this.Duty = duty;
            this.Ean = ean;
            this.Ecommerce_Asin = ecommerce_Asin;
            this.Ecommerce_Bullet1 = ecommerce_Bullet1;
            this.Ecommerce_Bullet2 = ecommerce_Bullet2;
            this.Ecommerce_Bullet3 = ecommerce_Bullet3;
            this.Ecommerce_Bullet4 = ecommerce_Bullet4;
            this.Ecommerce_Bullet5 = ecommerce_Bullet5;
            this.Ecommerce_Components = ecommerce_Components;
            this.Ecommerce_Cost = ecommerce_CostAmazon;
            this.Ecommerce_ExternalId = ecommerce_ExternalID;
            this.Ecommerce_ExternalIdType = ecommerce_ExternalIdType;
            this.Ecommerce_ItemHeight = ecommerce_ItemHeight;
            this.Ecommerce_ItemLength = ecommerce_ItemLength;
            this.Ecommerce_ItemName = ecommerce_ItemName;
            this.Ecommerce_ItemWeight = ecommerce_ItemWeight;
            this.Ecommerce_ItemWidth = ecommerce_ItemWidth;
            this.Ecommerce_ModelName = ecommerce_ModelName;
            this.Ecommerce_PackageHeight = ecommerce_PackageHeight;
            this.Ecommerce_PackageLength = ecommerce_PackageLength;
            this.Ecommerce_PackageWeight = ecommerce_PackageWeight;
            this.Ecommerce_PackageWidth = ecommerce_PackageWidth;
            this.Ecommerce_PageQty = ecommerce_PageQty;
            this.Ecommerce_ProductCategory = ecommerce_ProductCategory;
            this.Ecommerce_ProductDescription = ecommerce_ProductDescription;
            this.Ecommerce_ProductSubcategory = ecommerce_ProductSubcategory;
            this.Ecommerce_ManufacturerName = ecommerce_ManufacturerName;
            this.Ecommerce_Msrp = ecommerce_Msrp;
            this.Ecommerce_SearchTerms = ecommerce_SearchTerms;
            this.Ecommerce_Size = ecommerce_Size;
            this.Ecommerce_Upc = ecommerce_Upc;
            this.Gpc = gpc;
            this.Height = height;
            this.ImagePath = imagePath;
            this.InnerpackHeight = innerpackHeight;
            this.InnerpackLength = innerpackLength;
            this.InnerpackQuantity = innerpackQuantity;
            this.InnerpackUpc = innerpackUpc;
            this.InnerpackWidth = innerpackWidth;
            this.InnerpackWeight = innerpackWeight;
            this.InStockDate = inStockDate;
            this.Isbn = isbn;
            this.ItemCategory = itemCategory;
            this.ItemFamily = itemFamily;
            this.ItemGroup = itemGroup;
            this.ItemId = itemId;
            this.ItemKeywords = itemKeywords;
            this.Language = language;
            this.Length = length;
            this.License = license;
            this.LicenseBeginDate = licenseBeginDate;
            this.ListPriceCad = listPriceCad;
            this.ListPriceUsd = listPriceUsd;
            this.ListPriceMxn = listPriceMxn;
            this.MetaDescription = metaDescription;
            this.MfgSource = mfgSource;
            this.Msrp = msrp;
            this.MsrpCad = msrpCad;
            this.MsrpMxn = msrpMxn;
            this.ProductFormat = productFormat;
            this.ProductGroup = productGroup;
            this.ProductIdTranslation = productIdTranslation;
            this.ProductLine = productLine;
            this.ProductQty = productQty;
            this.Property = property;
            this.PricingGroup = pricingGroup;
            this.PrintOnDemand = printOnDemand;
            this.PsStatus = psStatus;
            this.SatCode = satCode;
            this.SellOnAllPosters = sellOnAllPosters;
            this.SellOnAmazon = sellOnAmazon;
            this.SellOnFanatics = sellOnFanatics;
            this.SellOnGuitarCenter = sellOnGuitarCenter;
            this.SellOnHayneedle = sellOnHayneedle;
            this.SellOnTarget = sellOnTarget;
            this.SellOnTrends = sellOnTrends;
            this.SellOnWalmart = sellOnWalmart;
            this.SellOnWayfair = sellOnWayfair;
            this.ShortDescription = shortDescription;
            this.Size = size;
            this.StandardCost = standardCost;
            this.StatsCode = statsCode;
            this.Status = status;
            this.TariffCode = tariffCode;
            this.Territory = territory;
            this.Title = title;
            this.Udex = udex;
            this.Upc = upc;
            this.WebsitePrice = websitePrice;
            this.Weight = weight;
            this.Width = width;
            ResetUpdate();
        }
        #endregion
    }
}
