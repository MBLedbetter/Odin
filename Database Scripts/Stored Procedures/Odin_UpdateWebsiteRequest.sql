
DROP PROCEDURE Odin_UpdateWebsiteRequest


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_UpdateWebsiteRequest(
	@RequestId int,
	@ItemId VARCHAR(18)='',
	@Comment VARCHAR(MAX) ='',
	@RequestStatus	VARCHAR(18)='')
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE Odin_WebsiteItemRequests
	SET
		Comment = @Comment,
		RequestStatus = @RequestStatus
	WHERE
		ItemId = @ItemId AND RequestId = @RequestId


END
GO

GRANT EXECUTE ON Odin_UpdateWebsiteRequest TO Odin