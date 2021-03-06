USE [master]
GO
/****** Object:  Database [Restaurant_CleanArchitecture]    Script Date: 15/6/2021 6:49:19 PM ******/
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
/****** Object:  Table [dbo].[Address]    Script Date: 15/6/2021 6:49:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
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
/****** Object:  Table [dbo].[Announcement]    Script Date: 15/6/2021 6:49:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Announcement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Message] [nvarchar](100) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](450) NOT NULL,
	[TargetTo] [nvarchar](100) NOT NULL,
	[UserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Announcement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Booking]    Script Date: 15/6/2021 6:49:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Booking](
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
/****** Object:  Table [dbo].[Owner_Register_Form]    Script Date: 15/6/2021 6:49:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owner_Register_Form](
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
/****** Object:  Table [dbo].[Restaurant]    Script Date: 15/6/2021 6:49:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RestaurantName] [nvarchar](100) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
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
/****** Object:  Table [dbo].[Restaurant_Follower]    Script Date: 15/6/2021 6:49:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurant_Follower](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RestaurantId] [int] NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[DateFollowed] [datetime] NOT NULL,
 CONSTRAINT [PK_Restaurant_Follower] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 15/6/2021 6:49:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[Username] [nvarchar](256) NOT NULL,
	[FirstName] [nvarchar](256) NULL,
	[LastName] [nvarchar](256) NULL,
	[Role] [nvarchar](100) NULL,
	[DateRequested] [datetime] NULL,
	[DateUpdated] [datetime] NULL,
	[UpdatedBy] [nvarchar](450) NULL,
	[Status] [nvarchar](100) NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (1, 2, CAST(N'2021-06-03 20:43:23.810' AS DateTime), N'yapkinhoe1@gmail.com', CAST(N'2021-06-10' AS Date), N'15:00:00', N'Completed', CAST(N'2021-06-03 20:43:23.810' AS DateTime), NULL)
INSERT [dbo].[Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (2, 2, CAST(N'2021-06-03 20:43:37.660' AS DateTime), N'porotomato@gmail.com', CAST(N'2021-06-10' AS Date), N'15:00:00', N'Rejected', CAST(N'2021-06-03 20:43:37.660' AS DateTime), NULL)
INSERT [dbo].[Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (3, 2, CAST(N'2021-06-03 20:43:49.570' AS DateTime), N'kinhoe0414@gmail.com', CAST(N'2021-06-10' AS Date), N'15:00:00', N'Reserved', CAST(N'2021-06-03 20:43:49.570' AS DateTime), NULL)
INSERT [dbo].[Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (4, 2, CAST(N'2021-06-03 20:44:13.767' AS DateTime), N'kentTee@gmail.com', CAST(N'2021-06-10' AS Date), N'15:00:00', N'Pending', CAST(N'2021-06-03 20:44:13.767' AS DateTime), NULL)
INSERT [dbo].[Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (6, 2, CAST(N'2021-06-04 17:27:55.703' AS DateTime), N'john01@gmail.com', CAST(N'2021-06-10' AS Date), N'16:00:00', N'Pending', CAST(N'2021-06-04 17:27:55.703' AS DateTime), NULL)
INSERT [dbo].[Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (7, 2, CAST(N'2021-06-04 17:28:01.137' AS DateTime), N'john02@gmail.com', CAST(N'2021-06-10' AS Date), N'16:00:00', N'Pending', CAST(N'2021-06-04 17:28:01.137' AS DateTime), NULL)
INSERT [dbo].[Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (8, 2, CAST(N'2021-06-04 17:28:04.687' AS DateTime), N'john03@gmail.com', CAST(N'2021-06-10' AS Date), N'16:00:00', N'Pending', CAST(N'2021-06-04 17:28:04.687' AS DateTime), NULL)
INSERT [dbo].[Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (9, 2, CAST(N'2021-06-04 17:28:08.353' AS DateTime), N'john04@gmail.com', CAST(N'2021-06-10' AS Date), N'16:00:00', N'Pending', CAST(N'2021-06-04 17:28:08.353' AS DateTime), NULL)
INSERT [dbo].[Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (10, 2, CAST(N'2021-06-11 14:51:32.000' AS DateTime), N'78df26a0-2171-41ac-afa0-6b26f4abaefc', CAST(N'2021-06-12' AS Date), N'12:00:00', N'Pending', CAST(N'2021-06-11 14:51:44.000' AS DateTime), NULL)
INSERT [dbo].[Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (11, 2, CAST(N'2021-06-11 14:59:56.000' AS DateTime), N'7f7d06a1-1940-42b2-aea0-6d7add7546ee', CAST(N'2021-06-11' AS Date), N'15:00:00', N'Pending', CAST(N'2021-06-11 15:01:08.000' AS DateTime), NULL)
INSERT [dbo].[Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (12, 2, CAST(N'2021-06-11 16:18:44.000' AS DateTime), N'johnny@gmail.com', CAST(N'2021-06-19' AS Date), N'12:00:00', N'Pending', CAST(N'2021-06-11 16:19:16.000' AS DateTime), NULL)
INSERT [dbo].[Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (13, 7, CAST(N'2021-06-14 15:06:00.000' AS DateTime), N'johnny@gmail.com', CAST(N'2021-06-15' AS Date), N'10:00:00', N'Pending', CAST(N'2021-06-14 15:06:24.000' AS DateTime), NULL)
INSERT [dbo].[Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (14, 7, CAST(N'2021-06-14 15:18:51.000' AS DateTime), N'bdd61d5f-0fcf-44ab-814a-2de2583e0b5a', CAST(N'2021-06-14' AS Date), N'16:00:00', N'Pending', CAST(N'2021-06-14 15:19:06.000' AS DateTime), NULL)
INSERT [dbo].[Booking] ([Id], [RestaurantId], [BookingDate], [ReservedBy], [ReservationDate], [ReservationTime], [Status], [LastUpdate], [UpdatedBy]) VALUES (15, 7, CAST(N'2021-06-14 19:55:19.000' AS DateTime), N'b81e3353-a5ed-48a5-9091-c51ba0005a7f', CAST(N'2021-06-14' AS Date), N'20:00:00', N'Pending', CAST(N'2021-06-14 19:55:50.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Booking] OFF
SET IDENTITY_INSERT [dbo].[Restaurant] ON 

INSERT [dbo].[Restaurant] ([Id], [RestaurantName], [Type], [OpenHour], [EndHour], [Description], [UserId], [Status], [AppovalDate], [ApprovedBy], [AddressId], [TableQty]) VALUES (2, N'Kent Ice Cream', N'1', N'12:00:00', N'22:00:00', N'Best Ice Cream Fast Food Store', NULL, N'Pending', NULL, NULL, NULL, 10)
INSERT [dbo].[Restaurant] ([Id], [RestaurantName], [Type], [OpenHour], [EndHour], [Description], [UserId], [Status], [AppovalDate], [ApprovedBy], [AddressId], [TableQty]) VALUES (3, N'Daboba99', N'1', N'08:00:00', N'20:00:00', N'This is update to test', NULL, N'Pending', NULL, NULL, NULL, 5)
INSERT [dbo].[Restaurant] ([Id], [RestaurantName], [Type], [OpenHour], [EndHour], [Description], [UserId], [Status], [AppovalDate], [ApprovedBy], [AddressId], [TableQty]) VALUES (4, N'Daboba', N'1', N'12:00:00', N'20:00:00', N'Best Milk in Town', NULL, N'Pending', NULL, NULL, NULL, 5)
INSERT [dbo].[Restaurant] ([Id], [RestaurantName], [Type], [OpenHour], [EndHour], [Description], [UserId], [Status], [AppovalDate], [ApprovedBy], [AddressId], [TableQty]) VALUES (5, N'Black Whale', N'1', N'12:00:00', N'20:00:00', N'Milk Tea', NULL, N'Pending', NULL, NULL, NULL, 5)
INSERT [dbo].[Restaurant] ([Id], [RestaurantName], [Type], [OpenHour], [EndHour], [Description], [UserId], [Status], [AppovalDate], [ApprovedBy], [AddressId], [TableQty]) VALUES (6, N'Daboba2', N'1', N'12:00:00', N'20:00:00', N'Best Milk in Town', NULL, N'Pending', NULL, NULL, NULL, 5)
INSERT [dbo].[Restaurant] ([Id], [RestaurantName], [Type], [OpenHour], [EndHour], [Description], [UserId], [Status], [AppovalDate], [ApprovedBy], [AddressId], [TableQty]) VALUES (7, N'Testing Restaurant Application', N'Fast Food', N'08:00:00', N'22:00:00', N'Testing to Ask For Creating of Restaurant', N'b81e3353-a5ed-48a5-9091-c51ba0005a7f', N'Approved', CAST(N'2021-06-14 05:06:59.000' AS DateTime), N'14760208-6885-4d60-8bf7-89df6c3d79bd', NULL, 3)
INSERT [dbo].[Restaurant] ([Id], [RestaurantName], [Type], [OpenHour], [EndHour], [Description], [UserId], [Status], [AppovalDate], [ApprovedBy], [AddressId], [TableQty]) VALUES (8, N'JohnCena5''s Restaurant', N'Cafe', N'08:00:00', N'22:00:00', N'Second Restaurant For John Cena', N'b81e3353-a5ed-48a5-9091-c51ba0005a7f', N'Pending', NULL, NULL, NULL, 3)
SET IDENTITY_INSERT [dbo].[Restaurant] OFF
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

INSERT [dbo].[UserProfile] ([Id], [UserId], [Username], [FirstName], [LastName], [Role], [DateRequested], [DateUpdated], [UpdatedBy], [Status]) VALUES (1, N'06ad5138-61e1-4f1e-82a6-d438c21610cc', N'JohnCena04', N'John 04', N'Cena04', N'Owner', CAST(N'2021-06-13 09:01:04.897' AS DateTime), CAST(N'2021-06-14 00:59:49.000' AS DateTime), N'14760208-6885-4d60-8bf7-89df6c3d79bd', N'Approve')
INSERT [dbo].[UserProfile] ([Id], [UserId], [Username], [FirstName], [LastName], [Role], [DateRequested], [DateUpdated], [UpdatedBy], [Status]) VALUES (2, N'2b82d205-206a-4ba5-93b2-d13e3e4d2b0a', N'YapKinHoe99', N'Yap ', N'Kin Hoe 99', N'Owner', CAST(N'2021-06-13 09:01:04.000' AS DateTime), CAST(N'2021-06-14 00:59:49.000' AS DateTime), N'14760208-6885-4d60-8bf7-89df6c3d79bd', N'Approve')
INSERT [dbo].[UserProfile] ([Id], [UserId], [Username], [FirstName], [LastName], [Role], [DateRequested], [DateUpdated], [UpdatedBy], [Status]) VALUES (3, N'2e70e23d-e41f-4b41-b3b0-8fea6336a461', N'Testing99', N'Testing', N'User 99', N'Owner', CAST(N'2021-06-13 09:01:04.897' AS DateTime), NULL, NULL, N'Pending')
INSERT [dbo].[UserProfile] ([Id], [UserId], [Username], [FirstName], [LastName], [Role], [DateRequested], [DateUpdated], [UpdatedBy], [Status]) VALUES (4, N'38bab46b-6e31-47f8-b2a3-97bef8bd5ff4', N'Customer03', N'Customer', N'03', N'Owner', CAST(N'2021-06-13 09:01:04.897' AS DateTime), NULL, NULL, N'Pending')
INSERT [dbo].[UserProfile] ([Id], [UserId], [Username], [FirstName], [LastName], [Role], [DateRequested], [DateUpdated], [UpdatedBy], [Status]) VALUES (5, N'3c716f2b-840c-460a-9de4-d961e62c0ff5', N'Poro99', N'Poro', N'Tomato', N'Owner', CAST(N'2021-06-13 09:01:04.897' AS DateTime), NULL, NULL, N'Pending')
INSERT [dbo].[UserProfile] ([Id], [UserId], [Username], [FirstName], [LastName], [Role], [DateRequested], [DateUpdated], [UpdatedBy], [Status]) VALUES (6, N'6d1a3e7d-c4fb-4915-b8dc-d2cc0a0c1bae', N'Testing11', N'Testing', N'Request Owner Role', N'Owner', CAST(N'2021-06-13 19:36:40.000' AS DateTime), NULL, NULL, N'Pending')
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Restaurant] FOREIGN KEY([RestaurantId])
REFERENCES [dbo].[Restaurant] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Restaurant]
GO
ALTER TABLE [dbo].[Restaurant]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Restaurant] CHECK CONSTRAINT [FK_Restaurant_Address]
GO
ALTER TABLE [dbo].[Restaurant_Follower]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_Follower_Restaurant] FOREIGN KEY([RestaurantId])
REFERENCES [dbo].[Restaurant] ([Id])
GO
ALTER TABLE [dbo].[Restaurant_Follower] CHECK CONSTRAINT [FK_Restaurant_Follower_Restaurant]
GO
USE [master]
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET  READ_WRITE 
GO
