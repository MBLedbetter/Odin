
DROP PROCEDURE Odin_GetWebCopyrightValue
GO

/* Retrieve web copyright list */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_GetWebCopyrightValue
	@copyright VARCHAR(MAX)=''
AS
BEGIN

	SET NOCOUNT ON;

	SELECT [VALUE] FROM Odin_Web_Copyright
	WHERE COPYRIGHT = @copyright

END
GO

GRANT EXECUTE ON Odin_GetWebCopyrightValue TO Odin
