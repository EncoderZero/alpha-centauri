using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using binbash.Models;

namespace binbash.Controllers {
    public class CartController : Controller {
        const String sessionKey = "Cart";

        // GET: Cart
        public ActionResult Cart() {
            BinBashModels db = new BinBashModels();
            CartCartViewModel viewModel = new CartCartViewModel();

            List<int> cartProducts = getSessionCart();
            viewModel.Products = db.Products.Where(p => cartProducts.Contains(p.Id)).ToArray();

            return View(viewModel);
        }

        // GET: Confrim
        public ActionResult Checkout() {
            return View();
        }

        public ActionResult Complete() {
            clearSessionCart();

            return View();
        }

        public ActionResult AddToCart() {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            var foo = addToSessionCart(id);

            return RedirectToAction(sessionKey);
        }

        public List<int> addToSessionCart(int productId) {
            List<int> cart = getSessionCart();

            cart.Add(productId);

            Session[sessionKey] = cart.ToArray();

            return getSessionCart();
        }

        public List<int> getSessionCart() {
            if(Session[sessionKey] == null) {
                Session[sessionKey] = new int[0];
            }

            return ((int[])Session[sessionKey]).ToList();
        }

        public List<int> removeFromSessionCart(int productId) {
            List<int> cart = getSessionCart();

            cart.Remove(productId);

            Session[sessionKey] = cart.ToArray();

            return getSessionCart();
        }

        public List<int> clearSessionCart() {
            Session[sessionKey] = new int[0];
            return getSessionCart();
        }
    }
}