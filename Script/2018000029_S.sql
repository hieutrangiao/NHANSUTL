CREATE TABLE [dbo].[ARSaleOrderPaymentTimes](
	[ARSaleOrderPaymentTimeID] [int] NOT NULL,
	[AAStatus] [varchar](10) NULL,
	[FK_ARSaleOrderID] [int] NULL,
	[ARSaleOrderPaymentTimeAmount] [decimal](18, 5) NULL,
	[ARSaleOrderPaymentTimeDate] [datetime] NULL,
	[ARSaleOrderPaymentTimePaymentMethod] [nvarchar](50) NULL,
	[ARSaleOrderPaymentTimeStatus] [nvarchar](50) NULL,
	[FK_GEPaymentTermID] [int] NULL,
	[ARSaleOrderPaymentTimeDueDate] [datetime] NULL,
	[ARSaleOrderPaymentTimePaidAmount] [decimal](18, 5) NULL,
	[ARSaleOrderPaymentTimeDueAmount] [decimal](18, 5) NULL,
	[ARSaleOrderPaymentTimeType] [nvarchar](50) NULL,
	[ARSaleOrderPaymentTimePaymentTermItemPaymentTime] [nvarchar](100) NULL,
	[ARSaleOrderPaymentTimePaymentTermItemDay] [int] NULL,
	[ARSaleOrderPaymentTimePaymentTermItemPercentPayment] [decimal](18, 5) NULL,
	[ARSaleOrderPaymentTimePaymentTermItemPaymentType] [nvarchar](50) NULL,
	[ARSaleOrderPaymentTimePaymentTermItemType] [nvarchar](50) NULL,
	[FK_GEPaymentTermItemID] [int] NULL,
 CONSTRAINT [PK_ARSaleOrderPaymentTimes] PRIMARY KEY CLUSTERED 
(
	[ARSaleOrderPaymentTimeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ARSaleOrderPaymentTimes]  WITH CHECK ADD  CONSTRAINT [FK_ARSaleOrderPaymentTimes_ARSaleOrders] FOREIGN KEY([FK_ARSaleOrderID])
REFERENCES [dbo].[ARSaleOrders] ([ARSaleOrderID])
GO

ALTER TABLE [dbo].[ARSaleOrderPaymentTimes] CHECK CONSTRAINT [FK_ARSaleOrderPaymentTimes_ARSaleOrders]
GO

ALTER TABLE [dbo].[ARSaleOrderPaymentTimes]  WITH CHECK ADD  CONSTRAINT [FK_ARSaleOrderPaymentTimes_GEPaymentTermItems] FOREIGN KEY([FK_GEPaymentTermItemID])
REFERENCES [dbo].[GEPaymentTermItems] ([GEPaymentTermItemID])
GO

ALTER TABLE [dbo].[ARSaleOrderPaymentTimes] CHECK CONSTRAINT [FK_ARSaleOrderPaymentTimes_GEPaymentTermItems]
GO

ALTER TABLE [dbo].[ARSaleOrderPaymentTimes]  WITH CHECK ADD  CONSTRAINT [FK_ARSaleOrderPaymentTimes_GEPaymentTerms] FOREIGN KEY([FK_GEPaymentTermID])
REFERENCES [dbo].[GEPaymentTerms] ([GEPaymentTermID])
GO

ALTER TABLE [dbo].[ARSaleOrderPaymentTimes] CHECK CONSTRAINT [FK_ARSaleOrderPaymentTimes_GEPaymentTerms]
GO