using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var t = Task.Run(new Action(StartListen));

            Console.Read();
        }

        public static void StartListen()
        {
            Socket listenfd = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //根据IP地址创建IPAddress对象
            IPAddress ipAdr = IPAddress.Parse("127.0.0.1");

            //用IPAddress指定的地址和端口初始化；
            IPEndPoint ipEp = new IPEndPoint(ipAdr, 1234);

            //给套接字绑定IP和端口
            listenfd.Bind(ipEp);
            //开始监听，等待客户端连接；
            listenfd.Listen(0);

            while (true)
            {
                //接收

                //Accept
                Socket connfd = listenfd.Accept();
                Console.WriteLine("[服务器]Accept");
                //Recv
                byte[] readBuff = new byte[1024];
                int count = connfd.Receive(readBuff);
                string str = System.Text.Encoding.UTF8.GetString(readBuff, 0, count);
                Console.WriteLine("[服务器接收]" + str);
                //Send
                byte[] bytes = System.Text.Encoding.Default.GetBytes("serv echo " + str);
                connfd.Send(bytes);
            }
        }
    }
}
