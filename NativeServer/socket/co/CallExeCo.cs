using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeServer.socket.constant;

namespace NativeServer.socket.co
{
    /// <summary>
    /// CMType = CallExe
    /// </summary>
    public class CallExeCo : CommunicateVO
    {
        
        public CallExeCo() : base(CMType.CallExe)
        {

        }
    }
}
