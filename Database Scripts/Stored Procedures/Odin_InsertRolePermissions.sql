/*
SELECT * FROM Odin_UserRoles
*/
DROP PROCEDURE Odin_InsertRolePermissions
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertRolePermissions

	@permission varchar(255) = '',
	@role varchar(255)=''
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [Odin_RolePermissions](
			[Role],
			[Permission]
			)
	VALUES(
			@role,					--Role
			@permission				--Permission
			)


END
GO

GRANT EXECUTE ON Odin_InsertRolePermissions TO Odin
GO