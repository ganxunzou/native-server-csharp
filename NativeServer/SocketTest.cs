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

namespace NativeServer
{
    public partial class SocketTest : Form
    {
        public SocketTest()
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
            AsyncClientSocket.initClientSocket("127.0.0.1", AsyncServerSocket.localPort);
            //AsyncClientSocket.StartClient("127.0.0.1", AsyncServerSocket.localPort);
        }

        private void btnSayHello_Click(object sender, EventArgs e)
        {
            SayHelloCo co = new SayHelloCo();
            AsyncClientSocket.getInstance().Send(co);
        }
    }
}
