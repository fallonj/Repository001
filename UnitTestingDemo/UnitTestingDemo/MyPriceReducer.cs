using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestingDemo
{
    class MyPriceReducer : IPriceReducer
    {
        private IProductRepository productRepository;

        public MyPriceReducer(IProductRepository repo) {
            productRepository = repo;
        }

        public void ReducePrices(decimal priceReduction)
        {
            foreach (Product p in productRepository.GetProducts())
            {
                p.Price = Math.Max(p.Price - priceReduction, 1);
                productRepository.UpdateProduct(p);
            }
        }
    }
}
