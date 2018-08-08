
DROP PROCEDURE Odin_InsertExcelLayoutId
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertExcelLayoutId

	@layoutId varchar(3),
	@layoutName varchar(255) = '',
	@customer varchar(255) = '',
	@productType varchar(255) = ''

AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO ODIN_EXCEL_LAYOUT_IDS(
			LAYOUT_ID,
			LAYOUT_NAME,
			CUSTOMER,
			PRODUCT_TYPE
			)
	VALUES(
			@layoutId,
			@layoutName,
			@customer,
			@productType
			)
END
GO

GRANT EXECUTE ON Odin_InsertExcelLayoutId TO Odin
GO

/*
sp_help ODIN_EXCEL_LAYOUT_IDS
SELECT * FROM ODIN_EXCEL_LAYOUT_IDS

*/