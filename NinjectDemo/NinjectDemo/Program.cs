using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace NinjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel();

            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
        
            IValueCalculator calcImpl = ninjectKernel.Get<IValueCalculator>();

            ShoppingCart cart = new ShoppingCart(calcImpl);

            Console.WriteLine("Total: {0:c}", cart.CalculateStockValue());
            Console.ReadKey();
        }
    }
}
