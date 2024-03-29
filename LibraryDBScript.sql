USE [master]
GO
/****** Object:  Database [Login]    Script Date: 22-11-2023 10:31:47 AM ******/
CREATE DATABASE [Login]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Login.mdf', FILENAME = N'C:\Users\IS001\Source\Repos\Library\Library\App_Data\Login.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Login_log.ldf', FILENAME = N'C:\Users\IS001\Source\Repos\Library\Library\App_Data\Login_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Login] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Login].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Login] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Login] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Login] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Login] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Login] SET ARITHABORT OFF 
GO
ALTER DATABASE [Login] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Login] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Login] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Login] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Login] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Login] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Login] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Login] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Login] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Login] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Login] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Login] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Login] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Login] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Login] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Login] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Login] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Login] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Login] SET  MULTI_USER 
GO
ALTER DATABASE [Login] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Login] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Login] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Login] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Login] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Login] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Login] SET QUERY_STORE = OFF
GO
USE [Login]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 22-11-2023 10:31:47 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[books]    Script Date: 22-11-2023 10:31:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[books](
	[SNO] [int] IDENTITY(1,1) NOT NULL,
	[Book_Name] [varchar](50) NULL,
	[Author_Name] [varchar](50) NULL,
	[category] [varchar](10) NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExceptionLogging]    Script Date: 22-11-2023 10:31:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExceptionLogging](
	[LogId] [bigint] IDENTITY(1,1) NOT NULL,
	[ExceptionMsg] [varchar](max) NULL,
	[ExceptionType] [varchar](max) NULL,
	[ExceptionSource] [nvarchar](max) NULL,
	[ExceptionURL] [varchar](max) NULL,
	[LogDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IssuedBooks]    Script Date: 22-11-2023 10:31:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IssuedBooks](
	[SNO] [int] NOT NULL,
	[Book_Name] [nvarchar](50) NOT NULL,
	[Author_Name] [nvarchar](50) NOT NULL,
	[category] [nvarchar](50) NOT NULL,
	[UserEmail] [nvarchar](50) NOT NULL,
	[IssuedON] [datetime] NOT NULL,
	[ReturnON] [datetime] NOT NULL,
	[Fine] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 22-11-2023 10:31:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Epic] [int] NOT NULL,
	[ConfirmPassword] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Login] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Online Books Record]    Script Date: 22-11-2023 10:31:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Online Books Record](
	[SNO] [int] NOT NULL,
	[Book Name] [nvarchar](50) NULL,
	[Author Name] [nvarchar](50) NULL,
	[User Email] [nvarchar](50) NULL,
	[Issued ON] [datetime] NULL,
	[Return ON] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[SNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Online_Book_Orders]    Script Date: 22-11-2023 10:31:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Online_Book_Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[First Name] [nvarchar](50) NULL,
	[Last Name] [nvarchar](50) NULL,
	[Area] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Postal Code] [nvarchar](50) NULL,
	[Phone Number] [nvarchar](50) NULL,
	[Email] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_UserMaster]    Script Date: 22-11-2023 10:31:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserMaster](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](25) NULL,
	[LoginID] [varchar](25) NULL,
	[Password] [varchar](200) NULL,
	[IsLocked] [varchar](1) NULL,
	[IsLogin] [bit] NULL,
	[LoginCnt] [int] NULL,
	[UserSession] [varchar](200) NULL,
	[LastLogin] [datetime] NULL,
	[Email] [varchar](50) NULL,
	[ContactNo] [varchar](20) NULL,
	[UserRole] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CrDate] [datetime] NULL,
	[CrBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
 CONSTRAINT [PK_tbl_UserMaster] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Login] SET  READ_WRITE 
GO
