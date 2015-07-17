using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace binbash.Models.BinBash {
    public partial class BinBashDbContext : DbContext {
        public BinBashDbContext()
            : base("name=DefaultConnection") {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Cart>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Carts)
                .Map(m => m.ToTable("CartProduct").MapLeftKey("Carts_Id").MapRightKey("Products_Id"));

            modelBuilder.Entity<Category>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
