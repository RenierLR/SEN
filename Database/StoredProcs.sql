USE SHSDatabase;

---------------------------------------------------------------------------------------
--Client Operations
---------------------------------------------------------------------------------------
GO  
CREATE PROCEDURE getAllClients 
AS   
BEGIN
    SELECT C.globalUniqueID, C.clientIdentifier,
		   P.globalUniqueID, P.identificationNumber, P.name, P.surname,
		   A.globalUniqueID, A.city, A.country, A.postalCode, A.street1, A.street2,
		   CD.globalUniqueID, CD.cellNumber, CD.email, CD.tellNumber, 
		   CO.globalUniqueID, CO.numberPayments, CO.paymentType, 
		   CC.globalUniqueID, CC.contractIdentifier, CC.issueDate, CC.numberPaymentsMade
    FROM tblClient C 
	INNER JOIN tblPerson P ON C.person_guid = P.globalUniqueID
	INNER JOIN tblAddress A ON P.address_guid = A.globalUniqueID
	INNER JOIN tblContactDetails CD ON P.contactDetails_guid = CD.globalUniqueID
	INNER JOIN tblClientContract CC ON C.globalUniqueID = CC.client_guid
	INNER JOIN tblContract CO ON CC.contract_guid = CO.globalUniqueID
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
	@TellNumber VARCHAR(10), 
	@ContractGlobalUniqueID UNIQUEIDENTIFIER, 
	@ClientContractGlobalUniqueID UNIQUEIDENTIFIER, 
	@ContractIdentifier VARCHAR(12), 
	@IssueDate DATE, 
	@NumberPaymentsMade INT

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

	INSERT INTO tblClientContract(globalUniqueID, contractIdentifier, issueDate, numberPaymentsMade, client_guid, contract_guid)
	VALUES (@ClientContractGlobalUniqueID, @ContractIdentifier, @IssueDate, @NumberPaymentsMade, @ClientGlobalUniqueID, @ContractGlobalUniqueID)
END
---------------------------------------------------------------------------------------