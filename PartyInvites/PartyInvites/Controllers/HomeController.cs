using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;

            ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";  

            return View();        
        }

        [HttpGet]
        public ViewResult RsvpForm() 
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                //TODO: Email guestResponse to the party organiser
                return View("Thanks", guestResponse);
            }
            else
            {
                //There is a validation error - redisplay the form
                return View();
            }    
        }

    }
}
