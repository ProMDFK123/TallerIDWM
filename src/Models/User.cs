using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Models;
using Microsoft.AspNetCore.Identity;

namespace api.src.Models
{
    public class User : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Thelephone { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow; 
        public DateTime? LastAccess { get; set; } 
        public bool IsActive { get; set; } = true; 
        public string? DeactivationReason { get; set; } 
        public Address1? Address1 { get; set; }
    }
}