using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var shool = new Shool();
            shool.Process_of_Aducation();

            var univer = new University();
            univer.Process_of_Aducation();

            Console.ReadKey();
        }
    }
}
