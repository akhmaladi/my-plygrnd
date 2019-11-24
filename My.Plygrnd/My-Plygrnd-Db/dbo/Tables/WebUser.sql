USE [my-plygrnd]
GO

CREATE TABLE [dbo].[WebUser]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[BusinessId] BIGINT NOT NULL,
	[Username] VARCHAR(200) NOT NULL,
	[Password] VARCHAR(200) NOT NULL,
	[Status] CHAR(1) NOT NULL,
	[CreationDate] DATETIME NULL,
	[LastLoginDate] DATETIME NULL 
)
GO

CREATE UNIQUE NONCLUSTERED INDEX IX_WebUser_Username ON [dbo].[WebUser] (Username)
GO