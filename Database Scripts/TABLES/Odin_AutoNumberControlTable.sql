/*DROP TABLE Odin_AutoNumberControlTable*/
CREATE TABLE Odin_AutoNumberControlTable
(
	Identifier VARCHAR(255) NOT NULL,
	NextAutoNumber INT
)

ALTER TABLE Odin_AutoNumberControlTable ADD PRIMARY KEY (Identifier)

INSERT INTO Odin_AutoNumberControlTable(
	Identifier,
	NextAutoNumber)
VALUES(
	'WebSiteIdentifier',
	1)

	/*
	SELECT * FROM Odin_AutoNumberControlTable
	*/