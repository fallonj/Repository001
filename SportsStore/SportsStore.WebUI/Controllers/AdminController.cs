using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    [Authorize] //This is the Authorize filter - it will redirect you to a log in page if you aren't already logged in
    public class AdminController : Controller
    {
        private IProductsRepository repository;

        public AdminController(IProductsRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productID)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);
    
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image)
        {


            if (ModelState.IsValid == true)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }

                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            { 
                //there is something wrong with the data values
                return View(product);
            }
        
        }


        public ViewResult Create() 
        {
            return View("Edit", new Product());
        }


        [HttpPost]
        public ActionResult Delete(int productID)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);
            if (product == null)
            {
                //Do Nothing
            }
            else
            {
                repository.DeleteProduct(product);
                TempData["message"] = string.Format("{0} was deleted", product.Name);
            }

            return RedirectToAction("Index");

        }

    }
}