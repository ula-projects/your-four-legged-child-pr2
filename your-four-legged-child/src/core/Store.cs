using System;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.models;
using your_four_legged_child.src.models.care;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.core
{
    internal partial class Store
    {
        float bcv;
        Product[] products;
        Product[] cart;
        Client[] clients;
        //Person currentClient;
        Vendor[] vendors;
        //Person[] currentVendor;
        Order[] orders;

        public Store(float _bcv)
        {
            products = new Product[5];
            cart = new Product[0];
            clients = new Client[0];
            vendors = new Vendor[3];
            orders = new Order[0];
            GenerateProducts();
            GenerateVendors();
            bcv = _bcv;
        }

        public void GenerateVendors()
        {
            vendors[0] = new Vendor("Nerio", "Balza", 27777348, "0424-7319042", "Santa Juana, Merida");
            vendors[1] = new Vendor("Liber", "Avendano", 12345679, "0424-7319042", "Centro, Merida");
            vendors[2] = new Vendor("Edwer", "Soret", 12345678, "0424-7319042", "Tovar, Merida");
        }

        public Vendor GetVendor(int i) => vendors[i];


        public void PrintVendors()
        {
            for (int i = 0; i < vendors.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(i + 1 + ")");
                Console.ResetColor();
                vendors[i].PrintDetails();
            }
        }
        public Client GetClient(int _idNumber)
        {
            foreach (var client in clients)
            {
                if (client.GetIdNumber() == _idNumber) return client;
            }
            return null;
        }

        public void AddNewClient(Client _client)
        {
            Array.Resize(ref clients, clients.Length + 1);
            clients[clients.Length - 1] = _client;
        }



        public void PrintOrderDetails(Client _client, Currency _currency)
        {
            bool specialTaxpayer = _client.GetSpecialTaxpayer();
            float cartTotal = _currency == Currency.bolivar ? GetCartTotal() * bcv : GetCartTotal();
            float iva = cartTotal * 0.16f;
            float finalTotal = specialTaxpayer ? cartTotal : cartTotal + iva;
            string icon = _currency == Currency.usd ? "$" : "bs";
            Menus.PrintHeader("Check Out");
            Menus.PrintCenterText("Detalles de tu compra");
            Menus.PrintLine();
            PrintCart();
            Menus.PrintRightText("I.V.A: " + iva);
            Menus.PrintRightText("Total a pagar: " + icon + finalTotal);
            Menus.PrintLine();
        }

        public void Payment(Order _order)
        {
            foreach (var product in cart)
            {
                _order.AddProductToCart(product);
            }
            Array.Resize(ref cart, 0);
            Array.Resize(ref orders, orders.Length + 1);
            orders[orders.Length - 1] = _order;
            _order.PrintBill();

        }

    }
}
