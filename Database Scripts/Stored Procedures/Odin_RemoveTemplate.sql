/*
*/
DROP PROCEDURE Odin_RemoveTemplate
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RemoveTemplate

	@templateId varchar(255) = ''
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM ODIN_ITEM_TEMPLATES
	WHERE TEMPLATE_ID = @templateId
	
END
GO

GRANT EXECUTE ON Odin_RemoveTemplate TO Odin
