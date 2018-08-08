
DROP PROCEDURE Odin_RetrieveCategoryMap
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RetrieveCategoryMap
		@categoryid VARCHAR(1000) = ''
AS
BEGIN

	SET NOCOUNT ON;

	SELECT CategoryMap FROM Odin_CategoryList WHERE CategoryId = @categoryid


END
GO

GRANT EXECUTE ON Odin_RetrieveCategoryMap TO Odin
