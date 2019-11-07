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
(   (SELECT MAX(STModuleID)+1 FROM dbo.STModules),   -- STModuleID - int
    N'Alive', -- AAStatus - nvarchar(50)
    N'DPT', -- STModuleNo - nvarchar(50)
    N'Department', -- STModuleName - nvarchar(255)
    N'Ngành hàng', -- STModuleDesc - nvarchar(512)
    1 -- STModuleIsVisible - bit
    )
