using TallerIDWM.Src.DTOs.Basket;
using TallerIDWM.Src.Models;

namespace TallerIDWM.Src.Mappers
{
    public static class BasketMapper
    {
        public static BasketDto ToDto(this Basket basket)
        {
            return new BasketDto
            {
                BasketId = basket.BasketId,
                Items =
                [
                    .. basket.Items.Select(x => new BasketItemDto
                    {
                        ProductId = x.ProductId,
                        Name = x.Product.Name,
                        Price = x.Product.Price,
                        PictureUrl = x.Product.Urls?.FirstOrDefault() ?? string.Empty,
                        Brand = x.Product.Brand,
                        Category = x.Product.Category,
                        Quantity = x.Quantity,
                    }),
                ],
            };
        }
    }
}
