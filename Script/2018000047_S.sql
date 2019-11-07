ALTER TABLE ARSaleOrders
ADD FK_HREmployeeID int
GO

ALTER TABLE [dbo].[ARSaleOrders]  WITH CHECK ADD  CONSTRAINT [FK_ARSaleOrders_HREmployees] FOREIGN KEY(FK_HREmployeeID)
REFERENCES [dbo].[HREmployees] (HREmployeeID)
GO

ALTER TABLE ARSaleOrders
ADD FK_HRSellerEmployeeID int
GO

ALTER TABLE [dbo].[ARSaleOrders]  WITH CHECK ADD  CONSTRAINT [FK_ARSaleOrders_HRSellerEmployees] FOREIGN KEY(FK_HRSellerEmployeeID)
REFERENCES [dbo].[HREmployees] (HREmployeeID)
GO

ALTER TABLE ICShipments
ADD FK_HREmployeeID int
GO

ALTER TABLE [dbo].[ICShipments]  WITH CHECK ADD  CONSTRAINT [FK_ICShipments_HREmployees] FOREIGN KEY(FK_HREmployeeID)
REFERENCES [dbo].[HREmployees] (HREmployeeID)
GO
