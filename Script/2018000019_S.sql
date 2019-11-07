CREATE TABLE [dbo].[GEPaymentTermItems](
	[GEPaymentTermItemID] [int] NOT NULL,
	[AAStatus] [varchar](10) NULL,
	[AACreatedUser] [varchar](100) NULL,
	[AACreatedDate] [datetime] NULL,
	[AAUpdatedUser] [varchar](100) NULL,
	[AAUpdatedDate] [datetime] NULL,
	[FK_GEPaymentTermID] [int] NULL,
	[GEPaymentTermItemDay] [int] NULL,
	[GEPaymentTermItemPaymentPercent] [int] NULL,
	[GEPaymentTermItemPaymentTime] [varchar](100) NULL,
	[GEPaymentTermItemPaymentType] [nvarchar](100) NULL,
 CONSTRAINT [PK_GEPaymentTermItems] PRIMARY KEY CLUSTERED 
(
	[GEPaymentTermItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[GEPaymentTermItems]  WITH CHECK ADD  CONSTRAINT [FK_GEPaymentTermItemItems_GEPaymentTerms] FOREIGN KEY([FK_GEPaymentTermID])
REFERENCES [dbo].[GEPaymentTerms] ([GEPaymentTermID])
GO

ALTER TABLE [dbo].[GEPaymentTermItems] CHECK CONSTRAINT [FK_GEPaymentTermItemItems_GEPaymentTerms]
GO