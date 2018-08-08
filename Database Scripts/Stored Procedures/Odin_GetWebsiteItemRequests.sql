
DROP PROCEDURE Odin_GetWebsiteItemRequests
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_GetWebsiteItemRequests
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		RequestId,
		ItemId,
		ItemStatus,
		UserName,
		DttmSubmitted,
		InStockDate,
		Comment,
		RequestStatus,
		GroupComment
	FROM Odin_WebsiteItemRequests OWIR
		 LEFT JOIN	Odin_RequestComments ORC
			ON  OWIR.RequestId = ORC.RID
			ORDER BY RequestId DESC


END
GO

GRANT EXECUTE ON Odin_GetWebsiteItemRequests TO Odin
