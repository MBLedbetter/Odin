/*
DROP FUNCTION [dbo].[Odin_RetrieveItemTerritories]
sp_help PS_ITEM_TERRITORY
*/
CREATE FUNCTION [dbo].Odin_RetrieveItemTerritories
(
    @itemId varchar(18)
)
RETURNS varchar(128)
AS
BEGIN
    DECLARE @output varchar(max)
    SELECT @output = COALESCE(@output + ', ', '') + TERRITORY
    FROM PS_ITEM_TERRITORY
    WHERE INV_ITEM_ID = @itemId
	AND SETID = 'SHARE'

    return @output
END

GO
