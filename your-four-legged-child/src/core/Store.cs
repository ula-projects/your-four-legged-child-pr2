using System;
using your_four_legged_child.src.models;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.core
{
    internal class Store
    {
        // Store Name
        string name;
        // Inventory
        Product[] products;
        // Cart
        Product[] Cart;

        public Store()
        {
            name = "Tu hijo de 4 Patas";
            products = new Product[12];
            GenerateProducts();
        }
        public void GenerateProducts()
        {
            products[0] = new Product("pdc1kg", "Purina Dog Chow 1kg", 5, "Perro", "Comida para perro de 1kg - razas pequenas", ProductTypes.care);
            products[1] = new Product("pdc2kg", "Purina Dog Chow 2kg", 10, "Perro", "Comida para perro de 2kg - razas medianas", ProductTypes.care);
            products[2] = new Product("pdc5kg", "Purina Dog Chow 5kg", 15, "Perro", "Comida para perro de 5kg - razas grandes", ProductTypes.care);
            products[3] = new Product("pdc1kg", "Purina Dog Chow 1kg", 5, "Perro", "Comida para perro de 1kg - razas pequenas", ProductTypes.special);
            products[4] = new Product("pdc2kg", "Purina Dog Chow 2kg", 10, "Perro", "Comida para perro de 2kg - razas medianas", ProductTypes.special);
            products[5] = new Product("pdc5kg", "Purina Dog Chow 5kg", 15, "Perro", "Comida para perro de 5kg - razas grandes", ProductTypes.special);
            products[6] = new Product("pdc1kg", "Purina Dog Chow 1kg", 5, "Perro", "Comida para perro de 1kg - razas pequenas", ProductTypes.special);
            products[7] = new Product("pdc2kg", "Purina Dog Chow 2kg", 10, "Perro", "Comida para perro de 2kg - razas medianas", ProductTypes.special);
            products[8] = new Product("pdc5kg", "Purina Dog Chow 5kg", 15, "Perro", "Comida para perro de 5kg - razas grandes", ProductTypes.special);
            products[9] = new Product("pdc1kg", "Purina Dog Chow 1kg", 5, "Perro", "Comida para perro de 1kg - razas pequenas", ProductTypes.special);
            products[10] = new Product("pdc2kg", "Purina Dog Chow 2kg", 10, "Perro", "Comida para perro de 2kg - razas medianas", ProductTypes.special);
            products[11] = new Product("pdc5kg", "Purina Dog Chow 5kg", 15, "Perro", "Comida para perro de 5kg - razas grandes", ProductTypes.special);
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


        // Agrega un nuevo producto al carrito de compras
        public void AddProductToCart(string _id)
        {
            Console.WriteLine(_id);
        }

        // Retorna el numero de elementos en el carrito
        public int getCartCount()
        {
            return 0;
        }
    }
}
