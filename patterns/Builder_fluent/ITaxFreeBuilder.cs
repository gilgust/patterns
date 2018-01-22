using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_fluent
{
    interface ITaxFreeBuilder
    {
        ITaxFreeBuilder BuildPerson( );
        ITaxFreeBuilder BuildPassportID( );
        ITaxFreeBuilder BuildProductsList( );
        ITaxFreeBuilder BuildPercent( );
        string toPrint();
    }
}
