
DROP PROCEDURE Odin_CompareProductFormats_Lines
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_CompareProductFormats_Lines
		@prodGroup VARCHAR(30)='',
		@prodLine VARCHAR(30)=''
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * FROM PS_PRODUCT_LINES
	WHERE UPPER(PROD_GROUP) = UPPER(@prodGroup)
		AND UPPER(PROD_LINE) = UPPER(@prodLine)


END
GO

GRANT EXECUTE ON Odin_CompareProductFormats_Lines TO Odin
