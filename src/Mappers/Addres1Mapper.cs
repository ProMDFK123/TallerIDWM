using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using api.src.Dtos;
using api.src.Models;

namespace TallerIDWM.src.Mappers
{
    public static class Addres1Mapper
    {
        public static Address1 FromDto(CreateAddres1Dto dto, string userId)
        {
            return new Address1
            {
                Street = dto.Street,
                Number = dto.Number,
                Commune = dto.Commune,
                Region = dto.Region,
                PostalCode = dto.PostalCode,
                UserId = userId
            };
        }
    }
}