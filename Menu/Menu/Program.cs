using System;

namespace Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] options = {"A","B","C","D","E"};
            Menu menu = new Menu();
            menu.ChooseOption(options);
        }
    }

    class Menu
    {
        public void ShowMenu(string[] options,int select)
        {
            if (select >= 0 && select < options.Length)
            {
                Console.Clear();
                for (int i = 0;i < options.Length;i++)
                {
                    if (i == select)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                        Console.WriteLine("{0}.- {1}", (i + 1), options[i]);
                }
            }
            else
            {
                Console.WriteLine("Acción no reconocida!");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ChooseOption(string[] options)
        {
            ConsoleKey key;
            int select = 0;
            Console.CursorVisible = false;
            do
            {
                ShowMenu(options, select);
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (select > 0)
                        {
                            select--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (select < options.Length - 1)
                        {
                            select++;
                        }
                        break;

                    case ConsoleKey.Enter:
                        //Switch con las opciones del programa aquí.
                        break;
                }
            } while (select != options.Length-1 || key != ConsoleKey.Enter);
            Console.WriteLine("CYA");
        }
    }
}
