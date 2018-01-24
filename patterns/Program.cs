using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicies;

namespace patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new ServiciesFactory("3158.wav");
            var AudioPlayer = a.GetAudioPlayer();
            Console.WriteLine("1");
            AudioPlayer.Load();
            AudioPlayer.Play();
            Console.ReadKey();
        }
    }
}
