using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class BuItemsInv
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets ADD_HANDLING
        /// </summary>
        public string AddHandling { get; set; }

        /// <summary>
        ///     Gets or sets ANNDM_INSTANCE
        /// </summary>
        public decimal AnndmInstance { get; set; }

        /// <summary>
        ///     Gets or sets ANNDM_STATUS
        /// </summary>
        public string AnndmStatus { get; set; }

        /// <summary>
        ///     Gets or sets AOQ
        /// </summary>
        public decimal Aoq { get; set; }

        /// <summary>
        ///     Gets or sets AVAIL_LEAD_TIME
        /// </summary>
        public short AvailLeadTime { get; set; }

        /// <summary>
        ///     Gets or sets AVERAGE_COST
        /// </summary>
        public decimal AverageCost { get; set; }

        /// <summary>
        ///     Gets or sets AVERAGE_COST_MAT
        /// </summary>
        public decimal AverageCostMat { get; set; }

        /// <summary>
        ///     Gets or sets BOM_CODE
        /// </summary>
        public short BomCode { get; set; }

        /// <summary>
        ///     Gets or sets BOM_USAGE
        /// </summary>
        public string BomUsage { get; set; }

        /// <summary>
        ///     Gets or sets BUSINESS_UNIT
        /// </summary>
        public string BusinessUnit { get; set; }

        /// <summary>
        ///     Gets or sets CHARGE_CODE
        /// </summary>
        public string ChargeCode { get; set; }

        /// <summary>
        ///     Gets or sets CHARGE_MARKUP_AMT
        /// </summary>
        public decimal ChargeMarkupAmt { get; set; }

        /// <summary>
        ///     Gets or sets CHARGE_MARKUP_PCNT
        /// </summary>
        public decimal ChargeMarkupPcnt { get; set; }

        /// <summary>
        ///     Gets or sets CONSIGNED_FLAG
        /// </summary>
        public string ConsignedFlag { get; set; }

        /// <summary>
        ///     Gets or sets COST_ELEMENT
        /// </summary>
        public string CostElement { get; set; }

        /// <summary>
        ///     Gets or sets COST_GROUP_CD
        /// </summary>
        public string CostGroupCd { get; set; }

        /// <summary>
        ///     Gets or sets COUNTRY_IST_ORIGIN
        /// </summary>
        public string CountryIstOrigin { get; set; }

        /// <summary>
        ///     Gets or sets CURRENT_COST
        /// </summary>
        public decimal CurrentCost { get; set; }

        /// <summary>
        ///     Gets or sets CYCLE_INSTANCE
        /// </summary>
        public decimal CycleInstance { get; set; }

        /// <summary>
        ///     Gets or sets DAYS_SUPPLY
        /// </summary>
        public decimal DaysSupply { get; set; }

        /// <summary>
        ///     Gets or sets DECLARED_VALUE
        /// </summary>
        public decimal DeclaredValue { get; set; }

        /// <summary>
        ///     Gets or sets DFLT_ACTUAL_COST
        /// </summary>
        public decimal DfltActualCost { get; set; }

        /// <summary>
        ///     Gets or sets DOCK_TO_STOCK
        /// </summary>
        public decimal DockToStock { get; set; }

        /// <summary>
        ///     Gets or sets DP_POLICYCONTROL
        /// </summary>
        public string DpPolicycontrol { get; set; }

        /// <summary>
        ///     Gets or sets DP_POLICYSET
        /// </summary>
        public string DpPolicyset { get; set; }

        /// <summary>
        ///     Gets or sets DP_PUBLISH_DATE
        /// </summary>
        public DateTime? DpPublishDate { get; set; }

        /// <summary>
        ///     Gets or sets DP_PUBLISHNAME
        /// </summary>
        public string DpPublishname { get; set; }

        /// <summary>
        ///     Gets or sets DT_TIMESTAMP
        /// </summary>
        public DateTime DtTimestamp { get; set; }

        /// <summary>
        ///     Gets or sets EN_AUTO_REV
        /// </summary>
        public string EnAutoRev { get; set; }

        /// <summary>
        ///     Gets or sets EOQ
        /// </summary>
        public decimal Eoq { get; set; }

        /// <summary>
        ///     Gets or sets EOQC_INSTANCE
        /// </summary>
        public decimal EoqcInstance { get; set; }

        /// <summary>
        ///     Gets or sets EOQC_STATUS
        /// </summary>
        public string EoqcStatus { get; set; }

        /// <summary>
        ///     Gets or sets EXCESS_BU
        /// </summary>
        public string ExcessBu { get; set; }

        /// <summary>
        ///     Gets or sets EXCESS_INVENTORY
        /// </summary>
        public string ExcessInventory { get; set; }

        /// <summary>
        ///     Gets or sets EXPORT_LIC_NBR
        /// </summary>
        public string ExportLicNbr { get; set; }

        /// <summary>
        ///     Gets or sets EXPORTER_ECCN
        /// </summary>
        public string ExporterEccn { get; set; }

        /// <summary>
        ///     Gets or sets FOQ
        /// </summary>
        public decimal Foq { get; set; }

        /// <summary>
        ///     Gets or sets FORECAST_ITEM_FLAG
        /// </summary>
        public string ForecastItemFlag { get; set; }

        /// <summary>
        ///     Gets or sets FORECASTER
        /// </summary>
        public string Forecaster { get; set; }

        /// <summary>
        ///     Gets or sets HISTORICAL_LEAD
        /// </summary>
        public decimal HistoricalLead { get; set; }

        /// <summary>
        ///     Gets or sets HLDC_INSTANCE
        /// </summary>
        public decimal HldcInstance { get; set; }

        /// <summary>
        ///     Gets or sets HLDC_STATUS
        /// </summary>
        public string HldcStatus { get; set; }

        /// <summary>
        ///     Gets or sets INCL_WIP_QTY_FLG
        /// </summary>
        public string InclWipQtyFlg { get; set; }

        /// <summary>
        ///     Gets or sets INSPECT_TIME
        /// </summary>
        public decimal InspectTime { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_ID
        /// </summary>
        public string InvItemId { get; set; }

        /// <summary>
        ///     Gets or sets INV_STOCK_TYPE
        /// </summary>
        public string InvStockType { get; set; }

        /// <summary>
        ///     Gets or sets INVENTORY_ITEM
        /// </summary>
        public string InventoryItem { get; set; }

        /// <summary>
        ///     Gets or sets IP_PLANNING_FLG
        /// </summary>
        public string IpPlanningFlg { get; set; }

        /// <summary>
        ///     Gets or sets ISOLATE_ITEM_FLG
        /// </summary>
        public string IsolateItemFlg { get; set; }

        /// <summary>
        ///     Gets or sets ISSUE_METHOD
        /// </summary>
        public string IssueMethod { get; set; }

        /// <summary>
        ///     Gets or sets ISSUE_MULTIPLE
        /// </summary>
        public decimal IssueMultiple { get; set; }

        /// <summary>
        ///     Gets or sets IST_REGION_ORIGIN
        /// </summary>
        public string IstRegionOrigin { get; set; }

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
        ///     Gets or sets LAST_2QTR_DEMAND
        /// </summary>
        public decimal Last2QtrDemand { get; set; }

        /// <summary>
        ///     Gets or sets LAST_ADJUSTMENT
        /// </summary>
        public DateTime? LastAdjustment { get; set; }

        /// <summary>
        ///     Gets or sets LAST_ANNUAL_DEMAND
        /// </summary>
        public decimal LastAnnualDemand { get; set; }

        /// <summary>
        ///     Gets or sets LAST_CYCLE_COUNT
        /// </summary>
        public DateTime LastCycleCount { get; set; }

        /// <summary>
        ///     Gets or sets LAST_DEMAND_CALC
        /// </summary>
        public string LastDemandCalc { get; set; }

        /// <summary>
        ///     Gets or sets LAST_DEMAND_DATE
        /// </summary>
        public DateTime? LastDemandDate { get; set; }

        /// <summary>
        ///     Gets or sets LAST_ISS_EXCESS
        /// </summary>
        public int LastIssExcess { get; set; }

        /// <summary>
        ///     Gets or sets LAST_MO_DEMAND
        /// </summary>
        public decimal LastMoDemand { get; set; }

        /// <summary>
        ///     Gets or sets LAST_ORDER
        /// </summary>
        public string LastOrder { get; set; }

        /// <summary>
        ///     Gets or sets LAST_ORDER_DATE
        /// </summary>
        public DateTime? LastOrderDate { get; set; }

        /// <summary>
        ///     Gets or sets LAST_PIT_COUNT
        /// </summary>
        public DateTime? LastPitCount { get; set; }

        /// <summary>
        ///     Gets or sets LAST_PRICE_PAID
        /// </summary>
        public decimal LastPricePaid { get; set; }

        /// <summary>
        ///     Gets or sets LAST_PUTAWAY_DATE
        /// </summary>
        public DateTime? LastPutawayDate { get; set; }

        /// <summary>
        ///     Gets or sets LAST_QTR_DEMAND
        /// </summary>
        public decimal LastQtrDemand { get; set; }

        /// <summary>
        ///     Gets or sets LAST_UD_DEMAND
        /// </summary>
        public decimal LastUdDemand { get; set; }

        /// <summary>
        ///     Gets or sets LAST_UTIL_REVIEW
        /// </summary>
        public DateTime? LastUtilReview { get; set; }

        /// <summary>
        ///     Gets or sets MASTER_RTG_OPT
        /// </summary>
        public string MasterRtgOpt { get; set; }

        /// <summary>
        ///     Gets or sets MATERIAL_RECON_FLG
        /// </summary>
        public string MaterialReconFlg { get; set; }

        /// <summary>
        ///     Gets or sets MFG_COSTED_FLAG
        /// </summary>
        public string MfgCostedFlag { get; set; }

        /// <summary>
        ///     Gets or sets MFG_LEADTIME_F
        /// </summary>
        public short MfgLeadtimeF { get; set; }

        /// <summary>
        ///     Gets or sets MFG_LEADTIME_V
        /// </summary>
        public short MfgLeadtimeV { get; set; }

        /// <summary>
        ///     Gets or sets MFG_LTRATEF
        /// </summary>
        public string MfgLtratef { get; set; }

        /// <summary>
        ///     Gets or sets MFG_LTRATEV
        /// </summary>
        public string MfgLtratev { get; set; }

        /// <summary>
        ///     Gets or sets MG_ASSOCIATED_BOM
        /// </summary>
        public string MgAssociatedBom { get; set; }

        /// <summary>
        ///     Gets or sets MG_PRDN_OPTION
        /// </summary>
        public string MgPrdnOption { get; set; }

        /// <summary>
        ///     Gets or sets MG_VALID_PRDN_OPT
        /// </summary>
        public string MgValidPrdnOpt { get; set; }

        /// <summary>
        ///     Gets or sets NEXT_UTIL_REVIEW
        /// </summary>
        public DateTime? NextUtilReview { get; set; }

        /// <summary>
        ///     Gets or sets NO_REPLENISH_FLG
        /// </summary>
        public string NoReplenishFlg { get; set; }

        /// <summary>
        ///     Gets or sets NON_OWN_FLAG
        /// </summary>
        public string NonOwnFlag { get; set; }

        /// <summary>
        ///     Gets or sets ORDER_MULTIPLE
        /// </summary>
        public int OrderMultiple { get; set; }

        /// <summary>
        ///     Gets or sets OVERSIZED
        /// </summary>
        public string Oversized { get; set; }

        /// <summary>
        ///     Gets or sets PHANTOM_ITEM_FLAG
        /// </summary>
        public string PhantomItemFlag { get; set; }

        /// <summary>
        ///     Gets or sets PLANNER_CD
        /// </summary>
        public string PlannerCd { get; set; }

        /// <summary>
        ///     Gets or sets PRDN_AREA_CODE
        /// </summary>
        public string PrdnAreaCode { get; set; }

        /// <summary>
        ///     Gets or sets PROJECTED_LEAD
        /// </summary>
        public decimal ProjectedLead { get; set; }

        /// <summary>
        ///     Gets or sets QTY_AVAILABLE
        /// </summary>
        public decimal QtyAvailable { get; set; }

        /// <summary>
        ///     Gets or sets QTY_IUT_PAR
        /// </summary>
        public decimal QtyIutPar { get; set; }

        /// <summary>
        ///     Gets or sets QTY_MAXIMUM
        /// </summary>
        public decimal QtyMaximum { get; set; }

        /// <summary>
        ///     Gets or sets QTY_ONHAND
        /// </summary>
        public decimal QtyOnhand { get; set; }

        /// <summary>
        ///     Gets or sets QTY_OWNED
        /// </summary>
        public decimal QtyOwned { get; set; }

        /// <summary>
        ///     Gets or sets QTY_RESERVED
        /// </summary>
        public decimal QtyReserved { get; set; }

        /// <summary>
        ///     Gets or sets REF_ROUTING_ITEM
        /// </summary>
        public string RefRoutingItem { get; set; }

        /// <summary>
        ///     Gets or sets RELATED_ITEM_ID
        /// </summary>
        public string RelatedItemId { get; set; }

        /// <summary>
        ///     Gets or sets REORDER_POINT
        /// </summary>
        public decimal ReorderPoint { get; set; }

        /// <summary>
        ///     Gets or sets REORDER_QTY
        /// </summary>
        public decimal ReorderQty { get; set; }

        /// <summary>
        ///     Gets or sets REPL_CALC_PERIOD
        /// </summary>
        public short ReplCalcPeriod { get; set; }

        /// <summary>
        ///     Gets or sets REPLENISH_CLASS
        /// </summary>
        public string ReplenishClass { get; set; }

        /// <summary>
        ///     Gets or sets REPLENISH_LEAD
        /// </summary>
        public decimal ReplenishLead { get; set; }

        /// <summary>
        ///     Gets or sets REPLENISH_POINT
        /// </summary>
        public decimal ReplenishPoint { get; set; }

        /// <summary>
        ///     Gets or sets RETEST_LEAD_TIME
        /// </summary>
        public short RetestLeadTime { get; set; }

        /// <summary>
        ///     Gets or sets REVISION_CONTROL
        /// </summary>
        public string RevisionControl { get; set; }

        /// <summary>
        ///     Gets or sets ROPC_INSTANCE
        /// </summary>
        public decimal RopcInstance { get; set; }

        /// <summary>
        ///     Gets or sets ROPC_STATUS
        /// </summary>
        public string RopcStatus { get; set; }

        /// <summary>
        ///     Gets or sets RTG_CODE
        /// </summary>
        public short RtgCode { get; set; }

        /// <summary>
        ///     Gets or sets SAFETY_LEAD_TIME
        /// </summary>
        public decimal SafetyLeadTime { get; set; }

        /// <summary>
        ///     Gets or sets SAFETY_STOCK
        /// </summary>
        public decimal SafetyStock { get; set; }

        /// <summary>
        ///     Gets or sets SF_DISPATCH_MODE
        /// </summary>
        public string SfDispatchMode { get; set; }

        /// <summary>
        ///     Gets or sets SF_RPL_METHOD
        /// </summary>
        public string SfRplMethod { get; set; }

        /// <summary>
        ///     Gets or sets SF_RPL_MODE
        /// </summary>
        public string SfRplMode { get; set; }

        /// <summary>
        ///     Gets or sets SF_RPL_PRDN_AREA
        /// </summary>
        public string SfRplPrdnArea { get; set; }

        /// <summary>
        ///     Gets or sets SF_RPL_SOURCE
        /// </summary>
        public string SfRplSource { get; set; }

        /// <summary>
        ///     Gets or sets SF_RPL_STOR_AREA
        /// </summary>
        public string SfRplStorArea { get; set; }

        /// <summary>
        ///     Gets or sets SF_RPL_STOR_LEV1
        /// </summary>
        public string SfRplStorLev1 { get; set; }

        /// <summary>
        ///     Gets or sets SF_RPL_STOR_LEV2
        /// </summary>
        public string SfRplStorLev2 { get; set; }

        /// <summary>
        ///     Gets or sets SF_RPL_STOR_LEV3
        /// </summary>
        public string SfRplStorLev3 { get; set; }

        /// <summary>
        ///     Gets or sets SF_RPL_STOR_LEV4
        /// </summary>
        public string SfRplStorLev4 { get; set; }

        /// <summary>
        ///     Gets or sets SF_RPL_TYPE
        /// </summary>
        public string SfRplType { get; set; }

        /// <summary>
        ///     Gets or sets SF_RPL_VENDOR_ID
        /// </summary>
        public string SfRplVendorId { get; set; }

        /// <summary>
        ///     Gets or sets SF_RPL_VNDR_LOC
        /// </summary>
        public string SfRplVndrLoc { get; set; }

        /// <summary>
        ///     Gets or sets SF_WIP_MAX_QTY
        /// </summary>
        public decimal SfWipMaxQty { get; set; }

        /// <summary>
        ///     Gets or sets SHELF_LIFE
        /// </summary>
        public short ShelfLife { get; set; }

        /// <summary>
        ///     Gets or sets SHIP_TYPE_ID
        /// </summary>
        public string ShipTypeId { get; set; }

        /// <summary>
        ///     Gets or sets SOURCE_CODE
        /// </summary>
        public string SourceCode { get; set; }

        /// <summary>
        ///     Gets or sets SSTC_INSTANCE
        /// </summary>
        public decimal SstcInstance { get; set; }

        /// <summary>
        ///     Gets or sets SSTC_STATUS
        /// </summary>
        public string SstcStatus { get; set; }

        /// <summary>
        ///     Gets or sets STAGED_DATE_FLAG
        /// </summary>
        public string StagedDateFlag { get; set; }

        /// <summary>
        ///     Gets or sets STD_PACK_UOM
        /// </summary>
        public string StdPackUom { get; set; }

        /// <summary>
        ///     Gets or sets STOCKOUT_RATE
        /// </summary>
        public decimal StockoutRate { get; set; }

        /// <summary>
        ///     Gets or sets TARGET_LEVEL
        /// </summary>
        public decimal TargetLevel { get; set; }

        /// <summary>
        ///     Gets or sets TRANSFER_MIN_ORDER
        /// </summary>
        public decimal TransferMinOrder { get; set; }

        /// <summary>
        ///     Gets or sets TRANSFER_YIELD
        /// </summary>
        public decimal TransferYield { get; set; }

        /// <summary>
        ///     Gets or sets TRANSIT_COST_TYP
        /// </summary>
        public string TransitCostTyp { get; set; }

        /// <summary>
        ///     Gets or sets UOM_CONV_FLAG
        /// </summary>
        public string UomConvFlag { get; set; }

        /// <summary>
        ///     Gets or sets USE_UP_QOH
        /// </summary>
        public string UseUpQoh { get; set; }

        /// <summary>
        ///     Gets or sets USG_TRCKNG_METHOD
        /// </summary>
        public string UsgTrckngMethod { get; set; }

        /// <summary>
        ///     Gets or sets VENDOR_ID
        /// </summary>
        public string VendorId { get; set; }

        /// <summary>
        ///     Gets or sets VNDR_LOC
        /// </summary>
        public string VndrLoc { get; set; }

        /// <summary>
        ///     Gets or sets WIP_MIN_QTY
        /// </summary>
        public decimal WipMinQty { get; set; }

        /// <summary>
        ///     Gets or sets YIELD_CALC_FLG
        /// </summary>
        public string YieldCalcFlg { get; set; }

        #endregion // Public Properties
    }
}
