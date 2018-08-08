
DROP PROCEDURE Odin_CompareProductFormats_Formats
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_CompareProductFormats_Formats
		@prodGroup VARCHAR(30)='',
		@prodLine VARCHAR(30)='',
		@prodFormat VARCHAR(60)=''
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT * FROM PS_PRODUCT_FORMATS
	WHERE UPPER(PROD_GROUP) = UPPER(@prodGroup)
		AND UPPER(PROD_FORMAT) = UPPER(@prodFormat)
		AND UPPER(PROD_LINE) = UPPER(@prodLine)


END
GO

GRANT EXECUTE ON Odin_CompareProductFormats_Formats TO Odin
