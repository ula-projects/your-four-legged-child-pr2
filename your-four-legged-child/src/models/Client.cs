using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using your_four_legged_child.src.core;

namespace your_four_legged_child.src.models
{
    internal class Client : Person
    {

        public Client(string _name, string _lastName, int _idNumber, string _phone, string _residence) : base(_name, _lastName, _idNumber, _phone, _residence)
        {

        }
    }
}
