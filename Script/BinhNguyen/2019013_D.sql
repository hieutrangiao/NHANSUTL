INSERT dbo.STToolbars ( STToolbarID ,
                             AAStatus ,
                             STToolbarName ,
                             STToolbarDesc ,
                             STToolbarTag ,
                             FK_STModuleID ,
                             STToolbarCaption ,
                             STToolbarGroup ,
                             STToolbarOrder ,
                             STToolbarParentID ,
                             STToolbarVisible )
VALUES ( (SELECT MAX(STToolbarID) + 1 FROM dbo.STToolbars) ,   -- STToolbarID - int
         'Alive' ,  -- AAStatus - varchar(10)
         'fld_barbtnPrint' ,  -- STToolbarName - varchar(100)
         N'In' , -- STToolbarDesc - nvarchar(255)
         'Print' ,  -- STToolbarTag - varchar(50)
         (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'SaleOrderShipment') ,   -- FK_STModuleID - int
         N'In' , -- STToolbarCaption - nvarchar(255)
         'Utility' ,  -- STToolbarGroup - varchar(50)
         0 ,   -- STToolbarOrder - int
         0 ,   -- STToolbarParentID - int
         1  -- STToolbarVisible - bit
    )
GO 

INSERT dbo.STToolbarFunctions ( STToolbarFunctionID ,
                                     AAStatus ,
                                     FK_STToolbarID ,
                                     STToolbarFunctionName ,
                                     STToolbarFunctionFullName ,
                                     STToolbarFunctionClass )
VALUES ( (SELECT MAX(STToolbarFunctionID) + 1 FROM dbo.STToolbarFunctions) ,  -- STToolbarFunctionID - int
         'Alive' , -- AAStatus - varchar(10)
         (SELECT STToolbarID FROM dbo.STToolbars WHERE STToolbarTag = 'Print' AND FK_STModuleID = (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'SaleOrderShipment')) ,  -- FK_STToolbarID - int
         'ActionPrint' , -- STToolbarFunctionName - varchar(100)
         'void ActionPrint()' , -- STToolbarFunctionFullName - varchar(255)
         'VinaERP.Modules.SaleOrderShipment.SaleOrderShipmentModule'   -- STToolbarFunctionClass - varchar(255)
    )
GO 