insert into ADConfigValues
values
(
	(select MAX(ADConfigValueID)+1 from ADConfigValues)
	, 'Alive'
	, GETDATE()
	, ''
	, GETDATE()
	, ''
	, 'PaymentTermItemPaymentTypeDeposit'
	, 'PaymentTermItemPaymentType'
	, 'Deposit'
	, N'Đặt cọc'
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
	, 'PaymentTermItemPaymentTypePayment'
	, 'PaymentTermItemPaymentType'
	, 'Payment'
	, N'Thanh toán'
	, 2
	, 1
)
Go