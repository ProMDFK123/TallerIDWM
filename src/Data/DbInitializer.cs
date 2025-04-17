using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Data;
using Ayudantia.src.models;

using Bogus;

using Microsoft.EntityFrameworkCore;

namespace api.src.Data
{
    public class DbInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<DataContext>()
                ?? throw new InvalidOperationException("Could not get DataContext");

            SeedData(context);
        }

        private static void SeedData(DataContext context)
        {
            context.Database.Migrate();

            if (context.Products.Any() || context.Users.Any() || context.Stores.Any()) return;

            var faker = new Faker("es");

            var stores = new Faker<Store>()
                .RuleFor(s => s.Name, f => f.Company.CompanyName())
                .RuleFor(s => s.Address, f => f.Address.FullAddress())
                .RuleFor(s => s.Email, f => f.Internet.Email())
                .Generate(5);
            context.Stores.AddRange(stores);
            context.SaveChanges();

            var products = new Faker<Product>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Category, f => f.Commerce.Department())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Price, f => f.Random.Decimal(5000, 50000))
                .RuleFor(p => p.Brand, f => f.Company.CompanyName())
                .RuleFor(p => p.Stock, f => f.Random.Int(10, 200))
                .RuleFor(p => p.Urls, f => new[]
                {
                    $"https://res.cloudinary.com/demo/image/upload/sample1.jpg",
                    $"https://res.cloudinary.com/demo/image/upload/sample2.jpg",
                    $"https://res.cloudinary.com/demo/image/upload/sample3.jpg"
                })
                .RuleFor(p => p.StoreId, f => f.PickRandom(stores).Id)
                .Generate(10);
            context.Set<Product>().AddRange(products);
            context.SaveChanges();

            var users = new Faker<User>()
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Name, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.PhoneNumber, f => int.Parse(f.Phone.PhoneNumber("##########")))
                .RuleFor(u => u.BirthDate, f => f.Date.Past(30, DateTime.Today.AddYears(-18)).ToString("yyyy-MM-dd"))
                .RuleFor(u => u.Street, f => f.Address.StreetName())
                .RuleFor(u => u.HouseNumber, f => f.Random.Int(1, 9999))
                .RuleFor(u => u.City, f => f.Address.City())
                .RuleFor(u => u.Region, f => f.Address.State())
                .RuleFor(u => u.ZipCode, f => int.Parse(f.Address.ZipCode("#####")))
                .Generate(10);
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}