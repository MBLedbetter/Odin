
/*
 
 SELECT TOP 10 * FROM PS_AMAZON_ITEM_ATTRIBUTES
 sp_help PS_AMAZON_ITEM_ATTRIBUTES
 ALTER TABLE [PS_AMAZON_ITEM_ATTRIBUTES] ADD [PAGE_COUNT] INT(4)
 ALTER TABLE [PS_AMAZON_ITEM_ATTRIBUTES] ADD [COST_FANATICS] VARCHAR(12)
 ALTER TABLE [PS_AMAZON_ITEM_ATTRIBUTES] ADD [COST_TARGET] VARCHAR(12)
 ALTER TABLE [PS_AMAZON_ITEM_ATTRIBUTES] ADD [COST_WALMART] VARCHAR(12)
 ALTER TABLE [PS_AMAZON_ITEM_ATTRIBUTES] ADD [SUBJECT_KEYWORDS] VARCHAR(500)
 ALTER TABLE [PS_AMAZON_ITEM_ATTRIBUTES] ADD [PARENT_ASIN] VARCHAR(10)
 ALTER TABLE [PS_AMAZON_ITEM_ATTRIBUTES] ADD [ITEM_TYPE_KEYWORDS] VARCHAR(500)
 ALTER TABLE [PS_AMAZON_ITEM_ATTRIBUTES] ADD [URL_PATH] VARCHAR(500)


*/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PS_AMAZON_ITEM_ATTRIBUTES]
(
	[INV_ITEM_ID] VARCHAR(18) NOT NULL,
	[ITEM_NAME] VARCHAR(254) NOT NULL,
	[MODEL_NAME] VARCHAR(50) NOT NULL,
	[PRODUCT_CATEGORY] VARCHAR(50) NOT NULL,
	[PRODUCT_SUBCATEGORY] VARCHAR(50) NOT NULL,
	[BULLET_1] VARCHAR(254) NOT NULL,
	[BULLET_2] VARCHAR(254) NOT NULL,
	[BULLET_3] VARCHAR(254) NOT NULL,
	[BULLET_4] VARCHAR(254),
	[BULLET_5] VARCHAR(254),
	[FULL_DESCRIPTION] VARCHAR(8000) NOT NULL,
	[EXTERNAL_ID_TYPE] VARCHAR(20) NOT NULL,
	[EXTERNAL_ID] VARCHAR(20) NOT NULL,
	[ASIN] VARCHAR(10) NOT NULL,
	[UPC_OVERRIDE] VARCHAR(12) NOT NULL,
	[SEARCH_TERMS] VARCHAR(500) NOT NULL,
	[IMAGE_URL_1] VARCHAR(254) NOT NULL,
	[IMAGE_URL_2] VARCHAR(254),
	[IMAGE_URL_3] VARCHAR(254),
	[IMAGE_URL_4] VARCHAR(254),
	[IMAGE_URL_5] VARCHAR(254),
	[SIZE] VARCHAR(254),
	[COST] DECIMAL(9, 2) NOT NULL,
	[MSRP] DECIMAL(9, 2) NOT NULL,
	[MANUFACTURER_NAME] VARCHAR(100) NOT NULL,
	[COUNTRY_OF_ORIGIN] VARCHAR(20) NOT NULL,
	[LENGTH] DECIMAL(9, 4) NOT NULL,
	[HEIGHT] DECIMAL(9, 4) NOT NULL,
	[WIDTH] DECIMAL(9, 4) NOT NULL,
	[WEIGHT] DECIMAL(9, 4) NOT NULL,
	[PACKAGE_LENGTH] DECIMAL(9, 4) NOT NULL,
	[PACKAGE_HEIGHT] DECIMAL(9, 4) NOT NULL,
	[PACKAGE_WIDTH] DECIMAL(9, 4) NOT NULL,
	[PACKAGE_WEIGHT] DECIMAL(9, 4) NOT NULL,
	[COMPONENTS] VARCHAR(100)
)
GO

ALTER TABLE [PS_AMAZON_ITEM_ATTRIBUTES] ADD PRIMARY KEY(INV_ITEM_ID)
GO

SET ANSI_PADDING OFF
GO


GRANT SELECT, INSERT, UPDATE ON PS_AMAZON_ITEM_ATTRIBUTES TO Odin
