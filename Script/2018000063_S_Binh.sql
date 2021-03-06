/****** Object:  StoredProcedure [dbo].[ICShipmentItems_GetShipmentItemForInvoice]    Script Date: 29/05/2019 9:29:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ICShipmentItems_GetShipmentItemForReport]
	@ICShipmentID INT 
AS
BEGIN
SET NOCOUNT ON
	SELECT
		  N'Ngày ' + CONVERT(NVARCHAR(2),DAY(GETDATE())) + N' tháng ' + CONVERT(NVARCHAR(2),MONTH(GETDATE())) + N' năm ' + CONVERT(NVARCHAR(4),YEAR(GETDATE())) AS ICShipmentExportInvoiceDateString
		, CONVERT(NVARCHAR(2),DAY(s.ICShipmentDate)) + '/' + CONVERT(NVARCHAR(2),MONTH(s.ICShipmentDate)) + '/' + CONVERT(NVARCHAR(4),YEAR(s.ICShipmentDate)) AS ICShipmentDateString
		, s.ICShipmentNo AS ICShipmentNo
		, c.ARCustomerName AS ARCustomerName
		, c.ARCustomerContactPhone1 AS ARCustomerContactPhone
		, c.ARCustomerContactAddress AS ARCustomerContactAddress
		, so.ARSaleOrderCustomerDeliveryAddress AS ARSaleOrderCustomerDeliveryAddress
		, e.HREmployeeName AS HRSellerName
		, st.ICStockName AS ICStockName
		, si.ICShipmentItemProductNo
		, si.ICShipmentItemProductName
		, mu.ICMeasureUnitName AS ICMeasureUnitName
		, si.ICShipmentItemProductUnitPrice
		, si.ICShipmentItemProductQty
		, si.ICShipmentItemDiscountAmount
		, si.ICShipmentItemTaxAmount
		, si.ICShipmentItemTotalAmount
		, (SELECT em.HREmployeeName FROM dbo.HREmployees em WHERE em.HREmployeeID = s.FK_HREmployeeID AND em.AAStatus = 'ALive') AS HREmployeeName
	from ICShipmentItems si
		inner join ICShipments s on s.ICShipmentID = si.FK_ICShipmentID
		inner join ARSaleOrders so on so.ARSaleOrderID = si.FK_ARSaleOrderID
		INNER JOIN dbo.ICProducts p ON p.ICProductID = si.FK_ICProductID
		LEFT JOIN dbo.ICMeasureUnits mu ON mu.ICMeasureUnitID = si.FK_ICMeasureUnitID AND mu.AAStatus = 'Alive'
		LEFT JOIN dbo.ARCustomers c ON c.ARCustomerID = so.FK_ARCustomerID AND c.AAStatus = 'Alive'
		LEFT JOIN dbo.HREmployees e ON e.HREmployeeID = so.FK_HRSellerEmployeeID AND e.AAStatus = 'Alive'
		LEFT JOIN dbo.ICStocks st ON st.ICStockID = si.FK_ICStockID AND st.AAStatus = 'Alive'
	where si.AAStatus = 'Alive'
		and s.AAStatus = 'Alive'
		and so.AAStatus = 'Alive'
		and s.ICShipmentID = @ICShipmentID
END
