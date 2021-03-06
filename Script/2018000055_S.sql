/****** Object:  StoredProcedure [dbo].[ARSaleOrderItems_GetSaleOrderItemForSaleOrderShipment]    Script Date: 12/7/2018 12:06:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nghia.Pham
-- Create date: 10/11/2018
-- Description:	ARSaleOrderItems_GetSaleOrderItemForSaleOrderShipment
-- =============================================
ALTER PROCEDURE [dbo].[ARSaleOrderItems_GetSaleOrderItemForSaleOrderShipment]
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
		, so.ARSaleOrderNo
	FROM dbo.ARSaleOrderItems soi
		INNER JOIN dbo.ARSaleOrders so ON so.ARSaleOrderID = soi.FK_ARSaleOrderID
	WHERE soi.AAStatus = 'Alive'
		AND so.AAStatus = 'Alive'
		AND so.ARSaleOrderStatus = 'Approved'
		AND (soi.ARSaleOrderItemProductQty 
			- ISNULL((SELECT SUM(shi.ICShipmentItemProductQty)
				  FROM dbo.ICShipmentItems shi 
				  WHERE shi.AAStatus = 'Alive'
					AND shi.FK_ARSaleOrderItemID = soi.ARSaleOrderItemID),0)
				) > 0
END