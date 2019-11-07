USE master
GO
DROP DATABASE [VinaERP_Standard]
GO
CREATE DATABASE [VinaERP_Standard]
GO
USE [VinaERP_Standard]
GO
CREATE TABLE [dbo].[AAColumnAlias]
(
	[AAColumnAliasID] [int] NOT NULL,
	[AAStatus] VARCHAR(10) NULL,
	[AAColumnAliasName] VARCHAR(200) NOT NULL,
	[AAColumnAliasCaption] NVARCHAR(255) NOT NULL,
	[AATableName] VARCHAR(100) NOT NULL,
	CONSTRAINT [PK_FAAAColumnAlias] PRIMARY KEY CLUSTERED 
	(
		[AAColumnAliasID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[STModules]
(
	[STModuleID] [int] NOT NULL,
	[AAStatus] VARCHAR(10) NULL,
	[STModuleNo] VARCHAR(50) NOT NULL,
	[STModuleName] VARCHAR(100) NOT NULL,
	[STModuleDesc] NVARCHAR(255) NOT NULL,
	[STModuleIsVisible] BIT NULL,
	CONSTRAINT [PK_FASTModules] PRIMARY KEY CLUSTERED 
	(
		[STModuleID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[STScreens]
(
	[STScreenID] [int] NOT NULL,
	[AAStatus] VARCHAR(10) NULL,
	[STScreenCode] VARCHAR(50) NOT NULL,
	[STScreenName] VARCHAR(100) NOT NULL,
	[STScreenDesc] NVARCHAR(255) NOT NULL,
	[FK_STModuleID] [int] NOT NULL,
	[STScreenTag] VARCHAR(10) NOT NULL,
	[STScreenSortOrder] INT NULL,
	[STScreenIsVisible] BIT NULL,
    CONSTRAINT [PK_FASTScreens] PRIMARY KEY CLUSTERED 
	(
		[STScreenID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[STScreens] ADD CONSTRAINT [FK_STScreens_STModules] FOREIGN KEY ([FK_STModuleID]) REFERENCES [dbo].[STModules] ([STModuleID])
GO
CREATE TABLE [dbo].[STToolbars]
(
	[STToolbarID] [int] NOT NULL,
	[AAStatus] VARCHAR(10) NULL,
	[STToolbarName] VARCHAR(100) NOT NULL,
	[STToolbarDesc] NVARCHAR(255) NOT NULL,
	[STToolbarTag] VARCHAR(50) NOT NULL,
	[FK_STModuleID] [int] NOT NULL,
	[STToolbarCaption] NVARCHAR(255),
	[STToolbarGroup] VARCHAR(50),
	[STToolbarOrder] INT NULL,
	[STToolbarParentID] INT NULL,
	[STToolbarVisible] BIT NULL
	CONSTRAINT [PK_FASTToolbars] PRIMARY KEY CLUSTERED 
	(
		[STToolbarID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[STToolbars] ADD CONSTRAINT [FK_STToolbars_STModules] FOREIGN KEY ([FK_STModuleID]) REFERENCES [dbo].[STModules] ([STModuleID])
GO
CREATE TABLE [dbo].[STToolbarFunctions]
(
	[STToolbarFunctionID] [int] NOT NULL,
	[AAStatus] VARCHAR(10) NULL,
	[FK_STToolbarID] [int] NOT NULL,
	[STToolbarFunctionName] VARCHAR(100) NOT NULL,
	[STToolbarFunctionFullName] VARCHAR(255) NOT NULL,
	[STToolbarFunctionClass] VARCHAR(255) NOT NULL,
	CONSTRAINT [PK_FASTToolbarFunctions] PRIMARY KEY CLUSTERED 
	(
		[STToolbarFunctionID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[STToolbarFunctions] ADD CONSTRAINT [FK_STToolbarFunctions_STToolbars] FOREIGN KEY ([FK_STToolbarID]) REFERENCES [dbo].[STToolbars] ([STToolbarID])
GO

CREATE TABLE [dbo].[GELookupTables]
(
	[GELookupTableID] [int] NOT NULL,
	[AAStatus] VARCHAR(10) NULL,
	[GELookupTableName] VARCHAR(100) NOT NULL,
	[GELookupTableDesc] NVARCHAR(255) NULL,
	[GELookupTableDisplayColumn] VARCHAR(200) NOT NULL,
	[GELookupTableDisplayColumnCaption] NVARCHAR(255) NOT NULL,
	CONSTRAINT [PK_FAGELookupTables] PRIMARY KEY CLUSTERED 
	(
		[GELookupTableID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[GELookupColumns]
(
	[GELookupColumnID] [int] NOT NULL,
	[AAStatus] VARCHAR(10) NULL,
	[FK_GELookupTableID] INT NOT NULL,
	[GELookupTableName] VARCHAR(100) NULL,
	[GELookupColumnFieldName] VARCHAR(200) NOT NULL,
	[GELookupColumnCaption] NVARCHAR(255) NOT NULL,
	[GELookupColumnWidth] INT NULL,
	[GELookupColumnFormatType] VARCHAR(50) NULL,
	[GELookupColumnFormatString] NVARCHAR(255) NULL,
	[GELookupColumnDesc] NVARCHAR(255) NULL
	CONSTRAINT [PK_FAGELookupColumns] PRIMARY KEY CLUSTERED 
	(
		[GELookupColumnID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GELookupColumns] ADD CONSTRAINT [FK_GELookupColumns_GELookupTables] FOREIGN KEY ([FK_GELookupTableID]) REFERENCES [dbo].[GELookupTables] ([GELookupTableID])
GO

CREATE TABLE [dbo].[GENumberings]
(
	[GENumberingID] [int] NOT NULL,
	[AAStatus] VARCHAR(10) NULL,
	[AACreatedDate] DATETIME NULL,
	[AACreatedUser] VARCHAR(100) NULL,
	[AAUpdatedDate] DATETIME NULL,
	[AAUpdatedUser] VARCHAR(100) NULL,
	[GENumberingName] VARCHAR(100) NOT NULL,
	[GENumberingPrefix] NVARCHAR(50) NULL,
	[GENumberingLength] INT NULL,
	[GENumberingNumber] INT NOT NULL,
	[GENumberingDesc] NVARCHAR(255) NULL,
	[GENumberingPrefixHaveYear] BIT NULL,
	CONSTRAINT [PK_FAGENumberings] PRIMARY KEY CLUSTERED 
	(
		[GENumberingID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ADConfigValues]
(
	[ADConfigValueID] [int] NOT NULL,
	[AAStatus] VARCHAR(10) NULL,
	[AACreatedDate] DATETIME NULL,
	[AACreatedUser] VARCHAR(100) NULL,
	[AAUpdatedDate] DATETIME NULL,
	[AAUpdatedUser] VARCHAR(100) NULL,
	[ADConfigKey] VARCHAR(100) NULL,
	[ADConfigKeyGroup] VARCHAR(100) NOT NULL,
	[ADConfigKeyValue] NVARCHAR(200) NOT NULL,
	[ADConfigText] NVARCHAR(255) NOT NULL,
	[ADConfigKeySortOrder] INT NULL,
	[ADConfigKeyIsActive] BIT NOT NULL
	CONSTRAINT [PK_FAADConfigValues] PRIMARY KEY CLUSTERED 
	(
		[ADConfigValueID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ICDepartments]
(
	[ICDepartmentID] [int] NOT NULL,
	[AAStatus] VARCHAR(10) NULL,
	[AACreatedDate] DATETIME NULL,
	[AACreatedUser] VARCHAR(100) NULL,
	[AAUpdatedDate] DATETIME NULL,
	[AAUpdatedUser] VARCHAR(100) NULL,
	[ICDepartmentNo] NVARCHAR(50) NOT NULL,
	[ICDepartmentName] NVARCHAR(255) NOT NULL,
	[ICDepartmentDesc] NVARCHAR(255) NULL,
	[ICDepartmentActiveCheck] BIT NOT NULL
	CONSTRAINT [PK_FAICDepartments] PRIMARY KEY CLUSTERED 
	(
		[ICDepartmentID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ICProductGroups]
(
	[ICProductGroupID] [int] NOT NULL,
	[AAStatus] VARCHAR(10) NULL,
	[AACreatedDate] DATETIME NULL,
	[AACreatedUser] VARCHAR(100) NULL,
	[AAUpdatedDate] DATETIME NULL,
	[AAUpdatedUser] VARCHAR(100) NULL,
	[ICProductGroupNo] NVARCHAR(50) NOT NULL,
	[ICProductGroupName] NVARCHAR(255) NOT NULL,
	[ICProductGroupDesc] NVARCHAR(255) NULL,
	[ICProductGroupParentID] INT NULL,
	[FK_ICDepartmentID] INT NOT NULL,
	[ICDepartmentActiveCheck] BIT NOT NULL
	CONSTRAINT [PK_FAICProductGroups] PRIMARY KEY CLUSTERED 
	(
		[ICProductGroupID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ICProductGroups] ADD CONSTRAINT [FK_ICProductGroups_ICDepartments] FOREIGN KEY ([FK_ICDepartmentID]) REFERENCES [dbo].[ICDepartments] ([ICDepartmentID])
GO

CREATE TABLE [dbo].[ICProductAttributes]
(
	[ICProductAttributeID] [int] NOT NULL,
	[AAStatus] VARCHAR(10) NULL,
	[AACreatedDate] DATETIME NULL,
	[AACreatedUser] VARCHAR(100) NULL,
	[AAUpdatedDate] DATETIME NULL,
	[AAUpdatedUser] VARCHAR(100) NULL,
	[ICProductAttributeGroup] VARCHAR(50) NOT NULL,
	[ICProductAttributeNo] NVARCHAR(50) NOT NULL,
	[ICProductAttributeName] NVARCHAR(255) NULL,
	[FK_ICProductGroupID] INT NOT NULL,
	[ICProductAttributeActiveCheck] BIT NOT NULL
	CONSTRAINT [PK_FAICProductAttributes] PRIMARY KEY CLUSTERED 
	(
		[ICProductAttributeID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ICProductAttributes] ADD CONSTRAINT [FK_ICProductAttributes_ICProductGroups] FOREIGN KEY ([FK_ICProductGroupID]) REFERENCES [dbo].[ICProductGroups] ([ICProductGroupID])
GO
CREATE TABLE [dbo].[ICMeasureUnits]
(
	[ICMeasureUnitID] [int] NOT NULL,
	[AAStatus] [varchar] (10),
	[AACreatedDate] [datetime] NULL,
	[AACreatedUser] [nvarchar] (100) NULL,
	[AAUpdatedDate] [datetime] NULL,
	[AAUpdatedUser] [nvarchar] (100),
	[ICMeasureUnitNo] [nvarchar] (50) NOT NULL,
	[ICMeasureUnitName] [nvarchar] (255) NOT NULL,
	[ICMeasureUnitDesc] [nvarchar] (255) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ICMeasureUnits] ADD CONSTRAINT [PK_ICMeasureUnits] PRIMARY KEY CLUSTERED ([ICMeasureUnitID]) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ICProducts]
(
	[ICProductID] [int] NOT NULL,
	[AAStatus] VARCHAR(10) NULL,
	[AACreatedDate] DATETIME NULL,
	[AACreatedUser] VARCHAR(100) NULL,
	[AAUpdatedDate] DATETIME NULL,
	[AAUpdatedUser] VARCHAR(100) NULL,
	[ICProductNo] NVARCHAR(50) NOT NULL,
	[ICProductName] NVARCHAR(255) NOT NULL,
	[ICProductDesc] NVARCHAR(512) NULL,
	[ICProductPrice] DECIMAL(18,5) NULL,
	[ICProductSupplierPrice] DECIMAL(18,5) NULL,
	[ICProductNoOfOldSys] NVARCHAR(50) NULL,
	[ICProductLength] DECIMAL(18,5) NULL,
	[ICProductHeight] DECIMAL(18,5) NULL,
	[ICProductWidth] DECIMAL(18,5) NULL,
	[ICProductPicture] VARBINARY(MAX) NULL,
	[ICProductType] VARCHAR(50) NULL,
	[ICProductAttributeWoodType] VARCHAR(255),
	[ICProductAttributeColor] VARCHAR(255),
	[ICProductOrigin] VARCHAR(100) NULL,
	[ICProductGrantedFrom] VARCHAR(100) NULL,
	[ICProductTemplateType] VARCHAR(100) NULL,
	[FK_ICDepartmentID] INT NOT NULL,
	[FK_ICProductGroupID] INT NOT NULL,
	[FK_ICProductBasicUnitID] INT NULL,
	[FK_ICProductSaleUnitID] INT NULL,
	[FK_ICProductAttributeWoodTypeID] INT NULL,
	[FK_ICProductAttributeColorID] INT NULL,
	[ICProductActiveCheck] BIT NOT NULL
	CONSTRAINT [PK_FAICProducts] PRIMARY KEY CLUSTERED 
	(
		[ICProductID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ICProducts]  WITH CHECK ADD  CONSTRAINT [FK_ICProducts_ICProductAttributeColors] FOREIGN KEY([FK_ICProductAttributeColorID]) REFERENCES [dbo].[ICProductAttributes] ([ICProductAttributeID])
GO
ALTER TABLE [dbo].[ICProducts]  WITH CHECK ADD  CONSTRAINT [FK_ICProducts_ICProductAttributeWoodTypes] FOREIGN KEY([FK_ICProductAttributeWoodTypeID]) REFERENCES [dbo].[ICProductAttributes] ([ICProductAttributeID])
GO
ALTER TABLE [dbo].[ICProducts]  WITH CHECK ADD CONSTRAINT [FK_ICProducts_ICMeasureBasicUnits] FOREIGN KEY([FK_ICProductBasicUnitID]) REFERENCES [dbo].[ICMeasureUnits] ([ICMeasureUnitID])
GO
ALTER TABLE [dbo].[ICProducts]  WITH CHECK ADD CONSTRAINT [FK_ICProducts_ICMeasureSaleUnits] FOREIGN KEY([FK_ICProductSaleUnitID]) REFERENCES [dbo].[ICMeasureUnits] ([ICMeasureUnitID])
GO
ALTER TABLE [dbo].[ICProducts]  WITH CHECK ADD CONSTRAINT [FK_ICProducts_ICProductGroups] FOREIGN KEY([FK_ICProductGroupID]) REFERENCES [dbo].[ICProductGroups] ([ICProductGroupID])
GO
ALTER TABLE [dbo].[ICProducts]  WITH CHECK ADD  CONSTRAINT [FK_ICProducts_ICDepartments] FOREIGN KEY([FK_ICDepartmentID]) REFERENCES [dbo].[ICDepartments] ([ICDepartmentID])
GO

CREATE TABLE [dbo].[ARCustomers]
(
	[ARCustomerID] [int] NOT NULL,
	[AAStatus] VARCHAR(10) NULL,
	[AACreatedDate] DATETIME NULL,
	[AACreatedUser] VARCHAR(100) NULL,
	[AAUpdatedDate] DATETIME NULL,
	[AAUpdatedUser] VARCHAR(100) NULL,
	[ARCustomerNo] NVARCHAR(50) NOT NULL,
	[ARCustomerName] NVARCHAR(255) NOT NULL,
	[ARCustomerDesc] NVARCHAR(512) NULL,
	[ARCustomerStartDate] DATETIME NULL,
	[ARCustomerTaxNumber] VARCHAR(100) NULL,
	[ARCustomerType] VARCHAR(100) NULL,
	[ARCustomerIDNumber] VARCHAR(20) NULL,
	[ARCustomerGender] VARCHAR(100) NULL,
	[ARCustomerContactName] NVARCHAR(200) NULL,
	[ARCustomerContactBirthday] DATETIME NULL,
	[ARCustomerContactFirstName] NVARCHAR(100) NULL,
	[ARCustomerContactLastName] NVARCHAR(100) NULL,
	[ARCustomerContactAddress] NVARCHAR(255) NULL,
	[ARCustomerContactPhone1] VARCHAR(20) NULL,
	[ARCustomerContactPhone2] VARCHAR(20) NULL,
	[ARCustomerActiveCheck] BIT NOT NULL
	CONSTRAINT [PK_FAARCustomers] PRIMARY KEY CLUSTERED 
	(
		[ARCustomerID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[ARSaleOrders]
(
	[ARSaleOrderID] [int] NOT NULL,
	[AAStatus] VARCHAR(10) NULL,
	[AACreatedDate] DATETIME NULL,
	[AACreatedUser] VARCHAR(100) NULL,
	[AAUpdatedDate] DATETIME NULL,
	[AAUpdatedUser] VARCHAR(100) NULL,
	[FK_ARCustomerID] INT NULL,
	[ARSaleOrderNo] NVARCHAR(50) NOT NULL,
	[ARSaleOrderName] NVARCHAR(255) NOT NULL,
	[ARSaleOrderDesc] NVARCHAR(512) NULL,
	[ARSaleOrderDate] DATETIME NULL,
	[ARSaleOrderDeliveryDate] DATETIME NULL,
	[ARSaleOrderDiscountPerCent] DECIMAL(18,5) NULL,
	[ARSaleOrderDiscountAmount] DECIMAL(18,5) NULL,
	[ARSaleOrderTaxPercent] DECIMAL(18,5) NULL,
	[ARSaleOrderTaxAmount] DECIMAL(18,5) NULL,
	[ARSaleOrderBeforeDiscountAmount] DECIMAL(18,5) NULL,
	[ARSaleOrderAfterDiscountAmount] DECIMAL(18,5) NULL,
	[ARSaleOrderTotalAmount] DECIMAL(18,5) NULL,
	[ARSaleOrderDepositAmount] DECIMAL(18,5) NULL,
	[ARSaleOrderBalanceDue] DECIMAL(18,5) NULL,
	[ARSaleOrderPaymentDate] DATETIME NULL,
	[ARSaleOrderType] VARCHAR(100),
	[ARSaleOrderStatus] VARCHAR(100),
	[ARSaleOrderCustomerName] NVARCHAR(255),
	[ARSaleOrderCustomerPhone] VARCHAR(20),
	[ARSaleOrderCustomerTaxCode] VARCHAR(100),
	[ARSaleOrderCustomerAddress] NVARCHAR(255),
	[ARSaleOrderCustomerDeliveryName] NVARCHAR(255),
	[ARSaleOrderCustomerDeliveryPhone] VARCHAR(20),
	[ARSaleOrderCustomerDeliveryAddress] NVARCHAR(255),
	[ARSaleOrderPaymentMethodType] VARCHAR(100),
	[ARSaleOrderPaymentTerm] VARCHAR(100),
	CONSTRAINT [PK_FAARSaleOrders] PRIMARY KEY CLUSTERED 
	(
		[ARSaleOrderID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ARSaleOrders]  WITH CHECK ADD CONSTRAINT [FK_ARSaleOrders_ARCustomers] FOREIGN KEY([FK_ARCustomerID])REFERENCES [dbo].[ARCustomers] ([ARCustomerID])
GO

CREATE TABLE [dbo].[ARSaleOrderItems]
(
	[ARSaleOrderItemID] [int] NOT NULL,
	[AAStatus] VARCHAR(10) NULL,
	[AACreatedDate] DATETIME NULL,
	[AACreatedUser] VARCHAR(100) NULL,
	[AAUpdatedDate] DATETIME NULL,
	[AAUpdatedUser] VARCHAR(100) NULL,
	[FK_ARSaleOrderID] INT NOT NULL,
	[FK_ICDepartmentID] INT NULL,
	[FK_ICProductGroupID] INT NULL,
	[FK_ICProductID] INT NOT NULL,
	[FK_ICMeasureUnitID] INT NULL,
	[ARSaleOrderItemProductNo] NVARCHAR(50) NULL,
	[ARSaleOrderItemProductName] NVARCHAR(255) NULL,
	[ARSaleOrderItemProductDesc] NVARCHAR(512) NULL,
	[ARSaleOrderItemProductType] VARCHAR(100) NULL,
	[ARSaleOrderItemProductUnitPrice] DECIMAL(18,5) NULL,
	[ARSaleOrderItemProductBasicUnit] DECIMAL(18,5) NULL,
	[ARSaleOrderItemDiscountPerCent] DECIMAL(18,5) NULL,
	[ARSaleOrderItemDiscountAmount] DECIMAL(18,5) NULL,
	[ARSaleOrderItemTaxPercent] DECIMAL(18,5) NULL,
	[ARSaleOrderItemTaxAmount] DECIMAL(18,5) NULL,
	[ARSaleOrderItemBeforeDiscountAmount] DECIMAL(18,5) NULL,
	[ARSaleOrderItemAfterDiscountAmount] DECIMAL(18,5) NULL,
	[ARSaleOrderItemTotalAmount] DECIMAL(18,5) NULL,
	[ARSaleOrderItemGrantedFrom] VARCHAR(100) NULL
	CONSTRAINT [PK_FAARSaleOrderItems] PRIMARY KEY CLUSTERED 
	(
		[ARSaleOrderItemID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

