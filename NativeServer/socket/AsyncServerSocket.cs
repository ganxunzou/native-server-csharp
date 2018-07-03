using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using NativeServer.exception;
using NativeServer.socket.utils;
using NativeServer.socket.co;
using NativeServer.handler;

namespace NativeServer.socket
{
    public class AsyncServerSocket: ICommunicate
    {
        // Thread signal.
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        public static int localPort = 0;
        private static AsyncServerSocket _asyncServer;
        //public static Dictionary<int, Socket> clientSockets { get; private set; }

        // server 接受消息回调函数
        private static ServerReceiveHandler _receiveHander;
        private static ServerSocketPortHandler _portHanlder;
        private static AcceptSocketHandler _acceptHandler;

        /// <summary>
        /// 私有构造函数，不允许直接new 实例化
        /// </summary>
        private AsyncServerSocket()
        {

        }

        /// <summary>
        /// 初始化Server Socket 服务
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="receiveHander"></param>
        public static void initSocketServer( string ip = "127.0.0.1", int port = 0, ServerReceiveHandler receiveHander = null, ServerSocketPortHandler portHanlder = null, AcceptSocketHandler acceptHandler = null)
        {
            if (null == _asyncServer)
            {
                _receiveHander = receiveHander;
                _portHanlder = portHanlder;
                _acceptHandler = acceptHandler;

                _asyncServer = new AsyncServerSocket();

                // clientSockets = new Dictionary<int, Socket>();

                _asyncServer.StartListening(ip, port);
            }
        }

        /// <summary>
        /// 获取Server Socket 实例
        /// </summary>
        /// <returns></returns>
        public static AsyncServerSocket getInstance()
        {
            if (_asyncServer == null)
                throw new ServerSocketNotInitException("Server Socket 未初始化，请调用initSocketServer静态方法进行初始化");

            return _asyncServer;
        }
       
        /// <summary>
        /// 启动Server Socket监听
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        private void StartListening(string ip = "127.0.0.1", int port = 0)
        {
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP socket.
            Socket serverSocket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                serverSocket.Bind(localEndPoint);
                localPort = ((IPEndPoint)serverSocket.LocalEndPoint).Port;
                Console.WriteLine("server socket listen port: {0}", localPort);
                if(_portHanlder != null)
                {
                    _portHanlder(localPort);
                }
                serverSocket.Listen(localPort);

                while (true)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    Console.WriteLine("Waiting for a connection...");
                    serverSocket.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        serverSocket);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        /// <summary>
        /// 接收Client Socket 链接
        /// </summary>
        /// <param name="ar"></param>
        private void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // int remotePort = ((IPEndPoint)handler.RemoteEndPoint).Port;
            //if (!clientSockets.ContainsKey(remotePort))
            //{
            //    clientSockets.Add(remotePort, handler);
            //}
            if(_acceptHandler != null)
            {
                _acceptHandler(handler);
            }

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReceiveCallback), state);
        }

        /// <summary>
        /// 接收 Client Socket 数据
        /// 私有函数不对外直接提供。
        /// 使用Receive(Socket socket, List<CommunicateVO> cos)接口监听数据
        /// </summary>
        /// <param name="ar"></param>
        private void ReceiveCallback(IAsyncResult ar)
        {
            String content = String.Empty;
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
 
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));
                content = state.sb.ToString();

                // 是否有结束标签
                if (content.IndexOf("####") > -1)
                {
                    List<CommunicateVO> cos = CommunicateUtils.strToCommunicateVos(content);
                    Receive(handler, cos);

                    // 重置数据传输对象
                    state.cleanData();
                }
            }

            // 继续获取数据
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);

        }

        /// <summary>
        /// 给Client Socket 发送数据
        /// 私有函数，不允许直接调用
        /// 采用Send(Socket, CommunicateVO)强制格式化传输数据
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="data"></param>
        private void Send(Socket handler, String data)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(data);
            handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
        }

        /// <summary>
        /// 异步发送回到函数
        /// </summary>
        /// <param name="ar"></param>
        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                // 释放链接。Server Socket 不主动释放客户端连接。保持长连接方式
                // handler.Shutdown(SocketShutdown.Both);
                // handler.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw e;
            }
        }

        /// <summary>
        /// 接收Client Socket 数据
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="cos"></param>
        public void Receive(Socket socket, List<CommunicateVO> cos)
        {
            if (_receiveHander != null)
                _receiveHander.Invoke(socket, cos);
        }

        /// <summary>
        /// 向Client Socket 发送数据
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="co"></param>
        public void Send(Socket socket, CommunicateVO co)
        {
            string data = CommunicateUtils.communicateVoToStr(co);
            Send(socket, data);
        }
    }
}
