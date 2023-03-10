USE [master]
GO
/****** Object:  Database [EczaneSistemi2Kasım]    Script Date: 9.01.2023 13:09:01 ******/
CREATE DATABASE [EczaneSistemi2Kasım]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EczaneSistemi2Kasım', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EczaneSistemi2Kasım.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EczaneSistemi2Kasım_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EczaneSistemi2Kasım_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EczaneSistemi2Kasım].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET ARITHABORT OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET  MULTI_USER 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET QUERY_STORE = OFF
GO
USE [EczaneSistemi2Kasım]
GO
/****** Object:  Table [dbo].[EczaneDepo]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EczaneDepo](
	[DepoNo] [int] IDENTITY(1,1) NOT NULL,
	[Depoil] [varchar](50) NULL,
	[Depoilce] [varchar](50) NULL,
	[DepoTel] [varchar](50) NULL,
 CONSTRAINT [PK_EczaneDepo] PRIMARY KEY CLUSTERED 
(
	[DepoNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EczaneHasta]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EczaneHasta](
	[HastaNo] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [varchar](50) NULL,
	[HastaTC] [varchar](50) NULL,
	[Cinsiyet] [varchar](50) NULL,
	[DogumYeri] [varchar](50) NULL,
	[DogumTarihi] [varchar](50) NULL,
	[Adres] [varchar](50) NULL,
	[Tel] [varchar](50) NULL,
	[Guvence] [varchar](50) NULL,
 CONSTRAINT [PK_EczaneHasta] PRIMARY KEY CLUSTERED 
(
	[HastaNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eczaneilac]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eczaneilac](
	[ilacNo] [int] IDENTITY(1,1) NOT NULL,
	[ilacAdi] [varchar](50) NULL,
	[UreticiFirma] [varchar](50) NULL,
	[Tarih] [varchar](50) NULL,
	[Fiyat] [int] NULL,
	[DepoNo] [int] NULL,
 CONSTRAINT [PK_Eczaneilac] PRIMARY KEY CLUSTERED 
(
	[ilacNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EczaneRecete]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EczaneRecete](
	[ReceteNo] [int] IDENTITY(1,1) NOT NULL,
	[HastaNo] [int] NULL,
	[ilacNo] [int] NULL,
	[Tarih] [varchar](50) NULL,
 CONSTRAINT [PK_EczaneRecete] PRIMARY KEY CLUSTERED 
(
	[ReceteNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EczaneSatis]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EczaneSatis](
	[SatisNo] [int] IDENTITY(1,1) NOT NULL,
	[HastaNo] [int] NULL,
	[ilacNo] [int] NULL,
	[Adet] [int] NULL,
	[Tarih] [varchar](50) NULL,
	[Fiyat] [int] NULL,
	[SatisSorumlusu] [varchar](50) NULL,
 CONSTRAINT [PK_EczaneSatis] PRIMARY KEY CLUSTERED 
(
	[SatisNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EczaneDepo] ON 

INSERT [dbo].[EczaneDepo] ([DepoNo], [Depoil], [Depoilce], [DepoTel]) VALUES (1, N'Afyon', N'Merkez', N'(272) 216-8954')
INSERT [dbo].[EczaneDepo] ([DepoNo], [Depoil], [Depoilce], [DepoTel]) VALUES (3, N'İstanbul', N'Üsküdar', N'(234) 789-0643')
INSERT [dbo].[EczaneDepo] ([DepoNo], [Depoil], [Depoilce], [DepoTel]) VALUES (4, N'İstanbul', N'Kadıköy', N'(234) 889-7654')
INSERT [dbo].[EczaneDepo] ([DepoNo], [Depoil], [Depoilce], [DepoTel]) VALUES (5, N'Bursa', N'Nilüfer', N'(245) 556-8998')
INSERT [dbo].[EczaneDepo] ([DepoNo], [Depoil], [Depoilce], [DepoTel]) VALUES (6, N'İzmir', N'Alsancak', N'(231) 345-1232')
INSERT [dbo].[EczaneDepo] ([DepoNo], [Depoil], [Depoilce], [DepoTel]) VALUES (7, N'İstanbul', N'Ümraniye', N'(234) 254-1786')
SET IDENTITY_INSERT [dbo].[EczaneDepo] OFF
GO
SET IDENTITY_INSERT [dbo].[EczaneHasta] ON 

INSERT [dbo].[EczaneHasta] ([HastaNo], [AdSoyad], [HastaTC], [Cinsiyet], [DogumYeri], [DogumTarihi], [Adres], [Tel], [Guvence]) VALUES (1, N'Ahmet Yan', N'56473829894', N'erkek', N'Kartal', N'12.02.2000', N'Afyon', N'(506) 789-3456', N'yok')
INSERT [dbo].[EczaneHasta] ([HastaNo], [AdSoyad], [HastaTC], [Cinsiyet], [DogumYeri], [DogumTarihi], [Adres], [Tel], [Guvence]) VALUES (2, N'İlkay Tır', N'75384902024', N'kadın', N'Pendik', N'2.11.1990', N'İstanbul', N'(507) 896-5930', N'var')
INSERT [dbo].[EczaneHasta] ([HastaNo], [AdSoyad], [HastaTC], [Cinsiyet], [DogumYeri], [DogumTarihi], [Adres], [Tel], [Guvence]) VALUES (5, N'İrem Gün', N'34213233454', N'kadın', N'Bursa', N'30.10.1995', N'Bursa', N'(541) 556-9864', N'var')
SET IDENTITY_INSERT [dbo].[EczaneHasta] OFF
GO
SET IDENTITY_INSERT [dbo].[Eczaneilac] ON 

INSERT [dbo].[Eczaneilac] ([ilacNo], [ilacAdi], [UreticiFirma], [Tarih], [Fiyat], [DepoNo]) VALUES (1, N'Arveles', N'Ecz', N'28.11.2025', 30, 1)
INSERT [dbo].[Eczaneilac] ([ilacNo], [ilacAdi], [UreticiFirma], [Tarih], [Fiyat], [DepoNo]) VALUES (5, N'Dolorin Cold', N'Ecz', N'28.11.2025', 30, 3)
INSERT [dbo].[Eczaneilac] ([ilacNo], [ilacAdi], [UreticiFirma], [Tarih], [Fiyat], [DepoNo]) VALUES (6, N'aspirin', N'Ecz', N'28.11.2025', 30, 3)
INSERT [dbo].[Eczaneilac] ([ilacNo], [ilacAdi], [UreticiFirma], [Tarih], [Fiyat], [DepoNo]) VALUES (7, N'aspir', N'Ecz', N'28.11.2025', 30, 4)
INSERT [dbo].[Eczaneilac] ([ilacNo], [ilacAdi], [UreticiFirma], [Tarih], [Fiyat], [DepoNo]) VALUES (8, N'nurofen', N'Ecz', N'3.11.2021', 25, 5)
INSERT [dbo].[Eczaneilac] ([ilacNo], [ilacAdi], [UreticiFirma], [Tarih], [Fiyat], [DepoNo]) VALUES (9, N'B12', N'Ecz', N'30.10.2020', 45, 6)
INSERT [dbo].[Eczaneilac] ([ilacNo], [ilacAdi], [UreticiFirma], [Tarih], [Fiyat], [DepoNo]) VALUES (10, N'C Vitamini', N'Ecz', N'25.10.2022', 45, 6)
SET IDENTITY_INSERT [dbo].[Eczaneilac] OFF
GO
SET IDENTITY_INSERT [dbo].[EczaneRecete] ON 

INSERT [dbo].[EczaneRecete] ([ReceteNo], [HastaNo], [ilacNo], [Tarih]) VALUES (1, 1, 1, N'1.11.2022')
INSERT [dbo].[EczaneRecete] ([ReceteNo], [HastaNo], [ilacNo], [Tarih]) VALUES (2, 1, 9, N'7.03.2019')
INSERT [dbo].[EczaneRecete] ([ReceteNo], [HastaNo], [ilacNo], [Tarih]) VALUES (3, 5, 5, N'7.11.2019')
INSERT [dbo].[EczaneRecete] ([ReceteNo], [HastaNo], [ilacNo], [Tarih]) VALUES (5, 2, 6, N'17.11.2022')
SET IDENTITY_INSERT [dbo].[EczaneRecete] OFF
GO
SET IDENTITY_INSERT [dbo].[EczaneSatis] ON 

INSERT [dbo].[EczaneSatis] ([SatisNo], [HastaNo], [ilacNo], [Adet], [Tarih], [Fiyat], [SatisSorumlusu]) VALUES (1, 1, 5, 1, N'1.11.2022', 100, N'Samet Ramazan')
INSERT [dbo].[EczaneSatis] ([SatisNo], [HastaNo], [ilacNo], [Adet], [Tarih], [Fiyat], [SatisSorumlusu]) VALUES (2, 2, 1, 2, N'5.01.2022', 50, N'Ahmet Er')
INSERT [dbo].[EczaneSatis] ([SatisNo], [HastaNo], [ilacNo], [Adet], [Tarih], [Fiyat], [SatisSorumlusu]) VALUES (3, 1, 7, 3, N'7.01.2021', 150, N'İsmail Ömür')
INSERT [dbo].[EczaneSatis] ([SatisNo], [HastaNo], [ilacNo], [Adet], [Tarih], [Fiyat], [SatisSorumlusu]) VALUES (4, 1, 6, 3, N'7.01.2021', 150, N'İsmail Ömür')
INSERT [dbo].[EczaneSatis] ([SatisNo], [HastaNo], [ilacNo], [Adet], [Tarih], [Fiyat], [SatisSorumlusu]) VALUES (5, 5, 10, 2, N'4.11.2022', 90, N'Ahmet Er')
INSERT [dbo].[EczaneSatis] ([SatisNo], [HastaNo], [ilacNo], [Adet], [Tarih], [Fiyat], [SatisSorumlusu]) VALUES (6, 5, 9, 1, N'4.11.2022', 90, N'Ahmet Er')
SET IDENTITY_INSERT [dbo].[EczaneSatis] OFF
GO
ALTER TABLE [dbo].[Eczaneilac]  WITH CHECK ADD  CONSTRAINT [FK_Eczaneilac_EczaneDepo] FOREIGN KEY([DepoNo])
REFERENCES [dbo].[EczaneDepo] ([DepoNo])
GO
ALTER TABLE [dbo].[Eczaneilac] CHECK CONSTRAINT [FK_Eczaneilac_EczaneDepo]
GO
ALTER TABLE [dbo].[EczaneRecete]  WITH CHECK ADD  CONSTRAINT [FK_EczaneRecete_EczaneHasta] FOREIGN KEY([HastaNo])
REFERENCES [dbo].[EczaneHasta] ([HastaNo])
GO
ALTER TABLE [dbo].[EczaneRecete] CHECK CONSTRAINT [FK_EczaneRecete_EczaneHasta]
GO
ALTER TABLE [dbo].[EczaneRecete]  WITH CHECK ADD  CONSTRAINT [FK_EczaneRecete_Eczaneilac] FOREIGN KEY([ilacNo])
REFERENCES [dbo].[Eczaneilac] ([ilacNo])
GO
ALTER TABLE [dbo].[EczaneRecete] CHECK CONSTRAINT [FK_EczaneRecete_Eczaneilac]
GO
ALTER TABLE [dbo].[EczaneSatis]  WITH CHECK ADD  CONSTRAINT [FK_EczaneSatis_EczaneHasta] FOREIGN KEY([HastaNo])
REFERENCES [dbo].[EczaneHasta] ([HastaNo])
GO
ALTER TABLE [dbo].[EczaneSatis] CHECK CONSTRAINT [FK_EczaneSatis_EczaneHasta]
GO
ALTER TABLE [dbo].[EczaneSatis]  WITH CHECK ADD  CONSTRAINT [FK_EczaneSatis_Eczaneilac] FOREIGN KEY([ilacNo])
REFERENCES [dbo].[Eczaneilac] ([ilacNo])
GO
ALTER TABLE [dbo].[EczaneSatis] CHECK CONSTRAINT [FK_EczaneSatis_Eczaneilac]
GO
/****** Object:  StoredProcedure [dbo].[DepoAra]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DepoAra]
@Depoil varchar(50)
as begin
select * from EczaneDepo where Depoil=@Depoil
end
GO
/****** Object:  StoredProcedure [dbo].[DepoEkle]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DepoEkle]
@Depoil varchar(50),
@Depoilce varchar(50),
@DepoTel varchar(50)

as begin
insert into EczaneDepo(Depoil,Depoilce,DepoTel)
values (@Depoil,@Depoilce, @DepoTel)
end
GO
/****** Object:  StoredProcedure [dbo].[DepoListele]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DepoListele]
as begin
select * from EczaneDepo
end
GO
/****** Object:  StoredProcedure [dbo].[DepoSil]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DepoSil]
@DepoNo int
as begin
delete from EczaneDepo where DepoNo=@DepoNo
end
GO
/****** Object:  StoredProcedure [dbo].[DepoYenile]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[DepoYenile]
@DepoNo int,
@Depoil varchar(50),
@Depoilce varchar(50),
@DepoTel varchar(50)
as begin
update EczaneDepo set
Depoil=@Depoil,Depoilce=@Depoilce,DepoTel=@DepoTel where DepoNo=@DepoNo
end
GO
/****** Object:  StoredProcedure [dbo].[EncokSatisYapanKim]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EncokSatisYapanKim]
@SatisSorumlusu varchar(50)
as begin
select  SUM(Adet*Fiyat) as 'Personelin Satış Yaptığı Tutar' , Sum(Adet) as 'Sattığı İlaç Sayısı' from EczaneSatis where SatisSorumlusu=@SatisSorumlusu
end
GO
/****** Object:  StoredProcedure [dbo].[getir]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getir]
as begin 
select  distinct(AdSoyad),HastaTC from EczaneRecete er inner join EczaneHasta eh on er.HastaNo=er.HastaNo group by AdSoyad,HastaTC 
end
GO
/****** Object:  StoredProcedure [dbo].[Giris]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Giris]
@SatisSorumlusu varchar(50)
as begin
select * from EczaneSatis where SatisSorumlusu=@SatisSorumlusu
end
GO
/****** Object:  StoredProcedure [dbo].[HastaAra]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[HastaAra]
@AdSoyad varchar(50)
as begin
select * from EczaneHasta where AdSoyad=@AdSoyad
end
GO
/****** Object:  StoredProcedure [dbo].[HastaEkle]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[HastaEkle]
@AdSoyad varchar(50),
@HastaTC varchar(50),
@Cinsiyet varchar(50),
@DogumYeri varchar(50),
@DogumTarihi varchar(50),
@Adres varchar(50),
@Tel varchar(50),
@Guvence varchar(50)
as begin
insert into EczaneHasta(AdSoyad,HastaTC,Cinsiyet,DogumYeri,DogumTarihi,Adres,Tel,Guvence)
values (@AdSoyad,@HastaTC,@Cinsiyet,@DogumYeri,@DogumTarihi,@Adres,@Tel,@Guvence)
end
GO
/****** Object:  StoredProcedure [dbo].[HastaListele]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[HastaListele]
as begin
select * from EczaneHasta
end
GO
/****** Object:  StoredProcedure [dbo].[HastaSil]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[HastaSil]
@HastaNo int
as begin
delete from EczaneHasta where HastaNo=@HastaNo
end
GO
/****** Object:  StoredProcedure [dbo].[HastaYenile]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[HastaYenile]
@HastaNo int,
@AdSoyad varchar(50),
@HastaTC varchar(50),
@Cinsiyet varchar(50),
@DogumYeri varchar(50),
@DogumTarihi varchar(50),
@Adres varchar(50),
@Tel varchar(50),
@Guvence varchar(50)
as begin
update EczaneHasta set
AdSoyad=@AdSoyad,HastaTC=@HastaTC,Cinsiyet=@Cinsiyet,DogumYeri=@DogumYeri,DogumTarihi=@DogumTarihi,Adres=@Adres,Tel=@Tel,Guvence=@Guvence where HastaNo=@HastaNo
end
GO
/****** Object:  StoredProcedure [dbo].[ilacAra]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ilacAra]
@ilacAdi varchar(50)
as begin
select * from Eczaneilac where ilacAdi=@ilacAdi
end
GO
/****** Object:  StoredProcedure [dbo].[ilacEkle]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ilacEkle]
@ilacAdi varchar(50),
@UreticiFirma varchar(50),
@Tarih varchar(50),
@Fiyat int,
@DepoNo int
as begin
insert into Eczaneilac(ilacAdi,UreticiFirma,Tarih,Fiyat,DepoNo)
values(@ilacAdi,@UreticiFirma,@Tarih,@Fiyat,@DepoNo)
end
GO
/****** Object:  StoredProcedure [dbo].[ilacFiyatSiralama]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ilacFiyatSiralama]
as begin
select * from Eczaneilac order by Fiyat desc
end
GO
/****** Object:  StoredProcedure [dbo].[ilacListele]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ilacListele]
as begin
select *from Eczaneilac
end
GO
/****** Object:  StoredProcedure [dbo].[ilacSil]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ilacSil]
@ilacNo int
as begin
delete from Eczaneilac where ilacNo=@ilacNo
end
GO
/****** Object:  StoredProcedure [dbo].[ilacYenile]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ilacYenile]
@ilacNo int,
@ilacAdi varchar(50),
@UreticiFirma varchar(50),
@Tarih varchar(50),
@Fiyat int,
@DepoNo int
as begin
update Eczaneilac set
ilacAdi=@ilacAdi,UreticiFirma=@UreticiFirma,Tarih=@Tarih,Fiyat=@Fiyat,DepoNo=@DepoNo where ilacNo=@ilacNo
end
GO
/****** Object:  StoredProcedure [dbo].[ReceteAra]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ReceteAra]
@ReceteNo int
as begin
select * from EczaneRecete where ReceteNo=@ReceteNo
end
GO
/****** Object:  StoredProcedure [dbo].[ReceteEkle]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ReceteEkle]
@HastaNo int,
@ilacNo int,
@Tarih varchar(50)
as begin
insert into EczaneRecete(HastaNo,ilacNo,Tarih)
values(@HastaNo,@ilacNo,@Tarih)
end
GO
/****** Object:  StoredProcedure [dbo].[ReceteHasta]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[ReceteHasta]
as begin 
select distinct(HastaTC), AdSoyad, DogumTarihi from EczaneRecete er inner join EczaneHasta eh on er.HastaNo=eh.HastaNo where eh.Guvence='yok'
end
GO
/****** Object:  StoredProcedure [dbo].[ReceteListele]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ReceteListele]
as begin
select * from EczaneRecete
end
GO
/****** Object:  StoredProcedure [dbo].[ReceteSil]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ReceteSil]
@ReceteNo int
as begin
delete from EczaneRecete where ReceteNo=@ReceteNo
end
GO
/****** Object:  StoredProcedure [dbo].[ReceteYenile]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ReceteYenile]
@ReceteNo int,
@HastaNo int,
@ilacNo int,
@Tarih varchar(50)
as begin
update EczaneRecete set
HastaNo=@HastaNo, ilacNo=@ilacNo,Tarih=@Tarih where ReceteNo=@ReceteNo
end
GO
/****** Object:  StoredProcedure [dbo].[SatisAra]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SatisAra]
@SatisNo  int
as begin
--select * from EczaneSatis where HastaNo like '%' + @HastaNo + '%'
select * from EczaneSatis where SatisNo=@SatisNo
end
GO
/****** Object:  StoredProcedure [dbo].[SatisEkle]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SatisEkle]
@HastaNo int,
@ilacNo int,
@Adet int,
@Tarih varchar(50),
@Fiyat int,
@SatisSorumlusu varchar(50)
as begin
insert into EczaneSatis(HastaNo,ilacNo,Adet,Tarih,Fiyat,SatisSorumlusu)
values (@HastaNo,@ilacNo,@Adet,@Tarih,@Fiyat,@SatisSorumlusu)
end
GO
/****** Object:  StoredProcedure [dbo].[SatisListele]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SatisListele]
as begin
select * from EczaneSatis
end
GO
/****** Object:  StoredProcedure [dbo].[SatisSil]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SatisSil]
@SatisNo int
as begin
delete from EczaneSatis where SatisNo=@SatisNo
end
GO
/****** Object:  StoredProcedure [dbo].[SatisYenile]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SatisYenile]
@SatisNo int,
@HastaNo int,
@ilacNo int,
@Adet int,
@Tarih varchar(50),
@Fiyat int,
@SatisSorumlusu varchar(50)
as begin
update EczaneSatis set 
HastaNo=@HastaNo,ilacNo=@ilacNo,Adet=@Adet,Tarih=@Tarih,Fiyat=@Fiyat,SatisSorumlusu=@SatisSorumlusu where SatisNo=@SatisNo
end
GO
/****** Object:  StoredProcedure [dbo].[TarihKontrol]    Script Date: 9.01.2023 13:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[TarihKontrol]
as begin
select ilacAdi,UreticiFirma from Eczaneilac ei inner join EczaneSatis es on ei.ilacNo=es.ilacNo where (Convert(datetime, ei.Tarih, 104)) < (Convert(datetime, es.Tarih, 104))
end
GO
USE [master]
GO
ALTER DATABASE [EczaneSistemi2Kasım] SET  READ_WRITE 
GO
