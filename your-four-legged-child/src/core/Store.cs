using System;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.models;
using your_four_legged_child.src.models.product;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.core
{
    internal partial class Store
    {
        string name;
        Product[] products;
        Product[] cart;

        public Store()
        {
            name = "Tu hijo de 4 Patas";
            products = new Product[4];
            cart = new Product[0];
            GenerateProducts();
        }
        public void GenerateProducts()
        {
            products[0] = new Food("dogfood1kg", "Purina Dog Chow 1kg", 5, "Perro", "Comida para Perro de 1kg", ProductTypes.care);
            products[1] = new Food("catfood1kg", "Purina Cat Chow 1kg", 5, "Gato", "Comida para Gato de 1kg", ProductTypes.care);
            products[2] = new Product("collar", "Collar", 5, "Perro", "Comida para Perro de 1kg", ProductTypes.care);
            products[3] = new Product("zapatos", "Zapato", 5, "Gato", "Comida para Gato de 1kg", ProductTypes.care);
        }



        //Imprime todos los Productos
        public void PrintAllProducts()
        {
            int count = 1;
            foreach (var product in products)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(count + ")");
                Console.ResetColor();
                product.PrintProduct();
                count++;
            }
        }

        // Imprime los productos de una categoria
        public void PrintProductsByCategory(ProductTypes _category)
        {
            int count = 0;
            foreach (var product in products)
            {
                if (product.GetProductType() == _category)
                {
                    count++;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(count + ")");
                    Console.ResetColor();

                    product.PrintProduct();
                }
            }
            if (count == 0)
            {
                string message = "0 productos encontrados";
                Console.WriteLine(message.PadLeft(Console.WindowWidth / 2 + message.Length / 2));
            };
        }

        public int GetProductsLength()
        {
            return products.Length;
        }

        public int GetProductsByCategoryLength(ProductTypes _category)
        {
            int count = 0;
            foreach (var product in products)
            {
                if (product.GetProductType() == _category)
                {
                    count++;
                }
            }
            return count;
        }

        public string[] GetProductsId()
        {
            int length = GetProductsLength();
            string[] ids = new string[length];
            for (int i = 0; i < length; i++)
            {
                ids[i] = products[i].GetId();
            }
            return ids;
        }

        public string[] GetProductsIdByCategory(ProductTypes _category)
        {
            int length = GetProductsByCategoryLength(_category);
            string[] ids = new string[length];

            for (int i = 0; i < length; i++)
            {
                if (products[i].GetProductType() == _category)
                {
                    ids[i] = products[i].GetId();
                }
            }
            return ids;
        }




        // Retorna el numero de elementos en el carrito
        public int getCartCount()
        {
            int count = 0;
            foreach (var cartProduct in cart)
            {
                count += cartProduct.GetCount();
            }
            return count;
        }

    }
}
