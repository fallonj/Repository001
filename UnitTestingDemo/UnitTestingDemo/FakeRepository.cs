using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestingDemo
{
    class FakeRepository : IProductRepository
    {
        public int UpdateProductCallCount { get; set; }


        private Product[] products = {
                                        new Product() { Name = "Kayak", Price = 275M},
                                        new Product() { Name = "Lifejacket", Price = 48.95M},
                                        new Product() { Name = "Soccer ball", Price = 19.50M},
                                        new Product() { Name = "Stadium", Price = 79500M}
                                     };

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public void UpdateProduct(Product productParam)
        {
            foreach (Product p in products.Where(x => x.Name == productParam.Name).Select(x => x)) 
            {
                p.Price = productParam.Price;
            }

            UpdateProductCallCount++;            
        }

        public decimal GetTotalValue() 
        {
            return products.Sum(x => x.Price);
        }
    }
}
