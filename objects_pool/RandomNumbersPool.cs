using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading; 

namespace objects_pool
{
    class RandomNumbersPool
    {
         private readonly IList<RandomNumber> _randomNumbersList;

         public int _maxSize { get; private set; }
         public int _minSize { get; private set; }


        public RandomNumbersPool(int maxSize, int minSize)
        {
            _maxSize = maxSize;
            _minSize = minSize;
             _randomNumbersList = new List<RandomNumber>();
             for (int i = 0; i<maxSize; i++)
             { 
                 _randomNumbersList.Add(new RandomNumber());
             }
         }
 
         private RandomNumber CreateNumber()
         {
             if (_randomNumbersList.Count<_maxSize)
             {
                 RandomNumber number = new RandomNumber();
                 _randomNumbersList.Add(number);
                 return number;
             }
             return null;
         }
 



         public RandomNumber GetNumber()
         {
             RandomNumber number = _randomNumbersList.FirstOrDefault(x => !x.InUse); 

            if (number != null)
             {
                 number.InUse = true;
                 return number;
             }
 
             if (number == null && _randomNumbersList.Count == _maxSize)
                 Console.WriteLine("No free object");

             number = CreateNumber();

             number.InUse = true;
             return number;
         }




 
         public void ReleaseNumber(RandomNumber num)
         {
             if (!_randomNumbersList.Contains(num))
                 Console.WriteLine("the object don't below to list");

            num.InUse = false;
         }
 
         public void DeleteNumber(RandomNumber num)
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
