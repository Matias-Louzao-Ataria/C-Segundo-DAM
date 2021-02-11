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
        public int num = -1;

        public void run(Socket clientSocket)
        {
            try
            {
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
                            }
                        }
                    }
                    this.writer.WriteLine("You've entered the game!");
                    this.writer.Flush();
                    this.fullUsername = this.username + "@" + this.ip;
                    this.PassMsg(this.fullUsername + " entered the game",false);
                    while (this.running)
                    {
                        if (Program.players.Count <= 1)
                        {
                            this.writer.WriteLine("Waiting for more players!");
                            this.writer.Flush();
                            lock (Program.l)
                            {
                                Monitor.Wait(Program.l);
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
                    
                        while (this.running && Program.players.Count > 1)
                        {
                            if (Program.contador == null)
                            {
                                Thread counter = new Thread(() =>
                                {
                                    while (Program.countDown > -1)
                                    {
                                        Console.WriteLine("a");
                                        Console.WriteLine(Program.countDown);
                                        lock (l)
                                        {
                                            Thread.Sleep(1000);
                                            if (Program.countDown > 0)
                                            {
                                                PassMsg(string.Format("{0} seconds remaining!", Program.countDown),true);
                                                Program.countDown--;
                                            }
                                            else
                                            {
                                                Console.WriteLine("BBBBBB");
                                                Client winner = CheckWinner();
                                                Console.WriteLine(winner.fullUsername);
                                                PassMsg(string.Format("the winner is: {0}!", winner.fullUsername), true);
                                                Console.WriteLine("AAA");
                                                Program.countDown--;
                                                Console.WriteLine("AAA");
                                                Console.WriteLine(Program.players.Count);
                                                foreach (Client c in Program.players)
                                                {
                                                    Console.WriteLine("SDF");
                                                    c.num = -1;
                                                }
                                            }
                                        }
                                    }

                                }
                                );
                                Program.contador = counter;
                                counter.Start();
                            }
                            else
                            {
                                if (Program.countDown <= 0)
                                {
                                    if (this.num == -1)
                                    {
                                        this.running = false;
                                    }
                                    this.writer.WriteLine("Game start!"+Environment.NewLine+" your number is: "+this.num);
                                    this.writer.Flush();
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

        //private void AnounceWinner()
        //{
        //    if (this.CheckWinner())
        //    {
        //        this.writer.WriteLine("Has ganado!");
        //        this.writer.Flush();
        //        this.PassMsg(string.Format("The winner is: {0}!", this.fullUsername),false);
        //    }
        //    else
        //    {
        //        this.writer.WriteLine("Has perdido!");
        //        this.writer.Flush();
        //    }
        //    this.running = false;
        //}

        private void PassMsg(string msg,bool all)
        {
            lock (Program.l)
            {
                
                foreach (Client c in Program.players)
                {
                    if (c.writer != null && c != this || all && c.writer != null)
                    {
                        try
                        {
                            c.writer.WriteLine(msg);
                            c.writer.Flush();
                        }
                        catch (Exception ex) when (ex is IOException || ex is SocketException || ex is ObjectDisposedException)
                        {
                            Console.WriteLine("ERROR writting to client!");
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                
            }
        }

        private Client CheckWinner()
        {
            int max = 0;
            Client winner = null;
            lock (Program.l)
            {
                foreach (Client c in Program.players)
                {
                    Console.WriteLine("Players: "+Program.players.Count);
                    if (c.num > max)
                    {
                        max = c.num;
                        winner = c;
                    }
                }
            }
            return winner;
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
