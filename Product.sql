USE [ProductsDB]
GO

/****** Create Table [dbo].[Product]    Script Date: 2018-09-09 10:16:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Price] [decimal](16, 2) NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

/***Insert data Into Table [dbo].[Product] ***/
INSERT INTO [dbo].[Product]
           ([Name]
           ,[Price]
           ,[Description])
     VALUES
           ('Dog Shampoo','10.57','shampoo for long hair dogs'),
		   ('WD Red 4 TB','150.99','NAS hard drive'),
		   ('2018 Nissan Mourano','37866.99','Nissan Mourano AWD with Tech Package?');
GO


/****** Object:Copy Columns to Table [dbo].[Product_Copy]    Script Date: 2018-09-09 10:51:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product_Copy](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Price] [decimal](16, 2) NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Product_Copy] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO


/***Insert data Into Table [dbo].[Product_Copy] ***/
INSERT INTO [dbo].[Product_Copy]  
    SELECT [ID], [Name], [Price], [Description]  
    FROM [dbo].[Product];  
GO 


/***Delete data of the 2nd row From Table [dbo].[Product_Copy] ***/
DELETE FROM [dbo].[Product_Copy]
      WHERE Price = '150.99';
GO