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
            BinBashModelsContext db = new BinBashModelsContext();
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

        // POST: Cart/add
        [HttpPost]
        public ActionResult AddToCart(int id, int quantity) {
            CartService.addItem(id, quantity);

            return RedirectToAction("cart");
        }

        // POST: Cart/SetQuantity
        public ActionResult SetCartQuantity(int id, int quantity) {

            CartService.SetItemQuanity(id, quantity);

            return RedirectToAction("cart");
        }

        // POST: Cart/Remove
        [HttpPost]
        public ActionResult RemoveFromCart(int id) {

            CartService.RemoveItem(id);

            return RedirectToAction("cart");
        }

    }
}