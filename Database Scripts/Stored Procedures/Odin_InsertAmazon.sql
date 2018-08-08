
DROP PROCEDURE Odin_InsertAmazon
GO
/*

sp_help PS_AMAZON_ITEM_ATTRIBUTES

*/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertAmazon
	@itemId VARCHAR(18)= '',
	@itemName VARCHAR(254)= '',
	@modelName VARCHAR(50)= '',
	@productCategory VARCHAR(50)= '',
	@productSubcategory VARCHAR(50)= '',
	@asin VARCHAR(10) = '',
	@bullet1 VARCHAR(254)= '',
	@bullet2 VARCHAR(254)= '',
	@bullet3 VARCHAR(254)= '',
	@bullet4 VARCHAR(254),
	@bullet5 VARCHAR(254),
	@productDescription VARCHAR(8000)= '',
	@externalIDType VARCHAR(50)= '',
	@externalID VARCHAR(20)= '',
	@searchTerms VARCHAR(500)= '',
	@imagePath1 VARCHAR(254)= '',
	@imagePath2 VARCHAR(254),
	@imagePath3 VARCHAR(254),
	@imagePath4 VARCHAR(254),
	@imagePath5 VARCHAR(254),
	@size VARCHAR(254),
	@cost DECIMAL(9, 2)= NULL,
	@msrp DECIMAL(9, 2)= NULL,
	@manufacturerName VARCHAR(100)= '',
	@countryOfOrigin VARCHAR(20)= '',
	@itemLength DECIMAL(9, 4)= NULL,
	@itemHeight DECIMAL(9, 4)= NULL,
	@itemWidth DECIMAL(9, 4)= NULL,
	@itemWeight DECIMAL(9, 4)= NULL,
	@packageLength DECIMAL(9, 4)= NULL,
	@packageHeight DECIMAL(9, 4)= NULL,
	@packageWidth DECIMAL(9, 4)= NULL,
	@packageWeight DECIMAL(9, 4)= NULL,
	@pageQty INT = 0,
	@components VARCHAR(100) = '',
	@upc VARCHAR(12) = ''

AS
BEGIN

	SET NOCOUNT ON;
	
	IF NOT EXISTS (SELECT * FROM PS_AMAZON_ITEM_ATTRIBUTES 
                   WHERE INV_ITEM_ID = @itemId)
		   BEGIN
			   INSERT INTO PS_AMAZON_ITEM_ATTRIBUTES(
			     INV_ITEM_ID,
			     ITEM_NAME,
				 MODEL_NAME,
				 PRODUCT_CATEGORY,
				 PRODUCT_SUBCATEGORY,
				 [ASIN],
				 BULLET_1,
				 BULLET_2,
				 BULLET_3,
				 BULLET_4,
				 BULLET_5,
				 FULL_DESCRIPTION,
				 EXTERNAL_ID_TYPE,
				 EXTERNAL_ID,
				 SEARCH_TERMS,
				 IMAGE_URL_1,
				 IMAGE_URL_2,
				 IMAGE_URL_3,
				 IMAGE_URL_4,
				 IMAGE_URL_5,
				 SIZE,
				 COST,
				 MSRP,
				 MANUFACTURER_NAME,
				 COUNTRY_OF_ORIGIN,
				 [LENGTH],
				 HEIGHT,
				 WIDTH,
				 [WEIGHT],
				 PACKAGE_LENGTH,
				 PACKAGE_HEIGHT,
				 PACKAGE_WIDTH,
				 PACKAGE_WEIGHT,
				 PAGE_COUNT,
				 COMPONENTS,
				 UPC_OVERRIDE
			)
	VALUES(
	
			     @itemId, -- INV_ITEM_ID
			     @itemName, -- ITEM_NAME
				 @modelName, -- MODEL_NAME
				 @productCategory, -- PRODUCT_CATEGORY
				 @productSubcategory, -- PRODUCT_SUBCATEGORY
				 @asin, -- ASIN
				 @bullet1, -- BULLET_1
				 @bullet2, -- BULLET_2
				 @bullet3, -- BULLET_3
				 @bullet4, -- BULLET_4
				 @bullet5, -- BULLET_5
				 @productDescription, -- FULL_DESCRIPTION
				 @externalIDType, -- EXTERNAL_ID_TYPE
				 @externalID, -- EXTERNAL_ID
				 @searchTerms, -- SEARCH_TERMS
				 @imagePath1, -- IMAGE_URL_1
				 @imagePath2, -- IMAGE_URL_2
				 @imagePath3, -- IMAGE_URL_3
				 @imagePath4, -- IMAGE_URL_4
				 @imagePath5, -- IMAGE_URL_5
				 @size, -- SIZE
				 @cost, -- COST
				 @msrp, -- MSRP
				 @manufacturerName, -- MANUFACTURER_NAME
				 @countryOfOrigin, -- COUNTRY_OF_ORIGIN
				 @itemLength, -- LENGTH
				 @itemHeight, -- HEIGHT
				 @itemWidth, -- WIDTH
				 @itemWeight, -- WEIGHT
				 @packageLength, -- PACKAGE_LENGTH
				 @packageHeight, -- PACKAGE_HEIGHT
				 @packageWidth, -- PACKAGE_WIDTH
				 @packageWeight, -- PACKAGE_WEIGHT
				 @pageQty, -- PAGE_COUNT
				 @components, -- COMPONENTS
				 @upc -- UPC_OVERRIDE
			)
		   END

	UPDATE PS_AMAZON_ITEM_ATTRIBUTES
	SET
		ITEM_NAME = @itemName,
		MODEL_NAME = @modelName,
		PRODUCT_CATEGORY = @productCategory,
		PRODUCT_SUBCATEGORY = @productSubcategory,
		[ASIN] = @asin,
		BULLET_1 = @bullet1,
		BULLET_2 = @bullet2,
		BULLET_3 = @bullet3,
		BULLET_4 = @bullet4,
		BULLET_5 = @bullet5,
		FULL_DESCRIPTION = @productDescription,
		EXTERNAL_ID_TYPE = @externalIDType,
		EXTERNAL_ID = @externalID,
		SEARCH_TERMS = @searchTerms,
		IMAGE_URL_1 = @imagePath1,
		IMAGE_URL_2 = @imagePath2,
		IMAGE_URL_3 = @imagePath3,
		IMAGE_URL_4 = @imagePath4,
		IMAGE_URL_5 = @imagePath5,
		SIZE = @size,
		COST = @cost,
		MSRP = @msrp,
		MANUFACTURER_NAME = @manufacturerName,
		COUNTRY_OF_ORIGIN = @countryOfOrigin,
		[LENGTH] = @itemLength,
		HEIGHT = @itemHeight,
		WIDTH = @itemWidth,
		[WEIGHT] = @itemWeight,
		PACKAGE_LENGTH = @packageLength,
		PACKAGE_HEIGHT = @packageHeight,
		PACKAGE_WIDTH = @packageWidth,
		PACKAGE_WEIGHT = @packageWeight,
		PAGE_COUNT = @pageQty,
		COMPONENTS = @components,
		UPC_OVERRIDE = @upc
	WHERE
		INV_ITEM_ID = @itemId



END
GO

GRANT EXECUTE ON Odin_InsertAmazon TO Odin
GO
/*
SELECT * FROM PS_AMAZON_ITEM_ATTRIBUTES
sp_help PS_AMAZON_ITEM_ATTRIBUTES
*/
