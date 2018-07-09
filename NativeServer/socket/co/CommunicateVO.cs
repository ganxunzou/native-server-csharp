using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeServer.socket.constant;

namespace NativeServer.socket.co
{
    /// <summary>
    /// Socket 通讯VO
    /// CommunicateVo 简称 Co
    /// </summary>
    public class CommunicateVO
    {
        // CMType 枚举类
        public CMType cmType { get; private set; }

        public string Uuid
        {
            get
            {
                return uuid;
            }

            set
            {
                uuid = value;
            }
        }

        private string uuid;

        public CommunicateVO(CMType cmType)
        {
            this.cmType = cmType;
            this.uuid = Guid.NewGuid().ToString();
        }
    }
}
