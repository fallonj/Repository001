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
            //ninjectKernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>();

            ninjectKernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("JohnsDiscountSize", 30M);
            //ninjectKernel.Bind<IDiscountHelper>().To<CrazyDiscountHelper>().WithPropertyValue("JohnsDiscountSize", 50M);

            //ninjectKernel.Bind<ShoppingCart>().ToSelf("parameterName", 2);
        
            IValueCalculator calcImpl = ninjectKernel.Get<IValueCalculator>();
            
            ShoppingCart cart = new ShoppingCart(calcImpl);

            Console.WriteLine("Total: {0:c}", cart.CalculateStockValue());
            Console.ReadKey();
        }
    }
}
