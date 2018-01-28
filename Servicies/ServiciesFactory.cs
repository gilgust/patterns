using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicies
{
    public class ServiciesFactory
    {
        public ServiciesFactory()
        {
        }

        public string Path { get; set; }

        public IAudioPlayer GetAudioPlayer()
        {
            var audioPlayer = AudioService.GetInstance();
            audioPlayer.PathToFite = Path;
            return audioPlayer;
        }

        public IFileService GetFileService()
        {
            return FileService.GetInstance();
        }
    }
}
