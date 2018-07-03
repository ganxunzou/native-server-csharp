using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeServer.socket.co;

/// <summary>
/// 回调（托管）函数
/// </summary>
namespace NativeServer.handler
{
    /// <summary>
    /// Server Socket Delegate Handler
    /// </summary>
    /// <param name="cos"></param>
    public delegate void ServerReceiveHandler(List<CommunicateVO> cos);

}
