using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public abstract class Contract
    {
        #region Fields
        private decimal contractCost;

        private string contractPaymentType;

        private int contractInstallments;

        private Guid contractGuid;
        #endregion

        #region Properties
        public Guid cGuid
        {
            get { return contractGuid; }
            //set { contractGuid = value; }
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
        #endregion

        #region Constructors
        public Contract()
        {

        }

        public Contract(decimal Cost, string PaymentType, int Installments, Guid ContractGuidParam)
        {
            this.cost = Cost;
            this.paymentType = PaymentType;
            this.installments = Installments;
            this.contractGuid = ContractGuidParam;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Contract newObj = obj as Contract;
            if ((object)newObj == null)
            {
                return false;
            }

            return (this.contractGuid == newObj.contractGuid);
        }

        public override int GetHashCode()
        {
            return contractGuid.GetHashCode() ^ installments.GetHashCode() ^ paymentType.GetHashCode() ^ cost.GetHashCode();
        }

        public override string ToString()
        {
            return "installments: "+installments.ToString()+", payment type: "+paymentType+", cost: "+cost.ToString();
        }
        #endregion
    }
}
