USE master
GO
if exists (select * from sysdatabases where name='SHSDatabase')
		drop database SHSDatabase
GO

CREATE DATABASE SHSDatabase
ON PRIMARY (
	NAME = MainData,
	FILENAME = "D:\Campus\SEN321\Database\MainData.mdf",
	SIZE = 300MB,
	MAXSIZE = 20GB,
	FILEGROWTH = 2MB
)

LOG ON (
	NAME = MainLog,
	FILENAME = "D:\Campus\SEN321\Database\MainLog.ldf",
	SIZE = 300MB,
	MAXSIZE = 20GB,
	FILEGROWTH = 2MB
)
GO

SET quoted_identifier on
GO

SET DATEFORMAT mdy
GO

USE "SHSDatabase"
GO

GO
CREATE TABLE tblAddress (
	rowNumber INT IDENTITY (101,1),
	globalUniqueID UNIQUEIDENTIFIER PRIMARY KEY,
	country VARCHAR(50) NOT NULL,
	city VARCHAR(50) NOT NULL,
	postalCode VARCHAR(10) NOT NULL,
	street1 VARCHAR(128) NOT NULL,
	street2 VARCHAR(128) NOT NULL
)

GO
CREATE TABLE tblContactDetails (
	rowNumber INT IDENTITY (101,1),
	globalUniqueID UNIQUEIDENTIFIER PRIMARY KEY,
	cellNumber VARCHAR(10) NOT NULL,
	email VARCHAR(128) NOT NULL,
	tellNumber VARCHAR(10) NOT NULL
)

GO
CREATE TABLE tblPerson (
	rowNumber INT IDENTITY (101,1),
	globalUniqueID UNIQUEIDENTIFIER PRIMARY KEY,
	address_guid UNIQUEIDENTIFIER NOT NULL,
	contactDetails_guid UNIQUEIDENTIFIER NOT NULL,
	identificationNumber VARCHAR(13) NOT NULL,
	name VARCHAR(50) NOT NULL,
	surname VARCHAR(50) NOT NULL,
	FOREIGN KEY (address_guid) REFERENCES tblAddress(globalUniqueID),
	FOREIGN KEY (contactDetails_guid) REFERENCES tblContactDetails(globalUniqueID)
)

GO
CREATE TABLE tblClient (
	rowNumber INT IDENTITY (101,1),
	globalUniqueID UNIQUEIDENTIFIER NOT NULL UNIQUE,
	clientIdentifier VARCHAR(9),
	person_guid UNIQUEIDENTIFIER NOT NULL,
	FOREIGN KEY (person_guid) REFERENCES tblPerson(globalUniqueID)
)

GO
CREATE TABLE tblTechnician (
	rowNumber INT IDENTITY (101,1),
	globalUniqueID UNIQUEIDENTIFIER PRIMARY KEY,
	person_guid UNIQUEIDENTIFIER NOT NULL,
	hireDate DATETIME NOT NULL,
	FOREIGN KEY (person_guid) REFERENCES tblPerson(globalUniqueID)
)

GO
CREATE TABLE tblOperator(
	rowNumber INT IDENTITY (101,1),
	globalUniqueID UNIQUEIDENTIFIER PRIMARY KEY,
	person_guid UNIQUEIDENTIFIER NOT NULL,
	username VARCHAR(50) NOT NULL,
	[password] VARCHAR(50) NOT NULL,
	FOREIGN KEY (person_guid) REFERENCES tblPerson(globalUniqueID)
)

GO
CREATE TABLE tblAppointment (
	rowNumber INT IDENTITY (101,1),
	globalUniqueID UNIQUEIDENTIFIER PRIMARY KEY,
	technician_guid UNIQUEIDENTIFIER NULL,
	client_guid UNIQUEIDENTIFIER NOT NULL,
	requestDate DATETIME NOT NULL,
	appointmentDate DATETIME,
	taskType VARCHAR(50) NOT NULL,
	[description] TEXT NOT NULL,
	FOREIGN KEY (client_guid) REFERENCES tblClient(globalUniqueID)
)

GO
CREATE TABLE tblContract (
	rowNumber INT IDENTITY (101,1),
	globalUniqueID UNIQUEIDENTIFIER NOT NULL,
	contractIdentifier VARCHAR(12) PRIMARY KEY,
	cost MONEY NOT NULL,
	paymentType VARCHAR(50) NOT NULL,
	numberPayments INT NOT NULL
)

GO
CREATE TABLE tblClientContract (
	rowNumber INT IDENTITY (101,1),
	globalUniqueID UNIQUEIDENTIFIER PRIMARY KEY,
	issueDate DATETIME NOT NULL,
	numberPaymentsMade INT NOT NULL,
	client_guid UNIQUEIDENTIFIER NOT NULL,
	contractIdentifier VARCHAR(12) NOT NULL,
	FOREIGN KEY (contractIdentifier) REFERENCES tblContract(contractIdentifier),
	FOREIGN KEY (client_guid) REFERENCES tblClient(globalUniqueID)
)

GO
CREATE TABLE tblOptions (
	rowNumber INT IDENTITY (101,1),
	globalUniqueID UNIQUEIDENTIFIER PRIMARY KEY,
	name VARCHAR(50) NOT NULL
)

GO
CREATE TABLE tblConfiguration (
	rowNumber INT IDENTITY (101,1),
	globalUniqueID UNIQUEIDENTIFIER PRIMARY KEY,
	option_guid UNIQUEIDENTIFIER NOT NULL,
	[description] TEXT NOT NULL,
	FOREIGN KEY (option_guid) REFERENCES tblOptions(globalUniqueID)
)

