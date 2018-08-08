/*
DROP FUNCTION [dbo].[Odin_RetrieveProductIdTranslations]
sp_help PS_MARKETPLACE_PRODUCT_TRANSLATIONS
*/

CREATE FUNCTION Odin_RetrieveProductIdTranslations
(
    @itemId varchar(18)
)
RETURNS varchar(128)
AS
BEGIN
    DECLARE @output varchar(max)
    SELECT @output = COALESCE(@output + ', ', '') + TO_PRODUCT_ID +'&'+CONVERT(varchar(18), TO_QTY)
    FROM PS_MARKETPLACE_PRODUCT_TRANSLATIONS
    WHERE FROM_PRODUCT_ID = @itemId

    return @output
END

GO
