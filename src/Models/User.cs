using System.ComponentModel.DataAnnotations;

namespace api.src.Models
{
    public class User
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Thelephone { get; set; }
        public required string birthdate { get; set; }
        public required Address1? Address1 { get; set; }
        public required string Role { get; set; }
    }
}