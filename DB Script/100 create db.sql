USE [master]
GO

/****** Object:  Database [PharmacyInterventions]    Script Date: 21/10/2014 11:24:07 a.m. ******/
CREATE DATABASE [PharmacyInterventions] ON  PRIMARY 
( NAME = N'PharmacyInterventions', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\PharmacyInterventions.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PharmacyInterventions_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\PharmacyInterventions_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [PharmacyInterventions] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PharmacyInterventions].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [PharmacyInterventions] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET ARITHABORT OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [PharmacyInterventions] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [PharmacyInterventions] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [PharmacyInterventions] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET  DISABLE_BROKER 
GO

ALTER DATABASE [PharmacyInterventions] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [PharmacyInterventions] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [PharmacyInterventions] SET  MULTI_USER 
GO

ALTER DATABASE [PharmacyInterventions] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [PharmacyInterventions] SET DB_CHAINING OFF 
GO

ALTER DATABASE [PharmacyInterventions] SET  READ_WRITE 
GO


