using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class ContactDetails
    {
        #region Fields
        private string contactEmail;

        private string contactCellNumber;

        private string contactTellNumber;

        private Guid contactGuid;
        #endregion

        #region Properties
        public Guid guid
        {
            get { return contactGuid; }
            //set { contactGuid = value; }
        }

        public string tellNumber
        {
            get { return contactTellNumber; }
            set { contactTellNumber = (value == null) || (value == string.Empty) ? "N/A" : value; }
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
        #endregion

        #region Constructors
        public ContactDetails()
        {

        }

        public ContactDetails(string Email, string CellNumber, string TellNumber, Guid guidParam)
        {
            this.email = Email;
            this.cellNumber = CellNumber;
            this.tellNumber = TellNumber;
            this.contactGuid = guidParam;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }

            ContactDetails newObj = obj as ContactDetails;
            if ((object)newObj == null)
            {
                return false;
            }

            return (this.guid == newObj.guid);
        }

        public override int GetHashCode()
        {
            return contactGuid.GetHashCode() ^ tellNumber.GetHashCode() ^ cellNumber.GetHashCode() ^ email.GetHashCode();
        }

        public override string ToString()
        {
            return "tellnumber: "+tellNumber+", cellnumber: "+cellNumber+", email: "+email;
        }
        #endregion
    }
}
