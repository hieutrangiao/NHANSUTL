insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'GEPaymentTermItemDay'
	, N'Số ngày'
	, 'GEPaymentTermItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'GEPaymentTermItemPaymentPercent'
	, N'Thanh toán(%)'
	, 'GEPaymentTermItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'GEPaymentTermItemPaymentTime'
	, N'Thời điểm thanh toán'
	, 'GEPaymentTermItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'GEPaymentTermItemPaymentType'
	, N'Loại thanh toán'
	, 'GEPaymentTermItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'GEPaymentTermNo'
	, N'Mã ĐKTT'
	, 'GEPaymentTerms'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'GEPaymentTermName'
	, N'Tên ĐKTT'
	, 'GEPaymentTerms'
)
Go