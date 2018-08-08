
DROP PROCEDURE Odin_GetWebsiteItemRequestList
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_GetWebsiteItemRequestList(
	@requestId int)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * FROM Odin_WebsiteItemRequests
	WHERE RequestId = @requestId


END
GO

GRANT EXECUTE ON Odin_GetWebsiteItemRequestList TO Odin