USE [master]
GO
/****** Object:  Database [optimak]    Script Date: 14.10.2021 09:56:02 ******/
CREATE DATABASE [optimak]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'optimak', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\optimak.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'optimak_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\optimak_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [optimak] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [optimak].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [optimak] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [optimak] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [optimak] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [optimak] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [optimak] SET ARITHABORT OFF 
GO
ALTER DATABASE [optimak] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [optimak] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [optimak] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [optimak] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [optimak] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [optimak] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [optimak] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [optimak] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [optimak] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [optimak] SET  DISABLE_BROKER 
GO
ALTER DATABASE [optimak] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [optimak] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [optimak] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [optimak] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [optimak] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [optimak] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [optimak] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [optimak] SET RECOVERY FULL 
GO
ALTER DATABASE [optimak] SET  MULTI_USER 
GO
ALTER DATABASE [optimak] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [optimak] SET DB_CHAINING OFF 
GO
ALTER DATABASE [optimak] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [optimak] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [optimak] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [optimak] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [optimak] SET QUERY_STORE = OFF
GO
USE [optimak]
GO
/****** Object:  User [ssAA]    Script Date: 14.10.2021 09:56:02 ******/
CREATE USER [ssAA] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [manos]    Script Date: 14.10.2021 09:56:02 ******/
CREATE USER [manos] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [cogurcu]    Script Date: 14.10.2021 09:56:02 ******/
CREATE USER [cogurcu] FOR LOGIN [cogurcu] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [manos]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [manos]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [manos]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [manos]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [manos]
GO
ALTER ROLE [db_datareader] ADD MEMBER [manos]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [manos]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [manos]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [manos]
GO
USE [optimak]
GO
/****** Object:  Sequence [dbo].[depoIrsaliyeSeq]    Script Date: 14.10.2021 09:56:03 ******/
CREATE SEQUENCE [dbo].[depoIrsaliyeSeq] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
/****** Object:  UserDefinedFunction [dbo].[GenerateFullEAN13]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GenerateFullEAN13] (@InputUPC nchar(20))
RETURNS nchar(13)
 
BEGIN
DECLARE @Sum int
DECLARE @ChkDgt nchar(1)
 
IF ( (Len(@InputUPC) < 12) OR (Len(@InputUPC) >13) )
 
BEGIN
RETURN NULL
END
 
ELSE IF (Len(@InputUPC) = 13)
 
BEGIN
SET @InputUPC = Left(@InputUPC, 12)
END
 
SET @Sum = 3 * (
 
CAST(Substring(@InputUPC,2,1) AS int)
+ CAST(Substring(@InputUPC,4,1) AS int)
+ CAST(Substring(@InputUPC,6,1) AS int)
+ CAST(Substring(@InputUPC,8,1) AS int)
+ CAST(Substring(@InputUPC,10,1) AS int)
+ CAST(Substring(@InputUPC,12,1) AS int) )
+ CAST(Substring(@InputUPC,1,1) AS int)
+ CAST(Substring(@InputUPC,3,1) AS int)
+ CAST(Substring(@InputUPC,5,1) AS int)
+ CAST(Substring(@InputUPC,7,1) AS int)
+ CAST(Substring(@InputUPC,9,1) AS int)
+ CAST(Substring(@InputUPC,11,1) AS int)
 
IF (@Sum % 10) = 0 BEGIN SET @ChkDgt = '0' END
ELSE IF (@Sum % 10) = 1 BEGIN SET @ChkDgt = '9' END
ELSE IF (@Sum % 10) = 2 BEGIN SET @ChkDgt = '8' END
ELSE IF (@Sum % 10) = 3 BEGIN SET @ChkDgt = '7' END
ELSE IF (@Sum % 10) = 4 BEGIN SET @ChkDgt = '6' END
ELSE IF (@Sum % 10) = 5 BEGIN SET @ChkDgt = '5' END
ELSE IF (@Sum % 10) = 6 BEGIN SET @ChkDgt = '4' END
ELSE IF (@Sum % 10) = 7 BEGIN SET @ChkDgt = '3' END
ELSE IF (@Sum % 10) = 8 BEGIN SET @ChkDgt = '2' END
ELSE IF (@Sum % 10) = 9 BEGIN SET @ChkDgt = '1' END
 
ELSE BEGIN SET @ChkDgt = 'Z' END
RETURN Left(@InputUPC,12) + @ChkDgt
END
GO
/****** Object:  Table [dbo].[AYAR_SutunBaslik]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AYAR_SutunBaslik](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sutunadi] [nvarchar](max) NULL,
	[caption] [nvarchar](max) NULL,
 CONSTRAINT [PK_AYAR_SutunBaslik] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AYAR_SutunSiralamasi]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AYAR_SutunSiralamasi](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kullaniciadi] [nvarchar](50) NULL,
	[formadi] [nvarchar](50) NULL,
	[sutunadi] [nvarchar](max) NULL,
	[siralama] [int] NULL,
 CONSTRAINT [PK_AYAR_SutunSiralamasi] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Depo_DepoBilgileri]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Depo_DepoBilgileri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[depo_adi] [nvarchar](max) NULL,
	[depo_aciklamasi] [nvarchar](max) NULL,
	[depo_birim] [int] NULL,
	[depo_sorumlu] [int] NULL,
 CONSTRAINT [PK_Depo_DepoBilgileri] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Depo_TalepListesiDetay]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Depo_TalepListesiDetay](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[stok_id] [int] NULL,
	[miktar] [float] NULL,
	[mamul_id] [int] NULL,
	[sip_DetayID] [int] NULL,
	[parcaStokAdi] [nvarchar](max) NULL,
	[uzunluk] [nvarchar](max) NULL,
	[kalanMiktar] [float] NULL,
 CONSTRAINT [PK_Depo_TalepListesiDetay] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[elektrik_stokListesi]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[elektrik_stokListesi](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[urun_adi] [nvarchar](max) NULL,
	[urun_kodu] [nvarchar](max) NULL,
 CONSTRAINT [PK_elektrik_stokListesi] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genel_birimTanimlari]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genel_birimTanimlari](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parent_id] [int] NULL,
	[birim_adi] [nvarchar](max) NULL,
	[birim_tanimi] [nvarchar](max) NULL,
 CONSTRAINT [PK_genel_Birimler] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genel_gorevTanimlari]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genel_gorevTanimlari](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parent_id] [int] NULL,
	[gorev_adi] [nvarchar](max) NULL,
	[gorev_tanimi] [nvarchar](max) NULL,
 CONSTRAINT [PK_genel_gorevTanimlari] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hesapBilgileri]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hesapBilgileri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hesap_adi] [nvarchar](100) NULL,
	[hesap_kodu] [nvarchar](50) NULL,
	[hesap_tipi] [int] NULL,
	[hesap_kategori] [int] NULL,
	[hesap_VNo] [varchar](100) NULL,
	[hesap_VDairesi] [nvarchar](100) NULL,
	[hesap_OlusturanId] [int] NULL,
	[hesap_TcNo] [varchar](11) NULL,
	[hesap_telefon] [varchar](50) NULL,
 CONSTRAINT [PK_hesapBaslik] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hesapKategorileri]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hesapKategorileri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aciklama] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hesapTipleri]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hesapTipleri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aciklama] [text] NULL,
 CONSTRAINT [PK_hesapTipleri] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[irsaliye_DetayKopya]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[irsaliye_DetayKopya](
	[id] [int] NOT NULL,
	[irsaliye_id] [int] NULL,
	[stok_id] [int] NULL,
	[kategori] [nvarchar](max) NULL,
	[parcaAdi] [nvarchar](max) NULL,
	[parcaStokAdi] [nvarchar](max) NULL,
	[malzeme] [nvarchar](max) NULL,
	[uzunluk] [nvarchar](max) NULL,
	[prosesGrubu] [nvarchar](max) NULL,
	[grubuAdi] [nvarchar](max) NULL,
	[altGrubuAdi] [nvarchar](max) NULL,
	[seriNumarasi] [nvarchar](max) NULL,
	[tip] [nvarchar](max) NULL,
	[miktar] [float] NULL,
	[birim] [nvarchar](max) NULL,
	[birimFiyat] [money] NULL,
	[kdv] [float] NULL,
	[terminTarihi] [datetime] NULL,
	[kullanici] [nvarchar](max) NULL,
	[sip_DetayID] [int] NULL,
	[mamul_id] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[irsaliye_IrsaliyeBaslik]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[irsaliye_IrsaliyeBaslik](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[olusturmaTarihi] [datetime] NULL,
	[terminTarihi] [datetime] NULL,
	[tedarikci] [int] NULL,
	[hedefDepo] [int] NULL,
	[toplamFiyat] [float] NULL,
	[aciklama] [nvarchar](250) NULL,
	[referans_IrsaliyeID] [int] NULL,
	[cikisbirimdepo] [bit] NULL,
	[hedefbirimdepo] [bit] NULL,
	[kullaniciadi] [nvarchar](max) NULL,
	[irsaliye_No] [nvarchar](max) NULL,
	[irsaliye_tipi] [varchar](50) NULL,
 CONSTRAINT [PK_satinalma_irsaliyeBaslik] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[irsaliye_IrsaliyeDetay]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[irsaliye_IrsaliyeDetay](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[irsaliye_id] [int] NULL,
	[stok_id] [int] NULL,
	[miktar] [float] NULL,
	[uzunluk] [nvarchar](max) NULL,
	[birim] [nvarchar](max) NULL,
	[birimFiyat] [money] NULL,
	[kdv] [float] NULL,
	[terminTarihi] [datetime] NULL,
	[kullanici] [nvarchar](max) NULL,
	[sip_DetayID] [int] NULL,
	[mamul_id] [int] NULL,
	[HS] [bit] NULL,
 CONSTRAINT [PK_satinalma_irsaliyeDetay] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[irsaliye_KodBilgileri]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[irsaliye_KodBilgileri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[irsaliye_kodu] [varchar](10) NULL,
	[irsaliye_aciklama] [nvarchar](200) NULL,
	[irsaliye_tipi] [varchar](50) NULL,
	[seq] [int] NULL,
	[goster] [bit] NULL,
 CONSTRAINT [PK_irsaliye_KodBilgileri] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kullanici_Gruplar]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kullanici_Gruplar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parent_id] [int] NULL,
	[BirimAdi] [nvarchar](max) NULL,
	[Tanim] [nvarchar](max) NULL,
 CONSTRAINT [PK_kullanici_Gruplar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kullaniciBilgileri]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kullaniciBilgileri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kullaniciadi] [nvarchar](50) NULL,
	[parola] [nvarchar](50) NULL,
	[adsoyad] [nvarchar](50) NULL,
	[bolum] [nvarchar](50) NULL,
	[birim] [nvarchar](50) NULL,
	[gorev] [nvarchar](50) NULL,
 CONSTRAINT [PK_kullaniciBilgileri] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kullaniciToken]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kullaniciToken](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[username] [nvarchar](50) NULL,
	[token] [nvarchar](50) NULL,
	[tarih] [datetime] NULL,
	[hostname] [nvarchar](max) NULL,
 CONSTRAINT [PK_kullaniciToken] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kullaniciYetkileri]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kullaniciYetkileri](
	[id] [int] NOT NULL,
	[kullaniciadi] [nvarchar](1) NULL,
	[ekle] [nvarchar](1) NULL,
	[sil] [nvarchar](1) NULL,
	[guncelle] [nvarchar](1) NULL,
	[goruntule] [nvarchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proje_DurumTakipBilgileri]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proje_DurumTakipBilgileri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[durum] [nvarchar](50) NULL,
	[aciklama] [nvarchar](max) NULL,
 CONSTRAINT [PK_proje_SatinalmaDurumTakipBilgileri] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proje_isEmirleri]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proje_isEmirleri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[baslik] [nvarchar](max) NULL,
	[aciklama] [nvarchar](max) NULL,
	[acilacak_Form] [nvarchar](max) NULL,
	[form_gonderilecekDeger] [nvarchar](max) NULL,
	[birim] [nvarchar](max) NULL,
	[personel] [nvarchar](max) NULL,
	[olusturan_kullanici] [nvarchar](max) NULL,
	[sip_DetayID] [int] NULL,
	[tarih] [datetime] NULL,
 CONSTRAINT [PK_proje] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proje_siparisBaslik]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proje_siparisBaslik](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tarih] [datetime] NULL,
	[musteri_id] [int] NULL,
	[hatkodu] [nvarchar](max) NULL,
	[olusturan] [nvarchar](max) NULL,
	[pypSorumlusu] [nvarchar](max) NULL,
	[olusturmatarihi] [datetime] NULL,
 CONSTRAINT [PK_proje_siparisBaslik] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proje_siparisDetay]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proje_siparisDetay](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[siparis_id] [int] NULL,
	[pyp_adi] [nvarchar](max) NULL,
	[miktar] [float] NULL,
	[tasarim_adi] [nvarchar](max) NULL,
	[uretim_kodu] [nvarchar](max) NULL,
	[durumTakipID] [int] NULL,
 CONSTRAINT [PK_proje_siparisDetay] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sistem_Log]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sistem_Log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sutunAdi] [nvarchar](max) NULL,
	[tabloAdi] [nvarchar](max) NULL,
	[eskiVeri] [nvarchar](max) NULL,
	[yeniVeri] [nvarchar](max) NULL,
	[net_adress] [nvarchar](max) NULL,
	[host_name] [nvarchar](max) NULL,
	[tarih] [datetime] NULL,
	[kullanici] [nvarchar](max) NULL,
 CONSTRAINT [PK_sistem_Log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stok_IsletmeStokBilgileri]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stok_IsletmeStokBilgileri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[stok_id] [int] NULL,
	[isletme_id] [int] NULL,
	[miktar] [float] NULL,
	[irsaliye_id] [int] NULL,
	[irsaliye_detayID] [int] NULL,
 CONSTRAINT [PK_stok_IsletmeStokBilgileri] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stok_StokBilgileri]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stok_StokBilgileri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[stok_id] [int] NULL,
	[depo_id] [int] NULL,
	[miktar] [float] NULL,
	[irsaliye_id] [int] NULL,
	[irsaliye_detayID] [int] NULL,
 CONSTRAINT [PK_stok_StokBilgileri] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stok_StokKartlari]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stok_StokKartlari](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parcaAdi] [nvarchar](max) NULL,
	[seriNumarasi] [nvarchar](max) NULL,
	[malzeme] [nvarchar](max) NULL,
 CONSTRAINT [PK_stok_StokKartlari] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stok_StokKartlariVaryant]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stok_StokKartlariVaryant](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[stok_id] [int] NULL,
	[kategori] [nvarchar](max) NULL,
	[parcaStokAdi] [nvarchar](max) NULL,
	[malzeme] [nvarchar](max) NULL,
	[uzunluk] [nvarchar](max) NULL,
	[prosesGrubu] [nvarchar](max) NULL,
	[grubuAdi] [nvarchar](max) NULL,
	[altGrubuAdi] [nvarchar](max) NULL,
	[seriNumarasi] [nvarchar](max) NULL,
	[tip] [nvarchar](max) NULL,
 CONSTRAINT [PK_stok_StokKartlariVaryant] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tasarim_urunAgaci]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tasarim_urunAgaci](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mamul_id] [int] NULL,
	[stok_id] [int] NULL,
	[ogeno] [nvarchar](max) NULL,
	[parcaAdi] [nvarchar](max) NULL,
	[resimNo] [nvarchar](max) NULL,
	[prosesGrubu] [nvarchar](max) NULL,
	[grubuAdi] [nvarchar](max) NULL,
	[altGrubuAdi] [nvarchar](max) NULL,
	[parcaStokAdi] [nvarchar](max) NULL,
	[malzeme] [nvarchar](max) NULL,
	[uzunluk] [nvarchar](max) NULL,
	[agirlik] [nvarchar](max) NULL,
	[rota] [nvarchar](max) NULL,
	[miktar] [float] NULL,
	[seriNumarasi] [nvarchar](max) NULL,
	[gerekenMiktar] [float] NULL,
	[ParentID] [nvarchar](max) NULL,
	[ID1] [int] NULL,
	[ParentID1] [int] NULL,
	[tip] [nvarchar](max) NULL,
	[carpim] [nvarchar](max) NULL,
	[kategori] [nvarchar](max) NULL,
	[kullaniciadi] [nvarchar](max) NULL,
 CONSTRAINT [PK_tasarim_urunAgaci] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[uretim_urunAgaci]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[uretim_urunAgaci](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mamul_id] [int] NULL,
	[tasarim_id] [int] NULL,
	[stok_id] [int] NULL,
	[ogeno] [nvarchar](max) NULL,
	[parcaAdi] [nvarchar](max) NULL,
	[resimNo] [nvarchar](max) NULL,
	[prosesGrubu] [nvarchar](max) NULL,
	[grubuAdi] [nvarchar](max) NULL,
	[altGrubuAdi] [nvarchar](max) NULL,
	[parcaStokAdi] [nvarchar](max) NULL,
	[malzeme] [nvarchar](max) NULL,
	[uzunluk] [nvarchar](max) NULL,
	[agirlik] [nvarchar](max) NULL,
	[rota] [nvarchar](max) NULL,
	[miktar] [float] NULL,
	[seriNumarasi] [nvarchar](max) NULL,
	[gerekenMiktar] [float] NULL,
	[ParentID] [nvarchar](max) NULL,
	[ID1] [int] NULL,
	[ParentID1] [int] NULL,
	[tip] [nvarchar](max) NULL,
	[carpim] [nvarchar](max) NULL,
	[kategori] [nvarchar](max) NULL,
	[kullaniciadi] [nvarchar](max) NULL,
	[sip_DetayID] [int] NULL,
 CONSTRAINT [PK_uretim_urunAgaci_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[irsaliye_IrsaliyeBaslik] ADD  CONSTRAINT [DF_satinalma_irsaliyeBaslik_olusturmaTarihi]  DEFAULT (getdate()) FOR [olusturmaTarihi]
GO
ALTER TABLE [dbo].[irsaliye_IrsaliyeBaslik] ADD  CONSTRAINT [DF_irsaliye_IrsaliyeBaslik_terminTarihi]  DEFAULT (getdate()) FOR [terminTarihi]
GO
ALTER TABLE [dbo].[irsaliye_IrsaliyeDetay] ADD  CONSTRAINT [DF_irsaliye_IrsaliyeDetay_uretilecek]  DEFAULT ((0)) FOR [HS]
GO
ALTER TABLE [dbo].[irsaliye_KodBilgileri] ADD  CONSTRAINT [DF_irsaliye_KodBilgileri_seq]  DEFAULT ((1)) FOR [seq]
GO
ALTER TABLE [dbo].[irsaliye_KodBilgileri] ADD  CONSTRAINT [DF_irsaliye_KodBilgileri_goster]  DEFAULT ((1)) FOR [goster]
GO
ALTER TABLE [dbo].[kullaniciToken] ADD  CONSTRAINT [DF_kullaniciToken_createDate]  DEFAULT (getdate()) FOR [tarih]
GO
ALTER TABLE [dbo].[kullaniciToken] ADD  CONSTRAINT [DF_kullaniciToken_hostname]  DEFAULT (host_name()) FOR [hostname]
GO
ALTER TABLE [dbo].[proje_isEmirleri] ADD  CONSTRAINT [DF_proje_isEmirleri_tarih]  DEFAULT (getdate()) FOR [tarih]
GO
ALTER TABLE [dbo].[proje_siparisBaslik] ADD  CONSTRAINT [DF_proje_siparisBaslik_olusturmatarihi]  DEFAULT (getdate()) FOR [olusturmatarihi]
GO
ALTER TABLE [dbo].[proje_siparisDetay] ADD  CONSTRAINT [DF_proje_siparisDetay_durumTakipID]  DEFAULT ((1)) FOR [durumTakipID]
GO
ALTER TABLE [dbo].[sistem_Log] ADD  CONSTRAINT [DF_sistem_Log_tarih]  DEFAULT (getdate()) FOR [tarih]
GO
/****** Object:  StoredProcedure [dbo].[DELETE_IrsaliyeDetay]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DELETE_IrsaliyeDetay]
@id int
as
BEGIN

Delete from irsaliye_IrsaliyeDetay where id = @id
Delete from stok_StokBilgileri where irsaliye_detayID = @id

END
GO
/****** Object:  StoredProcedure [dbo].[FIND_StokKarti]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[FIND_StokKarti]
@barcode nvarchar(300) = null
as
BEGIN



declare @serino varchar(50)
declare @stokAdi varchar(200)
declare @ayiriciIndex int

select @ayiriciIndex = CHARINDEX('-', @barcode,0)
if(@ayiriciIndex > 0 )
BEGIN
select @serino= (select top 1 * from string_split(@barcode,'-') )
select @stokAdi =  RIGHT(@barcode, ( LEN(@barcode) - LEN(@serino)-1  ) )


END
ELSE
BEGIN
select @serino = @barcode
select @stokAdi = @barcode
END


select top 1 * from stok_StokKartlari where seriNumarasi = @serino or parcaAdi = @stokAdi

END
GO
/****** Object:  StoredProcedure [dbo].[GET_IrsaliyeBaslik]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GET_IrsaliyeBaslik]
as
begin
select id, irsaliye_tipi, irsaliye_No,
CASE 
WHEN cikisbirimdepo = 0 then (Select hesap_adi from hesapBilgileri where id=tedarikci)
else (select depo_adi from Depo_DepoBilgileri where id = tedarikci ) end as Nereden,
CASE
WHEN hedefbirimdepo = 0 then (Select hesap_adi from hesapBilgileri where id=hedefDepo)
else (select depo_adi from Depo_DepoBilgileri where id = HedefDepo ) end as Nereye,
olusturmaTarihi, terminTarihi, tedarikci, hedefDepo, cikisbirimdepo, hedefbirimdepo,
kullaniciadi as olusturan
from irsaliye_IrsaliyeBaslik ib
end
GO
/****** Object:  StoredProcedure [dbo].[GET_IrsaliyeDetay]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GET_IrsaliyeDetay]
@irsaliye_id int
as
begin
select * from irsaliye_IrsaliyeDetay id
left join stok_StokKartlari sk on id.stok_id = sk.id
where irsaliye_id = @irsaliye_id
end
GO
/****** Object:  StoredProcedure [dbo].[GET_MalzemeListesi]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GET_MalzemeListesi]
@mamul_id int 
as
BEGIN

select parcaAdi, resimNo, prosesGrubu, grubuAdi, altGrubuAdi, parcaStokAdi, malzeme, uzunluk, agirlik, rota,  seriNumarasi, tip, kategori, sum(gerekenMiktar) as gerekenMiktar from tasarim_urunagaci where  mamul_id = @mamul_id or id = @mamul_id   group by parcaAdi, resimNo, prosesGrubu, grubuAdi, altGrubuAdi, parcaStokAdi, malzeme, uzunluk, agirlik, rota,  seriNumarasi, tip, kategori order by parcaAdi asc

END
GO
/****** Object:  StoredProcedure [dbo].[GET_MalzemeListesiStokAltMamulMiktari]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GET_MalzemeListesiStokAltMamulMiktari]
@stok_id int,
@takimsayisi float,
@sip_DetayID int
as
begin

--select @sip_DetayID = 6
--select @stok_id= 2288
--select @takimsayisi = 1


declare @tasarim_id int
declare @tasarim_mamul_id int
declare @tasarim_ID1 int

select top 1 @tasarim_id = tasarim_id from uretim_urunAgaci where sip_DetayID = @sip_DetayID and stok_id =@stok_id 
select @tasarim_mamul_id = mamul_id, @tasarim_ID1 = ID1 from tasarim_urunAgaci where id = @tasarim_id

/*
--select @tasarim_mamul_id
select ogeno, mamul_id, stok_id, parcaAdi, miktar, (miktar * @takimsayisi  
--(select miktar from tasarim_urunAgaci as USTKIRIM where USTKIRIM.ID1 = MEVCUTKIRIM.ParentID1 and mamul_id = @tasarim_mamul_id )
)as gerekenMiktar, ID1, ParentID1, carpim
  into #BirinciKirimlar
from  tasarim_urunAgaci as MEVCUTKIRIM where ParentID1 = @tasarim_ID1 and mamul_id = @tasarim_mamul_id
select * from #BirinciKirimlar
*/

