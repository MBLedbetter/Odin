
DROP PROCEDURE Odin_InsertInvItems
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertInvItems
	@harmonizedCd varchar(14) = '',
	@itemColor varchar(10)='',
	@itemHeight decimal(15,4),
	@itemLength decimal(15,4),
	@itemWeight decimal(15,4),
	@itemWidth decimal(15,4),
	@upc varchar(18) = '',
	@description varchar(254) ='',
	@itemId varchar(18)='',
	@userName varchar(30)

AS
BEGIN

	SET NOCOUNT ON;
	
	IF NOT EXISTS (SELECT * FROM PS_INV_ITEMS 
                   WHERE INV_ITEM_ID = @itemId)
		   BEGIN
			   INSERT INTO PS_INV_ITEMS(
			AVAIL_LEAD_TIME,
			AVAIL_STATUS,
			CHARGE_CODE,
			CHARGE_MARKUP_AMT,
			CHARGE_MARKUP_PCNT,
			COMMODITY_CD,
			COMMODITY_CD_EU,
			CONSUMABLE_FLG,
			CURRENCY_CD,
			DESCR254,
			DISPOSABLE_FLAG,
			EFFDT,
			HARMONIZED_CD,
			HAZ_CLASS_CD,
			INTL_HAZARD_ID,
			INV_ITEM_COLOR,
			INV_ITEM_HEIGHT,
			INV_ITEM_ID,
			INV_ITEM_LENGTH,
			INV_ITEM_SIZE,
			INV_ITEM_TEMPLATE,
			INV_ITEM_TYPE,
			INV_ITEM_VOLUME,
			INV_ITEM_WEIGHT,
			INV_ITEM_WIDTH,
			INV_PROD_GRADE,
			INV_STOCK_TYPE,
			LAST_DTTM_UPDATE,
			LAST_MAINT_OPRID,
			MAX_CAPACITY,
			MSDS_ID,
			PACKING_CD,
			POTENCY_RATING,
			RECOM_HUMIDITY_PCT,
			RECOM_STOR_TEMP,
			RECYCLE_FLAG,
			RETEST_LEAD_TIME,
			RETURNABLE_FLG,
			REUSABLE_FLAG,
			SERVICE_EXCH_AMT,
			SERVICE_PRICE,
			SERVICEABLE_FLG,
			SETID,
			SHELF_LIFE,
			SHIP_TYPE_ID,
			STOR_RULES_ID,
			UNIT_MEASURE_DIM,
			UNIT_MEASURE_TEMP,
			UNIT_MEASURE_VOL,
			UNIT_MEASURE_WT,
			UPC_ID
			)
	VALUES(
			0,					--AVAIL_LEAD_TIME
			'',					--AVAIL_STATUS
			'',					--CHARGE_CODE
			0,					--CHARGE_MARKUP_AMT
			0,					--CHARGE_MARKUP_PCNT
			'',					--COMMODITY_CD
			'',					--COMMODITY_CD_EU
			'N',				--CONSUMABLE_FLG
			'',					--CURRENCY_CD
			@description,		--DESCR254
			'N',				--DISPOSABLE_FLAG
			'1901-01-01',		--EFFDT
			@harmonizedCd,		--HARMONIZED_CD
			'',					--HAZ_CLASS_CD
			'',					--INTL_HAZARD_ID
			@itemColor,			--INV_ITEM_COLOR
			@itemHeight,		--INV_ITEM_HEIGHT
			@itemId,			--INV_ITEM_ID
			@itemLength,		--INV_ITEM_LENGTH
			'',					--INV_ITEM_SIZE
			'',					--INV_ITEM_TEMPLATE
			'',					--INV_ITEM_TYPE
			0,					--INV_ITEM_VOLUME
			@itemWeight,		--INV_ITEM_WEIGHT
			@itemWidth,			--INV_ITEM_WIDTH
			'',					--INV_PROD_GRADE
			'',					--INV_STOCK_TYPE
			GETDATE(),			--LAST_DTTM_UPDATE
			@userName,			--LAST_MAINT_OPRID
			0,					--MAX_CAPACITY
			'',					--MSDS_ID
			'',					--PACKING_CD
			'',					--POTENCY_RATING
			0,					--RECOM_HUMIDITY_PCT
			0,					--RECOM_STOR_TEMP
			'N',				--RECYCLE_FLAG
			0,					--RETEST_LEAD_TIME
			'N',				--RETURNABLE_FLG
			'N',				--REUSABLE_FLAG
			0,					--SERVICE_EXCH_AMT
			0,					--SERVICE_PRICE
			'N',				--SERVICEABLE_FLG
			'SHARE',			--SETID
			0,					--SHELF_LIFE
			'',					--SHIP_TYPE_ID
			'',					--STOR_RULES_ID
			'IN',				--UNIT_MEASURE_DIM
			'',					--UNIT_MEASURE_TEMP
			'',					--UNIT_MEASURE_VOL
			'LB',				--UNIT_MEASURE_WT
			@upc				--UPC_ID

			)
		   END

	UPDATE PS_INV_ITEMS
	SET
		HARMONIZED_CD = @harmonizedCd,
		INV_ITEM_COLOR = @itemColor,
		INV_ITEM_HEIGHT = @itemHeight,
		INV_ITEM_LENGTH = @itemLength,
		INV_ITEM_WEIGHT = @itemWeight,
		DESCR254 = @description,
		INV_ITEM_WIDTH = @itemWidth,
		LAST_MAINT_OPRID = @userName,
		LAST_DTTM_UPDATE = GETDATE(),
		UPC_ID = @upc
	WHERE
		INV_ITEM_ID = @itemId
		AND SETID = 'SHARE'
END
GO

GRANT EXECUTE ON Odin_InsertInvItems TO Odin
GO
/*
SELECT * FROM PS_INV_ITEMS
sp_help PS_INV_ITEMS
*/
