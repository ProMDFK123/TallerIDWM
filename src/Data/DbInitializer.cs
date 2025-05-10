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

            //Faker para Products
            if (context.Products.Any()) return;

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

            //Faker para Users
            if (context.Users.Any()) return;

            var userFaker = new Faker<User>("es")
                .RuleFor(u => u.FirstName, f => f.Person.FullName)
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.Address1, (f, u) => new Address1
                {
                    Street = f.Address.StreetAddress(),
                    City = f.Address.City(),
                    Region = f.Address.State(),
                    postalCode = f.Address.ZipCode(),
                    commune = f.Address.State()
                })
                .RuleFor(u => u.Thelephone, f => f.Phone.PhoneNumber())
                .Generate(9);

            context.Set<User>().AddRange(userFaker);

            var specificUserFaker = new Faker<User>("es")
                .RuleFor(u => u.FirstName, "Ignacio")
                .RuleFor(u => u.LastName, "Mancilla")
                .RuleFor(u => u.Email, "ignacio.mancilla01@gmail.com")
                .RuleFor(u => u.Password, "Pa$$word2025")
                .RuleFor(u => u.Thelephone, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.Address1, (f, u) => new Address1
                {
                    Street = f.Address.StreetAddress(),
                    City = f.Address.City(),
                    Region = f.Address.State(),
                    postalCode = f.Address.ZipCode(),
                    commune = f.Address.State()
                });

            context.Set<User>().Add(specificUserFaker.Generate());
            context.SaveChanges();

            //Faker para Address1s
            if (context.Address1.Any()) return;

            var addressFaker = new Faker<Address1>("es")
                .RuleFor(a => a.Street, f => f.Address.FullAddress())
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.commune, f => f.Address.State())
                .RuleFor(a => a.postalCode, f => f.Address.ZipCode())
                .RuleFor(a => a.Region, f => f.Address.State())
                .RuleFor(a => a.UserId, (f, a) => f.Random.Guid().ToString())
                .RuleFor(a => a.User, (f, a) => null!)
                .Generate(10);

            var addresses = addressFaker.ToList();
            context.Set<Address1>().AddRange(addressFaker);

            var users = context.Set<User>().Where(u => addresses.Select(a => a.UserId).Contains(u.Id)).ToList();

            foreach (var address in addresses)
            {
                address.User = users.FirstOrDefault(u => u.Id == address.UserId);
            }

            context.SaveChanges();
        }
    }
}