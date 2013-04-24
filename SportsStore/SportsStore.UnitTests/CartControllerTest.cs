﻿using SportsStore.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Web.Mvc;
using System.Linq;
using Moq;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for CartControllerTest and is intended
    ///to contain all CartControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CartControllerTest
    {

        [TestMethod]
        public void Can_Add_To_Cart()
        {
            // Arrange - create the mock repository
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] 
                                                {
                                                   new Product {ProductID = 1, Name = "P1", Category = "Apples"}
                                                }.AsQueryable());

            // Arrange - create a Cart
            Cart cart = new Cart();
            // Arrange - create the controller
            CartController target = new CartController(mock.Object);
            
            // Act - add a product to the cart
            target.AddToCart(cart, 1, null);

            // Assert
            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.ToArray()[0].Product.ProductID, 1);
        }


        [TestMethod]
        public void Adding_Product_To_Cart_Goes_To_Cart_Screen()
        {
            // Arrange - create the mock repository
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] 
                                                    {
                                                        new Product {ProductID = 1, Name = "P1", Category = "Apples"},
                                                    }.AsQueryable());
            
            // Arrange - create a Cart
            Cart cart = new Cart();
            
            // Arrange - create the controller
            CartController target = new CartController(mock.Object);
            
            // Act - add a product to the cart
            RedirectToRouteResult result = target.AddToCart(cart, 2, "myUrl");
            
            // Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
        }

        [TestMethod]
        public void Can_View_Cart_Contents()
        {
            // Arrange - create a Cart
            Cart cart = new Cart();
            // Arrange - create the controller
            CartController target = new CartController(null);
            
            // Act - call the Index action method
            CartIndexViewModel result = (CartIndexViewModel)target.Index(cart, "myUrl").ViewData.Model;
            
            // Assert
            Assert.AreSame(result.Cart, cart);
            Assert.AreEqual(result.ReturnUrl, "myUrl");
        }
    }
}
