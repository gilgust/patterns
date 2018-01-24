using System; 

namespace Decorator
{
    class ProductForEU :ProductDecorator
    {
        public ProductForEU(Product product) : base(product)
        {
            _product.Article = "#" + _product.Article;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine("Euro");
        }

    }
}
