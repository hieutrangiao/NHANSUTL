insert into ADConfigValues
values
(
	(select MAX(ADConfigValueID)+1 from ADConfigValues)
	, 'Alive'
	, GETDATE()
	, ''
	, GETDATE()
	, ''
	, 'SaleOrderStatusApproved'
	, 'SaleOrderStatus'
	, 'Approved'
	, N'Đã duyệt'
	, 2
	, 1
)
Go