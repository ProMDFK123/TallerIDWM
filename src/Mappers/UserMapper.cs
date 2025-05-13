using TallerIDWM.Src.DTOs.Auth;
using TallerIDWM.Src.DTOs.User;
using TallerIDWM.Src.Models;

namespace TallerIDWM.Src.Mappers
{
    public class UserMapper
    {
        public static User RegisterToUser(RegisterDto dto) =>
            new()
            {
                UserName = dto.Email,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.Thelephone,
                Telephone = dto.Thelephone,
                RegisteredAt = DateTime.UtcNow,
                IsActive = true,
                ShippingAddress = new ShippingAddress
                {
                    Street = dto.Street ?? string.Empty,
                    Number = dto.Number ?? string.Empty,
                    Commune = dto.Commune ?? string.Empty,
                    Region = dto.Region ?? string.Empty,
                    PostalCode = dto.PostalCode ?? string.Empty,
                },
            };

        public static UserDto UserToUserDto(User user) =>
            new()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email ?? string.Empty,
                Thelephone = user.PhoneNumber ?? string.Empty,
                Street = user.ShippingAddress?.Street,
                Number = user.ShippingAddress?.Number,
                Commune = user.ShippingAddress?.Commune,
                Region = user.ShippingAddress?.Region,
                PostalCode = user.ShippingAddress?.PostalCode,
                RegisteredAt = user.RegisteredAt,
                LastAccess = user.LastAccess,
                IsActive = user.IsActive,
            };

        public static AuthenticatedUserDto UserToAuthenticatedDto(User user, string token) =>
            new()
            {
                FirtsName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email ?? string.Empty,
                Thelephone = user.PhoneNumber ?? string.Empty,
                Token = token,
                Street = user.ShippingAddress?.Street,
                Number = user.ShippingAddress?.Number,
                Commune = user.ShippingAddress?.Commune,
                Region = user.ShippingAddress?.Region,
                PostalCode = user.ShippingAddress?.PostalCode,
                RegisteredAt = user.RegisteredAt,
                LastAccess = user.LastAccess,
                IsActive = user.IsActive,
            };

        public static void UpdateUserFromDto(User user, UpdateProfileDto dto)
        {
            user.FirstName = dto.FirtsName;
            user.LastName = dto.LastName;
            user.Telephone = dto.Phone ?? string.Empty;
        }
    }
}
