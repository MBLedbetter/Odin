
DROP PROCEDURE Odin_GetWebsiteItemRequests_User
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_GetWebsiteItemRequests_User
		@username VARCHAR(30)=''
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * FROM Odin_WebsiteItemRequests WHERE UserName = @username ORDER BY DttmSubmitted ASC


END
GO

GRANT EXECUTE ON Odin_GetWebsiteItemRequests_User TO Odin