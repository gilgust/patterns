using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_fluent
{
    class TaxFreeDirector
    {
        private readonly ITaxFreeBuilder _TaxFreeBuilder;

        public TaxFreeDirector(ITaxFreeBuilder TFBuilder)
        {
            _TaxFreeBuilder = TFBuilder;
        }
        public string BuildTF()
        {
            return _TaxFreeBuilder.BuildPerson().BuildPassportID().BuildProductsList().BuildPercent().toPrint();
        }
    }
}
