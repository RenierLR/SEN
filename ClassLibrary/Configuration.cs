using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class Configuration
    {
        private Option configurationOption;

        private List<Product> configurationProducts;

        private string configurationDescription;

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

        public Configuration()
        {

        }

        public Configuration(Option OptionParam, List<Product> Products, string Description)
        {
            this.option = OptionParam;
            this.products = Products;
            this.description = Description;
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

        public void createConfiguration() { }

        public void deleteConfiguration() { }

        public void updateConfiguration() { }
    }
}
