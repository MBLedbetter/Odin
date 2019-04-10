using System;

namespace Odin.DbTableModels
{
    public class OdinItem
    {
        #region Public Properties
        
        /// <summary>
        ///     Gets or sets ACCOUNTING_GROUP
        /// </summary>
        public string AccountingGroup { get; set; }

        /// <summary>
        ///     Gets or sets ALT_IMAGE_FILE_1
        /// </summary>
        public string AltImageFile1 { get; set; }

        /// <summary>
        ///     Gets or sets ALT_IMAGE_FILE_2
        /// </summary>
        public string AltImageFile2 { get; set; }

        /// <summary>
        ///     Gets or sets ALT_IMAGE_FILE_3
        /// </summary>
        public string AltImageFile3 { get; set; }

        /// <summary>
        ///     Gets or sets ALT_IMAGE_FILE_4
        /// </summary>
        public string AltImageFile4 { get; set; }

        /// <summary>
        ///     Gets or sets ATTRIBUTE_SET
        /// </summary>
        public string AttributeSet { get; set; }

        /// <summary>
        ///     Gets or sets BILL_OF_MATERIALS
        /// </summary>
        public string BillOfMaterials { get; set; }

        /// <summary>
        ///     Gets or sets CASEPACK_HEIGHT
        /// </summary>
        public decimal? CasepackHeight { get; set; }

        /// <summary>
        ///     Gets or sets CASEPACK_LENGTH
        /// </summary>
        public decimal? CasepackLength { get; set; }

        /// <summary>
        ///     Gets or sets CASEPACK_QTY
        /// </summary>
        public short CasepackQty { get; set; }

        /// <summary>
        ///     Gets or sets CASEPACK_UPC
        /// </summary>
        public string CasepackUpc { get; set; }

        /// <summary>
        ///     Gets or sets CASEPACK_WEIGHT
        /// </summary>
        public decimal? CasepackWeight { get; set; }

        /// <summary>
        ///     Gets or sets CASEPACK_WIDTH
        /// </summary>
        public decimal? CasepackWidth { get; set; }

        /// <summary>
        ///     Gets or sets CATEGORY
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        ///     Gets or sets CM_GROUP
        /// </summary>
        public string CmGroup { get; set; }

        /// <summary>
        ///     Gets or sets COPYRIGHT
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        ///     Gets or sets COUNTRY_IST_ORIGIN
        /// </summary>
        public string CountryIstOrigin { get; set; }

        /// <summary>
        ///     Gets or sets DACCAD
        /// </summary>
        public decimal? DefaultActualCostCad { get; set; }

        /// <summary>
        ///     Gets or sets DACUSD
        /// </summary>
        public decimal? DefaultActualCostUsd { get; set; }

        /// <summary>
        ///     Gets or sets DESCR60
        /// </summary>
        public string Descr60 { get; set; }

        /// <summary>
        ///     Gets or sets DIRECT_IMPORT
        /// </summary>
        public string DirectImport { get; set; }

        /// <summary>
        ///     Gets or sets DUTY
        /// </summary>
        public string Duty { get; set; }