if EXISTS( select * from tasarim_urunAgaci where mamul_id = @tasarim_mamul_id )
BEGIN

;with tree (ogeno, mamul_id, stok_id, parcaAdi, miktar,uzunluk, gerekenMiktar, ID1, ParentID1, carpim) as (

select
usttablo.ogeno, 
usttablo.mamul_id, 
usttablo.stok_id, 
usttablo.parcaAdi, 
usttablo.miktar, 
usttablo.uzunluk,
(usttablo.miktar * @takimsayisi ) as gerekenMiktar, -- usttablo.gerekenMiktar
usttablo.ID1, 
usttablo.ParentID1, 
carpim from tasarim_urunAgaci usttablo 
where mamul_id = @tasarim_mamul_id and ParentID1  = @tasarim_ID1--  in (select ID1 from #BirinciKirimlar)

union all
select 
usttablo.ogeno, 
usttablo.mamul_id, 
usttablo.stok_id, 
usttablo.parcaAdi, 
usttablo.miktar,
usttablo.uzunluk,
CASE 
WHEN usttablo.carpim ='Hayır' then bk.gerekenMiktar
else (usttablo.miktar * bk.gerekenMiktar ) end, 
usttablo.ID1, 
usttablo.ParentID1, 
usttablo.carpim from tasarim_urunAgaci usttablo 
inner join 
tree bk on usttablo.ParentID1 = bk.ID1 
where usttablo.mamul_id = @tasarim_mamul_id 


) 
select * into #altkirimlar from tree 


select * from #altkirimlar
drop table #altkirimlar

END-- IF END
ELSE
BEGIN 
select 
ogeno, 
mamul_id, 
stok_id, 
parcaAdi, 
miktar, 
uzunluk,
(gerekenMiktar * @takimsayisi) as gerekenMiktar, 
ID1, 
ParentID1, 
carpim
from tasarim_urunAgaci where mamul_id = @tasarim_id
END


end

GO
/****** Object:  StoredProcedure [dbo].[GET_projeSiparisDetay]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[GET_projeSiparisDetay]
@siparisid int
as
BEGIN
select *, (Select top 1 id from proje_isEmirleri where sip_DetayID = siparisDetay.id and birim= 'Tasarım') as TasarimIsEmriID, 
CASE
WHEN ( (Select id from proje_isEmirleri where sip_DetayID = siparisDetay.id and birim= 'Tasarım')) IS NOT NULL then CAST(1 as bit)
else CAST(0 as bit) end as TasarimBool,
CASE
WHEN ( (Select id from proje_isEmirleri where sip_DetayID = siparisDetay.id and birim= 'Satınalma')) IS NOT NULL then CAST(1 as bit)
else CAST(0 as bit) end as SatinalmaBool,

(Select top 1 id from proje_isEmirleri where sip_DetayID = siparisDetay.id and birim= 'Satınalma') as SatinalmaIsEmriID,
(Select durum from proje_DurumTakipBilgileri where id = durumTakipID ) as Durum
from proje_siparisDetay as siparisDetay where siparis_id = @siparisid

END
GO
/****** Object:  StoredProcedure [dbo].[GET_ProjeTalepListesiHeader]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GET_ProjeTalepListesiHeader]
as
BEGIN


select ua.id,
ua.parcaAdi, 
pyp_adi, 
uretim_kodu, 
hesap_adi,
sd.id as sip_DetayID
from uretim_urunAgaci as ua 
left join proje_siparisDetay as sd on ua.sip_DetayID = sd.id 
left join proje_SiparisBaslik as sb on sb.id = sd.siparis_id
left join hesapBilgileri as hb on hb.id = sb.musteri_id
where ua.mamul_id is null and sd.durumTakipID = 5
END
GO
/****** Object:  StoredProcedure [dbo].[GET_SatinalmaMalzemeListesi]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GET_SatinalmaMalzemeListesi]
@sip_DetayID int = 3,
@Mamul_ID int = null
as
BEGIN


select 
stok_id, 
kategori,
parcaAdi, 
parcaStokAdi, 
malzeme, 
uzunluk, 
prosesGrubu, 
grubuAdi,
altGrubuAdi,
seriNumarasi,
tip,
sip_DetayID,
mamul_id,

SUM(gerekenMiktar) gerekenMiktar
,
 ISNULL(
 (select SUM(miktar) from irsaliye_IrsaliyeDetay as irsd 
 where sip_DetayID = @sip_DetayID and irsd.stok_id = ua.stok_id  and irsd.uzunluk = ua.uzunluk
 and 
(
 (Select irsaliye_tipi from irsaliye_IrsaliyeBaslik ib where ib.id =irsd.irsaliye_id) = 'QQQ'
 or
  (Select irsaliye_tipi from irsaliye_IrsaliyeBaslik ib where ib.id =irsd.irsaliye_id) = 'SAT'
  )
 
 
 ) ,0) projeyeAtananMiktar
,
(SUM(gerekenMiktar) 
- ISNULL((select SUM(miktar) from irsaliye_IrsaliyeDetay as irsd 
where sip_DetayID = @sip_DetayID and irsd.stok_id = ua.stok_id and irsd.uzunluk = ua.uzunluk
and 
(
 (Select irsaliye_tipi from irsaliye_IrsaliyeBaslik ib where ib.id =irsd.irsaliye_id) = 'QQQ'
 or
  (Select irsaliye_tipi from irsaliye_IrsaliyeBaslik ib where ib.id =irsd.irsaliye_id) = 'SAT'
  )

 ), 0)
)
ihtiyacMiktari
,
COUNT(parcaAdi) kirimAdet,
(Select hesap_adi from hesapBilgileri where id = ( Select musteri_id from proje_siparisBaslik where id = (select siparisDetay.siparis_id from proje_siparisDetay as siparisDetay where id = sip_DetayID ))) MusteriAdi,
(Select musteri_id from proje_siparisBaslik where id = (select siparisDetay.siparis_id from proje_siparisDetay as siparisDetay where id = sip_DetayID )) MusteriID

--,((select CONVERT(varchar, id)+',' from uretim_urunAgaci uua where uua.sip_DetayID=@sip_DetayID and uua.stok_id = ua.stok_id for xml path(''))) idListesi
--,((select CONVERT(varchar, ParentID1)+',' from uretim_urunAgaci uua where uua.sip_DetayID=@sip_DetayID and uua.stok_id = ua.stok_id for xml path(''))) ParentListesi

from uretim_urunAgaci as ua
where sip_DetayID = @sip_DetayID --and mamul_id = @Mamul_ID
group by
stok_id, 
kategori,
parcaAdi, 
parcaStokAdi, 
malzeme, 
uzunluk, 
prosesGrubu, 
grubuAdi,
altGrubuAdi,
seriNumarasi,
sip_DetayID,
tip,
mamul_id
order by kategori desc



END
GO
/****** Object:  StoredProcedure [dbo].[GET_SatinalmaMalzemeListesiAll]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GET_SatinalmaMalzemeListesiAll]
as
BEGIN

select 
stok_id, 
kategori,
parcaAdi, 
parcaStokAdi, 
malzeme, 
uzunluk, 
prosesGrubu, 
grubuAdi,
altGrubuAdi,
seriNumarasi,
tip,
sip_DetayID,
mamul_id,

SUM(gerekenMiktar) gerekenMiktar
,
 ISNULL((select SUM(miktar) from irsaliye_IrsaliyeDetay as irsd where irsd.stok_id = ua.stok_id ),0) projeyeAtananMiktar
,
(SUM(gerekenMiktar) 
- ISNULL((select SUM(miktar) from irsaliye_IrsaliyeDetay as irsd where irsd.stok_id = ua.stok_id), 0)
)
ihtiyacMiktari
,
COUNT(parcaAdi) kirimAdet,
(Select hesap_adi from hesapBilgileri where id = ( Select musteri_id from proje_siparisBaslik where id = (select siparisDetay.siparis_id from proje_siparisDetay as siparisDetay where id = sip_DetayID ))) MusteriAdi,
(Select musteri_id from proje_siparisBaslik where id = (select siparisDetay.siparis_id from proje_siparisDetay as siparisDetay where id = sip_DetayID )) MusteriID

--,((select CONVERT(varchar, id)+',' from uretim_urunAgaci uua where uua.sip_DetayID=@sip_DetayID and uua.stok_id = ua.stok_id for xml path(''))) idListesi
--,((select CONVERT(varchar, ParentID1)+',' from uretim_urunAgaci uua where uua.sip_DetayID=@sip_DetayID and uua.stok_id = ua.stok_id for xml path(''))) ParentListesi

from uretim_urunAgaci as ua
--and mamul_id = @Mamul_ID
group by
stok_id, 
kategori,
parcaAdi, 
parcaStokAdi, 
malzeme, 
uzunluk, 
prosesGrubu, 
grubuAdi,
altGrubuAdi,
seriNumarasi,
sip_DetayID,
tip,
mamul_id
order by kategori desc
END
GO
/****** Object:  StoredProcedure [dbo].[GET_StokBilgileri]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GET_StokBilgileri]
as
begin

select stok_id, parcaAdi, hesap_adi as lokasyon, sum(miktar) as StokMiktari, 'TEDARİK' as StokMerkezi from stok_IsletmeStokBilgileri isb
inner join stok_StokKartlari  sk on isb.stok_id = sk.id
inner join hesapBilgileri hb on isb.isletme_id = hb.id group by stok_id, parcaAdi, hesap_adi
union all
select stok_id, parcaAdi, depo_adi as lokasyon, SUM(miktar) as StokMiktari, 'DEPO' as StokMerkezi from stok_StokBilgileri sb
inner join stok_StokKartlari  sk on sb.stok_id = sk.id
inner join Depo_DepoBilgileri hb on sb.depo_id = hb.id group by stok_id, parcaAdi, depo_adi

end
GO
/****** Object:  StoredProcedure [dbo].[GET_URETIM_TedarikciKalanUretimSayisi]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
INSERT INTO stok_IsletmeStokBilgileri
(stok_id,  isletme_id  ,miktar,irsaliye_id, irsaliye_detayID) values
(1122, 1, 1,3,508)
*/

CREATE proc [dbo].[GET_URETIM_TedarikciKalanUretimSayisi]
as
begin
select 
irsd.stok_id, 
irsb.tedarikci, 
irsd.miktar,
ISNULL(sum(sb.miktar),0) as Stok_ToplamMiktar,
irsaliye_detayID,
irsd.irsaliye_id,
irsd.sip_DetayID
into #sanalTablo
from stok_IsletmeStokBilgileri sb
right join irsaliye_IrsaliyeDetay irsd on sb.irsaliye_detayID = irsd.id 
right join irsaliye_IrsaliyeBaslik irsb on irsb.id = irsd.irsaliye_id
where irsb.irsaliye_tipi = 'SAT'  
group by 
irsd.stok_id, 
irsb.tedarikci, 
irsd.miktar,
irsaliye_detayID,
irsd.irsaliye_id,
irsd.sip_DetayID


select 
ROW_NUMBER() OVER (ORDER BY st.stok_id) as sira_numarasi, 
st.stok_id,
parcaAdi,
tedarikci,
hesap_adi,
sip_DetayID,
uretim_kodu,
st.miktar,
Stok_ToplamMiktar,
(st.miktar-Stok_ToplamMiktar) as KalanUretim,
irsaliye_detayID,
irsaliye_id

from #sanalTablo  st
left join tasarim_urunAgaci ua on ua.stok_id = st.stok_id
left join hesapBilgileri hb on hb.id = st.tedarikci
left join proje_siparisDetay sd on sd.id = st.sip_DetayID
where st.miktar > Stok_ToplamMiktar
group by 
st.stok_id, 
parcaAdi,
tedarikci,
hesap_adi,
sip_DetayID, 
uretim_kodu,
st.miktar, Stok_ToplamMiktar,
irsaliye_detayID,
irsaliye_id

drop table #sanalTablo

end
GO
/****** Object:  StoredProcedure [dbo].[GET_UretimUrunAgaciListele]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GET_UretimUrunAgaciListele]
as
begin
select ua.id, parcaAdi, hatkodu, uretim_kodu, hesap_adi, sd.id as siparisDetay_id from uretim_urunagaci ua
inner join proje_siparisDetay sd on sd.id = ua.sip_DetayID
inner join proje_siparisBaslik sb on sb.id = sd.siparis_id
inner join hesapBilgileri hb on hb.id = sb.musteri_id
where mamul_id IS NULL
end
GO
/****** Object:  StoredProcedure [dbo].[GET_UrunAgaci]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GET_UrunAgaci]
@mamul_adi nvarchar(max)=null,
@mamul_id int= null
as
begin

if(@mamul_id IS NOT NULL)
begin
select * from tasarim_urunagaci where id = @mamul_id or mamul_id = @mamul_id
RETURN
end

if( @mamul_adi IS NULL OR @mamul_adi = '' )
begin
select * from tasarim_urunagaci


end
else
begin


select @mamul_id = id from tasarim_urunagaci where parcaAdi = @mamul_adi 
select * from tasarim_urunagaci where id = @mamul_id or mamul_id = @mamul_id
end
end
GO
/****** Object:  StoredProcedure [dbo].[INSERT_AyarSutunSiralamasi]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[INSERT_AyarSutunSiralamasi]
@kullaniciadi nvarchar(50),
@formadi nvarchar(max),
@sutunadi nvarchar(max),
@siralama int
as
BEGIN

if exists(select * from AYAR_SutunSiralamasi where kullaniciadi = @kullaniciadi and formadi = @formadi and sutunadi = @sutunadi )
BEGIN
UPDATE AYAR_SutunSiralamasi set siralama = @siralama where kullaniciadi = @kullaniciadi and @formadi = @formadi and sutunadi = @sutunadi
return;
END
ELSE
BEGIN
INSERT INTO AYAR_SutunSiralamasi(kullaniciadi, formadi, sutunadi, siralama) values (@kullaniciadi, @formadi, @sutunadi, @siralama )
return;
END
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_IRSALIYEMalzemeListesiStokAltMamulMiktari]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INSERT_IRSALIYEMalzemeListesiStokAltMamulMiktari]
@stok_id int,
@takimsayisi float,
@sip_DetayID int,
@irsaliye_id int
as
begin
/*
declare @sip_DetayID int
declare @stok_id int
declare @takimsayisi int

select @sip_DetayID = 6
select @stok_id= 2288
select @takimsayisi = 1
*/

declare @tasarim_id int
declare @tasarim_mamul_id int
declare @tasarim_ID1 int

select top 1 @tasarim_id = tasarim_id from uretim_urunAgaci where sip_DetayID = @sip_DetayID and stok_id =@stok_id 
select @tasarim_mamul_id = mamul_id, @tasarim_ID1 = ID1 from tasarim_urunAgaci where id = @tasarim_id

declare @AltKirimlar Table(ogeno nvarchar(max), mamul_id int, stok_id int, parcaAdi nvarchar(max), miktar float, uzunluk nvarchar(max), gerekenMiktar float, ID1 int, ParentID1 int, carpim nvarchar(max))

if EXISTS( select * from tasarim_urunAgaci where mamul_id = @tasarim_mamul_id )
BEGIN

;with tree (ogeno, mamul_id, stok_id, parcaAdi, miktar, uzunluk, gerekenMiktar, ID1, ParentID1, carpim) as (

select
usttablo.ogeno, 
usttablo.mamul_id, 
usttablo.stok_id, 
usttablo.parcaAdi, 
usttablo.miktar, 
usttablo.uzunluk,
(usttablo.miktar * @takimsayisi ) as gerekenMiktar, -- usttablo.gerekenMiktar
usttablo.ID1, 
usttablo.ParentID1, 
carpim from tasarim_urunAgaci usttablo 
where mamul_id = @tasarim_mamul_id and ParentID1  = @tasarim_ID1--  in (select ID1 from #BirinciKirimlar)

union all
select 
usttablo.ogeno, 
usttablo.mamul_id, 
usttablo.stok_id, 
usttablo.parcaAdi, 
usttablo.miktar,
usttablo.uzunluk,
CASE 
WHEN usttablo.carpim ='Hayır' then bk.gerekenMiktar
else (usttablo.miktar * bk.gerekenMiktar ) end, 
usttablo.ID1, 
usttablo.ParentID1, 
usttablo.carpim from tasarim_urunAgaci usttablo 
inner join 
tree bk on usttablo.ParentID1 = bk.ID1 
where usttablo.mamul_id = @tasarim_mamul_id 


) 
select * into #altkirimlar from tree 

insert @AltKirimlar
select * from #altkirimlar

END-- IF END
ELSE
BEGIN 

insert @AltKirimlar
select 
ogeno, 
mamul_id, 
stok_id, 
parcaAdi, 
miktar, 
uzunluk,
(gerekenMiktar * @takimsayisi) as gerekenMiktar, 
ID1, 
ParentID1, 
carpim
from  tasarim_urunAgaci where mamul_id = @tasarim_id
END



declare @irsaliyeNo varchar(15)
declare @tedarikci int
declare @hedefDepo int
select @irsaliyeNo = irsaliye_No, @tedarikci = tedarikci, @hedefDepo =hedefDepo from irsaliye_IrsaliyeBaslik where id = @irsaliye_id

declare @eklenenIrsaliyeID int
declare @DonenTablo TABLE (id int, irsaliye_no nvarchar(max))

--EXEC @eklenenIrsaliyeID = INSERT_IrsaliyeBaslik null, @tedarikci,  @hedefDepo, null, null, null, null, null, null, 5, @irsaliye_id
insert into @DonenTablo EXEC INSERT_IrsaliyeBaslik null, @tedarikci, @hedefDepo, null, null, null, null, null, 5, @irsaliye_id

select @eklenenIrsaliyeID = id from @DonenTablo


insert into irsaliye_IrsaliyeDetay 
(
irsaliye_id,
stok_id,
miktar,
uzunluk,
birim,
birimFiyat,
kdv,
terminTarihi,
kullanici,
sip_DetayID

)
Select @eklenenIrsaliyeID,kirim.stok_id, kirim.gerekenMiktar, kirim.uzunluk, null, null, null, null, null,@sip_DetayID from @AltKirimlar as kirim




--select * from #Altmamuller
-- Veritabanına İrsaliye Oluşturma Başlangıç



---Veritabanına İrsaiye Oluşturma Son


end

--drop table #BirinciKirimlar

GO
/****** Object:  StoredProcedure [dbo].[INSERT_IrsaliyeBaslik]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INSERT_IrsaliyeBaslik]
@termintarihi datetime = null,
@tedarikci int= null,
@hedefDepo int= null,
@toplamFiyat float= null,
@aciklama nvarchar(250)= null,
@hedefBirimDepo bit= null,
@cikisBirimDepo bit= null,
@kullaniciadi nvarchar(max)= null,
@irsaliye_kod_id int= null,
@referansIrsaliyeID int= null
as
BEGIN

declare @DonenTablo TABLE (id int, irsaliye_no nvarchar(max))
declare @irsaliye_tipi varchar(50)
declare @irsaliyeNo varchar(20)
declare @irsaliyeSeq int

select @irsaliyeSeq =( select seq from irsaliye_KodBilgileri where id = @irsaliye_kod_id )
select @irsaliye_tipi = (select irsaliye_kodu from irsaliye_KodBilgileri where id = @irsaliye_kod_id)

Select @irsaliyeNo = @irsaliye_tipi + convert(varchar, REPLICATE('0', 13-len(@irsaliyeSeq))) + CONVERT(varchar, @irsaliyeSeq) 

insert into irsaliye_IrsaliyeBaslik
(terminTarihi, 
tedarikci, 
hedefDepo, 
toplamFiyat, 
aciklama,
referans_IrsaliyeID, 
cikisbirimdepo,
hedefbirimdepo,
kullaniciadi, 
irsaliye_No, 
irsaliye_tipi)
output  INSERTED.id, INSERTED.irsaliye_No into @DonenTablo
values 
(@termintarihi, 
@tedarikci,
@hedefDepo, 
@toplamFiyat, 
@aciklama,
@referansIrsaliyeID, 
@cikisBirimDepo, 
@hedefBirimDepo, 
@kullaniciadi,
@irsaliyeNo, 
@irsaliye_tipi )

update irsaliye_KodBilgileri set seq = seq + 1 where id = @irsaliye_kod_id


select * from @DonenTablo

--select @outputID = id from @DonenTablo  


END


GO
/****** Object:  StoredProcedure [dbo].[INSERT_IrsaliyeDetay]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INSERT_IrsaliyeDetay]
@irsaliye_id int,
@stok_id	 int,
@miktar	float,
@uzunluk nvarchar(max) = null,
@birim	nvarchar(max) = null,
@birimFiyat	money = null,
@kdv	float = null,
@terminTarihi datetime = null,
@kullanici	nvarchar(max),
@sip_DetayID	int,
@DepoAktarim bit = 0,
@HS bit = 0
as
BEGIN

declare @InsertedTable table(id int)
insert into irsaliye_IrsaliyeDetay 
(
irsaliye_id,
stok_id,
miktar,
uzunluk,
birim,
birimFiyat,
kdv,
terminTarihi,
kullanici,
sip_DetayID,
HS
--mamul_id
)
output inserted.id into @InsertedTable
values
(
@irsaliye_id,
@stok_id,
@miktar,
@uzunluk,
@birim,
@birimFiyat,
@kdv,
@terminTarihi,
@kullanici,
@sip_DetayID,
@HS
)




declare @irsaliyeTipi varchar(5)
declare @hedefdepo int
declare @cikisdepo int
declare @cikisbirimdepo bit
declare @hedefbirimdepo bit


select @irsaliyeTipi = irsaliye_tipi, @cikisdepo = tedarikci, @hedefDepo=hedefDepo, @cikisbirimdepo=cikisbirimdepo, @hedefbirimdepo = hedefbirimdepo from irsaliye_IrsaliyeBaslik where id = @irsaliye_id 

--@cikisbirimdepo : Tedarikçi depo mu? (1:E  / 0:İŞLETME )
--@hedefbirimdepo : Hedef Dep mu? (1:E / 0:İŞLETME )
--@cikisdepo: Tedarikçi ID --stok düş ( satınalma ise stok ekle )
--@girisdepo : Hedef Depo ID -- stok ekle ( satınalma ise stok ekleme )

if(@irsaliyeTipi= 'QQQ')
BEGIN
return --stok işlemiyor. id döndürülmez.
END
ELSE
BEGIN --İrsaiye Tipi Else Begin


if(@irsaliyeTipi = 'SAT')
BEGIN --satınalma if başlangıç

if(@HS = 0)
BEGIN
print 'stok işlenmiyor.'
END
ELSE
BEGIN -- hs if else başlangıç


if(@cikisbirimdepo = 1)
INSERT INTO stok_StokBilgileri(stok_id,depo_id,miktar,irsaliye_id, irsaliye_detayID) values
(@stok_id, @cikisdepo, @miktar, @irsaliye_id, (select id from @InsertedTable) ) 
ELSE
INSERT INTO stok_IsletmeStokBilgileri(stok_id,isletme_id,miktar,irsaliye_id, irsaliye_detayID) values
(@stok_id, @cikisdepo, @miktar, @irsaliye_id, (select id from @InsertedTable) ) 

END  -- hs if else son

END -- satınalma if son

ELSE
BEGIN --satınalma else başlangıç

IF(@hedefbirimdepo = 1 ) -- STOK GİRİŞLERİ
INSERT INTO stok_StokBilgileri(stok_id,depo_id,miktar,irsaliye_id, irsaliye_detayID) values
(@stok_id, @hedefdepo, @miktar, @irsaliye_id, (select id from @InsertedTable) ) 
else
INSERT INTO stok_IsletmeStokBilgileri(stok_id,isletme_id,miktar,irsaliye_id, irsaliye_detayID) values
(@stok_id, @hedefdepo, @miktar, @irsaliye_id, (select id from @InsertedTable) ) 

IF(@cikisbirimdepo = 1 ) -- STOK ÇIKIŞLARI 
INSERT INTO stok_StokBilgileri(stok_id,depo_id,miktar,irsaliye_id, irsaliye_detayID) values
(@stok_id, @cikisdepo, @miktar*-1, @irsaliye_id, (select id from @InsertedTable) ) 
else
INSERT INTO stok_IsletmeStokBilgileri(stok_id,isletme_id,miktar,irsaliye_id, irsaliye_detayID) values
(@stok_id, @cikisdepo, @miktar*-1, @irsaliye_id, (select id from @InsertedTable) ) 


END --satınalma else son

END -- QQQ end.



select id from @InsertedTable

if(@DepoAktarim=1 ) OR (@HS = 1)
BEGIN
print 'girdi'
exec INSERT_IRSALIYEMalzemeListesiStokAltMamulMiktari @stok_id, @miktar, @sip_DetayID, @irsaliye_id
END

END








--SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.Columns WHERE TABLE_NAME = 'irsaliye_IrsaliyeDetay'

GO
/****** Object:  StoredProcedure [dbo].[INSERT_IsletmeStok]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INSERT_IsletmeStok]
@stok_id int,
@isletme_id int,
@miktar float,
@irsaliye_id int,
@irsaliye_detayID int
as
begin


INSERT INTO stok_IsletmeStokBilgileri
(stok_id,  isletme_id  ,miktar,irsaliye_id, irsaliye_detayID) values
(@stok_id, @isletme_id, @miktar,@irsaliye_id,@irsaliye_detayID)

select 'success' as msg


end
GO
/****** Object:  StoredProcedure [dbo].[INSERT_TasarimUrunAgaci]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INSERT_TasarimUrunAgaci]
@mamul_id	int = null,
--@stok_id	nchar(10) = null,
@ogeno	nvarchar(MAX) = null,
@parcaAdi	nvarchar(MAX) = null,
@resimNo	nvarchar(MAX)= null,
@prosesGrubu	nvarchar(MAX)= null,
@grubuAdi	nvarchar(MAX)= null,
@altGrubuAdi	nvarchar(MAX)= null,
@parcaStokAdi	nvarchar(MAX)= null,
@malzeme	nvarchar(MAX)= null,
@uzunluk	nvarchar(MAX)= null,
@agirlik	nvarchar(MAX)= null,
@rota	nvarchar(MAX)= null,
@miktar	float= null,
@seriNumarasi	nvarchar(MAX)= -1,
@gerekenMiktar	float= null,
@ParentID	nvarchar(MAX)= null,
@ID1	int= null,
@ParentID1	int= null,
@tip	nvarchar(MAX)= null,
@carpim	nvarchar(MAX)= null,
@kategori	nvarchar(MAX)= null,
@kullaniciadi	nvarchar(MAX)= null,
@eklemetipi int = null --Mamül / Kırım.  ( Mamül 0, kırım 1) 
as
BEGIN



declare @StokID int

if exists (Select * from stok_StokKartlari where parcaAdi = @parcaAdi and seriNumarasi=@seriNumarasi and malzeme = @malzeme) 
begin
select @StokID = id from stok_StokKartlari where parcaAdi = @parcaAdi and seriNumarasi=@seriNumarasi and malzeme = @malzeme
end
else
begin
declare @StokTablo table (EklenenID int)
insert into stok_StokKartlari (parcaAdi,seriNumarasi, malzeme) output inserted.id into @StokTablo values(@parcaAdi,@seriNumarasi, @malzeme)
Select @StokID = EklenenID from @StokTablo
end


if (@eklemetipi = 0 )
begin
declare @UrunTablo table (EklenenID2 int)
declare @UrunEklenenID int
INSERT INTO tasarim_urunagaci (ogeno,stok_id,parcaAdi,resimNo,prosesGrubu,grubuAdi,altGrubuAdi,parcaStokAdi,malzeme,uzunluk,agirlik,rota,miktar,seriNumarasi,gerekenMiktar,ParentID,ID1,ParentID1,tip,carpim,kategori,kullaniciadi) output INSERTED.id into @UrunTablo VALUES(@ogeno,@StokID,@parcaAdi,@resimNo,@prosesGrubu,@grubuAdi,@altGrubuAdi,@parcaStokAdi,@malzeme,@uzunluk,@agirlik,@rota,@miktar,@seriNumarasi,@gerekenMiktar,@ParentID,@ID1,@ParentID1,@tip,@carpim,@kategori,@kullaniciadi) 
Select @UrunEklenenID = EklenenID2  from @UrunTablo
select @UrunEklenenID
end

if(@eklemetipi = 1 )
begin
INSERT INTO tasarim_urunagaci (ogeno,mamul_id,stok_id,parcaAdi,resimNo,prosesGrubu,grubuAdi,altGrubuAdi,parcaStokAdi,malzeme,uzunluk,agirlik,rota,miktar,seriNumarasi,gerekenMiktar,ParentID,ID1,ParentID1,tip,carpim,kategori,kullaniciadi) VALUES(@ogeno,@mamul_id,@StokID,@parcaAdi,@resimNo,@prosesGrubu,@grubuAdi,@altGrubuAdi,@parcaStokAdi,@malzeme,@uzunluk,@agirlik,@rota,@miktar,@seriNumarasi,@gerekenMiktar,@ParentID,@ID1,@ParentID1,@tip,@carpim,@kategori,@kullaniciadi) 
end


END
	
GO
/****** Object:  StoredProcedure [dbo].[INSERT_UretimUrunAgaci]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INSERT_UretimUrunAgaci]
@sip_DetayID int,
@kullaniciadi nvarchar(max),
@Tasarim_ID int,
@takimSayisi int
as
begin


insert into uretim_urunAgaci
select 
null as mamul_id,
id as tasarim_id, 
stok_id,
ogeno,
parcaAdi,
resimNo,
prosesGrubu,
grubuAdi,
altGrubuAdi,
parcaStokAdi,
malzeme,
uzunluk,
agirlik,
rota,
(miktar*@takimSayisi) as miktar,
seriNumarasi,
(gerekenMiktar*@takimSayisi) as gerekenMiktar,
ParentID,
ID1,
ParentID1,
tip,
carpim,
kategori,
ISNULL(@kullaniciadi, kullaniciadi) as kullaniciadi,
@sip_DetayID as sip_DetayID 
from tasarim_urunAgaci where id = @Tasarim_ID

declare @INSERTED_ID int
select @INSERTED_ID = id from uretim_urunAgaci where tasarim_id = @Tasarim_ID


insert into uretim_urunAgaci
select 
@INSERTED_ID as mamul_id,
id as tasarim_id, 
stok_id,
ogeno,
parcaAdi,
resimNo,
prosesGrubu,
grubuAdi,
altGrubuAdi,
parcaStokAdi,
malzeme,
uzunluk,
agirlik,
rota,
miktar,
seriNumarasi,
(gerekenMiktar*@takimSayisi) as gerekenMiktar,
ParentID,
ID1,
ParentID1,
tip,
carpim,
kategori,
ISNULL(@kullaniciadi, kullaniciadi) as kullaniciadi,
@sip_DetayID as sip_DetayID 
from tasarim_urunAgaci where mamul_id = @Tasarim_ID


/*

insert into satinalma_MalzemeListesi 
(mamul_id,parcaAdi,parcaStokAdi,malzeme, uzunluk, tip, grubuAdi, altGrubuAdi, kategori, sip_DetayID, gerekenMiktar, kirimMiktari)
select mamul_id,parcaAdi,parcaStokAdi,malzeme,uzunluk,tip,grubuAdi,altGrubuAdi, kategori, sip_DetayID, sum(gerekenMiktar) as gerekenMiktar, COUNT(parcaAdi) as kirimMiktari
from uretim_urunAgaci 
where mamul_id = @Tasarim_ID or id = @Tasarim_ID and sip_DetayID = @sip_DetayID
group by mamul_id,parcaAdi,parcaStokAdi,malzeme,uzunluk,tip,grubuAdi,altGrubuAdi,kategori,sip_DetayID
*/

end
GO
/****** Object:  StoredProcedure [dbo].[kullaniciLogin]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[kullaniciLogin]
@username nvarchar(50) = null,
@password nvarchar(50) = null
AS
BEGIN



--Token Start
DECLARE @automateKey VARCHAR(15)
DECLARE @Length INT = 15
DECLARE @Count INT = 15

SET @Length = @Length + 1
SET @Count = @Count + 1
--this seems unnecessary , why not just SET @Count = 3 ?

SELECT @automateKey =  
      (SELECT CAST((ABS(Checksum(NewId())) % 10) AS VARCHAR(1)) + 
              CHAR(ascii('A')+(Abs(Checksum(NewId()))%25)) +
              LEFT(newid(),@count) Random_Number)

WHILE (@automateKey LIKE '%0%' OR @automateKey LIKE '%1%')
BEGIN
    SELECT @automateKey = REPLACE(@automateKey, '0', (Abs(Checksum(NewId()))%10))
    SELECT @automateKey = REPLACE(@automateKey, '1', (Abs(Checksum(NewId()))%10))
END

WHILE (@automateKey LIKE '%O%' OR @automateKey LIKE '%L%')
BEGIN
    SELECT @automateKey = REPLACE(@automateKey, 'O', CHAR(ascii('A')+(Abs(Checksum(NewId()))%25)))
    SELECT @automateKey = REPLACE(@automateKey, 'L', CHAR(ascii('A')+(Abs(Checksum(NewId()))%25)))
END


--Token End



IF EXISTS ( Select * from kullaniciBilgileri where kullaniciadi = @username and parola = @password ) 
BEGIN
select kullaniciadi,adsoyad,birim,bolum,gorev, @automateKey as 'token' from kullaniciBilgileri where kullaniciadi = @username and parola = @password

declare @u_id INT
declare @u_name nvarchar(50)
select @u_id = id, @u_name = kullaniciadi from kullaniciBilgileri where kullaniciadi = @username and parola = @password


insert into kullaniciToken(user_id, username, token) values (@u_id, @u_name,@automateKey)


END
ELSE
BEGIN
Select 'Hatalı Kullanıcı adı veya parola' as ERROR, @username as 'KullanıcıAdı'
--select @username as username, @password as password
RAISERROR('Hatalı kullanıcı adı veya parola', 16,1)
END

END




GO
/****** Object:  StoredProcedure [dbo].[SET_ProjeSiparisDetayDurumTakipID]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SET_ProjeSiparisDetayDurumTakipID]
@siparis_DetayID int,
@durumTakipID int
as
begin

UPDATE proje_siparisDetay set durumTakipID = @durumTakipID where id = @siparis_DetayID


end
GO
/****** Object:  StoredProcedure [dbo].[tokenCheck]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tokenCheck]
@token nvarchar(50) = null,
@kullaniciadi nvarchar(50) = null
AS
BEGIN
if EXISTS(select TOP(1) * from kullaniciToken where username = @kullaniciadi and token = @token order by id desc )
begin 
select '1' as tokenState, kullaniciadi, adsoyad, parola from kullaniciBilgileri where kullaniciadi = @kullaniciadi;
end
else
begin
select '0' as tokenState
end
END
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_IrsaliyeDetay]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[UPDATE_IrsaliyeDetay]
@id int,
--@irsaliye_id int,
@stok_id	 int,
--@kategori	 nvarchar(max),
--@parcaAdi	nvarchar(max),
--@parcaStokAdi	nvarchar(max),
--@malzeme	nvarchar(max),
--@uzunluk	nvarchar(max),
--@prosesGrubu	nvarchar(max),
--@grubuAdi	nvarchar(max),
--@altGrubuAdi	nvarchar(max),
--@seriNumarasi	nvarchar(max),
--@tip	nvarchar(max),
--@miktar	float,
@birim	nvarchar(max),
@birimFiyat	money,
@kdv	float,
@terminTarihi	datetime,
@kullanici	nvarchar(max),
@sip_DetayID	int
--@mamul_id	int
as
BEGIN

UPDATE irsaliye_IrsaliyeDetay 
SET
stok_id = @stok_id,
--miktar = @miktar,
@birim = @birim,
birimFiyat = @birimFiyat,
kdv = @kdv,
terminTarihi = @terminTarihi,
kullanici = @kullanici,
sip_DetayID = @sip_DetayID
where id = @id

/*
UPDATE stok_StokBilgileri 
SET 
miktar = 
CASE
WHEN ( miktar > 0) THEN @miktar
WHEN ( miktar < 0) then @miktar * -1
end 
where irsaliye_detayID = @id
*/

END








--SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.Columns WHERE TABLE_NAME = 'irsaliye_IrsaliyeDetay'

GO
/****** Object:  StoredProcedure [dbo].[WEB_GET_DepoVeIsletmeBilgileri]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[WEB_GET_DepoVeIsletmeBilgileri]
as
begin
select id, depo_adi from Depo_DepoBilgileri 
select id, hesap_adi from hesapBilgileri
end
GO
/****** Object:  StoredProcedure [dbo].[WEB_GET_IrsaliyeDetay]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[WEB_GET_IrsaliyeDetay]
@irsaliyeNo nvarchar(16)
as
begin
declare @irsaliye_id int
select @irsaliye_id = id from irsaliye_IrsaliyeBaslik where irsaliye_No = @irsaliyeNo

select  *,
CASE 
WHEN cikisbirimdepo = 0 then (Select hesap_adi from hesapBilgileri where id = tedarikci)
else (select depo_adi from Depo_DepoBilgileri where id = tedarikci ) end as tedarikci_adi,
CASE
WHEN hedefbirimdepo = 0 then (Select hesap_adi from hesapBilgileri where id = hedefDepo)
else (select depo_adi from Depo_DepoBilgileri where id = hedefDepo ) end as hedef_yeri
from irsaliye_IrsaliyeBaslik where irsaliye_No = @irsaliyeNo

select 
irsd.id,
parcaAdi,
stok_id,
irsd.miktar as stokMiktari,
irsd.birim,
irsd.birimFiyat,
irsd.kdv,
irsd.terminTarihi,
sd.uretim_kodu,
uzunluk,
ib.tedarikci as isletme_id,
sd.id as siparis_DetayID,

CASE
WHEN cikisbirimdepo = 0 then 
( select SUM(miktar) from stok_IsletmeStokBilgileri where isletme_id = tedarikci )
else
( select SUM(miktar) from stok_StokBilgileri where depo_id = tedarikci )
end as anlikStokMiktari,
CASE 
WHEN cikisbirimdepo = 0 then (Select hesap_adi from hesapBilgileri where id = tedarikci)
else (select depo_adi from Depo_DepoBilgileri where id = tedarikci ) end as hesap_adi
from irsaliye_IrsaliyeDetay irsd
inner join stok_StokKartlari sk on sk.id = irsd.stok_id
inner join proje_siparisDetay sd on sd.id = irsd.sip_DetayID
inner join irsaliye_IrsaliyeBaslik ib on ib.id =irsd.irsaliye_id 
where irsaliye_id = @irsaliye_id

end
GO
/****** Object:  StoredProcedure [dbo].[WEB_GET_KonumaGoreMalzemeListesi]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[WEB_GET_KonumaGoreMalzemeListesi]
as
begin

select ROW_NUMBER() OVER (ORDER BY isletme_id) as sira_numarasi, 
sb.stok_id, 
parcaAdi, 
isletme_id, 
hesap_adi,
psd.uretim_kodu,
psd.id as siparis_DetayID,
SUM(sb.miktar) as stokMiktari,
uzunluk

from stok_IsletmeStokBilgileri sb
left join stok_StokKartlari sk on sk.id = sb.stok_id
left join hesapBilgileri hb on hb.id = sb.isletme_id
left join irsaliye_IrsaliyeDetay irsd on irsd.id = sb.irsaliye_detayID
left join proje_siparisDetay psd on irsd.sip_DetayID = psd.id
group by  sb.stok_id, parcaAdi, isletme_id, hesap_adi, psd.uretim_kodu, psd.id, uzunluk HAVING SUM(sb.miktar) <> 0

end


--Birim
/*CASE 
WHEN UPPER(irsd.birim) = '' then 'TANIMSIZ'
WHEN  UPPER(irsd.birim) IS NULL then 'TANIMSIZ'
else
UPPER(irsd.birim) end as birim*/
GO
/****** Object:  StoredProcedure [dbo].[WEB_GET_Proje_SiparisDetay]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[WEB_GET_Proje_SiparisDetay]
as
begin
select sd.id as sd_id, sd.miktar as takimSayisi, uretim_kodu,hatkodu as hat_kodu, pypSorumlusu, hesap_adi from proje_siparisDetay sd
inner join proje_siparisBaslik sb on sd.siparis_id = sb. id
inner join hesapBilgileri hb on sb.musteri_id = hb.id
end
GO
/****** Object:  StoredProcedure [dbo].[WEB_GET_ProjeBazliIrsaliyeListesi]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[WEB_GET_ProjeBazliIrsaliyeListesi]
@sip_DetayID int
as
BEGIN
select 
tedarikci,
hedefDepo,
CASE 
WHEN cikisbirimdepo = 0 then (Select hesap_adi from hesapBilgileri where id = tedarikci)
else (select depo_adi from Depo_DepoBilgileri where id = tedarikci ) end as tedarikci_adi,
CASE
WHEN hedefbirimdepo = 0 then (Select hesap_adi from hesapBilgileri where id = hedefDepo)
else (select depo_adi from Depo_DepoBilgileri where id = hedefDepo ) end as hedef_yeri,
ib.olusturmaTarihi as olusturma_tarihi,
ib.terminTarihi as termin_tarihi,
irsaliye_No as irsaliye_no,
irsaliye_tipi,
uretim_kodu
into #temp
from irsaliye_IrsaliyeBaslik  ib
inner join stok_IsletmeStokBilgileri isb on isb.irsaliye_id = ib.id
left join irsaliye_IrsaliyeDetay id on ib.id = id.irsaliye_id
left join proje_siparisDetay psd on id.sip_DetayID = psd.id
where sip_DetayID = @sip_DetayID and irsaliye_tipi != 'QQQ'
--select * from #temp

select tedarikci_adi, hedef_yeri, olusturma_tarihi, termin_tarihi, irsaliye_no, uretim_kodu  from #temp
group by tedarikci_adi, hedef_yeri, olusturma_tarihi, termin_tarihi, irsaliye_no, uretim_kodu
order by irsaliye_no asc
/*union
select tedarikci_adi, hedef_yeri, olusturma_tarihi, termin_tarihi, irsaliye_no, uretim_kodu  from #temp
where tedarikci in (
select isletme_id from stok_IsletmeStokBilgileri group by isletme_id, stok_id, irsaliye_id HAVING SUM(miktar)<> 0 ) and irsaliye_tipi = 'SAT'
group by tedarikci_adi, hedef_yeri, olusturma_tarihi, termin_tarihi, irsaliye_no
order by irsaliye_no asc
--group by tedarikci_adi, hedef_yeri, olusturma_tarihi, termin_tarihi, irsaliye_no 
*/

drop table #temp

END
--select * from stok_IsletmeStokBilgileri
GO
/****** Object:  StoredProcedure [dbo].[WEB_INSERT_Irsaliye]    Script Date: 14.10.2021 09:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[WEB_INSERT_Irsaliye]
@irsaliyebaslik nvarchar(max),
@irsaliyedetay nvarchar(max) = null
as
BEGIN

select * from OPENJSON(@irsaliyebaslik)

END
GO
USE [master]
GO
ALTER DATABASE [optimak] SET  READ_WRITE 
GO
