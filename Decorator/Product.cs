using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator 
{
    class Product : IProduct
    {
        public string Name { get; set ; }
        public string Article { get; set; }
        public decimal Price { get; set; }

        public void GetInfo()
        {
            Console.WriteLine("{0} {1} {2}", Name, Article, Price);
        }

        public IProduct GetProduct()
        {
            Product a = new Product();
            a.Name = this.Name;
            a.Article = this.Article;
            a.Price = this.Price;
            return a;
        }
         

    }
}