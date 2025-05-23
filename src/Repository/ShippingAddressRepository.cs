using TallerIDWM.Src.Data;
using TallerIDWM.Src.Interfaces;
using TallerIDWM.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace TallerIDWM.Src.Repositories
{
    public class ShippingAddressRepository(DataContext context) : IShippingAddressRepository
    {
        private readonly DataContext _context = context;

        public async Task<ShippingAddress?> GetByUserIdAsync(string userId)
        {
            return await _context.ShippingAddress.FirstOrDefaultAsync(a => a.UserId == userId);
        }

        public async Task AddAsync(ShippingAddress address)
        {
            await _context.ShippingAddress.AddAsync(address);
        }

        public async Task<ShippingAddress?> GetDefaultAddressAsync(string userId)
        {
            return await _context
                .ShippingAddress.Where(a => a.UserId == userId)
                .FirstOrDefaultAsync(a => a.UserId == userId);
        }
    }
}
