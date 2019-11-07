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
(   (SELECT MAX(GELookupTableID)+1 FROM dbo.GELookupTables),   -- GELookupTableID - int
    'Alive',  -- AAStatus - varchar(10)
    'ICDepartments',  -- GELookupTableName - varchar(100)
    N'ICDepartmentName', -- GELookupTableDesc - nvarchar(255)
    'ICDepartmentName',  -- GELookupTableDisplayColumn - varchar(200)
    N'Ngành hàng'  -- GELookupTableDisplayColumnCaption - nvarchar(255)
    )
GO

INSERT INTO dbo.GELookupColumns
(
    GELookupColumnID,
    AAStatus,
    FK_GELookupTableID,
    GELookupTableName,
    GELookupColumnFieldName,
    GELookupColumnCaption,
    GELookupColumnWidth,
    GELookupColumnFormatType,
    GELookupColumnFormatString,
    GELookupColumnDesc
)
VALUES
(   (SELECT MAX(GELookupColumnID)+1 FROM dbo.GELookupColumns),   -- GELookupColumnID - int
    'Alive',  -- AAStatus - varchar(10)
    (SELECT GELookupTableID FROM dbo.GELookupTables WHERE GELookupTableName = 'ICDepartments'),   -- FK_GELookupTableID - int
    'ICDepartments',  -- GELookupTableName - varchar(100)
    'ICDepartmentName',  -- GELookupColumnFieldName - varchar(200)
    N'Ngành hàng', -- GELookupColumnCaption - nvarchar(255)
    0,   -- GELookupColumnWidth - int
    '',  -- GELookupColumnFormatType - varchar(50)
    N'', -- GELookupColumnFormatString - nvarchar(255)
    N''  -- GELookupColumnDesc - nvarchar(255)
    )