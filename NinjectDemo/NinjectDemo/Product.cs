using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjectDemo
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get; }
    }
 
   
    public interface IValueCalculator
    {
        decimal ValueProducts(params Product[] products);
    }
 
    
    public class LinqValueCalculator : IValueCalculator
    {

        private IDiscountHelper discounter;
        
        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            discounter = discountParam;
        }

        public decimal ValueProducts(params Product[] products)
        {
            return discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }

    public class ShoppingCart
    {
        private IValueCalculator calculator;
        public ShoppingCart(IValueCalculator calcParam)
        {
            calculator = calcParam;
        }

        public decimal CalculateStockValue()
        {
            // define the set of products to sum
            Product[] products = {
                        new Product() { Name = "Kayak", Price = 275M},
                        new Product() { Name = "Lifejacket", Price = 48.95M},
                        new Product() { Name = "Soccer ball", Price = 19.50M},
                        new Product() { Name = "Stadium", Price = 79500M}
                        };

            // calculate the total value of the products
            decimal totalValue = calculator.ValueProducts(products);
            // return the result
            return totalValue;

        }

    }

    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }

    public class DefaultDiscountHelper : IDiscountHelper
    {
        public decimal JohnsDiscountSize { get; set; }

        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (JohnsDiscountSize / 100m * totalParam));
        }
    }

    public class CrazyDiscountHelper : IDiscountHelper
    {

        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (50m / 100m * totalParam));
        }
    }

}