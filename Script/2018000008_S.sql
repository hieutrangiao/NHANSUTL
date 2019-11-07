INSERT INTO dbo.STModules
(
    STModuleID,
    AAStatus,
    STModuleNo,
    STModuleName,
    STModuleDesc,
    STModuleIsVisible
)
VALUES
(   ISNULL((SELECT MAX(STModuleID) +1 FROM dbo.STModules),1),   -- STModuleID - int
    'Alive',  -- AAStatus - varchar(10)
    'SO',  -- STModuleNo - varchar(50)
    'SaleOrder',  -- STModuleName - varchar(100)
    N'Đơn bán hàng', -- STModuleDesc - nvarchar(255)
    1 -- STModuleIsVisible - bit
    )

GO
INSERT INTO dbo.STScreens
(
    STScreenID,
    AAStatus,
    STScreenCode,
    STScreenName,
    STScreenDesc,
    FK_STModuleID,
    STScreenTag,
    STScreenSortOrder,
    STScreenIsVisible
)
VALUES
(   ISNULL((SELECT MAX(STScreenID) +1 FROM dbo.STScreens),1),   -- STScreenID - int
    'Alive',  -- AAStatus - varchar(10)
    'DMSO100',  -- STScreenCode - varchar(50)
    'guiDMSO100',  -- STScreenName - varchar(100)
    N'Thông tin', -- STScreenDesc - nvarchar(255)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'SaleOrder' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
    'DM',  -- STScreenTag - varchar(10)
    1,   -- STScreenSortOrder - int
    1 -- STScreenIsVisible - bit
    )
GO

INSERT INTO dbo.STScreens
(
    STScreenID,
    AAStatus,
    STScreenCode,
    STScreenName,
    STScreenDesc,
    FK_STModuleID,
    STScreenTag,
    STScreenSortOrder,
    STScreenIsVisible
)
VALUES
(   ISNULL((SELECT MAX(STScreenID) +1 FROM dbo.STScreens),1),   -- STScreenID - int
    'Alive',  -- AAStatus - varchar(10)
    'SMSO100',  -- STScreenCode - varchar(50)
    'guiSMSO100',  -- STScreenName - varchar(100)
    N'Tìm kiếm', -- STScreenDesc - nvarchar(255)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'SaleOrder' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
    'SM',  -- STScreenTag - varchar(10)
    1,   -- STScreenSortOrder - int
    1 -- STScreenIsVisible - bit
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
    'fld_barbtnNew',  -- STToolbarName - varchar(100)
    N'Tạo mới', -- STToolbarDesc - nvarchar(255)
    'New',  -- STToolbarTag - varchar(50)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'SaleOrder' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
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
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'SaleOrder' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
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
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'SaleOrder' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
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
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'SaleOrder' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
    N'Lưu', -- STToolbarCaption - nvarchar(255)
    'Action',  -- STToolbarGroup - varchar(50)
    4,   -- STToolbarOrder - int
    0,   -- STToolbarParentID - int
    1 -- STToolbarVisible - bit
    )