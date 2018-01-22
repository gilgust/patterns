using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var log = Logger.GetInstance();
               //log.Path = @"text_2.txt";

                log.LogText("Hello world");
                log.LogText("text text text");

                Console.WriteLine(log.ReadFile());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
