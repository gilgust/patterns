using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Logger
    {
        private static readonly Lazy<Logger> lazy = new Lazy<Logger>(()=> new Logger());

        public  string Path { get; set; }

        private Logger()
        {
            Path = @"\text.txt";
        }

        public static Logger GetInstance()
        {
            return lazy.Value;
        }

        public void LogText(string str)
        {
            str += '\n';
            File.AppendAllText(Path, str);
        }

        public string ReadFile()
        {
            return File.ReadAllText(Path);
        }
    }
}
