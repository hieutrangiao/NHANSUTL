CREATE TABLE [dbo].[ARInvoices](
	[ARInvoiceID] [int] NOT NULL,
	[AAStatus] [varchar](10) NULL,
	[AACreatedDate] [datetime] NULL,
	[AACreatedUser] [varchar](100) NULL,
	[AAUpdatedDate] [datetime] NULL,
	[AAUpdatedUser] [varchar](100) NULL,
	[FK_ARCustomerID] [int] NULL,
	[ARInvoiceNo] [nvarchar](50) NOT NULL,
	[ARInvoiceName] [nvarchar](255) NOT NULL,
	[ARInvoiceDesc] [nvarchar](512) NULL,
	[ARInvoiceDate] [datetime] NULL,
	[ARInvoiceDeliveryDate] [datetime] NULL,
	[ARInvoiceDiscountPerCent] [decimal](18, 5) NULL,
	[ARInvoiceDiscountAmount] [decimal](18, 5) NULL,
	[ARInvoiceTaxPercent] [decimal](18, 5) NULL,
	[ARInvoiceTaxAmount] [decimal](18, 5) NULL,
	[ARInvoiceTotalAmount] [decimal](18, 5) NULL,
	[ARInvoiceStatus] [varchar](100) NULL,
	[ARInvoiceCustomerName] [nvarchar](255) NULL,
	[ARInvoiceCustomerPhone] [varchar](20) NULL,
	[ARInvoiceCustomerTaxCode] [varchar](100) NULL,
	[ARInvoiceCustomerAddress] [nvarchar](255) NULL,
	[ARInvoiceCustomerDeliveryName] [nvarchar](255) NULL,
	[ARInvoiceCustomerDeliveryPhone] [varchar](20) NULL,
	[ARInvoiceCustomerDeliveryAddress] [nvarchar](255) NULL,
	[FK_GECurrencyID] [int] NULL,
	[ARInvoiceExchangeRate] [decimal](18, 5) NULL,
	[ARInvoiceSubTotalAmount] [decimal](18, 5) NULL,
	[FK_ARSaleOrderID] [int] NULL,
 CONSTRAINT [PK_FAARInvoices] PRIMARY KEY CLUSTERED 
(
	[ARInvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ARInvoices]  WITH CHECK ADD  CONSTRAINT [FK_ARInvoices_ARCustomers] FOREIGN KEY([FK_ARCustomerID])
REFERENCES [dbo].[ARCustomers] ([ARCustomerID])
GO

ALTER TABLE [dbo].[ARInvoices] CHECK CONSTRAINT [FK_ARInvoices_ARCustomers]
GO

ALTER TABLE [dbo].[ARInvoices]  WITH CHECK ADD  CONSTRAINT [FK_ARInvoices_GECurrencies] FOREIGN KEY([FK_GECurrencyID])
REFERENCES [dbo].[GECurrencies] ([GECurrencyID])
GO

ALTER TABLE [dbo].[ARInvoices] CHECK CONSTRAINT [FK_ARInvoices_GECurrencies]
GO

ALTER TABLE [dbo].[ARInvoices]  WITH CHECK ADD  CONSTRAINT [FK_ARInvoices_ARSaleOrders] FOREIGN KEY([FK_ARSaleOrderID])
REFERENCES [dbo].[ARSaleOrders] ([ARSaleOrderID])
GO

ALTER TABLE [dbo].[ARInvoices] CHECK CONSTRAINT [FK_ARInvoices_ARSaleOrders]
GO
