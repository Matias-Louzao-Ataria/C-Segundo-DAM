using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Timers;

namespace ServicesT1EJ6
{
    class Program
    {
        public static Random r = new Random();
        public static bool running = true;
        public static bool displayPaused = false;
        public static bool isStart = true;
        public static Object l = new Object();
        public static int contcomun = 0;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Thread player1thread = new Thread(player1);
            Thread player2thread = new Thread(player2);
            Thread displayThread = new Thread(display);
            player1thread.Start();
            player2thread.Start();
            displayThread.Start();
            player1thread.Join();
            if (contcomun >= 20)
            {
                Console.SetCursorPosition(0,10);
                Console.WriteLine("Player 1 wins!");
                Console.SetCursorPosition(0,11);
                Console.WriteLine("Counter: {0}",contcomun);
            }
            else
            {
                Console.SetCursorPosition(0,10);
                Console.WriteLine("Player 2 wins!");
                Console.SetCursorPosition(0,11);
                Console.WriteLine("Counter: {0}",contcomun);
            }
            Console.ReadKey();
        }

        public static void player1()
        {
            int player1int = 1;
            while (running)
            {
                lock (l)
                {
                    if (running)
                    {
                        player1int = r.Next(1, 11);
                        Console.SetCursorPosition(0,1);
                        Console.WriteLine("Player 1 drawed a {0,2}", player1int);
                        if (player1int == 5 || player1int == 7)
                        {
                            lock (l)
                            {
                                if (displayPaused)
                                {
                                    contcomun += 5;
                                }
                                else
                                {
                                    contcomun++;
                                }
                                displayPaused = true;
                            }
                        }
                        if (contcomun >= 20)
                        {
                            running = false;
                        }
                    }
                }
                Thread.Sleep(r.Next(100, (100 * player1int) + 1));
            }
        }

        public static void player2()
        {
            int player2int = 1;
            while (running)
            {
                lock (l)
                {
                    if (running)
                    {
                        player2int = r.Next(1, 11);
                        Console.SetCursorPosition(0,2);
                        Console.WriteLine("Player 2 drawed a {0,2}", player2int);
                        if (player2int == 5 || player2int == 7)
                        {
                            if (displayPaused)
                            {
                                contcomun++;
                            }
                            else if(!displayPaused && !isStart)
                            {
                                contcomun -= 5;
                            }
                            displayPaused = false;
                        }
                        if (contcomun <= -20)
                        {
                            running = false;
                        }
                    }
                }
                Thread.Sleep(r.Next(100, (100 * player2int) + 1));
            }
        }

        public static void display()
        {
            int contchar = 0;
            char[] c = {'|','/','-','\\','-','\\'};
            while (running)
            {
                lock (l)
                {
                    if (running && !displayPaused)
                    {
                        Console.SetCursorPosition(5, 5);
                        Console.WriteLine(c[contchar]);
                        contchar++;
                        isStart = false;
                        if (contchar >= c.Length)
                        {
                            contchar = 0;
                        }
                    }
                }
                if (!displayPaused)
                {
                    Thread.Sleep(200);
                }
            }
        }
    }
}
