USE [my-plygrnd]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_Login]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_Login]
GO

CREATE PROCEDURE [dbo].[usp_Login]
	@Username VARCHAR(200),
	@Password VARCHAR(200)
AS
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM WebUSer (NOLOCK) WHERE UserName = @UserName) RETURN 1

	IF (SELECT [Password] FROM WebUser (NOLOCK) WHERE UserName = @UserName) <> @Password RETURN 1

	RETURN 0
END