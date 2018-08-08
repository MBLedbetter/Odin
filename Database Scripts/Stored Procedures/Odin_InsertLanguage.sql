
/*
SELECT * FROM PS_ITEM_LANGUAGE
SELECT * FROM PS_ITEM_TERRITORY
*/
DROP PROCEDURE Odin_InsertLanguage
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertLanguage
	@itemId CHAR(18)='',
	@language VARCHAR(100) =''
AS
BEGIN

	SET NOCOUNT ON;
	
	DELETE FROM PS_ITEM_LANGUAGE WHERE INV_ITEM_ID = @itemId;
	
	INSERT INTO PS_ITEM_LANGUAGE(SETID, INV_ITEM_ID, LANGUAGE_CD) SELECT 'SHARE', @itemId, Value FROM Odin_ListToTable(@language,'/')
	
END
GO

GRANT EXECUTE ON Odin_InsertLanguage TO Odin
GO