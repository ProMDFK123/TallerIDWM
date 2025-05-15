using System.ComponentModel.DataAnnotations;


namespace TallerIDWM.Src.DTOs.User
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "La contraseña actual es obligatoria.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña actual debe tener al menos 8 caracteres.")]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "La contraseña actual debe contener al menos una letra mayúscula, una letra minúscula, un número y un carácter especial."
        )]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "La nueva contraseña es obligatoria.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "La nueva contraseña debe tener al menos 8 caracteres.")]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "La nueva contraseña debe contener al menos una letra mayúscula, una letra minúscula, un número y un carácter especial."
        )]
        public string NewPassword { get; set; } = string.Empty;

        [Compare("NewPassword", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
