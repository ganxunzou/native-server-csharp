using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace SocketApplication
{
   
    public class Program
    {
        public enum Color
        {
            Red,
            Blue
        }

        static void Main(string[] args)
        {

            Color color = Color.Red;
            string red = Enum.GetName(typeof(Color), color);//推荐  
            Console.WriteLine(red == "Red");

            MyThread myt = new MyThread();
            while (true)
            {
                Console.WriteLine("输入 stop 后台线程挂起 start 开始执行！");
                string str = Console.ReadLine();
                if (str.ToLower().Trim() == "stop")
                {
                    Console.WriteLine("线程停止运行...\n");
                    myt.Stop();
                }
                if (str.ToLower().Trim() == "start")
                {
                    Console.WriteLine("线程开启运行...\n");
                    myt.Start();
                }
            }
        }
    }
}
