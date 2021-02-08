using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServicesT2EJ3
{
    class Program
    {
        public static bool running = true;
        public static Random randomN = new Random();
        public static ArrayList players = new ArrayList();
        public static Object l = new Object();
        public static int countDown = 2;
        public static Client contador = null;

        static void Main(string[] args)
        {
            try
            {
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 2609);
                Socket serverSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(serverEndPoint);
                serverSocket.Listen(10);
                while (Program.running)
                {
                    Socket socketClient = serverSocket.Accept();
                    if (countDown == 0)
                    {
                        countDown = 2;
                    }
                    Client client = new Client();
                    Thread clientThread = new Thread(() => client.run(socketClient));
                    clientThread.Start();
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Server error!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
