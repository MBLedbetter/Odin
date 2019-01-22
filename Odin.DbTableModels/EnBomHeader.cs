using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odin.DbTableModels
{
    public class EnBomHeader
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
        ///     Gets or sets BOM_QTY
        /// </summary>
        public int BomQty { get; set; }

        /// <summary>
        ///     Gets or sets BUSINESS_UNIT
        /// </summary>
        public string BusinessUnit { get; set; }

        /// <summary>
        ///     Gets or setsDESCR
        /// </summary>
        public string Descr { get; set; }

        /// <summary>
        ///     Gets or sets DESCRSHORT
        /// </summary>
        public string Descrshort { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_ID
        /// </summary>
        public string InvItemId { get; set; }

        /// <summary>
        ///     Gets or sets TEXT254
        /// </summary>
        public string Text254 { get; set; }
    }
}
