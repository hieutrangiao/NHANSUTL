/****** Object:  StoredProcedure [dbo].[ARSaleOrderItems_GetSaleOrderItemForSaleOrderShipment]    Script Date: 12/2/2018 8:17:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nghia.Pham
-- Create date: 10/11/2018
-- Description:	ARSaleOrderItems_GetSaleOrderItemForSaleOrderShipment
-- =============================================
CREATE PROCEDURE [dbo].[ARSaleOrderItems_GetSaleOrderItemForSaleOrderShipment]
AS
BEGIN
SET NOCOUNT ON
	SELECT
		soi.ARSaleOrderItemProductQty 
		- ISNULL((SELECT SUM(shi.ICShipmentItemProductQty)
				  FROM dbo.ICShipmentItems shi 
				  WHERE shi.AAStatus = 'Alive'
					AND shi.FK_ARSaleOrderItemID = soi.ARSaleOrderItemID),0) AS ARSaleOrderItemProductQty
		,soi.*
	FROM dbo.ARSaleOrderItems soi
		INNER JOIN dbo.ARSaleOrders so ON so.ARSaleOrderID = soi.FK_ARSaleOrderID
	WHERE soi.AAStatus = 'Alive'
		AND so.AAStatus = 'Alive'
		AND so.ARSaleOrderStatus = 'New'
		AND (soi.ARSaleOrderItemProductQty 
			- ISNULL((SELECT SUM(shi.ICShipmentItemProductQty)
				  FROM dbo.ICShipmentItems shi 
				  WHERE shi.AAStatus = 'Alive'
					AND shi.FK_ARSaleOrderItemID = soi.ARSaleOrderItemID),0)
				) > 0
END