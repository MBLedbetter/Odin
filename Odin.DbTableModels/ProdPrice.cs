using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class ProdPrice
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets BUSINESS_UNIT_IN
        /// </summary>
        public string BusinessUnitIn { get; set; }

        /// <summary>
        ///     Gets or sets CURRENCY_CD
        /// </summary>
        public string CurrencyCd { get; set; }

        /// <summary>
        ///     Gets or sets DATETIME_ADDED
        /// </summary>
        public DateTime DatetimeAdded { get; set; }

        /// <summary>
        ///     Gets or sets EFF_STATUS
        /// </summary>
        public string EffStatus { get; set; }

        /// <summary>
        ///     Gets or sets EFFDT
        /// </summary>
        public DateTime Effdt { get; set; }

        /// <summary>
        ///     Gets or sets LAST_MAINT_OPRID
        /// </summary>
        public string LastMaintOprid { get; set; }

        /// <summary>
        ///     Gets or sets LASTUPDDTTM
        /// </summary>
        public DateTime Lastupddttm { get; set; }

        /// <summary>
        ///     Gets or sets LIST_PRICE
        /// </summary>
        public decimal ListPrice { get; set; }

        /// <summary>
        ///     Gets or sets MFG_SUG_RTL_PRC
        /// </summary>
        public decimal MfgSugRtlPrc { get; set; }

        /// <summary>
        ///     Gets or sets PRICING_FLAG
        /// </summary>
        public string PricingFlag { get; set; }

        /// <summary>
        ///     Gets or sets PRODUCT_ID
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        ///     Gets or sets REPAIR_COST
        /// </summary>
        public decimal RepairCost { get; set; }

        /// <summary>
        ///     Gets or sets SERVICE_COST
        /// </summary>
        public decimal ServiceCost { get; set; }

        /// <summary>
        ///     Gets or sets SETID
        /// </summary>
        public string Setid { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_COST
        /// </summary>
        public decimal UnitCost { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_OF_MEASURE
        /// </summary>
        public string UnitOfMeasure { get; set; }

        #endregion // Public Properties
    }
}
