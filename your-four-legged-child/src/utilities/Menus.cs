using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using your_four_legged_child.src.models;

namespace your_four_legged_child.src.utilities
{
    public static class Menus
    {
        public static void ExitApp()
        {
            //string message = "¡Hasta la proxima!";
            //CleanConsole();
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("");
            //Console.WriteLine(message.PadLeft(Console.WindowWidth / 2 + message.Length / 2));
            //Console.WriteLine("");
            //Console.ResetColor();
        }
        public static void MainMenu(int _cart = 0)
        {
            string message = "Tu hijo de 4 patas - Petshop";
            string cart = "Carrito: " + _cart;
            PrintHeader(message);
            Console.WriteLine(cart.PadLeft(Console.WindowWidth));
            Console.ResetColor();
            Console.WriteLine("\n1) Ver Productos\n2) Ver Carrito\n3) Ver Vendedores\n0) Salir\n");
        }

        public static void ProductMenu()
        {
            PrintHeader("Menu de Productos");
            Console.WriteLine("\n1) Todos\n2) Productos de cuidado\n3) Servicios especiales\n4) Accesorios de moda\n0) Regresar\n");
        }

        public static void PrintHeader(string _message)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            PrintLine();
            Console.WriteLine(_message.PadLeft(Console.WindowWidth / 2 + _message.Length / 2));
            PrintLine();
            Console.ResetColor();
        }

        public static void PrintOption(int _state)
        {
            if (_state == -1)
            {
                DeleteLastLine();
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write("Option: ");
            Console.ResetColor();
        }

        public static void PrintArrow(int _state)
        {
            if (_state == -1)
            {
                DeleteLastLine();
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write("-> ");
            Console.ResetColor();
        }

        public static void PrintProductRange(int _min, int _max)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n(" + _min + " - " + _max + ") ");
            Console.ResetColor();
        }

        public static void PrintLine()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        public static void DeleteLastLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }
}
