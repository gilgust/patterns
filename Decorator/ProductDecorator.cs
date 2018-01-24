using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    abstract class ProductDecorator:IProduct 

    {
        public string Name { get; set; }
        public string Article { get; set; }
        public decimal Price { get; set; }
        protected Product _product;

        protected ProductDecorator(Product product)
        {
            _product = (Product)product.Clone();
        }

        public Product GetProduct()
        {
            return _product;
        }

        public virtual void GetInfo()
        {
            _product.GetInfo();
        }
    }
}
