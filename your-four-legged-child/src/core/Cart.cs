using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using your_four_legged_child.src.models;

namespace your_four_legged_child.src.core
{
    internal class Cart
    {
        Product product;
        int count;

        public Cart()
        {
        }
        //public Cart(Product _product, int _count)
        //{
        //    this.product = _product;
        //    this.count = _count;
        //}

        public void AddProduct(Product _product) { }

        public void RemoveProduct(string _id) { }

        public void UpdateProduct(string _id, int _quantity) { }
    }
}
