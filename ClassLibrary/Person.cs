using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public abstract class Person
    {
        private string personName;

        private string personSurname;

        private string personID;
        
        private Address personAddress;

        private ContactDetails personContactDetails;

        private Guid personGuid;

        public Guid pGuid
        {
            get { return personGuid; }
            set { personGuid = value; }
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
            this.pGuid = PersonGuidParam;
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
