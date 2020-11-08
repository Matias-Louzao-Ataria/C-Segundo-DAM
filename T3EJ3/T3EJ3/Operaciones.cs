using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3EJ3
{
    class Operaciones
    {
        private ArrayList games = new ArrayList();

        public ArrayList Games
        {
            get
            {
                return this.games;
            }
        }

        public Operaciones()
        {
            Game g;
            Random numLetter = new Random();
            Random letter = new Random();
            int numLetters;
            string ranName = "";
            for (int i = 0;i < 3;i++)
            {
                if (i == 0)
                {
                    g = new Game("Monster Hunter",2004,GameStyle.Arcade);
                }
                else
                {
                    ranName = "";
                    numLetters = numLetter.Next(1, 11);
                    for (int j = 0;j < numLetters;j++)
                    {
                        ranName += (char)letter.Next(97,123);
                    }
                    g = new Game(ranName,letter.Next(1974,2020),(GameStyle)letter.Next(0,5));
                }
                this.games.Insert(this.DeterminePosition(g.Year), g);
            }
        }

        public bool AddGame(Game g)
        {
                games.Insert(this.DeterminePosition(g.Year),g);
                return true;
        }

        public int DeterminePosition(int year)
        {
            foreach (Game game in this.games)
            {
                if (year > game.Year)
                {
                    return this.games.IndexOf(game);
                }
            }
            return this.games.Count;
        }

        public bool Remove(int maxPos,int minPos = 0)
        {
            if (maxPos >= 0 && maxPos <= this.games.Count && minPos >= 0 && minPos <= this.games.Count)
            {
                this.games.RemoveRange(minPos,(maxPos-minPos)+1);//Con el +1 se elimina también el elemento en maxPos.
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Game> StyleSearch(int style)
        {
            List<Game> res = null;
            foreach (Game game in this.games)
            {
                if (game.Style == (GameStyle)style)
                {
                    res = new List<Game>();
                    res.Add(game);
                }
            }
            return res;
        }
    }
}
