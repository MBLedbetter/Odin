
DROP PROCEDURE Odin_InsertProdPgrpLnk
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertProdPgrpLnk(
	@productGroup varchar(10),
	@primPrcFlag varchar(1),
	@prodGroupType varchar(4),
	@itemId varchar(18),
	@userName varchar(30)
	)
	

AS
BEGIN

	SET NOCOUNT ON;
	
	IF NOT EXISTS (SELECT * FROM PS_PROD_PGRP_LNK 
                   WHERE PRODUCT_ID = @itemId 
				   and PROD_GRP_TYPE = @prodGroupType
				   )
		   BEGIN
			   INSERT INTO PS_PROD_PGRP_LNK(
			SETID,
			PRODUCT_ID,
			PROD_GRP_TYPE,
			PRODUCT_GROUP,
			PRIMARY_FLAG,
			PRIM_PRC_FLAG,
			DATETIME_ADDED,
			LASTUPDDTTM,
			LAST_MAINT_OPRID
	)
	VALUES(
			'SHARE',			--SETID
			@itemId,			--PRODUCT_ID
			@prodGroupType,		--PROD_GRP_TYPE
			@productGroup,		--PRODUCT_GROUP
			'N',				--PRIMARY_FLAG
			@primPrcFlag,		--PRIM_PRC_FLAG
			GETDATE(),			--DATETIME_ADDED
			GETDATE(),			--LASTUPDDTTM
			@userName			--LAST_MAINT_OPRID
			)
			
		   END
	
	UPDATE PS_PROD_PGRP_LNK
	SET	
		PRODUCT_GROUP = @productGroup,
		LASTUPDDTTM = GETDATE(),
		LAST_MAINT_OPRID = @userName		
	WHERE
		PRODUCT_ID = @itemId 
		AND PROD_GRP_TYPE = @prodGroupType
		AND SETID = 'SHARE'
		
END
GO

GRANT EXECUTE ON Odin_InsertProdPgrpLnk TO Odin
GO
/*
SELECT * FROM PS_PROD_PGRP_LNK
sp_help PS_PROD_PGRP_LNK
*/
