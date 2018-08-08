/*
SELECT * FROM PS_BU_ITEMS_INV ORDER BY INV_ITEM_ID ASC
*/

DROP PROCEDURE Odin_UpdateBuItemsInv


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_UpdateBuItemsInv(
	@businessUnit varchar(5)='',
	@itemId varchar(18) ='',
	@COO varchar(3)='',
	@mfg varchar(2)='',
	@dac varchar(9)=''
	)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE PS_BU_ITEMS_INV
	SET
		COUNTRY_IST_ORIGIN = @COO,
		SOURCE_CODE = @mfg,
		CURRENT_COST = @dac,
		DFLT_ACTUAL_COST = @dac

	WHERE
		INV_ITEM_ID = @itemId and BUSINESS_UNIT = @businessUnit


END
GO

GRANT EXECUTE ON Odin_UpdateBuItemsInv TO Odin
