using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TallerIDWM.Src.DTOs;
using TallerIDWM.Src.DTOs.ShippingAddress;
using TallerIDWM.Src.Models;

namespace TallerIDWM.Src.Mappers
{
    public static class ShippingAddressMapper
    {
        public static ShippingAddress FromDto(CreateShippingAddressDto dto, string userId)
        {
            return new ShippingAddress
            {
                Street = dto.Street,
                Number = dto.Number,
                Commune = dto.Commune,
                Region = dto.Region,
                PostalCode = dto.PostalCode,
                UserId = userId
            };
        }

        public static ShippingAddress ToDto(ShippingAddress shippingAddress)
        {
            return new ShippingAddress
            {
                Street = shippingAddress.Street,
                Number = shippingAddress.Number,
                Commune = shippingAddress.Commune,
                Region = shippingAddress.Region,
                PostalCode = shippingAddress.PostalCode
            };
        }
    }
}