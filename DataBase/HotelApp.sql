/*
NAME: Shaira Shrapova (WMADJr B)
DATE: 05/30/2022
PURPOSE: Database HotelApp for DP Project
*/

--DROP DATABASE HotelApp ; 
USE [master]
GO

IF DB_ID('HotelApp') IS NOT NULL
BEGIN
	DROP DATABASE HotelApp;
END

GO

CREATE DATABASE [HotelApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HotelApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HotelApp.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HotelApp] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HotelApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HotelApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotelApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelApp] SET RECOVERY FULL 
GO
ALTER DATABASE [HotelApp] SET  MULTI_USER 
GO
ALTER DATABASE [HotelApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelApp] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HotelApp', N'ON'
GO
ALTER DATABASE [HotelApp] SET QUERY_STORE = OFF
GO
USE [HotelApp]
GO
/****** 1. Object:  Table [dbo].[Amentities] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amentities](
	[AmentityID] [int] IDENTITY(1,1) NOT NULL,
	[AmentityName] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Amentities] PRIMARY KEY CLUSTERED 
(
	[AmentityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 2. Object:  Table [dbo].[Hotel]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[HotelID] [int] IDENTITY(1,1) NOT NULL,
	[HotelName] [varchar](255) NOT NULL,
	[CivicNumber] [varchar](255) NOT NULL,
	[StreetName] [varchar] (255) NOT NULL,
	[City] [varchar] (255) NOT NULL,
	[Province] [varchar] (255) NOT NULL,
	[PhoneNumber] [varchar] (255) NOT NULL,
	[PathToPicture] [varchar] (255) NOT NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 3. Object:  Table [dbo].[AmentitiesHotel] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AmentitiesHotel](
	[HotelID] [int] NOT NULL,
	[AmentityID] [int] NOT NULL)
GO

/****** 4. Object:  Table [dbo].[RoomType] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomType](
	[RoomTypeID] [int] IDENTITY(1,1) NOT NULL,
	[RoomTypeName] [varchar](50) NOT NULL,
	[RoomTypeDescription] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
(
	[RoomTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 5. Object:  Table [dbo].[Room] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[HotelID] [int] NOT NULL,
	[RoomTypeID] [int] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 6. Object:  Table [dbo].[Booking] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingID] [int] IDENTITY(1,1) NOT NULL,
	[AgentID] [int] NOT NULL,
	[RoomID] [int] NOT NULL,
	[GuestID] [int] NOT NULL,
	[ArrivalDate][datetime] NOT NULL,
	[DepartureDate][datetime] NOT NULL
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 7. Object:  Table [dbo].[Guest] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[GuestID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[CivicNumber] [varchar](50) NOT NULL,
	[StreetName] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Province] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[IsVip] [bit] NOT NULL,
 CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED 
(
	[GuestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** 8. Object:  Table [dbo].[Agent] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agent](
	[AgentID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Company] [varchar](50) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Agent] PRIMARY KEY CLUSTERED 
(
	[AgentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** 9. Object:  Table [dbo].[Password] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Password](
	[PasswordID] [int] IDENTITY(1,1) NOT NULL,
	[AgentID] [int] NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Password] PRIMARY KEY CLUSTERED 
(
	[PasswordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Amentities] ON
INSERT [dbo].[Amentities]   ([AmentityID], [AmentityName]) VALUES (1, 'Free parking')
INSERT [dbo].[Amentities]   ([AmentityID], [AmentityName]) VALUES (2, 'Pool and Spa')
INSERT [dbo].[Amentities]   ([AmentityID], [AmentityName]) VALUES (3, 'Free Breakfast')
SET IDENTITY_INSERT [dbo].[Amentities] OFF

SET IDENTITY_INSERT [dbo].[Hotel] ON 
INSERT [dbo].[Hotel]   ([HotelID], [HotelName], [CivicNumber], [StreetName], [City], [Province], [PhoneNumber], [PathToPicture]) VALUES (1, 'Holiday Inn', '502', 'Kennedy Street', 'Moncton', 'NB', '5062349892', 'PathToPicture1')
INSERT [dbo].[Hotel]   ([HotelID], [HotelName], [CivicNumber], [StreetName], [City], [Province], [PhoneNumber], [PathToPicture]) VALUES (2, 'Hyatt Place', '1000', 'Main St', 'Moncton', 'NB', '5068749852', 'PathToPicture1')
INSERT [dbo].[Hotel]   ([HotelID], [HotelName], [CivicNumber], [StreetName], [City], [Province], [PhoneNumber], [PathToPicture]) VALUES (3, 'Hilton', '2356', 'Highfield St', 'Moncton', 'NB', '5068745591', 'PathToPicture1')
SET IDENTITY_INSERT [dbo].[Hotel] OFF

--SET IDENTITY_INSERT [dbo].[AmentitiesHotel] ON 
INSERT [dbo].[AmentitiesHotel]   ([HotelID], [AmentityID]) VALUES (1, 1)
INSERT [dbo].[AmentitiesHotel]   ([HotelID], [AmentityID]) VALUES (2, 2)
INSERT [dbo].[AmentitiesHotel]   ([HotelID], [AmentityID]) VALUES (3, 3)
--SET IDENTITY_INSERT [dbo].[AmentitiesHotel] OFF 

SET IDENTITY_INSERT [dbo].[RoomType] ON 
INSERT [dbo].[RoomType]   ([RoomTypeID], [RoomTypeName], [RoomTypeDescription]) VALUES (1, 'Queen Room', 'Room size 28 m²')
INSERT [dbo].[RoomType]   ([RoomTypeID], [RoomTypeName], [RoomTypeDescription]) VALUES (2, 'King Room',	'Room size 35 m²')
INSERT [dbo].[RoomType]   ([RoomTypeID], [RoomTypeName], [RoomTypeDescription]) VALUES (3, 'Premium King Room',	'Room size 42 m² with extra king bed')
SET IDENTITY_INSERT [dbo].[RoomType] OFF

SET IDENTITY_INSERT [dbo].[Room] ON 
INSERT [dbo].[Room]   ([RoomID], [HotelID], [RoomTypeID]) VALUES (1, 1, 1)
INSERT [dbo].[Room]   ([RoomID], [HotelID], [RoomTypeID]) VALUES (2, 2, 2) 
INSERT [dbo].[Room]   ([RoomID], [HotelID], [RoomTypeID]) VALUES (3, 3, 3)
SET IDENTITY_INSERT [dbo].[Room] OFF


SET IDENTITY_INSERT [dbo].[Booking] ON 
INSERT [dbo].[Booking]   ([BookingID], [AgentID], [RoomID], [GuestID], [ArrivalDate], [DepartureDate]) VALUES (1, 1, 1, 1, '2022-05-06', '2022-05-07')
INSERT [dbo].[Booking]   ([BookingID], [AgentID], [RoomID], [GuestID], [ArrivalDate], [DepartureDate]) VALUES (2, 2, 2, 2, '2022-05-08', '2022-05-10')
INSERT [dbo].[Booking]   ([BookingID], [AgentID], [RoomID], [GuestID], [ArrivalDate], [DepartureDate]) VALUES (3, 3, 3, 3, '2022-05-12', '2022-05-16')
SET IDENTITY_INSERT [dbo].[Booking] OFF

SET IDENTITY_INSERT [dbo].[Guest] ON 
INSERT [dbo].[Guest]   ([GuestID], [FirstName], [LastName], [CivicNumber], [StreetName], [City], [Province], [PhoneNumber], [Email], [IsVIP]) VALUES (1, 'Michael', 'Pierce', '132', 'Melanson', 'Moncton', 'NB', '5061209495', 'mpierce@gmail.com', 1)
INSERT [dbo].[Guest]   ([GuestID], [FirstName], [LastName], [CivicNumber], [StreetName], [City], [Province], [PhoneNumber], [Email], [IsVIP]) VALUES (2, 'Shaira', 'Sharapova', '87', 'Pierre St', 'Moncton', 'NB', '5061207691', 'ssharapova@gmail.com', 0)
INSERT [dbo].[Guest]   ([GuestID], [FirstName], [LastName], [CivicNumber], [StreetName], [City], [Province], [PhoneNumber], [Email], [IsVIP]) VALUES (3, 'Sebastien', 'Robichaud', '99', 'Suzelle St', 'Moncton', 'NB', '5061207688', 'srobichaud@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[Guest] OFF

SET IDENTITY_INSERT [dbo].[Agent] ON 
INSERT [dbo].[Agent]   ([AgentID], [FirstName], [LastName], [Company], [Phone], [Email], [UserName]) VALUES (1, 'Anna', 'Smith', 'WorldBest', '5061208987', 'anna12@gmail.com', 'anna01')
INSERT [dbo].[Agent]   ([AgentID], [FirstName], [LastName],[Company], [Phone], [Email], [UserName]) VALUES (2, 'Kate', 'Jones', 'ITravel', '5061200087', 'kate@gmail.com', 'kate01')
INSERT [dbo].[Agent]   ([AgentID], [FirstName], [LastName],[Company], [Phone], [Email], [UserName]) VALUES (3, 'Maria', 'Pierce', 'CheapTrip', '5061200987', 'maria@gmail.com', 'maria01')
SET IDENTITY_INSERT [dbo].[Agent] OFF

SET IDENTITY_INSERT [dbo].[Password] ON 
INSERT [dbo].[Password]   ([PasswordID], [AgentID], [Password]) VALUES (1, 1, '54324')
INSERT [dbo].[Password]   ([PasswordID], [AgentID], [Password]) VALUES (2, 2, '5hdkf4')
INSERT [dbo].[Password]   ([PasswordID], [AgentID], [Password]) VALUES (3, 3, '5sd324')
SET IDENTITY_INSERT [dbo].[Password] OFF


ALTER TABLE [dbo].[AmentitiesHotel]  WITH CHECK ADD CONSTRAINT [FK_AmentitiesHotel_Hotel] FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotel] ([HotelID])
GO
ALTER TABLE [dbo].[AmentitiesHotel] CHECK CONSTRAINT [FK_AmentitiesHotel_Hotel]
GO

ALTER TABLE [dbo].[AmentitiesHotel]  WITH CHECK ADD CONSTRAINT [FK_AmentitiesHotel_Amentities] FOREIGN KEY([AmentityID])
REFERENCES [dbo].[Amentities] ([AmentityID])
GO
ALTER TABLE [dbo].[AmentitiesHotel] CHECK CONSTRAINT [FK_AmentitiesHotel_Amentities]
GO

ALTER TABLE [dbo].[Room]  WITH CHECK ADD CONSTRAINT [FK_Room_Hotel] FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotel] ([HotelID])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Hotel]
GO

ALTER TABLE [dbo].[Room]  WITH CHECK ADD CONSTRAINT [FK_Room_RoomType] FOREIGN KEY([RoomTypeID])
REFERENCES [dbo].[RoomType] ([RoomTypeID])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_RoomType]
GO

--Booking AgentID
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD CONSTRAINT [FK_Booking_Agent] FOREIGN KEY([AgentID])
REFERENCES [dbo].[Agent] ([AgentID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Agent]
GO

--Booking RoomID
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD CONSTRAINT [FK_Booking_Room] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Room]
GO

--Booking GuestID
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD CONSTRAINT [FK_Booking_Guest] FOREIGN KEY([GuestID])
REFERENCES [dbo].[Guest] ([GuestID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Guest]
GO

--Password AgentID
ALTER TABLE [dbo].[Password]  WITH CHECK ADD CONSTRAINT [FK_Password_Agent] FOREIGN KEY([AgentID])
REFERENCES [dbo].[Agent] ([AgentID])
GO
ALTER TABLE [dbo].[Password] CHECK CONSTRAINT [FK_Password_Agent]
GO


GO
USE [master]
GO
ALTER DATABASE [HotelApp] SET  READ_WRITE 
GO
