using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace binbash.Controllers
{
    public class CartController : Controller
    {
        // GET: Shopping
        public ActionResult Cart()
        {
            return View();
        }
    }
}