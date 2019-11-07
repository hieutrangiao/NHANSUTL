INSERT INTO dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID)+1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    N'Alive', -- AAStatus - nvarchar(50)
    N'ARSaleOrderItemProductNo', -- AAColumnAliasName - nvarchar(255)
    N'Mã sản phẩm', -- AAColumnAliasCaption - nvarchar(255)
    N'ARSaleOrderItems'  -- AATableName - nvarchar(100)
    )
GO

INSERT INTO dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID)+1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    N'Alive', -- AAStatus - nvarchar(50)
    N'ARSaleOrderItemProductName', -- AAColumnAliasName - nvarchar(255)
    N'Tên sản phẩm', -- AAColumnAliasCaption - nvarchar(255)
    N'ARSaleOrderItems'  -- AATableName - nvarchar(100)
    )
GO

INSERT INTO dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID)+1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    N'Alive', -- AAStatus - nvarchar(50)
    N'ARSaleOrderItemProductDesc', -- AAColumnAliasName - nvarchar(255)
    N'Mô tả', -- AAColumnAliasCaption - nvarchar(255)
    N'ARSaleOrderItems'  -- AATableName - nvarchar(100)
    )