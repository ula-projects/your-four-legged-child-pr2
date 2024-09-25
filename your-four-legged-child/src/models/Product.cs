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

        // *****Getters*****

        public string GetId() => this.id;
        public string GetName() => this.name;
        public string GetAnimal() => this.animal;
        public float GetPrice() => this.price;
        public string GetDetails() => this.details;
        public ProductTypes GetProductType() => this.type;
        public int GetCount() => this.count;
        public float GetTotal() => this.price * this.count;

        /// *****Setters*****

        /// <summary>
        /// Definir la cantidad de un mismo producto
        /// </summary>
        /// <param name="_count"></param>
        /// <param name="add"></param>
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

        /// <summary>
        /// Personalizar el producto
        /// </summary>
        public virtual void Personalize()
        {
            Console.WriteLine("Cuantos Productos deseas llevar?");
            this.count = UserInput.Number(1);
        }

        /// <summary>
        /// Actualizar personalizacion del producto
        /// </summary>
        public virtual void Update()
        {

        }

        // *****Methods*****

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_currency"></param>
        /// <param name="_bcv"></param>
        public virtual void PrintProduct()
        {
            string nameText = "Nombre: " + this.name;
            string priceText = "Precio: $" + this.price;
            Console.Write(nameText);
            Console.WriteLine(priceText.PadLeft(Console.WindowWidth - nameText.Length));
            Console.WriteLine("Descripccion: " + details);
            Menus.PrintLine();
        }

        /// <summary>
        /// Imprimir datos basicos del producto
        /// </summary>
        public virtual void PrintProduct(Currency _currency, float _bcv)
        {
            string nameText = "Nombre: " + this.name;
            string priceText = "Precio: " + (_currency == Currency.usd ? "USD " : "BS ") + (_currency == Currency.usd ? this.price : this.price * _bcv);
            Console.Write(nameText);
            Console.WriteLine(priceText.PadLeft(Console.WindowWidth - nameText.Length));
            Console.WriteLine("Descripccion: " + details);
            Menus.PrintLine();
        }

        /// <summary>
        /// Imprimir todos los datos del producto
        /// </summary>
        public virtual void PrintProductDetails()
        {
            PrintProduct();
            Menus.DeleteLastLine();
            Console.WriteLine("Animal: " + animal);
            Menus.PrintRightText("Cantidad: " + this.count);
            Menus.PrintLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_currency"></param>
        /// <param name="bcv"></param>
        public virtual void PrintProductDetails(Currency _currency, float _bcv)
        {
            PrintProduct(_currency, _bcv);
            Menus.DeleteLastLine();
            Console.WriteLine("Animal: " + animal);
            Menus.PrintRightText("Cantidad: " + this.count);
            Menus.PrintLine();
        }

        /// <summary>
        /// Comparar Producto
        /// </summary>
        /// <param name="_compareTo"></param>
        /// <returns></returns>
        public virtual bool Compare(Product _compareTo) => this.id == _compareTo.GetId() ? true : false;

        /// <summary>
        /// Clonar producto
        /// </summary>
        /// <returns></returns>
        public virtual Product Clone()
        {

            return (Product)this.MemberwiseClone();
        }
    }
}
