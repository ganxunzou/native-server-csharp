using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fleck;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    public class user
    {
        public string uid { get; set; }
        public string pwd { get; set; }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Fleck
            var server = new WebSocketServer("ws://127.0.0.1:8181");
            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {

                    Console.WriteLine("Open!");
                    socket.Send("hello");
                };

                socket.OnClose = () => Console.WriteLine("Close!");
                socket.OnMessage = message =>
                {
                    Console.WriteLine(message);
                    //尝试用websocket进行登录
                    dynamic o = JsonConvert.DeserializeObject<user>(message);
                    var pwd = o.pwd;
                    var uid = o.uid;
                    if (uid == "admin" && uid == "admin")
                    {
                        socket.Send("login success");
                    }
                    else
                    {
                        socket.Send("login fail");
                    }

                };

            });

        }
    }
}
