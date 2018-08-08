DROP PROCEDURE Odin_RemoveUserRole


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RemoveUserRole(
	@userName varchar(255)='',
	@role varchar(255)=''
	)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM Odin_UserRoles

	WHERE
		UserName = @userName AND
		Role = @role


END
GO

GRANT EXECUTE ON Odin_RemoveUserRole TO Odin
GO