
DROP PROCEDURE Odin_CompareCountryTbl
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_CompareCountryTbl
		@country VARCHAR(3) = ''
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * FROM PS_COUNTRY_TBL
	WHERE COUNTRY = @country


END
GO

GRANT EXECUTE ON Odin_CompareCountryTbl TO Odin