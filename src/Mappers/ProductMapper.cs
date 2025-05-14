using TallerIDWM.Src.DTOs.Product;
using TallerIDWM.Src.Models;

namespace TallerIDWM.Src.Mappers
{
    public static class ProductMapper
    {
        public static Product FromCreateDto(ProductDto dto, List<string> urls)
        {
            return new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                Brand = dto.Brand,
                Category = dto.Category,
                Urls = [.. urls],
            };
        }
    }
}
