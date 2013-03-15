USE [master]
GO

/****** Object:  Database [LinqChat]    Script Date: 03/12/2009 15:49:39 ******/
CREATE DATABASE [LinqChat] ON  PRIMARY 
( NAME = N'LinqChat', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\LinqChat.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LinqChat_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\LinqChat_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [LinqChat] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LinqChat].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [LinqChat] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [LinqChat] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [LinqChat] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [LinqChat] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [LinqChat] SET ARITHABORT OFF 
GO

ALTER DATABASE [LinqChat] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [LinqChat] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [LinqChat] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [LinqChat] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [LinqChat] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [LinqChat] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [LinqChat] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [LinqChat] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [LinqChat] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [LinqChat] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [LinqChat] SET  DISABLE_BROKER 
GO

ALTER DATABASE [LinqChat] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [LinqChat] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [LinqChat] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [LinqChat] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [LinqChat] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [LinqChat] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [LinqChat] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [LinqChat] SET  READ_WRITE 
GO

ALTER DATABASE [LinqChat] SET RECOVERY FULL 
GO

ALTER DATABASE [LinqChat] SET  MULTI_USER 
GO

ALTER DATABASE [LinqChat] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [LinqChat] SET DB_CHAINING OFF 
GO

------------------------------------------------------------------------------------------------------------------------------

USE [LinqChat]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [varchar](30) NOT NULL,
	[Lastname] [varchar](30) NOT NULL,
	[Username] [varchar](30) NOT NULL,
	[Password] [varchar](30) NOT NULL,
	[Sex] [varchar](1) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

------------------------------------------------------------------------------------------------------------------------------

USE [LinqChat]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Room](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

------------------------------------------------------------------------------------------------------------------------------

USE [LinqChat]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LoggedInUser](
	[LoggedInUserID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[RoomID] [int] NULL,
 CONSTRAINT [PK_LoggedInUser] PRIMARY KEY CLUSTERED 
(
	[LoggedInUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[LoggedInUser]  WITH CHECK ADD  CONSTRAINT [FK_LoggedInUser_Room] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO

ALTER TABLE [dbo].[LoggedInUser] CHECK CONSTRAINT [FK_LoggedInUser_Room]
GO

ALTER TABLE [dbo].[LoggedInUser]  WITH CHECK ADD  CONSTRAINT [FK_LoggedInUser_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO

ALTER TABLE [dbo].[LoggedInUser] CHECK CONSTRAINT [FK_LoggedInUser_User]
GO

------------------------------------------------------------------------------------------------------------------------------

USE [LinqChat]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PrivateMessage](
	[PrivateMessageID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ToUserID] [int] NOT NULL,
	[TimeUserSentInvitation] [datetime] NOT NULL,
 CONSTRAINT [PK_PrivateMessage] PRIMARY KEY CLUSTERED 
(
	[PrivateMessageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PrivateMessage]  WITH CHECK ADD  CONSTRAINT [FK_PrivateMessage_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO

ALTER TABLE [dbo].[PrivateMessage] CHECK CONSTRAINT [FK_PrivateMessage_User]
GO

ALTER TABLE [dbo].[PrivateMessage]  WITH CHECK ADD  CONSTRAINT [FK_PrivateMessage_User1] FOREIGN KEY([ToUserID])
REFERENCES [dbo].[User] ([UserID])
GO

ALTER TABLE [dbo].[PrivateMessage] CHECK CONSTRAINT [FK_PrivateMessage_User1]
GO

------------------------------------------------------------------------------------------------------------------------------

USE [LinqChat]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Message](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[RoomID] [int] NULL,
	[UserID] [int] NOT NULL,
	[ToUserID] [int] NULL,
	[Text] [varchar](100) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[Color] [varchar](50) NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Room] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO

ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Room]
GO

ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO

ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User]
GO

ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User1] FOREIGN KEY([ToUserID])
REFERENCES [dbo].[User] ([UserID])
GO

ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User1]
GO

ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_TimeStamp]  DEFAULT (getdate()) FOR [TimeStamp]
GO


