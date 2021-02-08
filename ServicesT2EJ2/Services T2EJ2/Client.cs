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
        bool running = false;
        string username = "";
        string fullUsername = "";
        string ip = null;
        

        public void run(Socket clientSocket)
        {
            try
            {
                this.socket = clientSocket;
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
                        Console.WriteLine(this.username);
                        if (this.username == "")
                        {
                            this.writer.WriteLine("Invalid username!");
                            this.writer.Flush();
                        }
                        else if(this.username != null)
                        {
                            lock (Program.l)
                            {
                                if (Program.users.Count > 0)
                                {
                                    if (!Program.users.Contains(this))
                                    {
                                        Program.users.Add(this);
                                        this.fullUsername = this.username + "@" + this.ip;
                                        PassMsg(this.fullUsername + " entered the chat");
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
                                    this.fullUsername = this.username + "@" + this.ip;
                                    PassMsg(this.fullUsername + " entered the chat");
                                }
                            }
                            this.running = true;
                        }
                    }
                    this.writer.WriteLine("You entered the chat.");
                    this.writer.Flush();
                    while (running)
                    {
                        if (running)
                        {
                            string msg = reader.ReadLine();
                            Console.WriteLine(msg);
                            if (msg != null)
                            {
                                switch (msg)
                                {
                                    case "#lista":
                                        msg = ListUsers();
                                        this.writer.WriteLine(msg);
                                        this.writer.Flush();
                                        break;

                                    case "#salir":
                                        lock (Program.l)
                                        {
                                            Program.users.Remove(this);
                                        }
                                        this.running = false;
                                        PassMsg(this.fullUsername + " left the chat.");
                                        break;

                                    default:
                                        if (msg.Trim().Length > 0 && msg != "")
                                        {
                                            PassMsg(this.fullUsername + " says: " + msg);
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                this.running = false;
                            }
                        }
                    }
                    lock (Program.l)
                    {
                        Program.users.Remove(this);
                    }
                    this.socket.Close();
                }
            }
            catch (Exception ex) when (ex is SocketException ||ex is IOException)
            {
                Console.WriteLine("ERROR client thread!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                lock (Program.l)
                {
                    Program.users.Remove(this);
                }
            }
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

        private string ListUsers()
        {
            string usernames = "";
            lock (Program.l)
            {
                if(Program.users.Count == 0)
                {
                    usernames = "No users conected";
                }
                else
                {
                    usernames += "Conected users:"+Environment.NewLine;
                    foreach (Client c in Program.users)
                    {
                        usernames += c.fullUsername + Environment.NewLine;
                    }
                }
            }
            return usernames;
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
