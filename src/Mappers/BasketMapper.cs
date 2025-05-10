using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using api.src.Dtos;
using api.src.Models;

namespace TallerIDWM.src.Mappers
{
    public static class BasketMapper
    {
        public static BasketDto ToDto(this Basket basket)
        {
            return new BasketDto
            {
                BasketId = basket.BasketId,
                Items = [.. basket.Items.Select(x => new BasketItemDto
                {
                    ProductId = x.ProductId,
                    Name = x.Product.Name,
                    Price = x.Product.Price,
                    PictureUrl = x.Product.Urls?.FirstOrDefault() ?? string.Empty,
                    Brand = x.Product.Brand,
                    Category = x.Product.Category,
                    Quantity = x.Quantity
                })]
            };
        }
    }
}