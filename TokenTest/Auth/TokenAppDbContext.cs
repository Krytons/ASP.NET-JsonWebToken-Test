using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenTest.Models;

namespace TokenTest.Auth
{
    public class TokenAppDbContext : IdentityDbContext<AppUser>
    {
        public TokenAppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId); //Makes ProductId primary key
                entity.Property(e => e.Name).IsRequired().HasMaxLength(30); //Makes Name required
                entity.HasIndex(e => new { e.Name }).IsUnique();
                entity.Property(e => e.Price).IsRequired(); //Makes Price required
            });

        }
    }
}
