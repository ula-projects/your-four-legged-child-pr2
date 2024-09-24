using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using your_four_legged_child.src.core;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            int mainState = 1;

            // Program While
            while (mainState != 0)
            {
                Menus.MainMenu(store.GetCartCount());

                mainState = UserInput.Option(0, 3);

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
                }
            }
        }
    }
}
