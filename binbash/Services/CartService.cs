using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using binbash.Wrappers;

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
        public static List<int> addItem(int productId) {
            List<int> cart = getItems();

            cart.Add(productId);

            Session[SESSION_KEY] = cart.ToArray();

            return getItems();
        }

        /// <summary>
        /// Gets the current list of products in the user's cart
        /// </summary>
        /// <returns>A list of ids of the products in the cart</returns>
        public static List<int> getItems() {
            if(Session[SESSION_KEY] == null) {
                Session[SESSION_KEY] = new int[0];
            }

            return ((int[])Session[SESSION_KEY]).ToList();
        }

        /// <summary>
        /// Removes an item from the user's cart
        /// </summary>
        /// <param name="productId">The id of the item to remove from the cart</param>
        /// <returns>A updated list of ids of the products in the cart</returns>
        public static List<int> removeItem(int productId) {
            List<int> cart = getItems();

            cart.Remove(productId);

            Session[SESSION_KEY] = cart.ToArray();

            return getItems();
        }

        /// <summary>
        /// Empties the user's cart
        /// </summary>
        /// <returns>A updated list of ids of the products in the cart</returns>
        public static List<int> clear() {
            Session[SESSION_KEY] = new int[0];
            return getItems();
        }
    }
}