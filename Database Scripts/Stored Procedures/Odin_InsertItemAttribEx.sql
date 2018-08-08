/*
SELECT * FROM PS_ITEM_ATTRIB_EX
sp_help PS_ITEM_ATTRIB_EX
ALTER TABLE PS_ITEM_ATTRIB_EX
ADD IMAGE_FILE_NAME varchar(255)
ALTER TABLE PS_ITEM_ATTRIB_EX ADD ALT_IMAGE_FILE_1 varchar(255)
ALTER TABLE PS_ITEM_ATTRIB_EX ADD ALT_IMAGE_FILE_2 varchar(255)
ALTER TABLE PS_ITEM_ATTRIB_EX ADD ALT_IMAGE_FILE_3 varchar(255)
ALTER TABLE PS_ITEM_ATTRIB_EX ADD ALT_IMAGE_FILE_4 varchar(255)
*/

DROP PROCEDURE Odin_InsertItemAttribEx
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertItemAttribEx
	@casepackHeight DECIMAL(5,2),
	@casepackLength DECIMAL(5,2),
	@casepackQty DECIMAL(5,2),
	@casepackUpc VARCHAR(12) = '',
	@casepackWidth DECIMAL(5,2),
	@casepackWeight DECIMAL(5,2),
	@directImport VARCHAR(1)='',
	@duty VARCHAR(30)='',
	@innerpackHeight DECIMAL(5,2),
	@innerpackLength DECIMAL(5,2),
	@innerpackQty SMALLINT,
	@innerpackUpc VARCHAR(12) = '',
	@innerpackWidth DECIMAL(5,2),
	@innerpackWeight DECIMAL(5,2),
	@itemId VARCHAR(18)='',
	@licenseBeginDate PSDATE = null,
	@prodFormat VARCHAR(60)='',
	@prodGroup VARCHAR(30)='',
	@prodLine VARCHAR(30)='',
	@satCode VARCHAR(20)='',
	@sellOnWeb VARCHAR(1)='N',
	@printOnDemand VARCHAR(1)='N',
	@translateEdiProd VARCHAR(1)='N',
	@imageFileName VARCHAR(250)='',
	@altImageFileName1 VARCHAR(250)='',
	@altImageFileName2 VARCHAR(250)='',
	@altImageFileName3 VARCHAR(250)='',
	@altImageFileName4 VARCHAR(250)=''

AS
BEGIN

	SET NOCOUNT ON;
	
	IF NOT EXISTS (SELECT * FROM PS_ITEM_ATTRIB_EX 
                   WHERE INV_ITEM_ID = @itemId)
	BEGIN
		INSERT INTO PS_ITEM_ATTRIB_EX(
			CASEPACK_HEIGHT,
			CASEPACK_LENGTH,
			CASEPACK_QTY,
			CASEPACK_UPC,
			CASEPACK_WIDTH,
			CASEPACK_WEIGHT,
			DIRECT_IMPORT,
			DUTY,
			GTIN,
			INNERPACK_HEIGHT,
			INNERPACK_LENGTH,
			INNERPACK_QTY,
			INNERPACK_UPC,
			INNERPACK_WIDTH,
			INNERPACK_WEIGHT,
			INV_ITEM_ID,
			BOX_ITEM_GROUP,
			LICENSE_BEGIN_DATE,
			PROD_FORMAT,
			PROD_GROUP,
			PROD_LINE,
			SAT_CODE,
			SETID,
			SELL_ON_WEB,
			PRINT_ON_DEMAND,
			TRANSLATE_EDI_PROD,
			IMAGE_FILE_NAME,
			ALT_IMAGE_FILE_1,
			ALT_IMAGE_FILE_2,
			ALT_IMAGE_FILE_3,
			ALT_IMAGE_FILE_4)
		VALUES(
			@casepackHeight,		-- CASEPACK_HEIGHT
			@casepackLength,		-- CASEPACK_LENGTH
			@casepackQty,			-- CASEPACK_QTY
			@casepackUpc,			-- CASEPACK_UPC
			@casepackWidth,			-- CASEPACK_WIDTH
			@casepackWeight,		-- CASEPACK_WEIGHT
			@directImport,			-- DIRECT_IMPORT
			@duty,					-- DUTY
			'',						-- GTIN
			@innerpackHeight,		-- INNERPACK_HEIGHT
			@innerpackLength,		-- INNERPACK_LENGTH
			@innerpackQty,			-- INNERPACK_QTY
			@innerpackUpc,			-- INNERPACK_UPC
			@innerpackWidth,		-- INNERPACK_WIDTH
			@innerpackWeight,		-- INNERPACK_WEIGHT
			@itemId,				-- INV_ITEM_ID
			'',						-- BOX_ITEM_GROUP
			@licenseBeginDate,		-- LICENSE_BEGIN_DATE
			@prodFormat,			-- PROD_FORMAT
			@prodGroup,				-- PROD_GROUP
			@prodLine,				-- PROD_LINE
			@satCode,				-- SAT_CODE
			'SHARE',				-- SETID
			@sellOnWeb,				-- SELL_ON_WEB
			@printOnDemand,			-- PRINT_ON_DEMAND
			@translateEdiProd,      -- TRANSLATE_EDI_PROD
			@imageFileName,			-- IMAGE_FILE_NAME
			@altImageFileName1,		-- ALT_IMAGE_FILE_1
			@altImageFileName2,		-- ALT_IMAGE_FILE_2
			@altImageFileName3,		-- ALT_IMAGE_FILE_3
			@altImageFileName4)		-- ALT_IMAGE_FILE_4
		 END

	UPDATE PS_ITEM_ATTRIB_EX
	SET
		CASEPACK_HEIGHT = @casepackHeight,
		CASEPACK_LENGTH = @casepackLength,
		CASEPACK_QTY = @casepackQty,
		CASEPACK_UPC = @casepackUpc,
		CASEPACK_WEIGHT = @casepackWeight,
		CASEPACK_WIDTH = @casepackWidth,
		DIRECT_IMPORT = @directImport,
		DUTY = @duty,
		INNERPACK_HEIGHT = @innerpackHeight,
		INNERPACK_LENGTH = @innerpackLength,
		INNERPACK_QTY = @innerpackQty,
		INNERPACK_UPC = @innerpackUpc,
		INNERPACK_WEIGHT = @innerpackWeight,
		INNERPACK_WIDTH = @innerpackWidth,
		LICENSE_BEGIN_DATE = @licenseBeginDate,
		PROD_FORMAT = @prodFormat,
		PROD_GROUP = @prodGroup,
		PROD_LINE = @prodLine,
		SAT_CODE = @satCode,
		SELL_ON_WEB = @sellOnWeb,
		PRINT_ON_DEMAND = @printOnDemand,
		TRANSLATE_EDI_PROD = @translateEdiProd,
		IMAGE_FILE_NAME = @imageFileName,
		ALT_IMAGE_FILE_1 = @altImageFileName1,
		ALT_IMAGE_FILE_2 = @altImageFileName2,
		ALT_IMAGE_FILE_3 = @altImageFileName3,
		ALT_IMAGE_FILE_4 = @altImageFileName4	
	WHERE 
		INV_ITEM_ID = @itemId
		AND SETID = 'SHARE'
END
GO

GRANT EXECUTE ON Odin_InsertItemAttribEx TO Odin
GO
