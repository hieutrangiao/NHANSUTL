INSERT INTO dbo.ICProductAttributes
(
    ICProductAttributeID,
    AAStatus,
    AACreatedDate,
    AACreatedUser,
    AAUpdatedDate,
    AAUpdatedUser,
    ICProductAttributeGroup,
    ICProductAttributeNo,
    ICProductAttributeName,
    FK_ICProductGroupID,
    ICProductAttributeActiveCheck
)
VALUES
(   0,         -- ICProductAttributeID - int
    'Dummy',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    '',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    '',        -- ICProductAttributeGroup - varchar(50)
    N'',       -- ICProductAttributeNo - nvarchar(50)
    N'',       -- ICProductAttributeName - nvarchar(255)
    0,         -- FK_ICProductGroupID - int
    0       -- ICProductAttributeActiveCheck - bit
    )