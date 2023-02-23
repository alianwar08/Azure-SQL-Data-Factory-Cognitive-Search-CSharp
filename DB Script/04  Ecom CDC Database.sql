
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



