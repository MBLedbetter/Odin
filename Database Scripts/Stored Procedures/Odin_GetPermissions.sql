
DROP PROCEDURE Odin_GetPermissions
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_GetPermissions
		@userName VARCHAR(255) = ''
AS
BEGIN

	DECLARE @role AS VARCHAR(255)

	SET NOCOUNT ON;
	SELECT @role = Role
		FROM Odin_UserRoles 
		WHERE UserName = @userName


	SELECT Permission FROM Odin_RolePermissions WHERE [Role] = @role

END
GO

GRANT EXECUTE ON Odin_GetPermissions TO Odin
GO