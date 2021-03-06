﻿using Mvvm;
using OdinModels;
using OdinServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Odin.ViewModels
{
    public class AdminRecordViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region Commands


        public ICommand FindItemCommand
        {
            get
            {
                if (_findItemCommand == null)
                {
                    _findItemCommand = new RelayCommand(param => FindItem());
                }
                return _findItemCommand;
            }
        }
        private RelayCommand _findItemCommand;

        public ICommand SortRecordDateCommand
        {
            get
            {
                if (_sortRecordDate == null)
                {
                    _sortRecordDate = new RelayCommand(param => SortRecordDates());
                }
                return _sortRecordDate;
            }
        }
        private RelayCommand _sortRecordDate;

        #endregion // Commands

        #region Properties

        /// <summary>
        ///     Gets or Sets the ItemIdSearch
        /// </summary>
        public string ItemIdSearch

        {
            get
            {
                return _itemIdSearch;
            }
            set
            {
                _itemIdSearch = value.ToUpper();
                OnPropertyChanged("ItemIdSearch");
            }
        }
        private string _itemIdSearch = string.Empty;

        /// <summary>
        ///     Gets or Sets the ItemList
        /// </summary>
        public List<ItemObject> ItemList
        {
            get
            {
                return _itemList;
            }
            set
            {
                _itemList = value;
                OnPropertyChanged("ItemList");
            }
        }
        private List<ItemObject> _itemList = new List<ItemObject>();

        /// <summary>
        ///     Gets or Sets the ItemService
        /// </summary>
        public ItemService ItemService { get; set; }

        /// <summary>
        ///     Flags current Record Date sort order
        /// </summary>
        private int RecordDateOrder { get; set; }

        #endregion // Properties

        #region Methods

        /// <summary>
        ///     Retrieves list of update records for the given item.
        /// </summary>
        public void FindItem()
        {
            if (!string.IsNullOrEmpty(this.ItemIdSearch))
            {
                try
                {
                    this.ItemList = ItemService.RetrieveItemUpdateRecords(this.ItemIdSearch);
                    if (this.ItemList.Count == 0)
                    {
                        MessageBox.Show("No update records were found for the given Item Id.");
                    }
                }
                catch(Exception ex)
                {
                    ErrorLog.LogError("Odin was unable to find the item update records.", ex.ToString());
                }
            }
        }

        /// <summary>
        ///     Toggles the sorting of the record dates
        /// </summary>
        public void SortRecordDates()
        {
            List<ItemObject> SortedList = new List<ItemObject>();
            if (RecordDateOrder == 0)
            {
                SortedList = this.ItemList.OrderByDescending(o => o.RecordDate).ToList();
                RecordDateOrder = 1;
            }
            else
            {
                SortedList = ItemList.OrderBy(o => o.RecordDate).ToList();
                RecordDateOrder = 0;
            }
            this.ItemList = SortedList;
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the AdminRecordViewModel
        /// </summary>
        /// <param name="itemService"></param>
        public AdminRecordViewModel(ItemService itemService)
        {
            this.ItemService = itemService ?? throw new ArgumentNullException("ItemService");
            this.RecordDateOrder = 0;
        }

        #endregion // Constructor

    }
}
