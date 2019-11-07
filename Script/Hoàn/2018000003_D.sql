INSERT INTO dbo.AAColumnAlias
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'APSupplierNo',  -- AAColumnAliasName - varchar(200)
    N'Mã nhà cung cấp', -- AAColumnAliasCaption - nvarchar(255)
    'APSuppliers'   -- AATableName - varchar(100)
)
GO

INSERT INTO dbo.AAColumnAlias
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'APSupplierName',  -- AAColumnAliasName - varchar(200)
    N'Tên nhà cung cấp', -- AAColumnAliasCaption - nvarchar(255)
    'APSuppliers'   -- AATableName - varchar(100)
)
GO

INSERT INTO dbo.AAColumnAlias
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'APSupplierDesc',  -- AAColumnAliasName - varchar(200)
    N'Mô tả', -- AAColumnAliasCaption - nvarchar(255)
    'APSuppliers'   -- AATableName - varchar(100)
)
GO

INSERT INTO dbo.AAColumnAlias
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'APSupplierNoOfOldSys',  -- AAColumnAliasName - varchar(200)
    N'Mã hệ thống cũ', -- AAColumnAliasCaption - nvarchar(255)
    'APSuppliers'   -- AATableName - varchar(100)
)
GO

INSERT INTO dbo.AAColumnAlias
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'APSupplierTypeCombo',  -- AAColumnAliasName - varchar(200)
    N'Loại nhà cung cấp', -- AAColumnAliasCaption - nvarchar(255)
    'APSuppliers'   -- AATableName - varchar(100)
)
GO

INSERT INTO dbo.AAColumnAlias
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'APSupplierWebsite',  -- AAColumnAliasName - varchar(200)
    N'Website', -- AAColumnAliasCaption - nvarchar(255)
    'APSuppliers'   -- AATableName - varchar(100)
)
GO

INSERT INTO dbo.AAColumnAlias
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'APSupplierContactAddressLine',  -- AAColumnAliasName - varchar(200)
    N'Địa chỉ', -- AAColumnAliasCaption - nvarchar(255)
    'APSuppliers'   -- AATableName - varchar(100)
)
GO

INSERT INTO dbo.AAColumnAlias
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'APSupplierContactPhone',  -- AAColumnAliasName - varchar(200)
    N'Số điện thoại', -- AAColumnAliasCaption - nvarchar(255)
    'APSuppliers'   -- AATableName - varchar(100)
)
GO