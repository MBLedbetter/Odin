using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class PurchItemBu
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets ACCEPT_ALL_SHIPTO
        /// </summary>
        public string AcceptAllShipto { get; set; }

        /// <summary>
        ///     Gets or sets ACCEPT_ALL_VENDOR
        /// </summary>
        public string AcceptAllVendor { get; set; }

        /// <summary>
        ///     Gets or sets ACCOUNT
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        ///     Gets or sets AFFILIATE
        /// </summary>
        public string Affiliate { get; set; }

        /// <summary>
        ///     Gets or sets AFFILIATE_INTRA1
        /// </summary>
        public string AffiliateIntra1 { get; set; }

        /// <summary>
        ///     Gets or sets AFFILIATE_INTRA2
        /// </summary>
        public string AffiliateIntra2 { get; set; }

        /// <summary>
        ///     Gets or sets ALTACCT
        /// </summary>
        public string Altacct { get; set; }

        /// <summary>
        ///     Gets or sets AUTO_SOURCE
        /// </summary>
        public string AutoSource { get; set; }

        /// <summary>
        ///     Gets or sets BU_UPD_PRICE
        /// </summary>
        public string BuUpdPrice { get; set; }

        /// <summary>
        ///     Gets or sets BUDGET_REF
        /// </summary>
        public string BudgetRef { get; set; }

        /// <summary>
        ///     Gets or sets BUSINESS_UNIT
        /// </summary>
        public string BusinessUnit { get; set; }

        /// <summary>
        ///     Gets or sets CHARTFIELD1
        /// </summary>
        public string Chartfield1 { get; set; }

        /// <summary>
        ///     Gets or sets CHARTFIELD2
        /// </summary>
        public string Chartfield2 { get; set; }

        /// <summary>
        ///     Gets or sets CHARTFIELD3
        /// </summary>
        public string Chartfield3 { get; set; }

        /// <summary>
        ///     Gets or sets CLASS_FLD
        /// </summary>
        public string ClassFld { get; set; }

        /// <summary>
        ///     Gets or sets CONTRACT_REQ
        /// </summary>
        public string ContractReq { get; set; }

        /// <summary>
        ///     Gets or sets CURRENCY_CD
        /// </summary>
        public string CurrencyCd { get; set; }

        /// <summary>
        ///     Gets or sets DEPTID
        /// </summary>
        public string Deptid { get; set; }

        /// <summary>
        ///     Gets or sets EXT_PRC_TOL
        /// </summary>
        public decimal ExtPrcTol { get; set; }

        /// <summary>
        ///     Gets or sets EXT_PRC_TOL_L
        /// </summary>
        public decimal ExtPrcTolL { get; set; }

        /// <summary>
        ///     Gets or sets FUND_CODE
        /// </summary>
        public string FundCode { get; set; }

        /// <summary>
        ///     Gets or sets INSPECT_CD
        /// </summary>
        public string InspectCd { get; set; }

        /// <summary>
        ///     Gets or sets INSPECT_SAMPLE_PER
        /// </summary>
        public decimal InspectSamplePer { get; set; }

        /// <summary>
        ///     Gets or sets INSPECT_UOM_TYPE
        /// </summary>
        public string InspectUomType { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_ID
        /// </summary>
        public string InvItemId { get; set; }

        /// <summary>
        ///     Gets or sets KB_OVR_RECV_TOL
        /// </summary>
        public decimal KbOvrRecvTol { get; set; }

        /// <summary>
        ///     Gets or sets KB_PAST_DUE_PO
        /// </summary>
        public string KbPastDuePo { get; set; }

        /// <summary>
        ///     Gets or sets LAST_DTTM_UPDATE
        /// </summary>
        public DateTime LastDttmUpdate { get; set; }

        /// <summary>
        ///     Gets or sets LAST_PO_PRICE_PAID
        /// </summary>
        public decimal LastPoPricePaid { get; set; }

        /// <summary>
        ///     Gets or sets OPERATING_UNIT
        /// </summary>
        public string OperatingUnit { get; set; }

        /// <summary>
        ///     Gets or sets OPRID_MODIFIED_BY
        /// </summary>
        public string OpridModifiedBy { get; set; }

        /// <summary>
        ///     Gets or sets PACKING_VOLUME
        /// </summary>
        public decimal PackingVolume { get; set; }

        /// <summary>
        ///     Gets or sets PACKING_WEIGHT
        /// </summary>
        public decimal PackingWeight { get; set; }

        /// <summary>
        ///     Gets or sets PCT_EXT_PRC_TOL
        /// </summary>
        public decimal PctExtPrcTol { get; set; }

        /// <summary>
        ///     Gets or sets PCT_EXT_PRC_TOL_L
        /// </summary>
        public decimal PctExtPrcTolL { get; set; }

        /// <summary>
        ///     Gets or sets PCT_UNDER_QTY
        /// </summary>
        public short PctUnderQty { get; set; }

        /// <summary>
        ///     Gets or sets PCT_UNIT_PRC_TOL
        /// </summary>
        public decimal PctUnitPrcTol { get; set; }

        /// <summary>
        ///     Gets or sets PCT_UNIT_PRC_TOL_L
        /// </summary>
        public decimal PctUnitPrcTolL { get; set; }

        /// <summary>
        ///     Gets or sets PRICE_LIST
        /// </summary>
        public decimal PriceList { get; set; }

        /// <summary>
        ///     Gets or sets PRIMARY_BUYER
        /// </summary>
        public string PrimaryBuyer { get; set; }

        /// <summary>
        ///     Gets or sets PRODUCT
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        ///     Gets or sets PROGRAM_CODE
        /// </summary>
        public string ProgramCode { get; set; }

        /// <summary>
        ///     Gets or sets PROJECT_ID
        /// </summary>
        public string ProjectId { get; set; }

        /// <summary>
        ///     Gets or sets QTY_RECV_TOL_PCT
        /// </summary>
        public decimal QtyRecvTolPct { get; set; }

        /// <summary>
        ///     Gets or sets RECV_PARTIAL_FLG
        /// </summary>
        public string RecvPartialFlg { get; set; }

        /// <summary>
        ///     Gets or sets RECV_REQ
        /// </summary>
        public string RecvReq { get; set; }

        /// <summary>
        ///     Gets or sets REJECT_DAYS
        /// </summary>
        public short RejectDays { get; set; }

        /// <summary>
        ///     Gets or sets RFQ_REQ_FLAG
        /// </summary>
        public string RfqReqFlag { get; set; }

        /// <summary>
        ///     Gets or sets RJCT_OVER_TOL_FLAG
        /// </summary>
        public string RjctOverTolFlag { get; set; }

        /// <summary>
        ///     Gets or sets ROUTING_ID
        /// </summary>
        public string RoutingId { get; set; }

        /// <summary>
        ///     Gets or sets SETID
        /// </summary>
        public string Setid { get; set; }

        /// <summary>
        ///     Gets or sets SHIP_LATE_DAYS
        /// </summary>
        public short ShipLateDays { get; set; }

        /// <summary>
        ///     Gets or sets SHIP_TYPE_ID
        /// </summary>
        public string ShipTypeId { get; set; }

        /// <summary>
        ///     Gets or sets STD_LEAD
        /// </summary>
        public short StdLead { get; set; }

        /// <summary>
        ///     Gets or sets STOCKLESS_FLG
        /// </summary>
        public string StocklessFlg { get; set; }

        /// <summary>
        ///     Gets or sets TAXABLE_CD
        /// </summary>
        public string TaxableCd { get; set; }

        /// <summary>
        ///     Gets or sets ULTIMATE_USE_CD
        /// </summary>
        public string UltimateUseCd { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_MEASURE_VOL
        /// </summary>
        public string UnitMeasureVol { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_MEASURE_WT
        /// </summary>
        public string UnitMeasureWt { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_PRC_TOL
        /// </summary>
        public decimal UnitPrcTol { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_PRC_TOL_L
        /// </summary>
        public decimal UnitPrcTolL { get; set; }

        /// <summary>
        ///     Gets or sets VAT_SVC_PERFRM_FLG
        /// </summary>
        public string VatSvcPerfrmFlg { get; set; }

        #endregion // Public Properties
    }
}
