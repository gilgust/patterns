using System.Collections.Generic; 

namespace Observer
{
    public class Detector
    {
        private int _value;
        private readonly IList<IObserver> _observers = new List<IObserver>();

        public int Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    Notify();
                }
            }
        }

        public Detector()
        {

        }

        public void Observe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void StopObserving(IObserver observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var o in _observers)
            {
                o.OnChange(this);
            }
        }
    }
}
