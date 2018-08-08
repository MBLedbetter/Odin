/*
Drop Function Odin_ListToTable
*/
CREATE FUNCTION Odin_ListToTable(@list AS VARCHAR(8000), @delim AS VARCHAR(10))
RETURNS @listTable TABLE(Value VARCHAR(10) COLLATE Latin1_General_BIN)
AS BEGIN

                -- Declare helper to identify the position of the delim
                DECLARE @delimPosition INT
    
                -- Prime the loop, with an initial check for the delim
                SET @delimPosition = CHARINDEX(@delim, @list)

                -- Loop through, until we no longer find the delimiter
                WHILE @delimPosition > 0
                BEGIN
                                -- Add the item to the table
                                INSERT INTO @listTable(Value)
                                VALUES(RTRIM(LTRIM(LEFT(@list, @delimPosition - 1))))
    
                                -- Remove the entry from the List
                                SET @list = LTRIM(RIGHT(@list, LEN(@list) - @delimPosition))

                                -- Perform position comparison
                                SET @delimPosition = CHARINDEX(@delim, @list)
                END

                -- If we still have an entry, add it to the list
                IF LEN(@list) > 0 BEGIN
                                INSERT INTO @listTable(Value)
                                VALUES(RTRIM(LTRIM(@list)))
                END

  RETURN

END
