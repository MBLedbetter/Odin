using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class OrdLine
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets ADDR_OVRD_LEVEL
        /// </summary>
        public string AddrOvrdLevel { get; set; }

        /// <summary>
        ///     Gets or sets ADDRESS_SEQ_NUM
        /// </summary>
        public short AddressSeqNum { get; set; }

        /// <summary>
        ///     Gets or sets AERP
        /// </summary>
        public string Aerp { get; set; }

        /// <summary>
        ///     Gets or sets ALLOW_OVERPICK_FLG
        /// </summary>
        public string AllowOverpickFlg { get; set; }

        /// <summary>
        ///     Gets or sets BCKORDR_CNCL_FLAG
        /// </summary>
        public string BckordrCnclFlag { get; set; }

        /// <summary>
        ///     Gets or sets BUSINESS_UNIT
        /// </summary>
        public string BusinessUnit { get; set; }

        /// <summary>
        ///     Gets or sets CANCEL_DATE
        /// </summary>
        public DateTime CancelDate { get; set; }

        /// <summary>
        ///     Gets or sets CARRIER_ID
        /// </summary>
        public string CarrierId { get; set; }

        /// <summary>
        ///     Gets or sets CARRIER_ID_EXP
        /// </summary>
        public string CarrierIdExp { get; set; }

        /// <summary>
        ///     Gets or sets CCI_REQ_EXP
        /// </summary>
        public string CciReqExp { get; set; }

        /// <summary>
        ///     Gets or sets CNTRCT_ID
        /// </summary>
        public string CntrctId { get; set; }

        /// <summary>
        ///     Gets or sets CNTRCT_LINE_NBR
        /// </summary>
        public int CntrctLineNbr { get; set; }

        /// <summary>
        ///     Gets or sets CNTRCT_SCHED_NBR
        /// </summary>
        public int CntrctSchedNbr { get; set; }

        /// <summary>
        ///     Gets or sets CONFIG_CODE
        /// </summary>
        public string ConfigCode { get; set; }

        /// <summary>
        ///     Gets or sets COO_REQ_EXP
        /// </summary>
        public string CooReqExp { get; set; }

        /// <summary>
        ///     Gets or sets COUNTRY_LOC_BUYER
        /// </summary>
        public string CountryLocBuyer { get; set; }

        /// <summary>
        ///     Gets or sets COUNTRY_LOC_SELLER
        /// </summary>
        public string CountryLocSeller { get; set; }

        /// <summary>
        ///     Gets or sets COUNTRY_SHIP_FROM
        /// </summary>
        public string CountryShipFrom { get; set; }

        /// <summary>
        ///     Gets or sets COUNTRY_SHIP_TO
        /// </summary>
        public string CountryShipTo { get; set; }

        /// <summary>
        ///     Gets or sets COUNTRY_VAT_BILLFR
        /// </summary>
        public string CountryVatBillfr { get; set; }

        /// <summary>
        ///     Gets or sets COUNTRY_VAT_BILLTO
        /// </summary>
        public string CountryVatBillto { get; set; }

        /// <summary>
        ///     Gets or sets COUNTRY_VAT_PERFRM
        /// </summary>
        public string CountryVatPerfrm { get; set; }

        /// <summary>
        ///     Gets or sets COUNTRY_VAT_SUPPLY
        /// </summary>
        public string CountryVatSupply { get; set; }

        /// <summary>
        ///     Gets or sets CP_TEMPLATE_ID
        /// </summary>
        public string CpTemplateId { get; set; }

        /// <summary>
        ///     Gets or sets CSD_BENEFIT_ID
        /// </summary>
        public string CsdBenefitId { get; set; }

        /// <summary>
        ///     Gets or sets CURRENCY_CD
        /// </summary>
        public string CurrencyCd { get; set; }

        /// <summary>
        ///     Gets or sets CURRENCY_CD_BASE
        /// </summary>
        public string CurrencyCdBase { get; set; }

        /// <summary>
        ///     Gets or sets CUST_BBACK_ALL_BSE
        /// </summary>
        public decimal CustBbackAllBse { get; set; }

        /// <summary>
        ///     Gets or sets CUST_BILL_BACK_ALL
        /// </summary>
        public decimal CustBillBackAll { get; set; }

        /// <summary>
        ///     Gets or sets CUST_NET_PRC_BASE
        /// </summary>
        public decimal CustNetPrcBase { get; set; }

        /// <summary>
        ///     Gets or sets CUST_NET_PRICE
        /// </summary>
        public decimal CustNetPrice { get; set; }

        /// <summary>
        ///     Gets or sets CUST_OFF_INV_BASE
        /// </summary>
        public decimal CustOffInvBase { get; set; }

        /// <summary>
        ///     Gets or sets CUST_OFF_INV_DISC
        /// </summary>
        public decimal CustOffInvDisc { get; set; }

        /// <summary>
        ///     Gets or sets CUST_PO_PRC_BASE
        /// </summary>
        public decimal CustPoPrcBase { get; set; }

        /// <summary>
        ///     Gets or sets CUST_PO_PRICE
        /// </summary>
        public decimal CustPoPrice { get; set; }

        /// <summary>
        ///     Gets or sets CUSTOMER_ITEM_NBR
        /// </summary>
        public string CustomerItemNbr { get; set; }

        /// <summary>
        ///     Gets or sets CUSTOMER_PO
        /// </summary>
        public string CustomerPo { get; set; }

        /// <summary>
        ///     Gets or sets CUSTOMER_PO_LINE
        /// </summary>
        public string CustomerPoLine { get; set; }

        /// <summary>
        ///     Gets or sets DATETIME_ADDED
        /// </summary>
        public DateTime DatetimeAdded { get; set; }

        /// <summary>
        ///     Gets or sets DROP_SHIP_FLAG
        /// </summary>
        public string DropShipFlag { get; set; }

        /// <summary>
        ///     Gets or sets EXPORT
        /// </summary>
        public string Export { get; set; }

        /// <summary>
        ///     Gets or sets EXPORT_APPL_DT
        /// </summary>
        public DateTime ExportApplDt { get; set; }

        /// <summary>
        ///     Gets or sets EXPORT_LIC_APPL
        /// </summary>
        public string ExportLicAppl { get; set; }

        /// <summary>
        ///     Gets or sets EXPORT_LIC_EXPIRE
        /// </summary>
        public DateTime ExportLicExpire { get; set; }

        /// <summary>
        ///     Gets or sets EXPORT_LIC_NBR
        /// </summary>
        public string ExportLicNbr { get; set; }

        /// <summary>
        ///     Gets or sets EXPORT_LIC_QTY
        /// </summary>
        public int ExportLicQty { get; set; }

        /// <summary>
        ///     Gets or sets EXPORT_LIC_REC
        /// </summary>
        public string ExportLicRec { get; set; }

        /// <summary>
        ///     Gets or sets EXPORT_LIC_REQ
        /// </summary>
        public string ExportLicReq { get; set; }

        /// <summary>
        ///     Gets or sets EXPORT_LIC_TYPE
        /// </summary>
        public string ExportLicType { get; set; }

        /// <summary>
        ///     Gets or sets EXPORT_LIC_VALUE
        /// </summary>
        public decimal ExportLicValue { get; set; }

        /// <summary>
        ///     Gets or sets EXPORT_REC_DT
        /// </summary>
        public DateTime ExportRecDt { get; set; }

        /// <summary>
        ///     Gets or sets EXS_TAX_TXN_TYPE
        /// </summary>
        public string ExsTaxTxnType { get; set; }

        /// <summary>
        ///     Gets or sets FREIGHT_TERMS
        /// </summary>
        public string FreightTerms { get; set; }

        /// <summary>
        ///     Gets or sets FREIGHT_TERMS_EXP
        /// </summary>
        public string FreightTermsExp { get; set; }

        /// <summary>
        ///     Gets or sets IMPORT_APPL_DT
        /// </summary>
        public DateTime ImportApplDt { get; set; }

        /// <summary>
        ///     Gets or sets IMPORT_CERT_NBR
        /// </summary>
        public string ImportCertNbr { get; set; }

        /// <summary>
        ///     Gets or sets IMPORT_LIC_APPL
        /// </summary>
        public string ImportLicAppl { get; set; }

        /// <summary>
        ///     Gets or sets IMPORT_LIC_EXP
        /// </summary>
        public DateTime ImportLicExp { get; set; }

        /// <summary>
        ///     Gets or sets IMPORT_LIC_REC
        /// </summary>
        public string ImportLicRec { get; set; }

        /// <summary>
        ///     Gets or sets IMPORT_LIC_REQ
        /// </summary>
        public string ImportLicReq { get; set; }

        /// <summary>
        ///     Gets or sets IMPORT_REC_DT
        /// </summary>
        public DateTime ImportRecDt { get; set; }

        /// <summary>
        ///     Gets or sets IST_TXN_FLG
        /// </summary>
        public string IstTxnFlg { get; set; }

        /// <summary>
        ///     Gets or sets LAST_MAINT_OPRID
        /// </summary>
        public string LastMaintOprid { get; set; }

        /// <summary>
        ///     Gets or sets LASTUPDDTTM
        /// </summary>
        public DateTime Lastupddttm { get; set; }

        /// <summary>
        ///     Gets or sets LIST_PRICE
        /// </summary>
        public decimal ListPrice { get; set; }

        /// <summary>
        ///     Gets or sets LIST_PRICE_BASE
        /// </summary>
        public decimal ListPriceBase { get; set; }

        /// <summary>
        ///     Gets or sets LIST_PRICE_ORIG
        /// </summary>
        public decimal ListPriceOrig { get; set; }

        /// <summary>
        ///     Gets or sets LIST_PRICEORIG_BSE
        /// </summary>
        public decimal ListPriceorigBse { get; set; }

        /// <summary>
        ///     Gets or sets LOAD_ID
        /// </summary>
        public string LoadId { get; set; }

        /// <summary>
        ///     Gets or sets MAX_PICK_TOLERANCE
        /// </summary>
        public decimal MaxPickTolerance { get; set; }

        /// <summary>
        ///     Gets or sets NAFTA_REQ_EXP
        /// </summary>
        public string NaftaReqExp { get; set; }

        /// <summary>
        ///     Gets or sets ORD_LINE_STATUS
        /// </summary>
        public string OrdLineStatus { get; set; }

        /// <summary>
        ///     Gets or sets ORD_LINE_TAG
        /// </summary>
        public int OrdLineTag { get; set; }

        /// <summary>
        ///     Gets or sets ORDER_GRP
        /// </summary>
        public string OrderGrp { get; set; }

        /// <summary>
        ///     Gets or sets ORDER_INT_LINE_NO
        /// </summary>
        public int OrderIntLineNo { get; set; }

        /// <summary>
        ///     Gets or sets ORDER_NO
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        ///     Gets or sets PAYMENT_METHOD
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        ///     Gets or sets PHYSICAL_NATURE
        /// </summary>
        public string PhysicalNature { get; set; }

        /// <summary>
        ///     Gets or sets PRICE
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        ///     Gets or sets PRICE_BASE
        /// </summary>
        public decimal PriceBase { get; set; }

        /// <summary>
        ///     Gets or sets PRICE_ORIG
        /// </summary>
        public decimal PriceOrig { get; set; }

        /// <summary>
        ///     Gets or sets PRICE_ORIG_BASE
        /// </summary>
        public decimal PriceOrigBase { get; set; }

        /// <summary>
        ///     Gets or sets PRICE_PROGRAM
        /// </summary>
        public string PriceProgram { get; set; }

        /// <summary>
        ///     Gets or sets PRICE_PROTECTED
        /// </summary>
        public string PriceProtected { get; set; }

        /// <summary>
        ///     Gets or sets PROCESS_INSTANCE
        /// </summary>
        public decimal ProcessInstance { get; set; }

        /// <summary>
        ///     Gets or sets PROD_ID_ENTERED
        /// </summary>
        public string ProdIdEntered { get; set; }

        /// <summary>
        ///     Gets or sets PROD_ID_SRC
        /// </summary>
        public string ProdIdSrc { get; set; }

        /// <summary>
        ///     Gets or sets PRODUCT_ID
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        ///     Gets or sets PRODUCT_ID_ORIG
        /// </summary>
        public string ProductIdOrig { get; set; }

        /// <summary>
        ///     Gets or sets PYMNT_TERMS_CD
        /// </summary>
        public string PymntTermsCd { get; set; }

        /// <summary>
        ///     Gets or sets QTY_ORDERED
        /// </summary>
        public decimal QtyOrdered { get; set; }

        /// <summary>
        ///     Gets or sets QTY_ORDERED_ORIG
        /// </summary>
        public decimal QtyOrderedOrig { get; set; }

        /// <summary>
        ///     Gets or sets REASON_CD
        /// </summary>
        public string ReasonCd { get; set; }

        /// <summary>
        ///     Gets or sets REPLACEMENT_FLG
        /// </summary>
        public string ReplacementFlg { get; set; }

        /// <summary>
        ///     Gets or sets REQ_ARRIVAL_DTTM
        /// </summary>
        public DateTime ReqArrivalDttm { get; set; }

        /// <summary>
        ///     Gets or sets REQ_SHIP_DTTM
        /// </summary>
        public DateTime ReqShipDttm { get; set; }

        /// <summary>
        ///     Gets or sets SCHED_ARRV_DTTM
        /// </summary>
        public DateTime SchedArrvDttm { get; set; }

        /// <summary>
        ///     Gets or sets SCHED_SHIP_DTTM
        /// </summary>
        public DateTime SchedShipDttm { get; set; }

        /// <summary>
        ///     Gets or sets SED_REQ_EXP
        /// </summary>
        public string SedReqExp { get; set; }

        /// <summary>
        ///     Gets or sets SHIP_FROM_BU
        /// </summary>
        public string ShipFromBu { get; set; }

        /// <summary>
        ///     Gets or sets SHIP_PARTIAL_FLAG
        /// </summary>
        public string ShipPartialFlag { get; set; }

        /// <summary>
        ///     Gets or sets SHIP_PRIOR_FLAG
        /// </summary>
        public string ShipPriorFlag { get; set; }

        /// <summary>
        ///     Gets or sets SHIP_PRIORITY_EXP
        /// </summary>
        public string ShipPriorityExp { get; set; }

        /// <summary>
        ///     Gets or sets SHIP_PRIORITY_ID
        /// </summary>
        public string ShipPriorityId { get; set; }

        /// <summary>
        ///     Gets or sets SHIP_TO_CUST_ID
        /// </summary>
        public string ShipToCustId { get; set; }

        /// <summary>
        ///     Gets or sets SHIP_TYPE_ID
        /// </summary>
        public string ShipTypeId { get; set; }

        /// <summary>
        ///     Gets or sets SHIP_TYPE_ID_EXP
        /// </summary>
        public string ShipTypeIdExp { get; set; }

        /// <summary>
        ///     Gets or sets STATE_LOC_BUYER
        /// </summary>
        public string StateLocBuyer { get; set; }

        /// <summary>
        ///     Gets or sets STATE_LOC_SELLER
        /// </summary>
        public string StateLocSeller { get; set; }

        /// <summary>
        ///     Gets or sets STATE_SHIP_FROM
        /// </summary>
        public string StateShipFrom { get; set; }

        /// <summary>
        ///     Gets or sets STATE_SHIP_TO
        /// </summary>
        public string StateShipTo { get; set; }

        /// <summary>
        ///     Gets or sets STATE_VAT_DEFAULT
        /// </summary>
        public string StateVatDefault { get; set; }

        /// <summary>
        ///     Gets or sets STATE_VAT_PERFRM
        /// </summary>
        public string StateVatPerfrm { get; set; }

        /// <summary>
        ///     Gets or sets STD_DISCOUNT
        /// </summary>
        public decimal StdDiscount { get; set; }

        /// <summary>
        ///     Gets or sets STORE_NUMBER
        /// </summary>
        public string StoreNumber { get; set; }

        /// <summary>
        ///     Gets or sets TAX_CD
        /// </summary>
        public string TaxCd { get; set; }

        /// <summary>
        ///     Gets or sets TAX_CD_VAT
        /// </summary>
        public string TaxCdVat { get; set; }

        /// <summary>
        ///     Gets or sets TAX_CUST_GROUP
        /// </summary>
        public string TaxCustGroup { get; set; }

        /// <summary>
        ///     Gets or sets TRNSPT_LEAD_DAYS
        /// </summary>
        public short TrnsptLeadDays { get; set; }

        /// <summary>
        ///     Gets or sets TRNSPT_LEAD_HOURS
        /// </summary>
        public short TrnsptLeadHours { get; set; }

        /// <summary>
        ///     Gets or sets TRNSPT_LEAD_MIN
        /// </summary>
        public short TrnsptLeadMin { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_COST
        /// </summary>
        public decimal UnitCost { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_OF_MEASURE
        /// </summary>
        public string UnitOfMeasure { get; set; }

        /// <summary>
        ///     Gets or sets UOM_ORIG
        /// </summary>
        public string UomOrig { get; set; }

        /// <summary>
        ///     Gets or sets VAT_APPLICABILITY
        /// </summary>
        public string VatApplicability { get; set; }

        /// <summary>
        ///     Gets or sets VAT_CALC_GROSS_NET
        /// </summary>
        public string VatCalcGrossNet { get; set; }

        /// <summary>
        ///     Gets or sets VAT_CNTRY_SUBD_FLG
        /// </summary>
        public string VatCntrySubdFlg { get; set; }

        /// <summary>
        ///     Gets or sets VAT_DCLRTN_POINT
        /// </summary>
        public string VatDclrtnPoint { get; set; }

        /// <summary>
        ///     Gets or sets VAT_DFLT_DONE_FLG
        /// </summary>
        public string VatDfltDoneFlg { get; set; }

        /// <summary>
        ///     Gets or sets VAT_DST_ACCT_TYPE
        /// </summary>
        public string VatDstAcctType { get; set; }

        /// <summary>
        ///     Gets or sets VAT_ENTITY
        /// </summary>
        public string VatEntity { get; set; }

        /// <summary>
        ///     Gets or sets VAT_EXCPTN_CERTIF
        /// </summary>
        public string VatExcptnCertif { get; set; }

        /// <summary>
        ///     Gets or sets VAT_EXCPTN_TYPE
        /// </summary>
        public string VatExcptnType { get; set; }

        /// <summary>
        ///     Gets or sets VAT_RECALC_FLG
        /// </summary>
        public string VatRecalcFlg { get; set; }

        /// <summary>
        ///     Gets or sets VAT_RGSTRN_BUYER
        /// </summary>
        public string VatRgstrnBuyer { get; set; }

        /// <summary>
        ///     Gets or sets VAT_ROUND_RULE
        /// </summary>
        public string VatRoundRule { get; set; }

        /// <summary>
        ///     Gets or sets VAT_SERVICE_TYPE
        /// </summary>
        public string VatServiceType { get; set; }

        /// <summary>
        ///     Gets or sets VAT_SVC_SUPPLY_FLG
        /// </summary>
        public string VatSvcSupplyFlg { get; set; }

        /// <summary>
        ///     Gets or sets VAT_TREATMENT
        /// </summary>
        public string VatTreatment { get; set; }

        /// <summary>
        ///     Gets or sets VAT_TREATMENT_GRP
        /// </summary>
        public string VatTreatmentGrp { get; set; }

        /// <summary>
        ///     Gets or sets VAT_TXN_TYPE_CD
        /// </summary>
        public string VatTxnTypeCd { get; set; }

        #endregion // Public Properties

    }
}
