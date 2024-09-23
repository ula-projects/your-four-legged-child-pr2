using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using your_four_legged_child.src.core;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            int mainState = 1;
            int productMenuState = 1;
            int productSelection = 1;
            int CartMenuState = 1;


            // Program While
            while (mainState != 0)
            {
                Menus.MainMenu(store.getCartCount());

                mainState = UserInput.Option(0, 3);

                switch (mainState)
                {
                    // Menu de Productos
                    case 1:
                        productMenuState = 1;
                        while (productMenuState != 0)
                        {
                            Menus.ProductMenu();
                            productMenuState = UserInput.Option(0, 4);

                            switch (productMenuState)
                            {
                                case 1:
                                    {
                                        productSelection = 1;
                                        string[] idList = store.GetProductsId();
                                        while (productSelection != 0)
                                        {
                                            Menus.ProductHeader("Todos los Productos");
                                            store.PrintAllProducts();
                                            Menus.PrintProductRange(1, store.GetProductsLength());
                                            Console.WriteLine("Selecciona un producto para agregar al carrito\n0) Regresar\n");
                                            productSelection = UserInput.Option(0, store.GetProductsLength());
                                            if (productSelection != 0) store.AddProductToCart(idList[productSelection - 1]);
                                            Console.ReadKey();
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        string[] idList = store.GetProductsId();
                                        while (productSelection != 0)
                                        {
                                            Menus.ProductHeader("Productos de Cuidado");
                                            store.PrintProductsByCategory(ProductTypes.care);
                                            productSelection = 1;
                                            Menus.PrintProductRange(1, store.GetProductsByCategoryLength(ProductTypes.care));
                                            Console.WriteLine("Selecciona un producto para agregar al carrito\n0) Regresar\n");
                                            productSelection = UserInput.Option(0, store.GetProductsByCategoryLength(ProductTypes.care));
                                            if (productSelection != 0) store.AddProductToCart(idList[productSelection - 1]);
                                            Console.ReadKey();
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        Menus.ProductHeader("Servicios Especiales");
                                        store.PrintProductsByCategory(ProductTypes.special);
                                        productSelection = 1;
                                        Menus.PrintProductRange(1, store.GetProductsByCategoryLength(ProductTypes.care));
                                        Console.WriteLine("Selecciona un producto para agregar al carrito\n0) Regresar");
                                        while (productSelection != 0)
                                        {
                                            productSelection = UserInput.Option(0, store.GetProductsByCategoryLength(ProductTypes.special));
                                        }
                                        break;
                                    }
                                case 4:
                                    {
                                        Menus.ProductHeader("Accesorios");
                                        store.PrintProductsByCategory(ProductTypes.accessories);
                                        productSelection = 1;
                                        Menus.PrintProductRange(1, store.GetProductsByCategoryLength(ProductTypes.care));
                                        Console.WriteLine("Selecciona un producto para agregar al carrito\n0) Regresar");
                                        while (productSelection != 0)
                                        {
                                            productSelection = UserInput.Option(0, store.GetProductsByCategoryLength(ProductTypes.accessories));
                                        }
                                        break;
                                    }
                            }

                        }

                        break;

                    // Menu de Carrito
                    case 2:
                        CartMenuState = 1;
                        while (CartMenuState != 0)
                        {
                            Menus.CartMenu();
                            CartMenuState = UserInput.Option(0, 3);

                            switch (CartMenuState)
                            {
                                case 0:
                                    break;
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                            }
                        }
                        break;
                }
            }
        }
    }
}
