SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PS_PROD_PGRP_LNK](
	[SETID] [char](5) NOT NULL,
	[PRODUCT_ID] [char](18) NOT NULL,
	[PROD_GRP_TYPE] [char](4) NOT NULL,
	[PRODUCT_GROUP] [char](10) NOT NULL,
	[PRIMARY_FLAG] [char](1) NOT NULL,
	[PRIM_PRC_FLAG] [char](1) NOT NULL,
	[DATETIME_ADDED] [dbo].[PSDATETIME] NULL,
	[LASTUPDDTTM] [dbo].[PSDATETIME] NULL,
	[LAST_MAINT_OPRID] [char](30) NOT NULL
)

GO

SET ANSI_PADDING OFF
GO

