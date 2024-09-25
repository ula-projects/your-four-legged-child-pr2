using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace your_four_legged_child.src.models
{
    internal class Vendor : Person
    {
        int sales;
        public Vendor(string _name, string _lastName, int _idNumber, string _phone, string _residence) : base(_name, _lastName, _idNumber, _phone, _residence)
        {
            this.sales = 0;
        }

        public int GetSales() => this.sales;

        public void SumSales() => this.sales++;
    }
}
