
/*
sp_help Odin_Web_License
SELECT * FROM Odin_Web_License
*/

DROP PROCEDURE Odin_InsertLicense
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertLicense
	@property VARCHAR(100) ='',
	@license VARCHAR(100) = ''

AS
BEGIN

	SET NOCOUNT ON;
	
	INSERT INTO Odin_Web_License(LICENSE, PROPERTY) VALUES (@license, @property)

END
GO

GRANT EXECUTE ON Odin_InsertLicense TO Odin
GO
