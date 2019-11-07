INSERT INTO dbo.GENumberings ( GENumberingID ,
                               AAStatus ,
                               AACreatedDate ,
                               AACreatedUser ,
                               AAUpdatedDate ,
                               AAUpdatedUser ,
                               GENumberingName ,
                               GENumberingPrefix ,
                               GENumberingLength ,
                               GENumberingNumber ,
                               GENumberingDesc ,
                               GENumberingPrefixHaveYear )
VALUES ( (SELECT MAX(GENumberingID) FROM dbo.GENumberings) + 1 ,         -- GENumberingID - int
         'Alive' ,        -- AAStatus - varchar(10)
         GETDATE() , -- AACreatedDate - datetime
         '' ,        -- AACreatedUser - varchar(100)
         GETDATE() , -- AAUpdatedDate - datetime
         '' ,        -- AAUpdatedUser - varchar(100)
         'Customer' ,        -- GENumberingName - varchar(100)
         N'KH-' ,       -- GENumberingPrefix - nvarchar(50)
         6 ,         -- GENumberingLength - int
         1 ,         -- GENumberingNumber - int
         N'Khách hàng' ,       -- GENumberingDesc - nvarchar(255)
         1        -- GENumberingPrefixHaveYear - bit
    )