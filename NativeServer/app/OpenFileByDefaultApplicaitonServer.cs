using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NativeServer.app
{
    //==============================================================
    //  作者：ganxunzou
    //  时间：2018/7/3 18:31:18
    //  说明： 
    //  修改者：
    //  修改说明： 
    //==============================================================
    public class OpenFileByDefaultApplicaitonServer
    {
        public static void openFile(string path)
        {
            if (File.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
            }
            else
            {
                Console.WriteLine("file exist:"+ path);
            }
           
        }
    }
}
