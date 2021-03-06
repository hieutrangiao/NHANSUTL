/****** Object:  StoredProcedure [dbo].[AAColumnAlias_GetColumnAliasByTableName]    Script Date: 11/10/2018 2:42:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nghia.Pham
-- Create date: 10/11/2018
-- Description:	AAColumnAlias_GetColumnAliasByTableName
-- =============================================
CREATE PROCEDURE [dbo].[AAColumnAlias_GetColumnAliasByTableName]
	@TableName varchar(100)

AS
BEGIN
SET NOCOUNT ON
	SELECT
		*
	FROM
		[dbo].[AAColumnAlias]
	WHERE AAStatus = 'Alive'
		AND AATableName = @TableName
END
