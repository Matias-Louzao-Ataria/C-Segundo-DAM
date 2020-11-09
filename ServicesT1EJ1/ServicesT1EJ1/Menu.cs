using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesT1EJ1
{
    class Menu
    {
        public delegate void funcs();
        static void Main(string[] args)
        {
            MenuGeneratorClass m = new MenuGeneratorClass();
            m.MenuGenerator(new string[] {"A" ,"B","C"}, new funcs[] {f1,f2,f3});
        }

        static void f1()
        {
            Console.WriteLine("A");
        }
        static void f2()
        {
            Console.WriteLine("B");
        }
        static void f3()
        {
            Console.WriteLine("C");
        }

    }

    class MenuGeneratorClass{
        
        public void MenuGenerator(string[] options,Menu.funcs[] functionArray)
        {
            if (options.Length == functionArray.Length)
            {
                options = options.Concat(new string[] { "Exit" }).ToArray();
                int select = 0;
                ConsoleKey input;
                ConsoleKeyInfo info;
                do
                {
                    MenuToScreen(options, select);
                    info = Console.ReadKey();
                    input = info.Key;
                    switch (input)
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
                            if (select != options.Length - 1 && select >= 0 && select < options.Length)
                            {
                                Console.Clear();
                                functionArray[select]();
                                Console.WriteLine("The selected option has ended press any key to continue!");
                                Console.ReadKey();
                            }
                            else { Console.WriteLine("a"); }
                            break;
                        default:
                            if (int.Parse("" + info.KeyChar) > 0 && int.Parse("" + info.KeyChar) < options.Length - 1)
                            {
                                select = int.Parse("" + info.KeyChar) - 1;
                                //goto case ConsoleKey.Enter;
                            }
                            break;
                    }
                } while (select != options.Length - 1 || input != ConsoleKey.Enter);
            }
            else
            {
                Console.WriteLine("There has to be the same number of options and functions otherwise the menu would not work!");
                Console.WriteLine("Pess any key to continue!");
                Console.ReadKey();
            }
        }

        public void MenuToScreen(string[] options,int select)
        {
            Console.Clear();
            Console.CursorVisible = false;
            for (int i = 0;i < options.Length ;i++)
            {
                if (i == select)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("{0,2}.- {1}.",(i+1),options[i]);
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
