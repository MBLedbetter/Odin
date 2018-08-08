
DROP PROCEDURE Odin_RetrieveUpcAll
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RetrieveUpcAll
AS
BEGIN

	SET NOCOUNT ON;

	SELECT INV_ITEM_ID, UPC_ID FROM PS_INV_ITEMS
	WHERE UPC_ID <> ''
	AND SETID = 'SHARE'

END
GO

GRANT EXECUTE ON Odin_RetrieveUpcAll TO Odin

/*
sp_help PS_INV_ITEMS
*/