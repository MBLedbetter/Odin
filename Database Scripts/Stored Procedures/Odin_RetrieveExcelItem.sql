
DROP PROCEDURE Odin_SelectItem
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_SelectItem
	@itemId VARCHAR(18)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT DISTINCT
		   CASEPACK_HEIGHT,
		   CASEPACK_LENGTH,
		   CASEPACK_QTY,
		   ITEM_ATTRIB_EX.CASEPACK_UPC,
		   CASEPACK_WIDTH,
		   CASEPACK_WEIGHT,
		   CM_GROUP,
		   COUNTRY_IST_ORIGIN,
		   (SELECT CURRENT_COST FROM PS_BU_ITEMS_INV WHERE INV_ITEM_ID = @itemId AND BUSINESS_UNIT='TRCN1') AS DACCAD,
		   (SELECT CURRENT_COST FROM PS_BU_ITEMS_INV WHERE INV_ITEM_ID = @itemId AND BUSINESS_UNIT='TRUS1') AS DACUSD,
		   DESCR60,
		   DIRECT_IMPORT,
		   DUTY,
		   HARMONIZED_CD,
		   ITEM_WEB_INFO.IMAGE_PATH,
		   INNERPACK_HEIGHT,
		   INNERPACK_LENGTH,
		   INNERPACK_QTY,
		   ITEM_ATTRIB_EX.INNERPACK_UPC,
		   (SELECT SEND_INVENTORY FROM PS_CUSTOMER_PRODUCT_ATTRIBUTES WHERE PRODUCT_ID = @itemId AND CUST_ID = '000000000020536' AND SETID = 'SHARE') AS SELL_ON_ALLPOSTERS,
		   (SELECT SEND_INVENTORY FROM PS_CUSTOMER_PRODUCT_ATTRIBUTES WHERE PRODUCT_ID = @itemId AND CUST_ID = '000000000125480' AND SETID = 'SHARE') AS SELL_ON_AMAZON,
		   (SELECT SEND_INVENTORY FROM PS_CUSTOMER_PRODUCT_ATTRIBUTES WHERE PRODUCT_ID = @itemId AND CUST_ID = '000000000125904' AND SETID = 'SHARE') AS SELL_ON_FANATICS,
		   (SELECT SEND_INVENTORY FROM PS_CUSTOMER_PRODUCT_ATTRIBUTES WHERE PRODUCT_ID = @itemId AND CUST_ID = '000000000126605' AND SETID = 'SHARE') AS SELL_ON_HAYNEEDLE,
		   (SELECT SEND_INVENTORY FROM PS_CUSTOMER_PRODUCT_ATTRIBUTES WHERE PRODUCT_ID = @itemId AND CUST_ID = '000000000064965' AND SETID = 'SHARE') AS SELL_ON_TARGET,
		   (SELECT SEND_INVENTORY FROM PS_CUSTOMER_PRODUCT_ATTRIBUTES WHERE PRODUCT_ID = @itemId AND CUST_ID = '000000000125921' AND SETID = 'SHARE') AS SELL_ON_WALMART,
		   ITEM_ATTRIB_EX.SELL_ON_WEB,
		   INNERPACK_WIDTH,
		   INNERPACK_WEIGHT,
		   INV_ITEM_COLOR,
		   INV_ITEM_GROUP,
		   INV_ITEM_HEIGHT,
		   INV_ITEM_LENGTH,
		   INV_ITEM_WEIGHT,
		   INV_ITEM_WIDTH,
		   INV_PROD_FAM_CD,
		   MASTER_ITEM_TBL.ITEM_FIELD_C2 AS PSSTATUS,
		   dbo.Odin_RetrieveItemLanguages(@itemId) AS [LANGUAGE],
		   dbo.Odin_RetrieveItemTerritories(@itemId) AS TERRITORY,
		   dbo.Odin_RetrieveProductIdTranslations(@itemId) AS PRODUCT_ID_TRANSLATION,
		   LICENSE_BEGIN_DATE,
		   (SELECT LIST_PRICE FROM PS_PROD_PRICE WHERE PRODUCT_ID=@itemId AND BUSINESS_UNIT_IN='TRCN1' AND CURRENCY_CD='CAD' AND SETID = 'SHARE' AND UNIT_OF_MEASURE = 'EA' AND EFFDT <> '') AS LISTCN,
		   (SELECT LIST_PRICE FROM PS_PROD_PRICE WHERE PRODUCT_ID=@itemId AND BUSINESS_UNIT_IN='TRUS1' AND CURRENCY_CD='USD' AND SETID = 'SHARE' AND UNIT_OF_MEASURE = 'EA' AND EFFDT <> '') AS LISTUS,
		   (SELECT LIST_PRICE FROM PS_PROD_PRICE WHERE PRODUCT_ID=@itemId AND BUSINESS_UNIT_IN='TRUS1' AND CURRENCY_CD='MXN' AND SETID = 'SHARE' AND UNIT_OF_MEASURE = 'EA' AND EFFDT <> '') AS LISTMX,
		   PROD_FIELD_C10_A,
		   PROD_FIELD_C10_C,
		   PROD_FIELD_C30_A,
		   PROD_FIELD_C30_B,
		   PROD_FIELD_C30_C,
		   PROD_CATEGORY,
		   PROD_FORMAT,
		   PROD_GROUP,
		   (SELECT STOR_LEVEL_1 FROM PS_FXD_BIN_LOC_INV WHERE INV_ITEM_ID=@itemId AND BUSINESS_UNIT='TRCN1') AS FPLCANL1,
		   (SELECT STOR_LEVEL_1 FROM PS_FXD_BIN_LOC_INV WHERE INV_ITEM_ID=@itemId AND BUSINESS_UNIT='TRUS1') AS FPLUSL1,
		   (SELECT PRODUCT_GROUP FROM PS_PROD_PGRP_LNK WHERE PRODUCT_ID = @itemId AND SETID = 'SHARE' AND PROD_GRP_TYPE='ACCT') AS ACCT_GRP,
		   (SELECT PRODUCT_GROUP FROM PS_PROD_PGRP_LNK WHERE PRODUCT_ID = @itemId AND SETID = 'SHARE' AND PROD_GRP_TYPE='PRC') AS PRC_GRP,
		   PROD_LINE,
		   PRICE_LIST,
		   (SELECT SOURCE_CODE FROM PS_BU_ITEMS_INV WHERE INV_ITEM_ID = @itemId AND BUSINESS_UNIT='TRUS1') AS MFG_SOURCE,
		   SAT_CODE,
		   UPC_ID,
		   IN_STOCK_DATE,
		   ITEM_KEYWORDS,
		   COPYRIGHT,
		   NEWCATEGORY,
		   CATEGORY,
		   NEW_DATE,
		   LICENSE,
		   ATTRIBUTE_SET,
		   SHORT_DESC,
		   ITEM_WEB_INFO.PROPERTY,
		   PRINT_ON_DEMAND,
		   ACTIVE = 0,
		   (SELECT MFG_SUG_RTL_PRC FROM PS_PROD_PRICE WHERE PRODUCT_ID=@itemId AND SETID = 'SHARE' AND BUSINESS_UNIT_IN='TRUS1' AND UNIT_OF_MEASURE = 'EA' AND CURRENCY_CD='USD' AND EFFDT <> '') AS MSRP1,
		   (SELECT MFG_SUG_RTL_PRC FROM PS_PROD_PRICE WHERE PRODUCT_ID=@itemId AND SETID = 'SHARE' AND BUSINESS_UNIT_IN='TRUS1' AND UNIT_OF_MEASURE = 'EA' AND CURRENCY_CD='CAD' AND EFFDT <> '') AS MSRP2,
		   (SELECT MFG_SUG_RTL_PRC FROM PS_PROD_PRICE WHERE PRODUCT_ID=@itemId AND SETID = 'SHARE' AND BUSINESS_UNIT_IN='TRUS1' AND UNIT_OF_MEASURE = 'EA' AND CURRENCY_CD='MXN' AND EFFDT <> '') AS MSRP3,
		   TITLE,
		   ITEM_WEB_INFO.PROPERTY,
		   META_DESCRIPTION,
		   ITEM_WEB_INFO.SIZE,
		   PROD_QTY,
		   ITEM_WEB_INFO.ON_SITE,
		   AMAZON_ITEM_ATTRIBUTES.ASIN AS A_ASIN,
		   AMAZON_ITEM_ATTRIBUTES.ITEM_NAME AS A_ITEM_NAME,
		   AMAZON_ITEM_ATTRIBUTES.MODEL_NAME AS A_MODEL_NAME,
		   AMAZON_ITEM_ATTRIBUTES.PRODUCT_CATEGORY AS A_PRODUCT_CATEGORY,
		   AMAZON_ITEM_ATTRIBUTES.PRODUCT_SUBCATEGORY AS A_PRODUCT_SUBCATEGORY,
		   AMAZON_ITEM_ATTRIBUTES.BULLET_1 AS A_BULLET_1,
	       AMAZON_ITEM_ATTRIBUTES.BULLET_2 AS A_BULLET_2,
		   AMAZON_ITEM_ATTRIBUTES.BULLET_3 AS A_BULLET_3,
		   AMAZON_ITEM_ATTRIBUTES.BULLET_4 AS A_BULLET_4,
		   AMAZON_ITEM_ATTRIBUTES.BULLET_5 AS A_BULLET_5,
		   AMAZON_ITEM_ATTRIBUTES.FULL_DESCRIPTION AS A_FULL_DESCRIPTION,
		   AMAZON_ITEM_ATTRIBUTES.EXTERNAL_ID_TYPE AS A_EXTERNAL_ID_TYPE,
		   AMAZON_ITEM_ATTRIBUTES.EXTERNAL_ID AS A_EXTERNAL_ID,
		   AMAZON_ITEM_ATTRIBUTES.SEARCH_TERMS AS A_SEARCH_TERMS,
		   AMAZON_ITEM_ATTRIBUTES.IMAGE_URL_1 AS A_IMAGE_URL_1,
		   AMAZON_ITEM_ATTRIBUTES.IMAGE_URL_2 AS A_IMAGE_URL_2,
		   AMAZON_ITEM_ATTRIBUTES.IMAGE_URL_3 AS A_IMAGE_URL_3,
		   AMAZON_ITEM_ATTRIBUTES.IMAGE_URL_4 AS A_IMAGE_URL_4,
		   AMAZON_ITEM_ATTRIBUTES.IMAGE_URL_5 AS A_IMAGE_URL_5,
		   AMAZON_ITEM_ATTRIBUTES.SIZE AS A_SIZE,
		   AMAZON_ITEM_ATTRIBUTES.COST AS A_COST,
		   AMAZON_ITEM_ATTRIBUTES.MSRP AS A_MSRP,
		   AMAZON_ITEM_ATTRIBUTES.MANUFACTURER_NAME AS A_MANUFACTURER_NAME,
		   AMAZON_ITEM_ATTRIBUTES.COUNTRY_OF_ORIGIN AS A_COUNTRY_OF_ORIGIN,
		   AMAZON_ITEM_ATTRIBUTES.LENGTH AS A_LENGTH,
		   AMAZON_ITEM_ATTRIBUTES.HEIGHT AS A_HEIGHT,
		   AMAZON_ITEM_ATTRIBUTES.WIDTH AS A_WIDTH,
		   AMAZON_ITEM_ATTRIBUTES.WEIGHT AS A_WEIGHT,
		   AMAZON_ITEM_ATTRIBUTES.PACKAGE_LENGTH AS A_PACKAGE_LENGTH,
		   AMAZON_ITEM_ATTRIBUTES.PACKAGE_HEIGHT AS A_PACKAGE_HEIGHT,
		   AMAZON_ITEM_ATTRIBUTES.PACKAGE_WIDTH AS A_PACKAGE_WIDTH,
		   AMAZON_ITEM_ATTRIBUTES.PACKAGE_WEIGHT AS A_PACKAGE_WEIGHT,
		   AMAZON_ITEM_ATTRIBUTES.COMPONENTS AS A_COMPONENTS,
		   AMAZON_ITEM_ATTRIBUTES.UPC_OVERRIDE AS A_UPC

	FROM PS_MASTER_ITEM_TBL MASTER_ITEM_TBL
		 INNER JOIN	PS_INV_ITEMS INV_ITEMS
			ON  INV_ITEMS.SETID = 'SHARE'
			AND INV_ITEMS.INV_ITEM_ID = MASTER_ITEM_TBL.INV_ITEM_ID
			AND EFFDT = (SELECT MAX(EFFDT)
						 FROM PS_INV_ITEMS
						 WHERE SETID = 'SHARE'
						   AND INV_ITEM_ID = MASTER_ITEM_TBL.INV_ITEM_ID
						   AND EFFDT <= GETDATE())
		 LEFT OUTER JOIN PS_ITEM_ATTRIB_EX ITEM_ATTRIB_EX
			ON  ITEM_ATTRIB_EX.SETID = 'SHARE'
			AND ITEM_ATTRIB_EX.INV_ITEM_ID = MASTER_ITEM_TBL.INV_ITEM_ID
		 INNER JOIN PS_PROD_ITEM PROD_ITEM
			ON PROD_ITEM.PRODUCT_ID = MASTER_ITEM_TBL.INV_ITEM_ID
			AND PROD_ITEM.SETID = 'SHARE'
		 INNER JOIN PS_BU_ITEMS_INV BU_ITEMS_INV
			ON BU_ITEMS_INV.INV_ITEM_ID = MASTER_ITEM_TBL.INV_ITEM_ID
		 LEFT JOIN PS_ITEM_WEB_INFO ITEM_WEB_INFO
			ON ITEM_WEB_INFO.INV_ITEM_ID = MASTER_ITEM_TBL.INV_ITEM_ID
		 LEFT JOIN PS_PROD_PGRP_LNK PROD_PGRP_LNK
			ON PROD_PGRP_LNK.PRODUCT_ID = MASTER_ITEM_TBL.INV_ITEM_ID
			AND PROD_PGRP_LNK.SETID = 'SHARE'
		 LEFT JOIN PS_PURCH_ITEM_ATTR PURCH_ITEM_ATTR
			ON PURCH_ITEM_ATTR.INV_ITEM_ID = MASTER_ITEM_TBL.INV_ITEM_ID
			AND PURCH_ITEM_ATTR.SETID = 'SHARE'
		 LEFT JOIN PS_FXD_BIN_LOC_INV FXD_BIN_LOC_INV
			ON FXD_BIN_LOC_INV.INV_ITEM_ID = MASTER_ITEM_TBL.INV_ITEM_ID
		 LEFT JOIN PS_AMAZON_ITEM_ATTRIBUTES AMAZON_ITEM_ATTRIBUTES
			ON AMAZON_ITEM_ATTRIBUTES.INV_ITEM_ID = MASTER_ITEM_TBL.INV_ITEM_ID
	WHERE MASTER_ITEM_TBL.SETID = 'SHARE'
	  AND MASTER_ITEM_TBL.INV_ITEM_ID = @itemId
	 
