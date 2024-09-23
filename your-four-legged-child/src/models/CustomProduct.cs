using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.models
{
    internal class CustomProduct : Product
    {
        string type;
        public CustomProduct(string _id) : base(_id, "Purina Dog Chow 1kg", 5, "Perro", "Comida para perro de 1kg - razas pequenas", ProductTypes.care) { }

        public override void PrintProduct()
        {
            Console.WriteLine(name);
        }
    }
}
