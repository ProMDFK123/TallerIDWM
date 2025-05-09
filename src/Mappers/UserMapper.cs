using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                PhoneNumber = registerDto.PhoneNumber,
                Address = registerDto.Address,
                City = registerDto.City,
                State = registerDto.State,
                Country = registerDto.Country,
                ZipCode = registerDto.ZipCode
            };
        }
    }
}