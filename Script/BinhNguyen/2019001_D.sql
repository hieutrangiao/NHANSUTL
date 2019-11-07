INSERT dbo.STModules ( STModuleID ,
                            AAStatus ,
                            STModuleNo ,
                            STModuleName ,
                            STModuleDesc ,
                            STModuleIsVisible )
VALUES ( (SELECT MAX(STModuleID) FROM dbo.STModules) + 1 , 
         'Alive' , 
         'CU' , 
         'Customer' , 
         N'Khách hàng' , 
         1 
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
VALUES ( (SELECT MAX(STScreenID) FROM dbo.STScreens) + 1 ,
         'Alive' ,
         'DMCU100' ,
         'guiDMCU100' ,  
         N'Thông tin' , 
         (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'Customer') , 
         'DM' , 
         1 , 
         1  
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
VALUES ( (SELECT MAX(STScreenID) FROM dbo.STScreens) + 1 ,
         'Alive' ,
         'SMCU100' , 
         'guiSMCU100' ,
         N'Tìm kiếm' , 
         (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'Customer') ,
         'SM' , 
         1 ,
         1 
    )
GO 