GO
CREATE TABLE tblProducts (
	rowNumber INT IDENTITY (101,1),
	globalUniqueID UNIQUEIDENTIFIER PRIMARY KEY,
	category VARCHAR(50) NOT NULL,
	name VARCHAR(50) NOT NULL,
	manufacturer VARCHAR(50) NOT NULL,
	model VARCHAR(50) NOT NULL,
	serialNumber VARCHAR(50) NOT NULL,
	[description] TEXT NOT NULL
)

GO
CREATE TABLE tblOffer (
	rowNumber INT IDENTITY (101,1),
	globalUniqueID UNIQUEIDENTIFIER PRIMARY KEY,
	category VARCHAR(50) NOT NULL,
	name VARCHAR(50) NOT NULL,
	[description] TEXT NOT NULL,
	discount FLOAT NOT NULL
)

GO
CREATE TABLE tblConfigurationProducts (
	rowNumber INT IDENTITY (101,1),
	configuration_guid UNIQUEIDENTIFIER NOT NULL,
	product_guid UNIQUEIDENTIFIER NOT NULL,
	FOREIGN KEY (configuration_guid) REFERENCES tblConfiguration(globalUniqueID),
	FOREIGN KEY (product_guid) REFERENCES tblProducts(globalUniqueID)
)

GO
CREATE TABLE tblContractOffer(
	rowNumber INT IDENTITY (101,1),
	offer_guid UNIQUEIDENTIFIER NOT NULL,
	contractIdentifier VARCHAR(12) NOT NULL,
	FOREIGN KEY (offer_guid) REFERENCES tblOffer(globalUniqueID),
	FOREIGN KEY (contractIdentifier) REFERENCES tblContract(contractIdentifier)
)

---------------------------------------------------------------------------------------
-- Client Operations
---------------------------------------------------------------------------------------
GO  
CREATE PROCEDURE getAllClients 
AS   
BEGIN
    SELECT C.globalUniqueID AS [CglobalUniqueID], C.clientIdentifier,
		   P.globalUniqueID AS [PglobalUniqueID], P.identificationNumber, P.name, P.surname,
		   A.globalUniqueID AS [AglobalUniqueID], A.city, A.country, A.postalCode, A.street1, A.street2,
		   CD.globalUniqueID AS [CDglobalUniqueID], CD.cellNumber, CD.email, CD.tellNumber 
	FROM tblClient C 
	INNER JOIN tblPerson P ON C.person_guid = P.globalUniqueID
	INNER JOIN tblAddress A ON P.address_guid = A.globalUniqueID
	INNER JOIN tblContactDetails CD ON P.contactDetails_guid = CD.globalUniqueID
END
---------------------------------------------------------------------------------------
GO  
CREATE PROCEDURE insertClient
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

AS   
BEGIN
	BEGIN TRANSACTION
	
		INSERT INTO tblAddress(globalUniqueID, country, city, postalCode, street1, street2)
		VALUES (@AddressGlobalUniqueID, @Country, @City, @PostalCode, @Street1, @Street2)
	
		INSERT INTO tblContactDetails(globalUniqueID, cellNumber, email, tellNumber)
		VALUES (@ContactDetailsGlobalUniqueID, @CellNumber, @Email, @TellNumber)

		INSERT INTO tblPerson(globalUniqueID, address_guid, contactDetails_guid, identificationNumber, name, surname)
		VALUES (@PersonGlobalUniqueID, @AddressGlobalUniqueID, @ContactDetailsGlobalUniqueID, @ID, @Name, @Surname)

		INSERT INTO tblClient(globalUniqueID, clientIdentifier, person_guid)
		VALUES (@ClientGlobalUniqueID, @ClientIdentifier, @PersonGlobalUniqueID)

	COMMIT
END

---------------------------------------------------------------------------------------
-- Appointment Operations
---------------------------------------------------------------------------------------

GO  
CREATE PROCEDURE getAllAppointments 
AS   
BEGIN
    SELECT A.globalUniqueID AS [AglobalUniqueID], A.client_guid, A.[description], A.requestDate, A.appointmentDate, A.taskType, A.technician_guid,
		   CC.contractIdentifier
    FROM tblAppointment A
	INNER JOIN tblClient C ON A.client_guid = C.globalUniqueID
	INNER JOIN tblClientContract CC ON C.globalUniqueID = CC.client_guid
END
---------------------------------------------------------------------------------------
GO  
CREATE PROCEDURE insertAppointment 
	@AppointmentGlobalUniqueID UNIQUEIDENTIFIER,
	@ClientGlobalUniqueID UNIQUEIDENTIFIER,
	@RequestDate DATETIME,
	@TaskType VARCHAR(50)
AS   
BEGIN
    INSERT INTO tblAppointment(globalUniqueID, client_guid, requestDate, taskType, [description])
	VALUES (@AppointmentGlobalUniqueID, @ClientGlobalUniqueID, @RequestDate, @TaskType, 'N/A')
END

---------------------------------------------------------------------------------------
-- Technician Operations
---------------------------------------------------------------------------------------

GO  
CREATE PROCEDURE getAllTechnicians 
AS   
BEGIN
    SELECT T.globalUniqueID AS [TglobalUniqueID], T.hireDate,
		   P.globalUniqueID AS [PglobalUniqueID], P.identificationNumber, P.name, P.surname,
		   A.globalUniqueID AS [AglobalUniqueID], A.city, A.country, A.postalCode, A.street1, A.street2,
		   CD.globalUniqueID AS [CDglobalUniqueID], CD.cellNumber, CD.email, CD.tellNumber
    FROM tblTechnician T
	INNER JOIN tblPerson P ON T.person_guid = P.globalUniqueID
	INNER JOIN tblAddress A ON P.address_guid = A.globalUniqueID
	INNER JOIN tblContactDetails CD ON P.contactDetails_guid = CD.globalUniqueID
END
