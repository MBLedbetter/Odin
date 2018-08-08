
DROP PROCEDURE Odin_InsertFxdBinLocInv
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertFxdBinLocInv
	@itemId varchar(18)='',
	@busUnit varchar(5)='',
	@fpll1 varchar(4)='0'

AS
BEGIN

	SET NOCOUNT ON;
	
	IF NOT EXISTS (SELECT * FROM PS_FXD_BIN_LOC_INV 
                   WHERE INV_ITEM_ID = @itemId
                   AND BUSINESS_UNIT = @busUnit
				   )
		   BEGIN
			   INSERT INTO PS_FXD_BIN_LOC_INV(
		BUSINESS_UNIT,
		INV_ITEM_ID,
		STORAGE_AREA,
		STOR_LEVEL_1,
		STOR_LEVEL_2,
		STOR_LEVEL_3,
		STOR_LEVEL_4,
		QTY_OPTIMAL,
		UNIT_OF_MEASURE,
		PICKING_ORDER
	)
	VALUES(
		@busUnit,		--BUSINESS_UNIT
		@itemId,		--INV_ITEM_ID
		'PICK',			--STORAGE_AREA
		@fpll1,			--STOR_LEVEL_1
		'0',			--STOR_LEVEL_2
		'',				--STOR_LEVEL_3
		'',				--STOR_LEVEL_4
		0.0000,			--QTY_OPTIMAL
		'EA',			--UNIT_OF_MEASURE
		1				--PICKING_ORDER
	)		
	END




END
GO

GRANT EXECUTE ON Odin_InsertFxdBinLocInv TO Odin
GO