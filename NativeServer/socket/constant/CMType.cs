using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NativeServer.socket.constant
{
    /// <summary>
    /// Communicate Type
    /// </summary>
    public enum CMType
    {
        SayHello = 0,
        CallExe = 1,
        DownloadFile = 2,
        OpenFile = 3,
    }
}
