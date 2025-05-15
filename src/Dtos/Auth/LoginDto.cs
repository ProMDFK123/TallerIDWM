using System.ComponentModel.DataAnnotations;

namespace TallerIDWM.Src.DTOs.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "El correo no es válido")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        public required string Password { get; set; }
    }
}
