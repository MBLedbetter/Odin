/*
SELECT * FROM Odin_Web_License
sp_help Odin_Web_License
*/
DROP PROCEDURE Odin_RemoveLicense
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RemoveLicense

	@license varchar(MAX) = ''
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM Odin_Web_License
	WHERE LICENSE = @license



END
GO

GRANT EXECUTE ON Odin_RemoveLicense TO Odin
