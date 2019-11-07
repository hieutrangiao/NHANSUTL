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

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ======================================================================
-- Created Date : 08/11/2018
-- Author: NghiaPham
-- Procedure Name:[GELookupColumns_GetLookupColumnByLookupTableName]
-- ======================================================================
CREATE PROCEDURE [dbo].[STToolbarFunctions_GetLastToolbarFunctionByModuleIDAndToolbarTagAndGroup]
 @ModuleID INT = NULL,
 @STToolbarTag NVARCHAR(255) = NULL,
 @STToolbarGroup NVARCHAR(255) = null
AS
BEGIN
SET NOCOUNT ON
 SELECT
  * 
 FROM dbo.STToolbarFunctions tf
  INNER JOIN dbo.STToolbars t ON tf.FK_STToolbarID = t.STToolbarID
 WHERE tf.AAStatus = 'Alive'
  AND t.AAStatus = 'Alive'
  AND t.FK_STModuleID = @ModuleID
  AND t.STToolbarTag = @STToolbarTag
  AND t.STToolbarGroup = @STToolbarGroup
END
GO

GO

/***** Object:  StoredProcedure [dbo].[STToolbars_GetAllToolbarByModuleID]    Script Date: 11/7/2018 10:27:01 AM *****/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:  Nghia.Pham
-- Create date: 02/11/2018
-- Description: STToolbars_GetAllToolbarByModuleID
-- =============================================
CREATE PROCEDURE [dbo].[STToolbars_GetAllToolbarByModuleID]
 @STModuleID INT = NULL
AS
BEGIN 
 SET NOCOUNT ON;

    select *
    from [dbo].[STToolbars]
    where AAStatus = 'Alive'
 and  FK_STModuleID = @STModuleID
    and  (STToolbarParentID is null or STToolbarParentID = 0)
END
GO

/***** Object:  StoredProcedure [dbo].[GELookupTables_GetObjectByTableName]    Script Date: 11/4/2018 5:41:40 PM *****/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nghia.Pham
-- Create date: 04/11/2018
-- Description:	[GELookupTables_GetObjectByTableName]
-- =============================================
CREATE PROCEDURE [dbo].[GELookupTables_GetObjectByTableName]
	@LookupTableName NVARCHAR(255)
AS
BEGIN	
	SET NOCOUNT ON;

    SELECT 
	  * 
	FROM dbo.GELookupTables
	WHERE AAStatus = 'Alive'
	  AND GELookupTableName = @LookupTableName
END
