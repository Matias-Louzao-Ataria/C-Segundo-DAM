using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ServerT3EJ1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any,2609);
            Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            socket.Bind(endPoint);
            socket.Listen(1);
            Socket client = socket.Accept();
            using (NetworkStream ns = new NetworkStream(client))
            using (StreamReader reader = new StreamReader(ns))
            {
                using (StreamWriter writer = new StreamWriter(ns))
                {
                    writer.WriteLine("Hey from socket!");
                    writer.Flush();
                    Console.WriteLine(reader.ReadLine());
                }
            }
            client.Close();
            socket.Close();
            Console.ReadKey();
        }
    }
}
