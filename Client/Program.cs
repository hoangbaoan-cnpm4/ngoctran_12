using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    class Program
    {
        public static void Client()
        {
            TcpClient tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect("127.0.0.1", 2507);
                Console.WriteLine("Connected");
                Stream stream = tcpClient.GetStream();
                byte[] send = new byte[1024];
                byte[] receive = new byte[1024];
                ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
                Random rd = new Random();
                while (true)
                {
                    int n = rd.Next(1, 100);
                    Console.WriteLine(n);
                    if (n <= 3)
                    {
                        break;
                    }
                    string sendNumber = n.ToString();
                    send = aSCIIEncoding.GetBytes(sendNumber);
                    stream.Write(send, 0, send.Length);
                }
                tcpClient.Close();
                Console.ReadLine();
            }
            catch
            {

            }
        }
        static void Main(string[] args)
        {
            Client();
            Console.ReadLine();
        }
    }
}
