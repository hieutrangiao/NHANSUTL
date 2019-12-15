SELECT * FROM dbo.STModules

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
    'WS',  -- STModuleNo - varchar(50)
    'EmployeeWorkSchedule',  -- STModuleName - varchar(100)
    N'Biến động giảm', -- STModuleDesc - nvarchar(255)
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
    'DMWS100',  -- STScreenCode - varchar(50)
    'guiDMWS100',  -- STScreenName - varchar(100)
    N'Thông tin', -- STScreenDesc - nvarchar(255)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'EmployeeWorkSchedule' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
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
    'SMWS100',  -- STScreenCode - varchar(50)
    'guiSMWS100',  -- STScreenName - varchar(100)
    N'Thông tin', -- STScreenDesc - nvarchar(255)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'EmployeeWorkSchedule' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
    'SM',  -- STScreenTag - varchar(10)
    2,   -- STScreenSortOrder - int
    1 -- STScreenIsVisible - bit
    )