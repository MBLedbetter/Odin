
DROP PROCEDURE Odin_GetPsCmGroupDefn
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_GetPsCmGroupDefn
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * FROM PS_CM_GROUP_DEFN

END
GO

GRANT EXECUTE ON Odin_GetPsCmGroupDefn TO Odin