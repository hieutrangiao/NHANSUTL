CREATE TABLE [dbo].[GECurrencies](
	[GECurrencyID] [int] NOT NULL,
	[AAStatus] [varchar](10) NULL,
	[GECurrencyNo] [nvarchar](50) NOT NULL,
	[GECurrencyName] [nvarchar](50) NOT NULL,
	[GECurrencyDesc] [nvarchar](510) NULL,
	[GECurrencyDecimalNumber] [int] NULL,
	[GECurrencyIsDefault] [bit] NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[GECurrencyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO