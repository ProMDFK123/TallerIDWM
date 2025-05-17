using TallerIDWM.Src.Models;

namespace TallerIDWM.Src.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int orderId, string userId);
    }
}
