USE [master]
GO
/****** Object:  Database [Restaurant_CleanArchitecture]    Script Date: 10/6/2021 11:56:40 AM ******/
CREATE DATABASE [Restaurant_CleanArchitecture]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Restaurant_CleanArchitecture', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Restaurant_CleanArchitecture.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Restaurant_CleanArchitecture_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Restaurant_CleanArchitecture_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Restaurant_CleanArchitecture].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET ARITHABORT OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET RECOVERY FULL 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET  MULTI_USER 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Restaurant_CleanArchitecture', N'ON'
GO
USE [Restaurant_CleanArchitecture]
GO
/****** Object:  Table [Address]    Script Date: 10/6/2021 11:56:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Building_No] [nvarchar](20) NOT NULL,
	[Address1] [nvarchar](150) NOT NULL,
	[Address2] [nvarchar](150) NULL,
	[City] [nvarchar](100) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[PostCode] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Booking]    Script Date: 10/6/2021 11:56:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Booking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RestaurantId] [int] NULL,
	[BookingDate] [datetime] NOT NULL,
	[ReservedBy] [nvarchar](450) NULL,
	[ReservationDate] [date] NOT NULL,
	[ReservationTime] [varchar](10) NOT NULL,
	[Status] [nvarchar](50) NULL,
	[LastUpdate] [datetime] NULL,
	[UpdatedBy] [nvarchar](450) NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Owner_Register_Form]    Script Date: 10/6/2021 11:56:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Owner_Register_Form](
	[Id] [int] NOT NULL,
	[ApplicationDate] [datetime] NOT NULL,
	[Restaurant_Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ApplicationStatus] [int] NULL,
	[ApprovedDate] [datetime] NULL,
	[ApprovedBy] [nvarchar](450) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [Restaurant]    Script Date: 10/6/2021 11:56:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Restaurant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RestaurantName] [nvarchar](100) NOT NULL,
	[Type] [int] NOT NULL,
	[OpenHour] [nvarchar](50) NOT NULL,
	[EndHour] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[UserId] [nvarchar](450) NULL,
	[Status] [nvarchar](50) NULL,
	[AppovalDate] [datetime] NULL,
	[ApprovedBy] [nvarchar](450) NULL,
	[AddressId] [int] NULL,
	[TableQty] [int] NULL,
 CONSTRAINT [PK_Restaurant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [Booking] ON 

INSERT [Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (1, 2, CAST(N'2021-06-03 20:43:23.810' AS DateTime), N'yapkinhoe1@gmail.com', CAST(N'2021-06-10' AS Date), N'15:00:00', N'Completed', CAST(N'2021-06-03 20:43:23.810' AS DateTime), NULL)
INSERT [Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (2, 2, CAST(N'2021-06-03 20:43:37.660' AS DateTime), N'porotomato@gmail.com', CAST(N'2021-06-10' AS Date), N'15:00:00', N'Rejected', CAST(N'2021-06-03 20:43:37.660' AS DateTime), NULL)
INSERT [Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (3, 2, CAST(N'2021-06-03 20:43:49.570' AS DateTime), N'kinhoe0414@gmail.com', CAST(N'2021-06-10' AS Date), N'15:00:00', N'Reserved', CAST(N'2021-06-03 20:43:49.570' AS DateTime), NULL)
INSERT [Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (4, 2, CAST(N'2021-06-03 20:44:13.767' AS DateTime), N'kentTee@gmail.com', CAST(N'2021-06-10' AS Date), N'15:00:00', N'Pending', CAST(N'2021-06-03 20:44:13.767' AS DateTime), NULL)
INSERT [Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (6, 2, CAST(N'2021-06-04 17:27:55.703' AS DateTime), N'john01@gmail.com', CAST(N'2021-06-10' AS Date), N'16:00:00', N'Pending', CAST(N'2021-06-04 17:27:55.703' AS DateTime), NULL)
INSERT [Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (7, 2, CAST(N'2021-06-04 17:28:01.137' AS DateTime), N'john02@gmail.com', CAST(N'2021-06-10' AS Date), N'16:00:00', N'Pending', CAST(N'2021-06-04 17:28:01.137' AS DateTime), NULL)
INSERT [Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (8, 2, CAST(N'2021-06-04 17:28:04.687' AS DateTime), N'john03@gmail.com', CAST(N'2021-06-10' AS Date), N'16:00:00', N'Pending', CAST(N'2021-06-04 17:28:04.687' AS DateTime), NULL)
INSERT [Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (9, 2, CAST(N'2021-06-04 17:28:08.353' AS DateTime), N'john04@gmail.com', CAST(N'2021-06-10' AS Date), N'16:00:00', N'Pending', CAST(N'2021-06-04 17:28:08.353' AS DateTime), NULL)
SET IDENTITY_INSERT [Booking] OFF
SET IDENTITY_INSERT [Restaurant] ON 

INSERT [Restaurant] ([Id], [RestaurantName], [Type], [OpenHour], [EndHour], [Description], [UserId], [Status], [AppovalDate], [ApprovedBy], [AddressId], [TableQty]) VALUES (2, N'Kent Ice Cream', 1, N'12:00:00', N'22:00:00', N'Best Ice Cream Fast Food Store', NULL, NULL, NULL, NULL, NULL, 10)
INSERT [Restaurant] ([Id], [RestaurantName], [Type], [OpenHour], [EndHour], [Description], [UserId], [Status], [AppovalDate], [ApprovedBy], [AddressId], [TableQty]) VALUES (3, N'Daboba99', 1, N'08:00:00', N'20:00:00', N'This is update to test', NULL, NULL, NULL, NULL, NULL, 5)
INSERT [Restaurant] ([Id], [RestaurantName], [Type], [OpenHour], [EndHour], [Description], [UserId], [Status], [AppovalDate], [ApprovedBy], [AddressId], [TableQty]) VALUES (4, N'Daboba', 1, N'12:00:00', N'20:00:00', N'Best Milk in Town', NULL, NULL, NULL, NULL, NULL, 5)
INSERT [Restaurant] ([Id], [RestaurantName], [Type], [OpenHour], [EndHour], [Description], [UserId], [Status], [AppovalDate], [ApprovedBy], [AddressId], [TableQty]) VALUES (5, N'Black Whale', 1, N'12:00:00', N'20:00:00', N'Milk Tea', NULL, NULL, NULL, NULL, NULL, 5)
INSERT [Restaurant] ([Id], [RestaurantName], [Type], [OpenHour], [EndHour], [Description], [UserId], [Status], [AppovalDate], [ApprovedBy], [AddressId], [TableQty]) VALUES (6, N'Daboba2', 1, N'12:00:00', N'20:00:00', N'Best Milk in Town', NULL, NULL, NULL, NULL, NULL, 5)
SET IDENTITY_INSERT [Restaurant] OFF
ALTER TABLE [Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Restaurant] FOREIGN KEY([RestaurantId])
REFERENCES [Restaurant] ([Id])
GO
ALTER TABLE [Booking] CHECK CONSTRAINT [FK_Booking_Restaurant]
GO
ALTER TABLE [Restaurant]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_Address] FOREIGN KEY([AddressId])
REFERENCES [Address] ([Id])
GO
ALTER TABLE [Restaurant] CHECK CONSTRAINT [FK_Restaurant_Address]
GO
USE [master]
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET  READ_WRITE 
GO
