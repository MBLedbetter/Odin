SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
--SELECT * FROM Odin_WebsiteItemRequests ORDER BY RequestId Desc
CREATE TABLE Odin_WebsiteItemRequests(
	RequestId INT NOT NULL,
	ItemId varchar(18) NOT NULL,
	ItemStatus varchar(18) NOT NULL,
	UserName varchar(255) NOT NULL,
	DttmSubmitted datetime,
	InStockDate datetime,
	Comment varchar(MAX),
	RequestStatus varchar(16)
)

GO
ALTER TABLE Odin_WebsiteItemRequests add primary key (RequestId, ItemId)

SET ANSI_PADDING OFF
GO

/*
ALTER TABLE [dbo].[Odin_WebsiteItemRequests] ADD [Website] [varchar](266) NULL
*/