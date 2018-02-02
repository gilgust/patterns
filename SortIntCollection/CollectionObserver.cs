using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortIntCollection
{
    class CollectionObserver : IObserver
    {
        public CollectionObserver(string name)
        {
            Name = name;
        }

        private string Name { get; set; }

        public void OnChange(SortIntCollection collection)
        {
            Console.WriteLine("{0} notified", Name);
        }
    }
}
