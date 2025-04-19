using api.src.Data;
using api.src.Interfaces;
using api.src.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_web_api.Src.Repositories
{
    public class ProductRepository(DataContext dataContext) : IProductRepository
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _dataContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal min, decimal max)
        {
            return await _dataContext
                .Products.Where(p => p.Price >= min && p.Price <= max)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string term)
        {
            if (string.IsNullOrEmpty(term))
                return await GetAllProductsAsync();

            term = term.ToLower();
            return await _dataContext
                .Products.Where(p =>
                    p.Name.ToLower().Contains(term)
                    || (p.Description != null && p.Description.ToLower().Contains(term))
                )
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByStoreAsync(int storeId)
        {
            return await _dataContext.Products.Where(p => p.StoreId == storeId).ToListAsync();
        }

        public async Task<IEnumerable<object>> GetProductsGroupedByStoreAsync()
        {
            return await _dataContext
                .Products.GroupBy(p => p.StoreId)
                .Select(g => new
                {
                    StoreId = g.Key,
                    Count = g.Count(),
                    Products = g.ToList(),
                })
                .ToListAsync();
        }

        public async Task<Product?> GetMostExpensiveProductAsync()
        {
            return await _dataContext
                .Products.OrderByDescending(p => p.Price)
                .FirstOrDefaultAsync();
        }
    }
}