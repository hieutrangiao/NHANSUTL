CREATE TABLE [dbo].[ICStockLots]
(
	[ICStockLotID] [int] NOT NULL,
	[AAStatus] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AACreatedDate] [datetime] NULL,
	[AAUpdatedDate] [datetime] NULL,
	[ICStockLotNo] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FK_ICProductID] [int] NOT NULL,
	[ICStockLotProductNo] [varchar] (255) NULL,
	[ICStockLotProductName] [VARCHAR] (255) NULL,
	[ICStockLotProductDesc] [VARCHAR] (512) NULL,
	[ICStockLotProductQty] [decimal] (18, 5) NULL,
	[FK_ICDepartmentID] [int] NULL,
	[FK_ICProductGroupID] [int] NULL,
	[FK_ICProductAttributeWoodTypeID] [int] NULL,
	[FK_ICProductAttributeColorID] [int] NULL,
	[ICStockLotProductWoodType] [varchar] (255) NULL,
	[ICStockLotProductColor] [VARCHAR] (255) NULL,
	[ICStockLotProductHeight] [decimal] (18, 5) NULL,
	[ICStockLotProductWidth] [decimal] (18, 5) NULL,
	[ICStockLotProductLength] [decimal] (18, 5) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ICStockLots] ADD CONSTRAINT [PK_MAProductSeries] PRIMARY KEY CLUSTERED ([ICStockLotID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ICStockLots] ADD CONSTRAINT [FK_ICStockLots_ICProducts] FOREIGN KEY ([FK_ICProductID]) REFERENCES [dbo].[ICProducts] ([ICProductID])
GO
