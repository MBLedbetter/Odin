/*
SELECT * FROM Odin_UserRoles
*/
DROP PROCEDURE Odin_InsertUserRole
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertUserRole

	@userName varchar(255) = '',
	@userRole varchar(255)=''
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO Odin_UserRoles(
			[UserName],
			[Role]
			)
	VALUES(
			@userName,					--UserName
			@userRole					--Role
			)


END
GO

GRANT EXECUTE ON Odin_InsertUserRole TO Odin
GO