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
(   ISNULL((SELECT MAX(GELookupTableID)+1 FROM dbo.GELookupTables ),1),   -- GELookupTableID - int
    'Alive',  -- AAStatus - varchar(10)
    'ICMeasureUnits',  -- GELookupTableName - varchar(100)
    N'ICMeasureUnitName', -- GELookupTableDesc - nvarchar(255)
    'ICMeasureUnitName',  -- GELookupTableDisplayColumn - varchar(200)
    N'Đơn vị tính'  -- GELookupTableDisplayColumnCaption - nvarchar(255)
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
(   ISNULL((SELECT MAX(GELookupColumnID)+1 FROM dbo.GELookupColumns ),1),   --  - int
    'Alive',  -- AAStatus - varchar(10)
    (SELECT GELookupTableID FROM GELookupTables WHERE GELookupTableName = 'ICMeasureUnits'),   -- FK_GELookupTableID - int
    'ICMeasureUnits',  -- GELookupTableName - varchar(100)
    'ICMeasureUnitName',  -- GELookupColumnFieldName - varchar(200)
    N'Đơn vị tính', -- GELookupColumnCaption - nvarchar(255)
    0,   -- GELookupColumnWidth - int
    '',  -- GELookupColumnFormatType - varchar(50)
    N'', -- GELookupColumnFormatString - nvarchar(255)
    N''  -- GELookupColumnDesc - nvarchar(255)
    )