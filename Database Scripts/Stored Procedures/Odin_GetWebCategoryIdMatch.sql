
/*
SELECT * FROM Odin_WebCategories
*/
DROP PROCEDURE Odin_GetWebCategoryIdMatch
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_GetWebCategoryIdMatch
		@categoryValue VARCHAR(250) = ''
AS
BEGIN

	SET NOCOUNT ON;

	SELECT ID FROM Odin_NewWebCategories
	WHERE UPPER(CATEGORY) = UPPER(@categoryValue)


END
GO

GRANT EXECUTE ON Odin_GetWebCategoryIdMatch TO Odin

