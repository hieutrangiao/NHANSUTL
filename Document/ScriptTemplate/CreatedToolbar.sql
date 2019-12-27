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
(   ISNULL((SELECT MAX(STToolbarID) +1 FROM dbo.STToolbars),1),   -- STToolbarID - int
    'Alive',  -- AAStatus - varchar(10)
    'fld_barbtnNew',  -- STToolbarName - varchar(100)
    N'Tạo mới', -- STToolbarDesc - nvarchar(255)
    'New',  -- STToolbarTag - varchar(50)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'PayRoll' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
    N'Tạo mới', -- STToolbarCaption - nvarchar(255)
    'Action',  -- STToolbarGroup - varchar(50)
    1,   -- STToolbarOrder - int
    0,   -- STToolbarParentID - int
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
(   ISNULL((SELECT MAX(STToolbarID) +1 FROM dbo.STToolbars),1),   -- STToolbarID - int
    'Alive',  -- AAStatus - varchar(10)
    'fld_barbtnEdit',  -- STToolbarName - varchar(100)
    N'Sửa', -- STToolbarDesc - nvarchar(255)
    'Edit',  -- STToolbarTag - varchar(50)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'PayRoll' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
    N'Sửa', -- STToolbarCaption - nvarchar(255)
    'Action',  -- STToolbarGroup - varchar(50)
    2,   -- STToolbarOrder - int
    0,   -- STToolbarParentID - int
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
(   ISNULL((SELECT MAX(STToolbarID) +1 FROM dbo.STToolbars),1),   -- STToolbarID - int
    'Alive',  -- AAStatus - varchar(10)
    'fld_barbtnCancel',  -- STToolbarName - varchar(100)
    N'Hủy', -- STToolbarDesc - nvarchar(255)
    'Cancel',  -- STToolbarTag - varchar(50)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'PayRoll' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
    N'Hủy', -- STToolbarCaption - nvarchar(255)
    'Action',  -- STToolbarGroup - varchar(50)
    3,   -- STToolbarOrder - int
    0,   -- STToolbarParentID - int
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
(   ISNULL((SELECT MAX(STToolbarID) +1 FROM dbo.STToolbars),1),   -- STToolbarID - int
    'Alive',  -- AAStatus - varchar(10)
    'fld_barbtnSave',  -- STToolbarName - varchar(100)
    N'Lưu', -- STToolbarDesc - nvarchar(255)
    'Save',  -- STToolbarTag - varchar(50)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'PayRoll' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
    N'Lưu', -- STToolbarCaption - nvarchar(255)
    'Action',  -- STToolbarGroup - varchar(50)
    4,   -- STToolbarOrder - int
    0,   -- STToolbarParentID - int
    1 -- STToolbarVisible - bit
    )

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
(   ISNULL((SELECT MAX(STToolbarID) +1 FROM dbo.STToolbars),1),   -- STToolbarID - int
    'Alive',  -- AAStatus - varchar(10)
    'fld_barbtnComplete',  -- STToolbarName - varchar(100)
    N'Hoàn tất', -- STToolbarDesc - nvarchar(255)
    'Complete',  -- STToolbarTag - varchar(50)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'PayRoll' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
    N'Hoàn tất', -- STToolbarCaption - nvarchar(255)
    'Action',  -- STToolbarGroup - varchar(50)
    5,   -- STToolbarOrder - int
    0,   -- STToolbarParentID - int
    1 -- STToolbarVisible - bit
    )

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
(   (SELECT MAX(STToolbarFunctionID) + 1 FROM dbo.STToolbarFunctions),  -- STToolbarFunctionID - int
    'Alive', -- AAStatus - varchar(10)
    (SELECT STToolbarID FROM dbo.STToolbars WHERE STToolbarTag = 'Complete' AND FK_STModuleID = (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'PayRoll' AND AAStatus = 'Alive')),  -- FK_STToolbarID - int
    'ActionComplete', -- STToolbarFunctionName - varchar(100)
    'void ActionComplete()', -- STToolbarFunctionFullName - varchar(255)
    'VinaERP.Modules.PayRoll.PayRollModule'  -- STToolbarFunctionClass - varchar(255)
    )