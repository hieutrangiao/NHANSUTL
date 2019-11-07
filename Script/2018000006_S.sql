
/****** Object:  StoredProcedure [dbo].[GEDBUtil_GetPrimaryColumnsByForeignTableName]    Script Date: 11/10/2018 2:38:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nghia.Pham
-- Create date: 10/11/2018
-- Description:	Get primary columns of all foreign columns of a table
-- =============================================
CREATE PROCEDURE [dbo].[GEDBUtil_GetPrimaryColumnsByForeignTableName] 
	-- Add the parameters for the stored procedure here
	@ForeignTableName			nvarchar(128)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT	kcu.COLUMN_NAME		as	ForeignColumnName
		,	tc.TABLE_NAME		as	PrimaryTableName
		,	ccu.COLUMN_NAME		as	PrimaryColumnName
	FROM	INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu																
		INNER JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc	on	kcu.CONSTRAINT_NAME = rc.CONSTRAINT_NAME		
		INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc ON	rc.UNIQUE_CONSTRAINT_NAME = tc.CONSTRAINT_NAME	
		INNER JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu	on	tc.TABLE_NAME = ccu.TABLE_NAME
	WHERE (kcu.TABLE_NAME=@ForeignTableName)        
        AND	(tc.CONSTRAINT_TYPE='PRIMARY KEY')
        AND (ccu.CONSTRAINT_NAME=tc.CONSTRAINT_NAME)        
END
