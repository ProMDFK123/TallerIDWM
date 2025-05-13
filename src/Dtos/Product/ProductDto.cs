using System.ComponentModel.DataAnnotations;

namespace TallerIDWM.Src.DTOs.Product
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public string Brand { get; set; } = string.Empty;

        [Required]
        public int Stock { get; set; }

        [Required]
        public List<IFormFile> Images { get; set; } = [];
    }
}
