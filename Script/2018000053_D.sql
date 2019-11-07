insert into GENumberings
values
(
	(select MAX(GENumberingID)+1 from GENumberings)
	, 'Alive'
	, GETDATE()
	, ''
	, GETDATE()
	, ''
	, 'Invoice'
	, N'HĐBH'
	, 6
	, 1
	, N'Hóa đơn bán hàng'
	, 1
)
Go

update  GENumberings set GENumberingDesc = N'Sản phẩm' where GENumberingName = 'Product'

insert into ADConfigValues
values
(
	(select MAX(ADConfigValueID)+1 from ADConfigValues)
	, 'Alive'
	, GETDATE()
	, ''
	, GETDATE()
	, ''
	, 'SaleOrderItemGrantedFromInventory'
	, 'SaleOrderItemGrantedFrom'
	, 'Inventory'
	, N'Tồn kho'
	, 1
	, 1
)
Go

insert into ADConfigValues
values
(
	(select MAX(ADConfigValueID)+1 from ADConfigValues)
	, 'Alive'
	, GETDATE()
	, ''
	, GETDATE()
	, ''
	, 'SaleOrderItemGrantedFromProduction'
	, 'SaleOrderItemGrantedFrom'
	, 'Production'
	, N'Sản xuất'
	, 2
	, 1
)
Go

insert into ADConfigValues
values
(
	(select MAX(ADConfigValueID)+1 from ADConfigValues)
	, 'Alive'
	, GETDATE()
	, ''
	, GETDATE()
	, ''
	, 'SaleOrderItemGrantedFromPurchase'
	, 'SaleOrderItemGrantedFrom'
	, 'Purchase'
	, N'Mua hàng'
	, 3
	, 1
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderNo'
	, N'Mã chứng từ'
	, 'ARSaleOrders'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderName'
	, N'Tên chứng từ'
	, 'ARSaleOrders'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderDesc'
	, N'Mô tả'
	, 'ARSaleOrders'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderDate'
	, N'Ngày chứng từ'
	, 'ARSaleOrders'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderDeliveryDate'
	, N'Ngày giao hàng'
	, 'ARSaleOrders'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderStatus'
	, N'Tình trạng'
	, 'ARSaleOrders'
)
Go

