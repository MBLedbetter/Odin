using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class OdinWebsiteItemRequests
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets Comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        ///     Gets or sets DttmSubmitted
        /// </summary>
        public string DttmSubmitted { get; set; }

        /// <summary>
        ///     Gets or sets InStockDate
        /// </summary>
        public string InStockDate { get; set; }

        /// <summary>
        ///     Gets or sets ItemId
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        ///     Gets or sets ItemStatus
        /// </summary>
        public string ItemStatus { get; set; }

        /// <summary>
        ///     Gets or sets RequestId
        /// </summary>
        public int RequestId { get; set; }

        /// <summary>
        ///     Gets or sets RequestStatus
        /// </summary>
        public string RequestStatus { get; set; }

        /// <summary>
        ///     Gets or sets UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     Gets or sets Website
        /// </summary>
        public string Website { get; set; }

        #endregion // Public Properties
    }
}
