using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class InvItemUom
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets CONTAINER_TYPE
        /// </summary>
        public string ContainerType { get; set; }

        /// <summary>
        ///     Gets or sets CONVERSION_RATE
        /// </summary>
        public decimal ConversionRate { get; set; }

        /// <summary>
        ///     Gets or sets DFLT_UOM_STOCK
        /// </summary>
        public string DfltUomStock { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_ID
        /// </summary>
        public string InvItemId { get; set; }

        /// <summary>
        ///     Gets or sets LAST_DTTM_UPDATE
        /// </summary>
        public DateTime LastDttmUpdate { get; set; }

        /// <summary>
        ///     Gets or sets LAST_MAINT_OPRID
        /// </summary>
        public string LastMaintOprid { get; set; }

        /// <summary>
        ///     Gets or sets PACKAGING_CD
        /// </summary>
        public string PackagingCd { get; set; }

        /// <summary>
        ///     Gets or sets PACKING_CD
        /// </summary>
        public string PackingCd { get; set; }

        /// <summary>
        ///     Gets or sets PACKING_VOLUME
        /// </summary>
        public decimal PackingVolume { get; set; }

        /// <summary>
        ///     Gets or sets PACKING_WEIGHT
        /// </summary>
        public decimal PackingWeight { get; set; }

        /// <summary>
        ///     Gets or sets QTY_PRECISION
        /// </summary>
        public string QtyPrecision { get; set; }

        /// <summary>
        ///     Gets or sets ROUND_RULE
        /// </summary>
        public string RoundRule { get; set; }

        /// <summary>
        ///     Gets or sets SETID
        /// </summary>
        public string Setid { get; set; }

        /// <summary>
        ///     Gets or sets SHIPPING_VOLUME
        /// </summary>
        public decimal ShippingVolume { get; set; }

        /// <summary>
        ///     Gets or sets SHIPPING_WEIGHT
        /// </summary>
        public decimal ShippingWeight { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_MEASURE_VOL
        /// </summary>
        public string UnitMeasureVol { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_MEASURE_WT
        /// </summary>
        public string UnitMeasureWt { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_OF_MEASURE
        /// </summary>
        public string UnitOfMeasure { get; set; }

        #endregion // Public Properties
    }
}
