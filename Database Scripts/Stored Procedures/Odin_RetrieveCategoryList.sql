
/*
	SELECT * FROM Odin_NewWebCategories
*/
DROP PROCEDURE Odin_RetrieveCategoryList
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RetrieveCategoryList
AS
BEGIN

	SET NOCOUNT ON;

	SELECT ID, CATEGORY FROM Odin_NewWebCategories


END
GO

GRANT EXECUTE ON Odin_RetrieveCategoryList TO Odin

