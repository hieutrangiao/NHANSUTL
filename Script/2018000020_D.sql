insert into STToolbars
values
(
	(select MAX(STToolbarID)+1 from STToolbars)
	, 'Alive'
	, 'fld_barbtnNew'
	, N'Tạo mới'
	, 'New'
	, (select STModuleID from STModules where AAStatus = 'Alive' and STModuleName = 'PaymentTerm')
	, N'Tạo mới'
	, 'Action'
	, 1
	, 0
	, 1
)
Go

insert into STToolbars
values
(
	(select MAX(STToolbarID)+1 from STToolbars)
	, 'Alive'
	, 'fld_barbtnEdit'
	, N'Sửa'
	, 'Edit'
	, (select STModuleID from STModules where AAStatus = 'Alive' and STModuleName = 'PaymentTerm')
	, N'Sửa'
	, 'Action'
	, 2
	, 0
	, 1
)
Go

insert into STToolbars
values
(
	(select MAX(STToolbarID)+1 from STToolbars)
	, 'Alive'
	, 'fld_barbtnCancel'
	, N'Hủy'
	, 'Cancel'
	, (select STModuleID from STModules where AAStatus = 'Alive' and STModuleName = 'PaymentTerm')
	, N'Hủy'
	, 'Action'
	, 3
	, 0
	, 1
)
Go

insert into STToolbars
values
(
	(select MAX(STToolbarID)+1 from STToolbars)
	, 'Alive'
	, 'fld_barbtnSave'
	, N'Lưu'
	, 'Save'
	, (select STModuleID from STModules where AAStatus = 'Alive' and STModuleName = 'PaymentTerm')
	, N'Lưu'
	, 'Action'
	, 4
	, 0
	, 1
)
Go