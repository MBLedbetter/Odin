

/*
SELECT WEBSITE_PRICE, * FROM ODIN_ITEM_TEMPLATES

 ALTER TABLE [ODIN_ITEM_TEMPLATES] ADD [WEBSITE_PRICE] VARCHAR(12)
 ALTER TABLE [ODIN_ITEM_TEMPLATES] ADD [ECOMMERCE_PAGE_COUNT] VARCHAR(12)
 ALTER TABLE [ODIN_ITEM_TEMPLATES] ADD [ECOMMERCE_COST_FANATICS] VARCHAR(12)
 ALTER TABLE [ODIN_ITEM_TEMPLATES] ADD [ECOMMERCE_COST_TARGET] VARCHAR(12)
 ALTER TABLE [ODIN_ITEM_TEMPLATES] ADD [ECOMMERCE_COST_WALMART] VARCHAR(12)
 ALTER TABLE [ODIN_ITEM_TEMPLATES] ADD [ECOMMERCE_COST_WALMART] VARCHAR(12)
 ALTER TABLE [ODIN_ITEM_TEMPLATES] ADD [PRINT_ON_DEMAND] VARCHAR(1)
 ALTER TABLE [ODIN_ITEM_TEMPLATES] ADD [PS_STATUS] VARCHAR(2)
*/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ODIN_ITEM_TEMPLATES]
(  
    [TEMPLATE_ID] VARCHAR(255),
	[INPUT_DATE] [dbo].[PSDATETIME],
    [USERNAME] VARCHAR(18),
    [ACCOUNTING_GROUP] VARCHAR(10),
    [CASEPACK_HEIGHT] VARCHAR(6),
    [CASEPACK_LENGTH] VARCHAR(6),
    [CASEPACK_QTY] VARCHAR(2),
	[CASEPACK_UPC] VARCHAR(12),
    [CASEPACK_WIDTH] VARCHAR(6),
    [CASEPACK_WEIGHT] VARCHAR(6),
    [CATEGORY] VARCHAR(MAX),
    [CATEGORY2] VARCHAR(MAX),
    [CATEGORY3] VARCHAR(MAX),
    [COPYRIGHT] VARCHAR(MAX),
    [COST_PROFILE_GROUP] VARCHAR(18),
    [DEFAULT_ACTUAL_COST_USD] VARCHAR(12),
    [DEFAULT_ACTUAL_COST_CAD] VARCHAR(12),
    [DUTY] VARCHAR(30),
	[GPC] VARCHAR(10),
	[HEIGHT]VARCHAR(12),	
    [INNERPACK_HEIGHT] VARCHAR(6),
    [INNERPACK_LENGTH] VARCHAR(6),
    [INNERPACK_QTY] VARCHAR(2),
	[INNERPACK_UPC] VARCHAR(12),
    [INNERPACK_WIDTH] VARCHAR(6),
    [INNERPACK_WEIGHT] VARCHAR(6),
    [IN_STOCK_DATE]  VARCHAR(30),
    [ITEM_CATEGORY] VARCHAR(60),
    [ITEM_FAMILY] VARCHAR(10),
	[ITEM_GROUP] VARCHAR(15),
    [ITEM_KEYWORDS] VARCHAR(MAX),
	[LENGTH]VARCHAR(12),
    [LICENSE] VARCHAR(255),
    [LIST_PRICE_CAD] VARCHAR(16),
    [LIST_PRICE_USD] VARCHAR(16),
    [LIST_PRICE_MXN] VARCHAR(16),
    [META_DESCRIPTION] VARCHAR(255),
    [MFG_SOURCE] VARCHAR(2),
    [MSRP] VARCHAR(10),
    [MSRP_CAD] VARCHAR(15),
    [MSRP_MXN] VARCHAR(15),
    [PRODUCT_FORMAT] VARCHAR(60),
    [PRODUCT_GROUP] VARCHAR(30),
    [PRODUCT_LINE] VARCHAR(30),
    [PROD_QTY] VARCHAR(266),
    [PRICING_GROUP] VARCHAR(10),
    [SIZE] VARCHAR(266),
    [STANDARD_COST] VARCHAR(15),
    [STATS_CODE] VARCHAR(30),
    [TARIFF_CODE] VARCHAR(14),
    [UDEX] VARCHAR(30),
	[WEIGHT]VARCHAR(12),
	[WIDTH]VARCHAR(12),
	[ECOMMERCE_BULLET_1] VARCHAR(254),
	[ECOMMERCE_BULLET_2] VARCHAR(254),
	[ECOMMERCE_BULLET_3] VARCHAR(254),
	[ECOMMERCE_BULLET_4] VARCHAR(254),
	[ECOMMERCE_BULLET_5] VARCHAR(254),
	[ECOMMERCE_COMPONENTS] VARCHAR(100),
	[ECOMMERCE_COST] VARCHAR(12),
	[ECOMMERCE_EXTERNAL_ID_TYPE] VARCHAR(10),
	[ECOMMERCE_ITEM_HEIGHT]VARCHAR(12),
	[ECOMMERCE_ITEM_LENGTH]VARCHAR(12),
	[ECOMMERCE_ITEM_WEIGHT]VARCHAR(12),
	[ECOMMERCE_ITEM_WIDTH]VARCHAR(12),
	[ECOMMERCE_MODEL_NAME] VARCHAR(50),
	[ECOMMERCE_PACKAGE_LENGTH]VARCHAR(12),
	[ECOMMERCE_PACKAGE_HEIGHT]VARCHAR(12),
	[ECOMMERCE_PACKAGE_WIDTH]VARCHAR(12),
	[ECOMMERCE_PACKAGE_WEIGHT]VARCHAR(12),
	[ECOMMERCE_PAGE_COUNT]VARCHAR(12),
	[ECOMMERCE_PRODUCT_CATEGORY] VARCHAR(50),
	[ECOMMERCE_PRODUCT_DESCRIPTION] VARCHAR(8000),
	[ECOMMERCE_PRODUCT_SUBCATEGORY] VARCHAR(50),
	[ECOMMERCE_MANUFACTURER_NAME] VARCHAR(100),
	[ECOMMERCE_MSRP] VARCHAR(12),
	[ECOMMERCE_SIZE] VARCHAR(254)
	)
GO

SET ANSI_PADDING OFF
GO