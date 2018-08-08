
DROP PROCEDURE Odin_InsertEnBomComps
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertEnBomComps
	@itemId VARCHAR(18)= '',
	@componentId VARCHAR(18)= '',
	@qty INT

AS
BEGIN

	SET NOCOUNT ON;
	
	BEGIN
		
		INSERT INTO PS_EN_BOM_COMPS(
		    BUSINESS_UNIT,
			INV_ITEM_ID,
			BOM_STATE,
			BOM_TYPE,
			BOM_CODE,
			COMPONENT_ID,
			OP_SEQUENCE,
			DATE_IN_EFFECT,
			DATE_OBSOLETE,
			POS_NBR,
			QTY_PER,
			QTY_CODE,
			YIELD,
			ECO_ID,
			PENDING_STATUS,
			SUB_SUPPLY_FLG,
			NON_OWN_FLAG,
			TEARDOWN_FLAG,
			ROLLUP_FLG,
			EN_SUBS_EXIST,
			INV_ITEM_SIZE,
			INV_ITEM_HEIGHT,
			INV_ITEM_LENGTH,
			INV_ITEM_WIDTH,
			INV_ITEM_WEIGHT,
			INV_ITEM_VOLUME,
			UNIT_MEASURE_DIM,
			UNIT_MEASURE_WT,
			UNIT_MEASURE_VOL,
			TEXT254,
			INCR_CONS_TYPE,
			INCR_CONS_OFFSET,
			COMP_REV
		)
		VALUES(
		    'TRUS1',                   -- BUSINESS_UNIT
			@itemId,                   -- INV_ITEM_ID
			'PR',                      -- BOM_STATE
			'PR',                      -- BOM_TYPE
			'1',                       -- BOM_CODE
			@componentId,              -- COMPONENT_ID
			0,                         -- OP_SEQUENCE
			'1900-01-01 00:00:00.000', -- DATE_IN_EFFECT
			'2099-12-31 00:00:00.000', -- DATE_OBSOLETE
			0,                         -- POS_NBR
			@qty,                      -- QTY_PER
			'ASY',                     -- QTY_CODE
			100.0000,                  -- YIELD
			'',                        -- ECO_ID
			'ACT',                     -- PENDING_STATUS
			'N',                       -- SUB_SUPPLY_FLG
			'N',                       -- NON_OWN_FLAG
			'N',                       -- TEARDOWN_FLAG
			'N',                       -- ROLLUP_FLG
			'N',                       -- EN_SUBS_EXIST
			'',						   -- INV_ITEM_SIZE
			0.0300,					   -- INV_ITEM_HEIGHT
			37.0000,				   -- INV_ITEM_LENGTH
			25.0000,				   -- INV_ITEM_WIDTH
			0.1250,					   -- INV_ITEM_WEIGHT
			0.0000,                    -- INV_ITEM_VOLUME
			'IN',                      -- UNIT_MEASURE_DIM
			'LB',                      -- UNIT_MEASURE_WT
			'',                        -- UNIT_MEASURE_VOL
			'',                        -- TEXT254
			1,                         -- INCR_CONS_TYPE
			0.0000,                    -- INCR_CONS_OFFSET
			''                         -- COMP_REV
		)
	END




END
GO

GRANT EXECUTE ON Odin_InsertEnBomComps TO Odin
GO
/*
SELECT * FROM PS_SF_PRDN_AREA_IT
sp_help PS_SF_PRDN_AREA_IT
*/
