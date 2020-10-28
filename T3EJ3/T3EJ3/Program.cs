using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3EJ3
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

struct Juego
{
    String titulo;
    int año;
    Estilo est;
}
enum Estilo{
    Arcade = 0,
    Videoaventura = 1,
    Shootemup = 2,
    Estrategia = 3,
    Deportivo = 4
}
