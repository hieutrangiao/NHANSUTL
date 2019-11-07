ALTER TABLE ARInvoices
ADD ARInvoiceComment nvarchar(512)
GO

ALTER TABLE ARInvoices
ADD ARInvoiceInternalComment nvarchar(512)
GO

ALTER TABLE ARSaleOrders
ADD ARSaleOrderComment nvarchar(512)
GO

ALTER TABLE ARSaleOrders
ADD ARSaleOrderInternalComment nvarchar(512)
GO

ALTER TABLE ARInvoices
ADD ARInvoiceVATInvoiceNo nvarchar(256)
GO

ALTER TABLE ARInvoices
ADD ARInvoiceVATDocumentType nvarchar(256)
GO

ALTER TABLE ARInvoices
ADD ARInvoiceVATSymbol nvarchar(256)
GO

ALTER TABLE ARInvoices
ADD ARInvoiceVATTemplateNo nvarchar(256)
GO

ALTER TABLE ARInvoices
ADD FK_HREmployeeID int
GO

ALTER TABLE [dbo].[ARInvoices]  WITH CHECK ADD  CONSTRAINT [FK_ARInvoices_HREmployees] FOREIGN KEY(FK_HREmployeeID)
REFERENCES [dbo].[HREmployees] (HREmployeeID)
GO

ALTER TABLE ARInvoices
ADD FK_HRSellerEmployeeID int
GO

ALTER TABLE [dbo].[ARInvoices]  WITH CHECK ADD  CONSTRAINT [FK_ARInvoices_HRSellerEmployees] FOREIGN KEY(FK_HRSellerEmployeeID)
REFERENCES [dbo].[HREmployees] (HREmployeeID)
GO
