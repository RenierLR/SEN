using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class Product
    {
        private string productName;

        private string productCategory;

        private string productDescription;

        private string productManufacturer;

        private string productModel;

        private string productSerialNumber;

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

        public Product(string Name, string Category, string Description, string Manufacturer, string Model, string SerialNumber)
        {
            this.name = Name;
            this.category = Category;
            this.description = Description;
            this.manufacturer = Manufacturer;
            this.model = Model;
            this.serialNumber = SerialNumber;
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

        public void createProduct() { }

        public void deleteProduct() { }

        public void updateProduct() { }
    }
}
