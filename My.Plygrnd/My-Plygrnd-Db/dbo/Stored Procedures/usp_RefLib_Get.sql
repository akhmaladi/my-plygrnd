USE [my-plygrnd]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_RefLib_Get]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_RefLib_Get]
GO

CREATE PROCEDURE [dbo].[usp_RefLib_Get]
	@RefType VARCHAR(20)
AS
BEGIN
	
	SELECT RefCd, CAST(RefCd AS VARCHAR) + ' : ' + Descp AS 'Descp'
	FROM ReferenceLibrary
	
	RETURN 0
END