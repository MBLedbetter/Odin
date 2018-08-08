/*
SELECT * FROM PS_ITEM_MFG
*/
DROP PROCEDURE Odin_InsertItemMfg


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertItemMfg(
	@itemId varchar(18)
	)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO PS_ITEM_MFG(
			SETID,
			INV_ITEM_ID,
			MFG_ID,
			MFG_ITM_ID,
			PREFERRED_MFG
			)
	VALUES(
		'SHARE',	--SETID
		@itemId,	--INV_ITEM_ID
		'',			--MFG_ID
		'',			--MFG_ITM_ID
		''			--PREFERRED_MFG
	)				


END
GO

GRANT EXECUTE ON Odin_InsertItemMfg TO Odin
GO