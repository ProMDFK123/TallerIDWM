using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using api.src.Dtos;
using TallerIDWM.src.Mappers;
using api.src.Models;

using Bogus;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using api.src.Data.Seeders;

namespace api.src.Data;

public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>()
            ?? throw new InvalidOperationException("Could not get UserManager");

        var context = scope.ServiceProvider.GetRequiredService<DataContext>()
            ?? throw new InvalidOperationException("Could not get StoreContext");
    }

    private static async Task SeedData(DataContext context, UserManager<User> userManager)
    {
        await context.Database.MigrateAsync();

        if (!context.Products.Any())
        {
            var products = ProductSeeder.GenerateProducts(10);
            context.Products.AddRange(products);
        }

        if (!context.Users.Any())
        {
            var users = UserSeeder.GenerateUsersDto(10);
            await UserSeeder.CreateUsers(userManager, users);
        }

        await context.SaveChangesAsync();
    }
}