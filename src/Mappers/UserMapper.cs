using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Dtos;
using api.src.Models;

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
    }
}