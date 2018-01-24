using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Detector dt = new Detector();
            RandNumber rn= new RandNumber(dt);

            for (int i = 0; i < 10; ++i)
            {
                Console.WriteLine(dt.Value);
                Thread.Sleep(1200);
            }
        }
    }
}
