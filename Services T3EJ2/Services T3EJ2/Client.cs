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
        IPAddress ip = null;

        public void run(Socket clientSocket)
        {
            try
            {
                IPEndPoint iPEndClient = (IPEndPoint)clientSocket.RemoteEndPoint;
                using (NetworkStream ns = new NetworkStream(clientSocket))
                {
                    using (StreamReader reader = new StreamReader(ns))
                    {
                        using (StreamWriter writer = new StreamWriter(ns))
                        {
                            this.ip = iPEndClient.Address;
                            while (this.username == "" && !Program.users.Contains(this))
                            {
                                writer.WriteLine("Enter a username:");
                                writer.Flush();
                                this.username = reader.ReadLine();
                                if (this.username == "")
                                {
                                    writer.WriteLine("Invalid username!");
                                    writer.Flush();
                                }
                                if (!Program.users.Contains(this))
                                {
                                    Program.users.Add(this);
                                    writer.WriteLine("User connected: " + this.username + "@" +this.ip);
                                    writer.Flush();
                                    while (running)
                                    {
                                        string msg = reader.ReadLine();
                                        foreach (Client c in Program.users)
                                        {
                                            c.writer.Write(msg);
                                            c.writer.Flush();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) when (ex is SocketException)
            {
                Console.WriteLine("ERROR client thread!");
            }
            IPEndPoint i = (IPEndPoint)clientSocket.RemoteEndPoint;
        }
    }
}
