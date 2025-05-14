using Microsoft.AspNetCore.Identity;

namespace TallerIDWM.Src.Models
{
    public class User : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Telephone { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastAccess { get; set; }
        public bool IsActive { get; set; } = true;
        public string? DeactivationReason { get; set; }
        public ShippingAddress? ShippingAddress { get; set; }
    }
}