        /// <summary>
        ///     Gets or sets EAN
        /// </summary>
        public string Ean { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceASIN
        /// </summary>
        public string EcommerceAsin { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceBULLET_1
        /// </summary>
        public string EcommerceBullet1 { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceBULLET_2
        /// </summary>
        public string EcommerceBullet2 { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceBULLET_3
        /// </summary>
        public string EcommerceBullet3 { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceBULLET_4
        /// </summary>
        public string EcommerceBullet4 { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceBULLET_5
        /// </summary>
        public string EcommerceBullet5 { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceCOMPONENTS
        /// </summary>
        public string EcommerceComponents { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceCOST
        /// </summary>
        public decimal? EcommerceCost { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceCOUNTRY_OF_ORIGIN
        /// </summary>
        public string EcommerceCountryOfOrigin { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceEXTERNAL_ID
        /// </summary>
        public string EcommerceExternalId { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceEXTERNAL_ID_TYPE
        /// </summary>
        public string EcommerceExternalIdType { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceFULL_DESCRIPTION
        /// </summary>
        public string EcommerceFullDescription { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceHEIGHT
        /// </summary>
        public decimal? EcommerceHeight { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceIMAGE_URL_1
        /// </summary>
        public string EcommerceImageUrl1 { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceIMAGE_URL_2
        /// </summary>
        public string EcommerceImageUrl2 { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceIMAGE_URL_3
        /// </summary>
        public string EcommerceImageUrl3 { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceIMAGE_URL_4
        /// </summary>
        public string EcommerceImageUrl4 { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceIMAGE_URL_5
        /// </summary>
        public string EcommerceImageUrl5 { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceITEM_NAME
        /// </summary>
        public string EcommerceItemName { get; set; }

        /// <summary>
        ///     Gets or sets ECOMMERCE_ITEM_TYPE_KEYWORDS
        /// </summary>
        public string EcommerceItemTypeKeywords { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceLENGTH
        /// </summary>
        public decimal? EcommerceLength { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceMANUFACTURER_NAME
        /// </summary>
        public string EcommerceManufacturerName { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceMODEL_NAME
        /// </summary>
        public string EcommerceModelName { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceMSRP
        /// </summary>
        public decimal? EcommerceMsrp { get; set; }

        /// <summary>
        ///     Gets or sets EcommercePACKAGE_HEIGHT
        /// </summary>
        public decimal? EcommercePackageHeight { get; set; }

        /// <summary>
        ///     Gets or sets EcommercePACKAGE_LENGTH
        /// </summary>
        public decimal? EcommercePackageLength { get; set; }

        /// <summary>
        ///     Gets or sets EcommercePACKAGE_WEIGHT
        /// </summary>
        public decimal? EcommercePackageWeight { get; set; }

        /// <summary>
        ///     Gets or sets EcommercePACKAGE_WIDTH
        /// </summary>
        public decimal? EcommercePackageWidth { get; set; }

        /// <summary>
        ///     Gets or sets EcommercePAGE_COUNT
        /// </summary>
        public int? EcommercePageCount { get; set; }

        /// <summary>
        ///     Gets or sets ECOMMERCE_PARENT_ASIN
        /// </summary>
        public string EcommerceParentAsin { get; set; }

        /// <summary>
        ///     Gets or sets EcommercePRODUCT_CATEGORY
        /// </summary>
        public string EcommerceProductCategory { get; set; }

        /// <summary>
        ///     Gets or sets EcommercePRODUCT_SUBCATEGORY
        /// </summary>
        public string EcommerceProductSubcategory { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceGENERIC_KEYWORDS
        /// </summary>
        public string EcommerceGenericKeywords { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceSIZE
        /// </summary>
        public string EcommerceSize { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceSEARCH_TERMS
        /// </summary>
        public string EcommerceSubjectKeywords { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceUPC
        /// </summary>
        public string EcommerceUpc { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceWEIGHT
        /// </summary>
        public decimal? EcommerceWeight { get; set; }

        /// <summary>
        ///     Gets or sets EcommerceWIDTH
        /// </summary>
        public decimal? EcommerceWidth { get; set; }

        /// <summary>
        ///     Gets or sets GPC
        /// </summary>
        public string Gpc { get; set; }

        /// <summary>
        ///     Gets or sets HARMONIZED_CD
        /// </summary>
        public string HarmonizedCd { get; set; }

        /// <summary>
        ///     Gets or sets IMAGE_FILE_NAME
        /// </summary>
        public string ImageFileName { get; set; }

        /// <summary>
        ///     Gets or sets INNERPACK_HEIGHT
        /// </summary>
        public decimal? InnerpackHeight { get; set; }

        /// <summary>
        ///     Gets or sets INNERPACK_LENGTH
        /// </summary>
        public decimal? InnerpackLength { get; set; }

        /// <summary>
        ///     Gets or sets INNERPACK_QTY
        /// </summary>
        public short? InnerpackQty { get; set; }

        /// <summary>
        ///     Gets or sets INNERPACK_UPC
        /// </summary>
        public string InnerpackUpc { get; set; }

        /// <summary>
        ///     Gets or sets INNERPACK_WEIGHT
        /// </summary>
        public decimal? InnerpackWeight { get; set; }

        /// <summary>
        ///     Gets or sets INNERPACK_WIDTH
        /// </summary>
        public decimal? InnerpackWidth { get; set; }

        /// <summary>
        ///     Gets or sets IN_STOCK_DATE
        /// </summary>
        public DateTime? InStockDate { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_COLOR
        /// </summary>
        public string InvItemColor { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_GROUP
        /// </summary>
        public string InvItemGroup { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_HEIGHT
        /// </summary>
        public decimal? InvItemHeight { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_ID
        /// </summary>
        public string InvItemId { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_LENGTH
        /// </summary>
        public decimal? InvItemLength { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_WEIGHT
        /// </summary>
        public decimal? InvItemWeight { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_WIDTH
        /// </summary>
        public decimal? InvItemWidth { get; set; }

        /// <summary>
        ///     Gets or sets INV_PROD_FAM_CD
        /// </summary>
        public string InvProdFamCd { get; set; }

        /// <summary>
        ///     Gets or sets ISBN
        /// </summary>
        public string Isbn { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_KEYWORDS
        /// </summary>
        public string ItemKeywords { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_KEYWORDS_OVERRIDE
        /// </summary>
        public string ItemKeywordsOverride { get; set; }

        /// <summary>
        ///     Gets or sets LANGUAGE
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        ///     Gets or sets LICENSE
        /// </summary>
        public string License { get; set; }

        /// <summary>
        ///     Gets or sets LICENSE_BEGIN_DATE
        /// </summary>
        public DateTime? LicenseBeginDate { get; set; }
        
        /// <summary>
        ///     Gets or sets LIST_PRICE_CAN
        /// </summary>
        public decimal? ListPriceCad { get; set; }

        /// <summary>
        ///     Gets or sets LIST_PRICE_MXN
        /// </summary>
        public decimal? ListPriceMxn { get; set; }

        /// <summary>
        ///     Gets or sets LIST_PRICE_USD
        /// </summary>
        public decimal? ListPriceUsd { get; set; }

        /// <summary>
        ///     Gets or sets META_DESCRIPTION
        /// </summary>
        public string MetaDescription { get; set; }
        
        /// <summary>
        ///     Gets or sets MFG_SOURCE
        /// </summary>
        public string MfgSource { get; set; }

        /// <summary>
        ///     Gets or sets MSRP_CAN
        /// </summary>
        public string MsrpCad { get; set; }

        /// <summary>
        ///     Gets or sets MSRP_MXN
        /// </summary>
        public string MsrpMxn { get; set; }

        /// <summary>
        ///     Gets or sets MSRP_USD
        /// </summary>
        public string MsrpUsd { get; set; }

        /// <summary>
        ///     Gets or sets NEW_DATE
        /// </summary>
        public string NewDate { get; set; }

        /// <summary>
        ///     Gets or sets NEWCATEGORY
        /// </summary>
        public string Newcategory { get; set; }

        /// <summary>
        ///     Gets or sets ON_SITE
        /// </summary>
        public string OnSite { get; set; }

        /// <summary>
        ///     Gets or sets PRICING_GROUP
        /// </summary>
        public string PricingGroup { get; set; }

        /// <summary>
        ///     Gets or sets PRINT_ON_DEMAND
        /// </summary>
        public string PrintOnDemand { get; set; }

        /// <summary>
        ///     Gets or sets PROD_CATEGORY
        /// </summary>
        public string ProdCategory { get; set; }

        /// <summary>
        ///     Gets or sets PROD_FORMAT
        /// </summary>
        public string ProdFormat { get; set; }

        /// <summary>
        ///     Gets or sets PROD_GROUP
        /// </summary>
        public string ProdGroup { get; set; }

        /// <summary>
        ///     Gets or sets PROD_LINE
        /// </summary>
        public string ProdLine { get; set; }

        /// <summary>
        ///     Gets or sets PROD_QTY
        /// </summary>
        public string ProdQty { get; set; }

        /// <summary>
        ///     Gets or sets PRODUCT_ID_TRANSLATION
        /// </summary>
        public string ProductIdTranslation { get; set; }

        /// <summary>
        ///     Gets or sets PROPERTY
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        ///     Gets or sets PSSTATUS
        /// </summary>
        public string Psstatus { get; set; }

        /// <summary>
        ///     Gets or sets SAT_CODE
        /// </summary>
        public string SatCode { get; set; }
        
        /// <summary>
        ///     Gets or sets SELL_ON_ALL_POSTERS
        /// </summary>
        public string SellOnAllPosters { get; set; }

        /// <summary>
        ///     Gets or sets SELL_ON_AMAZON
        /// </summary>
        public string SellOnAmazon { get; set; }

        /// <summary>
        ///     Gets or sets SELL_ON_AMAZON_SELLER_CENTRAL
        /// </summary>
        public string SellOnAmazonSellerCentral { get; set; }

        /// <summary>
        ///     Gets or sets SELL_ON_ECOMMERCE
        /// </summary>
        public string SellOnEcommerce { get; set; }

        /// <summary>
        ///     Gets or sets SELL_ON_FANATICS
        /// </summary>
        public string SellOnFanatics { get; set; }

        /// <summary>
        ///     Gets or sets SELL_ON_GUITAR_CENTER
        /// </summary>
        public string SellOnGuitarCenter { get; set; }

        /// <summary>
        ///     Gets or sets SELL_ON_HAYNEEDLE
        /// </summary>
        public string SellOnHayneedle { get; set; }

        /// <summary>
        ///     Gets or sets SELL_ON_TARGET
        /// </summary>
        public string SellOnTarget { get; set; }

        /// <summary>
        ///     Gets or sets SELL_ON_TRS
        /// </summary>
        public string SellOnTrs { get; set; }

        /// <summary>
        ///     Gets or sets SELL_ON_WALMART
        /// </summary>
        public string SellOnWalmart { get; set; }

        /// <summary>
        ///     Gets or sets SELL_ON_WAYFAIR
        /// </summary>
        public string SellOnWayfair { get; set; }

        /// <summary>
        ///     Gets or sets SELL_ON_WEB
        /// </summary>
        public string SellOnWeb { get; set; }

        /// <summary>
        ///     Gets or sets SHORT_DESC
        /// </summary>
        public string ShortDesc { get; set; }

        /// <summary>
        ///     Gets or sets SIZE
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        ///     Gets or sets STANDARD_COST
        /// </summary>
        public decimal? StandardCost { get; set; }

        /// <summary>
        ///     Gets or sets STATS_CODE
        /// </summary>
        public string StatsCode { get; set; }

        /// <summary>
        ///     Gets or sets TERRITORY
        /// </summary>
        public string Territory { get; set; }

        /// <summary>
        ///     Gets or sets TITLE
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets TITLE_OVERRIDE
        /// </summary>
        public string TitleOverride { get; set; }

        /// <summary>
        ///     Gets or sets UDEX
        /// </summary>
        public string Udex { get; set; }

        /// <summary>
        ///     Gets or sets UPC_ID
        /// </summary>
        public string UpcId { get; set; }

        /// <summary>
        ///     Gets or sets WARRANTY
        /// </summary>
        public string  Warranty { get; set; }

        /// <summary>
        ///     Gets or sets WARRANTY_CHECK
        /// </summary>
        public string WarrantyCheck { get; set; }

        /// <summary>
        ///     Gets or sets WEBSITE_PRICE
        /// </summary>
        public string WebsitePrice { get; set; }

        /// <summary>
        ///     Gets or sets WEBSITE_PRICE_OVERRIDE
        /// </summary>
        public string WebsitePriceOverride { get; set; }

        #endregion // Public Properties
    }
}
