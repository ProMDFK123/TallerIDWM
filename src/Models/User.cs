using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace api.src.Models
{
    public class User : IdentityUser
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Thelephone { get; set; }
        public required string birthdate { get; set; }
        public required string? Address1 { get; set; }
        public required string Role { get; set; }
    }
}