/*
Drop Table ODIN_ITEM_UPDATE_RECORDS
SELECT * FROM ODIN_ITEM_UPDATE_RECORDS
ALTER TABLE [dbo].[ODIN_ITEM_UPDATE_RECORDS] ADD [WEBSITE_PRICE] [varchar](18) NULL
*/

USE [ODin]
GO

/****** Object:  Table [dbo].[ODIN_ITEM_UPDATE_RECORDS]    Script Date: 5/9/2018 10:24:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ODIN_ITEM_UPDATE_RECORDS](
	[INV_ITEM_ID] [varchar](18) NULL,
	[ITEM_INPUT_STATUS] [varchar](18) NULL,
	[INPUT_DATE] [dbo].[PSDATETIME] NULL,
	[USERNAME] [varchar](18) NULL,
	[ACCOUNTING_GROUP] [varchar](10) NULL,
	[BILL_OF_MATERIALS] [varchar](max) NULL,
	[CASEPACK_HEIGHT] [varchar](6) NULL,
	[CASEPACK_LENGTH] [varchar](6) NULL,
	[CASEPACK_QTY] [varchar](7) NULL,
	[CASEPACK_UPC] [varchar](12) NULL,
	[CASEPACK_WIDTH] [varchar](6) NULL,
	[CASEPACK_WEIGHT] [varchar](6) NULL,
	[CATEGORY] [varchar](max) NULL,
	[CATEGORY2] [varchar](max) NULL,
	[CATEGORY3] [varchar](max) NULL,
	[COLOR] [varchar](10) NULL,
	[COPYRIGHT] [varchar](max) NULL,
	[COUNTRY_OF_ORIGIN] [varchar](3) NULL,
	[COST_PROFILE_GROUP] [varchar](18) NULL,
	[DEFAULT_ACTUAL_COST_USD] [varchar](12) NULL,
	[DEFAULT_ACTUAL_COST_CAD] [varchar](12) NULL,
	[DESCRIPTION] [varchar](max) NULL,
	[DIRECT_IMPORT] [varchar](1) NULL,
	[DUTY] [varchar](30) NULL,
	[EAN] [varchar](30) NULL,
	[FPLCANL1] [varchar](4) NULL,
	[FPLUSL1] [varchar](4) NULL,
	[GPC] [varchar](10) NULL,
	[HEIGHT] [varchar](12) NULL,
	[INNERPACK_HEIGHT] [varchar](6) NULL,
	[INNERPACK_LENGTH] [varchar](6) NULL,
	[INNERPACK_QTY] [varchar](7) NULL,
	[INNERPACK_UPC] [varchar](12) NULL,
	[INNERPACK_WIDTH] [varchar](6) NULL,
	[INNERPACK_WEIGHT] [varchar](6) NULL,
	[IN_STOCK_DATE] [varchar](30) NULL,
	[ISBN] [varchar](10) NULL,
	[ITEM_CATEGORY] [varchar](60) NULL,
	[ITEM_FAMILY] [varchar](10) NULL,
	[ITEM_GROUP] [varchar](15) NULL,
	[ITEM_KEYWORDS] [varchar](max) NULL,
	[LANGUAGE] [varchar](128) NULL,
	[LENGTH] [varchar](12) NULL,
	[LICENSE] [varchar](255) NULL,
	[LICENSE_BEGIN_DATE] [varchar](30) NULL,
	[LIST_PRICE_CAD] [varchar](16) NULL,
	[LIST_PRICE_USD] [varchar](16) NULL,
	[LIST_PRICE_MXN] [varchar](16) NULL,
	[META_DESCRIPTION] [varchar](255) NULL,
	[MFG_SOURCE] [varchar](2) NULL,
	[MSRP] [varchar](10) NULL,
	[MSRP_CAD] [varchar](15) NULL,
	[MSRP_MXN] [varchar](15) NULL,
	[PRODUCT_FORMAT] [varchar](60) NULL,
	[PRODUCT_GROUP] [varchar](30) NULL,
	[PRODUCT_LINE] [varchar](30) NULL,
	[PROD_QTY] [varchar](266) NULL,
	[PRICING_GROUP] [varchar](10) NULL,
	[PS_STATUS] [varchar](2) NULL,
	[PROPERTY] [varchar](max) NULL,
	[SHORT_DESC] [varchar](max) NULL,
	[SIZE] [varchar](266) NULL,
	[STANDARD_COST] [varchar](15) NULL,
	[STATS_CODE] [varchar](30) NULL,
	[TARIFF_CODE] [varchar](14) NULL,
	[TERRITORY] [varchar](128) NULL,
	[TITLE] [varchar](266) NULL,
	[UDEX] [varchar](30) NULL,
	[UPC] [varchar](18) NULL,
	[WEIGHT] [varchar](12) NULL,
	[WIDTH] [varchar](12) NULL,
	[A_AMAZON_ACTIVE] [varchar](1) NULL,
	[A_BULLET_1] [varchar](254) NULL,
	[A_BULLET_2] [varchar](254) NULL,
	[A_BULLET_3] [varchar](254) NULL,
	[A_BULLET_4] [varchar](254) NULL,
	[A_BULLET_5] [varchar](254) NULL,
	[A_COMPONENTS] [varchar](100) NULL,
	[A_COST] [varchar](12) NULL,
	[A_EXTERNAL_ID_TYPE] [varchar](20) NULL,
	[A_EXTERNAL_ID] [varchar](20) NULL,
	[A_IMAGE_URL_1] [varchar](254) NULL,
	[A_IMAGE_URL_2] [varchar](254) NULL,
	[A_IMAGE_URL_3] [varchar](254) NULL,
	[A_IMAGE_URL_4] [varchar](254) NULL,
	[A_IMAGE_URL_5] [varchar](254) NULL,
	[A_ITEM_HEIGHT] [varchar](12) NULL,
	[A_ITEM_LENGTH] [varchar](12) NULL,
	[A_ITEM_NAME] [varchar](254) NULL,
	[A_ITEM_WEIGHT] [varchar](12) NULL,
	[A_ITEM_WIDTH] [varchar](12) NULL,
	[A_MODEL_NAME] [varchar](50) NULL,
	[A_PACKAGE_LENGTH] [varchar](12) NULL,
	[A_PACKAGE_HEIGHT] [varchar](12) NULL,
	[A_PACKAGE_WIDTH] [varchar](12) NULL,
	[A_PACKAGE_WEIGHT] [varchar](12) NULL,
	[A_PAGE_QTY] [varchar](4) NULL,
	[A_PRODUCT_CATEGORY] [varchar](50) NULL,
	[A_PRODUCT_DESCRIPTION] [varchar](8000) NULL,
	[A_PRODUCT_SUBCATEGORY] [varchar](50) NULL,
	[A_MANUFACTURER_NAME] [varchar](100) NULL,
	[A_MSRP] [varchar](12) NULL,
	[A_SEARCH_TERMS] [varchar](500) NULL,
	[A_SIZE] [varchar](254) NULL,
	[PRINT_ON_DEMAND] [varchar](1) NULL,
	[SELL_ON_FANATICS] [varchar](1) NULL,
	[SELL_ON_JET] [varchar](1) NULL,
	[SELL_ON_WALMART] [varchar](1) NULL,
	[PRODUCT_ID_TRANSLATION] [varchar](100) NULL,
	[A_ASIN] [varchar](10) NULL,
	[A_UPC] [varchar](12) NULL,
	[IMAGE_PATH] [varchar](254) NULL,
	[SELL_ON_WEB] [varchar](1) NULL,
	[SELL_ON_TARGET] [varchar](1) NULL,
	[SAT_CODE] [varchar](20) NULL,
	[SELL_ON_AMAZON] [varchar](1) NULL,
	[SELL_ON_HAYNEEDLE] [varchar](1) NULL,
	[SELL_ON_ALLPOSTERS] [varchar](1) NULL,
	[ALT_IMAGE_FILE_1] [varchar](254) NULL,
	[ALT_IMAGE_FILE_2] [varchar](254) NULL,
	[ALT_IMAGE_FILE_3] [varchar](254) NULL,
	[ALT_IMAGE_FILE_4] [varchar](254) NULL,
	[IMAGE_FILE_NAME] [varchar](254) NULL,
	[PAGE_COUNT] [varchar](4) NULL,
	[SELL_ON_WAYFAIR] [varchar](1) NULL
)

GO

SET ANSI_PADDING OFF
GO

GRANT SELECT, INSERT ON ODIN_ITEM_UPDATE_RECORDS TO Odin

