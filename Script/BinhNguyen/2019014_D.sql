INSERT dbo.STModules ( STModuleID ,
                            AAStatus ,
                            STModuleNo ,
                            STModuleName ,
                            STModuleDesc ,
                            STModuleIsVisible )
VALUES ( (SELECT MAX(STModuleID) + 1 FROM dbo.STModules) ,   -- STModuleID - int
         'Alive' ,  -- AAStatus - varchar(10)
         'ISS' ,  -- STModuleNo - varchar(50)
         'InventoryStatistics' ,  -- STModuleName - varchar(100)
         N'Tổng hợp nhập xuất tồn' , -- STModuleDesc - nvarchar(255)
         1  -- STModuleIsVisible - bit
    )
GO 

INSERT dbo.STScreens ( STScreenID ,
                            AAStatus ,
                            STScreenCode ,
                            STScreenName ,
                            STScreenDesc ,
                            FK_STModuleID ,
                            STScreenTag ,
                            STScreenSortOrder ,
                            STScreenIsVisible )
VALUES ( (SELECT MAX(STScreenID) + 1 FROM dbo.STScreens) ,   -- STScreenID - int
         'Alive' ,  -- AAStatus - varchar(10)
         'DMISS100' ,  -- STScreenCode - varchar(50)
         'guiDMISS100' ,  -- STScreenName - varchar(100)
         N'Tổng hợp nhập xuất tồn' , -- STScreenDesc - nvarchar(255)
         (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'InventoryStatistics') ,   -- FK_STModuleID - int
         'DM' ,  -- STScreenTag - varchar(10)
         0 ,   -- STScreenSortOrder - int
         1  -- STScreenIsVisible - bit
    )
GO 
