using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class ItmCatTbl
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets ACCOUNT
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        ///     Gets or sets ALTACCT
        /// </summary>
        public string Altacct { get; set; }

        /// <summary>
        ///     Gets or sets CATEGORY_CD
        /// </summary>
        public string CategoryCd { get; set; }

        /// <summary>
        ///     Gets or sets CATEGORY_ID
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        ///     Gets or sets CATEGORY_TYPE
        /// </summary>
        public string CategoryType { get; set; }

        /// <summary>
        ///     Gets or sets COMMENTS_LONG
        /// </summary>
        public string CommentsLong { get; set; }

    /// <summary>
    ///     Gets or sets CUM_SRC_RUN_LEVEL
    /// </summary>
    public string CumSrcRunLevel { get; set; }

    /// <summary>
    ///     Gets or sets CURRENCY_CD
    /// </summary>
    public string CurrencyCd { get; set; }

    /// <summary>
    ///     Gets or sets DESCR
    /// </summary>
    public string Descr { get; set; }

    /// <summary>
    ///     Gets or sets DESCRSHORT
    /// </summary>
    public string Descrshort { get; set; }

    /// <summary>
    ///     Gets or sets EFF_STATUS
    /// </summary>
    public string EffStatus { get; set; }

    /// <summary>
    ///     Gets or sets EFFDT
    /// </summary>
    public DateTime Effdt { get; set; }

    /// <summary>
    ///     Gets or sets EXT_PRC_TOL
    /// </summary>
    public decimal ExtPrcTol { get; set; }

    /// <summary>
    ///     Gets or sets EXT_PRC_TOL_L
    /// </summary>
    public decimal ExtPrcTolL { get; set; }

    /// <summary>
    ///     Gets or sets HIST_END_DT
    /// </summary>
    public DateTime HistEndDt { get; set; }

    /// <summary>
    ///     Gets or sets HIST_NBR_MTHS
    /// </summary>
    public short HistNbrMths { get; set; }

    /// <summary>
    ///     Gets or sets HIST_START_DT
    /// </summary>
    public DateTime HistStartDt { get; set; }

    /// <summary>
    ///     Gets or sets HIST_START_MTH
    /// </summary>
    public short HistStartMth { get; set; }

    /// <summary>
    ///     Gets or sets INSPECT_CD
    /// </summary>
    public string InspectCd { get; set; }

    /// <summary>
    ///     Gets or sets INSPECT_UOM_TYPE
    /// </summary>
    public string InspectUomType { get; set; }

    /// <summary>
    ///     Gets or sets LEAD_TIME
    /// </summary>
    public short LeadTime { get; set; }

    /// <summary>
    ///     Gets or sets LEAD_TIME_IMP
    /// </summary>
    public decimal LeadTimeImp { get; set; }

    /// <summary>
    ///     Gets or sets MARKETCODE
    /// </summary>
    public string Marketcode { get; set; }

    /// <summary>
    ///     Gets or sets MERCH_AMT_CAT_TOT
    /// </summary>
    public decimal MerchAmtCatTot { get; set; }

    /// <summary>
    ///     Gets or sets NBR_OF_ITMS
    /// </summary>
    public int NbrOfItms { get; set; }

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
    ///     Gets or sets PHYSICAL_NATURE
    /// </summary>
    public string PhysicalNature { get; set; }

    /// <summary>
    ///     Gets or sets PRICE_IMP
    /// </summary>
    public decimal PriceImp { get; set; }

    /// <summary>
    ///     Gets or sets PRIMARY_BUYER
    /// </summary>
    public string PrimaryBuyer { get; set; }

    /// <summary>
    ///     Gets or sets PROFILE_ID
    /// </summary>
    public string ProfileId { get; set; }

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
    ///     Gets or sets SHIPTO_PR_IMP
    /// </summary>
    public decimal ShiptoPrImp { get; set; }

    /// <summary>
    ///     Gets or sets SRC_METHOD
    /// </summary>
    public string SrcMethod { get; set; }

    /// <summary>
    ///     Gets or sets ULTIMATE_USE_CD
    /// </summary>
    public string UltimateUseCd { get; set; }

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

    /// <summary>
    ///     Gets or sets VNDR_PR_IMP
    /// </summary>
    public decimal VndrPrImp { get; set; }

    /// <summary>
    ///     Gets or sets WF_PCT_PRC_TOL_OVR
    /// </summary>
    public decimal WfPctPrcTolOvr { get; set; }

    /// <summary>
    ///     Gets or sets WF_PCT_PRC_TOL_UND
    /// </summary>
    public decimal WfPctPrcTolUnd { get; set; }

    /// <summary>
    ///     Gets or sets WF_PRC_TOL_OVR
    /// </summary>
    public decimal WfPrcTolOvr { get; set; }

    /// <summary>
    ///     Gets or sets WF_PRC_TOL_UND
    /// </summary>
    public decimal WfPrcTolUnd { get; set; }

    #endregion // Public Properties
}
}
