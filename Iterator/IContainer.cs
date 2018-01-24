namespace Iterator
{
    // интерфейс коллекции задаёт способ получения итератора
    public interface IContainer<T>
    {
        IIterator<T> CreateIterator();
    }
}