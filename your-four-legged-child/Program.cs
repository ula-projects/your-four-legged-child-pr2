using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using your_four_legged_child.src.core;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.models;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float bcv = 36.55f;
            Store store = new Store(bcv);
            int mainState = 1;

            // Program While
            while (mainState != 0)
            {
                int cartLength = store.GetCartLength();
                Menus.MainMenu(store.GetCartCount());
                if (cartLength > 0)
                {
                    mainState = UserInput.Option(0, 3);
                }
                else
                {
                    mainState = UserInput.Option(0, 2);
                }

                switch (mainState)
                {
                    // Menu de Productos
                    case 1:
                        {
                            int productMenuState = 1;
                            while (productMenuState != 0)
                            {
                                Menus.ProductMenu();
                                productMenuState = UserInput.Option(0, 4);

                                switch (productMenuState)
                                {
                                    case 1:
                                        {
                                            int productSelection = 1;
                                            string[] idList = store.GetProductsId();

                                            while (productSelection != 0)
                                            {
                                                Menus.PrintHeader("Todos los Productos");
                                                store.PrintAllProducts();
                                                Menus.PrintProductRange(1, store.GetProductsLength());
                                                Console.WriteLine("Selecciona un producto para agregar al carrito\n0) Regresar\n");
                                                productSelection = UserInput.Option(0, store.GetProductsLength());
                                                if (productSelection != 0) store.AddProductToCart(idList[productSelection - 1]);
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            int productSelection = 1;
                                            string[] idList = store.GetProductsIdByCategory(ProductTypes.care);
                                            int length = store.GetProductsByCategoryLength(ProductTypes.special);

                                            while (productSelection != 0)
                                            {
                                                Menus.PrintHeader("Productos de Cuidado");
                                                store.PrintProductsByCategory(ProductTypes.care);
                                                if (length > 0)
                                                {
                                                    Menus.PrintProductRange(1, store.GetProductsByCategoryLength(ProductTypes.special));
                                                    Console.WriteLine("Selecciona un producto para agregar al carrito");
                                                }
                                                Console.WriteLine("0) Regresar");
                                                productSelection = UserInput.Option(0, store.GetProductsByCategoryLength(ProductTypes.care));
                                                if (productSelection != 0) store.AddProductToCart(idList[productSelection - 1]);
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            int productSelection = 1;
                                            string[] idList = store.GetProductsIdByCategory(ProductTypes.special);
                                            int length = store.GetProductsByCategoryLength(ProductTypes.special);

                                            while (productSelection != 0)
                                            {
                                                Menus.PrintHeader("Servicios Especiales");
                                                store.PrintProductsByCategory(ProductTypes.special);
                                                if (length > 0)
                                                {
                                                    Menus.PrintProductRange(1, store.GetProductsByCategoryLength(ProductTypes.special));
                                                    Console.WriteLine("Selecciona un producto para agregar al carrito");
                                                }
                                                Console.WriteLine("0) Regresar");
                                                productSelection = UserInput.Option(0, store.GetProductsByCategoryLength(ProductTypes.special));
                                                if (productSelection != 0) store.AddProductToCart(idList[productSelection - 1]);
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            int productSelection = 1;
                                            string[] idList = store.GetProductsIdByCategory(ProductTypes.accessories);
                                            int length = store.GetProductsByCategoryLength(ProductTypes.accessories);

                                            while (productSelection != 0)
                                            {
                                                Menus.PrintHeader("Accesorios");
                                                store.PrintProductsByCategory(ProductTypes.accessories);
                                                if (length > 0)
                                                {
                                                    Menus.PrintProductRange(1, store.GetProductsByCategoryLength(ProductTypes.accessories));
                                                    Console.WriteLine("Selecciona un producto para agregar al carrito");
                                                }
                                                Console.WriteLine("0) Regresar");
                                                productSelection = UserInput.Option(0, store.GetProductsByCategoryLength(ProductTypes.accessories));
                                                if (productSelection != 0) store.AddProductToCart(idList[productSelection - 1]);
                                            }
                                            break;
                                        }
                                }

                            }

                            break;
                        }

                    // Menu de Carrito
                    case 2:
                        {
                            int CartMenuState = 1;

                            while (CartMenuState != 0)
                            {
                                int length = store.GetCartLength();
                                Menus.PrintHeader("Carrito");
                                store.PrintCart();
                                if (length > 0)
                                {
                                    Menus.PrintProductRange(1, length);
                                    Console.WriteLine("Selecciona un producto para ver mas opciones");
                                }
                                Console.WriteLine("0) Regresar");
                                CartMenuState = UserInput.Option(0, length);
                                if (CartMenuState != 0)
                                    store.UpdateProduct(CartMenuState - 1);
                            }
                            break;
                        }
                    case 3:
                        {
                            Menus.PrintHeader("Check Out");
                            Client client = null;
                            Vendor vendor = null;
                            Currency currency = Currency.bolivar;
                            PaymentMethod paymentMethod = PaymentMethod.card;

                            while (client == null)
                            {
                                Console.WriteLine("Introduce la cedula del cliente");
                                int clientID = UserInput.Number(1);
                                client = store.GetClient(clientID);
                                if (client == null)
                                {
                                    Menus.DeleteLastLine(2);
                                    Console.WriteLine("Cliente no existe\n1) Crear Cliente\n0) Introducir cedula\n");
                                    int option = UserInput.Option(0, 1);

                                    if (option == 1)
                                    {
                                        Menus.DeleteLastLine(5);
                                        string name;
                                        string lastName;
                                        string phoneNumber;
                                        string residence;
                                        bool specialTaxpayer;

                                        Console.WriteLine("Nombre: ");
                                        name = UserInput.String();
                                        Console.WriteLine("Apellido: ");
                                        lastName = UserInput.String();
                                        Console.WriteLine("Numero de telefono: ");
                                        phoneNumber = UserInput.String();
                                        Console.WriteLine("Residencia: ");
                                        residence = UserInput.String();
                                        Console.WriteLine("Contribuyente especial:\n1) si\n2) no");
                                        specialTaxpayer = UserInput.Bool(1, 2);
                                        client = new Client(name, lastName, clientID, phoneNumber, residence, specialTaxpayer);
                                        store.AddNewClient(client);
                                        Menus.DeleteLastLine(12);
                                    }
                                    else
                                    {
                                        Menus.DeleteLastLine(5);
                                    }
                                }
                            }
                            client.PrintDetails();
                            Console.ReadKey();

                            Menus.PrintHeader("Check Out");
                            store.PrintVendors();
                            Console.WriteLine("Selecciona un vendedor:");
                            int vendorPos = UserInput.Option(1, 3);
                            vendor = store.GetVendor(vendorPos - 1);

                            Menus.PrintHeader("Check Out");
                            vendor.PrintDetails();
                            Console.ReadKey();

                            Menus.PrintHeader("Check Out");
                            Console.WriteLine("\nSelecciona la moneda de pago\n1) Bolivares\n2) Dolares");
                            int currencySelected = UserInput.Option(1, 2);

                            switch (currencySelected)
                            {
                                case 1:
                                    currency = Currency.bolivar;
                                    break;
                                case 2:
                                    currency = Currency.usd;
                                    break;
                            }

                            Menus.PrintHeader("Check Out");
                            Console.WriteLine("\nSelecciona la moneda de pago\n1) Efectivo\n2) Tarjeta");
                            int paymentSelected = UserInput.Option(1, 2);

                            switch (currencySelected)
                            {
                                case 1:
                                    paymentMethod = PaymentMethod.cash;
                                    break;
                                case 2:
                                    paymentMethod = PaymentMethod.card;
                                    break;
                            }

                            Order order = new Order(client, vendor, currency, paymentMethod, bcv);

                            store.PrintOrderDetails(client, currency);

                            Console.WriteLine("1) Pagar\n2) Cancelar\n");
                            int finalOption = UserInput.Option(1, 2);

                            if (finalOption == 1)
                            {
                                store.Payment(order);
                            }


                            Console.ReadKey();
                            break;
                        }
                }
            }
        }
    }
}
