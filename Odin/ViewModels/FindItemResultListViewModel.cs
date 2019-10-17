using Mvvm;
using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Odin.ViewModels
{
    public class FindItemResultListViewModel : ViewModelBase, INotifyPropertyChanged
    {

        #region Commands

        public ICommand SortItemIdCommand
        {
            get
            {
                if (_sortItemId == null)
                {
                    _sortItemId = new RelayCommand(param => SortItemIds());
                }
                return _sortItemId;
            }
        }
        private RelayCommand _sortItemId;

        public ICommand SortDescriptionCommand
        {
            get
            {
                if (_sortDescription == null)
                {
                    _sortDescription = new RelayCommand(param => SortDescriptions());
                }
                return _sortDescription;
            }
        }
        private RelayCommand _sortDescription;

        #endregion // Commands

        #region Properties

        /// <summary>
        ///     gets or sets the list of search items
        /// </summary>
        public List<SearchItem> SearchItems
        {
            get
            {
                return _searchItems;
            }
            set
            {
                _searchItems = value;
                OnPropertyChanged("SearchItems");
            }

        }
        private List<SearchItem> _searchItems = new List<SearchItem>();

        /// <summary>
        ///     Either Selects or deselects all items in the list
        /// </summary>
        public bool SelectAll
        {
            get
            {
                return _selectAll;
            }
            set
            {
                _selectAll = value;
                SetItemCheckBoxes(value);
                OnPropertyChanged("SelectAll");
            }
        }
        private bool _selectAll = false;

        /// <summary>
        ///     Flags current ItemId sort order
        /// </summary>
        private int ItemIdSearchOrder { get; set; }

        /// <summary>
        ///     Flags current Description sort order
        /// </summary>
        private int DescriptionIdSearchOrder { get; set; }

        #endregion // Properties

        #region Methods

        /// <summary>
        ///     Returns a list of selected items
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<SearchItem> ReturnSelectedItems()
        {
            ObservableCollection<SearchItem> ReturnList = new ObservableCollection<SearchItem>();
            foreach(SearchItem i in this.SearchItems)
            {
                if (i.IsSelected)
                {
                    ReturnList.Add(i);
                }
            }
            return ReturnList;
        }

        /// <summary>
        ///     Sets the IsSelected status for all items in the Search Item List
        /// </summary>
        /// <param name="value"></param>
        public void SetItemCheckBoxes(bool value)
        {
            List<SearchItem> ReturnList = new List<SearchItem>();
            foreach (SearchItem x in this.SearchItems)
            {
                x.IsSelected = value;
                ReturnList.Add(x);
            }
            this.SearchItems = ReturnList;
        }

        public void SortItemIds()
        {
            List<SearchItem> SortedList = new List<SearchItem>();
            if (ItemIdSearchOrder == 0)
            {
                SortedList = SearchItems.OrderByDescending(o => o.ItemId).ToList();
                ItemIdSearchOrder = 1;
            }
            else
            {
                SortedList = SearchItems.OrderBy(o => o.ItemId).ToList();
                ItemIdSearchOrder = 0;
            }
            this.SearchItems = SortedList;
        }

        public void SortDescriptions()
        {
            List<SearchItem> SortedList = new List<SearchItem>();
            if (DescriptionIdSearchOrder == 0)
            {
                SortedList = SearchItems.OrderByDescending(o => o.Description).ToList();
                DescriptionIdSearchOrder = 1;
            }
            else
            {
                SortedList = SearchItems.OrderBy(o => o.Description).ToList();
                DescriptionIdSearchOrder = 0;
            }
            this.SearchItems = SortedList;
        }

        #endregion // Methods

        #region Constructor

        public FindItemResultListViewModel(List<SearchItem> searchItems)
        {
            this.SearchItems = searchItems;
            this.ItemIdSearchOrder = 0;
            this.DescriptionIdSearchOrder = 0;
        }

        #endregion // Constructor

    }
}
