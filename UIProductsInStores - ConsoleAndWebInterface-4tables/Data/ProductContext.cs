using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
  public  class ProductContext:DbContext
    {
        public ProductContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.; Integrated Security=true; Database=ShopDbStores");
            }
            base.OnConfiguring(optionsBuilder);

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet <Store> Stores { get; set; }
        public DbSet <ProductStore> ProductsStores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductStore>().HasKey(x=>new { x.ProductId, x.StoreId});
        }
    }
}
