using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using binbash.Models.Identity;

namespace binbash.Models.BinBash {
    public partial class Cart {
        public Cart() {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public int ApplicationUser_Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}