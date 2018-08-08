
/****** Object:  Table [dbo].[PS_INV_ITEMS]    Script Date: 11/25/2013 2:16:58 PM ******/
/*
Creates web product type options 
DROP TABLE Odin_Web_Product_Types
*/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE Odin_Web_Product_Types(
	[PROD_TYPE] [char](64) NULL
)
INSERT INTO Odin_Web_Product_Types(PROD_TYPE) VALUES ('Poster Product'),('Sticker Product'),('Writing Product'),('Tattoo Product'),('Gift Wrap Product'),('Papercraft Product'),('Bookmark Product'),('Calendar Product'),('Tape Product')
GO

SET ANSI_PADDING OFF
GO

/*
SELECT * FROM Odin_Web_Product_Types
*/
