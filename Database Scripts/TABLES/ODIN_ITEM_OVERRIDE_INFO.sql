
/****** Object:  Table [dbo].[ODIN_ITEM_OVERRIDE_INFO]    Script Date: 4/5/2017 1:51:17 PM ******/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ODIN_ITEM_OVERRIDE_INFO](
	[INV_ITEM_ID] [varchar](18) NOT NULL,
	[ITEM_KEYWORDS] [varchar](max) NOT NULL,
	[TITLE] [varchar](266) NULL,
	[WEBSITE_PRICE] [varchar](25) NULL
)
SET ANSI_PADDING OFF
GO

SET ANSI_PADDING OFF
GO

/*
SELECT * FROM [ODIN_ITEM_OVERRIDE_INFO]
*/