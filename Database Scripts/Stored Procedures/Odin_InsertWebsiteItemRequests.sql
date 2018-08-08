
DROP PROCEDURE Odin_InsertWebsiteItemRequests
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertWebsiteItemRequests(
	@RequestId VARCHAR(18)='',
	@ItemId VARCHAR(18)='',
	@ItemStatus VARCHAR(18)='',
	@UserName VARCHAR(255)='',
	@Comment VARCHAR(MAX) ='',
	@InStockDate DATETIME = NULL,
	@RequestStatus	VARCHAR(18)='')
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO Odin_WebsiteItemRequests(
		RequestId,
		ItemId,
		ItemStatus,
		UserName,
		DttmSubmitted,
		InStockDate,
		Comment,
		RequestStatus)
	VALUES(
		@RequestId,			--RequestId
		@ItemId,			--ItemId
		@ItemStatus,
		@UserName,			--UserName
		GETDATE(),		--DttmSubmitted
		@InStockDate,
		@Comment,			--Comment
		@RequestStatus)		--RequestStatus


END
GO

GRANT EXECUTE ON Odin_InsertWebsiteItemRequests TO Odin
GO