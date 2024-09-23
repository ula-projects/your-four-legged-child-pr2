using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace your_four_legged_child.src.utilities
{
    public static class UserInput
    {
        public static int Option(int _min, int _max)
        {
            Menus.PrintOption(1);
            bool ready = false;
            int value = 0;
            while (!ready)
            {
                string userChoise = Console.ReadLine();
                try
                {
                    value = int.Parse(userChoise);
                    if (value >= _min && value <= _max)
                    {
                        ready = true;
                    }
                    else
                    {
                        Menus.PrintOption(-1);
                    }
                }
                catch
                {
                    Menus.PrintOption(-1);
                }
            }
            return value;
        }

        public static int Number()
        {
            Menus.PrintArrow(1);
            bool ready = false;
            int value = 0;
            while (!ready)
            {
                string userInput = Console.ReadLine();
                try
                {
                    value = int.Parse(userInput);
                    ready = true;
                }
                catch
                {
                    Menus.PrintArrow(-1);
                }
            }
            Menus.DeleteLastLine();
            Menus.PrintArrow(1);
            Console.WriteLine(value);
            return value;
        }
        public static int Number(int _min = 0)
        {
            Menus.PrintArrow(1);
            bool ready = false;
            int value = 0;
            while (!ready)
            {
                string userInput = Console.ReadLine();
                try
                {
                    value = int.Parse(userInput);
                    if (value >= _min)
                    {
                        ready = true;
                    }
                    else
                    {
                        Menus.PrintArrow(-1);
                    }
                }
                catch
                {
                    Menus.PrintArrow(-1);
                }
            }
            Menus.DeleteLastLine();
            Menus.PrintArrow(1);
            Console.WriteLine(value);
            return value;
        }
    }
}
