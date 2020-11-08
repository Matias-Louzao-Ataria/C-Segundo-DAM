using ServicesT1EJ1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace T3EJ3
{
    class Interfaz
    {
        public Operaciones o;

        public Interfaz()
        {
            o = new Operaciones();
        }

        public void EnterData()
        {
            bool error = false;
            Game g = new Game();
            string name = "";
            do
            {
                Console.WriteLine("Enter the name of the game:");
                name = Console.ReadLine();
                Console.WriteLine("Enter the year in which the game came out:");
                int year = AskForInteger();
                Console.WriteLine("Enter the genre if the game:");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("{0}.- {1}", (i + 1), (GameStyle)i);
                }
                int style = AskForInteger()-1;

                try
                {
                    g = new Game(name, year, (GameStyle)style);
                    error = false;
                }
                catch (Exception ex) when (ex is ArgumentException || ex is ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Invalid game, plase enter a new one!");
                    error = true;
                }
            } while (error);

            if (this.o.AddGame(g))
            {
                Console.WriteLine("Game added correctly!");
            }
            else
            {
                Console.WriteLine("Failed to add the game!");
            }
        }

        public void DeleteRangeOfGames()
        {
            ArrayList gameList = this.o.Games;
            string answer;
            int min = 0,max = 0;

            ShowTitles();
            Console.WriteLine("Enter the first position you'd like to remove:");
            min = AskForInteger();
            Console.WriteLine("Enter the last position you'd like to remove:");
            max = AskForInteger();
            if (min > 0)
            {
                for (int i = min - 1; i < max; i++)
                {
                    Console.WriteLine("Game title: {0}, year it was released: {1,4}, genre: {2}", ((Game)gameList.ToArray()[i]).Title, ((Game)gameList.ToArray()[i]).Year, ((Game)gameList.ToArray()[i]).Style.ToString());
                }
                Console.WriteLine("Are you sure you want to remove those games?");
                answer = Console.ReadLine();
                if (answer.ToLower().Contains("s") || answer.ToLower().Contains("y"))
                {
                    if (this.o.Remove(max - 1, min - 1))
                    {
                        Console.WriteLine("Games removed correctly!");
                    }
                    else
                    {
                        Console.WriteLine("Could not remove the games");
                    }
                }
                else
                {
                    Console.WriteLine("Operation stopped by the user!");
                }
            }
            else
            {
                for (int i = 0; i < max - 1; i++)
                {
                    Console.WriteLine("Game title: {0}, year it was released: {1,4}, genre: {2}", ((Game)gameList.ToArray()[i]).Title, ((Game)gameList.ToArray()[i]).Year, ((Game)gameList.ToArray()[i]).Style.ToString());
                }
                Console.WriteLine("Are you sure you want to remove those games?");
                answer = Console.ReadLine();
                if (answer.ToLower().Contains("s") || answer.ToLower().Contains("y"))
                {
                    if (this.o.Remove(max - 1))
                    {
                        Console.WriteLine("Games removed correctly!");
                    }
                    else
                    {
                        Console.WriteLine("Could not remove the games");
                    }
                }
                else
                {
                    Console.WriteLine("Operation stopped by the user!");
                }
            }
        }

        private void DeleteRangeOfGames(int min,int max)
        {
            this.o.Remove(min, max);
        }

        private void ShowTitles()
        {

            ArrayList gameList = this.o.Games;
            int cont = 0;
            foreach (Game g in gameList)
            {
                cont++;
                Console.WriteLine("{0}.- {1}", (cont), g.Title);
            }

        }

        public void ShowWholeList()
        {
            ArrayList gameList = this.o.Games;
            if (gameList.Count > 0)
            {
                foreach (Game g in gameList)
                {
                    Console.WriteLine("Game title: {0}, year it was released: {1,4}, genre: {2}",g.Title,g.Year,g.Style.ToString());
                }
            }
            else
            {
                Console.WriteLine("List is empty!");
            }
        }

        public void ShowStyle()
        {
            bool error = false;
            do
            {
                int select = 0,cont = 0;
                Console.WriteLine("Enter the genre you'd like to check:");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("{0}.- {1}", (i + 1), ((GameStyle)i).ToString());
                }
                select = AskForInteger();
                if (select > 0 && select < 6)
                {
                    ArrayList gameList = this.o.Games;
                    if (gameList.Count > 0)
                    {
                        foreach (Game g in gameList)
                        {
                            if (select-1 == (int)g.Style)
                            {
                                Console.WriteLine("Game title: {0}, year it was released: {1,4}, genre: {2}", g.Title, g.Year, g.Style.ToString());
                                cont++;
                            }
                        }
                        if (!(cont > 0))
                        {
                            Console.WriteLine("There are no games of that genre!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("List is empty!");
                    }
                    error = false;
                }
                else
                {
                    Console.WriteLine("Invalid genre!");
                    Console.WriteLine("Please enter a new one:");
                    error = true;
                }
            } while (error);
        }

        public void ModifyTitle()
        {
            int select;
            ShowTitles();
            Console.WriteLine("Enter the game you'd like to modify:");
            select = AskForInteger();
            EnterData();
            DeleteRangeOfGames(select,select);
        }

        public int AskForInteger()
        {
            bool error = true;
            int res = 0;
            while (error)
            {
                try
                {
                    res = int.Parse(Console.ReadLine());
                    error = false;
                }
                catch (Exception e) when (e is FormatException || e is OverflowException)
                {
                    Console.WriteLine("Invalid number!");
                    Console.WriteLine("Please enter a new one:");
                    error = true;
                }
            }
            return res;
        }
    }
}
