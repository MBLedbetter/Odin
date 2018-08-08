DROP PROCEDURE Odin_RemoveRolePermisions


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RemoveRolePermisions(
	@permission varchar(255)='',
	@role varchar(255)=''
	)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM Odin_RolePermissions

	WHERE
		Permission = @permission AND
		[Role] = @role


END
GO

GRANT EXECUTE ON Odin_RemoveRolePermisions TO Odin
GO