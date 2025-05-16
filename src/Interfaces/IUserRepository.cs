using Microsoft.AspNetCore.Identity;
using TallerIDWM.Src.Models;

namespace TallerIDWM.Src.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsersQueryable();
        Task<User?> GetUserByIdAsync(string id);
        Task<User?> GetUserByEmailAsync(string email);
        Task UpdateUserAsync(User user); // Save status change or profile update
        Task<User?> GetByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<IdentityResult> UpdatePasswordAsync(User user,string currentPassword, string newPassword);
        Task<User?> GetUserWithAddressByIdAsync(string userId);
    }
}
