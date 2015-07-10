using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace binbash.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About Us";
            ViewBag.Message = "Supppliers of all Your Nerdy Needs.";
            ViewBag.OutClass = "null-container";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Want to talk?";
            ViewBag.Title = "Contact Us";

            return View();
        }

        public ActionResult PrivatePolicy()
        {
            ViewBag.Message = "Private Policy";

            return View();
        }
        public ActionResult TermsAndConditions()
        {
            ViewBag.Message = "Terms And Conditions";

            return View();
        }
    }
}