SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PS_ITEM_MFG](
	[SETID] [char](5) NOT NULL,
	[INV_ITEM_ID] [char](18) NOT NULL,
	[MFG_ID] [char](50) NOT NULL,
	[MFG_ITM_ID] [char](50) NOT NULL,
	[PREFERRED_MFG] [char](1) NOT NULL
)

GO

SET ANSI_PADDING OFF
GO

