using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeServer.socket.constant;

namespace NativeServer.socket.co.cro
{
    /// <summary>
    /// 调用exe 返回对象
    /// </summary>
    public class CallExeCro : CommunicateReturnVO
    {
        private string output;
        private string error;
        private int exitCode;

        public CallExeCro() : base(CMType.CallExe)
        {

        }

        public string Output
        {
            get
            {
                return output;
            }

            set
            {
                output = value;
            }
        }

        public string Error
        {
            get
            {
                return error;
            }

            set
            {
                error = value;
            }
        }

        public int ExitCode
        {
            get
            {
                return exitCode;
            }

            set
            {
                exitCode = value;
            }
        }
    }
}
