/*
SELECT * FROM ODIN_CUSTOMER_CONVERSION
DROP FUNCTION [dbo].[Odin_RetrieveSellOnFlag]
sp_help PS_ITEM_TERRITORY
*/
CREATE FUNCTION [dbo].Odin_RetrieveSellOnFlag
(
    @itemId varchar(18),
    @customer varchar(128)
)
RETURNS varchar(1)
AS
BEGIN
    DECLARE @output varchar(max)
    DECLARE @custId varchar(max)
	SELECT @custId = CORPORATE_CUST_ID FROM ODIN_CUSTOMER_CONVERSION WHERE CUST_NAME = @customer
	SELECT @output = CPA.SEND_INVENTORY 
	FROM PS_CUSTOMER_PRODUCT_ATTRIBUTES  CPA
	WHERE CPA.PRODUCT_ID = @itemId 
		AND CPA.CUST_ID = @custId 
		AND CPA.SETID = 'SHARE'
    return @output
END

GO
