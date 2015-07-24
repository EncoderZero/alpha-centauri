using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using binbash.Wrappers;
using binbash.Models;

namespace binbash.Services {

    /// <summary>
    /// Provides access and modification of the current user's cart
    /// </summary>
    public class CartService {
        private const String SESSION_KEY = "Cart";

        private static SessionWrapper Session = new SessionWrapper();

        /// <summary>
        /// Adds an item to the user's cart
        /// </summary>
        /// <param name="productId">The id of the product to add to the cart</param>
        /// <returns>A updated list of ids of the products in the cart</returns>
        public static List<CartItem> addItem(int productId) {
            return addItem(productId, 1);
        }

        public static List<CartItem> addItem(int productId, int quantity) {
            if(quantity <= 0) {
                throw new ArgumentException("Quantity must be greater then 0");
            }

            List<CartItem> cart = GetItems();
            CartItem cartItem = cart.Find(ci => ci.ProductId == productId);

            if(cartItem != null) {
                cartItem.Quantity += quantity;
            } else {
                cartItem = new CartItem();
                cartItem.ProductId = productId;
                cartItem.Quantity = quantity;
                cart.Add(cartItem);
            }

            Session[SESSION_KEY] = cart.ToArray();

            return GetItems();
        }

        /// <summary>
        /// Gets the current list of products in the user's cart
        /// </summary>
        /// <returns>A list of ids of the products in the cart</returns>
        public static List<CartItem> GetItems() {
            if(Session[SESSION_KEY] == null) {
                Session[SESSION_KEY] = new CartItem[0];
            }

            return ((CartItem[])Session[SESSION_KEY]).ToList();
        }

        public static List<CartItem> SetItemQuanity(int productId, int quantity) {
            if(quantity <= 0) {
                throw new ArgumentException("Quantity must be greater then 0");
            }

            List<CartItem> cart = GetItems();
            CartItem cartItem = cart.Find(ci => ci.ProductId == productId);

            if(cartItem != null) {
                cartItem.Quantity = quantity;
            } else {
                cartItem = new CartItem();
                cartItem.ProductId = productId;
                cartItem.Quantity = quantity;
                cart.Add(cartItem);
            }

            Session[SESSION_KEY] = cart.ToArray();

            return GetItems();
        }

        public static List<CartItem> AddItemQuantity(int productId, int quantity) {
            return addItem(productId, quantity);
        }

        public static List<CartItem> RemoveItemQuantity(int productId, int quantity) {
            if(quantity <= 0) {
                throw new ArgumentException("Quantity must be greater then 0");
            }

            List<CartItem> cart = GetItems();
            CartItem cartItem = cart.Find(ci => ci.ProductId == productId);

            if(cartItem != null) {
                int newQuantity = cartItem.Quantity - quantity;

                if(newQuantity <= 0) {
                    cart.Remove(cartItem);
                } else {
                    cartItem.Quantity = newQuantity;
                }
            }

            Session[SESSION_KEY] = cart.ToArray();

            return GetItems();
        }

        /// <summary>
        /// Removes all of an item from the user's cart
        /// </summary>
        /// <param name="productId">The id of the item to remove from the cart</param>
        /// <returns>A updated list of ids of the products in the cart</returns>
        public static List<CartItem> RemoveItem(int productId) {
            List<CartItem> cart = GetItems();

            CartItem cartItem = cart.Find(ci => ci.ProductId == productId);

            if(cartItem != null) {
                cart.Remove(cartItem);
            }

            Session[SESSION_KEY] = cart.ToArray();

            return GetItems();
        }

        /// <summary>
        /// Empties the user's cart
        /// </summary>
        /// <returns>A updated list of ids of the products in the cart</returns>
        public static List<CartItem> Clear() {
            Session[SESSION_KEY] = new List<CartItem>().ToArray();
            return GetItems();
        }
    }
}