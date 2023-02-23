/****** Object:  Table [dbo].[Categories]    Script Date: 2/23/2023 9:45:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[category_id] [uniqueidentifier] NOT NULL,
	[category_name] [nvarchar](150) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2/23/2023 9:45:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[product_id] [uniqueidentifier] NOT NULL,
	[product_name] [nvarchar](150) NULL,
	[price] [decimal](18, 2) NULL,
	[description] [nvarchar](250) NULL,
	[image_url] [nvarchar](500) NULL,
	[date_added] [datetime2](7) NOT NULL,
	[category_id] [uniqueidentifier] NULL,
	[RowVersion] [timestamp] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Products_VW]    Script Date: 2/23/2023 9:45:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   view [dbo].[Products_VW]
as
select p.*,c.category_name,

			 CASE
                  WHEN c.RowVersion > p.RowVersion
                     THEN c.RowVersion
                  ELSE p.RowVersion
             END AS FinalRowVersion

from products p
left join Categories c on p.category_id=c.category_id
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2/23/2023 9:45:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[order_id] [uniqueidentifier] NOT NULL,
	[order_date] [datetime2](7) NOT NULL,
	[customer_name] [nvarchar](150) NULL,
	[RowVersion] [timestamp] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdersProducts]    Script Date: 2/23/2023 9:45:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersProducts](
	[order_id] [uniqueidentifier] NOT NULL,
	[product_id] [uniqueidentifier] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_OrdersProducts] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC,
	[product_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrdersProducts]  WITH CHECK ADD  CONSTRAINT [FK_OrdersProducts_Orders_order_id] FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([order_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrdersProducts] CHECK CONSTRAINT [FK_OrdersProducts_Orders_order_id]
GO
ALTER TABLE [dbo].[OrdersProducts]  WITH CHECK ADD  CONSTRAINT [FK_OrdersProducts_Products_product_id] FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([product_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrdersProducts] CHECK CONSTRAINT [FK_OrdersProducts_Products_product_id]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_category_id] FOREIGN KEY([category_id])
REFERENCES [dbo].[Categories] ([category_id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_category_id]
GO
