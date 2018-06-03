using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class Client : Person
    {
        private ClientContract clientContract;

        private string clientIdentifier;

        private Guid clientGuid;

        public Guid clGuid
        {
            get { return clientGuid; }
            set { clientGuid = value; }
        }

        public string identifier
        {
            get { return clientIdentifier; }
            set { clientIdentifier = value; }
        }

        public ClientContract contract
        {
            get { return clientContract; }
            set { clientContract = value; }
        }

        public Client()
        {

        }

        public Client(string Name, string Surname, string ID, Address AddressObject, ContactDetails ContactDetailsObject, Guid PersonGuidParam, ClientContract Contract, string clientIdentifier, Guid ClientGuidParam) :base(Name, Surname, ID, AddressObject, ContactDetailsObject, PersonGuidParam)
        {
            this.contract = Contract;
            this.identifier = identifier;
            this.clGuid = ClientGuidParam;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public List<Client> createAllClients() {
            DataHandler.DataHandler dataAccess = new DataHandler.DataHandler();

            List<Client> clients = new List<Client>();

            string[,] tblAddress = new string[,] { { "globalUniqueID", "guid"}, { "country", "country" }, { "city", "city" }, { "postalCode", "postalCode" }, { "street1", "street1" }, { "street2", "street2" } };
            KeyValuePair<string, string[,]> AddressPair =new KeyValuePair<string, string[,]>("tblAddress",tblAddress);
            DataTable AddressTable = dataAccess.dynamicQueries<Address>("SELECT", null, AddressPair);

            string[,] tblContactDetails = new string[,] { { "globalUniqueID", "guid" }, { "cellNumber", "cellNumber" }, { "tellNumber", "tellNumber" }, { "email", "email" } };
            KeyValuePair<string, string[,]> ContactDetailsPair = new KeyValuePair<string, string[,]>("tblContactDetails", tblContactDetails);
            DataTable ContactDetailsTable = dataAccess.dynamicQueries<Address>("SELECT", null, ContactDetailsPair);

            string[,] tblPerson = new string[,] { { "globalUniqueID", "pGuid" }, { "identificationNumber", "ID" }, { "name", "name" }, { "surname", "surname" } };
            KeyValuePair<string, string[,]> PersonPair = new KeyValuePair<string, string[,]>("tblPerson", tblPerson);
            DataTable PersonTable = dataAccess.dynamicQueries<Address>("SELECT", null, PersonPair);

            string[,] tblClient = new string[,] { { "globalUniqueID", "clGuid" }, { "clientIdentifier", "identifier" } };
            KeyValuePair<string, string[,]> ClientPair = new KeyValuePair<string, string[,]>("tblClient", tblClient);
            DataTable ClientTable = dataAccess.dynamicQueries<Address>("SELECT", null, ClientPair);

            string[,] tblContract = new string[,] { { "globalUniqueID", "cGuid" }, { "cost", "cost" }, { "paymentType", "paymentType" }, { "numberPayments", "installments" } };
            KeyValuePair<string, string[,]> ContractPair = new KeyValuePair<string, string[,]>("tblContract", tblContract);
            DataTable ContractTable = dataAccess.dynamicQueries<Address>("SELECT", null, ContractPair);

            string[,] tblClientContract = new string[,] { { "globalUniqueID", "ccGuid" }, { "contractIdentifier", "identifier" }, { "issueDate", "issueDate" }, { "numberPaymentsMade", "installmentsPayed" } };
            KeyValuePair<string, string[,]> ClientContractPair = new KeyValuePair<string, string[,]>("tblClientContract", tblClientContract);
            DataTable ClientContractTable = dataAccess.dynamicQueries<Address>("SELECT", null, ClientContractPair);

            foreach (DataRow clientRow in ClientTable.Rows)
            {
                Guid clientGuid = (Guid)clientRow["globalUniqueID"];
                Guid personGuid = (Guid)clientRow["person_guid"];
                DataRow[] personRow = PersonTable.Select("globalUniqueID = '"+personGuid.ToString()+"'");
                Guid addressGuid = (Guid)personRow[0]["address_guid"];
                Guid contactGuid = (Guid)personRow[0]["contactDetails_guid"];
                DataRow[] addressRow = AddressTable.Select("globalUniqueID = '" + addressGuid.ToString() + "'");
                DataRow[] contactRow = ContactDetailsTable.Select("globalUniqueID = '" + contactGuid.ToString() + "'");
                DataRow[] clientContractRow = ClientContractTable.Select("globalUniqueID = '" + clientGuid.ToString() + "'");
                Guid contractGuid = (Guid)clientContractRow[0]["contract_guid"];
                DataRow[] contractRow = ContractTable.Select("globalUniqueID = '" + contractGuid.ToString() + "'");
                Address newAddress = new Address((string)addressRow[0]["country"],
                                                 (string)addressRow[0]["city"],
                                                 (string)addressRow[0]["postalCode"],
                                                 (string)addressRow[0]["street1"],
                                                 (string)addressRow[0]["street2"],
                                                 (Guid)addressRow[0]["globalUniqueID"]);
                ContactDetails newContactDetails = new ContactDetails((string)contactRow[0]["email"],
                                                                      (string)contactRow[0]["cellNumber"],
                                                                      (string)contactRow[0]["tellNumber"],
                                                                      (Guid)contactRow[0]["globalUniqueID"]);
                ClientContract newClientContract = new ClientContract((decimal)contractRow[0]["cost"],
                                                                      (string)contractRow[0]["paymentType"],
                                                                      (int)contractRow[0]["numberPayments"],
                                                                      (Guid)contractRow[0]["globalUniqueID"],
                                                                      (string)clientContractRow[0]["contractIdentifier"],
                                                                      (DateTime)clientContractRow[0]["issueDate"],
                                                                      (int)clientContractRow[0]["numberPaymentsMade"],
                                                                      (Guid)clientContractRow[0]["globalUniqueID"]);
                Client newClient = new Client((string)personRow[0]["name"],
                                              (string)personRow[0]["surname"],
                                              (string)personRow[0]["identificationNumber"],
                                              newAddress,
                                              newContactDetails,
                                              (Guid)personRow[0]["globalUniqueID"],
                                              newClientContract,
                                              (string)clientRow["clientIdentifier"],
                                              (Guid)clientRow["globalUniqueID"]);
                clients.Add(newClient);
            }
            return clients;
        }

        public void deleteClient() { }

        public void updateClient() { }
    }
}
