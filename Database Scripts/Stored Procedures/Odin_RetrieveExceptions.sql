
DROP PROCEDURE Odin_RetrieveExceptions
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RetrieveExceptions
	@field VARCHAR(MAX),
	@exceptionTrigger VARCHAR(MAX),
	@exceptionResult VARCHAR(MAX)
	
AS
BEGIN

	SET NOCOUNT ON;

	SELECT EXCEPTION_VALUE FROM Odin_Item_Exceptions
	WHERE FIELD = @field
		AND EXCEPTION_TRIGGER = @exceptionTrigger
		AND EXCEPTION_RESULT = @exceptionResult

END
GO

GRANT EXECUTE ON Odin_RetrieveExceptions TO Odin