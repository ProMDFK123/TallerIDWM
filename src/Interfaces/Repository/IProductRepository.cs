using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TallerIDWM.Src.Models;

namespace TallerIDWM.Src.Interfaces;

public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(int id);
    Task<IEnumerable<Product>> GetProductsAsync();
    Task AddProductAsync(Product product);
    Task DeleteProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task<bool> IsProductInOrdersAsync(int productId);

    IQueryable<Product> GetQueryableProducts();

}