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

        /// <summary>
        /// 用于区分CommunicateVo 和 CommunicateReturnVo
        /// 因为JSON序列化后，无法区分CommunicateVo 和 CommunicateReturnVo
        /// </summary>
        private bool cro = true;

        public CommunicateReturnVO(CMType type): base(type)
        {

        }

        public bool Cro
        {
            get
            {
                return cro;
            }

            private set { }
        }
    }
}
