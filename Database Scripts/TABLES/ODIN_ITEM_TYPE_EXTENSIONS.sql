SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ODIN_ITEM_TYPE_EXTENSIONS]
(  
    [PREFIX] VARCHAR(24),
	[SUFFIX] VARCHAR(24)
)
GO

SET ANSI_PADDING OFF
GO


SELECT * FROM ODIN_ITEM_TYPE_SUFFIXES
INSERT INTO [ODIN_ITEM_TYPE_EXTENSIONS] VALUES ('FR', 'BLK22X34')
INSERT INTO [ODIN_ITEM_TYPE_EXTENSIONS] VALUES ('FR', 'SIL22X34')
INSERT INTO [ODIN_ITEM_TYPE_EXTENSIONS] VALUES ('FR', 'MAH22X34')
INSERT INTO [ODIN_ITEM_TYPE_EXTENSIONS] VALUES ('FR', 'WHT22X34')
INSERT INTO [ODIN_ITEM_TYPE_EXTENSIONS] VALUES ('POD', '')
INSERT INTO [ODIN_ITEM_TYPE_EXTENSIONS] VALUES ('RP', '')
INSERT INTO [ODIN_ITEM_TYPE_EXTENSIONS] VALUES ('EBPOD', 'PC')
INSERT INTO [ODIN_ITEM_TYPE_EXTENSIONS] VALUES ('EBPOD', 'PM')
INSERT INTO [ODIN_ITEM_TYPE_EXTENSIONS] VALUES ('EB', 'PC')
INSERT INTO [ODIN_ITEM_TYPE_EXTENSIONS] VALUES ('EB', 'PM')
INSERT INTO ODIN_ITEM_TYPE_EXTENSIONS VALUES ('FR','BLK24X36')
INSERT INTO ODIN_ITEM_TYPE_EXTENSIONS VALUES ('FR','SIL24X36')
INSERT INTO ODIN_ITEM_TYPE_EXTENSIONS VALUES ('FR','MAH24X36')
INSERT INTO ODIN_ITEM_TYPE_EXTENSIONS VALUES ('FR','WHT24X36')

GRANT SELECT, INSERT, UPDATE, DELETE ON ODIN_ITEM_TYPE_EXTENSIONS TO Odin
