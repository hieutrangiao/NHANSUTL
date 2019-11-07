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
(   (select MAX(STModuleID)+1 FROM dbo.STModules),   -- STModuleID - int
    'Alive',  -- AAStatus - varchar(10)
    'PD',  -- STModuleNo - varchar(50)
    'Product',  -- STModuleName - varchar(100)
    N'Sản phẩm', -- STModuleDesc - nvarchar(255)
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
(   (SELECT MAX(STScreenID) +1 FROM dbo.STScreens),   -- STScreenID - int
    'Alive',  -- AAStatus - varchar(10)
    'DMPD100',  -- STScreenCode - varchar(50)
    'guiDMPD100',  -- STScreenName - varchar(100)
    N'Thông tin', -- STScreenDesc - nvarchar(255)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'Product' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
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
(   (SELECT MAX(STScreenID) +1 FROM dbo.STScreens),   -- STScreenID - int
    'Alive',  -- AAStatus - varchar(10)
    'SMPD100',  -- STScreenCode - varchar(50)
    'guiSMPD100',  -- STScreenName - varchar(100)
    N'Thông tin', -- STScreenDesc - nvarchar(255)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'Product' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
    'DM',  -- STScreenTag - varchar(10)
    2,   -- STScreenSortOrder - int
    1 -- STScreenIsVisible - bit
    )