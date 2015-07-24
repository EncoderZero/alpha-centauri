using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace binbash.Models {
    public class CartCartViewModel {
        public ICollection<Product> Products { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public double TotalPrice { get; set; }
    }
}