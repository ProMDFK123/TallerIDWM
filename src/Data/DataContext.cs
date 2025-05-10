using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using api.src.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.src.Data;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<User>(options)
{
    public required DbSet<Product> Products { get; set; }

    public required DbSet<Address1> Address1s { get; set; }

    public required DbSet<Basket> Baskets { get; set; }

    public required DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<User>()
                .HasOne(u => u.Address1)
                .WithOne(sa => sa.User)
                .HasForeignKey<Address1>(sa => sa.UserId);
        List<IdentityRole> roles =
        [
            new IdentityRole { Id = "1" ,Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "2" ,Name = "User", NormalizedName = "USER" }
        ];

        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }
}