CREATE TABLE [dbo].[ICShipments]
(
	[ICShipmentID] [int] NOT NULL,
	[AAStatus] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AACreatedDate] [datetime] NULL,
	[AACreatedUser] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AAUpdatedDate] [datetime] NULL,
	[AAUpdatedUser] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ICShipmentNo] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ICShipmentName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ICShipmentDesc] [nvarchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ICShipmentDate] [datetime] NULL,
	[ICShipmentStatus] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ICShipmentDeliveryDate] [datetime] NULL,
	[FK_ARSaleOrderID] INT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ICShipments] ADD CONSTRAINT [PK_ICShipments] PRIMARY KEY CLUSTERED ([ICShipmentID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ICShipments] ADD CONSTRAINT [FK_ICShipments_ARSaleOrders] FOREIGN KEY ([FK_ARSaleOrderID]) REFERENCES [dbo].[ARSaleOrders] ([ARSaleOrderID])
GO
