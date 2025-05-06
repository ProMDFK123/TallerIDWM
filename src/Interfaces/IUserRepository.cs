using api.src.Models;

namespace api.src.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
    }
}