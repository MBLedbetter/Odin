/*
SELECT * FROM Odin_Web_License
sp_help Odin_Web_License
*/
DROP PROCEDURE Odin_RemoveProperty
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RemoveProperty

	@property varchar(MAX) = ''
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM Odin_Web_License
	WHERE PROPERTY = @property

END
GO

GRANT EXECUTE ON Odin_RemoveProperty TO Odin
