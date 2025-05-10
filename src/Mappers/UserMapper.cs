using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using api.src.Dtos;
using api.src.Dtos.User;
using api.src.Models;

namespace TallerIDWM.src.Mappers
{
    public class UserMapper
    {

        public static User RegisterToUser(RegisterDto dto) =>
            new()
            {
                UserName = dto.Email,
                Email = dto.Email,
                FirstName = dto.FirtsName,
                LastName = dto.LastName,
                PhoneNumber = dto.Thelephone,
                Thelephone = dto.Thelephone,
                RegisteredAt = DateTime.UtcNow,
                IsActive = true,
                Address1 = new Address1
                {
                    Street = dto.Street ?? string.Empty,
                    Number = dto.Number ?? string.Empty,
                    Commune = dto.Commune ?? string.Empty,
                    Region = dto.Region ?? string.Empty,
                    PostalCode = dto.PostalCode ?? string.Empty
                }
            };
        public static UserDto UserToUserDto(User user) =>
            new()
            {
                FirtsName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email ?? string.Empty,
                Thelephone = user.PhoneNumber ?? string.Empty,
                Street = user.Address1?.Street,
                Number = user.Address1?.Number,
                Commune = user.Address1?.Commune,
                Region = user.Address1?.Region,
                PostalCode = user.Address1?.PostalCode,
                RegisteredAt = user.RegisteredAt,
                LastAccess = user.LastAccess,
                IsActive = user.IsActive
            };
        public static AuthenticatedUserDto UserToAuthenticatedDto(User user, string token) =>
            new()
            {
                FirtsName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email ?? string.Empty,
                Thelephone = user.PhoneNumber ?? string.Empty,
                Token = token,
                Street = user.Address1?.Street,
                Number = user.Address1?.Number,
                Commune = user.Address1?.Commune,
                Region = user.Address1?.Region,
                PostalCode = user.Address1?.PostalCode,
                RegisteredAt = user.RegisteredAt,
                LastAccess = user.LastAccess,
                IsActive = user.IsActive
            };
        public static void UpdateUserFromDto(User user, UpdateProfileDto dto)
        {
            user.FirstName = dto.FirtsName;
            user.LastName = dto.LastName;
            user.Thelephone = dto.Phone ?? string.Empty;
        }
    }
}