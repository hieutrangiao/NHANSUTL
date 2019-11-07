INSERT INTO dbo.APSuppliers
VALUES
(   0,         -- APSupplierID - int
    'Dummy',        -- AAStatus - varchar(10)
    N'',       -- AACreatedUser - nvarchar(50)
    N'',       -- AAUpdatedUser - nvarchar(50)
    GETDATE(), -- AACreatedDate - datetime
    GETDATE(), -- AAUpdatedDate - datetime
    0,         -- FK_GECurrencyID - int
    N'',       -- APSupplierNo - nvarchar(50)
    N'',       -- APSupplierName - nvarchar(100)
    N'',       -- APSupplierDesc - nvarchar(255)
    1,      -- APSupplierActiveCheck - bit
    '',        -- APSupplierNoOfOldSys - varchar(50)
    NULL,      -- APSupplierPicture - varbinary(max)
    N'',       -- APSupplierTypeCombo - nvarchar(50)
    N'',       -- APSupplierWebsite - nvarchar(100)
    N'',       -- APSupplierContactEmail - nvarchar(100)
    N'',       -- APSupplierContactAddressLine - nvarchar(200)
    N'',       -- APSupplierContactFax - nvarchar(50)
    '',        -- APSupplierContactPhone - varchar(50)
    N'',       -- APSupplierContactCellPhone - nvarchar(256)
    '',        -- APSupplierPaymentMethod - varchar(50)
    '',        -- APSupplierTaxNumber - varchar(50)
    N'',       -- APSupplierBankName - nvarchar(250)
    '',        -- APSupplierBankCode - varchar(50)
    '',        -- APSupplierBankAccount - varchar(50)
    0          -- FK_GEPaymentTermID - int
)
GO

INSERT INTO dbo.GENumberings
VALUES
(   (SELECT MAX(GENumberingID) + 1 FROM dbo.GENumberings),         -- GENumberingID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    'Hoan Vo',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'Supplier',        -- GENumberingName - varchar(100)
    N'NCC-',       -- GENumberingPrefix - nvarchar(50)
    6,         -- GENumberingLength - int
    1,         -- GENumberingNumber - int
    N'Nhà cung cấp',       -- GENumberingDesc - nvarchar(255)
    1       -- GENumberingPrefixHaveYear - bit
)
GO

INSERT INTO dbo.STToolbars
VALUES
(   (SELECT MAX(STToolbarID) + 1 FROM dbo.STToolbars),   -- STToolbarID - int
    'Alive',  -- AAStatus - varchar(10)
    'fld_barbtnNew',  -- STToolbarName - varchar(100)
    N'Tạo mới', -- STToolbarDesc - nvarchar(255)
    'New',  -- STToolbarTag - varchar(50)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleDesc LIKE N'Nhà cung cấp'),   -- FK_STModuleID - int
    N'Tạo mới', -- STToolbarCaption - nvarchar(255)
    'Action',  -- STToolbarGroup - varchar(50)
    1,   -- STToolbarOrder - int
    0,   -- STToolbarParentID - int
    1 -- STToolbarVisible - bit
)
GO

INSERT INTO dbo.STToolbars
VALUES
(    (SELECT MAX(STToolbarID) + 1 FROM dbo.STToolbars),   -- STToolbarID - int
    'Alive',  -- AAStatus - varchar(10)
    'fld_barbtnEdit',  -- STToolbarName - varchar(100)
    N'Sửa', -- STToolbarDesc - nvarchar(255)
    'Edit',  -- STToolbarTag - varchar(50)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleDesc LIKE N'Nhà cung cấp'),   -- FK_STModuleID - int
    N'Sửa', -- STToolbarCaption - nvarchar(255)
    'Action',  -- STToolbarGroup - varchar(50)
    2,   -- STToolbarOrder - int
    0,   -- STToolbarParentID - int
    1 -- STToolbarVisible - bit
)
GO

INSERT INTO dbo.STToolbars
VALUES
(    (SELECT MAX(STToolbarID) + 1 FROM dbo.STToolbars),   -- STToolbarID - int
    'Alive',  -- AAStatus - varchar(10)
    'fld_barbtnCancel',  -- STToolbarName - varchar(100)
    N'Hủy', -- STToolbarDesc - nvarchar(255)
    'Cancel',  -- STToolbarTag - varchar(50)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleDesc LIKE N'Nhà cung cấp'),   -- FK_STModuleID - int
    N'Hủy', -- STToolbarCaption - nvarchar(255)
    'Action',  -- STToolbarGroup - varchar(50)
    3,   -- STToolbarOrder - int
    0,   -- STToolbarParentID - int
    1 -- STToolbarVisible - bit
)
GO

INSERT INTO dbo.STToolbars
VALUES
(    (SELECT MAX(STToolbarID) + 1 FROM dbo.STToolbars),   -- STToolbarID - int
    'Alive',  -- AAStatus - varchar(10)
    'fld_barbtnSave',  -- STToolbarName - varchar(100)
    N'Lưu', -- STToolbarDesc - nvarchar(255)
    'Save',  -- STToolbarTag - varchar(50)
    (SELECT STModuleID FROM dbo.STModules WHERE STModuleDesc LIKE N'Nhà cung cấp'),   -- FK_STModuleID - int
    N'Lưu', -- STToolbarCaption - nvarchar(255)
    'Action',  -- STToolbarGroup - varchar(50)
    4,   -- STToolbarOrder - int
    0,   -- STToolbarParentID - int
    1 -- STToolbarVisible - bit
)
GO
