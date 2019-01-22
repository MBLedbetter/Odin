using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class InvItems
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets AVAIL_LEAD_TIME
        /// </summary>
        public short AvailLeadTime { get; set; }

        /// <summary>
        ///     Gets or sets AVAIL_STATUS
        /// </summary>
        public string AvailStatus { get; set; }

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
        ///     Gets or sets COMMODITY_CD
        /// </summary>
        public string CommodityCd { get; set; }

        /// <summary>
        ///     Gets or sets COMMODITY_CD_EU
        /// </summary>
        public string CommodityCdEu { get; set; }

        /// <summary>
        ///     Gets or sets CONSUMABLE_FLG
        /// </summary>
        public string ConsumableFlg { get; set; }

        /// <summary>
        ///     Gets or sets CURRENCY_CD
        /// </summary>
        public string CurrencyCd { get; set; }

        /// <summary>
        ///     Gets or sets DESCR254
        /// </summary>
        public string Descr254 { get; set; }

        /// <summary>
        ///     Gets or sets DISPOSABLE_FLAG
        /// </summary>
        public string DisposableFlag { get; set; }

        /// <summary>
        ///     Gets or sets EFFDT
        /// </summary>
        public DateTime Effdt { get; set; }

        /// <summary>
        ///     Gets or sets HARMONIZED_CD
        /// </summary>
        public string HarmonizedCd { get; set; }

        /// <summary>
        ///     Gets or sets HAZ_CLASS_CD
        /// </summary>
        public string HazClassCd { get; set; }

        /// <summary>
        ///     Gets or sets INTL_HAZARD_ID
        /// </summary>
        public string IntlHazardId { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_COLOR
        /// </summary>
        public string InvItemColor { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_HEIGHT
        /// </summary>
        public decimal InvItemHeight { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_ID
        /// </summary>
        public string InvItemId { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_LENGTH
        /// </summary>
        public decimal InvItemLength { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_SIZE
        /// </summary>
        public string InvItemSize { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_TEMPLATE
        /// </summary>
        public string InvItemTemplate { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_TYPE
        /// </summary>
        public string InvItemType { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_VOLUME
        /// </summary>
        public decimal InvItemVolume { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_WEIGHT
        /// </summary>
        public decimal InvItemWeight { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_WIDTH
        /// </summary>
        public decimal InvItemWidth { get; set; }

        /// <summary>
        ///     Gets or sets INV_PROD_GRADE
        /// </summary>
        public string InvProdGrade { get; set; }

        /// <summary>
        ///     Gets or sets INV_STOCK_TYPE
        /// </summary>
        public string InvStockType { get; set; }

        /// <summary>
        ///     Gets or sets LAST_DTTM_UPDATE
        /// </summary>
        public DateTime? LastDttmUpdate { get; set; }

        /// <summary>
        ///     Gets or sets LAST_MAINT_OPRID
        /// </summary>
        public string LastMaintOprid { get; set; }

        /// <summary>
        ///     Gets or sets MAX_CAPACITY
        /// </summary>
        public decimal MaxCapacity { get; set; }

        /// <summary>
        ///     Gets or sets MSDS_ID
        /// </summary>
        public string MsdsId { get; set; }

        /// <summary>
        ///     Gets or sets PACKING_CD
        /// </summary>
        public string PackingCd { get; set; }

        /// <summary>
        ///     Gets or sets POTENCY_RATING
        /// </summary>
        public string PotencyRating { get; set; }

        /// <summary>
        ///     Gets or sets RECOM_HUMIDITY_PCT
        /// </summary>
        public decimal RecomHumidityPct { get; set; }

        /// <summary>
        ///     Gets or sets RECOM_STOR_TEMP
        /// </summary>
        public decimal RecomStorTemp { get; set; }

        /// <summary>
        ///     Gets or sets RECYCLE_FLAG
        /// </summary>
        public string RecycleFlag { get; set; }

        /// <summary>
        ///     Gets or sets RETEST_LEAD_TIME
        /// </summary>
        public short RetestLeadTime { get; set; }

        /// <summary>
        ///     Gets or sets RETURNABLE_FLG
        /// </summary>
        public string ReturnableFlg { get; set; }

        /// <summary>
        ///     Gets or sets REUSABLE_FLAG
        /// </summary>
        public string ReusableFlag { get; set; }

        /// <summary>
        ///     Gets or sets SERVICE_EXCH_AMT
        /// </summary>
        public decimal ServiceExchAmt { get; set; }

        /// <summary>
        ///     Gets or sets SERVICE_PRICE
        /// </summary>
        public decimal ServicePrice { get; set; }

        /// <summary>
        ///     Gets or sets SERVICEABLE_FLG
        /// </summary>
        public string ServiceableFlg { get; set; }

        /// <summary>
        ///     Gets or sets SETID
        /// </summary>
        public string Setid { get; set; }

        /// <summary>
        ///     Gets or sets SHELF_LIFE
        /// </summary>
        public short ShelfLife { get; set; }

        /// <summary>
        ///     Gets or sets SHIP_TYPE_ID
        /// </summary>
        public string ShipTypeId { get; set; }

        /// <summary>
        ///     Gets or sets STOR_RULES_ID
        /// </summary>
        public string StorRulesId { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_MEASURE_DIM
        /// </summary>
        public string UnitMeasureDim { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_MEASURE_TEMP
        /// </summary>
        public string UnitMeasureTemp { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_MEASURE_VOL
        /// </summary>
        public string UnitMeasureVol { get; set; }

        /// <summary>
        ///     Gets or sets UNIT_MEASURE_WT
        /// </summary>
        public string UnitMeasureWt { get; set; }

        /// <summary>
        ///     Gets or sets UPC_ID
        /// </summary>
        public string UpcId { get; set; }

        #endregion // Public Properties
    }
}
