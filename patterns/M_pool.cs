using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace patterns
{
    class M_pool
    {
        private readonly IList<R_N> _randomNumbersList;

        public int _maxSize { get; private set; }
        public int _minSize { get; private set; }
        private Mutex _mutex = new Mutex();


        public M_pool(int minSize, int maxSize)
        {
            _maxSize = maxSize;
            _minSize = minSize;
            _randomNumbersList = new List<R_N>();
            for (int i = 0; i < _minSize; i++)
            {
                _randomNumbersList.Add(new R_N());
            }
        }

        private R_N CreateNumber()
        {
            if (_randomNumbersList.Count < _maxSize)
            {
                R_N number = new R_N();
                _randomNumbersList.Add(number);
                return number;
            }
            return null;
        }




        public R_N GetNumber()
        {
            R_N number = null;
            Thread a = new Thread(() =>
            {
                _mutex.WaitOne();
                while (true)
                {
                    number = _randomNumbersList.FirstOrDefault(x => !x.InUse);

                    if (number != null)
                    {
                        number.InUse = true;
                        break;
                    }

                    if (number == null && _randomNumbersList.Count == _maxSize)
                        Console.WriteLine("No free object");

                    if (number == null && _randomNumbersList.Count < _maxSize)
                    {
                        number = CreateNumber();

                        number.InUse = true;
                        break;
                    }
                    Thread.Sleep(100);
                }
                _mutex.ReleaseMutex();
            });

            return number;
        }





        public void ReleaseNumber(R_N num)
        {
            if (!_randomNumbersList.Contains(num))
                Console.WriteLine("the object don't below to list");

            num.InUse = false;
        }

        public void DeleteNumber(R_N num)
        {
            if (!_randomNumbersList.Contains(num))
                Console.WriteLine("the object don't below to list");

            if (_randomNumbersList.Count > _minSize)
            {
                _randomNumbersList.Remove(num);
                Console.WriteLine("the object deleted");
            }

            Console.WriteLine("the object cen't be deleted");
        }
    }
}
