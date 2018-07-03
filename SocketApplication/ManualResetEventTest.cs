using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SocketApplication
{
    class MyThread
    {
        Thread t = null;
        ManualResetEvent manualEvent = new ManualResetEvent(true);//为true,一开始就可以执行
        private void Run()
        {
            while (true)
            {
                Console.WriteLine("====================");
                Console.WriteLine("waitBe");
                this.manualEvent.WaitOne(5000);
                Console.WriteLine("线程id:{0}", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>");

                Thread.Sleep(2000);
            }
        }

        public void Start()
        {
            this.manualEvent.Set();
        }

        public void Stop()
        {
            this.manualEvent.Reset();
        }

        public MyThread()
        {
            t = new Thread(this.Run);
            t.Start();
        }

    }


    class ManualResetEventTest
    {
    }
}
