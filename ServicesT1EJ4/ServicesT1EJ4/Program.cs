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
        static void Main(string[] args)
        {
            Caballo[] runners = new Caballo[5];

            for (int i = 0;i < runners.Length ;i++)
            {
                runners[i] = new Caballo(i,0,i+1);
            }

            Thread[] threads = new Thread[runners.Length];

            for (int i = 0;i < threads.Length ;i++)
            {
                threads[i] = new Thread(runners[i].correr);
                threads[i].Start();
            }
            Console.ReadKey();
        }
    }
}
