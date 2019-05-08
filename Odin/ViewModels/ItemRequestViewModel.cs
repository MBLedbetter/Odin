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

        /// <summary>
        ///     Gets or sets the AdminStatus
        /// </summary>
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

        /// <summary>
        ///     Gets or sets the Comment
        /// </summary>
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
                OnPropertyChanged("Comment");
            }

        }
        private string _comment = string.Empty;

        /// <summary>
        ///     Gets or sets the DttmSubmitted
        /// </summary>
        public string DttmSubmitted
        {
            get
            {
                return _dttmSubmitted;
            }
            set
            {
                _dttmSubmitted = value;
            }

        }
        private string _dttmSubmitted = string.Empty;

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
                _inStockDate = value;
            }

        }
        private string _inStockDate = string.Empty;

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
            }

        }
        private string _itemId = string.Empty;

        /// <summary>
        ///     Gets or sets the ItemStatus
        /// </summary>
        public string ItemStatus
        {
            get
            {
                return _itemStatus;
            }
            set
            {
                _itemStatus = value;
            }

        }
        private string _itemStatus = string.Empty;

        /// <summary>
        ///     Gets or sets the OptionService
        /// </summary>
        public OptionService OptionService { get; set; }

        /// <summary>
        ///     Gets or sets the RequestId
        /// </summary>
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

        /// <summary>
        ///     Gets or sets the RequestStatus
        /// </summary>
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
        private string _requestStatus = string.Empty;

        /// <summary>
        ///     Gets or sets the RequestStatusList
        /// </summary>
        public List<string> RequestStatusList
        {
            get
            {
                return GlobalData.RequestStatus;
            }
        }

        /// <summary>
        ///     Gets or sets the UserName
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
            }

        }
        private string _userName = string.Empty;

        /// <summary>
        ///     Gets or sets the Website
        /// </summary>
        public string Website
        {
            get
            {
                return _website;
            }
            set
            {
                _website = value;
            }

        }
        private string _website = string.Empty;

        #endregion // Properties        

        #region Methods

        public bool SaveRequest() 
        {
            
            Request request = new Request(this.RequestId, this.ItemId, this.ItemStatus, this.UserName, this.DttmSubmitted,this.InStockDate, this.Comment, this.RequestStatus, this.Website);
            OptionService.UpdateWebsiteRequest(request);
            return true;
        }

        #endregion // Methods

        #region Constructor

        public ItemRequestViewModel(OptionService optionService, Request request, Boolean adminStatus)
        {
            this.OptionService = optionService ?? throw new ArgumentNullException("optionService");
            this.AdminStatus = adminStatus;
            this.Comment = request.Comment;
            this.DttmSubmitted = request.DttmSubmitted;
            this.ItemId = request.ItemId;
            this.ItemStatus = request.ItemStatus;
            this.RequestId = request.RequestId;
            this.RequestStatus = request.RequestStatus;
            this.UserName = request.UserName;
            this.Website = request.Website;
        }

        #endregion // Constructor
    }
}
