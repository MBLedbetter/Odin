/*
SELECT * FROM PS_PRODUCT_GROUPS
*/
DROP PROCEDURE Odin_GetProductGroups
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_GetProductGroups
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * FROM PS_PRODUCT_GROUPS


END
GO

GRANT EXECUTE ON Odin_GetProductGroups TO Odin
