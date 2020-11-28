using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ServicesT1EJ4_Mejorado_
{
	public class Caballo
    {
		public int id,x = 0;
		
        public Caballo(int id)
		{
			this.id = id;
		}

		public void run()
		{
            while (Program.running)
            {
                lock (Program.l)
                {
                    if (Program.running)
                    {
                        Console.SetCursorPosition(x,id);
                        int num = Program.r.Next(1, 5);
                        this.x += num;
                        if (x >= 25)
                        {
                            for (int i = 0; i < num; i++)
                            {
                                if (i == num-1)
                                {
                                    Console.Write("#");
                                }
                                else
                                {
                                    Console.Write("_");
                                }
                            }
                            Program.running = false;
                        }
                        else
                        {
                            for (int i = 0;i < num;i++)
                            {
                                Console.Write("_");
                            }
                        }
                    }
                }
                Thread.Sleep(Program.r.Next(0,500));
            }
		}
    }
}
