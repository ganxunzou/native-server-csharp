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
        // exe 路径
        private string exePath;
        
        /// <summary>
        /// 注意，这种方式相当于命令行的方式调用，因此参数格式有长度限制
        /// 需要有程序本身调整。
        /// 调整方案：
        ///   （C/S架构）: 将参数写入到临时文件中，Exe从临时文件中读取
        ///   （B/S架构）：带优化（TODO）
        /// </summary>
        private string[] args;

        // exe 调用方式，默认异步调用
        private bool async = true;

        public string ExePath
        {
            get
            {
                return exePath;
            }

            set
            {
                exePath = value;
            }
        }

        public string[] Args
        {
            get
            {
                return args;
            }

            set
            {
                args = value;
            }
        }

        public bool Async
        {
            get
            {
                return async;
            }

            set
            {
                async = value;
            }
        }

        public CallExeCo() : base(CMType.CallExe)
        {

        }
    }
}
