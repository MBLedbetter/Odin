using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdinModels
{
    public class Layout
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the layout Customer
        /// </summary>
        public string Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }
        private string _customer = string.Empty;

        /// <summary>
        ///     Gets or sets the layout id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _id = 0;

        /// <summary>
        ///     Gets or sets the layout name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _name = string.Empty;
        
        /// <summary>
        ///     Gets or sets the product type
        /// </summary>
        public string ProductType
        {
            get { return _productType; }
            set { _productType = value; }
        }
        private string _productType = string.Empty;
        
        #endregion // Properties

        #region Constructor

        public Layout(string name, int id, string customer, string productType)
        {
            this.Name = name;
            this.Id = id;
            this.Customer = customer;
            this.ProductType = productType;
        }

        #endregion // Constructor
    }
}
