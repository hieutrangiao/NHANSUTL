INSERT INTO dbo.STModules
VALUES
(   (SELECT MAX(STModuleID) + 1 FROM dbo.STModules),   -- STModuleID - int
    'Alive',  -- AAStatus - varchar(10)
    'SP',  -- STModuleNo - varchar(50)
    'Supplier',  -- STModuleName - varchar(100)
    N'Nhà cung cấp', -- STModuleDesc - nvarchar(255)
    1 -- STModuleIsVisible - bit
)
GO

INSERT INTO dbo.STScreens
VALUES
(   (SELECT MAX(STScreenID) + 1 FROM dbo.STScreens),   -- STScreenID - int
    'Alive',  -- AAStatus - varchar(10)
    'DMSP100',  -- STScreenCode - varchar(50)
    'guiDMSP100',  -- STScreenName - varchar(100)
    N'Thông tin', -- STScreenDesc - nvarchar(255)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'Supplier'),   -- FK_STModuleID - int
    'DM',  -- STScreenTag - varchar(10)
    1,   -- STScreenSortOrder - int
    1 -- STScreenIsVisible - bit
)
GO

INSERT INTO dbo.STScreens
VALUES
(   (SELECT MAX(STScreenID) + 1 FROM dbo.STScreens),   -- STScreenID - int
    'Alive',  -- AAStatus - varchar(10)
    'SMSP100',  -- STScreenCode - varchar(50)
    'guiSMSP100',  -- STScreenName - varchar(100)
    N'Tìm kiếm', -- STScreenDesc - nvarchar(255)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'Supplier'),   -- FK_STModuleID - int
    'SM',  -- STScreenTag - varchar(10)
    1,   -- STScreenSortOrder - int
    1 -- STScreenIsVisible - bit
)
GO
