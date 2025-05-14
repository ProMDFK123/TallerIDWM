using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TallerIDWM.Src.Data;
using TallerIDWM.Src.Interfaces;
using TallerIDWM.Src.Models;

namespace TallerIDWM.Src.Repositories
{
    public class UserRepository(UserManager<User> userManager, DataContext context)
        : IUserRepository
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly DataContext _context = context;

        public IQueryable<User> GetUsersQueryable()
        {
            return _userManager.Users.Include(u => u.ShippingAddress).AsQueryable();
        }

        public async Task<User?> GetUserByIdAsync(string id)
        {
            return await _userManager
                .Users.Include(u => u.ShippingAddress)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userManager
                .Users.Include(u => u.ShippingAddress)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userManager.UpdateAsync(user);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userManager
                .Users.Include(u => u.ShippingAddress)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            return await Task.Run(() =>
            {
                var hasher = new PasswordHasher<User>();
                var result = hasher.VerifyHashedPassword(user, user.PasswordHash!, password);
                return result == PasswordVerificationResult.Success;
            });
        }

        public async Task<IdentityResult> UpdatePasswordAsync(User user, string newPassword) =>
            await _userManager.ChangePasswordAsync(user, user.PasswordHash!, newPassword);

        public Task<User?> GetUserWithAddressByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            // Aquí va la lógica para obtener un usuario por su ID de tu base de datos
            return await _context.Users.FindAsync(id);
        }
    }
}
