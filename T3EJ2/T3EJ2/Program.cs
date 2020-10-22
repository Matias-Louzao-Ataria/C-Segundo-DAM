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
        Mathematics = 0,
        Physics = 1,
        Technical_drawing = 2,
        Algebra = 3
    }
}
