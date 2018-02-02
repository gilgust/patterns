using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Servicies
{
    internal class AudioService : IAddPath, IAudioPlayer
    {
        private static readonly Lazy<AudioService> _Lazy =
            new Lazy<AudioService>(()=> new AudioService());
        private SoundPlayer _player = new SoundPlayer();

        private AudioService()
        {
            PathToFite = null;
            NameFile = null;
        }


        public string PathToFite { get; set; }
        public string NameFile { get; set; }

        public static AudioService GetInstance()
        {
            return _Lazy.Value;
        }

        public void Load( )
        {
            _player.SoundLocation = Path.Combine(PathToFite,NameFile);
            _player.Load();
        }

        public void Play()
        {
            _player.PlaySync();
        }
    }
}
