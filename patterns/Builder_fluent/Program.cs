using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_fluent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            List<Product> LP_1 = new List<Product> {
                new Product { _Name = "glasses", Price = 100M } ,
                new Product { _Name = "mobile", Price = 500M } };

            Check ch_1 = new Check();
            ch_1._Person = "Adam Smit";
            ch_1._PassportID = Guid.NewGuid().ToString();
            ch_1._LP = LP_1;
            ch_1._Percent = 13.5D;

            TaxFreeBuilder TF = new TaxFreeBuilder(ch_1);
            TaxFreeDirector director = new TaxFreeDirector(TF);

            Console.WriteLine(director.BuildTF());
            Console.ReadKey();
        }
    }
}
