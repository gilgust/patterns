using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Servicies
{
    internal class AudioService : IAddPath, IAudioPlayer
    {
        private SoundPlayer _player = new SoundPlayer();
        private string _path;

        public AudioService(string path)
        {
            _path = path;
        } 
        public void Load( )
        {
            _player.SoundLocation = _path;
            _player.Load();
        }

        public void Play()
        {
            _player.PlaySync();
        }

        public void SetPath(string path)
        {
            _path = path;
        }
    }
}
