using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class PvItmCategory
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets CATEGORY_ID
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_ID
        /// </summary>
        public string InvItemId { get; set; }

        /// <summary>
        ///     Gets or sets PV_PREFERRED_CAT
        /// </summary>
        public string PvPreferredCat { get; set; }

        /// <summary>
        ///     Gets or sets SETID
        /// </summary>
        public string Setid { get; set; }

        #endregion // Public Properties
    }
}
