using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortIntCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCollection = new SortIntCollection();
            var observer_1 = new CollectionObserver("observer 1");
            var observer_2 = new CollectionObserver("observer 2");

            myCollection.Observe(observer_1);
            myCollection.Observe(observer_2);

            myCollection.Add(1);
            myCollection.Add(3);

            myCollection.StopObserveing(observer_2);

            myCollection.Add(1,8,3,0,7,6,2,5,9,4);

            foreach (var VARIABLE in myCollection)
            {
                Console.Write(VARIABLE);
            }
            Console.WriteLine();
            Console.WriteLine(" length = {0}", myCollection.Length);

            myCollection.Remove(4);
            foreach (var VARIABLE in myCollection)
            {
                Console.Write(VARIABLE);
            }
            Console.WriteLine();
            Console.WriteLine(" length = {0}", myCollection.Length);



            Console.ReadKey();
        }
    }
}
