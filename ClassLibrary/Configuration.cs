using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class Configuration
    {
        #region Fields
        private Option configurationOption;

        private List<Product> configurationProducts;

        private string configurationDescription;
        #endregion

        #region Properties
        public string description
        {
            get { return configurationDescription; }
            set { configurationDescription = value; }
        }

        public List<Product> products
        {
            get { return configurationProducts; }
            set { configurationProducts = value; }
        }

        public Option option
        {
            get { return configurationOption; }
            set { configurationOption = value; }
        }
        #endregion

        #region Constructors
        public Configuration()
        {

        }

        public Configuration(Option OptionParam, List<Product> Products, string Description)
        {
            this.option = OptionParam;
            this.products = Products;
            this.description = Description;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Configuration newObj = obj as Configuration;
            if ((object)newObj == null)
            {
                return false;
            }

            return ((this.configurationOption == newObj.configurationOption) && (this.configurationProducts == newObj.configurationProducts) && (this.configurationDescription == newObj.configurationDescription));
        }

        public override int GetHashCode()
        {
            return description.GetHashCode() ^ products.GetHashCode() ^ option.GetHashCode();
        }

        public override string ToString()
        {
            return "option: {"+option.ToString()+"}, description: "+description;
        }
        #endregion

        public void createConfiguration() { }

        public void deleteConfiguration() { }

        public void updateConfiguration() { }
    }
}
