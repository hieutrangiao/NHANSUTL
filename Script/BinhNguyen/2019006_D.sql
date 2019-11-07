INSERT dbo.STModules ( STModuleID ,
                            AAStatus ,
                            STModuleNo ,
                            STModuleName ,
                            STModuleDesc ,
                            STModuleIsVisible )
VALUES ( (SELECT MAX(STModuleID) FROM dbo.STModules) + 1 , 
         'Alive' , 
         'P' , 
         'Proposal' , 
         N'Báo giá' , 
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
         'DMPS100' ,
         'guiDMPS100' ,  
         N'Thông tin' , 
         (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'Proposal') , 
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
         'SMPS100' , 
         'guiSMPS100' ,
         N'Tìm kiếm' , 
         (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'Proposal') ,
         'SM' , 
         1 ,
         1 
    )
GO