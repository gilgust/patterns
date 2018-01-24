using System;

namespace facade
{
    class LogarithmSquareFactorial
    { 
        public double Logarithm(double a)
        {
            return Math.Log(a);
        }

        public double Square(double a)
        {
            return Math.Sqrt(a);
        }

        public double Factorial(double a)
        {
            var buff = 1;
            for (int i = 1; i < a; i++)
            {
                buff *= i;
            }
            return buff;
        }
    }
}
