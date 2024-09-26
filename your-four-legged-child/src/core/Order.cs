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
	/*
    TDA ORDEN

    - Propiedades:
    Cliente             cliente
    Vendedor            vendedor
    Moneda              moneda
    MétodoDePago        pago
    Array de Productos  carrito
    Flotante            dolarBCV
    Entero              ID
    Fecha               fecha

    -Métodos
                Orden(Cliente, Vendedor, Moneda, MetodoDePago, flotante dolarBCV, entero ID)
    Vacío       FijarFecha()
    Flotante    CalcularTotalDelCarrito()
    Vacío       AggProductoAlCarrito(Producto)
    Vacío       ImprimirCarrito()
    Vacío       ImprimirFactura()

     */
	internal class Order
    {
        Client client;
        Vendor vendor;
        Currency currency;
        PaymentMethod paymentMethod;
        Product[] cart;
        float bcv;
        int id;
        DateTime date;

        public Order(Client _client, Vendor _vendor, Currency _currency, PaymentMethod paymentMethod, float _bcv, int _id)
        {
            cart = new Product[0];
            this.client = _client;
            this.vendor = _vendor;
            this.currency = _currency;
            this.paymentMethod = paymentMethod;
            this.bcv = _bcv;
            this.id = _id;
            date = DateTime.Now;
        }

        public void SetTime()
        {
            date = DateTime.Now;
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
            foreach (var product in cart)
            {
                product.PrintToBill(currency, bcv);
            }

        }

        public void PrintBill()
        {
            bool specialTaxpayer = client.GetSpecialTaxpayer();
            float cartTotal = GetCartTotal() * bcv;
            float biG = cartTotal * 0.16f;
            float ivaG = biG * 0.16f;
            float finalTotal = specialTaxpayer ? cartTotal : cartTotal + ivaG + biG;

            Menus.PrintHeader("Factura");
            Menus.PrintCenterText("SENIAT");
            Menus.PrintCenterText("RIF J-145847563");
            Menus.PrintCenterText("TU HIJO DE 4 PATAS C.A.");
            Menus.PrintCenterText("AV 5 ZERPA, ENTRE CALLE 19-18");
            Menus.PrintCenterText("LOCAL 4-85 NRO PB SECTOR CENTRO");
            Menus.PrintCenterText("MERIDA MERIDA ZONAPOSTAL 5101");
            Menus.PrintLine();
            Console.WriteLine("RIF/C.I: " + client.GetIdNumber());
            Console.WriteLine("Razon Social: " + client.GetFullName());
            Console.WriteLine("Direccion: " + client.GetResidence());
            Console.WriteLine("Telefono: " + client.GetPhoneNumber());
            Menus.PrintCenterText("FACTURA");
            Menus.PrintLeftRightText("Factura:", id.ToString());
            Menus.PrintLeftRightText("Fecha:", date.ToString());
            Menus.PrintLine();
            PrintCart();
            Menus.PrintLine();
            Menus.PrintLeftRightText("SUBTIL:", ("Bs " + cartTotal));
            Menus.PrintLeftRightText("EXENTO:", "Bs 0.00");
            Menus.PrintLeftRightText("BI G(16.00%)", biG.ToString());
            Menus.PrintLeftRightText("IVA G (16.00%)", ivaG.ToString());
            Menus.PrintLine();

            if (currency == Currency.usd)
            {
                float BIIGTF = finalTotal * 0.03f;
                float IGTF = BIIGTF * 0.3f;
                finalTotal += BIIGTF;
                finalTotal += IGTF;
                Menus.PrintLeftRightText("BI IGTF (3.00%): ", ("Bs " + BIIGTF));
                Menus.PrintLeftRightText("IGTF (3.00%): ", ("Bs " + IGTF));
                Menus.PrintLine();
            }
            if (paymentMethod == PaymentMethod.card)
            {
                Menus.PrintLeftRightText("T.DEBITO", "Bs" + finalTotal);
            }
            else
            {
                Menus.PrintLeftRightText("EFECTIVO", "Bs" + finalTotal);
            }
            Menus.PrintLine();
            Menus.PrintLeftRightText("TOTAL: ", "Bs " + finalTotal);
            Menus.PrintLine();
            Menus.PrintCenterText("Emitido por: 'TU HIJO DE 4 PATAS C.A.'");

            Console.ForegroundColor = ConsoleColor.Green;
            Menus.PrintLine();
            Menus.PrintCenterText("Gracias por su compra");
            Menus.PrintLine();
        }
    }
}
