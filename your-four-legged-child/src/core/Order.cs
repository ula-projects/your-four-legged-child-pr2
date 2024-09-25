using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.models;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.core
{
    internal class Order
    {
        Client client;
        Vendor vendor;
        Currency currency;
        PaymentMethod paymentMethod;
        Product[] cart;
        float bcv;

        public Order(Client _client, Vendor _vendor, Currency _currency, PaymentMethod paymentMethod, float _bcv)
        {
            cart = new Product[0];
            this.client = _client;
            this.vendor = _vendor;
            this.currency = _currency;
            this.paymentMethod = paymentMethod;
            this.bcv = _bcv;
        }

        public float GetCartTotal()
        {
            float total = 0;
            foreach (var cartProduct in cart)
            {
                total += cartProduct.GetTotal();
            }
            return total;
        }

        public void AddProductToCart(Product _product)
        {
            Array.Resize(ref cart, cart.Length + 1);
            cart[cart.Length - 1] = _product;
        }

        public void PrintCart()
        {
            string totalText = "SUBTTL: " + (currency == Currency.usd ? "USD " : "BS ") + (currency == Currency.usd ? GetCartTotal() : GetCartTotal() * bcv);
            int count = 1;

            foreach (var product in cart)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(count + ")");
                Console.ResetColor();
                product.PrintProductDetails(currency, bcv);
                count++;
            }
            Menus.PrintRightText(totalText);
            Menus.PrintLine();
        }

        public void PrintBill()
        {
            bool specialTaxpayer = client.GetSpecialTaxpayer();
            string currencyText = (currency == Currency.usd ? "USD " : "BS ");
            float cartTotal = currency == Currency.bolivar ? GetCartTotal() * bcv : GetCartTotal();
            float iva = cartTotal * 0.16f;
            float finalTotal = specialTaxpayer ? cartTotal : cartTotal + iva;

            Menus.PrintHeader("Factura");
            Menus.PrintCenterText("SENIAT");
            Menus.PrintCenterText("Tu hijo de 5 patas - Petshop");
            Menus.PrintCenterText("Tienda Online");
            Console.WriteLine("Cliente: ");
            client.PrintDetails();
            Menus.PrintLine();
            Console.WriteLine("Vendedor: ");
            vendor.PrintDetails();
            Menus.PrintLine();
            Menus.PrintCenterText("Detalles de tu compra");
            Menus.PrintLine();
            PrintCart();
            Menus.PrintRightText("IVA G16.00%: " + currencyText + iva);
            if (currency == Currency.usd)
            {
                float IGTF = finalTotal * 0.03f;
                finalTotal += IGTF;
                Menus.PrintRightText("IGTF 3.00%: " + currencyText + IGTF);
            }
            Menus.PrintRightText("Total a pagar: " + currencyText + finalTotal);
            Menus.PrintLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Menus.PrintLine();
            Menus.PrintCenterText("Gracias por su compra");
            Menus.PrintLine();
        }
    }
}
