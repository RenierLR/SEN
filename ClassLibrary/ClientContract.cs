using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class ClientContract : Contract
    {
        #region Fields
        private string contractIdentifier;

        private DateTime contractIssueDate;

        private int contractInstallmentsPayed;

        private Guid clientContractGuid;
        #endregion

        #region Properties
        public Guid ccGuid
        {
            get { return clientContractGuid; }
            //set { clientContractGuid = value; }
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
        #endregion

        #region Constructors
        public ClientContract()
        {

        }

        public ClientContract(decimal Cost, string PaymentType, int Installments, Guid ContractGuidParam, string Identifier, DateTime IssueDate, int InstallmentsPayed, Guid ClientContractGuidParam) : base(Cost, PaymentType, Installments, ContractGuidParam)
        {
            this.identifier = Identifier;
            this.issueDate = IssueDate;
            this.installmentsPayed = InstallmentsPayed;
            this.clientContractGuid = ClientContractGuidParam;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            ClientContract newObj = obj as ClientContract;
            if ((object)newObj == null)
            {
                return false;
            }

            return (this.ccGuid == newObj.ccGuid);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ clientContractGuid.GetHashCode() ^ installmentsPayed.GetHashCode() ^ issueDate.GetHashCode() ^ identifier.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString()+", installments payed: "+installmentsPayed.ToString()+", date issued: "+issueDate.ToString()+", identifier: "+identifier;
        }
        #endregion
    }
}
