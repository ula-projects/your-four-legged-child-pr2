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
        public static void MainMenu(int _cart = 0)
        {
            string message = "Tu hijo de 4 patas - Petshop";
            string cart = "Carrito: " + _cart;
            PrintHeader(message);
            Console.WriteLine(cart.PadLeft(Console.WindowWidth));
            Console.ResetColor();
            Console.WriteLine("\n1) Ver Productos\n2) Ver Carrito");
            if (_cart > 0) Console.WriteLine("3) Comprar");
            Console.WriteLine("0) Salir\n");
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
        public static void DeleteLastLine(int i)
        {
            for (int j = 0; j < i; j++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
            }
        }

        public static void PrintCenterText(string _message)
        {
            Console.WriteLine(_message.PadLeft(Console.WindowWidth / 2 + _message.Length / 2));
        }
        public static void PrintRightText(string _message)
        {
            Console.WriteLine(_message.PadLeft(Console.WindowWidth));
        }

        public static void PrintLeftRightText(string _left, string _right)
        {

            Console.Write(_left);
            Console.WriteLine(_right.PadLeft(Console.WindowWidth - _left.Length));
        }
    }
}
