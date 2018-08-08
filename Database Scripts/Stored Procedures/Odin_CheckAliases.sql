
DROP PROCEDURE Odin_CheckAliases
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_CheckAliases
		@alias1 VARCHAR(255) = '',
		@alias2 VARCHAR(255) = '',
		@alias3 VARCHAR(255) = '',
		@alias4 VARCHAR(255) = '',
		@alias5 VARCHAR(255) = ''

AS
BEGIN

	SET NOCOUNT ON;

	IF OBJECT_ID('tempdb..#Duplicates' , 'U') IS NOT NULL
    DROP TABLE #Duplicates

	CREATE TABLE #Duplicates
	(
       ProductAlias VARCHAR(255)
	)
	INSERT INTO #Duplicates(ProductAlias)
	VALUES(@alias1)
	INSERT INTO #Duplicates(ProductAlias)
	VALUES(@alias2)
	INSERT INTO #Duplicates(ProductAlias)
	VALUES(@alias3)
	INSERT INTO #Duplicates(ProductAlias)
	VALUES(@alias4)
	INSERT INTO #Duplicates(ProductAlias)
	VALUES(@alias5)
	INSERT #Duplicates SELECT Alias1 FROM Odin_CategoryList WHERE Alias1 <> ''
	INSERT #Duplicates SELECT Alias2 FROM Odin_CategoryList WHERE Alias2 <> ''
	INSERT #Duplicates SELECT Alias3 FROM Odin_CategoryList WHERE Alias3 <> ''
	INSERT #Duplicates SELECT Alias4 FROM Odin_CategoryList WHERE Alias4 <> ''
	INSERT #Duplicates SELECT Alias5 FROM Odin_CategoryList WHERE Alias5 <> ''
	
	SELECT ProductAlias FROM #Duplicates WHERE ProductAlias <> '' GROUP BY ProductAlias HAVING COUNT(*) > 1 

	
	DROP TABLE #Duplicates
	

END
GO
/*
GRANT EXECUTE ON Odin_CheckAliases TO Odin
*/
/*
SELECT * FROM Odin_CategoryList
*/