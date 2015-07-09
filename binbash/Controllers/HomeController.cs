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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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