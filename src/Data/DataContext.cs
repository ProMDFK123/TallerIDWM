using api.src.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace api.src.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<User>(options)
    {
        public required DbSet<Product> Products { get; set; }

        public required DbSet<Address1> Address1 { get; set; }
        public required DbSet<Basket> Baskets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasOne<Address1>(u => u.Address1)
            .WithOne(a => a.User)
            .HasForeignKey<Address1>(a => a.UserId);
            List<IdentityRole> roles =
            [
                new IdentityRole { Id = "1" ,Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "2" ,Name = "User", NormalizedName = "USER" }
            ];

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}