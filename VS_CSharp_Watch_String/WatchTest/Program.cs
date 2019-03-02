using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WatchTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("zum.com", 80);

            byte[] httpRequest = Encoding.ASCII.GetBytes(@"GET / HTTP/1.1
Host: zum.com
Connection: keep - alive
Upgrade - Insecure - Requests: 1
User - Agent: Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 72.0.3626.119 Safari / 537.36
Accept: text / html,application / xhtml + xml,application / xml; q = 0.9,image / webp,image / apng,*/*;q=0.8
Accept-Encoding: gzip, deflate
Accept-Language: en-US,en;q=0.9,ko;q=0.8,ja;q=0.7" + "\r\n\r\n");

            socket.Send(httpRequest);
            var recvArg = new SocketAsyncEventArgs();
            recvArg.SetBuffer(new byte[0xFFFF], 0, 0xFFFF);
            recvArg.Completed += RecvArg_Completed;

            if (socket.ReceiveAsync(recvArg) == false)
            {
                RecvArg_Completed(socket, recvArg);
            }

            Console.ReadLine();
        }

        private static void RecvArg_Completed(object sender, SocketAsyncEventArgs e)
        {

        }
    }
}
