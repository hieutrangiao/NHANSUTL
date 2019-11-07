CREATE TABLE [dbo].[STColumns](
	[STColumnID] [int] NOT NULL,
	[FK_STScreenID] [int] NOT NULL,
	[STColumnName] [nvarchar](256) NULL,
	[STColumnFieldName] [varchar](256) NULL,
	[STColumnControlName] [varchar](256) NULL,
	[STColumnWidth] [int] NULL,
	[STColumnVisibleIndex] [int] NULL,
 CONSTRAINT [PK_STColumns] PRIMARY KEY CLUSTERED 
(
	[STColumnID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[STColumns]  WITH NOCHECK ADD  CONSTRAINT [FK_STColumns_STScreens] FOREIGN KEY([FK_STScreenID])
REFERENCES [dbo].[STScreens] ([STScreenID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[STColumns] CHECK CONSTRAINT [FK_STColumns_STScreens]
GO