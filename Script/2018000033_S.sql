CREATE TABLE [dbo].[ICStockDocuments]
(
	[ICStockDocumentID] [int] NOT NULL,
	[AAStatus] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AACreatedDate] [datetime] NULL,
	[AACreatedUser] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AAUpdatedDate] [datetime] NULL,
	[AAUpdatedUser] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FK_ICProductID] [int] NOT NULL,
	[FK_ICStockLotID] [int] NOT NULL,
	[FK_ICStockID] [int] NOT NULL,
	[ICStockDocumentNo] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ICStockDocumentName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ICStockDocumentDate] [datetime] NOT NULL,
	[ICStockDocumentType] [varchar] (50) NULL,
	[ICStockDocumentProductNo] [decimal] (18, 5) NULL,
	[ICStockDocumentProductName] [VARCHAR] (255) NULL,
	[ICStockDocumentProductDesc] [VARCHAR] (512) NULL,
	[FK_ICProductAttributeWoodTypeID] [int] NULL,
	[FK_ICProductAttributeColorID] [int] NULL,
	[ICStockDocumentProductWoodType] [varchar] (255) NULL,
	[ICStockDocumentProductColor] [VARCHAR] (255) NULL,
	[ICStockDocumentProductHeight] [decimal] (18, 5) NULL,
	[ICStockDocumentProductWidth] [decimal] (18, 5) NULL,
	[ICStockDocumentProductLength] [decimal] (18, 5) NULL,
	[ICStockDocumentProductQty] [decimal] (18, 5) NULL,
	[ICStockDocumentProductPrice] [decimal] (18, 5) NULL,
	[ICStockDocumentDiscountPerCent] [decimal] (18, 5) NULL,
	[ICStockDocumentDiscountAmount] [decimal] (18, 5) NULL,
	[ICStockDocumentTaxPercent] [decimal] (18, 5) NULL,
	[ICStockDocumentTaxAmount] [decimal] (18, 5) NULL,
	[ICStockDocumentTotalAmount] [decimal] (18, 5) NULL,
	[ICStockDocumentStockLotNo] [NVARCHAR] (50) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ICStockDocuments] ADD CONSTRAINT [PK_ICStockDocuments] PRIMARY KEY CLUSTERED ([ICStockDocumentID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ICStockDocuments] ADD CONSTRAINT [FK_ICStockDocuments_ICProducts] FOREIGN KEY ([FK_ICProductID]) REFERENCES [dbo].[ICProducts] ([ICProductID])
GO
ALTER TABLE [dbo].[ICStockDocuments] ADD CONSTRAINT [FK_ICStockDocuments_ICStocks] FOREIGN KEY ([FK_ICStockID]) REFERENCES [dbo].[ICStocks] ([ICStockID])
GO
ALTER TABLE [dbo].[ICStockDocuments] ADD CONSTRAINT [FK_ICStockDocuments_ICStockLots] FOREIGN KEY ([FK_ICStockID]) REFERENCES [dbo].[ICStockLots] ([ICStockLotID])
GO