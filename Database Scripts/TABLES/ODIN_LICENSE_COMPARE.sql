
/****** Object:  Table [dbo].[PS_INV_ITEMS]    Script Date: 11/25/2013 2:16:58 PM ******/
/*
DROP TABLE ODIN_LICENSE_COMPARE
*/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE ODIN_LICENSE_COMPARE(
	LICENSE varchar(MAX) NULL,
	FILTER_LICENSE varchar(MAX) NULL
)
INSERT INTO ODIN_LICENSE_COMPARE(LICENSE, FILTER_LICENSE) 
VALUES ('MARVEL ENTERTAINMENT','MARVEL'),
('NFL LEAGUE','NFL'),
('NFL LIQUID BLUE','NFL'),
('NFL PLAYERS','NFL'),
('NFL PREMIUMS','NFL'),
('NFL SUPER BOWL 2014-','NFL'),
('NFL SUPER BOWL THE WHO/LIVE NATION','NFL'),
('NHL ENTERPRISES, INC.                   ','NHL'),
('NHL GUARDIANS                           ','NHL'),
('NHL PLAYERS ASSOCIATION                 ','NHL'),
('PARAMOUNT LICENSING                     ','PARAMOUNT'),
('SPONGEBOB                               ','Nickelodeon: Spongebob'),
('SPIDER-MAN MERCHANDISING                ','Marvel: Spider-Man'),
('DISNEY - G FORCE                        ','Disney: G FORCE'),
('DISNEY - HISTORY                        ','Disney: HISTORY'),
('DISNEY - JONAS BROTHERS TV SHOW         ','Disney: JONAS BROTHERS TV SHOW'),
('DISNEY - RAPUNZEL MOVIE                 ','Disney: RAPUNZEL MOVIE'),
('DISNEY - THE ARISTOCATS                 ','Disney: THE ARISTOCATS'),
('DISNEY - THE MUPPETS                    ','Disney: THE MUPPETS'),
('DISNEY - TOY STORY                      ','Disney: TOY STORY'),
('DISNEY - WALT DISNEY RETROSPECTIVE      ','Disney: WALT DISNEY RETROSPECTIVE'),
('DISNEY -LITTLE EINSTEINS                ','Disney: LITTLE EINSTEINS'),
('DISNEY CAMP ROCK                        ','Disney: CAMP ROCK'),
('DISNEY EMOJI                            ','Disney: EMOJI'),
('DISNEY FIRE AND RESCUE                  ','Disney: FIRE AND RESCUE'),
('DISNEY- 101 DALMATIONS                  ','Disney: 101 DALMATIONS'),
('DISNEY- CORY IN THE HOUSE               ','Disney: CORY IN THE HOUSE'),
('DISNEY- JONAS BROTHERS                  ','Disney: JONAS BROTHERS'),
('DISNEY- PHINEAS & FERB                  ','Disney: PHINEAS & FERB'),
('DISNEY-A CHRISTMAS CAROL                ','Disney: A CHRISTMAS CAROL'),
('DISNEY-BOLT                             ','Disney: BOLT'),
('DISNEY-CARS                             ','Disney: CARS'),
('DISNEY-CHEETAH GIRLS                    ','Disney: CHEETAH GIRLS'),
('DISNEY-CHICKEN LITTLE                   ','Disney: CHICKEN LITTLE'),
('DISNEY-CHRONICLES OF NARNIA             ','Disney: CHRONICLES OF NARNIA'),
('DISNEY-CLASSICS -BAMBI                  ','Disney: BAMBI'),
('DISNEY-CLASSICS-DUMBO                   ','Disney: DUMBO'),
('DISNEY-CLASSICS-LADY & THE TRAMP        ','Disney: LADY & THE TRAMP'),
('DISNEY-CLASSICS-SNOW WHITE              ','Disney: SNOW WHITE'),
('DISNEY-CLUB PENGUIN                     ','Disney: CLUB PENGUIN'),
('DISNEY-DOC MCSTUFFINS                   ','Disney: DOC MCSTUFFINS'),
('DISNEY-FAIRIES                          ','Disney: FAIRIES'),
('DISNEY-FINDING NEMO                     ','Disney: FINDING NEMO'),
('DISNEY-HANDY MANNY                      ','Disney: HANDY MANNY'),
('DISNEY-HANNAH MONTANA                   ','Disney: HANNAH MONTANA'),
('DISNEY-HERBIE THE LOVE BUG              ','Disney: HERBIE THE LOVE BUG'),
('DISNEY-HIGH SCHOOL MUSICAL              ','Disney: HIGH SCHOOL MUSICAL'),
('DISNEY-HIGH SCHOOL MUSICAL 3            ','Disney: HIGH SCHOOL MUSICAL'),
('DISNEY-JAKE AND THE NEVERLAND PIRATES   ','Disney: JAKE AND THE NEVERLAND PIRATES'),
('DISNEY-JOHN CARTER                      ','Disney: JOHN CARTER'),
('DISNEY-KIM POSSIBLE                     ','Disney: KIM POSSIBLE'),
('DISNEY-KINGDOM HEARTS                   ','Disney: KINGDOM HEARTS'),
('DISNEY-MEET THE ROBINSON                ','Disney: MEET THE ROBINSON'),
('DISNEY-MOANA                            ','Disney: MOANA'),
('DISNEY-NIGHTMARE BEFORE CHRISTMAS       ','Disney: NIGHTMARE BEFORE CHRISTMAS'),
('DISNEY-PIRATES OF THE CARIBBEAN         ','Disney: PIRATES OF THE CARIBBEAN'),
('DISNEY-PIXAR MISC MOVIES CALENDAR       ','Disney: PIXAR MISC MOVIES CALENDAR'),
('DISNEY-POWER RANGERS                    ','Disney: POWER RANGERS'),
('DISNEY-PRINCE OF PERSIA                 ','Disney: PRINCE OF PERSIA'),
('DISNEY-PRINCESS                         ','Disney: PRINCESS'),
('DISNEY-PRINCESS PROTECTION PROGRAM      ','Disney: PRINCESS PROTECTION PROGRAM'),
('DISNEY-RATATOUILLE                      ','Disney: RATATOUILLE'),
('DISNEY-STANDARD CHARACTERS              ','Disney: STANDARD CHARACTERS'),
('DISNEY-THE INCREDIBLES                  ','Disney: THE INCREDIBLES'),
('DISNEY-THE LION GUARD                   ','Disney: THE LION GUARD'),
('DISNEY-TINKERBELL                       ','Disney: TINKERBELL'),
('DISNEY-TRON                             ','Disney: TRON'),
('DISNEY-VILLAINS CALENDAR                ','Disney: VILLAINS'),
('DISNEY-WALL-E                           ','Disney: WALL-E'),
('DISNEY-WINNIE THE POOH                  ','Disney: WINNIE THE POOH'),
('DISNEY-WIZARDS OF WAVERLY PLACE         ','Disney: WIZARDS OF WAVERLY PLACE'),
('MAJOR LEAGUE BASEBALL                   ','MLB'),
('NBA  TEAMS                              ','NBA'),
('NBA PLAYERS                             ','NBA'),
('NBA PLAYERS & TEAMS                     ','NBA'),
('SCHOLASTIC ENTERTAINMENT                ','SCHOLASTIC'),
('TWENTIETH CENTURY FOX                   ','20th Century Fox'),
('UNIVERSAL STUDIOS LICENSING             ','Universal'),
('WRESTLING                               ','WWE'),
('DORA                                    ','Nickelodeon: DORA'),
('GO DIEGO GO                             ','Nickelodeon: GO DIEGO GO')
GO

SET ANSI_PADDING OFF
GO

/*
SELECT * FROM ODIN_LICENSE_COMPARE
*/
