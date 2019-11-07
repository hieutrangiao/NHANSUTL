CREATE PROCEDURE [dbo].[ICShipmentItems_GetShipmentItemForInvoice]
AS
BEGIN
SET NOCOUNT ON
	select
		si.ICShipmentItemProductQty 
			- ISNULL((SELECT SUM(ii.ARInvoiceItemProductQty)
				  FROM dbo.ARInvoiceItems ii 
				  WHERE ii.AAStatus = 'Alive'
					AND ii.FK_ICShipmentItemID = si.ICShipmentItemID),0) as ICShipmentItemProductQty
		, si.*
		, so.ARSaleOrderNo
	from ICShipmentItems si
		inner join ICShipments s on s.ICShipmentID = si.FK_ICShipmentID
		inner join ARSaleOrders so on so.ARSaleOrderID = si.FK_ARSaleOrderID
	where si.AAStatus = 'Alive'
		and s.AAStatus = 'Alive'
		and so.AAStatus = 'Alive'
		and s.ICShipmentStatus = 'New'
		and (si.ICShipmentItemProductQty 
				- ISNULL((SELECT SUM(ii.ARInvoiceItemProductQty)
					  FROM dbo.ARInvoiceItems ii 
					  WHERE ii.AAStatus = 'Alive'
						AND ii.FK_ICShipmentItemID = si.ICShipmentItemID),0)
					) > 0
END
GO