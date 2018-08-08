
/*
sp_help Odin_Web_Territories
SELECT * FROM Odin_Web_Territories
*/

DROP PROCEDURE Odin_InsertWebTerritory
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertWebTerritory
	@territory VARCHAR(40) =''
AS
BEGIN

	SET NOCOUNT ON;

	
	INSERT INTO Odin_Web_Territories(TERRITORY) VALUES (@territory)

END
GO

GRANT EXECUTE ON Odin_InsertWebTerritory TO Odin
GO
