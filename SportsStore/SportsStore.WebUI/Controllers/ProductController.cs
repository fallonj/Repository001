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
        public int PageSize = 4; //We will change this later

        public ProductController(IProductsRepository productRepository)
        {
            repository = productRepository;
        
        }

        public ViewResult List(int page = 1)
        {
            //return View(repository.Products);
            return View(
                repository.Products
                .OrderBy(p=> p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                );

        }

    }
}
