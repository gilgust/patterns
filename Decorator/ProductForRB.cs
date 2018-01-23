using System; 

namespace Decorator
{
    class ProductForRB : ProductDecorator
    {
        public decimal Rate { get; set; }

        public ProductForRB(Product product) : base(product)
        {
            Rate = (decimal)2.1;
            _product.Article = "№" + _product.Article;
            _product.Price *=   Rate;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.Write("BelRub ");
            Console.WriteLine("+ налоги");
        }
    }
}
