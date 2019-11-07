ALTER TABLE GEPaymentTerms
ADD FK_HREmployeeID int
GO

ALTER TABLE [dbo].[GEPaymentTerms]  WITH CHECK ADD  CONSTRAINT [FK_GEPaymentTerms_HREmployees] FOREIGN KEY(FK_HREmployeeID)
REFERENCES [dbo].[HREmployees] (HREmployeeID)
GO

