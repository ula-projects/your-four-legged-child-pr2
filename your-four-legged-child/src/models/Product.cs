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
        int count;
        ProductTypes type;

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

        // Imprimir datos basicos del producto
        public virtual void PrintProduct()
        {
            string nameText = "Nombre " + this.name;
            string priceText = "Precio: $" + this.price;
            Console.Write(nameText);
            Console.WriteLine(priceText.PadLeft(Console.WindowWidth - nameText.Length - 1));
            Console.WriteLine("Descripccion: " + details);
            Menus.PrintLine();
        }
        // Imprimir todos los datos del producto
        public virtual void PrintProductDetails()
        {
            string countText = "Cantidad: " + this.count;
            PrintProduct();
            Menus.DeleteLastLine();
            Console.WriteLine("Animal: " + animal);
            Console.WriteLine(countText.PadLeft(Console.WindowWidth - countText.Length - 1));
            Menus.PrintLine();
        }
        // Personalizar el producto
        public virtual void Personalize()
        {
            Console.WriteLine("Cuantos Productos deseas llevar?");
            this.count = UserInput.Number(1);
        }

        // Comparar Producto
        public virtual bool Compare(Product _compareTo) => this.id == _compareTo.GetId() ? true : false;

        // Clonar producto
        public Product Clone()
        {
            return (Product)this.MemberwiseClone();
        }
    }
}
