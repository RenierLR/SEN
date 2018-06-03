using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public abstract class Contract
    {
        private decimal contractCost;

        private string contractPaymentType;

        private int contractInstallments;

        private Guid contractGuid;

        public Guid cGuid
        {
            get { return contractGuid; }
            set { contractGuid = value; }
        }

        public int installments
        {
            get { return contractInstallments; }
            set { contractInstallments = value; }
        }
        
        public string paymentType
        {
            get { return contractPaymentType; }
            set { contractPaymentType = value; }
        }
        
        public decimal cost
        {
            get { return contractCost; }
            set { contractCost = value; }
        }

        public Contract()
        {

        }

        public Contract(decimal Cost, string PaymentType, int Installments, Guid ContractGuidParam)
        {
            this.cost = Cost;
            this.paymentType = PaymentType;
            this.installments = Installments;
            this.cGuid = ContractGuidParam;
        }
    }
}
