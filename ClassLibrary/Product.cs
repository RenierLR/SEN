using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class Product
    {
        #region Fields
        private string productName;

        private string productCategory;

        private string productDescription;

        private string productManufacturer;

        private string productModel;

        private string productSerialNumber;
        #endregion

        #region Properties
        public string serialNumber
        {
            get { return productSerialNumber; }
            set { productSerialNumber = value; }
        }

        public string model
        {
            get { return productModel; }
            set { productModel = value; }
        }

        public string manufacturer
        {
            get { return productManufacturer; }
            set { productManufacturer = value; }
        }

        public string description
        {
            get { return productDescription; }
            set { productDescription = value; }
        }

        public string category
        {
            get { return productCategory; }
            set { productCategory = value; }
        }

        public string name
        {
            get { return productName; }
            set { productName = value; }
        }
        #endregion

        #region Constructors
        public Product()
        {

        }

        public Product(string Name, string Category, string Description, string Manufacturer, string Model, string SerialNumber)
        {
            this.name = Name;
            this.category = Category;
            this.description = Description;
            this.manufacturer = Manufacturer;
            this.model = Model;
            this.serialNumber = SerialNumber;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Product newObj = obj as Product;
            if ((object)newObj == null)
            {
                return false;
            }

            return ((this.serialNumber == newObj.serialNumber) && (this.model == newObj.model) && (this.manufacturer == newObj.manufacturer) && (this.description == newObj.description) && (this.category == newObj.category) && (this.name == newObj.name));
        }

        public override int GetHashCode()
        {
            return serialNumber.GetHashCode() ^ model.GetHashCode() ^ manufacturer.GetHashCode() ^ description.GetHashCode() ^ category.GetHashCode() ^ name.GetHashCode();
        }

        public override string ToString()
        {
            return "serial number: "+serialNumber+", model: "+model+", manufacturer: "+manufacturer+", description: "+description+", name: "+name;
        }
        #endregion

        public void createProduct() { }

        public void deleteProduct() { }

        public void updateProduct() { }
    }
}
