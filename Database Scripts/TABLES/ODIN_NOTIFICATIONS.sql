/*
SELECT * FROM ODIN_NOTIFICATIONS
DROP TABLE ODIN_NOTIFICATIONS
INSERT INTO ODIN_NOTIFICATIONS VALUES (1, '2018-06-27 00:00:00.000', 'The item saving process is no longer all or nothing and processes items individually. If an error occurs the saving process will stop, but all items preceeding the error will be saved. ')
INSERT INTO ODIN_NOTIFICATIONS VALUES (2, '2018-06-27 00:00:00.000', 'A "Select All" box has been added to the item lookup tool. Options to hide collumns in the main window have been added.')
INSERT INTO ODIN_NOTIFICATIONS VALUES (3, '2018-06-27 00:00:00.000', 'Image collumn headers have been changed to "Image Path" & "Image Path 2-5".')
INSERT INTO ODIN_NOTIFICATIONS VALUES (4, '2018-07-17 00:00:00.000', '"Website Price" field has been added to ecommerce info tab. This field will be used for the displayed price on Trendsinternational.com and will be a required field for website submissions.')
INSERT INTO ODIN_NOTIFICATIONS VALUES (5, '2018-27-17 00:00:00.000', 'A Product Format Exclusion tool has been added to the option pannel. See help documentation for details (pg 12).')
INSERT INTO ODIN_NOTIFICATIONS VALUES (6, '2018-08-08 00:00:00.000', 'Product Id Translations can no longer be modified after an items initial setup. Orders in progress will error if this field is adjusted. Ecommerce Image paths in excel sheets will no longer be read into Odin and will be generated from the Image Path fields.')
INSERT INTO ODIN_NOTIFICATIONS VALUES (7, '2018-08-21 00:00:00.000', 'Sell On Guitar Center field has been added.')
INSERT INTO ODIN_NOTIFICATIONS VALUES (8, '2018-08-28 00:00:00.000', 'Bill of Material values can no longer be updated once they have been inserted into the system. Orders in progress will error if this field is adjusted.')
INSERT INTO ODIN_NOTIFICATIONS VALUES (9, '2018-09-07 00:00:00.000', 'Sell On Amazon Seller Central has been added.')
INSERT INTO ODIN_NOTIFICATIONS VALUES (10, '2018-09-18 00:00:00.000', 'Ecommerce Subject Keywords field has been added.')
INSERT INTO ODIN_NOTIFICATIONS VALUES (11, '2018-09-18 00:00:00.000', 'Sell On Ecommerce Field Added.')
*/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ODIN_NOTIFICATIONS](
	[NOTIFICATION_NUMBER] [int],
	[DATE] [datetime],
	[NOTIFICATION] [varchar](max)
)

GO

SET ANSI_PADDING OFF
GO
