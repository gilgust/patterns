using System;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var shool_1 = new Shool("школа №7");
            var shool_2 = new Shool("школа №28");
            var shool_3 = new Shool("школа №126");
            var shool_4 = new Shool("школа №38");
            

            var univer_1 = new University("БНТУ");
            var univer_2 = new University("РТИ");

            var list = new List(shool_1,shool_2,shool_3,shool_4,univer_1, univer_2);
            Console.WriteLine("Iterator:");
            var iterator = list.CreateIterator();
            while (!iterator.IsDone)
            {
                Console.WriteLine(iterator.Current.Name);
                iterator.MoveNext();
            }


            Console.ReadKey();
        }
    }
}
