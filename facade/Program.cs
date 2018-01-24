using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
            var a = calc.Factorial(7);
            Console.WriteLine(a);
            a = calc.Division(34, 7);
            Console.Write(a);
            Console.ReadKey();
        }
    }
}
