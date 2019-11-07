ALTER TABLE ICShipments
ADD FK_ARCustomerID int
GO

ALTER TABLE [dbo].[ICShipments]  WITH CHECK ADD  CONSTRAINT [FK_ICShipments_ARCustomers] FOREIGN KEY(FK_ARCustomerID)
REFERENCES [dbo].[ARCustomers] (ARCustomerID)
GO