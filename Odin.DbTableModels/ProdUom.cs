using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class ProdUom
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets DATETIME_ADDED
        /// </summary>
        public DateTime DatetimeAdded { get; set; }

        /// <summary>
        ///     Gets or sets DFLT_UOM
        /// </summary>
        public string DfltUom { get; set; }

        /// <summary>
        ///     Gets or sets LAST_MAINT_OPRID
        /// </summary>
        public string LastMaintOprid { get; set; }

        /// <summary>
        ///     Gets or sets LASTUPDDTTM
        /// </summary>
        public DateTime Lastupddttm { get; set; }

        /// <summary>
        ///     Gets or sets MAX_ORDER_QTY
        /// </summary>
        public decimal MaxOrderQty { get; set; }

        /// <summary>
        ///     Gets or sets MIN_ORDER_QTY
        /// </summary>
        public decimal MinOrderQty { get; set; }

        /// <summary>
        ///     Gets or sets ORDER_INCREMENT
        /// </summary>
        public decimal OrderIncrement { get; set; }

        /// <summary>
        ///     Gets or sets PRODUCT_ID
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        ///     Gets or sets SETID
        /// </summary>
        public string Setid { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_OF_MEASURE
        /// </summary>
        public string UnitOfMeasure { get; set; }

        #endregion // Public Properties
    }
}
