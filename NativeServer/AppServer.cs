using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeServer.socket;
using NativeServer.socket.co;
using NativeServer.socket.co.cro;
using NativeServer.handler;
using NativeServer.app;
using System.Net.Sockets;

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

        public static void Receive(Socket socket, List<CommunicateVO> cos)
        {
            foreach (CommunicateVO co in cos)
            {
                if(co is CallExeCo)
                {
                    dealCallExe(socket, co as CallExeCo);
                }
                else if(co is DownloadFileCo)
                {

                }
            }
        }

        private static void dealCallExe(Socket socket, CallExeCo co)
        {

            CallExeServer exe = new CallExeServer();

            if (co.Async)
            {
                CallExeCro exeCro = new CallExeCro();

                // CallExeOutputHandler outputHandler = new CallExeOutputHandler();
                // async
                exe.asyncCallExe(co.ExePath, co.Args, 
                    delegate (string output)
                    {
                        Console.WriteLine("output：" + output);
                        // 每次只输出一行，因此需要动态添加"\n"
                        exeCro.Output += output + "\n";
                    },
                    delegate (int exitCode)
                    {
                        Console.WriteLine("exitCode:" + exitCode);
                        exeCro.ExitCode = exitCode;

                        if(exeCro.Output != null && exeCro.Output.Length >= 1)
                        {
                            // 去除最后一个"\n"
                            exeCro.Output = exeCro.Output.Substring(0, exeCro.Output.Length - 1);
                        }
                        // 异步调用结束
                        AsyncServerSocket.getInstance().Send(socket, exeCro);
                    },
                    delegate (string error)
                    {
                        Console.WriteLine("error:" + error);
                        exeCro.Error += error;
                    });
                //string[] ret = exe.asyncCallExe(co.ExePath, co.Args,null);
            }
            else
            {
                // sync
                string[] ret = exe.syncCallExe(co.ExePath, co.Args);
                Console.WriteLine("exitCode:{0}, ouput:{1}, error:{2}", ret[0], ret[1], ret[2]);


                CallExeCro exeCro = new CallExeCro();
                exeCro.ExitCode = int.Parse(ret[0]);
                exeCro.Output = ret[1];
                exeCro.Error = ret[2];
                AsyncServerSocket.getInstance().Send(socket, exeCro);

            }
        }
    }
}
