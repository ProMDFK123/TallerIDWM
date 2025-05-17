using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TallerIDWM.Src.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TallerIDWM.Src.Data;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<User>(options)
{
    public required DbSet<Product> Products { get; set; }

    public required DbSet<ShippingAddress> ShippingAddress { get; set; }

    public required DbSet<Basket> Baskets { get; set; }
    public required DbSet<Order> Orders { get; set; }
    public required DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<User>()
                .HasOne(u => u.ShippingAddress)
                .WithOne(sa => sa.User)
                .HasForeignKey<ShippingAddress>(sa => sa.UserId);
        List<IdentityRole> roles =
        [
            new IdentityRole { Id = "1" ,Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "2" ,Name = "User", NormalizedName = "USER" }
        ];

        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }
}