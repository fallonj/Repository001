using SportsStore.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using SportsStore.Domain.Abstract;
using System.Web.Mvc;
using Moq;
using SportsStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using SportsStore.WebUI.Models;


namespace SportsStore.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for ProductControllerTest and is intended
    ///to contain all ProductControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProductControllerTest
    {

        [TestMethod]
        public void Can_Paginate() 
        { 
            //Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();

            mock.Setup(m => m.Products).Returns(new Product[] {
            
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}

            }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //Act
            //IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;
            ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;


            //Assert
            Product[] products = result.Products.ToArray();
            Assert.IsTrue(products.Length == 2);
            Assert.AreEqual(result.PagingInfo.TotalPages, products.Length);
            Assert.AreEqual(products[0].Name, "P4");
            Assert.AreEqual(products[1].Name, "P5");        
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            //Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();

            mock.Setup(m => m.Products).Returns(new Product[] {
            
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}

            }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //Act
            ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;
            PagingInfo pageInfo = result.PagingInfo;

            //Assert
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);

        }

    }
}
