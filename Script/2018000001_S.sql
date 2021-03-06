/****** Object:  StoredProcedure [dbo].[GELookupColumns_GetLookupColumnByLookupTableName]   Script Date: 11/8/2018 8:11:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ======================================================================
-- Created Date : 08/11/2018
-- Author: NghiaPham
-- Procedure Name:[GELookupColumns_GetLookupColumnByLookupTableName]
-- ======================================================================

CREATE PROCEDURE [dbo].[GELookupColumns_GetLookupColumnByLookupTableName]
	@GELookupTableName NVARCHAR(255) = null
AS
BEGIN
SET NOCOUNT ON
	SELECT
		lc.*
	FROM [dbo].[GELookupColumns] lc
		INNER JOIN dbo.GELookupTables lt ON lc.FK_GELookupTableID = lt.GELookupTableID
	WHERE lt.AAStatus='Alive'
		AND lc.AAStatus = 'Alive'
		AND lt.GELookupTableName = @GELookupTableName
			
END