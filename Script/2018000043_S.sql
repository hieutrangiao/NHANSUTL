CREATE TABLE [dbo].[ARInvoiceItems](
	[ARInvoiceItemID] [int] NOT NULL,
	[AAStatus] [varchar](10) NULL,
	[AACreatedDate] [datetime] NULL,
	[AACreatedUser] [varchar](100) NULL,
	[AAUpdatedDate] [datetime] NULL,
	[AAUpdatedUser] [varchar](100) NULL,
	[FK_ARInvoiceID] [int] NOT NULL,
	[FK_ICDepartmentID] [int] NULL,
	[FK_ICProductGroupID] [int] NULL,
	[FK_ICProductID] [int] NOT NULL,
	[FK_ICMeasureUnitID] [int] NULL,
	[ARInvoiceItemProductNo] [nvarchar](50) NULL,
	[ARInvoiceItemProductName] [nvarchar](255) NULL,
	[ARInvoiceItemProductDesc] [nvarchar](512) NULL,
	[ARInvoiceItemProductType] [varchar](100) NULL,
	[ARInvoiceItemProductUnitPrice] [decimal](18, 5) NULL,
	[ARInvoiceItemDiscountPerCent] [decimal](18, 5) NULL,
	[ARInvoiceItemDiscountAmount] [decimal](18, 5) NULL,
	[ARInvoiceItemTaxPercent] [decimal](18, 5) NULL,
	[ARInvoiceItemTaxAmount] [decimal](18, 5) NULL,
	[ARInvoiceItemTotalAmount] [decimal](18, 5) NULL,
	[FK_ICShipmentItemID] [int] NULL,
 CONSTRAINT [PK_FAARInvoiceItems] PRIMARY KEY CLUSTERED 
(
	[ARInvoiceItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ARInvoiceItems]  WITH CHECK ADD  CONSTRAINT [FK_ARInvoiceItems_ARInvoices] FOREIGN KEY([FK_ARInvoiceID])
REFERENCES [dbo].[ARInvoices] ([ARInvoiceID])
GO

ALTER TABLE [dbo].[ARInvoiceItems] CHECK CONSTRAINT [FK_ARInvoiceItems_ARInvoices]
GO

ALTER TABLE [dbo].[ARInvoiceItems]  WITH CHECK ADD  CONSTRAINT [FK_ARInvoiceItems_FK_ICMeasureUnits] FOREIGN KEY([FK_ICMeasureUnitID])
REFERENCES [dbo].[ICMeasureUnits] ([ICMeasureUnitID])
GO

ALTER TABLE [dbo].[ARInvoiceItems] CHECK CONSTRAINT [FK_ARInvoiceItems_FK_ICMeasureUnits]
GO

ALTER TABLE [dbo].[ARInvoiceItems]  WITH CHECK ADD  CONSTRAINT [FK_ARInvoices_ICProducts] FOREIGN KEY([FK_ICProductID])
REFERENCES [dbo].[ICProducts] ([ICProductID])
GO

ALTER TABLE [dbo].[ARInvoiceItems] CHECK CONSTRAINT [FK_ARInvoices_ICProducts]
GO


