using System; 
using System.Linq; 

namespace Adapter
{
    internal class AdapterStr: NumberOfRepeats
    {
        private readonly string _str;

        public AdapterStr(string str)
        {
            _str = str;
        }

        public void CountRepeats(params char[] letters)
        {
            string buf = _str.ToLower();
            int count = 0;

            for (int i = 0; i < letters.Length; ++i)
            {
                count += buf.Count(c => c.Equals(letters[i]));
                Console.WriteLine("{0} ---- {1}", letters[i], count);
                count = 0;
            }
        }
    }
}
