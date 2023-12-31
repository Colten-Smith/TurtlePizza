USE [master]
GO
/****** Object:  Database [final_capstone]    Script Date: 8/17/2023 1:23:45 PM ******/
CREATE DATABASE [final_capstone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'final_capstone', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\final_capstone.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'final_capstone_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\final_capstone_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [final_capstone] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [final_capstone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [final_capstone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [final_capstone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [final_capstone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [final_capstone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [final_capstone] SET ARITHABORT OFF 
GO
ALTER DATABASE [final_capstone] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [final_capstone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [final_capstone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [final_capstone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [final_capstone] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [final_capstone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [final_capstone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [final_capstone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [final_capstone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [final_capstone] SET  ENABLE_BROKER 
GO
ALTER DATABASE [final_capstone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [final_capstone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [final_capstone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [final_capstone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [final_capstone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [final_capstone] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [final_capstone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [final_capstone] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [final_capstone] SET  MULTI_USER 
GO
ALTER DATABASE [final_capstone] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [final_capstone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [final_capstone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [final_capstone] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [final_capstone] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [final_capstone] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [final_capstone] SET QUERY_STORE = OFF
GO
USE [final_capstone]
GO
/****** Object:  Table [dbo].[address]    Script Date: 8/17/2023 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[address](
	[street_address] [nvarchar](100) NOT NULL,
	[apt_num] [int] NULL,
	[zip] [int] NOT NULL,
	[city] [nvarchar](30) NOT NULL,
	[state] [varchar](2) NOT NULL,
	[user_id] [int] NULL,
	[address_id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_address_1] PRIMARY KEY CLUSTERED 
(
	[address_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cheese]    Script Date: 8/17/2023 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cheese](
	[cheese_id] [int] IDENTITY(1,1) NOT NULL,
	[cheese_name] [nvarchar](30) NOT NULL,
	[fdc_id] [int] NULL,
	[is_available] [bit] NOT NULL,
	[price] [money] NOT NULL,
 CONSTRAINT [PK_cheese] PRIMARY KEY CLUSTERED 
(
	[cheese_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[crust]    Script Date: 8/17/2023 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[crust](
	[crust_id] [int] IDENTITY(1,1) NOT NULL,
	[crust_name] [nvarchar](30) NOT NULL,
	[fdc_id] [int] NULL,
	[price] [money] NOT NULL,
	[is_Available] [bit] NOT NULL,
 CONSTRAINT [PK_crust] PRIMARY KEY CLUSTERED 
(
	[crust_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[drink]    Script Date: 8/17/2023 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[drink](
	[drink_id] [int] IDENTITY(1,1) NOT NULL,
	[drink_name] [nvarchar](30) NOT NULL,
	[fdc_id] [int] NULL,
	[price] [money] NOT NULL,
	[is_available] [bit] NOT NULL,
 CONSTRAINT [PK_drink] PRIMARY KEY CLUSTERED 
(
	[drink_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 8/17/2023 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[total_price] [money] NOT NULL,
	[is_delivery] [bit] NOT NULL,
	[order_status] [tinyint] NULL,
	[start_time] [datetime] NULL,
	[delivery_time] [datetime] NULL,
	[complete_time] [datetime] NULL,
	[cancelled] [bit] NOT NULL,
	[cook_id] [int] NULL,
	[driver_id] [int] NULL,
	[notes] [nvarchar](256) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[payment_id] [int] NULL,
	[address_id] [int] NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_drink]    Script Date: 8/17/2023 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_drink](
	[order_id] [int] NOT NULL,
	[drink_id] [int] NOT NULL,
	[orderDrink_id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Index [IX_order_drink]    Script Date: 8/17/2023 1:23:45 PM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_order_drink] ON [dbo].[order_drink]
(
	[orderDrink_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_pizza]    Script Date: 8/17/2023 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_pizza](
	[order_id] [int] NOT NULL,
	[pizza_id] [int] NOT NULL,
	[size_id] [int] NOT NULL,
	[orderPizza_id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_side]    Script Date: 8/17/2023 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_side](
	[order_id] [int] NOT NULL,
	[side_id] [int] NOT NULL,
	[orderSide_id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Index [IX_order_side]    Script Date: 8/17/2023 1:23:45 PM ******/
CREATE CLUSTERED INDEX [IX_order_side] ON [dbo].[order_side]
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment]    Script Date: 8/17/2023 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment](
	[card_num] [nvarchar](50) NOT NULL,
	[exp_date] [date] NOT NULL,
	[cvc] [int] NOT NULL,
	[user_id] [int] NULL,
	[payment_id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_payment_1] PRIMARY KEY CLUSTERED 
(
	[payment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pizza]    Script Date: 8/17/2023 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pizza](
	[pizza_id] [int] IDENTITY(1,1) NOT NULL,
	[crust_id] [int] NOT NULL,
	[pizza_name] [nvarchar](30) NOT NULL,
	[is_available] [bit] NOT NULL,
	[is_vegetarian] [bit] NULL,
	[is_glutenfree] [bit] NULL,
	[sauce_id] [int] NOT NULL,
	[is_specialty] [bit] NOT NULL,
	[user_id] [int] NULL,
	[is_favorited] [bit] NOT NULL,
	[price] [money] NOT NULL,
 CONSTRAINT [PK_pizza] PRIMARY KEY CLUSTERED 
(
	[pizza_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pizza_cheese]    Script Date: 8/17/2023 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pizza_cheese](
	[pizza_id] [int] NOT NULL,
	[cheese_id] [int] NOT NULL,
 CONSTRAINT [PK_pizza_cheese] PRIMARY KEY CLUSTERED 
(
	[pizza_id] ASC,
	[cheese_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pizza_topping]    Script Date: 8/17/2023 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pizza_topping](
	[topping_id] [int] NOT NULL,
	[pizza_id] [int] NOT NULL,
	[is_extra] [bit] NOT NULL,
	[quad_1] [bit] NOT NULL,
	[quad_2] [bit] NOT NULL,
	[quad_3] [bit] NOT NULL,
	[quad_4] [bit] NOT NULL,
	[pizzaTopping_id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sauce]    Script Date: 8/17/2023 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sauce](
	[sauce_id] [int] IDENTITY(1,1) NOT NULL,
	[sauce_name] [nvarchar](30) NOT NULL,
	[fdc_id] [int] NULL,
	[is_Available] [bit] NOT NULL,
	[price] [money] NOT NULL,
 CONSTRAINT [PK_sauce] PRIMARY KEY CLUSTERED 
(
	[sauce_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[side]    Script Date: 8/17/2023 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[side](
	[side_id] [int] IDENTITY(1,1) NOT NULL,
	[side_name] [nvarchar](30) NOT NULL,
	[fdc_id] [int] NULL,
	[is_available] [bit] NOT NULL,
	[is_wing] [bit] NOT NULL,
	[price] [money] NOT NULL,
 CONSTRAINT [PK_side] PRIMARY KEY CLUSTERED 
(
	[side_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[size]    Script Date: 8/17/2023 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[size](
	[size_id] [int] IDENTITY(1,1) NOT NULL,
	[size_name] [nvarchar](10) NOT NULL,
	[price] [money] NOT NULL,
	[is_available] [bit] NOT NULL,
 CONSTRAINT [PK_size] PRIMARY KEY CLUSTERED 
(
	[size_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[topping]    Script Date: 8/17/2023 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[topping](
	[topping_id] [int] IDENTITY(1,1) NOT NULL,
	[topping_name] [varchar](30) NOT NULL,
	[fdc_id] [int] NULL,
	[price] [money] NOT NULL,
	[is_available] [bit] NOT NULL,
 CONSTRAINT [PK_topping] PRIMARY KEY CLUSTERED 
(
	[topping_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 8/17/2023 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password_hash] [varchar](200) NOT NULL,
	[salt] [varchar](200) NOT NULL,
	[user_role] [varchar](50) NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cheese] ON 

INSERT [dbo].[cheese] ([cheese_id], [cheese_name], [fdc_id], [is_available], [price]) VALUES (1, N'Mozzarella', 380742, 1, 0.5000)
INSERT [dbo].[cheese] ([cheese_id], [cheese_name], [fdc_id], [is_available], [price]) VALUES (2, N'Cheddar', 2015943, 1, 1.0000)
INSERT [dbo].[cheese] ([cheese_id], [cheese_name], [fdc_id], [is_available], [price]) VALUES (3, N'Gouda', 2057469, 1, 1.0000)
INSERT [dbo].[cheese] ([cheese_id], [cheese_name], [fdc_id], [is_available], [price]) VALUES (4, N'Provolone', 493519, 1, 1.0000)
INSERT [dbo].[cheese] ([cheese_id], [cheese_name], [fdc_id], [is_available], [price]) VALUES (5, N'Parmesan', 2021452, 1, 1.0000)
INSERT [dbo].[cheese] ([cheese_id], [cheese_name], [fdc_id], [is_available], [price]) VALUES (6, N'PepperJack', 2021586, 1, 1.0000)
SET IDENTITY_INSERT [dbo].[cheese] OFF
GO
SET IDENTITY_INSERT [dbo].[crust] ON 

INSERT [dbo].[crust] ([crust_id], [crust_name], [fdc_id], [price], [is_Available]) VALUES (1, N'Thin', 1631602, 0.0000, 1)
INSERT [dbo].[crust] ([crust_id], [crust_name], [fdc_id], [price], [is_Available]) VALUES (2, N'Thicc', 1631602, 0.0000, 1)
INSERT [dbo].[crust] ([crust_id], [crust_name], [fdc_id], [price], [is_Available]) VALUES (3, N'Pretzel', 1631602, 1.0000, 1)
INSERT [dbo].[crust] ([crust_id], [crust_name], [fdc_id], [price], [is_Available]) VALUES (4, N'Stuffed', 1631602, 1.0000, 1)
INSERT [dbo].[crust] ([crust_id], [crust_name], [fdc_id], [price], [is_Available]) VALUES (5, N'Normal', 1631602, 0.0000, 1)
SET IDENTITY_INSERT [dbo].[crust] OFF
GO
SET IDENTITY_INSERT [dbo].[drink] ON 

INSERT [dbo].[drink] ([drink_id], [drink_name], [fdc_id], [price], [is_available]) VALUES (11, N'Pepsi Can', 173656, 2.0000, 1)
INSERT [dbo].[drink] ([drink_id], [drink_name], [fdc_id], [price], [is_available]) VALUES (12, N'Pepsi 2L', 173656, 3.0000, 1)
INSERT [dbo].[drink] ([drink_id], [drink_name], [fdc_id], [price], [is_available]) VALUES (13, N'Diet Pepsi Can', 173656, 2.0000, 1)
INSERT [dbo].[drink] ([drink_id], [drink_name], [fdc_id], [price], [is_available]) VALUES (14, N'Diet Pepsi 2L', 173656, 3.0000, 1)
INSERT [dbo].[drink] ([drink_id], [drink_name], [fdc_id], [price], [is_available]) VALUES (15, N'Sierra Mist', 1458439, 2.0000, 1)
INSERT [dbo].[drink] ([drink_id], [drink_name], [fdc_id], [price], [is_available]) VALUES (16, N'Sierra Mist 2L', 1458439, 3.0000, 1)
INSERT [dbo].[drink] ([drink_id], [drink_name], [fdc_id], [price], [is_available]) VALUES (18, N'Diet Sierra Mist Can', 1459409, 2.0000, 1)
INSERT [dbo].[drink] ([drink_id], [drink_name], [fdc_id], [price], [is_available]) VALUES (19, N'Diet Sierra Mist 2L', 1459409, 3.0000, 1)
INSERT [dbo].[drink] ([drink_id], [drink_name], [fdc_id], [price], [is_available]) VALUES (20, N'Mountain Dew Can', 1627784, 2.0000, 1)
INSERT [dbo].[drink] ([drink_id], [drink_name], [fdc_id], [price], [is_available]) VALUES (21, N'Mountain Dew 2L', 1627784, 3.0000, 1)
INSERT [dbo].[drink] ([drink_id], [drink_name], [fdc_id], [price], [is_available]) VALUES (22, N'Diet Mountain Dew Can', 1627784, 2.0000, 1)
INSERT [dbo].[drink] ([drink_id], [drink_name], [fdc_id], [price], [is_available]) VALUES (23, N'Diet Mountain Dew 2L', 1627784, 3.0000, 1)
INSERT [dbo].[drink] ([drink_id], [drink_name], [fdc_id], [price], [is_available]) VALUES (24, N'Mutagen Ooze Can', 1627784, 2.0000, 1)
INSERT [dbo].[drink] ([drink_id], [drink_name], [fdc_id], [price], [is_available]) VALUES (25, N'Mutagen Ooze 2L', 1627784, 3.0000, 1)
SET IDENTITY_INSERT [dbo].[drink] OFF
GO
SET IDENTITY_INSERT [dbo].[pizza] ON 

INSERT [dbo].[pizza] ([pizza_id], [crust_id], [pizza_name], [is_available], [is_vegetarian], [is_glutenfree], [sauce_id], [is_specialty], [user_id], [is_favorited], [price]) VALUES (4, 2, N'The Raph', 1, 0, 0, 1, 1, NULL, 0, 0.0000)
INSERT [dbo].[pizza] ([pizza_id], [crust_id], [pizza_name], [is_available], [is_vegetarian], [is_glutenfree], [sauce_id], [is_specialty], [user_id], [is_favorited], [price]) VALUES (6, 5, N'The Donny', 1, 0, 0, 1, 1, NULL, 0, 0.0000)
INSERT [dbo].[pizza] ([pizza_id], [crust_id], [pizza_name], [is_available], [is_vegetarian], [is_glutenfree], [sauce_id], [is_specialty], [user_id], [is_favorited], [price]) VALUES (7, 1, N'The Leo', 1, 0, 0, 2, 1, NULL, 0, 0.0000)
INSERT [dbo].[pizza] ([pizza_id], [crust_id], [pizza_name], [is_available], [is_vegetarian], [is_glutenfree], [sauce_id], [is_specialty], [user_id], [is_favorited], [price]) VALUES (8, 5, N'The Mikey', 1, 0, 0, 1, 1, NULL, 0, 0.0000)
INSERT [dbo].[pizza] ([pizza_id], [crust_id], [pizza_name], [is_available], [is_vegetarian], [is_glutenfree], [sauce_id], [is_specialty], [user_id], [is_favorited], [price]) VALUES (9, 5, N'The Shredder', 1, 0, 0, 1, 1, NULL, 0, 0.0000)
INSERT [dbo].[pizza] ([pizza_id], [crust_id], [pizza_name], [is_available], [is_vegetarian], [is_glutenfree], [sauce_id], [is_specialty], [user_id], [is_favorited], [price]) VALUES (10, 3, N'BeeBop & Rocksteady', 1, 0, 0, 2, 1, NULL, 0, 0.0000)
INSERT [dbo].[pizza] ([pizza_id], [crust_id], [pizza_name], [is_available], [is_vegetarian], [is_glutenfree], [sauce_id], [is_specialty], [user_id], [is_favorited], [price]) VALUES (12, 4, N'The Splinter', 1, 0, 0, 1, 1, NULL, 0, 0.0000)
SET IDENTITY_INSERT [dbo].[pizza] OFF
GO
INSERT [dbo].[pizza_cheese] ([pizza_id], [cheese_id]) VALUES (4, 1)
INSERT [dbo].[pizza_cheese] ([pizza_id], [cheese_id]) VALUES (6, 1)
INSERT [dbo].[pizza_cheese] ([pizza_id], [cheese_id]) VALUES (7, 1)
INSERT [dbo].[pizza_cheese] ([pizza_id], [cheese_id]) VALUES (8, 1)
INSERT [dbo].[pizza_cheese] ([pizza_id], [cheese_id]) VALUES (9, 6)
INSERT [dbo].[pizza_cheese] ([pizza_id], [cheese_id]) VALUES (10, 1)
INSERT [dbo].[pizza_cheese] ([pizza_id], [cheese_id]) VALUES (12, 1)
INSERT [dbo].[pizza_cheese] ([pizza_id], [cheese_id]) VALUES (12, 2)
INSERT [dbo].[pizza_cheese] ([pizza_id], [cheese_id]) VALUES (12, 3)
INSERT [dbo].[pizza_cheese] ([pizza_id], [cheese_id]) VALUES (12, 4)
INSERT [dbo].[pizza_cheese] ([pizza_id], [cheese_id]) VALUES (12, 5)
GO
SET IDENTITY_INSERT [dbo].[pizza_topping] ON 

INSERT [dbo].[pizza_topping] ([topping_id], [pizza_id], [is_extra], [quad_1], [quad_2], [quad_3], [quad_4], [pizzaTopping_id]) VALUES (3, 4, 0, 1, 1, 1, 1, 2)
INSERT [dbo].[pizza_topping] ([topping_id], [pizza_id], [is_extra], [quad_1], [quad_2], [quad_3], [quad_4], [pizzaTopping_id]) VALUES (5, 4, 0, 1, 1, 1, 1, 3)
INSERT [dbo].[pizza_topping] ([topping_id], [pizza_id], [is_extra], [quad_1], [quad_2], [quad_3], [quad_4], [pizzaTopping_id]) VALUES (17, 4, 0, 1, 1, 1, 1, 4)
INSERT [dbo].[pizza_topping] ([topping_id], [pizza_id], [is_extra], [quad_1], [quad_2], [quad_3], [quad_4], [pizzaTopping_id]) VALUES (19, 4, 0, 1, 1, 1, 1, 5)
INSERT [dbo].[pizza_topping] ([topping_id], [pizza_id], [is_extra], [quad_1], [quad_2], [quad_3], [quad_4], [pizzaTopping_id]) VALUES (25, 6, 0, 1, 1, 1, 1, 6)
INSERT [dbo].[pizza_topping] ([topping_id], [pizza_id], [is_extra], [quad_1], [quad_2], [quad_3], [quad_4], [pizzaTopping_id]) VALUES (9, 6, 0, 1, 1, 1, 1, 7)
INSERT [dbo].[pizza_topping] ([topping_id], [pizza_id], [is_extra], [quad_1], [quad_2], [quad_3], [quad_4], [pizzaTopping_id]) VALUES (23, 7, 0, 1, 1, 1, 1, 8)
INSERT [dbo].[pizza_topping] ([topping_id], [pizza_id], [is_extra], [quad_1], [quad_2], [quad_3], [quad_4], [pizzaTopping_id]) VALUES (27, 8, 0, 1, 1, 1, 1, 10)
INSERT [dbo].[pizza_topping] ([topping_id], [pizza_id], [is_extra], [quad_1], [quad_2], [quad_3], [quad_4], [pizzaTopping_id]) VALUES (17, 8, 0, 1, 1, 1, 1, 11)
INSERT [dbo].[pizza_topping] ([topping_id], [pizza_id], [is_extra], [quad_1], [quad_2], [quad_3], [quad_4], [pizzaTopping_id]) VALUES (15, 8, 0, 1, 1, 1, 1, 12)
INSERT [dbo].[pizza_topping] ([topping_id], [pizza_id], [is_extra], [quad_1], [quad_2], [quad_3], [quad_4], [pizzaTopping_id]) VALUES (21, 9, 0, 1, 1, 1, 1, 13)
INSERT [dbo].[pizza_topping] ([topping_id], [pizza_id], [is_extra], [quad_1], [quad_2], [quad_3], [quad_4], [pizzaTopping_id]) VALUES (17, 10, 0, 1, 1, 0, 0, 14)
INSERT [dbo].[pizza_topping] ([topping_id], [pizza_id], [is_extra], [quad_1], [quad_2], [quad_3], [quad_4], [pizzaTopping_id]) VALUES (11, 10, 0, 1, 1, 0, 0, 15)
INSERT [dbo].[pizza_topping] ([topping_id], [pizza_id], [is_extra], [quad_1], [quad_2], [quad_3], [quad_4], [pizzaTopping_id]) VALUES (29, 10, 0, 0, 0, 1, 1, 16)
INSERT [dbo].[pizza_topping] ([topping_id], [pizza_id], [is_extra], [quad_1], [quad_2], [quad_3], [quad_4], [pizzaTopping_id]) VALUES (7, 10, 0, 0, 0, 1, 1, 17)
SET IDENTITY_INSERT [dbo].[pizza_topping] OFF
GO
SET IDENTITY_INSERT [dbo].[sauce] ON 

INSERT [dbo].[sauce] ([sauce_id], [sauce_name], [fdc_id], [is_Available], [price]) VALUES (1, N'Red', 172880, 1, 0.0000)
INSERT [dbo].[sauce] ([sauce_id], [sauce_name], [fdc_id], [is_Available], [price]) VALUES (2, N'White', 2113696, 1, 0.0000)
INSERT [dbo].[sauce] ([sauce_id], [sauce_name], [fdc_id], [is_Available], [price]) VALUES (3, N'None', 0, 1, 0.0000)
SET IDENTITY_INSERT [dbo].[sauce] OFF
GO
SET IDENTITY_INSERT [dbo].[side] ON 

INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (1, N'Half Dozen Buffalo Wings', 2085798, 1, 1, 6.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (2, N'Dozen Buffalo Wings', 2085798, 1, 1, 12.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (3, N'Half Dozen Hot n'' Garlic', 2085798, 1, 1, 6.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (4, N'Dozen Hot n'' Garlic', 2085798, 1, 1, 12.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (5, N'Half Dozen BBQ Wings', 2085798, 1, 1, 6.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (6, N'Dozen BBQ Wings', 2085798, 1, 1, 12.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (7, N'Half Dozen Hot Ranch', 2085798, 1, 1, 6.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (9, N'Dozen Hot Ranch ', 2085798, 1, 1, 12.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (11, N'Half Dozen Cajun Rub', 2085798, 1, 1, 6.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (12, N'Dozen Cajun Rub', 2085798, 1, 1, 12.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (13, N'Half Dozen Honey Mustard', 2085798, 1, 1, 6.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (17, N'Dozen Honey Mustard', 2085798, 1, 1, 12.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (18, N'Half Dozen Butter Garlic Parm', 2085798, 1, 1, 6.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (19, N'Dozen Garlic Parm', 2085798, 1, 1, 12.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (20, N'Half Dozen Dry Ranch', 2085798, 1, 1, 6.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (21, N'Dozen Dry Ranch', 2085798, 1, 1, 12.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (22, N'Half Dozen Honey Garlic', 2085798, 1, 1, 6.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (23, N'Dozen Honey Garlic', 2085798, 1, 1, 12.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (24, N'Half Dozen Hot', 2085798, 1, 1, 6.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (25, N'Dozen Hot', 2085798, 1, 1, 12.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (26, N'Half Dozen Mild', 2085798, 1, 1, 6.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (27, N'Dozen Mild', 2085798, 1, 1, 12.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (28, N'Small Fries', 2093015, 1, 0, 2.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (29, N'Medium Fries', 2093015, 1, 0, 4.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (30, N'Large Fries', 2093015, 1, 0, 6.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (31, N'Small Onion Rings', 1904109, 1, 0, 3.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (32, N'Medium Onion Rings', 1904109, 1, 0, 5.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (33, N'Large Onion Rings', 1904109, 1, 0, 7.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (34, N'Small Mozz Sticks', 2076513, 1, 0, 4.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (35, N'Medium Mozz Sticks', 2076513, 1, 0, 6.0000)
INSERT [dbo].[side] ([side_id], [side_name], [fdc_id], [is_available], [is_wing], [price]) VALUES (36, N'Large Mozz Sticks', 2076513, 1, 0, 8.0000)
SET IDENTITY_INSERT [dbo].[side] OFF
GO
SET IDENTITY_INSERT [dbo].[size] ON 

INSERT [dbo].[size] ([size_id], [size_name], [price], [is_available]) VALUES (1, N'Small', 8.0000, 1)
INSERT [dbo].[size] ([size_id], [size_name], [price], [is_available]) VALUES (2, N'Medium', 12.0000, 1)
INSERT [dbo].[size] ([size_id], [size_name], [price], [is_available]) VALUES (3, N'Large', 15.0000, 1)
SET IDENTITY_INSERT [dbo].[size] OFF
GO
SET IDENTITY_INSERT [dbo].[topping] ON 

INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (1, N'Xtra Cheese', 0, 0.5000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (2, N'Xtra Xtra Cheese', 0, 0.7500, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (3, N'Pepperoni', 1870176, 0.5000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (4, N'Xtra Pepperoni', 1870176, 0.7500, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (5, N'Sausage', 2076349, 0.5000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (6, N'Xtra Sausage', 2076349, 0.7500, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (7, N'Mushrooms', 2119916, 0.5000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (8, N'Xtra Mushrooms', 2119916, 0.7500, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (9, N'Green Peppers', 2345499, 0.5000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (10, N'Xtra Green Peppers', 2345499, 0.7500, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (11, N'Onions', 2345315, 0.5000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (12, N'Xtra Onions', 2345315, 0.7500, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (13, N'Black Olives', 594932, 0.5000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (14, N'Xtra Black Olives', 594932, 0.7500, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (15, N'Pineapple', 2282543, 0.5000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (16, N'Xtra Pineapple', 2282543, 0.7500, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (17, N'Bacon', 1897574, 1.0000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (18, N'Xtra Bacon', 1897574, 1.5000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (19, N'Meatball', 2009350, 1.0000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (20, N'Xtra MeatBall', 2009350, 1.5000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (21, N'Hot Sausage', 2066728, 1.0000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (22, N'Xtra Hot Sausage', 2066728, 1.5000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (23, N'Clams', 1914474, 1.0000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (24, N'Xtra Clams', 1914474, 1.5000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (25, N'Chicken', 2090362, 1.0000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (26, N'Xtra Chicken', 2090362, 1.5000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (27, N'Fries', 2093015, 1.0000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (28, N'Xtra Fries', 2093015, 1.5000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (29, N'Arugula', 2574948, 0.5000, 1)
INSERT [dbo].[topping] ([topping_id], [topping_name], [fdc_id], [price], [is_available]) VALUES (30, N'Xtra Arugula', 2574948, 0.7500, 1)
SET IDENTITY_INSERT [dbo].[topping] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role]) VALUES (1, N'user', N'Jg45HuwT7PZkfuKTz6IB90CtWY4=', N'LHxP4Xh7bN0=', N'user')
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role]) VALUES (2, N'admin', N'YhyGVQ+Ch69n4JMBncM4lNF/i9s=', N'Ar/aB2thQTI=', N'admin')
SET IDENTITY_INSERT [dbo].[users] OFF
GO
/****** Object:  Index [PK_order_drink]    Script Date: 8/17/2023 1:23:45 PM ******/
ALTER TABLE [dbo].[order_drink] ADD  CONSTRAINT [PK_order_drink] PRIMARY KEY NONCLUSTERED 
(
	[orderDrink_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_order_pizza]    Script Date: 8/17/2023 1:23:45 PM ******/
ALTER TABLE [dbo].[order_pizza] ADD  CONSTRAINT [PK_order_pizza] PRIMARY KEY NONCLUSTERED 
(
	[orderPizza_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_order_side]    Script Date: 8/17/2023 1:23:45 PM ******/
ALTER TABLE [dbo].[order_side] ADD  CONSTRAINT [PK_order_side] PRIMARY KEY NONCLUSTERED 
(
	[orderSide_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_order_side_1]    Script Date: 8/17/2023 1:23:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_order_side_1] ON [dbo].[order_side]
(
	[side_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_order_side_3]    Script Date: 8/17/2023 1:23:45 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_order_side_3] ON [dbo].[order_side]
(
	[orderSide_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_pizza_topping_1]    Script Date: 8/17/2023 1:23:45 PM ******/
ALTER TABLE [dbo].[pizza_topping] ADD  CONSTRAINT [PK_pizza_topping_1] PRIMARY KEY NONCLUSTERED 
(
	[pizzaTopping_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_UserName]    Script Date: 8/17/2023 1:23:45 PM ******/
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [UQ_UserName] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[crust] ADD  CONSTRAINT [DF_crust_isAvailable]  DEFAULT ((1)) FOR [is_Available]
GO
ALTER TABLE [dbo].[order] ADD  CONSTRAINT [DF_order_order_status]  DEFAULT ((1)) FOR [order_status]
GO
ALTER TABLE [dbo].[order] ADD  CONSTRAINT [DF_order_cancelled]  DEFAULT ((0)) FOR [cancelled]
GO
ALTER TABLE [dbo].[pizza] ADD  CONSTRAINT [DF_pizza_is_available]  DEFAULT ((1)) FOR [is_available]
GO
ALTER TABLE [dbo].[pizza] ADD  CONSTRAINT [DF_pizza_is_vegetarian]  DEFAULT ((0)) FOR [is_vegetarian]
GO
ALTER TABLE [dbo].[pizza] ADD  CONSTRAINT [DF_pizza_is_glutenfree]  DEFAULT ((0)) FOR [is_glutenfree]
GO
ALTER TABLE [dbo].[pizza] ADD  CONSTRAINT [DF_pizza_is_specialty]  DEFAULT ((0)) FOR [is_specialty]
GO
ALTER TABLE [dbo].[pizza_topping] ADD  CONSTRAINT [DF_pizza_topping_is_extra]  DEFAULT ((0)) FOR [is_extra]
GO
ALTER TABLE [dbo].[pizza_topping] ADD  CONSTRAINT [DF_pizza_topping_quad_1]  DEFAULT ((1)) FOR [quad_1]
GO
ALTER TABLE [dbo].[pizza_topping] ADD  CONSTRAINT [DF_pizza_topping_quad_2]  DEFAULT ((1)) FOR [quad_2]
GO
ALTER TABLE [dbo].[pizza_topping] ADD  CONSTRAINT [DF_pizza_topping_quad_3]  DEFAULT ((1)) FOR [quad_3]
GO
ALTER TABLE [dbo].[pizza_topping] ADD  CONSTRAINT [DF_pizza_topping_quad_4]  DEFAULT ((1)) FOR [quad_4]
GO
ALTER TABLE [dbo].[sauce] ADD  CONSTRAINT [DF_sauce_isAvailable]  DEFAULT ((1)) FOR [is_Available]
GO
ALTER TABLE [dbo].[side] ADD  CONSTRAINT [DF_side_is_wing]  DEFAULT ((0)) FOR [is_wing]
GO
ALTER TABLE [dbo].[address]  WITH CHECK ADD  CONSTRAINT [FK_address_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[address] CHECK CONSTRAINT [FK_address_users]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_address] FOREIGN KEY([address_id])
REFERENCES [dbo].[address] ([address_id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_address]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_payment] FOREIGN KEY([payment_id])
REFERENCES [dbo].[payment] ([payment_id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_payment]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_users]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_users1] FOREIGN KEY([cook_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_users1]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_users2] FOREIGN KEY([driver_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_users2]
GO
ALTER TABLE [dbo].[order_drink]  WITH CHECK ADD  CONSTRAINT [FK_order_drink_drink] FOREIGN KEY([drink_id])
REFERENCES [dbo].[drink] ([drink_id])
GO
ALTER TABLE [dbo].[order_drink] CHECK CONSTRAINT [FK_order_drink_drink]
GO
ALTER TABLE [dbo].[order_drink]  WITH CHECK ADD  CONSTRAINT [FK_order_drink_order] FOREIGN KEY([order_id])
REFERENCES [dbo].[order] ([order_id])
GO
ALTER TABLE [dbo].[order_drink] CHECK CONSTRAINT [FK_order_drink_order]
GO
ALTER TABLE [dbo].[order_pizza]  WITH CHECK ADD  CONSTRAINT [FK_order_pizza_order] FOREIGN KEY([order_id])
REFERENCES [dbo].[order] ([order_id])
GO
ALTER TABLE [dbo].[order_pizza] CHECK CONSTRAINT [FK_order_pizza_order]
GO
ALTER TABLE [dbo].[order_pizza]  WITH CHECK ADD  CONSTRAINT [FK_order_pizza_pizza] FOREIGN KEY([pizza_id])
REFERENCES [dbo].[pizza] ([pizza_id])
GO
ALTER TABLE [dbo].[order_pizza] CHECK CONSTRAINT [FK_order_pizza_pizza]
GO
ALTER TABLE [dbo].[order_pizza]  WITH CHECK ADD  CONSTRAINT [FK_order_pizza_size] FOREIGN KEY([size_id])
REFERENCES [dbo].[size] ([size_id])
GO
ALTER TABLE [dbo].[order_pizza] CHECK CONSTRAINT [FK_order_pizza_size]
GO
ALTER TABLE [dbo].[order_side]  WITH CHECK ADD  CONSTRAINT [FK_order_side_order2] FOREIGN KEY([order_id])
REFERENCES [dbo].[order] ([order_id])
GO
ALTER TABLE [dbo].[order_side] CHECK CONSTRAINT [FK_order_side_order2]
GO
ALTER TABLE [dbo].[order_side]  WITH CHECK ADD  CONSTRAINT [FK_order_side_side] FOREIGN KEY([side_id])
REFERENCES [dbo].[side] ([side_id])
GO
ALTER TABLE [dbo].[order_side] CHECK CONSTRAINT [FK_order_side_side]
GO
ALTER TABLE [dbo].[payment]  WITH CHECK ADD  CONSTRAINT [FK_payment_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[payment] CHECK CONSTRAINT [FK_payment_users]
GO
ALTER TABLE [dbo].[pizza]  WITH CHECK ADD  CONSTRAINT [FK_pizza_crust] FOREIGN KEY([crust_id])
REFERENCES [dbo].[crust] ([crust_id])
GO
ALTER TABLE [dbo].[pizza] CHECK CONSTRAINT [FK_pizza_crust]
GO
ALTER TABLE [dbo].[pizza]  WITH CHECK ADD  CONSTRAINT [FK_pizza_sauce] FOREIGN KEY([sauce_id])
REFERENCES [dbo].[sauce] ([sauce_id])
GO
ALTER TABLE [dbo].[pizza] CHECK CONSTRAINT [FK_pizza_sauce]
GO
ALTER TABLE [dbo].[pizza_cheese]  WITH CHECK ADD  CONSTRAINT [FK_pizza_cheese_cheese] FOREIGN KEY([cheese_id])
REFERENCES [dbo].[cheese] ([cheese_id])
GO
ALTER TABLE [dbo].[pizza_cheese] CHECK CONSTRAINT [FK_pizza_cheese_cheese]
GO
ALTER TABLE [dbo].[pizza_cheese]  WITH CHECK ADD  CONSTRAINT [FK_pizza_cheese_pizza] FOREIGN KEY([pizza_id])
REFERENCES [dbo].[pizza] ([pizza_id])
GO
ALTER TABLE [dbo].[pizza_cheese] CHECK CONSTRAINT [FK_pizza_cheese_pizza]
GO
ALTER TABLE [dbo].[pizza_topping]  WITH CHECK ADD  CONSTRAINT [FK_pizza_topping_pizza1] FOREIGN KEY([pizza_id])
REFERENCES [dbo].[pizza] ([pizza_id])
GO
ALTER TABLE [dbo].[pizza_topping] CHECK CONSTRAINT [FK_pizza_topping_pizza1]
GO
ALTER TABLE [dbo].[pizza_topping]  WITH CHECK ADD  CONSTRAINT [FK_pizza_topping_topping1] FOREIGN KEY([topping_id])
REFERENCES [dbo].[topping] ([topping_id])
GO
ALTER TABLE [dbo].[pizza_topping] CHECK CONSTRAINT [FK_pizza_topping_topping1]
GO
USE [master]
GO
ALTER DATABASE [final_capstone] SET  READ_WRITE 
GO
