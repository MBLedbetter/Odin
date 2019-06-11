
/* 
 SELECT TOP 10 * FROM PS_MARKETPLACE_CUSTOMER_PRODUCTS
 */
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PS_MARKETPLACE_CUSTOMER_PRODUCTS]
(
	[SETID] VARCHAR(5) NOT NULL,
	[INV_ITEM_ID] VARCHAR(18) NOT NULL,
	[CUST_ID] VARCHAR(15) NOT NULL,
	[TITLE] VARCHAR(266) NOT NULL
)
GO

ALTER TABLE [PS_MARKETPLACE_CUSTOMER_PRODUCTS] ADD PRIMARY KEY(SETID,CUST_ID,INV_ITEM_ID)
GO

SET ANSI_PADDING OFF
GO


GRANT SELECT, INSERT, UPDATE ON PS_MARKETPLACE_CUSTOMER_PRODUCTS TO Odin
