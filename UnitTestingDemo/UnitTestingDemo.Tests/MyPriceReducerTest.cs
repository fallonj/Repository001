using UnitTestingDemo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace UnitTestingDemo.Tests
{
    [TestClass]
    public class MyPriceReducerTest
    {
        private IEnumerable<Product> products;

        [TestInitialize]
        public void PreTestInitialise() 
        {
            // Arrange
            products = new Product[] {
                new Product() { Name = "Kayak", Price = 275M},
                new Product() { Name = "Lifejacket", Price = 48.95M},
                new Product() { Name = "Soccer ball", Price = 19.50M},
                new Product() { Name = "Stadium", Price = 79500M}
            };
        }


        [TestMethod]
        public void All_Prices_Are_Changed() {
            // Arrange
            FakeRepository repo = new FakeRepository();
            decimal reductionAmount = 10;
            IEnumerable<decimal> prices = repo.GetProducts().Select(e => e.Price);
            decimal[] initialPrices = prices.ToArray();
            MyPriceReducer target = new MyPriceReducer(repo);
      
            // Act      
            target.ReducePrices(reductionAmount);
            prices.Zip(initialPrices, (p1, p2) =>
            {
                if (p1 == p2)
                {
                    Assert.Fail();
                }

                return p1;
            });
      }

        [TestMethod]
        public void Correct_Total_Reduction_Amount()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m=> m.GetProducts()).Returns(products);

            //FakeRepository repo = new FakeRepository();
            decimal reductionAmount = 10;
            decimal initialTotal = products.Sum(x=>x.Price);
            MyPriceReducer target = new MyPriceReducer(mock.Object);
            // Act
            target.ReducePrices(reductionAmount);

            // Assert
            Assert.AreEqual(
                                products.Sum(p => p.Price),
                                (initialTotal - (products.Count() * reductionAmount))
                            );
        }

        [TestMethod]
        public void No_Price_Less_Than_One_Dollar()
        {
            // Arrange
            FakeRepository repo = new FakeRepository();
            decimal reductionAmount = decimal.MaxValue;
            MyPriceReducer target = new MyPriceReducer(repo);
            // Act
            target.ReducePrices(reductionAmount);
            // Assert
            foreach (Product prod in repo.GetProducts())
            {
                Assert.IsTrue(prod.Price >= 1);
            }
        }
    }




}
