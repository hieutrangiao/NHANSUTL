INSERT dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'FK_ARCustomerID',  -- AAColumnAliasName - varchar(200)
    N'Khách hàng', -- AAColumnAliasCaption - nvarchar(255)
    'ARProposals'   -- AATableName - varchar(100)
    )
GO 

INSERT dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'ARProposalNo',  -- AAColumnAliasName - varchar(200)
    N'Mã chứng từ', -- AAColumnAliasCaption - nvarchar(255)
    'ARProposals'   -- AATableName - varchar(100)
    )
GO 

INSERT dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'ARProposalDate',  -- AAColumnAliasName - varchar(200)
    N'Ngày chứng từ', -- AAColumnAliasCaption - nvarchar(255)
    'ARProposals'   -- AATableName - varchar(100)
    )
GO 

INSERT dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'ARProposalName',  -- AAColumnAliasName - varchar(200)
    N'Tên báo giá', -- AAColumnAliasCaption - nvarchar(255)
    'ARProposals'   -- AATableName - varchar(100)
    )
GO 

INSERT dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'ARProposalStatus',  -- AAColumnAliasName - varchar(200)
    N'Tình trạng', -- AAColumnAliasCaption - nvarchar(255)
    'ARProposals'   -- AATableName - varchar(100)
    )
GO 

INSERT dbo.AAColumnAlias
(
    AAColumnAliasID,
    AAStatus,
    AAColumnAliasName,
    AAColumnAliasCaption,
    AATableName
)
VALUES
(   (SELECT MAX(AAColumnAliasID) + 1 FROM dbo.AAColumnAlias),   -- AAColumnAliasID - int
    'Alive',  -- AAStatus - varchar(10)
    'ARProposalTotalAmount',  -- AAColumnAliasName - varchar(200)
    N'Thành tiền', -- AAColumnAliasCaption - nvarchar(255)
    'ARProposals'   -- AATableName - varchar(100)
    )
GO 

