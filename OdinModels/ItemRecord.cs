using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OdinModels
{
    public class ItemRecord: INotifyPropertyChanged
    {
        #region Events

        /// <summary>
        ///     This event is raised when a property of this object is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion // Events

        #region Properties

        /// <summary>
        ///     Gets or Sets the Input Date
        /// </summary>
        public string InputDate
        {
            get
            {
                return _inputDate;
            }
            set
            {
                _inputDate = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("InputDate"));
                }
            }

        }
        private string _inputDate = string.Empty;

        /// <summary>
        ///     Gets or Sets the Item Id
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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ItemId"));
                }
            }

        }
        private string _itemId = string.Empty;

        /// <summary>
        ///     Gets or Sets the Record Status
        /// </summary>
        public string RecordStatus
        {
            get
            {
                return _recordStatus;
            }
            set
            {
                _recordStatus = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("RecordStatus"));
                }
            }

        }
        private string _recordStatus = string.Empty;

        /// <summary>
        ///     Gets or Sets the User Name
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

        #endregion // Properties

        #region Constructor

        /// <summary>
        ///     Constructs the UserRecord model
        /// </summary>
        /// <param name="inputDate"></param>
        /// <param name="itemId"></param>
        /// <param name="recordStatus"></param>
        public ItemRecord(string inputDate, string itemId, string recordStatus, string userName)
        {
            this.InputDate = inputDate;
            this.ItemId = itemId;
            this.RecordStatus = recordStatus;
            this.UserName = userName;
        }

        public ItemRecord()
        {

        }

        #endregion // Constructor

    }
}
