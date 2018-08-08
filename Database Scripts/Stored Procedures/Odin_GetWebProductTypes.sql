
DROP PROCEDURE Odin_GetWebProductTypes
GO

/* Retrieve the list of web product types */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_GetWebProductTypes
AS
BEGIN

	SET NOCOUNT ON;

	SELECT [PROD_TYPE] FROM Odin_Web_Product_Types

END
GO

GRANT EXECUTE ON Odin_GetWebProductTypes TO Odin
