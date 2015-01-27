CREATE TABLE [dbo].[Fixtures]
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	OpponentName VARCHAR(50),
	Organisation VARCHAR(50),
	TipOff DATETIME,
	AddressLine1 VARCHAR(50),
	AddressLine2 VARCHAR(50),
	TownCity VARCHAR(50),
	Postcode VARCHAR(8),
	TeamId INT NOT NULL,
	ImgName VARCHAR(MAX)
)
