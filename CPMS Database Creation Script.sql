USE [master]
GO
/****** Object:  Database [CPMS]    Script Date: 5/5/2021 12:59:06 PM ******/
CREATE DATABASE [CPMS]
GO
ALTER DATABASE [CPMS] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CPMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CPMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CPMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CPMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CPMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CPMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [CPMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CPMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CPMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CPMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CPMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CPMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CPMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CPMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CPMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CPMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CPMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CPMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CPMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CPMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CPMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CPMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CPMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CPMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CPMS] SET  MULTI_USER 
GO
ALTER DATABASE [CPMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CPMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CPMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CPMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CPMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CPMS] SET QUERY_STORE = OFF
GO
USE [CPMS]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [CPMS]
GO
/****** Object:  User [IUSRCPMS]    Script Date: 5/5/2021 12:59:06 PM ******/
CREATE USER [IUSRCPMS] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [IUSRCPMS]
GO
ALTER ROLE [db_datareader] ADD MEMBER [IUSRCPMS]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [IUSRCPMS]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 5/5/2021 12:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleInitial] [nvarchar](1) NULL,
	[LastName] [nvarchar](50) NULL,
	[Affiliation] [nvarchar](50) NULL,
	[Department] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](2) NULL,
	[ZipCode] [nvarchar](10) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](100) NULL,
	[Password] [nvarchar](5) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Defaults]    Script Date: 5/5/2021 12:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Defaults](
	[EnabledReviewers] [bit] NULL,
	[EnabledAuthors] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paper]    Script Date: 5/5/2021 12:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paper](
	[PaperID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorID] [int] NULL,
	[Active] [bit] NULL,
	[FilenameOriginal] [nvarchar](100) NULL,
	[Filename] [nvarchar](100) NULL,
	[Title] [nvarchar](200) NULL,
	[Certification] [nvarchar](3) NULL,
	[NotesToReviewers] [nvarchar](max) NULL,
	[AnalysisOfAlgorithms] [bit] NULL,
	[Applications] [bit] NULL,
	[Architecture] [bit] NULL,
	[ArtificialIntelligence] [bit] NULL,
	[ComputerEngineering] [bit] NULL,
	[Curriculum] [bit] NULL,
	[DataStructures] [bit] NULL,
	[Databases] [bit] NULL,
	[DistanceLearning] [bit] NULL,
	[DistributedSystems] [bit] NULL,
	[EthicalSocietalIssues] [bit] NULL,
	[FirstYearComputing] [bit] NULL,
	[GenderIssues] [bit] NULL,
	[GrantWriting] [bit] NULL,
	[GraphicsImageProcessing] [bit] NULL,
	[HumanComputerInteraction] [bit] NULL,
	[LaboratoryEnvironments] [bit] NULL,
	[Literacy] [bit] NULL,
	[MathematicsInComputing] [bit] NULL,
	[Multimedia] [bit] NULL,
	[NetworkingDataCommunications] [bit] NULL,
	[NonMajorCourses] [bit] NULL,
	[ObjectOrientedIssues] [bit] NULL,
	[OperatingSystems] [bit] NULL,
	[ParallelsProcessing] [bit] NULL,
	[Pedagogy] [bit] NULL,
	[ProgrammingLanguages] [bit] NULL,
	[Research] [bit] NULL,
	[Security] [bit] NULL,
	[SoftwareEngineering] [bit] NULL,
	[SystemsAnalysisAndDesign] [bit] NULL,
	[UsingTechnologyInTheClassroom] [bit] NULL,
	[WebAndInternetProgramming] [bit] NOT NULL,
	[Other] [bit] NULL,
	[OtherDescription] [nvarchar](50) NULL,
 CONSTRAINT [PK_Paper] PRIMARY KEY CLUSTERED 
(
	[PaperID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 5/5/2021 12:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[PaperID] [int] NULL,
	[ReviewerID] [int] NULL,
	[AppropriatenessOfTopic] [decimal](3, 2) NULL,
	[TimelinessOfTopic] [decimal](3, 2) NULL,
	[SupportiveEvidence] [decimal](3, 2) NULL,
	[TechnicalQuality] [decimal](3, 2) NULL,
	[ScopeOfCoverage] [decimal](3, 2) NULL,
	[CitationOfPreviousWork] [decimal](3, 2) NULL,
	[Originality] [decimal](3, 2) NULL,
	[ContentComments] [nvarchar](max) NULL,
	[OrganizationOfPaper] [decimal](3, 2) NULL,
	[ClarityOfMainMessage] [decimal](3, 2) NULL,
	[Mechanics] [decimal](3, 2) NULL,
	[WrittenDocumentComments] [nvarchar](max) NULL,
	[SuitabilityForPresentation] [decimal](3, 2) NULL,
	[PotentialInterestInTopic] [decimal](3, 2) NULL,
	[PotentialForOralPresentationComments] [nvarchar](max) NULL,
	[OverallRating] [decimal](3, 2) NULL,
	[OverallRatingComments] [nvarchar](max) NULL,
	[ComfortLevelTopic] [decimal](3, 2) NULL,
	[ComfortLevelAcceptability] [decimal](3, 2) NULL,
	[Complete] [bit] NULL,
 CONSTRAINT [PK_Score] PRIMARY KEY CLUSTERED 
(
	[ReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviewer]    Script Date: 5/5/2021 12:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviewer](
	[ReviewerID] [int] IDENTITY(1,1) NOT NULL,
	[Active] [bit] NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleInitial] [nvarchar](1) NULL,
	[LastName] [nvarchar](50) NULL,
	[Affiliation] [nvarchar](50) NULL,
	[Department] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](2) NULL,
	[ZipCode] [nvarchar](10) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](100) NULL,
	[Password] [nvarchar](5) NULL,
	[AnalysisOfAlgorithms] [bit] NULL,
	[Applications] [bit] NULL,
	[Architecture] [bit] NULL,
	[ArtificialIntelligence] [bit] NULL,
	[ComputerEngineering] [bit] NULL,
	[Curriculum] [bit] NULL,
	[DataStructures] [bit] NULL,
	[Databases] [bit] NULL,
	[DistancedLearning] [bit] NULL,
	[DistributedSystems] [bit] NULL,
	[EthicalSocietalIssues] [bit] NULL,
	[FirstYearComputing] [bit] NULL,
	[GenderIssues] [bit] NULL,
	[GrantWriting] [bit] NULL,
	[GraphicsImageProcessing] [bit] NULL,
	[HumanComputerInteraction] [bit] NULL,
	[LaboratoryEnvironments] [bit] NULL,
	[Literacy] [bit] NULL,
	[MathematicsInComputing] [bit] NULL,
	[Multimedia] [bit] NULL,
	[NetworkingDataCommunications] [bit] NULL,
	[NonMajorCourses] [bit] NULL,
	[ObjectOrientedIssues] [bit] NULL,
	[OperatingSystems] [bit] NULL,
	[ParallelProcessing] [bit] NULL,
	[Pedagogy] [bit] NULL,
	[ProgrammingLanguages] [bit] NULL,
	[Research] [bit] NULL,
	[Security] [bit] NULL,
	[SoftwareEngineering] [bit] NULL,
	[SystemsAnalysisAndDesign] [bit] NULL,
	[UsingTechnologyInTheClassroom] [bit] NULL,
	[WebAndInternetProgramming] [bit] NOT NULL,
	[Other] [bit] NULL,
	[OtherDescription] [nvarchar](50) NULL,
	[ReviewsAcknowledged] [bit] NULL,
 CONSTRAINT [PK_Reviewer] PRIMARY KEY CLUSTERED 
(
	[ReviewerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_FirstName]  DEFAULT ('') FOR [FirstName]
GO
ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_MiddleInitial]  DEFAULT ('') FOR [MiddleInitial]
GO
ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_LastName]  DEFAULT ('') FOR [LastName]
GO
ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_Affiliation]  DEFAULT ('') FOR [Affiliation]
GO
ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_Department]  DEFAULT ('') FOR [Department]
GO
ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_Address]  DEFAULT ('') FOR [Address]
GO
ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_City]  DEFAULT ('') FOR [City]
GO
ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_State]  DEFAULT ('') FOR [State]
GO
ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_ZipCode]  DEFAULT ('') FOR [ZipCode]
GO
ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_PhoneNumber]  DEFAULT ('') FOR [PhoneNumber]
GO
ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_EmailAddress]  DEFAULT ('') FOR [EmailAddress]
GO
ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_Password]  DEFAULT ('') FOR [Password]
GO
ALTER TABLE [dbo].[Defaults] ADD  CONSTRAINT [DF_Defaults_ActiveWebsite]  DEFAULT ((0)) FOR [EnabledReviewers]
GO
ALTER TABLE [dbo].[Defaults] ADD  CONSTRAINT [DF_Defaults_EnabledAuthors]  DEFAULT ((0)) FOR [EnabledAuthors]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_FilenameOriginal]  DEFAULT ('') FOR [FilenameOriginal]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_Filename]  DEFAULT ('') FOR [Filename]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_Title]  DEFAULT ('') FOR [Title]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_Certification]  DEFAULT ('') FOR [Certification]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_NotesToReviewers]  DEFAULT ('') FOR [NotesToReviewers]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_AnalysisOfAlgorithms]  DEFAULT ((0)) FOR [AnalysisOfAlgorithms]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_Applications]  DEFAULT ((0)) FOR [Applications]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_Architecture]  DEFAULT ((0)) FOR [Architecture]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_ArtificialIntelligence]  DEFAULT ((0)) FOR [ArtificialIntelligence]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_ComputerEngineering]  DEFAULT ((0)) FOR [ComputerEngineering]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_Curriculum]  DEFAULT ((0)) FOR [Curriculum]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_DataStructures]  DEFAULT ((0)) FOR [DataStructures]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_Databases]  DEFAULT ((0)) FOR [Databases]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_DistanceLearning]  DEFAULT ((0)) FOR [DistanceLearning]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_DistributedSystems]  DEFAULT ((0)) FOR [DistributedSystems]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_EthicalSocietalIssues]  DEFAULT ((0)) FOR [EthicalSocietalIssues]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_FirstYearComputing]  DEFAULT ((0)) FOR [FirstYearComputing]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_GenderIssues]  DEFAULT ((0)) FOR [GenderIssues]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_GrantWriting]  DEFAULT ((0)) FOR [GrantWriting]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_GraphicsImageProcessing]  DEFAULT ((0)) FOR [GraphicsImageProcessing]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_HumanComputerInteraction]  DEFAULT ((0)) FOR [HumanComputerInteraction]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_LaboratoryEnvironments]  DEFAULT ((0)) FOR [LaboratoryEnvironments]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_Literacy]  DEFAULT ((0)) FOR [Literacy]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_MathematicsInComputing]  DEFAULT ((0)) FOR [MathematicsInComputing]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_Multimedia]  DEFAULT ((0)) FOR [Multimedia]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_NetworkingDataCommunications]  DEFAULT ((0)) FOR [NetworkingDataCommunications]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_NonMajorCourses]  DEFAULT ((0)) FOR [NonMajorCourses]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_ObjectOrientedIssues]  DEFAULT ((0)) FOR [ObjectOrientedIssues]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_OperatingSystems]  DEFAULT ((0)) FOR [OperatingSystems]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_ParallelProcessing]  DEFAULT ((0)) FOR [ParallelsProcessing]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_Pedagogy]  DEFAULT ((0)) FOR [Pedagogy]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_ProgrammingLanguages]  DEFAULT ((0)) FOR [ProgrammingLanguages]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_Research]  DEFAULT ((0)) FOR [Research]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_Security]  DEFAULT ((0)) FOR [Security]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_SoftwareEngineering]  DEFAULT ((0)) FOR [SoftwareEngineering]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_SystemsAnalysisAndDesign]  DEFAULT ((0)) FOR [SystemsAnalysisAndDesign]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_UsingTechnologyInTheClassroom]  DEFAULT ((0)) FOR [UsingTechnologyInTheClassroom]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_WebAndInternetProgramming]  DEFAULT ((0)) FOR [WebAndInternetProgramming]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_Other]  DEFAULT ((0)) FOR [Other]
GO
ALTER TABLE [dbo].[Paper] ADD  CONSTRAINT [DF_Paper_OtherDescription]  DEFAULT ('') FOR [OtherDescription]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_AppropriatenessOfTopic]  DEFAULT ((0)) FOR [AppropriatenessOfTopic]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_TimelinessOfTopic]  DEFAULT ((0)) FOR [TimelinessOfTopic]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_SupportiveEvidence]  DEFAULT ((0)) FOR [SupportiveEvidence]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_TechnicalQuality]  DEFAULT ((0)) FOR [TechnicalQuality]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_ScopeOfCoverage]  DEFAULT ((0)) FOR [ScopeOfCoverage]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_CitationOfPreviousWork]  DEFAULT ((0)) FOR [CitationOfPreviousWork]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_Originality]  DEFAULT ((0)) FOR [Originality]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_ContentComments]  DEFAULT ('') FOR [ContentComments]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_OrganizationOfPaper]  DEFAULT ((0)) FOR [OrganizationOfPaper]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_ClarityOfMainMessage]  DEFAULT ((0)) FOR [ClarityOfMainMessage]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_Mechanics]  DEFAULT ((0)) FOR [Mechanics]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_WrittenDocumentComments]  DEFAULT ('') FOR [WrittenDocumentComments]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_SuitabilityForPresentation]  DEFAULT ((0)) FOR [SuitabilityForPresentation]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_PotentialInterestInTopic]  DEFAULT ((0)) FOR [PotentialInterestInTopic]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_PotentialForOralPresentationComments]  DEFAULT ('') FOR [PotentialForOralPresentationComments]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_OverallRating]  DEFAULT ((0)) FOR [OverallRating]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_OverallRatingComments]  DEFAULT ('') FOR [OverallRatingComments]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_ComfortLevelTopic]  DEFAULT ((0)) FOR [ComfortLevelTopic]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_ComfortLevelAcceptability]  DEFAULT ((0)) FOR [ComfortLevelAcceptability]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_Complete]  DEFAULT ((0)) FOR [Complete]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_FirstName]  DEFAULT ('') FOR [FirstName]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_MiddleInitial]  DEFAULT ('') FOR [MiddleInitial]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_LastName]  DEFAULT ('') FOR [LastName]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_Affiliation]  DEFAULT ('') FOR [Affiliation]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_Department]  DEFAULT ('') FOR [Department]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_Address]  DEFAULT ('') FOR [Address]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_City]  DEFAULT ('') FOR [City]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_State]  DEFAULT ('') FOR [State]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_ZipCode]  DEFAULT ('') FOR [ZipCode]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_PhoneNumber]  DEFAULT ('') FOR [PhoneNumber]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_EmailAddress]  DEFAULT ('') FOR [EmailAddress]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_Password]  DEFAULT ('') FOR [Password]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_AnalysisOfAlgorithms]  DEFAULT ((0)) FOR [AnalysisOfAlgorithms]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_Applications]  DEFAULT ((0)) FOR [Applications]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_Architecture]  DEFAULT ((0)) FOR [Architecture]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_ArtificialIntelligence]  DEFAULT ((0)) FOR [ArtificialIntelligence]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_ComputerEngineering]  DEFAULT ((0)) FOR [ComputerEngineering]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_Curriculum]  DEFAULT ((0)) FOR [Curriculum]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_DataStructures]  DEFAULT ((0)) FOR [DataStructures]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_Databases]  DEFAULT ((0)) FOR [Databases]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_DistanceLearning]  DEFAULT ((0)) FOR [DistancedLearning]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_DistributedSystems]  DEFAULT ((0)) FOR [DistributedSystems]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_EthicalSocietalIssues]  DEFAULT ((0)) FOR [EthicalSocietalIssues]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_FirstYearComputing]  DEFAULT ((0)) FOR [FirstYearComputing]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_GenderIssues]  DEFAULT ((0)) FOR [GenderIssues]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_GrantWriting]  DEFAULT ((0)) FOR [GrantWriting]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_GraphicsImageProcessing]  DEFAULT ((0)) FOR [GraphicsImageProcessing]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_HumanComputerInteraction]  DEFAULT ((0)) FOR [HumanComputerInteraction]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_LaboratoryEnvironments]  DEFAULT ((0)) FOR [LaboratoryEnvironments]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_Literacy]  DEFAULT ((0)) FOR [Literacy]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_MathematicsInComputing]  DEFAULT ((0)) FOR [MathematicsInComputing]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_Multimedia]  DEFAULT ((0)) FOR [Multimedia]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_NetworkingDataCommunications]  DEFAULT ((0)) FOR [NetworkingDataCommunications]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_NonMajorCourses]  DEFAULT ((0)) FOR [NonMajorCourses]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_ObjectOrientedIssues]  DEFAULT ((0)) FOR [ObjectOrientedIssues]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_OperatingSystems]  DEFAULT ((0)) FOR [OperatingSystems]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_ParallelProcessing]  DEFAULT ((0)) FOR [ParallelProcessing]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_Pedagogy]  DEFAULT ((0)) FOR [Pedagogy]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_ProgrammingLanguages]  DEFAULT ((0)) FOR [ProgrammingLanguages]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_Research]  DEFAULT ((0)) FOR [Research]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_Security]  DEFAULT ((0)) FOR [Security]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_SoftwareEngineering]  DEFAULT ((0)) FOR [SoftwareEngineering]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_SystemsAnalysisAndDesign]  DEFAULT ((0)) FOR [SystemsAnalysisAndDesign]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_UsingTechnologyInTheClassroom]  DEFAULT ((0)) FOR [UsingTechnologyInTheClassroom]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_WebAndInternetProgramming]  DEFAULT ((0)) FOR [WebAndInternetProgramming]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_Other]  DEFAULT ((0)) FOR [Other]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_OtherDescription]  DEFAULT ('') FOR [OtherDescription]
GO
ALTER TABLE [dbo].[Reviewer] ADD  CONSTRAINT [DF_Reviewer_ReviewsAcknowledged]  DEFAULT ((0)) FOR [ReviewsAcknowledged]
GO
ALTER TABLE [dbo].[Paper]  WITH CHECK ADD  CONSTRAINT [FK_Paper_Author] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Author] ([AuthorID])
GO
ALTER TABLE [dbo].[Paper] CHECK CONSTRAINT [FK_Paper_Author]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Reviewer] FOREIGN KEY([ReviewerID])
REFERENCES [dbo].[Reviewer] ([ReviewerID])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Reviewer]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Score_Paper] FOREIGN KEY([PaperID])
REFERENCES [dbo].[Paper] ([PaperID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Score_Paper]
GO
/****** Object:  StoredProcedure [dbo].[spAuthorCheckDuplicate]    Script Date: 5/5/2021 12:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[spAuthorCheckDuplicate]
	-- Add the parameters for the stored procedure here
	@EmailAddress AS nvarchar(100),
	@RowCount as int OUTPUT
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT AuthorID
	  FROM Author
	 WHERE EmailAddress = @EmailAddress;

	SELECT @RowCount = @@ROWCOUNT;

END
GO
/****** Object:  StoredProcedure [dbo].[spAuthorLogin]    Script Date: 5/5/2021 12:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spAuthorLogin]
	-- Add the parameters for the stored procedure here
	@EmailAddress AS nvarchar(100),
	@Password AS nvarchar(5),
	@RowCount as int OUTPUT,
	@AuthorID AS int OUTPUT,
	@FirstName AS nvarchar(50) OUTPUT,
	@User AS nvarchar(100) OUTPUT
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT @AuthorID = AuthorID,
		   @FirstName = FirstName,
	       @User = FirstName + ' ' + MiddleInitial + ' ' + LastName
	  FROM Author
	 WHERE EmailAddress = @EmailAddress
	   AND Password = @Password;

	SELECT @RowCount = @@ROWCOUNT;

END
GO
/****** Object:  StoredProcedure [dbo].[spAuthorRetrievePassword]    Script Date: 5/5/2021 12:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[spAuthorRetrievePassword]
	-- Add the parameters for the stored procedure here
	@EmailAddress AS nvarchar(100),
	@Password AS nvarchar(5) OUTPUT,
	@RowCount AS int OUTPUT
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT @Password = Password
	  FROM Author
	 WHERE EmailAddress = @EmailAddress;

	SELECT @RowCount = @@ROWCOUNT;

END
GO
/****** Object:  StoredProcedure [dbo].[spDefaultsRetrieve]    Script Date: 5/5/2021 12:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[spDefaultsRetrieve]
	-- Add the parameters for the stored procedure here
	@EnabledReviewers as bit OUTPUT,
	@EnabledAuthors as bit OUTPUT
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT @EnabledReviewers = EnabledReviewers,
		   @EnabledAuthors = EnabledAuthors
	  FROM Defaults;

END
GO
/****** Object:  StoredProcedure [dbo].[spPaperRetrieveNotesToReviewers]    Script Date: 5/5/2021 12:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[spPaperRetrieveNotesToReviewers]
	-- Add the parameters for the stored procedure here
	@PaperID AS int,
	@NotesToReviewers AS nvarchar(max) OUTPUT
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT @NotesToReviewers = NotesToReviewers
	  FROM Paper
	 WHERE PaperID = @PaperID;

END
GO
/****** Object:  StoredProcedure [dbo].[spPaperRetrieveTItle]    Script Date: 5/5/2021 12:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[spPaperRetrieveTItle]
	-- Add the parameters for the stored procedure here
	@PaperID AS int,
	@Title AS nvarchar(max) OUTPUT
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT @Title = Title
	  FROM Paper
	 WHERE PaperID = @PaperID;

END
GO
/****** Object:  StoredProcedure [dbo].[spReviewCheckDuplicate]    Script Date: 5/5/2021 12:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[spReviewCheckDuplicate]
	-- Add the parameters for the stored procedure here
	@PaperID AS int,
	@ReviewerID AS int,
	@RowCount as int OUTPUT
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ReviewID
	  FROM Review
	 WHERE PaperID = @PaperID
	   AND ReviewerID = @ReviewerID;

	SELECT @RowCount = @@ROWCOUNT;

END
GO
/****** Object:  StoredProcedure [dbo].[spReviewerCheckDuplicate]    Script Date: 5/5/2021 12:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[spReviewerCheckDuplicate]
	-- Add the parameters for the stored procedure here
	@EmailAddress AS nvarchar(100),
	@RowCount as int OUTPUT
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ReviewerID
	  FROM Reviewer
	 WHERE EmailAddress = @EmailAddress;

	SELECT @RowCount = @@ROWCOUNT;

END
GO
/****** Object:  StoredProcedure [dbo].[spReviewerLogin]    Script Date: 5/5/2021 12:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spReviewerLogin]
	-- Add the parameters for the stored procedure here
	@EmailAddress AS nvarchar(100),
	@Password AS nvarchar(5),
	@RowCount as int OUTPUT,
	@ReviewerID AS int OUTPUT,
	@FirstName AS nvarchar(50) OUTPUT,
	@User AS nvarchar(100) OUTPUT
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT @ReviewerID = ReviewerID,
		   @FirstName = FirstName,
	       @User = FirstName + ' ' + MiddleInitial + ' ' + LastName
	  FROM Reviewer
	 WHERE EmailAddress = @EmailAddress
	   AND Password = @Password;

	SELECT @RowCount = @@ROWCOUNT;

END
GO
/****** Object:  StoredProcedure [dbo].[spReviewerRetrievePassword]    Script Date: 5/5/2021 12:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[spReviewerRetrievePassword]
	-- Add the parameters for the stored procedure here
	@EmailAddress AS nvarchar(100),
	@Password AS nvarchar(5) OUTPUT,
	@RowCount AS int OUTPUT
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT @Password = Password
	  FROM Reviewer
	 WHERE EmailAddress = @EmailAddress;

	SELECT @RowCount = @@ROWCOUNT;

END
GO
/****** Object:  StoredProcedure [dbo].[spReviewGetNumberOfReviews]    Script Date: 5/5/2021 12:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[spReviewGetNumberOfReviews]
	-- Add the parameters for the stored procedure here
	@PaperID AS int,
	@RowCount as int OUTPUT
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT @RowCount = COUNT(ReviewID)
	  FROM Review
	 WHERE PaperID = @PaperID

END
GO
/****** Object:  StoredProcedure [dbo].[spReviewInsert]    Script Date: 5/5/2021 12:59:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spReviewInsert]
	-- Add the parameters for the stored procedure here
    @PaperID int,
    @ReviewerID int,
    @AppropriatenessOfTopic decimal(18,2) = 3.00,
    @TimelinessOfTopic decimal(18,2) = 3.00,
    @SupportiveEvidence decimal(18,2) = 3.00,
    @TechnicalQuality decimal(18,2) = 3.00,
    @ScopeOfCoverage decimal(18,2) = 3.00,
    @CitationOfPreviousWork decimal(18,2) = 3.00,
    @Originality decimal(18,2) = 3.00,
    @ContentComments nvarchar(MAX) = '',
    @OrganizationOfPaper decimal(18,2) = 3.00,
    @ClarityOfMainMessage decimal(18,2) = 3.00,
    @Mechanics decimal(18,2) = 3.00,
    @WrittenDocumentComments nvarchar(MAX) = '',
    @SuitabilityForPresentation decimal(18,2) = 3.00,
    @PotentialInterestInTopic decimal(18,2) = 3.00,
    @PotentialForOralPresentationComments nvarchar(MAX) = '',
    @OverallRating decimal(18,2) = 3.00,
    @OverallRatingComments nvarchar(MAX) = '',
    @ComfortLevelTopic decimal(18,2) = 3.00,
    @ComfortLevelAcceptability decimal(18,2) = 3.00,
    @Complete bit = 0

AS

BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    INSERT
        INTO Review
        (
            PaperID,
            ReviewerID,
            AppropriatenessOfTopic,
            TimelinessOfTopic,
            SupportiveEvidence,
            TechnicalQuality,
            ScopeOfCoverage,
            CitationOfPreviousWork,
            Originality,
            ContentComments,
            OrganizationOfPaper,
            ClarityOfMainMessage,
            Mechanics,
            WrittenDocumentComments,
            SuitabilityForPresentation,
            PotentialInterestInTopic,
            PotentialForOralPresentationComments,
            OverallRating,
            OverallRatingComments,
			ComfortLevelTopic,
			ComfortLevelAcceptability,
            Complete
        )
    VALUES
        (
            @PaperID,
            @ReviewerID,
            @AppropriatenessOfTopic,
            @TimelinessOfTopic,
            @SupportiveEvidence,
            @TechnicalQuality,
            @ScopeOfCoverage,
            @CitationOfPreviousWork,
            @Originality,
            @ContentComments,
            @OrganizationOfPaper,
            @ClarityOfMainMessage,
            @Mechanics,
            @WrittenDocumentComments,
            @SuitabilityForPresentation,
            @PotentialInterestInTopic,
            @PotentialForOralPresentationComments,
            @OverallRating,
            @OverallRatingComments,
			@ComfortLevelTopic,
			@ComfortLevelAcceptability,
            @Complete
        ) ;

END
GO
USE [master]
GO
ALTER DATABASE [CPMS] SET  READ_WRITE 
GO
