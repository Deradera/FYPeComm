USE [FYP_eComm_DEV]
GO
/****** Object:  Table [dbo].[COLOUR]    Script Date: 11/05/2018 14:12:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COLOUR](
	[colour_id] [int] IDENTITY(1,1) NOT NULL,
	[colour_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_COLOUR] PRIMARY KEY CLUSTERED 
(
	[colour_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROD_CAT]    Script Date: 11/05/2018 14:12:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROD_CAT](
	[prod_cat_id] [int] IDENTITY(1,1) NOT NULL,
	[prod_cat_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PROD_CAT] PRIMARY KEY CLUSTERED 
(
	[prod_cat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROD_SIZE_COLOUR_LINK]    Script Date: 11/05/2018 14:12:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROD_SIZE_COLOUR_LINK](
	[prod_id] [uniqueidentifier] NOT NULL,
	[size_id] [int] NULL,
	[colour_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROD_SUB_CAT]    Script Date: 11/05/2018 14:12:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROD_SUB_CAT](
	[prod_sub_cat_id] [int] IDENTITY(1,1) NOT NULL,
	[prod_sub_cat_name] [varchar](50) NOT NULL,
	[prod_parent_cat_id] [int] NOT NULL,
 CONSTRAINT [PK_PROD_SUB_CAT] PRIMARY KEY CLUSTERED 
(
	[prod_sub_cat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCT]    Script Date: 11/05/2018 14:12:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCT](
	[prod_id] [uniqueidentifier] NOT NULL,
	[prod_name] [nvarchar](50) NOT NULL,
	[prod_desc] [nvarchar](50) NOT NULL,
	[prod_price] [float] NOT NULL,
	[prod_img] [varchar](50) NOT NULL,
	[sub_cat_id] [int] NOT NULL,
 CONSTRAINT [PK_PRODUCT] PRIMARY KEY CLUSTERED 
(
	[prod_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SIZE]    Script Date: 11/05/2018 14:12:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIZE](
	[size_id] [int] IDENTITY(1,1) NOT NULL,
	[size_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SIZE] PRIMARY KEY CLUSTERED 
(
	[size_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[COLOUR] ON 

INSERT [dbo].[COLOUR] ([colour_id], [colour_name]) VALUES (1, N'White')
INSERT [dbo].[COLOUR] ([colour_id], [colour_name]) VALUES (2, N'Light Blue')
INSERT [dbo].[COLOUR] ([colour_id], [colour_name]) VALUES (3, N'Dark Blue')
INSERT [dbo].[COLOUR] ([colour_id], [colour_name]) VALUES (4, N'Green')
INSERT [dbo].[COLOUR] ([colour_id], [colour_name]) VALUES (5, N'Pink')
INSERT [dbo].[COLOUR] ([colour_id], [colour_name]) VALUES (6, N'Purple')
INSERT [dbo].[COLOUR] ([colour_id], [colour_name]) VALUES (7, N'Yellow')
INSERT [dbo].[COLOUR] ([colour_id], [colour_name]) VALUES (8, N'Red')
INSERT [dbo].[COLOUR] ([colour_id], [colour_name]) VALUES (9, N'Orange')
INSERT [dbo].[COLOUR] ([colour_id], [colour_name]) VALUES (10, N'Black')
INSERT [dbo].[COLOUR] ([colour_id], [colour_name]) VALUES (11, N'Beige')
SET IDENTITY_INSERT [dbo].[COLOUR] OFF
SET IDENTITY_INSERT [dbo].[PROD_CAT] ON 

INSERT [dbo].[PROD_CAT] ([prod_cat_id], [prod_cat_name]) VALUES (1, N'Men''s')
INSERT [dbo].[PROD_CAT] ([prod_cat_id], [prod_cat_name]) VALUES (2, N'Women''s')
SET IDENTITY_INSERT [dbo].[PROD_CAT] OFF
SET IDENTITY_INSERT [dbo].[PROD_SUB_CAT] ON 

INSERT [dbo].[PROD_SUB_CAT] ([prod_sub_cat_id], [prod_sub_cat_name], [prod_parent_cat_id]) VALUES (1, N'Shirts and T-shirts', 1)
INSERT [dbo].[PROD_SUB_CAT] ([prod_sub_cat_id], [prod_sub_cat_name], [prod_parent_cat_id]) VALUES (2, N'Jeans', 1)
INSERT [dbo].[PROD_SUB_CAT] ([prod_sub_cat_id], [prod_sub_cat_name], [prod_parent_cat_id]) VALUES (3, N'Jackets and Coats', 1)
INSERT [dbo].[PROD_SUB_CAT] ([prod_sub_cat_id], [prod_sub_cat_name], [prod_parent_cat_id]) VALUES (4, N'Sportswear', 1)
INSERT [dbo].[PROD_SUB_CAT] ([prod_sub_cat_id], [prod_sub_cat_name], [prod_parent_cat_id]) VALUES (5, N'Loungewear', 1)
SET IDENTITY_INSERT [dbo].[PROD_SUB_CAT] OFF
INSERT [dbo].[PRODUCT] ([prod_id], [prod_name], [prod_desc], [prod_price], [prod_img], [sub_cat_id]) VALUES (N'b9f02c65-f862-495f-a9b8-84af05d5a97f', N'Plain T-Shirt', N'A Basic Comfy T-shirt with no prints.', 1, N'~/images/Products/white tshirt.jpg', 1)
SET IDENTITY_INSERT [dbo].[SIZE] ON 

INSERT [dbo].[SIZE] ([size_id], [size_name]) VALUES (1, N'Small')
INSERT [dbo].[SIZE] ([size_id], [size_name]) VALUES (2, N'Medium')
INSERT [dbo].[SIZE] ([size_id], [size_name]) VALUES (3, N'Large')
INSERT [dbo].[SIZE] ([size_id], [size_name]) VALUES (4, N'X-Large')
INSERT [dbo].[SIZE] ([size_id], [size_name]) VALUES (5, N'XX-Large')
INSERT [dbo].[SIZE] ([size_id], [size_name]) VALUES (6, N'X-Small')
INSERT [dbo].[SIZE] ([size_id], [size_name]) VALUES (7, N'6')
INSERT [dbo].[SIZE] ([size_id], [size_name]) VALUES (8, N'8')
INSERT [dbo].[SIZE] ([size_id], [size_name]) VALUES (9, N'10')
INSERT [dbo].[SIZE] ([size_id], [size_name]) VALUES (10, N'12')
INSERT [dbo].[SIZE] ([size_id], [size_name]) VALUES (11, N'14')
INSERT [dbo].[SIZE] ([size_id], [size_name]) VALUES (12, N'16')
INSERT [dbo].[SIZE] ([size_id], [size_name]) VALUES (13, N'18')
INSERT [dbo].[SIZE] ([size_id], [size_name]) VALUES (14, N'20')
SET IDENTITY_INSERT [dbo].[SIZE] OFF
ALTER TABLE [dbo].[PROD_SIZE_COLOUR_LINK]  WITH CHECK ADD  CONSTRAINT [FK_PROD_SIZE_COLOUR_LINK_COLOUR] FOREIGN KEY([colour_id])
REFERENCES [dbo].[COLOUR] ([colour_id])
GO
ALTER TABLE [dbo].[PROD_SIZE_COLOUR_LINK] CHECK CONSTRAINT [FK_PROD_SIZE_COLOUR_LINK_COLOUR]
GO
ALTER TABLE [dbo].[PROD_SIZE_COLOUR_LINK]  WITH CHECK ADD  CONSTRAINT [FK_PROD_SIZE_COLOUR_LINK_PRODUCT] FOREIGN KEY([prod_id])
REFERENCES [dbo].[PRODUCT] ([prod_id])
GO
ALTER TABLE [dbo].[PROD_SIZE_COLOUR_LINK] CHECK CONSTRAINT [FK_PROD_SIZE_COLOUR_LINK_PRODUCT]
GO
ALTER TABLE [dbo].[PROD_SIZE_COLOUR_LINK]  WITH CHECK ADD  CONSTRAINT [FK_PROD_SIZE_COLOUR_LINK_SIZE] FOREIGN KEY([size_id])
REFERENCES [dbo].[SIZE] ([size_id])
GO
ALTER TABLE [dbo].[PROD_SIZE_COLOUR_LINK] CHECK CONSTRAINT [FK_PROD_SIZE_COLOUR_LINK_SIZE]
GO
ALTER TABLE [dbo].[PROD_SUB_CAT]  WITH CHECK ADD  CONSTRAINT [FK_PROD_SUB_CAT_PROD_CAT] FOREIGN KEY([prod_parent_cat_id])
REFERENCES [dbo].[PROD_CAT] ([prod_cat_id])
GO
ALTER TABLE [dbo].[PROD_SUB_CAT] CHECK CONSTRAINT [FK_PROD_SUB_CAT_PROD_CAT]
GO
ALTER TABLE [dbo].[PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_PROD_SUB_CAT] FOREIGN KEY([sub_cat_id])
REFERENCES [dbo].[PROD_SUB_CAT] ([prod_sub_cat_id])
GO
ALTER TABLE [dbo].[PRODUCT] CHECK CONSTRAINT [FK_PRODUCT_PROD_SUB_CAT]
GO
