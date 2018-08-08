SET ANSI_NULLS ON
GO

DROP TABLE ODIN_SPECIAL_CHARS

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
CREATE TABLE ODIN_SPECIAL_CHARS(
	ID varchar(1),
    CHARACTER varchar(5) NOT NULL
)

GO

SET ANSI_PADDING OFF
GO

/*
SELECT * FROM ODIN_SPECIAL_CHARS
*/
INSERT INTO ODIN_SPECIAL_CHARS(ID, CHARACTER)
VALUES 
('1','™'),
('1',','),
('1','®'),
('1','á'),
('1','é'),
('1','í'),
('1','ó'),
('1','ú'),
('1','ñ'),
('1','ü'),
('1','¡'),
('1','¿'),
('1','©'),
('1','Á'),
('1','É'),
('1','Í'),
('1','Ó'),
('1','Ú'),
('1','Ü'),
('1','Ñ')

