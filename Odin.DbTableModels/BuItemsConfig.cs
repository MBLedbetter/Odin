using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class BuItemsConfig
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets BUSINESS_UNIT
        /// </summary>
        public string BusinessUnit { get; set; }

        /// <summary>
        ///     Gets or sets BUSINESS_UNIT_CP
        /// </summary>
        public string BusinessUnitCp { get; set; }

        /// <summary>
        ///     Gets or sets CFG_LEAD_TIME
        /// </summary>
        public decimal CfgLeadTime { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_ID
        /// </summary>
        public string InvItemId { get; set; }

        /// <summary>
        ///     Gets or sets LASTUPDDTTM
        /// </summary>
        public DateTime Lastupddttm { get; set; }

        /// <summary>
        ///     Gets or sets REF_BOM_ITEM
        /// </summary>
        public string RefBomItem { get; set; }

        /// <summary>
        ///     Gets or sets RULE_BASED_COMP
        /// </summary>
        public string RuleBasedComp { get; set; }

        /// <summary>
        ///     Gets or sets RULE_BASED_OPER
        /// </summary>
        public string RuleBasedOper { get; set; }

        /// <summary>
        ///     Gets or sets SHIP_TYPE_ID
        /// </summary>
        public string ShipTypeId { get; set; }

        #endregion // Public Properties
    }
}
