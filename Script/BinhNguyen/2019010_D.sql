INSERT dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'FK_ICProductID',  -- AAColumnAliasName - varchar(200)
    N'Mã sản phẩm', -- AAColumnAliasCaption - nvarchar(255)
    'ARProposalItems'   -- AATableName - varchar(100)
    )
GO 

INSERT dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'ARProposalItemProductName',  -- AAColumnAliasName - varchar(200)
    N'Tên sản phẩm', -- AAColumnAliasCaption - nvarchar(255)
    'ARProposalItems'   -- AATableName - varchar(100)
    )
GO 

INSERT dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'ARProposalItemDesc',  -- AAColumnAliasName - varchar(200)
    N'Mô tả', -- AAColumnAliasCaption - nvarchar(255)
    'ARProposalItems'   -- AATableName - varchar(100)
    )
GO 

INSERT dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'ARProposalItemProductUnitPrice',  -- AAColumnAliasName - varchar(200)
    N'Đơn giá gốc', -- AAColumnAliasCaption - nvarchar(255)
    'ARProposalItems'   -- AATableName - varchar(100)
    )
GO 

INSERT dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'ARProposalItemPrice',  -- AAColumnAliasName - varchar(200)
    N'Đơn giá', -- AAColumnAliasCaption - nvarchar(255)
    'ARProposalItems'   -- AATableName - varchar(100)
    )
GO 

INSERT dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'ARProposalItemDiscountPercent',  -- AAColumnAliasName - varchar(200)
    N'%CK', -- AAColumnAliasCaption - nvarchar(255)
    'ARProposalItems'   -- AATableName - varchar(100)
    )
GO 

INSERT dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'ARProposalItemDiscountAmount',  -- AAColumnAliasName - varchar(200)
    N'Tiền chiết khấu', -- AAColumnAliasCaption - nvarchar(255)
    'ARProposalItems'   -- AATableName - varchar(100)
    )
GO 

INSERT dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'ARProposalItemTaxPercent',  -- AAColumnAliasName - varchar(200)
    N'%Thuế', -- AAColumnAliasCaption - nvarchar(255)
    'ARProposalItems'   -- AATableName - varchar(100)
    )
GO 

INSERT dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'ARProposalItemTaxAmount',  -- AAColumnAliasName - varchar(200)
    N'Tiền thuế', -- AAColumnAliasCaption - nvarchar(255)
    'ARProposalItems'   -- AATableName - varchar(100)
    )
GO 