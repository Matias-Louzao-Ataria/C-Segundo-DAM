using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServicesT1EJ4
{
    class Caballo
    {
        public static readonly Object l = new object();
        public static bool running = true;
        private int id;
        public int Id { set; get;}

        private int x = 0;
        private int conx, cony;

        public int X { 
            set 
            {
                if (value >= 0)
                {
                    this.x = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            get
            {
                return this.x;
            }
        }

        public int Conx
        {
            set
            {
                if (value >= 0)
                {
                    this.conx = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            get
            {
                return this.conx;
            }
        }

        public int Cony
        {
            set
            {
                if (value >= 0)
                {
                    this.cony = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            get
            {
                return this.cony;
            }
        }

        public Caballo(int id,int conx,int cony)
        {
            this.Id = id;
            
        }

        public void correr()
        {
            /*while (running)
            {*/
                for (int i = 0; i <= this.X; i++)
                {
                    lock (l)
                    {
                        if (i == 0)
                        {
                            this.X++;
                        }
                        Console.SetCursorPosition(this.Conx, this.Cony);
                        if (this.X == i)
                        {
                            Console.WriteLine("#");
                        }
                        else
                        {
                            Console.Write("_");
                        }
                        if (this.conx < Console.BufferWidth-1)
                        {
                            this.conx++;
                        }
                        if (x >= 20)
                        {
                            running = false;
                        }
                    }
                        //Thread.Sleep(50);
                }
            //}
        }
    }
}
