using System;
using System.Collections;
using System.IO;
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
            int select = 0;
            while (select != 5)
            {
                Console.WriteLine("1.- Enter PC.\n2.- Remove PC.\n3.- Show PCs.\n4.- Show PC.\n5.- Salir.");
                select = Menu.EnterInteger();
                m.menu(select);
            }
        }
    }

    class Menu
    {
        string home = "", sep = "";
        private Hashtable pcs;
        private FileInfo f;
        public Menu(Hashtable pcs)
        {
            this.pcs = pcs;
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                home = Environment.GetEnvironmentVariable("HOME");
                sep = "/";
            }
            else
            {
                home = Environment.GetEnvironmentVariable("homepath");
                sep = "\\";
            }
            f = new FileInfo(home + sep + "datos.txt");
            if (f.Exists && f.Length > 0)
            {
                LoadData(home + sep + "datos.txt");
            }
        }

        public void menu(int select)
        {   
            switch (select)
            {
                case 1:
                    this.EnterData();
                    break;

                case 2:
                    Console.WriteLine("Enter the IP of the PC you'd like to remove: ");
                    RemovePc(Console.ReadLine());
                    break;

                case 3:
                    ShowPcs();
                    break;

                case 4:
                    Console.WriteLine("Enter the IP of the PC you'd like to see: ");
                    ShowPc(Console.ReadLine());
                    break;

                case 5:
                    Console.WriteLine("See you!");
                    break;

                default:
                    Console.WriteLine("Action not recognised!");
                    break;
            }
            Save(home+sep+"datos.txt");
        }

        public void LoadData(string f)
        {
            using (StreamReader reader = new StreamReader(f))
            {
                while (!reader.EndOfStream)
                {
                    AddPc(reader.ReadLine(), int.Parse(reader.ReadLine()), false);
                }
            }
        }

        public void EnterData()
        {
            Regex rex = new Regex("^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])");
            int gb = 0;
            String ip = "";
            do
            {

                if (ip != "")
                {
                    Console.WriteLine("Enter RAM quantity in GB:");
                    gb = EnterInteger();
                    if (gb <= 0)
                    {
                        Console.WriteLine("Invalid RAM quantity!");

                    }
                    else
                    {
                        AddPc(ip,gb,true); 
                    }

                }
                else
                {
                    Console.WriteLine("Enter an IP:");
                    ip = Console.ReadLine();
                    if (!rex.IsMatch(ip))
                    {
                        Console.WriteLine("Invalid IP!");
                        ip = "";
                    }
                }
            } while (!rex.IsMatch(ip) || gb <= 0);
        }

        public void AddPc(string ip,int gb,Boolean disp)
        {
            pcs.Add(ip, gb);
            if (disp)
            {
                Console.WriteLine("PC added correctly!");
            }
        }

        public void RemovePc(string ip)
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

        public void ShowPcs()
        {
            if (pcs.Count > 0)
            {
                foreach (DictionaryEntry entry in pcs)
                {
                    Console.WriteLine("This PC's IP is: {0} and it's RAM amount is {1}GB.", entry.Key, entry.Value);
                }
            }
            else
            {
                Console.WriteLine("There are no PC's in the list!");
            }
        }

        public void ShowPc(string ip)
        {
            if (pcs.ContainsKey(ip))
            {
                foreach (DictionaryEntry e in pcs)
                {
                    if (e.Key.ToString() == ip)
                    {
                        Console.WriteLine("IP: {0}, {1}GB.", e.Key, e.Value);
                    }
                }
            }
            else
            {
                Console.WriteLine("That PC does not exist!");
            }
        }

        public void Save(string f)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(f))
                {
                    foreach (DictionaryEntry entry in pcs)
                    {
                        writer.WriteLine(entry.Key);
                        writer.WriteLine(entry.Value);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static int EnterInteger()
        {
            int res = 0;
            while (res == 0)
            {
                try
                {
                    res = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    res = 0;
                }
                catch (OverflowException e) {
                    Console.WriteLine(e.Message);
                    res = 0;
                }
            }
            return res;
        }
    }
}
