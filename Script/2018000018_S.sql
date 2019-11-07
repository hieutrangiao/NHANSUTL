CREATE TABLE [dbo].[GEPaymentTerms](
	[GEPaymentTermID] [int] NOT NULL,
	[AAStatus] [varchar](10) NULL,
	[AACreatedUser] [varchar](100) NULL,
	[AACreatedDate] [datetime] NULL,
	[AAUpdatedUser] [varchar](100) NULL,
	[AAUpdatedDate] [datetime] NULL,
	[GEPaymentTermNo] [varchar](50) NOT NULL,
	[GEPaymentTermName] [nvarchar](256) NOT NULL,
	[GEPaymentTermDate] [datetime] NULL,
	[GEPaymentTermDesc] [nvarchar](512) NULL,
	[GEPaymentTermIsActive] [bit] NULL,
 CONSTRAINT [PK_GEPaymentTerms] PRIMARY KEY CLUSTERED 
(
	[GEPaymentTermID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO