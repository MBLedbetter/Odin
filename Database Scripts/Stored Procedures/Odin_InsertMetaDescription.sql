
/*
sp_help Odin_MetaDescription
SELECT * FROM Odin_MetaDescription
*/

DROP PROCEDURE Odin_InsertMetaDescription
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertMetaDescription
	@metaDescription VARCHAR(100) =''

AS
BEGIN

	SET NOCOUNT ON;
	
	INSERT INTO Odin_MetaDescription(META_DESCRIPTION) VALUES (@metaDescription)

END
GO

GRANT EXECUTE ON Odin_InsertMetaDescription TO Odin
GO
