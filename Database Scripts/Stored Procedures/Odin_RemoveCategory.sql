/*
SELECT * FROM Odin_NewWebCategories
*/
DROP PROCEDURE Odin_RemoveCategory
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RemoveCategory

	@category varchar(MAX) = ''
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM Odin_NewWebCategories
	WHERE CATEGORY = @category



END
GO

GRANT EXECUTE ON Odin_RemoveCategory TO Odin
