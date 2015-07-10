using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using binbash.Models;
using binbash.Services;

namespace binbash.Controllers {

    public class CartController : Controller {

        public ActionResult Cart() {
            BinBashModels db = new BinBashModels();
            CartCartViewModel viewModel = new CartCartViewModel();

            List<int> cartProducts = CartService.getItems();
            viewModel.Products = db.Products.Where(p => cartProducts.Contains(p.Id)).ToArray();

            return View(viewModel);
        }

        public ActionResult Checkout() {
            return View();
        }

        public ActionResult Complete() {
            CartService.clear();

            return View();
        }

        public ActionResult AddToCart() {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            var foo = CartService.addItem(id);

            return RedirectToAction("cart");
        }


    }
}