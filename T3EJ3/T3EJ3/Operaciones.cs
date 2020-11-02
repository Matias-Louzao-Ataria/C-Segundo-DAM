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
                this.games.RemoveRange(minPos,(maxPos-minPos));
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
                if (game.Style == (Style)style)
                {
                    res = new List<Game>();
                    res.Add(game);
                }
            }
            return res;
        }
    }
}
