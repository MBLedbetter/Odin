SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
--DROP TABLE Odin_RequestComments
--SELECT * FROM Odin_RequestComments
CREATE TABLE Odin_RequestComments(
	RID INT NOT NULL,
	GroupComment varchar(MAX)
)

GO

SET ANSI_PADDING OFF
GO
/*
INSERT INTO Odin_RequestComments
Values(35,'TEST')
*/
