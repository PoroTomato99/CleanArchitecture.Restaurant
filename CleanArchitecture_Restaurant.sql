USE [master]
GO
/****** Object:  Database [Restaurant_CleanArchitecture]    Script Date: 31/5/2021 5:50:41 AM ******/
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
/****** Object:  Table [dbo].[Restaurant]    Script Date: 31/5/2021 5:50:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RestaurantName] [nvarchar](100) NOT NULL,
	[Type] [int] NOT NULL,
	[OpenHour] [nvarchar](50) NOT NULL,
	[EndHour] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Restaurant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Restaurant] ON 

INSERT [dbo].[Restaurant] ([Id], [RestaurantName], [Type], [OpenHour], [EndHour], [Description]) VALUES (2, N'Kent Ice Cream', 1, N'12:00:00', N'10:00:00', N'Best Ice Cream Fast Food Store')
INSERT [dbo].[Restaurant] ([Id], [RestaurantName], [Type], [OpenHour], [EndHour], [Description]) VALUES (3, N'Daboba99', 1, N'08:00:00', N'20:00:00', N'This is update to test')
INSERT [dbo].[Restaurant] ([Id], [RestaurantName], [Type], [OpenHour], [EndHour], [Description]) VALUES (4, N'Daboba', 1, N'12:00:00.00', N'20:00:00.00', N'Best Milk in Town')
INSERT [dbo].[Restaurant] ([Id], [RestaurantName], [Type], [OpenHour], [EndHour], [Description]) VALUES (5, N'Black Whale', 1, N'12:00:00.00', N'20:00:00.00', N'Milk Tea')
INSERT [dbo].[Restaurant] ([Id], [RestaurantName], [Type], [OpenHour], [EndHour], [Description]) VALUES (6, N'Daboba2', 1, N'12:00:00', N'20:00:00', N'Best Milk in Town')
SET IDENTITY_INSERT [dbo].[Restaurant] OFF
USE [master]
GO
ALTER DATABASE [Restaurant_CleanArchitecture] SET  READ_WRITE 
GO
