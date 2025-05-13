using TallerIDWM.Src.Models;

namespace TallerIDWM.Src.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetProductById(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(int id);
        Task<Product> GetProductByIdAsync(int id);
    }
}
