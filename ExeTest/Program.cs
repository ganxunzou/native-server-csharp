using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
                Console.WriteLine("args:{0}", string.Join(",", args));

            Console.WriteLine("hello this is exe xxxx");

            
            Environment.Exit(0);
        }
    }
}
