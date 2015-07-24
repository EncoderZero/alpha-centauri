using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using binbash.Models;
using binbash.Services;

namespace binbash.Controllers {

    public class CartController : Controller {

        // GET: Cart/Cart
        public ActionResult Cart() {
            BinBashModels db = new BinBashModels();
            CartCartViewModel viewModel = new CartCartViewModel();

            var Products = db.Products.ToList();

            viewModel.CartItems = CartService.GetItems();
            viewModel.TotalPrice = 0;

            foreach(CartItem cartItem in viewModel.CartItems) {
                cartItem.Product = Products.Find(p => p.Id == cartItem.ProductId);
                cartItem.ItemTotal = cartItem.Product.Price * cartItem.Quantity;

                viewModel.TotalPrice += cartItem.ItemTotal;
            }

            return View(viewModel);
        }

        // GET: Cart/Checkout
        public ActionResult Checkout() {
            return View();
        }

        // GET: Cart/Complete
        public ActionResult Complete() {
            CartService.Clear();

            return View();
        }

        // GET: Cart/AddToCart?id=5
        public ActionResult AddToCart() {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            CartService.addItem(id);

            return RedirectToAction("cart");
        }

        // GET: Cart/SetCartQuantity?id=5&quantity=1
        public ActionResult SetCartQuantity() {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            int quantity = Convert.ToInt32(Request.QueryString["quantity"]);

            CartService.SetItemQuanity(id, quantity);

            return RedirectToAction("cart");
        }

        // GET: Cart/RemoveFromCart?id=5
        public ActionResult RemoveFromCart() {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            CartService.RemoveItem(id);

            return RedirectToAction("cart");
        }

    }
}