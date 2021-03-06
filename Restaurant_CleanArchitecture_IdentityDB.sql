USE [master]
GO
/****** Object:  Database [Restaurant_CleanArchitecture_IdentityDB]    Script Date: 15/6/2021 6:50:43 PM ******/
CREATE DATABASE [Restaurant_CleanArchitecture_IdentityDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Restaurant_CleanArchitecture_IdentityDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Restaurant_CleanArchitecture_IdentityDB.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Restaurant_CleanArchitecture_IdentityDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Restaurant_CleanArchitecture_IdentityDB_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Restaurant_CleanArchitecture_IdentityDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET RECOVERY FULL 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET  MULTI_USER 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Restaurant_CleanArchitecture_IdentityDB', N'ON'
GO
USE [Restaurant_CleanArchitecture_IdentityDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 15/6/2021 6:50:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 15/6/2021 6:50:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 15/6/2021 6:50:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 15/6/2021 6:50:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 15/6/2021 6:50:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 15/6/2021 6:50:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 15/6/2021 6:50:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 15/6/2021 6:50:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210527031157_Initial-Migration', N'5.0.6')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'07e38feb-b2ca-484c-96a0-f8778665f010', N'Admin', N'ADMIN', N'b3803254-5060-4cee-a680-12fd1efc717b')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'42b05d5b-6980-48c5-a27a-4c89de2ba976', N'Owner', N'OWNER', N'1033cb13-b408-4229-8e0e-b2b91d12eae3')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'6d2c13b4-77df-4078-976e-d26bf3ffc593', N'Customer', N'CUSTOMER', N'610c6a5a-a7ea-4ec7-8875-cc1023fb4a99')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'872148dc-133c-4f0e-8d5d-d3b67eb5c6c0', N'Employee', N'EMPLOYEE', N'2f1422a8-d6d6-4cc2-863a-059fd5e4e562')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'14760208-6885-4d60-8bf7-89df6c3d79bd', N'07e38feb-b2ca-484c-96a0-f8778665f010')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3c716f2b-840c-460a-9de4-d961e62c0ff5', N'07e38feb-b2ca-484c-96a0-f8778665f010')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'668d1c85-4e9d-407c-b49f-2a95af386bf1', N'07e38feb-b2ca-484c-96a0-f8778665f010')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'06ad5138-61e1-4f1e-82a6-d438c21610cc', N'42b05d5b-6980-48c5-a27a-4c89de2ba976')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2b82d205-206a-4ba5-93b2-d13e3e4d2b0a', N'42b05d5b-6980-48c5-a27a-4c89de2ba976')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b81e3353-a5ed-48a5-9091-c51ba0005a7f', N'42b05d5b-6980-48c5-a27a-4c89de2ba976')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'06ad5138-61e1-4f1e-82a6-d438c21610cc', N'6d2c13b4-77df-4078-976e-d26bf3ffc593')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2e70e23d-e41f-4b41-b3b0-8fea6336a461', N'6d2c13b4-77df-4078-976e-d26bf3ffc593')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'31b9a545-fe42-4d26-9de3-825384a353b0', N'6d2c13b4-77df-4078-976e-d26bf3ffc593')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'38bab46b-6e31-47f8-b2a3-97bef8bd5ff4', N'6d2c13b4-77df-4078-976e-d26bf3ffc593')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6d1a3e7d-c4fb-4915-b8dc-d2cc0a0c1bae', N'6d2c13b4-77df-4078-976e-d26bf3ffc593')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8681c952-fb87-4f6c-b7a3-6660c8b39f94', N'6d2c13b4-77df-4078-976e-d26bf3ffc593')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9d9cdbd4-f035-46b5-a929-66d1f795c1c4', N'6d2c13b4-77df-4078-976e-d26bf3ffc593')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'acbd29eb-bee9-4455-af03-f066f9d11647', N'6d2c13b4-77df-4078-976e-d26bf3ffc593')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'adcffe47-f183-4a9c-b340-6a9e968ef0f5', N'6d2c13b4-77df-4078-976e-d26bf3ffc593')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ae38dba1-1203-49ed-836f-ff0b479ed388', N'6d2c13b4-77df-4078-976e-d26bf3ffc593')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b81e3353-a5ed-48a5-9091-c51ba0005a7f', N'6d2c13b4-77df-4078-976e-d26bf3ffc593')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bdd61d5f-0fcf-44ab-814a-2de2583e0b5a', N'6d2c13b4-77df-4078-976e-d26bf3ffc593')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cb31a9dc-1245-428a-a5cc-ef81235070c9', N'6d2c13b4-77df-4078-976e-d26bf3ffc593')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ea33d3fb-7526-4588-97a6-94baf04e9e1c', N'6d2c13b4-77df-4078-976e-d26bf3ffc593')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'06ad5138-61e1-4f1e-82a6-d438c21610cc', N'JohnCena04', N'JOHNCENA04', N'JohnCena04@gmail.com', N'JOHNCENA04@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEBsYO30yfncaHzGRFPUdS+XK9OsG46ZRfj1k0HPDz3JFlk+2H94KrcUC8VxBbzA6Pg==', N'ON5C7D6HXUMTFATEJLI3GUVCUOEP7IMM', N'87f86270-d2af-4dd6-a438-95f892e63189', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'14760208-6885-4d60-8bf7-89df6c3d79bd', N'SuperUser01', N'SUPERUSER01', N'SuperUser01@gmail.com', N'SUPERUSER01@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEM8Xe5Gi6Ikrzi+b7R06c7Me+aDgcX2AYuU9qzsAwkxHEerEKA8mMG8aRaw6PQl5IA==', N'VFXTAWPVYK3KWW4EN4ESKQZWK3KKE5AC', N'd8472c86-3046-47e6-b27f-7a4f99cf11fd', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2b82d205-206a-4ba5-93b2-d13e3e4d2b0a', N'YapKinHoe99', N'YAPKINHOE99', N'yapkinhoe1@gmail.com', N'YAPKINHOE1@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEPnZRxtm3VOqutppZKMWT+L40HdxF0ma3epnm0xx+kHT3XSOVog8gfs/ckkCP3JToQ==', N'4LNQXUI37UWZYPJNPKXE2GOEBP2OLAG7', N'8189b77d-a454-4c70-bfe6-8c25f6be6299', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2e70e23d-e41f-4b41-b3b0-8fea6336a461', N'Testing99', N'TESTING99', N'Testing99@gmail.com', N'TESTING99@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEN6MZlIJoTV1f1q7xvymC0lBTS2i5B40juDukVVO4145cnA0F8Pe7hFIb2Ic9T+mJw==', N'LXOULWNT4NY5DCX64LQ2S72K46PHIVSL', N'eb22a2d8-3772-40fd-99e7-f5e2f73291da', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'31b9a545-fe42-4d26-9de3-825384a353b0', N'JohnCena', N'JOHNCENA', N'JohnCena@gmail.com', N'JOHNCENA@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEN7cEWyPEa2zLN1+R5zY7w62bxUwh/vz4K3QjmYA7rgAacAwLgldyOmlemdRv2V2/w==', N'NFGZ5HLYY7YXBBPT5XQGLLMHVRUFOL7E', N'2432e507-e68d-421f-8be2-51a772cc31c9', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'38bab46b-6e31-47f8-b2a3-97bef8bd5ff4', N'Customer03', N'CUSTOMER03', N'custome03@gmail.com', N'CUSTOME03@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEMeZeU3iOTrEyg/eDTuLcuJcyzyKFEPFZ05GEbcrUKdrSo8ms2hos9a1VjpmrvIPyw==', N'KG7HSAIUOQZT7BEIRWVQ57QIFKCQPFK5', N'06d0e2bd-807c-458d-ba58-5c5eccc71ee9', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3c716f2b-840c-460a-9de4-d961e62c0ff5', N'Poro99', N'PORO99', N'kinhoe0414@gmail.com', N'KINHOE0414@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKh7Qa/7TIYQdjYdpBihxTEKD8RWPm3NpjeOjzYtNRo5hg4zU3grV0y03ktq5M4G2w==', N'OY2XNWVPMNJ5DDWJPYSYATHRZ34DMWIR', N'b375d585-5389-422c-a060-ccf40585e72d', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'668d1c85-4e9d-407c-b49f-2a95af386bf1', N'NewAdmin99', N'NEWADMIN99', N'user@example.com', N'USER@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAEOzxq8hU3TQSUe2QmIHXybFappH1Yg0tUfY5gf31qrpOX893nm9XQNjTV0IsE3urig==', N'X2FJC6J56Q5P6FBABOFGDTWROPDZQNSE', N'a0e9eede-3ab7-4262-bc22-cf0cec885070', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6d1a3e7d-c4fb-4915-b8dc-d2cc0a0c1bae', N'Testing11', N'TESTING11', N'Testing11@gmail.com', N'TESTING11@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEJuh77FVyPHEKopfUSFtbGR9aY1qusICp+oIBimu5FZaTu55YbAk3UXxXmqR32UyHw==', N'VDX4V4AMWJZBSJLI4GUAYPCCOPIM6GT5', N'81198bed-f178-44f6-a797-21be1f04fdae', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8681c952-fb87-4f6c-b7a3-6660c8b39f94', N'NormalCustomerPoro', N'NORMALCUSTOMERPORO', N'NormalCustomerPoro@gmail.com', N'NORMALCUSTOMERPORO@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAELuTK495HWnDllx/++VtFZ/Cm6FMHE3PwuM33pRC0NBFQH1Plb6mdUH1NwT4DdreRg==', N'CGVB2QBGOSLAGLDFLHQ7DNOTELNLLEST', N'180ea1aa-c440-4a32-92e1-ed19aeaba5fd', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9d9cdbd4-f035-46b5-a929-66d1f795c1c4', N'JohnCena02', N'JOHNCENA02', N'JohnCena02@gmail.com', N'JOHNCENA02@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEPufyzWT9ho82uayKpMoDY59DIrFOAsUEe0e7xPemwLqoygdWJ7qyqE1M59WxCnZrw==', N'SJJDUEFIRUNYOSTX2IOIVQWWM6XEYAJ4', N'97ee16cc-5ff6-43a3-bcb7-eda1a0442f50', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'acbd29eb-bee9-4455-af03-f066f9d11647', N'JohnCena10', N'JOHNCENA10', N'JohnCena10@gmail.com', N'JOHNCENA10@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEMZfW7HEShIiwTwKQa1/QsFgUC8xZ4Sa7xdRu3bdAju/dp0eSqTg1RQDXQhNFwkvUQ==', N'Z2J2SC6DMTJ7GUHPV6NEFAQA3UGCENIO', N'f48cf3a8-c4c5-46a8-a7e8-002d19eefb8f', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'adcffe47-f183-4a9c-b340-6a9e968ef0f5', N'NewCustomer99', N'NEWCUSTOMER99', N'NewCustomer@gmail.com', N'NEWCUSTOMER@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEPgf0GFHNJIVZpMvfLDC9UfQde+Lh/4FEhAVfPNxV+N0fMBqfPJ0LEnY/zCVGnrA6Q==', N'ISFCTIWAVUFNVALOMGCRTKHFVV6SYKKE', N'befca236-0afd-4431-aa3d-12ae67bb2a7d', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ae38dba1-1203-49ed-836f-ff0b479ed388', N'TeeHongChun', N'TEEHONGCHUN', N'hongchun@gmail.com', N'HONGCHUN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEA/rtXf7sX2JyfE/2cRnQPlC20kYlcCZPjiSuVHcyEp7n2iScANNeYrT4f6AR7aKHA==', N'3ZHUNGHJRE6OVRGF33SZGZ2NG6EZKC4J', N'ea828aae-0785-4160-b179-b92fcc9f3381', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b81e3353-a5ed-48a5-9091-c51ba0005a7f', N'JohnCena05', N'JOHNCENA05', N'JohnCena05@gmail.com', N'JOHNCENA05@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEMgV5qKxtg79swBDPnfPurgiWZ6gW9Hc5pii49bhV+44lqSF4vOfU014srE4EI71QA==', N'WOSBWTHDAC4QG7GTFE36URLZYYXFYUQ7', N'63054350-7deb-4741-a05b-b9ab244a756e', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'bdd61d5f-0fcf-44ab-814a-2de2583e0b5a', N'KinHoe0414', N'KINHOE0414', N'kinhoe0414new@gmail.com', N'KINHOE0414NEW@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAELBSsLkLOhNvUTwmwOXFPy31nwxf2kYuEFYi4oBqXOi9gIgfpeUC5h9UI0foff2rLw==', N'J6B4SLR4OE5X365OYI2DARNXVFVEZWAP', N'a741a96e-6604-4d0b-b525-5bf1a33564b6', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'cb31a9dc-1245-428a-a5cc-ef81235070c9', N'Customer02', N'CUSTOMER02', N'custome02@gmail.com', N'CUSTOME02@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKtM22sqfe+RU2x8fuxwLZd1tUf+V/xqm73QiSmhuQ2eTF5mYLnOkYCm2O6NQJpHGg==', N'YN6S44OYWUCZRKNUG3S7CGN6RTITCU2X', N'0dad972e-25e6-495c-99c5-542e7e22c3d8', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ea33d3fb-7526-4588-97a6-94baf04e9e1c', N'Customer01', N'CUSTOMER01', N'customer@gmail.com', N'CUSTOMER@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEF0XBkPOfP23BYxZaBIdXounwxfRacoRjlDYNnlE35Hu0QCCUkGpaLyxSHsTS2xEqw==', N'U6QGISW6QTITGAH75DOYM2F6ZTC2PCIK', N'5e85a499-c354-4ec1-a712-613e3c99e8ef', NULL, 0, 0, NULL, 1, 0)
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 15/6/2021 6:50:43 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 15/6/2021 6:50:43 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 15/6/2021 6:50:43 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 15/6/2021 6:50:43 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 15/6/2021 6:50:43 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [EmailIndex]    Script Date: 15/6/2021 6:50:43 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 15/6/2021 6:50:43 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [Restaurant_CleanArchitecture_IdentityDB] SET  READ_WRITE 
GO
