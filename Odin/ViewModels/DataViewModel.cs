using Mvvm;
using OdinModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Odin.ViewModels
{
    public class DataViewModel : ViewModelBase, INotifyPropertyChanged
    {

        #region Commands

        /// <summary>
        ///     Sorts the Existing ItemIds
        /// </summary>
        public ICommand SortExistingItemIdsCommand
        {
            get
            {
                if (_sortItemId == null)
                {
                    _sortItemId = new RelayCommand(param => SortExistingItemIds());
                }
                return _sortItemId;
            }
        }
        private RelayCommand _sortItemId;

        /// <summary>
        ///     Sorts Item Ids on tab 2
        /// </summary>
        public ICommand SortTab2ItemIdsCommand
        {
            get
            {
                if (_sortTab2ItemIds == null)
                {
                    _sortTab2ItemIds = new RelayCommand(param => SortTab2ItemIds());
                }
                return _sortTab2ItemIds;
            }
        }
        private RelayCommand _sortTab2ItemIds;

        /// <summary>
        ///     Sorts Upcs on tab 2
        /// </summary>
        public ICommand SortTab2ItemUpcsCommand
        {
            get
            {
                if (_sortTab2Upcs == null)
                {
                    _sortTab2Upcs = new RelayCommand(param => SortTab2Upcs());
                }
                return _sortTab2Upcs;
            }
        }
        private RelayCommand _sortTab2Upcs;

        /// <summary>
        ///     Sorts Parent Asins on tab 3
        /// </summary>
        public ICommand SortTab3ParentAsinsCommand
        {
            get
            {
                if (_sortTab3ParentAsins == null)
                {
                    _sortTab3ParentAsins = new RelayCommand(param => SortTab3ParentAsins());
                }
                return _sortTab3ParentAsins;
            }
        }
        private RelayCommand _sortTab3ParentAsins;

        /// <summary>
        ///     Sorts Variant Ids on tab 3
        /// </summary>
        public ICommand SortTab3VariantIdsCommand
        {
            get
            {
                if (_sortTab3VariantIds == null)
                {
                    _sortTab3VariantIds = new RelayCommand(param => SortTab3VariantIds());
                }
                return _sortTab3VariantIds;
            }
        }
        private RelayCommand _sortTab3VariantIds;

        #endregion // Commands

        #region Properties

        /// <summary>
        ///     Gets or sets the ExistingItemIdsOrder flag for ordering ExistingItemIds List
        /// </summary>
        private int ExistingItemIdsOrder { get; set; }

        /// <summary>
        ///     Gets or set a list of existing ItemIds
        /// </summary>
        public List<string> ExistingItemIds
        {
            get
            {
                return _existingItemIds;
            }
            set
            {
                _existingItemIds = value;
                OnPropertyChanged("ExistingItemIds");
            }
        }
        private List<string> _existingItemIds = new List<string>();

        /// <summary>
        ///     Gets or set a list of existing Item Id + Upc pairs
        /// </summary>
        public List<KeyValuePair<string, string>> ItemIdUpcs
        {
            get
            {
                return _itemIdUpcs;
            }
            set
            {
                _itemIdUpcs = value;
                OnPropertyChanged("ItemIdUpcs");
            }
        }
        List<KeyValuePair<string, string>> _itemIdUpcs = new List<KeyValuePair<string, string>>();

        /// <summary>
        ///     Gets or set a list of existing ProductVariations [variantId + ParentAsin]
        /// </summary>
        public List<KeyValuePair<string,string>> ProductVariations
        {
            get
            {
                return _productVariations;
            }
            set
            {
                _productVariations = value;
                OnPropertyChanged("ProductVariations");
            }
        }
        List<KeyValuePair<string, string>> _productVariations = new List<KeyValuePair<string, string>>();

        /// <summary>
        ///     Gets or sets the Tab2ItemIdsOrder flag for ordering Tab2ItemIds List
        /// </summary>
        private int Tab2ItemIdsOrder { get; set; }

        /// <summary>
        ///     Gets or sets the Tab2UpcsOrder flag for ordering Tab2Upcs List
        /// </summary>
        private int Tab2UpcsOrder { get; set; }

        /// <summary>
        ///     Gets or sets the Tab3ParentAsinsOrder flag for ordering Tab3ParentAsins List
        /// </summary>
        private int Tab3ParentAsinsOrder { get; set; }

        /// <summary>
        ///     Gets or sets the Tab3VariantIdsOrder flag for ordering Tab3VariantIds List
        /// </summary>
        private int Tab3VariantIdsOrder { get; set; }

        #endregion // Properties

        #region Methods

        /// <summary>
        ///     Sorts the ExistingItemIds by toggling ExistingItemIdsOrder int
        /// </summary>
        public void SortExistingItemIds()
        {
            List<string> SortedList = new List<string>();
            if (ExistingItemIdsOrder == 0)
            {
                SortedList = ExistingItemIds.OrderByDescending(o => o).ToList();
                ExistingItemIdsOrder = 1;
            }
            else
            {
                SortedList = ExistingItemIds.OrderBy(o => o).ToList();
                ExistingItemIdsOrder = 0;
            }
            this.ExistingItemIds = SortedList;
        }

        /// <summary>
        ///     Sorts the ItemIdUpcs by ItemId toggling Tab2ItemIdsOrder int
        /// </summary>
        public void SortTab2ItemIds()
        {
            List<KeyValuePair<string, string>> SortedList = new List<KeyValuePair<string, string>>();
            if (Tab2ItemIdsOrder == 0)
            {
                SortedList = ItemIdUpcs.OrderByDescending(o => o.Value).ToList();
                Tab2ItemIdsOrder = 1;
            }
            else
            {
                SortedList = ItemIdUpcs.OrderBy(o => o.Value).ToList();
                Tab2ItemIdsOrder = 0;
            }
            this.ItemIdUpcs = SortedList;
        }

        /// <summary>
        ///     Sorts the ItemIdUpcs by Upc toggling Tab2UpcsOrder int
        /// </summary>
        public void SortTab2Upcs()
        {
            List<KeyValuePair<string, string>> SortedList = new List<KeyValuePair<string, string>>();
            if (Tab2UpcsOrder == 0)
            {
                SortedList = ItemIdUpcs.OrderByDescending(o => o.Key).ToList();
                Tab2UpcsOrder = 1;
            }
            else
            {
                SortedList = ItemIdUpcs.OrderBy(o => o.Key).ToList();
                Tab2UpcsOrder = 0;
            }
            this.ItemIdUpcs = SortedList;
        }

        /// <summary>
        ///     Sorts the ProductVariations ParentAsin by toggling Tab3ParentAsinsOrder int
        /// </summary>
        public void SortTab3ParentAsins()
        {
            List<KeyValuePair<string, string>> SortedList = new List<KeyValuePair<string, string>>();
            if (Tab3ParentAsinsOrder == 0)
            {
                SortedList = ProductVariations.OrderByDescending(o => o.Value).ToList();
                Tab3ParentAsinsOrder = 1;
            }
            else
            {
                SortedList = ProductVariations.OrderBy(o => o.Value).ToList();
                Tab3ParentAsinsOrder = 0;
            }
            this.ProductVariations = SortedList;
        }

        /// <summary>
        ///     Sorts the ProductVariations VariantId by toggling Tab3VariantIdsOrder int
        /// </summary>
        public void SortTab3VariantIds()
        {
            List<KeyValuePair<string, string>> SortedList = new List<KeyValuePair<string, string>>();
            if (Tab3VariantIdsOrder == 0)
            {
                SortedList = ProductVariations.OrderByDescending(o => o.Key).ToList();
                Tab3VariantIdsOrder = 1;
            }
            else
            {
                SortedList = ProductVariations.OrderBy(o => o.Key).ToList();
                Tab3VariantIdsOrder = 0;
            }
            this.ProductVariations = SortedList;
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     FieldEditWindowViewModel constructor
        /// </summary>
        /// <param name="fieldType">Name of field</param>
        /// <param name="fieldValue">Value of field</param>
        /// <param name="fieldStatus">Flag for update or add</param>
        /// <param name="itemService"></param>
        /// <param name="emailService"></param>
        public DataViewModel()
        {
            this.ExistingItemIds = GlobalData.ItemIds;
            this.ExistingItemIds.Sort();
            this.ProductVariations = GlobalData.ProductVariations;
            this.ItemIdUpcs = GlobalData.Upcs;
            this.ExistingItemIdsOrder = 0;
            this.Tab2ItemIdsOrder = 0;
            this.Tab2UpcsOrder = 0;
            this.Tab3ParentAsinsOrder = 0;
            this.Tab3VariantIdsOrder = 0;
        }

        #endregion // Constructor
    }
}
