using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using binbash.Models;

namespace binbash.Controllers {
    public class CartController : Controller {
        // GET: Cart
        public ActionResult Cart() {
            return View();
        }

        // GET: Confrim
        public ActionResult Confirm() {
            return View();
        }

        public ActionResult AddToCart() {
            var id = Request.QueryString["id"];

            return Content("Hello " + id);
        }
    }
}