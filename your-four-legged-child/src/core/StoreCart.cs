using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using your_four_legged_child.src.models;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.core
{
    internal partial class Store
    {
        // Getters

        // Retorna el numero de elementos en el carrito
        public int GetCartLength() => this.cart.Length;

        // Retorna el numero de productos totales en el carrito
        public int GetCartCount()
        {
            int count = 0;
            foreach (var cartProduct in cart)
            {
                count += cartProduct.GetCount();
            }
            return count;
        }

        // Retorna el precio total del carrito sin iva
        public float GetCartTotal()
        {
            float total = 0;
            foreach (var cartProduct in cart)
            {
                total += cartProduct.GetTotal();
            }
            return total;
        }

        // Setters

        // Update One Product
        public void UpdateProduct(int i)
        {
            cart[i].Update();
        }

        // Agrega un nuevo producto al carrito de compras
        public void AddProductToCart(string _id)
        {
            foreach (var product in products)
            {
                if (product.GetId() == _id)
                {
                    Product newProduct = product.Clone();
                    int existsPos = -1;
                    Console.Clear();
                    newProduct.PrintProduct();
                    newProduct.Personalize();

                    for (int i = 0; i < cart.Length; i++)
                    {
                        if (cart[i].GetId() == newProduct.GetId())
                            if (cart[i].Compare(newProduct))
                                existsPos = i;
                    }
                    Console.WriteLine(existsPos);
                    Console.ReadKey();

                    if (existsPos != -1)
                    {
                        cart[existsPos].SetCount(newProduct.GetCount(), true);
                    }
                    else
                    {
                        Array.Resize(ref cart, this.cart.Length + 1);
                        int newPos = this.cart.Length - 1;
                        cart[newPos] = newProduct;
                    }

                }
            }
        }

        // Methods

        // Imprimit Carrito
        public void PrintCart()
        {
            string totalText = "Total: " + GetCartTotal();
            int count = 1;
            foreach (var product in cart)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(count + ")");
                Console.ResetColor();
                product.PrintProductDetails();
                count++;
            }
            Console.WriteLine(totalText.PadLeft(Console.WindowWidth));
            Menus.PrintLine();
        }
    }
}
