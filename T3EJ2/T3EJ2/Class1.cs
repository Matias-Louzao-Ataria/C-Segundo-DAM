using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3EJ2
{
    class Aula
    {
        private string[] nombres = new string[12];
        public string[] Nombres
        {
            get;
        }

        public Aula()
        {
            for (int i = 0;i < nombres.Length;i++)
            {

            }
        }

        public double media(double[,] notas)
        {
            double total = 0;
            for (int i = 0;i < nombres.Length;i++)
            {
                for (int j = 0;j < notas.Length;j++)
                {
                    total += notas[j, 0];
                }
            }
            return total/(nombres.Length*notas.Length);
        }


    }
}
