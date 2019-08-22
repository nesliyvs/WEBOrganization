using OrganizationWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrganizationWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogInItem lg)
        {
            if (lg.UserName == null || lg.Password == null)
            {
                ModelState.AddModelError("Hatali", "UserName or Password is empty");
                return RedirectToAction("Login");
            }




            if (lg.UserName=="Nesli" && lg.Password=="2810")
            {
                Session["User"] = "Nesli";
                return RedirectToAction("Index");
            }

            else
            {
                ModelState.AddModelError("Hatali", "UserName or Password is wrong");
                return View(lg);
            }
                
           
           
            
        }

        
        public ActionResult LogOut()
        {
            Session["User"] = null;
            return View("Login");

        }

    }
}