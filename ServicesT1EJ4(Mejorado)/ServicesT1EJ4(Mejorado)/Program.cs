using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ServicesT1EJ4_Mejorado_
{
    class Program
    {
        public static bool running = true;
        public static Object l = new Object();
        public static Random r = new Random();
        static void Main(string[] args)
        {
            Thread[] runners = new Thread[5];
            Caballo[] manada = new Caballo[runners.Length];
            for (int i = 0;i < runners.Length ;i++)
            {
                manada[i] = new Caballo(i);
                runners[i] = new Thread(manada[i].run);
                runners[i].Start();
            }
            runners[0].Join();
            for (int i = 0; i < runners.Length; i++)
            {
                if (manada[i].x >= 25)
                {
                    Console.SetCursorPosition(0,7);
                    Console.WriteLine(("{0} Wins! X: {1}"),(i+1),manada[i].x);
                }
            }
            Console.ReadKey();
        }
    }
}
