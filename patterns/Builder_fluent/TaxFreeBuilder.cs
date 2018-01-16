using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_fluent
{
    class TaxFreeBuilder: ITaxFreeBuilder
    {
        private Check _check;
        StringBuilder _checkToPrint = new StringBuilder();

        public TaxFreeBuilder( Check check)
        {
            _check = check;
        }

        public ITaxFreeBuilder BuildPerson( )
        {
            _checkToPrint.Append(_check._Person + Environment.NewLine);
            return this;
        }
        public ITaxFreeBuilder BuildPassportID( )
        {
            _checkToPrint.Append(_check._PassportID + Environment.NewLine);
            return this;
        }

        public ITaxFreeBuilder BuildProductsList( )
        {
            foreach (var product in _check._LP)
            {
                _checkToPrint.Append(product._Name + "\t" + product.Price.ToString() + Environment.NewLine);
            }
            return this;
        }

        public ITaxFreeBuilder BuildPercent( )
        {
            _checkToPrint.Append(_check._Percent + Environment.NewLine);
            return this;
        }

        public string toPrint()
        {

            return _checkToPrint.ToString();
        }
    }
}
