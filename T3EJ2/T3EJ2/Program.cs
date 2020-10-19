using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3EJ2
{
    class Program
    {
        static void Main(string[] args)
        {
            Aula a = new Aula();//FIXME todo en general
            Alumno a2 = new Alumno(a.Nombres.Length);
            Console.WriteLine(a.media(a2.Notas));
        }
    }

    enum Subjects
    {
        Mathematics = 1,
        Physics = 2,
        Technical_drawing = 3,
        Algebra = 4
    }
}
