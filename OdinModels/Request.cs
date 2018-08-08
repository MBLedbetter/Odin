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
            }

        }
        private string _comment;

        public string GroupComment
        {
            get
            {
                if (_groupComment == null)
                {
                    _groupComment = string.Empty;
                }
                return _groupComment;
            }
            set
            {
                _groupComment = value;
            }

        }
        private string _groupComment;

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
            }

        }
        private string _requestStatus;

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
            string itemId,
            string itemStatus,
            string userName,
            string dttmSubmitted,
            string inStockDate,
            string comment,
            string requestStatus)
        {
            this.RequestId = requestId;
            this.ItemId = itemId;
            this.UserName = userName;
            this.DttmSubmitted = dttmSubmitted;
            this.InStockDate = inStockDate;
            this.ItemStatus = itemStatus;
            this.Comment = comment;
            this.RequestStatus = requestStatus;
        }

        public Request(
            int requestId,
            string itemId,
            string itemStatus,
            string userName,
            string inStockDate,
            string comment,
            string requestStatus)
        {
            this.RequestId = requestId;
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
