INSERT dbo.ADConfigValues ( ADConfigValueID ,
                                 AAStatus ,
                                 AACreatedDate ,
                                 AACreatedUser ,
                                 AAUpdatedDate ,
                                 AAUpdatedUser ,
                                 ADConfigKey ,
                                 ADConfigKeyGroup ,
                                 ADConfigKeyValue ,
                                 ADConfigText ,
                                 ADConfigKeySortOrder ,
                                 ADConfigKeyIsActive )
VALUES ( (SELECT MAX(ADConfigValueID) FROM dbo.ADConfigValues) + 1 ,         -- ADConfigValueID - int
         'Alive' ,        -- AAStatus - varchar(10)
         GETDATE() , -- AACreatedDate - datetime
         '' ,        -- AACreatedUser - varchar(100)
         GETDATE() , -- AAUpdatedDate - datetime
         '' ,        -- AAUpdatedUser - varchar(100)
         'CustomerTypePersonal' ,        -- ADConfigKey - varchar(100)
         'CustomerType' ,        -- ADConfigKeyGroup - varchar(100)
         N'Personal' ,       -- ADConfigKeyValue - nvarchar(200)
         N'Cá nhân' ,       -- ADConfigText - nvarchar(255)
         0 ,         -- ADConfigKeySortOrder - int
         1        -- ADConfigKeyIsActive - bit
    )
GO 

INSERT dbo.ADConfigValues ( ADConfigValueID ,
                                 AAStatus ,
                                 AACreatedDate ,
                                 AACreatedUser ,
                                 AAUpdatedDate ,
                                 AAUpdatedUser ,
                                 ADConfigKey ,
                                 ADConfigKeyGroup ,
                                 ADConfigKeyValue ,
                                 ADConfigText ,
                                 ADConfigKeySortOrder ,
                                 ADConfigKeyIsActive )
VALUES ( (SELECT MAX(ADConfigValueID) FROM dbo.ADConfigValues) + 1 ,         -- ADConfigValueID - int
         'Alive' ,        -- AAStatus - varchar(10)
         GETDATE() , -- AACreatedDate - datetime
         '' ,        -- AACreatedUser - varchar(100)
         GETDATE() , -- AAUpdatedDate - datetime
         '' ,        -- AAUpdatedUser - varchar(100)
         'CustomerTypeCompany' ,        -- ADConfigKey - varchar(100)
         'CustomerType' ,        -- ADConfigKeyGroup - varchar(100)
         N'Company' ,       -- ADConfigKeyValue - nvarchar(200)
         N'Công ty' ,       -- ADConfigText - nvarchar(255)
         1 ,         -- ADConfigKeySortOrder - int
         1        -- ADConfigKeyIsActive - bit
    )
GO 

INSERT dbo.ADConfigValues ( ADConfigValueID ,
                                 AAStatus ,
                                 AACreatedDate ,
                                 AACreatedUser ,
                                 AAUpdatedDate ,
                                 AAUpdatedUser ,
                                 ADConfigKey ,
                                 ADConfigKeyGroup ,
                                 ADConfigKeyValue ,
                                 ADConfigText ,
                                 ADConfigKeySortOrder ,
                                 ADConfigKeyIsActive )
VALUES ( (SELECT MAX(ADConfigValueID) FROM dbo.ADConfigValues) + 1 ,         -- ADConfigValueID - int
         'Alive' ,        -- AAStatus - varchar(10)
         GETDATE() , -- AACreatedDate - datetime
         '' ,        -- AACreatedUser - varchar(100)
         GETDATE() , -- AAUpdatedDate - datetime
         '' ,        -- AAUpdatedUser - varchar(100)
         'CustomerTypeVip' ,        -- ADConfigKey - varchar(100)
         'CustomerType' ,        -- ADConfigKeyGroup - varchar(100)
         N'VIP' ,       -- ADConfigKeyValue - nvarchar(200)
         N'VIP' ,       -- ADConfigText - nvarchar(255)
         2 ,         -- ADConfigKeySortOrder - int
         1        -- ADConfigKeyIsActive - bit
    )
GO 



--============================================================================================

INSERT dbo.ADConfigValues ( ADConfigValueID ,
                                 AAStatus ,
                                 AACreatedDate ,
                                 AACreatedUser ,
                                 AAUpdatedDate ,
                                 AAUpdatedUser ,
                                 ADConfigKey ,
                                 ADConfigKeyGroup ,
                                 ADConfigKeyValue ,
                                 ADConfigText ,
                                 ADConfigKeySortOrder ,
                                 ADConfigKeyIsActive )
VALUES ( (SELECT MAX(ADConfigValueID) FROM dbo.ADConfigValues) + 1 ,         -- ADConfigValueID - int
         'Alive' ,        -- AAStatus - varchar(10)
         GETDATE() , -- AACreatedDate - datetime
         '' ,        -- AACreatedUser - varchar(100)
         GETDATE() , -- AAUpdatedDate - datetime
         '' ,        -- AAUpdatedUser - varchar(100)
         'CustomerPaymentMethodCash' ,        -- ADConfigKey - varchar(100)
         'CustomerPaymentMethod' ,        -- ADConfigKeyGroup - varchar(100)
         N'Cash' ,       -- ADConfigKeyValue - nvarchar(200)
         N'Tiền mặt / Cash' ,       -- ADConfigText - nvarchar(255)
         0 ,         -- ADConfigKeySortOrder - int
         1        -- ADConfigKeyIsActive - bit
    )
GO 

