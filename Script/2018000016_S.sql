/****** Object:  StoredProcedure [dbo].[ICProductAttributes_GetProductAttributeByGroup]    Script Date: 11/11/2018 3:37:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ======================================================================
-- Created Date : 08/11/2018
-- Author: NghiaPham
-- Procedure Name:[ICProductAttributes_GetProductAttributeByGroup]
-- ======================================================================
CREATE PROCEDURE [dbo].[ICProductAttributes_GetProductAttributeByGroup]
	@ProductAttributeByGroup VARCHAR(100) = null
AS
BEGIN
SET NOCOUNT ON
	 SELECT
	  * 
	 FROM dbo.ICProductAttributes
	 WHERE AAStatus = 'Alive'
		AND ICProductAttributeGroup = @ProductAttributeByGroup
END
