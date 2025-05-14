using TallerIDWM.Src.DTOs.Order;
using TallerIDWM.Src.Models;

namespace TallerIDWM.Src.Mappers
{
    public static class OrderMapper
    {
        public static Order FromBasket(Basket basket, string userId, int shippingAddressId)
        {
            return new Order
            {
                UserId = userId,
                ShippingAddressId = shippingAddressId,
                Total = basket.Items.Sum(i => i.Quantity * i.Product.Price),
                Items =
                [
                    .. basket.Items.Select(i => new OrderItem
                    {
                        ProductId = i.Product.Id,
                        ProductName = i.Product.Name,
                        Quantity = i.Quantity,
                        Price = i.Product.Price,
                    }),
                ],
            };
        }

        public static OrderDto ToOrderDto(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                CreatedAt = order.OrderDate,
                ShippingAddress = order.ShippingAddress,
                Total = (int)Math.Floor(order.Total),
                Items =
                [
                    .. order.Items.Select(i => new OrderItemDto
                    {
                        ProductId = i.ProductId,
                        Name = i.ProductName,
                        Quantity = i.Quantity,
                        Price = (int)Math.Floor(i.Price),
                        ImageUrl = "", // Puedes ajustar si decides guardar o mapear imágenes
                    }),
                ],
            };
        }

        public static OrderSummaryDto ToSummaryDto(Order order)
        {
            return new OrderSummaryDto
            {
                Id = order.Id,
                CreatedAt = order.OrderDate,
                Total = (int)Math.Floor(order.Total),
            };
        }
    }
}
