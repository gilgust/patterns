using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxyStr = new ProxyStr("aaaAqqqEEEe");
            proxyStr.CountRepeats('a', 'b', 'e');

            Console.WriteLine(proxyStr.Print());


            Console.ReadKey();
        }
    }
}
