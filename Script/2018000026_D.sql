insert into GECurrencies
values
(
	0
	, 'Dummy'
	, ''
	, ''
	, N''
	, null
	, null
)
Go

insert into GECurrencies
values
(
	(select MAX(GECurrencyID)+1 from GECurrencies)
	, 'Alive'
	, 'VND'
	, 'VND'
	, N'Đồng chẵn'
	, 3
	, 1
)
Go

insert into GECurrencies
values
(
	(select MAX(GECurrencyID)+1 from GECurrencies)
	, 'Alive'
	, 'USD'
	, 'USD'
	, N'Đô la Mỹ'
	, 3
	, 0
)
Go

insert into GECurrencies
values
(
	(select MAX(GECurrencyID)+1 from GECurrencies)
	, 'Alive'
	, 'EUR'
	, 'EUR'
	, N'Đồng Euro'
	, 3
	, 0
)
Go

select * from GENumberings

insert into GENumberings
values
(
	(select MAX(GENumberingID)+1 from GENumberings)
	, 'Alive'
	, getdate()
	, ''
	, getdate()
	, ''
	, 'SaleOrder'
	, 'ĐBH'
	, 6
	, 1
	, 'Mã chứng từ'
	, '1'
)
Go