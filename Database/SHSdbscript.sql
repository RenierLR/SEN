USE [master]
GO
/****** Object:  Database [SHSDatabase]    Script Date: 2018/06/05 21:27:37 ******/
CREATE DATABASE [SHSDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MainData', FILENAME = N'D:\Campus\SEN321\Database\MainData.mdf' , SIZE = 307200KB , MAXSIZE = 20971520KB , FILEGROWTH = 2048KB )
 LOG ON 
( NAME = N'MainLog', FILENAME = N'D:\Campus\SEN321\Database\MainLog.ldf' , SIZE = 307200KB , MAXSIZE = 20971520KB , FILEGROWTH = 2048KB )
GO
ALTER DATABASE [SHSDatabase] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SHSDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SHSDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SHSDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SHSDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SHSDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SHSDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [SHSDatabase] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SHSDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SHSDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SHSDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SHSDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SHSDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SHSDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SHSDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SHSDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SHSDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SHSDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SHSDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SHSDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SHSDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SHSDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SHSDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SHSDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SHSDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SHSDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [SHSDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SHSDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SHSDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SHSDatabase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SHSDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SHSDatabase]
GO
/****** Object:  Table [dbo].[tblAddress]    Script Date: 2018/06/05 21:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblAddress](
	[rowNumber] [int] IDENTITY(101,1) NOT NULL,
	[globalUniqueID] [uniqueidentifier] NOT NULL,
	[country] [varchar](50) NOT NULL,
	[city] [varchar](50) NOT NULL,
	[postalCode] [varchar](10) NOT NULL,
	[street1] [varchar](128) NOT NULL,
	[street2] [varchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[globalUniqueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblAppointment]    Script Date: 2018/06/05 21:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblAppointment](
	[rowNumber] [int] IDENTITY(101,1) NOT NULL,
	[globalUniqueID] [uniqueidentifier] NOT NULL,
	[technician_guid] [uniqueidentifier] NULL,
	[client_guid] [uniqueidentifier] NOT NULL,
	[requestDate] [datetime] NOT NULL,
	[appointmentDate] [datetime] NULL,
	[taskType] [varchar](50) NOT NULL,
	[description] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[globalUniqueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblClient]    Script Date: 2018/06/05 21:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblClient](
	[rowNumber] [int] IDENTITY(101,1) NOT NULL,
	[globalUniqueID] [uniqueidentifier] NOT NULL,
	[clientIdentifier] [varchar](9) NULL,
	[person_guid] [uniqueidentifier] NOT NULL,
UNIQUE NONCLUSTERED 
(
	[globalUniqueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblClientContract]    Script Date: 2018/06/05 21:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblClientContract](
	[rowNumber] [int] IDENTITY(101,1) NOT NULL,
	[globalUniqueID] [uniqueidentifier] NOT NULL,
	[issueDate] [datetime] NOT NULL,
	[numberPaymentsMade] [int] NOT NULL,
	[client_guid] [uniqueidentifier] NOT NULL,
	[contractIdentifier] [varchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[globalUniqueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblConfiguration]    Script Date: 2018/06/05 21:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblConfiguration](
	[rowNumber] [int] IDENTITY(101,1) NOT NULL,
	[globalUniqueID] [uniqueidentifier] NOT NULL,
	[option_guid] [uniqueidentifier] NOT NULL,
	[description] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[globalUniqueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblConfigurationProducts]    Script Date: 2018/06/05 21:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblConfigurationProducts](
	[rowNumber] [int] IDENTITY(101,1) NOT NULL,
	[configuration_guid] [uniqueidentifier] NOT NULL,
	[product_guid] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblContactDetails]    Script Date: 2018/06/05 21:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblContactDetails](
	[rowNumber] [int] IDENTITY(101,1) NOT NULL,
	[globalUniqueID] [uniqueidentifier] NOT NULL,
	[cellNumber] [varchar](10) NOT NULL,
	[email] [varchar](128) NOT NULL,
	[tellNumber] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[globalUniqueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblContract]    Script Date: 2018/06/05 21:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblContract](
	[rowNumber] [int] IDENTITY(101,1) NOT NULL,
	[globalUniqueID] [uniqueidentifier] NOT NULL,
	[contractIdentifier] [varchar](12) NOT NULL,
	[cost] [money] NOT NULL,
	[paymentType] [varchar](50) NOT NULL,
	[numberPayments] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[contractIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblContractOffer]    Script Date: 2018/06/05 21:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblContractOffer](
	[rowNumber] [int] IDENTITY(101,1) NOT NULL,
	[offer_guid] [uniqueidentifier] NOT NULL,
	[contractIdentifier] [varchar](12) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblOffer]    Script Date: 2018/06/05 21:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblOffer](
	[rowNumber] [int] IDENTITY(101,1) NOT NULL,
	[globalUniqueID] [uniqueidentifier] NOT NULL,
	[category] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [text] NOT NULL,
	[discount] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[globalUniqueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblOperator]    Script Date: 2018/06/05 21:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblOperator](
	[rowNumber] [int] IDENTITY(101,1) NOT NULL,
	[globalUniqueID] [uniqueidentifier] NOT NULL,
	[person_guid] [uniqueidentifier] NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[globalUniqueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblOptions]    Script Date: 2018/06/05 21:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblOptions](
	[rowNumber] [int] IDENTITY(101,1) NOT NULL,
	[globalUniqueID] [uniqueidentifier] NOT NULL,
	[name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[globalUniqueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblPerson]    Script Date: 2018/06/05 21:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPerson](
	[rowNumber] [int] IDENTITY(101,1) NOT NULL,
	[globalUniqueID] [uniqueidentifier] NOT NULL,
	[address_guid] [uniqueidentifier] NOT NULL,
	[contactDetails_guid] [uniqueidentifier] NOT NULL,
	[identificationNumber] [varchar](13) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[surname] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[globalUniqueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblProducts]    Script Date: 2018/06/05 21:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProducts](
	[rowNumber] [int] IDENTITY(101,1) NOT NULL,
	[globalUniqueID] [uniqueidentifier] NOT NULL,
	[category] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[manufacturer] [varchar](50) NOT NULL,
	[model] [varchar](50) NOT NULL,
	[serialNumber] [varchar](50) NOT NULL,
	[description] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[globalUniqueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTechnician]    Script Date: 2018/06/05 21:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTechnician](
	[rowNumber] [int] IDENTITY(101,1) NOT NULL,
	[globalUniqueID] [uniqueidentifier] NOT NULL,
	[person_guid] [uniqueidentifier] NOT NULL,
	[hireDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[globalUniqueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tblAppointment]  WITH CHECK ADD FOREIGN KEY([client_guid])
REFERENCES [dbo].[tblClient] ([globalUniqueID])
GO
ALTER TABLE [dbo].[tblClient]  WITH CHECK ADD FOREIGN KEY([person_guid])
REFERENCES [dbo].[tblPerson] ([globalUniqueID])
GO
ALTER TABLE [dbo].[tblClientContract]  WITH CHECK ADD FOREIGN KEY([client_guid])
REFERENCES [dbo].[tblClient] ([globalUniqueID])
GO
ALTER TABLE [dbo].[tblClientContract]  WITH CHECK ADD FOREIGN KEY([contractIdentifier])
REFERENCES [dbo].[tblContract] ([contractIdentifier])
GO
ALTER TABLE [dbo].[tblConfiguration]  WITH CHECK ADD FOREIGN KEY([option_guid])
REFERENCES [dbo].[tblOptions] ([globalUniqueID])
GO
ALTER TABLE [dbo].[tblConfigurationProducts]  WITH CHECK ADD FOREIGN KEY([configuration_guid])
REFERENCES [dbo].[tblConfiguration] ([globalUniqueID])
GO
ALTER TABLE [dbo].[tblConfigurationProducts]  WITH CHECK ADD FOREIGN KEY([product_guid])
REFERENCES [dbo].[tblProducts] ([globalUniqueID])
GO
ALTER TABLE [dbo].[tblContractOffer]  WITH CHECK ADD FOREIGN KEY([contractIdentifier])
REFERENCES [dbo].[tblContract] ([contractIdentifier])
GO
ALTER TABLE [dbo].[tblContractOffer]  WITH CHECK ADD FOREIGN KEY([offer_guid])
REFERENCES [dbo].[tblOffer] ([globalUniqueID])
GO
ALTER TABLE [dbo].[tblOperator]  WITH CHECK ADD FOREIGN KEY([person_guid])
REFERENCES [dbo].[tblPerson] ([globalUniqueID])
GO
ALTER TABLE [dbo].[tblPerson]  WITH CHECK ADD FOREIGN KEY([address_guid])
REFERENCES [dbo].[tblAddress] ([globalUniqueID])
GO
ALTER TABLE [dbo].[tblPerson]  WITH CHECK ADD FOREIGN KEY([contactDetails_guid])
REFERENCES [dbo].[tblContactDetails] ([globalUniqueID])
GO
ALTER TABLE [dbo].[tblTechnician]  WITH CHECK ADD FOREIGN KEY([person_guid])
REFERENCES [dbo].[tblPerson] ([globalUniqueID])
GO
/****** Object:  StoredProcedure [dbo].[getAllClients]    Script Date: 2018/06/05 21:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getAllClients] 
AS   
BEGIN
    SELECT C.globalUniqueID AS [CglobalUniqueID], C.clientIdentifier,
		   P.globalUniqueID AS [PglobalUniqueID], P.identificationNumber, P.name, P.surname,
		   A.globalUniqueID AS [AglobalUniqueID], A.city, A.country, A.postalCode, A.street1, A.street2,
		   CD.globalUniqueID AS [CDglobalUniqueID], CD.cellNumber, CD.email, CD.tellNumber 
		   --CO.globalUniqueID, CO.numberPayments, CO.paymentType, 
		   --CC.globalUniqueID, CC.contractIdentifier, CC.issueDate, CC.numberPaymentsMade
    FROM tblClient C 
	INNER JOIN tblPerson P ON C.person_guid = P.globalUniqueID
	INNER JOIN tblAddress A ON P.address_guid = A.globalUniqueID
	INNER JOIN tblContactDetails CD ON P.contactDetails_guid = CD.globalUniqueID
	--INNER JOIN tblClientContract CC ON C.globalUniqueID = CC.client_guid
	--INNER JOIN tblContract CO ON CC.contract_guid = CO.globalUniqueID
END

GO
/****** Object:  StoredProcedure [dbo].[insertClient]    Script Date: 2018/06/05 21:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertClient]
	@ClientGlobalUniqueID UNIQUEIDENTIFIER, 
	@ClientIdentifier VARCHAR(9),
	@PersonGlobalUniqueID UNIQUEIDENTIFIER, 
	@ID VARCHAR(15), 
	@Name VARCHAR(50), 
	@Surname VARCHAR(50),
	@AddressGlobalUniqueID UNIQUEIDENTIFIER, 
	@City VARCHAR(50), 
	@Country VARCHAR(50), 
	@PostalCode VARCHAR(10), 
	@Street1 VARCHAR(128), 
	@Street2 VARCHAR(128),
	@ContactDetailsGlobalUniqueID UNIQUEIDENTIFIER, 
	@CellNumber VARCHAR(10), 
	@Email VARCHAR(128), 
	@TellNumber VARCHAR(10) 
	--@ContractGlobalUniqueID UNIQUEIDENTIFIER, 
	--@ClientContractGlobalUniqueID UNIQUEIDENTIFIER, 
	--@ContractIdentifier VARCHAR(12), 
	--@IssueDate DATE, 
	--@NumberPaymentsMade INT

AS   
BEGIN
	INSERT INTO tblAddress(globalUniqueID, country, city, postalCode, street1, street2)
	VALUES (@AddressGlobalUniqueID, @Country, @City, @PostalCode, @Street1, @Street2)
	
	INSERT INTO tblContactDetails(globalUniqueID, cellNumber, email, tellNumber)
	VALUES (@ContactDetailsGlobalUniqueID, @CellNumber, @Email, @TellNumber)

	INSERT INTO tblPerson(globalUniqueID, address_guid, contactDetails_guid, identificationNumber, name, surname)
	VALUES (@PersonGlobalUniqueID, @AddressGlobalUniqueID, @ContactDetailsGlobalUniqueID, @ID, @Name, @Surname)

	INSERT INTO tblClient(globalUniqueID, clientIdentifier, person_guid)
	VALUES (@ClientGlobalUniqueID, @ClientIdentifier, @PersonGlobalUniqueID)

	--INSERT INTO tblClientContract(globalUniqueID, contractIdentifier, issueDate, numberPaymentsMade, client_guid, contract_guid)
	--VALUES (@ClientContractGlobalUniqueID, @ContractIdentifier, @IssueDate, @NumberPaymentsMade, @ClientGlobalUniqueID, @ContractGlobalUniqueID)
END
---------------------------------------------------------------------------------------
GO
USE [master]
GO
ALTER DATABASE [SHSDatabase] SET  READ_WRITE 
GO
