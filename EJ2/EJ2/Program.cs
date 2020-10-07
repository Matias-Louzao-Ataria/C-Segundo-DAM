//#define FRASE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EJ2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca la primera frase:");
            string s1 = Console.ReadLine();
            Console.WriteLine("Introduce la segunda frase:");
            string s2 = Console.ReadLine();
#if !FRASE
            Console.WriteLine("{0}\t{1}\n{0}\n{1}",s1,s2);
#else
            Console.WriteLine("\"{0}\" \\{1}\\",s1,s2);
#endif
            Console.Read();
        }
    }
}
