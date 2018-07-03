using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeServer.socket.constant;

namespace NativeServer.socket.co
{
    /// <summary>
    /// CMType SayHello
    /// </summary>
    public class SayHelloCo : CommunicateVO
    {
        public SayHelloCo() : base(CMType.SayHello)
        {

        }
    }
}
