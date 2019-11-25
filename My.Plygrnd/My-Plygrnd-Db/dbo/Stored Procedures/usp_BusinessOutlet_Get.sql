USE [my-plygrnd]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_BusinessOutlet_Get]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_BusinessOutlet_Get]
GO

CREATE PROCEDURE [dbo].[usp_BusinessOutlet_Get]
	@BusinessId BIGINT
AS
	SELECT Id, BusinessId, BranchId, [Name], [Address], Latitude, Longitude
	FROM BusinessOutlet (NOLOCK)
	WHERE BusinessId = @BusinessId
RETURN 0
