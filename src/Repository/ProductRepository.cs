
using TallerIDWM.Src.Data;
using TallerIDWM.Src.Interfaces;
using TallerIDWM.Src.Models;

using Microsoft.EntityFrameworkCore;

namespace TallerIDWM.Src.Repository;

public class ProductRepository(DataContext store, ILogger<Product> logger) : IProductRepository
{
    private readonly DataContext _context = store;
    private readonly ILogger<Product> _logger = logger;

    public async Task AddProductAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public Task DeleteProductAsync(Product product)
    {
        _context.Products.Remove(product);
        return Task.CompletedTask;
    }


    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id) ?? null;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public IQueryable<Product> GetQueryableProducts()
    {
        return _context.Products.AsQueryable();
    }

    public Task UpdateProductAsync(Product product)
    {
        _context.Products.Update(product);
        return Task.CompletedTask;
    }

    public async Task<bool> IsProductInOrdersAsync(int productId)
    {
        return await _context.OrderItems.AnyAsync(i => i.ProductId == productId);
    }


}