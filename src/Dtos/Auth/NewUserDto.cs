namespace TallerIDWM.Src.DTOs.Auth
{
    public class NewUserDto
    {
        public required string FirstName { get; set; } = string.Empty;
        public required string LastName { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
    }
}