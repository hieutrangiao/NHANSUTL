INSERT INTO dbo.STToolbars ( STToolbarID ,
                             AAStatus ,
                             STToolbarName ,
                             STToolbarDesc ,
                             STToolbarTag ,
                             FK_STModuleID ,
                             STToolbarCaption ,
                             STToolbarGroup ,
                             STToolbarOrder ,
                             STToolbarParentID ,
                             STToolbarVisible )
VALUES ( (SELECT MAX(STToolbarID) FROM dbo.STToolbars) + 1 ,   -- STToolbarID - int
         'Alive' ,  -- AAStatus - varchar(10)
         'fld_barbtnApprove' ,  -- STToolbarName - varchar(100)
         N'Duyệt' , -- STToolbarDesc - nvarchar(255)
         'Approve' ,  -- STToolbarTag - varchar(50)
         (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'Proposal' AND AAStatus = 'Alive') ,   -- FK_STModuleID - int
         N'Duyệt' , -- STToolbarCaption - nvarchar(255)
         'Action' ,  -- STToolbarGroup - varchar(50)
         4 ,   -- STToolbarOrder - int
         0 ,   -- STToolbarParentID - int
         1  -- STToolbarVisible - bit
    )
GO 

INSERT dbo.STToolbarFunctions
(
    STToolbarFunctionID,
    AAStatus,
    FK_STToolbarID,
    STToolbarFunctionName,
    STToolbarFunctionFullName,
    STToolbarFunctionClass
)
VALUES
(   (SELECT MAX(STToolbarFunctionID) + 1 FROM dbo.STToolbarFunctions),  -- STToolbarFunctionID - int
    'Alive', -- AAStatus - varchar(10)
    (SELECT STToolbarID FROM dbo.STToolbars WHERE FK_STModuleID = (SELECT STModuleID FROM dbo.STModules WHERE STModuleName = 'Proposal' AND AAStatus = 'Alive') AND STToolbarTag = 'Approve'),  -- FK_STToolbarID - int
    'ActionApprove', -- STToolbarFunctionName - varchar(100)
    'Void ActionApprove()', -- STToolbarFunctionFullName - varchar(255)
    'BOSERP.Modules.Proposal.ProposalModule'  -- STToolbarFunctionClass - varchar(255)
    )