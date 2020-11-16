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
        
        public static bool running = true;
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
            this.conx = conx;
            this.cony = cony;
            
        }

        public void correr()//Existe la posibilidad de que 2 llegen al mismo tiempo.
        {
            Random r = new Random();
            Console.CursorVisible = false;
            while (running)
            {
                lock (Program.l)
                {
                    if (running)//Esto arregla la llegada simultanea.
                    {
                        this.X += r.Next(0, 4);
                        if (x >= 12)
                        {
                            running = false;
                        }
                    }
                }
                if(running)
                    Thread.Sleep(r.Next(0,250));
            }
            for (int i = 0; i <= this.X; i++)
            {
                lock (Program.l)//IMPORTANTE todo lo que haga cosas con this. (excepto comparaciones) fuera del lock porque es especifico de un objeto y no es un recurso compartido.
                        //Hago esto porque lock es para evitar que un hilo acceda a datos que está usando otro (recursos compartidos), en este caso la consola.
                {
                    Console.SetCursorPosition(this.Conx, this.Cony);
                    if (this.X == i)
                    {
                        Console.WriteLine("#");
                    }
                    else
                    {
                        Console.Write("_");
                    }
                }
                if (this.conx < Console.BufferWidth - 1)
                {
                    this.conx++;
                }
            }
            if (!running)
            {
                lock(Program.l)
                Monitor.Pulse(Program.l);//Mejor que el pulse se haga siempre lo último.
            }
        }
    }
}
