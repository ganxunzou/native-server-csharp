using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeServer.socket.constant;

namespace NativeServer.socket.co.cro
{
    /// <summary>
    /// 通讯调用返回VO （cro : Communication Return VO 简写）
    /// </summary>
    public class CommunicateReturnVO : CommunicateVO
    {
        public CommunicateReturnVO(CMType type): base(type)
        {

        }
    }
}
