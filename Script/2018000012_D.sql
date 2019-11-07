
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
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'Product' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
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
    N'Hủy', -- STToolbarDesc - nvarchar(255)
    'Edit',  -- STToolbarTag - varchar(50)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'Product' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
    N'Hủy', -- STToolbarCaption - nvarchar(255)
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
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'Product' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
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
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'Product' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
    N'Lưu', -- STToolbarCaption - nvarchar(255)
    'Action',  -- STToolbarGroup - varchar(50)
    4,   -- STToolbarOrder - int
    0,   -- STToolbarParentID - int
    1 -- STToolbarVisible - bit
    )