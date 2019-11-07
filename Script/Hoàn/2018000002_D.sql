INSERT INTO dbo.ADConfigValues
VALUES
(   (SELECT MAX(ADConfigValueID) + 1 FROM dbo.ADConfigValues),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    'Admin',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'SupplierTypeAlternative',        -- ADConfigKey - varchar(100)
    'SupplierType',        -- ADConfigKeyGroup - varchar(100)
    N'Alternative',       -- ADConfigKeyValue - nvarchar(200)
    N'Nhà cung cấp phụ',       -- ADConfigText - nvarchar(255)
    1,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
)
GO

INSERT INTO dbo.ADConfigValues
VALUES
(   (SELECT MAX(ADConfigValueID) + 1 FROM dbo.ADConfigValues),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    'Admin',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'SupplierTypeMainSupplier',        -- ADConfigKey - varchar(100)
    'SupplierType',        -- ADConfigKeyGroup - varchar(100)
    N'MainSupplier',       -- ADConfigKeyValue - nvarchar(200)
    N'Nhà cung cấp chính',       -- ADConfigText - nvarchar(255)
    1,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
)
GO

INSERT INTO dbo.ADConfigValues
VALUES
(   (SELECT MAX(ADConfigValueID) + 1 FROM dbo.ADConfigValues),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    'Admin',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'PaymentMethodCash',        -- ADConfigKey - varchar(100)
    'PaymentMethod',        -- ADConfigKeyGroup - varchar(100)
    N'Cash',       -- ADConfigKeyValue - nvarchar(200)
    N'Tiền mặt / Cash',       -- ADConfigText - nvarchar(255)
    1,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
)
GO

INSERT INTO dbo.ADConfigValues
VALUES
(   (SELECT MAX(ADConfigValueID) + 1 FROM dbo.ADConfigValues),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    'Admin',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'PaymentMethodCreditCard',        -- ADConfigKey - varchar(100)
    'PaymentMethod',        -- ADConfigKeyGroup - varchar(100)
    N'CreditCard',       -- ADConfigKeyValue - nvarchar(200)
    N'Thẻ tín dụng / CreditCard',       -- ADConfigText - nvarchar(255)
    1,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
)
GO

INSERT INTO dbo.ADConfigValues
VALUES
(   (SELECT MAX(ADConfigValueID) + 1 FROM dbo.ADConfigValues),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    'Admin',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'PaymentMethodCreditNote',        -- ADConfigKey - varchar(100)
    'PaymentMethod',        -- ADConfigKeyGroup - varchar(100)
    N'CreditNote',       -- ADConfigKeyValue - nvarchar(200)
    N'Phiếu ghi có / CreditNote',       -- ADConfigText - nvarchar(255)
    1,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
)
GO

INSERT INTO dbo.ADConfigValues
VALUES
(   (SELECT MAX(ADConfigValueID) + 1 FROM dbo.ADConfigValues),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    'Admin',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'PaymentMethodGiftVoucher',        -- ADConfigKey - varchar(100)
    'PaymentMethod',        -- ADConfigKeyGroup - varchar(100)
    N'GiftVoucher',       -- ADConfigKeyValue - nvarchar(200)
    N'Voucher cty tặng khách / GiftVoucher',       -- ADConfigText - nvarchar(255)
    1,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
)
GO

INSERT INTO dbo.ADConfigValues
VALUES
(   (SELECT MAX(ADConfigValueID) + 1 FROM dbo.ADConfigValues),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    'Admin',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'PaymentMethodBankTransfer',        -- ADConfigKey - varchar(100)
    'PaymentMethod',        -- ADConfigKeyGroup - varchar(100)
    N'BankTransfer',       -- ADConfigKeyValue - nvarchar(200)
    N'Chuyển khoản / BankTransfer',       -- ADConfigText - nvarchar(255)
    1,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
)
GO

INSERT INTO dbo.ADConfigValues
VALUES
(   (SELECT MAX(ADConfigValueID) + 1 FROM dbo.ADConfigValues),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    'Admin',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'PaymentMethodPaymentOrder',        -- ADConfigKey - varchar(100)
    'PaymentMethod',        -- ADConfigKeyGroup - varchar(100)
    N'PaymentOrder',       -- ADConfigKeyValue - nvarchar(200)
    N'Ủy nhiệm chi / PaymentOrder',       -- ADConfigText - nvarchar(255)
    1,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
)
GO

INSERT INTO dbo.ADConfigValues
VALUES
(   (SELECT MAX(ADConfigValueID) + 1 FROM dbo.ADConfigValues),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    'Admin',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'PaymentMethodCashSec',        -- ADConfigKey - varchar(100)
    'PaymentMethod',        -- ADConfigKeyGroup - varchar(100)
    N'CashSec',       -- ADConfigKeyValue - nvarchar(200)
    N'Sec tiền mặt / CashSec',       -- ADConfigText - nvarchar(255)
    1,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
)
GO

INSERT INTO dbo.ADConfigValues
VALUES
(   (SELECT MAX(ADConfigValueID) + 1 FROM dbo.ADConfigValues),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    'Admin',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'PaymentMethodTransferSec',        -- ADConfigKey - varchar(100)
    'PaymentMethod',        -- ADConfigKeyGroup - varchar(100)
    N'TransferSec',       -- ADConfigKeyValue - nvarchar(200)
    N'Sec chuyển khoản / TransferSec',       -- ADConfigText - nvarchar(255)
    1,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
)
GO

INSERT INTO dbo.ADConfigValues
VALUES
(   (SELECT MAX(ADConfigValueID) + 1 FROM dbo.ADConfigValues),         -- ADConfigValueID - int
    'Alive',        -- AAStatus - varchar(10)
    GETDATE(), -- AACreatedDate - datetime
    'Admin',        -- AACreatedUser - varchar(100)
    GETDATE(), -- AAUpdatedDate - datetime
    '',        -- AAUpdatedUser - varchar(100)
    'PaymentMethodDepositTransfer',        -- ADConfigKey - varchar(100)
    'PaymentMethod',        -- ADConfigKeyGroup - varchar(100)
    N'DepositTransfer',       -- ADConfigKeyValue - nvarchar(200)
    N'Chuyển cọc / DepositTransfer',       -- ADConfigText - nvarchar(255)
    1,         -- ADConfigKeySortOrder - int
    1       -- ADConfigKeyIsActive - bit
)
GO