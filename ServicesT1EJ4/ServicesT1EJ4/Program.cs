using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServicesT1EJ4
{
    class Program
    {
        public static readonly Object lmain = new object();
        public static readonly Object l = new object();
        static void Main(string[] args)
        {
            Caballo[] runners = new Caballo[5];
            bool error = false;
            bool replay = false;

           /*do
            {
                Console.WriteLine("Enter the horse you want to bet for: 1 for the first horse and {0} for the last one!", runners.Length);
                int select = AskForInteger();
                select--;
                if (select >= 0 && select < runners.Length) {*/ 
                
                    for (int i = 0; i < runners.Length; i++)
                    {
                        runners[i] = new Caballo(i, 0, i + 1);
                    }

                    Thread[] threads = new Thread[runners.Length];

                    for (int i = 0; i < threads.Length; i++)
                    {
                        threads[i] = new Thread(runners[i].correr);
                        threads[i].Start();
                    }

                    //threads[0].Join();

                    while (Caballo.running)//A veces el pulse llega antes que el wait, esto no pasa con join.
                    {
                        lock (l)
                        {
                            Monitor.Wait(l);
                        }
                    }

                    for (int i = 0; i < runners.Length; i++)
                    {
                        lock (l)
                        {
                            if (runners[i].X >= 12)
                            {
                                Console.SetCursorPosition(0, 10);
                                Console.WriteLine(runners[i].Id+1);
                                /*if (select == runners[i].Id)
                                {
                                    Console.WriteLine("You win!");
                                    Console.WriteLine("Would you like to play again?");
                                    if (Console.ReadLine().Contains("yes"))
                                    {
                                        replay = true;
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        replay = false;
                                    }
                                }*/
                            }
                        }
                    }
                   /* error = false;
                }
                else
                {
                    Console.WriteLine("Invalid horse!");
                    error = true;
                }
            } while (error ||replay);*/
            
            Console.ReadKey();
        }

        public static int AskForInteger()
        {
            bool error = true;
            int res = 0;
            while (error)
            {
                try
                {
                    res = int.Parse(Console.ReadLine());
                    error = false;
                }
                catch (Exception e) when (e is FormatException || e is OverflowException)
                {
                    Console.WriteLine("Invalid number!");
                    Console.WriteLine("Please enter a new one:");
                    error = true;
                }
            }
            return res;
        }
    }
}
