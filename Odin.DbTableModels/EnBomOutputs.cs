using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class EnBomOutputs
    {
        /// <summary>
        ///     Gets or sets BOM_CODE  
        /// </summary>
        public short BomCode { get; set; }

        /// <summary>
        ///     Gets or sets BOM_STATE
        /// </summary>
        public string BomState { get; set; }

        /// <summary>
        ///     Gets or sets BOM_TYPE
        /// </summary>
        public string BomType { get; set; }

        /// <summary>
        ///     Gets or sets BUSINESS_UNIT
        /// </summary>
        public string BusinessUnit { get; set; }

        /// <summary>
        ///     Gets or sets DATE_IN_EFFECT
        /// </summary>
        public DateTime DateInEffect { get; set; }

        /// <summary>
        ///     Gets or sets DATE_OBSOLETE
        /// </summary>
        public DateTime DateObsolete { get; set; }

        /// <summary>
        ///     Gets or sets INCR_REL_OFFSET
        /// </summary>
        public decimal IncrRelOffset { get; set; }

        /// <summary>
        ///     Gets or sets INCR_REL_TYPE
        /// </summary>
        public string IncrRelType { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_ID
        /// </summary>
        public string InvItemId { get; set; }

        /// <summary>
        ///     Gets or sets MG_OUTPUT_COST_PCT
        /// </summary>
        public short MgOutputCostPct { get; set; }

        /// <summary>
        ///     Gets or sets MG_OUTPUT_ITEM
        /// </summary>
        public string MgOutputItem { get; set; }

        /// <summary>
        ///     Gets or sets MG_OUTPUT_QTY
        /// </summary>
        public decimal MgOutputQty { get; set; }

        /// <summary>
        ///     Gets or sets MG_OUTPUT_QTY_CODE
        /// </summary>
        public string MgOutputQtyCode { get; set; }

        /// <summary>
        ///     Gets or sets MG_OUTPUT_RES_PCT
        /// </summary>
        public short MgOutputResPct { get; set; }

        /// <summary>
        ///     Gets or sets MG_OUTPUT_TYPE
        /// </summary>
        public string MgOutputType { get; set; }

        /// <summary>
        ///     Gets or sets OP_SEQUENCE
        /// </summary>
        public short OpSequence { get; set; }
    }
}
