
DROP PROCEDURE Odin_InsertProdPrice
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertProdPrice
	@productGroup varchar(10),
	@productId varchar(18),
	@listPrice decimal(15,4),
	@msrp decimal(15,4),
	@bui varchar(5),
	@ccd varchar(3),
	@userName varchar(30)

AS
BEGIN

	SET NOCOUNT ON;
	
	IF NOT EXISTS (SELECT * FROM PS_PROD_PRICE 
                   WHERE PRODUCT_ID = @productId
                   AND BUSINESS_UNIT_IN = @bui
                   AND CURRENCY_CD = @ccd)
		   BEGIN
			   INSERT INTO PS_PROD_PRICE(
			SETID,
			PRODUCT_ID,
			UNIT_OF_MEASURE,
			BUSINESS_UNIT_IN,
			CURRENCY_CD,
			EFFDT,
			EFF_STATUS,
			LIST_PRICE,
			UNIT_COST,
			SERVICE_COST,
			REPAIR_COST,
			MFG_SUG_RTL_PRC,
			PRICING_FLAG,
			DATETIME_ADDED,
			LASTUPDDTTM,
			LAST_MAINT_OPRID
	)
	VALUES(			
			'SHARE',			--SETID
			@productId,			--PRODUCT_ID
			'EA',				--UNIT_OF_MEASURE
			@bui,				--BUSINESS_UNIT_IN
			@ccd,				--CURRENCY_CD
			'1901-01-01',		--EFFDT
			'A',				--EFF_STATUS
			@listPrice,			--LIST_PRICE
			0.0000,				--UNIT_COST
			0.0000,				--SERVICE_COST
			0.0000,				--REPAIR_COST
			@msrp,				--MFG_SUG_RTL_PRC
			'',					--PRICING_FLAG
			GETDATE(),			--DATETIME_ADDED
			GETDATE(),			--LASTUPDDTTM
			@userName			--LAST_MAINT_OPRID
	)		
		   END

	UPDATE PS_PROD_PRICE
	SET
		LIST_PRICE = @listPrice,
		LASTUPDDTTM = GETDATE(),
		MFG_SUG_RTL_PRC = @msrp,
		LAST_MAINT_OPRID = @userName
	WHERE
		PRODUCT_ID = @productId 
		AND CURRENCY_CD = @ccd
		AND UNIT_OF_MEASURE = 'EA'
		AND BUSINESS_UNIT_IN = @bui
		AND SETID = 'SHARE'

END
GO

GRANT EXECUTE ON Odin_InsertProdPrice TO Odin
GO
/*
SELECT * FROM PS_PROD_PRICE WHERE EFFDT <> '1901-01-01 00:00:00.000'
sp_help PS_PROD_PRICE
*/
