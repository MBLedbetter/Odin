
DROP PROCEDURE Odin_RetrieveCategoryId
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RetrieveCategoryId
		@category VARCHAR(1000) = ''
AS
BEGIN

	SET NOCOUNT ON;

	SELECT CategoryId FROM Odin_CategoryList WHERE CategoryMap = @category


END
GO

GRANT EXECUTE ON Odin_RetrieveCategoryId TO Odin
