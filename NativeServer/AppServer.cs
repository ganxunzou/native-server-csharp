using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeServer.socket;
using NativeServer.socket.co;
using NativeServer.handler;

namespace NativeServer
{
    public class AppServer
    {
        public static void initApp()
        {
            ServerReceiveHandler handler = new ServerReceiveHandler(Receive);
            // 初始化Server Socket
            AsyncServerSocket.initSocketServer("127.0.0.1", 0, handler);
        }

        public static void Receive(List<CommunicateVO> cos)
        {
            Console.WriteLine("aaaa", cos.Count);
        }

    }
}
