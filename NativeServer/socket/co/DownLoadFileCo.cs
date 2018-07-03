using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeServer.socket.constant;

namespace NativeServer.socket.co
{
    public class DownloadFileCo : CommunicateVO
    {
        private string url;
        private string savePath;

        public DownloadFileCo() : base(CMType.DownloadFile)
        {

        }

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public string SavePath
        {
            get
            {
                return savePath;
            }

            set
            {
                savePath = value;
            }
        }

       
    }
}
