using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeServer.socket.constant;

namespace NativeServer.socket.co.cro
{
    //==============================================================
    //  作者：ganxunzou
    //  时间：2018/7/3 16:49:07
    //  说明： 
    //  修改者：
    //  修改说明： 
    //==============================================================
    public class DownloadFileCro : CommunicateReturnVO
    {
        private bool isSuccess;
        private string localPath;
        private string message;

        public DownloadFileCro() : base(CMType.DownloadFile)
        {

        }

        public bool IsSuccess
        {
            get
            {
                return isSuccess;
            }

            set
            {
                isSuccess = value;
            }
        }

        public string LocalPath
        {
            get
            {
                return localPath;
            }

            set
            {
                localPath = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }
    }
}
