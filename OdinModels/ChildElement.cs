using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdinModels
{
    public class ChildElement
    {
        #region Properties

        /// <summary>
        ///     product Id Translations item id
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
        ///     Gets or sets the ParentId.
        /// </summary>
        public string ParentId
        {
            get
            {
                return _parentId;
            }
            set
            {
                _parentId = value;
            }
        }
        private string _parentId;

        /// <summary>
        ///     Quantity of the item
        /// </summary>
        public int Qty
        {
            get
            {
                return _qty;
            }
            set
            {
                _qty = value;
            }
        }
        private int _qty = 1;
        
        #endregion // Properties

        #region Constructor

        /// <summary>
        ///     Constructs the Product Id Translation object
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="qty"></param>
        public ChildElement(string itemId, string parentId, int qty = 1)
        {
            this.ItemId = itemId;
            this.ParentId = parentId;
            this.Qty = qty;
        }

        #endregion // Constructor
    }
}
