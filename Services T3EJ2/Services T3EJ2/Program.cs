using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Services_T3EJ2
{
    class Program
    {
        public static ArrayList users = new ArrayList();
        public static Object l = new object();
        static void Main(string[] args)
        {
            try
            {
                bool running = true;
                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 2609);
                Socket sockerServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sockerServer.Bind(iPEndPoint);
                sockerServer.Listen(0);
                while (running)
                {
                    Socket clientSocket = sockerServer.Accept();
                    Client c = new Client();
                    Thread threadCLient = new Thread(() => c.run(clientSocket));
                    threadCLient.Start();
                }
            }
            catch (Exception ex) when (ex is SocketException)
            {

            }
        }
    }
}
