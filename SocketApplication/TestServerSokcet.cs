using System.Runtime.InteropServices;
using System.Collections;
using System.IO;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace testProject
{



    

 

 

public static class GlobalVar

    {

        public static string IPAddress = "";

        public static int TCPPort = 5001;

        public static IntPtr DataToClientStructPtr; //Pointer to Structure that holds actual data to send.

    }





    public class StateObject

    {

        public Socket workSocket = null;

        public const int BufferSize = 1024;

        public byte[] DataToSend = new byte[BufferSize];

        public byte[] DataToReceive = new byte[BufferSize];

        public int DataType; //A field in the Structure that holds actual data.

        //All data sent to and received from client is stored in Structures, each Struct has an Int DataType 
        //as first field to identify the type of information being sent/received(packets) and process is accordingly.



    }



    public class IPsFunction

    {

        public static void InterfaceIPs()

        {

            UnicastIPAddressInformationCollection IPs;

            NetworkInterface[] Interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface Interface in Interfaces)

            {

                IPInterfaceProperties InterfaceProperties = Interface.GetIPProperties();

                IPs = InterfaceProperties.UnicastAddresses;

                if (IPs.Count > 0)

                {

                    foreach (UnicastIPAddressInformation ip in IPs)

                    {



                        GlobalVar.IPAddress = ip.Address.ToString();//If just one IP (127.0.0.1)

                        //IPAddress LocalIP = IPAddress.Parse(ip.Address.ToString());

                        //comboBox2.Items.Add(LocalIP.ToString());  //Add in list box to select if more than one.

                    }

                }

            }

        }

    }





    public class Server

    {

        public static ManualResetEvent Signal = new ManualResetEvent(false); // Thread signal.

        public Server()

        {

        }



        public static void StartListening()

        {

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse(GlobalVar.IPAddress), GlobalVar.TCPPort);

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try

            {

                listener.Bind(localEndPoint);

                listener.Listen(100);

                while (true)

                {

                    Signal.Reset();

                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);

                    Signal.WaitOne();

                }

            }

            catch (Exception e)

            {

                //

            }

        }



        public static void AcceptCallback(IAsyncResult ar)

        {

            Signal.Set();

            Socket listener = (Socket)ar.AsyncState;

            Socket handler = listener.EndAccept(ar);

            StateObject state = new StateObject();

            state.workSocket = handler;

            handler.BeginReceive(state.DataToReceive, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);

        }

        unsafe public static void ReadCallback(IAsyncResult ar)

        {

            StateObject state = (StateObject)ar.AsyncState;

            Socket handler = state.workSocket;

            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)

            {

                fixed (byte* TempPtr = state.DataToReceive)

                    state.DataType = *(int*)TempPtr;

                if (state.DataType > 10 && state.DataType < 19)

                {

                    if ((state.DataType == 11))

                    {

                        //Int 11 specifies that a specific data is requested, copy specific data from the respective structure.

                        Marshal.Copy(GlobalVar.DataToClientStructPtr, state.DataToSend, 0, GlobalVar.DataLenght);

                        Send(handler, state);

                    }

                    if (state.DataType == 13)

                    {

                        //Copy something else and send, or run any other function

                        Send(handler, state);

                    }

                }

            }

            handler.BeginReceive(state.DataToReceive, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);

        }



        private static void Send(Socket handler, StateObject state)

        {

            handler.BeginSend(state.DataToSend, 0, state.DataToSend.Length, 0, new AsyncCallback(SendCallback), handler); //Loop, Go back to read next request from client



        }



        private static void SendCallback(IAsyncResult ar)

        {

            try

            {

                Socket handler = (Socket)ar.AsyncState;



            }

            catch (Exception e)

            {

                //

            }

        }

    }

}

