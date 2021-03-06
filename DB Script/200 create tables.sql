USE [master]
GO
/****** Object:  Database [PharmacyInterventions]    Script Date: 21/10/2014 11:25:44 a.m. ******/
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
USE [PharmacyInterventions]
GO
/****** Object:  Table [dbo].[Contribution]    Script Date: 21/10/2014 11:25:44 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contribution](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nhi] [varchar](7) NOT NULL,
	[WardId] [int] NOT NULL,
	[PharmacistId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[StaffInvolvedId] [int] NOT NULL,
	[MedicationId1] [int] NOT NULL,
	[MedicationId2] [int] NULL,
	[OutcomeId] [int] NOT NULL,
	[StageId] [int] NOT NULL,
	[TimeFrameId] [int] NOT NULL,
	[Details] [varchar](max) NULL,
	[ContributionTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Contributions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContributionType]    Script Date: 21/10/2014 11:25:44 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContributionType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ContributionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InterventionGrade]    Script Date: 21/10/2014 11:25:44 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InterventionGrade](
	[Value] [int] NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[Example] [varchar](500) NOT NULL,
 CONSTRAINT [PK_InterventionGrade] PRIMARY KEY CLUSTERED 
(
	[Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Interventions]    Script Date: 21/10/2014 11:25:44 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Interventions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nhi] [varchar](7) NOT NULL,
	[WardId] [int] NOT NULL,
	[PharmacistId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Details] [varchar](max) NULL,
	[InterventionGradeValue] [int] NOT NULL,
	[DoseReceived] [bit] NOT NULL CONSTRAINT [DF_Interventions_DoesReceived]  DEFAULT ((1)),
	[MedicationId1] [int] NOT NULL,
	[MedicationId2] [int] NULL,
	[InterventionTypeId] [int] NOT NULL,
	[RiskMonitorPro] [bit] NOT NULL CONSTRAINT [DF_Interventions_RiskMonitorPro]  DEFAULT ((0)),
	[StaffInvolvedId] [int] NOT NULL,
	[TimeFrameId] [int] NOT NULL,
	[OutcomeId] [int] NOT NULL,
	[StageId] [int] NOT NULL,
 CONSTRAINT [PK_Interventions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InterventionType]    Script Date: 21/10/2014 11:25:44 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InterventionType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InterventionTypeCategoryId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_InterventionType_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_InterventionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InterventionTypeCategory]    Script Date: 21/10/2014 11:25:44 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InterventionTypeCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_InterventionTypeCategory_IsActive]  DEFAULT ((1)),
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_InterventionTypeCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Kpi]    Script Date: 21/10/2014 11:25:44 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Kpi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PharmacistId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[WardId] [int] NOT NULL,
	[Notes] [varchar](max) NULL,
	[MedicationChartsReviewed] [int] NOT NULL,
	[MedicinesReconciliationsMedical] [int] NOT NULL,
	[MedicinesReconciliationsSurgical] [int] NOT NULL,
	[MedicinesReconciliationsOther] [int] NOT NULL,
	[YellowCardsCompleted] [int] NOT NULL,
	[YellowCardsCompletedAndCounselled] [int] NOT NULL,
	[WarfarinCounselling] [int] NOT NULL,
	[SelfMedication] [int] NOT NULL,
	[DischargeOrderReview] [int] NOT NULL,
	[CommunityLiaison] [int] NOT NULL,
	[MedicineEducationTalks] [int] NOT NULL,
 CONSTRAINT [PK_Kpi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Medications]    Script Date: 21/10/2014 11:25:44 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Medications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_Medications_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_Medications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Outcomes]    Script Date: 21/10/2014 11:25:44 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Outcomes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Outcomes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pharmacists]    Script Date: 21/10/2014 11:25:44 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pharmacists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_Pharmacists_IsActive]  DEFAULT ((1)),
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_Pharmacists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StaffTypes]    Script Date: 21/10/2014 11:25:44 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StaffTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StaffTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Stages]    Script Date: 21/10/2014 11:25:44 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Stages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Stages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TimeFrames]    Script Date: 21/10/2014 11:25:44 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TimeFrames](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TimeFrames] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Wards]    Script Date: 21/10/2014 11:25:44 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Wards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_Wards_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_Wards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Contribution]  WITH CHECK ADD  CONSTRAINT [FK_Contribution_ContributionType] FOREIGN KEY([ContributionTypeId])
REFERENCES [dbo].[ContributionType] ([Id])
GO
ALTER TABLE [dbo].[Contribution] CHECK CONSTRAINT [FK_Contribution_ContributionType]
GO
ALTER TABLE [dbo].[Contribution]  WITH CHECK ADD  CONSTRAINT [FK_Contribution_Medications] FOREIGN KEY([MedicationId1])
REFERENCES [dbo].[Medications] ([Id])
GO
ALTER TABLE [dbo].[Contribution] CHECK CONSTRAINT [FK_Contribution_Medications]
GO
ALTER TABLE [dbo].[Contribution]  WITH CHECK ADD  CONSTRAINT [FK_Contribution_Medications1] FOREIGN KEY([MedicationId2])
REFERENCES [dbo].[Medications] ([Id])
GO
ALTER TABLE [dbo].[Contribution] CHECK CONSTRAINT [FK_Contribution_Medications1]
GO
ALTER TABLE [dbo].[Contribution]  WITH CHECK ADD  CONSTRAINT [FK_Contribution_Outcomes] FOREIGN KEY([OutcomeId])
REFERENCES [dbo].[Outcomes] ([Id])
GO
ALTER TABLE [dbo].[Contribution] CHECK CONSTRAINT [FK_Contribution_Outcomes]
GO
ALTER TABLE [dbo].[Contribution]  WITH CHECK ADD  CONSTRAINT [FK_Contribution_Pharmacists] FOREIGN KEY([PharmacistId])
REFERENCES [dbo].[Pharmacists] ([Id])
GO
ALTER TABLE [dbo].[Contribution] CHECK CONSTRAINT [FK_Contribution_Pharmacists]
GO
ALTER TABLE [dbo].[Contribution]  WITH CHECK ADD  CONSTRAINT [FK_Contribution_StaffTypes] FOREIGN KEY([StaffInvolvedId])
REFERENCES [dbo].[StaffTypes] ([Id])
GO
ALTER TABLE [dbo].[Contribution] CHECK CONSTRAINT [FK_Contribution_StaffTypes]
GO
ALTER TABLE [dbo].[Contribution]  WITH CHECK ADD  CONSTRAINT [FK_Contribution_Stages] FOREIGN KEY([StageId])
REFERENCES [dbo].[Stages] ([Id])
GO
ALTER TABLE [dbo].[Contribution] CHECK CONSTRAINT [FK_Contribution_Stages]
GO
ALTER TABLE [dbo].[Contribution]  WITH CHECK ADD  CONSTRAINT [FK_Contribution_TimeFrames] FOREIGN KEY([TimeFrameId])
REFERENCES [dbo].[TimeFrames] ([Id])
GO
ALTER TABLE [dbo].[Contribution] CHECK CONSTRAINT [FK_Contribution_TimeFrames]
GO
ALTER TABLE [dbo].[Contribution]  WITH CHECK ADD  CONSTRAINT [FK_Contribution_Wards] FOREIGN KEY([WardId])
REFERENCES [dbo].[Wards] ([Id])
GO
ALTER TABLE [dbo].[Contribution] CHECK CONSTRAINT [FK_Contribution_Wards]
GO
ALTER TABLE [dbo].[Interventions]  WITH CHECK ADD  CONSTRAINT [FK_Interventions_InterventionGrade] FOREIGN KEY([InterventionGradeValue])
REFERENCES [dbo].[InterventionGrade] ([Value])
GO
ALTER TABLE [dbo].[Interventions] CHECK CONSTRAINT [FK_Interventions_InterventionGrade]
GO
ALTER TABLE [dbo].[Interventions]  WITH CHECK ADD  CONSTRAINT [FK_Interventions_InterventionType] FOREIGN KEY([InterventionTypeId])
REFERENCES [dbo].[InterventionType] ([Id])
GO
ALTER TABLE [dbo].[Interventions] CHECK CONSTRAINT [FK_Interventions_InterventionType]
GO
ALTER TABLE [dbo].[Interventions]  WITH CHECK ADD  CONSTRAINT [FK_Interventions_Outcomes] FOREIGN KEY([OutcomeId])
REFERENCES [dbo].[Outcomes] ([Id])
GO
ALTER TABLE [dbo].[Interventions] CHECK CONSTRAINT [FK_Interventions_Outcomes]
GO
ALTER TABLE [dbo].[Interventions]  WITH CHECK ADD  CONSTRAINT [FK_Interventions_Pharmacists] FOREIGN KEY([PharmacistId])
REFERENCES [dbo].[Pharmacists] ([Id])
GO
ALTER TABLE [dbo].[Interventions] CHECK CONSTRAINT [FK_Interventions_Pharmacists]
GO
ALTER TABLE [dbo].[Interventions]  WITH CHECK ADD  CONSTRAINT [FK_Interventions_StaffTypes] FOREIGN KEY([StaffInvolvedId])
REFERENCES [dbo].[StaffTypes] ([Id])
GO
ALTER TABLE [dbo].[Interventions] CHECK CONSTRAINT [FK_Interventions_StaffTypes]
GO
ALTER TABLE [dbo].[Interventions]  WITH CHECK ADD  CONSTRAINT [FK_Interventions_Stages] FOREIGN KEY([StageId])
REFERENCES [dbo].[Stages] ([Id])
GO
ALTER TABLE [dbo].[Interventions] CHECK CONSTRAINT [FK_Interventions_Stages]
GO
ALTER TABLE [dbo].[Interventions]  WITH CHECK ADD  CONSTRAINT [FK_Interventions_TimeFrames] FOREIGN KEY([TimeFrameId])
REFERENCES [dbo].[TimeFrames] ([Id])
GO
ALTER TABLE [dbo].[Interventions] CHECK CONSTRAINT [FK_Interventions_TimeFrames]
GO
ALTER TABLE [dbo].[Interventions]  WITH CHECK ADD  CONSTRAINT [FK_Interventions_Wards] FOREIGN KEY([WardId])
REFERENCES [dbo].[Wards] ([Id])
GO
ALTER TABLE [dbo].[Interventions] CHECK CONSTRAINT [FK_Interventions_Wards]
GO
ALTER TABLE [dbo].[Interventions]  WITH CHECK ADD  CONSTRAINT [FK_Interventions1_Medications] FOREIGN KEY([MedicationId1])
REFERENCES [dbo].[Medications] ([Id])
GO
ALTER TABLE [dbo].[Interventions] CHECK CONSTRAINT [FK_Interventions1_Medications]
GO
ALTER TABLE [dbo].[Interventions]  WITH CHECK ADD  CONSTRAINT [FK_Interventions2_Medications] FOREIGN KEY([MedicationId2])
REFERENCES [dbo].[Medications] ([Id])
GO
ALTER TABLE [dbo].[Interventions] CHECK CONSTRAINT [FK_Interventions2_Medications]
GO
ALTER TABLE [dbo].[InterventionType]  WITH CHECK ADD  CONSTRAINT [FK_InterventionType_InterventionTypeCategory1] FOREIGN KEY([InterventionTypeCategoryId])
REFERENCES [dbo].[InterventionTypeCategory] ([Id])
GO
ALTER TABLE [dbo].[InterventionType] CHECK CONSTRAINT [FK_InterventionType_InterventionTypeCategory1]
GO
ALTER TABLE [dbo].[Kpi]  WITH CHECK ADD  CONSTRAINT [FK_Kpi_Pharmacists] FOREIGN KEY([PharmacistId])
REFERENCES [dbo].[Pharmacists] ([Id])
GO
ALTER TABLE [dbo].[Kpi] CHECK CONSTRAINT [FK_Kpi_Pharmacists]
GO
ALTER TABLE [dbo].[Kpi]  WITH CHECK ADD  CONSTRAINT [FK_Kpi_Wards] FOREIGN KEY([WardId])
REFERENCES [dbo].[Wards] ([Id])
GO
ALTER TABLE [dbo].[Kpi] CHECK CONSTRAINT [FK_Kpi_Wards]
GO
USE [master]
GO
ALTER DATABASE [PharmacyInterventions] SET  READ_WRITE 
GO
