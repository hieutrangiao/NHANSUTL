insert into GELookupTables
values
(
	(select MAX(GELookupTableID)+1 from GELookupTables)
	, 'Alive'
	, 'HREmployees'
	, 'HREmployees'
	, 'HREmployeeName'
	, N'Tên nhân viên'
)
Go

insert into GELookupTables
values
(
	(select MAX(GELookupTableID)+1 from GELookupTables)
	, 'Alive'
	, 'ARSaleOrders'
	, 'ARSaleOrders'
	, 'ARSaleOrderNo'
	, N'Mã đơn bán hàng'
)
Go

UPDATE dbo.ADUsers
SET FK_HREmployeeID = 1

UPDATE dbo.	HREmployees
SET AAStatus = 'Alive'
WHERE HREmployeeID = 1

select * from ARSaleOrders

select * from HREmployees

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ICShipmentNo'
	, N'Mã chứng từ'
	,'ICShipments'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ICShipmentName'
	, N'Tên chứng từ'
	,'ICShipments'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ICShipmentDesc'
	, N'Mô tả'
	,'ICShipments'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ICShipmentDate'
	, N'Ngày chứng từ'
	,'ICShipments'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ICShipmentStatus'
	, N'Tình trạng'
	,'ICShipments'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ICShipmentDeliveryDate'
	, N'Ngày giao hàng'
	,'ICShipments'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'FK_ARSaleOrderID'
	, N'Mã đơn bán hàng'
	,'ICShipments'
)
Go

select * from ICShipmentItems

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ICShipmentItemProductNo'
	, N'Mã sản phẩm'
	,'ICShipmentItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ICShipmentItemProductDesc'
	, N'Mô tả'
	,'ICShipmentItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ICShipmentItemProductType'
	, N'Loại sản phẩm'
	,'ICShipmentItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ICShipmentItemProductQty'
	, N'Số lượng'
	,'ICShipmentItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'FK_ICStockID'
	, N'Kho'
	,'ICShipmentItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'FK_ICStockLotID'
	, N'Lô'
	,'ICShipmentItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ICShipmentItemProductName'
	, N'Tên sản phẩm'
	,'ICShipmentItems'
)
Go