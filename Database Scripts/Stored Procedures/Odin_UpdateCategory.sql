DROP PROCEDURE Odin_UpdateCategory


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_UpdateCategory(
	@category varchar(1000) ='',
	@oldCategory varchar(1000) =''
	)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE Odin_NewWebCategories
	SET
	CATEGORY = @category
	WHERE
		CATEGORY = @oldCategory


END
GO

GRANT EXECUTE ON Odin_UpdateCategory TO Odin
