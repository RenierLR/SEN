using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class Operator : Person
    {
        private string operatorUsername;

        private string operatorPassword;

        public string password
        {
            get { return operatorPassword; }
            set { operatorPassword = value; }
        }

        public string username
        {
            get { return operatorUsername; }
            set { operatorUsername = value; }
        }

        public Operator()
        {

        }

        public Operator(string Name, string Surname, string ID, Address AddressObject, ContactDetails ContactDetailsObject, Guid PersonGuidParam, string Username, string Password) : base(Name, Surname, ID, AddressObject, ContactDetailsObject, PersonGuidParam)
        {
            this.username = Username;
            this.password = Password;
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

        public void createOperator() { }

        public void deleteOperator() { }

        public void updateOperator() { }
    }
}
