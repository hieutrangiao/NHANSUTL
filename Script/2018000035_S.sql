CREATE TABLE [dbo].[ICShipmentItems]
(
	[ICShipmentItemID] [int] NOT NULL,
	[AAStatus] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AACreatedDate] [datetime] NULL,
	[AACreatedUser] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AAUpdatedDate] [datetime] NULL,
	[AAUpdatedUser] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FK_ICShipmentID] [int] NULL,
	[FK_ARSaleOrderID] [int] NULL,
	[FK_ARSaleOrderItemID] [int] NULL,
	[FK_ICDepartmentID] [int] NULL,
	[FK_ICProductGroupID] [int] NULL,
	[FK_ICProductID] [int] NOT NULL,
	[FK_ICMeasureUnitID] [int] NULL,
	[ICShipmentItemProductNo] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ICShipmentItemProductName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ICShipmentItemProductDesc] [nvarchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ICShipmentItemProductQty] [nvarchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ICShipmentItemProductType] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FK_ICProductAttributeWoodTypeID] [int] NULL,
	[FK_ICProductAttributeColorID] [int] NULL,
	[ICShipmentItemProductWoodType] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ICShipmentItemProductColor] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ICShipmentItemProductUnitPrice] [decimal] (18, 5) NULL,
	[ICShipmentItemDiscountPerCent] [decimal] (18, 5) NULL,
	[ICShipmentItemDiscountAmount] [decimal] (18, 5) NULL,
	[ICShipmentItemTaxPercent] [decimal] (18, 5) NULL,
	[ICShipmentItemTaxAmount] [decimal] (18, 5) NULL,
	[ICShipmentItemTotalAmount] [decimal] (18, 5) NULL,
	[FK_ICStockLotID] [int] NULL,
	[FK_ICStockID] [int] NULL,
	[ICShipmentItemStockLotNo] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ICShipmentItems] ADD CONSTRAINT [PK_ICShipmentItems] PRIMARY KEY CLUSTERED ([ICShipmentItemID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ICShipmentItems] ADD CONSTRAINT [FK_ICShipmentItems_ICShipments] FOREIGN KEY ([FK_ICShipmentID]) REFERENCES [dbo].[ICShipments] ([ICShipmentID])
GO