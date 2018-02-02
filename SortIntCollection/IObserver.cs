using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortIntCollection
{
    interface IObserver
    {
        void OnChange(SortIntCollection collection);
    }
}
