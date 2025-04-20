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

            if (context.Products.Any() || context.Users.Any() || context.Addresses.Any()) return;

            var faker = new Faker("es");


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
                .RuleFor(p => p.StoreId, f => f.Random.Int(1, 5))
                .Generate(10);

            foreach (var product in products)
            {
                if (!context.Products.Any(p => p.Name == product.Name))
                {
                    context.Set<Product>().Add(product);
                }
            }

            context.Set<Product>().AddRange(products);

            var users = new Faker<User>()
                .RuleFor(u => u.Id, f => f.IndexFaker + 1)
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.Thelephone, f => f.Phone.PhoneNumber("##########"))
                .RuleFor(u => u.birthdate, f => f.Date.Past(30, DateTime.Today.AddYears(-18)).ToString("yyyy-MM-dd"))
                .RuleFor(u => u.Role, f => f.PickRandom("cliente", "administrador"))
                .RuleFor(u => u.Address1, (f, u) => f.Random.Bool() ? new Address1
                {
                    Street = f.Address.StreetAddress(),
                    City = f.Address.City(),
                    commune = f.Address.County(),
                    Region = f.Address.State(),
                    postalCode = f.Address.ZipCode(),
                    User = u
                } : null)
                .Generate(9);

            foreach (var user in users)
            {
                if (!context.Users.Any(u => u.Email == user.Email))
                {
                    context.Users.Add(user);
                }
            }

            var addresses = users.Select(user => user.Address1).Where(a => a != null).ToList();
            foreach (var address in addresses)
            {
                if (!context.Addresses.Any(a => a.Street == address.Street && a.postalCode == address.postalCode))
                {
                    context.Addresses.Add(address);
                }
            }

            var ignacio = new User
            {
                Id = 10,
                FirstName = "Ignacio",
                LastName = "Mancilla",
                Email = "ignacio.mancilla@gmail.com",
                Password = "Pa$$word2025",
                Thelephone = "973465281",
                birthdate = "1999-06-05",
                Role = "administrador",
                Address1 = new Address1
                {
                    Street = "Calle Falsa 555",
                    City = "Santiago",
                    commune = "Ñuñoa",
                    Region = "RM",
                    postalCode = "1240000"
                }
            };
            ignacio.Address1.User = ignacio;

            context.Users.Add(ignacio);
            context.Addresses.Add(ignacio.Address1);

            context.SaveChanges();
        }
    }
}