using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class ItemMfg
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets INV_ITEM_ID
        /// </summary>
        public string InvItemId { get; set; }

        /// <summary>
        ///     Gets or sets MFG_ID
        /// </summary>
        public string MfgId { get; set; }

        /// <summary>
        ///     Gets or sets MFG_ITM_ID
        /// </summary>
        public string MfgItmId { get; set; }

        /// <summary>
        ///     Gets or sets PREFERRED_MFG
        /// </summary>
        public string PreferredMfg { get; set; }

        /// <summary>
        ///     Gets or sets SETID
        /// </summary>
        public string Setid { get; set; }

        #endregion // Public Properties
    }
}
