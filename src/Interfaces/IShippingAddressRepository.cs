using TallerIDWM.Src.Models;

namespace TallerIDWM.Src.Interfaces
{
    public interface IShippingAddressRepository
    {
        Task<ShippingAddress?> GetByUserIdAsync(string userId);
        Task AddAsync(ShippingAddress address);
        Task<ShippingAddress?> GetDefaultAddressAsync(string userId);
    }
}
