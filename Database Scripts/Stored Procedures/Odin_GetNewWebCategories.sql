
DROP PROCEDURE Odin_GetNewWebCategories
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_GetNewWebCategories
AS
BEGIN

	SET NOCOUNT ON;

	SELECT [CATEGORY] FROM Odin_NewWebCategories

END
GO

GRANT EXECUTE ON Odin_GetNewWebCategories TO Odin
