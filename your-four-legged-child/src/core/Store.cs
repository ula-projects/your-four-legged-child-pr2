using System;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.models;
using your_four_legged_child.src.models.care;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.core
{
    /*
    TDA TIENDA
    
    - Descripción: Clase _principal_ que se encarga de manejar productos, las ordenes, los vendedores, los clientes y las ventas

    - Compuesta por:
    Producto
    Cliente
    Vendedor
    Orden

    - Propiedades
    Flotante                bcv
    Array de Productos      productos //Productos disponibles en la tienda
    Array de Productos      carrito //"Carrito" con las cosas que esta comprando la persona
    Array de Clientes       clientes //Clientes registrados
    Array de Vendedores     vendedores //Vendedores registrados
    Array de Ordenes        oredenes //Las ventas realizadas

    - Métodos
                            Store(flotante DolarBCV) //Instancia todos los datos internos, y hay que pasarle el precio del dolar
    Vacío                   GenerarVendedores() //Instanciar todos lo vendedores predeterminados
    Vendedor                GetVendedor(entero pos) //pos es la posicion en el array
    Vacío                   ImprimirVendedores()
    Vacío                   AggNuevoVendedor(Vendedor v)
    Cliente                 GetCliente(entero ID)
    Vacío                   AggNuevoCliente(Cliente c)
    Vacío                   ImprimirDetallesDeLaOrden(Cliente c, Moneda moneda)
    Vacío                   Pagar(Orden x)
     */


    internal partial class Store
    {
        float bcv;
        Product[] products;
        Product[] cart;
        Client[] clients;
        Vendor[] vendors;
        Order[] orders;

        public Store(float _bcv)
        {
            products = new Product[15];
            cart = new Product[0];
            clients = new Client[0];
            vendors = new Vendor[3];
            orders = new Order[0];
            GenerateProducts();
            GenerateVendors();
            bcv = _bcv;
        }

        void GenerateVendors()
        {
            vendors[0] = new Vendor("Nerio", "Balza", 27777348, "0424-7319042", "Santa Juana, Merida");
            vendors[1] = new Vendor("Liber", "Avendano", 12345679, "0424-7319042", "Centro, Merida");
            vendors[2] = new Vendor("Edwer", "Soret", 12345678, "0424-7319042", "Tovar, Merida");
        }

        /// <summary>
        /// Retorna un vendedor seleccionado
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Vendor GetVendor(int i) => vendors[i];

        /// <summary>
        /// Retorna la cantidad de vendedores disponibles
        /// </summary>
        /// <returns></returns>
        public int GetVendorCount() => vendors.Length;


        /// <summary>
        /// Imprime todos los vendedores
        /// </summary>
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

        /// <summary>
        /// Recibe un nuevo vendedor y lo agrega a la lista de vendedores de la tienda
        /// </summary>
        /// <param name="_vendor"></param>
        public void AddNewVendor(Vendor _vendor)
        {
            Array.Resize(ref vendors, vendors.Length + 1);
            vendors[vendors.Length - 1] = _vendor;
        }

        /// <summary>
        /// Retorna el cliente que coincida con el mismo numero de cedula
        /// </summary>
        /// <param name="_idNumber"></param>
        /// <returns></returns>
        public Client GetClient(int _idNumber)
        {
            foreach (var client in clients)
            {
                if (client.GetIdNumber() == _idNumber) return client;
            }
            return null;
        }

        /// <summary>
        /// Recibe un cliente y lo agrega a la lista de clientes de la tienda
        /// </summary>
        /// <param name="_client"></param>
        public void AddNewClient(Client _client)
        {
            Array.Resize(ref clients, clients.Length + 1);
            clients[clients.Length - 1] = _client;
        }

        /// <summary>
        /// Imprime los datoa de compra antes de pagar
        /// </summary>
        /// <param name="_client"></param>
        /// <param name="_currency"></param>
        public void PrintOrderDetails(Client _client, Currency _currency)
        {
            bool specialTaxpayer = _client.GetSpecialTaxpayer();
            string currencyText = (_currency == Currency.usd ? "USD " : "BS ");
            float cartTotal = _currency == Currency.bolivar ? GetCartTotal() * bcv : GetCartTotal();
            float iva = cartTotal * 0.16f;
            float finalTotal = specialTaxpayer ? cartTotal : cartTotal + iva;
            Menus.PrintHeader("Check Out");
            Menus.PrintCenterText("Detalles de tu compra");
            Menus.PrintLine();
            PrintCart(_currency);
            //Menus.PrintRightText("IVA G16.00%: " + currencyText + iva);
            //if (_currency == Currency.usd)
            //{
            //    float IGTF = finalTotal * 0.03f;
            //    finalTotal += IGTF;
            //    Menus.PrintRightText("IGTF 3.00%: " + currencyText + IGTF);
            //}
            //Menus.PrintRightText("Total a pagar: " + currencyText + finalTotal);
            //Menus.PrintLine();
        }

        /// <summary>
        /// Se realiza una compra
        /// </summary>
        /// <param name="_order"></param>
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
