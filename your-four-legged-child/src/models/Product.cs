using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.models
{
    internal class Product
    {
        protected string id;
        protected string name;
        string animal;
        float price;
        string details;
        string[] sizeOpts;
        string size;
        ProductTypes type;

        public Product(string _id, string _name, float _price, string _animal, string _details, ProductTypes _type)
        {
            this.id = _id;
            this.name = _name;
            this.price = _price;
            this.animal = _animal;
            this.details = _details;
            this.type = _type;
        }

        public virtual void PrintProduct()
        {
            string nameText = "Nombre " + name;
            Console.Write(nameText);
            string priceText = "Precio: " + this.price;
            Console.WriteLine(priceText.PadLeft(Console.WindowWidth - nameText.Length - 1));
            Console.WriteLine("Descripccion: " + details);
            Menus.PrintLine();
        }

        public ProductTypes GetProductType()
        {
            return this.type;
        }

        public string GetId() => this.id;
    }
}
