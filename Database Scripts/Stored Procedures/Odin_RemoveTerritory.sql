/*
SELECT * FROM Odin_Web_Territories
sp_help Odin_Web_Territories
*/
DROP PROCEDURE Odin_RemoveTerritory
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RemoveTerritory

	@territory varchar(MAX) = ''
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM Odin_Web_Territories
	WHERE TERRITORY = @territory

END
GO

GRANT EXECUTE ON Odin_RemoveTerritory TO Odin
