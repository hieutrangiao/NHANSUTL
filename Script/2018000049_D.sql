insert into ADConfigValues
values
(
	(select MAX(ADConfigValueID)+1 from ADConfigValues)
	, 'Alive'
	, GETDATE()
	, ''
	, GETDATE()
	, ''
	, 'ShipmentStatusNew'
	, 'ShipmentStatus'
	, 'New'
	, N'Tạo mới'
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
	, 'ShipmentItemProductTypeTemplate'
	, 'ShipmentItemProductType'
	, 'Template'
	, N'Hàng có sẵn'
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
	, 'InvoiceStatusNew'
	, 'InvoiceStatus'
	, 'New'
	, N'Tạo mới'
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
	, 'ShipmentItemProductTypeDesign'
	, 'ShipmentItemProductType'
	, 'Design'
	, N'Hàng thiết kế'
	, 2
	, 1
)
Go

select * from STToolbars

select * from STToolbarFunctions

insert into STToolbars
values
(
	(select MAX(STToolbarID)+1 from STToolbars)
	, 'Alive'
	, 'fld_barbtnNewFromSaleOrederShipment'
	, N'Từ xuất kho bán hàng'
	, 'NewFromSaleOrederShipment'
	, (select STModuleID from STModules where STModuleName = 'Invoice')
	, N'Từ xuất kho bán hàng'
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
	, (select STToolbarID from STToolbars where STToolbarName = 'fld_barbtnNewFromSaleOrederShipment' and FK_STModuleID = (select STModuleID from STModules where STModuleName = 'Invoice'))
	, 'ActionNewFromSaleOrederShipment'
	, 'Void ActionNewFromSaleOrederShipment()'
	, 'VinaERP.Modules.Invoice.InvoiceModule'
)
Go