INSERT INTO dbo.STToolbars
(
    STToolbarID,
    AAStatus,
    STToolbarName,
    STToolbarDesc,
    STToolbarTag,
    FK_STModuleID,
    STToolbarCaption,
    STToolbarGroup,
    STToolbarOrder,
    STToolbarParentID,
    STToolbarVisible
)
VALUES
(   (SELECT MAX(STToolbarID)+1 FROM dbo.STToolbars),   -- STToolbarID - int
    'Alive',  -- AAStatus - varchar(10)
    'fld_barbtnNewFromManual',  -- STToolbarName - varchar(100)
    N'Tạo mới thông thường', -- STToolbarDesc - nvarchar(255)
    'NewFromManual',  -- STToolbarTag - varchar(50)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'SaleOrderShipment'),   -- FK_STModuleID - int
    N'Thông thường', -- STToolbarCaption - nvarchar(255)
    'Action',  -- STToolbarGroup - varchar(50)
    1,   -- STToolbarOrder - int
    (SELECT STToolbarID FROM dbo.STToolbars WHERE AAStatus = 'Alive' AND  FK_STModuleID = (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'SaleOrderShipment')
		AND STToolbarTag = 'New'),   -- STToolbarParentID - int
    1 -- STToolbarVisible - bit
    )

GO

INSERT INTO dbo.STToolbars
(
    STToolbarID,
    AAStatus,
    STToolbarName,
    STToolbarDesc,
    STToolbarTag,
    FK_STModuleID,
    STToolbarCaption,
    STToolbarGroup,
    STToolbarOrder,
    STToolbarParentID,
    STToolbarVisible
)
VALUES
(   (SELECT MAX(STToolbarID)+1 FROM dbo.STToolbars),   -- STToolbarID - int
    'Alive',  -- AAStatus - varchar(10)
    'fld_barbtnNewFromManual2',  -- STToolbarName - varchar(100)
    N'Tạo mới thông thường', -- STToolbarDesc - nvarchar(255)
    'NewFromManual2',  -- STToolbarTag - varchar(50)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'SaleOrderShipment'),   -- FK_STModuleID - int
    N'Thông thường', -- STToolbarCaption - nvarchar(255)
    'Action',  -- STToolbarGroup - varchar(50)
    1,   -- STToolbarOrder - int
    (SELECT STToolbarID FROM dbo.STToolbars WHERE AAStatus = 'Alive' AND  FK_STModuleID = (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'SaleOrderShipment')
		AND STToolbarTag = 'NewFromManual'),   -- STToolbarParentID - int
    1 -- STToolbarVisible - bit
    )

GO

INSERT INTO dbo.STToolbars
(
    STToolbarID,
    AAStatus,
    STToolbarName,
    STToolbarDesc,
    STToolbarTag,
    FK_STModuleID,
    STToolbarCaption,
    STToolbarGroup,
    STToolbarOrder,
    STToolbarParentID,
    STToolbarVisible
)
VALUES
(   (SELECT MAX(STToolbarID)+1 FROM dbo.STToolbars),   -- STToolbarID - int
    'Alive',  -- AAStatus - varchar(10)
    'fld_barbtnNewFromSaleOrder',  -- STToolbarName - varchar(100)
    N'Tạo mới từ đơn bán hàng', -- STToolbarDesc - nvarchar(255)
    'NewFromSaleOrder',  -- STToolbarTag - varchar(50)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'SaleOrderShipment'),   -- FK_STModuleID - int
    N'Từ đơn bán hàng', -- STToolbarCaption - nvarchar(255)
    'Action',  -- STToolbarGroup - varchar(50)
    1,   -- STToolbarOrder - int
    (SELECT STToolbarID FROM dbo.STToolbars WHERE AAStatus = 'Alive' AND  FK_STModuleID = (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'SaleOrderShipment')
		AND STToolbarTag = 'New'),   -- STToolbarParentID - int
    1 -- STToolbarVisible - bit
    )
GO

INSERT INTO dbo.STToolbarFunctions
(
    STToolbarFunctionID,
    AAStatus,
    FK_STToolbarID,
    STToolbarFunctionName,
    STToolbarFunctionFullName,
    STToolbarFunctionClass
)
VALUES
(   ISNULL((SELECT MAX(STToolbarFunctionID)+1 FROM dbo.STToolbarFunctions),1),  -- STToolbarFunctionID - int
    'Alive', -- AAStatus - varchar(10)
    (SELECT STToolbarID FROM dbo.STToolbars WHERE AAStatus = 'Alive' AND  FK_STModuleID = (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'SaleOrderShipment')
		AND STToolbarTag = 'NewFromManual'),  -- FK_STToolbarID - int
    'NewFromManual', -- STToolbarFunctionName - varchar(100)
    'Void NewFromManual()', -- STToolbarFunctionFullName - varchar(255)
    'VinaERP.Modules.SaleOrderShipment.SaleOrderShipmentModule'  -- STToolbarFunctionClass - varchar(255)
    )

GO


INSERT INTO dbo.STToolbarFunctions
(
    STToolbarFunctionID,
    AAStatus,
    FK_STToolbarID,
    STToolbarFunctionName,
    STToolbarFunctionFullName,
    STToolbarFunctionClass
)
VALUES
(   ISNULL((SELECT MAX(STToolbarFunctionID)+1 FROM dbo.STToolbarFunctions),1),  -- STToolbarFunctionID - int
    'Alive', -- AAStatus - varchar(10)
    (SELECT STToolbarID FROM dbo.STToolbars WHERE AAStatus = 'Alive' AND  FK_STModuleID = (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'SaleOrderShipment')
		AND STToolbarTag = 'NewFromSaleOrder'),  -- FK_STToolbarID - int
    'NewFromSaleOrder', -- STToolbarFunctionName - varchar(100)
    'Void NewFromSaleOrder()', -- STToolbarFunctionFullName - varchar(255)
    'VinaERP.Modules.SaleOrderShipment.SaleOrderShipmentModule'  -- STToolbarFunctionClass - varchar(255)
    )

GO