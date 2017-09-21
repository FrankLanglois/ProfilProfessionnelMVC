CREATE TABLE [dbo].[Company]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [DateStart] DATE NULL, 
    [DateFinish] DATE NULL, 
    [IsCurrentCompany] BIT NOT NULL DEFAULT 0
)
