CREATE TABLE [dbo].[ICStocks]
(
	[ICStockID] [int] NOT NULL,
	[AAStatus] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AACreatedUser] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AACreatedDate] [datetime] NULL,
	[AAUpdatedUser] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AAUpdatedDate] [datetime] NULL,
	[ICStockNo] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ICStockName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ICStockDesc] [nvarchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ICStockType] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ICStockActiveCheck] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ICStocks] ADD CONSTRAINT [PK_MAStocks] PRIMARY KEY CLUSTERED ([ICStockID]) ON [PRIMARY]


