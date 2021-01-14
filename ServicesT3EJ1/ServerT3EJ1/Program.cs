using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ServerT3EJ1
{
    class Program
    {
        static bool running = true;
        static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any,2609);
            Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            socket.Bind(endPoint);
            socket.Listen(10);
            while (running)
            {
                Socket client = socket.Accept();
                Thread clientThread = new Thread(hilo);
                clientThread.Start(client);
            }
        }

        private static void hilo(Object client)
        {
            Socket clientSocket = (Socket)client;
            string request = null;
            using (NetworkStream ns = new NetworkStream(clientSocket))
            using (StreamReader reader = new StreamReader(ns))
            {
                using (StreamWriter writer = new StreamWriter(ns))
                {
                    DateTime dateTime;
                    try
                    {
                        writer.WriteLine("Bienvenido!");
                        writer.Flush();
                        request = reader.ReadLine();
                        switch (request)
                        {
                            case "hora":
                                dateTime = DateTime.Now;
                                writer.WriteLine(string.Format("{0}" + ':' + "{1}" + ':' + "{2}", dateTime.Hour, dateTime.Minute, dateTime.Second));
                                break;

                            case "fecha":
                                dateTime = DateTime.Now;
                                writer.WriteLine(string.Format("{0}/{1}/{2}", dateTime.Day, dateTime.Month, dateTime.Year));
                                break;

                            case "todo":
                                dateTime = DateTime.Now;
                                writer.WriteLine(string.Format("{0}/{1}/{2} {0}" + ':' + "{1}" + ':' + "{2}", dateTime.Day, dateTime.Month, dateTime.Year, dateTime.Hour, dateTime.Minute, dateTime.Second));
                                break;

                            case "apagar":
                                lock (client)
                                {
                                    running = false;
                                }
                                break;
                            default:
                                writer.WriteLine("404 Command not found");
                                break;
                        }
                        writer.Flush();
                    }
                    catch (IOException ex) when (ex is IOException)
                    {
                        Console.WriteLine("ERROR");
                    }
                    clientSocket.Close();
                }
            }
        }
    }
}
