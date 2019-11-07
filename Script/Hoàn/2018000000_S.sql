CREATE TABLE [dbo].[APSuppliers](
	[APSupplierID] [int] NOT NULL,
	[AAStatus] [varchar](10) NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
	[AACreatedDate] [datetime] NULL,
	[AAUpdatedDate] [datetime] NULL,
	[FK_GECurrencyID] [int] NULL,					--loại tiền tệ
	[APSupplierNo] [nvarchar](50) NOT NULL,			--mã ncc
	[APSupplierName] [nvarchar](100) NOT NULL,		--tên ncc
	[APSupplierDesc] [nvarchar](255) NULL,			--Mô tả
	[APSupplierActiveCheck] [bit] NOT NULL,			--Hoạt động
	[APSupplierNoOfOldSys] [varchar](50) NULL,		--Mã hệ thống cũ
	[APSupplierPicture] [varbinary](max) NULL,		--Hình ảnh
	[APSupplierTypeCombo] [nvarchar](50) NULL,		--Loại ncc
	[APSupplierWebsite] [nvarchar](100) NULL,		--website
	[APSupplierContactEmail] [nvarchar](100) NULL,
	[APSupplierContactAddressLine] [nvarchar](200) NOT NULL,	--địa chỉ
	[APSupplierContactFax] [nvarchar](50) NULL,					-- số fax
	[APSupplierContactPhone] [varchar](50) NULL,				--sdt
	[APSupplierContactCellPhone] [nvarchar](256) NULL,			--di động
	[APSupplierPaymentMethod] [varchar](50) NULL,				--phương thức thanh toán
	[APSupplierTaxNumber] [varchar](50) NULL,		--mã số thuế
	[APSupplierBankName] [nvarchar](250) NULL,		--tên ngân hàng
	[APSupplierBankCode] [varchar](50) NULL,		--mã ngân hàng
	[APSupplierBankAccount] [varchar](50) NULL,		--số tk
	[FK_GEPaymentTermID] [int] NULL,				--Điều khoản thanh toán
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[APSupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[APSuppliers] ADD  CONSTRAINT [DF_MASuppliers_MASupplierActiveCheck]  DEFAULT ((1)) FOR [APSupplierActiveCheck]
GO

ALTER TABLE [dbo].[APSuppliers]  WITH NOCHECK ADD  CONSTRAINT [FK_MASuppliers_GECurrencies] FOREIGN KEY([FK_GECurrencyID])
REFERENCES [dbo].[GECurrencies] ([GECurrencyID])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[APSuppliers] CHECK CONSTRAINT [FK_MASuppliers_GECurrencies]
GO

ALTER TABLE [dbo].[APSuppliers]  WITH CHECK ADD  CONSTRAINT [FK_APSuppliers_GEPaymentTerms] FOREIGN KEY([FK_GEPaymentTermID])
REFERENCES [dbo].[GEPaymentTerms] ([GEPaymentTermID])
GO

ALTER TABLE [dbo].[APSuppliers] CHECK CONSTRAINT [FK_APSuppliers_GEPaymentTerms]
GO