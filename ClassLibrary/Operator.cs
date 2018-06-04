using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class Operator : Person
    {
        #region Fields
        private string operatorUsername;

        private string operatorPassword;
        #endregion

        #region Properties
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
        #endregion

        #region Constructors
        public Operator()
        {

        }

        public Operator(string Name, string Surname, string ID, Address AddressObject, ContactDetails ContactDetailsObject, Guid PersonGuidParam, string Username, string Password) : base(Name, Surname, ID, AddressObject, ContactDetailsObject, PersonGuidParam)
        {
            this.username = Username;
            this.password = Password;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Operator newObj = obj as Operator;
            if ((object)newObj == null)
            {
                return false;
            }

            return ((this.operatorUsername == newObj.operatorUsername) && (this.operatorPassword == newObj.operatorPassword));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ password.GetHashCode() ^ username.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString()+", password: "+password+", username: "+username;
        }
        #endregion

        public void createOperator() { }

        public void deleteOperator() { }

        public void updateOperator() { }
    }
}
