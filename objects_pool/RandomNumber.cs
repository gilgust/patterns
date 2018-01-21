using System;
using System.Numerics;

namespace objects_pool
{
    class RandomNumber
    {
        private static readonly Random Rand = new Random(DateTime.Now.Minute);
        public bool InUse { get; set; }

        public BigInteger Value { get; private set; }


        public RandomNumber()
        {
            var number = (BigInteger)Rand.Next(100,10000);
            Value = Factorial(number);
            InUse = false;

        }


     
        private BigInteger Factorial(BigInteger input)
        {
            BigInteger result = 1;
            for (int i = 2; i <= input; ++i)
                result *= i;
            return result;
        }

    }
}
