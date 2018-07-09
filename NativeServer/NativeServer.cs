using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fleck;
using System.Net.Sockets;
using System.Threading;
using NativeServer.app;
using NativeServer.socket.co;
using NativeServer.socket.co.cro;
using NativeServer.socket.utils;
using System.Net;

namespace NativeServer
{
    public partial class NativeServer : Form
    {
        private const int PORT = 8181;
        private const string ADDRESS = "127.0.0.1";

        private bool allowShowDiaplay = false;

        private Dictionary<int, IWebSocketConnection> clientMap = new Dictionary<int, IWebSocketConnection>();
        

        public NativeServer()
        {
            InitializeComponent();

            allowShowDiaplay = false;

            // 允许跨线程调用控件
            CheckForIllegalCrossThreadCalls = false;

            initServer(ADDRESS, PORT);

        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(allowShowDiaplay ? value : allowShowDiaplay);
        }

        public void initServer(string ip, int port)
        {
            var server = new WebSocketServer(string.Format("ws://{0}:{1}", ip, port));
            server.RestartAfterListenError = true;
            server.Start(socket =>
            {
                socket.OnOpen = () => 
                {
                    if (!clientMap.ContainsKey(socket.ConnectionInfo.ClientPort))
                    {
                        clientMap.Add(socket.ConnectionInfo.ClientPort, socket);
                    }
                };
                socket.OnClose = () =>
                {
                    if (clientMap.ContainsKey(socket.ConnectionInfo.ClientPort))
                    {
                        clientMap.Remove(socket.ConnectionInfo.ClientPort);
                    }
                };
                socket.OnMessage = message => 
                {
                    Console.WriteLine("OnMessage", socket.ConnectionInfo);
                    List<CommunicateVO> cos = CommunicateUtils.strToCommunicateVos(message);
                    Receive(socket, cos);
                };
            });

        }

        public void Receive(IWebSocketConnection socket, List<CommunicateVO> cos)
        {
            foreach (CommunicateVO co in cos)
            {
                if (co is CallExeCo)
                {
                    dealCallExe(socket, co as CallExeCo);
                }
                else if (co is DownloadFileCo)
                {
                    dealDownloadFile(socket, co as DownloadFileCo);
                }
                else if(co is OpenFileCo)
                {
                    dealOpenFile(socket, co as OpenFileCo);
                }
            }
        }

        private void dealCallExe(IWebSocketConnection socket, CallExeCo co)
        {

            // exe 调用服务
            CallExeServer exeServer = new CallExeServer();

            // 响应数据对象
            CallExeCro exeCro = new CallExeCro();
            exeCro.Uuid = co.Uuid;

            if (co.Async)
            {
               

                logReqMsg(socket, "exePath:" + co.ExePath + ", Args:" + string.Join(",", co.Args), co.Uuid);
                // CallExeOutputHandler outputHandler = new CallExeOutputHandler();
                // async
                exeServer.asyncCallExe(co.ExePath, co.Args,
                    output =>
                    {
                        Console.WriteLine("output：" + output);
                        // 每次只输出一行，因此需要动态添加"\n"
                        exeCro.Output += output + "\n";
                    },
                    exitCode => 
                    {
                        Console.WriteLine("exitCode:" + exitCode);
                        exeCro.ExitCode = exitCode;

                        if (exeCro.Output != null && exeCro.Output.Length >= 1)
                        {
                            // 去除最后一个"\n"
                            exeCro.Output = exeCro.Output.Substring(0, exeCro.Output.Length - 1);
                        }

                        // logResMsg(socket, "exitCode:"+ exeCro.ExitCode + ", output:"+ exeCro.Output, co.Uuid);
                        // 异步调用结束
                        socket.Send(CommunicateUtils.communicateVoToStr(exeCro));
                    },
                    error =>
                    {
                        Console.WriteLine("error:" + error);
                        exeCro.Error += error;
                    });
            }
            else
            {
                // sync
                string[] ret = exeServer.syncCallExe(co.ExePath, co.Args);
                Console.WriteLine("exitCode:{0}, ouput:{1}, error:{2}", ret[0], ret[1], ret[2]);

                exeCro.ExitCode = int.Parse(ret[0]);
                exeCro.Output = ret[1];
                exeCro.Error = ret[2];

                socket.Send(CommunicateUtils.communicateVoToStr(exeCro));
            }
        }
        
        private void logReqMsg(IWebSocketConnection socket, string msg, string uuid)
        {


            int port = PORT;
            // string uuid = Guid.NewGuid().ToString();

            // [REQ][PORT][UUID]：MSG
            string fmsg = "[REQ]["+port+"]["+uuid+"]:" + msg ;
            txtMsg.Text += fmsg + Environment.NewLine;

            //return uuid;
        }

        private void logResMsg(string msg, string uuid)
        {
            int port = PORT;
            // [RES][PORT][UUID]：MSG
            string fmsg = "[RES][" + port + "][" + uuid + "]:" + msg;
            txtMsg.Text += fmsg + Environment.NewLine;
        }
        
        private void dealDownloadFile(IWebSocketConnection socket, DownloadFileCo co)
        {
            DownloadFileServer server = new DownloadFileServer();
            

            logReqMsg(socket, "URL:" + co.Url + ", savePath:" + co.SavePath, co.Uuid);

            server.downloadFile(co.Url, co.SavePath, 
                delegate (DownloadFileCro cro)
                {
                    cro.Uuid = co.Uuid;

                    logResMsg("isSuccess:" + cro.IsSuccess + ", savePath:" + cro.LocalPath + ", Message:" + cro.Message , co.Uuid);
                    // 异步调用结束
                    socket.Send(CommunicateUtils.communicateVoToStr(cro));
                    server = null;
                });
        }

        private void dealOpenFile(IWebSocketConnection socket, OpenFileCo co)
        {
            OpenFileByDefaultApplicaitonServer.openFile(co.FilePath);
        }
    }
}
