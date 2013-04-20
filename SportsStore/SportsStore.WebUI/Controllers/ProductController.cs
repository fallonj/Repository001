using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        private IProductsRepository repository;

        public ProductController(IProductsRepository productRepository)
        {
            repository = productRepository;
        
        }

        public ViewResult List()
        {
            return View(repository.Products);
        }

    }
}
