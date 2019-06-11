using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class MarketplaceCustomerProducts
    {
        #region Properties
        
        /// <summary>
        ///     Gets or sets CUST_ID
        /// </summary>
        public string CustId { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_ID
        /// </summary>
        public string InvItemId { get; set; }

        /// <summary>
        ///     Gets or sets SETID
        /// </summary>
        public string Setid { get; set; }

        /// <summary>
        ///     Gets or sets TITLE
        /// </summary>
        public string Title { get; set; }

        #endregion // Properties
    }
}
