using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class ContactDetails
    {
        private string contactEmail;

        private string contactCellNumber;

        private string contactTellNumber;

        private Guid contactGuid;

        public Guid guid
        {
            get { return contactGuid; }
            set { contactGuid = value; }
        }

        public string tellNumber
        {
            get { return contactTellNumber; }
            set { contactTellNumber = value; }
        }

        public string cellNumber
        {
            get { return contactCellNumber; }
            set { contactCellNumber = value; }
        }

        public string email
        {
            get { return contactEmail; }
            set { contactEmail = value; }
        }

        public ContactDetails()
        {

        }

        public ContactDetails(string Email, string CellNumber, string TellNumber, Guid guidParam)
        {
            this.email = Email;
            this.cellNumber = CellNumber;
            this.tellNumber = TellNumber;
            this.guid = guidParam;
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
    }
}
