using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicies
{
    public class ServiciesFactory
    {
        private string _path;

        public ServiciesFactory(string path)
        {
            _path = path;
        }
        public IAudioPlayer GetAudioPlayer()
        {
            return new AudioService(_path);
        }
    }
}
