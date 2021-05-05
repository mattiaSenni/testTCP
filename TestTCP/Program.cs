using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace TestTCP
{
    class Program
    {
        static int port = 2021; 
        static void Main(string[] args)
        {
            bool tuaMamma = true;
            while(tuaMamma)
            {
                //Console.Clear();
                Console.WriteLine("insersci il messaggio : [ip] [porta] [messaggio]");
                string[] mex = Console.ReadLine().Split(' ');
                string ip = mex[0];
                int porta = int.Parse(mex[1]);
                string message = mex[2] + " " + mex[3];
                byte[] data = Encoding.ASCII.GetBytes(message);

                Socket s = new Socket(SocketType.Stream, ProtocolType.IP);
                s.Connect(IPAddress.Parse(ip), porta);
                //s.Bind(new IPEndPoint(IPAddress.Any, porta));

                for (int i = 0; i < data.Length;)
                    i += s.Send(data, i, data.Length - i, SocketFlags.None);
            }
        }
    }
}
