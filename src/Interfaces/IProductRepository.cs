using api.src.Models;

namespace api.src.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal min, decimal max);
        Task<IEnumerable<Product>> SearchProductsAsync(string term);
        Task<IEnumerable<Product>> GetProductsByStoreAsync(int storeId);
        Task<IEnumerable<object>> GetProductsGroupedByStoreAsync();
        Task<Product?> GetMostExpensiveProductAsync();
    }
}