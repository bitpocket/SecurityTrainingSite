USE [master]
GO
CREATE DATABASE [SecurityTraining] ON  PRIMARY 
( NAME = N'SecurityTraining', FILENAME = N'c:\SecurityTraining\SecurityTraining.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SecurityTraining_log', FILENAME = N'c:\SecurityTraining\SecurityTraining_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SecurityTraining] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SecurityTraining].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SecurityTraining] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [SecurityTraining] SET ANSI_NULLS OFF
GO
ALTER DATABASE [SecurityTraining] SET ANSI_PADDING OFF
GO
ALTER DATABASE [SecurityTraining] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [SecurityTraining] SET ARITHABORT OFF
GO
ALTER DATABASE [SecurityTraining] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [SecurityTraining] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [SecurityTraining] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [SecurityTraining] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [SecurityTraining] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [SecurityTraining] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [SecurityTraining] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [SecurityTraining] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [SecurityTraining] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [SecurityTraining] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [SecurityTraining] SET  DISABLE_BROKER
GO
ALTER DATABASE [SecurityTraining] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [SecurityTraining] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [SecurityTraining] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [SecurityTraining] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [SecurityTraining] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [SecurityTraining] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [SecurityTraining] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [SecurityTraining] SET  READ_WRITE
GO
ALTER DATABASE [SecurityTraining] SET RECOVERY SIMPLE
GO
ALTER DATABASE [SecurityTraining] SET  MULTI_USER
GO
ALTER DATABASE [SecurityTraining] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [SecurityTraining] SET DB_CHAINING OFF
GO
USE [SecurityTraining]
GO

CREATE USER [sectest_usr] FOR LOGIN [sectest_login] WITH DEFAULT_SCHEMA=[dbo]
GO

CREATE USER [nt_user] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO

CREATE USER [builtin] FOR LOGIN [BUILTIN\Users]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Secret](
	[key] [int] NULL,
	[value] [varchar](255) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Links](
	[link] [varchar](255) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comments](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[user_id] [int] FOREIGN KEY REFERENCES Users(id),
	[comment] [varchar](255) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChosenPets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[animal] [varchar](255) NOT NULL,
	[name] [varchar](255) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT INTO [SecurityTraining].[dbo].[Users]
           ([UserName]
           ,[Password])
     VALUES
           ('admin', 'admin1')
GO
INSERT INTO [SecurityTraining].[dbo].[Users]
           ([UserName]
           ,[Password])
     VALUES
           ('anotheruser','awsomeP@ssw0rd')
GO