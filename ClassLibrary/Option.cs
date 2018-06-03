using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class Option
    {
        private string optionName;

        private Guid optionGuid;

        public Guid guid
        {
            get { return optionGuid; }
            set { optionGuid = value; }
        }


        public string name
        {
            get { return optionName; }
            set { optionName = value; }
        }

        public Option()
        {

        }

        public Option(string Name, Guid guidParam)
        {
            this.name = Name;
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

        public void createOption() { }

        public void deleteOption() { }

        public void updateOption() { }
    }
}
