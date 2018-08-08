
DROP PROCEDURE Odin_CompareProductFormats
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_CompareProductFormats
		@prodGroup VARCHAR(30)='',
		@prodLine VARCHAR(30)='',
		@prodFormat VARCHAR(60)=''
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * FROM PS_PRODUCT_FORMATS
	WHERE PROD_GROUP = @prodGroup
		AND PROD_FORMAT = @prodFormat
		AND PROD_LINE = @prodLine


END
GO

GRANT EXECUTE ON Odin_CompareProductFormats TO Odin
