using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public abstract class Person
    {
        #region Fields
        private string personName;

        private string personSurname;

        private string personID;
        
        private Address personAddress;

        private ContactDetails personContactDetails;

        private Guid personGuid;
        #endregion

        #region Properties
        public Guid pGuid
        {
            get { return personGuid; }
            //set { personGuid = value; }
        }

        public ContactDetails contactDetails
        {
            get { return personContactDetails; }
            set { personContactDetails = value; }
        }

        public Address address
        {
            get { return personAddress; }
            set { personAddress = value; }
        }

        public string ID
        {
            get { return personID; }
            set { personID = value; }
        }

        public string surname
        {
            get { return personSurname; }
            set { personSurname = value; }
        }

        public string name
        {
            get { return personName; }
            set { personName = value; }
        }
        #endregion

        #region Constructors
        public Person()
        {

        }

        public Person(string Name, string Surname, string ID, Address AddressObject, ContactDetails ContactDetailsObject, Guid PersonGuidParam)
        {
            this.name = Name;
            this.surname = Surname;
            this.ID = ID;
            this.address = AddressObject;
            this.contactDetails = ContactDetailsObject;
            this.personGuid = PersonGuidParam;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Person newObj = obj as Person;
            if ((object)newObj == null)
            {
                return false;
            }

            return (this.pGuid == newObj.pGuid);
        }

        public override int GetHashCode()
        {
            return personGuid.GetHashCode() ^ contactDetails.GetHashCode() ^ address.GetHashCode() ^ ID.GetHashCode() ^ surname.GetHashCode() ^ name.GetHashCode();
        }

        public override string ToString()
        {
            return "name: "+name+", surname: "+surname+", id: "+ID+", address: {"+address.ToString()+"}, contact details: {"+contactDetails.ToString()+"}";
        }
        #endregion
    }
}
