namespace Iterator
{
    public interface IIterator<out T>
    { 
        void Reset();
         
        void MoveNext();
         
        bool IsDone { get; }
         
        T Current { get; }
    }
}