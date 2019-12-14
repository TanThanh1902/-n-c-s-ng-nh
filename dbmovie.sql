USE [master]
GO
/****** Object:  Database [DBMovie]    Script Date: 12/14/2019 3:00:58 PM ******/
CREATE DATABASE [DBMovie]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBMovie', FILENAME = N'D:\Document\Project\Movie\SQL\DBMovie.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBMovie_log', FILENAME = N'D:\Document\Project\Movie\SQL\DBMovie_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBMovie] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBMovie].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBMovie] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBMovie] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBMovie] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBMovie] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBMovie] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBMovie] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBMovie] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DBMovie] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBMovie] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBMovie] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBMovie] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBMovie] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBMovie] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBMovie] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBMovie] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBMovie] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBMovie] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBMovie] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBMovie] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBMovie] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBMovie] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBMovie] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBMovie] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBMovie] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBMovie] SET  MULTI_USER 
GO
ALTER DATABASE [DBMovie] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBMovie] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBMovie] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBMovie] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DBMovie]
GO
/****** Object:  Table [dbo].[TSql_Banner]    Script Date: 12/14/2019 3:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TSql_Banner](
	[IDBanner] [int] IDENTITY(1,1) NOT NULL,
	[Banner] [nvarchar](max) NOT NULL,
	[FilmName] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_TSql_Banner] PRIMARY KEY CLUSTERED 
(
	[IDBanner] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TSql_Categorys]    Script Date: 12/14/2019 3:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TSql_Categorys](
	[IDCategory] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TSql_Categorys] PRIMARY KEY CLUSTERED 
(
	[IDCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TSql_Chat]    Script Date: 12/14/2019 3:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TSql_Chat](
	[IDChat] [int] IDENTITY(1,1) NOT NULL,
	[Chat] [nvarchar](max) NOT NULL,
	[DateChat] [datetime] NULL,
	[IDUser] [int] NULL,
 CONSTRAINT [PK_TSql_Chat] PRIMARY KEY CLUSTERED 
(
	[IDChat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TSql_Comment]    Script Date: 12/14/2019 3:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TSql_Comment](
	[IDComment] [int] IDENTITY(1,1) NOT NULL,
	[IDFilm] [int] NOT NULL,
	[IDInfo] [int] NULL,
	[Comment] [nvarchar](max) NULL,
	[DatePost] [datetime] NULL,
 CONSTRAINT [PK_TSql_Comment] PRIMARY KEY CLUSTERED 
(
	[IDComment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TSql_Country]    Script Date: 12/14/2019 3:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TSql_Country](
	[IDCountry] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TSql_Country] PRIMARY KEY CLUSTERED 
(
	[IDCountry] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TSql_Film_Category]    Script Date: 12/14/2019 3:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TSql_Film_Category](
	[IDFilm_Category] [int] IDENTITY(1,1) NOT NULL,
	[IDFilm] [int] NOT NULL,
	[IDCategory] [int] NOT NULL,
	[DateCreate] [date] NULL,
	[DateUpdate] [date] NULL,
 CONSTRAINT [PK_TSql_Film_Category] PRIMARY KEY CLUSTERED 
(
	[IDFilm_Category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TSql_Films]    Script Date: 12/14/2019 3:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TSql_Films](
	[IDFilm] [int] IDENTITY(1,1) NOT NULL,
	[FilmName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Time] [int] NULL,
	[Author] [nvarchar](50) NULL,
	[DateSubmited] [date] NULL,
	[Image] [nvarchar](max) NULL,
	[IDCountry] [int] NULL,
	[Rating] [float] NULL,
	[Views] [int] NULL,
	[LinkFilm] [nvarchar](max) NULL,
	[Trailer] [nvarchar](max) NULL,
	[Download] [nvarchar](max) NULL,
	[Languages] [nvarchar](max) NULL,
	[Votes] [int] NULL,
 CONSTRAINT [PK_TSql_Films] PRIMARY KEY CLUSTERED 
(
	[IDFilm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TSql_Informations]    Script Date: 12/14/2019 3:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TSql_Informations](
	[IDInfo] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [int] NOT NULL,
	[DateCreate] [datetime] NULL,
	[ForgotPasswordCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_TSql_Informations] PRIMARY KEY CLUSTERED 
(
	[IDInfo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TSql_Reply]    Script Date: 12/14/2019 3:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TSql_Reply](
	[IDReply] [int] IDENTITY(1,1) NOT NULL,
	[IDComment] [int] NOT NULL,
	[Reply] [nvarchar](max) NOT NULL,
	[IDInfo] [int] NULL,
	[DatePost] [datetime] NULL,
 CONSTRAINT [PK_TSql_Reply] PRIMARY KEY CLUSTERED 
(
	[IDReply] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[TSql_Banner] ON 

INSERT [dbo].[TSql_Banner] ([IDBanner], [Banner], [FilmName], [Description]) VALUES (1, N'5.jpg', N'Tazran', N'Tarzan, having acclimated to life in London, is called back to his former home in the jungle to investigate the activities at a mining encampment.')
INSERT [dbo].[TSql_Banner] ([IDBanner], [Banner], [FilmName], [Description]) VALUES (2, N'2.jpg', N'Maximum Ride', N'Six children, genetically cross-bred with avian DNA, take flight around the country to discover their origins. Along the way, their mysterious past is ...')
INSERT [dbo].[TSql_Banner] ([IDBanner], [Banner], [FilmName], [Description]) VALUES (3, N'3.jpg', N'Independence', N'The fate of humanity hangs in the balance as the U.S. President and citizens decide if these aliens are to be trusted ...or feared')
INSERT [dbo].[TSql_Banner] ([IDBanner], [Banner], [FilmName], [Description]) VALUES (4, N'4.jpg', N'Central Intelligence', N'Bullied as a teen for being overweight, Bob Stone (Dwayne Johnson) shows up to his high school reunion looking fit and muscular. Claiming to be on a top-secret ...')
INSERT [dbo].[TSql_Banner] ([IDBanner], [Banner], [FilmName], [Description]) VALUES (5, N'6.jpg', N'Ice Age', N'In the film''s epilogue, Scrat keeps struggling to control the alien ship until it crashes on Mars, destroying all life on the planet.')
INSERT [dbo].[TSql_Banner] ([IDBanner], [Banner], [FilmName], [Description]) VALUES (6, N'7.jpg', N'X - Man', N'In 1977, paranormal investigators Ed (Patrick Wilson) and Lorraine Warren come out of a self-imposed sabbatical to travel to Enfield, a borough in north ...')
SET IDENTITY_INSERT [dbo].[TSql_Banner] OFF
SET IDENTITY_INSERT [dbo].[TSql_Categorys] ON 

INSERT [dbo].[TSql_Categorys] ([IDCategory], [CategoryName]) VALUES (1, N'Hành động')
INSERT [dbo].[TSql_Categorys] ([IDCategory], [CategoryName]) VALUES (2, N'Phiêu lưu')
INSERT [dbo].[TSql_Categorys] ([IDCategory], [CategoryName]) VALUES (3, N'Hài hước')
INSERT [dbo].[TSql_Categorys] ([IDCategory], [CategoryName]) VALUES (4, N'Hoạt hình')
INSERT [dbo].[TSql_Categorys] ([IDCategory], [CategoryName]) VALUES (5, N'Anime')
INSERT [dbo].[TSql_Categorys] ([IDCategory], [CategoryName]) VALUES (6, N'Lãng mạng')
INSERT [dbo].[TSql_Categorys] ([IDCategory], [CategoryName]) VALUES (7, N'Bi kịch')
INSERT [dbo].[TSql_Categorys] ([IDCategory], [CategoryName]) VALUES (8, N'Giáo dục')
INSERT [dbo].[TSql_Categorys] ([IDCategory], [CategoryName]) VALUES (9, N'Viễn tưởng')
INSERT [dbo].[TSql_Categorys] ([IDCategory], [CategoryName]) VALUES (10, N'Khoa học')
INSERT [dbo].[TSql_Categorys] ([IDCategory], [CategoryName]) VALUES (11, N'Võ thuật')
INSERT [dbo].[TSql_Categorys] ([IDCategory], [CategoryName]) VALUES (12, N'Drama')
INSERT [dbo].[TSql_Categorys] ([IDCategory], [CategoryName]) VALUES (13, N'16+')
INSERT [dbo].[TSql_Categorys] ([IDCategory], [CategoryName]) VALUES (14, N'18+')
SET IDENTITY_INSERT [dbo].[TSql_Categorys] OFF
SET IDENTITY_INSERT [dbo].[TSql_Country] ON 

INSERT [dbo].[TSql_Country] ([IDCountry], [CountryName]) VALUES (1, N'Việt Nam')
INSERT [dbo].[TSql_Country] ([IDCountry], [CountryName]) VALUES (2, N'Nhật Bản')
INSERT [dbo].[TSql_Country] ([IDCountry], [CountryName]) VALUES (3, N'Trung quốc')
INSERT [dbo].[TSql_Country] ([IDCountry], [CountryName]) VALUES (4, N'Thái Lan')
INSERT [dbo].[TSql_Country] ([IDCountry], [CountryName]) VALUES (5, N'Ấn Độ')
INSERT [dbo].[TSql_Country] ([IDCountry], [CountryName]) VALUES (6, N'Nga')
INSERT [dbo].[TSql_Country] ([IDCountry], [CountryName]) VALUES (7, N'Anh')
INSERT [dbo].[TSql_Country] ([IDCountry], [CountryName]) VALUES (8, N'Đức')
INSERT [dbo].[TSql_Country] ([IDCountry], [CountryName]) VALUES (9, N'Pháp')
INSERT [dbo].[TSql_Country] ([IDCountry], [CountryName]) VALUES (10, N'Châu Phi')
INSERT [dbo].[TSql_Country] ([IDCountry], [CountryName]) VALUES (11, N'Mỹ')
INSERT [dbo].[TSql_Country] ([IDCountry], [CountryName]) VALUES (12, N'Canada')
INSERT [dbo].[TSql_Country] ([IDCountry], [CountryName]) VALUES (13, N'Đa quốc gia')
INSERT [dbo].[TSql_Country] ([IDCountry], [CountryName]) VALUES (14, N'Hàn Quốc')
INSERT [dbo].[TSql_Country] ([IDCountry], [CountryName]) VALUES (15, N'Hồng Kông')
SET IDENTITY_INSERT [dbo].[TSql_Country] OFF
SET IDENTITY_INSERT [dbo].[TSql_Film_Category] ON 

INSERT [dbo].[TSql_Film_Category] ([IDFilm_Category], [IDFilm], [IDCategory], [DateCreate], [DateUpdate]) VALUES (1, 2, 2, NULL, NULL)
INSERT [dbo].[TSql_Film_Category] ([IDFilm_Category], [IDFilm], [IDCategory], [DateCreate], [DateUpdate]) VALUES (6, 2, 1, NULL, CAST(0x45400B00 AS Date))
INSERT [dbo].[TSql_Film_Category] ([IDFilm_Category], [IDFilm], [IDCategory], [DateCreate], [DateUpdate]) VALUES (7, 2, 3, NULL, CAST(0x45400B00 AS Date))
INSERT [dbo].[TSql_Film_Category] ([IDFilm_Category], [IDFilm], [IDCategory], [DateCreate], [DateUpdate]) VALUES (8, 2, 4, NULL, CAST(0x45400B00 AS Date))
INSERT [dbo].[TSql_Film_Category] ([IDFilm_Category], [IDFilm], [IDCategory], [DateCreate], [DateUpdate]) VALUES (46, 67, 1, CAST(0x7C400B00 AS Date), CAST(0x7C400B00 AS Date))
INSERT [dbo].[TSql_Film_Category] ([IDFilm_Category], [IDFilm], [IDCategory], [DateCreate], [DateUpdate]) VALUES (47, 68, 1, CAST(0x7C400B00 AS Date), CAST(0x7C400B00 AS Date))
INSERT [dbo].[TSql_Film_Category] ([IDFilm_Category], [IDFilm], [IDCategory], [DateCreate], [DateUpdate]) VALUES (48, 68, 6, CAST(0x7C400B00 AS Date), CAST(0x7C400B00 AS Date))
SET IDENTITY_INSERT [dbo].[TSql_Film_Category] OFF
SET IDENTITY_INSERT [dbo].[TSql_Films] ON 

INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (2, N'Tarzan', N'Tarzan, having acclimated to life in London, is called back to his former home in the jungle to investigate the activities at a mining encampment.', NULL, NULL, CAST(0x42400B00 AS Date), N'm3.jpg', 11, 3.8333334128061929, 18, N'https://www.youtube.com/embed/BBRCKcGPmhI', N'https://www.youtube.com/embed/S8_YwFLCh4U', N'https://drive.google.com/uc?authuser=0&id=1dDfV2HPky1gu6H6HoCcqqp_VPRrI1omB&export=download', NULL, 6)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (5, N'Greater', N'Tarzan, having acclimated to life in London, is called back to his former home in the jungle to investigate the activities at a mining encampment.', NULL, NULL, CAST(0x42400B00 AS Date), N'm12.jpg', 1, 4.2500002980232239, 3, N'https://www.youtube.com/embed/BBRCKcGPmhI', N'https://www.youtube.com/embed/S8_YwFLCh4U', N'https://drive.google.com/uc?authuser=0&id=1dDfV2HPky1gu6H6HoCcqqp_VPRrI1omB&export=download', NULL, 8)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (6, N'X-Men', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm11.jpg', 2, 4.666666666666667, 3, N'https://www.youtube.com/embed/BBRCKcGPmhI', N'https://www.youtube.com/embed/S8_YwFLCh4U', N'https://drive.google.com/uc?authuser=0&id=1dDfV2HPky1gu6H6HoCcqqp_VPRrI1omB&export=download', NULL, 3)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (7, N'Light B/t Oceans', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm7.jpg', 3, 0, 0, N'https://www.youtube.com/embed/BBRCKcGPmhI', N'https://www.youtube.com/embed/S8_YwFLCh4U', N'https://drive.google.com/uc?authuser=0&id=1dDfV2HPky1gu6H6HoCcqqp_VPRrI1omB&export=download', NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (8, N'The BFG', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm8.jpg', 1, 0, 0, N'https://www.youtube.com/embed/BBRCKcGPmhI', N'https://www.youtube.com/embed/S8_YwFLCh4U', N'https://drive.google.com/uc?authuser=0&id=1dDfV2HPky1gu6H6HoCcqqp_VPRrI1omB&export=download', NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (9, N'Central Intelligence', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm9.jpg', 5, 0, 1, NULL, N'https://www.youtube.com/embed/S8_YwFLCh4U', NULL, NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (10, N'Don''t Think Twice', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm10.jpg', 2, 0, 0, NULL, N'https://www.youtube.com/embed/S8_YwFLCh4U', NULL, NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (11, N'Peter', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm17.jpg', 11, 0, 0, NULL, N'https://www.youtube.com/embed/S8_YwFLCh4U', NULL, NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (12, N'God’s Compass', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm15.jpg', 11, 0, 0, NULL, N'https://www.youtube.com/embed/S8_YwFLCh4U', NULL, NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (13, N'Bad Moms', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm2.jpg', 11, 0, 1, NULL, N'https://www.youtube.com/embed/S8_YwFLCh4U', NULL, NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (14, N'Jason Bourne', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm5.jpg', 11, 0, 0, NULL, N'https://www.youtube.com/embed/S8_YwFLCh4U', NULL, NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (15, N'Rezort', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm16.jpg', 6, 0, 0, NULL, N'https://www.youtube.com/embed/S8_YwFLCh4U', NULL, NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (16, N'ISRA 88', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm18.jpg', 11, 0, 0, NULL, N'https://www.youtube.com/embed/S8_YwFLCh4U', NULL, NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (17, N'War Dogs', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm1.jpg', 11, 0, 0, NULL, N'https://www.youtube.com/embed/S8_YwFLCh4U', NULL, NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (18, N'The Other Side', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm14.jpg', 5, 0, 0, NULL, N'https://www.youtube.com/embed/S8_YwFLCh4U', NULL, NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (19, N'Civil War', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm19.jpg', 1, 0, 0, NULL, N'https://www.youtube.com/embed/S8_YwFLCh4U', NULL, NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (20, N'The Secret Life of Pets', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm20.jpg', 1, 0, 0, NULL, N'https://www.youtube.com/embed/S8_YwFLCh4U', NULL, NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (21, N'The Jungle Book', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm21.jpg', 1, 0, 0, NULL, N'https://www.youtube.com/embed/S8_YwFLCh4U', NULL, NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (23, N'the conjuring 2', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm22.jpg', 1, 0, 0, NULL, N'https://www.youtube.com/embed/S8_YwFLCh4U', NULL, NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (26, N'Citizen Soldier', NULL, NULL, NULL, CAST(0x42400B00 AS Date), N'm13.jpg', 1, 0, 0, NULL, N'https://www.youtube.com/embed/S8_YwFLCh4U', NULL, NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (49, N'Tarzan1', N'Tarzan, having acclimated to life in London, is called back to his former home in the jungle to investigate the activities at a mining encampment.', 120, NULL, CAST(0x45400B00 AS Date), N'm3.jpg', 11, 0, 0, NULL, N'https://www.youtube.com/embed/S8_YwFLCh4U', NULL, NULL, 0)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (67, N'Tarzan1', N'<p>gg</p>
', 11, N'1', CAST(0x7C400B00 AS Date), N'Penguins.jpg', 1, 0, 1, N'https://drive.google.com/open?id=1SoeVfgTLDyBcSEQay35otI1QCbP9lb4W', NULL, N'https://drive.google.com/uc?authuser=0&id=1dDfV2HPky1gu6H6HoCcqqp_VPRrI1omB&export=download', NULL, NULL)
INSERT [dbo].[TSql_Films] ([IDFilm], [FilmName], [Description], [Time], [Author], [DateSubmited], [Image], [IDCountry], [Rating], [Views], [LinkFilm], [Trailer], [Download], [Languages], [Votes]) VALUES (68, N'aa', N'<p>gg</p>
', 1, N'1', CAST(0x7C400B00 AS Date), N'Penguins.jpg', 11, 0, 1, N'https://drive.google.com/open?id=1SoeVfgTLDyBcSEQay35otI1QCbP9lb4W', NULL, N'https://drive.google.com/uc?authuser=0&id=1dDfV2HPky1gu6H6HoCcqqp_VPRrI1omB&export=download', NULL, 0)
SET IDENTITY_INSERT [dbo].[TSql_Films] OFF
SET IDENTITY_INSERT [dbo].[TSql_Informations] ON 

INSERT [dbo].[TSql_Informations] ([IDInfo], [DisplayName], [UserName], [Password], [Role], [DateCreate], [ForgotPasswordCode]) VALUES (2019, N'Thanh', N'tanthanh141214@gmail.com', N'1', 1, CAST(0x0000AB0C00C6FF53 AS DateTime), N'5476a4a3-2c73-45be-8a8e-66b3db50b70a')
INSERT [dbo].[TSql_Informations] ([IDInfo], [DisplayName], [UserName], [Password], [Role], [DateCreate], [ForgotPasswordCode]) VALUES (3018, N'Thanh', N'user1@1', N'1', 2, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TSql_Informations] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [uni_user_name]    Script Date: 12/14/2019 3:00:59 PM ******/
ALTER TABLE [dbo].[TSql_Informations] ADD  CONSTRAINT [uni_user_name] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TSql_Films] ADD  CONSTRAINT [DF_TSql_Films_Rating]  DEFAULT ((0)) FOR [Rating]
GO
ALTER TABLE [dbo].[TSql_Films] ADD  CONSTRAINT [DF_TSql_Films_Views]  DEFAULT ((0)) FOR [Views]
GO
ALTER TABLE [dbo].[TSql_Films] ADD  CONSTRAINT [DF_TSql_Films_Votes]  DEFAULT ((0)) FOR [Votes]
GO
ALTER TABLE [dbo].[TSql_Informations] ADD  CONSTRAINT [DF_TSql_Informations_Role]  DEFAULT ((0)) FOR [Role]
GO
ALTER TABLE [dbo].[TSql_Chat]  WITH CHECK ADD  CONSTRAINT [FK_TSql_Chat_TSql_Informations] FOREIGN KEY([IDUser])
REFERENCES [dbo].[TSql_Informations] ([IDInfo])
GO
ALTER TABLE [dbo].[TSql_Chat] CHECK CONSTRAINT [FK_TSql_Chat_TSql_Informations]
GO
ALTER TABLE [dbo].[TSql_Comment]  WITH CHECK ADD  CONSTRAINT [FK_TSql_Comment_TSql_Films] FOREIGN KEY([IDFilm])
REFERENCES [dbo].[TSql_Films] ([IDFilm])
GO
ALTER TABLE [dbo].[TSql_Comment] CHECK CONSTRAINT [FK_TSql_Comment_TSql_Films]
GO
ALTER TABLE [dbo].[TSql_Comment]  WITH CHECK ADD  CONSTRAINT [FK_TSql_Comment_TSql_Informations] FOREIGN KEY([IDInfo])
REFERENCES [dbo].[TSql_Informations] ([IDInfo])
GO
ALTER TABLE [dbo].[TSql_Comment] CHECK CONSTRAINT [FK_TSql_Comment_TSql_Informations]
GO
ALTER TABLE [dbo].[TSql_Film_Category]  WITH CHECK ADD  CONSTRAINT [FK_TSql_Film_Category_TSql_Categorys] FOREIGN KEY([IDCategory])
REFERENCES [dbo].[TSql_Categorys] ([IDCategory])
GO
ALTER TABLE [dbo].[TSql_Film_Category] CHECK CONSTRAINT [FK_TSql_Film_Category_TSql_Categorys]
GO
ALTER TABLE [dbo].[TSql_Film_Category]  WITH CHECK ADD  CONSTRAINT [FK_TSql_Film_Category_TSql_Films] FOREIGN KEY([IDFilm])
REFERENCES [dbo].[TSql_Films] ([IDFilm])
GO
ALTER TABLE [dbo].[TSql_Film_Category] CHECK CONSTRAINT [FK_TSql_Film_Category_TSql_Films]
GO
ALTER TABLE [dbo].[TSql_Films]  WITH CHECK ADD  CONSTRAINT [FK_TSql_Films_TSql_Country] FOREIGN KEY([IDCountry])
REFERENCES [dbo].[TSql_Country] ([IDCountry])
GO
ALTER TABLE [dbo].[TSql_Films] CHECK CONSTRAINT [FK_TSql_Films_TSql_Country]
GO
ALTER TABLE [dbo].[TSql_Reply]  WITH CHECK ADD  CONSTRAINT [FK_TSql_Reply_TSql_Comment] FOREIGN KEY([IDComment])
REFERENCES [dbo].[TSql_Comment] ([IDComment])
GO
ALTER TABLE [dbo].[TSql_Reply] CHECK CONSTRAINT [FK_TSql_Reply_TSql_Comment]
GO
ALTER TABLE [dbo].[TSql_Reply]  WITH CHECK ADD  CONSTRAINT [FK_TSql_Reply_TSql_Informations] FOREIGN KEY([IDInfo])
REFERENCES [dbo].[TSql_Informations] ([IDInfo])
GO
ALTER TABLE [dbo].[TSql_Reply] CHECK CONSTRAINT [FK_TSql_Reply_TSql_Informations]
GO
USE [master]
GO
ALTER DATABASE [DBMovie] SET  READ_WRITE 
GO
