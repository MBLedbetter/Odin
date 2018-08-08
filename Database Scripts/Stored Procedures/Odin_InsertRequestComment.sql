
/*
SELECT * FROM Odin_RequestComments
*/
DROP PROCEDURE Odin_InsertRequestComments
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertRequestComments
	@RequestId VARCHAR(18)='',
	@Comment VARCHAR(MAX) =''
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO Odin_RequestComments(
		RID,
		GroupComment)
	VALUES(
		@RequestId,			--RequestId
		@Comment			--Comment
		)


END
GO

GRANT EXECUTE ON Odin_InsertRequestComments TO Odin
GO