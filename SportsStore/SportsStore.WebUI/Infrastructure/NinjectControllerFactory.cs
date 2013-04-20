using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {

        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }


        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }


        private void AddBindings()
        {
            //Mock implementation of the IProductsRepository interface
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(
                                                new List<Product>
                                                {
                                                    new Product { Name = "Football", Price = 25},
                                                    new Product { Name="Surf Board", Price = 179},
                                                    new Product{Name = "Running Shoes", Price = 95}
                                                }.AsQueryable());

            //ninjectKernel.Bind<IProductsRepository>().ToConstant(mock.Object);
            ninjectKernel.Bind<IProductsRepository>().To<EFProductRepository>();
         
            
            //Put additional bindings here

        }
   


    }
}