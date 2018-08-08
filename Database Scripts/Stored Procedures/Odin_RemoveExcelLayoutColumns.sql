
DROP PROCEDURE Odin_RemoveExcelLayoutColumns
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RemoveExcelLayoutColumns

	@layoutId VARCHAR(3)

AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM ODIN_EXCEL_LAYOUT_DATA
	WHERE LAYOUT_ID = @layoutId

END
GO

GRANT EXECUTE ON Odin_RemoveExcelLayoutColumns TO Odin
GO