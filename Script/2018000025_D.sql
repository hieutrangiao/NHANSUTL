insert into GELookupTables
values
(
	(select MAX(GELookupTableID)+1 from GELookupTables)
	, 'Alive'
	, 'GECurrencies'
	, 'GECurrencies'
	, 'GECurrencyNo'
	, N'Mã loại tiển tệ'
)
Go

select * from ADConfigValues

insert into ADConfigValues
values
(
	(select MAX(ADConfigValueID)+1 from ADConfigValues)
	, 'Alive'
	, GETDATE()
	, ''
	, GETDATE()
	, ''
	, 'PaymentMethodCash'
	, 'PaymentMethod'
	, 'Cash'
	, N'Tiền mặt / Cash'
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
	, 'PaymentMethodCreditCard'
	, 'PaymentMethod'
	, 'CreditCard'
	, N'Thẻ tín dụng / CreditCard'
	, 2
	, 1
)
Go

select * from ARSaleOrderItems

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderItemProductNo'
	, N'Mã sản phẩm'
	, 'ARSaleOrderItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderItemProductName'
	, N'Tên sản phẩm'
	, 'ARSaleOrderItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderItemProductDesc'
	, N'Mô tả'
	, 'ARSaleOrderItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderItemProductUnitPrice'
	, N'Đơn giá'
	, 'ARSaleOrderItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'FK_ICMeasureUnitID'
	, N'Đơn vị tính'
	, 'ARSaleOrderItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderItemDiscountPerCent'
	, N'% chiết khấu'
	, 'ARSaleOrderItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderItemDiscountAmount'
	, N'Tiền chiết khấu'
	, 'ARSaleOrderItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderItemTaxPercent'
	, N'% thuế'
	, 'ARSaleOrderItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderItemTaxAmount'
	, N'Tiền thuế'
	, 'ARSaleOrderItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderItemTotalAmount'
	, N'Thành tiền'
	, 'ARSaleOrderItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderItemGrantedFrom'
	, N'Cấp từ'
	, 'ARSaleOrderItems'
)
Go