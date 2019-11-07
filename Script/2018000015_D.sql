INSERT INTO dbo.ADConfigValues
(
    ADConfigValueID,
    AAStatus,
    AACreatedDate,
    AACreatedUser,
    AAUpdatedDate,
    AAUpdatedUser,
    ADConfigKey,
    ADConfigKeyGroup,
    ADConfigKeyValue,
    ADConfigText,
    ADConfigKeySortOrder,
    ADConfigKeyIsActive
)
VALUES
(   ISNULL((SELECT MAX(ADConfigValueID)+1 FROM dbo.ADConfigValues),1),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    '',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'VietName',        -- ADConfigKey - varchar(100)
    'ProductOrigin',        -- ADConfigKeyGroup - varchar(100)
    N'ProductOriginVietName',       -- ADConfigKeyValue - nvarchar(200)
    N'Việt Nam',       -- ADConfigText - nvarchar(255)
    1,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
    )
GO
INSERT INTO dbo.ADConfigValues
(
    ADConfigValueID,
    AAStatus,
    AACreatedDate,
    AACreatedUser,
    AAUpdatedDate,
    AAUpdatedUser,
    ADConfigKey,
    ADConfigKeyGroup,
    ADConfigKeyValue,
    ADConfigText,
    ADConfigKeySortOrder,
    ADConfigKeyIsActive
)
VALUES
(   ISNULL((SELECT MAX(ADConfigValueID)+1 FROM dbo.ADConfigValues),1),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    '',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'Japan',        -- ADConfigKey - varchar(100)
    'ProductOrigin',        -- ADConfigKeyGroup - varchar(100)
    N'ProductOriginJapan',       -- ADConfigKeyValue - nvarchar(200)
    N'Nhật Bản',       -- ADConfigText - nvarchar(255)
    2,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
    )
GO

INSERT INTO dbo.ADConfigValues
(
    ADConfigValueID,
    AAStatus,
    AACreatedDate,
    AACreatedUser,
    AAUpdatedDate,
    AAUpdatedUser,
    ADConfigKey,
    ADConfigKeyGroup,
    ADConfigKeyValue,
    ADConfigText,
    ADConfigKeySortOrder,
    ADConfigKeyIsActive
)
VALUES
(   ISNULL((SELECT MAX(ADConfigValueID)+1 FROM dbo.ADConfigValues),1),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    '',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'China',        -- ADConfigKey - varchar(100)
    'ProductOrigin',        -- ADConfigKeyGroup - varchar(100)
    N'ProductOriginChina',       -- ADConfigKeyValue - nvarchar(200)
    N'Trung Quốc',       -- ADConfigText - nvarchar(255)
    2,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
    )