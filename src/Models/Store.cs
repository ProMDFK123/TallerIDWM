using System.ComponentModel.DataAnnotations;

namespace api.src.Models
{
    public class Store
    {
        [Required]
        [Key]
        public required int Id { get; set; }

        [Required]
        [StringLength(20)]
        public required string Name { get; set; }

        [Required]
        [StringLength(100)]
        public required string Address { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        public List<Product> Products { get; set; } = [];
    }
}