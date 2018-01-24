using System; 

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Product a = new Product() { Article = "112a", Name = "knife", Price = 2 };
            IProduct forEU = new ProductForEU(a);
            forEU.GetInfo();
            IProduct forRB = new ProductForRB(a);
            forRB.GetInfo();
            Console.ReadKey();
        }
    }
}
