using System;
using System.Numerics; 

namespace patterns
{
    class R_N
    {

        static Random _Rand = new Random(DateTime.Now.Minute);
        private BigInteger _result;
        public BigInteger _number;
        public bool InUse { get; set; }

        public BigInteger Value
        {
            get { return _result; }
            private set { _result = value; }
        }


        public R_N()
        {
            _number = (BigInteger)_Rand.Next(2, 10);
            _result = Factorial(_number);
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
