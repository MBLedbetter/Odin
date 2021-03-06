SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PS_DEFAULT_LOC_INV](
	[BUSINESS_UNIT] [char](5) NOT NULL,
	[INV_ITEM_ID] [char](18) NOT NULL,
	[DEF_LOC_TYPE] [char](1) NOT NULL,
	[STORAGE_AREA] [char](5) NOT NULL,
	[STOR_LEVEL_1] [char](4) NOT NULL,
	[STOR_LEVEL_2] [char](4) NOT NULL,
	[STOR_LEVEL_3] [char](4) NOT NULL,
	[STOR_LEVEL_4] [char](4) NOT NULL
)

GO

SET ANSI_PADDING OFF
GO

