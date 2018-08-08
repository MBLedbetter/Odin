
DROP PROCEDURE Odin_InsertCmItemMethod
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertCmItemMethod
	@itemId varchar(18),
	@busUnit varchar(5),
	@cmProfileId varchar(10)

AS
BEGIN

	SET NOCOUNT ON;
	
	IF NOT EXISTS (SELECT * FROM PS_CM_ITEM_METHOD 
                   WHERE INV_ITEM_ID = @itemId 
				   AND BUSINESS_UNIT = @busUnit)
		   BEGIN
			   INSERT INTO PS_CM_ITEM_METHOD(
		BUSINESS_UNIT,
		INV_ITEM_ID,
		CM_BOOK,
		CM_PROFILE_ID
	)
	VALUES(
		@busUnit,		--BUSINESS_UNIT
		@itemId,		--INV_ITEM_ID
		'FIN',			--CM_BOOK
		@cmProfileId	--CM_PROFILE_ID
	)	
		   END

	UPDATE PS_CM_ITEM_METHOD
	SET
		CM_PROFILE_ID = @cmProfileId

	WHERE 
		INV_ITEM_ID = @itemId 
		AND BUSINESS_UNIT = @busUnit
		AND CM_BOOK = 'FIN'

END
GO

GRANT EXECUTE ON Odin_InsertCmItemMethod TO Odin
GO
/*
SELECT * FROM PS_CM_ITEM_METHOD
sp_help PS_CM_ITEM_METHOD
*/
