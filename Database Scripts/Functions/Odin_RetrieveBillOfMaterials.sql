/*
DROP FUNCTION [dbo].[Odin_RetrieveBillOfMaterials]
sp_help PS_EN_BOM_COMPS
*/

CREATE FUNCTION Odin_RetrieveBillOfMaterials
(
    @itemId varchar(18)
)
RETURNS varchar(128)
AS
BEGIN
    DECLARE @output varchar(max)
    SELECT @output = COALESCE(@output + ', ', '') + COMPONENT_ID +'&'+CONVERT(varchar(18), QTY_PER)
    FROM PS_EN_BOM_COMPS
    WHERE INV_ITEM_ID = @itemId
	AND BUSINESS_UNIT = 'TRUS1'

    return @output
END

GO
