using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class ProdPgrpLnk
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets DATETIME_ADDED
        /// </summary>
        public DateTime DatetimeAdded { get; set; }

        /// <summary>
        ///     Gets or sets LAST_MAINT_OPRID
        /// </summary>
        public string LastMaintOprid { get; set; }

        /// <summary>
        ///     Gets or sets LASTUPDDTTM
        /// </summary>
        public DateTime Lastupddttm { get; set; }

        /// <summary>
        ///     Gets or sets PRIM_PRC_FLAG
        /// </summary>
        public string PrimPrcFlag { get; set; }

        /// <summary>
        ///     Gets or sets PRIMARY_FLAG
        /// </summary>
        public string PrimaryFlag { get; set; }

        /// <summary>
        ///     Gets or sets PROD_GRP_TYPE
        /// </summary>
        public string ProdGrpType { get; set; }

        /// <summary>
        ///     Gets or sets PRODUCT_GROUP
        /// </summary>
        public string ProductGroup { get; set; }

        /// <summary>
        ///     Gets or sets PRODUCT_ID
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        ///     Gets or sets SETID
        /// </summary>
        public string Setid { get; set; }

        #endregion // Public Properties
    }
}
