
/****** Object:  Table [dbo].[PS_MASTER_ITEM_TBL]    Script Date: 11/25/2013 2:06:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PS_MASTER_ITEM_TBL](
	[SETID] [char](5) NOT NULL,
	[INV_ITEM_ID] [char](18) NOT NULL,
	[ITM_STATUS_EFFDT] [dbo].[PSDATE] NULL,
	[ITM_STATUS_CURRENT] [char](1) NOT NULL,
	[ITM_STAT_DT_FUTURE] [dbo].[PSDATE] NULL,
	[ITM_STATUS_FUTURE] [char](1) NOT NULL,
	[DESCR] [char](30) NOT NULL,
	[DESCR60] [char](60) NOT NULL,
	[DESCRSHORT] [char](10) NOT NULL,
	[UNIT_MEASURE_STD] [char](3) NOT NULL,
	[INV_ITEM_GROUP] [char](15) NOT NULL,
	[INV_PROD_FAM_CD] [char](10) NOT NULL,
	[CATEGORY_ID] [char](5) NOT NULL,
	[DATE_ADDED] [dbo].[PSDATE] NULL,
	[ORIG_OPRID] [char](30) NOT NULL,
	[APPROVAL_OPRID] [char](30) NOT NULL,
	[APPROVAL_DATE] [dbo].[PSDATE] NULL,
	[LAST_MAINT_OPRID] [char](30) NOT NULL,
	[LAST_DTTM_UPDATE] [dbo].[PSDATETIME] NULL,
	[CHANGE_FIELD] [char](18) NOT NULL,
	[INVENTORY_ITEM] [char](1) NOT NULL,
	[LOT_CONTROL] [char](1) NOT NULL,
	[SERIAL_CONTROL] [char](1) NOT NULL,
	[SHIP_SERIAL_CNTRL] [char](1) NOT NULL,
	[NON_OWN_FLAG] [char](1) NOT NULL,
	[APPROV_REQUIRED] [char](1) NOT NULL,
	[APPROV_SUBMITTED] [char](1) NOT NULL,
	[DENIAL_REASON] [char](250) NOT NULL,
	[STAGED_DATE_FLAG] [char](1) NOT NULL,
	[DIST_CFG_FLAG] [char](1) NOT NULL,
	[PRDN_CFG_FLAG] [char](1) NOT NULL,
	[CFG_CODE_OPT] [char](1) NOT NULL,
	[CFG_COST_OPT] [char](1) NOT NULL,
	[CFG_LOT_OPT] [char](1) NOT NULL,
	[CP_TEMPLATE_ID] [char](10) NOT NULL,
	[CP_TREE_DIST] [char](18) NOT NULL,
	[CP_TREE_PRDN] [char](18) NOT NULL,
	[CM_GROUP] [char](15) NOT NULL,
	[MATERIAL_RECON_FLG] [char](1) NOT NULL,
	[USG_TRCKNG_METHOD] [char](2) NOT NULL,
	[CONSIGNED_FLAG] [char](1) NOT NULL,
	[PL_PRIO_FAMILY] [char](10) NOT NULL,
	[ITEM_FIELD_C30_A] [char](30) NOT NULL,
	[ITEM_FIELD_C30_B] [char](30) NOT NULL,
	[ITEM_FIELD_C30_C] [char](30) NOT NULL,
	[ITEM_FIELD_C30_D] [char](30) NOT NULL,
	[ITEM_FIELD_C1_A] [char](1) NOT NULL,
	[ITEM_FIELD_C1_B] [char](1) NOT NULL,
	[ITEM_FIELD_C1_C] [char](1) NOT NULL,
	[ITEM_FIELD_C1_D] [char](1) NOT NULL,
	[ITEM_FIELD_C10_A] [char](10) NOT NULL,
	[ITEM_FIELD_C10_B] [char](10) NOT NULL,
	[ITEM_FIELD_C10_C] [char](10) NOT NULL,
	[ITEM_FIELD_C10_D] [char](10) NOT NULL,
	[ITEM_FIELD_C2] [char](2) NOT NULL,
	[ITEM_FIELD_C4] [char](4) NOT NULL,
	[ITEM_FIELD_C6] [char](6) NOT NULL,
	[ITEM_FIELD_C8] [char](8) NOT NULL,
	[ITEM_FIELD_N12_A] [decimal](15, 3) NOT NULL,
	[ITEM_FIELD_N12_B] [decimal](15, 3) NOT NULL,
	[ITEM_FIELD_N12_C] [decimal](15, 3) NOT NULL,
	[ITEM_FIELD_N12_D] [decimal](15, 3) NOT NULL,
	[ITEM_FIELD_N15_A] [decimal](15, 0) NOT NULL,
	[ITEM_FIELD_N15_B] [decimal](15, 0) NOT NULL,
	[ITEM_FIELD_N15_C] [decimal](15, 0) NOT NULL,
	[ITEM_FIELD_N15_D] [decimal](15, 0) NOT NULL,
	[PROMISE_OPTION] [char](1) NOT NULL,
	[DEVICE_TRACKING] [char](1) NOT NULL,
	[SERIAL_IN_PRDN] [char](1) NOT NULL,
	[TRACE_USAGE] [char](1) NOT NULL,
	[TRACE_CHANGE] [char](1) NOT NULL,
	[PHYSICAL_NATURE] [char](1) NOT NULL
)

GO

CREATE UNIQUE CLUSTERED INDEX IDX_MASTER_ITEM_TBL
	on PS_MASTER_ITEM_TBL(SETID, INV_ITEM_ID);

SET ANSI_PADDING OFF
GO

