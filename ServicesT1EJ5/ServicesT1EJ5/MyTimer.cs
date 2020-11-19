using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ServicesT1EJ5
{
    class MyTimer
    {
        public delegate void Delegado();
        private Delegado delegado;
        public int interval = 0;
        private Thread t;
        public static bool running = true;
        public static bool waiting = true;
        public MyTimer(Delegado d)
        {
            if (d != null)
            {
                this.delegado = d;
            }
            else
            {
                throw new ArgumentNullException();
            }

            t = new Thread(exec);
            t.IsBackground = true;
            t.Start();
        }

        public void run()
        {
            lock (Program.l)
            {
                //running = true;
                waiting = false;
                Monitor.Pulse(Program.l);
            }
        }

        public void exec()
        {
            while (running)
            {
                lock (Program.l)
                {
                    if (running)
                    {
                        while (waiting)
                        {
                            Monitor.Wait(Program.l);
                        }
                        this.delegado();
                    }
                }
                if (running)
                {
                    Thread.Sleep(interval);
                }

            }
        }

        public void pause()
        {
            lock (Program.l)
            {
                //running = false;
                waiting = true;
            }
        }

    }
}
