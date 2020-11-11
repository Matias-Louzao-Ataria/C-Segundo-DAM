using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace ServicesT1EJ3
{
    class Program
    {
        public static int num = 0;
        public static readonly object l = new object();
        public static bool running = true;
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => {
                while (running)//No meter bucles dentro de los locks
                {
                    lock (l)
                    {
                        num++;
                        Console.WriteLine("Thread 1 increment {0}", num);
                        if (num >= 1000)
                        {
                            running = false;
                            Console.WriteLine("Thread 1 finished 1st!");
                        }
                    }
                }
            });
            Thread t2 = new Thread(() => {
                while (running)
                {
                    lock (l)
                    {
                        num--;
                        Console.WriteLine("Thread 2 decrement {0}", num);
                        if (num <= -1000)
                        {
                            running = false;
                            Console.WriteLine("Thread 2 finished 1st!");
                        }
                    }
                }
            });
            //t1.Priority = ThreadPriority.Lowest;
            t1.Start();//Dependiendo de cual empiece antes tiene más posibilidad de acabar antes uno u otro.
            t2.Start();

            Console.ReadKey();
        }
    }
}