END
GO

GRANT EXECUTE ON Odin_SelectItem TO Odin
GO
/*
SELECT * FROM PS_INV_ITEMS WHERE INV_ITEM_ID ='TEST1'
SELECT SOURCE_CODE FROM PS_BU_ITEMS_INV WHERE INV_ITEM_ID = 'DC653123'
sp_help PS_FXD_BIN_LOC_INV

(SELECT SEND_INVENTORY FROM PS_CUSTOMER_PRODUCT_ATTRIBUTES WHERE PRODUCT_ID = @itemId AND CUST_ID = '000000000020536' AND SETID = 'SHARE') AS SELL_ON_ALLPOSTERS,
		   (SELECT SEND_INVENTORY FROM PS_CUSTOMER_PRODUCT_ATTRIBUTES WHERE PRODUCT_ID = @itemId AND CUST_ID = '000000000125480' AND SETID = 'SHARE') AS SELL_ON_AMAZON,
		   (SELECT SEND_INVENTORY FROM PS_CUSTOMER_PRODUCT_ATTRIBUTES WHERE PRODUCT_ID = @itemId AND CUST_ID = '000000000125904' AND SETID = 'SHARE') AS SELL_ON_FANATICS,
		   (SELECT SEND_INVENTORY FROM PS_CUSTOMER_PRODUCT_ATTRIBUTES WHERE PRODUCT_ID = @itemId AND CUST_ID = '000000000126605' AND SETID = 'SHARE') AS SELL_ON_HAYNEEDLE,
		   (SELECT SEND_INVENTORY FROM PS_CUSTOMER_PRODUCT_ATTRIBUTES WHERE PRODUCT_ID = @itemId AND CUST_ID = '000000000064965' AND SETID = 'SHARE') AS SELL_ON_TARGET,
		   (SELECT SEND_INVENTORY FROM PS_CUSTOMER_PRODUCT_ATTRIBUTES WHERE PRODUCT_ID = @itemId AND CUST_ID = '000000000125921' AND SETID = 'SHARE') AS SELL_ON_WALMART,
		   

*/