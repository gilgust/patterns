using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortIntCollection
{
    class SortIntCollection : IEnumerable<int>
    {
        private int [] _ints = new int[0];
        private readonly IList<IObserver> _observers = new List<IObserver>(); 

        public int Length { get => _ints.Length;}

        public void Add(int Item)
        {
            Array.Resize( ref _ints, _ints.Length +1);
            _ints[_ints.Length - 1] = Item;
            Array.Sort(_ints);
            Notify();
        }

        public void Add(params int[] items)
        {
            int lengthCollection = Length - 1;
            Array.Resize( ref _ints, _ints.Length + items.Length);
            for (int i = 0; i < items.Length; i++, lengthCollection++)
            {
                _ints[lengthCollection + 1] = items[i];
            }
            Array.Sort(_ints);
            Notify();
        }

        public void Remove(int item)
        {
            int numIndex = Array.IndexOf(_ints, item);
            _ints = _ints.Where((val, idx) => idx != numIndex).ToArray();
            Array.Sort(_ints);
            Notify();
        }

        public int Get(int index)
        {
            return _ints[index];
        }

        //iterator
        public IEnumerator<int> GetEnumerator()
        {
            foreach (var item in _ints)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //observer
        public void Observe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void StopObserveing(IObserver observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.OnChange(this);
            }
        }
    }
}
