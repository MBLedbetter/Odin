
/*
SELECT * FROM PS_MARKETPLACE_PRODUCT_TRANSLATIONS
sp_help PS_MARKETPLACE_PRODUCT_TRANSLATIONS
*/
DROP PROCEDURE Odin_GetProductIdTranslations
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_GetProductIdTranslations
		@itemId VARCHAR(18) = ''
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * FROM PS_MARKETPLACE_PRODUCT_TRANSLATIONS
	WHERE FROM_PRODUCT_ID = @itemId


END
GO

GRANT EXECUTE ON Odin_GetProductIdTranslations TO Odin
