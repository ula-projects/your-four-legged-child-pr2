using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.models
{
    internal class Product
    {
        string id;
        string name;
        float price;
        string details;
        string animal;
        ProductTypes type;
        int count;

        // Constructores
        public Product(string _id, string _name, float _price, string _animal, string _details, ProductTypes _type)
        {
            this.id = _id;
            this.name = _name;
            this.price = _price;
            this.animal = _animal;
            this.details = _details;
            this.type = _type;
        }

        // Getters
        public string GetId() => this.id;
        public string GetName() => this.name;
        public string GetAnimal() => this.animal;
        public float GetPrice() => this.price;
        public string GetDetails() => this.details;
        public ProductTypes GetProductType() => this.type;
        public int GetCount() => this.count;
        public float GetTotal() => this.price * this.count;
        //Setters
        public void SetCount(int _count, bool add = false)
        {
            if (_count > 0)
            {
                if (add)
                {
                    this.count += _count;
                }
                else
                {
                    this.count = _count;
                }
            }
        }

        // Methods
        public virtual void PrintProduct()
        {
            string nameText = "Nombre " + name;
            Console.Write(nameText);
            string priceText = "Precio: " + this.price;
            Console.WriteLine(priceText.PadLeft(Console.WindowWidth - nameText.Length - 1));
            Console.WriteLine("Descripccion: " + details);
            Menus.PrintLine();
        }
        public virtual void PrintProductDetails()
        {
            string nameText = "Nombre " + name;
            Console.Write(nameText);
            string priceText = "Precio: " + price;
            Console.WriteLine(priceText.PadLeft(Console.WindowWidth - nameText.Length - 1));
            Console.WriteLine("Descripccion: " + details);
            Console.WriteLine("Animal: " + animal);
            Menus.PrintLine();
        }



        public virtual void Personalize()
        {
            Console.WriteLine("Cuantos Productos deseas llevar?");
            int count = UserInput.Number(1);
            Console.ReadKey();
        }
        public Product Clone()
        {
            return (Product)this.MemberwiseClone();
        }
    }
}
