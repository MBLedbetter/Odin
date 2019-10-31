using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class CustomerProductAttributes
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets CASEPACK_QTY
        /// </summary>
        public int CasepackQty { get; set; }

        /// <summary>
        ///     Gets or sets CUST_ID
        /// </summary>
        public string CustId { get; set; }

        /// <summary>
        ///     Gets or sets INNERPACK_QTY
        /// </summary>
        public int InnerpackQty { get; set; }

        /// <summary>
        ///     Gets or sets IS_EXCLUSIVE
        /// </summary>
        public string IsExclusive { get; set; }

        /// <summary>
        ///     Gets or sets PRODUCT_ID
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        ///     Gets or sets SEND_INVENTORY
        /// </summary>
        public string SendInventory { get; set; }

        /// <summary>
        ///     Gets or sets SETID
        /// </summary>
        public string Setid { get; set; }

        #endregion // Public Properties
    }
}
