
DROP PROCEDURE Odin_CompareCategory
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_CompareCategory
		@category VARCHAR(1000) = ''
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * FROM Odin_CategoryList
	WHERE Upper(CategoryMap) = Upper(@category) OR
	Upper(Alias1) = Upper(@category) OR
	Upper(Alias2) = Upper(@category) OR
	Upper(Alias3) = Upper(@category) OR
	Upper(Alias4) = Upper(@category) OR
	Upper(Alias5) = Upper(@category)


END
GO

GRANT EXECUTE ON Odin_CompareCategory TO Odin