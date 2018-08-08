using Mvvm;
using OdinModels;
using OdinServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Odin.ViewModels
{
    public class ItemRequestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Commands

        public ICommand SaveRequestCommand
        {
            get
            {
                if (_saveRequestCommand == null)
                {
                    _saveRequestCommand = new RelayCommand(param => SaveRequest());
                }
                return _saveRequestCommand;
            }
        }
        private RelayCommand _saveRequestCommand;

        #endregion // Commands

        #region Properties

        public bool AdminStatus
        {
            get
            {
                return _adminStatus;
            }
            set
            {
                if (this.AdminStatus != value)
                {
                    _adminStatus = value;
                    OnPropertyChanged("AdminStatus");
                }
            }
        }
        private bool _adminStatus;
        public int RequestId
        {
            get
            {
                return _requestId;
            }
            set
            {
                if (this.RequestId != value)
                {
                    _requestId = value;
                    OnPropertyChanged("RequestId");
                }
            }
        }
        private int _requestId;
        public string ItemId
        {
            get
            {
                if (_itemId == null)
                {
                    _itemId = string.Empty;
                }
                return _itemId;
            }
            set
            {
                _itemId = value;
            }

        }
        private string _itemId;
        public string UserName
        {
            get
            {
                if (_userName == null)
                {
                    _userName = string.Empty;
                }
                return _userName;
            }
            set
            {
                _userName = value;
            }

        }
        private string _userName;
        public string DttmSubmitted
        {
            get
            {
                if (_dttmSubmitted == null)
                {
                    _dttmSubmitted = string.Empty;
                }
                return _dttmSubmitted;
            }
            set
            {
                _dttmSubmitted = value;
            }

        }
        private string _dttmSubmitted;
        public string InStockDate
        {
            get
            {
                if (_inStockDate == null)
                {
                    _inStockDate = string.Empty;
                }
                return _inStockDate;
            }
            set
            {
                _inStockDate = value;
            }

        }
        private string _inStockDate;
        public string Comment
        {
            get
            {
                if (_comment == null)
                {
                    _comment = string.Empty;
                }
                return _comment;
            }
            set
            {
                _comment = value;
                OnPropertyChanged("Comment");
            }

        }
        private string _comment;
        public string ItemStatus
        {
            get
            {
                if (_itemStatus == null)
                {
                    _itemStatus = string.Empty;
                }
                return _itemStatus;
            }
            set
            {
                _itemStatus = value;
            }

        }
        private string _itemStatus;
        public string RequestStatus
        {
            get
            {
                if (_requestStatus == null)
                {
                    _requestStatus = string.Empty;
                }
                return _requestStatus;
            }
            set
            {
                _requestStatus = value;
                OnPropertyChanged("RequestStatus");
            }

        }
        private string _requestStatus;
        public List<string> RequestStatusList
        {
            get
            {
                return GlobalData.RequestStatus;
            }
        }
        /// <summary>
        ///     Gets or sets the OptionService
        /// </summary>
        public OptionService OptionService { get; set; }

        #endregion // Properties        

        #region Methods

        public bool SaveRequest() 
        {
            
            Request request = new Request(this.RequestId, this.ItemId, this.ItemStatus, this.UserName, this.DttmSubmitted,this.InStockDate, this.Comment, this.RequestStatus);
            OptionService.UpdateWebsiteRequest(request);
            return true;
        }

        #endregion // Methods

        #region Constructor

        public ItemRequestViewModel(OptionService optionService, Request request, Boolean adminStatus)
        {
            if (optionService == null) { throw new ArgumentNullException("optionService"); }
            this.OptionService = optionService;
            this.RequestId = request.RequestId;
            this.ItemId = request.ItemId;
            this.UserName = request.UserName;
            this.RequestStatus = request.RequestStatus;
            this.ItemStatus = request.ItemStatus;
            this.Comment = request.Comment;
            this.DttmSubmitted = request.DttmSubmitted;
            this.AdminStatus = adminStatus;
        }

        #endregion // Constructor
    }
}
