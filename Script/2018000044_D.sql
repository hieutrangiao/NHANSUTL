insert into STModules
values
(
	(select MAX(STModuleID)+1 from STModules)
	, 'Alive'
	, 'IV'
	, 'Invoice'
	, N'Hóa đơn bán hàng'
	, 1
)
Go

insert into STScreens
values
(
	(select MAX(STScreenID)+1 from STScreens)
	, 'Alive'
	, 'DMIV100'
	, 'guiDMIV100'
	, N'Thông tin'
	, (select STModuleID from STModules where STModuleName = 'Invoice')
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
	, 'SMIV100'
	, 'guiSMIV100'
	, N'Tìm kiếm'
	, (select STModuleID from STModules where STModuleName = 'Invoice')
	, 'SM'
	, 1
	, 1
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARInvoiceNo'
	, N'Mã chứng từ'
	,'ARInvoices'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARInvoiceName'
	, N'Tên chứng từ'
	,'ARInvoices'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARInvoiceDesc'
	, N'Mô tả'
	,'ARInvoices'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARInvoiceDate'
	, N'Ngày chứng từ'
	,'ARInvoices'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARInvoiceDeliveryDate'
	, N'Ngày giao hàng'
	,'ARInvoices'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARInvoiceStatus'
	, N'Tình trạng'
	,'ARInvoices'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARInvoiceItemProductNo'
	, N'Mã sản phẩm'
	,'ARInvoiceItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARInvoiceItemProductName'
	, N'Tên sản phẩm'
	,'ARInvoiceItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARInvoiceItemProductDesc'
	, N'Mô tả'
	,'ARInvoiceItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARInvoiceItemProductUnitPrice'
	, N'Đơn giá'
	,'ARInvoiceItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARInvoiceItemDiscountPerCent'
	, N'% chiết khấu'
	,'ARInvoiceItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARInvoiceItemDiscountAmount'
	, N'Tiền chiết khấu'
	,'ARInvoiceItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARInvoiceItemTaxPercent'
	, N'% thuế'
	,'ARInvoiceItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARInvoiceItemTaxAmount'
	, N'Tiền thuế'
	,'ARInvoiceItems'
)
Go

insert into AAColumnAlias
values
(
	(select MAX(AAColumnAliasID)+1 from AAColumnAlias)
	, 'Alive'
	, 'ARInvoiceItemTotalAmount'
	, N'Thành tiền'
	,'ARInvoiceItems'
)
Go

select * from STToolbars

insert into STToolbars
values
(
	(select MAX(STToolbarID)+1 from STToolbars)
	, 'Alive'
	, 'fld_barbtnNew'
	, N'Tạo mới'
	, 'New'
	, (select STModuleID from STModules where STModuleName = 'Invoice')
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
	, (select STModuleID from STModules where STModuleName = 'Invoice')
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
	, (select STModuleID from STModules where STModuleName = 'Invoice')
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
	, (select STModuleID from STModules where STModuleName = 'Invoice')
	, N'Lưu'
	, 'Action'
	, 4
	, 0
	, 1
)
Go

insert into STToolbars
values
(
	(select MAX(STToolbarID)+1 from STToolbars)
	, 'Alive'
	, 'fld_barbtnNewNormal'
	, N'Thông thường'
	, 'NewNormal'
	, (select STModuleID from STModules where STModuleName = 'Invoice')
	, N'Thông thường'
	, 'Action'
	, 1
	, (select STToolbarID from STToolbars where STToolbarName = 'fld_barbtnNew' and FK_STModuleID = (select STModuleID from STModules where STModuleName = 'Invoice'))
	, 1
)
Go

insert into STToolbarFunctions
values
(
	ISNULL((select MAX(STToolbarFunctionID)+1 from STToolbarFunctions),1)
	, 'Alive'
	, (select STToolbarID from STToolbars where STToolbarName = 'fld_barbtnNewNormal' and FK_STModuleID = (select STModuleID from STModules where STModuleName = 'Invoice'))
	, 'ActionNew'
	, 'Void ActionNew()'
	, 'VinaERP.Modules.Invoice.InvoiceModule'
)
Go