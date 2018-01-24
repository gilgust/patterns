namespace Observer
{
    public interface IObserver
    {
        void OnChange(Detector detector);
    }
}