
/* SELECT * FROM PS_ITEM_WEB_INFO WHERE INV_ITEM_ID = 'RP14086' */
DROP PROCEDURE Odin_InsertItemWebInfo
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertItemWebInfo

	@title varchar(266)='',
	@itemKeywords varchar(MAX)='',
	@inStockDate datetime = null,
	@newDate datetime = null,
	@category varchar(254)='',
	@newCategory varchar(254)='',
	@copyright varchar(MAX)='',
	@itemId varchar(18)='',
	@active int,
    @license VARCHAR(255)='',
    @attributeSet VARCHAR(255)='',
    @shortDescription VARCHAR(MAX)='',
    @relatedProduct VARCHAR(MAX)='',
	@imagePath VARCHAR(254) = '',
    @property VARCHAR(MAX)='',
	@metaDescription VARCHAR(255)='',
    @size VARCHAR(255) = '',
    @prodQty VARCHAR(255) = '1'
AS
BEGIN

	SET NOCOUNT ON;
	IF NOT EXISTS (SELECT * FROM PS_ITEM_WEB_INFO 
                   WHERE INV_ITEM_ID = @itemId)
					   BEGIN
						   INSERT INTO PS_ITEM_WEB_INFO(
								INV_ITEM_ID,
								IN_STOCK_DATE,
								ITEM_KEYWORDS,
								CATEGORY,
								NEWCATEGORY,
								COPYRIGHT,
								MSRP,
								TITLE,
								ACTIVE,
								LICENSE,
								ATTRIBUTE_SET,
								SHORT_DESC,
								META_DESCRIPTION,
								NEW_DATE,
								PROPERTY,
								SIZE,
								PROD_QTY,
								IMAGE_PATH,
								ON_SITE
								)
						VALUES(		
								@itemId,		--INV_ITEM_ID
								@inStockDate,	--IN_STOCK_DATE
								@itemKeywords,	--ITEM_KEYWORDS
								@category,		--CATEGORY
								'',	--NEWCATEGORY
								@copyright,		--COPYRITE
								0.0000,			--MSRP
								@title,			--TITLE
								@active,		-- ACTIVE	
								@license,		-- LICENSE
								@attributeSet,	-- ATTRIBUTE SET
								@shortDescription,-- SHORT DESCIPTION
								@metaDescription, -- META DESCRIPTION
								'',					-- NEW DATE
								@property,			-- PROPERTY
								@size,				-- SIZE
								@prodQty,				-- PROD_QTY
								@imagePath,
								'N'
								)	
					   END
				   BEGIN

	UPDATE PS_ITEM_WEB_INFO
	SET
			CATEGORY = @category,
			NEWCATEGORY = @newCategory,
			IN_STOCK_DATE = @inStockDate,
			ITEM_KEYWORDS = @itemKeywords,
			COPYRIGHT = @copyright,
			TITLE = @title,
			ACTIVE = @active,
			LICENSE = @license,
			ATTRIBUTE_SET = @attributeSet,
			SHORT_DESC = @shortDescription,
			META_DESCRIPTION = @metaDescription,
			SIZE = @size,
			PROPERTY = @property,
			PROD_QTY = @prodQty,
			IMAGE_PATH = @imagePath
	WHERE
		INV_ITEM_ID = @itemId

		END
END
GO

GRANT EXECUTE ON Odin_InsertItemWebInfo TO Odin

/*
SELECT * FROM PS_ITEM_WEB_INFO
sp_help PS_ITEM_WEB_INFO
*/