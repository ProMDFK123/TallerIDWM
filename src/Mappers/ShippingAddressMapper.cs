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
                UserId = userId,
            };
        }
    }
}
