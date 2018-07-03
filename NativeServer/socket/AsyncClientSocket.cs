using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using NativeServer.socket.co;
using NativeServer.exception;
using NativeServer.socket.utils;
using NativeServer.handler;


namespace NativeServer.socket
{
    /// <summary>
    /// 测试用的Client Socket 
    /// TODO: 未进行结构化设计
    /// </summary>
    public class AsyncClientSocket : ICommunicate
    {
        // ManualResetEvent instances signal completion.
        private ManualResetEvent connectDone =  new ManualResetEvent(false);
        private ManualResetEvent sendDone = new ManualResetEvent(false);
        private ManualResetEvent receiveDone = new ManualResetEvent(false);

        private Socket socket;

        public void createSocketConnect(string ip = "127.0.0.1", int port = 0, ClientSocketPortHandler portHandler = null)
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(ip);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP socket.
                socket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);


                // Connect to the remote endpoint.
                socket.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), socket);

                int localPort = ((IPEndPoint)socket.LocalEndPoint).Port;
                if (portHandler != null)
                {
                    portHandler(localPort);
                }

                connectDone.WaitOne();

                // Send test data to the remote device.
                //Send(client, "This is a test<EOF>");
                //sendDone.WaitOne();

                // Receive the response from the remote device.
                Receive(socket);
                receiveDone.WaitOne();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void Receive(Socket client)
        {
            try
            {
                // Create the state object.
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0 )
                {
                    state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));
                    string content = state.sb.ToString();
                    if (content.IndexOf("####") > -1)
                    {
                        List<CommunicateVO> cos = CommunicateUtils.strToCommunicateVos(content);
                        Receive(client, cos);
                    }
                    else
                    {
                        // Get the rest of the data.
                        client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                    }
                        
                }
                else
                {
                    //string content = state.sb.ToString();
                    //if (content.IndexOf("####") >= 0)
                    //{
                    //    List<CommunicateVO> cos = CommunicateUtils.strToCommunicateVos(content);
                    //    Receive(client, cos);
                    //}

                    // Signal that all bytes have been received.
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            
            // Begin sending the data to the remote device.
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Receive(Socket socket, List<CommunicateVO> cos)
        {
            Console.WriteLine("aaaa", cos.Count);   
        }

        public void Send(Socket socket, CommunicateVO co)
        {
            string data = CommunicateUtils.communicateVoToStr(co);
            Send(socket, data);
        }

        public void Send(CommunicateVO co)
        {
            Send(socket, co);
        }
    }
}
