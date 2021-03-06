
DROP PROCEDURE Odin_RetrieveActiveEcommerceItemIds
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RetrieveActiveEcommerceItemIds(
	@startDate PSDATE,
	@endDate PSDATE,
	@productGroup Varchar(30) = '',
	@customerId varchar(15) = ''
	)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT DISTINCT 
		CUSTOMER_PRODUCT_ATTRIBUTES.PRODUCT_ID
	FROM  PS_CUSTOMER_PRODUCT_ATTRIBUTES CUSTOMER_PRODUCT_ATTRIBUTES
		JOIN PS_ITEM_ATTRIB_EX ITEM_ATTRIB_EX
			ON ITEM_ATTRIB_EX.SETID = 'SHARE'
			AND ITEM_ATTRIB_EX.INV_ITEM_ID = CUSTOMER_PRODUCT_ATTRIBUTES.PRODUCT_ID
		JOIN PS_MASTER_ITEM_TBL MASTER_ITEM_TBL
			ON MASTER_ITEM_TBL.SETID = 'SHARE'
			AND MASTER_ITEM_TBL.INV_ITEM_ID = CUSTOMER_PRODUCT_ATTRIBUTES.PRODUCT_ID
	WHERE CUSTOMER_PRODUCT_ATTRIBUTES.SEND_INVENTORY = 'Y'
		AND MASTER_ITEM_TBL.DATE_ADDED BETWEEN @startDate AND @endDate
		AND ITEM_ATTRIB_EX.PROD_GROUP = @productGroup
		AND CUSTOMER_PRODUCT_ATTRIBUTES.SETID = 'SHARE'
		AND CUSTOMER_PRODUCT_ATTRIBUTES.CUST_ID = @customerId

END
GO

GRANT EXECUTE ON Odin_RetrieveActiveEcommerceItemIds TO Odin
GO
/*
SELECT * FROM PS_AMAZON_ITEM_ATTRIBUTES WHERE INV_ITEM_ID = 'ST5525'
SELECT * FROM PS_MASTER_ITEM_TBL WHERE INV_ITEM_ID = 'ST5525'
sp_help PS_MASTER_ITEM_TBL
*/