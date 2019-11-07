ALTER TABLE ARSaleOrders
ADD FK_GECurrencyID int
GO

ALTER TABLE [dbo].[ARSaleOrders]  WITH CHECK ADD  CONSTRAINT [FK_ARSaleOrders_GECurrencies] FOREIGN KEY(FK_GECurrencyID)
REFERENCES [dbo].[GECurrencies] (GECurrencyID)
GO

ALTER TABLE ARSaleOrders
ADD FK_GEPaymentTermID int
GO

ALTER TABLE [dbo].[ARSaleOrders]  WITH CHECK ADD  CONSTRAINT [FK_ARSaleOrders_GEPaymentTerms] FOREIGN KEY(FK_GEPaymentTermID)
REFERENCES [dbo].[GEPaymentTerms] (GEPaymentTermID)
GO

ALTER TABLE ARSaleOrders
ADD ARSaleOrderExchangeRate decimal(18,5)
GO

ALTER TABLE [dbo].[ARSaleOrderItems]  WITH CHECK ADD  CONSTRAINT [FK_ARSaleOrders_ICProducts] FOREIGN KEY(FK_ICProductID)
REFERENCES [dbo].[ICProducts] (ICProductID)
GO

ALTER TABLE [dbo].[ARSaleOrderItems]  WITH CHECK ADD  CONSTRAINT [FK_ARSaleOrderItems_FK_ICMeasureUnits] FOREIGN KEY(FK_ICMeasureUnitID)
REFERENCES [dbo].[ICMeasureUnits] (ICMeasureUnitID)
GO

ALTER TABLE ARCustomers
ADD FK_GECurrencyID int
GO

ALTER TABLE [dbo].[ARCustomers]  WITH CHECK ADD  CONSTRAINT [FK_ARCustomers_GECurrencies] FOREIGN KEY(FK_GECurrencyID)
REFERENCES [dbo].[GECurrencies] (GECurrencyID)
GO

ALTER TABLE ARCustomers
ADD FK_GEPaymentTermID int
GO

ALTER TABLE [dbo].[ARCustomers]  WITH CHECK ADD  CONSTRAINT [FK_ARCustomers_GEPaymentTerms] FOREIGN KEY(FK_GEPaymentTermID)
REFERENCES [dbo].[GEPaymentTerms] (GEPaymentTermID)
GO

ALTER TABLE ARCustomers
ADD ARCustomerPaymentMethod varchar(100)
GO

ALTER TABLE ARSaleOrders
ADD ARSaleOrderSubTotalAmount decimal(18,5)
GO