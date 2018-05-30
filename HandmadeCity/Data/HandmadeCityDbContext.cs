using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandmadeCity.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HandmadeCity.Data
{
    public class HandmadeCityDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<PurchaseProduct> PurchaseProducts { get; set; }

        public HandmadeCityDbContext(DbContextOptions<HandmadeCityDbContext> options)
            : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PurchaseProduct>()
                .HasKey(bc => new { bc.PurchaseId, bc.ProductId });

            builder.Entity<PurchaseProduct>()
                .HasOne(bc => bc.Purchase)
                .WithMany(b => b.PurchaseProducts)
                .HasForeignKey(bc => bc.PurchaseId);

            builder.Entity<PurchaseProduct>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.PurchaseProducts)
                .HasForeignKey(bc => bc.ProductId);

            base.OnModelCreating(builder);
        }
    }
}
