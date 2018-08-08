/*
SELECT * FROM PS_PROD_UOM WHERE PRODUCT_ID = '000000ABD'
SELECT * FROM PS_PROD_UOM
*/
DROP PROCEDURE Odin_InsertProdUom


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertProdUom(
	@productId varchar(18)='',
	@userName varchar(30)
	)
AS
BEGIN

	SET NOCOUNT ON;
	IF NOT EXISTS (SELECT * FROM PS_PROD_UOM 
                   WHERE PRODUCT_ID = @productId
				   )
				   BEGIN
	INSERT INTO PS_PROD_UOM(
			SETID,
			PRODUCT_ID,
			UNIT_OF_MEASURE,
			DFLT_UOM,
			MIN_ORDER_QTY,
			MAX_ORDER_QTY,
			ORDER_INCREMENT,
			DATETIME_ADDED,
			LASTUPDDTTM,
			LAST_MAINT_OPRID
	)
	VALUES(			
			'SHARE',				--SETID
			@productId,				--PRODUCT_ID
			'EA',					--UNIT_OF_MEASURE
			'Y',					--DFLT_UOM
			0.0000,					--MIN_ORDER_QTY
			0.0000,					--MAX_ORDER_QTY
			0.0000,					--ORDER_INCREMENT
			Getdate(),				--DATETIME_ADDED
			Getdate(),				--LASTUPDDTTM
			@userName				--LAST_MAINT_OPRID
	)				
	END


END
GO

GRANT EXECUTE ON Odin_InsertProdUom TO Odin