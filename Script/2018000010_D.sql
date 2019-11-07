INSERT INTO dbo.GELookupColumns
(
    GELookupColumnID,
    AAStatus,
    GELookupTableName,
    GELookupColumnFieldName,
    GELookupColumnCaption,
    GELookupColumnWidth,
    GELookupColumnFormatType,
    GELookupColumnFormatString,
    GELookupColumnDesc,
    FK_GELookupTableID
)
VALUES
(   ISNULL((SELECT MAX(GELookupColumnID) + 1 FROM dbo.GELookupColumns),0),   -- GELookupColumnID - int
    'Alive',  -- AAStatus - varchar(50)
    N'ARCustomers', -- GELookupTableName - nvarchar(255)
    N'ARCustomerNo', -- GELookupColumnFieldName - nvarchar(255)
    N'Mã khách hàng', -- GELookupColumnCaption - nvarchar(255)
    50,   -- GELookupColumnWidth - int
    N'', -- GELookupColumnFormatType - nvarchar(255)
    N'', -- GELookupColumnFormatString - nvarchar(255)
    N'', -- GELookupColumnDesc - nvarchar(255)
    1    -- FK_GELookupTableID - int
    )

GO

INSERT INTO dbo.GELookupColumns
(
    GELookupColumnID,
    AAStatus,
    GELookupTableName,
    GELookupColumnFieldName,
    GELookupColumnCaption,
    GELookupColumnWidth,
    GELookupColumnFormatType,
    GELookupColumnFormatString,
    GELookupColumnDesc,
    FK_GELookupTableID
)
VALUES
(   (SELECT MAX(GELookupColumnID) + 1 FROM dbo.GELookupColumns),   -- GELookupColumnID - int
    'Alive',  -- AAStatus - varchar(50)
    N'ARCustomers', -- GELookupTableName - nvarchar(255)
    N'ARCustomerName', -- GELookupColumnFieldName - nvarchar(255)
    N'Tên khách hàng', -- GELookupColumnCaption - nvarchar(255)
    100,   -- GELookupColumnWidth - int
    N'', -- GELookupColumnFormatType - nvarchar(255)
    N'', -- GELookupColumnFormatString - nvarchar(255)
    N'', -- GELookupColumnDesc - nvarchar(255)
    1    -- FK_GELookupTableID - int
    )
