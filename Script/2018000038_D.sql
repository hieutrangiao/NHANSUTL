INSERT INTO dbo.GENumberings
(
    GENumberingID,
    AAStatus,
    AACreatedDate,
    AACreatedUser,
    AAUpdatedDate,
    AAUpdatedUser,
    GENumberingName,
    GENumberingPrefix,
    GENumberingLength,
    GENumberingNumber,
    GENumberingDesc,
    GENumberingPrefixHaveYear
)
VALUES
(   (SELECT MAX(GENumberingID)+1 FROM dbo.GENumberings),         -- GENumberingID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    '',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'SaleOrderShipment',        -- GENumberingName - varchar(100)
    N'XKBH-',       -- GENumberingPrefix - nvarchar(50)
    5,         -- GENumberingLength - int
    1,         -- GENumberingNumber - int
    N'Xuất kho bán hàng',       -- GENumberingDesc - nvarchar(255)
    1       -- GENumberingPrefixHaveYear - bit
    )
