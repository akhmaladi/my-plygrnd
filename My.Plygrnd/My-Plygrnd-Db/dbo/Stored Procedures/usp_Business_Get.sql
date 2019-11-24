USE [my-plygrnd]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_Business_Get]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_Business_Get]
GO

CREATE PROCEDURE [dbo].[usp_Business_Get]
AS
	SELECT a.Id, a.[Name], b.Descp AS 'Type', a.PIC 'Owner'
	FROM BusinessInfo a (NOLOCK)
	JOIN ReferenceLibrary b (NOLOCK) ON b.RefType = 'BsnType' AND b.RefCd = a.Type

RETURN 0
