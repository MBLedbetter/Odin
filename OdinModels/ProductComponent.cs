using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdinModels
{
    public class ProductComponent
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the ParentId
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        ///     Gets or sets the ProductId
        /// </summary>
        public string ProductId { get;set; }

        /// <summary>
        ///     Gets or sets the DtcPrice
        /// </summary>
        public string DtcPrice { get; set; }

        #endregion // Properties

        #region Constructor

        /// <summary>
        ///     Constructs the ProductComponent
        /// </summary>
        /// <param name="productId">Id for the given item</param>
        public ProductComponent()
        {
            this.ParentId = "";
            this.ProductId = "";
            this.DtcPrice = "";
        }

        /// <summary>
        ///     Constructs the ProductComponent
        /// </summary>
        /// <param name="productId">Id for the given item</param>
        /// <param name="parentId">Parent Id for the given item</param>
        /// <param name="dtcPrice">Dtc Price for the given item</param>
        public ProductComponent(string productId, 
            string parentId, 
            string dtcPrice)
        {
            this.ParentId = parentId;
            this.ProductId = productId;
            this.DtcPrice = dtcPrice;
        }

        #endregion // Constructor
    }
}
