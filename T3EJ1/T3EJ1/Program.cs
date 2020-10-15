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
            Hashtable pcs = new Hashtable();
            Menu m = new Menu(pcs);
            m.menu(1);
            m.menu(3);
            Console.ReadLine();
        }
    }

    class Menu
    {
        private Hashtable pcs;
        public Menu(Hashtable pcs)
        {
            this.pcs = pcs;
        }

        public void menu(int select)
        {
            switch (select)
            {
                case 1:
                    this.AddPc(pcs);
                    break;

                case 2:
                    Console.WriteLine("Enter the IP of the PC you'd like to remove: ");
                    RemovePc(pcs,Console.ReadLine());
                    break;

                case 3:
                    ShowPcs(pcs);
                    break;

                case 4:
                    Console.WriteLine("Enter the IP of the PC you'd like to see: ");
                    ShowPc(pcs, Console.ReadLine());
                    break;

                default:
                    Console.WriteLine("Action not recognised!");
                    break;
            }
        }

        public void AddPc(Hashtable pcs)
        {
            Regex rex = new Regex("[0-9]?[0-9]?[0-9].[0-9]?[0-9]?[0-9].[0-9]?[0-9]?[0-9].[0-9]?[0-9]?[0-9]");
            int gb = 0;
            String ip = "";
            do
            {

                if (ip != "")
                {
                    Console.WriteLine("Enter RAM quantity in GB:");
                    gb = int.Parse(Console.ReadLine());
                    if (gb <= 0)
                    {
                        Console.WriteLine("Invalid RAM quantity!");
                        
                    }
                    else
                    {
                        pcs.Add(ip, gb);
                        Console.WriteLine("PC added correctly!");
                    }

                }
                else
                {
                    Console.WriteLine("Enter an IP:");
                    ip = Console.ReadLine();
                    if (!rex.IsMatch(ip))
                    {
                        Console.WriteLine("Invalid IP!");
                    }
                }
            } while (!rex.IsMatch(ip) || gb <= 0);
        }

        public void RemovePc(Hashtable pcs, string ip)
        {
            if (pcs.Count > 0)
            {
                if (pcs.ContainsKey(ip))
                {
                    pcs.Remove(ip);
                    Console.WriteLine("PC removed correctly!");
                }
                else
                {
                    Console.WriteLine("That PC does not exist!");
                }
            }
            else
            {
                Console.WriteLine("There are no PC's in the list!");
            }
        }

        public void ShowPcs(Hashtable pcs)
        {
            if (pcs.Count > 0)
            {
                foreach (DictionaryEntry entry in pcs)
                {
                    Console.WriteLine("This PC's IP is: {0} and it's RAM amount is {1}GB.",entry.Key,entry.Value);
                }
            }
            else
            {
                Console.WriteLine("There are no PC's in the list!");
            }
        }

        public void ShowPc(Hashtable pcs, string ip)
        {
            foreach (DictionaryEntry e in pcs)
            {
                if (e.Key.ToString() == ip)
                {
                    Console.WriteLine("IP: {0}, {1}GB.",e.Value,e.Key);
                }
            }
        }
    }
}
