using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class Option
    {
        #region Fields
        private string optionName;

        private Guid optionGuid;
        #endregion

        #region Properties
        public Guid guid
        {
            get { return optionGuid; }
            //set { optionGuid = value; }
        }
        
        public string name
        {
            get { return optionName; }
            set { optionName = value; }
        }
        #endregion

        #region Constructors
        public Option()
        {

        }

        public Option(string Name, Guid guidParam)
        {
            this.name = Name;
            this.optionGuid = guidParam;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Option newObj = obj as Option;
            if ((object)newObj == null)
            {
                return false;
            }

            return (this.optionGuid == newObj.optionGuid);
        }

        public override int GetHashCode()
        {
            return optionGuid.GetHashCode() ^ name.GetHashCode();
        }

        public override string ToString()
        {
            return "name: "+name;
        }
        #endregion

        public void createOption() { }

        public void deleteOption() { }

        public void updateOption() { }
    }
}
