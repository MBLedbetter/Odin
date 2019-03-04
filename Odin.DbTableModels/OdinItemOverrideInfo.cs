using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class OdinItemOverrideInfo
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets INV_ITEM_ID
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_KEYWORDS
        /// </summary>
        public string ItemKeywords { get; set; }

        /// <summary>
        ///     Gets or sets TITLE
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets WEBSITE_PRICE
        /// </summary>
        public string WebsitePrice { get; set; }

        #endregion // Public Properties
    }
}
