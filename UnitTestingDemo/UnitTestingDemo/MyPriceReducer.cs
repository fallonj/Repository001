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
            throw new NotImplementedException();
        }
    }
}
