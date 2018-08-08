DROP PROCEDURE Odin_CheckOrderLine

USE [Odin]
GO

/****** Object:  StoredProcedure [dbo].[Odin_CheckOrderLine]    Script Date: 6/28/2017 7:53:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Odin_CheckOrderLine]
		@itemId VARCHAR(18) = ''

AS
BEGIN

	SET NOCOUNT ON;
		
	SELECT * FROM PS_ORD_LINE WHERE CUSTOMER_ITEM_NBR = @itemId AND ORD_LINE_STATUS IN ('P','O')
		

END

GO
