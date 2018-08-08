
DROP PROCEDURE Odin_RetrieveTemplateNames
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RetrieveTemplateNames

AS
BEGIN

	SET NOCOUNT ON;

	SELECT TEMPLATE_ID

	FROM ODIN_ITEM_TEMPLATES
	 

END
GO

GRANT EXECUTE ON Odin_RetrieveTemplateNames TO Odin
GO
/*
*/