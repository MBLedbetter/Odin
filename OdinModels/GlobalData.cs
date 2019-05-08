using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdinModels
{
    public static class GlobalData
    {
        #region Public Properties

        #region Permissions

        public static List<string> UserPermissions
        {
            get
            {
                return _userPermissions;
            }
            set
            {
                _userPermissions = value;
            }
        }
        private static List<string> _userPermissions = new List<string>();

        #endregion // Permissions

        /// <summary>
        ///     Gets or sets AccountingGroups
        /// </summary>
        public static List<string> AccountingGroups
        {
            get
            {
                return _accountingGroups;
            }
            set
            {
                _accountingGroups = value;
            }
        }
        private static List<string> _accountingGroups = new List<string>();

        /// <summary>
        ///     Gets or sets Asins
        /// </summary>
        public static Dictionary<string, string> Asins
        {
            get
            {
                return _asins;
            }
            set
            {
                _asins = value;
            }
        }
        private static Dictionary<string, string> _asins = new Dictionary<string, string>();

        /// <summary>
        ///     Existing Bill of materials
        /// </summary>
        public static List<ChildElement> BillofMaterials
        {
            get
            {
                return _billofMaterials;
            }
            set
            {
                _billofMaterials = value;
            }

        }
        private static List<ChildElement> _billofMaterials = new List<ChildElement>();

        /// <summary>
        ///     Copyright dropdown values
        /// </summary>
        public static List<string> CopyrightGroups
        {
            get
            {
                return _copyright;
            }
            set
            {
                _copyright = value;
            }

        }
        private static List<string> _copyright = new List<string>();

        /// <summary>
        ///     Gets or sets CostProfileGroups
        /// </summary>
        public static List<string> CostProfileGroups
        {
            get
            {
                return _costProfileGroups;
            }
            set
            {
                _costProfileGroups = value;
            }
        }
        private static List<string> _costProfileGroups = new List<string>();

        /// <summary>
        ///     Gets or sets CountriesOfOrigin
        /// </summary>
        public static Dictionary<string, string> CountriesOfOrigin
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
        private static Dictionary<string, string> _countriesOfOrigin = new Dictionary<string, string>();

        /// <summary>
        ///     gets or sets the Dictionary of customers and their coresponding ids
        /// </summary>
        public static Dictionary<string, string> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;
            }
        }
        private static Dictionary<string, string> _customers = new Dictionary<string, string>();

        /// <summary>
        ///     Key value pair list of customer Names and their current customer id
        /// </summary>
        public static Dictionary<string, string> CustomerIdConversions
        {
            get
            {
                return _customerIdConversions;
            }
            set
            {
                _customerIdConversions = value;
            }
        }
        private static Dictionary<string, string> _customerIdConversions = new Dictionary<string, string>();

        /// <summary>
        ///     Gets or sets the _ecomFlagRequirement
        /// </summary>
        public static bool EcomFlagRequirement
        {
            get
            {
                return _ecomFlagRequirement;
            }
            set
            {
                _ecomFlagRequirement = value;
            }
        }
        private static bool _ecomFlagRequirement = false;

        /// <summary>
        ///     List of cached External Id Type values
        /// </summary>
        public static List<string> ExternalIdTypes
        {
            get
            {
                return _externalIdTypes;
            }
            set
            {
                _externalIdTypes = value;
            }
        }
        private static List<string> _externalIdTypes = new List<string>();

        /// <summary>
        ///     List of users to exempt from establishing an FTP connection
        /// </summary>
        public static List<string> FtpUserexceptions
        {
            get
            {
                return _ftpUserexceptions;
            }
            set
            {
                _ftpUserexceptions = value;
            }
        }
        private static List<string> _ftpUserexceptions = new List<string>();

        /// <summary>
        ///     List of Item Category Name / id from PS_ITM_CAT_TBL
        /// </summary>
        public static Dictionary<string, string> ItemCategories
        {
            get
            {
                return _itemCategories;
            }
            set
            {
                _itemCategories = value;
            }
        }
        private static Dictionary<string, string> _itemCategories = new Dictionary<string, string>();

        /// <summary>
        ///     Gets or sets ItemGroups
        /// </summary>
        public static List<string> ItemGroups
        {
            get
            {
                return _itemGroups;
            }
            set
            {
                _itemGroups = value;
            }
        }
        private static List<string> _itemGroups = new List<string>();

        /// <summary>
        ///     List of all existing item ids
        /// </summary>
        public static List<string> ItemIds
        {
            get
            {
                return _itemIds;
            }
            set
            {
                _itemIds = value;
            }
        }
        private static List<string> _itemIds = new List<string>();

        /// <summary>
        ///     List of item id suffixes
        /// </summary>
        public static List<string> ItemIdSuffixes
        {
            get
            {
                return _itemIdSuffixes;
            }
            set
            {
                _itemIdSuffixes = value;
            }
        }
        private static List<string> _itemIdSuffixes = new List<string>();

        /// <summary>
        ///     List of most recent record for all items
        /// </summary>
        public static List<ItemRecord> ItemRecords
        {
            get
            {
                return _itemRecords;
            }
            set
            {
                _itemRecords = value;
            }
        }
        private static List<ItemRecord> _itemRecords = new List<ItemRecord>();

        /// <summary>
        ///     List of ItemTypeExtensions pairs
        /// </summary>
        public static List<KeyValuePair<string, string>> ItemTypeExtensions
        {
            get
            {
                return _itemTypeExtensions;
            }
            set
            {
                _itemTypeExtensions = value;
                
            }
        }
        private static List<KeyValuePair<string, string>> _itemTypeExtensions = new List<KeyValuePair<string, string>>();

        /// <summary>
        ///     List of ItemTypeExtensions
        /// </summary>
        public static List<string> ItemTypeExtensionsList
        {
            get
            {
                return _itemTypeExtensionsList;
            }
            set
            {
                _itemTypeExtensionsList = value;
            }
        }
        private static List<string> _itemTypeExtensionsList = new List<string>();

        /// <summary>
        ///     Language dropdown values
        /// </summary>
        public static List<string> Languages
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
            }
        }
        private static List<string> _language = new List<string>();

        /// <summary>
        ///     License Group dropdown values
        /// </summary>
        public static List<string> Licenses
        {
            get
            {
                return _licenses;
            }
            set
            {
                _licenses = value;
            }

        }
        private static List<string> _licenses = new List<string>();

        /// <summary>
        ///     List of all item ids currently loaded in Odin
        /// </summary>
        public static List<string> LocalItemIds
        {
            get
            {
                return _localItemIds;
            }
            set
            {
                _localItemIds = value;
            }
        }
        private static List<string> _localItemIds = new List<string>();

        /// <summary>
        ///     Gets or sets MetaDescriptions
        /// </summary>
        public static List<string> MetaDescriptions
        {
            get
            {
                return _metaDescriptions;
            }
            set
            {
                _metaDescriptions = value;
            }
        }
        private static List<string> _metaDescriptions = new List<string>();

        /// <summary>
        ///     Gets or sets the NotificationNumber
        /// </summary>
        public static int NotificationNumber
        {
            get
            {
                return _notificationNumber;
            }
            set
            {
                _notificationNumber = value;
            }
        }
        private static int _notificationNumber = 0;

        /// <summary>
        ///     Gets or sets PricingGroups
        /// </summary>
        public static List<string> PricingGroups
        {
            get
            {
                return _pricingGroups;
            }
            set
            {
                _pricingGroups = value;
            }
        }
        private static List<string> _pricingGroups = new List<string>();

        /// <summary>
        ///     List of cached product category values
        /// </summary>
        public static List<string> ProductCategories
        {
            get
            {
                return _productCategories;
            }
            set
            {
                _productCategories = value;
            }
        }
        private static List<string> _productCategories = new List<string>();

        /// <summary>
        ///     List of cached product format/line/group objects
        /// </summary>
        public static List<ProductFormat> ProductFormats
        {
            get
            {
                return _productFormats;
            }
            set
            {
                _productFormats = value;
            }
        }
        private static List<ProductFormat> _productFormats = new List<ProductFormat>();

        /// <summary>
        ///     List of Product Format Exclusion Options
        /// </summary>
        public static List<string> ProductFormatExclusionOptions
        {
            get
            {
                return _productFormatExclusionOptions;
            }
            set
            {
                _productFormatExclusionOptions = value;
            }
        }
        private static List<string> _productFormatExclusionOptions = new List<string>();
        
        /// <summary>
        ///     List of accepted product groups
        /// </summary>
        public static List<string> ProductGoups
        {
            get
            {
                return _productGoups;
            }
            set
            {
                _productGoups = value;
            }
        }
        private static List<string> _productGoups = new List<string>();

        /// <summary>
        ///     List of accepted product lines
        /// </summary>
        public static List<KeyValuePair<string, string>> ProductLines
        {
            get
            {
                return _productLines;
            }
            set
            {
                _productLines = value;
            }
        }
        private static List<KeyValuePair<string, string>> _productLines = new List<KeyValuePair<string, string>>();
        
        /// <summary>
        ///     List of property / license combinations
        /// </summary>
        public static List<KeyValuePair<string, string>> Properties
        {
            get
            {
                return _properties;
            }
            set
            {
                _properties = value;
            }
        }
        private static List<KeyValuePair<string, string>> _properties = new List<KeyValuePair<string, string>>();

        /// <summary>
        ///     Gets or sets PsStatuses
        /// </summary>
        public static List<string> PsStatuses
        {
            get
            {
                return _psStatuses;
            }
            set
            {
                _psStatuses = value;
            }

        }
        private static List<string> _psStatuses = new List<string>();

        /// <summary>
        ///     Gets or sets RequestStatus
        /// </summary>
        public static List<string> RequestStatus
        {
            get
            {
                return _requestStatus;
            }
            set
            {
                _requestStatus = value;
            }
        }
        private static List<string> _requestStatus = new List<string>();

        /// <summary>
        ///     List of characters not allow in the peoplesoft database
        /// </summary>
        public static List<string> SpecialCharacters
        {
            get
            {
                return _specialCharacters;
            }
            set
            {
                _specialCharacters = value;
            }

        }
        private static List<string> _specialCharacters = new List<string>();

        /// <summary>
        ///     Gets or sets list of StatsCodes and their coresponding brand names
        /// </summary>
        public static Dictionary<string, string> StatsCodes
        {
            get
            {
                return _statsCodes;
            }
            set
            {
                _statsCodes = value;
            }
        }
        private static Dictionary<string, string> _statsCodes = new Dictionary<string, string>();
        
        /// <summary>
        ///     Gets or sets TariffCodes
        /// </summary>
        public static List<string> TariffCodes
        {
            get
            {
                return _tariffCodes;
            }
            set
            {
                _tariffCodes = value;
            }

        }
        private static List<string> _tariffCodes = new List<string>();

        /// <summary>
        ///     Gets or sets TemplateNames
        /// </summary>
        public static List<string> TemplateNames
        {
            get
            {
                return _templateNames;
            }
            set
            {
                _templateNames = value;
            }

        }
        private static List<string> _templateNames = new List<string>();

        /// <summary>
        ///     Gets or sets Territories
        /// </summary>
        public static List<string> Territories
        {
            get
            {
                return _territories;
            }
            set
            {
                _territories = value;
            }
        }
        private static List<string> _territories = new List<string>();

        /// <summary>
        ///     Dictionary of tool tips
        /// </summary>
        public static Dictionary<string, string> ToolTips
        {
            get
            {
                return _toolTips;
            }
            set
            {
                _toolTips = value;
            }
        }
        private static Dictionary<string, string> _toolTips = new Dictionary<string, string>();

        /// <summary>
        ///     Gets or sets UpcProductFormatExceptions
        /// </summary>
        public static List<string> UpcProductFormatExceptions
        {
            get
            {
                return _upcProductFormatExceptions;
            }
            set
            {
                _upcProductFormatExceptions = value;
            }
        }
        private static List<string> _upcProductFormatExceptions = new List<string>();
        
        /// <summary>
        ///     List of existing upcs / item id pairs
        /// </summary>
        public static List<KeyValuePair<string, string>> Upcs
        {
            get
            {
                return _upcs;
            }
            set
            {
                _upcs = value;
            }
        }
        private static List<KeyValuePair<string, string>> _upcs = new List<KeyValuePair<string, string>>();

        /// <summary>
        ///     Username of current user
        /// </summary>
        public static string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }
        private static string _userName = Environment.UserName.ToUpper();

        /// <summary>
        ///     Gets or sets UserNames
        /// </summary>
        public static List<string> UserNames
        {
            get
            {
                return _userNames;
            }
            set
            {
                _userNames = value;
            }
        }
        private static List<string> _userNames = new List<string>();

        /// <summary>
        ///     Gets or sets UserRoles
        /// </summary>
        public static List<string> UserRoles
        {
            get
            {
                return _userRoles;
            }
            set
            {
                _userRoles = value;
            }
        }
        private static List<string> _userRoles = new List<string>();

        /// <summary>
        ///     Gets or sets VariantGroupExclusionOptions
        /// </summary>
        public static List<string> VariantGroupExclusionOptions
        {
            get
            {
                return _variantGroupExclusionOptions;
            }
            set
            {
                _variantGroupExclusionOptions = value;
            }
        }
        private static List<string> _variantGroupExclusionOptions = new List<string>();

        /// <summary>
        ///     Gets or sets the WebCategoryList value. a Dictionary of website category names/ids from ODIN_WEB_CATEGORIES
        /// </summary>
        public static Dictionary<string, string> WebCategoryList
        {
            get { return _webCategoryList; }
            set { _webCategoryList = value; }
        }
        private static Dictionary<string, string> _webCategoryList = new Dictionary<string, string>();

        #endregion // Public Properties

        #region Methods

        /// <summary>
        ///     Clears all the global 
        /// </summary>
        public static void ClearValues()
        {
            AccountingGroups.Clear();
            CopyrightGroups.Clear();
            CostProfileGroups.Clear();
            CountriesOfOrigin.Clear();
            Customers.Clear();
            CustomerIdConversions.Clear();
            ExternalIdTypes.Clear();
            ItemCategories.Clear();
            ItemGroups.Clear();
            ItemIds.Clear();
            ItemIdSuffixes.Clear();
            ItemRecords.Clear();
            Languages.Clear();
            Licenses.Clear();
            LocalItemIds.Clear();
            MetaDescriptions.Clear();
            PricingGroups.Clear();
            ProductCategories.Clear();
            ProductFormats.Clear();
            ProductGoups.Clear();
            ProductLines.Clear();
            Properties.Clear();
            PsStatuses.Clear();
            RequestStatus.Clear();
            SpecialCharacters.Clear();
            TariffCodes.Clear();
            Territories.Clear();
            ToolTips.Clear();
            UpcProductFormatExceptions.Clear();
            Upcs.Clear();
            UserNames.Clear();
            UserRoles.Clear();
            WebCategoryList.Clear();
        }

        /// <summary>
        ///     Creates a list of all the item type extension prefixes ans suffixes
        /// </summary>
        public static void CreateItemTypeExtensionList()
        {
            List<string> newList = new List<string>();
            foreach(KeyValuePair<string,string> x in ItemTypeExtensions)
            {
                if(!newList.Contains(x.Key)&& x.Key!= "")
                {
                    newList.Add(x.Key);
                }
                if (!newList.Contains(x.Value) && x.Value != "")
                {
                    newList.Add(x.Value);
                }
            }
            ItemTypeExtensionsList = newList;
        }

        /// <summary>
        ///     Returns a List of all CountryOfOrigin 3 character codes
        /// </summary>
        /// <returns></returns>
        public static List<string> ReturnCountryofOriginCodes()
        {
            List<string> results = new List<string>();
            foreach(KeyValuePair<string,string> x in CountriesOfOrigin)
            {
                results.Add(x.Key);
            }
            results.Sort();
            return results;
        }

        /// <summary>
        ///     Returns a list of all Web Category values
        /// </summary>
        /// <returns></returns>
        public static List<string> ReturnWebCategoryListValues()
        {
            List<string> results = new List<string>() { "" };
            foreach (KeyValuePair<string, string> x in WebCategoryList)
            {
                results.Add(x.Value);
            }
            results.Sort();
            return results;
        }

        #endregion // Methods    

    }
}
