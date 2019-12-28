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
    'AW',  -- STModuleNo - varchar(50)
    'ManagerTimeKeeper',  -- STModuleName - varchar(100)
    N'Kết nối máy chấm công', -- STModuleDesc - nvarchar(255)
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
    'DMMT100',  -- STScreenCode - varchar(50)
    'guiDMMT100',  -- STScreenName - varchar(100)
    N'Xác định giờ công', -- STScreenDesc - nvarchar(255)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'ManagerTimeKeeper' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
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
    'DMMT101',  -- STScreenCode - varchar(50)
    'guiDMMT101',  -- STScreenName - varchar(100)
    N'Xem thông tin chấm công', -- STScreenDesc - nvarchar(255)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'ManagerTimeKeeper' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
    'DM',  -- STScreenTag - varchar(10)
    2,   -- STScreenSortOrder - int
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
    'SMPR100',  -- STScreenCode - varchar(50)
    'guiSMPR100',  -- STScreenName - varchar(100)
    N'Thông tin', -- STScreenDesc - nvarchar(255)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'ManagerTimeKeeper' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
    'SM',  -- STScreenTag - varchar(10)
    2,   -- STScreenSortOrder - int
    1 -- STScreenIsVisible - bit
    )