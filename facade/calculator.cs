using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade
{
    class Calculator
    {
        private readonly LogarithmSquareFactorial  _logarithmSquareFactorial= new LogarithmSquareFactorial();
        private readonly MultiplicationDivision _multiplicationDivision = new MultiplicationDivision();
        private readonly PlusMinus _plusMinus = new PlusMinus();
         
        public double Plus(double a, double b)
        {
            return _plusMinus.Plus(a, b);
        }

        public double Minus(double a, double b)
        {
            return _plusMinus.Plus(a, b);
        }
        public double Multiplication(double a, double b)
        {
            return _multiplicationDivision.Multiplication(a, b);
        }

        public double Division(double a, double b)
        {
            return _multiplicationDivision.Division(a, b);
        }
        public double Logarithm(double a)
        {
            return _logarithmSquareFactorial.Logarithm(a);
        }

        public double Square(double a)
        {
            return _logarithmSquareFactorial.Square(a);
        }

        public double Factorial(double a)
        {
            return _logarithmSquareFactorial.Factorial(a);
        }
    }
}
