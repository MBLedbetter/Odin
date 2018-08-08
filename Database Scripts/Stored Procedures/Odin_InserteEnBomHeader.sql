
DROP PROCEDURE Odin_InserteEnBomHeader
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InserteEnBomHeader
	@itemId VARCHAR(18)= '',
	@descr VARCHAR(30)= '',
	@descShort VARCHAR(10)= ''

AS
BEGIN

	SET NOCOUNT ON;
	
	IF NOT EXISTS (SELECT * FROM PS_EN_BOM_HEADER 
                   WHERE INV_ITEM_ID = @itemId
				   )
	BEGIN
		
		INSERT INTO PS_EN_BOM_HEADER(
			BUSINESS_UNIT,
			INV_ITEM_ID,
			BOM_STATE,
			BOM_TYPE,
			BOM_CODE,
			BOM_QTY,
			DESCR,
			DESCRSHORT,
			TEXT254
		)
		VALUES(
		    'TRUS1',	-- BUSINESS_UNIT
			@itemId,	-- INV_ITEM_ID
			'PR',		-- BOM_STATE
			'PR',		-- BOM_TYPE
			1,			-- BOM_CODE
			1,			-- BOM_QTY
			@descr,		-- DESCR
			@descShort,	-- DESCRSHORT
			''			-- TEXT254
		)
	END




END
GO

GRANT EXECUTE ON Odin_InserteEnBomHeader TO Odin
GO
/*
SELECT * FROM PS_SF_PRDN_AREA_IT
sp_help PS_SF_PRDN_AREA_IT
*/
