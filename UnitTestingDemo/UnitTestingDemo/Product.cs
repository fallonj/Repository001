using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestingDemo
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get; }
    }
    
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void UpdateProduct(Product product);
    }

    public interface IPriceReducer
    {
        void ReducePrices(decimal priceReduction);
    }
}
