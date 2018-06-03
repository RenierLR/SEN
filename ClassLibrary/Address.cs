using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class Address
    {
        private string addressCountry;

        private string addressCity;

        private string addressPostalCode;

        private string addressStreet;

        private string addressStreet2;

        private Guid addressGuid;

        public Guid guid
        {
            get { return addressGuid; }
            set { addressGuid = value; }
        }
   
        public string street2
        {
            get { return addressStreet2; }
            set { addressStreet2 = value; }
        }

        public string street
        {
            get { return addressStreet; }
            set { addressStreet = value; }
        }

        public string postalCode
        {
            get { return addressPostalCode; }
            set { addressPostalCode = value; }
        }

        public string city
        {
            get { return addressCity; }
            set { addressCity = value; }
        }

        public string country
        {
            get { return addressCountry; }
            set { addressCountry = value; }
        }

        public Address()
        {

        }

        public Address(string Country, string City, string PostalCode, string Street, string Street2, Guid guidParam)
        {
            this.country = Country;
            this.city = City;
            this.postalCode = PostalCode;
            this.street = Street;
            this.street2 = Street2;
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
