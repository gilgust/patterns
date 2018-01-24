using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Observer
{
    class RandNumber
    {
        private Detector _detector;
        private static Random _random;
        private TimerCallback _timerCallback ;
        private Timer _timer;

        public RandNumber(Detector detector)
        {
            _detector = detector;
            _random = new Random();
            TimerCallback _timerCallback = new TimerCallback(ChangValue);
            _timer = new Timer(_timerCallback,_detector,0, 1000);
        }

        public static void ChangValue(object obj)
        {
            var dt = (Detector) obj; 
            dt.Value = _random.Next(1000); 
        }
    }
}
