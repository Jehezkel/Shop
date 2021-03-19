using System;
using System.Security.Cryptography;
using Shop.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.Extensions.Options;
using IdentityServer4.EntityFramework.Options;

namespace Shop.Web.DAL
{
    public class AppDbContext : ApiAuthorizationDbContext<AppUser>
    {
        public AppDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductDescription>().HasKey(d => d.ProductId);
            builder.Entity<ProductDescription>()
                .HasOne(d => d.Product)
                .WithOne(p => p.ProductDescription)
                .HasForeignKey<ProductDescription>(d => d.ProductId);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductDescription> ProductDescriptions { get; set; }
    }
}