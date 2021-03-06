SET ANSI_NULLS ON
GO
--drop table PS_PURCH_ITEM_ATTR
SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [PS_PURCH_ITEM_ATTR](
	[SETID] [char](5) NOT NULL,
	[INV_ITEM_ID] [char](18) NOT NULL,
	[PO_AVAIL_DT] [DATE] NULL,
	[PO_UNAVAIL_DT] [DATE] NULL,
	[DESCR] [char](30) NOT NULL,
	[DESCRSHORT] [char](10) NOT NULL,
	[ACCOUNT] [char](10) NOT NULL,
	[ALTACCT] [char](10) NOT NULL,
	[DEPTID] [char](10) NOT NULL,
	[OPERATING_UNIT] [char](8) NOT NULL,
	[PRODUCT] [char](6) NOT NULL,
	[FUND_CODE] [char](5) NOT NULL,
	[CLASS_FLD] [char](5) NOT NULL,
	[PROGRAM_CODE] [char](5) NOT NULL,
	[BUDGET_REF] [char](8) NOT NULL,
	[AFFILIATE] [char](5) NOT NULL,
	[AFFILIATE_INTRA1] [char](10) NOT NULL,
	[AFFILIATE_INTRA2] [char](10) NOT NULL,
	[CHARTFIELD1] [char](10) NOT NULL,
	[CHARTFIELD2] [char](10) NOT NULL,
	[CHARTFIELD3] [char](10) NOT NULL,
	[PROJECT_ID] [char](15) NOT NULL,
	[PRICE_LIST] [decimal](15, 5) NOT NULL,
	[TAXABLE_CD] [char](1) NOT NULL,
	[AUTO_SOURCE] [char](1) NOT NULL,
	[STD_LEAD] [smallint] NOT NULL,
	[UNIT_PRC_TOL] [decimal](13, 5) NOT NULL,
	[EXT_PRC_TOL] [decimal](13, 5) NOT NULL,
	[PCT_UNIT_PRC_TOL] [decimal](5, 2) NOT NULL,
	[PCT_EXT_PRC_TOL] [decimal](5, 2) NOT NULL,
	[INSPECT_CD] [char](1) NOT NULL,
	[INSPECT_UOM_TYPE] [char](1) NOT NULL,
	[ROUTING_ID] [char](10) NOT NULL,
	[RECV_REQ] [char](1) NOT NULL,
	[QTY_RECV_TOL_PCT] [decimal](5, 2) NOT NULL,
	[RJCT_OVER_TOL_FLAG] [char](1) NOT NULL,
	[RFQ_REQ_FLAG] [char](1) NOT NULL,
	[REJECT_DAYS] [smallint] NOT NULL,
	[PRIMARY_BUYER] [char](30) NOT NULL,
	[MODEL] [char](30) NOT NULL,
	[ACCEPT_ALL_VENDOR] [char](1) NOT NULL,
	[ACCEPT_ALL_SHIPTO] [char](1) NOT NULL,
	[CONTRACT_REQ] [char](1) NOT NULL,
	[DESCR254_MIXED] [char](254) NOT NULL,
	[FILENAME] [char](80) NOT NULL,
	[FILE_EXTENSION] [char](3) NOT NULL,
	[RECV_PARTIAL_FLG] [char](1) NOT NULL,
	[CURRENCY_CD] [char](3) NOT NULL,
	[PCT_UNDER_QTY] [smallint] NOT NULL,
	[STOCKLESS_FLG] [char](1) NOT NULL,
	[INSPECT_SAMPLE_PER] [decimal](5, 2) NOT NULL,
	[VAT_SVC_PERFRM_FLG] [char](1) NOT NULL,
	[LAST_PO_PRICE_PAID] [decimal](15, 5) NOT NULL,
	[SRC_METHOD] [char](1) NOT NULL,
	[LEAD_TIME_IMP] [decimal](5, 2) NOT NULL,
	[PRICE_IMP] [decimal](5, 2) NOT NULL,
	[SHIPTO_PR_IMP] [decimal](5, 2) NOT NULL,
	[VNDR_PR_IMP] [decimal](5, 2) NOT NULL,
	[USE_CAT_SRC_CNTL] [char](1) NOT NULL,
	[UNIT_PRC_TOL_L] [decimal](13, 5) NOT NULL,
	[PCT_UNIT_PRC_TOL_L] [decimal](5, 2) NOT NULL,
	[EXT_PRC_TOL_L] [decimal](13, 5) NOT NULL,
	[PCT_EXT_PRC_TOL_L] [decimal](5, 2) NOT NULL,
	[PACKING_VOLUME] [decimal](15, 4) NOT NULL,
	[PACKING_WEIGHT] [decimal](15, 4) NOT NULL,
	[UNIT_MEASURE_VOL] [char](3) NOT NULL,
	[UNIT_MEASURE_WT] [char](3) NOT NULL,
	[SHIP_LATE_DAYS] [smallint] NOT NULL,
	[SHIP_TYPE_ID] [char](10) NOT NULL,
	[KB_PAST_DUE_PO] [char](1) NOT NULL,
	[KB_OVR_RECV_TOL] [decimal](5, 2) NOT NULL,
	[ULTIMATE_USE_CD] [char](8) NOT NULL,
	[WF_PCT_PRC_TOL_OVR] [decimal](5, 2) NOT NULL,
	[WF_PCT_PRC_TOL_UND] [decimal](5, 2) NOT NULL,
	[WF_PRC_TOL_OVR] [decimal](13, 5) NOT NULL,
	[WF_PRC_TOL_UND] [decimal](13, 5) NOT NULL,
	[AVAIL_ALL_RGNS] [char](1) NOT NULL,
	[OPRID_MODIFIED_BY] [char](30) NOT NULL,
	[LAST_DTTM_UPDATE] [DATETIME] NULL
)
GO

SET ANSI_PADDING OFF
GO

