CREATE TABLE [dbo].[Results]
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	CheshireScore INT NOT NULL,
	OpponentScore INT NOT NULL,
	GameStory XML,
	BoxScore XML,
	ShotChartUrl VARCHAR(MAX),
	FixtureId INT NOT NULL, 
    [ImgName] VARCHAR(MAX) NULL
)
