using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerIDWM.src.Dtos
{
    public class UserDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Thelephone { get; set; }
        public required string? Street { get; set; }
        public required string? City { get; set; }
        public required string? commune { get; set; }
        public required string? Region { get; set; }
        public required string? postalCode { get; set; }
        public required string? Id { get; set; }
        public required DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public required bool IsActive { get; set; } = true;
        public required string? UserName { get; set; }
        public required string? Password { get; set; }
    }
}