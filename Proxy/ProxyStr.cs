using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class ProxyStr: NumberOfRepeats
    { 
        private AdapterStr _adapterStr;
        private string _proxyStr;
        public ProxyStr( string str)
        {
            _adapterStr = new AdapterStr(str);
            _proxyStr = str.ToUpper();
        }


        public void CountRepeats(params char[] letters)
        {
            _adapterStr.CountRepeats(letters);
        }

        public string Print()
        {
            return _proxyStr;
        }
    }
}
