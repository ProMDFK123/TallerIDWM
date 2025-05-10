using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.src.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);
        Task<IReadOnlyList<Order>> GetOrdersByUserIdAsync(string userId);
        Task<IReadOnlyList<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId, string userId);
    }
}