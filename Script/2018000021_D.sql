insert into STModules
values
(
	(select MAX(STModuleID)+1 from STModules)
	, 'Alive'
	, 'PT'
	, 'PaymentTerm'
	, N'Điều khoản thanh toán'
	, 1
)
Go

insert into STScreens
values
(
	(select MAX(STScreenID)+1 from STScreens)
	, 'Alive'
	, 'DMPT100'
	, 'guiDMPT100'
	, N'Thông tin'
	, (select STModuleID from STModules where STModuleName = N'PaymentTerm' and AAStatus = 'Alive')
	, 'DM'
	, 1
	, 1
)
Go

insert into STScreens
values
(
	(select MAX(STScreenID)+1 from STScreens)
	, 'Alive'
	, 'SMPT100'
	, 'guiSMPT100'
	, N'Thông tin'
	, (select STModuleID from STModules where STModuleName = N'PaymentTerm' and AAStatus = 'Alive')
	, 'DM'
	, 1
	, 1
)
Go

