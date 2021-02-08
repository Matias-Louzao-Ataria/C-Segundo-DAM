using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace ServicesT2EJ3
{
    class Client
    {
        private Socket socket = null;
        private NetworkStream ns = null;
        private StreamReader reader = null;
        private StreamWriter writer = null;
        bool running = true;
        string username = "";
        string fullUsername = "";
        string ip = null;
        public static Object l = new Object();
        private int num = -1,cont = 0;

        public void run(Socket clientSocket)
        {
            try
            {
                Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess().Threads.Count);
                this.socket = clientSocket;
                IPEndPoint iPEndClient = (IPEndPoint)clientSocket.RemoteEndPoint;
                this.ip = iPEndClient.Address.ToString();
                using (this.ns = new NetworkStream(clientSocket))
                using (this.reader = new StreamReader(ns))
                using (this.writer = new StreamWriter(ns))
                {
                    while (this.username == "" || this.username == null && !Program.players.Contains(this))
                    {
                        this.writer.WriteLine("Enter a username!");
                        this.writer.Flush();
                        this.username = this.reader.ReadLine();
                        lock (Program.l)
                        {
                            if (Program.players.Count <= 0)
                            {
                                Program.players.Add(this);
                                this.writer.WriteLine("You've entered the game!");
                                this.writer.Flush();
                                this.fullUsername = this.username + "@" + this.ip;
                                this.PassMsg(this.fullUsername + " entered the game");
                            }
                            else if (Program.players.Contains(this))
                            {
                                this.writer.WriteLine("Player already playing, choose a diferent username!");
                                this.writer.Flush();
                                this.username = "";
                            }
                            else if (!Program.players.Contains(this))
                            {
                                Program.players.Add(this);
                                this.writer.WriteLine("You've entered the game!");
                                this.writer.Flush();
                                this.fullUsername = this.username + "@" + this.ip;
                                this.PassMsg(this.fullUsername + " entered the game");
                            }
                        }
                    }
                    if (Program.players.Count <= 1)
                    {
                        this.writer.WriteLine("Waiting for more players!");
                        this.writer.Flush();
                        lock (Program.l)
                        {
                            Monitor.Wait(Program.l);//Si el cliente se desconecta aquí no se como saberlo y falla
                        }
                    }
                    else
                    {
                        lock (Program.l)
                        {
                            Monitor.Pulse(Program.l);
                        }
                    }

                    lock (Program.l) 
                    { 
                        this.num = Program.randomN.Next(0, 21);
                    }
                    Console.WriteLine("{0} : {1}", this.username, this.num);
                    
                    while (this.running)
                    {
                        lock (Program.l)
                        {
                            if (Program.contador == null)
                            {
                                Program.contador = this;
                            }
                            else
                            {
                                if (Program.contador == this)
                                {
                                    Thread.Sleep(1000);
                                    if (Program.countDown > 0)
                                    {
                                        this.writer.WriteLine("{0} seconds remaining!", Program.countDown);
                                        this.writer.Flush();
                                        this.PassMsg(string.Format("{0} seconds remaining!", Program.countDown));
                                        Console.WriteLine("D");
                                        Program.countDown--;

                                    }
                                }
                                
                                if (Program.countDown == 0)
                                {
                                    this.writer.WriteLine("Game start!");
                                    this.writer.Flush();
                                    this.AnounceWinner();
                                }
                            }

                        }
                    }
                }
                if (!this.running)
                {
                    lock (Program.l)
                    {
                        Program.players.Remove(this);
                        
                    }
                }
            }
            catch (Exception ex) when (ex is SocketException || ex is IOException)
            {
                Console.WriteLine("ERROR client thread!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                lock (Program.l)
                {
                    Program.players.Remove(this);
                }
            }
        }

        private void AnounceWinner()
        {
            if (this.CheckWinner())
            {
                this.writer.WriteLine("Has ganado!");
                this.writer.Flush();
            }
            else
            {
                this.writer.WriteLine("Has perdido!");
                this.writer.Flush();
            }
            this.running = false;
        }

        private void PassMsg(string msg)
        {
            lock (Program.l)
            {
                foreach (Client c in Program.players)
                {
                    if (c.writer != null && c != this)
                    {
                        c.writer.WriteLine(msg);
                        c.writer.Flush();
                    }
                }

            }
        }

        private bool CheckWinner()
        {
            lock (Program.l)
            {
                foreach (Client c in Program.players)
                {
                    if (c != this)
                    {
                        if (this.num > c.num)
                        {
                            this.cont++;
                        }
                    }
                }

                return this.cont == Program.players.Count - 1;
            }
        }

        public override bool Equals(object obj)
        {
            try
            {
                Client cl = (Client)obj;
                return this.username == cl.username && this.ip == cl.ip;
            }
            catch (Exception ex) when (ex is InvalidCastException)
            {
                return false;
            }
        }
    }
}
