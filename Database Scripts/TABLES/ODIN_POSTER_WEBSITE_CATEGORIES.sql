
/****** Object:  Table [dbo].[ODIN_ITEM_OVERRIDE_INFO]    Script Date: 4/5/2017 1:51:17 PM ******/

SET ANSI_NULLS ON
GO

DROP TABLE ODIN_POSTER_WEBSITE_CATEGORIES

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
CREATE TABLE ODIN_POSTER_WEBSITE_CATEGORIES(
	CATEGORY_ID int IDENTITY(1,1) PRIMARY KEY,
	CATEGORY varchar(MAX) NOT NULL
)

GO

SET ANSI_PADDING OFF
GO

/*
SELECT * FROM ODIN_POSTER_WEBSITE_CATEGORIES
*/
-- INSERT INTO ODIN_POSTER_WEBSITE_CATEGORIES VALUES('Default Category/Shop by License/Harry Potter')
INSERT INTO ODIN_POSTER_WEBSITE_CATEGORIES(CATEGORY)
VALUES 
('Default Category'),
('Default Category/Shop by Genre'),
('Default Category/Shop by License'),
('Default Category/Shop by Genre/Animal'),
('Default Category/Shop by Genre/Anime'),
('Default Category/Shop by Genre/Art Trends'),
('Default Category/Shop by Genre/Comics'),
('Default Category/Shop by Genre/Educational'),
('Default Category/Shop by Genre/Humor'),
('Default Category/Shop by Genre/Influencer'),
('Default Category/Shop by Genre/Inspirational'),
('Default Category/Shop by Genre/Kids Stuff'),
('Default Category/Shop by Genre/Models'),
('Default Category/Shop by Genre/Movies'),
('Default Category/Shop by Genre/Music'),
('Default Category/Shop by Genre/Sports'),
('Default Category/Shop by Genre/Television'),
('Default Category/Shop by Genre/Video Games'),
('Default Category/Shop by License/Activision'),
('Default Category/Shop by License/DC Comics'),
('Default Category/Shop by License/Disney'),
('Default Category/Shop by License/Dreamworks'),
('Default Category/Shop by License/Fender'),
('Default Category/Shop by License/Harry Potter'),
('Default Category/Shop by License/Marvel'),
('Default Category/Shop by License/MLB'),
('Default Category/Shop by License/NBA'),
('Default Category/Shop by License/Netflix'),
('Default Category/Shop by License/NFL'),
('Default Category/Shop by License/NHL'),
('Default Category/Shop by License/Nickelodeon'),
('Default Category/Shop by License/Pokemon'),
('Default Category/Shop by License/Rolling Stone'),
('Default Category/Shop by License/Sanrio'),
('Default Category/Shop by License/Sports Illustrated'),
('Default Category/Shop by License/Star Wars'),
('Default Category/Shop by License/WWE'),
('Default Category/Exclusive Collections'),
('Default Category/Featured products'),
('Default Category/Whats New')


GRANT SELECT, INSERT, UPDATE ON ODIN_POSTER_WEBSITE_CATEGORIES TO Odin