﻿CREATE TABLE [dbo].[Teams]
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50),
	LeagueId INT NOT NULL
)