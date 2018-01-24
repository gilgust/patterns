namespace Decorator
{
    interface IProduct
    {
        string Name { get; set; }
        string Article { get; set; }
        decimal Price { get; set; }
         
        void GetInfo();
    }
}
