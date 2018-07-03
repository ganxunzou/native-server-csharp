using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeServer.socket.co;
using NativeServer.socket.co.cro;
using System.Net.Sockets;

/// <summary>
/// 回调（托管）函数
/// </summary>
namespace NativeServer.handler
{
    /// <summary>
    /// Server Socket Delegate Handler
    /// </summary>
    /// <param name="cos"></param>
    public delegate void ServerReceiveHandler(Socket socket, List<CommunicateVO> cos);


    /// <summary>
    /// Async Call Eexe Delegate Output Handler
    /// </summary>
    /// <param name="cos"></param>
    public delegate void CallExeOutputHandler(string output);

    /// <summary>
    /// Async Call Eexe Delegate Error Handler
    /// </summary>
    /// <param name="cos"></param>
    public delegate void CallExeErrorHandler(string error);

    /// <summary>
    /// Async Call Eexe Delegate Error Handler
    /// </summary>
    /// <param name="cos"></param>
    public delegate void CallExeExitHandler(int exitCoe);


    /// <summary>
    /// Get Client Socket init Port
    /// </summary>
    /// <param name="cos"></param>
    public delegate void ClientSocketPortHandler(int port);


    /// <summary>
    /// Get Server Socket init Port
    /// </summary>
    /// <param name="cos"></param>
    public delegate void ServerSocketPortHandler(int port);

    /// <summary>
    /// Accept Client Socket
    /// </summary>
    /// <param name="cos"></param>
    public delegate void AcceptSocketHandler(Socket socket);


    /// <summary>
    /// Download File Handler 
    /// </summary>
    /// <param name="cos"></param>
    public delegate void DownloadFileHandler(DownloadFileCro cro);
}
