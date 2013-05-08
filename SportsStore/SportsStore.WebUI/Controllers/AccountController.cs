using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        
        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        public ViewResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnViewModel model, string returnUrl)
        {
            if (ModelState.IsValid == true)
            {
                if (authProvider.Authenticate(model.UserName, model.Password) == true)
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect UserName or Password");
                    return View();
                }

            }
            else 
            {
                return View();
            }
        
        }
    }
}