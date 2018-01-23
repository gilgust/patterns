using System; 

namespace Decorator 
{
    class Product : IProduct, ICloneable
    {
         

        public string Name { get; set ; }
        public string Article { get; set; }
        public decimal Price { get; set; }

        public void GetInfo()
        {
            Console.Write("{0} {1} {2}", Name, Article, Price);
        }
        


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}