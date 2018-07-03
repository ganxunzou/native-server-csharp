using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeServer.socket.constant;

namespace NativeServer.socket.co
{
    /// <summary>
    /// CMType OpenFile
    /// </summary>
    public class OpenFileCo : CommunicateVO
    {
        public OpenFileCo() : base(CMType.OpenFile)
        {

        }
    }
}
