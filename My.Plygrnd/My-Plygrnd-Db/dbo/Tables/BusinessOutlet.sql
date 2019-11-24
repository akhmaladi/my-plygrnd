USE [my-plygrnd]
GO

CREATE TABLE [dbo].[BusinessOutlet]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[BusinessId] BIGINT NOT NULL,
	[BranchId] VARCHAR(20) NOT NULL,
	[Name] VARCHAR(200) NOT NULL,
	[Address] VARCHAR(2000) NULL
)
GO

CREATE NONCLUSTERED INDEX IX_BusinessOutlet_BusinessId ON [dbo].[BusinessOutlet] (BusinessId)
GO