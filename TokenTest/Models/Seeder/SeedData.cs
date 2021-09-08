using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenTest.Auth;

namespace TokenTest.Models.Seeder
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (TokenAppDbContext context = new TokenAppDbContext(serviceProvider.GetRequiredService<DbContextOptions<TokenAppDbContext>>()))
            {
                //Check if there are any products
                if (context.Products.Any())
                {
                    Console.WriteLine("Db seeding not needed");
                    return; //Database already seeded
                }

                //Add some products
                context.Products.Add(new Product("Xiaomi MI 11 lite 128Gb", 320.99));
                context.Products.Add(new Product("Iphone 12 RED 128Gb", 799.99));
                context.Products.Add(new Product("Iphone 12 Pro Max 256Gb", 1232.99));
                context.Products.Add(new Product("Samsung Galaxy S20 note 256Gb", 999.99));
                context.Products.Add(new Product("Samsung Galaxy S10 note 256Gb", 699.99));
                context.Products.Add(new Product("Google Pixel 4XL 128Gb", 499.99));
                //Save
                context.SaveChanges();
                Console.WriteLine("DB seeding completed");
            }
        }

    }
}