INSERT dbo.ADConfigValues ( ADConfigValueID ,
                                 AAStatus ,
                                 AACreatedDate ,
                                 AACreatedUser ,
                                 AAUpdatedDate ,
                                 AAUpdatedUser ,
                                 ADConfigKey ,
                                 ADConfigKeyGroup ,
                                 ADConfigKeyValue ,
                                 ADConfigText ,
                                 ADConfigKeySortOrder ,
                                 ADConfigKeyIsActive )
VALUES ( (SELECT MAX(ADConfigValueID) FROM dbo.ADConfigValues) + 1 ,         -- ADConfigValueID - int
         'Alive' ,        -- AAStatus - varchar(10)
         GETDATE() , -- AACreatedDate - datetime
         '' ,        -- AACreatedUser - varchar(100)
         GETDATE() , -- AAUpdatedDate - datetime
         '' ,        -- AAUpdatedUser - varchar(100)
         'CustomerPaymentMethodCreditCard' ,        -- ADConfigKey - varchar(100)
         'CustomerPaymentMethod' ,        -- ADConfigKeyGroup - varchar(100)
         N'CreditCard' ,       -- ADConfigKeyValue - nvarchar(200)
         N'Thẻ tín dụng / CreditCard' ,       -- ADConfigText - nvarchar(255)
         1 ,         -- ADConfigKeySortOrder - int
         1        -- ADConfigKeyIsActive - bit
    )
GO 

--====================================================================

INSERT dbo.ADConfigValues ( ADConfigValueID ,
                                 AAStatus ,
                                 AACreatedDate ,
                                 AACreatedUser ,
                                 AAUpdatedDate ,
                                 AAUpdatedUser ,
                                 ADConfigKey ,
                                 ADConfigKeyGroup ,
                                 ADConfigKeyValue ,
                                 ADConfigText ,
                                 ADConfigKeySortOrder ,
                                 ADConfigKeyIsActive )
VALUES ( (SELECT MAX(ADConfigValueID) FROM dbo.ADConfigValues) + 1 ,         -- ADConfigValueID - int
         'Alive' ,        -- AAStatus - varchar(10)
         GETDATE() , -- AACreatedDate - datetime
         '' ,        -- AACreatedUser - varchar(100)
         GETDATE() , -- AAUpdatedDate - datetime
         '' ,        -- AAUpdatedUser - varchar(100)
         'CustomerGenderMan' ,        -- ADConfigKey - varchar(100)
         'CustomerGender' ,        -- ADConfigKeyGroup - varchar(100)
         N'Man' ,       -- ADConfigKeyValue - nvarchar(200)
         N'Nam' ,       -- ADConfigText - nvarchar(255)
         0 ,         -- ADConfigKeySortOrder - int
         1        -- ADConfigKeyIsActive - bit
    )
GO 

INSERT dbo.ADConfigValues ( ADConfigValueID ,
                                 AAStatus ,
                                 AACreatedDate ,
                                 AACreatedUser ,
                                 AAUpdatedDate ,
                                 AAUpdatedUser ,
                                 ADConfigKey ,
                                 ADConfigKeyGroup ,
                                 ADConfigKeyValue ,
                                 ADConfigText ,
                                 ADConfigKeySortOrder ,
                                 ADConfigKeyIsActive )
VALUES ( (SELECT MAX(ADConfigValueID) FROM dbo.ADConfigValues) + 1 ,         -- ADConfigValueID - int
         'Alive' ,        -- AAStatus - varchar(10)
         GETDATE() , -- AACreatedDate - datetime
         '' ,        -- AACreatedUser - varchar(100)
         GETDATE() , -- AAUpdatedDate - datetime
         '' ,        -- AAUpdatedUser - varchar(100)
         'CustomerGenderWoman' ,        -- ADConfigKey - varchar(100)
         'CustomerGender' ,        -- ADConfigKeyGroup - varchar(100)
         N'Woman' ,       -- ADConfigKeyValue - nvarchar(200)
         N'Nữ' ,       -- ADConfigText - nvarchar(255)
         1 ,         -- ADConfigKeySortOrder - int
         1        -- ADConfigKeyIsActive - bit
    )
GO 

INSERT dbo.ADConfigValues ( ADConfigValueID ,
                                 AAStatus ,
                                 AACreatedDate ,
                                 AACreatedUser ,
                                 AAUpdatedDate ,
                                 AAUpdatedUser ,
                                 ADConfigKey ,
                                 ADConfigKeyGroup ,
                                 ADConfigKeyValue ,
                                 ADConfigText ,
                                 ADConfigKeySortOrder ,
                                 ADConfigKeyIsActive )
VALUES ( (SELECT MAX(ADConfigValueID) FROM dbo.ADConfigValues) + 1 ,         -- ADConfigValueID - int
         'Alive' ,        -- AAStatus - varchar(10)
         GETDATE() , -- AACreatedDate - datetime
         '' ,        -- AACreatedUser - varchar(100)
         GETDATE() , -- AAUpdatedDate - datetime
         '' ,        -- AAUpdatedUser - varchar(100)
         'CustomerGenderOther' ,        -- ADConfigKey - varchar(100)
         'CustomerGender' ,        -- ADConfigKeyGroup - varchar(100)
         N'Other' ,       -- ADConfigKeyValue - nvarchar(200)
         N'Khác' ,       -- ADConfigText - nvarchar(255)
         2 ,         -- ADConfigKeySortOrder - int
         1        -- ADConfigKeyIsActive - bit
    )
GO 

