using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace your_four_legged_child.src.core
{
    internal partial class Store
    {
        // Imprimit Carrito
        public void PrintCart()
        {
            int count = 1;
            foreach (var product in cart)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(count + ")");
                Console.ResetColor();
                product.PrintProductDetails();
                count++;
            }
        }
    }
}
