using SportsStore.WebUI.HtmlHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for PagingHelpersTest and is intended
    ///to contain all PagingHelpersTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PagingHelpersTest
    {

        [TestMethod]
        public void Can_Generate_Page_Links()
        { 
            //Arrange
            HtmlHelper myHelper = null;

            PagingInfo pagingInfo = new PagingInfo { CurrentPage = 2, TotalItems = 38, ItemsPerPage = 10 };

            Func<int, string> pageUrlDelegate = (i) => "Page " + i;

            //Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);


            //Assert
            Assert.AreEqual(result.ToString(), @"<a href=""Page 1"">1</a><a class=""selected"" href=""Page 2"">2</a><a href=""Page 3"">3</a>"); 

        }


    }
}
