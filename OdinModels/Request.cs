using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdinModels
{
    public class Request
    {
        #region Properties
                                        
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
        ///     Gets or sets the GroupComment
        /// </summary>
        public string GroupComment
        {
            get
            {
                return _groupComment;
            }
            set
            {
                _groupComment = value;
            }

        }
        private string _groupComment = string.Empty;

        /// <summary>
        ///     Gets or sets the ItemCategory
        /// </summary>
        public string ItemCategory
        {
            get
            {
                return _itemCategory;
            }
            set
            {
                _itemCategory = value;
            }

        }
        private string _itemCategory = string.Empty;

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
                _requestId = value;
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
                return _requestStatus;
            }
            set
            {
                _requestStatus = value;
            }

        }
        private string _requestStatus = string.Empty;

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
        private string _userName;

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

        #region Constructor

        public Request(
            string itemId,
            string itemStatus
            )
        {
            this.ItemStatus = itemStatus;
            this.ItemId = itemId;
        }

        public Request(
            int requestId,
            string userName,
            string dttmSubmitted,
            string requestStatus)
        {
            this.RequestStatus = requestStatus;
            this.RequestId = requestId;
            this.UserName = userName;
            this.DttmSubmitted = dttmSubmitted;
        }

        public Request(
            int requestId,
            string itemCategory,
            string itemId,
            string itemStatus,
            string userName,
            string dttmSubmitted,
            string inStockDate,
            string comment,
            string requestStatus,
            string website)
        {
            this.RequestId = requestId;
            this.ItemCategory = itemCategory;
            this.ItemId = itemId;
            this.UserName = userName;
            this.DttmSubmitted = dttmSubmitted;
            this.InStockDate = inStockDate;
            this.ItemStatus = itemStatus;
            this.Comment = comment;
            this.RequestStatus = requestStatus;
            this.Website = website;
        }

        public Request(
            int requestId,
            string itemCategory,
            string itemId,
            string itemStatus,
            string userName,
            string inStockDate,
            string comment,
            string requestStatus)
        {
            this.RequestId = requestId;
            this.ItemCategory = itemCategory;
            this.ItemId = itemId;
            this.UserName = userName;
            this.InStockDate = inStockDate;
            this.ItemStatus = itemStatus;
            this.Comment = comment;
            this.RequestStatus = requestStatus;
        }
        #endregion // Constructor

    }
}
