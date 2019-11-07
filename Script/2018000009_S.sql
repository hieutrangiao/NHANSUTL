INSERT INTO dbo.GELookupTables
(
    GELookupTableID,
    AAStatus,
    GELookupTableName,
    GELookupTableDesc,
    GELookupTableDisplayColumn,
    GELookupTableDisplayColumnCaption
)
VALUES
(   ISNULL((SELECT MAX(GELookupTableID)+1 FROM dbo.GELookupTables),1),   -- GELookupTableID - int
    'Alive',  -- AAStatus - varchar(10)
    'ARCustomers',  -- GELookupTableName - varchar(100)
    N'ARCustomers', -- GELookupTableDesc - nvarchar(255)
    'ARCustomerName',  -- GELookupTableDisplayColumn - varchar(200)
    N'Tên khách hàng'  -- GELookupTableDisplayColumnCaption - nvarchar(255)
    )
GO

INSERT INTO dbo.GELookupTables
(
    GELookupTableID,
    AAStatus,
    GELookupTableName,
    GELookupTableDesc,
    GELookupTableDisplayColumn,
    GELookupTableDisplayColumnCaption
)
VALUES
(   ISNULL((SELECT MAX(GELookupTableID)+1 FROM dbo.GELookupTables),1),   -- GELookupTableID - int
    'Alive',  -- AAStatus - varchar(10)
    'ICProducts',  -- GELookupTableName - varchar(100)
    N'ICProducts', -- GELookupTableDesc - nvarchar(255)
    'ICProductNo',  -- GELookupTableDisplayColumn - varchar(200)
    N'Mã sản phẩm'  -- GELookupTableDisplayColumnCaption - nvarchar(255)
    )