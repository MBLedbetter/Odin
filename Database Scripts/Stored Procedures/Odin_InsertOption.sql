/*
SELECT * FROM Odin_UserRoles
*/
DROP PROCEDURE Odin_InsertOption
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertOption

	@optionId varchar(255) = '',
	@value varchar(255)=''
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [ODIN_OPTIONS_TABLE](
			[OPTION_ID],
			[VALUE]
			)
	VALUES(
			@optionId,			-- OPTION_ID
			@value				-- VALUE
			)


END
GO

GRANT EXECUTE ON Odin_InsertOption TO Odin
GO