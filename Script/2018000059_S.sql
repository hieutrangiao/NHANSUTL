ALTER TABLE [dbo].[ICShipmentItems]  WITH CHECK ADD  CONSTRAINT [FK_ICShipmentItems_ICStockLots] FOREIGN KEY([FK_ICStockLotID])
REFERENCES [dbo].[ICStockLots] ([ICStockLotID])
GO

ALTER TABLE [dbo].[ICShipmentItems]  WITH CHECK ADD  CONSTRAINT [FK_ICShipmentItems_ICStocks] FOREIGN KEY([FK_ICStockID])
REFERENCES [dbo].[ICStocks] ([ICStockID])
GO

