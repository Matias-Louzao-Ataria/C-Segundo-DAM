using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace T3EJ1
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Menu
    {
        public void menu(int select)
        {
            Hashtable pcs = new Hashtable();
            switch (select)
            {
            case 1:

                    break;

            case 2:

                    break;

            case 3:

                    break;

            case 4:

                    break;

            default:
                    Console.WriteLine("Action not recognised!");
                    break;
            }
        }

        public void AddPc(Hashtable pcs)
        {
            Regex rex = new Regex("\b((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)(\\.|$)){4}\b");
            Console.WriteLine("Enter an IP:");
            String ip = Console.ReadLine();
            int gb = 0;
            do
            {
                if (rex.IsMatch(ip))
                {
                    Console.WriteLine("Enter RAM quantity in GB:");
                    gb = int.Parse(Console.ReadLine());
                    if (gb <= 0)
                    {
                        Console.WriteLine("Invalid RAM quantity!");
                    }
                    else
                    {
                        pcs.Add(ip,gb);
                    }

                }
                else
                {
                    Console.WriteLine("Invalid IP");
                    Console.WriteLine("Enter an IP:");
                    ip = Console.ReadLine();
                }
            } while (!rex.IsMatch(ip) && gb <= 0);
        }
    }
}
