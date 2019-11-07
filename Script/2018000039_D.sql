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
    'Alive',  -- AAStatus - varchar(10)
    'ARSaleOrderItemProductQty',  -- AAColumnAliasName - varchar(200)
    N'Số lượng', -- AAColumnAliasCaption - nvarchar(255)
    'ARSaleOrderItems'   -- AATableName - varchar(100)
    )