
DROP PROCEDURE Odin_GetWebLicense
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_GetWebLicense
AS
BEGIN

	SET NOCOUNT ON;

	SELECT DISTINCT [LICENSE] FROM Odin_Web_License

END
GO

GRANT EXECUTE ON Odin_GetWebLicense TO Odin
