insert into ADConfigValues
values
(
	(select MAX(ADConfigValueID)+1 from ADConfigValues)
	, 'Alive'
	, GETDATE()
	, ''
	, GETDATE()
	, ''
	, 'PaymentTermItemPaymentTimeIsContract'
	, 'PaymentTermItemPaymentTime'
	, 'IsContract'
	, N'Ngay khi kí hợp đồng'
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
	, 'PaymentTermItemPaymentTimeIsBeforeDelivery'
	, 'PaymentTermItemPaymentTime'
	, 'IsBeforeDelivery'
	, N'Trước khi giao hàng'
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
	, 'PaymentTermItemPaymentTimeIsAfterDelivery'
	, 'PaymentTermItemPaymentTime'
	, 'IsAfterDelivery'
	, N'Sau khi giao hàng'
	, 3
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
	, 'PaymentTermItemPaymentTimeIsInvoice'
	, 'PaymentTermItemPaymentTime'
	, 'IsInvoice'
	, N'Khi có hóa đơn'
	, 4
	, 1
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARInvoiceItemProductQty'
	, N'Số lượng'
	,'ARInvoieItems'
)
Go

