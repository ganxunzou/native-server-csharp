using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeServer.socket.co;
using System.Net;
using System.Net.Sockets;


namespace NativeServer.socket
{
    /// <summary>
    /// 通讯接口
    /// </summary>
    public interface ICommunicate
    {
        /// <summary>
        /// 接收接口
        /// </summary>
        /// <param name="cos"></param>
        void Receive(Socket socket, List<CommunicateVO> cos);

        /// <summary>
        /// 发送接口
        /// </summary>
        /// <param name="co"></param>
        void Send(Socket socket, CommunicateVO co);
    }
}
