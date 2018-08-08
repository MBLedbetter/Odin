
DROP PROCEDURE Odin_SelectWebsiteRequest


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_SelectWebsiteRequest(
	@RequestId int
	)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * FROM Odin_WebsiteItemRequests
		WHERE RequestId = @RequestId


END
GO

GRANT EXECUTE ON Odin_SelectWebsiteRequest TO Odin
