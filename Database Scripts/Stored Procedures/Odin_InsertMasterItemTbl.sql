
DROP PROCEDURE Odin_InsertMasterItemTbl
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertMasterItemTbl
		@itemCategory VARCHAR(15)='',
		@cmGroup VARCHAR(15) ='',
		@description VARCHAR(60)='',
		@itemGroup VARCHAR(15)='',
		@itemId VARCHAR(18)='',
		@desc10 VARCHAR(10)='',
		@desc30 VARCHAR(30)='',
		@psStatus VARCHAR(2) = '',
		@itemFamily VARCHAR(10) = '',
		@userName VARCHAR(30)

AS
BEGIN
	DECLARE @categoryID AS VARCHAR(5)

	SET NOCOUNT ON;

	SELECT @categoryID = CATEGORY_ID
		FROM PS_ITM_CAT_TBL 
		WHERE CATEGORY_CD = @itemCategory

	IF NOT EXISTS (SELECT * FROM PS_MASTER_ITEM_TBL 
                   WHERE INV_ITEM_ID = @itemId)
		   BEGIN
			   INSERT INTO PS_MASTER_ITEM_TBL(
		APPROV_REQUIRED,
		APPROV_SUBMITTED,
		APPROVAL_DATE,
		APPROVAL_OPRID,
		CATEGORY_ID,
		CFG_CODE_OPT,
		CFG_COST_OPT,
		CFG_LOT_OPT,
		CHANGE_FIELD,
		CM_GROUP,
		CONSIGNED_FLAG,
		CP_TEMPLATE_ID,
		CP_TREE_DIST,
		CP_TREE_PRDN,
		DATE_ADDED,
		DENIAL_REASON,
		DESCR,
		DESCR60,
		DESCRSHORT,
		DEVICE_TRACKING,
		DIST_CFG_FLAG,
		INV_ITEM_GROUP,
		INV_ITEM_ID,
		INV_PROD_FAM_CD,
		INVENTORY_ITEM,
		ITEM_FIELD_C1_A,
		ITEM_FIELD_C1_B,
		ITEM_FIELD_C1_C,
		ITEM_FIELD_C1_D,
		ITEM_FIELD_C10_A,
		ITEM_FIELD_C10_B,
		ITEM_FIELD_C10_C,
		ITEM_FIELD_C10_D,
		ITEM_FIELD_C2,
		ITEM_FIELD_C30_A,
		ITEM_FIELD_C30_B,
		ITEM_FIELD_C30_C,
		ITEM_FIELD_C30_D,
		ITEM_FIELD_C4,
		ITEM_FIELD_C6,
		ITEM_FIELD_C8,
		ITEM_FIELD_N12_A,
		ITEM_FIELD_N12_B,
		ITEM_FIELD_N12_C,
		ITEM_FIELD_N12_D,
		ITEM_FIELD_N15_A,
		ITEM_FIELD_N15_B,
		ITEM_FIELD_N15_C,
		ITEM_FIELD_N15_D,
		ITM_STAT_DT_FUTURE,
		ITM_STATUS_CURRENT,
		ITM_STATUS_EFFDT,
		ITM_STATUS_FUTURE,
		LAST_DTTM_UPDATE,
		LAST_MAINT_OPRID,
		LOT_CONTROL,
		MATERIAL_RECON_FLG,
		NON_OWN_FLAG,
		ORIG_OPRID,
		PHYSICAL_NATURE,
		PL_PRIO_FAMILY,
		PRDN_CFG_FLAG,
		PROMISE_OPTION,
		SERIAL_CONTROL,
		SERIAL_IN_PRDN,
		SETID,
		SHIP_SERIAL_CNTRL,
		STAGED_DATE_FLAG,
		TRACE_CHANGE,
		TRACE_USAGE,
		UNIT_MEASURE_STD,
		USG_TRCKNG_METHOD
	)
	VALUES(
		'N',										-- APPROV_REQUIRED
		'N',										-- APPROV_SUBMITTED
		CONVERT(CHAR(10), GETDATE(), 121),			-- APPROVAL_DATE
		@userName,									-- APPROVAL_OPRID
		@categoryID,								-- CATEGORY_ID
		'N',										-- CFG_CODE_OPT
		'N',										-- CFG_COST_OPT
		'N',										-- CFG_LOT_OPT
		'',											-- CHANGE_FIELD
		@cmGroup,									-- CM_GROUP
		'N',										-- CONSIGNED_FLAG
		'',											-- CP_TEMPLATE_ID
		'',											-- CP_TREE_DIST
		'',											-- CP_TREE_PRDN
		CONVERT(CHAR(10), GETDATE(), 121),			-- DATE_ADDED
		'',											-- DENIAL_REASON
		@desc30,									-- DESCR
		@description,								-- DESCR60
		@desc10,									-- DESCRSHORT
		'N',										-- DEVICE_TRACKING
		'N',										-- DIST_CFG_FLAG
		@itemGroup,									-- INV_ITEM_GROUP
		@itemId,									-- INV_ITEM_ID
		@itemFamily,								-- INV_PROD_FAM_CD
		'Y',										-- INVENTORY_ITEM
		'',											-- ITEM_FIELD_C1_A
		'',											-- ITEM_FIELD_C1_B
		'',											-- ITEM_FIELD_C1_C
		'',											-- ITEM_FIELD_C1_D
		'',											-- ITEM_FIELD_C10_A
		'',											-- ITEM_FIELD_C10_B
		'',											-- ITEM_FIELD_C10_C
		'',											-- ITEM_FIELD_C10_D
		@psStatus,									-- ITEM_FIELD_C2
		'',											-- ITEM_FIELD_C30_A
		'',											-- ITEM_FIELD_C30_B
		'',											-- ITEM_FIELD_C30_C
		'',											-- ITEM_FIELD_C30_D
		'',											-- ITEM_FIELD_C4
		'',											-- ITEM_FIELD_C6
		'',											-- ITEM_FIELD_C8
		0,											-- ITEM_FIELD_N12_A
		0,											-- ITEM_FIELD_N12_B
		0,											-- ITEM_FIELD_N12_C
		0,											-- ITEM_FIELD_N12_D
		0,											-- ITEM_FIELD_N15_A
		0,											-- ITEM_FIELD_N15_B
		0,											-- ITEM_FIELD_N15_C
		0,											-- ITEM_FIELD_N15_D
		NULL,										-- ITM_STAT_DT_FUTURE
		1,											-- ITM_STATUS_CURRENT
		CONVERT(CHAR(10), GETDATE(), 121),			-- ITM_STATUS_EFFDT
		'',				 						    -- ITM_STATUS_FUTURE
		GETDATE(),									-- LAST_DTTM_UPDATE
		@userName,									-- LAST_MAINT_OPRID
		'N',										-- LOT_CONTROL
		'N',										-- MATERIAL_RECON_FLG
		'N',										-- NON_OWN_FLAG
		@userName,									-- ORIG_OPRID
		'G',										-- PHYSICAL_NATURE
		'',											-- PL_PRIO_FAMILY
		'N',										-- PRDN_CFG_FLAG
		'',											-- PROMISE_OPTION
		'N',										-- SERIAL_CONTROL
		'N',										-- SERIAL_IN_PRDN
		'SHARE',									-- SETID
		'N',										-- SHIP_SERIAL_CNTRL
		'N',										-- STAGED_DATE_FLAG
		'0',										-- TRACE_CHANGE
		'0',										-- TRACE_USAGE
		'EA',										-- UNIT_MEASURE_STD
		'01'										-- USG_TRCKNG_METHOD

)			-- SETID
		   END
		   
	UPDATE PS_MASTER_ITEM_TBL
	SET
		LAST_MAINT_OPRID = @userName,
		INV_ITEM_GROUP = @itemGroup,
		INV_ITEM_ID = @itemId,
		INV_PROD_FAM_CD = @itemFamily,
		DESCR = @desc30,
		DESCR60 = @description,
		DESCRSHORT = @desc10,
		APPROVAL_OPRID = @userName,
		CATEGORY_ID = @categoryID,
		CM_GROUP = @cmGroup,
		ITEM_FIELD_C2 = @psStatus,
		LAST_DTTM_UPDATE = GETDATE()

	WHERE 
		INV_ITEM_ID = @itemId
		AND SETID = 'SHARE'

END
GO

GRANT EXECUTE ON Odin_InsertMasterItemTbl TO Odin
GO
/*

sp_help PS_MASTER_ITEM_TBL
*/