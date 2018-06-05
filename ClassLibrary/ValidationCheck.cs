using SmartHomeSystemsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ValidationCheck
    {
        private static ValidationCheck instance = new ValidationCheck();

        public static ValidationCheck getInstance()
        {
            return instance;
        }

        ValidationCheck()
        {

        }

        public bool IsValidClientIdentifier(string identifierTest, List<Client> clients)
        {
            if (identifierTest.Length != 9)
            {
                return false;
            }

            if (identifierChar(identifierTest.Substring(0,1)) == false)
            {
                return false;
            }

            if (IsStringInt(identifierTest.Substring(1,7)) == false)
            {
                return false;
            }

            foreach (Client client in clients)
            {
                if (client.identifier == identifierTest)
                {
                    return false;
                }
            }

            return true;
        }

        public bool identifierChar(string firstChar)
        {
            if ((firstChar == "A") || (firstChar == "B") || (firstChar == "C") || (firstChar == "D") || (firstChar == "E"))
            {
                return true;
            }

            return false;
        }

        public bool IsValidEmail(string emailTest, List<Client> clients)
        {
            foreach (Client client in clients)
            {
                if (client.contactDetails.email == emailTest)
                {
                    return false;
                }
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(emailTest);
                return addr.Address == emailTest;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidID(string IDtest, List<Client> clients)
        {
            if (IDtest.Length != 13)
            {
                return false;
            }
            int testValid;
            if (int.TryParse(IDtest.Substring(0,7), out testValid) != true)
            {
                return false;
            }
            if (int.TryParse(IDtest.Substring(7, 6), out testValid) != true)
            {
                return false;
            }
            int year, month, day;
            year = int.Parse(IDtest.Substring(0, 2));
            month = int.Parse(IDtest.Substring(2, 2));
            day = int.Parse(IDtest.Substring(4, 2));
            if ((month <1) || (month >12))
            {
                return false;
            }

            if ((month ==1)||(month==3)||(month==5)||(month==7)||(month==8)||(month==10)||(month==12))
            {
                if ((day < 1) || (day > 31))
                {
                    return false;
                }
            }
            else
            {
                if ((day < 1) || (day > 30))
                {
                    return false;
                }
            }
            
            foreach (Client client in clients)
            {
                if (client.ID == IDtest)
                {
                    return false;
                }
            }

            return true;
            
        }

        public bool IsPopulatedString(string testString)
        {
            if (testString.Length == 0)
            {
                return false;
            }

            return true;
        }

        public bool IsStringInt(string testString)
        {
            int testInt;
            if (int.TryParse(testString, out testInt) == false)
            {
                return false;
            }

            return true;
        }

        public bool IsValidCell(string cellNum)
        {
            if (IsStringInt(cellNum) == false)
            {
                return false;
            }
            if (cellNum.Length != 10)
            {
                return false;
            }
            return true;
        }
    }
}
