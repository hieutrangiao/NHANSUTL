INSERT dbo.AAColumnAlias ( AAColumnAliasID ,
                                AAStatus ,
                                AAColumnAliasName ,
                                AAColumnAliasCaption ,
                                AATableName )
VALUES ( (SELECT MAX(AAColumnAliasID) FROM dbo.AAColumnAlias) + 1 ,   -- AAColumnAliasID - int
         'Alive' ,  -- AAStatus - varchar(10)
         'ARCustomerNo' ,  -- AAColumnAliasName - varchar(200)
         N'Mã khách hàng' , -- AAColumnAliasCaption - nvarchar(255)
         'ARCustomers'    -- AATableName - varchar(100)
    )
GO 
INSERT dbo.AAColumnAlias ( AAColumnAliasID ,
                                AAStatus ,
                                AAColumnAliasName ,
                                AAColumnAliasCaption ,
                                AATableName )
VALUES ( (SELECT MAX(AAColumnAliasID) FROM dbo.AAColumnAlias) + 1 ,   -- AAColumnAliasID - int
         'Alive' ,  -- AAStatus - varchar(10)
         'ARCustomerName' ,  -- AAColumnAliasName - varchar(200)
         N'Tên khách hàng' , -- AAColumnAliasCaption - nvarchar(255)
         'ARCustomers'    -- AATableName - varchar(100)
    )
GO 
INSERT dbo.AAColumnAlias ( AAColumnAliasID ,
                                AAStatus ,
                                AAColumnAliasName ,
                                AAColumnAliasCaption ,
                                AATableName )
VALUES ( (SELECT MAX(AAColumnAliasID) FROM dbo.AAColumnAlias) + 1 ,   -- AAColumnAliasID - int
         'Alive' ,  -- AAStatus - varchar(10)
         'ARCustomerStartDate' ,  -- AAColumnAliasName - varchar(200)
         N'Ngày tạo' , -- AAColumnAliasCaption - nvarchar(255)
         'ARCustomers'    -- AATableName - varchar(100)
    )
GO 
INSERT dbo.AAColumnAlias ( AAColumnAliasID ,
                                AAStatus ,
                                AAColumnAliasName ,
                                AAColumnAliasCaption ,
                                AATableName )
VALUES ( (SELECT MAX(AAColumnAliasID) FROM dbo.AAColumnAlias) + 1 ,   -- AAColumnAliasID - int
         'Alive' ,  -- AAStatus - varchar(10)
         'ARCustomerIDNumber' ,  -- AAColumnAliasName - varchar(200)
         N'CMND' , -- AAColumnAliasCaption - nvarchar(255)
         'ARCustomers'    -- AATableName - varchar(100)
    )
GO 
INSERT dbo.AAColumnAlias ( AAColumnAliasID ,
                                AAStatus ,
                                AAColumnAliasName ,
                                AAColumnAliasCaption ,
                                AATableName )
VALUES ( (SELECT MAX(AAColumnAliasID) FROM dbo.AAColumnAlias) + 1 ,   -- AAColumnAliasID - int
         'Alive' ,  -- AAStatus - varchar(10)
         'ARCustomerGender' ,  -- AAColumnAliasName - varchar(200)
         N'Giới tính' , -- AAColumnAliasCaption - nvarchar(255)
         'ARCustomers'    -- AATableName - varchar(100)
    )
GO 
INSERT dbo.AAColumnAlias ( AAColumnAliasID ,
                                AAStatus ,
                                AAColumnAliasName ,
                                AAColumnAliasCaption ,
                                AATableName )
VALUES ( (SELECT MAX(AAColumnAliasID) FROM dbo.AAColumnAlias) + 1 ,   -- AAColumnAliasID - int
         'Alive' ,  -- AAStatus - varchar(10)
         'ARCustomerContactBirthday' ,  -- AAColumnAliasName - varchar(200)
         N'Ngày sinh' , -- AAColumnAliasCaption - nvarchar(255)
         'ARCustomers'    -- AATableName - varchar(100)
    )
GO 
INSERT dbo.AAColumnAlias ( AAColumnAliasID ,
                                AAStatus ,
                                AAColumnAliasName ,
                                AAColumnAliasCaption ,
                                AATableName )
VALUES ( (SELECT MAX(AAColumnAliasID) FROM dbo.AAColumnAlias) + 1 ,   -- AAColumnAliasID - int
         'Alive' ,  -- AAStatus - varchar(10)
         'ARCustomerContactAddress' ,  -- AAColumnAliasName - varchar(200)
         N'Địa chỉ' , -- AAColumnAliasCaption - nvarchar(255)
         'ARCustomers'    -- AATableName - varchar(100)
    )
GO 
INSERT dbo.AAColumnAlias ( AAColumnAliasID ,
                                AAStatus ,
                                AAColumnAliasName ,
                                AAColumnAliasCaption ,
                                AATableName )
VALUES ( (SELECT MAX(AAColumnAliasID) FROM dbo.AAColumnAlias) + 1 ,   -- AAColumnAliasID - int
         'Alive' ,  -- AAStatus - varchar(10)
         'ARCustomerContactPhone1' ,  -- AAColumnAliasName - varchar(200)
         N'Điện thoại 1' , -- AAColumnAliasCaption - nvarchar(255)
         'ARCustomers'    -- AATableName - varchar(100)
    )
GO 
INSERT dbo.AAColumnAlias ( AAColumnAliasID ,
                                AAStatus ,
                                AAColumnAliasName ,
                                AAColumnAliasCaption ,
                                AATableName )
VALUES ( (SELECT MAX(AAColumnAliasID) FROM dbo.AAColumnAlias) + 1 ,   -- AAColumnAliasID - int
         'Alive' ,  -- AAStatus - varchar(10)
         'ARCustomerContactPhone2' ,  -- AAColumnAliasName - varchar(200)
         N'Điện thoại 2' , -- AAColumnAliasCaption - nvarchar(255)
         'ARCustomers'    -- AATableName - varchar(100)
    )
GO 
GO 
INSERT dbo.AAColumnAlias ( AAColumnAliasID ,
                                AAStatus ,
                                AAColumnAliasName ,
                                AAColumnAliasCaption ,
                                AATableName )
VALUES ( (SELECT MAX(AAColumnAliasID) FROM dbo.AAColumnAlias) + 1 ,   -- AAColumnAliasID - int
         'Alive' ,  -- AAStatus - varchar(10)
         'ARCustomerContactPhone2' ,  -- AAColumnAliasName - varchar(200)
         N'Điện thoại 2' , -- AAColumnAliasCaption - nvarchar(255)
         'ARCustomers'    -- AATableName - varchar(100)
    )
GO 
GO 
INSERT dbo.AAColumnAlias ( AAColumnAliasID ,
                                AAStatus ,
                                AAColumnAliasName ,
                                AAColumnAliasCaption ,
                                AATableName )
VALUES ( (SELECT MAX(AAColumnAliasID) FROM dbo.AAColumnAlias) + 1 ,   -- AAColumnAliasID - int
         'Alive' ,  -- AAStatus - varchar(10)
         'ARCustomerType' ,  -- AAColumnAliasName - varchar(200)
         N'Loại khách hàng' , -- AAColumnAliasCaption - nvarchar(255)
         'ARCustomers'    -- AATableName - varchar(100)
    )
GO 