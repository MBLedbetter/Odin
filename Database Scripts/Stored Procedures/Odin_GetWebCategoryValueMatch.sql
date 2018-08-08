
/*
SELECT * FROM Odin_WebCategories
*/
DROP PROCEDURE Odin_GetWebCategoryValueMatch
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_GetWebCategoryValueMatch
		@categoryId VARCHAR(250) = ''
AS
BEGIN

	SET NOCOUNT ON;

	SELECT CATEGORY FROM Odin_NewWebCategories
	WHERE ID = @categoryId


END
GO

GRANT EXECUTE ON Odin_GetWebCategoryValueMatch TO Odin

