using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class MarketplaceProductTranslations
    {
        /// <summary>
        ///     Gets or sets DTTM_ADDED
        /// </summary>
        public DateTime DttmAdded { get; set; }

        /// <summary>
        ///     Gets or sets FROM_PRODUCT_ID
        /// </summary>
        public string FromProductId { get; set; }

        /// <summary>
        ///     Gets or sets OPRID
        /// </summary>
        public string Oprid { get; set; }

        /// <summary>
        ///     Gets or sets TO_PRODUCT_ID
        /// </summary>
        public string ToProductId { get; set; }

        /// <summary>
        ///     Gets or sets TO_QTY
        /// </summary>
        public int ToQty { get; set; }
    }
}
