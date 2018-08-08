using Mvvm;
using OdinModels;
using OdinServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Odin.ViewModels
{
    public class ItemRecordListViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region Commands

        public ICommand GenerateListCommand
        {
            get
            {
                if (_generateList == null)
                {
                    _generateList = new RelayCommand(param => GenerateList());
                }
                return _generateList;
            }
        }
        private RelayCommand _generateList;

        public ICommand OpenSelectedItemRecordCommand
        {
            get
            {
                if (_openSelectedItemRecord == null)
                {
                    _openSelectedItemRecord = new RelayCommand(param => OpenSelectedItemRecord());
                }
                return _openSelectedItemRecord;
            }
        }
        private RelayCommand _openSelectedItemRecord;

        public ICommand SortInputDateCommand
        {
            get
            {
                if (_sortInputDate == null)
                {
                    _sortInputDate = new RelayCommand(param => SortInputDates());
                }
                return _sortInputDate;
            }
        }
        private RelayCommand _sortInputDate;

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

        public ICommand SortRecordStatusCommand
        {
            get
            {
                if (_sortRecordStatus == null)
                {
                    _sortRecordStatus = new RelayCommand(param => SortRecordStatus());
                }
                return _sortRecordStatus;
            }
        }
        private RelayCommand _sortRecordStatus;

        public ICommand SortUserNameCommand
        {
            get
            {
                if (_sortUserName == null)
                {
                    _sortUserName = new RelayCommand(param => SortUserNames());
                }
                return _sortUserName;
            }
        }
        private RelayCommand _sortUserName;


        #endregion // Commands

        #region Properties

        /// <summary>
        ///     Flags current Input Date sort order
        /// </summary>
        private int InputDateSorOrder { get; set; }

        /// <summary>
        ///     Flags current ItemId sort order
        /// </summary>
        private int ItemIdSorOrder { get; set; }

        /// <summary>
        ///     Gets or sets the viewmodels ItemService
        /// </summary>
        public ItemService ItemService {get;set;}

        /// <summary>
        ///     Gets or Sets the Record List field
        /// </summary>
        public List<ItemRecord> RecordList
        {
            get
            {
                return _recordList;
            }
            set
            {
                _recordList = value;
                OnPropertyChanged("RecordList");
            }
        }
        private List<ItemRecord> _recordList = new List<ItemRecord>();
        
        /// <summary>
        ///     Gets or Sets the Selected Record field
        /// </summary>
        public ItemRecord SelectedRecord
        {
            get
            {
                return _selectedRecord;
            }
            set
            {
                _selectedRecord = value;
                OnPropertyChanged("SelectedRecord");
            }
        }
        private ItemRecord _selectedRecord = new ItemRecord();
        
        /// <summary>
        ///     Flags current record status sort order
        /// </summary>
        private int RecordStatusSortOrder { get; set; }

        /// <summary>
        ///     Gets or sets the user name filter
        /// </summary>
        public string UserNameFilter
        {
            get
            {
                return _userNameFilter;
            }
            set
            {
                if (this.UserNameFilter != value)
                {
                    _userNameFilter = value;
                    UpdateUserNameFilter(value);
                    OnPropertyChanged("UserNameFilter");
                }
            }

        }
        private string _userNameFilter = string.Empty;

        /// <summary>
        ///     Gets or sets the list of user names from Global Data
        /// </summary>
        public List<string> UserNameList
        {
            get
            {
                return _userNameList;
            }
            set
            {
                _userNameList = value;
            }
        }
        private List<string> _userNameList = new List<string>();

        /// <summary>
        ///     Flags current username sort order
        /// </summary>
        private int UserNameSorOrder { get; set; }

        #endregion // Properties

        #region Methods
        
        /// <summary>
        ///     Generates a list of all item Records
        /// </summary>
        public void GenerateList()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            this.RecordList = ItemService.RetrieveItemRecords();
            Mouse.OverrideCursor = null;
        }

        /// <summary>
        ///     Not Opertational: Opens the record view for the given item
        /// </summary>
        public void OpenSelectedItemRecord()
        {

        }

        /// <summary>
        ///     Sorts the Record list by item ids
        /// </summary>
        public void SortItemIds()
        {
            List<ItemRecord> SortedList = new List<ItemRecord>();
            if (ItemIdSorOrder == 0)
            {
                SortedList = RecordList.OrderByDescending(o => o.ItemId).ToList();
                ItemIdSorOrder = 1;
            }
            else
            {
                SortedList = RecordList.OrderBy(o => o.ItemId).ToList();
                ItemIdSorOrder = 0;
            }
            this.RecordList = SortedList;
        }

        /// <summary>
        ///     Sorts the Record list by the record status
        /// </summary>
        public void SortRecordStatus()
        {
            List<ItemRecord> SortedList = new List<ItemRecord>();
            if (RecordStatusSortOrder == 0)
            {
                SortedList = RecordList.OrderByDescending(o => o.RecordStatus).ToList();
                RecordStatusSortOrder = 1;
            }
            else
            {
                SortedList = RecordList.OrderBy(o => o.RecordStatus).ToList();
                RecordStatusSortOrder = 0;
            }
            this.RecordList = SortedList;

        }

        /// <summary>
        ///     Sorts the Record list by the input dates
        /// </summary>
        public void SortInputDates()
        {
            List<ItemRecord> SortedList = new List<ItemRecord>();
            if (InputDateSorOrder == 0)
            {
                SortedList = RecordList.OrderByDescending(o => o.InputDate).ToList();
                InputDateSorOrder = 1;
            }
            else
            {
                SortedList = RecordList.OrderBy(o => o.InputDate).ToList();
                InputDateSorOrder = 0;
            }
            this.RecordList = SortedList;

        }

        /// <summary>
        ///     Sorts the Record list by the user names
        /// </summary>
        public void SortUserNames()
        {
            List<ItemRecord> SortedList = new List<ItemRecord>();
            if (UserNameSorOrder == 0)
            {
                SortedList = RecordList.OrderByDescending(o => o.UserName).ToList();
                UserNameSorOrder = 1;
            }
            else
            {
                SortedList = RecordList.OrderBy(o => o.UserName).ToList();
                UserNameSorOrder = 0;
            }
            this.RecordList = SortedList;

        }

        /// <summary>
        ///     Filters the record list by the user name
        /// </summary>
        /// <param name="value"></param>
        public void UpdateUserNameFilter(string value)
        {
            if (value != "")
            {
                List<ItemRecord> FilteredList = new List<ItemRecord>();
                foreach (ItemRecord record in GlobalData.ItemRecords)
                {
                    if (record.UserName == value)
                    {
                        FilteredList.Add(record);
                    }
                }
                this.RecordList = FilteredList;
            }
            else
            {
                this.RecordList = GlobalData.ItemRecords;
            }
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Opens the record view for the given item
        /// </summary>
        public ItemRecordListViewModel(ItemService itemService)
        {

            if (itemService == null) { throw new ArgumentNullException("itemService"); }
            this.ItemService = itemService;
            this.RecordList = GlobalData.ItemRecords;
            this.InputDateSorOrder = 0;
            this.ItemIdSorOrder = 0;
            this.RecordStatusSortOrder = 0;
            this.UserNameList = GlobalData.UserNames;
            this.UserNameList.Add("");
            this.UserNameSorOrder = 0;
            // GenerateList();
        }

        #endregion // Constructor
    }
}
