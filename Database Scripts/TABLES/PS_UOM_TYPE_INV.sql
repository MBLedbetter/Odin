SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PS_UOM_TYPE_INV](
	[SETID] [char](5) NOT NULL,
	[INV_ITEM_ID] [char](18) NOT NULL,
	[UNIT_OF_MEASURE] [char](3) NOT NULL,
	[INV_UOM_TYPE] [char](4) NOT NULL
)

GO

SET ANSI_PADDING OFF
GO

