USE [my-plygrnd]
GO

CREATE TABLE [dbo].[ReferenceLibrary]
(
	RefType VARCHAR(20) NOT NULL,
	RefCd INT NOT NULL,
	Descp VARCHAR(200) NOT NULL
)
GO

CREATE NONCLUSTERED INDEX IX_ReferenceLibrary_RefType ON [dbo].[ReferenceLibrary] (RefType)
GO