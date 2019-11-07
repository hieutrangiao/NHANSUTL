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
    'ICProductNo',  -- AAColumnAliasName - varchar(200)
    N'Mã sản phẩm', -- AAColumnAliasCaption - nvarchar(255)
    'ICProducts'   -- AATableName - varchar(100)
    )