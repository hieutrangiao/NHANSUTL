INSERT dbo.ADConfigValues
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
(   (SELECT MAX(ADConfigValueID) + 1 FROM dbo.ADConfigValues),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    '',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'ProposalStatusNew',        -- ADConfigKey - varchar(100)
    'ProposalStatus',        -- ADConfigKeyGroup - varchar(100)
    N'New',       -- ADConfigKeyValue - nvarchar(200)
    N'Tạo mới',       -- ADConfigText - nvarchar(255)
    1,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
    )
GO 

INSERT dbo.ADConfigValues
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
(   (SELECT MAX(ADConfigValueID) + 1 FROM dbo.ADConfigValues),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    '',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'ProposalStatusApproved',        -- ADConfigKey - varchar(100)
    'ProposalStatus',        -- ADConfigKeyGroup - varchar(100)
    N'Approved',       -- ADConfigKeyValue - nvarchar(200)
    N'Đã duyệt',       -- ADConfigText - nvarchar(255)
    2,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
    )
GO 

INSERT dbo.ADConfigValues
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
(   (SELECT MAX(ADConfigValueID) + 1 FROM dbo.ADConfigValues),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    '',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'ProposalPaymentMethodCash',        -- ADConfigKey - varchar(100)
    'ProposalPaymentMethod',        -- ADConfigKeyGroup - varchar(100)
    N'Cash',       -- ADConfigKeyValue - nvarchar(200)
    N'Tiền mặt / Cash',       -- ADConfigText - nvarchar(255)
    1,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
    )
GO 

INSERT dbo.ADConfigValues
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
(   (SELECT MAX(ADConfigValueID) + 1 FROM dbo.ADConfigValues),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    '',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'ProposalPaymentMethodCreditCard',        -- ADConfigKey - varchar(100)
    'ProposalPaymentMethod',        -- ADConfigKeyGroup - varchar(100)
    N'CreditCard',       -- ADConfigKeyValue - nvarchar(200)
    N'Thẻ tín dụng / CreditCard',       -- ADConfigText - nvarchar(255)
    2,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
    )
GO 