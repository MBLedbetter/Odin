
DROP PROCEDURE Odin_InsertExcelLayoutColumn
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertExcelLayoutColumn

	@layoutId VARCHAR(3),
	@columnNumber int,
    @field VARCHAR(255)='',
	@option VARCHAR(255)='',
	@customer VARCHAR(255)=''

AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO ODIN_EXCEL_LAYOUT_DATA(
			LAYOUT_ID,
			COLUMN_NUMBER,
			FIELD,
			[OPTION],
			CUSTOMER
			)
	VALUES(
			@layoutId,
			@columnNumber,
			@field,
			@option,
			@customer)
END
GO

GRANT EXECUTE ON Odin_InsertExcelLayoutColumn TO Odin
GO

/*
	DELETE FROM ODIN_EXCEL_LAYOUT_DATA 
*/