ALTER TABLE [dbo].[ICShipmentItems]  WITH CHECK ADD  CONSTRAINT [FK_ICShipmentItems_ICProducts] FOREIGN KEY([FK_ICProductID])
REFERENCES [dbo].[ICProducts] ([ICProductID])
GO

ALTER TABLE ARInvoiceItems
ADD ARInvoiceItemProductQty decimal(18,5)
GO


