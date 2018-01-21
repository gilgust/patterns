using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace patterns
{
    class Program
    {
        static void Main(string[] args)
        {

            M_pool pool = new M_pool(2,3);
            List<R_N> _list = new List<R_N>();

            for (int i = 0; i < 4; i++)
            {
                var a = pool.GetNumber();
                if(a != null)
                    Console.WriteLine("a: {0} \n {1} \n {2}", a.InUse, a._number, a.Value);
                else
                {
                    Console.WriteLine("a = null");
                }
                _list.Add(a);
            }

            pool.ReleaseNumber(_list[0]);
            Console.WriteLine("{0} \n", _list[3].Value);


            Console.ReadLine();
        }
    }
}