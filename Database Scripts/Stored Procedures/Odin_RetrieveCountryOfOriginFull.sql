
DROP PROCEDURE Odin_RetrieveCountryOfOriginFull
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_RetrieveCountryOfOriginFull
AS
BEGIN

	SET NOCOUNT ON;

	SELECT COUNTRY, DESCR FROM PS_COUNTRY_TBL

END
GO

GRANT EXECUTE ON Odin_RetrieveCountryOfOriginFull TO Odin