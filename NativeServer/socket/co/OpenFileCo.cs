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
        private string filePath;

        public OpenFileCo() : base(CMType.OpenFile)
        {

        }

        public string FilePath
        {
            get
            {
                return filePath;
            }

            set
            {
                filePath = value;
            }
        }
    }
}
