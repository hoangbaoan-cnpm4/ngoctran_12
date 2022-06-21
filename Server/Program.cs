using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class Program
    {
        public static void Server()
        {
            try
            {
                IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
                TcpListener tcpListener = new TcpListener(iPAddress, 2507);
                tcpListener.Start();
                Console.WriteLine("Running ...");
                Console.WriteLine("Waiting ...");
                Socket socket = tcpListener.AcceptSocket();
                Console.WriteLine("Connected ...");
                byte[] send = new byte[1024];
                byte[] receive = new byte[1024];
                ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                List<int> a = new List<int>();
                while (true)
                {
                    int k = socket.Receive(receive);
                    if (k <= 0)
                    {
                        break;
                    }
                    string receiveNumber = aSCIIEncoding.GetString(receive, 0, k);
                    int n = Convert.ToInt32(receiveNumber);
                    if (n <= 3)
                    {
                        break;
                    }
                    a.Add(n);
                    Console.WriteLine(a.Max());

                }
                socket.Close();
                tcpListener.Stop();
                Console.ReadLine();
            }
            catch
            {

            }
        }
        static void Main(string[] args)
        {
            Server();
            Console.ReadLine();
        }
    }
}
