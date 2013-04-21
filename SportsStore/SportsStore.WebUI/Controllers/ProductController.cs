using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;

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
            ////return View(repository.Products);
            //return View(
            //    repository.Products
            //    .OrderBy(p=> p.ProductID)
            //    .Skip((page - 1) * PageSize)
            //    .Take(PageSize)
            //    );

            ProductsListViewModel viewModel = new ProductsListViewModel
                                                        {
                                                            Products = repository.Products
                                                                            .OrderBy(p => p.ProductID)
                                                                            .Skip((page - 1) * PageSize)
                                                                            .Take(PageSize),
                                                            PagingInfo = new PagingInfo { 
                                                                                CurrentPage = page,
                                                                                ItemsPerPage = PageSize,
                                                                                TotalItems = repository.Products.Count()
                                                                        }

                                                        };

            return View(viewModel);
        }

    }
}
