DROP PROCEDURE Odin_UpdateUserRole


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_UpdateUserRole(
	@userName varchar(255)='',
	@role varchar(255)=''
	)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE Odin_UserRoles
	SET
	[Role] = @role

	WHERE
		UserName = @userName


END
GO

GRANT EXECUTE ON Odin_UpdateUserRole TO Odin
GO
