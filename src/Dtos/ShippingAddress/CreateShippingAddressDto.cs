using System.ComponentModel.DataAnnotations;

namespace TallerIDWM.Src.DTOs.ShippingAddress
{
    public class CreateShippingAddressDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        public required string Street { get; set; }

        [Required(ErrorMessage = "El número es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Debe ser un valor numérico.")]
        public required string Number { get; set; }

        [Required(ErrorMessage = "La comuna es obligatoria.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "La comuna solo puede contener letras y espacios.")]
        public required string Commune { get; set; }

        [Required(ErrorMessage = "La región es obligatoria.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "La región solo puede contener letras y espacios.")]
        public required string Region { get; set; }

        [Required(ErrorMessage = "El código postal es obligatorio.")]
        [RegularExpression(@"^\d{7}$", ErrorMessage = "El código postal debe tener 7 dígitos.")]
        public required string PostalCode { get; set; }
    }
}
