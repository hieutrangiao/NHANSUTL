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
    'CC',  -- STModuleNo - varchar(50)
    'CompanyConstant',  -- STModuleName - varchar(100)
    N'Cấu hình hệ thống', -- STModuleDesc - nvarchar(255)
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
    'DMCC100',  -- STScreenCode - varchar(50)
    'guiDMCC100',  -- STScreenName - varchar(100)
    N'Thông tin', -- STScreenDesc - nvarchar(255)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'CompanyConstant' AND AAStatus = 'Alive'),   -- FK_STModuleID - int
    'DM',  -- STScreenTag - varchar(10)
    1,   -- STScreenSortOrder - int
    1 -- STScreenIsVisible - bit
    )
GO