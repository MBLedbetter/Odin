
DROP PROCEDURE Odin_GetWebCopyright
GO

/* Retrieve web copyright list */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_GetWebCopyright
AS
BEGIN

	SET NOCOUNT ON;

	SELECT [COPYRIGHT] FROM Odin_Web_Copyright

END
GO

GRANT EXECUTE ON Odin_GetWebCopyright TO Odin
