using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class ClientContract : Contract
    {
        private string contractIdentifier;

        private DateTime contractIssueDate;

        private int contractInstallmentsPayed;

        private Guid clientContractGuid;

        public Guid ccGuid
        {
            get { return clientContractGuid; }
            set { clientContractGuid = value; }
        }

        public int installmentsPayed
        {
            get { return contractInstallmentsPayed; }
            set { contractInstallmentsPayed = value; }
        }

        public DateTime issueDate
        {
            get { return contractIssueDate; }
            set { contractIssueDate = value; }
        }

        public string identifier
        {
            get { return contractIdentifier; }
            set { contractIdentifier = value; }
        }

        public ClientContract()
        {

        }

        public ClientContract(decimal Cost, string PaymentType, int Installments, Guid ContractGuidParam, string Identifier, DateTime IssueDate, int InstallmentsPayed, Guid ClientContractGuidParam) : base(Cost, PaymentType, Installments, ContractGuidParam)
        {
            this.identifier = Identifier;
            this.issueDate = IssueDate;
            this.installmentsPayed = InstallmentsPayed;
            this.ccGuid = ClientContractGuidParam;
        }
    }
}
