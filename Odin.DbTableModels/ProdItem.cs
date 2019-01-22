using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class ProdItem
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets ACTIVITY_ID
        /// </summary>
        public string ActivityId { get; set; }

        /// <summary>
        ///     Gets or sets APPLIES_TO
        /// </summary>
        public string AppliesTo { get; set; }

        /// <summary>
        ///     Gets or sets BP_DTL_TMPL_ID
        /// </summary>
        public string BpDtlTmplId { get; set; }

        /// <summary>
        ///     Gets or sets BUSINESS_UNIT_PC
        /// </summary>
        public string BusinessUnitPc { get; set; }

        /// <summary>
        ///     Gets or sets CA_AP_TMPL_ID
        /// </summary>
        public string CaApTmplId { get; set; }

        /// <summary>
        ///     Gets or sets CA_BP_TMPL_ID
        /// </summary>
        public string CaBpTmplId { get; set; }

        /// <summary>
        ///     Gets or sets CATALOG_NBR
        /// </summary>
        public string CatalogNbr { get; set; }

        /// <summary>
        ///     Gets or sets CFG_CODE_OPT
        /// </summary>
        public string CfgCodeOpt { get; set; }

        /// <summary>
        ///     Gets or sets CFG_KIT_FLAG
        /// </summary>
        public string CfgKitFlag { get; set; }

        /// <summary>
        ///     Gets or sets COMM_FLAG
        /// </summary>
        public string CommFlag { get; set; }

        /// <summary>
        ///     Gets or sets COMM_PCT
        /// </summary>
        public decimal CommPct { get; set; }

        /// <summary>
        ///     Gets or sets COST_ELEMENT
        /// </summary>
        public string CostElement { get; set; }

        /// <summary>
        ///     Gets or sets CP_TEMPLATE_ID
        /// </summary>
        public string CpTemplateId { get; set; }

        /// <summary>
        ///     Gets or sets CP_TREE_DIST
        /// </summary>
        public string CpTreeDist { get; set; }

        /// <summary>
        ///     Gets or sets DATETIME_ADDED
        /// </summary>
        public DateTime DatetimeAdded { get; set; }

        /// <summary>
        ///     Gets or sets DESCR
        /// </summary>
        public string Descr { get; set; }

        /// <summary>
        ///     Gets or sets DESCR254
        /// </summary>
        public string Descr254 { get; set; }

        /// <summary>
        ///     Gets or sets DROP_SHIP_FLAG
        /// </summary>
        public string DropShipFlag { get; set; }

        /// <summary>
        ///     Gets or sets EFF_STATUS
        /// </summary>
        public string EffStatus { get; set; }

        /// <summary>
        ///     Gets or sets EXPORT_LIC_REQ
        /// </summary>
        public string ExportLicReq { get; set; }

        /// <summary>
        ///     Gets or sets FORECAST_ITEM_FLAG
        /// </summary>
        public string ForecastItemFlag { get; set; }

        /// <summary>
        ///     Gets or sets HOLD_UPDATE_SW
        /// </summary>
        public string HoldUpdateSw { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_ID
        /// </summary>
        public string InvItemId { get; set; }

        /// <summary>
        ///     Gets or sets LAST_MAINT_OPRID
        /// </summary>
        public string LastMaintOprid { get; set; }

        /// <summary>
        ///     Gets or sets LASTUPDDTTM
        /// </summary>
        public DateTime Lastupddttm { get; set; }

        /// <summary>
        ///     Gets or sets LOWER_MARGIN_PCT
        /// </summary>
        public decimal LowerMarginPct { get; set; }

        /// <summary>
        ///     Gets or sets MODEL_NBR
        /// </summary>
        public string ModelNbr { get; set; }

        /// <summary>
        ///     Gets or sets PERCENTAGE
        /// </summary>
        public decimal Percentage { get; set; }

        /// <summary>
        ///     Gets or sets PHYSICAL_NATURE
        /// </summary>
        public string PhysicalNature { get; set; }

        /// <summary>
        ///     Gets or sets PRICE_KIT_FLAG
        /// </summary>
        public string PriceKitFlag { get; set; }

        /// <summary>
        ///     Gets or sets PRICING_STRUCTURE
        /// </summary>
        public string PricingStructure { get; set; }

        /// <summary>
        ///     Gets or sets PROD_BRAND
        /// </summary>
        public string ProdBrand { get; set; }

        /// <summary>
        ///     Gets or sets PROD_CATEGORY
        /// </summary>
        public string ProdCategory { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_C1_A
        /// </summary>
        public string ProdFieldC1A { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_C1_B
        /// </summary>
        public string ProdFieldC1B { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_C1_C
        /// </summary>
        public string ProdFieldC1C { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_C1_D
        /// </summary>
        public string ProdFieldC1D { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_C10_A
        /// </summary>
        public string ProdFieldC10A { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_C10_B
        /// </summary>
        public string ProdFieldC10B { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_C10_C
        /// </summary>
        public string ProdFieldC10C { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_C10_D
        /// </summary>
        public string ProdFieldC10D { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_C2
        /// </summary>
        public string ProdFieldC2 { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_C30_A
        /// </summary>
        public string ProdFieldC30A { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_C30_B
        /// </summary>
        public string ProdFieldC30B { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_C30_C
        /// </summary>
        public string ProdFieldC30C { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_C30_D
        /// </summary>
        public string ProdFieldC30D { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_C4
        /// </summary>
        public string ProdFieldC4 { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_C6
        /// </summary>
        public string ProdFieldC6 { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_C8
        /// </summary>
        public string ProdFieldC8 { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_N12_A
        /// </summary>
        public decimal ProdFieldN12A { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_N12_B
        /// </summary>
        public decimal ProdFieldN12B { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_N12_C
        /// </summary>
        public decimal ProdFieldN12C { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_N12_D
        /// </summary>
        public decimal ProdFieldN12D { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_N15_A
        /// </summary>
        public decimal ProdFieldN15A { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_N15_B
        /// </summary>
        public decimal ProdFieldN15B { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_N15_C
        /// </summary>
        public decimal ProdFieldN15C { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FIELD_N15_D
        /// </summary>
        public decimal ProdFieldN15D { get; set; }

        /// <summary>
        ///     Gets or sets PRODUCT_ID
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        ///     Gets or sets PRODUCT_KIT_FLAG
        /// </summary>
        public string ProductKitFlag { get; set; }

        /// <summary>
        ///     Gets or sets PRODUCT_USE
        /// </summary>
        public string ProductUse { get; set; }

        /// <summary>
        ///     Gets or sets PROJECT_ID
        /// </summary>
        public string ProjectId { get; set; }

        /// <summary>
        ///     Gets or sets RENEWABLE
        /// </summary>
        public string Renewable { get; set; }

        /// <summary>
        ///     Gets or sets RETURN_FLAG
        /// </summary>
        public string ReturnFlag { get; set; }

        /// <summary>
        ///     Gets or sets REV_RECOG_METHOD
        /// </summary>
        public string RevRecogMethod { get; set; }

        /// <summary>
        ///     Gets or sets RNW_TEMPLATE_ID
        /// </summary>
        public string RnwTemplateId { get; set; }

        /// <summary>
        ///     Gets or sets SETID
        /// </summary>
        public string Setid { get; set; }

        /// <summary>
        ///     Gets or sets TAX_PRODUCT_NBR
        /// </summary>
        public string TaxProductNbr { get; set; }

        /// <summary>
        ///     Gets or sets TAX_TRANS_SUB_TYPE
        /// </summary>
        public string TaxTransSubType { get; set; }

        /// <summary>
        ///     Gets or sets TAX_TRANS_TYPE
        /// </summary>
        public string TaxTransType { get; set; }

        /// <summary>
        ///     Gets or sets THIRD_PARTY_FLG
        /// </summary>
        public string ThirdPartyFlg { get; set; }

        /// <summary>
        ///     Gets or sets UPPER_MARGIN_PCT
        /// </summary>
        public decimal UpperMarginPct { get; set; }

        /// <summary>
        ///     Gets or sets VAT_SVC_PERFRM_FLG
        /// </summary>
        public string VatSvcPerfrmFlg { get; set; }

        #endregion // Public Properties
    }
}
