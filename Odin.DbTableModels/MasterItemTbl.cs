using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class MasterItemTbl
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets APPROV_REQUIRED
        /// </summary>
        public string ApprovRequired { get; set; }

        /// <summary>
        ///     Gets or sets APPROV_SUBMITTED
        /// </summary>
        public string ApprovSubmitted { get; set; }

        /// <summary>
        ///     Gets or sets APPROVAL_DATE
        /// </summary>
        public DateTime ApprovalDate { get; set; }

        /// <summary>
        ///     Gets or sets APPROVAL_OPRID
        /// </summary>
        public string ApprovalOprid { get; set; }

        /// <summary>
        ///     Gets or sets CATEGORY_ID
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        ///     Gets or sets CFG_CODE_OPT
        /// </summary>
        public string CfgCodeOpt { get; set; }

        /// <summary>
        ///     Gets or sets CFG_COST_OPT
        /// </summary>
        public string CfgCostOpt { get; set; }

        /// <summary>
        ///     Gets or sets CFG_LOT_OPT
        /// </summary>
        public string CfgLotOpt { get; set; }

        /// <summary>
        ///     Gets or sets CHANGE_FIELD
        /// </summary>
        public string ChangeField { get; set; }

        /// <summary>
        ///     Gets or sets CM_GROUP
        /// </summary>
        public string CmGroup { get; set; }

        /// <summary>
        ///     Gets or sets CONSIGNED_FLAG
        /// </summary>
        public string ConsignedFlag { get; set; }

        /// <summary>
        ///     Gets or sets CP_TEMPLATE_ID
        /// </summary>
        public string CpTemplateId { get; set; }

        /// <summary>
        ///     Gets or sets CP_TREE_DIST
        /// </summary>
        public string CpTreeDist { get; set; }

        /// <summary>
        ///     Gets or sets CP_TREE_PRDN
        /// </summary>
        public string CpTreePrdn { get; set; }

        /// <summary>
        ///     Gets or sets DATE_ADDED
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        ///     Gets or sets DENIAL_REASON
        /// </summary>
        public string DenialReason { get; set; }

        /// <summary>
        ///     Gets or sets DESCR
        /// </summary>
        public string Descr { get; set; }

        /// <summary>
        ///     Gets or sets DESCR60
        /// </summary>
        public string Descr60 { get; set; }

        /// <summary>
        ///     Gets or sets DESCRSHORT
        /// </summary>
        public string Descrshort { get; set; }

        /// <summary>
        ///     Gets or sets DEVICE_TRACKING
        /// </summary>
        public string DeviceTracking { get; set; }

        /// <summary>
        ///     Gets or sets DIST_CFG_FLAG
        /// </summary>
        public string DistCfgFlag { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_GROUP
        /// </summary>
        public string InvItemGroup { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_ID
        /// </summary>
        public string InvItemId { get; set; }

        /// <summary>
        ///     Gets or sets INV_PROD_FAM_CD
        /// </summary>
        public string InvProdFamCd { get; set; }

        /// <summary>
        ///     Gets or sets INVENTORY_ITEM
        /// </summary>
        public string InventoryItem { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_C1_A
        /// </summary>
        public string ItemFieldC1A { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_C1_B
        /// </summary>
        public string ItemFieldC1B { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_C1_C
        /// </summary>
        public string ItemFieldC1C { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_C1_D
        /// </summary>
        public string ItemFieldC1D { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_C10_A
        /// </summary>
        public string ItemFieldC10A { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_C10_B
        /// </summary>
        public string ItemFieldC10B { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_C10_C
        /// </summary>
        public string ItemFieldC10C { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_C10_D
        /// </summary>
        public string ItemFieldC10D { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_C2
        /// </summary>
        public string ItemFieldC2 { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_C30_A
        /// </summary>
        public string ItemFieldC30A { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_C30_B
        /// </summary>
        public string ItemFieldC30B { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_C30_C
        /// </summary>
        public string ItemFieldC30C { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_C30_D
        /// </summary>
        public string ItemFieldC30D { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_C4
        /// </summary>
        public string ItemFieldC4 { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_C6
        /// </summary>
        public string ItemFieldC6 { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_C8
        /// </summary>
        public string ItemFieldC8 { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_N12_A
        /// </summary>
        public decimal ItemFieldN12A { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_N12_B
        /// </summary>
        public decimal ItemFieldN12B { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_N12_C
        /// </summary>
        public decimal ItemFieldN12C { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_N12_D
        /// </summary>
        public decimal ItemFieldN12D { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_N15_A
        /// </summary>
        public decimal ItemFieldN15A { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_N15_B
        /// </summary>
        public decimal ItemFieldN15B { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_N15_C
        /// </summary>
        public decimal ItemFieldN15C { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_FIELD_N15_D
        /// </summary>
        public decimal ItemFieldN15D { get; set; }

        /// <summary>
        ///     Gets or sets ITM_STAT_DT_FUTURE
        /// </summary>
        public DateTime? ItmStatDtFuture { get; set; }

        /// <summary>
        ///     Gets or sets ITM_STATUS_CURRENT
        /// </summary>
        public string ItmStatusCurrent { get; set; }

        /// <summary>
        ///     Gets or sets ITM_STATUS_EFFDT
        /// </summary>
        public DateTime ItmStatusEffdt { get; set; }

        /// <summary>
        ///     Gets or sets ITM_STATUS_FUTURE
        /// </summary>
        public string ItmStatusFuture { get; set; }

        /// <summary>
        ///     Gets or sets LAST_DTTM_UPDATE
        /// </summary>
        public DateTime LastDttmUpdate { get; set; }

        /// <summary>
        ///     Gets or sets LAST_MAINT_OPRID
        /// </summary>
        public string LastMaintOprid { get; set; }

        /// <summary>
        ///     Gets or sets LOT_CONTROL
        /// </summary>
        public string LotControl { get; set; }

        /// <summary>
        ///     Gets or sets MATERIAL_RECON_FLG
        /// </summary>
        public string MaterialReconFlg { get; set; }

        /// <summary>
        ///     Gets or sets NON_OWN_FLAG
        /// </summary>
        public string NonOwnFlag { get; set; }

        /// <summary>
        ///     Gets or sets ORIG_OPRID
        /// </summary>
        public string OrigOprid { get; set; }

        /// <summary>
        ///     Gets or sets PHYSICAL_NATURE
        /// </summary>
        public string PhysicalNature { get; set; }

        /// <summary>
        ///     Gets or sets PL_PRIO_FAMILY
        /// </summary>
        public string PlPrioFamily { get; set; }

        /// <summary>
        ///     Gets or sets PRDN_CFG_FLAG
        /// </summary>
        public string PrdnCfgFlag { get; set; }

        /// <summary>
        ///     Gets or sets PROMISE_OPTION
        /// </summary>
        public string PromiseOption { get; set; }

        /// <summary>
        ///     Gets or sets SERIAL_CONTROL
        /// </summary>
        public string SerialControl { get; set; }

        /// <summary>
        ///     Gets or sets SERIAL_IN_PRDN
        /// </summary>
        public string SerialInPrdn { get; set; }

        /// <summary>
        ///     Gets or sets SETID
        /// </summary>
        public string Setid { get; set; }

        /// <summary>
        ///     Gets or sets SHIP_SERIAL_CNTRL
        /// </summary>
        public string ShipSerialCntrl { get; set; }

        /// <summary>
        ///     Gets or sets STAGED_DATE_FLAG
        /// </summary>
        public string StagedDateFlag { get; set; }

        /// <summary>
        ///     Gets or sets TRACE_CHANGE
        /// </summary>
        public string TraceChange { get; set; }

        /// <summary>
        ///     Gets or sets TRACE_USAGE
        /// </summary>
        public string TraceUsage { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_MEASURE_STD
        /// </summary>
        public string UnitMeasureStd { get; set; }

        /// <summary>
        ///     Gets or sets USG_TRCKNG_METHOD
        /// </summary>
        public string UsgTrckngMethod { get; set; }

        #endregion // Public Properties
    }
}
