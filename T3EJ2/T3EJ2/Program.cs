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
            InterfazDeUsuario i = new InterfazDeUsuario();
            i.menu();
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
