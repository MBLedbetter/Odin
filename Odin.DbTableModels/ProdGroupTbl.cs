using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class ProdGroupTbl
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets SETID
        /// </summary>
        public string Setid { get; set; }

        /// <summary>
        ///     Gets or sets PROD_GRP_TYPE
        /// </summary>
        public string ProdGrpType { get; set; }

        /// <summary>
        ///     Gets or sets PRODUCT_GROUP
        /// </summary>
        public string ProductGroup { get; set; }

        /// <summary>
        ///     Gets or sets EFFDT
        /// </summary>
        public DateTime Effdt { get; set; }

        /// <summary>
        ///     Gets or sets DESCR
        /// </summary>
        public string Descr { get; set; }

        /// <summary>
        ///     Gets or sets EFF_STATUS
        /// </summary>
        public string EffStatus { get; set; }

        /// <summary>
        ///     Gets or sets WEB_OE_PROD_CAT
        /// </summary>
        public string WebOeProdCat { get; set; }

        /// <summary>
        ///     Gets or sets DESCRSHORT
        /// </summary>
        public string Descrshort { get; set; }

        /// <summary>
        ///     Gets or sets GLOBAL_FLAG
        /// </summary>
        public string GlobalFlag { get; set; }

        /// <summary>
        ///     Gets or sets DATETIME_ADDED
        /// </summary>
        public DateTime DatetimeAdded { get; set; }

        /// <summary>
        ///     Gets or sets LASTUPDDTTM
        /// </summary>
        public DateTime Lastupddttm { get; set; }

        /// <summary>
        ///     Gets or sets LAST_MAINT_OPRID
        /// </summary>
        public string LastMaintOprid { get; set; }

        #endregion // Public Properties
    }
}
