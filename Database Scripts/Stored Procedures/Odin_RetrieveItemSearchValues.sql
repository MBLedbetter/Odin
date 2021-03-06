
DROP PROCEDURE Odin_RetrieveItemSearchValues
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RetrieveItemSearchValues
	@value varchar(254) = ''

AS
BEGIN

	SET NOCOUNT ON;
	SELECT INV_ITEM_ID, DESCR254 FROM PS_INV_ITEMS WHERE INV_ITEM_ID LIKE '%'+@value+'%' OR DESCR254 LIKE '%'+@value+'%'
	
END
GO

GRANT EXECUTE ON Odin_RetrieveItemSearchValues TO Odin
GO
/*
SELECT * FROM PS_PROD_PRICE
*/
