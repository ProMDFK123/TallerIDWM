using api.src.Models;

namespace api.src.Interfaces
{
    public interface IAddress1Repository
    {
        Task<Address1> GetAddressById(int id);
        Task<IEnumerable<Address1>> GetAddresses();
        Task<Address1> AddAddress(Address1 address);
        Task<Address1> UpdateAddress(Address1 address);
    }
}