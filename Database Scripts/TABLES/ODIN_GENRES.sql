SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ODIN_GENRES]
(  
    [GENRE] VARCHAR(254)
)
GO

SET ANSI_PADDING OFF
GO

GRANT SELECT, INSERT ON ODIN_GENRES TO Odin
/*

SELECT * FROM ODIN_GENRES

INSERT INTO [ODIN_GENRES] VALUES ('ANIMAL')
INSERT INTO [ODIN_GENRES] VALUES ('ANIME')
INSERT INTO [ODIN_GENRES] VALUES ('ART')
INSERT INTO [ODIN_GENRES] VALUES ('COMICS')
INSERT INTO [ODIN_GENRES] VALUES ('EDUCATIONAL')
INSERT INTO [ODIN_GENRES] VALUES ('HUMOR')
INSERT INTO [ODIN_GENRES] VALUES ('INFLUENCERS')
INSERT INTO [ODIN_GENRES] VALUES ('INSPIRATIONAL')
INSERT INTO [ODIN_GENRES] VALUES ('KIDS'' STUFF')
INSERT INTO [ODIN_GENRES] VALUES ('MODELS')
INSERT INTO [ODIN_GENRES] VALUES ('MOVIES')
INSERT INTO [ODIN_GENRES] VALUES ('MUSIC')
INSERT INTO [ODIN_GENRES] VALUES ('SPORTS')
INSERT INTO [ODIN_GENRES] VALUES ('TELEVISION')
INSERT INTO [ODIN_GENRES] VALUES ('VIDEO GAMES')
*/
