using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.IO;
using System.Diagnostics;

namespace EJemploExamenServicios
{
    class Program
    {
        public static int xliebre = 0,xtortuga = 0;
        public static Random r = new Random();
        public static object l = new object();
        public static bool running = true;
        public static System.Timers.Timer a = new System.Timers.Timer(2500);
        static void Main(string[] args)
        {
            FileInfo f = new FileInfo("ganadores.txt");
            if (f.Exists)
            {
                using (StreamReader reader = new StreamReader(f.FullName)) {
                    string str = "";
                    while (str != null)
                    {
                        try
                        {
                            str = reader.ReadLine();
                            Console.WriteLine(str);
                        }
                        catch (Exception ex) when (ex is IOException)
                        {
                            Console.WriteLine("Error leyendo del archivo!");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("El archivo de ganadores no existe!");
                f.Create();
            }
            ThreadStart s = new ThreadStart(notepad);
            Thread t3 = new Thread(s);
            t3.Start();
            t3.Join();
            
            Thread t = new Thread(CorreLiebre);
            Thread t2 = new Thread(CorreTortuga);
            Thread main = Thread.CurrentThread;
            a.Elapsed += OnTimedEvent;
            t.Start();
            t2.Start();
            t.Join();
            if (xliebre >= 25)
            {
                Console.WriteLine("Gana la liebre");
                using (StreamWriter writer = new StreamWriter(f.FullName,true))
                {
                    try
                    {
                        writer.WriteLine("Liebre");
                    }
                    catch (Exception ex) when (ex is IOException)
                    {
                        Console.WriteLine("Error escribiendo al archivo!");
                    }
                }
            }else if(xtortuga >= 25)
            {
                Console.WriteLine("Gana la tortuga"); 
                using (StreamWriter writer = new StreamWriter(f.FullName, true))
                {
                    try
                    {
                        writer.WriteLine("Tortuga");
                    }
                    catch (Exception ex) when (ex is IOException)
                    {
                        Console.WriteLine("Error escribiendo al archivo!");
                    }
                }
            }
            Console.WriteLine("Se ha guardado en {0}",f.FullName);
            DirectoryInfo dir = f.Directory;
            foreach(FileInfo f2 in dir.GetFiles())
            {
                Console.WriteLine("{0} ocupa: {1} bytes",f2.Name,f2.Length);
            }

            Console.ReadKey();
        }

        public static void notepad()
        {
            ProcessStartInfo info = new ProcessStartInfo("notepad");
            Process p = null;
            try
            {
                p = Process.Start(info);
                
            }
            catch (Exception ex) when (ex is System.ComponentModel.Win32Exception || ex is ArgumentNullException ||ex is FileNotFoundException)
            {
                Console.WriteLine("Error de acceso al proceso!");
            }
            Console.WriteLine("Threads del notepad:");
            try
            {
                foreach (ProcessThread p2 in p.Threads)
                {
                    Console.WriteLine("Id: {0}, State: {1}, priority: {2}, started at: {3}",p2.Id,p2.ThreadState,p2.PriorityLevel,p2.StartTime.Hour);
                }
            }
            catch (Exception ex) when (ex is SystemException || ex is PlatformNotSupportedException)
            {
                Console.WriteLine(ex.GetType().ToString());
                Console.WriteLine("Error de acceso a los hilos del proceso!");

            }
            Console.WriteLine();
            p.WaitForExit();
        }

        public static void CorreLiebre()
        {
            while (running)
            {
                Thread.Sleep(200);
                lock (l)
                {
                    if (running)
                    {
                        xliebre += 6;
                        Console.WriteLine("La liebre ha dado: {0} pasos", xliebre);
                    }
                }
                if (xliebre >= 25)
                {
                    running = false;
                }
                else
                {
                    int rng = r.Next(0, 101);
                    switch (rng)
                    {
                        case int a when (a >= 0 && a <= 59):
                            lock (l)
                            {
                                Console.WriteLine("La liebre se ha dormido!");
                                Thread t = new Thread(dormir);
                                t.Start();
                                Monitor.Wait(l);
                            }
                                Console.WriteLine("La liebre ha despertado!");
                            break;
                        default:
                            //Console.WriteLine("La liebre no se ha dormido!");
                            break;
                    }

                }
            }
        }

        public static void dormir()
        {
            a.Start();
        }

        public static void OnTimedEvent(Object source, ElapsedEventArgs args)
        {
            lock (l)
            {
                a.Stop();
                Monitor.Pulse(l);
            }
        }

        public static void CorreTortuga()
        {
            while (running)
            {
                Thread.Sleep(300);
                if (running)
                {
                    lock (l)
                    {
                        xtortuga += 1;
                        Console.WriteLine("La tortuga ha dado: {0} pasos", xtortuga);
                    }
                    if (xtortuga >= 25)
                    {
                        lock (l)
                        {
                            running = false;
                        }
                    }
                    if (xliebre == xtortuga && running)
                    {
                        switch (r.Next(0, 101))
                        {
                            case int a when (a >= 0 && a <= 49):
                                lock (l)
                                {
                                    Console.WriteLine("La tortuga ha hecho ruido y ha despertado a la liebre!");
                                    Monitor.Pulse(l);
                                }
                                break;
                        }
                    }
                }
            }
        }
    }
}
