using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using Newtonsoft.Json;
using NativeServer.socket.constant;
using System.IO;
using System.Net.Sockets;
using System.Net;
using NativeServer.handler;
using NativeServer.socket;
using NativeServer.socket.co;
using NativeServer.socket.co.cro;
using NativeServer.app;


namespace NativeServer
{
    public partial class ServerForm : Form
    {

        private Dictionary<int, Socket> clientMap = new Dictionary<int, Socket>();

        public ServerForm()
        {
            InitializeComponent();
            
            // 允许跨线程调用控件
            CheckForIllegalCrossThreadCalls = false;

            Thread t = new Thread(this.startServerSocket);
            t.Start();
        }

        private void startServerSocket()
        {
            // AppServer.initApp();
            ServerReceiveHandler receiveHandler = new ServerReceiveHandler(Receive);
            AcceptSocketHandler acceptHandler = new AcceptSocketHandler(accept);

            // 初始化Server Socket
            AsyncServerSocket.initSocketServer("127.0.0.1", 0, 
                receiveHandler, 
                delegate (int port) {
                    this.txtPort.Text = port + "";
                }, 
                acceptHandler);
        }

        private void accept(Socket socket)
        {
            int remotePort = ((IPEndPoint)socket.RemoteEndPoint).Port;
            if(!clientMap.ContainsKey(remotePort))
            {
                clientMap.Add(remotePort, socket);
                int index = this.cboClient.Items.Add(remotePort);
                this.cboClient.SelectedIndex = index;

            }
        }

        public void Receive(Socket socket, List<CommunicateVO> cos)
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

        private void dealCallExe(Socket socket, CallExeCo co)
        {

            CallExeServer exe = new CallExeServer();

            if (co.Async)
            {
                CallExeCro exeCro = new CallExeCro();

                string uuid = logReqMsg(socket, "exePath:" + co.ExePath + ", Args:" + string.Join(",", co.Args));
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

                        if (exeCro.Output != null && exeCro.Output.Length >= 1)
                        {
                            // 去除最后一个"\n"
                            exeCro.Output = exeCro.Output.Substring(0, exeCro.Output.Length - 1);
                        }

                        logResMsg(socket, "exitCode:"+ exeCro.ExitCode + ", output:"+ exeCro.Output, uuid);
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
        
        private string logReqMsg(Socket socket, string msg)
        {
            int port = ((IPEndPoint)socket.RemoteEndPoint).Port;
            string uuid = Guid.NewGuid().ToString();

            // [REQ][PORT][UUID]：MSG
            string fmsg = "[REQ]["+port+"]["+uuid+"]:" + msg ;
            txtMsg.Text += fmsg + Environment.NewLine;

            return uuid;
        }

        private void logResMsg(Socket socket, string msg, string uuid)
        {
            int port = ((IPEndPoint)socket.RemoteEndPoint).Port;
            // [RES][PORT][UUID]：MSG
            string fmsg = "[RES][" + port + "][" + uuid + "]:" + msg;
            txtMsg.Text += fmsg + Environment.NewLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientForm client = new ClientForm();
            client.Show();
        }

        private void dealDownloadFile(Socket socket, DownloadFileCo co)
        {
            DownloadFileServer server = new DownloadFileServer();

            string uuid = logReqMsg(socket, "URL:" + co.Url + ", savePath:" + co.SavePath);

            server.downloadFile(co.Url, co.SavePath, 
                delegate (DownloadFileCro cro)
                {
                    logResMsg(socket, "isSuccess:" + cro.IsSuccess + ", savePath:" + cro.LocalPath + ", Message:" + cro.Message , uuid);
                    // 异步调用结束
                    AsyncServerSocket.getInstance().Send(socket, cro);
                    server = null;
                });
        }

        private void dealOpenFile(Socket socket, OpenFileCo co)
        {
            OpenFileByDefaultApplicaitonServer.openFile(co.FilePath);
        }
    }
}
