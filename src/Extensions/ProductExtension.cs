using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Models;

namespace api.src.Extensions
{
    public static class ProductExtension
    {
        public static IQueryable<Product> Filter(this IQueryable<Product> query, string? brands, string? categories)
        {
            var brandList = new List<string>();
            var categoryList = new List<string>();

            if (!string.IsNullOrWhiteSpace(brands))
            {
                brandList.AddRange(brands.ToLower().Split(","));
            }

            if (!string.IsNullOrWhiteSpace(categories))
            {
                categoryList.AddRange(categories.ToLower().Split(","));
            }

            query = query.Where(p => brandList.Count == 0 || brandList.Contains(p.Brand.ToLower()));
            query = query.Where(p => categoryList.Count == 0 || categoryList.Contains(p.Category.ToLower()));

            return query;
        }

        public static IQueryable<Product> Search(this IQueryable<Product> query, string? search)
        {
            if (string.IsNullOrWhiteSpace(search)) return query;

            var lowerCaseSearch = search.Trim().ToLower();

            return query.Where(p => p.Name.ToLowe().Contains(lowerCaseSearch));
        }

        public static IQueryable<Product> Sort(this IQueryable<Product> query, string? orderBy)
        {
            query = orderBy switch
            {
                "price" => query.OrderBy(p => p.Price),
                "priceDesc" => query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(p => p.Id)
            };

            return query;
        }
    }
}