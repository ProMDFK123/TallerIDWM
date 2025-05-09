using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Dtos;
using api.src.Models;
using TallerIDWM.src.Dtos;

namespace TallerIDWM.src.Mappers
{
    public class UserMapper
    {
        public User RegisterToUser(RegisterDto registerDto)
        {
            return new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Thelephone = registerDto.PhoneNumber,
            };
        }

        public AuthenticatedUserDto UserToAuthenticatedDto(User user, string token)
        {
            return new AuthenticatedUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Token = token,
                // ... otras propiedades que quieras incluir en la respuesta de autenticación
            };
        }

        public UserDto UserToUserDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Thelephone = user.Thelephone,
                RegisteredAt = user.RegisteredAt,
                IsActive = user.IsActive,
            };
        }
    }
}