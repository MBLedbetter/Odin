using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
   public class FxdBinLocInv
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets BUSINESS_UNIT
        /// </summary>
        public string BusinessUnit { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_ID
        /// </summary>
        public string InvItemId { get; set; }

        /// <summary>
        ///     Gets or sets PICKING_ORDER
        /// </summary>
        public short PickingOrder { get; set; }

        /// <summary>
        ///     Gets or sets QTY_OPTIMAL
        /// </summary>
        public decimal QtyOptimal { get; set; }

        /// <summary>
        ///     Gets or sets STOR_LEVEL_1
        /// </summary>
        public string StorLevel1 { get; set; }

        /// <summary>
        ///     Gets or sets STOR_LEVEL_2
        /// </summary>
        public string StorLevel2 { get; set; }

        /// <summary>
        ///     Gets or sets STOR_LEVEL_3
        /// </summary>
        public string StorLevel3 { get; set; }

        /// <summary>
        ///     Gets or sets STOR_LEVEL_4
        /// </summary>
        public string StorLevel4 { get; set; }

        /// <summary>
        ///     Gets or sets STORAGE_AREA
        /// </summary>
        public string StorageArea { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_OF_MEASURE
        /// </summary>
        public string UnitOfMeasure { get; set; }

        #endregion // Public Properties
    }
}
