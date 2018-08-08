/*
SELECT * FROM Odin_MetaDescription
sp_help Odin_MetaDescription
*/
DROP PROCEDURE Odin_RemoveMetaDescription
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RemoveMetaDescription

	@metaDescription varchar(MAX) = ''
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM Odin_MetaDescription
	WHERE META_DESCRIPTION = @metaDescription



END
GO

GRANT EXECUTE ON Odin_RemoveMetaDescription TO Odin
