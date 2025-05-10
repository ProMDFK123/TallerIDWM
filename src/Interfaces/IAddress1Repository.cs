
using api.src.Models;

namespace api.src.Interfaces
{
    public interface IAddress1Repository
    {
        Task<Address1?> GetByUserIdAsync(string userId);
        Task AddAsync(Address1 address);
    }
}
