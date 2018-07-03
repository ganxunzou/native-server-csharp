using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NativeServer.socket;
using System.Threading;
using NativeServer.socket.co;
using Newtonsoft.Json;
using NativeServer.socket.constant;
using System.IO;

namespace NativeServer
{
    public partial class SocketForm : Form
    {

        private Dictionary<int, AsyncClientSocket> clientMap = new Dictionary<int, AsyncClientSocket>();

        public SocketForm()
        {
            InitializeComponent();

            // 允许跨线程调用控件
            CheckForIllegalCrossThreadCalls = false;

            Thread t = new Thread(this.startServerSocket);
            t.Start();
        }

        private void startServerSocket()
        {
            AppServer.initApp();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(this.startClientSocket);
            t.Start();
        }

        
        private void startClientSocket()
        {
            this.txtPort.Text = AsyncServerSocket.localPort+"";
            AsyncClientSocket client = new AsyncClientSocket();
            client.createSocketConnect("127.0.0.1", AsyncServerSocket.localPort, 
                delegate (int port) {
                    int index = cboClient.Items.Add(port);
                    cboClient.SelectedIndex = index;

                    clientMap.Add(port, client);
                });
            
            // AsyncClientSocket.initClientSocket("127.0.0.1", AsyncServerSocket.localPort);
            //AsyncClientSocket.StartClient("127.0.0.1", AsyncServerSocket.localPort);
        }

        private void btnSayHello_Click(object sender, EventArgs e)
        {
            SayHelloCo co = new SayHelloCo();

            int port = int.Parse(cboClient.SelectedItem.ToString());
            clientMap[port].Send(co);

        }

        private void btnCallExe_Click(object sender, EventArgs e)
        {
            CallExeCo co = new CallExeCo();
            string exePath = txtExePath.Text;
            if (!File.Exists(exePath))
            {
                exePath = System.Windows.Forms.Application.StartupPath + "/" + exePath;
            }

            co.ExePath = exePath;
            co.Args = txtExeArgs.Text.Split(',');
            //co.Async = false;

            int port = int.Parse(cboClient.SelectedItem.ToString());
            clientMap[port].Send(co);
        }
    }
}
