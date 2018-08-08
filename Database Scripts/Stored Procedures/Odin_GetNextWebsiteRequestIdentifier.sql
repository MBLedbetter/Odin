DROP PROCEDURE Odin_GetNextWebsiteIdentifier
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_GetNextWebsiteIdentifier
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT NextAutoNumber FROM Odin_AutoNumberControlTable (UPDLOCK)
	UPDATE Odin_AutoNumberControlTable SET NextAutoNumber = NextAutoNumber + 1
	WHERE Identifier = 'WebSiteIdentifier';
	
END
GO

GRANT EXECUTE ON Odin_GetNextWebsiteIdentifier TO Odin