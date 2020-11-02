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
            string[] options = { "Add videogame", "Remove videogame", "Visualize whole list", "Check videogames of a certain style", "Modify a videogame", "Exit" };
            Menu menu = new Menu();
            menu.ChooseOption(options);
        }
    }
}

struct Game
{
    private string title;

    public string Title 
    {
        set
        {
            if (value.Trim().Replace(" ","").Replace("\t","").Length <= 0)
            {
                throw new ArgumentException();
            }
            else
            {
                this.title = value;
            }
        }

        get
        {
            return this.title;
        }
    }

    private int year;
    public int Year
    {
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this.year = value;
            }
        }

        get
        {
            return this.year;
        }
    }

    private Style style;

    public Style Style
    {
        set
        {
            if ((int)value < 0 || (int)value > 4)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        get
        {
            return this.style;
        }
    }

}
enum Style{
    Arcade = 0,
    Videoaventura = 1,
    Shootemup = 2,
    Estrategia = 3,
    Deportivo = 4
}
