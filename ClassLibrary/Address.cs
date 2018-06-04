using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class Address
    {
        #region Fields
        private string addressCountry;

        private string addressCity;

        private string addressPostalCode;

        private string addressStreet;

        private string addressStreet2;

        private Guid addressGuid;
        #endregion

        #region Properties
        public Guid guid
        {
            get { return addressGuid; }
            //set { addressGuid = value; }
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
        #endregion

        #region Constructors
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
            this.addressGuid = guidParam;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Address newObj = obj as Address;
            if ((object)newObj == null)
            {
                return false;
            }

            return (this.addressGuid == newObj.addressGuid);
        }

        public override int GetHashCode()
        {
            return addressGuid.GetHashCode() ^ street.GetHashCode() ^ street2.GetHashCode() ^ postalCode.GetHashCode() ^ city.GetHashCode() ^ country.GetHashCode();
        }

        public override string ToString()
        {
            return "line1: "+street+", line2: "+street2+", postalcode: "+postalCode+", city: "+city+", country: "+country;
        }
        #endregion
    }
}
