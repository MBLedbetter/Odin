/*
SELECT * FROM PS_UOM_TYPE_INV WHERE INV_ITEM_ID = '000000ABD'
SELECT * FROM PS_UOM_TYPE_INV
sp_help PS_UOM_TYPE_INV
*/
DROP PROCEDURE Odin_InsertUomTypeInv


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertUomTypeInv(
	@itemId varchar(18),
	@invUomType varchar(4)
	)
AS
BEGIN

	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT * FROM PS_UOM_TYPE_INV 
                   WHERE INV_ITEM_ID = @itemId
				   )
		   BEGIN

	INSERT INTO PS_UOM_TYPE_INV(
			SETID,
			INV_ITEM_ID,
			UNIT_OF_MEASURE,
			INV_UOM_TYPE
	)
	VALUES(
			'SHARE',	--SETID
			@itemId,	--INV_ITEM_ID
			'EA',		--UNIT_OF_MEASURE
			@invUomType	--INV_UOM_TYPE
	)			
	END	

END
GO

GRANT EXECUTE ON Odin_InsertUomTypeInv TO Odin
GO