using System.ComponentModel.DataAnnotations;

namespace api.src.Models
{
    public class User
    {
        [Required]
        [Key]
        public required int Id { get; set; }

        [Required]
        [Key]
        public required int Email { get; set; }

        [Required]
        [StringLength(20)]
        public required string Name { get; set; }

        [Required]
        [StringLength(100)]
        public required string LastName { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public required int PhoneNumber { get; set; }

        [Required]
        public required string BirthDate { get; set; }

        public string? Street { get; set; }
        public int? HouseNumber { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public int? ZipCode { get; set; }
    }
}