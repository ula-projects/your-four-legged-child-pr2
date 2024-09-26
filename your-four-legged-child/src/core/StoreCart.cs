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
    TDA STORE (continuación)

    - Métodos
    Vacío   ActualizarProductoCArrito(entero pos) // pos es la posicion del producto en el carrito
    Vacío   AggProductoAlCarrito(C. de caracteres ID)
    Vacío   BorrarProductoDelCarrito(entero pos)
    Vacío   ImprimirCarrito()
    Vacío   ImprimirCarrito(Moneda moneda) // Puede imprimir en $ o Bs
     */


    internal partial class Store
    {

        /// <summary>
        /// Retorna el numero de elementos en el carrito
        /// </summary>
        /// <returns></returns>
        public int GetCartLength() => this.cart.Length;

        /// <summary>
        /// Retorna el numero de productos totales en el carrito
        /// </summary>
        /// <returns></returns>
        public int GetCartCount()
        {
            int count = 0;
            foreach (var cartProduct in cart)
            {
                count += cartProduct.GetCount();
            }
            return count;
        }

        /// <summary>
        /// Calcula el precio total del carrito
        /// </summary>
        /// <returns></returns>
        public float GetCartTotal()
        {
            float total = 0;
            foreach (var cartProduct in cart)
            {
                total += cartProduct.GetTotal();
            }
            return total;
        }

        /// <summary>
        /// Menu para editar un producto del carrito
        /// </summary>
        /// <param name="i"></param>
        public void UpdateProduct(int i)
        {
            int options = 1;
            while (options != 0)
            {
                Menus.PrintHeader("Actualizar Producto");
                cart[i].PrintProductDetails();
                Console.WriteLine("1) Eliminar producto\n2) Actualizar Cantidad\n3) Actualizar Personalizacion\n0) Regresar");
                options = UserInput.Option(0, 3);
                switch (options)
                {
                    case 1:
                        DeleteProductFromCart(i);
                        options = 0;
                        break;
                    case 2:
                        {
                            Menus.DeleteLastLine(5);
                            Console.WriteLine("Cantidad: ");
                            int count = UserInput.Number(1);
                            cart[i].SetCount(count);
                        }
                        break;
                    case 3:
                        Menus.DeleteLastLine(5);
                        cart[i].Update();
                        break;
                }
            };
        }

        /// <summary>
        ///  Agrega un nuevo producto al carrito de compras
        /// </summary>
        /// <param name="_id">id del producto</param>
        public void AddProductToCart(string _id)
        {
            foreach (var product in products)
            {
                if (product.GetId() == _id)
                {
                    Product newProduct = product.Clone();
                    int existsPos = -1;
                    Console.Clear();
                    newProduct.PrintProduct();
                    newProduct.Personalize();

                    for (int i = 0; i < cart.Length; i++)
                    {
                        if (cart[i].GetId() == newProduct.GetId())
                            if (cart[i].Compare(newProduct))
                                existsPos = i;
                    }

                    if (existsPos != -1)
                    {
                        cart[existsPos].SetCount(newProduct.GetCount(), true);
                    }

                    else
                    {
                        Array.Resize(ref cart, this.cart.Length + 1);
                        cart[this.cart.Length - 1] = newProduct;
                    }
                    Menus.PrintHeader("Agregado Exitosamente al carrito");
                    Console.ReadKey();

                }
            }
        }

        /// <summary>
        /// Elimina un producto del carrito
        /// </summary>
        /// <param name="_index"></param>
        public void DeleteProductFromCart(int _index)
        {
            Product[] auxCart = cart;
            Array.Resize(ref cart, this.cart.Length - 1);


            int cartPos = 0;
            for (int i = 0; i < auxCart.Length; i++)
            {
                if (i != _index)
                {
                    cart[cartPos] = auxCart[i];
                    cartPos++;
                }
            }
        }

        /// <summary>
        /// Imprime el carrito y muestra el precio total del carrito
        /// </summary>
        public void PrintCart()
        {
            string totalText = "Total: " + GetCartTotal();
            int count = 1;
            foreach (var product in cart)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(count + ")");
                Console.ResetColor();
                product.PrintProductDetails();
                count++;
            }
            Console.WriteLine(totalText.PadLeft(Console.WindowWidth));
            Menus.PrintLine();
        }

        /// <summary>
        /// Imprime el carrito y muestra el precio total en la moneda seleccionada
        /// </summary>
        /// <param name="_currency"></param>
        public void PrintCart(Currency _currency)
        {
            string totalText = "SUBTTL: " + (_currency == Currency.usd ? "USD " : "BS ") + (_currency == Currency.usd ? GetCartTotal() : GetCartTotal() * bcv);
            int count = 1;

            foreach (var product in cart)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(count + ")");
                Console.ResetColor();
                product.PrintProductDetails(_currency, bcv);
                count++;
            }
            Menus.PrintRightText(totalText);
            Menus.PrintLine();
        }
    }
}
