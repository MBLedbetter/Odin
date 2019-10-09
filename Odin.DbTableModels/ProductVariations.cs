using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class ProductVariations
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets CUST_ID
        /// </summary>
        public string CustId { get; set; }

        /// <summary>
        ///     Gets or sets DTTM_CREATED
        /// </summary>
        public DateTime DttmCreated { get; set; }

        /// <summary>
        ///     Gets or sets DTTM_LAST_UPDATED
        /// </summary>
        public DateTime DttmUpdated { get; set; }

        /// <summary>
        ///     Gets or sets EXTERNAL_PARENT_ID
        /// </summary>
        public string ExternalParentId { get; set; }

        /// <summary>
        ///     Gets or sets PRODUCT_ID
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        ///     Gets or sets SETID
        /// </summary>
        public string SetId { get; set; }

        /// <summary>
        ///     Gets or sets VARIATION_GROUP_ID
        /// </summary>
        public string VariationGroupId { get; set; }

        /// <summary>
        ///     Gets or sets VARIATION_PRODUCT_CATEGORY
        /// </summary>
        public string VariationProductCategory { get; set; }

        #endregion // Public Properties
    }
}
