
DROP PROCEDURE Odin_GetNewWebCategoryMatch
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_GetNewWebCategoryMatch
		@category VARCHAR(250) = ''
AS
BEGIN
	
	DECLARE @oldId AS INT
	SET NOCOUNT ON;

	SET @oldId = (SELECT m.ID FROM Odin_WebCategories m WHERE m.CATEGORY = @category)

	SELECT CATEGORY FROM Odin_NewWebCategories WHERE OLD_ID = @oldId

END
GO

GRANT EXECUTE ON Odin_GetNewWebCategoryMatch TO Odin
