using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Data;
using api.src.Models;

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

            if (context.Products.Any() || context.Users.Any() || context.Address1s.Any()) return;

            var faker = new Faker("es");
            var productFaker = new Faker<Product>("es")
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
                .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()))
                .RuleFor(p => p.Category, f => f.Commerce.Categories(1)[0])
                .RuleFor(p => p.Urls, f => new[] { f.Image.PicsumUrl() })
                .RuleFor(p => p.Stock, f => f.Random.Int(1, 100))
                .RuleFor(p => p.Brand, f => f.Company.CompanyName())

            .Generate(10); 
            context.Set<Product>().AddRange(productFaker);
            context.SaveChanges();
        }
    }
}