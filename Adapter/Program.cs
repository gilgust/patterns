using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {

            AdapterStr adapter = new AdapterStr("aaaAqqqEEEe");
            adapter.CountRepeats('a', 'b', 'e');
            Console.ReadKey();
        }
    }
}
