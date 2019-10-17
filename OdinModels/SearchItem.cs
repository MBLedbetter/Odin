using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdinModels
{
    public class SearchItem
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the search items itemId
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
                /*
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Category"));
                }
                */
            }
        }
        private string _itemId = string.Empty;

        /// <summary>
        ///     Gets or sets the search items description
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                /*
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Category"));
                }
                */
            }
        }
        private string _description = string.Empty;

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                this._isSelected = value;
            }
        }
        private bool _isSelected = false;

        /// <summary>
        ///     Gets or sets the search items Status
        /// </summary>
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        private string _status = string.Empty;

        #endregion // Properties

        #region Constructor

        /// <summary>
        ///     Constructs a search item object with supplied fields for item Id, description, status
        /// </summary>
        public SearchItem(string itemId, string description, string status)
        {
            this.ItemId = itemId;
            this.Description = description;
            this.IsSelected = false;
            this.Status = status;
        }

        /// <summary>
        ///     Constructs a search item object with supplied fields for item Id and description
        /// </summary>
        public SearchItem(string itemId, string description)
        {
            this.ItemId = itemId;
            this.Description = description;
            this.IsSelected = false;
        }

        /// <summary>
        ///     Constructs a search item object with empty fields
        /// </summary>
        public SearchItem()
        {
            this.ItemId = "";
            this.Description = "";
            this.IsSelected = false;
        }

        #endregion // Constructor
    }
}
