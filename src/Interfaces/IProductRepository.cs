using api.src.Models;

namespace api.src.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(int id);
        Task<Product> GetProductByIdAsync(int id);
    }
}