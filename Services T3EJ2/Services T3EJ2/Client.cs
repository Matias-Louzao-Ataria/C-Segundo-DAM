using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Services_T3EJ2
{
    class Client
    {
        private Socket socket = null;
        private NetworkStream ns = null;
        private StreamReader reader = null;
        private StreamWriter writer = null;
        bool running = true;
        string username = "";
        string ip = null;
        

        public void run(Socket clientSocket)
        {
            try
            {
                IPEndPoint iPEndClient = (IPEndPoint)clientSocket.RemoteEndPoint;
                using (this.ns = new NetworkStream(clientSocket))
                using (this.reader = new StreamReader(ns))
                using (this.writer = new StreamWriter(ns))
                {
                    this.ip = iPEndClient.Address.ToString();
                    while (this.username == "" && !Program.users.Contains(this))
                    {
                        writer.WriteLine("Enter a username:");
                        writer.Flush();
                        this.username = reader.ReadLine();
                        if (this.username == "")
                        {
                            this.writer.WriteLine("Invalid username!");
                            this.writer.Flush();
                        }
                        else if(username != null)
                        {
                            lock (Program.l)
                            {
                                if (Program.users.Count > 0)
                                {
                                    if (!Program.users.Contains(this))
                                    {
                                        Program.users.Add(this);
                                        PassMsg(this.username + "@" + this.ip+" entered the chat");
                                    }
                                    else
                                    {
                                        this.writer.WriteLine("User already exists!");
                                        this.writer.Flush();
                                        this.username = "";
                                    }
                                }
                                else
                                {
                                    Program.users.Add(this);
                                    PassMsg(this.username + "@" + this.ip + " entered the chat");
                                }
                            }
                        }
                    }
                    while (running)
                    {
                        if (running)
                        {
                            string msg = reader.ReadLine();
                            if (msg != null)
                            {
                                PassMsg(this.username + "@" + this.ip + " says: " + msg);
                            }
                        }
                    }
                    this.socket.Close();
                }
            }
            catch (Exception ex) when (ex is SocketException ||ex is IOException)
            {
                Console.WriteLine("ERROR client thread!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
            }
            IPEndPoint i = (IPEndPoint)clientSocket.RemoteEndPoint;
        }

        private void PassMsg(string msg)
        {
            lock (Program.l)
            {
                foreach (Client c in Program.users)
                {
                    if (c.writer != null && c != this)
                    {
                        c.writer.WriteLine(msg);
                        c.writer.Flush();
                    }
                }

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
