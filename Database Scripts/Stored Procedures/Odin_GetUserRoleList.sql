
DROP PROCEDURE Odin_GetUserRoleList
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_GetUserRoleList
AS
BEGIN

	SELECT * FROM Odin_UserRoles

END
GO

GRANT EXECUTE ON Odin_GetUserRoleList TO Odin
GO