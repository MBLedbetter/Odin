/*
DROP FUNCTION [dbo].[Odin_RetrieveItemLanguages]
sp_help PS_ITEM_LANGUAGE
*/
CREATE FUNCTION [dbo].[Odin_RetrieveItemLanguages]
(
    @itemId varchar(128)
)
RETURNS varchar(128)
AS
BEGIN
    DECLARE @output varchar(max)
    SELECT  @output = COALESCE(@output + ', ', '') + LANGUAGE_CD
    FROM PS_ITEM_LANGUAGE
    WHERE INV_ITEM_ID = @itemId
	AND SETID = 'SHARE'

    RETURN @output
END

GO
