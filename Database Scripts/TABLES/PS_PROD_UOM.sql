SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PS_PROD_UOM](
	[SETID] [char](5) NOT NULL,
	[PRODUCT_ID] [char](18) NOT NULL,
	[UNIT_OF_MEASURE] [char](3) NOT NULL,
	[DFLT_UOM] [char](1) NOT NULL,
	[MIN_ORDER_QTY] [decimal](14, 4) NOT NULL,
	[MAX_ORDER_QTY] [decimal](14, 4) NOT NULL,
	[ORDER_INCREMENT] [decimal](14, 4) NOT NULL,
	[DATETIME_ADDED] [dbo].[PSDATETIME] NULL,
	[LASTUPDDTTM] [dbo].[PSDATETIME] NULL,
	[LAST_MAINT_OPRID] [char](30) NOT NULL
)
GO

SET ANSI_PADDING OFF
GO

