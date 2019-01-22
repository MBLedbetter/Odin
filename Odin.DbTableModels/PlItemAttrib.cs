using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class PlItemAttrib
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets AUTO_APPROVE_MSG
        /// </summary>
        public string AutoApproveMsg { get; set; }

        /// <summary>
        ///     Gets or sets BUSINESS_UNIT
        /// </summary>
        public string BusinessUnit { get; set; }

        /// <summary>
        ///     Gets or sets CAP_FENCE_OFF
        /// </summary>
        public int CapFenceOff { get; set; }

        /// <summary>
        ///     Gets or sets DEMAND_FENCE_OF
        /// </summary>
        public decimal DemandFenceOf { get; set; }

        /// <summary>
        ///     Gets or sets EARLY_FENCE
        /// </summary>
        public int EarlyFence { get; set; }

        /// <summary>
        ///     Gets or sets EXCESS_LEVEL
        /// </summary>
        public decimal ExcessLevel { get; set; }

        /// <summary>
        ///     Gets or sets EXTRA_CONSUMP
        /// </summary>
        public string ExtraConsump { get; set; }

        /// <summary>
        ///     Gets or sets FCST_ADJ_ACTION
        /// </summary>
        public string FcstAdjAction { get; set; }

        /// <summary>
        ///     Gets or sets FCST_FULFILL_SIZE
        /// </summary>
        public decimal FcstFulfillSize { get; set; }

        /// <summary>
        ///     Gets or sets FIRMED_ORDER
        /// </summary>
        public short FirmedOrder { get; set; }

        /// <summary>
        ///     Gets or sets GBL_EARLY_FENCE
        /// </summary>
        public string GblEarlyFence { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_ID
        /// </summary>
        public string InvItemId { get; set; }

        /// <summary>
        ///     Gets or sets MFG_LEAD_TIME_FLAG
        /// </summary>
        public string MfgLeadTimeFlag { get; set; }

        /// <summary>
        ///     Gets or sets MFG_MAX_ORDER
        /// </summary>
        public decimal MfgMaxOrder { get; set; }

        /// <summary>
        ///     Gets or sets MFG_MIN_ORDER
        /// </summary>
        public decimal MfgMinOrder { get; set; }

        /// <summary>
        ///     Gets or sets MFG_MOD_UNIT
        /// </summary>
        public string MfgModUnit { get; set; }

        /// <summary>
        ///     Gets or sets MFG_ORDER_MOD
        /// </summary>
        public string MfgOrderMod { get; set; }

        /// <summary>
        ///     Gets or sets MFG_ORDER_MULTIPLE
        /// </summary>
        public decimal MfgOrderMultiple { get; set; }

        /// <summary>
        ///     Gets or sets MSR_CONSUMP
        /// </summary>
        public string MsrConsump { get; set; }

        /// <summary>
        ///     Gets or sets PL_AGG_DMD_FLAG
        /// </summary>
        public string PlAggDmdFlag { get; set; }

        /// <summary>
        ///     Gets or sets PL_FIXED_PERIOD
        /// </summary>
        public short PlFixedPeriod { get; set; }

        /// <summary>
        ///     Gets or sets PL_ITEM_EXPL
        /// </summary>
        public string PlItemExpl { get; set; }

        /// <summary>
        ///     Gets or sets PL_PRIO_FAMILY
        /// </summary>
        public string PlPrioFamily { get; set; }

        /// <summary>
        ///     Gets or sets PL_PROJ_USE_DT
        /// </summary>
        public DateTime? PlProjUseDt { get; set; }

        /// <summary>
        ///     Gets or sets PL_SEARCH_DEPTH
        /// </summary>
        public short PlSearchDepth { get; set; }

        /// <summary>
        ///     Gets or sets PLAN_FENCE_OFF
        /// </summary>
        public decimal PlanFenceOff { get; set; }

        /// <summary>
        ///     Gets or sets PLAN_HORIZON
        /// </summary>
        public decimal PlanHorizon { get; set; }

        /// <summary>
        ///     Gets or sets PLANNED_BY
        /// </summary>
        public string PlannedBy { get; set; }

        /// <summary>
        ///     Gets or sets PLANNER_CD
        /// </summary>
        public string PlannerCd { get; set; }

        /// <summary>
        ///     Gets or sets PROD_CONSUMP
        /// </summary>
        public string ProdConsump { get; set; }

        /// <summary>
        ///     Gets or sets PUR_MAX_ORDER
        /// </summary>
        public decimal PurMaxOrder { get; set; }

        /// <summary>
        ///     Gets or sets PUR_MIN_ORDER
        /// </summary>
        public decimal PurMinOrder { get; set; }

        /// <summary>
        ///     Gets or sets PUR_ORDER_MOD
        /// </summary>
        public string PurOrderMod { get; set; }

        /// <summary>
        ///     Gets or sets PUR_ORDER_MULTIPLE
        /// </summary>
        public decimal PurOrderMultiple { get; set; }

        /// <summary>
        ///     Gets or sets PURCHASE_YIELD
        /// </summary>
        public decimal PurchaseYield { get; set; }

        /// <summary>
        ///     Gets or sets RELEASED_ORDER
        /// </summary>
        public short ReleasedOrder { get; set; }

        /// <summary>
        ///     Gets or sets RESCH_IN_FACTOR
        /// </summary>
        public decimal ReschInFactor { get; set; }

        /// <summary>
        ///     Gets or sets RESCH_OUT_FACTOR
        /// </summary>
        public decimal ReschOutFactor { get; set; }

        /// <summary>
        ///     Gets or sets SAFETY_LEVEL
        /// </summary>
        public decimal SafetyLevel { get; set; }

        /// <summary>
        ///     Gets or sets SALES_CONSUMP
        /// </summary>
        public string SalesConsump { get; set; }

        /// <summary>
        ///     Gets or sets SPOT_BUY_FLG
        /// </summary>
        public string SpotBuyFlg { get; set; }

        /// <summary>
        ///     Gets or sets TRANS_CONSUMP
        /// </summary>
        public string TransConsump { get; set; }

        /// <summary>
        ///     Gets or sets TRANS_ORD_MULTIPLE
        /// </summary>
        public decimal TransOrdMultiple { get; set; }

        /// <summary>
        ///     Gets or sets TRANSFER_MAX_ORDER
        /// </summary>
        public decimal TransferMaxOrder { get; set; }

        /// <summary>
        ///     Gets or sets TRANSFER_MIN_ORDER
        /// </summary>
        public decimal TransferMinOrder { get; set; }

        /// <summary>
        ///     Gets or sets TRANSFER_ORD_MOD
        /// </summary>
        public string TransferOrdMod { get; set; }

        /// <summary>
        ///     Gets or sets TRANSFER_YIELD
        /// </summary>
        public decimal TransferYield { get; set; }

        /// <summary>
        ///     Gets or sets USE_SHIPTO_LOC
        /// </summary>
        public string UseShiptoLoc { get; set; }

        #endregion // Public Properties
    }
}
