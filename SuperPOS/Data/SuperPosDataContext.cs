using SuperPOS.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace SuperPOS.Data
{
    internal class SuperPosDataContext : DbContext
    {
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseModel && (e.State == EntityState.Added || e.State == EntityState.Modified));
            foreach (var entityEntry in entries)
            {
                ((BaseModel)entityEntry.Entity).LastUpdatedAt = DateTime.Now;
            }
            return base.SaveChanges();
        }

        public DbSet<User> Users  { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<PurchaseItem> PurchasesItems { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
    }
}
