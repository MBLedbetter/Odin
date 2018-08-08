DROP PROCEDURE Odin_InsertProdPriceBu

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertProdPriceBu(
	@productId varchar(18),
	@bui varchar(5),
	@ccd varchar(3),
	@userName varchar(30)
	)
AS
BEGIN

	SET NOCOUNT ON;
	IF NOT EXISTS (SELECT * FROM PS_PROD_PRICE_BU 
                   WHERE PRODUCT_ID = @productId
                   AND BUSINESS_UNIT_IN = @bui
                   AND CURRENCY_CD = @ccd)
					   BEGIN
						   INSERT INTO PS_PROD_PRICE_BU(
								SETID,
								PRODUCT_ID,
								UNIT_OF_MEASURE,
								BUSINESS_UNIT_IN,
								CURRENCY_CD,
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
								GETDATE(),			--DATETIME_ADDED
								GETDATE(),			--LASTUPDDTTM
								@userName			--LAST_MAINT_OPRID
						)			
					   END

END
GO

GRANT EXECUTE ON Odin_InsertProdPriceBu TO Odin

/*
SELECT * FROM PS_PROD_PRICE_BU
*/