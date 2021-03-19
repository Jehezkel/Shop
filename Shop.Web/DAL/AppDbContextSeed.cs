using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Shop.Web.Models;

namespace Shop.Web.DAL
{
    public static class AppDbContextSeed
    {
        public static async Task SeedSampleProductsAsync(AppDbContext context)
        {
            if (false)
            {
                context.Products.Add(new Product
                {
                    ProductName = "Rower",
                    Price = 350.5M
                });
                context.Products.Add(new Product
                {
                    ProductName = "Akwarium",
                    Price = 400.20M
                });
                context.Products.Add(new Product
                {
                    ProductName = "Hustawka",
                    Price = 1000.5M
                });
                context.Products.Add(new Product
                {
                    ProductName = "Proszek do prania",
                    Price = 29.99M
                });
                context.Products.Add(new Product
                {
                    ProductName = "Lalka",
                    Price = 199.99M
                });
                context.Products.Add(new Product
                {
                    ProductName = "Kredki",
                    Price = 9.99M
                });
                await context.SaveChangesAsync();
            }

        }
    }
}