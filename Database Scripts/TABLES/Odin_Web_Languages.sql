
/****** Object:  Table [dbo].[PS_INV_ITEMS]    Script Date: 11/25/2013 2:16:58 PM ******/
/*
DROP TABLE Odin_Web_Languages
*/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE Odin_Web_Languages(
	[LANGUAGE] [char](18) NULL
)
INSERT INTO Odin_Web_Languages(LANGUAGE) VALUES ('ENG'),('SPA'),('FRE'),('ENG/FRE/SPA'),('ENG/FRE'),('ENG/SPA'),('FRE/SPA')
GO

SET ANSI_PADDING OFF
GO

/*
SELECT * FROM Odin_Web_Languages
*/
