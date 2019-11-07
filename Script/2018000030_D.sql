insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderPaymentTimeAmount'
	, N'Số tiền'
	,'ARSaleOrderPaymentTimes'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderPaymentTimeDate'
	, N'Ngày thanh toán'
	,'ARSaleOrderPaymentTimes'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderPaymentTimePaymentMethod'
	, N'Phương thức thanh toán'
	,'ARSaleOrderPaymentTimes'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderPaymentTimeStatus'
	, N'Tình trạng'
	,'ARSaleOrderPaymentTimes'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'FK_GEPaymentTermID'
	, N'Điều khoản thanh toán'
	,'ARSaleOrderPaymentTimes'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderPaymentTimeDueDate'
	, N'Hạn chốt thanh toán'
	,'ARSaleOrderPaymentTimes'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderPaymentTimePaidAmount'
	, N'Đã thanh toán'
	,'ARSaleOrderPaymentTimes'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderPaymentTimeDueAmount'
	, N'Còn lại'
	,'ARSaleOrderPaymentTimes'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARSaleOrderPaymentTimePaymentType'
	, N'Loại thanh toán'
	,'ARSaleOrderPaymentTimes'
)
Go

insert into GELookupTables
values
(
	(select MAX(GELookupTableID)+1 from GELookupTables)
	, 'Alive'
	, 'GEPaymentTerms'
	, 'GEPaymentTerms'
	, 'GEPaymentTermName'
	, N'Tên điều khoản thanh toán'
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
	, 'SaleOrderStatusNew'
	, 'SaleOrderStatus'
	, 'New'
	, N'Tạo mới'
	, 1
	, 1
)
Go
